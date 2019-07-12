Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmTiposCargos
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCTiposCargos As Ladisac.BL.IBCTiposCargos
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oTiposcargos As New TiposCargos

        Private Function validar() As Boolean
            Dim result As Boolean = True
            If (txtTiposCargor.Text.Trim = "") Then
                ErrorProvider1.SetError(txtTiposCargor, "Periodisidad")
                result = False
            Else
                ErrorProvider1.SetError(txtTiposCargor, Nothing)

            End If

            Return result
        End Function
        Private Sub limpiar()
            txtTiposCargor.Text = ""
            txtCodigo.Text = ""
            txtCodigoSunat.Text = ""

        End Sub
        Sub cargarTiposCargos(ByVal id As String)
            limpiar()
            oTiposcargos = BCTiposCargos.TiposCargosSeek(id)

            oTiposcargos.MarkAsModified()

            txtCodigo.Text = oTiposcargos.tis_TipCargo_Id
            txtTiposCargor.Text = oTiposcargos.tis_Descripcion
            txtCodigoSunat.Text = oTiposcargos.tis_CodigoSunat
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposCargos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargarTiposCargos(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            If (validar()) Then
                If (oTiposcargos.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.TiposCargos", "tis_TipCargo_Id", 3, "")
                End If

                oTiposcargos.tis_TipCargo_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                oTiposcargos.tis_Descripcion = txtTiposCargor.Text
                oTiposcargos.tis_CodigoSunat = txtCodigoSunat.Text
                oTiposcargos.Usu_Id = SessionServer.UserId
                oTiposcargos.tis_FECGRAB = Now
                Try
                    BCTiposCargos.Maintenance(oTiposcargos)

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
            oTiposcargos = New TiposCargos
            oTiposcargos.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oTiposcargos.MarkAsDeleted()

            oTiposcargos.tis_TipCargo_Id = txtCodigo.Text ' IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
            oTiposcargos.tis_Descripcion = txtTiposCargor.Text
            oTiposcargos.tis_CodigoSunat = txtCodigoSunat.Text
            oTiposcargos.Usu_Id = SessionServer.UserId
            oTiposcargos.tis_FECGRAB = Now
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCTiposCargos.Maintenance(oTiposcargos)
                    ' verificar si se elimino
                    Panel1.Enabled = False
                    limpiar()
                    ' fin de  verificar
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

        Private Sub frmPeriodisidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub


    End Class
End Namespace