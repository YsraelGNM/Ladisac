Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE

Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmTiposPlanillas

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCTiposPlanillas As Ladisac.BL.IBCTiposPlanillas
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oTiposPlanillas As New TiposPlanillas

        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtTipoPlanilla.Text.Trim = "") Then
                ErrorProvider1.SetError(txtTipoPlanilla, "Descripcion")
                result = False
            Else
                ErrorProvider1.SetError(txtTipoPlanilla, Nothing)
            End If

            Return result
        End Function
        Private Sub limpiar()
            txtTipoPlanilla.Text = ""
            txtCodigo.Text = ""
            chkEsGrupoPLanillas.Checked = False
        End Sub
        Sub cargar(ByVal id As String)
            limpiar()
            oTiposPlanillas = BCTiposPlanillas.TiposPlanillasSeek(id)

            oTiposPlanillas.MarkAsModified()

            txtCodigo.Text = oTiposPlanillas.tip_TipoPlan_Id
            txtTipoPlanilla.Text = oTiposPlanillas.tip_Descripcion
            chkEsGrupoPLanillas.Checked = oTiposPlanillas.tip_EsAcumuladoDePlanillas
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposPlanillas)

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
                If (oTiposPlanillas.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.TiposPlanillas", "tip_TipoPlan_Id", 3, "")
                End If
                oTiposPlanillas.tip_TipoPlan_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                oTiposPlanillas.tip_Descripcion = txtTipoPlanilla.Text
                oTiposPlanillas.tip_EsAcumuladoDePlanillas = chkEsGrupoPLanillas.Checked
                oTiposPlanillas.Usu_Id = SessionServer.UserId
                oTiposPlanillas.tip_FECGRAB = Now
                Try
                    BCTiposPlanillas.Maintenance(oTiposPlanillas)
                    menuInicio()
                    Panel1.Enabled = False
                    limpiar()
                    MsgBox("Datos Guardados")
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
            oTiposPlanillas = New TiposPlanillas
            oTiposPlanillas.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub

        Public Overrides Sub OnManEliminar()

            oTiposPlanillas.MarkAsDeleted()

            oTiposPlanillas.tip_TipoPlan_Id = txtCodigo.Text
            oTiposPlanillas.tip_Descripcion = txtTipoPlanilla.Text
            oTiposPlanillas.tip_EsAcumuladoDePlanillas = chkEsGrupoPLanillas.Checked
            oTiposPlanillas.Usu_Id = SessionServer.UserId
            oTiposPlanillas.tip_FECGRAB = Now
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCTiposPlanillas.Maintenance(oTiposPlanillas)

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


        Private Sub frmTiposPlanillas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub
    End Class
End Namespace