
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports Microsoft.Reporting.WinForms

Namespace Ladisac.Contabilidad.Views

    Public Class frmVisorReportes

        Private sBusco As String
        Private snombreRecurso As String

      

        Private Sub frmVisorReportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        End Sub
  Public Sub Reporte(ByVal oCrystalReport As Object)
            Try
                CrystalReportViewer1.ReportSource = oCrystalReport
            Catch ex As Exception
                CrystalReportViewer1.ReportSource = Nothing
            End Try

        End Sub
    End Class
End Namespace