Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmControlPeso
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCControlPeso As Ladisac.BL.IBCControlPeso
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mCPE As ControlPeso
    Protected mProduccion As Produccion

    'ingreso de codigo
    Private Sub frmControlPeso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()

        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.
        'se declara los objetos.

        Me.txtProduccion.TabIndex = 0
        Call validacion_desactivacion(False, 1)
        txtCodigo.TabIndex = 0
        txtProduccion.TabIndex = 1
        TabPage1.TabIndex = 2
        TabPage2.TabIndex = 3
        TabPage3.TabIndex = 4
        TabPage4.TabIndex = 5

    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mCPE = Nothing
        txtCodigo.Text = String.Empty
        txtProduccion.Text = String.Empty
        txtProduccion.Tag = Nothing
        dgvDetalle.Rows.Clear()
        dgvDetalle2.Rows.Clear()
        dgvDetalle3.Rows.Clear()
        dgvDetalle4.Rows.Clear()

        dgvDetalle.Rows(0).Cells("DPE_TIPO").Value = "HU"
        dgvDetalle2.Rows(0).Cells("DPE_TIPO2").Value = "SE"
        'dgvDetalle3.Rows(0).Cells("DPE_TIPO3").Value = "CA"
        dgvDetalle4.Rows(0).Cells("DPE_TIPO4").Value = "CO"


        '------------------------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub txtProduccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProduccion.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Produccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProduccion.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PRO_Id
            txtProduccion.Text = frm.dgvLista.CurrentRow.Cells(0).Value & " " & frm.dgvLista.CurrentRow.Cells("ART_DESCRIPCION").Value 'Nombres 'Nombres
            mProduccion = BCProduccion.ProduccionGetById(txtProduccion.Tag)
            If dgvDetalle.RowCount > 0 Then
                dgvDetalle.Rows(0).Cells(1).Tag = mProduccion.PER_ID_ING  'Per_Id
                dgvDetalle.Rows(0).Cells(1).Value = mProduccion.Personas.PER_NOMBRES & " " & mProduccion.Personas.PER_APE_PAT  'Nombres
            End If
        End If
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        Select Case e.ColumnIndex
            Case 1
                frm.Tabla = "Persona"
                frm.Tipo = "Trabajador"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
                End If
        End Select
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle2_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle2.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        Select Case e.ColumnIndex
            Case 1
                frm.Tabla = "Persona"
                frm.Tipo = "Trabajador"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle2.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                    dgvDetalle2.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
                End If
        End Select
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle3_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle3.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        Select Case e.ColumnIndex
            Case 1
                frm.Tabla = "Persona"
                frm.Tipo = "Trabajador"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle3.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                    dgvDetalle3.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
                End If
            Case 10
                frm.Tabla = "ControlCarga"
                frm.Tipo = mCPE.Produccion.PRO_ID
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle3.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'CAR_Id
                    dgvDetalle3.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value 'CAR_ID
                    dgvDetalle3.CurrentRow.Cells("DPE_FECHA3").Value = frm.dgvLista.CurrentRow.Cells(5).Value 'CAR_FECHA
                End If
        End Select
        frm.Dispose()
        dgvDetalle3_CellEndEdit(sender, e)
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Select Case tabPesos.SelectedIndex
            Case 2
                Dim nRow As New DataGridViewRow
                dgvDetalle3.Rows.Add(nRow)
                dgvDetalle3.CurrentCell = dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 1).Cells(1)
                If dgvDetalle3.CurrentRow.Index > 0 Then
                    For Each mCol As DataGridViewColumn In dgvDetalle3.Columns
                        dgvDetalle3.CurrentRow.Cells(mCol.Index).Value = dgvDetalle3.Rows(dgvDetalle3.CurrentRow.Index - 1).Cells(mCol.Index).Value
                        dgvDetalle3.CurrentRow.Cells(mCol.Index).Tag = dgvDetalle3.Rows(dgvDetalle3.CurrentRow.Index - 1).Cells(mCol.Index).Tag
                    Next
                    dgvDetalle3.CurrentRow.Cells("CAR_ID3").Value = String.Empty
                    dgvDetalle3.CurrentRow.Cells("CAR_ID3").Tag = Nothing
                    dgvDetalle3.CurrentRow.Cells("DPE_ID3").Value = Nothing
                Else
                    dgvDetalle3.CurrentRow.Cells("DPE_TIPO3").Value = "CA"
                End If
        End Select
    End Sub

    Private Sub dgvDetalle4_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle4.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        Select Case e.ColumnIndex
            Case 1
                frm.Tabla = "Persona"
                frm.Tipo = "Trabajador"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle4.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                    dgvDetalle4.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
                End If
        End Select
        frm.Dispose()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '---------------------------------------------



        If mCPE IsNot Nothing Then
            dgvDetalle.EndEdit()
            mCPE.PRO_ID = CInt(txtProduccion.Tag)
            mCPE.CPE_ESTADO = True
            mCPE.CPE_FEC_GRAB = Now
            mCPE.USU_ID = SessionServer.UserId
            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("DPE_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("DPE_ID").Tag, ControlPesoDetalle)
                        .PER_ID_OPERADOR = mDetalle.Cells("PER_ID_OPERADOR").Tag
                        .DPE_FECHA = mDetalle.Cells("DPE_FECHA").Value
                        .DPE_PESO = CDbl(mDetalle.Cells("DPE_PESO").Value)
                        .DPE_PESO_TIERRA = CDbl(mDetalle.Cells("DPE_PESO_TIERRA").Value)
                        .DPE_PORCENTAJE_HUMEDAD = CDbl(mDetalle.Cells("DPE_PORCENTAJE_HUMEDAD").Value)
                        .DPE_TIPO = mDetalle.Cells("DPE_TIPO").Value
                        .DPE_ALTO = CDbl(mDetalle.Cells("DPE_ALTO").Value)
                        .DPE_ANCHO = CDbl(mDetalle.Cells("DPE_ANCHO").Value)
                        .DPE_LARGO = CDbl(mDetalle.Cells("DPE_LARGO").Value)
                        .CAR_ID = CInt(mDetalle.Cells("CAR_ID").Value)
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("PER_ID_OPERADOR").Value Is Nothing Then
                    Dim nDPE As New ControlPesoDetalle
                    With nDPE
                        .PER_ID_OPERADOR = mDetalle.Cells("PER_ID_OPERADOR").Tag
                        .DPE_FECHA = mDetalle.Cells("DPE_FECHA").Value
                        .DPE_PESO = CDbl(mDetalle.Cells("DPE_PESO").Value)
                        .DPE_PESO_TIERRA = CDbl(mDetalle.Cells("DPE_PESO_TIERRA").Value)
                        .DPE_PORCENTAJE_HUMEDAD = CDbl(mDetalle.Cells("DPE_PORCENTAJE_HUMEDAD").Value)
                        .DPE_TIPO = mDetalle.Cells("DPE_TIPO").Value
                        .DPE_ALTO = CDbl(mDetalle.Cells("DPE_ALTO").Value)
                        .DPE_ANCHO = CDbl(mDetalle.Cells("DPE_ANCHO").Value)
                        .DPE_LARGO = CDbl(mDetalle.Cells("DPE_LARGO").Value)
                        .CAR_ID = CInt(mDetalle.Cells("CAR_ID").Value)
                        .MarkAsAdded()
                    End With
                    mCPE.ControlPesoDetalle.Add(nDPE)

                    'Para peso cocido
                    nDPE = New ControlPesoDetalle
                    With nDPE
                        .PER_ID_OPERADOR = mDetalle.Cells("PER_ID_OPERADOR").Tag
                        .DPE_FECHA = mDetalle.Cells("DPE_FECHA").Value
                        .DPE_PESO = (CDbl(mDetalle.Cells("DPE_PESO").Value) * 76.5) / 100
                        .DPE_PESO_TIERRA = .DPE_PESO - (.DPE_PESO * (CDbl(mDetalle.Cells("DPE_PORCENTAJE_HUMEDAD").Value) / 100))
                        .DPE_PORCENTAJE_HUMEDAD = CDbl(mDetalle.Cells("DPE_PORCENTAJE_HUMEDAD").Value)
                        .DPE_TIPO = "CO"
                        .DPE_ALTO = CDbl(mDetalle.Cells("DPE_ALTO").Value)
                        .DPE_ANCHO = CDbl(mDetalle.Cells("DPE_ANCHO").Value)
                        .DPE_LARGO = CDbl(mDetalle.Cells("DPE_LARGO").Value)
                        .CAR_ID = CInt(mDetalle.Cells("CAR_ID").Value)
                        .MarkAsAdded()
                    End With
                    mCPE.ControlPesoDetalle.Add(nDPE)
                End If
            Next
            '2
            For Each mDetalle As DataGridViewRow In dgvDetalle2.Rows
                If Not mDetalle.Cells("DPE_ID2").Value Is Nothing Then
                    With CType(mDetalle.Cells("DPE_ID2").Tag, ControlPesoDetalle)
                        .PER_ID_OPERADOR = mDetalle.Cells("PER_ID_OPERADOR2").Tag
                        .DPE_FECHA = mDetalle.Cells("DPE_FECHA2").Value
                        .DPE_PESO = CDbl(mDetalle.Cells("DPE_PESO2").Value)
                        .DPE_PESO_TIERRA = CDbl(mDetalle.Cells("DPE_PESO_TIERRA2").Value)
                        .DPE_PORCENTAJE_HUMEDAD = CDbl(mDetalle.Cells("DPE_PORCENTAJE_HUMEDAD2").Value)
                        .DPE_TIPO = mDetalle.Cells("DPE_TIPO2").Value
                        .DPE_ALTO = CDbl(mDetalle.Cells("DPE_ALTO2").Value)
                        .DPE_ANCHO = CDbl(mDetalle.Cells("DPE_ANCHO2").Value)
                        .DPE_LARGO = CDbl(mDetalle.Cells("DPE_LARGO2").Value)
                        .CAR_ID = CInt(mDetalle.Cells("CAR_ID2").Value)
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("PER_ID_OPERADOR2").Value Is Nothing Then
                    Dim nDPE As New ControlPesoDetalle
                    With nDPE
                        .PER_ID_OPERADOR = mDetalle.Cells("PER_ID_OPERADOR2").Tag
                        .DPE_FECHA = mDetalle.Cells("DPE_FECHA2").Value
                        .DPE_PESO = CDbl(mDetalle.Cells("DPE_PESO2").Value)
                        .DPE_PESO_TIERRA = CDbl(mDetalle.Cells("DPE_PESO_TIERRA2").Value)
                        .DPE_PORCENTAJE_HUMEDAD = CDbl(mDetalle.Cells("DPE_PORCENTAJE_HUMEDAD2").Value)
                        .DPE_TIPO = mDetalle.Cells("DPE_TIPO2").Value
                        .DPE_ALTO = CDbl(mDetalle.Cells("DPE_ALTO2").Value)
                        .DPE_ANCHO = CDbl(mDetalle.Cells("DPE_ANCHO2").Value)
                        .DPE_LARGO = CDbl(mDetalle.Cells("DPE_LARGO2").Value)
                        .CAR_ID = CInt(mDetalle.Cells("CAR_ID2").Value)
                        .MarkAsAdded()
                    End With
                    mCPE.ControlPesoDetalle.Add(nDPE)
                End If
            Next
            '3
            For Each mDetalle As DataGridViewRow In dgvDetalle3.Rows
                If Not mDetalle.Cells("DPE_ID3").Value Is Nothing Then
                    With CType(mDetalle.Cells("DPE_ID3").Tag, ControlPesoDetalle)
                        .PER_ID_OPERADOR = mDetalle.Cells("PER_ID_OPERADOR3").Tag
                        .DPE_FECHA = mDetalle.Cells("DPE_FECHA3").Value
                        .DPE_PESO = CDbl(mDetalle.Cells("DPE_PESO3").Value)
                        .DPE_PESO_TIERRA = CDbl(mDetalle.Cells("DPE_PESO_TIERRA3").Value)
                        .DPE_PORCENTAJE_HUMEDAD = CDbl(mDetalle.Cells("DPE_PORCENTAJE_HUMEDAD3").Value)
                        .DPE_TIPO = mDetalle.Cells("DPE_TIPO3").Value
                        .DPE_ALTO = CDbl(mDetalle.Cells("DPE_ALTO3").Value)
                        .DPE_ANCHO = CDbl(mDetalle.Cells("DPE_ANCHO3").Value)
                        .DPE_LARGO = CDbl(mDetalle.Cells("DPE_LARGO3").Value)
                        .CAR_ID = CInt(mDetalle.Cells("CAR_ID3").Value)
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("PER_ID_OPERADOR3").Value Is Nothing Then
                    Dim nDPE As New ControlPesoDetalle
                    With nDPE
                        .PER_ID_OPERADOR = mDetalle.Cells("PER_ID_OPERADOR3").Tag
                        .DPE_FECHA = mDetalle.Cells("DPE_FECHA3").Value
                        .DPE_PESO = CDbl(mDetalle.Cells("DPE_PESO3").Value)
                        .DPE_PESO_TIERRA = CDbl(mDetalle.Cells("DPE_PESO_TIERRA3").Value)
                        .DPE_PORCENTAJE_HUMEDAD = CDbl(mDetalle.Cells("DPE_PORCENTAJE_HUMEDAD3").Value)
                        .DPE_TIPO = mDetalle.Cells("DPE_TIPO3").Value
                        .DPE_ALTO = CDbl(mDetalle.Cells("DPE_ALTO3").Value)
                        .DPE_ANCHO = CDbl(mDetalle.Cells("DPE_ANCHO3").Value)
                        .DPE_LARGO = CDbl(mDetalle.Cells("DPE_LARGO3").Value)
                        .CAR_ID = CInt(mDetalle.Cells("CAR_ID3").Value)
                        .MarkAsAdded()
                    End With
                    mCPE.ControlPesoDetalle.Add(nDPE)
                End If
            Next
            '4
            For Each mDetalle As DataGridViewRow In dgvDetalle4.Rows
                If Not mDetalle.Cells("DPE_ID4").Value Is Nothing Then
                    With CType(mDetalle.Cells("DPE_ID4").Tag, ControlPesoDetalle)
                        .PER_ID_OPERADOR = mDetalle.Cells("PER_ID_OPERADOR4").Tag
                        .DPE_FECHA = mDetalle.Cells("DPE_FECHA4").Value
                        .DPE_PESO = CDbl(mDetalle.Cells("DPE_PESO4").Value)
                        .DPE_PESO_TIERRA = CDbl(mDetalle.Cells("DPE_PESO_TIERRA4").Value)
                        .DPE_PORCENTAJE_HUMEDAD = CDbl(mDetalle.Cells("DPE_PORCENTAJE_HUMEDAD4").Value)
                        .DPE_TIPO = mDetalle.Cells("DPE_TIPO4").Value
                        .DPE_ALTO = CDbl(mDetalle.Cells("DPE_ALTO4").Value)
                        .DPE_ANCHO = CDbl(mDetalle.Cells("DPE_ANCHO4").Value)
                        .DPE_LARGO = CDbl(mDetalle.Cells("DPE_LARGO4").Value)
                        .CAR_ID = CInt(mDetalle.Cells("CAR_ID4").Value)
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("PER_ID_OPERADOR4").Value Is Nothing Then
                    Dim nDPE As New ControlPesoDetalle
                    With nDPE
                        .PER_ID_OPERADOR = mDetalle.Cells("PER_ID_OPERADOR4").Tag
                        .DPE_FECHA = mDetalle.Cells("DPE_FECHA4").Value
                        .DPE_PESO = CDbl(mDetalle.Cells("DPE_PESO4").Value)
                        .DPE_PESO_TIERRA = CDbl(mDetalle.Cells("DPE_PESO_TIERRA4").Value)
                        .DPE_PORCENTAJE_HUMEDAD = CDbl(mDetalle.Cells("DPE_PORCENTAJE_HUMEDAD4").Value)
                        .DPE_TIPO = mDetalle.Cells("DPE_TIPO4").Value
                        .DPE_ALTO = CDbl(mDetalle.Cells("DPE_ALTO4").Value)
                        .DPE_ANCHO = CDbl(mDetalle.Cells("DPE_ANCHO4").Value)
                        .DPE_LARGO = CDbl(mDetalle.Cells("DPE_LARGO4").Value)
                        .CAR_ID = CInt(mDetalle.Cells("CAR_ID4").Value)
                        .MarkAsAdded()
                    End With
                    mCPE.ControlPesoDetalle.Add(nDPE)
                End If
            Next
            BCControlPeso.MantenimientoControlPeso(mCPE)
            LimpiarControles()
        End If



        '------------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mCPE = New ControlPeso
        mCPE.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtProduccion.Focus()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ControlPeso"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarControlPeso(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarControlPeso(ByVal CPE_Id As Integer)
        mCPE = BCControlPeso.ControlPesoGetById(CPE_Id)
        mCPE.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mCPE.CPE_ID
        txtProduccion.Text = mCPE.Produccion.PRO_ID & " - " & mCPE.Produccion.Ladrillo.Articulos.ART_DESCRIPCION
        txtProduccion.Tag = mCPE.Produccion.PRO_ID

        For Each mItem In mCPE.ControlPesoDetalle
            Dim nRow As New DataGridViewRow
            Select Case mItem.DPE_TIPO
                Case "HU"
                    dgvDetalle.Rows.Add(nRow)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DPE_ID").Value = mItem.DPE_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DPE_ID").Tag = mItem
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PER_ID_OPERADOR").Value = mItem.Personas.PER_NOMBRES & " " & mItem.Personas.PER_APE_PAT
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PER_ID_OPERADOR").Tag = mItem.PER_ID_OPERADOR
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DPE_FECHA").Value = mItem.DPE_FECHA
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DPE_PESO").Value = mItem.DPE_PESO
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DPE_PESO_TIERRA").Value = mItem.DPE_PESO_TIERRA
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DPE_PORCENTAJE_HUMEDAD").Value = mItem.DPE_PORCENTAJE_HUMEDAD
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DPE_TIPO").Value = mItem.DPE_TIPO
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DPE_ALTO").Value = mItem.DPE_ALTO
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DPE_ANCHO").Value = mItem.DPE_ANCHO
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DPE_LARGO").Value = mItem.DPE_LARGO
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAR_ID").Value = mItem.CAR_ID
                Case "SE"
                    dgvDetalle2.Rows.Add(nRow)
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DPE_ID2").Value = mItem.DPE_ID
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DPE_ID2").Tag = mItem
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("PER_ID_OPERADOR2").Value = mItem.Personas.PER_NOMBRES & " " & mItem.Personas.PER_APE_PAT
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("PER_ID_OPERADOR2").Tag = mItem.PER_ID_OPERADOR
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DPE_FECHA2").Value = mItem.DPE_FECHA
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DPE_PESO2").Value = mItem.DPE_PESO
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DPE_PESO_TIERRA2").Value = mItem.DPE_PESO_TIERRA
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DPE_PORCENTAJE_HUMEDAD2").Value = mItem.DPE_PORCENTAJE_HUMEDAD
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DPE_TIPO2").Value = mItem.DPE_TIPO
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DPE_ALTO2").Value = mItem.DPE_ALTO
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DPE_ANCHO2").Value = mItem.DPE_ANCHO
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DPE_LARGO2").Value = mItem.DPE_LARGO
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("CAR_ID2").Value = mItem.CAR_ID
                Case "CA"
                    dgvDetalle3.Rows.Add(nRow)
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 1).Cells("DPE_ID3").Value = mItem.DPE_ID
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 1).Cells("DPE_ID3").Tag = mItem
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 1).Cells("PER_ID_OPERADOR3").Value = mItem.Personas.PER_NOMBRES & " " & mItem.Personas.PER_APE_PAT
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 1).Cells("PER_ID_OPERADOR3").Tag = mItem.PER_ID_OPERADOR
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 1).Cells("DPE_FECHA3").Value = mItem.DPE_FECHA
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 1).Cells("DPE_PESO3").Value = mItem.DPE_PESO
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 1).Cells("DPE_PESO_TIERRA3").Value = mItem.DPE_PESO_TIERRA
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 1).Cells("DPE_PORCENTAJE_HUMEDAD3").Value = mItem.DPE_PORCENTAJE_HUMEDAD
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 1).Cells("DPE_TIPO3").Value = mItem.DPE_TIPO
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 1).Cells("DPE_ALTO3").Value = mItem.DPE_ALTO
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 1).Cells("DPE_ANCHO3").Value = mItem.DPE_ANCHO
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 1).Cells("DPE_LARGO3").Value = mItem.DPE_LARGO
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 1).Cells("CAR_ID3").Value = mItem.CAR_ID
                Case "CO"
                    dgvDetalle4.Rows.Add(nRow)
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("DPE_ID4").Value = mItem.DPE_ID
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("DPE_ID4").Tag = mItem
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("PER_ID_OPERADOR4").Value = mItem.Personas.PER_NOMBRES & " " & mItem.Personas.PER_APE_PAT
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("PER_ID_OPERADOR4").Tag = mItem.PER_ID_OPERADOR
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("DPE_FECHA4").Value = mItem.DPE_FECHA
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("DPE_PESO4").Value = mItem.DPE_PESO
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("DPE_PESO_TIERRA4").Value = mItem.DPE_PESO_TIERRA
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("DPE_PORCENTAJE_HUMEDAD4").Value = mItem.DPE_PORCENTAJE_HUMEDAD
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("DPE_TIPO4").Value = mItem.DPE_TIPO
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("DPE_ALTO4").Value = mItem.DPE_ALTO
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("DPE_ANCHO4").Value = mItem.DPE_ANCHO
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("DPE_LARGO4").Value = mItem.DPE_LARGO
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("CAR_ID4").Value = mItem.CAR_ID
            End Select

        Next
    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        Select Case dgvDetalle.CurrentCell.ColumnIndex
            Case 4, 6
                dgvDetalle.CurrentRow.Cells("DPE_PESO_TIERRA").Value = dgvDetalle.CurrentRow.Cells("DPE_PESO").Value - (dgvDetalle.CurrentRow.Cells("DPE_PESO").Value * (dgvDetalle.CurrentRow.Cells("DPE_PORCENTAJE_HUMEDAD").Value / 100))
        End Select
        dgvDetalle.CurrentRow.Cells("DPE_TIPO").Value = "HU"
    End Sub


    Private Sub dgvDetalle2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle2.CellEndEdit
        dgvDetalle.EndEdit()
        Dim mPT = (From mG As DataGridViewRow In dgvDetalle.Rows Where mG.Cells("DPE_PESO").Value > 0 Order By mG.Cells("DPE_FECHA").Value Descending Select PesoTierra = mG.Cells("DPE_PESO_TIERRA").Value, Peso = mG.Cells("DPE_PESO").Value, Porcentaje = mG.Cells("DPE_PORCENTAJE_HUMEDAD").Value).FirstOrDefault
        dgvDetalle2.CurrentRow.Cells("DPE_PESO_TIERRA2").Value = mPT.PesoTierra
        Select Case dgvDetalle2.CurrentCell.ColumnIndex
            Case 4
                dgvDetalle2.CurrentRow.Cells("DPE_PORCENTAJE_HUMEDAD2").Value = mPT.Porcentaje - (100 - ((dgvDetalle2.CurrentRow.Cells("DPE_PESO2").Value / mPT.Peso) * 100))
        End Select
        dgvDetalle2.CurrentRow.Cells("DPE_TIPO2").Value = "SE"
        If dgvDetalle2.RowCount > 1 Then
            dgvDetalle2.CurrentRow.Cells("PER_ID_OPERADOR2").Tag = dgvDetalle2.Rows(0).Cells("PER_ID_OPERADOR2").Tag
            dgvDetalle2.CurrentRow.Cells("PER_ID_OPERADOR2").Value = dgvDetalle2.Rows(0).Cells("PER_ID_OPERADOR2").Value
        End If
    End Sub


    Private Sub dgvDetalle3_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle3.CellEndEdit
        dgvDetalle2.EndEdit()
        Dim mPT = (From mG As DataGridViewRow In dgvDetalle2.Rows Where mG.Cells("DPE_PESO2").Value > 0 Order By mG.Cells("DPE_FECHA2").Value Descending Select PesoTierra = mG.Cells("DPE_PESO_TIERRA2").Value, Peso = mG.Cells("DPE_PESO2").Value, Porcentaje = mG.Cells("DPE_PORCENTAJE_HUMEDAD2").Value).FirstOrDefault
        If mPT IsNot Nothing Then
            dgvDetalle3.CurrentRow.Cells("DPE_PESO3").Value = mPT.Peso
            dgvDetalle3.CurrentRow.Cells("DPE_PESO_TIERRA3").Value = mPT.PesoTierra
            dgvDetalle3.CurrentRow.Cells("DPE_PORCENTAJE_HUMEDAD3").Value = mPT.Porcentaje
            dgvDetalle3.CurrentRow.Cells("DPE_TIPO3").Value = "CA"
        End If
        If dgvDetalle3.RowCount > 1 Then
            dgvDetalle3.CurrentRow.Cells("PER_ID_OPERADOR3").Tag = dgvDetalle3.Rows(0).Cells("PER_ID_OPERADOR3").Tag
            dgvDetalle3.CurrentRow.Cells("PER_ID_OPERADOR3").Value = dgvDetalle3.Rows(0).Cells("PER_ID_OPERADOR3").Value
        End If
    End Sub


    Private Sub dgvDetalle4_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle4.CellEndEdit
        Select Case dgvDetalle4.CurrentCell.ColumnIndex
            Case 4, 6
                dgvDetalle4.CurrentRow.Cells("DPE_PESO_TIERRA4").Value = dgvDetalle4.CurrentRow.Cells("DPE_PESO4").Value - (dgvDetalle4.CurrentRow.Cells("DPE_PESO4").Value * (dgvDetalle4.CurrentRow.Cells("DPE_PORCENTAJE_HUMEDAD4").Value / 100))
        End Select
        dgvDetalle4.CurrentRow.Cells("DPE_TIPO4").Value = "CO"
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        If Not e.Row.Cells("DPE_ID").Value Is Nothing Then
            CType(e.Row.Cells("DPE_ID").Tag, ControlPesoDetalle).MarkAsDeleted()
        End If
    End Sub

    Private Sub dgvDetalle2_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle2.UserDeletingRow
        If Not e.Row.Cells("DPE_ID2").Value Is Nothing Then
            CType(e.Row.Cells("DPE_ID2").Tag, ControlPesoDetalle).MarkAsDeleted()
        End If
    End Sub

    Private Sub dgvDetalle3_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle3.UserDeletingRow
        If Not e.Row.Cells("DPE_ID3").Value Is Nothing Then
            CType(e.Row.Cells("DPE_ID3").Tag, ControlPesoDetalle).MarkAsDeleted()
        End If
    End Sub

    Private Sub dgvDetalle4_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle4.UserDeletingRow
        If Not e.Row.Cells("DPE_ID4").Value Is Nothing Then
            CType(e.Row.Cells("DPE_ID4").Tag, ControlPesoDetalle).MarkAsDeleted()
        End If
    End Sub

    '===================================================================================================================
    '----procedimiento de validaciones

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(txtProduccion.Text.Trim) = 0 Then Error_validacion.SetError(txtProduccion, "Ingrese la Produccion") : txtProduccion.Focus() : flag = False

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
        If mCPE IsNot Nothing Then
            For Each mItem In mCPE.ControlPesoDetalle
                mItem.MarkAsDeleted()
            Next
            mCPE.MarkAsDeleted()
            BCControlPeso.MantenimientoControlPeso(mCPE)
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

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        If dgvDetalle.CurrentCell.ColumnIndex = 1 And e.KeyCode = Keys.Enter Then
            frm.Tabla = "Persona"
            frm.Tipo = "Trabajador"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
            End If
            e.SuppressKeyPress = True
        End If
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle2.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        If dgvDetalle2.CurrentCell.ColumnIndex = 1 And e.KeyCode = Keys.Enter Then
            frm.Tabla = "Persona"
            frm.Tipo = "Trabajador"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dgvDetalle2.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                dgvDetalle2.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
            End If
        End If
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle3.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        If dgvDetalle3.CurrentCell.ColumnIndex = 1 And e.KeyCode = Keys.Enter Then
            frm.Tabla = "Persona"
            frm.Tipo = "Trabajador"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dgvDetalle3.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                dgvDetalle3.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
            End If
        ElseIf dgvDetalle3.CurrentCell.ColumnIndex = 10 And e.KeyCode = Keys.Enter Then
            frm.Tabla = "ControlCarga"
            frm.Tipo = mCPE.Produccion.PRO_ID
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dgvDetalle3.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'CAR_Id
                dgvDetalle3.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value 'CAR_ID
            End If
        End If
        frm.Dispose()
        dgvDetalle3_CellEndEdit(sender, Nothing)
    End Sub

    Private Sub dgvDetalle4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle4.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        If dgvDetalle4.CurrentCell.ColumnIndex = 1 And e.KeyCode = Keys.Enter Then
            frm.Tabla = "Persona"
            frm.Tipo = "Trabajador"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dgvDetalle4.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                dgvDetalle4.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
            End If
        End If
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvDetalle.RowsAdded
        Try
            dgvDetalle.Rows(dgvDetalle.RowCount - 1).Cells("DPE_PORCENTAJE_HUMEDAD").Value = 19
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvDetalle4_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvDetalle4.RowsAdded
        Try
            dgvDetalle4.Rows(dgvDetalle4.RowCount - 1).Cells("DPE_PORCENTAJE_HUMEDAD4").Value = 19
        Catch ex As Exception

        End Try
    End Sub
End Class
