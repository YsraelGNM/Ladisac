
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views

    Public Class frmCentroRiesgo
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCCentroRiesgo As Ladisac.BL.IBCCentroRiesgo
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil
        Protected oCentroRiesgo As New BE.CentroRiesgo

        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtDescripcion.Text.Trim = "") Then
                ErrorProvider1.SetError(txtDescripcion, "Centro de Riesgo")
                result = False
            Else
                ErrorProvider1.SetError(txtDescripcion, Nothing)
            End If
            If (Not IsNumeric(txtTasa.TabIndex)) Then
                ErrorProvider1.SetError(txtTasa, "Taza")
                result = False
            Else
                ErrorProvider1.SetError(txtTasa, Nothing)
            End If

            Return result
        End Function
        Private Sub limpiar()
            txtDescripcion.Text = ""
            txtId.Text = ""
            txtTasa.Text = ""
            
        End Sub

        Sub cargar(ByVal id As String)
            limpiar()
            oCentroRiesgo = BCCentroRiesgo.CentroRiesgoSeek(id)

            oCentroRiesgo.MarkAsModified()

            txtId.Text = oCentroRiesgo.cer_ID
            txtDescripcion.Text = oCentroRiesgo.cer_Descripcion
            txtTasa.Text = oCentroRiesgo.cer_Tasa

        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.CentroRiesgo)

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
                If (oCentroRiesgo.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.CentroRiesgo", "cer_ID", 2, "")
                End If

                oCentroRiesgo.cer_ID = IIf(txtId.Text = "", sCorrelativo, txtId.Text)
                oCentroRiesgo.cer_Descripcion = txtDescripcion.Text
                oCentroRiesgo.cer_Tasa = txtTasa.Text
                oCentroRiesgo.Usu_Id = SessionServer.UserId

                oCentroRiesgo.con_FECGRAB = Now

                Try
                    BCCentroRiesgo.Maintenance(oCentroRiesgo)
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
            oCentroRiesgo = New CentroRiesgo
            oCentroRiesgo.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oCentroRiesgo.MarkAsDeleted()

            oCentroRiesgo.cer_ID = txtId.Text
            oCentroRiesgo.cer_Descripcion = txtDescripcion.Text
            oCentroRiesgo.cer_Tasa = txtTasa.Text
            oCentroRiesgo.Usu_Id = SessionServer.UserId
            oCentroRiesgo.con_FECGRAB = Now
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCCentroRiesgo.Maintenance(oCentroRiesgo)
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

        Private Sub frmCentroRiesgo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub
    End Class
End Namespace
