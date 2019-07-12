
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmPlanillasPanelAdministracionDetalle


        <Dependency()> _
        Public Property BCConceptosPlanilla As BL.IBCConceptosPlanilla
        <Dependency()> _
        Public Property BCConsultasReportesPlanillas As BL.IBCConsultasReportesPlanillas
        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil

        Dim oRPTPLLXAcumuladosXTrabajador As New rptPLLXAcumuladosXTrabajador

        Private Sub frmPlanillasPanelAdministracionDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            obtenerConceptos()
        End Sub

        Sub cargarPersonas(ByVal oTable As DataTable)
            Dim x As Integer = 0

            dgvConceptos.Rows.Clear()

            While (oTable.Rows.Count > x)

                With oTable.Rows(x)

                    dgvConceptos.Rows.Add(CType(.Item(0), Boolean), .Item(1), .Item(2), .Item(3), .Item(4), .Item(5))


                End With

                x += 1
            End While


        End Sub
        Sub obtenerConceptos()
            Dim query As String

            '----------------------------------------------------------
            query = Me.BCConceptosPlanilla.ConceptosXTipoPlanillaSelectXML()
            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    cargarPersonas(ds.Tables(0))

                End If
            End If
            '-----------------------------------
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasar.Click
            Dim x, y As Integer
            Dim bIngresar As Boolean = True
            x = 0
            y = 0
            While (dgvConceptos.SelectedRows.Count > x)
                y = 0
                bIngresar = True
                While (dgvConceptos2.Rows.Count > y)

                    If (dgvConceptos.SelectedRows(x).Cells(0).Value = dgvConceptos2.Rows(y).Cells(0).Value AndAlso _
                       dgvConceptos.SelectedRows(x).Cells(1).Value = dgvConceptos2.Rows(y).Cells(1).Value AndAlso _
                       dgvConceptos.SelectedRows(x).Cells(2).Value = dgvConceptos2.Rows(y).Cells(2).Value AndAlso _
                       dgvConceptos.SelectedRows(x).Cells(3).Value = dgvConceptos.Rows(y).Cells(3).Value) Then
                        bIngresar = False
                    End If
                    y += 1
                End While
                If (bIngresar) Then

                    With dgvConceptos.SelectedRows(x)
                        dgvConceptos2.Rows.Add(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value, dgvConceptos2.Rows.Count, .Cells(4).Value, .Cells(5).Value)
                    End With
                End If
                x += 1
            End While


        End Sub

      
        Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
            Dim y As Integer
            Try
                While (dgvConceptos2.SelectedRows.Count > y)

                    dgvConceptos2.Rows.Remove(dgvConceptos2.SelectedRows(y))
                    y += 1
                End While
            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
            dgvConceptos2.Rows.Clear()
        End Sub

        Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
            Dim oTable As New DataTable
            Dim x As Integer = 0
           
            oTable = Me.BCConsultasReportesPlanillas.SPSelectReportPLLXAcumuladosXListaTrabajador(BCUtil.getXml(dgvConceptos2, 1, 2, 3), BCUtil.getXml(dgvPersonas2, 0, 1, 2))

            If (oTable.Rows.Count > 0) Then

                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

                oRPTPLLXAcumuladosXTrabajador.Database.Tables(0).SetDataSource(oTable)

                frm.Reporte(oRPTPLLXAcumuladosXTrabajador)
                frm.ShowDialog()

            Else
                MsgBox("NO hay Datos a Mostrar")
            End If

        End Sub
    End Class
End Namespace
