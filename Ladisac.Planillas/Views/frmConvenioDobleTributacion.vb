Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views
    Public Class frmConvenioDobleTributacion

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property BCConvenioDobleTributacion As Ladisac.BL.IBCConvenioDobleTributacion

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oConvenioDobleTributacion As New ConvenioDobleTributacion
        Private Function validar() As Boolean
            Dim result As Boolean = True
            If (txtConvenioTributacion.Text.Trim = "") Then
                ErrorProvider1.SetError(txtConvenioTributacion, "Descripcion")
                result = False
            Else
                ErrorProvider1.SetError(txtConvenioTributacion, Nothing)
            End If

            Return result
        End Function
        Private Sub limpiar()
            txtCodigo.Text = Nothing
            txtConvenioTributacion.Text = Nothing
            txtCodigoSunat.Text = Nothing
        End Sub

        Sub cargarConvenioDobleTributacion(ByVal id As String)
            limpiar()
            oConvenioDobleTributacion = BCConvenioDobleTributacion.ConvenioDobleTributacionSeek(id)
            oConvenioDobleTributacion.MarkAsModified()
            txtCodigo.Text = oConvenioDobleTributacion.cod_DobleTribu_Id
            txtConvenioTributacion.Text = oConvenioDobleTributacion.cod_Descripcion
            txtCodigoSunat.Text = oConvenioDobleTributacion.cod_CodigoSunat

        End Sub
        Public Overrides Sub OnManBuscar()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.ConvenioDobleTributacion)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargarConvenioDobleTributacion(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False
        End Sub
        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            If (validar()) Then
                If (oConvenioDobleTributacion.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.ConvenioDobleTributacion", "cod_DobleTribu_Id", 3, "")
                End If

                oConvenioDobleTributacion.cod_DobleTribu_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                oConvenioDobleTributacion.cod_Descripcion = txtConvenioTributacion.Text
                oConvenioDobleTributacion.cod_CodigoSunat = txtCodigoSunat.Text
                oConvenioDobleTributacion.Usu_Id = SessionServer.UserId
                oConvenioDobleTributacion.cod_FECGRAB = Now
                Try
                    BCConvenioDobleTributacion.MAintenance(oConvenioDobleTributacion)

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
            oConvenioDobleTributacion = New ConvenioDobleTributacion
            oConvenioDobleTributacion.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oConvenioDobleTributacion.MarkAsDeleted()

            oConvenioDobleTributacion.cod_DobleTribu_Id = txtCodigo.Text
            oConvenioDobleTributacion.cod_Descripcion = txtConvenioTributacion.Text
            oConvenioDobleTributacion.cod_CodigoSunat = txtCodigoSunat.Text
            oConvenioDobleTributacion.Usu_Id = SessionServer.UserId
            oConvenioDobleTributacion.cod_FECGRAB = Now
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCConvenioDobleTributacion.MAintenance(oConvenioDobleTributacion)
                    MsgBox("Datos Guardados")
                    Panel1.Enabled = False
                    limpiar()
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

        Private Sub frmConvenioDobleTributacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub
    End Class
End Namespace
