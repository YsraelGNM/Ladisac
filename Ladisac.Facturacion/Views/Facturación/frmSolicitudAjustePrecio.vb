Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports System.Net.Mail

Public Class frmSolicitudAjustePrecio
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCSolicitudAjustePrecio As Ladisac.BL.IBCSolicitudAjustePrecio
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCPersona As Ladisac.BL.IBCPersona
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro
    <Dependency()> _
    Public Property BCPuntoVenta As Ladisac.BL.IBCPuntoVenta

    Protected SAP As SolicitudAjustePrecio
    Public pPVE_ID As String

    Private Sub frmSolicitudSoporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
        txtPuntoVenta.Text = pPVE_ID
        txtPuntoVentaDescripcion.Text = BCPuntoVenta.PuntoVentaGetById(pPVE_ID).PVE_DESCRIPCION
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        SAP = Nothing
        dtpfecha.Value = Now
        txtCodigo.Text = String.Empty
        txtCliente.Text = String.Empty
        txtCliente.Tag = Nothing
        dgvDetalle.Rows.Clear()
        '------------------------
        Error_Validacion.Clear()
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

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "SolicitudAjustePrecio"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarSolicitudAjustePrecio(key)
            LlenarControles()
            ''---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarSolicitudAjustePrecio(ByVal SAP_ID As Integer)
        SAP = BCSolicitudAjustePrecio.SolicitudAjustePrecioGetById(SAP_ID)
        SAP.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = SAP.SAP_ID
        dtpfecha.Value = SAP.SAP_FECHA
        txtCliente.Text = SAP.Personas1.PER_APE_PAT & " " & SAP.Personas1.PER_APE_MAT & " " & SAP.Personas1.PER_NOMBRES
        txtCliente.Tag = SAP.PER_ID_CLI

        For Each mItem In SAP.SolicitudAjustePrecioDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("APD_ID").Value = mItem.APD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("APD_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ART_ID").Value = mItem.ART_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Descripcion").Value = mItem.Articulos.ART_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("LPR_ID").Value = mItem.LPR_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PRECIO_NORMAL").Value = mItem.APD_PRECIO_NORMAL
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("APD_TIPO_PRECIO").Value = mItem.APD_TIPO_PRECIO
            If mItem.APD_FLAG = 1 Then
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).ReadOnly = True
            End If
        Next

    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar

        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------
        If SAP IsNot Nothing Then
            SAP.SAP_FECHA = dtpfecha.Value
            SAP.PER_ID_SOLICITADO = SessionServer.Usuario.PER_ID
            SAP.PER_ID_CLI = txtCliente.Tag

            dgvDetalle.EndEdit()

            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("APD_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("APD_ID").Tag, SolicitudAjustePrecioDetalle)
                        .ART_ID = mDetalle.Cells("ART_ID").Value
                        .APD_PRECIO_NORMAL = CDec(mDetalle.Cells("PRECIO_NORMAL").Value)
                        .APD_OBSERVACION = mDetalle.Cells("APD_OBSERVACION").Value
                        .LPR_ID = mDetalle.Cells("LPR_ID").Value
                        .APD_TIPO_PRECIO = mDetalle.Cells("APD_TIPO_PRECIO").Value
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("ART_ID").Value Is Nothing Then
                    Dim nAPD As New SolicitudAjustePrecioDetalle
                    With nAPD
                        .ART_ID = mDetalle.Cells("ART_ID").Value
                        .APD_PRECIO_NORMAL = CDec(mDetalle.Cells("PRECIO_NORMAL").Value)
                        .APD_PRECIO_APROBADO = 0
                        .APD_OBSERVACION = mDetalle.Cells("APD_OBSERVACION").Value
                        .LPR_ID = mDetalle.Cells("LPR_ID").Value
                        .APD_TIPO_PRECIO = mDetalle.Cells("APD_TIPO_PRECIO").Value
                        .MarkAsAdded()
                    End With
                    SAP.SolicitudAjustePrecioDetalle.Add(nAPD)
                End If
            Next

            SAP.SAP_ESTADO = True
            SAP.SAP_FEC_GRAB = Now
            SAP.USU_ID = SessionServer.UserId

            If BCSolicitudAjustePrecio.MantenimientoSolicitudAjustePrecio(SAP) > 0 Then
                Dim PER = BCPersona.PersonaGetById(SAP.PER_ID_SOLICITADO)
                If PER IsNot Nothing Then
                    EnviarEmail("Solicitud de Ajuste Precio Nro: " & SAP.SAP_ID.ToString, "ynunez@ladrilleraeldiamante.com", "arojas@ladrilleraeldiamante.com", PER.PER_EMAIL.ToString, "", PER.PER_APE_PAT & " " & PER.PER_APE_MAT & " " & PER.PER_NOMBRES, txtCliente.Text)
                Else
                    MessageBox.Show("Falta datos en el Usuario.")
                End If
                MessageBox.Show(SAP.SAP_ID)
                LimpiarControles()
            Else
                MessageBox.Show("Error en la Grabación.")
            End If

        End If

        '------------------------------------------
        Call validacion_desactivacion(False, 3)

    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        SAP = New SolicitudAjustePrecio
        SAP.MarkAsAdded()

        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        OnManAgregarFilaGrid()

    End Sub

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True
        Error_Validacion.Clear()
        If Len(txtCliente.Text.Trim) = 0 Then Error_Validacion.SetError(txtCliente, "Ingrese Solicitado") : txtCliente.Focus() : flag = False

        If dgvDetalle.Rows.Count = 0 Then Error_Validacion.SetError(dgvDetalle, "Ingrese un Articulo en el detalle.") : dgvDetalle.Focus() : flag = False

        For Each mFila As DataGridViewRow In dgvDetalle.Rows
            Dim lpr As String = dgvDetalle.Rows(0).Cells("LPR_ID").Value
            If (mFila.Cells("ART_ID").Value & "") = "" Then Error_Validacion.SetError(dgvDetalle, "Ingrese un Codigo de Articulo en el detalle.") : dgvDetalle.Focus() : flag = False
            'If lpr <> mFila.Cells("LPR_ID").Value Then Error_Validacion.SetError(dgvDetalle, "La Lista de Precio tiene que ser igual en todos los detalles.") : dgvDetalle.Focus() : flag = False
        Next

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'codigos agregados===================================================
    Public Overrides Sub OnReportes()
        Dim frm = Me.ContainerService.Resolve(Of frmRptSolicitudSoporte)()
        frm.MdiParent = Me.ContainerService.Resolve(Of Ladisac.Foundation.MainWindow)()
        frm.Show()
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
        If SAP IsNot Nothing Then
            SAP.SAP_ESTADO = False
            SAP.MarkAsModified()
            BCSolicitudAjustePrecio.MantenimientoSolicitudAjustePrecio(SAP)
        End If

        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub
    Public Overrides Sub OnManSalir()
        Me.Dispose()
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
    End Sub

    Private Sub txtCliente_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Cliente"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtCliente.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
            txtCliente.Text = frm.dgvLista.CurrentRow.Cells("Nombre").Value 'Nombres
            dgvDetalle.Rows.Clear()
        End If
        frm.Dispose()
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.F1 Then txtCliente_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub EnviarEmail(ByVal Asunto As String, ByVal correo1 As String, ByVal correo2 As String, ByVal correo3 As String, ByVal correo4 As String, ByVal Quien As String, ByVal Cuerpo As String)
        Dim SmtpServer As New SmtpClient()
        Dim mail As New MailMessage()
        Dim eTo, eNuestroCorreo, eNuestraContraseña As String

        Try
            eNuestroCorreo = "sistemas@ladrilleraeldiamante.com"
            eNuestraContraseña = "Sistemas1"
            SmtpServer.Port = 25
            SmtpServer.Host = "mail.ladrilleraeldiamante.com"
            SmtpServer.EnableSsl = False
            'SmtpServer.Credentials = New Net.NetworkCredential(eNuestroCorreo, eNuestraContraseña)
            mail = New MailMessage()
            mail.From = New MailAddress(eNuestroCorreo)
            mail.Subject = Asunto
            mail.Body = "Solicitado por: " & Quien & "<br/>" & _
                        Cuerpo

            mail.IsBodyHtml = True

            'For Each mDestinatario In gridDestinatarios.Rows
            mail.To.Clear()
            'Destinatario del Mensaje
            'eTo = "ynunez@ladrilleraeldiamante.com"
            'Destinatarios del correo
            'mail.To.Add(eTo)
            mail.To.Add(correo1)
            mail.To.Add(correo2)
            Try
                mail.To.Add(correo3)
                mail.To.Add(correo4)
            Catch ex As Exception
                MsgBox("No tiene correo en el Sistema.")
            End Try
            'Le decimos que envíe el correo
            SmtpServer.Send(mail)
            'Next

            'Msgbox dando el Ok del envío
            'MsgBox("Correo enviado")
        Catch ex As Exception
            'Msgbox informandonos si existiera algún error
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        If txtCliente.Tag = Nothing Then Exit Sub
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "ART_ID"
                frm.Tabla = "ListaPrecioArticulo"
                frm.Tipo = pPVE_ID
                frm.Art_Id = dgvDetalle.CurrentCell.EditedFormattedValue
                frm.Tipo2 = txtCliente.Tag
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(2).Value 'aRT_ID
                    dgvDetalle.CurrentRow.Cells("Descripcion").Value = frm.dgvLista.CurrentRow.Cells(3).Value
                    dgvDetalle.CurrentRow.Cells("LPR_ID").Value = frm.dgvLista.CurrentRow.Cells(0).Value
                    If frm.dgvLista.Columns(frm.dgvLista.CurrentCell.ColumnIndex).Name = "Precio" Then
                        dgvDetalle.CurrentRow.Cells("PRECIO_NORMAL").Value = frm.dgvLista.CurrentCell.Value
                        dgvDetalle.CurrentRow.Cells("APD_TIPO_PRECIO").Value = "PN"
                    ElseIf frm.dgvLista.Columns(frm.dgvLista.CurrentCell.ColumnIndex).Name = "PrecioIncEnvio" Then
                        dgvDetalle.CurrentRow.Cells("PRECIO_NORMAL").Value = frm.dgvLista.CurrentCell.Value
                        dgvDetalle.CurrentRow.Cells("APD_TIPO_PRECIO").Value = "PE"
                    End If
                End If
        End Select
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle_CellDoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub txtPuntoVenta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPuntoVenta.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "PuntoventaXUsu_Id"
        frm.Tipo = SessionServer.UserId
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPuntoVenta.Text = frm.dgvLista.CurrentRow.Cells(0).Value
            pPVE_ID = frm.dgvLista.CurrentRow.Cells(0).Value
            txtPuntoVentaDescripcion.Text = frm.dgvLista.CurrentRow.Cells(1).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub txtPuntoVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPuntoVenta.KeyDown
        If e.KeyCode = Keys.Enter Then txtPuntoVenta_DoubleClick(Nothing, Nothing)
    End Sub
End Class
