Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Namespace Ladisac.Produccion.Views

    Public Class frmControlParada
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCControlParada As Ladisac.BL.IBCControlParada
        <Dependency()> _
        Public Property BCProduccion As Ladisac.BL.IBCProduccion
        <Dependency()> _
        Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

        Protected mCPA As ControlParada
        Dim F1, F2 As DateTime
        Public mProd As BE.Produccion
        Dim mProduccion As BE.Produccion

        'ingreso de codigo
        Private Sub frmControlParada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            LimpiarControles()

            '==========================================================================
            'se llama al procedimiento de paso rapido entre cajas de texto.
            'se declara los objetos.---------    1->tipo textbox     2->combo

            Call validar_longitud()
            Call validacion_desactivacion(False, 1)

            If mProd IsNot Nothing Then
                OnManNuevo()
                mProduccion = mProd
                txtProduccion.Tag = mProduccion.PRO_ID  'PRO_Id
                txtProduccion.Text = mProduccion.PRO_ID & " " & mProduccion.Ladrillo.Articulos.ART_DESCRIPCION  'Nombres
                txtIng1.Text = mProduccion.Personas.PER_NOMBRES & " " & mProduccion.Personas.PER_APE_PAT & " " & mProduccion.Personas.PER_APE_MAT
                txtIng1.Tag = mProduccion.PER_ID_ING
                txtOperador.Text = mProduccion.Personas2.PER_NOMBRES & " " & mProduccion.Personas2.PER_APE_PAT & " " & mProduccion.Personas2.PER_APE_MAT
                txtOperador.Tag = mProduccion.PER_ID_OPE
                numHoraInicio.Value = mProduccion.PRO_HI
                numHoraFinal.Value = mProduccion.PRO_HF
                dtpFecha.Value = mProduccion.PRO_FECHA
                QuitarColumnas()
            End If

            txtProduccion.TabIndex = 0
            txtIng1.TabIndex = 1
            txtOperador.TabIndex = 2
            numHoraInicio.TabIndex = 3
            numHoraFinal.TabIndex = 4
            TabPage1.TabIndex = 5
            TabPage2.TabIndex = 6
            TabPage3.TabIndex = 7

        End Sub

        'ingreso de codigo
        Sub LimpiarControles()
            mCPA = Nothing
            txtProduccion.Text = String.Empty
            txtProduccion.Tag = Nothing
            txtOperador.Text = String.Empty
            txtOperador.Tag = Nothing
            txtIng1.Text = String.Empty
            txtIng1.Tag = Nothing
            dtpFecha.Value = Today
            numHoraInicio.Value = 0
            numHoraFinal.Value = 0
            dgvDetalle.Rows.Clear()
            dgvMolde.Rows.Clear()
            dgvInsumo.Rows.Clear()



            '--------------------------
            Error_validacion.Clear()
        End Sub

        Private Sub txtProduccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProduccion.DoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            frm.Tabla = "Produccion"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtProduccion.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PRO_Id
                txtProduccion.Text = frm.dgvLista.CurrentRow.Cells(0).Value & " " & frm.dgvLista.CurrentRow.Cells("ART_DESCRIPCION").Value 'Nombres
                Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value 'PRO_ID
                CargarProduccion(key)
                txtIng1.Text = mProduccion.Personas.PER_NOMBRES & " " & mProduccion.Personas.PER_APE_PAT & " " & mProduccion.Personas.PER_APE_MAT
                txtIng1.Tag = mProduccion.PER_ID_ING
                numHoraInicio.Value = mProduccion.PRO_HI
                numHoraFinal.Value = mProduccion.PRO_HF
                dtpFecha.Value = mProduccion.PRO_FECHA
                QuitarColumnas()
            End If
            frm.Dispose()
        End Sub

        Sub CargarProduccion(ByVal PRO_Id As Integer)
            mProduccion = BCProduccion.ProduccionGetById(PRO_Id)
        End Sub

        Private Sub txtOperador_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOperador.DoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            frm.Tabla = "Persona"
            frm.Tipo = "Trabajador"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'CType(sender, TextBox).Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                txtOperador.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                'CType(sender, TextBox).Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
                txtOperador.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
            End If
            frm.Dispose()
        End Sub

        Private Sub txtIng1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIng1.DoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            frm.Tabla = "Persona"
            frm.Tipo = "Trabajador"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtIng1.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                'CType(sender, TextBox).Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
                txtIng1.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
            End If
            frm.Dispose()
        End Sub

        'Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        '    Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        '    Select Case e.ColumnIndex
        '        Case 1
        '            frm.Tabla = "Parada"
        '            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'PAR_Descripcion
        '                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'PAR_Id
        '            End If
        '    End Select
        '    frm.Dispose()
        'End Sub

        Private Sub dgvMolde_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMolde.CellDoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            Select Case e.ColumnIndex
                Case 1
                    frm.Tabla = "Molde"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvMolde.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'MOL_Descripcion
                        dgvMolde.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'MOL_Id
                    End If
            End Select
            frm.Dispose()
        End Sub

        Private Sub dgvMolde_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMolde.CellEndEdit
            Select Case dgvMolde.Columns(dgvMolde.CurrentCell.ColumnIndex).Name
                Case "DPM_HORA"
                    Try
                        If Not IsDate(Replace(dgvMolde.CurrentCell.Value, ".", ":")) Then
                            dgvMolde.CurrentCell.Value = 0
                        End If
                    Catch ex As Exception
                        Exit Sub
                    End Try


                    If e.RowIndex = 0 Then
                        F1 = dtpFecha.Value.Date.AddHours(Int(numHoraInicio.Value)).AddMinutes((numHoraInicio.Value - Int(numHoraInicio.Value)) * 100)
                        If numHoraInicio.Value > dgvMolde.CurrentCell.Value Then
                            F2 = dtpFecha.Value.Date.AddDays(1).AddHours(Int(dgvMolde.CurrentCell.Value)).AddMinutes((dgvMolde.CurrentCell.Value - Int(dgvMolde.CurrentCell.Value)) * 100)
                        Else
                            F2 = dtpFecha.Value.Date.AddHours(Int(dgvMolde.CurrentCell.Value)).AddMinutes((dgvMolde.CurrentCell.Value - Int(dgvMolde.CurrentCell.Value)) * 100)
                        End If
                        CType(sender, DataGridView).CurrentRow.Cells("DPM_TIEMPO").Value = F2 - F1
                    ElseIf e.RowIndex <> dgvMolde.RowCount Then
                        F1 = dtpFecha.Value.Date.AddHours(Int(dgvMolde.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value)).AddMinutes((dgvMolde.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value - Int(dgvMolde.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value)) * 100)
                        If dgvMolde.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value > dgvMolde.CurrentCell.Value Then
                            F2 = dtpFecha.Value.Date.AddDays(1).AddHours(Int(dgvMolde.CurrentCell.Value)).AddMinutes((dgvMolde.CurrentCell.Value - Int(dgvMolde.CurrentCell.Value)) * 100)
                        Else
                            F2 = dtpFecha.Value.Date.AddHours(Int(dgvMolde.CurrentCell.Value)).AddMinutes((dgvMolde.CurrentCell.Value - Int(dgvMolde.CurrentCell.Value)) * 100)
                        End If
                        If dgvMolde.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value > 0 Then
                            'Dim T1 As TimeSpan = dgvMolde.Rows(e.RowIndex - 1).Cells("DPM_TIEMPO").Value
                            'dgvMolde.Rows(e.RowIndex - 1).Cells("DPM_TIEMPO").Value = (F2 - F1).Add(T1)
                            dgvMolde.Rows(e.RowIndex - 1).Cells("DPM_TIEMPO").Value = (F2 - F1)
                        Else
                            dgvMolde.Rows(e.RowIndex - 1).Cells("DPM_TIEMPO").Value = (F2 - F1)
                        End If
                    End If
            End Select

        End Sub

        Private Sub dgvInsumo_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInsumo.CellDoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            Select Case e.ColumnIndex
                Case 1
                    frm.Tabla = "ArticuloControlParada"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvInsumo.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'ART_Descripcion
                        dgvInsumo.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'ART_Id
                    End If
            End Select
            frm.Dispose()
        End Sub

        Sub NormalizarHoras()
            For Each mF As DataGridViewRow In dgvDetalle.Rows
                For Col As Integer = 2 To 25
                    If mF.Cells(Col).Value Is Nothing OrElse mF.Cells(Col).Value.ToString = "" Then
                        mF.Cells(Col).Tag = 0
                    Else
                        mF.Cells(Col).Tag = mF.Cells(Col).Value
                    End If
                Next
            Next
        End Sub

        Function ValidarParadas() As Boolean
            For Each mF As DataGridViewRow In dgvDetalle.Rows
                If mF.Cells("PAR_ID").Tag IsNot Nothing Then
                    For Cont As Integer = mF.Index + 1 To dgvDetalle.RowCount - 1
                        If mF.Cells("PAR_ID").Tag = dgvDetalle.Rows(Cont).Cells("PAR_ID").Tag Then
                            MessageBox.Show("No puede duplicar paradas.")
                            Return False
                        End If
                    Next
                End If
            Next
            Return True
        End Function


        Sub TiempoMolde()
            For Each mF As DataGridViewRow In dgvMolde.Rows
                mF.Cells("DPM_TIEMPO").Value = Nothing
            Next

            For Each mF As DataGridViewRow In dgvMolde.Rows
                dgvMolde.CurrentCell = mF.Cells("DPM_HORA")
                dgvMolde.BeginEdit(False)
                SendKeys.Send("{F2}")
            Next
            If dgvMolde.Rows.Count > 0 Then dgvMolde.CurrentCell = dgvMolde.Rows(0).Cells("DPM_HORA")
            If dgvMolde.Rows.Count > 1 Then
                If dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_HORA").Value < numHoraInicio.Value Then
                    F1 = dtpFecha.Value.Date.AddDays(1).AddHours(Int(dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_HORA").Value)).AddMinutes((dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_HORA").Value - Int(dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_HORA").Value)) * 100)
                Else
                    F1 = dtpFecha.Value.Date.AddHours(Int(dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_HORA").Value)).AddMinutes((dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_HORA").Value - Int(dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_HORA").Value)) * 100)
                End If

                If numHoraInicio.Value > numHoraFinal.Value Then
                    F2 = dtpFecha.Value.Date.AddDays(1).AddHours(Int(numHoraFinal.Value)).AddMinutes((numHoraFinal.Value - Int(numHoraFinal.Value)) * 100)
                Else
                    F2 = dtpFecha.Value.Date.AddHours(Int(numHoraFinal.Value)).AddMinutes((numHoraFinal.Value - Int(numHoraFinal.Value)) * 100)
                End If
                dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_TIEMPO").Value = F2 - F1
            ElseIf dgvMolde.Rows.Count > 0 Then
                F1 = dtpFecha.Value.Date.AddHours(Int(numHoraInicio.Value)).AddMinutes((numHoraInicio.Value - Int(numHoraInicio.Value)) * 100)
                If numHoraInicio.Value > numHoraFinal.Value Then
                    F2 = dtpFecha.Value.Date.AddDays(1).AddHours(Int(numHoraFinal.Value)).AddMinutes((numHoraFinal.Value - Int(numHoraFinal.Value)) * 100)
                Else
                    F2 = dtpFecha.Value.Date.AddHours(Int(numHoraFinal.Value)).AddMinutes((numHoraFinal.Value - Int(numHoraFinal.Value)) * 100)
                End If
                dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_TIEMPO").Value = F2 - F1

            End If
        End Sub

        'ingreso de codigo
        Public Overrides Sub OnManGuardar()
            'cod ingresado q llama ala funcion para validar
            If Not validar_controles() Then Exit Sub
            '----------------------------------------------------



            dgvDetalle.EndEdit()
            dgvMolde.EndEdit()
            dgvInsumo.EndEdit()
            NormalizarHoras()
            TiempoMolde()
            If mCPA IsNot Nothing Then
                mCPA.CPA_FECHA = dtpFecha.Value
                mCPA.CPA_HORA_INICIO = numHoraInicio.Value
                mCPA.CPA_HORA_FINAL = numHoraFinal.Value
                mCPA.PRO_ID = CInt(txtProduccion.Tag)
                mCPA.PER_ID_OPERADOR = txtOperador.Tag
                mCPA.PERS_ID_ING1 = txtIng1.Tag
                mCPA.PERS_ID_ING2 = Nothing
                mCPA.CPA_OBSERVACION = Nothing
                mCPA.CPA_ESTADO = True
                mCPA.CPA_FEC_GRAB = Now
                mCPA.USU_ID = SessionServer.UserId
                For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                    If Not mDetalle.Cells("DCP_ID").Value Is Nothing Then
                        With CType(mDetalle.Cells("DCP_ID").Tag, ControlParadaDetalle)
                            .PAR_ID = CInt(mDetalle.Cells("PAR_ID").Tag)
                            .DCP_H00 = CDbl(mDetalle.Cells("DCP_H00").Tag)
                            .DCP_H01 = CDbl(mDetalle.Cells("DCP_H01").Tag)
                            .DCP_H02 = CDbl(mDetalle.Cells("DCP_H02").Tag)
                            .DCP_H03 = CDbl(mDetalle.Cells("DCP_H03").Tag)
                            .DCP_H04 = CDbl(mDetalle.Cells("DCP_H04").Tag)
                            .DCP_H05 = CDbl(mDetalle.Cells("DCP_H05").Tag)
                            .DCP_H06 = CDbl(mDetalle.Cells("DCP_H06").Tag)
                            .DCP_H07 = CDbl(mDetalle.Cells("DCP_H07").Tag)
                            .DCP_H08 = CDbl(mDetalle.Cells("DCP_H08").Tag)
                            .DCP_H09 = CDbl(mDetalle.Cells("DCP_H09").Tag)
                            .DCP_H10 = CDbl(mDetalle.Cells("DCP_H10").Tag)
                            .DCP_H11 = CDbl(mDetalle.Cells("DCP_H11").Tag)
                            .DCP_H12 = CDbl(mDetalle.Cells("DCP_H12").Tag)
                            .DCP_H13 = CDbl(mDetalle.Cells("DCP_H13").Tag)
                            .DCP_H14 = CDbl(mDetalle.Cells("DCP_H14").Tag)
                            .DCP_H15 = CDbl(mDetalle.Cells("DCP_H15").Tag)
                            .DCP_H16 = CDbl(mDetalle.Cells("DCP_H16").Tag)
                            .DCP_H17 = CDbl(mDetalle.Cells("DCP_H17").Tag)
                            .DCP_H18 = CDbl(mDetalle.Cells("DCP_H18").Tag)
                            .DCP_H19 = CDbl(mDetalle.Cells("DCP_H19").Tag)
                            .DCP_H20 = CDbl(mDetalle.Cells("DCP_H20").Tag)
                            .DCP_H21 = CDbl(mDetalle.Cells("DCP_H21").Tag)
                            .DCP_H22 = CDbl(mDetalle.Cells("DCP_H22").Tag)
                            .DCP_H23 = CDbl(mDetalle.Cells("DCP_H23").Tag)
                            .MarkAsModified()
                        End With
                    ElseIf Not mDetalle.Cells("PAR_ID").Value Is Nothing OrElse mDetalle.Cells("PAR_ID").Value <> "" Then
                        Dim nDCP As New ControlParadaDetalle
                        With nDCP
                            .PAR_ID = CInt(mDetalle.Cells("PAR_ID").Tag)
                            .DCP_H00 = CDbl(mDetalle.Cells("DCP_H00").Tag)
                            .DCP_H01 = CDbl(mDetalle.Cells("DCP_H01").Tag)
                            .DCP_H02 = CDbl(mDetalle.Cells("DCP_H02").Tag)
                            .DCP_H03 = CDbl(mDetalle.Cells("DCP_H03").Tag)
                            .DCP_H04 = CDbl(mDetalle.Cells("DCP_H04").Tag)
                            .DCP_H05 = CDbl(mDetalle.Cells("DCP_H05").Tag)
                            .DCP_H06 = CDbl(mDetalle.Cells("DCP_H06").Tag)
                            .DCP_H07 = CDbl(mDetalle.Cells("DCP_H07").Tag)
                            .DCP_H08 = CDbl(mDetalle.Cells("DCP_H08").Tag)
                            .DCP_H09 = CDbl(mDetalle.Cells("DCP_H09").Tag)
                            .DCP_H10 = CDbl(mDetalle.Cells("DCP_H10").Tag)
                            .DCP_H11 = CDbl(mDetalle.Cells("DCP_H11").Tag)
                            .DCP_H12 = CDbl(mDetalle.Cells("DCP_H12").Tag)
                            .DCP_H13 = CDbl(mDetalle.Cells("DCP_H13").Tag)
                            .DCP_H14 = CDbl(mDetalle.Cells("DCP_H14").Tag)
                            .DCP_H15 = CDbl(mDetalle.Cells("DCP_H15").Tag)
                            .DCP_H16 = CDbl(mDetalle.Cells("DCP_H16").Tag)
                            .DCP_H17 = CDbl(mDetalle.Cells("DCP_H17").Tag)
                            .DCP_H18 = CDbl(mDetalle.Cells("DCP_H18").Tag)
                            .DCP_H19 = CDbl(mDetalle.Cells("DCP_H19").Tag)
                            .DCP_H20 = CDbl(mDetalle.Cells("DCP_H20").Tag)
                            .DCP_H21 = CDbl(mDetalle.Cells("DCP_H21").Tag)
                            .DCP_H22 = CDbl(mDetalle.Cells("DCP_H22").Tag)
                            .DCP_H23 = CDbl(mDetalle.Cells("DCP_H23").Tag)
                            .MarkAsAdded()
                        End With
                        mCPA.ControlParadaDetalle.Add(nDCP)
                    End If
                Next

                For Each mMolde As DataGridViewRow In dgvMolde.Rows
                    If Not mMolde.Cells("DPM_ID").Value Is Nothing Then
                        With CType(mMolde.Cells("DPM_ID").Tag, ControlParadaMoldeDetalle)
                            .MOL_ID = CInt(mMolde.Cells("MOL_ID").Tag)
                            .DPM_NRO_MEZCLA = CDbl(mMolde.Cells("DPM_NRO_MEZCLA").Value)
                            .DPM_HORA = CDbl(mMolde.Cells("DPM_HORA").Value)
                            F1 = Nothing
                            F1 = F1.Add(mMolde.Cells("DPM_Tiempo").Value)
                            Dim colx As Integer = 1
                            For hr As Integer = 0 To 23
                                colx += 1
                                If Int(mMolde.Cells("DPM_HORA").Value) = hr Then
                                    For Each mFila As DataGridViewRow In dgvDetalle.Rows
                                        If Not mFila.Cells(colx).Value Is Nothing Then
                                            F1 = F1.AddMinutes(Math.Abs(Int(mFila.Cells(colx).Value))).AddSeconds(Math.Abs((mFila.Cells(colx).Value - Int(mFila.Cells(colx).Value)) * 100))
                                        End If
                                    Next
                                    Exit For
                                End If
                            Next
                            .DPM_TIEMPO = F1.Hour + (F1.Minute / 60)
                            .DPM_CONTOMETRO = CDbl(mMolde.Cells("DPM_CONTOMETRO").Value)
                            .MarkAsModified()
                        End With
                    ElseIf Not mMolde.Cells("MOL_ID").Value Is Nothing Then
                        Dim nDPM As New ControlParadaMoldeDetalle
                        With nDPM
                            .MOL_ID = CInt(mMolde.Cells("MOL_ID").Tag)
                            .DPM_NRO_MEZCLA = CDbl(mMolde.Cells("DPM_NRO_MEZCLA").Value)
                            .DPM_HORA = CDbl(mMolde.Cells("DPM_HORA").Value)
                            F1 = Nothing
                            F1 = F1.Add(mMolde.Cells("DPM_Tiempo").Value)
                            Dim colx As Integer = 1
                            For hr As Integer = 0 To 23
                                colx += 1
                                If Int(mMolde.Cells("DPM_HORA").Value) = hr Then
                                    For Each mFila As DataGridViewRow In dgvDetalle.Rows
                                        If Not mFila.Cells(colx).Value Is Nothing Then
                                            F1 = F1.AddMinutes(Math.Abs(Int(mFila.Cells(colx).Value))).AddSeconds(Math.Abs((mFila.Cells(colx).Value - Int(mFila.Cells(colx).Value)) * 100))
                                        End If
                                    Next
                                    Exit For
                                End If
                            Next
                            .DPM_TIEMPO = F1.Hour + (F1.Minute / 60)
                            .DPM_CONTOMETRO = CDbl(mMolde.Cells("DPM_CONTOMETRO").Value)
                            .MarkAsAdded()
                        End With
                        mCPA.ControlParadaMoldeDetalle.Add(nDPM)
                    End If
                Next

                For Each mInsumo As DataGridViewRow In dgvInsumo.Rows
                    If Not mInsumo.Cells("DPA_ID").Value Is Nothing Then
                        With CType(mInsumo.Cells("DPA_ID").Tag, ControlParadaArticuloDetalle)
                            .ART_ID = mInsumo.Cells("ART_ID").Tag
                            .DPA_CANTIDAD = CDbl(mInsumo.Cells("DPA_CANTIDAD").Value)
                            .MarkAsModified()
                        End With
                    ElseIf Not mInsumo.Cells("ART_ID").Value Is Nothing Then
                        Dim nDPA As New ControlParadaArticuloDetalle
                        With nDPA
                            .ART_ID = mInsumo.Cells("ART_ID").Tag
                            .DPA_CANTIDAD = CDbl(mInsumo.Cells("DPA_CANTIDAD").Value)
                            .MarkAsAdded()
                        End With
                        mCPA.ControlParadaArticuloDetalle.Add(nDPA)
                    End If
                Next

                BCControlParada.MantenimientoControlParada(mCPA)
                LimpiarControles()
            End If

            '------------------------------------------
            Call validacion_desactivacion(False, 3)
            Me.Dispose()
        End Sub

        'ingreso de codigo
        Public Overrides Sub OnManNuevo()
            LimpiarControles()
            mCPA = New ControlParada
            mCPA.MarkAsAdded()

            '---------------------------------------
            Call validacion_desactivacion(True, 2)
            txtProduccion.Focus()
        End Sub

        'ingrso de codigo
        Public Overrides Sub OnManBuscar()
            LimpiarControles()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            frm.Tabla = "ControlParada"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
                CargarControlParada(key)
                LlenarControles()
                QuitarColumnas()
                TiempoMolde()
                '---------------------------------
                Call validacion_desactivacion(True, 5)
            End If
            frm.Dispose()
        End Sub

        Sub CargarControlParada(ByVal CPA_Id As Integer)
            mCPA = BCControlParada.ControlParadaGetById(CPA_Id)
            mCPA.MarkAsModified()
        End Sub

        Sub LlenarControles()
            dtpFecha.Value = mCPA.CPA_FECHA
            numHoraInicio.Value = mCPA.CPA_HORA_INICIO
            numHoraFinal.Value = mCPA.CPA_HORA_FINAL
            txtProduccion.Text = mCPA.Produccion.PRO_ID & " " & mCPA.Produccion.Ladrillo.Articulos.ART_DESCRIPCION
            txtProduccion.Tag = mCPA.Produccion.PRO_ID
            txtOperador.Text = mCPA.Personas.PER_NOMBRES & " " & mCPA.Personas.PER_APE_PAT
            txtOperador.Tag = mCPA.PER_ID_OPERADOR

            txtIng1.Text = mCPA.Personas1.PER_NOMBRES & " " & mCPA.Personas1.PER_APE_PAT
            txtIng1.Tag = mCPA.PERS_ID_ING1

            For Each mItem In mCPA.ControlParadaDetalle
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_ID").Value = mItem.DCP_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_ID").Tag = mItem
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_Id").Value = mItem.Parada.PAR_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_Id").Tag = mItem.PAR_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H00").Value = mItem.DCP_H00
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H01").Value = mItem.DCP_H01
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H02").Value = mItem.DCP_H02
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H03").Value = mItem.DCP_H03
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H04").Value = mItem.DCP_H04
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H05").Value = mItem.DCP_H05
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H06").Value = mItem.DCP_H06
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H07").Value = mItem.DCP_H07
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H08").Value = mItem.DCP_H08
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H09").Value = mItem.DCP_H09
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H10").Value = mItem.DCP_H10
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H11").Value = mItem.DCP_H11
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H12").Value = mItem.DCP_H12
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H13").Value = mItem.DCP_H13
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H14").Value = mItem.DCP_H14
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H15").Value = mItem.DCP_H15
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H16").Value = mItem.DCP_H16
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H17").Value = mItem.DCP_H17
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H18").Value = mItem.DCP_H18
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H19").Value = mItem.DCP_H19
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H20").Value = mItem.DCP_H20
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H21").Value = mItem.DCP_H21
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H22").Value = mItem.DCP_H22
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DCP_H23").Value = mItem.DCP_H23
            Next

            For Each mMolde In mCPA.ControlParadaMoldeDetalle
                Dim nRow As New DataGridViewRow
                dgvMolde.Rows.Add(nRow)
                dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_ID").Value = mMolde.DPM_ID
                dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_ID").Tag = mMolde
                dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("MOL_ID").Value = mMolde.Molde.MOL_DESCRIPCION
                dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("MOL_ID").Tag = mMolde.MOL_ID
                dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_NRO_MEZCLA").Value = mMolde.DPM_NRO_MEZCLA
                dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_HORA").Value = mMolde.DPM_HORA
                'dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_TIEMPO").Value = mMolde.DPM_TIEMPO
                dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_CONTOMETRO").Value = mMolde.DPM_CONTOMETRO
            Next

            For Each mArti In mCPA.ControlParadaArticuloDetalle
                Dim nRow As New DataGridViewRow
                dgvInsumo.Rows.Add(nRow)
                dgvInsumo.Rows(dgvInsumo.Rows.Count - 1).Cells("DPA_ID").Value = mArti.DPA_ID
                dgvInsumo.Rows(dgvInsumo.Rows.Count - 1).Cells("DPA_ID").Tag = mArti
                dgvInsumo.Rows(dgvInsumo.Rows.Count - 1).Cells("ART_ID").Value = mArti.Articulos.ART_DESCRIPCION
                dgvInsumo.Rows(dgvInsumo.Rows.Count - 1).Cells("ART_ID").Tag = mArti.ART_ID
                dgvInsumo.Rows(dgvInsumo.Rows.Count - 1).Cells("DPA_CANTIDAD").Value = mArti.DPA_CANTIDAD
            Next
        End Sub
        '===================================================================================================================
        '----procedimiento de validaciones

        'validamos los campos a llenar
        Function validar_controles()
            'aqui se ingresara los objetos del formulario a validar
            Dim flag As Boolean = True

            Error_validacion.Clear()
            If Len(txtProduccion.Text.Trim) = 0 Then Error_validacion.SetError(txtProduccion, "Ingrese la Produccion") : txtProduccion.Focus() : flag = False
            If Len(txtOperador.Text.Trim) = 0 Then Error_validacion.SetError(txtOperador, "Ingrese el Nombre del Operador") : txtOperador.Focus() : flag = False
            If Len(txtIng1.Text.Trim) = 0 Then Error_validacion.SetError(txtIng1, "Ingrese el Nombre del Ingeniero") : txtIng1.Focus() : flag = False
            If Len(numHoraInicio.Text.Trim) = 0 Then Error_validacion.SetError(numHoraInicio, "Ingrese la Hora Inicial") : numHoraInicio.Focus() : flag = False
            If Len(numHoraFinal.Text.Trim) = 0 Then Error_validacion.SetError(numHoraFinal, "Ingrese la Hora Final") : numHoraFinal.Focus() : flag = False


            If flag = False Then
                MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Return flag

        End Function

        'validamos la longitud de los campos
        Private Sub validar_longitud()
            'Me.txtProduccion.MaxLength=100
            Me.txtOperador.MaxLength = 160
            Me.txtIng1.MaxLength = 160
            Me.numHoraInicio.Maximum = 99 : Me.numHoraInicio.DecimalPlaces = 2
            Me.numHoraFinal.Maximum = 99 : Me.numHoraFinal.DecimalPlaces = 2
        End Sub

        'codigos agregados===================================================
        Public Overrides Sub OnManDeshacerCambios()
            Call LimpiarControles()
            Call validacion_desactivacion(False, 4)

        End Sub
        Public Overrides Sub OnManEditar()
            Call validacion_desactivacion(True, 6)
        End Sub
        Public Overrides Sub OnManCancelarEdicion()
            Call LimpiarControles()
            Call validacion_desactivacion(False, 7)
        End Sub
        Public Overrides Sub OnManEliminar()
            If mCPA IsNot Nothing Then
                For Each mItem In mCPA.ControlParadaDetalle
                    mItem.MarkAsDeleted()
                Next
                For Each mItem In mCPA.ControlParadaMoldeDetalle
                    mItem.MarkAsDeleted()
                Next
                For Each mItem In mCPA.ControlParadaArticuloDetalle
                    mItem.MarkAsDeleted()
                Next
                mCPA.MarkAsDeleted()
                BCControlParada.MantenimientoControlParada(mCPA)
                Call LimpiarControles()
                Call validacion_desactivacion(False, 7)
            End If
        End Sub
        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub

        'valida controles desactivacion
        Sub validacion_desactivacion(ByVal op As Boolean, ByVal flag As Integer)
            'datos a tener en cuenta
            '1=load
            '2=nuevo
            '3=guardar
            '4=DeshacerCambios
            '5=buscar
            '6=editar
            '7=deshacer,eliminar

            If flag = 1 Or flag = 3 Or flag = 4 Or flag = 7 Then

                'desactiva controles
                For Each ctrl As Control In Me.Controls
                    ctrl.Enabled = op
                Next
                'desactiva controles anidados del toolstrip
                For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                    If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                        oOpcionMenu.Enabled = op
                    End If
                Next
                'activamos barra
                Me.tsBarra.Enabled = True
                Me.tsbSalir.Enabled = True
                '----
                Me.tsbNuevo.Enabled = Not op
                Me.tsbBuscar.Enabled = Not op
                Me.tsbSalir.Enabled = Not op
                Me.tscPosicion.Enabled = Not op
                Me.tsbReportes.Enabled = Not op


            ElseIf flag = 2 Or flag = 6 Then 'evento nuevo registro
                'desactiva controles
                For Each ctrl As Control In Me.Controls
                    ctrl.Enabled = op
                Next
                'desactiva controles anidados del toolstrip
                For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                    If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                        oOpcionMenu.Enabled = Not op
                    End If
                Next
                'activamos barra
                Me.tsBarra.Enabled = True
                Me.tsbSalir.Enabled = True
                '----
                Me.tsbGrabar.Enabled = op
                Me.TsbGrabarNuevo.Enabled = op
                Me.tsbDeshacer.Enabled = op
                Me.tsbAgregar.Enabled = op
                Me.tsbQuitar.Enabled = op


            ElseIf flag = 5 Then 'evento buscar/editar
                'desactiva controles
                For Each ctrl As Control In Me.Controls
                    ctrl.Enabled = op
                Next
                'desactiva controles anidados del toolstrip
                For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                    If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                        oOpcionMenu.Enabled = op
                    End If
                Next
                'activamos barra
                Me.tsBarra.Enabled = True
                Me.tsbSalir.Enabled = True
                '----
                Me.tsbNuevo.Enabled = Not op
                Me.tsbEditar.Enabled = Not op
                Me.tsbCancelarEditar.Enabled = Not op
                Me.tsbReportes.Enabled = Not op

            End If
        End Sub

        Private Sub txtProduccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProduccion.KeyDown
            If e.KeyCode = Keys.Enter Then txtProduccion_DoubleClick(Nothing, Nothing)
        End Sub

        Private Sub txtIng1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIng1.KeyDown
            If e.KeyCode = Keys.Enter Then txtIng1_DoubleClick(Nothing, Nothing)
        End Sub

        Private Sub txtOperador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOperador.KeyDown
            If e.KeyCode = Keys.Enter Then txtOperador_DoubleClick(Nothing, Nothing)
        End Sub

        Private Sub dgvMolde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMolde.KeyDown
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            If dgvMolde.CurrentCell.ColumnIndex = 1 And e.KeyCode = Keys.Enter Then
                frm.Tabla = "Molde"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvMolde.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'MOL_Descripcion
                    dgvMolde.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'MOL_Id
                End If
            End If
            frm.Dispose()
        End Sub

        Private Sub dgvInsumo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvInsumo.KeyDown
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            If dgvInsumo.CurrentCell.ColumnIndex = 1 And e.KeyCode = Keys.Enter Then
                frm.Tabla = "ArticuloControlParada"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvInsumo.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'ART_Descripcion
                    dgvInsumo.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'ART_Id
                End If
            End If
            frm.Dispose()
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End Sub

        Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            If dgvDetalle.CurrentCell.ColumnIndex = 1 Then
                frm.Tabla = "Parada"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'PAR_Descripcion
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'PAR_Id
                    If Not ValidarParadas() Then
                        dgvDetalle.CurrentCell.Value = ""  'PAR_Descripcion
                        dgvDetalle.CurrentCell.Tag = Nothing  'PAR_Id
                    End If
                End If
            End If
            frm.Dispose()
        End Sub

        Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
            If e.ColumnIndex > 1 Then
                Try
                    If Not IsNumeric(sender.CurrentCell.value) Then
                        MessageBox.Show("El valor es incorrecto.")
                        sender.CurrentCell.value = 0
                    End If
                Catch ex As Exception

                End Try
            End If
        End Sub

        Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            If dgvDetalle.CurrentCell.ColumnIndex = 1 And e.KeyCode = Keys.Enter Then
                frm.Tabla = "Parada"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'PAR_Descripcion
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'PAR_Id
                    If Not ValidarParadas() Then
                        dgvDetalle.CurrentCell.Value = ""  'PAR_Descripcion
                        dgvDetalle.CurrentCell.Tag = Nothing  'PAR_Id
                    End If
                End If
            End If
            frm.Dispose()

            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
            End If
        End Sub

        Public Overrides Sub OnManAgregarFilaGrid()
            Dim nRow As New DataGridViewRow
            Select Case TabControl1.SelectedIndex
                Case 0
                    dgvDetalle.Rows.Add(nRow)
                Case 1
                    dgvMolde.Rows.Add(nRow)
                    If dgvMolde.Rows(0).Cells("MOL_ID").Tag IsNot Nothing Then
                        dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("MOL_ID").Value = dgvMolde.Rows(dgvMolde.Rows.Count - 2).Cells("MOL_ID").Value
                        dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("MOL_ID").Tag = dgvMolde.Rows(dgvMolde.Rows.Count - 2).Cells("MOL_ID").Tag
                        dgvMolde.Rows(dgvMolde.Rows.Count - 1).Cells("DPM_NRO_MEZCLA").Value = dgvMolde.Rows(dgvMolde.Rows.Count - 2).Cells("DPM_NRO_MEZCLA").Value + 1
                    End If

                Case 2
                    dgvInsumo.Rows.Add(nRow)
            End Select

        End Sub

        Sub QuitarColumnas()
            If numHoraInicio.Value >= 0 And numHoraFinal.Value >= 0 Then
                For Each colParadas As DataGridViewColumn In dgvDetalle.Columns()
                    If colParadas.Index >= 2 Then
                        If numHoraInicio.Value < numHoraFinal.Value Then
                            Dim HoraI As String = Double.Parse(numHoraInicio.Value).ToString("00.00")
                            Dim HoraF As String = Double.Parse(numHoraFinal.Value).ToString("00.00")
                            If Mid(colParadas.Name, 6, 2) >= Mid(HoraI, 1, 2) And Mid(colParadas.Name, 6, 2) <= Mid(HoraF, 1, 2) Then
                                dgvDetalle.Columns(colParadas.Index).Visible = True
                            Else
                                dgvDetalle.Columns(colParadas.Index).Visible = False
                            End If
                        Else
                            Dim HoraI As String = Double.Parse(numHoraInicio.Value).ToString("00.00")
                            Dim HoraF As String = Double.Parse(numHoraFinal.Value).ToString("00.00")
                            If Mid(colParadas.Name, 6, 2) > Mid(HoraF, 1, 2) And Mid(colParadas.Name, 6, 2) < Mid(HoraI, 1, 2) Then
                                dgvDetalle.Columns(colParadas.Index).Visible = False
                            Else
                                dgvDetalle.Columns(colParadas.Index).Visible = True
                            End If
                        End If
                    End If
                Next
            End If
        End Sub

        Private Sub numHoraFinal_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles numHoraFinal.Enter, numHoraInicio.Enter
            sender.Select(0, sender.Text.ToString.Length)
        End Sub

        Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
            If Not e.Row.Cells("DCP_ID").Tag Is Nothing Then
                CType(e.Row.Cells("DCP_ID").Tag, ControlParadaDetalle).MarkAsDeleted()
            End If
        End Sub

        Private Sub dgvMolde_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvMolde.UserDeletingRow
            If Not e.Row.Cells("DPM_ID").Tag Is Nothing Then
                CType(e.Row.Cells("DPM_ID").Tag, ControlParadaMoldeDetalle).MarkAsDeleted()
            End If
        End Sub

        Private Sub dgvInsumo_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvInsumo.UserDeletingRow
            If Not e.Row.Cells("DPA_ID").Tag Is Nothing Then
                CType(e.Row.Cells("DPA_ID").Tag, ControlParadaArticuloDetalle).MarkAsDeleted()
            End If
        End Sub
    End Class
End Namespace