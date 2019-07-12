Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views
    Public Class frmClaseCuenta
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property IBCClaseCuenta As Ladisac.BL.IBCClaseCuenta
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oClaseCuenta As New ClaseCuenta
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
        Sub cargarNivelEducacion(ByVal id As String)
            limpiar()
            oClaseCuenta = IBCClaseCuenta.ClaseCuentaSeek(id)

            oClaseCuenta.MarkAsModified()

            txtCodigo.Text = oClaseCuenta.cls_Id
            txtDescripcion.Text = oClaseCuenta.cls_Clase

        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.ClaseCuenta)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargarNivelEducacion(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            Try
                Dim sCorrelativo As String = ""
                If (validar()) Then
                    If (oClaseCuenta.ChangeTracker.State = ObjectState.Added) Then
                        sCorrelativo = BCUtil.GetId("con.ClaseCuenta", "cls_Id", 2, "")
                    End If

                    oClaseCuenta.cls_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                    oClaseCuenta.cls_Clase = txtDescripcion.Text


                    oClaseCuenta.Usu_Id = SessionServer.UserId
                    oClaseCuenta.cls_FECGRAB = Now
                    IBCClaseCuenta.Maintenance(oClaseCuenta)
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
            oClaseCuenta = New BE.ClaseCuenta
            oClaseCuenta.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()

            Me.Dispose()
        End Sub

        Public Overrides Sub OnManEliminar()
            oClaseCuenta.MarkAsDeleted()

            oClaseCuenta.cls_Id = txtCodigo.Text
            oClaseCuenta.cls_Clase = txtDescripcion.Text

            oClaseCuenta.Usu_Id = SessionServer.UserId
            oClaseCuenta.cls_FECGRAB = Now
            ' verificar si se elimino

            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    IBCClaseCuenta.Maintenance(oClaseCuenta)
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

        Private Sub frmClaseCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub
    End Class
End Namespace