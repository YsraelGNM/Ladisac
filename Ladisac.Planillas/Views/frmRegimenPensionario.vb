Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE

Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmRegimenPensionario
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCRegimenPensionario As Ladisac.BL.IBCRegimenPensionario
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oRegimenPensionario As New RegimenPensionario
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtNivelEducacion.Text.Trim = "") Then
                ErrorProvider1.SetError(txtNivelEducacion, "Descripcion")
                result = False
            Else
                ErrorProvider1.SetError(txtNivelEducacion, Nothing)
            End If

            Return result

        End Function
        Private Sub limpiar()
            txtNivelEducacion.Text = ""
            txtCodigo.Text = ""
            txtCodigoSunat.Text = ""

        End Sub
        Sub cargarRegimenPensionario(ByVal id As String)
            limpiar()
            oRegimenPensionario = BCRegimenPensionario.RegimenPensionarioSeek(id)

            oRegimenPensionario.MarkAsModified()

            txtCodigo.Text = oRegimenPensionario.rep_RegiPension_id
            txtNivelEducacion.Text = oRegimenPensionario.rep_Descripcion
            txtCodigoSunat.Text = oRegimenPensionario.rep_CodigoSunat
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.RegimenPensionario)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargarRegimenPensionario(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            If (validar()) Then
                If (oRegimenPensionario.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.RegimenPensionario", "rep_RegiPension_id", 3, "")
                End If

                oRegimenPensionario.rep_RegiPension_id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                oRegimenPensionario.rep_Descripcion = txtNivelEducacion.Text
                oRegimenPensionario.rep_CodigoSunat = txtCodigoSunat.Text
                oRegimenPensionario.Usu_Id = SessionServer.UserId
                oRegimenPensionario.rep_FECGRAB = Now
                Try
                    BCRegimenPensionario.Mantenance(oRegimenPensionario)
                    MsgBox("Datos ")
                    menuInicio()
                    Panel1.Enabled = False
                    limpiar()

                    'finde verificar
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
            oRegimenPensionario = New RegimenPensionario
            oRegimenPensionario.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oRegimenPensionario.MarkAsDeleted()

            oRegimenPensionario.rep_RegiPension_id = txtCodigo.Text
            oRegimenPensionario.rep_Descripcion = txtNivelEducacion.Text
            oRegimenPensionario.rep_CodigoSunat = txtCodigoSunat.Text
            oRegimenPensionario.Usu_Id = SessionServer.UserId
            oRegimenPensionario.rep_FECGRAB = Now
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then

                    BCRegimenPensionario.Mantenance(oRegimenPensionario)

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

        Private Sub frmRegimenPensionario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub
    End Class
End Namespace