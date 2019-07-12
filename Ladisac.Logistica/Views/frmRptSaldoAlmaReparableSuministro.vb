Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports Microsoft.Reporting.WinForms

Public Class frmRptSaldoAlmaReparableSuministro

    <Dependency()> _
    Public Property BCKardex As Ladisac.BL.IBCKardex
    Dim oreporte As New rptSaldoAlmaReparableSuministro
    Private Sub frmRptSaldoAlmaReparableSuministro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblTitle.Text = "Saldos de Almacen de Reparables y Suministros"
        Me.Text = "Saldos de Almacen de Reparables y Suministros"

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim oTable As New DataTable

        Try
            oTable = Me.BCKardex.spSaldoAlmaReparableSuministro(CDate(dateDesde.Text), CDate(dateHasta.Text))
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmVisorReportes)()

            oreporte.Database.Tables(0).SetDataSource(oTable)

            oreporte.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & " ' "

            frm.Reporte(oreporte)
            frm.ShowDialog()


        Catch ex As Exception

        End Try
    End Sub
End Class