Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Contabilidad.Views
    Public Class frmExportarSunatPLE



        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad
        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService


        Private Sub btnPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodo.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
                frm.cargarDatos()
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPeriodo.Text = .Cells(0).Value

                    End With
                End If
                frm.Dispose()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim query As String
            Dim oTable As New DataTable
            Dim x As Integer = 0
            'Me.Cursor = Cursors.WaitCursor


            If (chkRegistroCompra.Checked) Then

                SaveFileDialog1.Title = "PLE Registro de COMPRAS  "
                SaveFileDialog1.DefaultExt = "txt"
                SaveFileDialog1.FileName = "LE" & SessionServer.RUCEmpresa & txtPeriodo.Text & "00080100001111.txt"
                SaveFileDialog1.ShowDialog()
                'Me.Cursor = Cursors.WaitCursor
                query = ""


                query = Me.BCConsultasReportesContabilidad.SPExportarComprasSunatPLEXML(txtPeriodo.Text)


                If (query <> Nothing) Then
                    Dim ds As New DataSet
                    Dim rea As New StringReader(query)
                    If (query <> "") Then
                        ds.ReadXml(rea)
                        oTable = ds.Tables(0)

                    Else
                        oTable = Nothing
                    End If
                End If



                Dim objStreamWriter As StreamWriter
                objStreamWriter = New StreamWriter(SaveFileDialog1.FileName)
                x = 0
                While (oTable.Rows.Count > x)

                    ' My.Computer.FileSystem.WriteAllText("C:\madro.txt", odataset.Rows(0).Item(0).ToString, True)
                    objStreamWriter.WriteLine(oTable.Rows(x).Item(0).ToString)

                    x += 1

                End While


                objStreamWriter.Close()

            End If

            If (chkRegistroCompraNoDomiciliados.Checked) Then
                Dim vFlag As Boolean = False
                SaveFileDialog1.Title = "PLE Registro de COMPRAS NO DOMICILIADOS "
                SaveFileDialog1.DefaultExt = "txt"
                SaveFileDialog1.FileName = "LE" & SessionServer.RUCEmpresa & txtPeriodo.Text & "00080200001111.txt"
                SaveFileDialog1.ShowDialog()
                'Me.Cursor = Cursors.WaitCursor
                query = ""
                query = Me.BCConsultasReportesContabilidad.SPExportarComprasNoDomiciliadosSunatPLEXML(txtPeriodo.Text)
                If (query <> Nothing) Then
                    Dim ds As New DataSet
                    Dim rea As New StringReader(query)
                    If (query <> "") Then
                        ds.ReadXml(rea)
                        oTable = ds.Tables(0)
                    Else
                        oTable = Nothing
                    End If
                Else
                    SaveFileDialog1.FileName = "LE" & SessionServer.RUCEmpresa & txtPeriodo.Text & "00080200001011.txt"
                    SaveFileDialog1.ShowDialog()
                    vFlag = True
                End If
                Dim objStreamWriter As StreamWriter
                objStreamWriter = New StreamWriter(SaveFileDialog1.FileName)
                x = 0
                While (oTable.Rows.Count > x)
                    ' My.Computer.FileSystem.WriteAllText("C:\madro.txt", odataset.Rows(0).Item(0).ToString, True)
                    objStreamWriter.WriteLine(oTable.Rows(x).Item(0).ToString)
                    x += 1
                End While
                If vFlag Then
                    objStreamWriter.WriteLine("")
                End If
                objStreamWriter.Close()
            End If


            If (chkRegistroVenta.Checked) Then

                SaveFileDialog1.Title = "PLE Registro de VENTAS  "
                SaveFileDialog1.DefaultExt = "txt"
                SaveFileDialog1.FileName = "LE" & SessionServer.RUCEmpresa & txtPeriodo.Text & "00140100001111.txt"
                SaveFileDialog1.ShowDialog()
                'Me.Cursor = Cursors.WaitCursor
                query = ""


                query = Me.BCConsultasReportesContabilidad.SPExportarVentasSunatPLEXML(txtPeriodo.Text)


                If (query <> Nothing) Then
                    Dim ds As New DataSet
                    Dim rea As New StringReader(query)
                    If (query <> "") Then
                        ds.ReadXml(rea)
                        oTable = ds.Tables(0)

                    Else
                        oTable = Nothing
                    End If
                End If



                Dim objStreamWriter As StreamWriter
                objStreamWriter = New StreamWriter(SaveFileDialog1.FileName)
                x = 0
                While (oTable.Rows.Count > x)

                    ' My.Computer.FileSystem.WriteAllText("C:\madro.txt", odataset.Rows(0).Item(0).ToString, True)
                    objStreamWriter.WriteLine(oTable.Rows(x).Item(0).ToString)

                    x += 1

                End While


                objStreamWriter.Close()

            End If
            If (chkLibroDiario.Checked) Then

                SaveFileDialog1.Title = "PLE Registro Libro Diario "
                SaveFileDialog1.DefaultExt = "txt"
                SaveFileDialog1.FileName = "LE" & SessionServer.RUCEmpresa & txtPeriodo.Text & "00050100001111.txt"
                SaveFileDialog1.ShowDialog()
                'Me.Cursor = Cursors.WaitCursor
                query = ""


                query = Me.BCConsultasReportesContabilidad.SPExportarAsientosSunatPLE51XML(txtPeriodo.Text)


                If (query <> Nothing) Then
                    Dim ds As New DataSet
                    Dim rea As New StringReader(query)
                    If (query <> "") Then
                        ds.ReadXml(rea)
                        oTable = ds.Tables(0)

                    Else
                        oTable = Nothing
                    End If
                End If



                Dim objStreamWriter As StreamWriter
                objStreamWriter = New StreamWriter(SaveFileDialog1.FileName)
                x = 0
                While (oTable.Rows.Count > x)

                    ' My.Computer.FileSystem.WriteAllText("C:\madro.txt", odataset.Rows(0).Item(0).ToString, True)
                    objStreamWriter.WriteLine(oTable.Rows(x).Item(0).ToString)

                    x += 1

                End While


                objStreamWriter.Close()

            End If

            If (chkLibroMayor.Checked) Then

                SaveFileDialog1.Title = "PLE Registro de Libro Mayor "
                SaveFileDialog1.DefaultExt = "txt"
                SaveFileDialog1.FileName = "LE" & SessionServer.RUCEmpresa & txtPeriodo.Text & "00060100001111.txt"
                SaveFileDialog1.ShowDialog()
                'Me.Cursor = Cursors.WaitCursor
                query = ""


                query = Me.BCConsultasReportesContabilidad.SPExportarMayorSunatPLE(txtPeriodo.Text)


                If (query <> Nothing) Then
                    Dim ds As New DataSet
                    Dim rea As New StringReader(query)
                    If (query <> "") Then
                        ds.ReadXml(rea)
                        oTable = ds.Tables(0)

                    Else
                        oTable = Nothing
                    End If
                End If



                Dim objStreamWriter As StreamWriter
                objStreamWriter = New StreamWriter(SaveFileDialog1.FileName)
                x = 0
                While (oTable.Rows.Count > x)

                    ' My.Computer.FileSystem.WriteAllText("C:\madro.txt", odataset.Rows(0).Item(0).ToString, True)
                    objStreamWriter.WriteLine(oTable.Rows(x).Item(0).ToString)

                    x += 1

                End While


                objStreamWriter.Close()

            End If

            ''''''''''''''''
            If (chkCuentas.Checked) Then

                SaveFileDialog1.Title = "PLE Cuentas contables "
                SaveFileDialog1.DefaultExt = "txt"
                ''SaveFileDialog1.FileName = "D" & SessionServer.RUCEmpresa & "083170.txt"
                SaveFileDialog1.FileName = "LE" & SessionServer.RUCEmpresa & txtPeriodo.Text & "00050300001111.txt"
                SaveFileDialog1.ShowDialog()
                'Me.Cursor = Cursors.WaitCursor
                query = ""


                query = Me.BCConsultasReportesContabilidad.spExportarSunatPDT321(txtPeriodo.Text)


                If (query <> Nothing) Then
                    Dim ds As New DataSet
                    Dim rea As New StringReader(query)
                    If (query <> "") Then
                        ds.ReadXml(rea)
                        oTable = ds.Tables(0)

                    Else
                        oTable = Nothing
                    End If
                End If



                Dim objStreamWriter As StreamWriter
                objStreamWriter = New StreamWriter(SaveFileDialog1.FileName)
                x = 0
                While (oTable.Rows.Count > x)

                    ' My.Computer.FileSystem.WriteAllText("C:\madro.txt", odataset.Rows(0).Item(0).ToString, True)
                    objStreamWriter.WriteLine(oTable.Rows(x).Item(0).ToString)

                    x += 1

                End While


                objStreamWriter.Close()

            End If
            MsgBox("Ok")
            Me.Cursor = Cursors.Default



        End Sub

        Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            Me.Dispose()
        End Sub
    End Class
End Namespace
