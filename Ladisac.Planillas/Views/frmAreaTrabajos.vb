

Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views

    Public Class frmAreaTrabajos

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCAreaTrabajos As Ladisac.BL.IBCAreaTrabajos
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil
        Protected oAreaTrabajos As New AreaTrabajos

        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtAreaTrabajo.Text.Trim = "") Then
                ErrorProvider1.SetError(txtAreaTrabajo, "Area de Trabajo")
                result = False
            Else
                ErrorProvider1.SetError(txtAreaTrabajo, Nothing)
            End If

            Return result
        End Function
        Private Sub limpiar()
            txtAreaTrabajo.Text = ""
            txtCodigo.Text = ""
            txtCodigoSunat.Text = ""
            chkEsPlanilla.Checked = False

        End Sub

        Sub cargar(ByVal id As String)
            limpiar()
            oAreaTrabajos = BCAreaTrabajos.AreaTrabajoSeek(id)

            oAreaTrabajos.MarkAsModified()

            txtCodigo.Text = oAreaTrabajos.art_AreaTrab_Id
            txtAreaTrabajo.Text = oAreaTrabajos.art_Descripcion
            txtCodigoSunat.Text = oAreaTrabajos.art_CodigoSunat
            chkEsPlanilla.Checked = oAreaTrabajos.art_EsPlanilla
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.AreaTrabajos)

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
                If (oAreaTrabajos.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.AreaTrabajos", "art_AreaTrab_Id", 3, "")
                End If

                oAreaTrabajos.art_AreaTrab_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                oAreaTrabajos.art_Descripcion = txtAreaTrabajo.Text
                oAreaTrabajos.art_CodigoSunat = txtCodigoSunat.Text
                oAreaTrabajos.Usu_Id = SessionServer.UserId
                oAreaTrabajos.art_EsPlanilla = chkEsPlanilla.Checked
                oAreaTrabajos.art_FECGRAB = Now

                Try
                    BCAreaTrabajos.Maintenance(oAreaTrabajos)
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
            oAreaTrabajos = New AreaTrabajos
            oAreaTrabajos.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oAreaTrabajos.MarkAsDeleted()

            oAreaTrabajos.art_AreaTrab_Id = txtCodigo.Text
            oAreaTrabajos.art_Descripcion = txtAreaTrabajo.Text
            oAreaTrabajos.art_CodigoSunat = txtCodigoSunat.Text
            oAreaTrabajos.Usu_Id = SessionServer.UserId
            oAreaTrabajos.art_FECGRAB = Now
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCAreaTrabajos.Maintenance(oAreaTrabajos)
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

        Private Sub frmAreaTrabajos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub
    End Class
End Namespace
