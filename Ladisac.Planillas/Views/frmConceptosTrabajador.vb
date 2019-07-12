Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views
    Public Class frmConceptosTrabajador
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCConceptosTrabajador As Ladisac.BL.IBCConceptosTrabajador
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil
        <Dependency()> _
        Public Property BCDatosLaborales As Ladisac.BL.IBCDatosLaborales

        Protected oConceptosTrabajador As New ConceptosTrabajador
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtConcepto.Text.Trim = "") Then
                ErrorProvider1.SetError(txtConcepto, "Concepto")
                result = False
            Else
                ErrorProvider1.SetError(txtConcepto, Nothing)
            End If

            If (txtImporte.Text = "" OrElse Not IsNumeric(txtImporte.Text)) Then
                ErrorProvider1.SetError(txtImporte, "Importe")
                result = False
            Else
                ErrorProvider1.SetError(txtImporte, Nothing)
            End If

            Return result
        End Function
        Private Sub limpiar()
            txtConcepto.Text = ""
            txtConcepto.Tag = ""

            txtTipoConcepto.Text = ""
            txtTipoConcepto.Tag = ""

            txtImporte.Text = ""

        End Sub

        Sub cargar(ByVal idPersona As String, ByVal idTipodConcepto As String, ByVal idConcepto As String)
            limpiar()
            oConceptosTrabajador = BCConceptosTrabajador.ConceptosTrabajadorSeek(idPersona, idTipodConcepto, idConcepto)

            oConceptosTrabajador.MarkAsModified()
            btnBucarRegimen.Enabled = False
            chkEsPorcentaje.Checked = oConceptosTrabajador.cot_EsPorcentaje

            'txtCodigo.Text = oAreaTrabajos.art_AreaTrab_Id
          

        End Sub

        Public Overrides Sub OnManBuscar()

            If (txtPersona.Tag <> "") Then
                limpiar()
                menuBuscar()
                buscar()
                Panel2.Enabled = False
                dataRegimen.Enabled = True
            Else
                MsgBox("Seleccione una persona ")
            End If

        End Sub

        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            If (validar()) Then

                oConceptosTrabajador.con_Conceptos_Id = txtConcepto.Tag
                oConceptosTrabajador.tic_TipoConcep_Id = txtTipoConcepto.Tag
                oConceptosTrabajador.cot_Importe = Val(txtImporte.Text)
                oConceptosTrabajador.per_Id = txtPersona.Tag
                oConceptosTrabajador.cot_EsPorcentaje = chkEsPorcentaje.Checked
                oConceptosTrabajador.Usu_Id = SessionServer.UserId
                oConceptosTrabajador.cot_FECGRAB = Now

                Try
                    BCConceptosTrabajador.Maintenance(oConceptosTrabajador)
                    MsgBox("Datos Guardados")
                    menuInicio()
                    Panel2.Enabled = False
                    dataRegimen.Enabled = False
                    limpiar()
                    concepto()

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

            If (txtPersona.Tag <> "") Then

                limpiar()
                oConceptosTrabajador = New ConceptosTrabajador
                oConceptosTrabajador.MarkAsAdded()
                Panel2.Enabled = True
                dataRegimen.Enabled = False
                btnBucarRegimen.Enabled = True
                menuNuevo()
            Else
                MsgBox("Seleccione una persona ")
            End If

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub
        Public Overrides Sub OnManEliminar()

            If (txtConcepto.Tag <> "") Then
                oConceptosTrabajador.MarkAsDeleted()
                oConceptosTrabajador.con_Conceptos_Id = txtConcepto.Tag
                oConceptosTrabajador.tic_TipoConcep_Id = txtTipoConcepto.Tag
                oConceptosTrabajador.cot_Importe = txtImporte.Text
                oConceptosTrabajador.per_Id = txtPersona.Tag
                oConceptosTrabajador.cot_EsPorcentaje = chkEsPorcentaje.Checked
                oConceptosTrabajador.Usu_Id = SessionServer.UserId
                oConceptosTrabajador.cot_FECGRAB = Now
                Try
                    If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                        BCConceptosTrabajador.Maintenance(oConceptosTrabajador)
                        Panel2.Enabled = False
                        limpiar()
                        MsgBox("Datos Eliminados")
                        dataRegimen.DataSource = Nothing
                    End If

                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                    If (rethrow) Then
                        Throw
                    End If

                End Try
                ErrorProvider1.SetError(txtConcepto, Nothing)
            Else
                ErrorProvider1.SetError(txtConcepto, "Concepto")
            End If


            ' fin de  verificar
        End Sub

        Public Overrides Sub OnManCancelarEdicion()
            menuInicio()
            Panel2.Enabled = False
            limpiar()
        End Sub
        Public Overrides Sub OnManEditar()
            pasarValiores()
            If (txtConcepto.Tag <> "") Then
                'cargar datos de conceptos
                menuEditar()
                Panel2.Enabled = True

            End If

        End Sub
        Public Overrides Sub OnManDeshacerCambios()
            menuInicio()
            Panel2.Enabled = False
            dataRegimen.Enabled = True
            limpiar()


        End Sub
        Public Sub concepto()
            Dim query As String
            query = Me.BCConceptosTrabajador.ConceptosTrabajadorQuery(txtPersona.Tag, Nothing, Nothing)

            dataRegimen.DataSource = Nothing

            If (query <> Nothing) Then

                Dim ds As New DataSet
                Dim rea As New StringReader(query)

                If (query <> "") Then
                    ds.ReadXml(rea)
                    dataRegimen.DataSource = ds.Tables(0)
                Else
                    dataRegimen.DataSource = Nothing
                End If

            End If
        End Sub
        Private Sub pasarValiores()
            If (dataRegimen.SelectedRows.Count > 0) Then
                'cargar datos de conceptos
                '-------------------------

                With dataRegimen.SelectedRows(0)
                    cargar(txtPersona.Tag, .Cells(0).Value, .Cells(1).Value)
                    txtImporte.Text = .Cells(3).Value
                    txtConcepto.Text = .Cells(2).Value
                    txtConcepto.Tag = .Cells(1).Value
                    txtTipoConcepto.Text = .Cells(0).Value
                    txtTipoConcepto.Tag = .Cells(0).Value
                End With

            Else
                MsgBox("Seleccione un Registro ")
            End If
        End Sub
        Private Sub buscar()
            Dim query As String
            query = Me.BCDatosLaborales.DatosLaboralesListaQuery( _
                IIf(txtTrabajador.Tag = "", Nothing, txtTrabajador.Tag), _
                Nothing, _
                Nothing, _
                IIf(txtTipoTrabajador.Tag = "", Nothing, txtTipoTrabajador.Tag), _
                IIf(txtRegimen.Tag = "", Nothing, txtRegimen.Tag))

            dataPersonas.DataSource = Nothing

            If (query <> Nothing) Then

                Dim ds As New DataSet
                Dim rea As New StringReader(query)

                If (query <> "") Then
                    ds.ReadXml(rea)
                    dataPersonas.DataSource = ds.Tables(0)
                Else
                    dataPersonas.DataSource = Nothing
                End If
            End If

        End Sub

        Private Sub frmConceptosTrabajador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel2.Enabled = False
        End Sub

        Private Sub btnLimpiarRegimen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarRegimen.Click

            txtRegimen.Tag = ""
            txtRegimen.Text = ""

        End Sub

        Private Sub btnTipoTrabLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoTrabLimpiar.Click
            txtTipoTrabajador.Tag = ""
            txtTipoTrabajador.Text = ""

        End Sub

        Private Sub btnBucarRegimen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBucarRegimen.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.RegimenPensionario)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtRegimen.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtRegimen.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
            End If
            frm.Dispose()

        End Sub

        Private Sub btnTipoTrabaBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoTrabaBuscar.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposTrabajador)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtTipoTrabajador.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtTipoTrabajador.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
            End If
            frm.Dispose()

        End Sub

        Private Sub btnConceptoBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConceptoBuscar.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Conceptos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtConcepto.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtTipoConcepto.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
                txtTipoConcepto.Tag = frm.dgbRegistro.CurrentRow.Cells(1).Value
                txtConcepto.Text = frm.dgbRegistro.CurrentRow.Cells(3).Value
            End If
            frm.Dispose()
         

        End Sub



        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            buscar()
        End Sub

        Private Sub dataPersonas_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dataPersonas.RowHeaderMouseDoubleClick
            Try
                If (dataPersonas.SelectedRows.Count > 0) Then
                    txtPersona.Tag = dataPersonas.SelectedRows(0).Cells(0).Value
                    txtPersona.Text = dataPersonas.SelectedRows(0).Cells(2).Value
                    concepto()
                Else
                    MsgBox("Seleccione un Registro")
                End If
            Catch ex As Exception

            End Try
        End Sub

       
        Private Sub dataRegimen_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataRegimen.CellContentDoubleClick
            pasarValiores()
        End Sub

        Private Sub dataRegimen_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dataRegimen.RowHeaderMouseDoubleClick
            pasarValiores()
        End Sub


        Private Sub btnTrabajador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrabajador.Click

            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.DatosLaborales)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtTrabajador.Tag = .Cells(0).Value()
                    txtTrabajador.Text = .Cells(2).Value
                    ' menuBuscar()
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnTrabajadorCLS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrabajadorCLS.Click

            txtTrabajador.Tag = ""
            txtTrabajador.Text = ""

        End Sub


    End Class

End Namespace