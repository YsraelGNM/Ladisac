Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views
    Public Class frmTiposTrabajador
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCTiposTrabajador As Ladisac.BL.IBCTiposTrabajador
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oTiposTrabajadro As New TiposTrabajador
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtTiposTrabajador.Text.Trim = "") Then
                ErrorProvider1.SetError(txtTiposTrabajador, "Tipos de Trabajador")
                result = False
            Else
                ErrorProvider1.SetError(txtTiposTrabajador, Nothing)
            End If

            Return result
        End Function
        Private Sub limpiar()
            txtTiposTrabajador.Text = ""
            txtCodigo.Text = ""
            txtCodigoSunat.Text = ""

        End Sub
        Sub cargarTiposTrabajadores(ByVal id As String)
            limpiar()
            oTiposTrabajadro = BCTiposTrabajador.TiposTrabajadorSeek(id)

            oTiposTrabajadro.MarkAsModified()

            txtCodigo.Text = oTiposTrabajadro.tit_TipoTrab_Id
            txtTiposTrabajador.Text = oTiposTrabajadro.tit_Descripcion
            txtCodigoSunat.Text = oTiposTrabajadro.tit_CodigoSunat
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposTrabajador)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargarTiposTrabajadores(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            If (validar()) Then
                If (oTiposTrabajadro.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.TiposTrabajador", "tit_TipoTrab_Id", 3, "")
                End If

                oTiposTrabajadro.tit_TipoTrab_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                oTiposTrabajadro.tit_Descripcion = txtTiposTrabajador.Text
                oTiposTrabajadro.tit_CodigoSunat = txtCodigoSunat.Text
                oTiposTrabajadro.Usu_Id = SessionServer.UserId
                oTiposTrabajadro.tit_FECGRAB = Now
                Try
                    BCTiposTrabajador.Maintenance(oTiposTrabajadro)
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
            oTiposTrabajadro = New TiposTrabajador
            oTiposTrabajadro.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oTiposTrabajadro.MarkAsDeleted()

            oTiposTrabajadro.tit_TipoTrab_Id = txtCodigo.Text
            oTiposTrabajadro.tit_Descripcion = txtTiposTrabajador.Text
            oTiposTrabajadro.tit_CodigoSunat = txtCodigoSunat.Text
            oTiposTrabajadro.Usu_Id = SessionServer.UserId
            oTiposTrabajadro.tit_FECGRAB = Now
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCTiposTrabajador.Maintenance(oTiposTrabajadro)
                    Panel1.Enabled = False
                    limpiar()
                    MsgBox("DAtos Eliminados")

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

       

        Private Sub frmTiposTrabajador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub
    End Class
End Namespace