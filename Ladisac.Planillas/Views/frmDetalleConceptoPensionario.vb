Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views

    Public Class frmDetalleConceptoPensionario

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCDetalleConceptoPensionario As Ladisac.BL.IBCDetalleConceptoPensionario
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oDetalleConceptosPensionarios As New DetalleConceptosPensionarios
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (chkRestrcciones.Checked) Then
                If (txtFactor.Text.Trim = "" AndAlso Not IsNumeric(txtFactor)) Then
                    ErrorProvider1.SetError(txtFactor, "Factor")
                    result = False
                Else
                    ErrorProvider1.SetError(txtFactor, Nothing)
                End If

                If (txtEdad.Text = "" AndAlso Not IsNumeric(txtEdad.Text)) Then
                    ErrorProvider1.SetError(txtEdad, "Edad")
                    result = False
                Else
                    ErrorProvider1.SetError(txtEdad, Nothing)
                End If
            End If

            If (txtRegimen.Text = "" OrElse txtRegimen.Tag = "") Then
                ErrorProvider1.SetError(txtRegimen, "Regimen")
                result = False
            Else
                ErrorProvider1.SetError(txtRegimen, Nothing)
            End If

            If (txtTipoConcepto.Tag = "" OrElse txtConcepto.Tag = "") Then
                ErrorProvider1.SetError(txtConcepto, "Concepto")
                result = False
            Else
                ErrorProvider1.SetError(txtConcepto, Nothing)
            End If

            Return result

        End Function
        Private Sub limpiar()
            txtConcepto.Tag = ""
            txtConcepto.Text = ""

            txtRegimen.Tag = ""
            txtRegimen.Text = ""

            txtTipoConcepto.Tag = ""
            txtTipoConcepto.Text = ""

            txtCuentaContable.Tag = ""
            txtCuentaContable.Text = ""

            txtFactor.Text = ""
            txtEdad.Text = "0"
            txtImporteMAximo.Text = "0"
            chkRestrcciones.Checked = False

        End Sub
        Sub cargar(ByVal rep_RegiPension_id As String, ByVal tic_TipoConcep_Id As String, ByVal con_Conceptos_Id As String)
            limpiar()
            Dim query As String

            oDetalleConceptosPensionarios = BCDetalleConceptoPensionario.DetalleConceptosPensionariosSeek(rep_RegiPension_id, tic_TipoConcep_Id, con_Conceptos_Id)

            oDetalleConceptosPensionarios.MarkAsModified()

            query = Me.BCDetalleConceptoPensionario.DetalleConceptosPensionariosDetalleQuery(rep_RegiPension_id, tic_TipoConcep_Id, con_Conceptos_Id)

            If (query <> Nothing) Then
                Dim ds As New DataSet

                Dim rea As New StringReader(query)

                If (query <> "") Then
                    ds.ReadXml(rea)

                    txtRegimen.Tag = oDetalleConceptosPensionarios.rep_RegiPension_id
                    txtRegimen.Text = ds.Tables(0).Rows(0).Item("rep_RegiPension_id").ToString

                    txtTipoConcepto.Tag = oDetalleConceptosPensionarios.tic_TipoConcep_Id
                    txtTipoConcepto.Text = ds.Tables(0).Rows(0).Item("tic_TipoConcep_Id").ToString

                    txtConcepto.Tag = oDetalleConceptosPensionarios.con_Conceptos_Id
                    txtConcepto.Text = ds.Tables(0).Rows(0).Item("con_Concepto").ToString

                    txtCuentaContable.Tag = oDetalleConceptosPensionarios.cuc_Id
                    txtCuentaContable.Text = ds.Tables(0).Rows(0).Item("CUC_DESCRIPCION").ToString

                    txtFactor.Text = oDetalleConceptosPensionarios.dcp_Factor
                    txtImporteMAximo.Text = oDetalleConceptosPensionarios.dcp_importeMaximo
                    txtEdad.Text = oDetalleConceptosPensionarios.dcp_EdadMaxima
                    chkRestrcciones.Checked = oDetalleConceptosPensionarios.dcp_esConRestriccion

                End If
            End If

        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.DetalleConceptoPensionario)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value, _
                       frm.dgbRegistro.CurrentRow.Cells(2).Value, _
                       frm.dgbRegistro.CurrentRow.Cells(1).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            If (validar()) Then

                oDetalleConceptosPensionarios.rep_RegiPension_id = txtRegimen.Tag
                oDetalleConceptosPensionarios.dcp_Factor = Val(txtFactor.Text)
                oDetalleConceptosPensionarios.cuc_Id = IIf(txtCuentaContable.Tag = "", Nothing, txtCuentaContable.Tag)
                oDetalleConceptosPensionarios.con_Conceptos_Id = txtConcepto.Tag
                oDetalleConceptosPensionarios.tic_TipoConcep_Id = txtTipoConcepto.Tag
                oDetalleConceptosPensionarios.Usu_Id = SessionServer.UserId
                oDetalleConceptosPensionarios.dcp_FECGRAB = Now
                oDetalleConceptosPensionarios.dcp_importeMaximo = txtImporteMAximo.Text
                oDetalleConceptosPensionarios.dcp_EdadMaxima = Val(txtEdad.Text)
                oDetalleConceptosPensionarios.dcp_esConRestriccion = chkRestrcciones.Checked

                Try
                    BCDetalleConceptoPensionario.Maintenance(oDetalleConceptosPensionarios)
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
            oDetalleConceptosPensionarios = New DetalleConceptosPensionarios
            oDetalleConceptosPensionarios.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oDetalleConceptosPensionarios.MarkAsDeleted()

            oDetalleConceptosPensionarios.rep_RegiPension_id = txtRegimen.Tag
            oDetalleConceptosPensionarios.dcp_Factor = txtFactor.Text
            oDetalleConceptosPensionarios.cuc_Id = txtCuentaContable.Tag
            oDetalleConceptosPensionarios.con_Conceptos_Id = txtConcepto.Tag
            oDetalleConceptosPensionarios.tic_TipoConcep_Id = txtTipoConcepto.Tag
            oDetalleConceptosPensionarios.Usu_Id = SessionServer.UserId
            oDetalleConceptosPensionarios.dcp_FECGRAB = Now
            oDetalleConceptosPensionarios.dcp_importeMaximo = txtImporteMAximo.Text
            oDetalleConceptosPensionarios.dcp_EdadMaxima = txtEdad.Text
            oDetalleConceptosPensionarios.dcp_esConRestriccion = chkRestrcciones.Checked
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCDetalleConceptoPensionario.Maintenance(oDetalleConceptosPensionarios)
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

        Private Sub frmDetalleConceptoPensionario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub

        Private Sub btnBuscarRegimen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarRegimen.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.RegimenPensionario)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtRegimen.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtRegimen.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
            End If
            frm.Dispose()
        End Sub

        Private Sub btnConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConcepto.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Conceptos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtConcepto.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtTipoConcepto.Tag = frm.dgbRegistro.CurrentRow.Cells(1).Value

                txtTipoConcepto.Text = frm.dgbRegistro.CurrentRow.Cells(2).Value
                txtConcepto.Text = frm.dgbRegistro.CurrentRow.Cells(3).Value
            End If
            frm.Dispose()

        End Sub

        Private Sub chkRestrcciones_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRestrcciones.CheckedChanged
            If (chkRestrcciones.Checked) Then
                Panel2.Enabled = True
            Else
                Panel2.Enabled = False
            End If
        End Sub

        Private Sub btnCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCuenta.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CuentasContables)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtCuentaContable.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtCuentaContable.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
            End If

            frm.Dispose()

        End Sub
    End Class
End Namespace