
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports System.Globalization
Namespace Ladisac.Planillas.Views
    Public Class ControlFiltroTrareaHoras



        Public Overridable Sub Control_Aplicar()

        End Sub

       


        Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click
            Control_Aplicar()
        End Sub

       
        Public Sub aplicarFiltros(ByRef oDataGirdView As DataGridView)
            ListaFiltro(oDataGirdView, listTarea, "Tarea")
            If (listTarea.Items.Count = 1) Then
                listTarea.SelectedIndex = 0
            End If

            ListaFiltro(oDataGirdView, listRefrigerio, "dgt_Refrigerio")
            If (listRefrigerio.Items.Count = 1) Then
                listRefrigerio.SelectedIndex = 0
            End If

            ListaFiltro(oDataGirdView, listBonificacion, "dgt_Bonificacion")
            If (listBonificacion.Items.Count = 1) Then
                listBonificacion.SelectedIndex = 0
            End If

            ListaFiltro(oDataGirdView, listDescuentos, "dgt_Descuento")
            If (listDescuentos.Items.Count = 1) Then
                listDescuentos.SelectedIndex = 0
            End If

            ListaFiltro(oDataGirdView, listTotal, "dgt_HoraTotales")
            If (listTotal.Items.Count = 1) Then
                listTotal.SelectedIndex = 0
            End If

            ListaFiltro(oDataGirdView, listFactor, "dgt_Factor")
            If (listFactor.Items.Count = 1) Then
                listFactor.SelectedIndex = 0
            End If

            ListaFiltro(oDataGirdView, listNumeroPersonas, "dgt_NumPersonas")
            If (listNumeroPersonas.Items.Count = 1) Then
                listNumeroPersonas.SelectedIndex = 0
            End If

            ListaFiltro(oDataGirdView, listCanTidadLadrillo, "dgt_CantidadLadrillo")
            If (listCanTidadLadrillo.Items.Count = 1) Then
                listCanTidadLadrillo.SelectedIndex = 0
            End If

            ListaFiltro(oDataGirdView, listMesa, "dgt_Mesas")
            If (listMesa.Items.Count = 1) Then
                listMesa.SelectedIndex = 0
            End If

            ListaFiltro(oDataGirdView, listAlas, "dgt_Alas")
            If (listAlas.Items.Count = 1) Then
                listAlas.SelectedIndex = 0
            End If

            ListaFiltro(oDataGirdView, listFraccion, "dgt_Fraccion")
            If (listFraccion.Items.Count = 1) Then
                listFraccion.SelectedIndex = 0
            End If


        End Sub

        Sub ListaFiltro(ByRef oDataGirdView As DataGridView, ByRef lis As ListBox, ByVal sColumna As String)
            Dim x As Integer = 0
            Dim y As Integer = 0
            Dim bAdd As Boolean = True

            If (Panel4.Visible) Then
                lis.Items.Clear()

                While (x < oDataGirdView.Rows.Count)
                    y = 0
                    bAdd = True

                    If (oDataGirdView.Rows(x).Visible) Then
                        While (lis.Items.Count > y)

                            If (oDataGirdView.Rows(x).Cells(sColumna).Value = lis.Items(y)) Then
                                bAdd = False
                            End If

                            y += 1

                        End While

                        Try


                            'MADRO:ADD elemento y ordenar si isnumeric 
                            If (bAdd) Then
                                lis.Items.Add(oDataGirdView.Rows(x).Cells(sColumna).Value)

                            End If

                        Catch ex As Exception

                        End Try
                    End If

                    x += 1
                End While
            End If

            If (oDataGirdView.RowCount > 0 AndAlso IsNumeric(oDataGirdView.Rows(0).Cells(sColumna).Value)) Then

                addyOrdenar(lis)

            End If


        End Sub

        Sub addyOrdenar(ByRef lis As ListBox)
            Dim iMin As Long
            Dim iMax As Long
            Dim Vectemp As String
            Dim Pos As Long
            Dim i As Long

            Dim Vector(lis.Items.Count - 1) As Double

            For i = 0 To UBound(Vector)
                Vector(i) = (lis.Items(i))
            Next i



            iMin = LBound(Vector)
            iMax = UBound(Vector)

            While iMax > iMin
                Pos = iMin
                For i = iMin To iMax - 1
                    If Vector(i) > Vector(i + 1) Then
                        Vectemp = Vector(i + 1)
                        Vector(i + 1) = Vector(i)
                        Vector(i) = Vectemp
                        Pos = i
                    End If
                Next i
                iMax = Pos
            End While


            lis.Items.Clear()

            For i = 0 To UBound(Vector)
                lis.Items.Add(Vector(i))
            Next i





        End Sub

        Public Function PocesarFiltros(ByVal oDataGirdView As DataGridView) As Boolean
            Dim result As Boolean = False
            Dim x As Integer = 0
            While (oDataGirdView.Rows.Count > x)

                Try
                    ' filtro codigo persona
                    If (chkCodigo.Checked) Then
                        If (oDataGirdView.Rows(x).Cells("Codigo").Value <> txtCodigo.Text.Trim) Then
                            oDataGirdView.Rows(x).Visible = False
                            result = True
                        End If
                    End If

                    ' filtro tarea
                    If (chkTarea.Checked) Then
                        If (oDataGirdView.Rows(x).Cells("Tarea").Value <> listTarea.SelectedItems(0).ToString) Then
                            oDataGirdView.Rows(x).Visible = False
                            result = True
                        End If
                    End If

                    ' filtro area 
                    If (chkArea.Checked) Then
                        If (oDataGirdView.Rows(x).Cells("art_AreaTrab_Id").Value <> cboAreaFiltro.SelectedValue) Then
                            oDataGirdView.Rows(x).Visible = False
                            result = True
                        End If
                    End If

                    ' filtro refrigerio
                    If (chkRefrigerio.Checked) Then
                        If (oDataGirdView.Rows(x).Cells("dgt_Refrigerio").Value <> listRefrigerio.SelectedItems(0).ToString) Then
                            oDataGirdView.Rows(x).Visible = False
                            result = True
                        End If
                    End If

                    ' filtro bonificacion
                    If (chkBonificacion.Checked) Then
                        If (oDataGirdView.Rows(x).Cells("dgt_Bonificacion").Value <> listBonificacion.SelectedItems(0).ToString) Then
                            oDataGirdView.Rows(x).Visible = False
                            result = True
                        End If
                    End If
                    ' filtrar descuentos 
                    If (chkDescuento.Checked) Then
                        If (oDataGirdView.Rows(x).Cells("dgt_Descuento").Value <> listDescuentos.SelectedItems(0).ToString) Then
                            oDataGirdView.Rows(x).Visible = False
                            result = True
                        End If
                    End If

                    ' filtro total horas 
                    If (chkTotal.Checked) Then
                        If (oDataGirdView.Rows(x).Cells("dgt_HoraTotales").Value <> listTotal.SelectedItems(0).ToString) Then
                            oDataGirdView.Rows(x).Visible = False
                            result = True
                        End If
                    End If

                    ' factor dgt_Factor
                    If (chkFactor.Checked) Then
                        If (oDataGirdView.Rows(x).Cells("dgt_Factor").Value <> listFactor.SelectedItems(0).ToString) Then
                            oDataGirdView.Rows(x).Visible = False
                            result = True
                        End If
                    End If
                    'dgt_NumPersonas
                    If (chkNumeroPersonas.Checked) Then
                        If (oDataGirdView.Rows(x).Cells("dgt_NumPersonas").Value <> listNumeroPersonas.SelectedItems(0).ToString) Then
                            oDataGirdView.Rows(x).Visible = False
                            result = True
                        End If
                    End If

                    'dgt_CantidadLadrillo
                    If (chkCanTidadLadrillo.Checked) Then
                        If (oDataGirdView.Rows(x).Cells("dgt_CantidadLadrillo").Value <> listCanTidadLadrillo.SelectedItems(0).ToString) Then
                            oDataGirdView.Rows(x).Visible = False
                            result = True
                        End If
                    End If

                    'dgt_Mesas
                    If (chkMesa.Checked) Then
                        If (oDataGirdView.Rows(x).Cells("dgt_Mesas").Value <> listMesa.SelectedItems(0).ToString) Then
                            oDataGirdView.Rows(x).Visible = False
                            result = True
                        End If
                    End If
                    'dgt_Alas

                    If (chkAlas.Checked) Then
                        If (oDataGirdView.Rows(x).Cells("dgt_Alas").Value <> listAlas.SelectedItems(0).ToString) Then
                            oDataGirdView.Rows(x).Visible = False
                            result = True
                        End If
                    End If
                    'dgt_Fraccion
                    If (chkFraccion.Checked) Then
                        If (oDataGirdView.Rows(x).Cells("dgt_Fraccion").Value <> listFraccion.SelectedItems(0).ToString) Then
                            oDataGirdView.Rows(x).Visible = False
                            result = True
                        End If
                    End If



                Catch ex As Exception

                End Try
                x += 1
            End While
            Return result
        End Function
        Public Sub limpiarFiltro(ByVal oDataGirdView As DataGridView)
            txtCodigo.Text = ""

            chkArea.Checked = False
            chkBonificacion.Checked = False
            chkCodigo.Checked = False
            chkRefrigerio.Checked = False
            chkTarea.Checked = False
            chkTotal.Checked = False
            aplicarFiltros(oDataGirdView)
        End Sub

        Private Sub ControlFintroTrareaHoras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub
    End Class

End Namespace