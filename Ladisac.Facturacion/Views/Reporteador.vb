Imports Microsoft.Practices.Unity
Imports CrystalDecisions
Namespace Ladisac
    Public Class Reporteador
        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        Public Sub Reporte(ByVal oCrystalReport As Object)
            Try
                CrystalReportViewer1.ReportSource = oCrystalReport
            Catch ex As Exception

            End Try
        End Sub
        Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
            If SessionService.NombreEmpresa = "Ladrillera El Diamante SAC" Then
                Me.BackColor = Me.ContainerService.Resolve(Of Foundation.MainWindow)().BackColor 'System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
            Else
                Me.BackColor = System.Drawing.Color.CadetBlue
            End If
        End Sub
    End Class
End Namespace