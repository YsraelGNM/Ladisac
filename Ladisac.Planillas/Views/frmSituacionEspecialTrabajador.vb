Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE

Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmSituacionEspecialTrabajador
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCSituacionEspecialTrabajador As Ladisac.BL.IBCSituacionEspecialTrabajador
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oSituacionEspecialTrabajador As New SituacionEspecialTrabajador
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtDescripcion.Text.Trim = "") Then
                ErrorProvider1.SetError(txtDescripcion, "Descripcion")
                result = False
            Else
                ErrorProvider1.SetError(txtDescripcion, Nothing)
            End If

            Return result
        End Function
        Private Sub limpiar()
            txtDescripcion.Text = ""
            txtCodigo.Text = ""
            txtCodigoSunat.Text = ""

        End Sub
        Sub cargarDatos(ByVal id As String)
            limpiar()
            oSituacionEspecialTrabajador = BCSituacionEspecialTrabajador.SituacionEspecialTrabajadorSeek(id)

            oSituacionEspecialTrabajador.MarkAsModified()

            txtCodigo.Text = oSituacionEspecialTrabajador.set_SituEspe_Id
            txtDescripcion.Text = oSituacionEspecialTrabajador.set_Descripcion
            txtCodigoSunat.Text = oSituacionEspecialTrabajador.set_CodigoSunat
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.SituacionEspecialTrabajador)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargarDatos(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            If (validar()) Then
                If (oSituacionEspecialTrabajador.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.SituacionEspecialTrabajador", "set_SituEspe_Id", 3, "")
                End If

                oSituacionEspecialTrabajador.set_SituEspe_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                oSituacionEspecialTrabajador.set_Descripcion = txtDescripcion.Text
                oSituacionEspecialTrabajador.set_CodigoSunat = txtCodigoSunat.Text
                oSituacionEspecialTrabajador.Usu_Id = SessionServer.UserId
                oSituacionEspecialTrabajador.set_FECGRAB = Now

                Try
                    BCSituacionEspecialTrabajador.Mantenance(oSituacionEspecialTrabajador)
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

            End If

        End Sub
        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oSituacionEspecialTrabajador = New SituacionEspecialTrabajador
            oSituacionEspecialTrabajador.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oSituacionEspecialTrabajador.MarkAsDeleted()

            oSituacionEspecialTrabajador.set_SituEspe_Id = txtCodigo.Text
            oSituacionEspecialTrabajador.set_Descripcion = txtDescripcion.Text
            oSituacionEspecialTrabajador.set_CodigoSunat = txtCodigoSunat.Text
            oSituacionEspecialTrabajador.Usu_Id = SessionServer.UserId
            oSituacionEspecialTrabajador.set_FECGRAB = Now

            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCSituacionEspecialTrabajador.Mantenance(oSituacionEspecialTrabajador)
                    Panel1.Enabled = False
                    limpiar()
                    ' fin de  verificar
                    MsgBox("Datos Eliminados")
                End If


            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                If (rethrow) Then
                    Throw
                End If
            End Try

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

        Private Sub frmRegimenPensionario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub
    End Class
End Namespace
