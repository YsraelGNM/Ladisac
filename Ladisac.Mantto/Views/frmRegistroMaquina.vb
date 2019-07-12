Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmRegistroMaquina
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCRegistroMaquina As Ladisac.BL.IBCRegistroMaquina
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCEntidad As Ladisac.BL.IBCEntidad

    Protected mRegistroMaquina As RegistroMaquina
    Dim query As String
    Dim ds As DataSet

    Private Sub frmPlanMantenimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()

        txtCodigo.TabIndex = 5
        txtEntidad.TabIndex = 1
        numTn.TabIndex = 6
        numDia.TabIndex = 8
        numUso.TabIndex = 10

        Call validacion_desactivacion(False, 1)
    End Sub

    Sub LimpiarControles()
        mRegistroMaquina = Nothing
        dtpFecha.Value = Now
        txtCodigo.Text = String.Empty
        txtEntidad.Text = String.Empty
        txtEntidad.Tag = Nothing
        txtChofer.Text = String.Empty
        txtChofer.Tag = Nothing
        numKilometraje.Value = 0
        numHorometro.Value = 0
        numTn.Value = 0
        numDia.Value = 0
        numUso.Value = 0
        dgvGrupo.Rows.Clear()
        TabControl1_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub txtEntidad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntidad.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Entidad"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtEntidad.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ENO_Id
            txtEntidad.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    Public Overrides Sub OnManEliminar()
        If mRegistroMaquina IsNot Nothing Then
            mRegistroMaquina.MarkAsDeleted()
            BCRegistroMaquina.MantenimientoRegistroMaquina(mRegistroMaquina)
            Call LimpiarControles()
            Call validacion_desactivacion(False, 3)
        End If
    End Sub

    Public Overrides Sub OnManGuardar()
        If TabControl1.SelectedIndex = 0 Then
            ProcesarGuardar()

        Else

            If mRegistroMaquina IsNot Nothing Then
                mRegistroMaquina.ENO_ID = CInt(txtEntidad.Tag)
                mRegistroMaquina.RMA_FECHA = dtpFecha.Value
                mRegistroMaquina.RMA_KILOMETRAJE = numKilometraje.Value
                mRegistroMaquina.RMA_HOROMETRO = numHorometro.Value
                mRegistroMaquina.RMA_TN = numTn.Value
                mRegistroMaquina.RMA_DIA = numDia.Value
                mRegistroMaquina.RMA_USO = numUso.Value
                mRegistroMaquina.PER_ID_CHOFER = txtChofer.Tag
                mRegistroMaquina.RMA_OBSERVACION = txtObservacion.Text
                mRegistroMaquina.RMA_ESTADO = True
                mRegistroMaquina.RMA_FEC_GRAB = Now
                mRegistroMaquina.USU_ID = SessionServer.UserId

                BCRegistroMaquina.MantenimientoRegistroMaquina(mRegistroMaquina)
                MessageBox.Show(mRegistroMaquina.RMA_ID)
                LimpiarControles()
            End If

        End If
        Call validacion_desactivacion(False, 3)
    End Sub

    Sub ProcesarGuardar()
        For Each mRow As DataGridViewRow In dgvGrupo.Rows
            If CDec(mRow.Cells("Kilometraje_Nue").Value) > 0 Then
                If mRegistroMaquina IsNot Nothing Then
                    mRegistroMaquina.ENO_ID = CInt(mRow.Cells("Placa").Tag)
                    mRegistroMaquina.RMA_FECHA = dtpFechaGrupo.Value
                    mRegistroMaquina.RMA_KILOMETRAJE = CDec(mRow.Cells("Kilometraje_Nue").Value)
                    mRegistroMaquina.RMA_HOROMETRO = CDec(mRow.Cells("Horometro_Nue").Value)
                    mRegistroMaquina.RMA_TN = 0
                    mRegistroMaquina.RMA_DIA = 0
                    mRegistroMaquina.RMA_USO = 0
                    mRegistroMaquina.RMA_ESTADO = True
                    mRegistroMaquina.RMA_FEC_GRAB = Now
                    mRegistroMaquina.USU_ID = SessionServer.UserId

                    BCRegistroMaquina.MantenimientoRegistroMaquina(mRegistroMaquina)
                    mRegistroMaquina = New RegistroMaquina
                    mRegistroMaquina.MarkAsAdded()
                End If
            End If
        Next

    End Sub

    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mRegistroMaquina = New RegistroMaquina
        mRegistroMaquina.MarkAsAdded()
        Call validacion_desactivacion(True, 2)
        txtEntidad.Focus()
    End Sub

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "RegistroMaquina"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarRegistroMaquina(key)
            LlenarControles()
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)
    End Sub

    Sub CargarRegistroMaquina(ByVal RMA_Id As Integer)
        mRegistroMaquina = BCRegistroMaquina.RegistroMaquinaGetById(RMA_Id)
        mRegistroMaquina.MarkAsModified()
    End Sub

    Sub LlenarControles()
        dtpFecha.Value = mRegistroMaquina.RMA_FECHA
        txtCodigo.Text = mRegistroMaquina.RMA_ID
        txtEntidad.Tag = mRegistroMaquina.ENO_ID
        txtEntidad.Text = mRegistroMaquina.Entidad.ENO_DESCRIPCION
        txtChofer.Text = mRegistroMaquina.Personas.PER_APE_PAT & " " & mRegistroMaquina.Personas.PER_APE_MAT & " " & mRegistroMaquina.Personas.PER_NOMBRES
        txtChofer.Tag = mRegistroMaquina.PER_ID_CHOFER
        numKilometraje.Value = mRegistroMaquina.RMA_KILOMETRAJE
        numHorometro.Value = mRegistroMaquina.RMA_HOROMETRO
        numTn.Value = mRegistroMaquina.RMA_TN
        numDia.Value = mRegistroMaquina.RMA_DIA
        numUso.Value = mRegistroMaquina.RMA_USO
        txtObservacion.Text = mRegistroMaquina.RMA_OBSERVACION

        mRegistroMaquina.kilometros_Ori = mRegistroMaquina.RMA_KILOMETRAJE
        mRegistroMaquina.Hora_Ori = mRegistroMaquina.RMA_HOROMETRO
        mRegistroMaquina.Tn_Ori = mRegistroMaquina.RMA_TN
        mRegistroMaquina.Dia_Ori = mRegistroMaquina.RMA_DIA
        mRegistroMaquina.Uso_Ori = mRegistroMaquina.RMA_USO
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
            Me.tsbReportes.Enabled = Not op

        End If
    End Sub

    Private Sub txtEntidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntidad.KeyDown
        If e.KeyCode = Keys.Enter Then txtEntidad_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtChofer_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChofer.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtChofer.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            txtChofer.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombre
        End If
        frm.Dispose()
    End Sub

    Private Sub txtChofer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChofer.KeyDown
        txtChofer_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            If BCEntidad IsNot Nothing Then
                Dim ds As New DataSet
                Dim query = BCEntidad.ListaEntidadRegistro
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
                For Each mRow As DataRow In ds.Tables(0).Rows
                    Dim nRow As New DataGridViewRow
                    dgvGrupo.Rows.Add(nRow)
                    dgvGrupo.Rows(dgvGrupo.Rows.Count - 1).Cells("Placa").Tag = mRow("ENO_ID")
                    dgvGrupo.Rows(dgvGrupo.Rows.Count - 1).Cells("Placa").Value = mRow("ENO_DESCRIPCION")
                    dgvGrupo.Rows(dgvGrupo.Rows.Count - 1).Cells("Kilometraje_Ant").Value = mRow("Kilometraje")
                    dgvGrupo.Rows(dgvGrupo.Rows.Count - 1).Cells("Horometro_Ant").Value = mRow("Horometro")
                Next
            End If
        End If
    End Sub

    Private Sub dgvGrupo_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGrupo.CellEndEdit
        CType(sender, DataGridView).CurrentRow.Cells("Kilometro_Total").Value = CDbl(CType(sender, DataGridView).CurrentRow.Cells("Kilometraje_Nue").Value) - CDbl(CType(sender, DataGridView).CurrentRow.Cells("Kilometraje_Ant").Value)
        CType(sender, DataGridView).CurrentRow.Cells("Horometro_Total").Value = CDbl(CType(sender, DataGridView).CurrentRow.Cells("Horometro_Nue").Value) - CDbl(CType(sender, DataGridView).CurrentRow.Cells("Horometro_Ant").Value)
    End Sub
End Class
