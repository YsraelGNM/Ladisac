Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms

Public Class frmReporteVentaGuiasProduccion
    <Dependency()> _
    Public Property BCDespachos As Ladisac.BL.IBCDespachos

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        If rbtDocumentoFacturas.Checked Then
            BCDespachos.spReporteDocumentoGuiasXLS(dtpFechaIni.Value, dtpFechaFin.Value)
        End If
        If rbtProcesoTerminado.Checked Then
            BCDespachos.spListaProcesoTerminadoXLS(dtpFechaFin.Value)
        End If
        If rbtStockLadrillo.Checked Then
            BCDespachos.spListaSaldoXAlmacenesLadrilloXLS(Nothing, Nothing, dtpFechaFin.Value)
        End If
        If rbtDocumentoGuias.Checked Then
            BCDespachos.spListaDocumentoGuiaCliente_1XLS(Nothing, dtpFechaIni.Value, dtpFechaFin.Value, False)
        End If
        If rbtPendientesEntrega.Checked Then
            BCDespachos.spKardexDocumentoDespachoNuevo3XLS("001", Nothing, "001", Nothing, Nothing, " AND PER_ID_CLI<>'041603' AND FECHA<='" & dtpFechaFin.Value.Year.ToString & Strings.Right("0" & dtpFechaFin.Value.Month.ToString, 2) & Strings.Right("0" & dtpFechaFin.Value.Day.ToString, 2) & "'", "TRUE")
        End If
    End Sub
End Class
