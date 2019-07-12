Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling


Namespace Ladisac.Planillas.Views

    Public Class frmSituacionTrabajador

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCSituacionTrabajador As Ladisac.BL.IBCSituacionTrabajador
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oSituacionTrabajador As New SituacionTrabajador
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
            oSituacionTrabajador = BCSituacionTrabajador.SituacionTrabajadorSeek(id)

            oSituacionTrabajador.MarkAsModified()

            txtCodigo.Text = oSituacionTrabajador.sit_SituaTrab_Id
            txtDescripcion.Text = oSituacionTrabajador.sit_Descripcion
            txtCodigoSunat.Text = oSituacionTrabajador.sit_CodigoSunat
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.SituacionTrabajador)

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
                If (oSituacionTrabajador.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.SituacionTrabajador", "sit_SituaTrab_Id", 3, "")
                End If

                oSituacionTrabajador.sit_SituaTrab_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                oSituacionTrabajador.sit_Descripcion = txtDescripcion.Text
                oSituacionTrabajador.sit_CodigoSunat = txtCodigoSunat.Text
                oSituacionTrabajador.Usu_Id = SessionServer.UserId
                oSituacionTrabajador.sit_FECGRAB = Now

                Try
                    BCSituacionTrabajador.Mantenance(oSituacionTrabajador)
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
            oSituacionTrabajador = New SituacionTrabajador
            oSituacionTrabajador.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oSituacionTrabajador.MarkAsDeleted()

            oSituacionTrabajador.sit_SituaTrab_Id = txtCodigo.Text
            oSituacionTrabajador.sit_Descripcion = txtDescripcion.Text
            oSituacionTrabajador.sit_CodigoSunat = txtCodigoSunat.Text
            oSituacionTrabajador.Usu_Id = SessionServer.UserId
            oSituacionTrabajador.sit_FECGRAB = Now
            Try
                ' verificar si se elimino
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCSituacionTrabajador.Mantenance(oSituacionTrabajador)

                    Panel1.Enabled = False
                    limpiar()
                    ' fin de verificar
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


        Private Sub frmSituacionTrabajador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub
    End Class
End Namespace
