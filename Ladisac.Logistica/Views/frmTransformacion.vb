Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmTransformacion
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCTransformacion As Ladisac.BL.IBCTransformacion

    Protected mTFO As Transformacion

    Private Sub frmTransformacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Dim mDt As DataTable = BCTransformacion.TransformacionxTFO()
        'Dim COUNT As Integer = 0
        'For Each mRow As DataRow In mDt.Rows
        '    mTFO = BCTransformacion.TransformacionGetById(mRow("TFO_ID"))
        '    mTFO.MarkAsModified()
        '    BCTransformacion.MantenimientoTransformacion(mTFO)
        'Next



        LimpiarControles()
        Call validacion_desactivacion(False, 1)

        txtResponsable.TabIndex = 0
        txtObservaciones.TabIndex = 1
        dtpFecha.TabIndex = 2
        cboEstado.TabIndex = 3
        dgvArticulosSalida.TabIndex = 4
        dgvArticulosEntrada.TabIndex = 5

    End Sub

    Private Sub txtResponsable_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResponsable.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtResponsable.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            txtResponsable.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

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
        'hacer
        If mTFO IsNot Nothing Then
            For CONT As Integer = mTFO.TransformacionDetalle.Count - 1 To 0 Step -1
                mTFO.TransformacionDetalle(CONT).MarkAsDeleted()
            Next
            mTFO.MarkAsDeleted()
            BCTransformacion.MantenimientoTransformacion(mTFO)
        End If
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub

    Public Overrides Sub OnManSalir()
        Me.Dispose()
    End Sub
    
    Private Sub dgvArticulosSalida_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArticulosSalida.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        Select Case e.ColumnIndex
            Case 0
                frm.Tabla = "Articulo"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvArticulosSalida.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                    dgvArticulosSalida.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'ART_codigo
                    dgvArticulosSalida.CurrentRow.Cells("Descripcion").Value = frm.dgvLista.CurrentRow.Cells(2).Value
                End If
        End Select
        frm.Dispose()
    End Sub

    Private Sub dgvArticulosEntrada_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArticulosEntrada.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        Select Case e.ColumnIndex
            Case 0
                frm.Tabla = "Articulo"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvArticulosEntrada.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                    dgvArticulosEntrada.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value   'ART_codigo
                    dgvArticulosEntrada.CurrentRow.Cells("Descripcion1").Value = frm.dgvLista.CurrentRow.Cells(2).Value 'descripcion
                End If
            Case 6
                frm.Tabla = "Persona"
                frm.Tipo = "Proveedor"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvArticulosEntrada.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'codigo
                    dgvArticulosEntrada.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value   'descripcion
                End If
        End Select
        frm.Dispose()
    End Sub

    'validamos los campos a llenar
    Function validar_controles()
        Dim flag As Boolean = True

        Error_Validacion.Clear()

        If Len(dtpFecha.Text.Trim) = 0 Then Error_Validacion.SetError(dtpFecha, "Ingrese la Fecha") : dtpFecha.Focus() : flag = False
        If Len(txtResponsable.Text.Trim) = 0 Then Error_validacion.SetError(txtResponsable, "Ingrese el Responsable") : txtResponsable.Focus() : flag = False
        If Len(cboEstado.Text.Trim) = 0 Then Error_validacion.SetError(cboEstado, "Escoja la Importancia") : cboEstado.Focus() : flag = False

        If dgvArticulosSalida.RowCount = 0 Then
            MessageBox.Show("No hay detalle agrege uno.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            flag = False
        End If

        If dgvArticulosEntrada.RowCount = 0 Then
            MessageBox.Show("No hay detalle agrege uno.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            flag = False
        End If

        

        If flag = False Then
            MessageBox.Show("Debe de ingresar datos en los campos seleccionados", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    Public Overrides Sub OnManGuardar()
        dgvArticulosSalida.EndEdit()
        dgvArticulosEntrada.EndEdit()

        If Not validar_controles() Then Exit Sub

        mTFO.TFO_FECHA = dtpFecha.Value
        mTFO.PER_ID_RESPONSABLE = txtResponsable.Tag
        mTFO.TFO_OBSERVACION = txtObservaciones.Text
        mTFO.TFO_ESTADO = True
        mTFO.TFO_FEC_GRAB = Now
        mTFO.USU_ID = SessionServer.UserId

        If cboEstado.Text = "Finalizado" Then mTFO.TFO_ES_PENDIENTE = "F" Else mTFO.TFO_ES_PENDIENTE = "P"

        For Each mDetalle As DataGridViewRow In dgvArticulosSalida.Rows
            If Not mDetalle.Cells("Descripcion").Tag Is Nothing Then
                With CType(mDetalle.Cells("Descripcion").Tag, TransformacionDetalle)
                    .ART_ID = mDetalle.Cells("CodArticulo").Tag
                    .TRD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                    .TRD_CANTIDAD_ATENDIDA = CDec(mDetalle.Cells("CantidadAtendida").Value)
                    .TRD_ES_SALIDA = True
                    .MarkAsModified()
                End With
            Else
                If Not mDetalle.Cells("Cantidad").Value Is Nothing Then
                    Dim nTRD As New TransformacionDetalle
                    With nTRD
                        .ART_ID = mDetalle.Cells("CodArticulo").Tag
                        .TRD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                        .TRD_CANTIDAD_ATENDIDA = CDec(mDetalle.Cells("CantidadAtendida").Value)
                        .TRD_ES_SALIDA = True
                        .MarkAsAdded()
                    End With
                    mTFO.TransformacionDetalle.Add(nTRD)
                End If
            End If


        Next

        For Each mDetalle As DataGridViewRow In dgvArticulosEntrada.Rows
            If Not mDetalle.Cells("Descripcion1").Tag Is Nothing Then
                With CType(mDetalle.Cells("Descripcion1").Tag, TransformacionDetalle)
                    .ART_ID = mDetalle.Cells("CodArticulo1").Tag
                    .TRD_CANTIDAD = CDec(mDetalle.Cells("Cantidad1").Value)
                    .TRD_CANTIDAD_ATENDIDA = CDec(mDetalle.Cells("CantidadAtendida1").Value)
                    .TRD_PU = CDec(mDetalle.Cells("PUServicio").Value)
                    If Not mDetalle.Cells("Proveedor").Tag Is Nothing Then .PER_ID_PROVEEDOR = mDetalle.Cells("Proveedor").Tag
                    .TRD_ES_SALIDA = False
                    .TRD_NRO_DOC = mDetalle.Cells("NroDocServicio").Value
                    .MarkAsModified()
                End With
            Else
                If Not mDetalle.Cells("Cantidad1").Value Is Nothing Then
                    Dim nTRD As New TransformacionDetalle
                    With nTRD
                        .ART_ID = mDetalle.Cells("CodArticulo1").Tag
                        .TRD_CANTIDAD = CDec(mDetalle.Cells("Cantidad1").Value)
                        .TRD_CANTIDAD_ATENDIDA = CDec(mDetalle.Cells("CantidadAtendida1").Value)
                        .TRD_PU = CDec(mDetalle.Cells("PUServicio").Value)
                        If Not mDetalle.Cells("Proveedor").Tag Is Nothing Then .PER_ID_PROVEEDOR = mDetalle.Cells("Proveedor").Tag
                        .TRD_ES_SALIDA = False
                        .TRD_NRO_DOC = mDetalle.Cells("NroDocServicio").Value
                        .MarkAsAdded()
                    End With
                    mTFO.TransformacionDetalle.Add(nTRD)
                End If
            End If


        Next
        BCTransformacion.MantenimientoTransformacion(mTFO)
        MessageBox.Show(mTFO.TFO_ID)
        LimpiarControles()
        Call validacion_desactivacion(False, 3)
    End Sub

    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mTFO = New Transformacion
        mTFO.MarkAsAdded()

        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtResponsable.Focus()

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

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Transformacion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As String = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarTransformacion(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub
    Sub Cargartransformacion(ByVal TFO_ID As Integer)
        mTFO = BCTransformacion.TransformacionGetById(TFO_ID)
        mTFO.MarkAsModified()
    End Sub
    Sub LimpiarControles()
        txtResponsable.Text = String.Empty
        txtResponsable.Tag = Nothing
        txtObservaciones.Text = String.Empty
        txtCodigo.Text = String.Empty
        dtpFecha.Value = Today

        cboEstado.SelectedIndex = 0
        dgvArticulosSalida.Rows.Clear()
        dgvArticulosEntrada.Rows.Clear()
        '--------------------------
        Error_validacion.Clear()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mTFO.TFO_ID
        txtResponsable.Text = mTFO.Personas.PER_APE_PAT & " " & mTFO.Personas.PER_APE_MAT
        txtResponsable.Tag = mTFO.PER_ID_RESPONSABLE
        dtpFecha.Text = mTFO.TFO_FECHA
        txtObservaciones.Text = mTFO.TFO_OBSERVACION

        If mTFO.TFO_ES_PENDIENTE = "P" Then
            cboEstado.SelectedIndex = 0
        Else
            cboEstado.SelectedIndex = 1
        End If
        For Each mItem In mTFO.TransformacionDetalle
            Dim nRow As New DataGridViewRow
            If mItem.TRD_ES_SALIDA = True Then
                dgvArticulosSalida.Rows.Add(nRow)
                dgvArticulosSalida.Rows(dgvArticulosSalida.Rows.Count - 2).Cells("CodArticulo").Value = mItem.Articulos.ART_Codigo
                dgvArticulosSalida.Rows(dgvArticulosSalida.Rows.Count - 2).Cells("CodArticulo").Tag = mItem.ART_ID
                dgvArticulosSalida.Rows(dgvArticulosSalida.Rows.Count - 2).Cells("Descripcion").Value = mItem.Articulos.ART_DESCRIPCION
                dgvArticulosSalida.Rows(dgvArticulosSalida.Rows.Count - 2).Cells("Descripcion").Tag = mItem
                dgvArticulosSalida.Rows(dgvArticulosSalida.Rows.Count - 2).Cells("Cantidad").Value = mItem.TRD_CANTIDAD
                dgvArticulosSalida.Rows(dgvArticulosSalida.Rows.Count - 2).Cells("CantidadAtendida").Value = mItem.TRD_CANTIDAD_ATENDIDA
            Else
                dgvArticulosEntrada.Rows.Add(nRow)
                dgvArticulosEntrada.Rows(dgvArticulosEntrada.Rows.Count - 2).Cells("CodArticulo1").Value = mItem.Articulos.ART_Codigo
                dgvArticulosEntrada.Rows(dgvArticulosEntrada.Rows.Count - 2).Cells("CodArticulo1").Tag = mItem.ART_ID
                dgvArticulosEntrada.Rows(dgvArticulosEntrada.Rows.Count - 2).Cells("Descripcion1").Value = mItem.Articulos.ART_DESCRIPCION
                dgvArticulosEntrada.Rows(dgvArticulosEntrada.Rows.Count - 2).Cells("Descripcion1").Tag = mItem
                dgvArticulosEntrada.Rows(dgvArticulosEntrada.Rows.Count - 2).Cells("Cantidad1").Value = mItem.TRD_CANTIDAD
                dgvArticulosEntrada.Rows(dgvArticulosEntrada.Rows.Count - 2).Cells("CantidadAtendida1").Value = mItem.TRD_CANTIDAD_ATENDIDA
                dgvArticulosEntrada.Rows(dgvArticulosEntrada.Rows.Count - 2).Cells("NroDocServicio").Value = mItem.TRD_NRO_DOC
                dgvArticulosEntrada.Rows(dgvArticulosEntrada.Rows.Count - 2).Cells("PUServicio").Value = mItem.TRD_PU
                dgvArticulosEntrada.Rows(dgvArticulosEntrada.Rows.Count - 2).Cells("Proveedor").Tag = mItem.PER_ID_PROVEEDOR
                If Not mItem.PER_ID_PROVEEDOR Is Nothing Then dgvArticulosEntrada.Rows(dgvArticulosEntrada.Rows.Count - 2).Cells("Proveedor").Value = mItem.Personas.PER_APE_PAT & " " & mItem.Personas.PER_APE_MAT
            End If
        Next
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 And mTFO IsNot Nothing Then
            Try
                If mTFO IsNot Nothing Then
                    Dim ds As New DataSet
                    Dim query = BCTransformacion.ImpresionTransformacion(mTFO.TFO_ID)
                    Dim rea As New StringReader(query)
                    ds.ReadXml(rea)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsImpresionTransformacion", ds.Tables(0)))
                    ReportViewer1.RefreshReport()
                End If

            Catch ex As Exception

            End Try
        End If

    End Sub
    Private Sub txtResponsable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResponsable.KeyDown
        If e.KeyCode = Keys.Enter Then txtResponsable_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub dgvArticulosSalida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvArticulosSalida.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        If e.KeyCode = Keys.Enter And dgvArticulosSalida.CurrentCell.ColumnIndex = 0 Then
            frm.Tabla = "Articulo"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dgvArticulosSalida.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                dgvArticulosSalida.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'ART_codigo
                dgvArticulosSalida.CurrentRow.Cells("Descripcion").Value = frm.dgvLista.CurrentRow.Cells(2).Value
            End If
        End If
        frm.Dispose()
    End Sub

    Private Sub dgvArticulosEntrada_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvArticulosEntrada.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        If e.KeyCode = Keys.Enter Then
            Select Case dgvArticulosEntrada.CurrentCell.ColumnIndex
                Case 0
                    frm.Tabla = "Articulo"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvArticulosEntrada.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                        dgvArticulosEntrada.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value   'ART_codigo
                        dgvArticulosEntrada.CurrentRow.Cells("Descripcion1").Value = frm.dgvLista.CurrentRow.Cells(2).Value 'descripcion
                    End If
                Case 6
                    frm.Tabla = "Persona"
                    frm.Tipo = "Proveedor"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvArticulosEntrada.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'codigo
                        dgvArticulosEntrada.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value   'descripcion
                    End If
            End Select
        End If
        frm.Dispose()
    End Sub

    Private Sub dgvArticulosEntrada_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvArticulosEntrada.UserDeletingRow
        If Not e.Row.Cells("Descripcion1").Tag Is Nothing Then
            CType(e.Row.Cells("Descripcion1").Tag, TransformacionDetalle).MarkAsDeleted()
        End If
    End Sub

    Private Sub dgvArticulosSalida_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvArticulosSalida.UserDeletingRow
        If Not e.Row.Cells("Descripcion").Tag Is Nothing Then
            CType(e.Row.Cells("Descripcion").Tag, TransformacionDetalle).MarkAsDeleted()
        End If
    End Sub
End Class