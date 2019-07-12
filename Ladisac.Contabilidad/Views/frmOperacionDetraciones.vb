Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views
    Public Class frmOperacionDetraciones
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCOperacionDetraciones As Ladisac.BL.IBCOperacionDetraciones
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oOperacionDetraciones As New BE.OperacionDetraciones
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
            oOperacionDetraciones = BCOperacionDetraciones.OperacionDetracionesSeek(id)
            oOperacionDetraciones.MarkAsModified()
            txtCodigo.Text = oOperacionDetraciones.opd_Oper_Detra_Id
            txtDescripcion.Text = oOperacionDetraciones.opd_Descripcion
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.OperacionDetraciones)

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
                    If (oOperacionDetraciones.ChangeTracker.State = ObjectState.Added) Then
                        sCorrelativo = BCUtil.GetId("Con.OperacionDetraciones", "opd_Oper_Detra_Id", 3, "")
                    End If

                    oOperacionDetraciones.opd_Oper_Detra_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                    oOperacionDetraciones.opd_Descripcion = txtDescripcion.Text


                    oOperacionDetraciones.Usu_Id = SessionServer.UserId
                    oOperacionDetraciones.opd_FECGRAB = Now
                    BCOperacionDetraciones.Maintenance(oOperacionDetraciones)
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
            oOperacionDetraciones = New BE.OperacionDetraciones
            oOperacionDetraciones.MarkAsAdded()
            Panel1.Enabled = True
        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub

        Public Overrides Sub OnManEliminar()
            oOperacionDetraciones.MarkAsDeleted()

            oOperacionDetraciones.opd_Oper_Detra_Id = txtCodigo.Text
            oOperacionDetraciones.opd_Descripcion = txtDescripcion.Text

            oOperacionDetraciones.Usu_Id = SessionServer.UserId
            oOperacionDetraciones.opd_FECGRAB = Now
            ' verificar si se elimino

            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCOperacionDetraciones.Maintenance(oOperacionDetraciones)
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

        Private Sub frmOperacionDetraciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()
            Panel1.Enabled = False

        End Sub
    End Class
End Namespace