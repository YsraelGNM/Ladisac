Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmOrdenSalida

    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCOrdenSalida As Ladisac.BL.IBCOrdenSalida
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCDocu As Ladisac.BL.IBCDocuMovimiento
    <Dependency()> _
    Public Property BCTipoDocumento As Ladisac.BL.IBCTipoDocumento
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro
    <Dependency()> _
    Public Property BCKardex As Ladisac.BL.IBCKardex
    <Dependency()> _
    Public Property BCArticuloAlmacen As Ladisac.BL.IBCArticuloAlmacen

    Protected mOS As OrdenSalida
    Dim mDmo As DocuMovimiento
    Protected mArticuloAlmacen As ArticuloAlmacen

    'Para impresion
    Dim mNuevaPag As Integer
    Dim mIndexItem As Integer
    Dim mCantLinea As Integer


    'ingreso de codigo
    Private Sub frmOrdenSalida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()

        'se llama al procedimiento de paso rapido entre cajas de texto.

        Call validar_longitud()
        Call validacion_desactivacion(False, 1)
        Me.ReportViewer1.RefreshReport()

        txtCodigo.TabIndex = 5
        txtProveedor.TabIndex = 1
        txtResponsable.TabIndex = 2
        dtpFecha.TabIndex = 3
        dgvDetalle.TabIndex = 4

    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mOS = Nothing
        txtCodigo.Text = String.Empty
        txtProveedor.Text = String.Empty
        txtProveedor.Tag = Nothing
        txtResponsable.Text = String.Empty
        txtResponsable.Tag = Nothing
        dtpFecha.Value = Today
        dgvDetalle.Rows.Clear()


        '--------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub txtProveedor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProveedor.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Proveedor"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProveedor.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
            txtProveedor.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
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

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        Select Case dgvDetalle.CurrentCell.ColumnIndex
            Case 1
                frm.Tabla = "EntidadID"
                frm.Tipo = dgvDetalle.CurrentCell.Value
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'ENO_Descripcion
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'ENO_Id
                End If
            Case 4
                frm.Tabla = "ArticuloAlmacen"
                'frm.Art_Id = dgvDetalle.CurrentRow.Cells("ART_ID").Value
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    CargarArticuloAlmacen(frm.dgvLista.CurrentRow.Cells(0).Value)
                    dgvDetalle.CurrentCell.Tag = mArticuloAlmacen.ART_ID 'ART_Id
                    dgvDetalle.CurrentCell.Value = mArticuloAlmacen.Articulos.ART_DESCRIPCION  'ART_Descripcion

                    dgvDetalle.CurrentRow.Cells("ALM_ID_SALIDA").Tag = mArticuloAlmacen.ALM_ID  'ALM_Id
                    dgvDetalle.CurrentRow.Cells("ALM_ID_SALIDA").Value = frm.dgvLista.CurrentRow.Cells(3).Value 'ALM_Descripcion

                End If
        End Select
        frm.Dispose()
    End Sub

    Sub CargarArticuloAlmacen(ByVal ARA_Id As Integer)
        mArticuloAlmacen = BCArticuloAlmacen.ArticuloAlmacenGetById(ARA_Id)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------

        If mOS IsNot Nothing Then

            dgvDetalle.EndEdit()
            mOS.OSA_FECHA = dtpFecha.Value
            mOS.PER_ID_PROVEEDOR = txtProveedor.Tag
            mOS.PER_ID_RESPONSABLE = txtResponsable.Tag
            If IsNumeric(txtDMO_ID.Text) Then If txtDMO_ID.Text > 0 Then mOS.DMO_ID_TFO = txtDMO_ID.Text
            mOS.OSA_ESTADO = True
            mOS.OSA_FEC_GRAB = Now
            mOS.USU_ID = SessionServer.UserId
            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("OSD_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("OSD_ID").Tag, OrdenSalidaDetalle)
                        .ENO_ID = mDetalle.Cells("ENO_ID").Tag
                        .ART_ID = mDetalle.Cells("ART_ID").Tag
                        .OSD_DESCRIPCION = mDetalle.Cells("OSD_DESCRIPCION").Value
                        .TRD_ID = mDetalle.Cells("TRD_ID").Value
                        .OSD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                        .OSD_OBSERVACION = mDetalle.Cells("Observacion").Value
                        .OSD_VUELVE = mDetalle.Cells("Vuelve").Value
                        .OSD_REGRESO = mDetalle.Cells("Regreso").Value
                        .ALM_ID_SALIDA = mDetalle.Cells("ALM_ID_SALIDA").Tag
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("Cantidad").Value Is Nothing Then
                    Dim nOSD As New OrdenSalidaDetalle
                    With nOSD
                        .ENO_ID = IIf(mDetalle.Cells("ENO_Id").Tag Is Nothing, Nothing, CInt(mDetalle.Cells("ENO_Id").Tag))
                        .ART_ID = mDetalle.Cells("ART_Id").Tag
                        .OSD_DESCRIPCION = mDetalle.Cells("OSD_DESCRIPCION").Value
                        .OSD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                        .TRD_ID = mDetalle.Cells("TRD_ID").Value
                        .OSD_OBSERVACION = mDetalle.Cells("Observacion").Value
                        .OSD_VUELVE = mDetalle.Cells("Vuelve").Value
                        .OSD_REGRESO = mDetalle.Cells("Regreso").Value
                        .ALM_ID_SALIDA = mDetalle.Cells("ALM_ID_SALIDA").Tag
                        .MarkAsAdded()
                    End With
                    mOS.OrdenSalidaDetalle.Add(nOSD)
                End If
            Next

            BCOrdenSalida.MantenimientoOrdenSalida(mOS)
            MessageBox.Show(mOS.OSA_ID)
            mOS = BCOrdenSalida.OrdenSalidaGetById(mOS.OSA_ID)

            Procesar()

            If MessageBox.Show("Desea Imprimir la Orden de Salida?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                TabControl1.SelectedIndex = 1
                'OnReportes()
            Else
                LimpiarControles()
                Call validacion_desactivacion(False, 3)
            End If

            '------------------------------------------
        End If
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mOS = New OrdenSalida
        mOS.MarkAsAdded()
        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtProveedor.Focus()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "OrdenSalida"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarOrdenSalida(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarOrdenSalida(ByVal OSA_Id As Integer)
        mOS = BCOrdenSalida.OrdenSalidaGetById(OSA_Id)
        mOS.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mOS.OSA_ID
        dtpFecha.Value = mOS.OSA_FECHA
        txtProveedor.Text = mOS.Personas.PER_NOMBRES & " " & mOS.Personas.PER_APE_PAT
        txtProveedor.Tag = mOS.PER_ID_PROVEEDOR
        txtResponsable.Text = mOS.Personas1.PER_NOMBRES & " " & mOS.Personas1.PER_APE_PAT
        txtResponsable.Tag = mOS.PER_ID_RESPONSABLE
        For Each mItem In mOS.OrdenSalidaDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("OSD_ID").Value = mItem.OSD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("OSD_ID").Tag = mItem
            If mItem.Entidad IsNot Nothing Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Eno_Id").Value = mItem.Entidad.ENO_DESCRIPCION
            If mItem.Entidad IsNot Nothing Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Eno_Id").Tag = mItem.ENO_ID
            If mItem.Articulos IsNot Nothing Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art_Id").Value = mItem.Articulos.ART_Codigo & " - " & mItem.Articulos.ART_DESCRIPCION
            If mItem.Articulos IsNot Nothing Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art_Id").Tag = mItem.ART_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("OSD_DESCRIPCION").Value = mItem.OSD_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TRD_ID").Value = mItem.TRD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value = mItem.OSD_CANTIDAD
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Observacion").Value = mItem.OSD_OBSERVACION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Vuelve").Value = mItem.OSD_VUELVE
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Regreso").Value = mItem.OSD_REGRESO
            If mItem.ALM_ID_SALIDA IsNot Nothing Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID_SALIDA").Tag = mItem.ALM_ID_SALIDA : dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID_SALIDA").Value = mItem.ALM_ID_SALIDA
        Next
    End Sub



    '===================================================================================================================
    '----procedimiento de validaciones
    'tecla enter de paso rapido entre cajas de texto.


    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(txtProveedor.Text.Trim) = 0 Then Error_validacion.SetError(txtProveedor, "Ingrese el Nombre del Proveedor") : txtProveedor.Focus() : flag = False
        If Len(txtResponsable.Text.Trim) = 0 Then Error_validacion.SetError(txtResponsable, "Ingrese el Nombre del Responsable") : txtResponsable.Focus() : flag = False


        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos.
    Private Sub validar_longitud()
        Me.txtProveedor.MaxLength = 160
        Me.txtResponsable.MaxLength = 160
    End Sub

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
        If mOS IsNot Nothing Then
            For Con As Integer = 0 To mOS.OrdenSalidaDetalle.Count - 1
                mOS.OrdenSalidaDetalle(Con).MarkAsDeleted()
            Next
            mOS.MarkAsDeleted()
            BCOrdenSalida.MantenimientoOrdenSalida(mOS)
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

    Public Overrides Sub OnReportes()
        If mOS IsNot Nothing Then
            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    mNuevaPag = 0
                    mIndexItem = 0
                    mCantLinea = 20
                    PrintDocument1.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 1, 5, 5)
                    PrintDocument1.Print()
                Catch ex As Exception
                    MessageBox.Show("No hay impresora activa", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End Try
            End If
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim ft As New System.Drawing.Font("Courier New", 10, FontStyle.Regular)
        Dim ftN As New System.Drawing.Font("Courier New", 10, FontStyle.Bold)

        e.Graphics.DrawString("ORDEN DE SALIDA NRO.: " & mOS.OSA_ID, ftN, Brushes.Black, 50, 30)
        e.Graphics.DrawString("Fecha", ftN, Brushes.Black, 450, 30)
        e.Graphics.DrawString(": " & mOS.OSA_FECHA, ftN, Brushes.Black, 490, 30)

        e.Graphics.DrawString("Proveedor", ftN, Brushes.Black, 50, 50)
        If Not mOS.PER_ID_PROVEEDOR = 0 Then e.Graphics.DrawString(": " & mOS.Personas.DocPersonas(0).DOP_NUMERO & " / " & mOS.Personas.PER_APE_PAT, ft, Brushes.Black, 200, 50)

        e.Graphics.DrawString("Direccion", ftN, Brushes.Black, 50, 70)
        If Not mOS.PER_ID_PROVEEDOR = 0 Then e.Graphics.DrawString(": " & mOS.Personas.DireccionesPersonas(0).DIR_DESCRIPCION, ft, Brushes.Black, 200, 70)

        e.Graphics.DrawString("Responsable", ftN, Brushes.Black, 50, 90)
        e.Graphics.DrawString(": " & mOS.Personas1.PER_APE_PAT, ft, Brushes.Black, 200, 90)

        e.Graphics.DrawLine(Pens.Black, 50, 108, 800, 108)

        e.Graphics.DrawString("Codigo", ftN, Brushes.Black, 50, 108)
        e.Graphics.DrawString("Entidad", ftN, Brushes.Black, 110, 108)
        e.Graphics.DrawString("Articulo", ftN, Brushes.Black, 400, 108)
        e.Graphics.DrawString("Cant.", ftN, Brushes.Black, 700, 108)

        e.Graphics.DrawLine(Pens.Black, 50, 122, 800, 122)

        Dim altu As Integer = -25

        Dim mItem As Object
        If mNuevaPag = 20 Then mNuevaPag = 0
        For mFila = mIndexItem To mOS.OrdenSalidaDetalle.Count - 1
            mItem = mOS.OrdenSalidaDetalle(mFila)
            mNuevaPag += 1
            altu += 16
            'e.Graphics.DrawString("Codigo", ftN, Brushes.Black, 50, 205)
            If mItem.Entidad Is Nothing Then e.Graphics.DrawString("", ft, Brushes.Black, 50, 140 + altu) Else e.Graphics.DrawString(mItem.Entidad.ENO_Id, ft, Brushes.Black, 50, 140 + altu)
            'e.Graphics.DrawString("Descripcion", ftN, Brushes.Black, 50, 225)
            If mItem.Entidad Is Nothing Then e.Graphics.DrawString("", ft, Brushes.Black, 110, 140 + altu) Else e.Graphics.DrawString(mItem.Entidad.ENO_Descripcion.Substring(0, IIf(mItem.Entidad.ENO_Descripcion.Length > 33, 33, mItem.Entidad.ENO_Descripcion.Length)), ft, Brushes.Black, 110, 140 + altu)
            'e.Graphics.DrawString("Unid.", ftN, Brushes.Black, 50, 245)

            If mItem.Articulos Is Nothing Then
                If mItem.Entidad Is Nothing Then e.Graphics.DrawString((mItem.OSD_Descripcion & "").ToString.Substring(0, IIf((mItem.OSD_Descripcion & "").ToString.Length > 38, 38, (mItem.OSD_Descripcion & "").ToString.Length)), ft, Brushes.Black, 400, 140 + altu) Else e.Graphics.DrawString((mItem.OSD_Descripcion & "").ToString.Substring(0, IIf((mItem.OSD_Descripcion & "").ToString.Length > 38, 38, (mItem.OSD_Descripcion & "").ToString.Length)), ft, Brushes.Black, 400, 140 + altu)
            Else
                If mItem.Entidad Is Nothing Then e.Graphics.DrawString(mItem.Articulos.Art_descripcion & (mItem.OSD_Descripcion & "").ToString.Substring(0, IIf((mItem.OSD_Descripcion & "").ToString.Length > 38, 38, (mItem.OSD_Descripcion & "").ToString.Length)), ft, Brushes.Black, 400, 140 + altu) Else e.Graphics.DrawString(mItem.Articulos.Art_descripcion & (mItem.OSD_Descripcion & "").ToString.Substring(0, IIf((mItem.OSD_Descripcion & "").ToString.Length > 38, 38, (mItem.OSD_Descripcion & "").ToString.Length)), ft, Brushes.Black, 400, 140 + altu)
            End If

            e.Graphics.DrawString(Math.Round(CType(mItem.OSD_Cantidad, Double), 2), ft, Brushes.Black, 730, 140 + altu)
            'e.Graphics.DrawString("Cant.", ftN, Brushes.Black, 50, 265)
            If IsNothing(mItem.OSD_Observacion) Then mItem.OSD_Observacion = ""
            If mItem.OSD_Observacion.ToString.Length >= 81 Then
                altu += 16
                e.Graphics.DrawString("Obs.: " & mItem.OSD_Observacion.Substring(0, 81), ft, Brushes.Black, 50, 140 + altu)
                Dim cade As String = ""
                Dim Num As Integer = 168 'Es la cant. de caracteres que voy a imprimir en una linea de la columna observaciones
                For ie As Integer = 81 To mItem.OSD_Observacion.Length - 1
                    If ie < Num Then
                        cade += mItem.OSD_Observacion.Chars(ie)
                    ElseIf ie = Num Then
                        altu += 16
                        e.Graphics.DrawString(cade, ft, Brushes.Black, 50, 140 + altu)
                        cade = ""
                        Num += 87
                        ie -= 1
                    End If
                Next
                If cade.Length > 0 Then
                    altu += 16
                    e.Graphics.DrawString(cade, ft, Brushes.Black, 50, 140 + altu)
                    cade = ""
                End If
            Else
                altu += 16
                e.Graphics.DrawString("Obs.: " & mItem.OSD_Observacion, ft, Brushes.Black, 50, 140 + altu)
            End If

            If mNuevaPag = 50 Then
                e.HasMorePages = True
                mIndexItem = mFila + 1
                Exit For
            Else
                e.HasMorePages = False
            End If
        Next

        e.Graphics.DrawString("ALMACEN", ftN, Brushes.Black, 100, 160 + altu + 90)
        e.Graphics.DrawString("SUPERINTENDENTE MANTTO", ftN, Brushes.Black, 300, 160 + altu + 90)
        e.Graphics.DrawString("RESPONSABLE", ftN, Brushes.Black, 600, 160 + altu + 90)


    End Sub

    Sub Visualizar()
        Try
            If mOS IsNot Nothing Then
                Dim ds As New DataSet
                Dim query = BCOrdenSalida.ImpresionOrdenDeSalida(mOS.OSA_ID)
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
                ReportViewer1.LocalReport.DataSources.Clear()
                ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsImpresionOrdenDeSalida", ds.Tables(0)))
                ReportViewer1.RefreshReport()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Visualizar()
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then txtProveedor_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtResponsable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResponsable.KeyDown
        If e.KeyCode = Keys.Enter Then txtResponsable_DoubleClick(Nothing, Nothing)
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle_CellDoubleClick(sender, Nothing)
        End If
        'Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        'If e.KeyCode = Keys.Enter Then
        '    Select Case dgvDetalle.CurrentCell.ColumnIndex
        '        Case 1
        '            frm.Tabla = "EntidadID"
        '            frm.Tipo = dgvDetalle.CurrentCell.Value
        '            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'ENO_Descripcion
        '                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'ENO_Id
        '            End If
        '        Case 2
        '            frm.Tabla = "ArticuloSumins"
        '            frm.Art_Id = dgvDetalle.CurrentRow.Cells("ART_ID").Value
        '            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
        '                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " - " & frm.dgvLista.CurrentRow.Cells(2).Value 'ART_Descripcion
        '                'dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(3).Value  'UnidadMedida
        '            End If
        '    End Select
        '    e.SuppressKeyPress = True
        '    e.Handled = True
        'End If
        'frm.Dispose()
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        If Not e.Row.Cells("OSD_ID").Value Is Nothing Then
            CType(e.Row.Cells("OSD_ID").Tag, OrdenSalidaDetalle).MarkAsDeleted()
        End If
    End Sub

    Private Sub txtDMO_ID_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDMO_ID.DoubleClick
        Try
            Dim key As Integer = txtDMO_ID.Text
            mDmo = BCDocu.DocuMovimientoGetById(key)
            If mDmo.TFO_ID Is Nothing Then MessageBox.Show("El documento no es una transformacion") : Exit Sub : LimpiarControles()
            If mDmo.DTD_ID <> "196" Then MessageBox.Show("El documento no es una transformacion de salida") : Exit Sub : LimpiarControles() 'Guia de salida
            For Each mitem In mDmo.DocuMovimientoDetalle
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                'If mitem.Entidad IsNot Nothing Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Eno_Id").Value = mitem.Entidad.ENO_DESCRIPCION
                'If mitem.Entidad IsNot Nothing Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Eno_Id").Tag = mitem.ENO_ID
                If mitem.Articulos IsNot Nothing Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art_Id").Value = mitem.Articulos.ART_Codigo & " - " & mitem.Articulos.ART_DESCRIPCION
                If mitem.Articulos IsNot Nothing Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art_Id").Tag = mitem.ART_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TRD_ID").Value = mitem.TRD_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value = mitem.DMD_CANTIDAD
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Observacion").Value = mitem.DMD_GLOSA
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Vuelve").Value = True
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Regreso").Value = False
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Procesar()
        Try

            'Dim mLista = BCDocu.ListaDocuMovimiento("OrSali = " & mOS.OSA_ID.ToString)
            'For Each mItem In mLista.Tables(0).Rows
            '    mDmo = BCDocu.DocuMovimientoGetById(mItem(0))
            '    mDmo.FecOri = mDmo.DMO_FECHA
            '    For Each mFila In mDmo.DocuMovimientoDetalle
            '        mFila.Alm_Ori = mFila.ALM_ID
            '        mFila.Art_Ori = mFila.ART_ID
            '        mFila.Kardex(0).MarkAsDeleted()
            '        mFila.MarkAsDeleted()
            '    Next
            '    mDmo.MarkAsDeleted()
            '    If Not BCDocu.MantenimientoDocuMovimiento(mDmo) = 1 Then
            '        MessageBox.Show("Error al eliminar.")
            '        Err.Raise(&HFFFFFF01, "Error Provocado", "Almacen Cerrado.")
            '    End If
            'Next

            Dim Flag As Boolean = False
            Dim Regreso As Boolean = False
            For Each DetaOS In mOS.OrdenSalidaDetalle
                If DetaOS.ART_ID IsNot Nothing Then
                    Flag = True
                End If
                If DetaOS.OSD_REGRESO = True Then
                    Regreso = True
                End If
            Next

            If Flag Then


                mDmo = New DocuMovimiento
                'With mDmo
                '    .TDO_ID = "039"
                '    .DTD_ID = "062" 'salida
                '    .DMO_SERIE = "0020"
                '    .DMO_NRO = mOS.OSA_ID
                '    .DetalleTipoDocumentos = BCTipoDocumento.TipoDocumentoGetById("062")
                '    .DMO_FECHA = mOS.OSA_FECHA
                '    .DMO_FECHA_DOCUMENTO = mOS.OSA_FECHA
                '    .ORR_ID = Nothing
                '    .PER_ID_PROVEEDOR = mOS.PER_ID_PROVEEDOR
                '    .MON_ID = "001" 'Soles
                '    .OCO_ID = Nothing
                '    .DOCU_AFECTA_KARDEX = True
                '    .SCO_ID = Nothing
                '    .DMO_ASIENTO = Nothing
                '    .DMO_CIERRE = Nothing
                '    .USU_ID = SessionServer.UserId
                '    .DMO_FEC_GRAB = Now
                '    .DMO_ESTADO = True
                '    .CCT_ID = ""
                '    .DMO_ID_REF = Nothing
                '    .DRU_ID = Nothing
                '    .CME_ID = Nothing
                '    .CPA_ID = Nothing
                '    .OSA_ID = mOS.OSA_ID
                'End With

                Dim DocumentacionDeta As New DocuMovimientoDetalle
                'For Each DetaOS In mOS.OrdenSalidaDetalle
                '    If DetaOS.ART_ID IsNot Nothing Then
                '        DocumentacionDeta = New DocuMovimientoDetalle
                '        With DocumentacionDeta
                '            .ALM_ID = DetaOS.ALM_ID_SALIDA
                '            .ART_ID = DetaOS.ART_ID
                '            .DMD_CANTIDAD = DetaOS.OSD_CANTIDAD
                '            .DMD_DESCUENTO = 0
                '            .DMD_PRECIO_UNITARIO = BCKardex.StockCostoPromedio(DetaOS.ART_ID, BCParametro.ParametroGetById("AlmSum").PAR_VALOR1, mOS.OSA_FECHA, 2)
                '            .DMD_IGV = 0
                '            .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                '            .DMD_GLOSA = "Transferencia por Orden Salida."
                '            .ORD_ID = Nothing
                '            .OCD_ID = Nothing
                '            .DMD_ID_REF = Nothing
                '            .OSD_ID = DetaOS.OSD_ID
                '            .ALM_ID_TRANSFERENCIA = BCParametro.ParametroGetById("AlmTransitoSumins").PAR_VALOR1 '179 
                '        End With
                '        mDmo.DocuMovimientoDetalle.Add(DocumentacionDeta)
                '    End If
                'Next

                'If BCDocu.MantenimientoDocuMovimiento(mDmo) = 1 Then
                '    MessageBox.Show(mDmo.DMO_ID)
                'Else
                '    Err.Raise(&HFFFFFF01, "Error Provocado", "Insercion incorrecta.")
                'End If

                If Regreso Then
                    ''Retorno para ingresar a almacen de origen
                    mDmo = New DocuMovimiento
                    With mDmo
                        .TDO_ID = "039"
                        .DTD_ID = "062" 'ingreso
                        .DMO_SERIE = "0020"
                        .DMO_NRO = mOS.OSA_ID
                        .DetalleTipoDocumentos = BCTipoDocumento.TipoDocumentoGetById("062")
                        .DMO_FECHA = Now
                        .DMO_FECHA_DOCUMENTO = mOS.OSA_FECHA
                        .ORR_ID = Nothing
                        .PER_ID_PROVEEDOR = mOS.PER_ID_PROVEEDOR
                        .MON_ID = "001" 'Soles
                        .OCO_ID = Nothing
                        .DOCU_AFECTA_KARDEX = True
                        .SCO_ID = Nothing
                        .DMO_ASIENTO = Nothing
                        .DMO_CIERRE = Nothing
                        .USU_ID = SessionServer.UserId
                        .DMO_FEC_GRAB = Now
                        .DMO_ESTADO = True
                        .CCT_ID = ""
                        .DMO_ID_REF = Nothing
                        .DRU_ID = Nothing
                        .CME_ID = Nothing
                        .CPA_ID = Nothing
                        .OSA_ID = mOS.OSA_ID
                    End With

                    For Each DetaOS In mOS.OrdenSalidaDetalle
                        If DetaOS.ART_ID IsNot Nothing And DetaOS.OSD_REGRESO = True Then
                            DocumentacionDeta = New DocuMovimientoDetalle
                            With DocumentacionDeta
                                .ALM_ID = BCParametro.ParametroGetById("AlmTransitoSumins").PAR_VALOR1 '179 
                                .ART_ID = DetaOS.ART_ID
                                .DMD_CANTIDAD = DetaOS.OSD_CANTIDAD
                                .DMD_DESCUENTO = 0
                                .DMD_PRECIO_UNITARIO = BCKardex.StockCostoPromedio(DetaOS.ART_ID, BCParametro.ParametroGetById("AlmTransitoSumins").PAR_VALOR1, mOS.OSA_FECHA, 2)
                                .DMD_IGV = 0
                                .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                                .DMD_GLOSA = "Ingreso Transferencia por Orden Salida."
                                .ORD_ID = Nothing
                                .OCD_ID = Nothing
                                .DMD_ID_REF = Nothing
                                .OSD_ID = DetaOS.OSD_ID
                                .ALM_ID_TRANSFERENCIA = DetaOS.ALM_ID_SALIDA
                            End With
                            mDmo.DocuMovimientoDetalle.Add(DocumentacionDeta)
                        End If
                    Next
                    If BCDocu.MantenimientoDocuMovimiento(mDmo) = 1 Then
                        MessageBox.Show(mDmo.DMO_ID)
                    Else
                        Err.Raise(&HFFFFFF01, "Error Provocado", "Insercion incorrecta.")
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Existe un Error, verificar Documentos " & ex.Message, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub
End Class
