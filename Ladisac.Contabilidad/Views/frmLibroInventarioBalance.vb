Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views
    Public Class frmLibroInventarioBalance
        <Dependency()>
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro
        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad
        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService


        Dim oReporte As New Object
        Dim oReporte10 As New rptLibroInventarioBalance10
        Dim oReporte12 As New rptLibroInventarioBalance
        Dim oReporte14 As New rptLibroInventarioBalance14
        Dim oReporte16 As New rptLibroInventarioBalance16
        Dim oReporte30 As New rptLibroInventarioBalance30
        Dim oReporte40 As New rptLibroInventarioBalance40
        Dim oReporte41 As New rptLibroInventarioBalance41
        Dim oReporte42 As New rptLibroInventarioBalance42
        Dim oReporte46 As New rptLibroInventarioBalance46
        Dim oReporte47 As New rptLibroInventarioBalance47
        Dim oReporte50 As New rptLibroInventarioBalance50

        Dim oReporteExistencias As New rptLibroInventarioBalanceExistencias

        Dim oReporteCajaBancos As New rptLibroCajaBancos
        Dim oReporteCajaBancosxMes As New rptLibroCajaBancosXMes
        Dim oReporteCajaBancosCtaCte As New rptLibroCajaBancosCtaCte

        Dim rptFormato36 As New rptFormatoCobranzaDudosa36Nuevo
        Dim rptFormato317 As New rptFormatoBalanceComprobacion317Nuevo

        Dim oReporteBalanceGeneral As New rptBalanceGeneral
        Dim oReportePatrimonioNeto As New rptPatrimonioNeto
        Dim oReporteEstadoGananciasPerdidas As New rptEstadoGananciasPerdidas

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles _
            btnCta10.Click, btnCta12.Click, btnCta14.Click, btnCta16.Click, _
            btnCta17.Click, btnCta18.Click, btnCta19.Click, btnCta30.Click, _
            btnCta31.Click, btnCta34.Click, _
            btnCta37.Click, btnCta40.Click, btnCta41.Click, btnCta42.Click, _
            btnCta43.Click, btnCta44.Click, btnCta45.Click, btnCta46.Click, _
            btnCta47X.Click, _
            btnCta47.Click, btnCta48.Click, btnCta49.Click, btnCta50.Click, _
            btnExistencias.Click, btnExistencias32.Click, btnExistencias33.Click, btnExistencias39.Click, _
            btnExistencias56.Click, btnExistencias58.Click, btnExistencias59.Click, _
            btnBalanceComprobacion.Click, btnPatrimonioNeto.Click, btnEstadoGananciasPerdidas.Click, btnCajaBancos.Click, btnCajaBancosCtaCte.Click, _
            btnBalanceGeneral.Click
            'Me.Cursor = Cursors.WaitCursor
            Try
                Dim vPeriodo As String = ""
                Dim vPeriodo0 As String = ""
                Dim vPeriodo1 As String = ""

                Dim vPeriodoInicio As String = ""
                Dim vPeriodoFin As String = ""

                Dim vCuenta As String = ""
                Dim ds As New DataSet
                Dim sr As Object
                vPeriodo = CStr(nudAnio.Value + 1) + "01"
                vPeriodo0 = CStr(nudAnio.Value) + "01"
                vPeriodo1 = CStr(nudAnio.Value) + "12"


                vPeriodoInicio = CStr(nudAnio.Value - 1) + "01"
                vPeriodoFin = CStr(nudAnio.Value + 1) + "01"

                Select Case sender.name
                    Case "btnCta10"
                        vCuenta = "10"
                        oReporte = oReporte10
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.2: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 10 - CAJA Y BANCOS'"
                    Case "btnCta12"
                        vCuenta = "12"
                        oReporte = oReporte12
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.3: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 12 - CUENTAS POR COBRAR COMERCIALES - TERCEROS'"
                    Case "btnCta14"
                        vCuenta = "14"
                        oReporte = oReporte14
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.4: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 14 - CUENTAS POR COBRAR ACCIONISTAS (O SOCIOS) Y PERSONAL'"
                    Case "btnCta16"
                        vCuenta = "16"
                        oReporte = oReporte16
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.5: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 16 - CUENTAS POR COBRAR DIVERSAS - TERCEROS'"
                    Case "btnCta17"
                        vCuenta = "17"
                        oReporte = oReporte16
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.5: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 17 - CUENTAS POR COBRAR DIVERSAS - RELACIONADAS'"
                    Case "btnCta18"
                        vCuenta = "18"
                        oReporte = oReporte16
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.5: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 18 - SERVICIOS Y OTROS CONTRATOS X ANTICIPADO'"
                    Case "btnCta19"
                        Dim oTable As New DataTable
                        oTable = Me.BCConsultasReportesContabilidad.RPTFormatoSaldoClientes33(vPeriodo1, "3.6")

                        Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()
                        rptFormato36.DataDefinition.FormulaFields("RucEmpresa").Text = "'" & SessionServer.RUCEmpresa & "'"
                        rptFormato36.DataDefinition.FormulaFields("NombreEmpresa").Text = "'" & SessionServer.NombreEmpresa & "'"
                        rptFormato36.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " - Diciembre'"
                        rptFormato36.Database.Tables(0).SetDataSource(oTable)
                        frm.Reporte(rptFormato36)
                        frm.ShowDialog()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    Case "btnCta30"
                        vCuenta = "30"
                        oReporte = oReporte30
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.9: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 30 - INVERSIONES MOBILIARIAS'"
                    Case "btnCta31"
                        vCuenta = "31"
                        oReporte = oReporte12
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.8: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 31 - INVERSIONES INMOBILIARIAS'"
                    Case "btnCta34"
                        vCuenta = "34"
                        oReporte = oReporte30
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.9: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 34 - ACTIVOS INTANGIBLES'"
                    Case "btnCta37"
                        vCuenta = "37"
                        oReporte = oReporte42
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.12: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 37 - ACTIVO DIFERIDO'"
                    Case "btnCta40"
                        vCuenta = "40"
                        oReporte = oReporte40
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.10: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 40 - TRIBUTOS POR PAGAR'"
                    Case "btnCta41"
                        vCuenta = "41"
                        oReporte = oReporte41
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.11: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 41 - REMUNERACIONES POR PAGAR'"
                    Case "btnCta42"
                        vCuenta = "42"
                        oReporte = oReporte42
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.12: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 42 - CUENTAS POR PAGAR COMERCIALES - TERCEROS'"
                    Case "btnCta43"
                        vCuenta = "43"
                        oReporte = oReporte42
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.12: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 43 - CUENTAS POR PAGAR COMERCIALES - RELACIONADAS'"
                    Case "btnCta44"
                        vCuenta = "44"
                        oReporte = oReporte42
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.12: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 44 - CUENTAS POR PAGAR A LOS ACCIONISTAS, DIRECTORES Y GERENTES'"
                    Case "btnCta45"
                        vCuenta = "45"
                        oReporte = oReporte42
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.12: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 45 - OBLIGACIONES FINANCIERAS'"
                    Case "btnCta46"
                        vCuenta = "46"
                        oReporte = oReporte46
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.13: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 46 - CUENTAS POR PAGAR DIVERSAS - TERCEROS'"
                    Case "btnCta47X"
                        vCuenta = "47"
                        oReporte = oReporte47
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.14: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 47 - CUENTAS POR PAGAR DIVERSAS - RELACIONADAS'"
                    Case "btnCta47"
                        vCuenta = "47"
                        oReporte = oReporte42
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.14: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 47 - CUENTAS POR PAGAR DIVERSAS - RELACIONADAS'"
                    Case "btnCta48"
                        vCuenta = "48"
                        oReporte = oReporte42
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.12: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 48 - PROVISIONES'"
                    Case "btnCta49"
                        vCuenta = "49"
                        oReporte = oReporte42
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.15: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DEL SALDO DE LA CUENTA 49 - PASIVO DIFERIDO'"
                    Case "btnCta50"
                        vCuenta = "50"
                        oReporte = oReporte50
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.16: LIBRO DE INVENTARIOS Y BALANCE'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "''"
                    Case "btnExistencias"
                        vCuenta = ""
                        oReporte = oReporteExistencias
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.7: EXISTENCIAS'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "''"
                    Case "btnExistencias32"
                        vCuenta = ""
                        oReporte = oReporteExistencias
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.7: EXISTENCIAS'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "''"
                    Case "btnExistencias33"
                        vCuenta = ""
                        oReporte = oReporteExistencias
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.7: EXISTENCIAS'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "''"
                    Case "btnExistencias39"
                        vCuenta = ""
                        oReporte = oReporteExistencias
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.7: EXISTENCIAS'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "''"
                    Case "btnExistencias56"
                        vCuenta = ""
                        oReporte = oReporteExistencias
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.7: EXISTENCIAS'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "''"
                    Case "btnExistencias58"
                        vCuenta = ""
                        oReporte = oReporteExistencias
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.7: EXISTENCIAS'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "''"
                    Case "btnExistencias59"
                        vCuenta = ""
                        oReporte = oReporteExistencias
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.7: EXISTENCIAS'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "''"
                    Case "btnBalanceComprobacion"
                        Dim oTable As New DataTable
                        oTable = Me.BCConsultasReportesContabilidad.HojaTrabajoReporteNuevoQuery(vPeriodo1, 1, 10, "A", "")
                        Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()
                        rptFormato317.DataDefinition.FormulaFields("RucEmpresa").Text = "'" & SessionServer.RUCEmpresa & "'"
                        rptFormato317.DataDefinition.FormulaFields("NombreEmpresa").Text = "'" & SessionServer.NombreEmpresa & "'"
                        rptFormato317.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " - Diciembre'"
                        rptFormato317.Database.Tables(0).SetDataSource(oTable)
                        frm.Reporte(rptFormato317)
                        frm.ShowDialog()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    Case "btnPatrimonioNeto"
                        vCuenta = ""
                        oReporte = oReportePatrimonioNeto
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.19: LIBRO DE INVENTARIOS Y BALANCES'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'PATRIMONIO NETO'"
                    Case "btnEstadoGananciasPerdidas"
                        vCuenta = ""
                        oReporte = oReporteEstadoGananciasPerdidas
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 3.20: LIBRO DE INVENTARIOS Y BALANCES'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'ESTADO DE GANANCIAS Y PÉRDIDAS POR FUNCIÓN'"

                    Case "btnCajaBancos"
                        vCuenta = "10"
                        'oReporte = oReporteCajaBancos
                        oReporte = oReporteCajaBancosxMes
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 1.1: LIBRO DE CAJA Y BANCOS'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DE LOS MOVIMIENTOS EN EFECTIVO'"
                    Case "btnCajaBancosCtaCte"
                        vCuenta = "10"
                        oReporte = oReporteCajaBancosCtaCte
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'FORMATO 1.2: LIBRO DE CAJA Y BANCOS'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'DETALLE DE LOS MOVIMIENTOS DE LA CUENTA CORRIENTE'"
                    Case "btnBalanceGeneral"
                        vCuenta = ""
                        oReporte = oReporteBalanceGeneral
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'BALANCE GENERAL'"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "''"
                    Case Else
                End Select

                Select Case sender.name
                    Case "btnCta10"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " - Diciembre'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalCta10XML", vPeriodo, "000", vCuenta))
                    Case "btnCta30"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " - Diciembre'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalCta30XML", vPeriodo0, vPeriodo1, vCuenta))
                    Case "btnCta34"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " - Diciembre'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalCta30XML", vPeriodo0, vPeriodo1, vCuenta))
                    Case "btnCta40"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " - Diciembre'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalCta40XML", vPeriodo, "000", vCuenta))
                    Case "btnCta41"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " - Diciembre'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalCta41XML", vPeriodo, "000", vCuenta))
                    Case "btnCta47X"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " - Diciembre'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalCta41XML", vPeriodo, "000", vCuenta))
                    Case "btnCta50"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'AL 31 DE DICIEMBRE DEL " + CStr(nudAnio.Value) + "'"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'( expresado en Nuevos Soles )'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalCta50XML", vPeriodo0, vPeriodo1, vCuenta))
                    Case "btnExistencias"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'AL 31 DE DICIEMBRE DEL " + CStr(nudAnio.Value) + "'"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'( expresado en Nuevos Soles )'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalExistenciasXML", vPeriodo, "000"))
                    Case "btnExistencias32"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'AL 31 DE DICIEMBRE DEL " + CStr(nudAnio.Value) + "'"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'( expresado en Nuevos Soles )'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalExistencias32XML", vPeriodo, "000"))
                    Case "btnExistencias33"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'AL 31 DE DICIEMBRE DEL " + CStr(nudAnio.Value) + "'"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'( expresado en Nuevos Soles )'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalExistencias33XML", vPeriodo, "000"))
                    Case "btnExistencias39"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'AL 31 DE DICIEMBRE DEL " + CStr(nudAnio.Value) + "'"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'( expresado en Nuevos Soles )'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalExistencias39XML", vPeriodo, "000"))
                    Case "btnExistencias56"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'AL 31 DE DICIEMBRE DEL " + CStr(nudAnio.Value) + "'"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'( expresado en Nuevos Soles )'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalExistencias56XML", vPeriodo, "000"))
                    Case "btnExistencias58"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'AL 31 DE DICIEMBRE DEL " + CStr(nudAnio.Value) + "'"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'( expresado en Nuevos Soles )'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalExistencias58XML", vPeriodo, "000"))
                    Case "btnExistencias59"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'AL 31 DE DICIEMBRE DEL " + CStr(nudAnio.Value) + "'"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'( expresado en Nuevos Soles )'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalExistencias59XML", vPeriodo, "000"))
                    Case "btnCajaBancos"
                        'oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Diciembre'"
                        'sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibCajaBancosEfectivoXML", vPeriodo0, "000", vCuenta))
                        Select Case cboMes.Text
                            Case "Enero"
                                'oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Enero'"
                                vPeriodo0 = CStr(nudAnio.Value) + "01"
                            Case "Febrero"
                                'oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Febrero'"
                                vPeriodo0 = CStr(nudAnio.Value) + "02"
                            Case "Marzo"
                                'oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Marzo'"
                                vPeriodo0 = CStr(nudAnio.Value) + "03"
                            Case "Abril"
                                'oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Abril'"
                                vPeriodo0 = CStr(nudAnio.Value) + "04"
                            Case "Mayo"
                                'oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Mayo'"
                                vPeriodo0 = CStr(nudAnio.Value) + "05"
                            Case "Junio"
                                'oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Junio'"
                                vPeriodo0 = CStr(nudAnio.Value) + "06"
                            Case "Julio"
                                'oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Julio'"
                                vPeriodo0 = CStr(nudAnio.Value) + "07"
                            Case "Agosto"
                                'oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Agosto'"
                                vPeriodo0 = CStr(nudAnio.Value) + "08"
                            Case "Septiembre"
                                'oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Septiembre'"
                                vPeriodo0 = CStr(nudAnio.Value) + "09"
                            Case "Octubre"
                                'oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Octubre'"
                                vPeriodo0 = CStr(nudAnio.Value) + "10"
                            Case "Noviembre"
                                'oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Noviembre'"
                                vPeriodo0 = CStr(nudAnio.Value) + "11"
                            Case "Diciembre"
                                'oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Diciembre'"
                                vPeriodo0 = CStr(nudAnio.Value) + "12"
                        End Select
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibCajaBancosEfectivoXML_2", vPeriodo0, "000", vCuenta))
                    Case "btnCajaBancosCtaCte"
                        'oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Diciembre'"


                        Select Case cboMes.Text
                            Case "Enero"
                                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero'"
                                vPeriodo0 = CStr(nudAnio.Value) + "01"
                            Case "Febrero"
                                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Febrero'"
                                vPeriodo0 = CStr(nudAnio.Value) + "02"
                            Case "Marzo"
                                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Marzo'"
                                vPeriodo0 = CStr(nudAnio.Value) + "03"
                            Case "Abril"
                                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Abril'"
                                vPeriodo0 = CStr(nudAnio.Value) + "04"
                            Case "Mayo"
                                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Mayo'"
                                vPeriodo0 = CStr(nudAnio.Value) + "05"
                            Case "Junio"
                                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Junio'"
                                vPeriodo0 = CStr(nudAnio.Value) + "06"
                            Case "Julio"
                                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Julio'"
                                vPeriodo0 = CStr(nudAnio.Value) + "07"
                            Case "Agosto"
                                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Agosto'"
                                vPeriodo0 = CStr(nudAnio.Value) + "08"
                            Case "Septiembre"
                                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Septiembre'"
                                vPeriodo0 = CStr(nudAnio.Value) + "09"
                            Case "Octubre"
                                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Octubre'"
                                vPeriodo0 = CStr(nudAnio.Value) + "10"
                            Case "Noviembre"
                                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Noviembre'"
                                vPeriodo0 = CStr(nudAnio.Value) + "11"
                            Case "Diciembre"
                                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Diciembre'"
                                vPeriodo0 = CStr(nudAnio.Value) + "12"
                        End Select


                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibCajaBancosCtaCteXML", vPeriodo0, "000", vCuenta))
                    Case "btnPatrimonioNeto"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Diciembre'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spPatrimonioNetoXML", vPeriodoInicio, vPeriodoFin))
                    Case "btnEstadoGananciasPerdidas"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " Enero - Diciembre'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spEstadoPerdidasGananciasXML", vPeriodo0))
                    Case "btnBalanceGeneral"
                        oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'AL 31 DE DICIEMBRE DEL " + CStr(nudAnio.Value) + "'"
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'( expresado en Nuevos Soles )'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spBalanceGeneralXML", vPeriodo))
                    Case Else
                        oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'PERIODO: " + CStr(nudAnio.Value) + " - Diciembre'"
                        sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spLibInvBalXML", vPeriodo, "000", vCuenta))
                End Select


                Dim vcontrol As Int16 = sr.Peek
                If vcontrol <> -1 Then
                    ds.ReadXml(sr)
                    oReporte.Database.Tables(0).SetDataSource(ds.Tables(0))
                    oReporte.DataDefinition.FormulaFields("RucEmpresa").Text = "'" & SessionServer.RUCEmpresa & "'"
                    oReporte.DataDefinition.FormulaFields("NombreEmpresa").Text = "'" & SessionServer.NombreEmpresa & "'"

                    Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()
                    frm.Reporte(oReporte)
                    frm.Show()
                    frm.BringToFront()
                Else
                    MsgBox("No se genero datos, reporte vacio", MsgBoxStyle.Information, Me.Text & " - Generar")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Me.Cursor = Cursors.Default
        End Sub
        Private Sub frmLibroInventarioBalance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            nudAnio.Value = Year(Now)
        End Sub

    End Class

End Namespace
