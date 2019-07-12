Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Imports Ladisac.Contabilidad.Views

Namespace Ladisac.CuentasCorrientes.Views
    Public Class frmReporteDepositoTerceros


        <Dependency()> _
        Public Property BCKardexCtaCte As BL.IBCKardexCtaCte

        Dim oReporte As New ReporteDepositoTerceros
        Private Sub btnPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPersona.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarPersona)

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

        Private Sub btnCLSPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLSPersona.Click
            txtPersona.Text = ""
            txtPersona.Tag = ""
        End Sub

        Private Sub btnBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBanco.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CajaCtaCteSelectXML)

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtBanco.Tag = .Cells(0).Value()
                        txtBanco.Text = .Cells(1).Value
                    End With
                End If
                frm.Dispose()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim otable As DataTable
            Dim sResponsable As String = ""
            Dim sBanco As String = ""
            Dim tipoReporte As Integer

            If (rdbDepositoTercero.Checked) Then
                tipoReporte = 1
            End If
            If (rdbNotaCargo.Checked) Then
                tipoReporte = 2
            End If

            If (txtPersona.Tag <> "") Then
                sResponsable = " Responsable :" & txtPersona.Text
            End If

            If (txtBanco.Tag <> "") Then
                sBanco = " Banco: " & txtBanco.Text
            End If


            Dim frm = ContainerService.Resolve(Of Ladisac.Reporteador)()



            otable = BCKardexCtaCte.spDepositoTerceros(CDate(dateDesde.Text), CDate(dateHasta.Text), txtPersona.Tag, txtBanco.Tag, txtCliente.Tag, tipoReporte)
            oReporte.Database.Tables(0).SetDataSource(otable)
            oReporte.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde" & dateDesde.Text & "  hasta " & dateHasta.Text & sResponsable & sBanco & "'"
            frm.Reporte(oReporte)


            frm.Show()
        End Sub

        Private Sub btnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCliente.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarPersona)

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtCliente.Tag = .Cells(0).Value()
                        txtCliente.Text = .Cells(1).Value
                    End With
                End If
                frm.Dispose()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnLimpiarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarCliente.Click
            txtCliente.Text = ""
            txtCliente.Tag = ""
        End Sub
    End Class
End Namespace
