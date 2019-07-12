
Imports Microsoft.Practices.Unity
Imports System.IO

Namespace Ladisac.Contabilidad.Views
    Public Class frmAsientoAutomatico


        <Dependency()> _
        Public Property BCAsientoAutomatico As Ladisac.BL.IBCAsientoAutomatico

        Private Sub frmAsientoAutomatico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


            dgvDetalle.Rows.Add("Ventas") '0
            dgvDetalle.Rows.Add("Compras") '1
            dgvDetalle.Rows.Add("Tesoreria") '2
            dgvDetalle.Rows.Add("Planilla") '3
            dgvDetalle.Rows.Add("Recarcular Kardex(moneda)") '4
            dgvDetalle.Rows.Add("Dividendos") '5

        End Sub

        Function validar() As Boolean
            Dim resul As Boolean = True
            If (txtPeriodo.Text = "") Then
                ErrorProvider1.SetError(txtPeriodo, "Periodo")
                resul = False
            Else

                ErrorProvider1.SetError(txtPeriodo, "")
            End If
            Return resul

        End Function

        Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
            Try


                Dim result As Boolean = False
                If (validar()) Then
                    'Me.Cursor = Cursors.WaitCursor
                    Select Case dgvDetalle.SelectedRows(0).Index
                        Case 0
                            result = BCAsientoAutomatico.AsientoAutomaticoVentas(txtPeriodo.Text)
                        Case 1
                            result = BCAsientoAutomatico.AsientoAutomaticoCompras(txtPeriodo.Text)
                        Case 2
                            result = BCAsientoAutomatico.AsientoAutomaticoTesoreria(txtPeriodo.Text)
                        Case 3
                            result = BCAsientoAutomatico.AsientoAutomaticoPersonal(txtPeriodo.Text)
                        Case 4
                            result = BCAsientoAutomatico.RecarculoKardex(txtPeriodo.Text)
                        Case 5
                            result = BCAsientoAutomatico.AsientoAutomaticoDividendos(txtPeriodo.Text)
                    End Select

                    If (result) Then
                        Me.Cursor = Cursors.Default
                        MsgBox("Termino de Procesar")
                    Else
                        Me.Cursor = Cursors.Default
                    End If
                End If

            Catch ex As Exception
                 MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub btnPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodo.Click

            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtPeriodo.Text = .Cells(0).Value
                End With
            End If
            frm.Dispose()
        End Sub
    End Class
End Namespace