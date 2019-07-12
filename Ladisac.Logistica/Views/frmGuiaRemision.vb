Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmGuiaRemision
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCGuiaRemision As Ladisac.BL.IBCGuiaRemision
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCDocuMovimiento As Ladisac.BL.IBCDocuMovimiento
    <Dependency()> _
    Public Property BCArticulo As Ladisac.BL.IBCArticulo
    <Dependency()> _
    Public Property BCTipoDocumento As Ladisac.BL.IBCTipoDocumento
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro
    <Dependency()> _
    Public Property BCMaestro As Ladisac.BL.IBCMaestro
    <Dependency()> _
    Public Property BCPersona As Ladisac.BL.IBCPersona
    <Dependency()> _
    Public Property BCConteo As Ladisac.BL.IBCControlConteo

    Private Compuesto1 As New Ladisac.BE.DetalleDocumentos

    Protected mGR As GuiaRemision
    Dim mDMO As DocuMovimiento
    Dim mNuevaPag As Integer
    Dim mIndexItem As Integer
    Dim mCantLinea As Integer
    Dim Atajo As Boolean

    Private Sub frmGuiaRemision_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()

        'se llama al procedimiento de paso rapido entre cajas de texto.

        Me.txtSerieRemision.TabIndex = 0
        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 18
        txtNroRemision.TabIndex = 1
        txtPuntoPartida.TabIndex = 2
        txtDestinatario.TabIndex = 3
        txtEmpTrans.TabIndex = 4
        txtPlacaVeh.TabIndex = 5
        txtMarcaVeh.TabIndex = 6
        txtCertificado.TabIndex = 7
        dtpFecha.TabIndex = 8
        dtpFechaInicioT.TabIndex = 9
        txtTransportista.TabIndex = 10
        txtLicencia.TabIndex = 11
        cboTipoMotivo.TabIndex = 12
        dgvDetalle.TabIndex = 13
        dtpFIProcesar.TabIndex = 14
        dtpFFProcesar.TabIndex = 15
        btnBuscar.TabIndex = 16
        dgvProcesar.TabIndex = 17

    End Sub

    Sub LimpiarControles()
        mGR = Nothing
        txtCodigo.Text = String.Empty
        txtSerieRemision.Text = String.Empty
        txtNroRemision.Text = String.Empty
        txtDestinatario.Text = String.Empty
        txtDestinatario.Tag = Nothing
        cboTipoMotivo.SelectedIndex = -1
        dtpFecha.Value = Now
        dtpFechaInicioT.Value = Now
        txtPuntoPartida.Text = String.Empty
        txtPuntoLlegada.Text = String.Empty
        txtEmpTrans.Text = String.Empty
        txtEmpTrans.Tag = Nothing
        txtMarcaVeh.Text = String.Empty
        txtPlacaVeh.Text = String.Empty
        txtPlacaVeh.Tag = Nothing
        txtTransportista.Text = String.Empty
        txtTransportista.Tag = Nothing
        txtLicencia.Text = String.Empty
        txtCertificado.Text = String.Empty
        dgvDetalle.Rows.Clear()

        Atajo = False
        '--------------------------
        Error_validacion.Clear()
    End Sub

    Private Function BuscarSeries() As Boolean
        If mGR IsNot Nothing Then
            If mGR.ChangeTracker.State = ObjectState.Added Then
                Compuesto1.Vista = "BuscarCorrelativos"
                Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()

                Dim ds As New DataSet
                Dim sr As New StringReader(BCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                    "002", _
                                                                    "039", _
                                                                    "058", _
                                                                    Nothing, _
                                                                    ""
                                                                   )
                                          )

                Dim vcontrol As Int16 = sr.Peek
                If vcontrol <> -1 Then
                    ds.ReadXml(sr)
                    txtSerieRemision.Text = ds.Tables(0).Rows(0).Item("CTD_COR_SERIE")
                    txtNroRemision.Text = ds.Tables(0).Rows(0).Item("CTD_COR_NUMERO")
                    Return True
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

    Private Sub txtDestinatario_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDestinatario.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Proveedor"

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtDestinatario.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
            txtDestinatario.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
            Try
                txtPuntoLlegada.Text = BCPersona.PersonaGetById(txtDestinatario.Tag).DireccionesPersonas(0).DIR_DESCRIPCION
            Catch ex As Exception

            End Try
        End If
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        If e.ColumnIndex = 1 Then
            frm.Tabla = "Articulo"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " - " & frm.dgvLista.CurrentRow.Cells(2).Value & " - " & frm.dgvLista.CurrentRow.Cells(3).Value 'ART_Descripcion
            End If
        End If
        frm.Dispose()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------
        If mGR IsNot Nothing Then
            dgvDetalle.EndEdit()
            mGR.GUI_FECHA = dtpFecha.Value
            mGR.GUI_FEC_INI_TRAS = dtpFechaInicioT.Value
            mGR.GUI_SERIE = txtSerieRemision.Text
            mGR.GUI_NRO = txtNroRemision.Text
            mGR.GUI_LICENCIA = txtLicencia.Text
            mGR.GUI_MARCA = txtMarcaVeh.Text
            mGR.GUI_CERTIFICADO = txtCertificado.Text
            mGR.GUI_MOTIVO = cboTipoMotivo.SelectedIndex 'cboTipoMotivo
            mGR.GUI_PLACA = txtPlacaVeh.Text.Trim() & "/" & txtPlacaRemolque.Text.Trim()

            mGR.PLA_ID = txtPlacaVeh.Tag  'txtPlacaVeh.Tag PLA_ID

            mGR.GUI_PTO_PARTIDA = txtPuntoPartida.Text
            mGR.GUI_PTO_LLEGADA = txtPuntoLlegada.Text
            mGR.PER_ID_CHOFER = txtTransportista.Tag
            mGR.PER_ID_EMP_TRANSP = txtEmpTrans.Tag
            mGR.PER_ID_PROVEEDOR = txtDestinatario.Tag
            mGR.GUI_ESTADO = True
            mGR.GUI_FEC_GRAB = Now
            mGR.USU_ID = SessionServer.UserId

            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("GUD_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("GUD_ID").Tag, GuiaRemisionDetalle)
                        .ART_ID = mDetalle.Cells("ART_ID").Tag
                        .GUD_CANTIDAD = CDec(mDetalle.Cells("GUD_CANTIDAD").Value)
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("GUD_CANTIDAD").Value Is Nothing Then
                    Dim nGRD As New GuiaRemisionDetalle
                    With nGRD
                        .ART_ID = mDetalle.Cells("ART_Id").Tag
                        .GUD_CANTIDAD = CDec(mDetalle.Cells("GUD_CANTIDAD").Value)
                        .MarkAsAdded()
                    End With
                    mGR.GuiaRemisionDetalle.Add(nGRD)
                End If
            Next
            If BCGuiaRemision.MantenimientoGuiaRemision(mGR) = 1 Then
                MessageBox.Show(mGR.GUI_ID)
                mGR = BCGuiaRemision.GuiaRemisionGetById(mGR.GUI_ID)
                OnReportes()
                LimpiarControles()
            Else
                MessageBox.Show("Error al insertar.")
                Exit Sub
            End If



            '------------------------------------------
            Call validacion_desactivacion(False, 3)
        End If



    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mGR = New GuiaRemision
        mGR.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        BuscarSeries()
        Me.txtSerieRemision.Focus()

    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "GuiaRemision"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarGuiaRemision(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarGuiaRemision(ByVal GUI_ID As Integer)
        mGR = BCGuiaRemision.GuiaRemisionGetById(GUI_ID)
        mGR.MarkAsModified()
    End Sub

    Sub LlenarControles()
        Dim Placa() As String
        Placa = Strings.Split(Trim(mGR.GUI_PLACA), "/")

        txtCodigo.Text = mGR.GUI_ID
        dtpFecha.Value = mGR.GUI_FECHA
        dtpFechaInicioT.Value = mGR.GUI_FEC_INI_TRAS
        txtDestinatario.Text = mGR.Personas.PER_APE_PAT & " " & mGR.Personas.PER_APE_MAT
        txtDestinatario.Tag = mGR.PER_ID_PROVEEDOR
        cboTipoMotivo.SelectedIndex = mGR.GUI_MOTIVO
        txtLicencia.Text = mGR.GUI_LICENCIA
        txtMarcaVeh.Text = mGR.GUI_MARCA
        txtPlacaVeh.Text = Placa(0)
        If Placa.Length > 1 Then txtPlacaRemolque.Text = Placa(1)

        txtPlacaVeh.Tag = mGR.PLA_ID

        txtCertificado.Text = mGR.GUI_CERTIFICADO
        txtSerieRemision.Text = mGR.GUI_SERIE
        txtNroRemision.Text = mGR.GUI_NRO
        txtPuntoPartida.Text = mGR.GUI_PTO_PARTIDA
        txtPuntoLlegada.Text = mGR.GUI_PTO_LLEGADA
        txtTransportista.Text = mGR.Personas2.PER_NOMBRES & " " & mGR.Personas2.PER_APE_PAT & " " & mGR.Personas2.PER_APE_MAT
        txtTransportista.Tag = mGR.PER_ID_CHOFER
        txtEmpTrans.Text = mGR.Personas1.PER_NOMBRES & " " & mGR.Personas1.PER_APE_PAT & " " & mGR.Personas1.PER_APE_MAT
        txtEmpTrans.Tag = mGR.PER_ID_EMP_TRANSP
        For Each mItem In mGR.GuiaRemisionDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("GUD_ID").Value = mItem.GUD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("GUD_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Art_Id").Value = mItem.Articulos.ART_Codigo & " - " & mItem.Articulos.ART_DESCRIPCION & " - " & mItem.Articulos.UnidadMedidaArticulos.UM_SIMBOLO
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Art_Id").Tag = mItem.ART_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("GUD_CANTIDAD").Value = mItem.GUD_CANTIDAD
        Next
    End Sub

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()


        'If Len(txtCodigo.Text.Trim) = 0 Then Error_validacion.SetError(txtCodigo, "Ingrese el Numero de Guia de Remision") : txtCodigo.Focus() : flag = False
        If Len(txtSerieRemision.Text.Trim) = 0 Then Error_validacion.SetError(txtSerieRemision, "Ingrese la Serie de Remision") : txtSerieRemision.Focus() : flag = False
        If Len(txtNroRemision.Text.Trim) = 0 Then Error_validacion.SetError(txtNroRemision, "Ingrese el Numero de Remision") : txtNroRemision.Focus() : flag = False
        If Len(txtPuntoPartida.Text.Trim) = 0 Then Error_validacion.SetError(txtPuntoPartida, "Ingrese el Punto De Partida") : txtPuntoPartida.Focus() : flag = False
        If Len(txtPuntoLlegada.Text.Trim) = 0 Then Error_validacion.SetError(txtPuntoLlegada, "Ingrese el Punto De Llegada") : txtPuntoLlegada.Focus() : flag = False
        If Len(txtDestinatario.Text.Trim) = 0 Then Error_validacion.SetError(txtDestinatario, "Ingrese el Nombre del Proveedor") : txtDestinatario.Focus() : flag = False
        If Len(txtEmpTrans.Text.Trim) = 0 Then Error_validacion.SetError(txtEmpTrans, "Ingrese el Nombre Empresa") : txtEmpTrans.Focus() : flag = False
        If Len(txtMarcaVeh.Text.Trim) = 0 Then Error_validacion.SetError(txtMarcaVeh, "Ingrese la Marca del Vehiculo") : txtMarcaVeh.Focus() : flag = False
        If Len(txtPlacaVeh.Text.Trim) = 0 Then Error_validacion.SetError(txtPlacaVeh, "Ingrese la Placa del Vehiculo") : txtPlacaVeh.Focus() : flag = False
        If Len(txtTransportista.Text.Trim) = 0 Then Error_validacion.SetError(txtTransportista, "Ingrese el Nombre del Transportista") : txtTransportista.Focus() : flag = False
        If Len(txtLicencia.Text.Trim) = 0 Then Error_validacion.SetError(txtLicencia, "Ingrese la Licencia Del Transportista") : txtLicencia.Focus() : flag = False
        If Len(dtpFecha.Text.Trim) = 0 Then Error_validacion.SetError(dtpFecha, "Ingrese la Fecha") : dtpFecha.Focus() : flag = False
        If Len(dtpFechaInicioT.Text.Trim) = 0 Then Error_validacion.SetError(dtpFechaInicioT, "Ingrese la Fecha de Inicio de Transporte") : dtpFechaInicioT.Focus() : flag = False
        If Len(cboTipoMotivo.Text.Trim) = 0 Then Error_validacion.SetError(cboTipoMotivo, "Ingrese el Motivo") : cboTipoMotivo.Focus() : flag = False


        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function
    Private Sub validar_longitud()
        Me.txtSerieRemision.MaxLength = 3
        Me.txtNroRemision.MaxLength = 25
        Me.txtDestinatario.MaxLength = 50
        Me.txtPlacaVeh.MaxLength = 20
        Me.txtMarcaVeh.MaxLength = 20

        Me.txtDestinatario.MaxLength = 45
        Me.txtPlacaVeh.MaxLength = 20
        Me.txtPlacaVeh.MaxLength = 20

        Me.cboTipoMotivo.DropDownStyle = ComboBoxStyle.DropDownList

    End Sub
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
        If mGR IsNot Nothing Then
            If mGR.DMO_ID > 0 Then
                MessageBox.Show("La Guia Remision no se puede eliminar porque ya fue Procesada.")
                Exit Sub
            End If

            If MessageBox.Show("Seguro de Eliminar la Guia Remision?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = vbOK Then
                'For Each mItem In mGR.GuiaRemisionDetalle
                '    mItem.MarkAsDeleted()
                'Next
                'mGR.MarkAsDeleted()
                mGR.GUI_ESTADO = False
                mGR.GUI_FEC_GRAB = Now
                mGR.USU_ID = SessionServer.UserId
                mGR.MarkAsModified()
                If BCGuiaRemision.MantenimientoGuiaRemision(mGR) = 1 Then
                    LimpiarControles()
                Else
                    MessageBox.Show("Error al eliminar.")
                    Exit Sub
                End If

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

        End If
    End Sub

    Private Sub txtEmpTrans_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpTrans.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Proveedor"

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtEmpTrans.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
            txtEmpTrans.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtTransportista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTransportista.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Chofer"

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtTransportista.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            txtTransportista.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtPlacaVeh_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlacaVeh.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Placas"
        frm.Tipo = txtEmpTrans.Tag

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPlacaVeh.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Pla_Id
            txtPlacaVeh.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Placa
            If Not Atajo Then
                txtEmpTrans.Tag = frm.dgvLista.CurrentRow.Cells(8).Value 'CodEmpTransp
                txtEmpTrans.Text = frm.dgvLista.CurrentRow.Cells(3).Value 'RazonSocialEmpTransp
                txtTransportista.Tag = frm.dgvLista.CurrentRow.Cells(9).Value 'CodChofer
                txtTransportista.Text = frm.dgvLista.CurrentRow.Cells(7).Value 'Nombre
                txtMarcaVeh.Text = frm.dgvLista.CurrentRow.Cells(4).Value 'Marca
                txtLicencia.Text = frm.dgvLista.CurrentRow.Cells(6).Value 'Licencia
                txtCertificado.Text = frm.dgvLista.CurrentRow.Cells(5).Value 'certificado
            End If
        End If
        frm.Dispose()
    End Sub

    Private Sub txtEmpTrans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmpTrans.KeyDown
        If e.KeyCode = Keys.Enter Then txtEmpTrans_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtEmpTrans_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpTrans.TextChanged
        If txtDestinatario.Text = "" Then
            txtMarcaVeh.Text = String.Empty
            txtPlacaVeh.Text = String.Empty
            txtPlacaVeh.Tag = Nothing
            txtTransportista.Text = String.Empty
            txtTransportista.Tag = Nothing
            txtLicencia.Text = String.Empty
            txtCertificado.Text = String.Empty
        End If
    End Sub

    Public Overrides Sub OnReportes()
        If mGR IsNot Nothing Then
            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    mNuevaPag = 0
                    mIndexItem = 0
                    mCantLinea = 7
                    Dim pkCustomSize1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 900, 550)
                    PrintDocument1.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1
                    PrintDocument1.PrinterSettings.DefaultPageSettings.Landscape = True
                    PrintDocument1.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(2, 2, 10, 10)
                    PrintDocument1.Print()
                Catch ex As Exception
                    MessageBox.Show("No hay impresora activa", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End Try
            End If
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim ft As New System.Drawing.Font("Courier New", 10, FontStyle.Regular)
        Dim ft8 As New System.Drawing.Font("Courier New", 8, FontStyle.Regular)
        Dim ftN As New System.Drawing.Font("Courier New", 10, FontStyle.Bold)
        Dim ftS As New System.Drawing.Font("Courier New", 10, FontStyle.Underline)
        Dim X As Integer
        X = 95
        'x =20

        'e.Graphics.DrawString(SessionServer.NombreEmpresa, ftN, Brushes.Black, 100, 40)
        e.Graphics.DrawString(mGR.GUI_SERIE & "-" & mGR.GUI_NRO, ftN, Brushes.Black, 600, 80 + X) 'guia
        e.Graphics.DrawString(mGR.GUI_PTO_PARTIDA, ftN, Brushes.Black, 300, 100 + X) 'punto partida
        e.Graphics.DrawString(mGR.Personas.PER_APE_PAT & " " & mGR.Personas.PER_APE_MAT, ftN, Brushes.Black, 300, 120 + X) 'destinatario

        For Each mDoc In mGR.Personas.DocPersonas
            If mDoc.TDP_ID = "04" Then
                e.Graphics.DrawString(mDoc.DOP_NUMERO, ftN, Brushes.Black, 630, 120 + X) 'fecha emision 150
            End If
        Next

        e.Graphics.DrawString(mGR.GUI_PTO_LLEGADA, ftN, Brushes.Black, 300, 140 + X) 'Direccion llegada


        e.Graphics.DrawString(mGR.GUI_FECHA.Value.Date, ftN, Brushes.Black, 190, 163 + X - 8) 'fecha emision 150
        e.Graphics.DrawString(mGR.GUI_FEC_INI_TRAS.Value.Date, ftN, Brushes.Black, 630, 163 + X - 8) 'fecha inicio de traslado  600      
        If mGR.GUI_MOTIVO = 0 Then
            e.Graphics.DrawString("Venta", ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        ElseIf mGR.GUI_MOTIVO = 1 Then
            e.Graphics.DrawString("Compra", ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        ElseIf mGR.GUI_MOTIVO = 2 Then
            e.Graphics.DrawString("Consignacion", ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        ElseIf mGR.GUI_MOTIVO = 3 Then
            e.Graphics.DrawString("Devolucion", ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        ElseIf mGR.GUI_MOTIVO = 4 Then
            e.Graphics.DrawString("Venta sujeta a confirmacion del Comprador", ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        ElseIf mGR.GUI_MOTIVO = 5 Then
            e.Graphics.DrawString("Traslado entre establecimientos", ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        ElseIf mGR.GUI_MOTIVO = 6 Then
            e.Graphics.DrawString("Traslado de bienes para transformarlos", ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        ElseIf mGR.GUI_MOTIVO = 7 Then
            e.Graphics.DrawString("Recojo de bienes transformados", ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        ElseIf mGR.GUI_MOTIVO = 8 Then
            e.Graphics.DrawString("Traslado por emisor itinerante de comprobante", ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        ElseIf mGR.GUI_MOTIVO = 9 Then
            e.Graphics.DrawString("Traslado zona primaria", ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        ElseIf mGR.GUI_MOTIVO = 10 Then
            e.Graphics.DrawString("Importacion", ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        ElseIf mGR.GUI_MOTIVO = 11 Then
            e.Graphics.DrawString("Exportacion", ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        ElseIf mGR.GUI_MOTIVO = 12 Then
            e.Graphics.DrawString("Otros", ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        ElseIf mGR.GUI_MOTIVO = 13 Then
            e.Graphics.DrawString("X Transporte Materia Prima", ftN, Brushes.Black, 500, 230 + X) 'motivo MOSTRAR EL MOTIVO
        Else
            e.Graphics.DrawString("NINGUNO", ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        End If
        'e.Graphics.DrawString(IIf(mGR.GUI_MOTIVO = 0, "Venta", IIf(mGR.GUI_MOTIVO = 1, "Compra", IIf(mGR.GUI_MOTIVO = 2, "Consignacion", IIf(mGR.GUI_MOTIVO = 3, "Devolucion", IIf(mGR.GUI_MOTIVO = 4, "Venta sujeta a confirmacion del Comprador", IIf(mGR.GUI_MOTIVO = 5, "Traslado entre establecimientos", IIf(mGR.GUI_MOTIVO = 6, "Traslado de bienes para transformarlos", IIf(mGR.GUI_MOTIVO = 7, "Recojo de bienes transformados", IIf(mGR.GUI_MOTIVO = 8, "Traslado por emisor itinerante de comprobante", IIf(mGR.GUI_MOTIVO = 9, "Traslado zona primaria", IIf(mGR.GUI_MOTIVO = 10, "Importacion", IIf(mGR.GUI_MOTIVO = 11, "Exportacion", IIf(mGR.GUI_MOTIVO = 12, "Otros", IIf(mGR.GUI_MOTIVO = 13, "X Transporte Materia Prima", "NINGUNO")))))))))))))), ftN, Brushes.Black, 520, 230 + X) 'motivo MOSTRAR EL MOTIVO
        '230'20
        Dim altu As Integer = -25
        Dim mOt As Integer = 0

        If mNuevaPag = mCantLinea Then mNuevaPag = 0 'Para imprimir varias paginas
        Dim mItem As Object

        For mFila = mIndexItem To mGR.GuiaRemisionDetalle.Count - 1
            mItem = mGR.GuiaRemisionDetalle(mFila)
            mNuevaPag += 1
            altu += 20
            e.Graphics.DrawString(mItem.Articulos.ART_Codigo, ft, Brushes.Black, 60 + 22, 287 + altu + X - 10)
            e.Graphics.DrawString(mItem.Articulos.ART_DESCRIPCION.Substring(0, IIf(mItem.Articulos.ART_DESCRIPCION.Length > 56, 56, mItem.Articulos.ART_DESCRIPCION.Length)), ft, Brushes.Black, 170 + 25, 287 + altu + X - 10)
            e.Graphics.DrawString(mItem.Articulos.UnidadMedidaArticulos.UM_SIMBOLO, ft, Brushes.Black, 600, 287 + altu + X - 10)
            e.Graphics.DrawString(Math.Round(mItem.GUD_CANTIDAD, 2), ft, Brushes.Black, 650 + 5, 287 + altu + X - 10)
            'altu += 16
            If mNuevaPag = mCantLinea Then
                e.HasMorePages = True
                mIndexItem = mFila + 1
                Exit For
            Else
                e.HasMorePages = False
            End If
        Next
        'e.Graphics.DrawString(mGR.Personas.PER_NOMBRES, ftN, Brushes.Black, 70, 195 + altu + 90)

        e.Graphics.DrawString(mGR.Personas1.PER_APE_PAT & " " & mGR.Personas1.PER_APE_MAT & " " & mGR.Personas1.PER_NOMBRES, ftN, Brushes.Black, 200, 520) 'NOMBRES 512 330 + 7 + 90 + X
        For Each mRuc In mGR.Personas1.DocPersonas
            If mRuc.TDP_ID = "04" Then
                e.Graphics.DrawString(mRuc.DOP_NUMERO, ftN, Brushes.Black, 440, 520) 'NOMBRES 512 330 + 7 + 90 + X
            End If
        Next
        e.Graphics.DrawString(mGR.Personas2.PER_APE_PAT & " " & mGR.Personas2.PER_APE_MAT & " " & mGR.Personas2.PER_NOMBRES, ftN, Brushes.Black, 650 + 10, 520) 'NOMBRES 512 330 + 7 + 90 + X

        e.Graphics.DrawString(mGR.GUI_MARCA, ftN, Brushes.Black, 140 + 5, 540) '527 350 + 7 + 90 + X - 5
        e.Graphics.DrawString(mGR.GUI_PLACA, ftN, Brushes.Black, 300, 540) '527 350 + 7 + 90 + X - 5
        e.Graphics.DrawString(mGR.GUI_CERTIFICADO, ftN, Brushes.Black, 450 + 40, 540) '527 350 + 7 + 90 + X - 5
        e.Graphics.DrawString(mGR.GUI_LICENCIA, ftN, Brushes.Black, 650 + 20, 540) '527  350 + 7 + 90 + X - 5

    End Sub

    Private Sub Procesar()
        For Each Item As DataGridViewRow In dgvProcesar.Rows
            Dim mDMOBorrar As DocuMovimiento

            Try
                If Item.Cells("PROCESO").Value Then
                    mGR = BCGuiaRemision.GuiaRemisionGetById(Item.Cells("GUI_ID").Value)

                    mDMO = New DocuMovimiento
                    With mDMO
                        .TDO_ID = "039"
                        .DTD_ID = "058"
                        .DMO_SERIE = mGR.GUI_SERIE
                        .DMO_NRO = mGR.GUI_NRO
                        .DetalleTipoDocumentos = BCTipoDocumento.TipoDocumentoGetById("058")
                        .DMO_FECHA = mGR.GUI_FECHA
                        .DMO_FECHA_DOCUMENTO = mGR.GUI_FECHA
                        .ORR_ID = Nothing
                        .PER_ID_PROVEEDOR = mGR.PER_ID_EMP_TRANSP
                        .MON_ID = "001" 'Soles
                        .OCO_ID = Nothing
                        .DOCU_AFECTA_KARDEX = True
                        .SCO_ID = Nothing
                        .DMO_ASIENTO = Nothing
                        .DMO_CIERRE = Nothing
                        .USU_ID = SessionServer.UserId
                        .DMO_FEC_GRAB = Now
                        .DMO_ESTADO = True
                        .CCT_ID = ""
                        .DMO_ID_REF = Nothing
                        .DRU_ID = Nothing
                        .CME_ID = Nothing
                        .CPA_ID = Nothing
                        .DTD_ID_REF = "278"
                    End With

                    Dim DocumentacionDeta As New DocuMovimientoDetalle
                    For Each DetaGR In mGR.GuiaRemisionDetalle
                        DocumentacionDeta = New DocuMovimientoDetalle
                        With DocumentacionDeta
                            .ALM_ID = BCParametro.ParametroGetById("AlmMP").PAR_VALOR1
                            .ART_ID = DetaGR.ART_ID
                            .DMD_CANTIDAD = DetaGR.GUD_CANTIDAD
                            .DMD_DESCUENTO = 0
                            If UCase(Trim(mGR.GUI_PTO_PARTIDA)).Contains("MOLLEBAYA") Then
                                '.DMD_PRECIO_UNITARIO = BCGuiaRemision.PrecioMateriaPrima(BCParametro.ParametroGetById("NeyaPolobMolleb").PAR_VALOR1, Today) + 20
                                Select Case DetaGR.ART_ID
                                    Case "002987" '012
                                        .DMD_PRECIO_UNITARIO = BCGuiaRemision.StockCostoPromedio(BCParametro.ParametroGetById("NeyaPolobMolleb").PAR_VALOR1, BCParametro.ParametroGetById("AlmMP").PAR_VALOR1, mGR.GUI_FECHA, 2) + 18.6 'mENOS 7%  DE 20 DICE GALLO 13/05/2014
                                    Case "022018" '026
                                        .DMD_PRECIO_UNITARIO = BCGuiaRemision.StockCostoPromedio(BCParametro.ParametroGetById("BlancaPolobMolleb").PAR_VALOR1, BCParametro.ParametroGetById("AlmMP").PAR_VALOR1, mGR.GUI_FECHA, 2) + 18.6 'mENOS 7%  DE 20 DICE GALLO 13/05/2014
                                    Case "024511" '029
                                        .DMD_PRECIO_UNITARIO = BCGuiaRemision.StockCostoPromedio(BCParametro.ParametroGetById("CachiosPolobMolleb").PAR_VALOR1, BCParametro.ParametroGetById("AlmMP").PAR_VALOR1, mGR.GUI_FECHA, 2) + 19 '
                                End Select


                            Else
                                .DMD_PRECIO_UNITARIO = BCGuiaRemision.PrecioMateriaPrima(DetaGR.ART_ID, Today)
                            End If
                            .DMD_IGV = 0
                            .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                            .DMD_GLOSA = "Ingreso materia prima."
                            .ORD_ID = Nothing
                            .OCD_ID = Nothing
                            .DMD_ID_REF = Nothing
                        End With
                        mDMO.DocuMovimientoDetalle.Add(DocumentacionDeta)
                    Next

                    If BCDocuMovimiento.MantenimientoDocuMovimiento(mDMO) = 1 Then
                        mDMOBorrar = BCDocuMovimiento.DocuMovimientoGetById(mDMO.DMO_ID)
                        mGR.DMO_ID = mDMO.DMO_ID
                        mGR.MarkAsModified()
                        If BCGuiaRemision.MantenimientoGuiaRemision(mGR) = 1 Then
                            MessageBox.Show(mDMO.DMO_ID)
                        Else
                            Err.Raise(&HFFFFFF01, "Error Provocado", "Insercion incorrecta.")
                        End If
                        BCConteo.Interfase_IngresoMP(mDMO.DMO_ID)
                    Else
                        Err.Raise(&HFFFFFF01, "Error Provocado", "Insercion incorrecta.")

                    End If


                    'Para restar el kardex de la Neya(M) y aumentar de la Neya '''''''''''''
                    If UCase(Trim(mGR.GUI_PTO_PARTIDA)).ToString.Contains("MOLLEBAYA") Then
                        mDMO = New DocuMovimiento
                        With mDMO
                            .TDO_ID = "007"
                            .DTD_ID = "016"
                            .DMO_SERIE = mGR.GUI_SERIE
                            .DMO_NRO = mGR.GUI_NRO
                            .DetalleTipoDocumentos = BCTipoDocumento.TipoDocumentoGetById("016")
                            .DMO_FECHA = mGR.GUI_FECHA
                            .DMO_FECHA_DOCUMENTO = mGR.GUI_FECHA
                            .ORR_ID = Nothing
                            .PER_ID_PROVEEDOR = mGR.PER_ID_EMP_TRANSP
                            .MON_ID = "001" 'Soles
                            .OCO_ID = Nothing
                            .DOCU_AFECTA_KARDEX = True
                            .SCO_ID = Nothing
                            .DMO_ASIENTO = Nothing
                            .DMO_CIERRE = Nothing
                            .USU_ID = SessionServer.UserId
                            .DMO_FEC_GRAB = Now
                            .DMO_ESTADO = True
                            .CCT_ID = ""
                            .DMO_ID_REF = Nothing
                            .DRU_ID = Nothing
                            .CME_ID = Nothing
                            .CPA_ID = Nothing
                            .DTD_ID_REF = "278"
                        End With

                        For Each DetaGR In mGR.GuiaRemisionDetalle
                            DocumentacionDeta = New DocuMovimientoDetalle
                            With DocumentacionDeta
                                .ALM_ID = BCParametro.ParametroGetById("AlmMP").PAR_VALOR1 '141 'Materia Prima 28
                                .ART_ID = BCParametro.ParametroGetById(DetaGR.ART_ID).PAR_VALOR1 'cambia el codigo de una tierra por otro codigo de mp
                                .DMD_CANTIDAD = DetaGR.GUD_CANTIDAD
                                .DMD_DESCUENTO = 0
                                .DMD_PRECIO_UNITARIO = BCGuiaRemision.PrecioMateriaPrima(DetaGR.ART_ID, Today)
                                .DMD_IGV = 0
                                .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                                .DMD_GLOSA = "Salida materia prima."
                                .ORD_ID = Nothing
                                .OCD_ID = Nothing
                                .DMD_ID_REF = Nothing
                            End With
                            mDMO.DocuMovimientoDetalle.Add(DocumentacionDeta)
                        Next
                        If BCDocuMovimiento.MantenimientoDocuMovimiento(mDMO) = 1 Then
                            MessageBox.Show(mDMO.DMO_ID)
                            mDMOBorrar = Nothing
                        Else
                            For Each mItem In mDMOBorrar.DocuMovimientoDetalle
                                mItem.Alm_Ori = mItem.ALM_ID
                                mItem.Art_Ori = mItem.ART_ID
                                mItem.Kardex(0).MarkAsDeleted()
                                mItem.MarkAsDeleted()
                            Next
                            mDMOBorrar.MarkAsDeleted()
                            BCDocuMovimiento.MantenimientoDocuMovimiento(mDMOBorrar)
                            Err.Raise(&HFFFFFF01, "Error Provocado", "Insercion incorrecta.")

                        End If
                    End If
                End If
            Catch ex As Exception
                If mDMOBorrar IsNot Nothing Then
                    For Each mItem In mDMOBorrar.DocuMovimientoDetalle
                        mItem.Alm_Ori = mItem.ALM_ID
                        mItem.Art_Ori = mItem.ART_ID
                        mItem.Kardex(0).MarkAsDeleted()
                        mItem.MarkAsDeleted()
                    Next
                    mDMOBorrar.MarkAsDeleted()
                    BCDocuMovimiento.MantenimientoDocuMovimiento(mDMOBorrar)
                End If
                MessageBox.Show("Existe un Error, verificar Documentos " & ex.Message, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Next
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Procesar()
        btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        dgvProcesar.Rows.Clear()
        Dim query As String
        Dim ds As New DataSet
        query = BCGuiaRemision.ListaGuiaRemisionAProcesar(dtpFIProcesar.Value.Date, dtpFFProcesar.Value.Date)
        If Not query = "" Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            For Each mItem In ds.Tables(0).Rows
                Dim nRow As New DataGridViewRow
                dgvProcesar.Rows.Add(nRow)
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 2).Cells("GUI_ID").Value = mItem("GUI_ID")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 2).Cells("GUI_NRO").Value = mItem("GUI_NRO")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 2).Cells("GUI_FECHA").Value = mItem("GUI_FECHA")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 2).Cells("PER_APE_PAT").Value = mItem("PER_APE_PAT")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 2).Cells("ART_DESCRIPCION_PROCESAR").Value = mItem("ART_DESCRIPCION")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 2).Cells("GUD_CANTIDAD_PROCESAR").Value = mItem("GUD_CANTIDAD")
                dgvProcesar.Rows(dgvProcesar.Rows.Count - 2).Cells("PROCESO").Value = False
            Next
        End If
    End Sub

    Private Sub btnAtajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtajo.Click
        mGR = New GuiaRemision
        mGR.MarkAsAdded()
        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
            mDetalle.Cells("GUD_ID").Value = Nothing
            txtPlacaVeh.Tag = Nothing
            txtPlacaVeh.Text = String.Empty
        Next
        txtCodigo.Text = String.Empty
        txtNroRemision.Text = String.Empty
        BuscarSeries()
        Atajo = True
    End Sub

    Private Sub txtDestinatario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDestinatario.KeyDown
        If e.KeyCode = Keys.Enter Then txtDestinatario_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtTransportista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransportista.KeyDown
        If e.KeyCode = Keys.Enter Then txtTransportista_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtPlacaVeh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlacaVeh.KeyDown
        If e.KeyCode = Keys.Enter Then txtPlacaVeh_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()

        If dgvDetalle.CurrentCell.ColumnIndex = 1 And e.KeyCode = Keys.Enter Then
            frm.Tabla = "Articulo"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " - " & frm.dgvLista.CurrentRow.Cells(2).Value & " - " & frm.dgvLista.CurrentRow.Cells(3).Value 'ART_Descripcion
            End If
        End If
        frm.Dispose()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        dtpFechaInicioT.Value = dtpFecha.Value
    End Sub
End Class