Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmSalidaCombustible
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCSalidaCombustible As Ladisac.BL.IBCSalidaCombustible
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCTipoDocumento As Ladisac.BL.IBCTipoDocumento
    <Dependency()> _
    Public Property BCArticuloAlmacen As Ladisac.BL.IBCArticuloAlmacen
    <Dependency()> _
    Public Property BCOrdenRequerimiento As Ladisac.BL.IBCOrdenRequerimiento
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro
    <Dependency()> _
    Public Property BCMaestro As Ladisac.BL.IBCMaestro
    <Dependency()> _
    Public Property BCControlGrifo As Ladisac.BL.IBCControlGrifo
    <Dependency()> _
    Public Property BCUnidadestransporte As Ladisac.BL.IBCUnidadesTransporte
    <Dependency()>
    Public Property BCPermisoUsuario As Ladisac.BL.BCPermisoUsuario

    Protected mSC As SalidaCombustible
    Protected mArticuloAlmacen As ArticuloAlmacen
    Protected mOR As OrdenRequerimiento
    Private Compuesto1 As New Ladisac.BE.DetalleDocumentos

    Dim mNuevaPag As Integer
    Dim mIndexItem As Integer
    Dim mCantLinea As Integer

    Dim MessageId, Codigo, Tipo As String
    Dim Id_Grifo As Integer

    Private Sub frmSalidaCombustible_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarTipoDocumento()
        LimpiarControles()


        'se llama al procedimiento de paso rapido entre cajas de texto.
      
        Me.cboTipoDocumento.TabIndex = 0
        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 13
        txtPlaca.TabIndex = 1
        txtEmpresa.TabIndex = 2
        txtChofer.TabIndex = 3
        numCantidad.TabIndex = 4
        numKilometraje.TabIndex = 5
        numHorometro.TabIndex = 6
        txtObservacion.TabIndex = 7
        dtpFecha.TabIndex = 8
        txtAlmacen.TabIndex = 9
        txtOR.TabIndex = 10
        txtStock.TabIndex = 11
        txtPU.TabIndex = 12

        Timer1.Interval = 1000 * 5 '5 SEGUNDOS
        Timer1.Start()
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mSC = Nothing
        Id_Grifo = 0
        txtCodigo.Text = String.Empty
        cboTipoDocumento.SelectedIndex = -1
        txtPlaca.Text = String.Empty
        txtPlaca.Tag = Nothing
        txtAlmacen.Text = String.Empty
        txtAlmacen.Tag = Nothing
        txtOR.Text = String.Empty
        txtOR.Tag = Nothing
        txtEmpresa.Text = String.Empty
        txtChofer.Text = String.Empty
        numCantidad.Value = 0
        numKilometraje.Value = 0
        numHorometro.Value = 0
        dtpFecha.Value = Now
        txtObservacion.Text = String.Empty
        txtPU.Text = String.Empty
        txtStock.Text = String.Empty

        '--------------------------
        Error_validacion.Clear()
    End Sub

    Sub CargarTipoDocumento()
        Dim ds As New DataSet
        Dim query = BCTipoDocumento.ListaDetalleTipoDocumentoSalidaCombustible
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboTipoDocumento
            .DisplayMember = "DTD_Descripcion"
            .ValueMember = "Codigo"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    Private Sub txtPlaca_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlaca.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "UnidadesTransporteSalidaCombustible"
        frm.Tipo = txtPlaca.Text
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPlaca.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Unt_Id
            txtPlaca.Text = frm.dgvLista.CurrentRow.Cells(0).Value 'Unt_Id
            txtOR.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Orr
            txtOR.Tag = frm.dgvLista.CurrentRow.Cells(4).Value 'Ord
            txtEmpresa.Tag = frm.dgvLista.CurrentRow.Cells(3).Value 'Pers_Id
            txtEmpresa.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Empresa

            For Each mDoc In cboTipoDocumento.Items
                If mDoc(0).ToString.Substring(0, 3) = BCParametro.ParametroGetById("DTD_FACT_VENTA").PAR_VALOR1 Then 'Factura
                    cboTipoDocumento.SelectedItem = mDoc
                    Exit For
                End If
            Next

        End If
        frm.Dispose()
    End Sub

    Private Sub txtChofer_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChofer.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        If cboTipoDocumento.SelectedIndex = 0 Then 'Ticket Factura
            frm.Tabla = "Persona"
            frm.Tipo = "Chofer"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtChofer.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                txtChofer.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombre
            End If
        Else 'O.R.
            frm.Tabla = "Persona"
            frm.Tipo = "Trabajador"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtChofer.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                txtChofer.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombre
            End If
        End If
        
        frm.Dispose()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mSC = New SalidaCombustible
        mSC.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        Me.cboTipoDocumento.Focus()

    End Sub

    Private Function BuscarSeries() As Boolean
        If mSC IsNot Nothing Then
            If mSC.ChangeTracker.State = ObjectState.Added Then
                Compuesto1.Vista = "BuscarCorrelativos"
                Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()

                Dim ds As New DataSet
                Dim sr As New StringReader(BCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                    "002", _
                                                                    cboTipoDocumento.SelectedValue.ToString.Substring(3, 3), _
                                                                    cboTipoDocumento.SelectedValue.ToString.Substring(0, 3), _
                                                                    Nothing, _
                                                                    ""
                                                                   )
                                          )

                Dim vcontrol As Int16 = sr.Peek
                If vcontrol <> -1 Then
                    ds.ReadXml(sr)
                    For Each mFac In ds.Tables(0).Rows
                        If mFac.Item("CTD_COR_SERIE") = "F05" Then
                            mSC.SCO_SERIE = mFac.Item("CTD_COR_SERIE")
                            mSC.SCO_NUMERO = mFac.Item("CTD_COR_NUMERO")
                            Return True
                            Exit For
                        End If
                    Next
                Else
                    Return False
                End If
            Else
                Return True
            End If
        Else
            Return False
        End If

    End Function

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------
        If mSC IsNot Nothing Then
            mSC.SCO_FECHA = dtpFecha.Value
            mSC.DTD_ID = cboTipoDocumento.SelectedValue.ToString.Substring(0, 3)
            mSC.TDO_ID = cboTipoDocumento.SelectedValue.ToString.Substring(3, 3)
            If cboTipoDocumento.SelectedValue.ToString.Length = 9 Then mSC.CCT_ID = cboTipoDocumento.SelectedValue.ToString.Substring(6, 3) Else mSC.CCT_ID = ""
            mSC.DetalleTipoDocumentos = cboTipoDocumento.Tag
            mSC.UNT_ID = IIf(txtPlaca.Text.Length = 0, Nothing, txtPlaca.Text)
            mSC.PER_ID_EMPRESA = txtEmpresa.Tag
            mSC.PER_ID_CHOFER = txtChofer.Tag
            mSC.ART_ID = BCParametro.ParametroGetById("Diesel").PAR_VALOR1 'Diesel
            mSC.ALM_ID = txtAlmacen.Tag
            mSC.ORR_ID = CInt(txtOR.Text)
            mSC.ORD_ID = CInt(txtOR.Tag)
            mSC.SCO_CANTIDAD = numCantidad.Value
            mSC.SCO_PRECIO_UNITARIO = txtPU.Text
            mSC.IGV = SessionServer.IGV
            mSC.SCO_KILOMETRAJE = numKilometraje.Value
            mSC.SCO_HOROMETRO = numHorometro.Value
            mSC.SCO_OBSERVACION = txtObservacion.Text & " /" & MessageId & "/"
            mSC.MessageId = MessageId
            mSC.Id_Grifo = Id_Grifo
            mSC.SCO_ESTADO = True
            mSC.SCO_FEC_GRAB = Now
            mSC.USU_ID = SessionServer.UserId
            mSC.SCO_SERIE_SUNAT = IIf((mSC.SCO_SERIE & "").ToString.Contains("F"), "F005", Nothing)
            BCSalidaCombustible.MantenimientoSalidaCombustible(mSC)
            MessageBox.Show(mSC.SCO_ID)
            mSC = BCSalidaCombustible.SalidaCombustibleGetById(mSC.SCO_ID)
            OnReportes()
            LimpiarControles()

            '------------------------------------------
            Call validacion_desactivacion(False, 3)
            Timer1.Start()
        End If
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "SalidaCombustible"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarSalidaCombustible(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarSalidaCombustible(ByVal OCO_Id As Integer)
        mSC = BCSalidaCombustible.SalidaCombustibleGetById(OCO_Id)
        mSC.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mSC.SCO_ID
        dtpFecha.Value = mSC.SCO_FECHA
        cboTipoDocumento.SelectedValue = mSC.DTD_ID & mSC.TDO_ID & mSC.CCT_ID
        txtPlaca.Text = mSC.UNT_ID
        txtPlaca.Tag = mSC.UNT_ID
        txtEmpresa.Text = mSC.Personas.PER_APE_PAT
        txtEmpresa.Tag = mSC.PER_ID_EMPRESA
        txtChofer.Text = mSC.Personas1.PER_APE_PAT
        txtChofer.Tag = mSC.PER_ID_CHOFER
        numCantidad.Value = mSC.SCO_CANTIDAD
        txtPU.Text = mSC.SCO_PRECIO_UNITARIO
        txtAlmacen.Text = mSC.Almacen.ALM_DESCRIPCION
        txtOR.Text = mSC.ORR_ID.ToString
        txtOR.Tag = mSC.ORD_ID.ToString
        txtAlmacen.Tag = mSC.Almacen.ALM_ID
        numKilometraje.Value = mSC.SCO_KILOMETRAJE
        numHorometro.Value = mSC.SCO_HOROMETRO
        txtObservacion.Text = mSC.SCO_OBSERVACION
    End Sub

    Private Sub txtAlmacen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAlmacen.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "ArticuloAlmacen"
        frm.Art_Id = BCParametro.ParametroGetById("Diesel").PAR_VALOR1 'Diesel
        frm.Alm_Id = Nothing
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If frm.dgvLista.CurrentRow.Cells(0).Value = 1405 Then 'Solo va a escoger el diesel de almacen principal
                CargarArticuloAlmacen(frm.dgvLista.CurrentRow.Cells(0).Value)
                txtAlmacen.Tag = mArticuloAlmacen.ALM_ID  'ALM_Id
                txtAlmacen.Text = frm.dgvLista.CurrentRow.Cells(3).Value 'ALM_Descripcion
                txtStock.Text = frm.dgvLista.CurrentRow.Cells(5).Value  'Stock
                txtPU.Text = frm.dgvLista.CurrentRow.Cells(6).Value  'Precio Unitario
            End If
        End If
    End Sub

    Sub CargarArticuloAlmacen(ByVal ARA_Id As Integer)
        mArticuloAlmacen = BCArticuloAlmacen.ArticuloAlmacenGetById(ARA_Id)
    End Sub

    Sub CargarOrdenRequerimiento(ByVal ORR_Id As Integer)
        mOR = BCOrdenRequerimiento.OrdenRequerimientoGetById(ORR_Id)
        mOR.MarkAsModified()
    End Sub

    Private Sub txtOR_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOR.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "OrdenRequerimientoSalidaCombustible"
        frm.Tipo = IIf(txtOR.Text.Length = 0, 0, txtOR.Text)
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarOrdenRequerimiento(key)
            'txtSerie.Text = "10"
            'txtNumero.Text = mOR.ORR_ID
            'dtpFechaDoc.Value = mOR.ORR_FECHA
            txtOR.Text = mOR.ORR_ID

            txtOR.Tag = frm.dgvLista.CurrentRow.Cells("ORD_ID").Value

            For Each mFila In mOR.OrdenRequerimientoDetalle
                If mFila.ORD_ID = frm.dgvLista.CurrentRow.Cells("ORD_ID").Value Then
                    If mFila.OrdenTrabajo.Entidad.UnidadesTransporte IsNot Nothing Then
                        txtPlaca.Text = mFila.OrdenTrabajo.Entidad.UnidadesTransporte.UNT_ID
                        txtEmpresa.Text = mFila.OrdenTrabajo.Entidad.UnidadesTransporte.Personas.PER_APE_PAT
                        txtEmpresa.Tag = mFila.OrdenTrabajo.Entidad.UnidadesTransporte.PER_ID
                        'Else
                        '    MessageBox.Show("Falta relacionar Placa en Entidad.")
                        '    LimpiarControles()
                        '    Call validacion_desactivacion(False, 3)
                        '    Exit Sub
                    Else
                        txtEmpresa.Text = SessionServer.NombreEmpresa
                        txtEmpresa.Tag = BCParametro.ParametroGetById("PerIdEmpresa").PAR_VALOR1
                    End If
                    Exit For
                End If
            Next

            For Each mDoc In cboTipoDocumento.Items
                If mDoc(0).ToString.Substring(0, 3) = BCParametro.ParametroGetById("DTD_OR").PAR_VALOR1 Then 'Orden Requerimiento
                    cboTipoDocumento.SelectedItem = mDoc
                    Exit For
                End If
            Next

            'cboMoneda.SelectedIndex = 0
            'chkAfectaKardex.Checked = True

            'For Each mItem In mOR.OrdenRequerimientoDetalle
            '    If (mItem.ORD_CANTIDAD - mItem.ORD_CANTIDAD_ATENDIDA) > 0 Then
            '        Dim nRow As New DataGridViewRow
            '        dgvDetalle.Rows.Add(nRow)
            '        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DMD_ID").Value = mItem.DMD_ID
            '        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DMD_ID").Tag = mItem
            '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Art_Id").Value = mItem.Articulos.ART_Codigo & " - " & mItem.Articulos.ART_DESCRIPCION
            '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Art_Id").Tag = mItem.ART_ID
            '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value = mItem.ORD_CANTIDAD - mItem.ORD_CANTIDAD_ATENDIDA
            '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("UM").Value = mItem.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
            '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ORD_ID").Tag = mItem.ORD_ID
            '        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value = mItem.DMD_PRECIO_UNITARIO
            '        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Descuento").Value = mItem.DMD_DESCUENTO

            '        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value - _
            '        '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value * (dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Descuento").Value / 100)
            '        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IGV").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value * (txtIGV.Text / 100)
            '        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Total").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value + dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IGV").Value

            '        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Glosa").Value = mItem.ORD_OBSERVACION
            '        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ALM_Id").Value = mItem.Almacen.ALM_DESCRIPCION
            '        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ALM_Id").Tag = mItem.ALM_ID
            '    End If
            'Next
        End If
        frm.Dispose()
    End Sub

    Private Sub cboTipoDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoDocumento.SelectedIndexChanged
        If mSC IsNot Nothing Then
            If cboTipoDocumento.SelectedIndex > -1 Then cboTipoDocumento.Tag = BCTipoDocumento.TipoDocumentoGetById(cboTipoDocumento.SelectedValue.ToString.Substring(0, 3))
        End If
    End Sub


    '===================================================================================================================
    '----procedimiento de validaciones
    'tecla enter de paso rapido entre cajas de texto.
  

 

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(cboTipoDocumento.Text.Trim) = 0 Then Error_validacion.SetError(cboTipoDocumento, "Ingrese el Tipo de Documento") : cboTipoDocumento.Focus() : flag = False
        If Len(txtEmpresa.Tag.Trim) = 0 Then Error_validacion.SetError(txtEmpresa, "Ingrese el Nombre de la Empresa") : txtEmpresa.Focus() : flag = False
        If Len(txtChofer.Tag.Trim) = 0 Then Error_validacion.SetError(txtChofer, "Ingrese el Nombre del Chofer") : txtChofer.Focus() : flag = False
        If Len(numCantidad.Text.Trim) = 0 Or numCantidad.Value = 0 Then Error_validacion.SetError(numCantidad, "Ingrese la Cantidad") : numCantidad.Focus() : flag = False
        If Len(numKilometraje.Text.Trim) = 0 Then Error_validacion.SetError(numKilometraje, "Ingrese el Numero del Kilometraje") : numKilometraje.Focus() : flag = False
        If Len(numHorometro.Text.Trim) = 0 Then Error_validacion.SetError(numHorometro, "Ingrese el Numero de Horometro") : numHorometro.Focus() : flag = False
        If Len(txtObservacion.Text.Trim) = 0 Then Error_validacion.SetError(txtObservacion, "Ingrese la Observacion") : txtObservacion.Focus() : flag = False
        If Len(txtAlmacen.Text.Trim) = 0 Then Error_validacion.SetError(txtAlmacen, "Ingrese el Nombre del Almacen") : txtAlmacen.Focus() : flag = False
        If Len(txtOR.Text.Trim) = 0 Then Error_validacion.SetError(txtOR, "Ingrese el Orden de Requerimiento") : txtOR.Focus() : flag = False
        If mSC.ChangeTracker.State = ObjectState.Added Then If (Len(txtStock.Text.Trim) = 0 Or CDbl(txtStock.Text) = 0) Then Error_validacion.SetError(txtStock, "Ingrese el Stock") : txtStock.Focus() : flag = False
        If mSC.ChangeTracker.State = ObjectState.Added Then If (Len(txtPU.Text.Trim) = 0 Or CDbl(txtPU.Text) = 0) Then Error_validacion.SetError(txtPU, "Ingrese el Precio Unitario") : txtPU.Focus() : flag = False

        If Not CType(cboTipoDocumento.Tag, DetalleTipoDocumentos).DTD_ID = BCParametro.ParametroGetById("DTD_OR").PAR_VALOR1 Then
            If Len(txtPlaca.Text.Trim) = 0 Then Error_validacion.SetError(txtPlaca, "Ingrese el Numero de la Placa") : txtPlaca.Focus() : flag = False
            If BuscarSeries() = False Then Error_validacion.SetError(txtPlaca, "No se puede encontrar Serie y Numero") : flag = False
        End If

        If CType(cboTipoDocumento.Tag, DetalleTipoDocumentos).DTD_ID = BCParametro.ParametroGetById("DTD_FACT_VENTA").PAR_VALOR1 And mSC.ChangeTracker.State = ObjectState.Modified Then
            Error_validacion.SetError(txtPlaca, "No se puede modificar una Factura") : txtPlaca.Focus() : flag = False
       End If

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos.
    Private Sub validar_longitud()
        Me.cboTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList
        txtPlaca.MaxLength = 8
        txtEmpresa.MaxLength = 160
        txtChofer.MaxLength = 160
        numCantidad.Maximum = 999999999999999 : numCantidad.DecimalPlaces = 3
        numKilometraje.Maximum = 999999999999999 : numKilometraje.DecimalPlaces = 3
        numHorometro.Maximum = 999999999999999 : numHorometro.DecimalPlaces = 3
        txtObservacion.MaxLength = 255
        txtAlmacen.MaxLength = 160
        'txtOR.MaxLength = 10
        txtStock.MaxLength = 10
        txtPU.MaxLength = 10

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
        If mSC IsNot Nothing Then 'NO SE PUEDE BORRAR PORQUE TIENE REFERENCIAS A FINANZAS Y QUEDARIA AL AIRE
            mSC.MarkAsDeleted()
            BCSalidaCombustible.MantenimientoSalidaCombustible(mSC)
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
            Me.tsbReportes.Enabled = op

        End If
    End Sub

    Private Sub txtPlaca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlaca.KeyDown
        If e.KeyCode = Keys.Enter Then txtPlaca_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtChofer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChofer.KeyDown
        If e.KeyCode = Keys.Enter Then txtChofer_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAlmacen.KeyDown
        If e.KeyCode = Keys.Enter Then txtAlmacen_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtOR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOR.KeyDown
        If e.KeyCode = Keys.Enter Then txtOR_DoubleClick(Nothing, Nothing)
    End Sub

    Public Overrides Sub OnReportes()
        If mSC IsNot Nothing Then
            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    mNuevaPag = 0
                    mIndexItem = 0
                    mCantLinea = 20

                    Dim pkCustomSize1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 340, 750)
                    PrintDocument1.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1
                    PrintDocument1.DefaultPageSettings.PaperSize = pkCustomSize1
                    PrintDocument1.PrinterSettings.DefaultPageSettings.Landscape = False

                    PrintDocument1.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
                    PrintDocument1.Print()
                Catch ex As Exception
                    MessageBox.Show("No hay impresora activa", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End Try
            End If
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim ft As New System.Drawing.Font("FontA11", 8.5, FontStyle.Regular)
        Dim ftN As New System.Drawing.Font("FontA12", 8.5, FontStyle.Regular)
        Dim ftLinea As New System.Drawing.Font("Arial", 10, FontStyle.Regular)
        Dim SF As New StringFormat
        Dim x As Integer
        x = 45

        If cboTipoDocumento.SelectedIndex = 0 Then 'Ticket Factura
            e.Graphics.DrawString("TICKET FACTURA", ftN, Brushes.Black, 80, 30)
            e.Graphics.DrawString("LADRILLERA EL DIAMANTE SAC", ftN, Brushes.Black, 40, 50)
            e.Graphics.DrawString("RUC 20120877055", ftN, Brushes.Black, 70, 70)
            e.Graphics.DrawString("VARIANTE DE UCHUMAYO KM 4", ft, Brushes.Black, 40, 110)
            e.Graphics.DrawString("Cerro Colorado", ft, Brushes.Black, 80, 130)
            e.Graphics.DrawString("Arequipa", ft, Brushes.Black, 100, 150)
            e.Graphics.DrawString("Autorizacion SUNAT 0051845042861", ft, Brushes.Black, 240 - ("Autorizacion SUNAT 0051845042861".Length) * 5 - x, 170)
            e.Graphics.DrawString("Numero Serie POS : SSCS100450", ft, Brushes.Black, 40, 190)

            e.Graphics.DrawString(CDate(mSC.SCO_FECHA).Date & "   # ticket: " & mSC.SCO_SERIE & "-" & mSC.SCO_NUMERO, ftN, Brushes.Black, 50 - x, 210)
            e.Graphics.DrawString("Cliente:", ft, Brushes.Black, 50 - x, 230)

            e.Graphics.DrawString((mSC.Personas.PER_APE_PAT & " " & mSC.Personas.PER_APE_MAT & " " & mSC.Personas.PER_NOMBRES).Substring(0, IIf((mSC.Personas.PER_APE_PAT & " " & mSC.Personas.PER_APE_MAT & " " & mSC.Personas.PER_NOMBRES).ToString.Length > 33, 33, (mSC.Personas.PER_APE_PAT & " " & mSC.Personas.PER_APE_MAT & " " & mSC.Personas.PER_NOMBRES).ToString.Length)), ftN, Brushes.Black, 50 - x, 243)
            If (mSC.Personas.PER_APE_PAT & " " & mSC.Personas.PER_APE_MAT & " " & mSC.Personas.PER_NOMBRES).ToString.Length > 33 Then
                e.Graphics.DrawString((mSC.Personas.PER_APE_PAT & " " & mSC.Personas.PER_APE_MAT & " " & mSC.Personas.PER_NOMBRES).Substring(33, (mSC.Personas.PER_APE_PAT & " " & mSC.Personas.PER_APE_MAT & " " & mSC.Personas.PER_NOMBRES).ToString.Length - 33), ftN, Brushes.Black, 50 - x, 256)
            End If

            Dim mRuc = (From mR In mSC.Personas.DocPersonas Where mR.TDP_ID = "04" Select mR).FirstOrDefault
            If mRuc IsNot Nothing Then
                e.Graphics.DrawString("R.U.C.: " & mRuc.DOP_NUMERO, ftN, Brushes.Black, 50 - x, 270)
            Else
                MessageBox.Show("No hay Ruc. Se cancela la impresion")
                Exit Sub
            End If

            e.Graphics.DrawString("Placa:", ft, Brushes.Black, 50 - x, 290)
            e.Graphics.DrawString(mSC.UNT_ID, ftN, Brushes.Black, 50 - x, 310)
            e.Graphics.DrawString("O.R.:", ft, Brushes.Black, 50 - x, 330)
            e.Graphics.DrawString(mSC.OrdenRequerimiento.ORR_ID, ftN, Brushes.Black, 50 - x, 350)
            e.Graphics.DrawString("Turno:", ft, Brushes.Black, 50 - x, 370)
            e.Graphics.DrawString("DESPACHO DE COMBUSTIBLE", ftN, Brushes.Black, 50 - x, 390)
            e.Graphics.DrawString("Grifero:", ft, Brushes.Black, 50 - x, 410)
            '''''Para saber quien lo hizo
            Dim Hecho As Usuarios
            Hecho = BCPermisoUsuario.UsuarioGetById(mSC.USU_ID)
            e.Graphics.DrawString(Hecho.USU_DESCRIPCION, ftN, Brushes.Black, 50 - x, 430)
            e.Graphics.DrawString("======================================", ftLinea, Brushes.Black, 50 - x, 450)
            e.Graphics.DrawString(mSC.OrdenRequerimiento.OrdenRequerimientoDetalle(0).Articulos.ART_DESCRIPCION, ft, Brushes.Black, 50 - x, 470)
            e.Graphics.DrawString("Cantidad GLN.", ftN, Brushes.Black, 100 - x, 490)
            e.Graphics.DrawString(Math.Round(CDec(mSC.SCO_CANTIDAD), 4), ftN, Brushes.Black, 300 - (Math.Round(CDec(mSC.SCO_CANTIDAD), 4).ToString.Length) * 5 - x - 40, 490, SF)
            e.Graphics.DrawString("Precio Unitario     S/.", ftN, Brushes.Black, 100 - x, 510)
            e.Graphics.DrawString(Math.Round(CDec(mSC.SCO_PRECIO_UNITARIO), 2), ftN, Brushes.Black, 295 - (Math.Round(CDec(mSC.SCO_PRECIO_UNITARIO), 2).ToString.Length) * 5 - x - 40, 510)
            e.Graphics.DrawString("----------------------------------------------------------", ftLinea, Brushes.Black, 50 - x, 530)
            e.Graphics.DrawString("Base Imponible   S/.", ftN, Brushes.Black, 100 - x, 550)
            e.Graphics.DrawString(Math.Round(Math.Round(CDec(mSC.SCO_CANTIDAD) * CDec(mSC.SCO_PRECIO_UNITARIO), 2) / ((CDec(SessionServer.IGV) / 100) + 1), 2), ftN, Brushes.Black, 300 - ((Math.Round(CDec((mSC.SCO_CANTIDAD * mSC.SCO_PRECIO_UNITARIO) / ((SessionServer.IGV / 100) + 1)), 2)).ToString.Length) * 5 - x - 40, 550)
            e.Graphics.DrawString("I.G.V.                    S/.", ftN, Brushes.Black, 100 - x, 570)
            e.Graphics.DrawString(Math.Round(Math.Round(CDec(mSC.SCO_CANTIDAD) * CDec(mSC.SCO_PRECIO_UNITARIO), 2) / ((CDec(SessionServer.IGV) / 100) + 1) * (CDec(SessionServer.IGV) / 100), 2), ftN, Brushes.Black, 300 - ((Math.Round(CDec(((mSC.SCO_CANTIDAD * mSC.SCO_PRECIO_UNITARIO) / ((SessionServer.IGV / 100) + 1)) * SessionServer.IGV / 100), 2)).ToString.Length) * 5 - x - 40, 570)
            e.Graphics.DrawString("Total de la Venta S/.", ftN, Brushes.Black, 100 - x, 590)
            e.Graphics.DrawString(Math.Round(CDec(mSC.SCO_CANTIDAD) * CDec(mSC.SCO_PRECIO_UNITARIO), 2), ftN, Brushes.Black, 300 - ((Math.Round(CDec(mSC.SCO_CANTIDAD * mSC.SCO_PRECIO_UNITARIO), 2)).ToString.Length) * 5 - x - 40, 590)
            e.Graphics.DrawString("======================================", ftLinea, Brushes.Black, 50 - x, 610)
            e.Graphics.DrawString(Now(), ft, Brushes.Black, 100 - x, 630)
            e.Graphics.DrawString(".", ft, Brushes.Black, 100 - x, 700)

        Else
            e.Graphics.DrawString("VALE DE COMBUSTIBLE", ftN, Brushes.Black, 70, 30)
            e.Graphics.DrawString("LADRILLERA EL DIAMANTE SAC", ftN, Brushes.Black, 40, 50)
            e.Graphics.DrawString("RUC 20120877055", ftN, Brushes.Black, 80, 70)

            e.Graphics.DrawString("VARIANTE DE UCHUMAYO KM 4", ft, Brushes.Black, 40, 110)
            e.Graphics.DrawString("Cerro Colorado", ft, Brushes.Black, 80, 130)
            e.Graphics.DrawString("Arequipa", ft, Brushes.Black, 90, 150)
            e.Graphics.DrawString(mSC.SCO_FECHA & "   # Vale: " & mSC.SCO_ID, ftN, Brushes.Black, 50 - x, 170)
            e.Graphics.DrawString("Turno", ft, Brushes.Black, 50 - x, 190)
            e.Graphics.DrawString("DESPACHO DE COMBUSTIBLE", ftN, Brushes.Black, 50 - x, 210)
            e.Graphics.DrawString("Grifero:", ft, Brushes.Black, 50 - x, 230)
            Dim Hecho As Usuarios
            Hecho = BCPermisoUsuario.UsuarioGetById(mSC.USU_ID)
            e.Graphics.DrawString(Hecho.USU_DESCRIPCION, ftN, Brushes.Black, 50 - x, 250)
            e.Graphics.DrawString("Cliente:", ft, Brushes.Black, 50 - x, 270)
            e.Graphics.DrawString(mSC.Personas.PER_APE_PAT & " " & mSC.Personas.PER_APE_MAT, ftN, Brushes.Black, 50 - x, 290)

            e.Graphics.DrawString("Chofer:", ft, Brushes.Black, 50 - x, 310)
            e.Graphics.DrawString(mSC.Personas1.PER_APE_PAT & " " & mSC.Personas1.PER_APE_MAT, ftN, Brushes.Black, 50 - x, 330)

            e.Graphics.DrawString("Placa:", ft, Brushes.Black, 50 - x, 350)
            e.Graphics.DrawString(mSC.UNT_ID, ftN, Brushes.Black, 50 - x, 370)
            e.Graphics.DrawString("O.R.:", ft, Brushes.Black, 50 - x, 390)
            e.Graphics.DrawString(mSC.OrdenRequerimiento.ORR_ID, ftN, Brushes.Black, 50 - x, 410)

            e.Graphics.DrawString("Kilometraje (Ref.):", ft, Brushes.Black, 50 - x, 430)
            e.Graphics.DrawString(Math.Round(CDec(mSC.SCO_KILOMETRAJE), 4), ftN, Brushes.Black, 170, 430)

            e.Graphics.DrawString("Horometro (Ref.):", ft, Brushes.Black, 50 - x, 450)
            e.Graphics.DrawString(Math.Round(CDec(mSC.SCO_HOROMETRO), 4), ftN, Brushes.Black, 170, 450)

            e.Graphics.DrawString("Observaciones (Ref.):", ft, Brushes.Black, 50 - x, 470)
            e.Graphics.DrawString(mSC.SCO_OBSERVACION, ftN, Brushes.Black, 50 - x, 490)

            e.Graphics.DrawString("--------------------------------------", ftLinea, Brushes.Black, 50 - x, 550)
            e.Graphics.DrawString("Combustible Entregado :", ftN, Brushes.Black, 50 - x, 570)
            e.Graphics.DrawString(mSC.OrdenRequerimiento.OrdenRequerimientoDetalle(0).Articulos.ART_DESCRIPCION, ft, Brushes.Black, 50 - x, 590)

            e.Graphics.DrawString("Cantidad GLN.", ftN, Brushes.Black, 100 - x, 610)
            e.Graphics.DrawString(Math.Round(CDec(mSC.SCO_CANTIDAD), 4), ftN, Brushes.Black, 170, 610)
            e.Graphics.DrawString("======================================", ftLinea, Brushes.Black, 50 - x, 630)
            e.Graphics.DrawString(Now(), ft, Brushes.Black, 100 - x, 650)
        End If


        'Dim formato As New StringFormat()
        'formato.Alignment = StringAlignment.Far
        'formato.LineAlignment = StringAlignment.Far

        'e.Graphics.DrawString(texto, fuente, Brushes.Black, New RectangleF(x, y, 80, fuente.Height), formato)

        'Dim sf As New StringFormat
        'sf.LineAlignment = StringAlignment.Center
        'sf.Alignment = StringAlignment.Center

        '' Draw the text.
        ''gr.DrawString(txt, Me.Font, Brushes.Black, x, y, sf)
        'e.Graphics.DrawString("asdasdasd", Me.Font, Brushes.Black, 0, 650, sf)
        ''sf.Dispose()


        'String.Format("{0:G}", DateTime.Now)


    End Sub

    Private Sub btnSurtidor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSurtidor.Click
        Try
            Dim ds As New DataSet
            Dim query = BCSalidaCombustible.ObtenerDatoGrifo
            If query.ToString.Length > 0 Then
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
                numCantidad.Value = Math.Round(CDbl(ds.Tables(0).Rows(0).Item("Volumen")), 4)
                txtPU.Text = Math.Round(CDbl(ds.Tables(0).Rows(0).Item("Precio")), 4)
                Id_Grifo = CInt(ds.Tables(0).Rows(0).Item("ID"))
            Else
                numCantidad.Value = 0
                txtPU.Text = "0"
                MessageBox.Show("No se ha jalado ningun dato.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al jalar el dato.")
        End Try
    End Sub

    Private Sub txtEmpresa_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpresa.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Proveedor"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtEmpresa.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
            txtEmpresa.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtEmpresa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmpresa.KeyDown
        If e.KeyCode = Keys.Enter Then txtEmpresa_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MessageId = String.Empty
        Codigo = String.Empty
        Tipo = String.Empty

        Dim ds As New DataSet

        Try
            Dim Query = BCControlGrifo.ListaControlGrifo()
            Dim rea As New StringReader(Query)
            ds.ReadXml(rea)
            MessageId = ds.Tables(0).Rows(0).Item(0)
            Codigo = ds.Tables(0).Rows(0).Item(1)
            Tipo = ds.Tables(0).Rows(0).Item(2)

            If MessageId.Length > 0 And Codigo.Length > 0 And Tipo.Length > 0 Then
                OnManNuevo()

                If Tipo = "I" Then
                    Dim key As Integer = Codigo
                    CargarOrdenRequerimiento(key)
                    txtOR.Text = mOR.ORR_ID
                    txtOR.Tag = mOR.OrdenRequerimientoDetalle(0).ORD_ID

                    If mOR.OrdenRequerimientoDetalle(0).OrdenTrabajo.Entidad.UnidadesTransporte IsNot Nothing Then
                        txtPlaca.Text = mOR.OrdenRequerimientoDetalle(0).OrdenTrabajo.Entidad.UnidadesTransporte.UNT_ID
                        txtEmpresa.Text = mOR.OrdenRequerimientoDetalle(0).OrdenTrabajo.Entidad.UnidadesTransporte.Personas.PER_APE_PAT
                        txtEmpresa.Tag = mOR.OrdenRequerimientoDetalle(0).OrdenTrabajo.Entidad.UnidadesTransporte.PER_ID
                    Else
                        txtEmpresa.Text = SessionServer.NombreEmpresa
                        txtEmpresa.Tag = BCParametro.ParametroGetById("PerIdEmpresa").PAR_VALOR1
                    End If

                    For Each mDoc In cboTipoDocumento.Items
                        If mDoc(0).ToString.Substring(0, 3) = BCParametro.ParametroGetById("DTD_OR").PAR_VALOR1 Then 'Orden Requerimiento
                            cboTipoDocumento.SelectedItem = mDoc
                            Exit For
                        End If
                    Next

                Else
                    ds = New DataSet
                    Query = Me.BCUnidadestransporte.ListaUnidadesTransporteSalidaCombustible(Codigo)
                    Dim rea1 As New StringReader(Query)
                    ds.ReadXml(rea1)

                    txtPlaca.Tag = ds.Tables(0).Rows(0).Item(0) 'Unt_Id
                    txtPlaca.Text = ds.Tables(0).Rows(0).Item(0) 'Unt_Id
                    txtOR.Text = ds.Tables(0).Rows(0).Item(1) 'orr
                    txtOR.Tag = ds.Tables(0).Rows(0).Item(4) 'ord
                    txtEmpresa.Tag = ds.Tables(0).Rows(0).Item(3) 'Pers_Id
                    txtEmpresa.Text = ds.Tables(0).Rows(0).Item(2) 'Empresa

                    For Each mDoc In cboTipoDocumento.Items
                        If mDoc(0).ToString.Substring(0, 3) = BCParametro.ParametroGetById("DTD_FACT_VENTA").PAR_VALOR1 Then 'Factura
                            cboTipoDocumento.SelectedItem = mDoc
                            Exit For
                        End If
                    Next
                End If

                Timer1.Stop()
            End If

        Catch ex As Exception
            If MessageId.Length > 0 Then
                Dim mCG As New ControlGrifo
                mCG = BCControlGrifo.ControlGrifoGetById(MessageId)
                mCG.Estado = 3
                mCG.MarkAsModified()
                BCControlGrifo.MantenimientoControlGrifo(mCG)
            End If
        End Try
    End Sub

    Private Sub btnLimpiarLectura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarLectura.Click
        If MessageId.Length > 0 Then
            Dim mCG As New ControlGrifo
            mCG = BCControlGrifo.ControlGrifoGetById(MessageId)
            mCG.Estado = 3
            mCG.MarkAsModified()
            BCControlGrifo.MantenimientoControlGrifo(mCG)
        End If
        OnManDeshacerCambios()
        Timer1.Start()
    End Sub
End Class
