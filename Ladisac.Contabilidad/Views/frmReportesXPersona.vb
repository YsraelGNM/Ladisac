Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports Microsoft.Reporting.WinForms

Namespace Ladisac.Contabilidad.Views
    Public Class frmReportesXPersona

        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad

        Dim oRptComprobantes As New rptComprobantes
        Dim sBusco As String


        Public campo1 As String
        Public campo2 As String

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


        Public Sub inicio(ByVal queBusco As String)
            sBusco = queBusco

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Comprobantes) Then
                PanelLibro.Visible = True
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ComprobantesRenta4ta) Then
                PanelLibro.Visible = True
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ComprobantesPercepcionReportes) Then
                PanelLibro.Visible = True
            End If


        End Sub

        Private Sub frmReportesXPersona_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

            Dim oTable As New DataTable

            Try

                If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Comprobantes) Then

                    oTable = Me.BCConsultasReportesContabilidad.RPTReportComprobantes(CDate(dateDesde.Value), CDate(dateHasta.Value), campo1, campo2, Nothing, Nothing, txtPersona.Tag)

                End If

                If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ComprobantesRenta4ta) Then

                    oTable = Me.BCConsultasReportesContabilidad.RPTReportComprobantes(CDate(dateDesde.Value), CDate(dateHasta.Value), campo1, campo2, Nothing, Nothing, txtPersona.Tag)

                End If


                If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ComprobantesPercepcionReportes) Then

                    oTable = Me.BCConsultasReportesContabilidad.RPTReportComprobantes(CDate(dateDesde.Value), CDate(dateHasta.Value), campo1, campo2, Nothing, Nothing, txtPersona.Tag)

                End If




                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

                If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Comprobantes) Then

                    oRptComprobantes.Database.Tables(0).SetDataSource(oTable)
                    oRptComprobantes.DataDefinition.FormulaFields("Reporte").Text = "'" & Ladisac.Contabilidad.Constants.MenuNames.Comprobantes & " '"
                    oRptComprobantes.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & " '"

                    frm.Reporte(oRptComprobantes)
                End If

                If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ComprobantesRenta4ta) Then

                    oRptComprobantes.Database.Tables(0).SetDataSource(oTable)
                    oRptComprobantes.DataDefinition.FormulaFields("Reporte").Text = "'" & Ladisac.Contabilidad.Constants.MenuNames.ComprobantesRenta4ta & " '"
                    oRptComprobantes.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & " '"


                    frm.Reporte(oRptComprobantes)
                End If

                If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ComprobantesPercepcionReportes) Then

                    oRptComprobantes.Database.Tables(0).SetDataSource(oTable)
                    oRptComprobantes.DataDefinition.FormulaFields("Reporte").Text = "'" & Ladisac.Contabilidad.Constants.MenuNames.ComprobantesPercepcionReportes & " '"
                    oRptComprobantes.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & " '"

                    frm.Reporte(oRptComprobantes)
                End If


                frm.ShowDialog()
            Catch ex As Exception
                MsgBox("No se puede mostrar la informacion :" & ex.Message)
            End Try

        End Sub
    End Class

End Namespace