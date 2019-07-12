Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views

    Public Class frmCtaCte

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCCtaCte As Ladisac.BL.IBCCtaCte
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oCtaCte As New CtaCte
        Private Function validar() As Boolean
            Dim result As Boolean = True
            If (txtDescripcion.Text.Trim = "") Then
                ErrorProvider1.SetError(txtDescripcion, "Clase")
                result = False
            Else
                ErrorProvider1.SetError(txtDescripcion, Nothing)
            End If
            Return result
        End Function
        Private Sub limpiar()
            txtDescripcion.Text = ""
            txtCodigo.Text = ""
        End Sub

        Sub cargar(ByVal id As String)

            limpiar()
            oCtaCte = BCCtaCte.CtaCteSeek(id)
            oCtaCte.MarkAsModified()

            txtCodigo.Text = oCtaCte.CCT_ID
            txtDescripcion.Text = oCtaCte.CCT_DESCRIPCION
            cboTipo.SelectedIndex = IIf(oCtaCte.CCT_ACT_PAS, 1, 0)
            chkEstado.Checked = oCtaCte.CCT_ESTADO
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.CtaCte)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            Try
                Dim sCorrelativo As String = ""
                If (validar()) Then
                    If (oCtaCte.ChangeTracker.State = ObjectState.Added) Then
                        sCorrelativo = BCUtil.GetId("Mae.CtaCte", "CCT_ID", 3, "")
                    End If

                    oCtaCte.CCT_ID = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                    oCtaCte.CCT_DESCRIPCION = txtDescripcion.Text
                    oCtaCte.CCT_ACT_PAS = cboTipo.SelectedIndex
                    oCtaCte.CCT_ESTADO = chkEstado.Checked
                    oCtaCte.USU_ID = SessionServer.UserId
                    oCtaCte.CCT_FEC_GRAB = Now
                    BCCtaCte.Maintenance(oCtaCte)
                    MsgBox("Datos Guardados")
                    menuInicio()
                    Panel1.Enabled = False
                    limpiar()
                End If
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oCtaCte = New BE.CtaCte
            oCtaCte.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()

            Me.Dispose()
        End Sub

        Public Overrides Sub OnManEliminar()

            MsgBox("Las cuentas corrientes no se eliminan,solo cambian de estado")


            'oCtaCte.MarkAsDeleted()

            'oCtaCte.CCT_ID = txtCodigo.Text
            'oCtaCte.CCT_DESCRIPCION = txtDescripcion.Text
            'oCtaCte.CCT_ACT_PAS = cboTipo.SelectedIndex
            'oCtaCte.CCT_ESTADO = chkEstado.Checked
            'oCtaCte.USU_ID = SessionServer.UserId
            'oCtaCte.CCT_FEC_GRAB = Now
            '' verificar si se elimino

            'Try
            '    If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
            '        BCCtaCte.Maintenance(oCtaCte)
            '        Panel1.Enabled = False
            '        limpiar()
            '        MsgBox("Datos Eliminados")

            '    End If


            'Catch ex As Exception
            '    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
            '    If (rethrow) Then
            '        Throw
            '    End If
            'End Try

            ' fin de  verificar
        End Sub

        Public Overrides Sub OnManCancelarEdicion()
            menuInicio()
            Panel1.Enabled = False
            limpiar()
        End Sub
        Public Overrides Sub OnManEditar()
            menuEditar()
            Panel1.Enabled = True
        End Sub
        Public Overrides Sub OnManDeshacerCambios()
            menuInicio()
            Panel1.Enabled = False
            limpiar()
        End Sub

        Private Sub frmCtaCte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            cboTipo.SelectedIndex = 0
            menuInicio()

            Panel1.Enabled = False
        End Sub

       
    End Class
End Namespace