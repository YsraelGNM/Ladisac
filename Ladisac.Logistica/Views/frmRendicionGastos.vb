Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing

Public Class frmRendicionGastos
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCRendicionGastos As Ladisac.BL.IBCRendicionGastos
    <Dependency()>
    Public Property BCPermisoUsuario As Ladisac.BL.BCPermisoUsuario
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro
    <Dependency()> _
    Public Property BCOrdenTrabajo As Ladisac.BL.IBCOrdenTrabajo

    Public mRGA As RendicionGastos
    Dim mOT As OrdenTrabajo

    Private Sub frmRendicionGastos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If mRGA IsNot Nothing Then
            If mRGA.RGA_ID > 0 Then LlenarControles()
            Totales()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        Else
            LimpiarControles()
            Call validacion_desactivacion(False, 1)
        End If

    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mRGA = Nothing
        txtCodigo.Text = String.Empty
        txtSolicitado.Text = SessionServer.UserName
        txtSolicitado.Tag = SessionServer.Usuario.PER_ID
        txtOT.Text = String.Empty
        txtOT.Tag = Nothing
        dgvDetalle.Rows.Clear()

        '--------------------------
        Error_Validacion.Clear()
    End Sub

    Private Sub txtSolicitado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSolicitado.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtSolicitado.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            txtSolicitado.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtSolicitado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSolicitado.KeyDown
        If e.KeyCode = Keys.Enter Then txtSolicitado_DoubleClick(Nothing, Nothing)
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        Totales()
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        If Not e.Row.Cells("RGD_ID").Tag Is Nothing Then
            CType(e.Row.Cells("RGD_ID").Tag, RendicionGastosDetalle).MarkAsDeleted()
        End If
        Totales()
    End Sub



    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        dgvDetalle.EndEdit()

        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------

        If mRGA IsNot Nothing Then
            mRGA.RGA_FECHA = dtpFecha.Value
            mRGA.PER_ID = txtSolicitado.Tag
            mRGA.OTR_ID = txtOT.Tag
            mRGA.RGA_ESTADO = True
            mRGA.RGA_FEC_GRAB = Now
            mRGA.USU_ID = SessionServer.UserId

            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("RGD_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("RGD_ID").Tag, RendicionGastosDetalle)
                        .RGD_FECHA = mDetalle.Cells("RGD_FECHA").Value
                        .RGD_MOTIVO = mDetalle.Cells("RGD_MOTIVO").Value
                        .RGD_ORIGEN = mDetalle.Cells("RGD_ORIGEN").Value
                        .RGD_DESTINO = mDetalle.Cells("RGD_DESTINO").Value
                        .RGD_MONTO = CDec(mDetalle.Cells("RGD_MONTO").Value)
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("RGD_MOTIVO").Value Is Nothing Then
                    Dim nRGD As New RendicionGastosDetalle
                    With nRGD
                        .RGD_FECHA = mDetalle.Cells("RGD_FECHA").Value
                        .RGD_MOTIVO = mDetalle.Cells("RGD_MOTIVO").Value
                        .RGD_ORIGEN = mDetalle.Cells("RGD_ORIGEN").Value
                        .RGD_DESTINO = mDetalle.Cells("RGD_DESTINO").Value
                        .RGD_MONTO = CDec(mDetalle.Cells("RGD_MONTO").Value)
                        .MarkAsAdded()
                    End With
                    mRGA.RendicionGastosDetalle.Add(nRGD)
                End If
            Next

            If BCRendicionGastos.MantenimientoRendicionGastos(mRGA) = 1 Then
                MessageBox.Show(mRGA.RGA_ID)
                mRGA = BCRendicionGastos.RendicionGastosGetById(mRGA.RGA_ID)
                OnReportes()
                LimpiarControles()
            Else
                MessageBox.Show("Error al insertar.")
                LimpiarControles()
                Exit Sub
            End If

            '------------------------------------------
            Call validacion_desactivacion(False, 3)
        End If
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mRGA = New RendicionGastos
        mRGA.MarkAsAdded()
        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtSolicitado.Focus()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "RendicionGastos"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarRendicionGastos(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)

        End If
        frm.Dispose()
    End Sub

    Sub CargarRendicionGastos(ByVal RGA_Id As Integer)
        mRGA = BCRendicionGastos.RendicionGastosGetById(RGA_Id)
        mRGA.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mRGA.RGA_ID
        dtpFecha.Value = mRGA.RGA_FECHA
        txtSolicitado.Text = mRGA.Personas.PER_APE_PAT & " " & mRGA.Personas.PER_APE_MAT
        txtSolicitado.Tag = mRGA.PER_ID
        txtOT.Text = mRGA.OTR_ID
        txtOT.Tag = mRGA.OTR_ID

        For Each mItem In mRGA.RendicionGastosDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RGD_ID").Value = mItem.RGD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RGD_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RGD_FECHA").Value = mItem.RGD_FECHA
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RGD_MOTIVO").Value = mItem.RGD_MOTIVO
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RGD_ORIGEN").Value = mItem.RGD_ORIGEN
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RGD_DESTINO").Value = mItem.RGD_DESTINO
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RGD_MONTO").Value = mItem.RGD_MONTO
        Next
        Totales()
        '''''Para saber quien lo hizo
        Dim Hecho As Usuarios
        Hecho = BCPermisoUsuario.UsuarioGetById(mRGA.USU_ID)
        lblHecho.Text = "Hecho por: " & Hecho.USU_DESCRIPCION
    End Sub

    'validamos los campos a llenar
    Function validar_controles()
        Dim flag As Boolean = True
        Dim mes As Integer

        Error_Validacion.Clear()

        If Len((txtSolicitado.Tag & "").Trim) = 0 Then Error_Validacion.SetError(txtSolicitado, "Ingrese el Nombre de la Persona Solicitante") : txtSolicitado.Focus() : flag = False
        If Len((txtOT.Tag & "").Trim) = 0 Then Error_Validacion.SetError(txtOT, "Ingrese el Codigo de la O.T.") : txtOT.Focus() : flag = False

        If dgvDetalle.RowCount = 0 Then
            MessageBox.Show("No hay detalle agrege uno.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            flag = False
        Else
            mes = CDate(dgvDetalle.Rows(0).Cells("RGD_FECHA").Value).Month
        End If

        For Each mItem As DataGridViewRow In dgvDetalle.Rows
            If CDate(dgvDetalle.Rows(0).Cells("RGD_FECHA").Value).Month <> mes Then
                MessageBox.Show("Los gastos deben corresponder al mismo mes.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                flag = False
            End If
        Next

        Dim Lista1 = From mGrid As DataGridViewRow In dgvDetalle.Rows Group mGrid By Fecha = mGrid.Cells("RGD_FECHA").Value Into Gpr = Group _
       Select Fecha, Monto = Gpr.Sum(Function(mgrid) CDec(mgrid.Cells("RGD_MONTO").Value))

        Dim MontoPorDia = BCParametro.ParametroGetById("MontoMovilidadXDia").PAR_VALOR1
        For Each mItem In Lista1.ToList
            If mItem.Monto > MontoPorDia Then
                MessageBox.Show("Se ha superado el gasto maximo por dia, establecido en S/. " & MontoPorDia.ToString, "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                flag = False
            End If
        Next


        If flag = False Then
            MessageBox.Show("Debe de ingresar datos en los campos seleccionados", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function


    'codigos agregados===================================================
    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)

    End Sub

    Public Overrides Sub OnManEliminar()
        If Not validar_controles() Then Exit Sub
        mRGA.RGA_ESTADO = 0
        mRGA.MarkAsModified()
        If BCRendicionGastos.MantenimientoRendicionGastos(mRGA) = 1 Then
            Call LimpiarControles()
            Call validacion_desactivacion(False, 7)
        Else
            MessageBox.Show("Error al Anular.")
            Exit Sub
        End If

    End Sub

    Public Overrides Sub OnManSalir()
        Me.Dispose()
    End Sub

    'valida controles desactivacion
    Sub validacion_desactivacion(ByVal op As Boolean, ByVal flag As Integer)
        'datos a tener en cuenta
        '1=load
        '2=nuevo
        '3=guardar
        '4=DeshacerCambios
        '5=buscar
        '6=editar
        '7=deshacer,eliminar

        If flag = 1 Or flag = 3 Or flag = 4 Or flag = 7 Then

            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbNuevo.Enabled = Not op
            Me.tsbBuscar.Enabled = Not op
            Me.tsbSalir.Enabled = Not op
            Me.tscPosicion.Enabled = Not op
            Me.tsbReportes.Enabled = Not op


        ElseIf flag = 2 Or flag = 6 Then 'evento nuevo registro
            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = Not op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbGrabar.Enabled = op
            Me.TsbGrabarNuevo.Enabled = op
            Me.tsbDeshacer.Enabled = op
            Me.tsbAgregar.Enabled = op
            Me.tsbQuitar.Enabled = op

        ElseIf flag = 5 Then 'evento buscar/editar
            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbNuevo.Enabled = Not op
            Me.tsbEditar.Enabled = Not op
            Me.tsbCancelarEditar.Enabled = Not op

        End If
    End Sub

    Private Sub txtOT_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOT.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        Dim Her = ContainerService.Resolve(Of Herramientas)()
        frm.Tabla = "OrdenTrabajoOR"
        frm.Tipo = IIf(txtOT.Text = "", Nothing, txtOT.Text)
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            mOT = BCOrdenTrabajo.OrdenTrabajoGetById(key)
            If Her.PermisoEntidad(mOT.ENO_ID) = False Then MsgBox("No le corresponde esta Area.") : frm.Dispose() : Exit Sub
            txtOT.Text = frm.dgvLista.CurrentRow.Cells(0).Value  'OTR_Id
            txtOT.Tag = CInt(frm.dgvLista.CurrentRow.Cells(0).Value)  'OTR_Id
        End If
    End Sub

    Private Sub txtOT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOT.KeyDown
        If e.KeyCode = Keys.Enter Then txtOT_DoubleClick(Nothing, Nothing)
    End Sub

    Public Overrides Sub OnReportes()
        If mRGA IsNot Nothing Then
            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Dim ds As New dsImpresionRendicionGastos
                    Dim rpt As New rptRendicionGastos

                    Dim dt As DataTable = BCRendicionGastos.ImprimirRendicionGastos(mRGA.RGA_ID)
                    ds.Tables(0).Merge(dt)
                    rpt.SetDataSource(ds.Tables(0))
                    rpt.PrintToPrinter(PrintDialog1.PrinterSettings, PrintDialog1.PrinterSettings.DefaultPageSettings, False)
                Catch ex As Exception
                    MessageBox.Show("No hay impresora activa", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End Try
            End If
        End If
    End Sub

    Sub Totales()
        txtTotal.Text = Math.Round(dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToDouble(row.Cells("RGD_MONTO").Value)), 2)
    End Sub

    Private Sub txtOT_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOT.KeyUp
        If txtOT.Text.Length > 0 Then
            If Not IsNumeric(txtOT.Text) Then
                txtOT.Text = String.Empty
            End If
        End If
    End Sub
End Class
