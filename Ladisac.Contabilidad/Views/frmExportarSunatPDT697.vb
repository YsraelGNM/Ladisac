
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views
    Public Class frmExportarSunatPDT697


        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad
        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

        Private Sub btnPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodo.Click
            Try

                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
                frm.cargarDatos()

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPeriodo.Text = .Cells(0).Value
                    End With
                End If

                frm.Dispose()

            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim query As String
            Dim oTable As New DataTable
            Dim x As Integer = 0

            If (chkComprobatePago.Checked) Then

                SaveFileDialog1.Title = "Exportar Sunat PDT 697  "
                SaveFileDialog1.DefaultExt = ""
                SaveFileDialog1.FileName = "0697" & SessionServer.RUCEmpresa & txtPeriodo.Text & "VC.txt"
                SaveFileDialog1.ShowDialog()

                query = ""

                query = Me.BCConsultasReportesContabilidad.spExportarSunatPDT697(txtPeriodo.Text)

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


            End If

            If (chkComprobatePercepcion.Checked) Then

                SaveFileDialog1.Title = "Exportar Sunat PDT 697 Comprobantes  "
                SaveFileDialog1.DefaultExt = ""
                SaveFileDialog1.FileName = "0697" & SessionServer.RUCEmpresa & txtPeriodo.Text & ".txt"
                SaveFileDialog1.ShowDialog()

                query = ""

                query = Me.BCConsultasReportesContabilidad.spExportarSunatPDT697Comprobantes(txtPeriodo.Text)

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


            End If


        End Sub


        Private Sub frmExportarSunatPDT697_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub
    End Class
End Namespace