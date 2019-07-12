Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmRecepcionDocumento
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCRecepcionDocumento As Ladisac.BL.IBCRecepcionDocumento
    <Dependency()> _
    Public Property BCOrdenCompra As Ladisac.BL.IBCOrdenCompra
    <Dependency()> _
    Public Property BCOrdenServicio As Ladisac.BL.IBCOrdenServicio

    Protected mRDO As RecepcionDocumento
    Protected mOC As OrdenCompra
    Protected mOS As OrdenServicio

    Private Sub frmRecepcionDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
        Me.ReportViewer1.RefreshReport()
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mRDO = Nothing
        dgvDetalle.Rows.Clear()
        dgvRecibido.Rows.Clear()

        '--------------------------
        Error_validacion.Clear()
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "DTD_ID"
                frm.Tabla = "TipoDocumentoRecepcion"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'DTD_Descripcion
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value.ToString.Substring(0, 3)  'DTD_Id
                End If
            Case "PER_ID_PROVEEDOR"
                frm.Tabla = "Persona"
                frm.Tipo = "Todo"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'PER_ID
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value   'descripcion
                End If
            Case "PER_ID_RECIBIDO"
                frm.Tabla = "Persona"
                frm.Tipo = "Usuario"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'PER_ID
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(2).Value   'descripcion
                End If
            Case "OCO_ID"
                frm.Tabla = "OrdenCompra"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
                    CargarOrdenCompra(key)
                    dgvDetalle.CurrentCell.Value = mOC.OCO_ID
                    dgvDetalle.CurrentRow.Cells("DTD_ID").Value = mOC.DetalleTipoDocumentos.DTD_DESCRIPCION
                    dgvDetalle.CurrentRow.Cells("DTD_ID").Tag = mOC.DTD_ID
                    dgvDetalle.CurrentRow.Cells("PER_ID_PROVEEDOR").Value = mOC.Personas.PER_APE_PAT & " " & mOC.Personas.PER_APE_MAT & " " & mOC.Personas.PER_NOMBRES
                    dgvDetalle.CurrentRow.Cells("PER_ID_PROVEEDOR").Tag = mOC.PER_ID_PROVEEDOR
                    dgvDetalle.CurrentRow.Cells("RDO_CONCEPTO").Value = mOC.OCO_OBSERVACIONES
                    mOC = Nothing
                End If
            Case "OSE_ID"
                frm.Tabla = "OrdenServicio"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
                    CargarOrdenServicio(key)
                    dgvDetalle.CurrentCell.Value = mOS.OSE_ID
                    dgvDetalle.CurrentRow.Cells("DTD_ID").Value = mOS.DetalleTipoDocumentos.DTD_DESCRIPCION
                    dgvDetalle.CurrentRow.Cells("DTD_ID").Tag = mOS.DTD_ID
                    dgvDetalle.CurrentRow.Cells("PER_ID_PROVEEDOR").Value = mOS.Personas.PER_APE_PAT & " " & mOS.Personas.PER_APE_MAT & " " & mOS.Personas.PER_NOMBRES
                    dgvDetalle.CurrentRow.Cells("PER_ID_PROVEEDOR").Tag = mOS.PER_ID_PROVEEDOR
                    dgvDetalle.CurrentRow.Cells("RDO_CONCEPTO").Value = mOS.OSE_OBSERVACIONES
                    mOS = Nothing
                End If
        End Select
        frm.Dispose()
    End Sub

    Sub CargarOrdenCompra(ByVal OCO_Id As Integer)
        mOC = BCOrdenCompra.OrdenCompraGetById(OCO_Id)
        mOC.MarkAsModified()
    End Sub

    Sub CargarOrdenServicio(ByVal OSE_Id As Integer)
        mOS = BCOrdenServicio.OrdenServicioGetById(OSE_Id)
        mOS.MarkAsModified()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        dgvDetalle.EndEdit()

        For Each mDetalle In dgvDetalle.Rows

            If Not validar_controles(mDetalle) Then Exit Sub

            If Not mDetalle.Cells("RDO_ID").Value Is Nothing Then
                With CType(mDetalle.Cells("RDO_ID").Tag, RecepcionDocumento)
                    .DTD_ID = mDetalle.Cells("DTD_ID").Tag
                    .RDO_SERIE = mDetalle.Cells("RDO_SERIE").Value.ToString.Trim.PadLeft(4, "0")
                    .RDO_NUMERO = mDetalle.Cells("RDO_NUMERO").Value.ToString.Trim.PadLeft(10, "0")
                    .RDO_FECHA_DOCUMENTO = mDetalle.Cells("RDO_FECHA_DOCUMENTO").Value
                    .PER_ID_PROVEEDOR = mDetalle.Cells("PER_ID_PROVEEDOR").Tag
                    .RDO_CONCEPTO = mDetalle.Cells("RDO_CONCEPTO").Value
                    .USU_ID = SessionServer.UserId
                    .RDO_FEC_GRAB = Now
                    .RDO_ESTADO = True
                    .PER_ID_RECIBIDO = mDetalle.Cells("PER_ID_RECIBIDO").Tag
                    .OCO_ID = mDetalle.Cells("OCO_ID").value
                    .OSE_ID = mDetalle.Cells("OSE_ID").value
                    .MarkAsModified()
                End With
                BCRecepcionDocumento.MantenimientoRecepcionDocumento(CType(mDetalle.Cells("RDO_ID").Tag, RecepcionDocumento))
            ElseIf mDetalle.Cells("RDO_ID").Value Is Nothing Then
                Dim nRDO As New RecepcionDocumento
                With nRDO
                    .DTD_ID = mDetalle.Cells("DTD_ID").Tag
                    .RDO_SERIE = mDetalle.Cells("RDO_SERIE").Value.ToString.Trim.PadLeft(4, "0")
                    .RDO_NUMERO = mDetalle.Cells("RDO_NUMERO").Value.ToString.Trim.PadLeft(10, "0")
                    .RDO_FECHA = Now
                    .RDO_FECHA_DOCUMENTO = mDetalle.Cells("RDO_FECHA_DOCUMENTO").Value
                    .PER_ID_PROVEEDOR = mDetalle.Cells("PER_ID_PROVEEDOR").Tag
                    .RDO_CONCEPTO = mDetalle.Cells("RDO_CONCEPTO").Value
                    .USU_ID = SessionServer.UserId
                    .RDO_FEC_GRAB = Now
                    .RDO_ESTADO = True
                    .PER_ID_RECIBIDO = mDetalle.Cells("PER_ID_RECIBIDO").Tag
                    .RDO_RECIBIDO = 0
                    .OCO_ID = mDetalle.Cells("OCO_ID").value
                    .OSE_ID = mDetalle.Cells("OSE_ID").value
                    .MarkAsAdded()
                    BCRecepcionDocumento.MantenimientoRecepcionDocumento(nRDO)
                End With
            End If

        Next
        LimpiarControles()
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        DarRecepcion()
        Call validacion_desactivacion(True, 2)
    End Sub


    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        'LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "RecepcionDocumento"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarRecepcionDocumento(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarRecepcionDocumento(ByVal RDO_Id As Integer)
        mRDO = BCrecepciondocumento.recepciondocumentoGetById(RDO_Id)
        'mRDO.MarkAsModified()
        mRDO.MarkAsAdded()
    End Sub

    Sub LlenarControles()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RDO_ID").Value = mRDO.RDO_ID
        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RDO_ID").Tag = mRDO
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DTD_ID").Value = mRDO.DetalleTipoDocumentos.DTD_DESCRIPCION
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DTD_ID").Tag = mRDO.DTD_ID
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RDO_SERIE").Value = mRDO.RDO_SERIE
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RDO_NUMERO").Value = mRDO.RDO_NUMERO
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RDO_FECHA_DOCUMENTO").Value = mRDO.RDO_FECHA_DOCUMENTO
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PER_ID_PROVEEDOR").Value = mRDO.Personas.PER_APE_PAT & " " & mRDO.Personas.PER_APE_MAT & " " & mRDO.Personas.PER_NOMBRES
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PER_ID_PROVEEDOR").Tag = mRDO.PER_ID_PROVEEDOR
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RDO_CONCEPTO").Value = mRDO.RDO_CONCEPTO
        'If mRDO.Personas1 IsNot Nothing Then
        '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PER_ID_RECIBIDO").Value = mRDO.Personas1.PER_APE_PAT & " " & mRDO.Personas1.PER_APE_MAT & " " & mRDO.Personas1.PER_NOMBRES
        '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PER_ID_RECIBIDO").Tag = mRDO.PER_ID_RECIBIDO
        'End If
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("OCO_ID").Value = mRDO.OCO_ID
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("OSE_ID").Value = mRDO.OSE_ID
    End Sub

    'validamos los campos a llenar
    Function validar_controles(ByVal nRow As DataGridViewRow)
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If nRow.Cells("DTD_ID").Tag Is Nothing Then Error_validacion.SetError(dgvDetalle, "No hay Tipo Documento en la fila.") : dgvDetalle.Focus() : flag = False
        'If Len(txtResponsable.Text.Trim) = 0 Then Error_validacion.SetError(txtResponsable, "Ingrese el Nombre del Responsable") : txtResponsable.Focus() : flag = False


        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'codigos agregados===================================================
    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)
    End Sub

    Public Overrides Sub OnManEditar()
        Call validacion_desactivacion(True, 6)
    End Sub

    Public Overrides Sub OnManCancelarEdicion()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub

    Public Overrides Sub OnManEliminar()
        If mRDO IsNot Nothing Then
            If mRDO.RDO_RECIBIDO = 0 Then
                mRDO.MarkAsDeleted()
                BCRecepcionDocumento.MantenimientoRecepcionDocumento(mRDO)
            End If
        Else
            MsgBox("Solo se puede Eliminar si no ha sido Recepcionado el Documento.")
        End If
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
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

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle_CellDoubleClick(sender, Nothing)
        End If
    End Sub

    Sub DarRecepcion()
        Dim mLista As List(Of RecepcionDocumento)
        mLista = BCRecepcionDocumento.ListaDarRecepcion(SessionServer.Usuario.PER_ID)
        For Each mItem In mLista

            Dim nRow As New DataGridViewRow
            dgvRecibido.Rows.Add(nRow)
            dgvRecibido.Rows(dgvRecibido.Rows.Count - 1).Cells("RDO_ID_1").Value = mItem.RDO_ID
            dgvRecibido.Rows(dgvRecibido.Rows.Count - 1).Cells("RDO_ID_1").Tag = mItem
            dgvRecibido.Rows(dgvRecibido.Rows.Count - 1).Cells("OCO_ID_1").Value = mItem.OCO_ID
            dgvRecibido.Rows(dgvRecibido.Rows.Count - 1).Cells("OSE_ID_1").Value = mItem.OSE_ID
            dgvRecibido.Rows(dgvRecibido.Rows.Count - 1).Cells("DTD_ID_1").Value = mItem.DetalleTipoDocumentos.DTD_DESCRIPCION
            dgvRecibido.Rows(dgvRecibido.Rows.Count - 1).Cells("DTD_ID_1").Tag = mItem.DTD_ID
            dgvRecibido.Rows(dgvRecibido.Rows.Count - 1).Cells("RDO_SERIE_1").Value = mItem.RDO_SERIE
            dgvRecibido.Rows(dgvRecibido.Rows.Count - 1).Cells("RDO_NUMERO_1").Value = mItem.RDO_NUMERO
            dgvRecibido.Rows(dgvRecibido.Rows.Count - 1).Cells("PER_ID_PROVEEDOR_1").Value = mItem.Personas.PER_APE_PAT & " " & mItem.Personas.PER_APE_MAT & " " & mItem.Personas.PER_NOMBRES
            dgvRecibido.Rows(dgvRecibido.Rows.Count - 1).Cells("PER_ID_PROVEEDOR_1").Tag = mItem.PER_ID_PROVEEDOR
            dgvRecibido.Rows(dgvRecibido.Rows.Count - 1).Cells("RDO_CONCEPTO_1").Value = mItem.RDO_CONCEPTO
            dgvRecibido.Rows(dgvRecibido.Rows.Count - 1).Cells("RDO_RECIBIDO_1").Value = False
            dgvRecibido.CurrentCell = dgvRecibido.Rows(dgvRecibido.Rows.Count - 1).Cells("OCO_ID_1")
        Next

    End Sub

    Private Sub btnRecibido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecibido.Click
        dgvRecibido.EndEdit()

        For Each mDetalle In dgvRecibido.Rows
            If mDetalle.Cells("RDO_RECIBIDO_1").Value = True Then

                If Not mDetalle.Cells("RDO_ID_1").Value Is Nothing Then
                    With CType(mDetalle.Cells("RDO_ID_1").Tag, RecepcionDocumento)
                        .RDO_RECIBIDO = 1
                        .RDO_FECHA_RECIBIDO = Now
                        .MarkAsModified()
                    End With
                    BCRecepcionDocumento.MantenimientoRecepcionDocumento(CType(mDetalle.Cells("RDO_ID_1").Tag, RecepcionDocumento))
                End If

            End If
        Next
        LimpiarControles()
        Call validacion_desactivacion(False, 3)
    End Sub

    Private Sub txtProveedor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProveedor.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Todo"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProveedor.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
            txtProveedor.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then txtProveedor_DoubleClick(Nothing, Nothing)
    End Sub


    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            ReportViewer1.LocalReport.DataSources.Clear()

            Dim ds1 As New DataSet
            Dim query1 = BCRecepcionDocumento.ListaReporteSeguimientoDocumento(dtpFechaIni.Value.Date, dtpFechaFin.Value.Date, txtSerie.Text, txtNumero.Text, txtProveedor.Tag, SessionServer.UserId)
            ds1.Merge(query1)
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaReporteSeguimientoDocumento", ds1.Tables(0)))


            ''ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            'Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Anio", cboAnio.Text)
            ''parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
            ''parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            ' '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaReporteSeguimientoDocumento", New DataTable()))
            ReportViewer1.RefreshReport()
        End Try
    End Sub
End Class
