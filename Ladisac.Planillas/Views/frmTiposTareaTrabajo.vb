Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views
    Public Class frmTiposTareaTrabajo
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCTiposTareaTrabajo As Ladisac.BL.IBCTiposTareaTrabajo
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oTiposTareaTrabajo As New TiposTareaTrabajo
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtTarea.Text.Trim = "") Then
                ErrorProvider1.SetError(txtTarea, "Tarea")
                result = False
            Else
                ErrorProvider1.SetError(txtTarea, Nothing)
            End If

            Return result
        End Function
        Private Sub limpiar()
            txtTarea.Text = ""
            txtCodigo.Text = ""

        End Sub
        Sub cargar(ByVal id As String)
            limpiar()
            oTiposTareaTrabajo = BCTiposTareaTrabajo.TiposTareaTrabajoSeek(id)

            oTiposTareaTrabajo.MarkAsModified()

            txtCodigo.Text = oTiposTareaTrabajo.tit_TipTarea_Id
            txtTarea.Text = oTiposTareaTrabajo.tit_TiposTarea

        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposTareaTrabajo)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            If (validar()) Then
                If (oTiposTareaTrabajo.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.TiposTareaTrabajo", "tit_TipTarea_Id", 3, "")
                End If

                oTiposTareaTrabajo.tit_TipTarea_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                oTiposTareaTrabajo.tit_TiposTarea = txtTarea.Text

                oTiposTareaTrabajo.Usu_Id = SessionServer.UserId
                oTiposTareaTrabajo.tit_FECGRAB = Now
                Try
                    BCTiposTareaTrabajo.Maintenance(oTiposTareaTrabajo)
                    MsgBox("Datos Guardados")
                    menuInicio()
                    Panel1.Enabled = False
                    limpiar()
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                    If (rethrow) Then
                        Throw
                    End If
                End Try
                'finde verificar
            End If
        End Sub

        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oTiposTareaTrabajo = New BE.TiposTareaTrabajo
            oTiposTareaTrabajo.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oTiposTareaTrabajo.MarkAsDeleted()

            oTiposTareaTrabajo.tit_TipTarea_Id = txtCodigo.Text
            oTiposTareaTrabajo.tit_TiposTarea = txtTarea.Text

            oTiposTareaTrabajo.Usu_Id = SessionServer.UserId
            oTiposTareaTrabajo.tit_FECGRAB = Now
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCTiposTareaTrabajo.Maintenance(oTiposTareaTrabajo)
                    Panel1.Enabled = False
                    limpiar()
                    MsgBox("Datos Eliminados")
                End If




            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                If (rethrow) Then
                    Throw
                End If

            End Try

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

        Private Sub frmTiposTareaTrabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub
    End Class
End Namespace