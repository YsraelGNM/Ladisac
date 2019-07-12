Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views

    Public Class frmExportarPlameTRegistro
        <Dependency()> _
        Public Property BCConsultasReportesPlanillas As BL.IBCConsultasReportesPlanillas
        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

        Private Sub frmExportarPlameTRegistro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        Private Sub chkConceptoEspesifico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConceptoEspesifico.CheckedChanged
            GroupBox3.Enabled = chkConceptoEspesifico.Checked
        End Sub

        Private Sub btnConceptoBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConceptoBuscar.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Conceptos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtConcepto.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtTipoConcepto.Tag = frm.dgbRegistro.CurrentRow.Cells(1).Value

                txtTipoConcepto.Text = frm.dgbRegistro.CurrentRow.Cells(2).Value
                txtConcepto.Text = frm.dgbRegistro.CurrentRow.Cells(3).Value
            End If
            frm.Dispose()
        End Sub

        Private Sub btnBuscarPLL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPLL.Click
            Dim query As String
            If (txtPeriodo.Text <> "") Then
                query = Me.BCConsultasReportesPlanillas.spPlanillaBuscarPlameSelectXML(txtPeriodo.Text)


                If (query <> Nothing) Then
                    Dim ds As New DataSet
                    Dim rea As New StringReader(query)
                    If (query <> "") Then
                        ds.ReadXml(rea)
                        Dim x As Integer
                        While (ds.Tables(0).Rows.Count > x)

                            With ds.Tables(0).Rows(x)
                                dgvPlanillas.Rows.Add(False, .Item(1), .Item(2), .Item(3), .Item(4), .Item(5), .Item(6))
                            End With

                            x += 1
                        End While



                    Else
                        dgvPlanillas.Rows.Clear()
                    End If
                End If
                ErrorProvider1.SetError(txtPeriodo, Nothing)
            Else
                ErrorProvider1.SetError(txtPeriodo, "Periodo")

            End If

        End Sub

        Private Sub btnPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodo.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodo.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
            End If

            frm.Dispose()
        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim query As String
            Dim oTable As New DataTable
            Dim x As Integer = 0
            Dim sTipoConcepto, sConcepto As String
            sTipoConcepto = ""
            sConcepto = ""

            If (chkConceptoEspesifico.Checked) Then
                sTipoConcepto = txtTipoConcepto.Tag
                sConcepto = txtConcepto.Tag
            Else
                sTipoConcepto = Nothing
                sConcepto = Nothing
            End If


            If (chkIngresosEgresosAportaciones.Checked Or chkConceptoEspesifico.Checked) Then

                SaveFileDialog1.Title = "Ingresos - Egresos -Aportaciones "
                SaveFileDialog1.DefaultExt = "txt"
                SaveFileDialog1.FileName = "0601" & txtPeriodo.Text & SessionServer.RUCEmpresa & ".rem"
                SaveFileDialog1.ShowDialog()
                query = ""
                query = Me.BCConsultasReportesPlanillas.SPPlanillaExportarPlameIngreEgresAportaciones(BCUtil.getXml(0, dgvPlanillas, 1, 2), sTipoConcepto, sConcepto)

            ElseIf chkDatosJornadaLaboral.Checked Then
                SaveFileDialog1.Title = "Datos Jornada Laboral"
                'SaveFileDialog1.DefaultExt = "txt"
                SaveFileDialog1.FileName = "0601" & txtPeriodo.Text & SessionServer.RUCEmpresa & ".jor"
                SaveFileDialog1.ShowDialog()
                query = ""
                query = Me.BCConsultasReportesPlanillas.SPPlanillaExportarPlameJornadaLaboral(BCUtil.getXml(0, dgvPlanillas, 1, 2))

            End If


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

        End Sub

        Private Sub chkMartarPlanillas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarcarPlanillas.CheckedChanged
            Dim x As Integer = 0
            While (dgvPlanillas.Rows.Count > x)
                If dgvPlanillas.Rows(x).Selected = True Then
                    dgvPlanillas.Rows(x).Cells(0).Value = chkMarcarPlanillas.Checked
                End If
                x += 1
            End While
        End Sub

        Private Sub chkIngresosEgresosAportaciones_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIngresosEgresosAportaciones.CheckedChanged
            chkConceptoEspesifico.Enabled = chkIngresosEgresosAportaciones.Checked
            chkConceptoEspesifico.Checked = chkIngresosEgresosAportaciones.Checked

        End Sub
    End Class
End Namespace
