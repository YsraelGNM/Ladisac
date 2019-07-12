Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms

Public Class frmRptQuemaLadrillo
    <Dependency()> _
    Public Property BCHorno As Ladisac.BL.IBCHorno
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion

    Private Sub frmRptQuemaLadrillo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarHornos()
        cboHorno.SelectedIndex = 0
    End Sub

    Sub CargarHornos()
        Dim ds As New DataSet
        Dim query = BCHorno.ListaHorno
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboHorno
            .DisplayMember = "HOR_Descripcion"
            .ValueMember = "HOR_ID"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            Dim ds As New DataSet
            Dim query = BCProduccion.ListaQuemaLadrillo(cboHorno.SelectedValue, dtpFecFin.Value)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)

            Dim Lectura As String = ""
            Lectura = Lectura & "Prod." & Chr(9) & "Descripcion" & Chr(9) & Chr(9) & Chr(9) & "Fecha Prod."

            Dim Lista1 = From mRows As DataRow In ds.Tables(0).Rows Where CInt("0" + mRows.Item("DPE_PESO")) = 0 Group mRows By PRO_ID = mRows.Item(5), Descri = mRows.Item(6), Fecha = mRows.Item(4) Into Gpr = Group Order By PRO_ID, Fecha Select PRO_ID, Descri, Fecha

            For Each Fila In Lista1.ToList
                Lectura = Lectura & Chr(13)
                Lectura = Lectura & Fila.PRO_ID & Chr(9) & Fila.Descri & Chr(9) & Chr(9) & Fila.Fecha
            Next
            If Lista1.Count > 0 Then MessageBox.Show("Las siguientes Producciones les falta el Peso enlazado con la Carga." & Chr(13) & Chr(13) & Lectura, "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning)



            Dim ds1 As New DataSet
            Dim query1 = BCProduccion.ListaVueltasHornoXAnio(cboHorno.SelectedValue, dtpFecFin.Value.Year)
            Dim rea1 As New StringReader(query1)
            ds1.ReadXml(rea1)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaQuemaLadrillo", ds.Tables(0)))
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaVueltasHornoXAnio", ds1.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("horno", cboHorno.Text)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.DateTime.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try
    End Sub

End Class
