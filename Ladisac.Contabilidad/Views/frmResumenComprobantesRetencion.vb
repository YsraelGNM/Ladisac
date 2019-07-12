Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views
    Public Class frmResumenComprobantesRetencion

        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad
        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            'Me.Cursor = Cursors.WaitCursor
            Dim query As String
            Dim oTable As New DataTable
            Dim x As Integer = 0

            Dim vDia As String = Microsoft.VisualBasic.DateAndTime.Day(dtpFecha.Text)
            Dim vMes As String = Month(dtpFecha.Text)
            Dim vAnio As String = Year(dtpFecha.Text)
            If Len(vDia) < 2 Then vDia = "0" & vDia
            If Len(vMes) < 2 Then vMes = "0" & vMes


            SaveFileDialog1.Title = "Resumen diario de comprobantes de retención"
            SaveFileDialog1.DefaultExt = ""
            SaveFileDialog1.FileName = SessionServer.RUCEmpresa & "-" & "20" & "-" & vAnio & vMes & vDia & "-" & "1" & ".txt"
            SaveFileDialog1.ShowDialog()

            query = ""

            query = Me.BCConsultasReportesContabilidad.spResumenComprobanteRetencion(dtpFecha.Value)

            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    oTable = ds.Tables(0)

                Else
                    oTable = Nothing
                End If
            End If

            Dim objStreamWriter As StreamWriter
            objStreamWriter = New StreamWriter(SaveFileDialog1.FileName)
            x = 0
            While (oTable.Rows.Count > x)

                ' My.Computer.FileSystem.WriteAllText("C:\madro.txt", odataset.Rows(0).Item(0).ToString, True)
                objStreamWriter.WriteLine(oTable.Rows(x).Item(0).ToString)
                x += 1

            End While

            objStreamWriter.Close()

            Me.Cursor = Cursors.Default
        End Sub

    End Class

End Namespace
