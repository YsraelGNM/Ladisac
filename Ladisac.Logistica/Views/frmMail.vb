Imports System.Net.Mail
Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmMail

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        ''Dim SmtpServer As New SmtpClient
        ''Dim mail As New MailMessage
        ''Dim eTo, eNuestroCorreo, eNuestraContraseña As String
        ''Try
        ''    eNuestroCorreo = txtCorreo.Text
        ''    eNuestraContraseña = txtContrasena.Text
        ''    SmtpServer.Port = 25
        ''    SmtpServer.Host = "mail.ladrilleraeldiamante.com"
        ''    SmtpServer.EnableSsl = False
        ''    SmtpServer.Credentials = New Net.NetworkCredential(eNuestroCorreo, eNuestraContraseña)
        ''    mail = New MailMessage
        ''    mail.From = New MailAddress(eNuestroCorreo)
        ''    mail.Subject = txtAsunto.Text
        ''    mail.Body = txtCuerpo.Text
        ''    mail.IsBodyHtml = True
        ''    For Each mFila As DataGridViewRow In dgvDetalle.Rows
        ''        mail.To.Clear()
        ''        eTo = mFila.Cells("correo").Value
        ''        mail.To.Add(eTo)
        ''        SmtpServer.Send(mail)
        ''    Next
        ''    MsgBox("Correo enviado")
        ''    Me.DialogResult = Windows.Forms.DialogResult.OK

        ''Catch ex As Exception
        ''    MsgBox(ex.Message)
        ''End Try
        Dim oApp As Object
        oApp = CreateObject("Outlook.Application")

        ' Crear un nuevo elemento de correo.
        Dim oMsg As Object
        oMsg = oApp.CreateItem(0)
        Dim oAttachs As Object
        oAttachs = oMsg.Attachments
        Dim oAttach As Object
        Try
            oAttach = oAttachs.Add("D:\Firma.png", , 0 + 1, "Firma")
        Catch ex As Exception
            MessageBox.Show("No hay Firma")
        End Try


        oMsg.Subject = txtAsunto.Text
        oMsg.Body = txtCuerpo.Text


        oMsg.HTMLBody = oMsg.HTMLBody & "<br/><br/><img src=Firma.png>"

        For Each mFila As DataGridViewRow In dgvDetalle.Rows
            'mail.To.Clear()
            'eTo = mFila.Cells("correo").Value
            'mail.To.Add(eTo)
            'SmtpServer.Send(mail)

            oMsg.To = Nothing
            oMsg.To = mFila.Cells("correo").Value
            'mostrar mail
            oMsg.Display()
        Next

    End Sub

    Function GetBoiler(ByVal sFile As String) As String
        Dim fso As Object
        Dim ts As Object
        fso = CreateObject("Scripting.FileSystemObject")
        ts = fso.GetFile(sFile).OpenAsTextStream(1, -2)
        GetBoiler = ts.readall
        ts.Close()
    End Function

    Private Sub dgvDetalle_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDetalle.CellMouseDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "razonsocial"
                frm.Tabla = "Persona"
                frm.Tipo = "Proveedor"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
                    dgvDetalle.CurrentRow.Cells("correo").Value = frm.dgvLista.CurrentRow.Cells(4).Value 'per_mail
                End If
        End Select
        frm.Dispose()
    End Sub

    Private Sub btnAgregarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarProveedor.Click
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
    End Sub

    Private Sub frmMail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarCorreo()
    End Sub

    Sub CargarCorreo()
        txtCorreo.Text = "compras@ladrilleraeldiamante.com"
        txtContrasena.Text = "compras2017"
    End Sub

End Class
