Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmCaCoDe
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCCaCoDeDetalle As Ladisac.BL.IBCCaCoDeDetalle
    <Dependency()> _
    Public Property BCControlCarga As Ladisac.BL.IBCControlCarga
    <Dependency()> _
    Public Property BCControlQuema As Ladisac.BL.IBCControlQuema
    <Dependency()> _
    Public Property BCControlDescarga As Ladisac.BL.IBCControlDescarga
    <Dependency()> _
    Public Property BCHorno As Ladisac.BL.IBCHorno
    <Dependency()> _
    Public Property BCPuertaHorno As Ladisac.BL.IBCPuertaHorno
    <Dependency()> _
    Public Property BCLadrilloMalecon As Ladisac.BL.IBCLadrilloMalecon
    <Dependency()> _
    Public Property BCMaleconPuerta As Ladisac.BL.IBCMaleconPuerta

    Protected mHorno As Horno
    Protected mLMA As LadrilloMalecon
    Protected Estado As String
    Protected BuscarFecha As Date
    'Protected mArticuloAlmacen As ArticuloAlmacen
    'Protected mOC As OrdenCompra
    Dim colCCD As New List(Of CaCoDe_Detalle)
    Structure Copia
        Dim mColumna As String
        Dim mValue As String
        Dim mTag As String
    End Structure
    Dim mCopia As Copia







    'ingreso de codigo
    Private Sub frmCaCoDe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarHornos()
        LimpiarControles()
        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.
        paso_enter(txtOperador1, cboHorno, Nothing, Nothing, 2)
        paso_enter(txtProduccion, Nothing, Nothing, Nothing, 1)
        paso_enter(txtOperador1, Nothing, Nothing, Nothing, 1)
        paso_enter(txtOperador2, Nothing, Nothing, Nothing, 1)
        paso_enter(txtOperador1, cboPuerta, Nothing, Nothing, 2)
        paso_enter(txtOperador1, cboHorno, numHF, dtpFecha, 4)
        paso_enter(txtOperador1, cboHorno, numHI, Nothing, 3)
        paso_enter(txtOperador1, cboHorno, numMI, Nothing, 3)
        paso_enter(txtOperador1, cboTipo, Nothing, Nothing, 2)
        paso_enter(txtOperador1, cboHorno, numHF, Nothing, 3)
        paso_enter(txtOperador1, cboHorno, numMF, Nothing, 3)

        Me.cboHorno.TabIndex = 0
        Call validar_longitud()
        Call validacion_desactivacion(False, 1)
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        cboHorno.SelectedIndex = -1
        txtProduccion.Text = String.Empty
        txtProduccion.Tag = Nothing
        txtOperador1.Text = String.Empty
        txtOperador1.Tag = Nothing
        txtOperador2.Text = String.Empty
        txtOperador2.Tag = Nothing
        cboPuerta.DataSource = Nothing
        dtpFecha.Value = Today
        numHI.Value = 0
        numHF.Value = 0
        numMI.Value = 0
        numMF.Value = 0
        numCarMI.Value = 0
        numCarMF.Value = 0
        cboTipo.SelectedIndex = -1
        dgvDetalle.Rows.Clear()
        dgvDetalle2.Rows.Clear()
        dgvDetalle3.Rows.Clear()
        dgvDetalle4.Rows.Clear()

        '--------------------------
        Error_Validacion.Clear()
    End Sub

    Sub CargarHornos()
        Dim ds As New DataSet
        Dim query = BCHorno.ListaHorno
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboHorno
            .DisplayMember = "HOR_Descripcion"
            .ValueMember = "HOR_ID"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    Sub CargarPuertaHorno(ByVal HOR_ID As Integer)
        Dim ds As New DataSet
        Dim query = BCPuertaHorno.ListaPuertaHornoByHorno(HOR_ID)
        If query.Length > 0 Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            With cboPuerta
                .DisplayMember = "PUE_Descripcion"
                .ValueMember = "PUE_ID"
                .DataSource = ds.Tables(0)
            End With
            cboPuerta.SelectedIndex = -1
        End If
    End Sub

    Sub CargarCaCoDeDetalle(ByVal Dia As Date, ByVal HOR_ID As Integer)
        colCCD.Clear()
        dgvDetalle.Rows.Clear()
        dgvDetalle2.Rows.Clear()
        dgvDetalle3.Rows.Clear()
        dgvDetalle4.Rows.Clear()
        Dim ds As New DataSet
        Dim query = BCCaCoDeDetalle.ListaCaCoDeDetalle(Dia, HOR_ID)
        If query.Length > 0 Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            For Each mItem In ds.Tables(0).Rows
                Dim mCCD As New CaCoDe_Detalle
                Dim nRow As New DataGridViewRow
                'mCCD = BCCaCoDeDetalle.CargarCaCoDeDetalle(mItem)
                mCCD = BCCaCoDeDetalle.CaCoDeDetalleGetById(mItem("CCD_ID"))
                colCCD.Add(mCCD) 'Agrego a la coleccion

                If mCCD.CCD_PUERTA = IIf(cboHorno.SelectedValue = "25", "1", "5") Then
                    dgvDetalle.Rows.Add(nRow)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_ID").Value = mCCD.CCD_ID  'mItem("CCD_ID")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_ID").Tag = mCCD
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAR_ID").Value = mCCD.CAR_ID  'mItem("CAR_ID")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("COQ_ID").Value = mCCD.COQ_ID  'mItem("COQ_ID")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DES_ID").Value = mCCD.DES_ID  'mItem("DES_ID")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("LMA_ID").Value = mCCD.LMA_ID  'mItem("LMA_ID")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_NRO_MALE").Value = String.Format("{0:000}", CInt(mCCD.CCD_NRO_MALE))  'mItem("CCD_NRO_MALE")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_FECHA").Value = mCCD.CCD_FECHA  'mItem("CCD_FECHA")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_TIPO").Value = mCCD.CCD_TIPO  'mItem("CCD_TIPO")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_ESTADO").Value = mCCD.CCD_ESTADO  'mItem("CCD_ESTADO")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_CANTIDAD").Value = mCCD.CCD_CANTIDAD  'mItem("CCD_CANTIDAD")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("HOR_ID").Value = mCCD.HOR_ID  'mItem("HOR_ID")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PUE_ID").Value = mCCD.PUE_ID  'mItem("PUE_ID")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_HORNO").Value = mCCD.CCD_HORNO  'mItem("CCD_HORNO")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_PUERTA").Value = mCCD.CCD_PUERTA  'mItem("CCD_PUERTA")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("LADRILLO").Value = mCCD.LadrilloMalecon.Ladrillo.Articulos.ART_DESCRIPCION
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PRO_ID").Value = mCCD.ControlCarga.PRO_ID
                End If

                If mCCD.CCD_PUERTA = IIf(cboHorno.SelectedValue = "25", "2", "6") Then
                    dgvDetalle2.Rows.Add(nRow.Clone)
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("CCD_ID2").Value = mCCD.CCD_ID  'mItem("CCD_ID")
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("CCD_ID2").Tag = mCCD
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("CAR_ID2").Value = mCCD.CAR_ID  'mItem("CAR_ID")
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("COQ_ID2").Value = mCCD.COQ_ID  'mItem("COQ_ID")
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("DES_ID2").Value = mCCD.DES_ID  'mItem("DES_ID")
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("LMA_ID2").Value = mCCD.LMA_ID  'mItem("LMA_ID")
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("CCD_NRO_MALE2").Value = String.Format("{0:000}", CInt(mCCD.CCD_NRO_MALE))  'mItem("CCD_NRO_MALE")
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("CCD_FECHA2").Value = mCCD.CCD_FECHA  'mItem("CCD_FECHA")
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("CCD_TIPO2").Value = mCCD.CCD_TIPO  'mItem("CCD_TIPO")
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("CCD_ESTADO2").Value = mCCD.CCD_ESTADO  'mItem("CCD_ESTADO")
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("CCD_CANTIDAD2").Value = mCCD.CCD_CANTIDAD  'mItem("CCD_CANTIDAD")
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("HOR_ID2").Value = mCCD.HOR_ID  'mItem("HOR_ID")
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("PUE_ID2").Value = mCCD.PUE_ID  'mItem("PUE_ID")
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("CCD_HORNO2").Value = mCCD.CCD_HORNO  'mItem("CCD_HORNO")
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("CCD_PUERTA2").Value = mCCD.CCD_PUERTA  'mItem("CCD_PUERTA")
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("LADRILLO2").Value = mCCD.LadrilloMalecon.Ladrillo.Articulos.ART_DESCRIPCION
                    dgvDetalle2.Rows(dgvDetalle2.Rows.Count - 2).Cells("PRO_ID2").Value = mCCD.ControlCarga.PRO_ID
                End If

                If mCCD.CCD_PUERTA = IIf(cboHorno.SelectedValue = "25", "3", "7") Then
                    dgvDetalle3.Rows.Add(nRow.Clone)
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("CCD_ID3").Value = mCCD.CCD_ID  'mItem("CCD_ID")
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("CCD_ID3").Tag = mCCD
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("CAR_ID3").Value = mCCD.CAR_ID  'mItem("CAR_ID")
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("COQ_ID3").Value = mCCD.COQ_ID  'mItem("COQ_ID")
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("DES_ID3").Value = mCCD.DES_ID  'mItem("DES_ID")
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("LMA_ID3").Value = mCCD.LMA_ID  'mItem("LMA_ID")
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("CCD_NRO_MALE3").Value = String.Format("{0:000}", CInt(mCCD.CCD_NRO_MALE))  'mItem("CCD_NRO_MALE")
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("CCD_FECHA3").Value = mCCD.CCD_FECHA  'mItem("CCD_FECHA")
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("CCD_TIPO3").Value = mCCD.CCD_TIPO  'mItem("CCD_TIPO")
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("CCD_ESTADO3").Value = mCCD.CCD_ESTADO  'mItem("CCD_ESTADO")
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("CCD_CANTIDAD3").Value = mCCD.CCD_CANTIDAD  'mItem("CCD_CANTIDAD")
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("HOR_ID3").Value = mCCD.HOR_ID  'mItem("HOR_ID")
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("PUE_ID3").Value = mCCD.PUE_ID  'mItem("PUE_ID")
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("CCD_HORNO3").Value = mCCD.CCD_HORNO  'mItem("CCD_HORNO")
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("CCD_PUERTA3").Value = mCCD.CCD_PUERTA  'mItem("CCD_PUERTA")
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("LADRILLO3").Value = mCCD.LadrilloMalecon.Ladrillo.Articulos.ART_DESCRIPCION
                    dgvDetalle3.Rows(dgvDetalle3.Rows.Count - 2).Cells("PRO_ID3").Value = mCCD.ControlCarga.PRO_ID
                End If

                If mCCD.CCD_PUERTA = IIf(cboHorno.SelectedValue = "25", "4", "8") Then
                    dgvDetalle4.Rows.Add(nRow.Clone)
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("CCD_ID4").Value = mCCD.CCD_ID  'mItem("CCD_ID")
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("CCD_ID4").Tag = mCCD
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("CAR_ID4").Value = mCCD.CAR_ID  'mItem("CAR_ID")
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("COQ_ID4").Value = mCCD.COQ_ID  'mItem("COQ_ID")
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("DES_ID4").Value = mCCD.DES_ID  'mItem("DES_ID")
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("LMA_ID4").Value = mCCD.LMA_ID  'mItem("LMA_ID")
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("CCD_NRO_MALE4").Value = String.Format("{0:000}", CInt(mCCD.CCD_NRO_MALE))  'mItem("CCD_NRO_MALE")
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("CCD_FECHA4").Value = mCCD.CCD_FECHA  'mItem("CCD_FECHA")
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("CCD_TIPO4").Value = mCCD.CCD_TIPO  'mItem("CCD_TIPO")
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("CCD_ESTADO4").Value = mCCD.CCD_ESTADO  'mItem("CCD_ESTADO")
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("CCD_CANTIDAD4").Value = mCCD.CCD_CANTIDAD  'mItem("CCD_CANTIDAD")
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("HOR_ID4").Value = mCCD.HOR_ID  'mItem("HOR_ID")
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("PUE_ID4").Value = mCCD.PUE_ID  'mItem("PUE_ID")
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("CCD_HORNO4").Value = mCCD.CCD_HORNO  'mItem("CCD_HORNO")
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("CCD_PUERTA4").Value = mCCD.CCD_PUERTA  'mItem("CCD_PUERTA")
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("LADRILLO4").Value = mCCD.LadrilloMalecon.Ladrillo.Articulos.ART_DESCRIPCION
                    dgvDetalle4.Rows(dgvDetalle4.Rows.Count - 2).Cells("PRO_ID4").Value = mCCD.ControlCarga.PRO_ID
                End If
            Next
        End If
    End Sub

    Private Sub cboHorno_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHorno.SelectedValueChanged
        If cboHorno.DataSource IsNot Nothing Then CargarPuertaHorno(cboHorno.SelectedValue) : mHorno = BCHorno.HornoGetById(cboHorno.SelectedValue)
    End Sub

    Private Sub txtProduccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProduccion.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Produccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProduccion.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Pro_Id
            txtProduccion.Text = frm.dgvLista.CurrentRow.Cells(0).Value & " " & frm.dgvLista.CurrentRow.Cells("ART_DESCRIPCION").Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtOperador1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOperador1.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtOperador1.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            txtOperador1.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtOperador2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOperador2.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtOperador2.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            txtOperador2.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargarCaCoDeDetalle(dtpFecha.Value, cboHorno.SelectedValue)
        BuscarFecha = dtpFecha.Value.Date
        ColorFila()
        btnAgregarCarga.Enabled = True
        btnAgregarQuema.Enabled = True
        btnAgregarDescarga.Enabled = True
    End Sub

    Private Sub btnAgregarCarga_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarCarga.Click
        If txtProduccion.Tag Is Nothing Then MessageBox.Show("Debe agregar una Produccion.") : Exit Sub
        If numMI.Value = 0 Or numMF.Value = 0 Then MessageBox.Show("Los Numeros de Malecon no pueden ser cero.") : Exit Sub
        If txtOperador1.Tag Is Nothing Then MessageBox.Show("Debe agregar un Operador.") : Exit Sub
        If cboTipo.SelectedIndex = -1 Then MessageBox.Show("Debe agregar el Tipo de Carga.") : Exit Sub

        Estado = "CA"
        If numMI.Value > numMF.Value Then
            For cont As Integer = 1 To numMF.Value
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                mLMA = BCLadrilloMalecon.LadrilloMaleconGetById2(cboHorno.SelectedValue, cont, txtProduccion.Tag)
                If mLMA IsNot Nothing Then
                    mLMA.MaleconPuerta = BCLadrilloMalecon.MaleconPuertaGetById(mLMA.MAL_ID)
                    mLMA.MaleconPuerta.PuertaHorno = BCMaleconPuerta.PuertaHornoGetById(mLMA.MaleconPuerta.PUE_ID)

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_ID").Value = Nothing
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAR_ID").Value = Nothing
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("COQ_ID").Value = Nothing
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DES_ID").Value = Nothing
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("LMA_ID").Value = mLMA.LMA_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_NRO_MALE").Value = String.Format("{0:000}", cont)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_FECHA").Value = dtpFecha.Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_TIPO").Value = cboTipo.Text
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_ESTADO").Value = "CA"
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_CANTIDAD").Value = IIf(numCantMalec.Value = 0, CInt(mLMA.LMA_CANTIDAD), CInt(numCantMalec.Value))
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("HOR_ID").Value = cboHorno.SelectedValue
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PUE_ID").Value = mLMA.MaleconPuerta.PUE_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_HORNO").Value = cboHorno.Text
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_PUERTA").Value = mLMA.MaleconPuerta.PuertaHorno.PUE_DESCRIPCION
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("LADRILLO").Value = mLMA.Ladrillo.Articulos.ART_DESCRIPCION
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PRO_ID").Value = txtProduccion.Tag
                End If

            Next
            For cont2 As Integer = numMI.Value To mHorno.PuertaHorno(mHorno.PuertaHorno.Count - 1).MaleconPuerta.Count
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                mLMA = BCLadrilloMalecon.LadrilloMaleconGetById2(cboHorno.SelectedValue, cont2, txtProduccion.Tag)
                If mLMA IsNot Nothing Then
                    mLMA.MaleconPuerta = BCLadrilloMalecon.MaleconPuertaGetById(mLMA.MAL_ID)
                    mLMA.MaleconPuerta.PuertaHorno = BCMaleconPuerta.PuertaHornoGetById(mLMA.MaleconPuerta.PUE_ID)

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_ID").Value = DBNull.Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAR_ID").Value = DBNull.Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("COQ_ID").Value = DBNull.Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DES_ID").Value = DBNull.Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("LMA_ID").Value = mLMA.LMA_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_NRO_MALE").Value = String.Format("{0:000}", cont2)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_FECHA").Value = dtpFecha.Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_TIPO").Value = cboTipo.Text
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_ESTADO").Value = "CA"
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_CANTIDAD").Value = IIf(numCantMalec.Value = 0, CInt(mLMA.LMA_CANTIDAD), CInt(numCantMalec.Value))
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("HOR_ID").Value = cboHorno.SelectedValue
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PUE_ID").Value = mLMA.MaleconPuerta.PUE_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_HORNO").Value = cboHorno.Text
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_PUERTA").Value = mLMA.MaleconPuerta.PuertaHorno.PUE_DESCRIPCION
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("LADRILLO").Value = mLMA.Ladrillo.Articulos.ART_DESCRIPCION
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PRO_ID").Value = txtProduccion.Tag
                End If

            Next
        Else
            For cont3 As Integer = numMI.Value To numMF.Value
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                mLMA = BCLadrilloMalecon.LadrilloMaleconGetById2(cboHorno.SelectedValue, cont3, txtProduccion.Tag)
                If mLMA IsNot Nothing Then
                    mLMA.MaleconPuerta = BCLadrilloMalecon.MaleconPuertaGetById(mLMA.MAL_ID)
                    mLMA.MaleconPuerta.PuertaHorno = BCMaleconPuerta.PuertaHornoGetById(mLMA.MaleconPuerta.PUE_ID)

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_ID").Value = DBNull.Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAR_ID").Value = DBNull.Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("COQ_ID").Value = DBNull.Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DES_ID").Value = DBNull.Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("LMA_ID").Value = mLMA.LMA_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_NRO_MALE").Value = String.Format("{0:000}", cont3)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_FECHA").Value = dtpFecha.Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_TIPO").Value = cboTipo.Text
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_ESTADO").Value = "CA"
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_CANTIDAD").Value = IIf(numCantMalec.Value = 0, CInt(mLMA.LMA_CANTIDAD), CInt(numCantMalec.Value))
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("HOR_ID").Value = cboHorno.SelectedValue
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PUE_ID").Value = mLMA.MaleconPuerta.PUE_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_HORNO").Value = cboHorno.Text
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CCD_PUERTA").Value = mLMA.MaleconPuerta.PuertaHorno.PUE_DESCRIPCION
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("LADRILLO").Value = mLMA.Ladrillo.Articulos.ART_DESCRIPCION
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PRO_ID").Value = txtProduccion.Tag
                End If
            Next
        End If

        For Each mFila As DataGridViewRow In dgvDetalle.Rows
            If mFila.Cells("CCD_PUERTA").Value = IIf(cboHorno.SelectedValue = "25", "2", "6") Then
                dgvDetalle2.Rows.Insert(0, {mFila.Cells(0).Value, mFila.Cells(1).Value, mFila.Cells(2).Value, mFila.Cells(3).Value, mFila.Cells(4).Value, mFila.Cells(5).Value, mFila.Cells(6).Value, mFila.Cells(7).Value, mFila.Cells(8).Value, mFila.Cells(9).Value, mFila.Cells(10).Value, mFila.Cells(11).Value, mFila.Cells(12).Value, mFila.Cells(13).Value, mFila.Cells(14).Value, mFila.Cells(15).Value})
                mFila.Selected = True
            ElseIf mFila.Cells("CCD_PUERTA").Value = IIf(cboHorno.SelectedValue = "25", "3", "7") Then
                dgvDetalle3.Rows.Insert(0, {mFila.Cells(0).Value, mFila.Cells(1).Value, mFila.Cells(2).Value, mFila.Cells(3).Value, mFila.Cells(4).Value, mFila.Cells(5).Value, mFila.Cells(6).Value, mFila.Cells(7).Value, mFila.Cells(8).Value, mFila.Cells(9).Value, mFila.Cells(10).Value, mFila.Cells(11).Value, mFila.Cells(12).Value, mFila.Cells(13).Value, mFila.Cells(14).Value, mFila.Cells(15).Value})
                mFila.Selected = True
            ElseIf mFila.Cells("CCD_PUERTA").Value = IIf(cboHorno.SelectedValue = "25", "4", "8") Then
                dgvDetalle4.Rows.Insert(0, {mFila.Cells(0).Value, mFila.Cells(1).Value, mFila.Cells(2).Value, mFila.Cells(3).Value, mFila.Cells(4).Value, mFila.Cells(5).Value, mFila.Cells(6).Value, mFila.Cells(7).Value, mFila.Cells(8).Value, mFila.Cells(9).Value, mFila.Cells(10).Value, mFila.Cells(11).Value, mFila.Cells(12).Value, mFila.Cells(13).Value, mFila.Cells(14).Value, mFila.Cells(15).Value})
                mFila.Selected = True
            End If
        Next

        For cont As Integer = dgvDetalle.Rows.Count - 1 To 0 Step -1
            If dgvDetalle.Rows(cont).Selected Then
                dgvDetalle.Rows.RemoveAt(dgvDetalle.Rows(cont).Index)
            End If
        Next

        ColorFila()
        btnAgregarCarga.Enabled = False
        btnAgregarQuema.Enabled = False
        btnAgregarDescarga.Enabled = False
    End Sub

    Sub ColorFila()
        For Each mFila As DataGridViewRow In dgvDetalle.Rows
            If mFila.Cells("CCD_ESTADO").Value = "CA" Then mFila.DefaultCellStyle.BackColor = IIf(mFila.Cells("CAR_ID").Value Is DBNull.Value, Drawing.Color.LightGreen, Drawing.Color.Green)
            If mFila.Cells("CCD_ESTADO").Value = "CO" Then mFila.DefaultCellStyle.BackColor = Drawing.Color.Red
            If mFila.Cells("CCD_ESTADO").Value = "DE" Then mFila.DefaultCellStyle.BackColor = Drawing.Color.Yellow
        Next
        For Each mFila As DataGridViewRow In dgvDetalle2.Rows
            If mFila.Cells("CCD_ESTADO2").Value = "CA" Then mFila.DefaultCellStyle.BackColor = IIf(mFila.Cells("CAR_ID2").Value Is DBNull.Value, Drawing.Color.LightGreen, Drawing.Color.Green)
            If mFila.Cells("CCD_ESTADO2").Value = "CO" Then mFila.DefaultCellStyle.BackColor = Drawing.Color.Red
            If mFila.Cells("CCD_ESTADO2").Value = "DE" Then mFila.DefaultCellStyle.BackColor = Drawing.Color.Yellow
        Next
        For Each mFila As DataGridViewRow In dgvDetalle3.Rows
            If mFila.Cells("CCD_ESTADO3").Value = "CA" Then mFila.DefaultCellStyle.BackColor = IIf(mFila.Cells("CAR_ID3").Value Is DBNull.Value, Drawing.Color.LightGreen, Drawing.Color.Green)
            If mFila.Cells("CCD_ESTADO3").Value = "CO" Then mFila.DefaultCellStyle.BackColor = Drawing.Color.Red
            If mFila.Cells("CCD_ESTADO3").Value = "DE" Then mFila.DefaultCellStyle.BackColor = Drawing.Color.Yellow
        Next
        For Each mFila As DataGridViewRow In dgvDetalle4.Rows
            If mFila.Cells("CCD_ESTADO4").Value = "CA" Then mFila.DefaultCellStyle.BackColor = IIf(mFila.Cells("CAR_ID4").Value Is DBNull.Value, Drawing.Color.LightGreen, Drawing.Color.Green)
            If mFila.Cells("CCD_ESTADO4").Value = "CO" Then mFila.DefaultCellStyle.BackColor = Drawing.Color.Red
            If mFila.Cells("CCD_ESTADO4").Value = "DE" Then mFila.DefaultCellStyle.BackColor = Drawing.Color.Yellow
        Next
    End Sub


    Private Sub btnAgregarQuema_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarQuema.Click
        If numMI.Value = 0 Or numMF.Value = 0 Then MessageBox.Show("Los Numeros de Malecon no pueden ser cero.") : Exit Sub
        If txtOperador1.Tag Is Nothing Then MessageBox.Show("Debe agregar un Operador.") : Exit Sub
        If txtOperador2.Tag Is Nothing Then MessageBox.Show("Debe agregar un Responsable.") : Exit Sub

        'If numMI.Value > numMF.Value Then
        '    For cont As Integer = 1 To numMF.Value
        '        Dim mRow = From mR As DataGridViewRow In dgvDetalle.Rows Where mR.Cells("CCD_NRO_MALE").Value = cont Select mR
        '        For Each mItem In mRow.ToList
        '            If mItem.Cells("CCD_ESTADO").Value = "DE" Or mItem.Cells("CCD_ESTADO").Value = "CO" Then MessageBox.Show("No puede quemar, si hay malecones en estado: Descarga o ya Quemados") : Exit Sub
        '        Next
        '        mRow = From mR As DataGridViewRow In dgvDetalle2.Rows Where mR.Cells("CCD_NRO_MALE2").Value = cont Select mR
        '        For Each mItem In mRow.ToList
        '            If mItem.Cells("CCD_ESTADO2").Value = "DE" Or mItem.Cells("CCD_ESTADO2").Value = "CO" Then MessageBox.Show("No puede quemar, si hay malecones en estado: Descarga o ya Quemados") : Exit Sub
        '        Next
        '        mRow = From mR As DataGridViewRow In dgvDetalle3.Rows Where mR.Cells("CCD_NRO_MALE3").Value = cont Select mR
        '        For Each mItem In mRow.ToList
        '            If mItem.Cells("CCD_ESTADO3").Value = "DE" Or mItem.Cells("CCD_ESTADO3").Value = "CO" Then MessageBox.Show("No puede quemar, si hay malecones en estado: Descarga o ya Quemados") : Exit Sub
        '        Next
        '        mRow = From mR As DataGridViewRow In dgvDetalle4.Rows Where mR.Cells("CCD_NRO_MALE4").Value = cont Select mR
        '        For Each mItem In mRow.ToList
        '            If mItem.Cells("CCD_ESTADO4").Value = "DE" Or mItem.Cells("CCD_ESTADO4").Value = "CO" Then MessageBox.Show("No puede quemar, si hay malecones en estado: Descarga o ya Quemados") : Exit Sub
        '        Next
        '    Next
        '    For cont2 As Integer = numMI.Value To mHorno.PuertaHorno(mHorno.PuertaHorno.Count - 1).MaleconPuerta(mHorno.PuertaHorno(mHorno.PuertaHorno.Count - 1).MaleconPuerta.Count - 1).MAL_DES_CORTA
        '        Dim mRow = From mR As DataGridViewRow In dgvDetalle.Rows Where mR.Cells("CCD_NRO_MALE").Value = cont2 Select mR
        '        For Each mItem In mRow.ToList
        '            If mItem.Cells("CCD_ESTADO").Value = "DE" Or mItem.Cells("CCD_ESTADO").Value = "CO" Then MessageBox.Show("No puede quemar, si hay malecones en estado: Descarga o ya Quemados") : Exit Sub
        '        Next
        '        mRow = From mR As DataGridViewRow In dgvDetalle2.Rows Where mR.Cells("CCD_NRO_MALE2").Value = cont2 Select mR
        '        For Each mItem In mRow.ToList
        '            If mItem.Cells("CCD_ESTADO2").Value = "DE" Or mItem.Cells("CCD_ESTADO2").Value = "CO" Then MessageBox.Show("No puede quemar, si hay malecones en estado: Descarga o ya Quemados") : Exit Sub
        '        Next
        '        mRow = From mR As DataGridViewRow In dgvDetalle3.Rows Where mR.Cells("CCD_NRO_MALE3").Value = cont2 Select mR
        '        For Each mItem In mRow.ToList
        '            If mItem.Cells("CCD_ESTADO3").Value = "DE" Or mItem.Cells("CCD_ESTADO3").Value = "CO" Then MessageBox.Show("No puede quemar, si hay malecones en estado: Descarga o ya Quemados") : Exit Sub
        '        Next
        '        mRow = From mR As DataGridViewRow In dgvDetalle4.Rows Where mR.Cells("CCD_NRO_MALE4").Value = cont2 Select mR
        '        For Each mItem In mRow.ToList
        '            If mItem.Cells("CCD_ESTADO4").Value = "DE" Or mItem.Cells("CCD_ESTADO4").Value = "CO" Then MessageBox.Show("No puede quemar, si hay malecones en estado: Descarga o ya Quemados") : Exit Sub
        '        Next
        '    Next
        'Else
        '    For cont3 As Integer = numMI.Value To numMF.Value
        '        Dim mRow = From mR As DataGridViewRow In dgvDetalle.Rows Where mR.Cells("CCD_NRO_MALE").Value = cont3 Select mR
        '        For Each mItem In mRow.ToList
        '            If mItem.Cells("CCD_ESTADO").Value = "DE" Or mItem.Cells("CCD_ESTADO").Value = "CO" Then MessageBox.Show("No puede quemar, si hay malecones en estado: Descarga o ya Quemados") : Exit Sub
        '        Next
        '        mRow = From mR As DataGridViewRow In dgvDetalle2.Rows Where mR.Cells("CCD_NRO_MALE2").Value = cont3 Select mR
        '        For Each mItem In mRow.ToList
        '            If mItem.Cells("CCD_ESTADO2").Value = "DE" Or mItem.Cells("CCD_ESTADO2").Value = "CO" Then MessageBox.Show("No puede quemar, si hay malecones en estado: Descarga o ya Quemados") : Exit Sub
        '        Next
        '        mRow = From mR As DataGridViewRow In dgvDetalle3.Rows Where mR.Cells("CCD_NRO_MALE3").Value = cont3 Select mR
        '        For Each mItem In mRow.ToList
        '            If mItem.Cells("CCD_ESTADO3").Value = "DE" Or mItem.Cells("CCD_ESTADO3").Value = "CO" Then MessageBox.Show("No puede quemar, si hay malecones en estado: Descarga o ya Quemados") : Exit Sub
        '        Next
        '        mRow = From mR As DataGridViewRow In dgvDetalle4.Rows Where mR.Cells("CCD_NRO_MALE4").Value = cont3 Select mR
        '        For Each mItem In mRow.ToList
        '            If mItem.Cells("CCD_ESTADO4").Value = "DE" Or mItem.Cells("CCD_ESTADO4").Value = "CO" Then MessageBox.Show("No puede quemar, si hay malecones en estado: Descarga o ya Quemados") : Exit Sub
        '        Next
        '    Next
        'End If

        Estado = "CO"
        If numMI.Value > numMF.Value Then
            For cont As Integer = 1 To numMF.Value
                Dim mRow = From mR As DataGridViewRow In dgvDetalle.Rows Where mR.Cells("CCD_NRO_MALE").Value = cont And mR.Cells("CCD_ESTADO").Value = "CA" Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO").Value = "CO"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Red
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle2.Rows Where mR.Cells("CCD_NRO_MALE2").Value = cont And mR.Cells("CCD_ESTADO2").Value = "CA" Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO2").Value = "CO"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Red
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle3.Rows Where mR.Cells("CCD_NRO_MALE3").Value = cont And mR.Cells("CCD_ESTADO3").Value = "CA" Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO3").Value = "CO"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Red
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle4.Rows Where mR.Cells("CCD_NRO_MALE4").Value = cont And mR.Cells("CCD_ESTADO4").Value = "CA" Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO4").Value = "CO"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Red
                Next
            Next
            For cont2 As Integer = numMI.Value To mHorno.PuertaHorno(mHorno.PuertaHorno.Count - 1).MaleconPuerta(mHorno.PuertaHorno(mHorno.PuertaHorno.Count - 1).MaleconPuerta.Count - 1).MAL_DES_CORTA
                Dim mRow = From mR As DataGridViewRow In dgvDetalle.Rows Where mR.Cells("CCD_NRO_MALE").Value = cont2 And mR.Cells("CCD_ESTADO").Value = "CA" Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO").Value = "CO"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Red
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle2.Rows Where mR.Cells("CCD_NRO_MALE2").Value = cont2 And mR.Cells("CCD_ESTADO2").Value = "CA" Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO2").Value = "CO"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Red
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle3.Rows Where mR.Cells("CCD_NRO_MALE3").Value = cont2 And mR.Cells("CCD_ESTADO3").Value = "CA" Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO3").Value = "CO"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Red
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle4.Rows Where mR.Cells("CCD_NRO_MALE4").Value = cont2 And mR.Cells("CCD_ESTADO4").Value = "CA" Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO4").Value = "CO"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Red
                Next
            Next
        Else
            For cont3 As Integer = numMI.Value To numMF.Value
                Dim mRow = From mR As DataGridViewRow In dgvDetalle.Rows Where mR.Cells("CCD_NRO_MALE").Value = cont3 And mR.Cells("CCD_ESTADO").Value = "CA" Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO").Value = "CO"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Red
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle2.Rows Where mR.Cells("CCD_NRO_MALE2").Value = cont3 And mR.Cells("CCD_ESTADO2").Value = "CA" Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO2").Value = "CO"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Red
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle3.Rows Where mR.Cells("CCD_NRO_MALE3").Value = cont3 And mR.Cells("CCD_ESTADO3").Value = "CA" Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO3").Value = "CO"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Red
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle4.Rows Where mR.Cells("CCD_NRO_MALE4").Value = cont3 And mR.Cells("CCD_ESTADO4").Value = "CA" Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO4").Value = "CO"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Red
                Next
            Next
        End If
        btnAgregarCarga.Enabled = False
        btnAgregarQuema.Enabled = False
        btnAgregarDescarga.Enabled = False
    End Sub

    Private Sub btnAgregarDescarga_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarDescarga.Click
        If txtOperador1.Tag Is Nothing Then MessageBox.Show("Debe agregar un Operador.") : Exit Sub

        cboPuerta_SelectedValueChanged(Nothing, Nothing)
        If numMI.Value > numMF.Value Then
            For cont As Integer = 1 To numMF.Value
                Dim mRow = From mR As DataGridViewRow In dgvDetalle.Rows Where mR.Cells("CCD_NRO_MALE").Value = cont Select mR
                For Each mItem In mRow.ToList
                    If mItem.Cells("CCD_ESTADO").Value = "CA" Or mItem.Cells("CCD_ESTADO").Value = "DE" Then MessageBox.Show("No puede descargar, todos los malecones deben de estar quemados.") : Exit Sub
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle2.Rows Where mR.Cells("CCD_NRO_MALE2").Value = cont Select mR
                For Each mItem In mRow.ToList
                    If mItem.Cells("CCD_ESTADO2").Value = "CA" Or mItem.Cells("CCD_ESTADO2").Value = "DE" Then MessageBox.Show("No puede descargar, todos los malecones deben de estar quemados.") : Exit Sub
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle3.Rows Where mR.Cells("CCD_NRO_MALE3").Value = cont Select mR
                For Each mItem In mRow.ToList
                    If mItem.Cells("CCD_ESTADO3").Value = "CA" Or mItem.Cells("CCD_ESTADO3").Value = "DE" Then MessageBox.Show("No puede descargar, todos los malecones deben de estar quemados.") : Exit Sub
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle4.Rows Where mR.Cells("CCD_NRO_MALE4").Value = cont Select mR
                For Each mItem In mRow.ToList
                    If mItem.Cells("CCD_ESTADO4").Value = "CA" Or mItem.Cells("CCD_ESTADO4").Value = "DE" Then MessageBox.Show("No puede descargar, todos los malecones deben de estar quemados.") : Exit Sub
                Next
            Next
            For cont2 As Integer = numMI.Value To mHorno.PuertaHorno(mHorno.PuertaHorno.Count - 1).MaleconPuerta.Count
                Dim mRow = From mR As DataGridViewRow In dgvDetalle.Rows Where mR.Cells("CCD_NRO_MALE").Value = cont2 Select mR
                For Each mItem In mRow.ToList
                    If mItem.Cells("CCD_ESTADO").Value = "CA" Or mItem.Cells("CCD_ESTADO").Value = "DE" Then MessageBox.Show("No puede descargar, todos los malecones deben de estar quemados.") : Exit Sub
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle2.Rows Where mR.Cells("CCD_NRO_MALE2").Value = cont2 Select mR
                For Each mItem In mRow.ToList
                    If mItem.Cells("CCD_ESTADO2").Value = "CA" Or mItem.Cells("CCD_ESTADO2").Value = "DE" Then MessageBox.Show("No puede descargar, todos los malecones deben de estar quemados.") : Exit Sub
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle3.Rows Where mR.Cells("CCD_NRO_MALE3").Value = cont2 Select mR
                For Each mItem In mRow.ToList
                    If mItem.Cells("CCD_ESTADO3").Value = "CA" Or mItem.Cells("CCD_ESTADO3").Value = "DE" Then MessageBox.Show("No puede descargar, todos los malecones deben de estar quemados.") : Exit Sub
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle4.Rows Where mR.Cells("CCD_NRO_MALE4").Value = cont2 Select mR
                For Each mItem In mRow.ToList
                    If mItem.Cells("CCD_ESTADO4").Value = "CA" Or mItem.Cells("CCD_ESTADO4").Value = "DE" Then MessageBox.Show("No puede descargar, todos los malecones deben de estar quemados.") : Exit Sub
                Next
            Next
        Else
            For cont3 As Integer = numMI.Value To numMF.Value
                Dim mRow = From mR As DataGridViewRow In dgvDetalle.Rows Where mR.Cells("CCD_NRO_MALE").Value = cont3 Select mR
                For Each mItem In mRow.ToList
                    If mItem.Cells("CCD_ESTADO").Value = "CA" Or mItem.Cells("CCD_ESTADO").Value = "DE" Then MessageBox.Show("No puede descargar, todos los malecones deben de estar quemados.") : Exit Sub
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle2.Rows Where mR.Cells("CCD_NRO_MALE2").Value = cont3 Select mR
                For Each mItem In mRow.ToList
                    If mItem.Cells("CCD_ESTADO2").Value = "CA" Or mItem.Cells("CCD_ESTADO2").Value = "DE" Then MessageBox.Show("No puede descargar, todos los malecones deben de estar quemados.") : Exit Sub
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle3.Rows Where mR.Cells("CCD_NRO_MALE3").Value = cont3 Select mR
                For Each mItem In mRow.ToList
                    If mItem.Cells("CCD_ESTADO3").Value = "CA" Or mItem.Cells("CCD_ESTADO3").Value = "DE" Then MessageBox.Show("No puede descargar, todos los malecones deben de estar quemados.") : Exit Sub
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle4.Rows Where mR.Cells("CCD_NRO_MALE4").Value = cont3 Select mR
                For Each mItem In mRow.ToList
                    If mItem.Cells("CCD_ESTADO4").Value = "CA" Or mItem.Cells("CCD_ESTADO4").Value = "DE" Then MessageBox.Show("No puede descargar, todos los malecones deben de estar quemados.") : Exit Sub
                Next
            Next
        End If

        Estado = "DE"
        If numMI.Value > numMF.Value Then
            For cont As Integer = 1 To numMF.Value
                Dim mRow = From mR As DataGridViewRow In dgvDetalle.Rows Where mR.Cells("CCD_NRO_MALE").Value = cont Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO").Value = "DE"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle2.Rows Where mR.Cells("CCD_NRO_MALE2").Value = cont Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO2").Value = "DE"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle3.Rows Where mR.Cells("CCD_NRO_MALE3").Value = cont Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO3").Value = "DE"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle4.Rows Where mR.Cells("CCD_NRO_MALE4").Value = cont Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO4").Value = "DE"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                Next
            Next
            For cont2 As Integer = numMI.Value To mHorno.PuertaHorno(mHorno.PuertaHorno.Count - 1).MaleconPuerta.Count
                Dim mRow = From mR As DataGridViewRow In dgvDetalle.Rows Where mR.Cells("CCD_NRO_MALE").Value = cont2 Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO").Value = "DE"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle2.Rows Where mR.Cells("CCD_NRO_MALE2").Value = cont2 Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO2").Value = "DE"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle3.Rows Where mR.Cells("CCD_NRO_MALE3").Value = cont2 Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO3").Value = "DE"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle4.Rows Where mR.Cells("CCD_NRO_MALE4").Value = cont2 Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO4").Value = "DE"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                Next
            Next
        Else
            For cont3 As Integer = numMI.Value To numMF.Value
                Dim mRow = From mR As DataGridViewRow In dgvDetalle.Rows Where mR.Cells("CCD_NRO_MALE").Value = cont3 Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO").Value = "DE"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle2.Rows Where mR.Cells("CCD_NRO_MALE2").Value = cont3 Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO2").Value = "DE"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle3.Rows Where mR.Cells("CCD_NRO_MALE3").Value = cont3 Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO3").Value = "DE"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                Next
                mRow = From mR As DataGridViewRow In dgvDetalle4.Rows Where mR.Cells("CCD_NRO_MALE4").Value = cont3 Select mR
                For Each mItem In mRow.ToList
                    mItem.Cells("CCD_ESTADO4").Value = "DE"
                    mItem.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                Next
            Next
        End If
        btnAgregarCarga.Enabled = False
        btnAgregarQuema.Enabled = False
        btnAgregarDescarga.Enabled = False
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------

        dgvDetalle.EndEdit()
        dgvDetalle2.EndEdit()
        dgvDetalle3.EndEdit()
        dgvDetalle4.EndEdit()
        Dim mCCD As New CaCoDe_Detalle

        ''''''''''''''''''If Not BuscarFecha = dtpFecha.Value.Date Then 'Es un nuevo dia
        colCCD.Clear()
        For Each mR As DataGridViewRow In dgvDetalle.Rows
            If CInt(mR.Cells("CCD_CANTIDAD").Value) > 0 Then
                mCCD = New CaCoDe_Detalle
                With mCCD
                    .CCD_ID = Nothing
                    If mR.Cells("CAR_ID").Value Is Nothing Or mR.Cells("CAR_ID").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID").Value)
                    If mR.Cells("COQ_ID").Value Is Nothing Or mR.Cells("COQ_ID").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID").Value)
                    If mR.Cells("DES_ID").Value Is Nothing Or mR.Cells("DES_ID").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID").Value)
                    .LMA_ID = CInt(mR.Cells("LMA_ID").Value)
                    .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE").Value
                    .CCD_FECHA = dtpFecha.Value.Date
                    .CCD_TIPO = mR.Cells("CCD_TIPO").Value
                    .CCD_ESTADO = mR.Cells("CCD_ESTADO").Value
                    .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD").Value)
                    .HOR_ID = CInt(mR.Cells("HOR_ID").Value)
                    .PUE_ID = CInt(mR.Cells("PUE_ID").Value)
                    .CCD_HORNO = mR.Cells("CCD_HORNO").Value
                    .CCD_PUERTA = mR.Cells("CCD_PUERTA").Value
                    .CCD_HI = mR.Cells("CCD_HI").Value
                    .CCD_HF = mR.Cells("CCD_HF").Value
                    .ENO_ID_ORIDES = mR.Cells("ENO_ID_ORIDES").Value
                    .CCD_ORIGEN_DESTINO = mR.Cells("CCD_ORIGEN_DESTINO").Value
                    .UNT_ID = mR.Cells("UNT_ID").Tag
                    .PER_ID_EMPRESA = mR.Cells("PER_ID_EMPRESA").Value
                    .MarkAsAdded()
                End With
                colCCD.Add(mCCD) 'Agrego a la coleccion
            End If
        Next
        For Each mR As DataGridViewRow In dgvDetalle2.Rows
            If CInt(mR.Cells("CCD_CANTIDAD2").Value) > 0 Then
                mCCD = New CaCoDe_Detalle
                With mCCD
                    .CCD_ID = Nothing
                    If mR.Cells("CAR_ID2").Value Is Nothing Or mR.Cells("CAR_ID2").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID2").Value)
                    If mR.Cells("COQ_ID2").Value Is Nothing Or mR.Cells("COQ_ID2").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID2").Value)
                    If mR.Cells("DES_ID2").Value Is Nothing Or mR.Cells("DES_ID2").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID2").Value)
                    .LMA_ID = CInt(mR.Cells("LMA_ID2").Value)
                    .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE2").Value
                    .CCD_FECHA = dtpFecha.Value.Date
                    .CCD_TIPO = mR.Cells("CCD_TIPO2").Value
                    .CCD_ESTADO = mR.Cells("CCD_ESTADO2").Value
                    .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD2").Value)
                    .HOR_ID = CInt(mR.Cells("HOR_ID2").Value)
                    .PUE_ID = CInt(mR.Cells("PUE_ID2").Value)
                    .CCD_HORNO = mR.Cells("CCD_HORNO2").Value
                    .CCD_PUERTA = mR.Cells("CCD_PUERTA2").Value
                    .CCD_HI = mR.Cells("CCD_HI2").Value
                    .CCD_HF = mR.Cells("CCD_HF2").Value
                    .ENO_ID_ORIDES = mR.Cells("ENO_ID_ORIDES2").Value
                    .CCD_ORIGEN_DESTINO = mR.Cells("CCD_ORIGEN_DESTINO2").Value
                    .UNT_ID = mR.Cells("UNT_ID2").Tag
                    .PER_ID_EMPRESA = mR.Cells("PER_ID_EMPRESA2").Value
                    .MarkAsAdded()
                End With
                colCCD.Add(mCCD) 'Agrego a la coleccion
            End If
        Next
        For Each mR As DataGridViewRow In dgvDetalle3.Rows
            If CInt(mR.Cells("CCD_CANTIDAD3").Value) > 0 Then
                mCCD = New CaCoDe_Detalle
                With mCCD
                    .CCD_ID = Nothing
                    If mR.Cells("CAR_ID3").Value Is Nothing Or mR.Cells("CAR_ID3").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID3").Value)
                    If mR.Cells("COQ_ID3").Value Is Nothing Or mR.Cells("COQ_ID3").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID3").Value)
                    If mR.Cells("DES_ID3").Value Is Nothing Or mR.Cells("DES_ID3").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID3").Value)
                    .LMA_ID = CInt(mR.Cells("LMA_ID3").Value)
                    .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE3").Value
                    .CCD_FECHA = dtpFecha.Value.Date
                    .CCD_TIPO = mR.Cells("CCD_TIPO3").Value
                    .CCD_ESTADO = mR.Cells("CCD_ESTADO3").Value
                    .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD3").Value)
                    .HOR_ID = CInt(mR.Cells("HOR_ID3").Value)
                    .PUE_ID = CInt(mR.Cells("PUE_ID3").Value)
                    .CCD_HORNO = mR.Cells("CCD_HORNO3").Value
                    .CCD_PUERTA = mR.Cells("CCD_PUERTA3").Value
                    .CCD_HI = mR.Cells("CCD_HI3").Value
                    .CCD_HF = mR.Cells("CCD_HF3").Value
                    .ENO_ID_ORIDES = mR.Cells("ENO_ID_ORIDES3").Value
                    .CCD_ORIGEN_DESTINO = mR.Cells("CCD_ORIGEN_DESTINO3").Value
                    .UNT_ID = mR.Cells("UNT_ID3").Tag
                    .PER_ID_EMPRESA = mR.Cells("PER_ID_EMPRESA3").Value
                    .MarkAsAdded()
                End With
                colCCD.Add(mCCD) 'Agrego a la coleccion
            End If
        Next
        For Each mR As DataGridViewRow In dgvDetalle4.Rows
            If CInt(mR.Cells("CCD_CANTIDAD4").Value) > 0 Then
                mCCD = New CaCoDe_Detalle
                With mCCD
                    .CCD_ID = Nothing
                    If mR.Cells("CAR_ID4").Value Is Nothing Or mR.Cells("CAR_ID4").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID4").Value)
                    If mR.Cells("COQ_ID4").Value Is Nothing Or mR.Cells("COQ_ID4").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID4").Value)
                    If mR.Cells("DES_ID4").Value Is Nothing Or mR.Cells("DES_ID4").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID4").Value)
                    .LMA_ID = CInt(mR.Cells("LMA_ID4").Value)
                    .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE4").Value
                    .CCD_FECHA = dtpFecha.Value.Date
                    .CCD_TIPO = mR.Cells("CCD_TIPO4").Value
                    .CCD_ESTADO = mR.Cells("CCD_ESTADO4").Value
                    .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD4").Value)
                    .HOR_ID = CInt(mR.Cells("HOR_ID4").Value)
                    .PUE_ID = CInt(mR.Cells("PUE_ID4").Value)
                    .CCD_HORNO = mR.Cells("CCD_HORNO4").Value
                    .CCD_PUERTA = mR.Cells("CCD_PUERTA4").Value
                    .CCD_HI = mR.Cells("CCD_HI4").Value
                    .CCD_HF = mR.Cells("CCD_HF4").Value
                    .ENO_ID_ORIDES = mR.Cells("ENO_ID_ORIDES4").Value
                    .CCD_ORIGEN_DESTINO = mR.Cells("CCD_ORIGEN_DESTINO4").Value
                    .UNT_ID = mR.Cells("UNT_ID4").Tag
                    .PER_ID_EMPRESA = mR.Cells("PER_ID_EMPRESA4").Value
                    .MarkAsAdded()
                End With
                colCCD.Add(mCCD) 'Agrego a la coleccion
            End If
        Next

        'Else 'No es nuevo el dia 'LO COMENTO PORQUE SIEMPRE DEBE SER NUEVO PARA CUANDO SE HAGA MAL UN DIA ENTONCES SE DEBE DE reemplazar, TODO ESTO HASTA END IF

        '    For Each mR As DataGridViewRow In dgvDetalle.Rows
        '        If Not mR.Cells("CCD_ID").Tag Is Nothing Then 'Ya existe
        '            With CType(mR.Cells("CCD_ID").Tag, CaCoDe_Detalle)
        '                .CCD_ID = CInt(mR.Cells("CCD_ID").Value)
        '                If mR.Cells("CAR_ID").Value Is Nothing Or mR.Cells("CAR_ID").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID").Value)
        '                If mR.Cells("COQ_ID").Value Is Nothing Or mR.Cells("COQ_ID").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID").Value)
        '                If mR.Cells("DES_ID").Value Is Nothing Or mR.Cells("DES_ID").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID").Value)
        '                .LMA_ID = CInt(mR.Cells("LMA_ID").Value)
        '                .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE").Value
        '                .CCD_FECHA = dtpFecha.Value.Date
        '                .CCD_TIPO = mR.Cells("CCD_TIPO").Value
        '                .CCD_ESTADO = mR.Cells("CCD_ESTADO").Value
        '                .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD").Value)
        '                .HOR_ID = CInt(mR.Cells("HOR_ID").Value)
        '                .PUE_ID = CInt(mR.Cells("PUE_ID").Value)
        '                .CCD_HORNO = mR.Cells("CCD_HORNO").Value
        '                .CCD_PUERTA = mR.Cells("CCD_PUERTA").Value
        '                .MarkAsModified()
        '            End With
        '        ElseIf Not mR.Cells("CCD_Cantidad").Value Is Nothing Then 'No existe
        '            mCCD = New CaCoDe_Detalle
        '            With mCCD
        '                .CCD_ID = Nothing
        '                If mR.Cells("CAR_ID").Value Is Nothing Or mR.Cells("CAR_ID").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID").Value)
        '                If mR.Cells("COQ_ID").Value Is Nothing Or mR.Cells("COQ_ID").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID").Value)
        '                If mR.Cells("DES_ID").Value Is Nothing Or mR.Cells("DES_ID").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID").Value)
        '                .LMA_ID = CInt(mR.Cells("LMA_ID").Value)
        '                .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE").Value
        '                .CCD_FECHA = dtpFecha.Value.Date
        '                .CCD_TIPO = mR.Cells("CCD_TIPO").Value
        '                .CCD_ESTADO = mR.Cells("CCD_ESTADO").Value
        '                .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD").Value)
        '                .HOR_ID = CInt(mR.Cells("HOR_ID").Value)
        '                .PUE_ID = CInt(mR.Cells("PUE_ID").Value)
        '                .CCD_HORNO = mR.Cells("CCD_HORNO").Value
        '                .CCD_PUERTA = mR.Cells("CCD_PUERTA").Value
        '                .MarkAsAdded()
        '            End With
        '            colCCD.Add(mCCD) 'Agrego a la coleccion
        '        End If
        '    Next
        '    For Each mR As DataGridViewRow In dgvDetalle2.Rows
        '        If Not mR.Cells("CCD_ID2").Tag Is Nothing Then 'Ya existe
        '            With CType(mR.Cells("CCD_ID2").Tag, CaCoDe_Detalle)
        '                .CCD_ID = CInt(mR.Cells("CCD_ID2").Value)
        '                If mR.Cells("CAR_ID2").Value Is Nothing Or mR.Cells("CAR_ID2").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID2").Value)
        '                If mR.Cells("COQ_ID2").Value Is Nothing Or mR.Cells("COQ_ID2").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID2").Value)
        '                If mR.Cells("DES_ID2").Value Is Nothing Or mR.Cells("DES_ID2").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID2").Value)
        '                .LMA_ID = CInt(mR.Cells("LMA_ID2").Value)
        '                .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE2").Value
        '                .CCD_FECHA = dtpFecha.Value.Date
        '                .CCD_TIPO = mR.Cells("CCD_TIPO2").Value
        '                .CCD_ESTADO = mR.Cells("CCD_ESTADO2").Value
        '                .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD2").Value)
        '                .HOR_ID = CInt(mR.Cells("HOR_ID2").Value)
        '                .PUE_ID = CInt(mR.Cells("PUE_ID2").Value)
        '                .CCD_HORNO = mR.Cells("CCD_HORNO2").Value
        '                .CCD_PUERTA = mR.Cells("CCD_PUERTA2").Value
        '                .MarkAsModified()
        '            End With
        '        ElseIf Not mR.Cells("CCD_Cantidad2").Value Is Nothing Then 'No existe
        '            mCCD = New CaCoDe_Detalle
        '            With mCCD
        '                .CCD_ID = Nothing
        '                If mR.Cells("CAR_ID2").Value Is Nothing Or mR.Cells("CAR_ID2").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID2").Value)
        '                If mR.Cells("COQ_ID2").Value Is Nothing Or mR.Cells("COQ_ID2").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID2").Value)
        '                If mR.Cells("DES_ID2").Value Is Nothing Or mR.Cells("DES_ID2").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID2").Value)
        '                .LMA_ID = CInt(mR.Cells("LMA_ID2").Value)
        '                .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE2").Value
        '                .CCD_FECHA = dtpFecha.Value.Date
        '                .CCD_TIPO = mR.Cells("CCD_TIPO2").Value
        '                .CCD_ESTADO = mR.Cells("CCD_ESTADO2").Value
        '                .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD2").Value)
        '                .HOR_ID = CInt(mR.Cells("HOR_ID2").Value)
        '                .PUE_ID = CInt(mR.Cells("PUE_ID2").Value)
        '                .CCD_HORNO = mR.Cells("CCD_HORNO2").Value
        '                .CCD_PUERTA = mR.Cells("CCD_PUERTA2").Value
        '                .MarkAsAdded()
        '            End With
        '            colCCD.Add(mCCD) 'Agrego a la coleccion
        '        End If
        '    Next
        '    For Each mR As DataGridViewRow In dgvDetalle3.Rows
        '        If Not mR.Cells("CCD_ID3").Tag Is Nothing Then 'Ya existe
        '            With CType(mR.Cells("CCD_ID3").Tag, CaCoDe_Detalle)
        '                .CCD_ID = CInt(mR.Cells("CCD_ID3").Value)
        '                If mR.Cells("CAR_ID3").Value Is Nothing Or mR.Cells("CAR_ID3").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID3").Value)
        '                If mR.Cells("COQ_ID3").Value Is Nothing Or mR.Cells("COQ_ID3").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID3").Value)
        '                If mR.Cells("DES_ID3").Value Is Nothing Or mR.Cells("DES_ID3").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID3").Value)
        '                .LMA_ID = CInt(mR.Cells("LMA_ID3").Value)
        '                .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE3").Value
        '                .CCD_FECHA = dtpFecha.Value.Date
        '                .CCD_TIPO = mR.Cells("CCD_TIPO3").Value
        '                .CCD_ESTADO = mR.Cells("CCD_ESTADO3").Value
        '                .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD3").Value)
        '                .HOR_ID = CInt(mR.Cells("HOR_ID3").Value)
        '                .PUE_ID = CInt(mR.Cells("PUE_ID3").Value)
        '                .CCD_HORNO = mR.Cells("CCD_HORNO3").Value
        '                .CCD_PUERTA = mR.Cells("CCD_PUERTA3").Value
        '                .MarkAsModified()
        '            End With
        '        ElseIf Not mR.Cells("CCD_Cantidad3").Value Is Nothing Then 'No existe
        '            mCCD = New CaCoDe_Detalle
        '            With mCCD
        '                .CCD_ID = Nothing
        '                If mR.Cells("CAR_ID3").Value Is Nothing Or mR.Cells("CAR_ID3").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID3").Value)
        '                If mR.Cells("COQ_ID3").Value Is Nothing Or mR.Cells("COQ_ID3").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID3").Value)
        '                If mR.Cells("DES_ID3").Value Is Nothing Or mR.Cells("DES_ID3").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID3").Value)
        '                .LMA_ID = CInt(mR.Cells("LMA_ID3").Value)
        '                .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE3").Value
        '                .CCD_FECHA = dtpFecha.Value.Date
        '                .CCD_TIPO = mR.Cells("CCD_TIPO3").Value
        '                .CCD_ESTADO = mR.Cells("CCD_ESTADO3").Value
        '                .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD3").Value)
        '                .HOR_ID = CInt(mR.Cells("HOR_ID3").Value)
        '                .PUE_ID = CInt(mR.Cells("PUE_ID3").Value)
        '                .CCD_HORNO = mR.Cells("CCD_HORNO3").Value
        '                .CCD_PUERTA = mR.Cells("CCD_PUERTA3").Value
        '                .MarkAsAdded()
        '            End With
        '            colCCD.Add(mCCD) 'Agrego a la coleccion
        '        End If
        '    Next
        '    For Each mR As DataGridViewRow In dgvDetalle4.Rows
        '        If Not mR.Cells("CCD_ID4").Tag Is Nothing Then 'Ya existe
        '            With CType(mR.Cells("CCD_ID4").Tag, CaCoDe_Detalle)
        '                .CCD_ID = CInt(mR.Cells("CCD_ID4").Value)
        '                If mR.Cells("CAR_ID4").Value Is Nothing Or mR.Cells("CAR_ID4").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID4").Value)
        '                If mR.Cells("COQ_ID4").Value Is Nothing Or mR.Cells("COQ_ID4").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID4").Value)
        '                If mR.Cells("DES_ID4").Value Is Nothing Or mR.Cells("DES_ID4").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID4").Value)
        '                .LMA_ID = CInt(mR.Cells("LMA_ID4").Value)
        '                .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE4").Value
        '                .CCD_FECHA = dtpFecha.Value.Date
        '                .CCD_TIPO = mR.Cells("CCD_TIPO4").Value
        '                .CCD_ESTADO = mR.Cells("CCD_ESTADO4").Value
        '                .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD4").Value)
        '                .HOR_ID = CInt(mR.Cells("HOR_ID4").Value)
        '                .PUE_ID = CInt(mR.Cells("PUE_ID4").Value)
        '                .CCD_HORNO = mR.Cells("CCD_HORNO4").Value
        '                .CCD_PUERTA = mR.Cells("CCD_PUERTA4").Value
        '                .MarkAsModified()
        '            End With
        '        ElseIf Not mR.Cells("CCD_Cantidad4").Value Is Nothing Then 'No existe
        '            mCCD = New CaCoDe_Detalle
        '            With mCCD
        '                .CCD_ID = Nothing
        '                If mR.Cells("CAR_ID4").Value Is Nothing Or mR.Cells("CAR_ID4").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID4").Value)
        '                If mR.Cells("COQ_ID4").Value Is Nothing Or mR.Cells("COQ_ID4").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID4").Value)
        '                If mR.Cells("DES_ID4").Value Is Nothing Or mR.Cells("DES_ID4").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID4").Value)
        '                .LMA_ID = CInt(mR.Cells("LMA_ID4").Value)
        '                .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE4").Value
        '                .CCD_FECHA = dtpFecha.Value.Date
        '                .CCD_TIPO = mR.Cells("CCD_TIPO4").Value
        '                .CCD_ESTADO = mR.Cells("CCD_ESTADO4").Value
        '                .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD4").Value)
        '                .HOR_ID = CInt(mR.Cells("HOR_ID4").Value)
        '                .PUE_ID = CInt(mR.Cells("PUE_ID4").Value)
        '                .CCD_HORNO = mR.Cells("CCD_HORNO4").Value
        '                .CCD_PUERTA = mR.Cells("CCD_PUERTA4").Value
        '                .MarkAsAdded()
        '            End With
        '            colCCD.Add(mCCD) 'Agrego a la coleccion
        '        End If
        '    Next
        '''''''''''''''''''''''''''''''''''''End If



        'For Each mR As DataGridViewRow In dgvDetalle.Rows
        '    If Not BuscarFecha = dtpFecha.Value.Date Then 'Es un nuevo dia
        '        If Not mR.Cells("CCD_Cantidad").Value Is Nothing Then
        '            Dim mCCD As New CaCoDe_Detalle
        '            With mCCD
        '                .CCD_ID = Nothing
        '                If mR.Cells("CAR_ID").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID").Value)
        '                If mR.Cells("COQ_ID").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID").Value)
        '                If mR.Cells("DES_ID").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID").Value)
        '                .LMA_ID = CInt(mR.Cells("LMA_ID").Value)
        '                .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE").Value
        '                .CCD_FECHA = dtpFecha.Value.Date
        '                .CCD_TIPO = mR.Cells("CCD_TIPO").Value
        '                .CCD_ESTADO = mR.Cells("CCD_ESTADO").Value
        '                .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD").Value)
        '                .HOR_ID = CInt(mR.Cells("HOR_ID").Value)
        '                .PUE_ID = CInt(mR.Cells("PUE_ID").Value)
        '                .CCD_HORNO = mR.Cells("CCD_HORNO").Value
        '                .CCD_PUERTA = mR.Cells("CCD_PUERTA").Value
        '                .MarkAsAdded()
        '            End With
        '            colCCD.Add(mCCD) 'Agrego a la coleccion
        '        End If
        '    Else 'Se trata del mismo dia
        '        If Not mR.Cells("CCD_ID").Tag Is Nothing Then 'Ya existe
        '            With CType(mR.Cells("CCD_ID").Tag, CaCoDe_Detalle)
        '                .CCD_ID = CInt(mR.Cells("CCD_ID").Value)
        '                If mR.Cells("CAR_ID").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID").Value)
        '                If mR.Cells("COQ_ID").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID").Value)
        '                If mR.Cells("DES_ID").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID").Value)
        '                .LMA_ID = CInt(mR.Cells("LMA_ID").Value)
        '                .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE").Value
        '                .CCD_FECHA = dtpFecha.Value.Date
        '                .CCD_TIPO = mR.Cells("CCD_TIPO").Value
        '                .CCD_ESTADO = mR.Cells("CCD_ESTADO").Value
        '                .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD").Value)
        '                .HOR_ID = CInt(mR.Cells("HOR_ID").Value)
        '                .PUE_ID = CInt(mR.Cells("PUE_ID").Value)
        '                .CCD_HORNO = mR.Cells("CCD_HORNO").Value
        '                .CCD_PUERTA = mR.Cells("CCD_PUERTA").Value
        '                .MarkAsModified()
        '            End With
        '            colCCD.Add(CType(mR.Cells("CCD_ID").Tag, CaCoDe_Detalle)) 'Agrego a la coleccion
        '        ElseIf Not mR.Cells("CCD_Cantidad").Value Is Nothing Then 'No existe
        '            Dim mCCD As New CaCoDe_Detalle
        '            With mCCD
        '                .CCD_ID = Nothing
        '                If mR.Cells("CAR_ID").Value Is DBNull.Value Then .CAR_ID = Nothing Else .CAR_ID = CInt(mR.Cells("CAR_ID").Value)
        '                If mR.Cells("COQ_ID").Value Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mR.Cells("COQ_ID").Value)
        '                If mR.Cells("DES_ID").Value Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mR.Cells("DES_ID").Value)
        '                .LMA_ID = CInt(mR.Cells("LMA_ID").Value)
        '                .CCD_NRO_MALE = mR.Cells("CCD_NRO_MALE").Value
        '                .CCD_FECHA = dtpFecha.Value.Date
        '                .CCD_TIPO = mR.Cells("CCD_TIPO").Value
        '                .CCD_ESTADO = mR.Cells("CCD_ESTADO").Value
        '                .CCD_CANTIDAD = CInt(mR.Cells("CCD_CANTIDAD").Value)
        '                .HOR_ID = CInt(mR.Cells("HOR_ID").Value)
        '                .PUE_ID = CInt(mR.Cells("PUE_ID").Value)
        '                .CCD_HORNO = mR.Cells("CCD_HORNO").Value
        '                .CCD_PUERTA = mR.Cells("CCD_PUERTA").Value
        '                .MarkAsAdded()
        '            End With
        '            colCCD.Add(mCCD) 'Agrego a la coleccion
        '        End If
        '    End If
        'Next

        Select Case Estado
            Case "CA"
                Dim CARGA As New ControlCarga
                CARGA.PER_ID_OPERADOR = txtOperador1.Tag
                CARGA.PRO_ID = CInt(txtProduccion.Tag)
                CARGA.HOR_ID = CInt(cboHorno.SelectedValue)
                CARGA.CAR_FECHA = dtpFecha.Value
                CARGA.CAR_HI = numHI.Value
                CARGA.CAR_HF = numHF.Value
                CARGA.CAR_MI = numMI.Value
                CARGA.CAR_MF = numMF.Value
                Dim TotalLAD = (From mT In colCCD Where mT.CCD_ID = Nothing And mT.CAR_ID Is Nothing And mT.CCD_ESTADO = "CA" Select mT.CCD_CANTIDAD).Sum()
                CARGA.CAR_TOTAL = TotalLAD
                CARGA.CAR_ESTADO = True
                CARGA.CAR_FEC_GRAB = Now
                CARGA.USU_ID = SessionServer.UserId
                CARGA.MarkAsAdded()
                BCCaCoDeDetalle.MantenimientoCaCoDeDetalle2(colCCD, CARGA, Nothing, Nothing)
                LimpiarCarga()
            Case "CO"
                Dim Quema As New ControlQuema
                Quema.HOR_ID = CInt(cboHorno.SelectedValue)
                Quema.PER_ID_OPERADOR = txtOperador1.Tag
                Quema.PER_ID_OPERADOR2 = txtOperador2.Tag
                Quema.COQ_FECHA = dtpFecha.Value
                Quema.COQ_HI = numHI.Value
                Quema.COQ_HF = numHF.Value
                Quema.COQ_MI = numMI.Value
                Quema.COQ_MF = numMF.Value
                Quema.COQ_FEC_GRAB = Now
                Quema.COQ_ESTADO = True
                Quema.USU_ID = SessionServer.UserId
                Quema.MarkAsAdded()
                BCCaCoDeDetalle.MantenimientoCaCoDeDetalle2(colCCD, Nothing, Quema, Nothing)
                LimpiarQuema()
            Case "DE"
                Dim Descarga As New ControlDescarga
                Descarga.HOR_ID = CInt(cboHorno.SelectedValue)
                Descarga.PUE_ID = CInt(cboPuerta.SelectedValue)
                Descarga.PER_ID_OPERADOR = txtOperador1.Tag
                Descarga.DES_FECHA = dtpFecha.Value
                Descarga.DES_HI = numHI.Value
                Descarga.DES_HF = numHF.Value
                Descarga.DES_MI = numMI.Value
                Descarga.DES_MF = numMF.Value
                Descarga.DES_FEC_GRAB = Now
                Descarga.DES_ESTADO = True
                Descarga.USU_ID = SessionServer.UserId
                Descarga.MarkAsAdded()
                BCCaCoDeDetalle.MantenimientoCaCoDeDetalle2(colCCD, Nothing, Nothing, Descarga)
                LimpiarDescarga()
        End Select

        btnBuscar_Click(Nothing, Nothing)

    End Sub

    Sub LimpiarCarga()
        numCarMI.Value = 0
        numCarMF.Value = 0
        txtProduccion.Text = String.Empty
        txtProduccion.Tag = Nothing
        cboPuerta.SelectedIndex = -1
        numCantMalec.Value = 0
        txtTotalCarga.Text = String.Empty
    End Sub

    Sub LimpiarQuema()
        txtProduccion.Text = String.Empty
        txtProduccion.Tag = Nothing
        cboPuerta.SelectedIndex = -1
        numHI.Value = 0
        numHF.Value = 0
        numMI.Value = 0
        numMF.Value = 0
        cboTipo.SelectedIndex = -1
        numCantMalec.Value = 0
        txtTotalCarga.Text = String.Empty
    End Sub

    Sub LimpiarDescarga()
        txtProduccion.Text = String.Empty
        txtProduccion.Tag = Nothing
        cboPuerta.SelectedIndex = -1
        numHI.Value = 0
        numHF.Value = 0
        numMI.Value = 0
        numMF.Value = 0
        cboTipo.SelectedIndex = -1
        numCantMalec.Value = 0
        txtTotalCarga.Text = String.Empty
    End Sub

    Private Sub cboPuerta_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPuerta.SelectedValueChanged
        If cboHorno.DataSource IsNot Nothing Then
            Dim mRow = From mR As DataGridViewRow In dgvDetalle.Rows Where mR.Cells("PUE_ID").Value = cboPuerta.SelectedValue Select mR
            If mRow.Count = 0 Then
                mRow = From mR As DataGridViewRow In dgvDetalle2.Rows Where mR.Cells("PUE_ID2").Value = cboPuerta.SelectedValue Select mR
                If mRow.Count = 0 Then
                    mRow = From mR As DataGridViewRow In dgvDetalle3.Rows Where mR.Cells("PUE_ID3").Value = cboPuerta.SelectedValue Select mR
                    If mRow.Count = 0 Then
                        mRow = From mR As DataGridViewRow In dgvDetalle4.Rows Where mR.Cells("PUE_ID4").Value = cboPuerta.SelectedValue Select mR
                        If mRow.Count > 0 Then
                            Dim mMax = (From mM In mRow Select CInt(mM.Cells("CCD_NRO_MALE4").Value)).Max
                            numMF.Value = mMax
                            Dim mMin = (From mM In mRow Select CInt(mM.Cells("CCD_NRO_MALE4").Value)).Min
                            numMF.Value = mMax
                            numMI.Value = mMin
                        End If
                    Else
                        Dim mMax = (From mM In mRow Select CInt(mM.Cells("CCD_NRO_MALE3").Value)).Max
                        numMF.Value = mMax
                        Dim mMin = (From mM In mRow Select CInt(mM.Cells("CCD_NRO_MALE3").Value)).Min
                        numMF.Value = mMax
                        numMI.Value = mMin
                    End If
                Else
                    Dim mMax = (From mM In mRow Select CInt(mM.Cells("CCD_NRO_MALE2").Value)).Max
                    numMF.Value = mMax
                    Dim mMin = (From mM In mRow Select CInt(mM.Cells("CCD_NRO_MALE2").Value)).Min
                    numMF.Value = mMax
                    numMI.Value = mMin
                End If
            Else
                Dim mMax = (From mM In mRow Select CInt(mM.Cells("CCD_NRO_MALE").Value)).Max
                numMF.Value = mMax
                Dim mMin = (From mM In mRow Select CInt(mM.Cells("CCD_NRO_MALE").Value)).Min
                numMF.Value = mMax
                numMI.Value = mMin
            End If
        End If
    End Sub




    Public Overrides Sub OnManNuevo()



        '---------------------------------------
        Call validacion_desactivacion(True, 2)

    End Sub
    Public Overrides Sub OnManBuscar()



        '---------------------------------
        Call validacion_desactivacion(True, 5)
    End Sub


    '===================================================================================================================
    '----procedimiento de validaciones
    'tecla enter de paso rapido entre cajas de texto.
    Sub paso_enter(ByVal caja As TextBox, ByVal combo As ComboBox, ByVal numero As NumericUpDown, ByVal fecha As DateTimePicker, ByVal flag As Integer)

        If caja.Name.Substring(0, 3) = "txt" And flag = 1 Then
            AddHandler caja.KeyPress, New System.Windows.Forms.KeyPressEventHandler(AddressOf EnterBox_caja)
        ElseIf combo.Name.Substring(0, 3) = "cbo" And flag = 2 Then
            AddHandler combo.KeyPress, New System.Windows.Forms.KeyPressEventHandler(AddressOf EnterBox_caja)
        ElseIf numero.Name.Substring(0, 3) = "num" And flag = 3 Then
            AddHandler numero.KeyPress, New System.Windows.Forms.KeyPressEventHandler(AddressOf EnterBox_caja)
        ElseIf fecha.Name.Substring(0, 3) = "dtp" And flag = 4 Then
            AddHandler fecha.KeyPress, New System.Windows.Forms.KeyPressEventHandler(AddressOf EnterBox_caja)

        End If

    End Sub

    Private Sub EnterBox_caja(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        'cajas de texto
        If e.KeyChar = Convert.ToChar(Keys.Tab) And sender.name.substring(0, 3) = "txt" Then
            e.Handled = True
            Select Case CType(sender, TextBox).Name
                Case "txtProduccion" : txtOperador1.Focus()
                Case "txtOperador1" : txtOperador2.Focus()
                Case "txtOperador2" : cboPuerta.Focus()

            End Select
            'combos desplegables
        ElseIf e.KeyChar = Convert.ToChar(Keys.Tab) And sender.name.substring(0, 3) = "cbo" Then
            e.Handled = True
            Select Case CType(sender, ComboBox).Name
                Case "cboHorno" : txtProduccion.Focus()
                Case "cboPuerta" : dtpFecha.Focus()
                Case "cboTipo" : numHF.Focus()

            End Select
            'numeros
        ElseIf e.KeyChar = Convert.ToChar(Keys.Tab) And sender.name.substring(0, 3) = "num" Then
            e.Handled = True
            Select Case CType(sender, NumericUpDown).Name
                Case "numHI" : numMI.Focus()
                Case "numMI" : cboTipo.Focus()
                Case "numHF" : numMF.Focus()
                Case "numMF" : cboHorno.Focus()

            End Select
            ''combo fecha
        ElseIf e.KeyChar = Convert.ToChar(Keys.Tab) And sender.name.substring(0, 3) = "dtp" Then
            e.Handled = True
            Select Case CType(sender, DateTimePicker).Name
                Case "dtpFecha" : numHI.Focus()

            End Select

        End If
    End Sub

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_Validacion.Clear()
        If Len(cboHorno.Text.Trim) = 0 Then Error_Validacion.SetError(cboHorno, "Ingrese el nombre del Horno ") : cboHorno.Focus() : flag = False
        'If Len(txtProduccion.Text.Trim) = 0 Then Error_validacion.SetError(txtProduccion, "Ingrese la Producción") : txtProduccion.Focus() : flag = False 'Not Quema
        If Len(txtOperador1.Text.Trim) = 0 Then Error_Validacion.SetError(txtOperador1, "Ingrese el Nombre del Operador 1") : txtOperador1.Focus() : flag = False
        'If Len(txtOperador2.Text.Trim) = 0 Then Error_validacion.SetError(txtOperador2, "Ingrese el Nombre del Operador 2") : txtOperador2.Focus() : flag = False 'Not Carga
        'If Len(cboPuerta.Text.Trim) = 0 Then Error_validacion.SetError(cboPuerta, "Ingrese el Nombre de la Puerta") : cboPuerta.Focus() : flag = False
        If Len(dtpFecha.Text.Trim) = 0 Then Error_Validacion.SetError(dtpFecha, "Ingrese la Fecha") : dtpFecha.Focus() : flag = False
        If Len(numHI.Text.Trim) = 0 Then Error_Validacion.SetError(numHI, "Ingrese la Hora de Inicio") : numHI.Focus() : flag = False
        If Len(numMI.Text.Trim) = 0 Then Error_Validacion.SetError(numMI, "Ingrese el Malecon Inicial") : numMI.Focus() : flag = False
        'If Len(cboTipo.Text.Trim) = 0 Then Error_validacion.SetError(cboTipo, "Ingrese el Tipo") : cboTipo.Focus() : flag = False 'Not Quema
        If Len(numHF.Text.Trim) = 0 Then Error_Validacion.SetError(numHF, "Ingrese la Hora Final") : numHF.Focus() : flag = False
        If Len(numMF.Text.Trim) = 0 Then Error_Validacion.SetError(numMF, "Ingrese el Malecon Final") : numMF.Focus() : flag = False


        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos.
    Private Sub validar_longitud()
        Me.cboHorno.MaxLength = 100 : Me.cboHorno.DropDownStyle = ComboBoxStyle.DropDownList
        Me.txtProduccion.MaxLength = 160
        Me.txtOperador1.MaxLength = 160
        Me.txtOperador2.MaxLength = 160
        Me.cboPuerta.MaxLength = 100 : Me.cboPuerta.DropDownStyle = ComboBoxStyle.DropDownList
        Me.numHI.Maximum = 99 : Me.numHI.DecimalPlaces = 2
        Me.numMI.Maximum = 1000 : Me.numMI.DecimalPlaces = 0
        Me.numHF.Maximum = 99 : Me.numHF.DecimalPlaces = 2
        Me.numMF.Maximum = 1000 : Me.numMF.DecimalPlaces = 0
        Me.cboTipo.MaxLength = 10 : Me.cboTipo.DropDownStyle = ComboBoxStyle.DropDownList

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
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
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
            rbtQuema.Checked = False
            rbtQuema.Checked = True

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

    Private Sub txtOperador1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOperador1.KeyDown

        If e.KeyCode = Keys.Enter Then txtOperador1_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtOperador2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOperador2.KeyDown
        If e.KeyCode = Keys.Enter Then txtOperador2_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub numHI_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles numHI.LostFocus, numHF.LostFocus
        Try
            If sender.value > 0 Then
                If Not IsDate(Replace(sender.Value, ".", ":")) Then
                    MessageBox.Show("La hora es incorrecta.")
                    sender.Value = 0
                    sender.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub numCantMalec_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles numCantMalec.Enter, numMF.Enter, numMI.Enter, numHI.Enter, numHF.Enter
        sender.Select(0, sender.Text.ToString.Length)
    End Sub

    Private Sub dgvDetalle4_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle4.UserDeletingRow
        If Not e.Row.Cells("CCD_ID4").Tag Is Nothing Then
            CType(e.Row.Cells("CCD_ID4").Tag, CaCoDe_Detalle).MarkAsDeleted()
        End If
    End Sub

    Private Sub dgvDetalle3_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle3.UserDeletingRow
        If Not e.Row.Cells("CCD_ID3").Tag Is Nothing Then
            CType(e.Row.Cells("CCD_ID3").Tag, CaCoDe_Detalle).MarkAsDeleted()
        End If
    End Sub

    Private Sub dgvDetalle2_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle2.UserDeletingRow
        If Not e.Row.Cells("CCD_ID2").Tag Is Nothing Then
            CType(e.Row.Cells("CCD_ID2").Tag, CaCoDe_Detalle).MarkAsDeleted()
        End If
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "CCD_ORIGEN_DESTINO"
                frm.Tabla = "CanchaSecadero"
                frm.Tipo = IIf(dgvDetalle.CurrentCell.EditedFormattedValue = "", Nothing, dgvDetalle.CurrentCell.EditedFormattedValue)
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'Descripcion
                    dgvDetalle.CurrentRow.Cells("ENO_ID_ORIDES").Value = frm.dgvLista.CurrentRow.Cells(0).Value  'Codigo
                End If
            Case "UNT_ID"
                frm.Tabla = "UnidadesTransporte"
                frm.Tipo = dgvDetalle.CurrentCell.EditedFormattedValue
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value  'Placa
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'Placa
                    dgvDetalle.CurrentRow.Cells("PER_ID_EMPRESA").Value = frm.dgvLista.CurrentRow.Cells(1).Value  'PER_ID_EMPRESA
                End If
        End Select
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle2_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle2.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        Select Case dgvDetalle2.Columns(dgvDetalle2.CurrentCell.ColumnIndex).Name
            Case "CCD_ORIGEN_DESTINO2"
                frm.Tabla = "CanchaSecadero"
                frm.Tipo = IIf(dgvDetalle2.CurrentCell.EditedFormattedValue = "", Nothing, dgvDetalle2.CurrentCell.EditedFormattedValue)
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle2.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'Descripcion
                    dgvDetalle2.CurrentRow.Cells("ENO_ID_ORIDES2").Value = frm.dgvLista.CurrentRow.Cells(0).Value  'Codigo
                End If
            Case "UNT_ID2"
                frm.Tabla = "UnidadesTransporte"
                frm.Tipo = dgvDetalle2.CurrentCell.EditedFormattedValue
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle2.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value  'Placa
                    dgvDetalle2.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'Placa
                    dgvDetalle2.CurrentRow.Cells("PER_ID_EMPRESA2").Value = frm.dgvLista.CurrentRow.Cells(1).Value  'PER_ID_EMPRESA
                End If
        End Select
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle3_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle3.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        Select Case dgvDetalle3.Columns(dgvDetalle3.CurrentCell.ColumnIndex).Name
            Case "CCD_ORIGEN_DESTINO3"
                frm.Tabla = "CanchaSecadero"
                frm.Tipo = IIf(dgvDetalle3.CurrentCell.EditedFormattedValue = "", Nothing, dgvDetalle3.CurrentCell.EditedFormattedValue)
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle3.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'Descripcion
                    dgvDetalle3.CurrentRow.Cells("ENO_ID_ORIDES3").Value = frm.dgvLista.CurrentRow.Cells(0).Value  'Codigo
                End If
            Case "UNT_ID3"
                frm.Tabla = "UnidadesTransporte"
                frm.Tipo = dgvDetalle3.CurrentCell.EditedFormattedValue
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle3.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value  'Placa
                    dgvDetalle3.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'Placa
                    dgvDetalle3.CurrentRow.Cells("PER_ID_EMPRESA3").Value = frm.dgvLista.CurrentRow.Cells(1).Value  'PER_ID_EMPRESA
                End If
        End Select
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle4_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle4.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        Select Case dgvDetalle4.Columns(dgvDetalle4.CurrentCell.ColumnIndex).Name
            Case "CCD_ORIGEN_DESTINO4"
                frm.Tabla = "CanchaSecadero"
                frm.Tipo = IIf(dgvDetalle4.CurrentCell.EditedFormattedValue = "", Nothing, dgvDetalle4.CurrentCell.EditedFormattedValue)
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle4.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'Descripcion
                    dgvDetalle4.CurrentRow.Cells("ENO_ID_ORIDES4").Value = frm.dgvLista.CurrentRow.Cells(0).Value  'Codigo
                End If
            Case "UNT_ID4"
                frm.Tabla = "UnidadesTransporte"
                frm.Tipo = dgvDetalle4.CurrentCell.EditedFormattedValue
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle4.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value  'Placa
                    dgvDetalle4.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'Placa
                    dgvDetalle4.CurrentRow.Cells("PER_ID_EMPRESA4").Value = frm.dgvLista.CurrentRow.Cells(1).Value  'PER_ID_EMPRESA
                End If
        End Select
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "CCD_HI", "CCD_HF"
                Try
                    If Not IsDate(Replace(dgvDetalle.CurrentCell.Value, ".", ":")) Then
                        dgvDetalle.CurrentCell.Value = 0
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
        End Select
    End Sub

    Private Sub dgvDetalle2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle2.CellEndEdit
        Select Case dgvDetalle2.Columns(dgvDetalle2.CurrentCell.ColumnIndex).Name
            Case "CCD_HI2", "CCD_HF2"
                Try
                    If Not IsDate(Replace(dgvDetalle2.CurrentCell.Value, ".", ":")) Then
                        dgvDetalle2.CurrentCell.Value = 0
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
        End Select
    End Sub

    Private Sub dgvDetalle3_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle3.CellEndEdit
        Select Case dgvDetalle3.Columns(dgvDetalle3.CurrentCell.ColumnIndex).Name
            Case "CCD_HI3", "CCD_HF3"
                Try
                    If Not IsDate(Replace(dgvDetalle3.CurrentCell.Value, ".", ":")) Then
                        dgvDetalle3.CurrentCell.Value = 0
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
        End Select
    End Sub

    Private Sub dgvDetalle4_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle4.CellEndEdit
        Select Case dgvDetalle4.Columns(dgvDetalle4.CurrentCell.ColumnIndex).Name
            Case "CCD_HI4", "CCD_HF4"
                Try
                    If Not IsDate(Replace(dgvDetalle4.CurrentCell.Value, ".", ":")) Then
                        dgvDetalle4.CurrentCell.Value = 0
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
        End Select
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle_CellDoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub dgvDetalle2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle2_CellDoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub dgvDetalle3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle3.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle3_CellDoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub dgvDetalle4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle4.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle4_CellDoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        If Not e.Row.Cells("CCD_ID").Tag Is Nothing Then
            CType(e.Row.Cells("CCD_ID").Tag, CaCoDe_Detalle).MarkAsDeleted()
        End If
    End Sub

    Private Sub txtTotalCarga_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalCarga.DoubleClick

        Dim Total = dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Where(Function(row) row.Cells("CAR_ID").Value Is DBNull.Value And Convert.ToInt32(row.Cells("CCD_CANTIDAD").Value > 0)).Sum(Function(row) Convert.ToInt32(row.Cells("CCD_CANTIDAD").Value))
        Dim Total2 = dgvDetalle2.Rows.Cast(Of DataGridViewRow).AsEnumerable.Where(Function(row) row.Cells("CAR_ID2").Value Is DBNull.Value And Convert.ToInt32(row.Cells("CCD_CANTIDAD2").Value > 0)).Sum(Function(row) Convert.ToInt32(row.Cells("CCD_CANTIDAD2").Value))
        Dim Total3 = dgvDetalle3.Rows.Cast(Of DataGridViewRow).AsEnumerable.Where(Function(row) row.Cells("CAR_ID3").Value Is DBNull.Value And Convert.ToInt32(row.Cells("CCD_CANTIDAD3").Value > 0)).Sum(Function(row) Convert.ToInt32(row.Cells("CCD_CANTIDAD3").Value))
        Dim Total4 = dgvDetalle4.Rows.Cast(Of DataGridViewRow).AsEnumerable.Where(Function(row) row.Cells("CAR_ID4").Value Is DBNull.Value And Convert.ToInt32(row.Cells("CCD_CANTIDAD4").Value > 0)).Sum(Function(row) Convert.ToInt32(row.Cells("CCD_CANTIDAD4").Value))

        'Dim Total As Integer = 0
        'For Each mFila As DataGridViewRow In dgvDetalle.Rows
        '    If mFila.Cells("CAR_ID").Value Is DBNull.Value And mFila.Cells("CCD_CANTIDAD").Value > 0 Then
        '        Total = Total + mFila.Cells("CCD_CANTIDAD").Value
        '    End If
        'Next

        txtTotalCarga.Text = Total + Total2 + Total3 + Total4
        Dim mds As New DataSet
        Dim ConteoOrSalida, CargadoHorno As Integer

        mds = BCCaCoDeDetalle.ValidarCarga(txtProduccion.Tag)

        ConteoOrSalida = mds.Tables(0).Rows(0).Item("ConteoOrSalida")
        CargadoHorno = mds.Tables(0).Rows(0).Item("CargadoHorno")

        If ConteoOrSalida - (CargadoHorno + txtTotalCarga.Text) < 0 Then
            MessageBox.Show("La Carga excede al Conteo ó la Produccion ya fue Terminada" & Chr(13) & "Total Conteo :" & ConteoOrSalida & Chr(13) & _
                            "Total Carga :" & CargadoHorno + txtTotalCarga.Text, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btnBuscar_Click(btnBuscar, e)
        Else
            If ConteoOrSalida > 0 Then
                Select Case MessageBox.Show("El Reciclaje va en : " & _
                                             Math.Round(((ConteoOrSalida - (CargadoHorno + txtTotalCarga.Text)) * 100) / ConteoOrSalida, 2) & " %" & Chr(13) & _
                                             "Quedarían : " & (ConteoOrSalida - CargadoHorno) - txtTotalCarga.Text & _
                                             " Ladrillos", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
                    Case Windows.Forms.DialogResult.Cancel
                        btnBuscar_Click(btnBuscar, e)
                End Select
            Else
                MsgBox("No tiene Conteo o Salida de secadero la Produccion que intenta Cargar" & Chr(13) & "Agrege el Conteo o Salida de Secadero para saber en que Reciclaje va.", MsgBoxStyle.Information, "Atencion")
                btnBuscar_Click(btnBuscar, e)
            End If
        End If

    End Sub

    Private Sub txtProduccion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProduccion.TextChanged
        If txtProduccion.Text.Length = 0 Then
            txtProduccion.Tag = Nothing
        End If
    End Sub

    Private Sub frmCaCoDe_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        dgvDetalle2.Width = (Me.Width / 2) - 70
        dgvDetalle2.Height = (Me.Height / 2) - 160
        dgvDetalle2.Location = New System.Drawing.Point(14, 249)

        dgvDetalle3.Width = (Me.Width / 2) - 70
        dgvDetalle3.Height = (Me.Height / 2) - 160
        dgvDetalle3.Location = New System.Drawing.Point((Me.Width / 2), 249)

        dgvDetalle.Width = (Me.Width / 2) - 70
        dgvDetalle.Height = (Me.Height / 2) - 160
        dgvDetalle.Location = New System.Drawing.Point(14, dgvDetalle2.Height + 260)

        dgvDetalle4.Width = (Me.Width / 2) - 70
        dgvDetalle4.Height = (Me.Height / 2) - 160
        dgvDetalle4.Location = New System.Drawing.Point((Me.Width / 2), dgvDetalle3.Height + 260)
    End Sub

    Private Sub rbtQuema_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtQuema.CheckedChanged
        If rbtQuema.AutoCheck = True Then
            pnlQuema.Enabled = True
            pnlQuema.BackColor = Drawing.Color.Aquamarine
            pnlDescarga.Enabled = False
            pnlDescarga.BackColor = Nothing
            pnlCarga.Enabled = False
            pnlCarga.BackColor = Nothing
        End If
    End Sub

    Private Sub rbtDescarga_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtDescarga.CheckedChanged
        If rbtDescarga.AutoCheck = True Then
            pnlDescarga.Enabled = True
            pnlDescarga.BackColor = Drawing.Color.Aquamarine
            pnlQuema.Enabled = False
            pnlQuema.BackColor = Nothing
            pnlCarga.Enabled = False
            pnlCarga.BackColor = Nothing
        End If
    End Sub

    Private Sub rbtCargar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtCargar.CheckedChanged
        If rbtCargar.AutoCheck = True Then
            pnlCarga.Enabled = True
            pnlCarga.BackColor = Drawing.Color.Aquamarine
            pnlQuema.Enabled = False
            pnlQuema.BackColor = Nothing
            pnlDescarga.Enabled = False
            pnlDescarga.BackColor = Nothing
        End If
    End Sub

    Private Sub numCarMI_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles numCarMI.ValueChanged
        numMI.Value = numCarMI.Value
    End Sub

    Private Sub numCarMF_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles numCarMF.ValueChanged
        numMF.Value = numCarMF.Value
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CopiarToolStripMenuItem.Click
        If dgvDetalle.Focused Then
            If dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name = "CCD_ORIGEN_DESTINO" Then
                mCopia.mColumna = dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
                mCopia.mValue = dgvDetalle.CurrentCell.Value
                mCopia.mTag = dgvDetalle.CurrentRow.Cells("ENO_ID_ORIDES").Value
            End If

        ElseIf dgvDetalle2.Focused Then
            If dgvDetalle2.Columns(dgvDetalle2.CurrentCell.ColumnIndex).Name = "CCD_ORIGEN_DESTINO2" Then
                mCopia.mColumna = dgvDetalle2.Columns(dgvDetalle2.CurrentCell.ColumnIndex).Name
                mCopia.mValue = dgvDetalle2.CurrentCell.Value
                mCopia.mTag = dgvDetalle2.CurrentRow.Cells("ENO_ID_ORIDES2").Value
            End If

        ElseIf dgvDetalle3.Focused Then
            If dgvDetalle3.Columns(dgvDetalle3.CurrentCell.ColumnIndex).Name = "CCD_ORIGEN_DESTINO3" Then
                mCopia.mColumna = dgvDetalle3.Columns(dgvDetalle3.CurrentCell.ColumnIndex).Name
                mCopia.mValue = dgvDetalle3.CurrentCell.Value
                mCopia.mTag = dgvDetalle3.CurrentRow.Cells("ENO_ID_ORIDES3").Value
            End If

        ElseIf dgvDetalle4.Focused Then
            If dgvDetalle4.Columns(dgvDetalle4.CurrentCell.ColumnIndex).Name = "CCD_ORIGEN_DESTINO4" Then
                mCopia.mColumna = dgvDetalle4.Columns(dgvDetalle4.CurrentCell.ColumnIndex).Name
                mCopia.mValue = dgvDetalle4.CurrentCell.Value
                mCopia.mTag = dgvDetalle4.CurrentRow.Cells("ENO_ID_ORIDES4").Value
            End If
        End If
    End Sub

    Private Sub PegarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PegarToolStripMenuItem.Click
        If dgvDetalle.Focused Then
            For Each mCol As DataGridViewColumn In dgvDetalle.Columns
                If mCol.Name = "CCD_ORIGEN_DESTINO" And mCol.Name = mCopia.mColumna Then
                    For Each mRow As DataGridViewRow In dgvDetalle.Rows
                        If mRow.Cells(mCol.Name).Selected Then
                            mRow.Cells(mCol.Name).Value = mCopia.mValue
                            mRow.Cells("ENO_ID_ORIDES").Value = mCopia.mTag
                        End If
                    Next
                End If
            Next

        ElseIf dgvDetalle2.Focused Then
            For Each mCol As DataGridViewColumn In dgvDetalle2.Columns
                If mCol.Name = "CCD_ORIGEN_DESTINO2" And mCol.Name = mCopia.mColumna Then
                    For Each mRow As DataGridViewRow In dgvDetalle2.Rows
                        If mRow.Cells(mCol.Name).Selected Then
                            mRow.Cells(mCol.Name).Value = mCopia.mValue
                            mRow.Cells("ENO_ID_ORIDES2").Value = mCopia.mTag
                        End If
                    Next
                End If
            Next

        ElseIf dgvDetalle3.Focused Then
            For Each mCol As DataGridViewColumn In dgvDetalle3.Columns
                If mCol.Name = "CCD_ORIGEN_DESTINO3" And mCol.Name = mCopia.mColumna Then
                    For Each mRow As DataGridViewRow In dgvDetalle3.Rows
                        If mRow.Cells(mCol.Name).Selected Then
                            mRow.Cells(mCol.Name).Value = mCopia.mValue
                            mRow.Cells("ENO_ID_ORIDES3").Value = mCopia.mTag
                        End If
                    Next
                End If
            Next

        ElseIf dgvDetalle4.Focused Then
            For Each mCol As DataGridViewColumn In dgvDetalle4.Columns
                If mCol.Name = "CCD_ORIGEN_DESTINO4" And mCol.Name = mCopia.mColumna Then
                    For Each mRow As DataGridViewRow In dgvDetalle4.Rows
                        If mRow.Cells(mCol.Name).Selected Then
                            mRow.Cells(mCol.Name).Value = mCopia.mValue
                            mRow.Cells("ENO_ID_ORIDES4").Value = mCopia.mTag
                        End If
                    Next
                End If
            Next

        End If
    End Sub
End Class


