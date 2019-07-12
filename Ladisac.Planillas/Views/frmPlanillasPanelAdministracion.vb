
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports System.Collections

Namespace Ladisac.Planillas.Views
    Public Class frmPlanillasPanelAdministracion

        <Dependency()> _
        Public Property BCPlanilla As BL.IBCPlanilla
        <Dependency()> _
        Public Property BCConsultasReportesPlanillas As BL.IBCConsultasReportesPlanillas
        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil

        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService



        Dim oReporte As New rptPlanillasBoletas
        Dim oreporteConsolidado As New rptReportePlanillaConsolidado

        Private Sub btnPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodo.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodoDesde.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtPeriodoHasta.Text = txtPeriodoDesde.Text

            End If

            frm.Dispose()
        End Sub

        Private Sub cargarBoletas()
            Dim query As String = Nothing

            dgvBoletas.DataSource = Nothing

            dgvBoletas.DataSource = Me.BCPlanilla.spPlanillaBuscarSelectXML(txtPeriodoDesde.Text, txtPeriodoHasta.Text, Nothing, Nothing, Nothing)


            If (dgvBoletas.Rows.Count > 0) Then
                dgvBoletas.Columns(0).Width = 40
                dgvBoletas.Columns(1).Width = 50

                dgvBoletas.Columns(2).Width = 40

                dgvBoletas.Columns(3).Width = 90
                dgvBoletas.Columns(5).Width = dgvBoletas.Columns(5).Width + 170
            End If
            'If (query <> Nothing) Then
            '    Dim ds As New DataSet
            '    Dim rea As New StringReader(query)
            '    If (query <> "") Then
            '        ds.ReadXml(rea)
            '        dgvBoletas.DataSource = ds.Tables(0)

            '    Else
            '        dgvBoletas.DataSource = Nothing
            '    End If
            'End If

        End Sub

        Private Sub cargarPersonas()
            Dim query As String = Nothing

            dgvPersonas.DataSource = Nothing

            query = Me.BCPlanilla.spPlanillaPersonaTotalesSelectXML(BCUtil.getXml(0, dgvBoletas, 2, 3))

            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    dgvPersonas.DataSource = ds.Tables(0)

                Else
                    dgvPersonas.DataSource = Nothing
                End If
            End If

            ' suma y conteo de registros 
            '-----------------------------------------------------------------
            Dim x As Integer = 0
            Dim dTotalINgreso, dTotalEgreso, neto As Double

            dTotalINgreso = 0
            dTotalEgreso = 0
            neto = 0

            While (dgvPersonas.Rows.Count > x)
                Try

                    dTotalINgreso += dgvPersonas.Rows(x).Cells("TotalIngreso").Value
                    dTotalEgreso += dgvPersonas.Rows(x).Cells("totalEgreso").Value
                    neto += dgvPersonas.Rows(x).Cells("Neto").Value

                Catch ex As Exception

                End Try
                x += 1
            End While


            txtTotalINgreso.Text = Math.Round(dTotalINgreso, 2)
            txtTotalEgreso.Text = Math.Round(dTotalEgreso, 2)
            txtTotalNeto.Text = Math.Round(neto, 2)
            txtTotalRegistros.Text = x.ToString
            If (dgvPersonas.Rows.Count > 0) Then
                dgvPersonas.Columns(0).Visible = False
                dgvPersonas.Columns(1).Visible = False
                'dgvPersonas.Columns(2).Visible = False
            End If



        End Sub
        Private Sub cargarConceptosPlanillas(ByVal serie As String, ByVal numero As String, ByVal idpersona As String)
            Dim query As String = Nothing

            dgvConceptosTrabajador.DataSource = Nothing

            query = Me.BCPlanilla.spPlanillaPersonaDetalleSelectXML(serie, numero, idpersona)

            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    dgvConceptosTrabajador.DataSource = ds.Tables(0)

                    dgvConceptosTrabajador.Columns(0).Visible = False
                    dgvConceptosTrabajador.Columns(1).Visible = False
                    dgvConceptosTrabajador.Columns(2).Visible = False
                    dgvConceptosTrabajador.Columns(3).Visible = False
                    dgvConceptosTrabajador.Columns(4).Visible = False
                    dgvConceptosTrabajador.Columns(5).Visible = False
                    dgvConceptosTrabajador.Columns(6).Visible = False
                    dgvConceptosTrabajador.Columns(7).Visible = False



                Else
                    dgvConceptosTrabajador.DataSource = Nothing
                End If
            End If
        End Sub

        Private Sub dgvBoletas_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvBoletas.RowHeaderMouseDoubleClick
            dgvBoletas.EndEdit()
            cargarPersonas()


        End Sub

        Private Sub dgvPersonas_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPersonas.RowHeaderMouseDoubleClick

            If (dgvPersonas.SelectedRows.Count > 0) Then
                Panel4.Visible = True
                With dgvPersonas.SelectedRows(0)
                    cargarConceptosPlanillas(.Cells("serie").Value, .Cells("Numero").Value, .Cells("per_Id").Value)
                    txtPersonaSelec.Text = .Cells("Nombre").Value
                End With

            End If
        End Sub

      
        Private Sub btnCerrarPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarPanel.Click
            Panel4.Visible = False
        End Sub

        Private Sub txtBuscarCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarCodigo.TextChanged
            Dim x As Integer = 0
            x = 0
            If (txtBuscarCodigo.Text.Length >= 4) Then
                While (dgvPersonas.Rows.Count > x)
                    Try
                        If (dgvPersonas.Rows(x).Cells("Codigo").Value = txtBuscarCodigo.Text) Then
                            dgvPersonas.CurrentCell = dgvPersonas.Rows(x).Cells("Codigo")
                            Exit Sub
                        End If
                    Catch ex As Exception

                    End Try
                    x += 1
                End While

            End If
        End Sub
        Sub SumarCampo2()
            Dim x As Integer = 0
            Dim dTotalINgreso, dTotalEgreso, neto As Double

            dTotalINgreso = 0
            dTotalEgreso = 0
            neto = 0

            While (dgvPersonas2.Rows.Count > x)
                Try

                    dTotalINgreso += dgvPersonas2.Rows(x).Cells("TotalIngreso").Value
                    dTotalEgreso += dgvPersonas2.Rows(x).Cells("totalEgreso").Value
                    neto += dgvPersonas2.Rows(x).Cells("Neto").Value

                Catch ex As Exception

                End Try
                x += 1
            End While


            txtTotalINgreso2.Text = dTotalINgreso
            txtTotalEgreso2.Text = dTotalEgreso
            txtTotalNeto2.Text = neto
            txtTotalRegistros2.Text = x.ToString
        End Sub

        Private Sub btnPasar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasar.Click
            'Dim x, y As Integer
            'Dim bIngresar As Boolean = True
            'x = 0
            'y = 0

            For Cont As Integer = dgvPersonas.Rows.Count - 1 To 0 Step -1
                If dgvPersonas.Rows(Cont).Selected Then
                    With dgvPersonas.Rows(Cont)
                        dgvPersonas2.Rows.Add(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value)
                    End With
                    dgvPersonas.Rows.RemoveAt(Cont)
                End If
            Next

            'While (dgvPersonas.SelectedRows.Count > x)
            '    y = 0
            '    bIngresar = True
            '    '' ''While (dgvPersonas2.Rows.Count > y)
            '    '' ''    If (dgvPersonas.SelectedRows(x).Cells(0).Value = dgvPersonas2.Rows(y).Cells(0).Value AndAlso _
            '    '' ''       dgvPersonas.SelectedRows(x).Cells(1).Value = dgvPersonas2.Rows(y).Cells(1).Value AndAlso _
            '    '' ''       dgvPersonas.SelectedRows(x).Cells(2).Value = dgvPersonas2.Rows(y).Cells(2).Value AndAlso _
            '    '' ''       dgvPersonas.SelectedRows(x).Cells(3).Value = dgvPersonas2.Rows(y).Cells(3).Value) Then
            '    '' ''        bIngresar = False
            '    '' ''    End If
            '    '' ''    y += 1
            '    '' ''End While
            '    'Dim mFlag = (From mRows As DataGridViewRow In dgvPersonas2.Rows Where mRows.Cells(0).Value = dgvPersonas.SelectedRows(x).Cells(0).Value AndAlso _
            '    '                                                                    mRows.Cells(1).Value = dgvPersonas.SelectedRows(x).Cells(1).Value AndAlso _
            '    '                                                                    mRows.Cells(2).Value = dgvPersonas.SelectedRows(x).Cells(2).Value AndAlso _
            '    '                                                                    mRows.Cells(3).Value = dgvPersonas.SelectedRows(x).Cells(3).Value).Count
            '    'If mFlag > 0 Then
            '    '    bIngresar = False
            '    'End If

            '    ''Dim mFilas = From mRows As DataGridViewRow In dgvPersonas.Rows Where (mRows.Cells(0).Value & mRows.Cells(1).Value & mRows.Cells(2).Value & mRows.Cells(3).Value).ToString.Contains((From mYa As DataGridViewRow In dgvPersonas2.Rows Select mYa.Cells(0).Value & mYa.Cells(1).Value & mYa.Cells(2).Value & mYa.Cells(3).Value).ToString) Select mRows
            '    ''Dim mFilas = From mRows As DataGridViewRow In ListOtros From mYa As DataGridViewRow In dgvPersonas2.Rows Where (mRows.Cells(0).Value & mRows.Cells(1).Value & mRows.Cells(2).Value & mRows.Cells(3).Value).ToString.Contains((From mRows As DataGridViewRow In dgvPersonas2.Rows Select mRows.Cells(0).Value & mRows.Cells(1).Value & mRows.Cells(2).Value & mRows.Cells(3).Value).ToString) Select mRows
            '    ''Dim mFilas = From mRows As DataGridViewRow In dgvPersonas.Rows Join mYa As DataGridViewRow In dgvPersonas2.Rows On Not (mRows.Cells(1).Value.ToString) Equals (mYa.Cells(1).Value.ToString) Select mRows

            '    ''For Each mFila In mFilas.ToList
            '    ''    MsgBox("Hola")
            '    ''Next



            '    If (bIngresar) Then
            '        With dgvPersonas.SelectedRows(x)
            '            dgvPersonas2.Rows.Add(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value)
            '        End With
            '        dgvPersonas.Rows.Remove(dgvPersonas.SelectedRows(x))
            '    End If
            '    x += 1
            'End While
            SumarCampo2()
        End Sub

        Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
            Dim y As Integer
            Try
                While (dgvPersonas2.SelectedRows.Count > y)

                    dgvPersonas2.Rows.Remove(dgvPersonas2.SelectedRows(y))
                    y += 1
                End While
            Catch ex As Exception

            End Try
            SumarCampo2()
        End Sub

        Private Sub btnQuitarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarTodo.Click
            dgvPersonas2.Rows.Clear()
            SumarCampo2()
        End Sub

        Private Sub dgvPersonas2_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPersonas2.RowHeaderMouseDoubleClick
            If (dgvPersonas2.SelectedRows.Count > 0) Then
                Panel4.Visible = True
                With dgvPersonas2.SelectedRows(0)
                    cargarConceptosPlanillas(.Cells("serie").Value, .Cells("Numero").Value, .Cells("per_Id").Value)
                    txtPersonaSelec.Text = .Cells("Nombre").Value
                End With

            End If
        End Sub

        Private Sub btnImprimirBoletas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirBoletas.Click
            Dim oTable As New DataTable

            If (dgvPersonas2.Rows.Count > 0) Then
                oTable = Me.BCConsultasReportesPlanillas.SPPlanillaImprimirLista(BCUtil.getXml(dgvPersonas2, 0, 1, 2))
                If (oTable.Rows.Count > 0) Then

                    Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()
                    oReporte.DataDefinition.FormulaFields("Ruc").Text = "'RUC Nº " & Me.SessionService.RUCEmpresa & "'"
                    actualizarTable1(oTable)
                    actualizarTable2(oTable)
                    oReporte.Database.Tables(0).SetDataSource(oTable)

                    frm.Reporte(oReporte)

                    frm.ShowDialog()

                Else
                    MsgBox("NO hay Datos a Mostrar")
                End If

            End If



        End Sub

        Sub actualizarTable1(ByRef otable As DataTable)
            Dim cuenta As Integer = 0
            cuenta = 0

            Dim x As Integer
            Dim y As Integer
            Dim colum1 As String
            Dim colum2 As String
            Dim valor1 As Double
            Dim valor2 As Double
            Dim valorInterno1 As Double
            Dim valorInterno2 As Double
            Dim serie As String = ""
            Dim numero As String = ""
            Dim per_id As String = ""

            Dim esNUll As Boolean
            Dim estadoIGual As Boolean = False

            Dim cuentaX1, cuentaX2 As Integer



            Dim reiniciar As Boolean = False
            esNUll = False
            cuentaX1 = 0
            While (otable.Rows.Count > cuenta)
                With otable.Rows(cuenta)
                    If (.Item("y") = 1) Then


                        If (.Item("serie") <> serie OrElse .Item("numero") <> numero OrElse .Item("per_id") <> per_id OrElse .Item("y") <> y) Then

                            serie = .Item("serie")
                            numero = .Item("numero")
                            per_id = .Item("per_id")
                            y = .Item("y")
                            cuentaX1 = cuenta

                        End If

                        estadoIGual = False


                        If (IsDBNull(.Item("colum1")) OrElse .Item("colum1") = "") Then

                            .Item("colum1") = Nothing
                            .Item("valor1") = 0
                            .Item("valorInterno1") = 0

                        Else

                            Try
                                If (otable.Rows(cuentaX1).Item("colum1") <> .Item("colum1")) Then
                                    estadoIGual = True
                                End If
                            Catch ex As Exception
                                estadoIGual = True
                            End Try



                            otable.Rows(cuentaX1).Item("colum1") = .Item("colum1")
                            otable.Rows(cuentaX1).Item("valor1") = .Item("valor1")
                            Try
                                otable.Rows(cuentaX1).Item("valorInterno1") = .Item("valorInterno1")

                            Catch ex As Exception
                                otable.Rows(cuentaX1).Item("valorInterno1") = 0
                            End Try

                            If (estadoIGual) Then
                                .Item("colum1") = Nothing
                                .Item("valor1") = 0
                                .Item("valorInterno1") = 0
                            End If
                            cuentaX1 += 1
                        End If
                    End If

                End With

                cuenta += 1
            End While


        End Sub
        Sub actualizarTable2(ByRef otable As DataTable)
            Dim cuenta As Integer = 0
            cuenta = 0

            Dim x As Integer
            Dim y As Integer
            Dim colum1 As String
            Dim colum2 As String
            Dim valor1 As Double
            Dim valor2 As Double
            Dim valorInterno1 As Double
            Dim valorInterno2 As Double
            Dim serie As String = ""
            Dim numero As String = ""
            Dim per_id As String = ""

            Dim esNUll As Boolean
            Dim estadoIGual As Boolean = False

            Dim cuentaX2 As Integer



            Dim reiniciar As Boolean = False
            esNUll = False
            cuentaX2 = 0
            While (otable.Rows.Count > cuenta)
                With otable.Rows(cuenta)
                    If (.Item("y") = 1) Then


                        If (.Item("serie") <> serie OrElse .Item("numero") <> numero OrElse .Item("per_id") <> per_id OrElse .Item("y") <> y) Then

                            serie = .Item("serie")
                            numero = .Item("numero")
                            per_id = .Item("per_id")
                            y = .Item("y")
                            cuentaX2 = cuenta

                        End If

                        estadoIGual = False


                        If (IsDBNull(.Item("colum2")) OrElse .Item("colum2") = "") Then

                            .Item("colum2") = Nothing
                            .Item("valor2") = 0
                            .Item("valorInterno2") = 0

                        Else

                            Try
                                If (otable.Rows(cuentaX2).Item("colum2") <> .Item("colum2")) Then
                                    estadoIGual = True
                                End If
                            Catch ex As Exception
                                estadoIGual = True
                            End Try



                            otable.Rows(cuentaX2).Item("colum2") = .Item("colum2")
                            otable.Rows(cuentaX2).Item("valor2") = .Item("valor2")
                            Try
                                otable.Rows(cuentaX2).Item("valorInterno2") = .Item("valorInterno2")

                            Catch ex As Exception
                                otable.Rows(cuentaX2).Item("valorInterno2") = 0
                            End Try

                            If (estadoIGual) Then
                                .Item("colum2") = Nothing
                                .Item("valor2") = 0
                                .Item("valorInterno2") = 0
                            End If
                            cuentaX2 += 1
                        End If
                    End If

                End With

                cuenta += 1
            End While


        End Sub
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodoHasta.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value


            End If

            frm.Dispose()
        End Sub

        Private Sub btnCargarBoletas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarBoletas.Click

            If (txtPeriodoDesde.Text <> "" And txtPeriodoHasta.Text <> "") Then
                cargarBoletas()
            Else
                MsgBox("Ingresar el Periodo")
            End If

        End Sub

      
        Private Sub btnReporteDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporteDetalle.Click

            If (dgvPersonas2.Rows.Count > 0) Then


                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmPlanillasPanelAdministracionDetalle)()



                Dim x, y As Integer
                Dim bIngresar As Boolean = True
                x = 0
                y = 0

                frm.dgvPersonas2.Rows.Clear()


                While (dgvPersonas2.Rows.Count > x)
                    y = 0
                    bIngresar = True
                    While (frm.dgvPersonas2.Rows.Count > y)

                        If (dgvPersonas2.Rows(x).Cells(0).Value = frm.dgvPersonas2.Rows(y).Cells(0).Value AndAlso _
                           dgvPersonas2.Rows(x).Cells(1).Value = frm.dgvPersonas2.Rows(y).Cells(1).Value AndAlso _
                           dgvPersonas2.Rows(x).Cells(2).Value = frm.dgvPersonas2.Rows(y).Cells(2).Value) Then

                            bIngresar = False


                        End If
                        y += 1
                    End While

                    If (bIngresar) Then
                        With dgvPersonas2.Rows(x)
                            frm.dgvPersonas2.Rows.Add(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value)
                        End With


                    End If
                    x += 1
                End While

                frm.ShowDialog()



                frm.Dispose()
            Else
                MsgBox("Selecione personas")
            End If


        End Sub

        Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
            Me.Dispose()
        End Sub

        Private Sub btnLibroPlanilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLibroPlanilla.Click
            Dim oTable As New DataTable
            Dim x As Integer = 0

            If (dgvPersonas2.Rows.Count > 0) Then
                oTable = Me.BCConsultasReportesPlanillas.spReportePlanillaConsolidado(BCUtil.getXml(dgvPersonas2, 0, 1, 2))
                If (oTable.Rows.Count > 0) Then

                    Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

                    oreporteConsolidado.Database.Tables(0).SetDataSource(oTable)


                    frm.Reporte(oreporteConsolidado)

                    frm.ShowDialog()

                Else
                    MsgBox("NO hay Datos a Mostrar")
                End If

            End If
        End Sub



        Private Sub DataGridView1_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPersonas2.ColumnHeaderMouseClick



            Static Orden As Integer = 1



            If dgvPersonas2.Rows.Count > 0 Then

                If dgvPersonas2.Columns(e.ColumnIndex).Name = "Codigo" Then

                    If Orden = 1 Then

                        dgvPersonas2.Sort(New OrdenarColumnaNumerica(SortOrder.Ascending, e.ColumnIndex))

                        Orden = 0

                    Else

                        dgvPersonas2.Sort(New OrdenarColumnaNumerica(SortOrder.Descending, e.ColumnIndex))

                        Orden = 1

                    End If

                End If

            End If

        End Sub

        Private Sub chkMarcarPersonas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarcarPersonas.CheckedChanged
            For Each mRow As DataGridViewRow In dgvBoletas.Rows
                If mRow.Selected = True Then
                    mRow.Cells(0).Value = chkMarcarPersonas.Checked
                End If
            Next

            'Dim x As Integer = 0
            'While (dgvBoletas.Rows.Count > x)
            '    dgvBoletas.Rows(x).Cells(0).Value = chkMarcarPersonas.Checked
            '    x += 1
            'End While

        End Sub

        Private Sub btnLibPlaSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLibPlaSum.Click
            Dim oTable As New DataTable
            Dim x As Integer = 0

            If (dgvPersonas2.Rows.Count > 0) Then
                oTable = Me.BCConsultasReportesPlanillas.spReportePlanillaConsolidadoSuma(BCUtil.getXml(dgvPersonas2, 0, 1, 2))
                Dim frm = Me.ContainerService.Resolve(Of frmRptPlanillaConsolidadoSuma)()
                frm.dt = oTable.Copy
                frm.Show()
            End If
        End Sub

        Private Sub btnAjusteEsSalud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAjusteEsSalud.Click
            If MessageBox.Show("Se tomara en cuenta el periodo final para Ajustar Essalud. Desea proceder?", "Atencion", MessageBoxButtons.YesNoCancel) = vbYes Then
                Try
                    Me.BCConsultasReportesPlanillas.AjusteMinimoEsSalud(txtPeriodoHasta.Text)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End Sub
    End Class

    Public Class OrdenarColumnaNumerica
        Implements System.Collections.IComparer




        Private sortOrderModifier As Integer = 1

        Private Col As Integer = 0



        Public Sub New(ByVal sortOrder As SortOrder, ByVal columna As Integer)

            Col = columna

            If sortOrder = sortOrder.Descending Then

                sortOrderModifier = -1

            ElseIf sortOrder = sortOrder.Ascending Then

                sortOrderModifier = 1

            End If

        End Sub



        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare

            Dim DataGridViewRow1 As DataGridViewRow = CType(x, DataGridViewRow)

            Dim DataGridViewRow2 As DataGridViewRow = CType(y, DataGridViewRow)



            Return (Math.Sign(CLng(DataGridViewRow1.Cells(Col).Value) - CLng(DataGridViewRow2.Cells(Col).Value))) * sortOrderModifier

        End Function


    End Class

End Namespace
