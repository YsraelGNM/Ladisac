Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports Microsoft.Reporting.WinForms


Namespace Ladisac.Contabilidad.Views

    Public Class frmReportesCentroCosto

        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad

        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil
        Dim oreporte As New rptRegistroComprasCentroCosto

        Private Sub frmReportesCentroCosto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

        End Sub

        Private Sub btnPeriodoinicial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodoinicial.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
                frm.cargarDatos()
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPeriodoinicial.Text = .Cells(0).Value

                    End With
                End If
                frm.Dispose()

            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnPeriodoFinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodoFinal.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
                frm.cargarDatos()
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPeriodoFinal.Text = .Cells(0).Value

                    End With
                End If
                frm.Dispose()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnCentroCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCentroCosto.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CentroCosto)
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow

                        txtcentroCosto.Tag = .Cells(0).Value
                        txtcentroCosto.Text = .Cells(1).Value

                    End With
                End If
                frm.Dispose()

            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPersona.Click

            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.BuscarPersona)

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPersona.Tag = .Cells(0).Value()
                        txtPersona.Text = .Cells(1).Value
                    End With
                End If
                frm.Dispose()
            Catch ex As Exception

            End Try

        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim oTable As New DataTable

            Try
                oTable = Me.BCConsultasReportesContabilidad.SPSelectReportRegistroComprasCentroCosto(txtPeriodoinicial.Text, txtPeriodoFinal.Text, txtPersona.Tag, txtcentroCosto.Tag)
                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

                oreporte.Database.Tables(0).SetDataSource(oTable)
                oreporte.DataDefinition.FormulaFields("Periodo").Text = "'Desde " & txtPeriodoinicial.Text & "  hasta " & txtPeriodoFinal.Text & " '"

                frm.Reporte(oreporte)
                frm.ShowDialog()


            Catch ex As Exception

            End Try

        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            txtPersona.Text = ""
            txtPersona.Tag = Nothing

        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            txtcentroCosto.Text = ""
            txtcentroCosto.Tag = Nothing
        End Sub
    End Class
End Namespace
