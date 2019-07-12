
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmTareaTrabajo
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCTareaTrabajo As Ladisac.BL.IBCTareaTrabajo


        Protected oTareaTrabajo As New BE.TareaTrabajo
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtTarea.Text.Trim = "") Then
                ErrorProvider1.SetError(txtTarea, "Tarea")
                result = False
            Else
                ErrorProvider1.SetError(txtTarea, Nothing)
            End If

            If (txtfactor.Text = "" OrElse Not IsNumeric(txtfactor.Text)) Then
                ErrorProvider1.SetError(txtfactor, "Factor")
                result = False
            Else
                ErrorProvider1.SetError(txtfactor, Nothing)
            End If

            If (txtTipo.Text = "") Then
                ErrorProvider1.SetError(txtTipo, "Tipo")
                result = False
            Else
                ErrorProvider1.SetError(txtTipo, Nothing)
            End If

            Return result

        End Function
        Private Sub limpiar()

            txtTarea.Text = ""
            txtCodigo.Text = ""
            txtfactor.Text = ""
            txtArticulo.Text = ""
            txtArticulo.Tag = ""
            txtTipo.Text = ""
            txtTipo.Tag = ""
            chkActivo.Checked = False
            chkTareoPll.Checked = False

        End Sub
        Sub cargar(ByVal tipo As String, ByVal idTArea As String)
            limpiar()
            oTareaTrabajo = BCTareaTrabajo.TareaTrabajoSeek(tipo, idTArea)

            oTareaTrabajo.MarkAsModified()

            txtCodigo.Text = oTareaTrabajo.ttr_TareaTrab_Id
            txtTarea.Text = oTareaTrabajo.ttr_Tarea
            txtfactor.Text = oTareaTrabajo.ttr_Factor

            txtTipo.Text = oTareaTrabajo.TiposTareaTrabajo.tit_TiposTarea
            txtTipo.Tag = oTareaTrabajo.tit_TipTarea_Id
            Try
                txtArticulo.Text = IIf(IsDBNull(oTareaTrabajo.Articulos), "", oTareaTrabajo.Articulos.ART_DESCRIPCION)
                txtArticulo.Tag = IIf((oTareaTrabajo.art_Id) Is Nothing, "", oTareaTrabajo.art_Id)
            Catch ex As Exception
                txtArticulo.Text = ""
                txtArticulo.Tag = ""
            End Try

            chkActivo.Checked = oTareaTrabajo.ttr_Activo
            chkTareoPll.Checked = IIf(IsDBNull(oTareaTrabajo.ttr_DestajoTrabajadorPll), False, oTareaTrabajo.ttr_DestajoTrabajadorPll)

        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TareaTrabajo)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(1).Value, frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If

            frm.Dispose()
            Panel1.Enabled = False

        End Sub


        Public Overrides Sub OnManGuardar()
            If (validar()) Then

                oTareaTrabajo.ttr_TareaTrab_Id = txtCodigo.Text
                oTareaTrabajo.tit_TipTarea_Id = txtTipo.Tag
                oTareaTrabajo.ttr_Tarea = txtTarea.Text
                oTareaTrabajo.art_Id = IIf(txtArticulo.Tag = "", Nothing, txtArticulo.Tag)
                oTareaTrabajo.ttr_Factor = txtfactor.Text
                oTareaTrabajo.ttr_Activo = chkActivo.Checked

                oTareaTrabajo.ttr_DestajoTrabajadorPll = chkTareoPll.Checked

                oTareaTrabajo.Usu_Id = SessionServer.UserId
                oTareaTrabajo.ttr_FECGRAB = Now
                Try
                    BCTareaTrabajo.Maintenance(oTareaTrabajo)
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
            oTareaTrabajo = New BE.TareaTrabajo
            oTareaTrabajo.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oTareaTrabajo.MarkAsDeleted()

            oTareaTrabajo.ttr_TareaTrab_Id = txtCodigo.Text
            oTareaTrabajo.tit_TipTarea_Id = txtTipo.Tag
            oTareaTrabajo.ttr_Tarea = txtTarea.Text
            oTareaTrabajo.art_Id = txtArticulo.Text
            oTareaTrabajo.ttr_Factor = txtfactor.Text
            oTareaTrabajo.ttr_Activo = chkActivo.Checked
            oTareaTrabajo.Usu_Id = SessionServer.UserId
            oTareaTrabajo.ttr_FECGRAB = Now
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCTareaTrabajo.Maintenance(oTareaTrabajo)
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

        Private Sub frmTareaTrabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub

        Private Sub btnTipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipo.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposTareaTrabajo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtTipo.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtTipo.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
            End If
            frm.Dispose()
        End Sub


        Private Sub btnArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArticulo.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.ArticulosLista)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtArticulo.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtArticulo.Text = frm.dgbRegistro.CurrentRow.Cells(2).Value
            End If
            frm.Dispose()
        End Sub

        Private Sub btnLimpia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpia.Click
            txtArticulo.Tag = Nothing
            txtArticulo.Text = Nothing
        End Sub
    End Class
End Namespace