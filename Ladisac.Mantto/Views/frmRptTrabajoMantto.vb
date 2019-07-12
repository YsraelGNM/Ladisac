Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmRptTrabajoMantto
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCEntidad As Ladisac.BL.IBCEntidad
    <Dependency()> _
    Public Property BCGrupo As Ladisac.BL.IBCGrupo
    Dim query As String
    Dim ds As DataSet
    Dim dsTrabajoMantto As New DataSet

    Private Sub frmRptTrabajoMantto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet
        query = BCGrupo.ListaGrupo
        Dim rea As New StringReader(query)
        rea = New StringReader(query)
        ds.ReadXml(rea)
        cboGrupo.DisplayMember = "GRU_DESCRIPCION"
        cboGrupo.ValueMember = "GRU_ID"
        cboGrupo.DataSource = ds.Tables(0)

        dtpFecIni.TabIndex = 1
        dtpFecFin.TabIndex = 2
        chkComparativo.TabIndex = 3
        dtpCompFI.TabIndex = 4
        dtpCompFF.TabIndex = 5
        chkDetallado.TabIndex = 6
        cboGrupo.TabIndex = 7
        dgvDetalle.TabIndex = 8
        dgvDetalle2.TabIndex = 9
        cboFase.SelectedIndex = -1
        dtpFecIni.Focus()
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        Select Case CType(sender, DataGridView).Columns(e.ColumnIndex).Name
            Case "ENO_ID"
                frm.Tabla = "Entidad"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Eno_Id
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'Eno_Descripcion
                End If
        End Select
        frm.Dispose()
    End Sub

    Function InsertarTrabajos(ByVal Eno_Id As Integer) As DataSet
        Dim ds As New DataSet
        Dim query = BCEntidad.EstadoTrabajoMantto(Eno_Id, dtpFecIni.Value, dtpFecFin.Value, IIf(chkComparativo.Checked, dtpCompFI.Value, Nothing), IIf(chkComparativo.Checked, dtpCompFF.Value, Nothing), CInt(cboGrupo.SelectedValue), IIf(cboFase.Text = "", Nothing, cboFase.Text))
        If query.Length > 0 Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
        End If
        Return ds
    End Function

    Function InsertarTrabajos2(ByVal Eno_Id As Integer) As DataSet
        Dim ds As New DataSet
        Dim query = BCEntidad.EstadoTrabajoManttoDetallado(Eno_Id, dtpFecIni.Value, dtpFecFin.Value, CInt(cboGrupo.SelectedValue), IIf(cboFase.Text = "", Nothing, cboFase.Text))
        If query.Length > 0 Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
        End If
        Return ds
    End Function

    Private Sub ReportViewer1_ReportRefresh(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ReportViewer1.ReportRefresh
        Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
        parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Detallado", chkDetallado.Checked)
        Me.ReportViewer1.LocalReport.SetParameters(parametro)
    End Sub

    Private Sub chkComparativo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkComparativo.CheckedChanged
        Me.GroupBox2.Enabled = chkComparativo.Checked
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        If e.KeyCode = Keys.Enter Then
            Select Case CType(sender, DataGridView).Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
                Case "ENO_ID"
                    frm.Tabla = "Entidad"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Eno_Id
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'Eno_Descripcion
                        RehacerReporte()
                    End If
            End Select
        End If
        frm.Dispose()
    End Sub

    Private Sub btnAgregarFila_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarFila.Click
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
    End Sub

    Sub RehacerReporte()
        dgvDetalle.EndEdit()
        dsTrabajoMantto.Clear()
        Dim dsOTDetallado As New DataSet

        Try

            For Each mFila As DataGridViewRow In dgvDetalle.Rows
                Dim ds As DataSet
                Dim ds2 As DataSet
                ds = InsertarTrabajos(mFila.Cells("ENO_ID").Tag)
                ds2 = InsertarTrabajos2(mFila.Cells("ENO_ID").Tag)

                If ds.Tables.Count > 0 Then
                    For Each mItem As DataRow In ds.Tables(0).Rows
                        mItem("grupo") = mFila.Cells(0).Value & " " & mFila.Cells(1).Value 'Eno_Id-Eno_Descripcion
                    Next
                    For Each mItem As DataRow In ds2.Tables(0).Rows
                        mItem("grupo") = mFila.Cells(0).Value & " " & mFila.Cells(1).Value 'Eno_Id-Eno_Descripcion
                    Next

                    dsTrabajoMantto.Merge(ds)
                    dsOTDetallado.Merge(ds2)

                    Dim Sumas = From busq In ds.Tables(0).AsEnumerable _
                     Group busq By Grupo = busq.Field(Of String)("Grupo") Into Group _
                     Select Grupo _
                     , Proceso = Group.Sum(Function(busq) busq.Field(Of String)("Proceso")) _
                     , ProcesoComp = Group.Sum(Function(busq) busq.Field(Of String)("ProcesoComp")) _
                     , Pendiente = Group.Sum(Function(busq) busq.Field(Of String)("Pendiente")) _
                     , PendienteComp = Group.Sum(Function(busq) busq.Field(Of String)("PendienteComp")) _
                     , Finalizado = Group.Sum(Function(busq) busq.Field(Of String)("Finalizado")) _
                     , FinalizadoComp = Group.Sum(Function(busq) busq.Field(Of String)("FinalizadoComp"))


                    mFila.Cells("CPA").Value = Sumas(0).Pendiente
                    mFila.Cells("CPC").Value = Sumas(0).PendienteComp
                    mFila.Cells("CFA").Value = Sumas(0).Finalizado
                    mFila.Cells("CFC").Value = Sumas(0).FinalizadoComp
                    mFila.Cells("CEA").Value = Sumas(0).Proceso
                    mFila.Cells("CEC").Value = Sumas(0).ProcesoComp
                End If
            Next


            dgvDetalle2.DataSource = dsOTDetallado.Tables(0)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsTrabajoMantto", dsTrabajoMantto.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Detallado", chkDetallado.Checked)

            ' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        RehacerReporte()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim Her As New Herramientas
        Her.excelExportar(Her.ToTable(dgvDetalle2, "table01"))
    End Sub
End Class