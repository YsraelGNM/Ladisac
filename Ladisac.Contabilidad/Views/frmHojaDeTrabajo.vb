Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports System.Threading
Namespace Ladisac.Contabilidad.Views
    Public Class frmHojaDeTrabajo

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

        <Dependency()>
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As Ladisac.BL.IBCConsultasReportesContabilidad

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Dim SubProceso As Thread
        Dim sCombo As String

        Private Sub btnPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodo.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPeriodo.Text = .Cells(0).Value

                    End With
                End If
                frm.Dispose()
            Catch ex As Exception
                MsgBox("Seleccione un Periodo")
            End Try

        End Sub

        Private Sub btnLibro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLibro.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.LibrosContables)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtLibro.Tag = .Cells(0).Value
                    txtLibro.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub frmHojaDeTrabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            cboNiveles.SelectedIndex = 9
            cboVerPor.SelectedIndex = 1
        End Sub
        Function validar()
            Return True
        End Function

        Private Sub darFormato()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
            DataGridViewCellStyle1.Format = "N2"

            ' DataGridViewCellStyle1.NullValue = Nothing
            ' Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
            dgbRegistro.Columns("Cargo").DefaultCellStyle = DataGridViewCellStyle1
            dgbRegistro.Columns("ABONO").DefaultCellStyle = DataGridViewCellStyle1
            dgbRegistro.Columns("DEUDOR").DefaultCellStyle = DataGridViewCellStyle1
            dgbRegistro.Columns("ACREEDOR").DefaultCellStyle = DataGridViewCellStyle1
            dgbRegistro.Columns("ACTIVO").DefaultCellStyle = DataGridViewCellStyle1
            dgbRegistro.Columns("PASIVO").DefaultCellStyle = DataGridViewCellStyle1
            dgbRegistro.Columns("perdidanat").DefaultCellStyle = DataGridViewCellStyle1
            dgbRegistro.Columns("gananciaNAt").DefaultCellStyle = DataGridViewCellStyle1
            dgbRegistro.Columns("perdidaFun").DefaultCellStyle = DataGridViewCellStyle1
            dgbRegistro.Columns("gananciaFun").DefaultCellStyle = DataGridViewCellStyle1


        End Sub
        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

            Dim query As String
            Dim X As Integer = 0
            Dim Y As Integer = 0

            dgbRegistro.Rows.Clear()
            If (validar()) Then
                query = BCConsultasReportesContabilidad.HojaTrabajoXMLQuery(txtPeriodo.Text, 1, cboNiveles.SelectedIndex + 1, cboVerPor.Text.Substring(0, 1), txtLibro.Tag)

                If (query <> Nothing) Then
                    Dim ds As New DataSet

                    Dim rea As New StringReader(query)
                    If (query <> "") Then
                        ds.ReadXml(rea)
                        SumaColumnas(ds.Tables(0))

                        ' ds.Tables(0).Columns("Cargo").DataType = System.Type.GetType("System.Decimal")
                        While (ds.Tables(0).Rows.Count > X)
                            Y = 0
                            dgbRegistro.Rows.Add()

                            While (ds.Tables(0).Columns.Count > Y)
                                Try
                                    If (IsNumeric(ds.Tables(0).Rows(X).Item(Y))) Then
                                        dgbRegistro.Rows(X).Cells(Y).Value = CDec(ds.Tables(0).Rows(X).Item(Y))
                                    Else
                                        dgbRegistro.Rows(X).Cells(Y).Value = ds.Tables(0).Rows(X).Item(Y)
                                    End If

                                Catch ex As Exception

                                End Try
                                Y += 1
                            End While
                            X += 1
                        End While



                        ' dgbRegistro.DataSource = ds.Tables(0)

                    Else
                        dgbRegistro.Rows.Clear()
                    End If

                    dgbRegistro.Columns("DeudorAA").Visible = False
                    dgbRegistro.Columns("AcreedorAA").Visible = False

                    darFormato()
                End If

            End If
        End Sub

        Sub SumaColumnas(ByRef oTable As DataTable)

            Dim cargoMN, abonoMN, Deudor, Acreedor, activo, pasivo, PerdidaNat, GananciaNat, PerdidaFun, GananciaFun As Double

            cargoMN = 0
            abonoMN = 0
            Deudor = 0
            Acreedor = 0
            activo = 0
            pasivo = 0
            PerdidaNat = 0
            GananciaNat = 0
            PerdidaFun = 0
            GananciaFun = 0

            Dim x As Int16 = 0
            If (oTable.Rows.Count > 0) Then

                While (oTable.Rows.Count > x)


                    cargoMN += oTable.Rows(x).Item("Cargo")
                    abonoMN += oTable.Rows(x).Item("abono")
                    Deudor += oTable.Rows(x).Item("Deudor")
                    Acreedor += oTable.Rows(x).Item("Acreedor")

                    activo += oTable.Rows(x).Item("activo")
                    pasivo += oTable.Rows(x).Item("pasivo")

                    PerdidaNat += oTable.Rows(x).Item("PerdidaNat")
                    GananciaNat += oTable.Rows(x).Item("GananciaNat")
                    PerdidaFun += oTable.Rows(x).Item("PerdidaFun")
                    GananciaFun += oTable.Rows(x).Item("GananciaFun")


                    x += 1
                End While
                oTable.Rows.Add()
                oTable.Rows.Add()
                oTable.Rows(oTable.Rows.Count - 1).Item("Descripcion") = "TOTALES PARCIALES --->>"
                oTable.Rows(oTable.Rows.Count - 1).Item("Cargo") = cargoMN
                oTable.Rows(oTable.Rows.Count - 1).Item("abono") = abonoMN
                oTable.Rows(oTable.Rows.Count - 1).Item("Deudor") = Deudor
                oTable.Rows(oTable.Rows.Count - 1).Item("Acreedor") = Acreedor
                oTable.Rows(oTable.Rows.Count - 1).Item("activo") = activo
                oTable.Rows(oTable.Rows.Count - 1).Item("pasivo") = pasivo


                oTable.Rows(oTable.Rows.Count - 1).Item("PerdidaNat") = PerdidaNat
                oTable.Rows(oTable.Rows.Count - 1).Item("GananciaNat") = GananciaNat
                oTable.Rows(oTable.Rows.Count - 1).Item("PerdidaFun") = PerdidaFun
                oTable.Rows(oTable.Rows.Count - 1).Item("GananciaFun") = GananciaFun



                oTable.Rows.Add()
                oTable.Rows(oTable.Rows.Count - 1).Item("Descripcion") = "RESULTADOS --->>"

                If (activo > pasivo) Then
                    oTable.Rows(oTable.Rows.Count - 1).Item("pasivo") = (activo - pasivo)
                Else

                    oTable.Rows(oTable.Rows.Count - 1).Item("activo") = (pasivo - activo)
                End If


                If (PerdidaNat > GananciaNat) Then
                    oTable.Rows(oTable.Rows.Count - 1).Item("GananciaNat") = (PerdidaNat - GananciaNat)
                Else

                    oTable.Rows(oTable.Rows.Count - 1).Item("PerdidaNat") = (GananciaNat - PerdidaNat)
                End If


                If (PerdidaFun > GananciaFun) Then
                    oTable.Rows(oTable.Rows.Count - 1).Item("GananciaFun") = (PerdidaFun - GananciaFun)
                Else

                    oTable.Rows(oTable.Rows.Count - 1).Item("PerdidaFun") = (GananciaFun - PerdidaFun)
                End If




            End If




        End Sub

        Sub AbrirExcel()


            BCConsultasReportesContabilidad.FormatoMayorAuxiliarDetalladoXLS(txtPeriodo.Text, _
                                                                            dgbRegistro.SelectedRows(0).Cells(1).Value, _
                                                                            dgbRegistro.SelectedRows(0).Cells(1).Value, _
                                                                            "", _
                                                                             txtLibro.Tag, sCombo, _
                                                                             0, SessionServer.UserId)
            SubProceso.Abort()



        End Sub
        Private Sub dgbRegistro_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgbRegistro.RowHeaderMouseDoubleClick

            If (dgbRegistro.SelectedRows.Count > 0) Then
                Try
                    If SubProceso.ThreadState = ThreadState.Running Then
                        MsgBox("Esta Procesando , Espere  un momento")
                    Else

                        SubProceso = New Thread(AddressOf Me.AbrirExcel)
                        SubProceso.Start()
                    End If
                Catch ex As Exception
                    Try
                        SubProceso = New Thread(AddressOf Me.AbrirExcel)

                        SubProceso.Start()
                    Catch ex2 As Exception
                        MsgBox(ex.Message)
                    End Try

                End Try

            End If

        End Sub

        Private Sub cboVerPor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVerPor.SelectedIndexChanged
            sCombo = cboVerPor.Text.Substring(0, 1)
        End Sub

        Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
            If (dgbRegistro.Rows.Count > 0) Then
                MsgBox(" Se exportaran los datos que se están visualizando ")

                Dim oTablita As New DataTable

                oTablita = BCUtil.getTable(dgbRegistro, "MiTablita")
                BCUtil.excelExportar(oTablita)
            Else
                MsgBox("Primero tiene que Generar")

            End If
        End Sub

        Private Sub btnRecibosHonorarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecibosHonorarios.Click
            'Me.Cursor = Cursors.WaitCursor
            Dim CadenaVista As String = ""
            Dim Her As New Herramientas
            Dim ds As New DataSet

            CadenaVista = IBCMaestro.EjecutarVista("dbo.spReciboHonorario", txtPeriodo.Text)
            Dim sr As New StringReader(CadenaVista)
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                dgvDatos.DataSource = ds.Tables(0)
            Else
                dgvDatos.DataSource = Nothing
            End If
            Her.excelExportar(Her.ToTable(dgvDatos, lblTitle.Text))
            Me.Cursor = Cursors.Default
        End Sub
    End Class
End Namespace