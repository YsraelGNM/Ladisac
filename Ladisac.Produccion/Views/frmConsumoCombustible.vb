Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmConsumoCombustible
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCConsumoCombustible As Ladisac.BL.IBCConsumoCombustible
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro
    <Dependency()> _
    Public Property BCAra As Ladisac.BL.IBCArticuloAlmacen

    Protected mCCO As ConsumoCombustible
    Protected mAra As ArticuloAlmacen

    'ingreso de codigo
    Private Sub frmConsumoCombustible_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()

        '==========================================================================
       
        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 0
        dtpFecha.TabIndex = 1
        txtQuemaHorno.TabIndex = 2
        txtSecadero.TabIndex = 3
        txtArticuloAlmacenTK1.TabIndex = 4

        txtAlmacenTK1.TabIndex = 5
        txtArticuloTK1.TabIndex = 6
        numCantidadTK1.TabIndex = 7
        numSaldoTK1.TabIndex = 8
        txtGlosaTK1.TabIndex = 9

        txtArticuloAlmacenTK2.TabIndex = 10
        txtAlmacenTK2.TabIndex = 11
        txtArticuloTK2.TabIndex = 12
        numCantidadTK2.TabIndex = 13
        numSaldoTK2.TabIndex = 14
        txtGlosaTK2.TabIndex = 15

        txtArticuloAlmacenTK3.TabIndex = 16
        txtAlmacenTK3.TabIndex = 17
        txtArticuloTK3.TabIndex = 18
        numCantidadTK3.TabIndex = 19
        numSaldoTK3.TabIndex = 20
        txtGlosaTK3.TabIndex = 21

        txtArticuloAlmacenTK4.TabIndex = 22
        txtAlmacenTK4.TabIndex = 23
        txtArticuloTK4.TabIndex = 24
        numCantidadTK4.TabIndex = 25
        numSaldoTK4.TabIndex = 26
        txtGlosaTK4.TabIndex = 27
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mCCO = Nothing
        txtCodigo.Text = String.Empty
        txtQuemaHorno.Text = String.Empty
        txtQuemaHorno.Tag = Nothing
        txtSecadero.Text = String.Empty
        txtSecadero.Tag = Nothing
        txtArticuloAlmacenTK1.Text = String.Empty
        txtArticuloAlmacenTK1.Tag = Nothing
        txtArticuloTK1.Text = String.Empty
        txtArticuloTK1.Tag = Nothing
        txtAlmacenTK1.Text = String.Empty
        txtAlmacenTK1.Tag = Nothing
        numStockTK1.Value = 0
        numCantidadTK1.Value = 0
        numSaldoTK1.Value = 0
        txtGlosaTK1.Text = String.Empty

        txtArticuloAlmacenTK2.Text = String.Empty
        txtArticuloAlmacenTK2.Tag = Nothing
        txtArticuloTK2.Text = String.Empty
        txtArticuloTK2.Tag = Nothing
        txtAlmacenTK2.Text = String.Empty
        txtAlmacenTK2.Tag = Nothing
        numStockTK2.Value = 0
        numCantidadTK2.Value = 0
        numSaldoTK2.Value = 0
        txtGlosaTK2.Text = String.Empty

        txtArticuloAlmacenTK3.Text = String.Empty
        txtArticuloAlmacenTK3.Tag = Nothing
        txtArticuloTK3.Text = String.Empty
        txtArticuloTK3.Tag = Nothing
        txtAlmacenTK3.Text = String.Empty
        txtAlmacenTK3.Tag = Nothing
        numStockTK3.Value = 0
        numCantidadTK3.Value = 0
        numSaldoTK3.Value = 0
        txtGlosaTK3.Text = String.Empty

        txtArticuloAlmacenTK4.Text = String.Empty
        txtArticuloAlmacenTK4.Tag = Nothing
        txtArticuloTK4.Text = String.Empty
        txtArticuloTK4.Tag = Nothing
        txtAlmacenTK4.Text = String.Empty
        txtAlmacenTK4.Tag = Nothing
        numStockTK4.Value = 0
        numCantidadTK4.Value = 0
        numSaldoTK4.Value = 0
        txtGlosaTK4.Text = String.Empty

        dtpFecha.Value = Today
        


        '--------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub txtQuemaHorno_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuemaHorno.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ControlQuemaCombustible"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtQuemaHorno.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'COQ_Id
            txtQuemaHorno.Text = frm.dgvLista.CurrentRow.Cells(0).Value & " " & frm.dgvLista.CurrentRow.Cells(1).Value & " " & frm.dgvLista.CurrentRow.Cells(2).Value & " " & frm.dgvLista.CurrentRow.Cells(3).Value 'Nombres
            dtpFecha.Value = frm.dgvLista.CurrentRow.Cells(1).Value
            'limpiar
            txtSecadero.Tag = Nothing
            txtSecadero.Text = String.Empty
            rbtIngreso.Checked = False
            rbtSalida.Checked = False
        End If
        frm.Dispose()
    End Sub

    Private Sub txtSecadero_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSecadero.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "SalidaSecaderoCombustible"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtSecadero.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'SSE_Id
            txtSecadero.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
            'limpiar
            txtQuemaHorno.Tag = Nothing
            txtQuemaHorno.Text = String.Empty
            rbtIngreso.Checked = False
            rbtSalida.Checked = False
        End If
        frm.Dispose()
    End Sub



    Private Sub txtArticuloAlmacenTK1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtArticuloAlmacenTK1.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ArticuloAlmacen"
        If rbtR500.Checked Then
            frm.Arti_Id = BCParametro.ParametroGetById("R500").PAR_VALOR1  '"001435" 'Codigo Arti_Id del R-500
        Else
            frm.Arti_Id = BCParametro.ParametroGetById("GAS").PAR_VALOR1  '"020946" 'Codigo Arti_Id del Gas
        End If
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtArticuloAlmacenTK1.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtArticuloAlmacenTK1.Text = frm.dgvLista.CurrentRow.Cells(0).Value
            'CType(sender, TextBox).Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ARA_Id
            'CType(sender, TextBox).Text = frm.dgvLista.CurrentRow.Cells(0).Value 'ARA_Id
            txtArticuloTK1.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'ART_Descripcion
            txtAlmacenTK1.Text = frm.dgvLista.CurrentRow.Cells(3).Value 'ALM_Descripcion
            numStockTK1.Value = frm.dgvLista.CurrentRow.Cells(5).Value 'Stock

        End If
        frm.Dispose()
    End Sub
    Private Sub txtArticuloAlmacenTK2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtArticuloAlmacenTK2.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ArticuloAlmacen"
        If rbtR500.Checked Then
            frm.Arti_Id = BCParametro.ParametroGetById("R500").PAR_VALOR1  '"001435" 'Codigo Arti_Id del R-500
        Else
            frm.Arti_Id = BCParametro.ParametroGetById("GAS").PAR_VALOR1  '"020946" 'Codigo Arti_Id del Gas
        End If
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtArticuloAlmacenTK2.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtArticuloAlmacenTK2.Text = frm.dgvLista.CurrentRow.Cells(0).Value
            'CType(sender, TextBox).Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ARA_Id
            'CType(sender, TextBox).Text = frm.dgvLista.CurrentRow.Cells(0).Value 'ARA_Id
            
            txtArticuloTK2.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'ART_Descripcion
            txtAlmacenTK2.Text = frm.dgvLista.CurrentRow.Cells(3).Value 'ALM_Descripcion
                    numStockTK2.Value = frm.dgvLista.CurrentRow.Cells(5).Value 'Stock
               
        End If
        frm.Dispose()
    End Sub
    Private Sub txtArticuloAlmacenTK3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtArticuloAlmacenTK3.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ArticuloAlmacen"
        If rbtR500.Checked Then
            frm.Arti_Id = BCParametro.ParametroGetById("R500").PAR_VALOR1  '"001435" 'Codigo Arti_Id del R-500
        Else
            frm.Arti_Id = BCParametro.ParametroGetById("GAS").PAR_VALOR1  '"020946" 'Codigo Arti_Id del Gas
        End If
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtArticuloAlmacenTK3.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtArticuloAlmacenTK3.Text = frm.dgvLista.CurrentRow.Cells(0).Value
            'CType(sender, TextBox).Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ARA_Id
            'CType(sender, TextBox).Text = frm.dgvLista.CurrentRow.Cells(0).Value 'ARA_Id

            txtArticuloTK3.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'ART_Descripcion
            txtAlmacenTK3.Text = frm.dgvLista.CurrentRow.Cells(3).Value 'ALM_Descripcion
            numStockTK3.Value = frm.dgvLista.CurrentRow.Cells(5).Value 'Stock

        End If
        frm.Dispose()
    End Sub
    Private Sub txtArticuloAlmacenTK4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtArticuloAlmacenTK4.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ArticuloAlmacen"
        If rbtR500.Checked Then
            frm.Arti_Id = BCParametro.ParametroGetById("R500").PAR_VALOR1  '"001435" 'Codigo Arti_Id del R-500
        Else
            frm.Arti_Id = BCParametro.ParametroGetById("GAS").PAR_VALOR1  '"020946" 'Codigo Arti_Id del Gas
        End If
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtArticuloAlmacenTK4.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtArticuloAlmacenTK4.Text = frm.dgvLista.CurrentRow.Cells(0).Value
            'CType(sender, TextBox).Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ARA_Id
            'CType(sender, TextBox).Text = frm.dgvLista.CurrentRow.Cells(0).Value 'ARA_Id

            txtArticuloTK4.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'ART_Descripcion
            txtAlmacenTK4.Text = frm.dgvLista.CurrentRow.Cells(3).Value 'ALM_Descripcion
                    numStockTK4.Value = frm.dgvLista.CurrentRow.Cells(5).Value 'Stock

        End If
        frm.Dispose()
    End Sub


    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------

        If mCCO IsNot Nothing Then

            For Cont As Integer = 1 To 4
                Select Case Cont
                    Case 1 And numCantidadTK1.Value > 0
                        If Not mCCO.CCO_ID > 0 Then
                            mCCO = New ConsumoCombustible
                            mCCO.MarkAsAdded()
                            If txtQuemaHorno.Tag Is Nothing Then mCCO.COQ_ID = Nothing Else mCCO.COQ_ID = CInt(txtQuemaHorno.Tag)
                            If txtSecadero.Tag Is Nothing Then mCCO.SSE_ID = Nothing Else mCCO.SSE_ID = CInt(txtSecadero.Tag)
                            mCCO.CCO_INGRESO_SALIDA = IIf(rbtIngreso.Checked, True, IIf(rbtSalida.Checked, False, Nothing))
                            mCCO.CCO_FECHA = dtpFecha.Value
                            mCCO.ARA_ID = CInt(txtArticuloAlmacenTK1.Tag)
                            mAra = BCAra.ArticuloAlmacenGetById(mCCO.ARA_ID)
                            mCCO.ALM_ID = mAra.ALM_ID
                            mCCO.ART_ID = mAra.ART_ID
                            mCCO.CCO_CANTIDAD = numCantidadTK1.Value
                            mCCO.CCO_GLOSA = txtGlosaTK1.Text
                            mCCO.CCO_ESTADO = True
                            mCCO.CCO_FEC_GRAB = Now
                            mCCO.USU_ID = SessionServer.UserId

                        Else

                            If txtQuemaHorno.Tag Is Nothing Then mCCO.COQ_ID = Nothing Else mCCO.COQ_ID = CInt(txtQuemaHorno.Tag)
                            If txtSecadero.Tag Is Nothing Then mCCO.SSE_ID = Nothing Else mCCO.SSE_ID = CInt(txtSecadero.Tag)
                            mCCO.CCO_INGRESO_SALIDA = IIf(rbtIngreso.Checked, True, IIf(rbtSalida.Checked, False, Nothing))
                            mCCO.CCO_FECHA = dtpFecha.Value
                            mCCO.ARA_ID = CInt(txtArticuloAlmacenTK1.Tag)
                            mAra = BCAra.ArticuloAlmacenGetById(mCCO.ARA_ID)
                            mCCO.ALM_ID = mAra.ALM_ID
                            mCCO.ART_ID = mAra.ART_ID
                            mCCO.CCO_CANTIDAD = numCantidadTK1.Value
                            mCCO.CCO_GLOSA = txtGlosaTK1.Text
                            mCCO.CCO_ESTADO = True
                            mCCO.CCO_FEC_GRAB = Now
                            mCCO.USU_ID = SessionServer.UserId
                        End If

                        BCConsumoCombustible.MantenimientoConsumoCombustible(mCCO)

                    Case 2 And numCantidadTK2.Value > 0
                        mCCO = New ConsumoCombustible
                        mCCO.MarkAsAdded()
                        If txtQuemaHorno.Tag Is Nothing Then mCCO.COQ_ID = Nothing Else mCCO.COQ_ID = CInt(txtQuemaHorno.Tag)
                        If txtSecadero.Tag Is Nothing Then mCCO.SSE_ID = Nothing Else mCCO.SSE_ID = CInt(txtSecadero.Tag)
                        mCCO.CCO_INGRESO_SALIDA = IIf(rbtIngreso.Checked, True, IIf(rbtSalida.Checked, False, Nothing))
                        mCCO.CCO_FECHA = dtpFecha.Value
                        mCCO.ARA_ID = CInt(txtArticuloAlmacenTK2.Tag)
                        mAra = BCAra.ArticuloAlmacenGetById(mCCO.ARA_ID)
                        mCCO.ALM_ID = mAra.ALM_ID
                        mCCO.ART_ID = mAra.ART_ID
                        mCCO.CCO_CANTIDAD = numCantidadTK2.Value
                        mCCO.CCO_GLOSA = txtGlosaTK2.Text
                        mCCO.CCO_ESTADO = True
                        mCCO.CCO_FEC_GRAB = Now
                        mCCO.USU_ID = SessionServer.UserId
                        BCConsumoCombustible.MantenimientoConsumoCombustible(mCCO)

                    Case 3 And numCantidadTK3.Value > 0
                        mCCO = New ConsumoCombustible
                        mCCO.MarkAsAdded()
                        If txtQuemaHorno.Tag Is Nothing Then mCCO.COQ_ID = Nothing Else mCCO.COQ_ID = CInt(txtQuemaHorno.Tag)
                        If txtSecadero.Tag Is Nothing Then mCCO.SSE_ID = Nothing Else mCCO.SSE_ID = CInt(txtSecadero.Tag)
                        mCCO.CCO_INGRESO_SALIDA = IIf(rbtIngreso.Checked, True, IIf(rbtSalida.Checked, False, Nothing))
                        mCCO.CCO_FECHA = dtpFecha.Value
                        mCCO.ARA_ID = CInt(txtArticuloAlmacenTK3.Tag)
                        mAra = BCAra.ArticuloAlmacenGetById(mCCO.ARA_ID)
                        mCCO.ALM_ID = mAra.ALM_ID
                        mCCO.ART_ID = mAra.ART_ID
                        mCCO.CCO_CANTIDAD = numCantidadTK3.Value
                        mCCO.CCO_GLOSA = txtGlosaTK3.Text
                        mCCO.CCO_ESTADO = True
                        mCCO.CCO_FEC_GRAB = Now
                        mCCO.USU_ID = SessionServer.UserId
                        BCConsumoCombustible.MantenimientoConsumoCombustible(mCCO)

                    Case 4 And numCantidadTK4.Value > 0
                        mCCO = New ConsumoCombustible
                        mCCO.MarkAsAdded()
                        If txtQuemaHorno.Tag Is Nothing Then mCCO.COQ_ID = Nothing Else mCCO.COQ_ID = CInt(txtQuemaHorno.Tag)
                        If txtSecadero.Tag Is Nothing Then mCCO.SSE_ID = Nothing Else mCCO.SSE_ID = CInt(txtSecadero.Tag)
                        mCCO.CCO_INGRESO_SALIDA = IIf(rbtIngreso.Checked, True, IIf(rbtSalida.Checked, False, Nothing))
                        mCCO.CCO_FECHA = dtpFecha.Value
                        mCCO.ARA_ID = CInt(txtArticuloAlmacenTK4.Tag)
                        mAra = BCAra.ArticuloAlmacenGetById(mCCO.ARA_ID)
                        mCCO.ALM_ID = mAra.ALM_ID
                        mCCO.ART_ID = mAra.ART_ID
                        mCCO.CCO_CANTIDAD = numCantidadTK4.Value
                        mCCO.CCO_GLOSA = txtGlosaTK4.Text
                        mCCO.CCO_ESTADO = True
                        mCCO.CCO_FEC_GRAB = Now
                        mCCO.USU_ID = SessionServer.UserId
                        BCConsumoCombustible.MantenimientoConsumoCombustible(mCCO)
                End Select
            Next

            LimpiarControles()
        End If


        '------------------------------------------
        Call validacion_desactivacion(False, 3)

    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mCCO = New ConsumoCombustible
        mCCO.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtQuemaHorno.Focus()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ConsumoCombustible"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarConsumoCombustible(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarConsumoCombustible(ByVal CCO_Id As Integer)
        mCCO = BCConsumoCombustible.ConsumoCombustibleGetById(CCO_Id)
        mCCO.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mCCO.CCO_ID
        dtpFecha.Value = mCCO.CCO_FECHA
        txtQuemaHorno.Text = mCCO.COQ_ID
        txtQuemaHorno.Tag = mCCO.COQ_ID
        txtSecadero.Text = mCCO.SSE_ID
        txtSecadero.Tag = mCCO.SSE_ID
        If mCCO.CCO_INGRESO_SALIDA Then
            rbtIngreso.Checked = True
            rbtSalida.Checked = False
        Else
            rbtIngreso.Checked = False
            rbtSalida.Checked = True
        End If
        txtArticuloAlmacenTK1.Text = mCCO.ARA_ID
        txtArticuloAlmacenTK1.Tag = mCCO.ARA_ID
        txtAlmacenTK1.Text = mCCO.ALM_ID
        txtAlmacenTK1.Tag = mCCO.ALM_ID
        txtArticuloTK1.Text = mCCO.ART_ID
        txtArticuloTK1.Tag = mCCO.ART_ID
        numCantidadTK1.Value = mCCO.CCO_CANTIDAD
        txtGlosaTK1.Text = mCCO.CCO_GLOSA
    End Sub

    '===================================================================================================================
    '----procedimiento de validaciones
    'tecla enter de paso rapido entre cajas de texto.

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(dtpFecha.Text.Trim) = 0 Then Error_validacion.SetError(dtpFecha, "Ingrese la Fecha ") : dtpFecha.Focus() : flag = False
        'If Len(txtQuemaHorno.Text.Trim) = 0 Then Error_validacion.SetError(txtQuemaHorno, "Ingrese el Nombre de Quema Horno") : txtQuemaHorno.Focus() : flag = False
        'If Len(txtSecadero.Text.Trim) = 0 Then Error_validacion.SetError(txtSecadero, "Ingrese el Nombre del Secadero") : txtSecadero.Focus() : flag = False
        If Len(txtArticuloAlmacenTK1.Text.Trim) = 0 Then Error_validacion.SetError(txtArticuloAlmacenTK1, "Ingrese el Nombre del Articulo Almacen") : txtArticuloAlmacenTK1.Focus() : flag = False
        If Len(txtAlmacenTK1.Text.Trim) = 0 Then Error_validacion.SetError(txtAlmacenTK1, "Ingrese el Nombre del Almacen") : txtAlmacenTK1.Focus() : flag = False
        If Len(txtArticuloTK1.Text.Trim) = 0 Then Error_validacion.SetError(txtArticuloTK1, "Ingrese el Nomber del Articulo") : txtArticuloTK1.Focus() : flag = False
        If Len(numCantidadTK1.Text.Trim) = 0 Then Error_validacion.SetError(numCantidadTK1, "Ingrese la Cantidad") : numCantidadTK1.Focus() : flag = False
        If Len(txtGlosaTK1.Text.Trim) = 0 Then Error_validacion.SetError(txtGlosaTK1, "Ingrese la Glosa") : txtGlosaTK1.Focus() : flag = False



        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos.
    Private Sub validar_longitud()
        Me.txtQuemaHorno.MaxLength = 100
        Me.txtSecadero.MaxLength = 100
        'Me.txtArticuloAlmacen.MaxLength = 100
        Me.txtAlmacenTK1.MaxLength = 160
        Me.txtArticuloTK1.MaxLength = 160
        Me.numCantidadTK1.Maximum = 999999999999999 : Me.numCantidadTK1.DecimalPlaces = 3
        Me.txtGlosaTK1.MaxLength = 255
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
        If mCCO IsNot Nothing Then
            If MessageBox.Show("Seguro de Eliminar el Consumo Combustible?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = vbOK Then
                mCCO.MarkAsDeleted()
                BCConsumoCombustible.MantenimientoConsumoCombustible(mCCO)
            End If
        End If

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

    Private Sub numCantidadTK1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles numCantidadTK1.Enter, _
                                                                                                    numCantidadTK2.Enter, _
                                                                                                    numCantidadTK3.Enter, _
                                                                                                    numCantidadTK4.Enter, _
                                                                                                    numSaldoTK1.Enter, _
                                                                                                    numSaldoTK2.Enter, _
                                                                                                    numSaldoTK3.Enter, _
                                                                                                    numSaldoTK4.Enter, _
                                                                                                    numStockTK1.Enter, _
                                                                                                    numStockTK2.Enter, _
                                                                                                    numStockTK3.Enter, _
                                                                                                    numStockTK4.Enter
        sender.Select(0, sender.Text.ToString.Length)
    End Sub

    Private Sub numCantidadTK1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles numCantidadTK1.ValueChanged, numCantidadTK2.ValueChanged, numCantidadTK3.ValueChanged, numCantidadTK4.ValueChanged
        If CType(sender, NumericUpDown).Value > 0 Then
            Select Case CType(sender, NumericUpDown).Name
                Case "numCantidadTK1"
                    numSaldoTK1.Value = numStockTK1.Value - CType(sender, NumericUpDown).Value
                Case "numCantidadTK2"
                    numSaldoTK2.Value = numStockTK2.Value - CType(sender, NumericUpDown).Value
                Case "numCantidadTK3"
                    numSaldoTK3.Value = numStockTK3.Value - CType(sender, NumericUpDown).Value
                Case "numCantidadTK4"
                    numSaldoTK4.Value = numStockTK4.Value - CType(sender, NumericUpDown).Value
            End Select
        End If
    End Sub

    Private Sub txtQuemaHorno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQuemaHorno.KeyDown
        If e.KeyCode = Keys.Enter Then txtQuemaHorno_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtSecadero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSecadero.KeyDown
        If e.KeyCode = Keys.Enter Then txtSecadero_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtArticuloAlmacenTK1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArticuloAlmacenTK1.KeyDown
        If e.KeyCode = Keys.Enter Then txtArticuloAlmacenTK1_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtArticuloAlmacenTK2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArticuloAlmacenTK2.KeyDown
        If e.KeyCode = Keys.Enter Then txtArticuloAlmacenTK2_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtArticuloAlmacenTK3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArticuloAlmacenTK3.KeyDown
        If e.KeyCode = Keys.Enter Then txtArticuloAlmacenTK3_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtArticuloAlmacenTK4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArticuloAlmacenTK4.KeyDown
        If e.KeyCode = Keys.Enter Then txtArticuloAlmacenTK4_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub rbtIngreso_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtIngreso.CheckedChanged
        If rbtIngreso.Checked Then
            'limpiar
            txtSecadero.Tag = Nothing
            txtSecadero.Text = String.Empty
            txtQuemaHorno.Tag = Nothing
            txtQuemaHorno.Text = String.Empty
            rbtSalida.Checked = False
        End If
    End Sub

    Private Sub rbtSalida_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtSalida.CheckedChanged
        If rbtSalida.Checked Then
            'limpiar
            txtSecadero.Tag = Nothing
            txtSecadero.Text = String.Empty
            txtQuemaHorno.Tag = Nothing
            txtQuemaHorno.Text = String.Empty
            rbtIngreso.Checked = False
        End If
    End Sub
End Class
