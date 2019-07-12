Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms



Public Class frmInventario
    <Dependency()> _
    Public Property BCAlmacen As Ladisac.BL.IBCAlmacen
    <Dependency()> _
    Public Property BCUbicacion As Ladisac.BL.IBCUbicacionAlmacen
    <Dependency()> _
    Public Property BCInventario As Ladisac.BL.IBCInventario
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

    Protected mINV As Inventario
    Dim ds As New DataSet
    Dim col As Integer = 0
    Dim dsReporte As New dsInventario

    Private Sub frmInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarAlmacen(-1, treeAlmacen.Nodes(0))
        CargarUbicacion()
    End Sub

    Public Overrides Sub OnManBuscar()
        dgvDetalle.Rows.Clear()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Inventario"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            dsReporte = New dsInventario
            dtpFecha.Value = frm.dgvLista.Rows(0).Cells("INV_FECHA").Value
            'Dim Fecha As Date = frm.dgvLista.CurrentRow.Cells(7).Value 'Fecha de inventario
            'Dim mCol = BCInventario.InventarioGetById_Fecha(Fecha)
            Dim mCol As New List(Of Inventario)
            Dim mInv As Inventario
            For Each mFila As DataGridViewRow In frm.dgvLista.Rows
                mInv = New Inventario
                mInv = BCInventario.InventarioGetById(mFila.Cells("INV_ID").Value)
                mInv.MarkAsModified()
                mInv.UbicacionAlmacen.MarkAsModified()
                mCol.Add(mInv)
            Next

            Dim mCole = From cC In mCol.AsQueryable Order By cC.UbicacionAlmacen.UBI_DESCRIPCION, cC.Articulos.ART_Codigo Select cC

            For Each mFila In mCole.ToList
                CargarInventario(mFila)
                'Para reporte
                Dim mRow As DataRow
                mRow = dsReporte.Tables(0).NewRow
                mRow.Item("ART_Codigo") = mFila.Articulos.ART_Codigo
                mRow.Item("ART_Descripcion") = mFila.Articulos.ART_DESCRIPCION
                mRow.Item("UM_Descripcion") = mFila.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
                mRow.Item("Ubicacion") = mFila.UbicacionAlmacen.UBI_DESCRIPCION
                mRow.Item("INV_CONTEO") = mFila.INV_CONTEO
                mRow.Item("INV_STOCK") = mFila.INV_STOCK
                mRow.Item("INV_PU") = mFila.INV_PU
                dsReporte.Tables(0).Rows.Add(mRow)
            Next

            Try
                ReportViewer1.LocalReport.DataSources.Clear()
                ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsInventario", dsReporte.Tables(0)))
                'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
                Dim parametro(3) As Microsoft.Reporting.WinForms.ReportParameter
                Dim mChkSaldo As String = IIf(chkSaldo.Checked = True, "1", "0")
                parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Saldo", mChkSaldo)
                parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("Fecha", dtpFecha.Value)
                parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Positivo", chkPositivo.Checked)
                parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Negativo", chkNegativo.Checked)
                'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

                '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
                Me.ReportViewer1.LocalReport.SetParameters(parametro)
                ReportViewer1.RefreshReport()
            Catch ex As Exception

            End Try
        End If
        frm.Dispose()
    End Sub

    Sub CargarInventario(ByVal mInventario As Inventario)
        mInventario.MarkAsModified()
        mInventario.UbicacionAlmacen.MarkAsModified()

        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("INV_ID").Value = mInventario.INV_ID
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("INV_ID").Tag = mInventario
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = mInventario.Articulos.ART_Codigo
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ART_ID").Value = mInventario.Articulos.ART_DESCRIPCION
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ART_ID").Tag = mInventario.ART_ID
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("UM_Descripcion").Value = mInventario.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID").Tag = mItem.Item("ALM_ID")
        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID").Value = mItem.Item("ALM_DESCRIPCION")
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Ubicacion").Tag = mInventario.UBI_ID
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Ubicacion").Value = mInventario.UbicacionAlmacen.UBI_DESCRIPCION
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("INV_STOCK").Value = mInventario.INV_STOCK
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("INV_CONTEO").Value = mInventario.INV_CONTEO
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("INV_PU").Value = mInventario.INV_PU

    End Sub

    Sub CargarAlmacen(ByVal ALM_ID_PADRE As Integer, ByVal mNodePadre As TreeNode)
        'Dim ds As New DataSet
        'Dim query = BCAlmacen.ListaAlmacen
        'Dim rea As New StringReader(query)
        'ds.ReadXml(rea)
        'For Each mItem As DataRow In ds.Tables(0).Rows
        '    Dim nRow As New DataGridViewRow
        '    dgvAlmacen.Rows.Add(nRow)
        '    dgvAlmacen.Rows(dgvAlmacen.Rows.Count - 1).Cells("ALM_IDF").Value = mItem.Item("Codigo")
        '    dgvAlmacen.Rows(dgvAlmacen.Rows.Count - 1).Cells("ALM_DescripcionF").Value = mItem.Item("Descripcion")
        '    dgvAlmacen.Rows(dgvAlmacen.Rows.Count - 1).Cells("MostrarF").Value = False

        '    ' ''''''''''''''''''''''''''''''''
        '    'Dim mNode As New TreeNode
        '    'mNode.Text = mItem.Item("Descripcion")
        '    'mNode.Tag = mItem.Item("Codigo")
        '    'mNode.ToolTipText = mItem.Item("Codigo")
        '    'treeAlmacen.Nodes(0).Nodes.Add(mNode)
        'Next


        For Each mAlmHijo In BCAlmacen.GetByIdPadre(ALM_ID_PADRE)
            ''''''''''''''''''''''''''''''''
            Dim mNode As New TreeNode
            mNode.Text = mAlmHijo.ALM_DESCRIPCION
            mNode.Tag = mAlmHijo.ALM_ID
            mNode.ToolTipText = mAlmHijo.ALM_ID

            'Dim NodPadre = (From mN As TreeNode In treeAlmacen.Nodes Where mN.Tag = ALM_ID_PADRE Select mN).FirstOrDefault
            treeAlmacen.SelectedNode = mNodePadre
            treeAlmacen.SelectedNode.Nodes.Add(mNode)
            CargarAlmacen(mAlmHijo.ALM_ID, mNode)
        Next
    End Sub

    Sub CargarUbicacion()
        dgvUbicacion.Rows.Clear()
        Dim ds As New DataSet
        Dim query = BCUbicacion.ListaUbicacionAlmacen
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)

        Dim dt As DataTable = SelectDataTable(ds.Tables(0), "Descripcion like '" & txtBuscar.Text & "%'")

        For Each mItem As DataRow In dt.Rows
            Dim nRow As New DataGridViewRow
            dgvUbicacion.Rows.Add(nRow)
            dgvUbicacion.Rows(dgvUbicacion.Rows.Count - 1).Cells("UBI_ID").Value = mItem.Item("Codigo")
            dgvUbicacion.Rows(dgvUbicacion.Rows.Count - 1).Cells("UBI_Descripcion").Value = mItem.Item("Descripcion")
            dgvUbicacion.Rows(dgvUbicacion.Rows.Count - 1).Cells("MostrarU").Value = True
        Next
    End Sub

    Private Function CargarListado(ByVal n As TreeNode) As DataSet
        Dim mds As New DataSet
        If n.Checked Then
            For Each mUbi As DataGridViewRow In dgvUbicacion.Rows
                If mUbi.Cells("MostrarU").Value = True Then
                    Dim ds As New DataSet
                    Dim query = BCInventario.ListaAInventariar(dtpFecha.Value.Date, n.Tag, CInt(mUbi.Cells("UBI_ID").Value))
                    If Not query = "" Then
                        Dim rea As New StringReader(query)
                        ds.ReadXml(rea)
                    Else
                        ds.Tables.Add(New DataTable)
                    End If
                    If mds.Tables.Count = 0 Then mds.Merge(ds) Else mds.Tables(0).Merge(ds.Tables(0))
                End If
            Next
        End If
        If mds.Tables.Count = 0 Then mds.Tables.Add(New DataTable)
        For Each nodHijos As TreeNode In n.Nodes
            mds.Tables(0).Merge(CargarListado(nodHijos).Tables(0))
        Next
        Return mds
    End Function

    Private Sub btnCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        dgvDetalle.Rows.Clear()
        Dim mds As New DataSet

        ''Dim ts1 As New TimeSpan(0, 10, 0)
        ''Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

        'For Each mFila As DataGridViewRow In dgvAlmacen.Rows
        '    If mFila.Cells("MostrarF").Value = True Then
        '        For Each mUbi As DataGridViewRow In dgvUbicacion.Rows
        '            If mUbi.Cells("MostrarU").Value = True Then
        '                Dim ds As New DataSet
        '                Dim query = BCInventario.ListaAInventariar(dtpFecha.Value.Date, CInt(mFila.Cells("ALM_IDF").Value), CInt(mUbi.Cells("UBI_ID").Value))
        '                If Not query = "" Then
        '                    Dim rea As New StringReader(query)
        '                    ds.ReadXml(rea)
        '                Else
        '                    ds.Tables.Add(New DataTable)
        '                End If
        '                If mds.Tables.Count = 0 Then mds.Merge(ds) Else mds.Tables(0).Merge(ds.Tables(0))
        '            End If
        '        Next
        '    End If
        'Next

        ''    Scope.Complete()
        ''End Using
        mds = CargarListado(treeAlmacen.Nodes(0))

        Dim Lista1 = From mDT As DataRow In mds.Tables(0).Rows _
                     Order By mDT.Item("UBI_DESCRIPCION"), mDT.Item("ART_CODIGO") _
                     Group mDT By ArtiId = mDT.Item("ART_ID"), ArtiCodigo = mDT.Item("ART_CODIGO"), ArtiDescripcion = mDT.Item("ART_DESCRIPCION"), ArtiUM = mDT.Item("UM_DESCRIPCION"), ArtiUbicacion = mDT.Item("UBI_DESCRIPCION"), UbiId = mDT.Item("UBI_ID") _
                     Into Gpr = Group _
                     Select ArtiId, ArtiCodigo, ArtiDescripcion, ArtiUM, ArtiUbicacion, UbiId, Stock = Gpr.Sum(Function(mDT) CDec(mDT.Item("Stock"))), CostoPromedio = Gpr.Average(Function(mDT) CDec(mDT.Item("PU")))
        'Select ArtiId, ArtiCodigo, ArtiDescripcion, ArtiUM, ArtiUbicacion, UbiId, Stock = Gpr.Sum(Function(mDT) CDec(mDT.Item("Stock"))), CostoPromedio = Gpr.Sum(Function(mDT) CDec(mDT.Item("Stock")) * CDec(mDT.Item("PU")))

        For Each mItem In Lista1.ToList
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = mItem.ArtiCodigo
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ART_ID").Tag = mItem.ArtiId
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ART_ID").Value = mItem.ArtiDescripcion
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("UM_Descripcion").Value = mItem.ArtiUM
            'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID").Tag = mItem.Item("ALM_ID")
            'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID").Value = mItem.Item("ALM_DESCRIPCION")
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("INV_STOCK").Value = mItem.Stock
            'If mItem.Stock > 0 Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("INV_PU").Value = mItem.CostoPromedio / mItem.Stock Else dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("INV_PU").Value = 0
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("INV_PU").Value = mItem.CostoPromedio
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Ubicacion").Value = mItem.ArtiUbicacion
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Ubicacion").Tag = mItem.UbiId
        Next

        dsReporte = New dsInventario
        For Each mItem In Lista1.ToList
            Dim mRow As DataRow
            mRow = dsReporte.Tables(0).NewRow
            mRow.Item("ART_Codigo") = mItem.ArtiCodigo
            mRow.Item("ART_Descripcion") = mItem.ArtiDescripcion
            mRow.Item("UM_Descripcion") = mItem.ArtiUM
            mRow.Item("Ubicacion") = mItem.ArtiUbicacion
            mRow.Item("INV_STOCK") = mItem.Stock
            'If mItem.Stock > 0 Then mRow.Item("INV_PU") = mItem.CostoPromedio / mItem.Stock Else mRow.Item("INV_PU") = 0
            mRow.Item("INV_PU") = mItem.CostoPromedio
            dsReporte.Tables(0).Rows.Add(mRow)
        Next

        Try
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsInventario", dsReporte.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(3) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Saldo", "")
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("Fecha", dtpFecha.Value)
            parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Positivo", chkPositivo.Checked)
            parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Negativo", chkNegativo.Checked)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))


            'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler


            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try

    End Sub

    'Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
    '    e.DataSources.Add(New ReportDataSource("dsInventario", dsReporte.Tables(0)))
    'End Sub



    Public Overrides Sub OnManGuardar()
        dgvDetalle.EndEdit()
        Dim colInventario As New List(Of Inventario)
        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
            If mDetalle.Cells("INV_ID").Value IsNot Nothing Then
                'If mDetalle.Cells("Codigo").Tag = True Then
                With CType(mDetalle.Cells("INV_ID").Tag, Inventario)
                    .ART_ID = mDetalle.Cells("ART_ID").Tag
                    '.ALM_ID = CInt(mDetalle.Cells("ALM_ID").Tag)
                    .UBI_ID = CInt(mDetalle.Cells("Ubicacion").Tag)
                    .INV_STOCK = CDbl(mDetalle.Cells("INV_STOCK").Value)
                    .INV_CONTEO = CDbl(mDetalle.Cells("INV_CONTEO").Value)
                    .INV_PU = CDbl(mDetalle.Cells("INV_PU").Value)
                    '.INV_FECHA = dtpFecha.Value.Date
                    .INV_ESTADO = True
                    .INV_FEC_GRAB = Now
                    .USU_ID = SessionServer.UserId
                    .MarkAsModified()

                End With
                BCInventario.MantenimientoInventario(CType(mDetalle.Cells("INV_ID").Tag, Inventario))
                'End If
                'colInventario.Add(CType(mDetalle.Cells("INV_ID").Tag, Inventario))
            Else

                If mDetalle.Cells("ART_ID").Value <> "" Then
                    mINV = New Inventario
                    With mINV
                        .ART_ID = mDetalle.Cells("ART_ID").Tag
                        '.ALM_ID = CInt(mDetalle.Cells("ALM_ID").Tag)
                        .UBI_ID = CInt(mDetalle.Cells("Ubicacion").Tag)
                        .INV_STOCK = CDbl(mDetalle.Cells("INV_STOCK").Value)
                        .INV_CONTEO = CDbl(mDetalle.Cells("INV_CONTEO").Value)
                        .INV_PU = CDbl(mDetalle.Cells("INV_PU").Value)
                        .INV_FECHA = dtpFecha.Value.Date
                        .INV_ESTADO = True
                        .INV_FEC_GRAB = Now
                        .USU_ID = SessionServer.UserId
                        .MarkAsAdded()
                        'BCInventario.MantenimientoInventario(mINV)
                    End With
                    colInventario.Add(mINV)

                End If
            End If
        Next
        BCInventario.MantenimientoInventarioMassive(colInventario)
        dgvDetalle.Rows.Clear()
    End Sub


    Private Sub ReportViewer1_ReportRefresh(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ReportViewer1.ReportRefresh
        Dim parametro(3) As Microsoft.Reporting.WinForms.ReportParameter
        Dim mChkSaldo As String = IIf(chkSaldo.Checked = True, "1", "0")
        parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Saldo", mChkSaldo)
        parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("Fecha", dtpFecha.Value)
        parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Positivo", chkPositivo.Checked)
        parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Negativo", chkNegativo.Checked)

        '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
        Me.ReportViewer1.LocalReport.SetParameters(parametro)
    End Sub

    'Sub dgvDetalle_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    If dgvDetalle.IsCurrentCellDirty Then
    '        dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit)
    '    End If
    'End Sub


    'Private Sub dgvDetalle_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellValueChanged
    '    dgvDetalle_CurrentCellDirtyStateChanged(Nothing, Nothing)
    'End Sub

    ' '' ''Private Sub dgvDetalle_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.RowEnter
    ' '' ''    If dgvDetalle.CurrentRow IsNot Nothing Then dgvDetalle.CurrentRow.Cells("Codigo").Tag = True
    ' '' ''End Sub

    Private Sub chkUbicaciones_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkUbicaciones.CheckedChanged
        For Each mItem As DataGridViewRow In dgvUbicacion.Rows
            mItem.Cells("MostrarU").Value = chkUbicaciones.Checked
        Next
    End Sub

    Private Sub treeAlmacen_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeAlmacen.AfterCheck
        SelecNode(e.Node)
    End Sub

    Public Sub SelecNode(ByVal Node As TreeNode)
        For Each mNod As TreeNode In Node.Nodes
            mNod.Checked = Node.Checked
            SelecNode(mNod)
        Next
    End Sub


    'PARA FILTRAR UBICACIONES
    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        CargarUbicacion()
    End Sub

    Public Shared Function SelectDataTable(ByVal dt As DataTable, ByVal filter As String) As DataTable
        Dim dtNew As DataTable
        Try
            dtNew = dt.Clone()
            dtNew = dt.Select(filter).CopyToDataTable
        Catch ex As Exception

        End Try
        Return dtNew
    End Function
End Class
