Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports Microsoft.Reporting.WinForms

Namespace Ladisac.Contabilidad.Views
    Public Class frmReportesXPeriodoNuevo


        <Dependency()>
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad

        Dim sBusco As String
        Dim rptFormatos41 As New rptFormatoVenta14
        Dim rptFormato81 As New rptFormatoCompra81
        Dim rptFormatoCuenta As New rptFormatoCuenta
        Dim rptFormato61 As New rptFormatoMayorGeneral61
        Dim rptFormato32 As New rptFormatoInventarioYBalance32
        Dim rptFormato33 As New rptFormatoSaldoClientes33
        Dim rptFormato34 As New rptFormatoCuentasXCobrar34
        Dim rptFormato35 As New rptFormatoCuentasXCobrarVarias35
        Dim rptFormato36 As New rptFormatoCobranzaDudosa36
        Dim rptFormato310 As New rptFormatosTributos310
        Dim rptFormato311 As New rptFormatoRenumeracionXPagar311
        Dim rptFormato312 As New rptFormatoProveedore42
        Dim rptFormato313 As New rptFormatoCuentasXPagarDiversas313
        Dim rptFormato317 As New rptFormatoBalanceComprobacion317
        Dim rptCuentasContables As New rptFormatoCuentasContables

        'Dim rptLibroDiarioGeneral51 As New rptLibroDiarioGeneral
        'Dim rptLibroDiarioGeneral51 As New rptLibroDiario
        Dim rptLibroDiarioGeneral51 As New rptLibroDiarioNuevo

        Dim rptAsientosConProblemas As New rptAuxiliaresAsientosConProblemas
        Dim rptReportDestinoCompras As New rptSelectReportDestinoCompras

        <Dependency()> _
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService


        Public Sub inicio(ByVal queBusco As String)
            sBusco = queBusco
            Dim CadenaVista As String = ""
            CadenaVista = IBCMaestro.EjecutarVista("dbo.spPeriodosXml")

            Dim ds As New DataSet
            Dim sr As New StringReader(CadenaVista)
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)

                Dim x As Int32 = 0
                Dim y As Int32 = 0
                dgvPeriodos.Rows.Clear()
                If (ds.Tables(0).Rows.Count > 0) Then
                    While (x < ds.Tables(0).Rows.Count)
                        dgvPeriodos.Rows.Add()
                        With ds.Tables(0).Rows(x)
                            While y < ds.Tables(0).Columns.Count
                                Select ds.Tables(0).Columns(y).ColumnName
                                    Case "Periodo"
                                        dgvPeriodos.Item(y, dgvPeriodos.Rows.Count - 1).Value = .Item(y).ToString
                                    Case "Selección"
                                        dgvPeriodos.Item(y, dgvPeriodos.Rows.Count - 1).Value = CBool(.Item(y))
                                End Select
                                y += 1
                            End While
                            y = 0
                        End With
                        x += 1
                    End While
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information, Me.Text)
                End If
            Else
                dgvPeriodos.DataSource = Nothing
            End If

            CadenaVista = IBCMaestro.EjecutarVista("dbo.spLibrosXml")
            Dim ds1 As New DataSet
            Dim sr1 As New StringReader(CadenaVista)
            Dim vcontrol1 As Int16 = sr1.Peek
            If vcontrol1 <> -1 Then
                ds1.ReadXml(sr1)

                Dim x As Int32 = 0
                Dim y As Int32 = 0
                dgvLibros.Rows.Clear()
                If (ds1.Tables(0).Rows.Count > 0) Then
                    While (x < ds1.Tables(0).Rows.Count)
                        dgvLibros.Rows.Add()
                        With ds1.Tables(0).Rows(x)
                            While y < ds1.Tables(0).Columns.Count
                                Select Case ds1.Tables(0).Columns(y).ColumnName
                                    Case "Código", "Descripción"
                                        dgvLibros.Item(y, dgvLibros.Rows.Count - 1).Value = .Item(y).ToString
                                    Case "Selección"
                                        dgvLibros.Item(y, dgvLibros.Rows.Count - 1).Value = CBool(.Item(y))
                                End Select
                                y += 1
                            End While
                            y = 0
                        End With
                        x += 1
                    End While
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information, Me.Text)
                End If
            Else
                dgvLibros.DataSource = Nothing
            End If

            btnGenerar.Visible = True
        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            'Me.Cursor = Cursors.WaitCursor

            Dim vCadenaPeriodo As String = ""
            Dim vCadenaPeriodoTitulo As String = ""
            Dim vCadenaLibros As String = ""
            Dim vContador As Int16 = 0

            For vFilas = 0 To dgvPeriodos.RowCount - 1
                If dgvPeriodos.Item("cSeleccion", vFilas).Value = True Then
                    vContador += 1
                    If vContador = 1 Then
                    Else
                        vCadenaPeriodo &= ","
                        vCadenaPeriodoTitulo &= " - "
                    End If

                    vCadenaPeriodo &= "'" & dgvPeriodos.Item("cPeriodo", vFilas).Value & "'"
                    vCadenaPeriodoTitulo &= dgvPeriodos.Item("cPeriodo", vFilas).Value
                End If
            Next

            vContador = 0
            For vFilas = 0 To dgvLibros.RowCount - 1
                If dgvLibros.Item("cSeleccion1", vFilas).Value = True Then
                    vContador += 1
                    If vContador = 1 Then
                    Else
                        vCadenaLibros &= ","
                    End If

                    vCadenaLibros &= "'" & dgvLibros.Item("cCodigo1", vFilas).Value & "'"
                End If
            Next

            If vCadenaLibros = "" Then
                vCadenaLibros = "  "
            Else
                vCadenaLibros = "  and a.lib_id in (" & vCadenaLibros & ")"
            End If


            Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()
            Dim query As String = Nothing
            Dim oTable As New DataTable

            If vCadenaPeriodo = "" Then
                oTable = Nothing
                MsgBox("¡No selecciono periodos!", MsgBoxStyle.Information, Me.Text)
            Else
                vCadenaPeriodoTitulo = "Periodo : " & vCadenaPeriodoTitulo
                oTable = Me.BCConsultasReportesContabilidad.SPLibroDiarioGeneral(vCadenaPeriodo, vCadenaLibros)
                rptLibroDiarioGeneral51.Database.Tables(0).SetDataSource(oTable)
                rptLibroDiarioGeneral51.DataDefinition.FormulaFields("Titulo1").Text = "'Libro Diario'"
                rptLibroDiarioGeneral51.DataDefinition.FormulaFields("Titulo2").Text = "'" & vCadenaPeriodoTitulo & "'"

                rptLibroDiarioGeneral51.DataDefinition.FormulaFields("NombreEmpresa").Text = "'" & SessionService.NombreEmpresa & "'"
                rptLibroDiarioGeneral51.DataDefinition.FormulaFields("RucEmpresa").Text = "'" & SessionService.RUCEmpresa & "'"


                frm.Reporte(rptLibroDiarioGeneral51)
                frm.ShowDialog()
            End If




            Me.Cursor = Cursors.Default

            'Dim query As String = Nothing
            'Dim oTable As New DataTable

            'Try

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Formatos41) Then

            '        oTable = Me.BCConsultasReportesContabilidad.RPTFormatoVenta14(txtPeriodo.Text)

            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCompra81) Then

            '        oTable = Me.BCConsultasReportesContabilidad.RPTFormatoCompra81(txtPeriodo.Text)

            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoMayorGeneral61) Then

            '        oTable = Me.BCConsultasReportesContabilidad.RPTFormatoMayorGeneral61(txtPeriodo.Text, 4)

            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoInventarioYBalance32) Then
            '        ''3.2   	Libro de Inventarios y Balance - Detalle del saldo de la cuenta 10 - Caja y Bancos	 desde: 10            	 hasta :1071
            '        '' se configuara en table  Con.ConfiguracionFormatos 
            '        oTable = Me.BCConsultasReportesContabilidad.RPTFormatoInventarioYBalance32(txtPeriodo.Text, "3.2")

            '    End If


            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoSaldoClientes33) Then

            '        oTable = Me.BCConsultasReportesContabilidad.RPTFormatoSaldoClientes33(txtPeriodo.Text, "3.3")

            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCuentasXCobrarAccionistas34) Then

            '        oTable = Me.BCConsultasReportesContabilidad.RPTFormatoSaldoClientes33(txtPeriodo.Text, "3.4")

            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCuentasXCobrarDiversas35) Then

            '        oTable = Me.BCConsultasReportesContabilidad.RPTFormatoSaldoClientes33(txtPeriodo.Text, "3.5")

            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCobranzaDudosa36) Then

            '        oTable = Me.BCConsultasReportesContabilidad.RPTFormatoSaldoClientes33(txtPeriodo.Text, "3.6")

            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosTributos310) Then

            '        oTable = Me.BCConsultasReportesContabilidad.RPTFormatosTributos310(txtPeriodo.Text, "3.10")

            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosRenumeracionXPagar311) Then

            '        oTable = Me.BCConsultasReportesContabilidad.RPTFormatoSaldoClientes33(txtPeriodo.Text, "3.11")

            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosProveedores312) Then

            '        oTable = Me.BCConsultasReportesContabilidad.RPTFormatoSaldoClientes33(txtPeriodo.Text, "3.12")

            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosCuentasXPagarDiversas313) Then

            '        oTable = Me.BCConsultasReportesContabilidad.RPTFormatoSaldoClientes33(txtPeriodo.Text, "3.13")

            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosBalandeComprobacion317) Then

            '        oTable = Me.BCConsultasReportesContabilidad.HojaTrabajoReporteQuery(txtPeriodo.Text, 1, 10, "A", "")

            '    End If
            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCuentaContable) Then

            '        oTable = Me.BCConsultasReportesContabilidad.RPTFormatoCuentaContable(txtPeriodo.Text)

            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.AsientosConProblemas) Then

            '        oTable = Me.BCConsultasReportesContabilidad.RPTReportAsientosConProblemas(txtPeriodo.Text, txtLibro.Tag)

            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ReportDestinoCompras) Then
            '        oTable = Me.BCConsultasReportesContabilidad.SPSelectReportDestinoCompras(txtPeriodo.Text)

            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.LibroDiarioGeneral) Then
            '        'oTable = Me.BCConsultasReportesContabilidad.SPLibroDiarioGeneral(txtPeriodo.Text, Nothing)
            '        oTable = Me.BCConsultasReportesContabilidad.SPLibroDiarioGeneral(txtPeriodo.Text, Nothing)
            '    End If


            '    If (query <> Nothing) Then
            '        Dim ds As New DataSet

            '        Dim rea As New StringReader(query)
            '        If (query <> "") Then
            '            ds.ReadXml(rea)
            '            oTable = ds.Tables(0)
            '        Else
            '            oTable.Clear()

            '        End If

            '    End If


            '    Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Formatos41) Then

            '        rptFormatos41.DataDefinition.FormulaFields("Empresa").Text = "'" & SessionService.NombreEmpresa & "'"
            '        rptFormatos41.DataDefinition.FormulaFields("Ruc").Text = "'" & SessionService.RUCEmpresa & "'"

            '        rptFormatos41.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptFormatos41)
            '    End If
            '    'rptFormato81
            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCompra81) Then

            '        rptFormato81.DataDefinition.FormulaFields("Empresa").Text = "'" & SessionService.NombreEmpresa & "'"
            '        rptFormato81.DataDefinition.FormulaFields("Ruc").Text = "'" & SessionService.RUCEmpresa & "'"


            '        rptFormato81.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptFormato81)
            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoMayorGeneral61) Then

            '        rptFormato61.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptFormato61)
            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoInventarioYBalance32) Then

            '        rptFormato32.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptFormato32)
            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoSaldoClientes33) Then

            '        rptFormato33.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptFormato33)
            '    End If
            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCuentasXCobrarAccionistas34) Then

            '        rptFormato34.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptFormato34)
            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCuentasXCobrarDiversas35) Then

            '        rptFormato35.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptFormato35)
            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCobranzaDudosa36) Then

            '        rptFormato36.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptFormato36)
            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosTributos310) Then

            '        rptFormato310.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptFormato310)
            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosRenumeracionXPagar311) Then

            '        rptFormato311.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptFormato311)
            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosProveedores312) Then

            '        rptFormato312.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptFormato312)
            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosCuentasXPagarDiversas313) Then

            '        rptFormato313.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptFormato313)
            '    End If


            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosBalandeComprobacion317) Then

            '        rptFormato317.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptFormato317)
            '    End If
            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCuentaContable) Then

            '        rptCuentasContables.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptCuentasContables)
            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.AsientosConProblemas) Then

            '        rptAsientosConProblemas.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptAsientosConProblemas)
            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ReportDestinoCompras) Then
            '        rptReportDestinoCompras.Database.Tables(0).SetDataSource(oTable)
            '        frm.Reporte(rptReportDestinoCompras)
            '    End If

            '    If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.LibroDiarioGeneral) Then
            '        rptLibroDiarioGeneral51.Database.Tables(0).SetDataSource(oTable)
            '        rptLibroDiarioGeneral51.DataDefinition.FormulaFields("Titulo1").Text = "'Libro Diario'"
            '        rptLibroDiarioGeneral51.DataDefinition.FormulaFields("Titulo2").Text = "'" & txtPeriodo.Text & "'"
            '        frm.Reporte(rptLibroDiarioGeneral51)
            '    End If


            '    frm.ShowDialog()
            'Catch ex As Exception
            '    MsgBox("No se puede mostrar la informacion :" & ex.Message)
            'End Try


        End Sub
    End Class
End Namespace