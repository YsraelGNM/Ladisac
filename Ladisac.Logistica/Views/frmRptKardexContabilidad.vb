Imports Microsoft.Practices.Unity
Imports System.IO

Public Class frmRptKardexContabilidad
    <Dependency()> _
    Public Property BCKardex As Ladisac.BL.IBCKardex

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ds As New DataSet
        Dim query As String = ""

        If TabControl1.SelectedIndex = 0 Then 'Detallado
            If chkLadrillo.Checked Or chkSuministro.Checked Then
                txtAlmacen.Text = String.Empty
                txtAlmacen.Tag = Nothing
                If chkLadrillo.Checked Then
                    query = BCKardex.ListaKardexContabilidad(dtpFecIni.Value, dtpFecFin.Value, txtAlmacen.Tag, txtArticulo.Tag, False, False, "LAD")
                ElseIf chkSuministro.Checked Then
                    query = BCKardex.ListaKardexContabilidad(dtpFecIni.Value, dtpFecFin.Value, txtAlmacen.Tag, txtArticulo.Tag, False, False, "SUM")
                End If
            Else
                query = BCKardex.ListaKardexContabilidad(dtpFecIni.Value, dtpFecFin.Value, txtAlmacen.Tag, txtArticulo.Tag, False, False, "")
            End If

        ElseIf TabControl1.SelectedIndex = 1 Then 'Anual
            If chkLadrillo.Checked Or chkSuministro.Checked Then
                txtAlmacen.Text = String.Empty
                txtAlmacen.Tag = Nothing

                If TabControl2.SelectedIndex = 0 Then 'Detallado
                    If chkLadrillo.Checked Then
                        query = BCKardex.ListaKardexContabilidad(dtpFecIni.Value, dtpFecFin.Value, txtAlmacen.Tag, txtArticulo.Tag, True, False, "LAD", True)
                    ElseIf chkSuministro.Checked Then
                        query = BCKardex.ListaKardexContabilidad(dtpFecIni.Value, dtpFecFin.Value, txtAlmacen.Tag, txtArticulo.Tag, True, False, "SUM", True)
                    End If

                ElseIf TabControl2.SelectedIndex = 1 Then 'Resumen
                    If chkLadrillo.Checked Then
                        query = BCKardex.ListaKardexContabilidad(dtpFecIni.Value, dtpFecFin.Value, txtAlmacen.Tag, txtArticulo.Tag, True, False, "LAD", False)
                    ElseIf chkSuministro.Checked Then
                        query = BCKardex.ListaKardexContabilidad(dtpFecIni.Value, dtpFecFin.Value, txtAlmacen.Tag, txtArticulo.Tag, True, False, "SUM", False)
                    End If
                End If
                

            Else
                If TabControl2.SelectedIndex = 0 Then 'Detallado
                    query = BCKardex.ListaKardexContabilidad(dtpFecIni.Value, dtpFecFin.Value, txtAlmacen.Tag, txtArticulo.Tag, True, False, "", True)
                ElseIf TabControl2.SelectedIndex = 1 Then 'Resumen
                    query = BCKardex.ListaKardexContabilidad(dtpFecIni.Value, dtpFecFin.Value, txtAlmacen.Tag, txtArticulo.Tag, True, False, "", False)
                End If


            End If

        ElseIf TabControl1.SelectedIndex = 2 Then 'Mensual
            Dim MI As Integer = dtpFecIni.Value.Month
            Dim MF As Integer = dtpFecFin.Value.Month

            For Cont As Integer = MI To MF
                Dim FI As String = "1/" & Cont.ToString & "/" & dtpFecFin.Value.Year.ToString
                Dim FF As String = "1/" & Cont.ToString & "/" & dtpFecFin.Value.Year.ToString

                If chkLadrillo.Checked Or chkSuministro.Checked Then
                    txtAlmacen.Text = String.Empty
                    txtAlmacen.Tag = Nothing
                    If chkLadrillo.Checked Then
                        query = BCKardex.ListaKardexContabilidad(FI, FF, txtAlmacen.Tag, txtArticulo.Tag, False, True, "LAD")
                    ElseIf chkSuministro.Checked Then
                        query = BCKardex.ListaKardexContabilidad(FI, FF, txtAlmacen.Tag, txtArticulo.Tag, False, True, "SUM")
                    End If
                Else
                    query = BCKardex.ListaKardexContabilidad(FI, FF, txtAlmacen.Tag, txtArticulo.Tag, False, True, "")
                End If


                If Cont = MI Then
                    If query.ToString.Length > 0 Then
                        Dim rea As New StringReader(query)
                        ds.ReadXml(rea)
                    End If
                Else
                    If query.ToString.Length > 0 Then
                        Dim ds2 As New DataSet
                        Dim rea As New StringReader(query)
                        ds2.ReadXml(rea)
                        ds.Merge(ds2)
                    End If
                End If

            Next



        ElseIf TabControl1.SelectedIndex = 3 Then 'Mensual Consolidado
            'Dim MI As Integer = dtpFecIni.Value.Month
            'Dim MF As Integer = dtpFecFin.Value.Month

            'For Cont As Integer = MI To MF
            '    Dim FI As String = "1/" & Cont.ToString & "/" & dtpFecFin.Value.Year.ToString
            '    Dim FF As String = "1/" & Cont.ToString & "/" & dtpFecFin.Value.Year.ToString

            '    If chkLadrillo.Checked Or chkSuministro.Checked Then
            '        txtAlmacen.Text = String.Empty
            '        txtAlmacen.Tag = Nothing
            '        If chkLadrillo.Checked Then
            '            query = BCKardex.ListaKardexContabilidad(FI, FF, txtAlmacen.Tag, txtArticulo.Tag, False, True, "LAD")
            '        ElseIf chkSuministro.Checked Then
            '            query = BCKardex.ListaKardexContabilidad(FI, FF, txtAlmacen.Tag, txtArticulo.Tag, False, True, "SUM")
            '        End If
            '    Else
            '        query = BCKardex.ListaKardexContabilidad(FI, FF, txtAlmacen.Tag, txtArticulo.Tag, False, True, "")
            '    End If


            '    If Cont = MI Then
            '        If query.ToString.Length > 0 Then
            '            Dim rea As New StringReader(query)
            '            ds.ReadXml(rea)
            '        End If
            '    Else
            '        If query.ToString.Length > 0 Then
            '            Dim ds2 As New DataSet
            '            Dim rea As New StringReader(query)
            '            ds2.ReadXml(rea)
            '            ds.Merge(ds2)
            '        End If
            '    End If

            'Next



            'Dim MI As Integer = dtpFecIni.Value.Month
            'Dim MF As Integer = dtpFecFin.Value.Month

            ''For Cont As Integer = MI To MF
            'Dim FI As String = "1/" & Cont.ToString & "/" & dtpFecFin.Value.Year.ToString
            'Dim FF As String = "1/" & Cont.ToString & "/" & dtpFecFin.Value.Year.ToString

            If chkLadrillo.Checked Or chkSuministro.Checked Then
                txtAlmacen.Text = String.Empty
                txtAlmacen.Tag = Nothing
                If chkLadrillo.Checked Then
                    query = BCKardex.ListaKardexContabilidad(dtpFecIni.Value, dtpFecFin.Value, txtAlmacen.Tag, txtArticulo.Tag, False, True, "LAD")
                ElseIf chkSuministro.Checked Then
                    query = BCKardex.ListaKardexContabilidad(dtpFecIni.Value, dtpFecFin.Value, txtAlmacen.Tag, txtArticulo.Tag, False, True, "SUM")
                End If
            Else
                query = BCKardex.ListaKardexContabilidad(dtpFecIni.Value, dtpFecFin.Value, txtAlmacen.Tag, txtArticulo.Tag, False, True, "")
            End If


            If query.ToString.Length > 0 Then
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
            End If

            'Next
        End If


        If TabControl1.SelectedIndex <> 2 And TabControl1.SelectedIndex <> 3 Then
            If query.ToString.Length > 0 Then
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
            End If
        End If



        Try

            If TabControl1.SelectedIndex = 0 Then 'Detallado
                ReportViewer1.LocalReport.DataSources.Clear()
                ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaKardexContabilidad", ds.Tables(0)))
                'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
                Dim parametro(6) As Microsoft.Reporting.WinForms.ReportParameter

                parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFecIni.Value.Date)
                parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFecFin.Value.Date)
                parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Anio", False)
                parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Mes", False)
                parametro(4) = New Microsoft.Reporting.WinForms.ReportParameter("Articulo", False)
                parametro(5) = New Microsoft.Reporting.WinForms.ReportParameter("Operacion", False)
                If chkLadrillo.Checked Then
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "LAD")
                ElseIf chkSuministro.Checked Then
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "SUM")
                Else
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "")
                End If


                ' '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
                Me.ReportViewer1.LocalReport.SetParameters(parametro)
                ReportViewer1.RefreshReport()

            ElseIf TabControl1.SelectedIndex = 1 Then 'Anual
                'Resumen Detallado Anual
                ReportViewer2.LocalReport.DataSources.Clear()
                ReportViewer2.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaKardexContabilidad", ds.Tables(0)))
                'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
                Dim parametro(6) As Microsoft.Reporting.WinForms.ReportParameter
                parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFecIni.Value.Date)
                parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFecFin.Value.Date)
                parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Anio", False)
                parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Mes", False)
                parametro(4) = New Microsoft.Reporting.WinForms.ReportParameter("Articulo", False)
                parametro(5) = New Microsoft.Reporting.WinForms.ReportParameter("Operacion", False)
                If chkLadrillo.Checked Then
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "LAD")
                ElseIf chkSuministro.Checked Then
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "SUM")
                Else
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "")
                End If

                ' '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
                Me.ReportViewer2.LocalReport.SetParameters(parametro)
                ReportViewer2.RefreshReport()


                'Resumen Resumen Anual
                ReportViewer4.LocalReport.DataSources.Clear()
                ReportViewer4.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaKardexContabilidad", ds.Tables(0)))
                'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
                parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFecIni.Value.Date)
                parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFecFin.Value.Date)
                parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Anio", False)
                parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Mes", False)
                parametro(4) = New Microsoft.Reporting.WinForms.ReportParameter("Articulo", False)
                parametro(5) = New Microsoft.Reporting.WinForms.ReportParameter("Operacion", False)
                If chkLadrillo.Checked Then
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "LAD")
                ElseIf chkSuministro.Checked Then
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "SUM")
                Else
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "")
                End If


                ' '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
                Me.ReportViewer4.LocalReport.SetParameters(parametro)
                ReportViewer4.RefreshReport()

            ElseIf TabControl1.SelectedIndex = 2 Then 'Mensual
                'Resumen Mensual
                ReportViewer3.LocalReport.DataSources.Clear()
                ReportViewer3.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaKardexContabilidad", ds.Tables(0)))
                'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
                Dim parametro(6) As Microsoft.Reporting.WinForms.ReportParameter
                parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFecIni.Value.Date)
                parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFecFin.Value.Date)
                parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Anio", False)
                parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Mes", True)
                parametro(4) = New Microsoft.Reporting.WinForms.ReportParameter("Articulo", False)
                parametro(5) = New Microsoft.Reporting.WinForms.ReportParameter("Operacion", False)
                If chkLadrillo.Checked Then
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "LAD")
                ElseIf chkSuministro.Checked Then
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "SUM")
                Else
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "")
                End If

                ' '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
                Me.ReportViewer3.LocalReport.SetParameters(parametro)
                ReportViewer3.RefreshReport()

            ElseIf TabControl1.SelectedIndex = 3 Then 'Mensual Consolidado
                'Resumen Mensual Consolidado
                ReportViewer5.LocalReport.DataSources.Clear()
                ReportViewer5.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaKardexContabilidad", ds.Tables(0)))
                'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
                Dim parametro(6) As Microsoft.Reporting.WinForms.ReportParameter
                parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFecIni.Value.Date)
                parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFecFin.Value.Date)
                parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Anio", False)
                parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Mes", True)
                parametro(4) = New Microsoft.Reporting.WinForms.ReportParameter("Articulo", False)
                parametro(5) = New Microsoft.Reporting.WinForms.ReportParameter("Operacion", False)
                If chkLadrillo.Checked Then
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "LAD")
                ElseIf chkSuministro.Checked Then
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "SUM")
                Else
                    parametro(6) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "")
                End If

                ' '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
                Me.ReportViewer5.LocalReport.SetParameters(parametro)
                ReportViewer5.RefreshReport()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmRptKardexContabilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAlmacen.TabIndex = 0
        txtArticulo.TabIndex = 1
        dtpFecIni.TabIndex = 2
        dtpFecFin.TabIndex = 3
        btnVisualizar.TabIndex = 4
        txtAlmacen.Focus()
    End Sub

    Private Sub txtArticulo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtArticulo.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Articulo"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtArticulo.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Art_Id
            txtArticulo.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    Private Sub txtAlmacen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAlmacen.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Almacen"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtAlmacen.Tag = CInt(frm.dgvLista.CurrentRow.Cells(0).Value) 'Alm_Id
            txtAlmacen.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    Private Sub txtArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then txtArticulo_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAlmacen.KeyDown
        If e.KeyCode = Keys.Enter Then txtAlmacen_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        btnVisualizar_Click(Nothing, Nothing)
    End Sub

    Private Sub chkLadrillo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLadrillo.CheckedChanged
        If chkLadrillo.Checked Then
            chkSuministro.Checked = False
        End If
    End Sub

    Private Sub chkSuministro_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSuministro.CheckedChanged
        If chkSuministro.Checked Then
            chkLadrillo.Checked = False
        End If
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl2.SelectedIndexChanged
        btnVisualizar_Click(Nothing, Nothing)
    End Sub

End Class