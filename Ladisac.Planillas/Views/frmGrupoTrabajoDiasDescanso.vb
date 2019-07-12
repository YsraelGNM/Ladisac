
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports System.Globalization

Namespace Ladisac.Planillas.Views

    Public Class frmGrupoTrabajoDiasDescanso

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCGrupoTrabajoDiasDescanso As Ladisac.BL.IBCGrupoTrabajoDiasDescanso
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil


        Private Function validar() As Boolean
            Dim result As Boolean = True
            Return result
        End Function

        Private Sub limpiar()

        End Sub
        Sub cargar(ByVal fechaDesde As Date, ByVal trabajador As String, ByVal tipo As Single)
            limpiar()
            Dim oDataTable As New DataTable

            oDataTable = BCGrupoTrabajoDiasDescanso.spGrupoTrabajoDiasDescansoSelect(fechaDesde)
            Dim f As Int16 = 0
            While (oDataTable.Columns.Count > f)
                dgvDetalle.Columns.Add(oDataTable.Columns(f).ColumnName, oDataTable.Columns(f).ColumnName)
                f += 1
            End While

            f = 0
            Dim y As Integer

            While (oDataTable.Rows.Count > f)
                dgvDetalle.Rows.Add()
                y = 0
                While (oDataTable.Columns.Count > y)
                    dgvDetalle.Rows(f).Cells(y).Value = oDataTable.Rows(f).Item(y)

                    y += 1
                End While

                f += 1

            End While


            dgvDetalle.Columns("d0_Observaciones").Visible = False
            dgvDetalle.Columns("d1_Observaciones").Visible = False
            dgvDetalle.Columns("d2_observaciones").Visible = False
            dgvDetalle.Columns("d3_Observaciones").Visible = False
            dgvDetalle.Columns("d4_Observaciones").Visible = False
            dgvDetalle.Columns("d5_Observaciones").Visible = False
            dgvDetalle.Columns("d6_Observaciones").Visible = False

            Dim x As Integer
            x = 0
            While (dgvDetalle.Columns.Count > x)
                dgvDetalle.Columns(x).SortMode = DataGridViewColumnSortMode.NotSortable
                x += 1
            End While




            ponerColor()
        End Sub

        Public Overrides Sub OnManBuscar()

            cargar(CDate(dateFechaDesde.Value), "", 0)
            menuBuscar()



        End Sub

        Function getXml(ByVal oDataGridView As DataGridView, ByVal ponerTodoCero As Boolean, ByVal ParamArray Columns() As Integer)
            Dim x, y As Int32
            Dim sRes As String
            x = 0
            y = 0

            sRes = "<MAtablita>"
            While (x < oDataGridView.Rows.Count)

                oDataGridView.Rows(x).Cells(0).Style.ForeColor = Drawing.Color.Red

                y = 0
                sRes &= " <rows>"
                While (y < Columns.Length)

                    If ("1,3,5,7,9,11,13".LastIndexOf(y.ToString()) >= 0) Then
                        If (ponerTodoCero) Then
                            sRes &= "  <campo" & y.ToString() & ">0</campo" & y.ToString() & ">"
                        Else

                            If (oDataGridView.Rows(x).Cells(Columns(y)).Style.BackColor = Drawing.Color.Red) Then
                                sRes &= "  <campo" & y.ToString() & ">1</campo" & y.ToString() & ">"
                            Else
                                sRes &= "  <campo" & y.ToString() & ">0</campo" & y.ToString() & ">"
                            End If

                        End If

                    Else

                        sRes &= "  <campo" & y.ToString() & ">" & oDataGridView.Rows(x).Cells(Columns(y)).Value & "</campo" & y.ToString() & ">"

                    End If



                    y += 1
                End While
                sRes &= " </rows>"
                x += 1
            End While
            sRes &= "</MAtablita>"
            Return sRes
        End Function



        Public Overrides Sub OnManGuardar()

            If (validar()) Then

                Try
                    BORRARfILTRO()

                    BCGrupoTrabajoDiasDescanso.Maintenance(dateFechaDesde.Value, getXml(dgvDetalle, False, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16), SessionServer.UserId.ToString)
                    MsgBox("Datos Guardados")
                    menuInicio()
                    Panel1.Enabled = False
                    limpiar()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'finde verificar
            End If
        End Sub

        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()

            ' Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub
        Public Overrides Sub OnManEliminar()

            Dim sCorrelativo As String = ""

            If (validar()) Then

                Try
                    If (MsgBox("Eliminar , equivale a poner todo como horas simples, desea continuar ", vbYesNo) = vbYes) Then
                        BCGrupoTrabajoDiasDescanso.Maintenance(dateFechaDesde.Value, getXml(dgvDetalle, True, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16), SessionServer.UserId)
                        MsgBox("Datos Guardados")
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()

                    End If

                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                    If (rethrow) Then
                        Throw
                    End If
                End Try

                'finde verificar

            End If
        End Sub

        Public Overrides Sub OnManCancelarEdicion()
            menuInicio()
            'Panel1.Enabled = False
            limpiar()
        End Sub
        Public Overrides Sub OnManEditar()
            menuEditar()
            ' Panel1.Enabled = True
        End Sub
        Public Overrides Sub OnManDeshacerCambios()
            menuInicio()
            ' Panel1.Enabled = False
            limpiar()
        End Sub

        Private Sub ponerColor()

            Dim x As Integer

            While (dgvDetalle.RowCount > x)

                With dgvDetalle.Rows(x)
                    Try
                        If (.Cells("d0").Value > 0) Then
                            dgvDetalle.Rows(x).Cells("D0_HoraReales").Style.BackColor = Drawing.Color.Red

                        End If
                        If (.Cells("d1").Value > 0) Then
                            dgvDetalle.Rows(x).Cells("D1_HoraReales").Style.BackColor = Drawing.Color.Red

                        End If
                        If (.Cells("d2").Value > 0) Then
                            dgvDetalle.Rows(x).Cells("D2_HoraReales").Style.BackColor = Drawing.Color.Red

                        End If
                        If (.Cells("d3").Value > 0) Then
                            dgvDetalle.Rows(x).Cells("D3_HoraReales").Style.BackColor = Drawing.Color.Red

                        End If
                        If (.Cells("d4").Value > 0) Then
                            dgvDetalle.Rows(x).Cells("D4_HoraReales").Style.BackColor = Drawing.Color.Red

                        End If
                        If (.Cells("d5").Value > 0) Then
                            dgvDetalle.Rows(x).Cells("D5_HoraReales").Style.BackColor = Drawing.Color.Red

                        End If
                        If (.Cells("d6").Value > 0) Then
                            dgvDetalle.Rows(x).Cells("D6_HoraReales").Style.BackColor = Drawing.Color.Red

                        End If
                    Catch ex As Exception

                    End Try

                End With


                x += 1
            End While

        End Sub

        Private Sub frmPeriodisidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            'Panel1.Enabled = False
        End Sub

        Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

        End Sub


        Private Sub dgvDetalle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDetalle.KeyPress
            Try

                If (e.KeyChar = Chr(Keys.D)) Then

                    If (dgvDetalle.SelectedCells(0).Style.BackColor = Drawing.Color.Red) Then
                        dgvDetalle.SelectedCells(0).Style.BackColor = Drawing.Color.White
                    Else
                        dgvDetalle.SelectedCells(0).Style.BackColor = Drawing.Color.Red
                    End If
                End If

            Catch ex As Exception

            End Try


        End Sub

        Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
            Dim x As Integer = 0
            x = 0
            If (txtCodigo.Text.Length >= 4) Then
                While (dgvDetalle.Rows.Count > x)
                    Try
                        If (dgvDetalle.Rows(x).Cells("Codigo").Value = txtCodigo.Text) Then
                            dgvDetalle.CurrentCell = dgvDetalle.Rows(x).Cells(0)
                            Exit Sub
                        End If
                    Catch ex As Exception

                    End Try
                    x += 1
                End While

            End If



           


        End Sub

        Private Sub btnFiltro1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltro1.Click
            Dim x As Integer

            While (dgvDetalle.Rows.Count > x)

                Try

                    If (Val(dgvDetalle.Rows(x).Cells("D0_HoraReales").Value) = 0 OrElse _
                            Val(dgvDetalle.Rows(x).Cells("D1_HoraReales").Value) = 0 OrElse _
                            Val(dgvDetalle.Rows(x).Cells("D2_HoraReales").Value) = 0 OrElse _
                            Val(dgvDetalle.Rows(x).Cells("D3_HoraReales").Value) = 0 OrElse _
                            Val(dgvDetalle.Rows(x).Cells("D4_HoraReales").Value) = 0 OrElse _
                            Val(dgvDetalle.Rows(x).Cells("D5_HoraReales").Value) = 0 OrElse _
                            Val(dgvDetalle.Rows(x).Cells("D6_HoraReales").Value) = 0) Then

                        dgvDetalle.Rows(x).Visible = False

                    End If

                Catch ex As Exception

                End Try


                x += 1
            End While

        End Sub
        Sub BORRARfILTRO()
            Dim x As Integer = 0
            x = 0

            While (dgvDetalle.Rows.Count > x)

                dgvDetalle.Rows(x).Visible = True

                x += 1
            End While

        End Sub
        Private Sub btnBorrarFiltros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarFiltros.Click
            BORRARfILTRO()

        End Sub
    End Class

End Namespace
