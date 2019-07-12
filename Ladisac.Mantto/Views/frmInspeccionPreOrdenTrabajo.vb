Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmInspeccionPreOrdenTrabajo
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCInspeccionPreOrdenTrabajo As Ladisac.BL.IBCInspeccionPreOrdenTrabajo
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mIOT As InspeccionPreOrdenTrabajo
    Dim query As String
    Dim ds As DataSet
    Dim col As Integer = -1

    Private Sub frmInspeccionPreOrdenTrabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim col As New ColumnaCalendario
        col.Name = "IOT_FECHA"
        col.HeaderText = "Fecha"
        Me.dgvDetalle.Columns.Add(col)
        CargarGrid()

        Call validacion_desactivacion(False, 1)
        txtBuscar.TabIndex = 1
        dgvDetalle.TabIndex = 2

    End Sub

    Private Sub CargarGrid()
        Try
            ds = New DataSet
            query = BCInspeccionPreOrdenTrabajo.ListaInspeccionPreOrdenTrabajo

            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            LlenarGrid(ds.Tables(0))
            ds = New DataSet
            ds.Tables.Add(DataGridViewToDataTable(dgvDetalle))
        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiarControles()
        mIOT = Nothing
        dgvDetalle.Rows.Clear()
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)
    End Sub

    Sub LlenarGrid(ByVal mDT As DataTable)
        dgvDetalle.Rows.Clear()
        For Each mItem In mDT.Rows
            If Not mItem("IOT_ID") = "" Then
                mIOT = New InspeccionPreOrdenTrabajo
                mIOT = BCInspeccionPreOrdenTrabajo.InspeccionPreOrdenTrabajoGetById(mItem("IOT_ID"))
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IOT_ID").Value = mIOT.IOT_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IOT_ID").Tag = mIOT

                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ENO_ID").Value = mIOT.Entidad.ENO_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ENO_ID").Tag = mIOT.ENO_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IOT_DESCRIPCION").Value = mIOT.IOT_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IOT_FECHA").Value = mIOT.IOT_FECHA
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("OTR_ID").Value = mIOT.OTR_ID
            End If
        Next
    End Sub

    Public Overrides Sub OnManGuardar()
        dgvDetalle.EndEdit()
        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
            If Not mDetalle.Cells("IOT_ID").Value Is Nothing Then
                With CType(mDetalle.Cells("IOT_ID").Tag, InspeccionPreOrdenTrabajo)
                    .ENO_ID = CInt(mDetalle.Cells("ENO_ID").Tag)
                    .IOT_DESCRIPCION = mDetalle.Cells("IOT_DESCRIPCION").Value
                    .IOT_FECHA = mDetalle.Cells("IOT_FECHA").Value
                    .OTR_ID = CInt(mDetalle.Cells("OTR_ID").Value)
                    .IOT_ESTADO = True
                    .IOT_FEC_GRAB = Now
                    .USU_ID = SessionServer.UserId
                    .MarkAsModified()
                End With
                BCInspeccionPreOrdenTrabajo.MantenimientoInspeccionPreOrdenTrabajo(CType(mDetalle.Cells("IOT_ID").Tag, InspeccionPreOrdenTrabajo))
            ElseIf Not mDetalle.Cells("ENO_ID").Value Is Nothing Then
                Dim nIOT As New InspeccionPreOrdenTrabajo
                With nIOT
                    .ENO_ID = CInt(mDetalle.Cells("ENO_ID").Tag)
                    .IOT_DESCRIPCION = mDetalle.Cells("IOT_DESCRIPCION").Value
                    .IOT_FECHA = mDetalle.Cells("IOT_FECHA").Value
                    .OTR_ID = CInt(mDetalle.Cells("OTR_ID").Value)
                    .IOT_ESTADO = True
                    .IOT_FEC_GRAB = Now
                    .USU_ID = SessionServer.UserId
                    .MarkAsAdded()
                End With
                BCInspeccionPreOrdenTrabajo.MantenimientoInspeccionPreOrdenTrabajo(nIOT)
            End If

        Next
        Call validacion_desactivacion(False, 3)

    End Sub

    Private Sub dgvDetalle_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
        col = e.ColumnIndex
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        Select Case CType(sender, DataGridView).Columns(e.ColumnIndex).Name
            Case "ENO_ID"
                frm.Tabla = "Entidad"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ENO_Id
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'ENO_Descripcion
                End If
            Case "OTR_ID"
                If dgvDetalle.CurrentCell.Value = 0 Then
                    Dim frmOT = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmOrdenTrabajo)()
                    frmOT.IOT_CodEntidad = dgvDetalle.CurrentRow.Cells("ENO_ID").Tag
                    frmOT.IOT_DesEntidad = dgvDetalle.CurrentRow.Cells("ENO_ID").Value
                    frmOT.IOT_Observacion = dgvDetalle.CurrentRow.Cells("IOT_DESCRIPCION").Value
                    If frmOT.ShowDialog = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Value = frmOT.IOT_CodOT
                        CType(dgvDetalle.CurrentRow.Cells("IOT_ID").Tag, InspeccionPreOrdenTrabajo).MarkAsModified()
                        BCInspeccionPreOrdenTrabajo.MantenimientoInspeccionPreOrdenTrabajo(CType(dgvDetalle.CurrentRow.Cells("IOT_ID").Tag, InspeccionPreOrdenTrabajo))
                    End If
                End If
        End Select
        frm.Dispose()
    End Sub

    Function ColumVisible(ByVal col As Integer, ByVal signo As Integer) As Integer
        Dim mCol As Integer
        If col = -1 Or col > dgvDetalle.Columns.Count - 1 Then
            mCol = 700
        Else
            If Not dgvDetalle.Columns(col).Visible Then
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
        If dgvDetalle.CurrentRow Is Nothing Then Exit Sub
        If col = -1 Then col = 0
        If e.KeyCode = Keys.Down Then
            If dgvDetalle.CurrentRow.Index < dgvDetalle.Rows.Count - 1 Then If dgvDetalle.Columns(col).Visible Then dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.CurrentRow.Index + 1).Cells(col)
        ElseIf e.KeyCode = Keys.Up Then
            If dgvDetalle.CurrentRow.Index > 0 Then If dgvDetalle.Columns(col).Visible Then dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.CurrentRow.Index - 1).Cells(col)
        ElseIf e.KeyCode = Keys.Enter Then
            dgvDetalle_CellDoubleClick(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Left Then
            If ColumVisible(col - 1, -1) <> 700 Then
                col = ColumVisible(col - 1, -1)
                dgvDetalle.CurrentCell = dgvDetalle.CurrentRow.Cells(col)
            End If
        ElseIf e.KeyCode = Keys.Right Then
            If ColumVisible(col + 1, 1) <> 700 Then
                col = ColumVisible(col + 1, 1)
                dgvDetalle.CurrentCell = dgvDetalle.CurrentRow.Cells(col)
            End If
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        If col = -1 Then col = 0
        LlenarGrid(SelectDataTable(ds.Tables(0), dgvDetalle.Columns(col).Name & " like '%" & txtBuscar.Text & "%'"))
        'If txtBuscar.Text = "" Then dgvDetalle.DataSource = ds.Tables(0)
        dgvDetalle.CurrentCell = dgvDetalle.Rows(0).Cells(col)
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

    Public Overrides Sub OnManNuevo()
        Call validacion_desactivacion(True, 2)
        txtBuscar.Focus()
    End Sub

    Private Sub dgvDetalle_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvDetalle.DragDrop

    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        If e.KeyCode = Keys.Enter Then
            Select Case CType(sender, DataGridView).Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
                Case "ENO_ID"
                    frm.Tabla = "Entidad"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ENO_Id
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'ENO_Descripcion
                    End If
                Case "OTR_ID"
                    If dgvDetalle.CurrentCell.Value = 0 Then
                        Dim frmOT = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmOrdenTrabajo)()
                        frmOT.IOT_CodEntidad = dgvDetalle.CurrentRow.Cells("ENO_ID").Tag
                        frmOT.IOT_DesEntidad = dgvDetalle.CurrentRow.Cells("ENO_ID").Value
                        frmOT.IOT_Observacion = dgvDetalle.CurrentRow.Cells("IOT_DESCRIPCION").Value
                        If frmOT.ShowDialog = Windows.Forms.DialogResult.OK Then
                            dgvDetalle.CurrentCell.Value = frmOT.IOT_CodOT
                            CType(dgvDetalle.CurrentRow.Cells("IOT_ID").Tag, InspeccionPreOrdenTrabajo).MarkAsModified()
                            BCInspeccionPreOrdenTrabajo.MantenimientoInspeccionPreOrdenTrabajo(CType(dgvDetalle.CurrentRow.Cells("IOT_ID").Tag, InspeccionPreOrdenTrabajo))
                        End If
                    End If
            End Select
        End If
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        If Not e.Row.Cells("IOT_ID").Tag Is Nothing Then
            If MessageBox.Show("Se borrara permanentemente. Desea contuinuar?", "Atencion", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                CType(e.Row.Cells("IOT_ID").Tag, InspeccionPreOrdenTrabajo).MarkAsDeleted()
                BCInspeccionPreOrdenTrabajo.MantenimientoInspeccionPreOrdenTrabajo(CType(e.Row.Cells("IOT_ID").Tag, InspeccionPreOrdenTrabajo))
            End If
        End If
    End Sub

    Public Shared Function IfNullObj(ByVal o As Object, Optional ByVal DefaultValue As String = "") As String
        Dim ret As String = ""
        Try
            If o Is DBNull.Value Then
                ret = DefaultValue
            Else
                ret = o.ToString
            End If
            Return (ret)
        Catch ex As Exception
            Return (ret)
        End Try
    End Function

    Public Shared Function DataGridViewToDataTable(ByVal dtg As DataGridView, Optional ByVal DataTableName As String = "myDataTable") As DataTable
        Try
            Dim dt As New DataTable(DataTableName)
            Dim row As DataRow
            Dim TotalDatagridviewColumns As Integer = dtg.ColumnCount - 1
            'Add Datacolumn
            For Each c As DataGridViewColumn In dtg.Columns
                Dim idColumn As DataColumn = New DataColumn()
                idColumn.ColumnName = c.Name
                dt.Columns.Add(idColumn)
            Next
            'Now Iterate thru Datagrid and create the data row
            For Each dr As DataGridViewRow In dtg.Rows
                'Iterate thru datagrid
                row = dt.NewRow 'Create new row
                'Iterate thru Column 1 up to the total number of columns
                For cn As Integer = 0 To TotalDatagridviewColumns
                    row.Item(cn) = IfNullObj(dr.Cells(cn).Value) ' This Will handle error datagridviewcell on NULL Values
                Next
                'Now add the row to Datarow Collection
                dt.Rows.Add(row)
            Next
            'Now return the data table
            Return (dt)
        Catch ex As Exception
            Return (Nothing)
        End Try
    End Function
End Class
