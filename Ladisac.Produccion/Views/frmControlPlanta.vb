Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.IO
Imports System.Windows.Forms

Public Class frmControlPlanta
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCControlPlanta As Ladisac.BL.IBCControlPlanta
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCParada As Ladisac.BL.IBCParada


    Protected mCPL As ControlPlanta

    Private Sub frmControlPlanta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Me.txtPlanta.Focus()
        Call validacion_desactivacion(False, 1)
        txtPlanta.TabIndex = 0
        dgvDetalle.TabIndex = 1

    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mCPL = Nothing
        txtPlanta.Text = String.Empty
        txtPlanta.Tag = Nothing
        dgvDetalle.Rows.Clear()
        '--------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub txtPlanta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlanta.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Planta"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPlanta.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtPlanta.Text = frm.dgvLista.CurrentRow.Cells(1).Value
        End If
        frm.Dispose()
        InsertarProduccion()
    End Sub

    Private Sub txtPlanta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlanta.KeyDown
        If e.KeyCode = Keys.Enter Then txtPlanta_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        If dgvDetalle.CurrentCell.ColumnIndex = 2 Then
            frm.Tabla = "Parada"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'PAR_Descripcion
                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'PAR_Id
            End If
        End If
        frm.Dispose()
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
    End Sub

    Public Sub InsertarProduccion()
        Try
            dgvDetalle.Rows.Clear()
            Dim contFecha As DateTime = dtpFecha.Value.Date.AddDays(-1).AddHours(20)
            Dim FF As DateTime = dtpFecha.Value.Date.AddHours(19).AddMinutes(59)
            Dim Lista = BCProduccion.ListaProduccionFecha(dtpFecha.Value, txtPlanta.Tag)
            'Dim parSP As Parada = BCParada.ParadaGetById (
            'Dim parCP As Parada

            While contFecha <= FF
                OnManAgregarFilaGrid()
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA").Value = String.Format("{0:00}", contFecha.Hour) & "." & String.Format("{0:00}", contFecha.Minute)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA_FINAL").Value = String.Format("{0:00}", contFecha.Hour) & "." & String.Format("{0:00}", contFecha.Minute)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Value = "PLANTA EN ESPERA"
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Tag = 1680 'Codigo de parada
                contFecha = contFecha.AddMinutes(1)
            End While

            If Lista.Count > 0 Then
                For Each mItem In Lista
                    For cont As Integer = 0 To dgvDetalle.Rows.Count - 1
                        If dgvDetalle.Rows(cont).Cells("DPL_HORA_FINAL").Value = (String.Format("{0:00}", Int(mItem.PRO_HF)) & "." & String.Format("{0:00}", (mItem.PRO_HF - Int(mItem.PRO_HF)) * 100)) Then
                            dgvDetalle.Rows(cont).Cells("DPL_ID").Value = Nothing
                            dgvDetalle.Rows(cont).Cells("DPL_ID").Tag = Nothing
                            dgvDetalle.Rows(cont).Cells("DPL_HORA").Value = String.Format("{0:00}", Int(mItem.PRO_HI)) & "." & String.Format("{0:00}", (mItem.PRO_HI - Int(mItem.PRO_HI)) * 100)
                            dgvDetalle.Rows(cont).Cells("DPL_HORA_FINAL").Value = String.Format("{0:00}", Int(mItem.PRO_HF)) & "." & String.Format("{0:00}", (mItem.PRO_HF - Int(mItem.PRO_HF)) * 100)
                            dgvDetalle.Rows(cont).Cells("PAR_ID").Value = "PLANTA EN PRODUCCION"
                            dgvDetalle.Rows(cont).Cells("PAR_ID").Tag = 1681 'Codigo de parada
                            dgvDetalle.Rows(cont).Cells("DPL_OBSERVACION").Value = mItem.PRO_ID & " - " & mItem.Ladrillo.Articulos.ART_DESCRIPCION
                        End If
                    Next
                Next
            End If
            'If Lista.Count > 0 Then
            '    For Each mItem In Lista
            '        OnManAgregarFilaGrid()
            '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_ID").Value = Nothing
            '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_ID").Tag = Nothing
            '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA").Value = String.Format("{0:00}", Int(mItem.PRO_HI)) & "." & String.Format("{0:00}", (mItem.PRO_HI - Int(mItem.PRO_HI)) * 100)
            '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA_FINAL").Value = String.Format("{0:00}", Int(mItem.PRO_HF)) & "." & String.Format("{0:00}", (mItem.PRO_HF - Int(mItem.PRO_HF)) * 100)
            '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Value = mItem.PRO_ID & " - " & mItem.Ladrillo.Articulos.ART_DESCRIPCION
            '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Tag = Nothing
            '    Next
            'End If

            'While contFecha <= FF
            '    For cont As Integer = 0 To dgvDetalle.Rows.Count - 1
            '        Dim FecProIni As DateTime = mItem.PRO_FECHA.Value
            '        If mItem.PRO_HI > mItem.PRO_HF Then
            '            FecProIni = FecProIni.AddDays(-1)
            '        End If
            '        FecProIni = FecProIni.AddHours(Int(mItem.PRO_HI))
            '        FecProIni = FecProIni.AddMinutes((Int(mItem.PRO_HI) - mItem.PRO_HI) * 10)

            '        Dim FecProFin As DateTime = mItem.PRO_FECHA.Value
            '        FecProFin = FecProFin.AddHours(Int(mItem.PRO_HF))
            '        FecProFin = FecProFin.AddMinutes((Int(mItem.PRO_HF) - mItem.PRO_HF) * 10)

            '        If Not dgvDetalle.Rows(cont).Cells("DPL_HORA_FINAL").Value = (String.Format("{0:00}", contFecha.Hour) & "." & String.Format("{0:00}", contFecha.Minute)) Then

            '            OnManAgregarFilaGrid()
            '            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA").Value = String.Format("{0:00}", contFecha.Hour) & "." & String.Format("{0:00}", contFecha.Minute)
            '            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA_FINAL").Value = String.Format("{0:00}", contFecha.Hour) & "." & String.Format("{0:00}", contFecha.Minute)
            '        End If
            '    Next
            '    contFecha = contFecha.AddMinutes(1)
            'End While


            For cont As Integer = 0 To dgvDetalle.Rows.Count - 1
                Try
                    If (dgvDetalle.Rows(cont + 1).Cells("PAR_ID").Tag & "") = "1680" Then 'Abajo es en blanco?
                        If (dgvDetalle.Rows(cont).Cells("PAR_ID").Tag & "") = "1680" Then 'Actual es en blanco?
                            dgvDetalle.Rows(cont + 1).Cells("DPL_HORA").Value = dgvDetalle.Rows(cont).Cells("DPL_HORA").Value 'al de abajo le copio la hora inicial del de arriba
                            dgvDetalle.Rows(cont).Cells("DPL_HORA").Value = "B"
                        End If
                    Else 'Cuando abajo es produccion
                        dgvDetalle.Rows(cont).Cells("DPL_HORA_FINAL").Value = dgvDetalle.Rows(cont + 1).Cells("DPL_HORA").Value 'al actual le pongo la hora final del de abajo
                    End If
                Catch ex As Exception

                End Try
            Next

            For cont As Integer = dgvDetalle.Rows.Count - 1 To 0 Step -1
                If dgvDetalle.Rows(cont).Cells("DPL_HORA").Value = "B" Then
                    dgvDetalle.Rows.Remove(dgvDetalle.Rows(cont))
                End If
            Next

            For cont As Integer = 0 To dgvDetalle.Rows.Count - 1
                Try
                    If dgvDetalle.Rows(cont).Cells("DPL_HORA_FINAL").Value = dgvDetalle.Rows(cont + 1).Cells("DPL_HORA_FINAL").Value Then
                        If (dgvDetalle.Rows(cont + 1).Cells("PAR_ID").Tag & "") = "1680" Then
                            dgvDetalle.Rows(cont + 1).Cells("DPL_HORA").Value = "B"
                        End If
                    End If
                Catch ex As Exception

                End Try
            Next

            For cont As Integer = dgvDetalle.Rows.Count - 1 To 0 Step -1
                If dgvDetalle.Rows(cont).Cells("DPL_HORA").Value = "B" Then
                    dgvDetalle.Rows.Remove(dgvDetalle.Rows(cont))
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        'Try
        '    dgvDetalle.Rows.Clear()
        '    Dim contFecha As DateTime = dtpFecha.Value.Date.AddDays(-1).AddHours(20)
        '    Dim FF As DateTime = dtpFecha.Value.Date.AddHours(19).AddMinutes(59)
        '    Dim Lista = BCProduccion.ListaProduccionFecha(dtpFecha.Value, txtPlanta.Tag)

        '    Dim idx As Integer = 0
        '    Dim Flag As Integer = 0
        '    While contFecha <= FF
        '        OnManAgregarFilaGrid()
        '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA").Value = String.Format("{0:00}", contFecha.Hour) & "." & String.Format("{0:00}", contFecha.Minute)
        '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA_FINAL").Value = String.Format("{0:00}", contFecha.Hour) & "." & String.Format("{0:00}", contFecha.Minute)
        '        contFecha = contFecha.AddMinutes(1)
        '    End While

        '    'For cont As Integer = dgvDetalle.Rows.Count - 1 To 0 Step -1
        '    '    If dgvDetalle.Rows(cont).Cells("PAR_ID").Tag = Nothing Then
        '    '        dgvDetalle.Rows.Remove(dgvDetalle.Rows(cont))
        '    '    End If
        '    'Next

        '    If Lista.Count > 0 Then
        '        For Each mItem In Lista
        '            'OnManAgregarFilaGrid()
        '            For Each mFila As DataGridViewRow In dgvDetalle.Rows
        '                If mFila.Cells("DPL_HORA_FINAL").Value = (String.Format("{0:00}", Int(mItem.PRO_HF)) & "." & String.Format("{0:00}", (mItem.PRO_HF - Int(mItem.PRO_HF)) * 100)) Then
        '                    mFila.Cells("DPL_ID").Value = Nothing
        '                    mFila.Cells("DPL_ID").Tag = Nothing
        '                    mFila.Cells("DPL_HORA").Value = String.Format("{0:00}", Int(mItem.PRO_HI)) & "." & String.Format("{0:00}", (mItem.PRO_HI - Int(mItem.PRO_HI)) * 100)
        '                    mFila.Cells("DPL_HORA_FINAL").Value = String.Format("{0:00}", Int(mItem.PRO_HF)) & "." & String.Format("{0:00}", (mItem.PRO_HF - Int(mItem.PRO_HF)) * 100)
        '                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Value = mItem.PRO_ID & " - " & mItem.Ladrillo.Articulos.ART_DESCRIPCION
        '                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Tag = Nothing
        '                End If
        '            Next

        '        Next
        '    End If

        '    'Dim idx As Integer = 0
        '    'Dim Flag As Integer = 0
        '    'While contFecha <= FF

        '    '    Dim mItem = Lista(idx)
        '    '    Dim FecProIni As DateTime = mItem.PRO_FECHA.Value
        '    '    If mItem.PRO_HI > mItem.PRO_HF Then
        '    '        FecProIni = FecProIni.AddDays(-1)
        '    '    End If
        '    '    FecProIni = FecProIni.AddHours(Int(mItem.PRO_HI))
        '    '    FecProIni = FecProIni.AddMinutes((Int(mItem.PRO_HI) - mItem.PRO_HI) * 10)

        '    '    Dim FecProFin As DateTime = mItem.PRO_FECHA.Value
        '    '    FecProFin = FecProFin.AddHours(Int(mItem.PRO_HF))
        '    '    FecProFin = FecProFin.AddMinutes((Int(mItem.PRO_HF) - mItem.PRO_HF) * 10)

        '    '    If FecProIni = contFecha Then
        '    '        OnManAgregarFilaGrid()
        '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_ID").Value = Nothing
        '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_ID").Tag = Nothing
        '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA").Value = mItem.PRO_HI
        '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA_FINAL").Value = mItem.PRO_HF
        '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Value = mItem.PRO_ID & " - " & mItem.Ladrillo.Articulos.ART_DESCRIPCION
        '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Tag = Nothing

        '    '        contFecha = FecProFin
        '    '        If Lista.Count - 1 >= idx Then idx += 1
        '    '    ElseIf FecProIni < contFecha And Flag = 0 Then
        '    '        OnManAgregarFilaGrid()
        '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_ID").Value = Nothing
        '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_ID").Tag = Nothing
        '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA").Value = mItem.PRO_HI
        '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA_FINAL").Value = mItem.PRO_HF
        '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Value = mItem.PRO_ID & " - " & mItem.Ladrillo.Articulos.ART_DESCRIPCION
        '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Tag = Nothing

        '    '        contFecha = FecProFin
        '    '        If Lista.Count - 1 >= idx Then idx += 1
        '    '    Else
        '    '        OnManAgregarFilaGrid()
        '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA").Value = contFecha
        '    '    End If
        '    '    contFecha.AddMinutes(1)

        '    '    'For Each mItem In Lista
        '    '    '    Dim FecProIni As DateTime = mItem.PRO_FECHA.Value
        '    '    '    If mItem.PRO_HI > mItem.PRO_HF Then
        '    '    '        FecProIni = FecProIni.AddDays(-1)
        '    '    '    End If
        '    '    '    FecProIni = FecProIni.AddHours(Int(mItem.PRO_HI))
        '    '    '    FecProIni = FecProIni.AddMinutes((Int(mItem.PRO_HI) - mItem.PRO_HI) * 10)

        '    '    '    Dim FecProFin As DateTime = mItem.PRO_FECHA.Value
        '    '    '    FecProFin = FecProFin.AddHours(Int(mItem.PRO_HF))
        '    '    '    FecProFin = FecProFin.AddMinutes((Int(mItem.PRO_HF) - mItem.PRO_HF) * 10)

        '    '    '    If FecProIni <= contFecha Then
        '    '    '        MsgBox(FecProIni)
        '    '    '        MsgBox(FecProFin)

        '    '    '        OnManAgregarFilaGrid()
        '    '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_ID").Value = Nothing
        '    '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_ID").Tag = Nothing
        '    '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA").Value = mItem.PRO_HI
        '    '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA_FINAL").Value = mItem.PRO_HF
        '    '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Value = mItem.PRO_ID & " - " & mItem.Ladrillo.Articulos.ART_DESCRIPCION
        '    '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Tag = Nothing

        '    '    '        contFecha = FecProFin
        '    '    '    Else
        '    '    '        OnManAgregarFilaGrid()
        '    '    '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA").Value = contFecha
        '    '    '    End If
        '    '    '    contFecha.AddMinutes(1)
        '    '    'Next
        '    'End While

        '    'End If



        '    ''For Each mItem In BCProduccion.ListaProduccionFecha(dtpFecha.Value, txtPlanta.Tag)
        '    ''    OnManAgregarFilaGrid()
        '    ''    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_ID").Value = Nothing
        '    ''    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_ID").Tag = Nothing
        '    ''    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA").Value = mItem.PRO_HI
        '    ''    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA_FINAL").Value = mItem.PRO_HF
        '    ''    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Value = mItem.PRO_ID & " - " & mItem.Ladrillo.Articulos.ART_DESCRIPCION
        '    ''    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Tag = Nothing
        '    ''Next
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "DPL_HORA"
                Try
                    If Not IsDate(Replace(dgvDetalle.CurrentCell.Value, ".", ":")) Then
                        dgvDetalle.CurrentCell.Value = 0
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

        End Select
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then dgvDetalle_CellDoubleClick(Nothing, Nothing)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------
        If mCPL IsNot Nothing Then
            dgvDetalle.EndEdit()
            mCPL.PLA_ID = CInt(txtPlanta.Tag)
            mCPL.CPL_FECHA = dtpFecha.Value
            mCPL.CPL_ESTADO = True
            mCPL.CPL_FEC_GRAB = Now
            mCPL.USU_ID = SessionServer.UserId
            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("DPL_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("DPL_ID").Tag, ControlPlantaDetalle)
                        .DPL_HORA = CDbl(mDetalle.Cells("DPL_HORA").Value)
                        .PAR_ID = CDbl(mDetalle.Cells("PAR_ID").Tag)
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("DPL_HORA").Value Is Nothing Then
                    Dim nDPL As New ControlPlantaDetalle
                    With nDPL
                        .DPL_HORA = CDbl(mDetalle.Cells("DPL_HORA").Value)
                        .PAR_ID = CDbl(mDetalle.Cells("PAR_ID").Tag)
                        .MarkAsAdded()
                    End With
                    mCPL.ControlPlantaDetalle.Add(nDPL)
                End If
            Next

            BCControlPlanta.MantenimientoControlPlanta(mCPL)
            LimpiarControles()
        End If


        '------------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mCPL = New ControlPlanta
        mCPL.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtPlanta.Focus()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ControlPlanta"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarControlPlanta(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarControlPlanta(ByVal CPL_Id As Integer)
        mCPL = BCControlPlanta.ControlPlantaGetById(CPL_Id)
        mCPL.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtPlanta.Text = mCPL.Planta.PLA_DESCRIPCION
        txtPlanta.Tag = mCPL.PLA_ID

        For Each mItem In mCPL.ControlPlantaDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_ID").Value = mItem.DPL_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA").Value = mItem.DPL_HORA
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_HORA_FINAL").Value = mItem.DPL_HORA_FINAL
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Value = mItem.Parada.PAR_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAR_ID").Tag = mItem.PAR_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DPL_OBSERVACION").Value = mItem.DPL_OBSERVACION
        Next
    End Sub
    '===================================================================================================================
    '----procedimiento de validaciones
    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(txtPlanta.Text.Trim) = 0 Then Error_Validacion.SetError(txtPlanta, "Ingrese la Planta") : txtPlanta.Focus() : flag = False

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

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
        If mCPL IsNot Nothing Then
            For Each mItem In mCPL.ControlPlantaDetalle
                mItem.MarkAsDeleted()
            Next
            mCPL.MarkAsDeleted()
            BCControlPlanta.MantenimientoControlPlanta(mCPL)
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

    Private Sub dtpFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        InsertarProduccion()
    End Sub
End Class
