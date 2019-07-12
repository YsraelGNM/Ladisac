
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views

    Public Class frmCalendarioDias

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCCalendarioDias As Ladisac.BL.IBCCalendarioDias

        Protected oCalendarioDias As New BE.CalendarioDias

        Sub cargar(ByVal id As Date)

            oCalendarioDias = BCCalendarioDias.CalendarioDiasSeek(id)

            oCalendarioDias.MarkAsModified()

            dateCalendario.SelectionStart = oCalendarioDias.cadi_Fecha

        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarFecha)()
            frm.inicio(Constants.BuscadoresNames.CalendarioDias)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()

            oCalendarioDias.cadi_Fecha = dateCalendario.SelectionStart
            oCalendarioDias.cadi_FECGRAB = Now

            Try
                BCCalendarioDias.Maintenance(oCalendarioDias)
                MsgBox("Datos Guardados")
                menuInicio()
                Panel1.Enabled = False

            Catch ex As Exception
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                'If (rethrow) Then
                '    Throw
                'End If
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Overrides Sub OnManNuevo()

            menuNuevo()
            oCalendarioDias = New BE.CalendarioDias
            oCalendarioDias.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oCalendarioDias.MarkAsDeleted()

            oCalendarioDias.cadi_Fecha = dateCalendario.SelectionStart
            oCalendarioDias.cadi_FECGRAB = Now
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCCalendarioDias.Maintenance(oCalendarioDias)
                    Panel1.Enabled = False

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
        End Sub
        Public Overrides Sub OnManEditar()
            MsgBox("No se Puede Modificar, solo eliminar")

            'menuEditar()
            'Panel1.Enabled = True
        End Sub
        Public Overrides Sub OnManDeshacerCambios()
            menuInicio()
            Panel1.Enabled = False

        End Sub

        Private Sub frmCalendarioDias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()
            Panel1.Enabled = False
        End Sub
    End Class

End Namespace
