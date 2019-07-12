Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports System.Net.Mail

Public Class frmSolicitudSoporte
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCSolicitudSoporte As Ladisac.BL.IBCSolicitudSoporte
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCPersona As Ladisac.BL.IBCPersona
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro
    Dim frmInputBox As New frmInputBox


    Protected SoSo As SolicitudSoporte

    Private Sub frmSolicitudSoporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        SoSo = Nothing
        dtpfecha.Value = Now
        txtCodigo.Text = String.Empty
        rbtLadisac.Checked = False
        rbtSpring.Checked = False
        txtSolicitado.Text = String.Empty
        txtSolicitado.Tag = Nothing
        cboArea.SelectedIndex = -1
        txtAutorizado.Text = String.Empty
        txtAutorizado.Tag = Nothing
        txtDescripcion.Text = String.Empty
        dgvDetalle.Rows.Clear()
        rdbConforme.Checked = False
        rdbNoConforme.Checked = False
        rbtH.Checked = False
        rbtS.Checked = False
        rbtU.Checked = False
        txtConformidad.Text = String.Empty
        rbtNecesidad.Checked = False
        rbtAjuste.Checked = False
        If SessionServer.UserId = "ADMIN" Or SessionServer.UserId = "YNUNEZ" Or SessionServer.UserId = "AMARTINEZ" Or SessionServer.UserId = "RSALAS" Or SessionServer.UserId = "MSAIRA" Then
            GroupBox2.Visible = True
            GroupBox3.Visible = True
        End If
        

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
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Foundation.Views.frmBuscar)()
        frm.Tabla = "SolicitudSoporte"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarSolicitudSoporte(key)
            LlenarControles()
            ''---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarSolicitudSoporte(ByVal SOS_ID As Integer)
        SoSo = BCSolicitudSoporte.SolicitudSoporteGetById(SOS_ID)
        SoSo.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = SoSo.SOS_ID
        dtpfecha.Value = SoSo.SOS_FECHA

        If SoSo.SOS_SISTEMA IsNot Nothing Then
            If SoSo.SOS_SISTEMA = 1 Then
                rbtLadisac.Checked = True
            Else
                rbtSpring.Checked = 2
            End If
        End If


        If SoSo.Personas IsNot Nothing Then
            txtSolicitado.Text = SoSo.Personas.PER_APE_PAT & " " & SoSo.Personas.PER_APE_MAT & " " & SoSo.Personas.PER_NOMBRES
            txtSolicitado.Tag = SoSo.PER_ID_SOLICITADO
        End If
        cboArea.Text = SoSo.SOS_AREA
        If SoSo.Personas1 IsNot Nothing Then
            txtAutorizado.Text = SoSo.Personas1.PER_APE_PAT & " " & SoSo.Personas1.PER_APE_MAT & " " & SoSo.Personas1.PER_NOMBRES
            txtAutorizado.Tag = SoSo.PER_ID_AUTORIZADO
        End If
        txtDescripcion.Text = SoSo.SOS_DESCRIPCION

        For Each mItem In SoSo.SolicitudSoporteDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SSD_MENSAJE").Value = mItem.SSD_MENSAJE.ToString
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SSD_MENSAJE").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SSD_FECHA").Value = mItem.SSD_FECHA
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).ReadOnly = True
        Next

        Select Case SoSo.SOS_TIPO
            Case 1
                rbtH.Checked = True
            Case 2
                rbtS.Checked = True
            Case 3
                rbtU.Checked = True
        End Select

        Select Case SoSo.SOS_SUB_TIPO
            Case 1
                rbtNecesidad.Checked = True
            Case 2
                rbtAjuste.Checked = True
        End Select

        If SoSo.SOS_CONFORMIDAD = 1 Then
            rdbConforme.Checked = True
        Else
            rdbNoConforme.Checked = True
        End If
        txtConformidad.Text = SoSo.SOS_DESCRIPCION_CONFORMIDAD
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar

        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------
        If SoSo IsNot Nothing Then
            SoSo.SOS_FECHA = dtpfecha.Value

            If rbtLadisac.Checked Then
                SoSo.SOS_SISTEMA = 1 'Ladisac
            Else
                SoSo.SOS_SISTEMA = 2 'Spring
            End If

            SoSo.PER_ID_SOLICITADO = txtSolicitado.Tag
            SoSo.SOS_AREA = cboArea.Text
            SoSo.PER_ID_AUTORIZADO = txtAutorizado.Tag
            SoSo.SOS_DESCRIPCION = txtDescripcion.Text

            If rbtH.Checked Then
                SoSo.SOS_TIPO = 1
            ElseIf rbtS.Checked Then
                SoSo.SOS_TIPO = 2
            ElseIf rbtU.Checked Then
                SoSo.SOS_TIPO = 3
            End If

            If rbtNecesidad.Checked Then
                SoSo.SOS_SUB_TIPO = 1
            ElseIf rbtAjuste.Checked Then
                SoSo.SOS_SUB_TIPO = 2
            End If

            dgvDetalle.EndEdit()
            Dim Mensaje As String

            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("SSD_MENSAJE").Tag Is Nothing Then
                    With CType(mDetalle.Cells("SSD_MENSAJE").Tag, SolicitudSoporteDetalle)
                        .SSD_MENSAJE = mDetalle.Cells("SSD_MENSAJE").Value
                        .SSD_FECHA = mDetalle.Cells("SSD_FECHA").Value
                        .MarkAsModified()
                    End With
                    Mensaje = Mensaje & mDetalle.Cells("SSD_MENSAJE").Value & "<br/>"
                ElseIf Not mDetalle.Cells("SSD_MENSAJE").Value Is Nothing Then
                    Dim nSSD As New SolicitudSoporteDetalle
                    With nSSD
                        .SSD_MENSAJE = SessionServer.UserName & ": " & mDetalle.Cells("SSD_MENSAJE").Value
                        .SSD_FECHA = mDetalle.Cells("SSD_FECHA").Value
                        .MarkAsAdded()
                    End With
                    SoSo.SolicitudSoporteDetalle.Add(nSSD)
                    Mensaje = Mensaje & nSSD.SSD_MENSAJE & "<br/>"
                End If
            Next

            If rdbConforme.Checked Then
                SoSo.SOS_CONFORMIDAD = 1
                Mensaje = Mensaje & "Estado SoSo : " & rdbConforme.Text & " Conforme <br/>"
            ElseIf rdbNoConforme.Checked Then
                SoSo.SOS_CONFORMIDAD = 2
                Mensaje = Mensaje & "Estado SoSo : " & rdbNoConforme.Text & " Conforme <br/>"
            End If

            SoSo.SOS_ESTADO = True
            SoSo.SOS_FEC_GRAB = Now
            SoSo.USU_ID = SessionServer.UserId

            If BCSolicitudSoporte.MantenimientoSolicitudSoporte(SoSo) > 0 Then
                Dim PER = BCPersona.PersonaGetById(SoSo.PER_ID_SOLICITADO)
                EnviarEmail("Solicitud de Soporte Nro: " & SoSo.SOS_ID.ToString & " -- " & txtDescripcion.Text, "ynunez@ladrilleraeldiamante.com", "msaira@ladrilleraeldiamante.com", "amartinez@ladrilleraeldiamante.com", PER.PER_EMAIL.ToString, txtSolicitado.Text, Mensaje)
                MessageBox.Show(SoSo.SOS_ID)
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
        SoSo = New SolicitudSoporte
        SoSo.MarkAsAdded()

        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        OnManAgregarFilaGrid()

    End Sub

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True
        Error_Validacion.Clear()
        If Len(txtSolicitado.Text.Trim) = 0 Then Error_Validacion.SetError(txtSolicitado, "Ingrese Solicitado") : txtSolicitado.Focus() : flag = False
        If cboArea.SelectedIndex = -1 Then Error_Validacion.SetError(cboArea, "Ingrese el Area") : cboArea.Focus() : flag = False
        If Len(txtDescripcion.Text.Trim) = 0 Then Error_Validacion.SetError(txtDescripcion, "Ingrese descripcion del problema") : txtDescripcion.Focus() : flag = False
        If rbtLadisac.Checked = False And rbtSpring.Checked = False Then Error_Validacion.SetError(rbtLadisac, "Marque un Sistema") : flag = False

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
        If SessionServer.UserId = "ADMIN" Or SessionServer.UserId = "MSAIRA" Then

            If SoSo IsNot Nothing Then
                For CONT As Integer = SoSo.SolicitudSoporteDetalle.Count - 1 To 0 Step -1
                    SoSo.SolicitudSoporteDetalle(CONT).MarkAsDeleted()
                Next
                SoSo.MarkAsDeleted()
                BCSolicitudSoporte.MantenimientoSolicitudSoporte(SoSo)
            End If
            Call LimpiarControles()
            Call validacion_desactivacion(False, 7)

        End If
    End Sub
    Public Overrides Sub OnManSalir()
        Me.Dispose()
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SSD_FECHA").Value = Now
    End Sub

    Private Sub txtSolicitado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSolicitado.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Foundation.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtSolicitado.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            txtSolicitado.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtAutorizado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAutorizado.DoubleClick

        'Dim frm = Me.ContainerService.Resolve(Of Ladisac.Foundation.Views.frmBuscar)()
        'frm.Tabla = "Persona"
        'frm.Tipo = "Trabajador"
        'If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    txtAutorizado.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
        '    txtAutorizado.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
        'End If
        'frm.Dispose()

        Try
            If SessionServer.UserId <> "ADMIN" Then
                If frmInputBox.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If Not frmInputBox.txtPassword.Text = BCParametro.ParametroGetById(SessionServer.UserId & "SOSO1").PAR_VALOR1 Then
                        MessageBox.Show("No ha ingresado una clave valida. Se cancelara la autorizacion.")
                    Else
                        txtAutorizado.Tag = SessionServer.Usuario.PER_ID 'Per_Id
                        txtAutorizado.Text = SessionServer.UserName  'Nombres
                    End If
                Else
                    MessageBox.Show("No ha ingresado una clave valida. Se cancelara la autorizacion.")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("No tiene permiso para ejecutar esta accion.")
        End Try
    End Sub

    Private Sub txtSolicitado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSolicitado.KeyDown
        If e.KeyCode = Keys.Enter Then txtSolicitado_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtAutorizado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAutorizado.KeyDown
        If e.KeyCode = Keys.Enter Then txtAutorizado_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub EnviarEmail(ByVal Asunto As String, ByVal correo1 As String, ByVal correo2 As String, ByVal correo3 As String, ByVal correo4 As String, ByVal Quien As String, ByVal Cuerpo As String)
        Dim SmtpServer As New SmtpClient()
        Dim mail As New MailMessage()
        Dim eTo, eNuestroCorreo, eNuestraContraseña As String

        Try
            eNuestroCorreo = "sistemas@ladrilleraeldiamante.com"
            eNuestraContraseña = "sistemas123"
            SmtpServer.Port = 25
            SmtpServer.Host = "smtpparla.spamina.com"
            SmtpServer.EnableSsl = True
            SmtpServer.Credentials = New Net.NetworkCredential(eNuestroCorreo, eNuestraContraseña)
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
            mail.To.Add(correo3)
            mail.To.Add("rahit.salas@ladrilleraeldiamante.com")
            Try
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

    Private Sub txtAutorizado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAutorizado.TextChanged

    End Sub

    Private Sub btnAtendido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtendido.Click
        OnManAgregarFilaGrid()
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SSD_MENSAJE").Value = "Hecho, verificar."
    End Sub
End Class
