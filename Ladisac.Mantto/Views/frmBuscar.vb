Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms
Imports Ladisac.BE
Imports System.Drawing
Imports Pitman.Printing
Imports Microsoft.Office.Interop

Namespace Ladisac.Mantto.Views
    Public Class frmBuscar
        <Dependency()> _
        Public Property BCTipoEntidad As Ladisac.BL.IBCTipoEntidad
        <Dependency()> _
        Public Property BCEntidad As Ladisac.BL.IBCEntidad
        <Dependency()> _
        Public Property BCCaracteristica As Ladisac.BL.IBCCaracteristica
        <Dependency()> _
        Public Property BCGrupo As Ladisac.BL.IBCGrupo
        <Dependency()> _
        Public Property BCTipoFalla As Ladisac.BL.IBCTipoFalla
        <Dependency()> _
        Public Property BCTipoClaseMantto As Ladisac.BL.IBCTipoClaseMantto
        <Dependency()> _
        Public Property BCMantto As Ladisac.BL.IBCMantto
        <Dependency()> _
        Public Property BCTipoMantto As Ladisac.BL.IBCTipoMantto
        <Dependency()> _
        Public Property BCInspeccion As Ladisac.BL.IBCInspeccion
        <Dependency()> _
        Public Property BCEntidadInspeccion As Ladisac.BL.IBCEntidadInspeccion
        <Dependency()> _
        Public Property BCComponenteInspeccion As Ladisac.BL.IBCComponenteInspeccion
        <Dependency()> _
        Public Property BCPersona As Ladisac.BL.IBCPersona
        <Dependency()> _
        Public Property BCOrdenTrabajo As Ladisac.BL.IBCOrdenTrabajo
        <Dependency()> _
        Public Property BCPlanMantto As Ladisac.BL.IBCPlanMantenimiento
        <Dependency()> _
        Public Property BCRegistroEquipo As Ladisac.BL.IBCRegistroEquipo
        <Dependency()> _
        Public Property BCPlantillaDocuIso As Ladisac.BL.IBCPlantillaDocuIso
        <Dependency()> _
        Public Property BCArea As Ladisac.BL.IBCArea
        <Dependency()> _
        Public Property BCDocuIso As Ladisac.BL.IBCDocuIso
        <Dependency()> _
        Public Property BCTipoDocumento As Ladisac.BL.IBCTipoDocumento
        <Dependency()> _
        Public Property BCFotoPersona As Ladisac.BL.IBCFotoPersona
        <Dependency()> _
        Public Property BCUnidadesTransporte As Ladisac.BL.IBCUnidadesTransporte
        <Dependency()> _
        Public Property BCProduccion As Ladisac.BL.IBCProduccion
        <Dependency()> _
        Public Property BCCancha As Ladisac.BL.IBCCancha

        Public Property Tabla() As String
            Get
                Return mTabla
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    mTabla = Nothing
                Else
                    mTabla = value
                End If
            End Set
        End Property

        Public Property Tipo() As String
            Get
                Return mTipo
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    mTipo = Nothing
                Else
                    mTipo = value
                End If
            End Set
        End Property

        Public Property Tipo2() As String
            Get
                Return mTipo2
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    mTipo2 = Nothing
                Else
                    mTipo2 = value
                End If
            End Set
        End Property

        Dim mTabla As String
        Dim query As String
        Dim mTipo As String
        Dim mTipo2 As String

        Dim ds As New DataSet
        Dim col As Integer = 0

        Private Sub frmBuscar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If Me.DialogResult = Nothing Then
                e.Cancel = True
            End If
        End Sub

        Private Sub frmBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, dgvLista.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Dispose()
            End If
        End Sub

        Private Sub frmBuscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Select Case Tabla
                Case "RegistroEquipo"
                    Me.lblTitle.Text = "Busqueda Registro Equipo"
                    query = Me.BCRegistroEquipo.ListaRegistroEquipo
                Case "Tarea"
                    Me.lblTitle.Text = "Busqueda Tarea"
                    query = Me.BCRegistroEquipo.ListaTarea
                Case "UbicacionTrabajo"
                    Me.lblTitle.Text = "Busqueda Ubicacion de Trabajo"
                    query = Me.BCRegistroEquipo.ListaUbicacionTrabajo
                Case "TipoEntidad"
                    Me.lblTitle.Text = "Busqueda Tipo Entidad"
                    query = Me.BCTipoEntidad.ListaTipoEntidad
                Case "Entidad"
                    Me.lblTitle.Text = "Busqueda Entidad"
                    query = Me.BCEntidad.ListaEntidad
                Case "Caracteristica"
                    Me.lblTitle.Text = "Busqueda de Caracteristicas"
                    query = Me.BCCaracteristica.ListaCaracteristica
                Case "Grupo"
                    Me.lblTitle.Text = "Busqueda de Grupo"
                    query = Me.BCGrupo.ListaGrupo
                Case "TipoFalla"
                    Me.lblTitle.Text = "Busqueda de Tipo de Fallas"
                    query = Me.BCTipoFalla.ListaTipoFalla
                Case "TipoClaseMantto"
                    Me.lblTitle.Text = "Busqueda de Tipo Clase Mantenimiento"
                    query = Me.BCTipoClaseMantto.ListaTipoClaseMantto
                Case "Mantto"
                    Me.lblTitle.Text = "Busqueda de Mantenimientos"
                    query = Me.BCMantto.ListaMantto
                Case "TipoMantto"
                    Me.lblTitle.Text = "Busqueda de Tipo de Mantenimientos"
                    query = Me.BCTipoMantto.ListaTipoMantto
                Case "Inspeccion"
                    Me.lblTitle.Text = "Busqueda de Inspeccion"
                    query = Me.BCInspeccion.ListaInspeccion
                Case "EntidadInspeccion"
                    Me.lblTitle.Text = "Busqueda de Inspecciones por Entidad"
                    query = Me.BCEntidadInspeccion.ListaEntidadInspeccion
                Case "ComponenteInspeccion"
                    Me.lblTitle.Text = "Busqueda de Componentes por Inspeccion"
                    query = Me.BCComponenteInspeccion.ListaComponenteInspeccion
                Case "Persona"
                    Me.lblTitle.Text = "Busqueda"
                    query = Me.BCPersona.ListaPersona(Tipo)
                Case "OrdenTrabajo"
                    Me.lblTitle.Text = "Busqueda Orden de Trabajo"
                    query = Me.BCOrdenTrabajo.ListaOrdenTrabajo
                Case "PlanMantto"
                    Me.lblTitle.Text = "Busqueda Plan de Mantenimiento"
                    query = Me.BCPlanMantto.ListaPlanMantenimiento
                Case "Placa"
                    Me.lblTitle.Text = "Busqueda Placas"
                    query = Me.BCUnidadesTransporte.ListaUnidadesTransporteEmpresa(Tipo)
                Case "PlantillaDocuIso"
                    Me.lblTitle.Text = "Busqueda Plantilla Documento ISO"
                    query = Me.BCPlantillaDocuIso.ListaPlantillaDocuIso
                Case "Area"
                    Me.lblTitle.Text = "Busqueda Area"
                    query = Me.BCArea.ListaArea
                Case "DocuIso"
                    Me.lblTitle.Text = "Busqueda Documento ISO"
                    query = Me.BCDocuIso.ListaDocuIso
                Case "TipoDocumentoISO"
                    Me.lblTitle.Text = "Busqueda Tipo Documento ISO"
                    query = Me.BCTipoDocumento.ListaDetalleTipoDocumentoISO
                Case "FotoPersona"
                    Me.lblTitle.Text = "Busqueda Firma ISO"
                    query = Me.BCFotoPersona.ListaFotoPersonas
                Case "AreaRRHH"
                    Me.lblTitle.Text = "Busqueda Area RRHH"
                    query = Me.BCArea.ListaAreaRRHH
                Case "UnidadesTransporte"
                    Me.lblTitle.Text = "Busqueda Unidades Transporte"
                    query = Me.BCUnidadesTransporte.ListaUnidadesTransporteXPlaca(Tipo)
                Case "Produccion"
                    Me.lblTitle.Text = "Busqueda Produccion"
                    query = Me.BCProduccion.ListaProduccion
                Case "Cancha"
                    Me.lblTitle.Text = "Busqueda Cancha"
                    query = Me.BCCancha.ListaCancha
                Case "EntidadPlaca"
                    Me.lblTitle.Text = "Busqueda Entidad Placa"
                    query = Me.BCEntidad.ListaEntidadPlaca
            End Select

            Try
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
                dgvLista.DataSource = ds.Tables(0)
                Select Case Tabla
                    Case "Persona", Tipo = "Trabajador"
                        dgvLista.Columns(0).Visible = False
                        col = 1
                End Select

                dgvLista.CurrentCell = dgvLista.Rows(0).Cells(col)
            Catch ex As Exception
                dgvLista.DataSource = Nothing
            End Try



            txtBuscar.Focus()
        End Sub

        Private Sub LlenarNodosHijos(ByVal nodoPadre As TreeNode)

            Dim nodoHijo As TreeNode
            Dim lisEntidades As List(Of Entidad)

            lisEntidades = Me.BCEntidad.ListaHijos(CType(nodoPadre.Tag, Entidad).ENO_ID)
            If lisEntidades.Count <> 0 Then
                For Each ent As Entidad In lisEntidades
                    nodoHijo = New TreeNode(ent.ENO_DESCRIPCION)
                    nodoHijo.Tag = ent
                    nodoPadre.Nodes.Add(nodoHijo)
                Next
            End If
        End Sub

        Private Sub dgvLista_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellClick
            col = e.ColumnIndex
        End Sub

        Private Sub dgvLista_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellDoubleClick
            If dgvLista.RowCount > 0 Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        End Sub

        Function ColumVisible(ByVal col As Integer, ByVal signo As Integer) As Integer
            Dim mCol As Integer
            If col = -1 Or col > dgvLista.Columns.Count - 1 Then
                mCol = 700
            Else
                If Not dgvLista.Columns(col).Visible Then
                    If signo = -1 Then
                        mCol = ColumVisible(col - 1, -1)
                    Else
                        mCol = ColumVisible(col + 1, 1)
                    End If
                Else
                    mCol = col
                End If
            End If
            Return mCol
        End Function

        Private Sub txtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscar.KeyDown
            If dgvLista.CurrentRow Is Nothing Then dgvLista.DataSource = ds.Tables(0) : Exit Sub
            If col = -1 Then col = 0
            If e.KeyCode = Keys.Down Then
                If dgvLista.CurrentRow.Index < dgvLista.Rows.Count - 1 Then If dgvLista.Columns(col).Visible Then dgvLista.CurrentCell = dgvLista.Rows(dgvLista.CurrentRow.Index + 1).Cells(col)
            ElseIf e.KeyCode = Keys.Up Then
                If dgvLista.CurrentRow.Index > 0 Then If dgvLista.Columns(col).Visible Then dgvLista.CurrentCell = dgvLista.Rows(dgvLista.CurrentRow.Index - 1).Cells(col)
            ElseIf e.KeyCode = Keys.Enter Then
                dgvLista_CellDoubleClick(Nothing, Nothing)
            ElseIf e.KeyCode = Keys.Left Then
                If ColumVisible(col - 1, -1) <> 700 Then
                    col = ColumVisible(col - 1, -1)
                    dgvLista.CurrentCell = dgvLista.CurrentRow.Cells(col)
                End If
            ElseIf e.KeyCode = Keys.Right Then
                If ColumVisible(col + 1, 1) <> 700 Then
                    col = ColumVisible(col + 1, 1)
                    dgvLista.CurrentCell = dgvLista.CurrentRow.Cells(col)
                End If
            ElseIf e.KeyCode = Keys.Back Then
                dgvLista.DataSource = ds.Tables(0)
            End If
        End Sub

        Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
            If col = -1 Then col = 0
            dgvLista.DataSource = SelectDataTable(CType(dgvLista.DataSource, DataTable), dgvLista.Columns(col).Name & " like '%" & txtBuscar.Text & "%'")
            If txtBuscar.Text = "" Then dgvLista.DataSource = ds.Tables(0)
            If dgvLista.Rows.Count > 0 Then dgvLista.CurrentCell = dgvLista.Rows(0).Cells(col)
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

        Private Sub dgvLista_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLista.CurrentCellChanged
            Try
                If dgvLista.CurrentRow.Cells("Ruta").Value.ToString.Length > 0 Then
                    lblView.Text = dgvLista.CurrentRow.Cells("Ruta").Value
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub dgvLista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = Keys.Enter Then
                dgvLista_CellDoubleClick(Nothing, Nothing)
                e.SuppressKeyPress = True
            End If
        End Sub

        Private Sub tviEntidades_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tviEntidades.AfterSelect
            tviEntidades.SelectedNode.Nodes.Clear()
            LlenarNodosHijos(tviEntidades.SelectedNode)
            tviEntidades.ExpandAll()

        End Sub

        Private Sub tviEntidades_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tviEntidades.NodeMouseDoubleClick

            If Tabla = "Entidad" Then
                If CType(tviEntidades.SelectedNode.Tag, Entidad).ENO_ID > 0 Then
                    dgvLista.DataSource = SelectDataTable(ds.Tables(0), "ENO_ID = '" & CType(tviEntidades.SelectedNode.Tag, Entidad).ENO_ID & "'")
                    dgvLista.CurrentCell = dgvLista.Rows(0).Cells("ENO_ID")
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            Else
                Try
                    If CType(tviEntidades.SelectedNode.Tag, Entidad).ENO_ID > 0 Then
                        dgvLista.DataSource = SelectDataTable(ds.Tables(0), "ENO_ID = '" & CType(tviEntidades.SelectedNode.Tag, Entidad).ENO_ID & "'")
                        If dgvLista.Rows.Count > 0 Then dgvLista.CurrentCell = dgvLista.Rows(0).Cells("ENO_ID")
                        TabControl1.SelectedIndex = 0
                    End If
                Catch ex As Exception
                End Try
            End If

        End Sub

        Private Sub TabPage1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter
            txtBuscar.Focus()
        End Sub

        Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
            Dim Her As New Herramientas
            Her.excelExportar(Her.ToTable(dgvLista, "lista"))
        End Sub

        Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
            'Dim print As New PrintHelper
            'print.PrintPreviewTree(tviEntidades, "Entidades")
            TreeviewToExcel(tviEntidades)
        End Sub

        Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
            If TabControl1.SelectedIndex = 1 Then
                'Tab "Arbol de entidades"
                Dim nodoPadre As TreeNode
                tviEntidades.Nodes.Clear()
                'Nodo raíz
                nodoPadre = New TreeNode("/")

                Select Case Tabla & Tipo2
                    Case "EntidadREQ"
                        nodoPadre.Tag = BCEntidad.EntidadGetById(CInt(Tipo))
                    Case Else
                        nodoPadre.Tag = BCEntidad.EntidadGetById(0)
                End Select

                tviEntidades.Nodes.Add(nodoPadre)
                'Nodos Hijos
                LlenarNodosHijos(nodoPadre)
                tviEntidades.ExpandAll()


            End If
        End Sub





        Public Sub TreeviewToExcel(ByVal tv As System.Windows.Forms.TreeView)
            '---------------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------------
            ' Procedure : Treeview_ToExcel
            ' Author    : AEC - Anders Ebro Christensen / TheSmileyCoder
            ' Date      : 2014-03-07
            ' Version   : 1.0
            ' Purpose   : Export a treeviews content into excel.
            '           : If no worksheet is passed a workbook is created.
            ' Commments :
            '           :
            ' Bugs?     : Email: TheSmileyCoder
            '---------------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------------
            Dim nodRoot As TreeNode
            Dim nodX As TreeNode
            Dim irow As Integer

            If tv.Nodes.Count = 0 Then
                MsgBox("Treeview contains no nodes to export")
            End If

            Dim exWorksheet = CreateObject("Excel.Application").Workbooks.Add.Sheets(1)

            'Get A node
            nodX = tv.Nodes(0) 'There is always at least 1 node present

            'Get the first root node
            nodRoot = nodX.FirstNode

            'Drill down and export to excel.
            Do
                Call pOutputNodeToExcel(0, irow, nodRoot, exWorksheet)
                nodRoot = nodRoot.NextNode
            Loop While Not (nodRoot Is Nothing)

            'Ensure worksheet is visible
            exWorksheet.Application.visible = True


            'Cleanup
            exWorksheet = Nothing

        End Sub

        Private Sub pOutputNodeToExcel(ByVal iLevel As Integer, ByRef irow As Integer, ByRef nodZ As TreeNode, ByRef exWorksheet As Excel.Worksheet)
            'Export to excel
            exWorksheet.Cells(irow + 1, iLevel + 1).Value = nodZ.Text
            '' ''If nodZ.ForeColor <> vbBlack Then
            '' ''    exWorksheet.Cells(irow + 1, iLevel + 1).Font.Color = nodZ.ForeColor
            '' ''End If
            '' ''If nodZ.Bold Then
            '' ''    exWorksheet.Cells(irow + 1, iLevel + 1).Font.Bold = True
            '' ''End If
            irow = irow + 1
            'Recursively work on children if any
            iLevel = iLevel + 1

            For Each mNod In nodZ.Nodes
                pOutputNodeToExcel(iLevel, irow, mNod, exWorksheet)
            Next
        End Sub
    End Class
End Namespace
