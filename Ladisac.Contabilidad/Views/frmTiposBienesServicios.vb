Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE

Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views
    Public Class frmTiposBienesServicios
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCTiposBienesServicios As Ladisac.BL.IBCTiposBienesServicios
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oTiposBienesServicios As New TiposBienesServicios
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtDescripcion.Text.Trim = "") Then
                ErrorProvider1.SetError(txtDescripcion, "Servicio")
                result = False
            Else
                ErrorProvider1.SetError(txtDescripcion, Nothing)
            End If

            If (txtPoncentaje.Text.Trim = "") Then
                ErrorProvider1.SetError(txtPoncentaje, "Porcentaje")
                result = False
            Else
                ErrorProvider1.SetError(txtPoncentaje, Nothing)

            End If

            Return result
        End Function
        Private Sub limpiar()
            txtDescripcion.Text = ""
            txtCodigo.Text = ""
            txtPoncentaje.Text = ""
        End Sub
        Sub cargar(ByVal id As String)
            limpiar()
            oTiposBienesServicios = BCTiposBienesServicios.TiposBienesServiciosSeek(id)

            oTiposBienesServicios.MarkAsModified()

            txtCodigo.Text = oTiposBienesServicios.tib_TipoBien_Id
            txtDescripcion.Text = oTiposBienesServicios.tib_Descripcion
            txtPoncentaje.Text = oTiposBienesServicios.tib_Poncentaje
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposBienesServicios)

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
                If (oTiposBienesServicios.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("con.TiposBienesServicios", "tib_TipoBien_Id", 3, "")
                End If

                oTiposBienesServicios.tib_TipoBien_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                oTiposBienesServicios.tib_Descripcion = txtDescripcion.Text
                oTiposBienesServicios.tib_Poncentaje = txtPoncentaje.Text

                oTiposBienesServicios.Usu_Id = SessionServer.UserId
                oTiposBienesServicios.tib_FECGRAB = Now

                Try
                    BCTiposBienesServicios.Maintenance(oTiposBienesServicios)
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
            oTiposBienesServicios = New BE.TiposBienesServicios
            oTiposBienesServicios.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oTiposBienesServicios.MarkAsDeleted()

            oTiposBienesServicios.tib_TipoBien_Id = txtCodigo.Text

            oTiposBienesServicios.Usu_Id = SessionServer.UserId
            oTiposBienesServicios.tib_FECGRAB = Now
            Try
                BCTiposBienesServicios.Maintenance(oTiposBienesServicios)
                Panel1.Enabled = False
                limpiar()
                MsgBox("Datos Eliminados")

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

        Private Sub frmTiposBienesServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub
    End Class
End Namespace
