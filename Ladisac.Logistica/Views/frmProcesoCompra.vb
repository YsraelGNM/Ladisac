Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmProcesoCompra
    <Dependency()> _
      Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCArticulos As Ladisac.BL.IBCArticulo
    <Dependency()> _
    Public Property BCArticulosAlma As Ladisac.BL.IBCArticuloAlmacen
    <Dependency()> _
    Public Property BCResponsable As Ladisac.BL.IBCPersona
    <Dependency()> _
    Public Property BCProcesoCompra As Ladisac.BL.IBCProcesoCompra
    <Dependency()> _
    Public Property BCOrdenCompra As Ladisac.BL.IBCOrdenCompra
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro
    <Dependency()> _
    Public Property BCOrdenRequerimiento As Ladisac.BL.IBCOrdenRequerimiento
    <Dependency()> _
    Public Property BCSolicitudCompra As Ladisac.BL.IBCSolicitudCompra

    Protected mProcesoC As ProcesoCompra
    Dim col As Integer = -1
    Dim colC As Integer = -1
    Dim colR As Integer = -1
    Dim ds As New DataSet
    Dim dsR As New DataSet

    Dim frmInputBox As New frmInputBox

    Private Sub frmProcesoCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListaProcesoCompraAConsolidar()
        txtBuscarAConsolidar.Focus()
        AddHandler dgvCotizacion.CellValueChanged, AddressOf LastColumnComboSelectionChanged
    End Sub

    Sub ListaProcesoCompraAConsolidar()
        Try
            ds = New DataSet
            Dim query = BCProcesoCompra.ListaProcesoCompraAConsolidar(SessionServer.UserId)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            dgvDetalle.DataSource = ds.Tables(0)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnConsolidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolidar.Click
        ListaProcesoCompraAConsolidar()
        txtBuscarAConsolidar_TextChanged(Nothing, Nothing)
        dgvDetalleConsolidar.Rows.Clear()
        Dim Lista1 = From mGrid As DataGridViewRow In dgvDetalle.Rows Group mGrid By ArtiId = mGrid.Cells("ART_ID").Value, ArtiCodigo = mGrid.Cells("ART_CODIGO").Value, ArtiDescripcion = mGrid.Cells("ART_DESCRIPCION").Value Into Gpr = Group _
        Select ArtiId, ArtiCodigo, ArtiDescripcion, Cantidad = Gpr.Sum(Function(mgrid) CDec(mgrid.Cells("ORD_CANTIDAD_COMPRA").Value)), TotalEstimado = Gpr.Average(Function(mgrid) CDec(mgrid.Cells("PRECIO").Value)), Stock = Gpr.Sum(Function(mgrid) CDec(mgrid.Cells("STOCK").Value))

        For Each mItem In Lista1.ToList
            dgvDetalleConsolidar.Rows.Add(mItem.ArtiCodigo, mItem.ArtiDescripcion, CType(mItem.Cantidad, Decimal), CType(mItem.Stock, Decimal), 0, CType(mItem.Cantidad, Decimal) * CType(mItem.TotalEstimado, Decimal), String.Empty, False, String.Empty, String.Empty, mItem.ArtiId, Date.Now)
        Next

        For Each mItem As DataGridViewRow In dgvDetalleConsolidar.Rows
            For Each mFila As DataGridViewRow In dgvDetalle.Rows
                If mItem.Cells("CodArticulo").Value = mFila.Cells("ART_CODIGO").Value Then
                    mItem.Cells("Observacion1").Value = mItem.Cells("Observacion1").Value & " / " & mFila.Cells("ord_observacion").Value
                End If
            Next
        Next

    End Sub

    Private Sub dgvDetalleConsolidar_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleConsolidar.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        Select Case CType(sender, DataGridView).Columns(e.ColumnIndex).Name
            Case "ResponsableSinCotizacion"
                frm.Tabla = "Persona"
                frm.Tipo = "Compras"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalleConsolidar.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PER_Id
                    dgvDetalleConsolidar.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'Nombres
                    dgvDetalleConsolidar.CurrentRow.Cells("Cotizacion").Value = False
                    dgvDetalleConsolidar.CurrentRow.Cells("Responsable").Value = String.Empty
                    dgvDetalleConsolidar.CurrentRow.Cells("Responsable").Tag = Nothing
                End If
            Case "Responsable"
                frm.Tabla = "Persona"
                frm.Tipo = "Compras"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalleConsolidar.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                    dgvDetalleConsolidar.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'Codigo + ART_Descripcion
                    dgvDetalleConsolidar.CurrentRow.Cells("Cotizacion").Value = True
                    dgvDetalleConsolidar.CurrentRow.Cells("ResponsableSinCotizacion").Value = String.Empty
                    dgvDetalleConsolidar.CurrentRow.Cells("ResponsableSinCotizacion").Tag = Nothing
                End If
        End Select

    End Sub

    Public Overrides Sub OnManGuardar()
        Select Case TabControl1.SelectedIndex
            Case 0
                dgvDetalle.EndEdit()
                mProcesoC = New ProcesoCompra
                mProcesoC.MarkAsAdded()

                Dim dt As New DataTable
                dt.Columns.Add("ORD_ID")
                dt.Columns.Add("SCD_ID")
                dt.Columns.Add("ART_ID")

                If mProcesoC IsNot Nothing Then

                    mProcesoC.PRC_ESTADO = True
                    mProcesoC.PRC_FEC_GRAB = Now
                    mProcesoC.PRC_FECHA = Today
                    mProcesoC.USU_ID = SessionServer.UserId
                    For Each mDetalle As DataGridViewRow In dgvDetalleConsolidar.Rows
                        If Not mDetalle.Cells("CodArticulo").Value Is Nothing Then
                            If mDetalle.Cells("Cant").Value > 0 And (mDetalle.Cells("ResponsableSinCotizacion").Value.ToString.Length > 0 Or mDetalle.Cells("Responsable").Value.ToString.Length > 0) Then
                                Dim nDMD As New ProcesoCompraDetalle
                                With nDMD
                                    .ART_ID = mDetalle.Cells("ART_ID").Value
                                    .PCD_CANT_SOLICITADA = CDec(mDetalle.Cells("CantSolicitada").Value)
                                    .PCD_STOCK = CDec(mDetalle.Cells("Stock").Value)
                                    .PCD_CANT_COMPRADA = 0 'CDec(mDetalle.Cells("Cant").Value)
                                    .PCD_CANT = CDec(mDetalle.Cells("Cant").Value) 'CDec(mDetalle.Cells("CantSolicitada").Value) - CDec(mDetalle.Cells("Cant").Value)
                                    .USU_ID_CONSERGE = mDetalle.Cells("ResponsableSinCotizacion").Tag
                                    .PCD_ES_COTIZACION = mDetalle.Cells("Cotizacion").Value
                                    .USU_ID_COTIZACION = mDetalle.Cells("Responsable").Tag
                                    .PCD_FECHA = Today
                                    .PCD_OBS = mDetalle.Cells("Observacion1").Value
                                    .PCD_COTIZANDO = False
                                    .PCD_FECHA_COTIZANDO = Nothing
                                    .PCD_OBS_COTIZANDO = String.Empty
                                    .PCD_RESPUESTA_COTIZANDO = False
                                    .PCD_FECHA_RESPUESTA_COTIZANDO = Nothing
                                    .PCD_OBS_RESPUESTA_COTIZANDO = String.Empty
                                    .PCD_REQUIERE_VB_SOLICITANTE = False
                                    .PCD_FECHA_RVBS = Nothing
                                    .PCD_OBS_RVBS = String.Empty
                                    .PCD_VB_SOLICITANTE = False
                                    .PCD_FECHA_VBS = Nothing
                                    .PCD_OBS_VBS = String.Empty
                                    .PCD_REQUIERE_VB_GERENCIA = False
                                    .PCD_FECHA_RVBG = Nothing
                                    .PCD_OBS_RVBG = String.Empty
                                    .PCD_VB_GERENCIA = False
                                    .PCD_FECHA_VBG = Nothing
                                    .PCD_OBS_VBG = String.Empty
                                    .OCD_ID = Nothing
                                    mProcesoC.ProcesoCompraDetalle.Add(nDMD)

                                    Dim nRow As DataRow
                                    For Each mFila In dgvDetalle.Rows
                                        If mFila.cells("ART_ID").value = nDMD.ART_ID Then
                                            nRow = dt.NewRow
                                            If mFila.cells("Tipo").value = "OR" Then
                                                nRow("ORD_ID") = mFila.cells("ORD_ID").value
                                                nRow("ART_ID") = mFila.cells("ART_ID").value
                                            Else
                                                nRow("SCD_ID") = mFila.cells("ORD_ID").value
                                                nRow("ART_ID") = mFila.cells("ART_ID").value
                                            End If
                                            dt.Rows.Add(nRow)
                                        End If
                                    Next

                                End With
                            End If
                        End If
                    Next

                    BCProcesoCompra.MantenimientoProcesoCompra(mProcesoC, dt)
                End If
                txtBuscarAConsolidar.Text = String.Empty
                txtBuscarConsolidado.Text = String.Empty
                btnConsolidar_Click(Nothing, Nothing)

            Case 1
                dgvConserje.EndEdit()
                For Each mC In dgvConserje.Rows
                    If mC.Cells("Aprobado").Value = True Then
                        CType(mC.Cells("CodArticulo1").Tag, ProcesoCompraDetalle).PCD_VB_GERENCIA = mC.Cells("Aprobado").Value
                        CType(mC.Cells("CodArticulo1").Tag, ProcesoCompraDetalle).PCD_FECHA_VBG = Date.Now
                        'CType(mC.Cells("CodArticulo1").Tag, ProcesoCompraDetalle).PCD_OBS_VBG = "."

                        CType(mC.Cells("CodArticulo1").Tag, ProcesoCompraDetalle).MarkAsModified()
                        BCProcesoCompra.MantenimientoProcesoCompraDetalle(CType(mC.Cells("CodArticulo1").Tag, ProcesoCompraDetalle))

                    ElseIf mC.Cells("Rechazado").Value = True Then

                        CType(mC.Cells("CodArticulo1").Tag, ProcesoCompraDetalle).MarkAsDeleted()
                        BCProcesoCompra.MantenimientoProcesoCompraDetalle(CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle))
                    End If
                Next
                btnListaConserje_Click(Nothing, Nothing)
            Case 2
                dgvCotizacion.EndEdit()
                For Each mC In dgvCotizacion.Rows
                    If mC.Cells("VBGerencia").Value = True And CType(mC.cells("CodArticulo2").tag, ProcesoCompraDetalle).OCD_ID > 0 Then
                        If mC.Cells("ObsVBG").Value.ToString.Length = 0 Then
                            MessageBox.Show("No ha ingresado una observacion en VB Gerencia. Se cancelara el guardado")
                            Exit Sub
                        End If
                    End If
                Next

                If SessionServer.UserId <> "ADMIN" Then
                    If frmInputBox.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If Not frmInputBox.txtPassword.Text = BCParametro.ParametroGetById(SessionServer.UserId & "PC").PAR_VALOR1 Then
                            MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
                        Exit Sub
                    End If
                End If

                For Each mC In dgvCotizacion.Rows

                    If mC.Cells("Cotizando2").Value = True And mC.Cells("HuboRespuesta").Value = False Then

                        CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_COTIZANDO = mC.Cells("Cotizando2").Value
                        CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_FECHA_COTIZANDO = Date.Now
                        CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_OBS_COTIZANDO = mC.Cells("ObsCotizando").Value
                        'If mC.Cells("ObsCotizando").Value.ToString.Length = 0 Then
                        '    MessageBox.Show("No ha ingresado una observacion en Cotizando. Se cancelara el guardado")
                        '    Exit Sub
                        'End If
                        CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).MarkAsModified()
                        BCProcesoCompra.MantenimientoProcesoCompraDetalle(CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle))

                        'ElseIf mC.Cells("Cotizando2").Value = True And mC.Cells("HuboRespuesta").Value = True And mC.Cells("RequiereVBSolicitante").Value = False And mC.Cells("RequiereVBGerencia").Value = False Then

                        '    CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_RESPUESTA_COTIZANDO = mC.Cells("HuboRespuesta").Value
                        '    CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_FECHA_RESPUESTA_COTIZANDO = Date.Now
                        '    CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_OBS_RESPUESTA_COTIZANDO = mC.Cells("ObsRespuesta").Value
                        '    If mC.Cells("ObsRespuesta").Value.ToString.Length = 0 Then
                        '        MessageBox.Show("No ha ingresado una observacion en Respuesta. Se cancelara el guardado")
                        '        Exit Sub
                        '    End If
                        '    CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).MarkAsModified()
                        '    BCProcesoCompra.MantenimientoProcesoCompraDetalle(CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle))

                        'ElseIf mC.Cells("Cotizando2").Value = True And mC.Cells("HuboRespuesta").Value = True And mC.Cells("RequiereVBSolicitante").Value = True And mC.Cells("VBSolicitante").Value = False Then

                        '    CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_REQUIERE_VB_SOLICITANTE = mC.Cells("RequiereVBSolicitante").Value
                        '    CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_FECHA_RVBS = Date.Now
                        '    CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_OBS_RVBS = mC.Cells("ObsRVBS").Value
                        '    If mC.Cells("ObsRVBS").Value.ToString.Length = 0 Then
                        '        MessageBox.Show("No ha ingresado una observacion en Requiere VB Solicitante. Se cancelara el guardado")
                        '        Exit Sub
                        '    End If
                        '    CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).MarkAsModified()
                        '    BCProcesoCompra.MantenimientoProcesoCompraDetalle(CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle))

                        'ElseIf mC.Cells("Cotizando2").Value = True And mC.Cells("HuboRespuesta").Value = True And mC.Cells("RequiereVBGerencia").Value = True And mC.Cells("VBGerencia").Value = False Then

                        '    CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_REQUIERE_VB_GERENCIA = mC.Cells("RequiereVBGerencia").Value
                        '    CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_FECHA_RVBG = Date.Now
                        '    CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_OBS_RVBG = mC.Cells("ObsRVBG").Value
                        '    If mC.Cells("ObsRVBG").Value.ToString.Length = 0 Then
                        '        MessageBox.Show("No ha ingresado una observacion en Requiere VB Gerencia. Se cancelara el guardado")
                        '        Exit Sub
                        '    End If
                        '    CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).MarkAsModified()
                        '    BCProcesoCompra.MantenimientoProcesoCompraDetalle(CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle))

                    End If

                    If mC.Cells("VBGerencia").Value = True Then

                        CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_VB_GERENCIA = mC.Cells("VBGerencia").Value
                        CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_FECHA_VBG = Date.Now
                        CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCD_OBS_VBG = mC.Cells("ObsVBG").Value

                        CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).MarkAsModified()
                        BCProcesoCompra.MantenimientoProcesoCompraDetalle(CType(mC.Cells("CodArticulo2").Tag, ProcesoCompraDetalle))
                    End If

                Next

                CargarDetalleProcesoCompraCotizacion()
        End Select
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 2 Then
            CargarDetalleProcesoCompraCotizacion()
        End If
        If TabControl1.SelectedIndex = 1 Then
            CargarDetalleProcesoCompraSinCotizacion()
        End If

        If TabControl1.SelectedIndex = 3 Then
            Try
                dsR = New DataSet
                Dim query = BCProcesoCompra.ListaProcesoCompraResumen
                Dim rea As New StringReader(query)
                dsR.ReadXml(rea)
                dgvResumen.DataSource = dsR.Tables(0)
                'DataGrid1.DataSource = dsAutores.Tables(0)
                'ReportViewer1.LocalReport.DataSources.Clear()
                'ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsImpresionProcesoCompraResumen", ds.Tables(0)))
                'ReportViewer1.RefreshReport()
            Catch ex As Exception
            End Try
        End If
    End Sub


    Sub CargarDetalleProcesoCompraCotizacion()
        Try
            dgvCotizacion.Rows.Clear()
            Dim ds As New DataSet
            Dim query = BCProcesoCompra.ListaProcesoCompraCotizacion(SessionServer.UserId)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)

            For Each mItem In ds.Tables(0).Rows
                Dim nRow As New DataGridViewRow
                Dim mPCD As New ProcesoCompraDetalle
                Dim mOCO As New OrdenCompraDetalle
                mPCD = BCProcesoCompra.ProcesoCompraDetalleGetById(mItem("PCD_ID"))
                dgvCotizacion.Rows.Add(nRow)
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("CodArticulo2").Value = mItem("PRC_ID") & " " & mItem("ART_Codigo")
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("CodArticulo2").Tag = mPCD
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("Descripcion2").Value = mItem("ART_DESCRIPCION")
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("Cant2").Value = mItem("PCD_CANT")
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("Cotizando2").Value = CBool(mItem("PCD_COTIZANDO"))
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("ObsCotizando").Value = mItem("PCD_OBS_COTIZANDO")
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("HuboRespuesta").Value = CBool(mItem("PCD_RESPUESTA_COTIZANDO"))
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("ObsRespuesta").Value = mItem("PCD_OBS_RESPUESTA_COTIZANDO")
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("RequiereVBSolicitante").Value = CBool(mItem("PCD_REQUIERE_VB_SOLICITANTE"))
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("ObsRVBS").Value = mItem("PCD_OBS_RVBS")
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("VBSolicitante").Value = CBool(mItem("PCD_VB_SOLICITANTE"))
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("ObsVBS").Value = mItem("PCD_OBS_VBS")
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("RequiereVBGerencia").Value = CBool(mItem("PCD_REQUIERE_VB_GERENCIA"))
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("ObsRVBG").Value = mItem("PCD_OBS_RVBG")
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("VBGerencia").Value = CBool(mItem("PCD_VB_GERENCIA"))
                dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("ObsVBG").Value = mItem("PCD_OBS_VBG")
                If mPCD.OCD_ID IsNot Nothing Then
                    mOCO = BCOrdenCompra.OrdenCompraDetalleGetById(mPCD.OCD_ID)
                    dgvCotizacion.Rows(dgvCotizacion.Rows.Count - 1).Cells("OCO_ID").Value = mOCO.OCO_ID
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub CargarDetalleProcesoCompraSinCotizacion()
        Try
            dgvConserje.Rows.Clear()
            Dim ds As New DataSet
            Dim query = BCProcesoCompra.ListaProcesoCompraSinCotizacion(SessionServer.UserId, dtpFechaConserje.Value)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)

            For Each mItem In ds.Tables(0).Rows
                Dim nRow As New DataGridViewRow
                Dim mPCD As New ProcesoCompraDetalle
                mPCD = BCProcesoCompra.ProcesoCompraDetalleGetById(mItem("PCD_ID"))
                dgvConserje.Rows.Add(nRow)
                dgvConserje.Rows(dgvConserje.Rows.Count - 1).Cells("CodArticulo1").Value = mItem("PRC_ID") & " " & mItem("ART_Codigo")
                dgvConserje.Rows(dgvConserje.Rows.Count - 1).Cells("CodArticulo1").Tag = mPCD
                dgvConserje.Rows(dgvConserje.Rows.Count - 1).Cells("Descripcion1").Value = mItem("ART_DESCRIPCION")
                dgvConserje.Rows(dgvConserje.Rows.Count - 1).Cells("UM").Value = mItem("UM_SIMBOLO")
                dgvConserje.Rows(dgvConserje.Rows.Count - 1).Cells("CantidadSolicitada").Value = mItem("PCD_CANT")
                dgvConserje.Rows(dgvConserje.Rows.Count - 1).Cells("Conserge").Value = mItem("USU_ID_CONSERGE")
                dgvConserje.Rows(dgvConserje.Rows.Count - 1).Cells("Conserge").Tag = mItem("USU_ID_CONSERGE")
                'dgvConserge.Rows(dgvConserge.Rows.Count - 1).Cells("Conserge").Value = mPCD.personas


            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnGenerarOC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerarOC.Click
        Try
            Dim flag As Boolean = False
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmOrdenCompra)()

            For Each item In dgvCotizacion.Rows
                If item.Cells("OC").Value = True Then
                    frm.mPCDE.Add(CType(item.Cells("CodArticulo2").Tag, ProcesoCompraDetalle))
                    flag = True
                Else
                    item.Cells("OC").Value = False
                End If
            Next

            If flag Then
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                End If
                CargarDetalleProcesoCompraCotizacion()
            End If

            frm.Dispose()

        Catch ex As Exception
            MessageBox.Show("Existe un Error, verificar datos " & ex.Message, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub dgvdetalle_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
        col = e.ColumnIndex
    End Sub

    Private Sub txtBuscarAConsolidar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarAConsolidar.KeyDown
        If col = -1 Then col = 0
        If e.KeyCode = Keys.Down Then
            If dgvDetalle.CurrentRow.Index + 1 < dgvDetalle.Rows.Count - 1 Then dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.CurrentRow.Index + 1).Cells(col)
        ElseIf e.KeyCode = Keys.Up Then
            If dgvDetalle.CurrentRow.Index - 1 > -1 Then dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.CurrentRow.Index - 1).Cells(col)
        ElseIf e.KeyCode = Keys.Left Then
            If Not col = 0 Then col = col - 1
            dgvDetalle.CurrentCell = dgvDetalle.CurrentRow.Cells(col)
        ElseIf e.KeyCode = Keys.Right Then
            If Not col = dgvDetalle.ColumnCount - 1 Then col = col + 1
            dgvDetalle.CurrentCell = dgvDetalle.CurrentRow.Cells(col)
        End If
    End Sub

    Private Sub txtBuscarAConsolidar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarAConsolidar.TextChanged
        If ds.Tables.Count = 0 Then Exit Sub
        If col = -1 Then col = 0
        dgvDetalle.DataSource = SelectDataTable(ds.Tables(0), dgvDetalle.Columns(col).Name & " like '%" & txtBuscarAConsolidar.Text & "%'")
        If txtBuscarAConsolidar.Text = "" Then dgvDetalle.DataSource = ds.Tables(0)
        If dgvDetalle.Rows.Count > 0 Then dgvDetalle.CurrentCell = dgvDetalle.Rows(0).Cells(col)
    End Sub

    Public Shared Function SelectDataTable(ByVal dt As DataTable, ByVal filter As String) As DataTable
        Dim rows As DataRow()
        Dim dtNew As DataTable

        dtNew = dt.Clone()
        rows = dt.Select(filter)
        For Each dr As DataRow In rows
            dtNew.ImportRow(dr)
        Next

        Return dtNew
    End Function

    '''''''''''''''''''''''''''''''''''''''''''
    Private Sub dgvdetalleconsolidar_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleConsolidar.CellClick
        colC = e.ColumnIndex
    End Sub

    Private Sub txtBuscarConsolidado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarConsolidado.KeyDown
        If e.KeyCode = Keys.Down Then
            If dgvDetalleConsolidar.CurrentRow.Index + 1 < dgvDetalleConsolidar.Rows.Count - 1 Then dgvDetalleConsolidar.CurrentCell = dgvDetalleConsolidar.Rows(dgvDetalleConsolidar.CurrentRow.Index + 1).Cells(colC)
        ElseIf e.KeyCode = Keys.Up Then
            If dgvDetalleConsolidar.CurrentRow.Index - 1 > -1 Then dgvDetalleConsolidar.CurrentCell = dgvDetalleConsolidar.Rows(dgvDetalleConsolidar.CurrentRow.Index - 1).Cells(colC)
        End If
    End Sub

    Private Sub txtBuscarConsolidado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarConsolidado.TextChanged
        If colC = -1 Then colC = 0
        For Each row As DataGridViewRow In dgvDetalleConsolidar.Rows
            If row.Cells(0).Value IsNot Nothing Then
                If row.Cells(colC).Value.ToString.ToLower.Contains(txtBuscarConsolidado.Text.ToLower) Then
                    row.Visible = True
                Else
                    row.Visible = False
                End If
            End If

        Next
    End Sub

    Private Sub dgvResumen_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResumen.CellClick
        colR = e.ColumnIndex
    End Sub

    Private Sub txtBuscarResumen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarResumen.KeyDown
        If e.KeyCode = Keys.Down Then
            If dgvResumen.CurrentRow.Index + 1 < dgvResumen.Rows.Count - 1 Then dgvResumen.CurrentCell = dgvResumen.Rows(dgvResumen.CurrentRow.Index + 1).Cells(colR)
        ElseIf e.KeyCode = Keys.Up Then
            If dgvResumen.CurrentRow.Index - 1 > -1 Then dgvResumen.CurrentCell = dgvResumen.Rows(dgvResumen.CurrentRow.Index - 1).Cells(colR)
        End If
    End Sub

    Private Sub txtBuscarResumen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarResumen.TextChanged
        If colR = -1 Then colR = 0
        dgvResumen.DataSource = SelectDataTableResumen(dsR.Tables(0), dgvResumen.Columns(colR).Name & " like '%" & txtBuscarResumen.Text & "%'")
        If txtBuscarResumen.Text = "" Then dgvResumen.DataSource = dsR.Tables(0)
        If dgvResumen.Rows.Count > 0 Then dgvResumen.CurrentCell = dgvResumen.Rows(0).Cells(colR)
    End Sub

    Public Shared Function SelectDataTableResumen(ByVal dt As DataTable, ByVal filter As String) As DataTable
        Dim rows As DataRow()
        Dim dtNew As DataTable

        dtNew = dt.Clone()
        rows = dt.Select(filter)
        For Each dr As DataRow In rows
            dtNew.ImportRow(dr)
        Next

        Return dtNew
    End Function

    Private Sub dgvDetalleConsolidar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalleConsolidar.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        If e.KeyCode = Keys.Enter Then
            Select Case CType(sender, DataGridView).Columns(dgvDetalleConsolidar.CurrentCell.ColumnIndex).Name
                Case "ResponsableSinCotizacion"
                    frm.Tabla = "Persona"
                    frm.Tipo = "Compras"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalleConsolidar.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PER_Id
                        dgvDetalleConsolidar.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'Nombres
                        dgvDetalleConsolidar.CurrentRow.Cells("Cotizacion").Value = False
                        dgvDetalleConsolidar.CurrentRow.Cells("Responsable").Value = String.Empty
                        dgvDetalleConsolidar.CurrentRow.Cells("Responsable").Tag = Nothing
                    End If
                Case "Responsable"
                    frm.Tabla = "Persona"
                    frm.Tipo = "Compras"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalleConsolidar.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                        dgvDetalleConsolidar.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'Codigo + ART_Descripcion
                        dgvDetalleConsolidar.CurrentRow.Cells("Cotizacion").Value = True
                        dgvDetalleConsolidar.CurrentRow.Cells("ResponsableSinCotizacion").Value = String.Empty
                        dgvDetalleConsolidar.CurrentRow.Cells("ResponsableSinCotizacion").Tag = Nothing
                    End If
            End Select
        End If
    End Sub

    Private Sub LastColumnComboSelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        If dgvCotizacion.CurrentCell.OwningColumn.Name = "gerente" Then
            dgvCotizacion.CurrentRow.Cells("ObsVBG").Value = dgvCotizacion.CurrentCell.Value
        End If
    End Sub

    Private Sub dgvCotizacion_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCotizacion.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmOrdenCompra)()
        Select Case CType(sender, DataGridView).Columns(e.ColumnIndex).Name
            Case "OCO_ID"
                frm.mOC = BCOrdenCompra.OrdenCompraGetById(dgvCotizacion.CurrentRow.Cells("OCO_ID").Value)
                frm.mOC.MarkAsModified()
                frm.mModiFromPC = True
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    frm.Dispose()
                    CargarDetalleProcesoCompraCotizacion()
                End If
        End Select
    End Sub

    Private Sub dgvCotizacion_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCotizacion.CellEndEdit
        Select Case dgvCotizacion.CurrentCell.OwningColumn.Name
            Case "OC"
                If (dgvCotizacion.CurrentRow.Cells("OCO_ID").Value & "").ToString.Length > 0 Then
                    dgvCotizacion.CurrentRow.Cells("OC").Value = False
                End If
            Case "VBGerencia"
                If (dgvCotizacion.CurrentRow.Cells("OCO_ID").Value & "").ToString.Length = 0 Then dgvCotizacion.CurrentCell.Value = False
                For Each mFila In dgvCotizacion.Rows
                    If mFila.cells("OCO_ID").value = dgvCotizacion.CurrentRow.Cells("OCO_ID").Value And (dgvCotizacion.CurrentRow.Cells("OCO_ID").Value & "").ToString.Length > 0 Then
                        mFila.cells("VBGerencia").value = dgvCotizacion.CurrentCell.Value
                    End If
                Next
        End Select
    End Sub

    Private Sub DevolverInicio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DevolverInicio.Click
        For Each mItem As DataGridViewRow In dgvCotizacion.Rows
            If mItem.Selected Then
                If Not mItem.Cells("CodArticulo2").Tag Is Nothing Then
                    If CType(mItem.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).OCD_ID IsNot Nothing Then
                        Dim mOCD As OrdenCompraDetalle
                        mOCD = BCOrdenCompra.OrdenCompraDetalleGetById(CType(mItem.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).OCD_ID)
                        If mOCD.OCD_CANTIDAD_INGRESADA > 0 Then
                            MessageBox.Show("No se puede devolver al inicio, porque la Orden de Compra ya fue ingresada")
                            Exit Sub
                        End If
                        mOCD.MarkAsDeleted()
                        BCOrdenCompra.MantenimientoOrdenCompraDetalle(mOCD)
                    End If
                    CType(mItem.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).MarkAsDeleted()
                    BCProcesoCompra.MantenimientoProcesoCompraDetalle(CType(mItem.Cells("CodArticulo2").Tag, ProcesoCompraDetalle))
                End If
            End If
        Next
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub DevolverInicioParaComprar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DevolverInicioParaComprar.Click
        For Each mItem As DataGridViewRow In dgvDetalle.Rows
            If mItem.Selected Then
                If mItem.Cells("TIPO").Value = "OR" Then
                    Dim mORD As OrdenRequerimientoDetalle
                    mORD = BCOrdenRequerimiento.OrdenRequerimientoDetalleGetById(mItem.Cells("ORD_ID").Value)
                    mORD.MarkAsModified()
                    mORD.ORD_ESTADO_COMPRA = Nothing
                    BCOrdenRequerimiento.MantenimientoOrdenRequerimientoDetalle(mORD)
                Else
                    Dim mSCD As SolicitudCompraDetalle
                    mSCD = BCSolicitudCompra.SolicitudCompraDetalleGetById(mItem.Cells("ORD_ID").Value)
                    mSCD.MarkAsModified()
                    mSCD.SCD_ESTADO_COMPRA = Nothing
                    BCSolicitudCompra.MantenimientoSolicitudCompraDetalle(mSCD)
                End If
            End If
        Next
        ListaProcesoCompraAConsolidar()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim Her As New Herramientas
        Her.excelExportar(Her.ToTable(dgvResumen, "lista"))
    End Sub

    Private Sub btnExpoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpoExcel.Click
        Dim Her As New Herramientas
        Her.excelExportar(Her.ToTable(dgvDetalle, "Comprar"))
    End Sub

    Private Sub btnSolicitarCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSolicitarCotizacion.Click
        Try
            Dim frm = Me.ContainerService.Resolve(Of frmMail)()
            frm.txtAsunto.Text = "Cotizacion"
            For Each item In dgvCotizacion.Rows
                If item.Cells("Cotizando2").Value = True Then
                    frm.txtCuerpo.Text = frm.txtCuerpo.Text & "* " & item.Cells("Descripcion2").value & "   X   " & Math.Round(CDec(CType(item.Cells("CodArticulo2").TAG, ProcesoCompraDetalle).PCD_CANT), 2) & "..." & CType(item.Cells("CodArticulo2").TAG, ProcesoCompraDetalle).Articulos.UnidadMedidaArticulos.UM_SIMBOLO & vbCrLf & Chr(13) & Chr(10)
                End If
            Next

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each item As DataGridViewRow In dgvCotizacion.Rows
                    If item.Cells("Cotizando2").Value = True Then
                        CType(item.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCDCotizacionDetalle = New Ladisac.BE.TrackableCollection(Of PCDCotizacionDetalle)
                        CType(item.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).MarkAsModified()
                        For Each mProv As DataGridViewRow In frm.dgvDetalle.Rows
                            Dim mPro As New PCDCotizacionDetalle
                            mPro.MarkAsAdded()
                            mPro.PER_ID_PROVEEDOR = mProv.Cells("razonsocial").Tag
                            CType(item.Cells("CodArticulo2").Tag, ProcesoCompraDetalle).PCDCotizacionDetalle.Add(mPro)
                            BCProcesoCompra.MantenimientoProcesoCompraDetalle(CType(item.Cells("CodArticulo2").Tag, ProcesoCompraDetalle))
                        Next
                    End If
                Next
            End If

            frm.Dispose()
            OnManGuardar()
        Catch ex As Exception
            MessageBox.Show("Existe un Error, verificar datos " & ex.Message, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub dgvConserge_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConserje.CellEndEdit
        If dgvConserje.Columns(e.ColumnIndex).Name = "Rechazado" Then
            If dgvConserje.CurrentCell.Value = True Then
                dgvConserje.CurrentRow.Cells("Aprobado").Value = False
            End If
        ElseIf dgvConserje.Columns(e.ColumnIndex).Name = "Aprobado" Then
            If dgvConserje.CurrentCell.Value = True Then
                dgvConserje.CurrentRow.Cells("Rechazado").Value = False
            End If
        End If
    End Sub

    Private Sub btnListaConserje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListaConserje.Click
        If TabControl2.TabIndex = 0 Then
            CargarDetalleProcesoCompraSinCotizacion()
        Else
            Visualizar()
        End If
    End Sub

    Sub Visualizar()
        Try
            'Impresion
            Dim ds As New DataSet
            Dim query = BCProcesoCompra.ListaProcesoCompraSinCotizacionImpresion(dtpFechaConserje.Value)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaProcesoCompraSinCotizacionImpresion", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Fecha", dtpFechaConserje.Value.Date.ToString)
            ' '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()

        Catch ex As Exception
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaProcesoCompraSinCotizacionImpresion", New DataTable()))
            ReportViewer1.RefreshReport()
        End Try
    End Sub
End Class