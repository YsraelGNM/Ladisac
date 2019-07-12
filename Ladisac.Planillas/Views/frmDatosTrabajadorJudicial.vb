
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmDatosTrabajadorJudicial

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCDatosTrabajadorJudicial As Ladisac.BL.IBCDatosTrabajadorJudicial

        Protected oDatosTrabajadorJudicial As New DatosTrabajadorJudicial

        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtSerie.Text.Trim = "") Then
                ErrorProvider1.SetError(txtSerie, "Serie")
                result = False
            Else
                ErrorProvider1.SetError(txtSerie, Nothing)
            End If

            If (txtBeneficiario.Tag.Trim = "") Then
                ErrorProvider1.SetError(txtBeneficiario, "Beneficiario")
                result = False
            Else
                ErrorProvider1.SetError(txtBeneficiario, Nothing)
            End If

            If (txtTrabajador.Tag.Trim = "") Then
                ErrorProvider1.SetError(txtTrabajador, "Trabajador")
                result = False
            Else
                ErrorProvider1.SetError(txtTrabajador, Nothing)
            End If

            If (dgvDetalle.Rows.Count <= 0) Then
                ErrorProvider1.SetError(dgvDetalle, "Conceptos")
                result = False
            Else
                ErrorProvider1.SetError(dgvDetalle, Nothing)
            End If


            Return result
        End Function
        Public Function validarCeldas(ByVal tip_TipoPlan_Id As String, ByVal dtj_idTiposConceptos As String, ByVal con_Conceptos_Id As String)
            Dim result As Boolean = True
            Dim x As Integer = 0

           
          
            While (dgvDetalle.RowCount > x)
                With dgvDetalle.Rows(x)
                    If (.Cells("tip_TipoPlan_Id").Value = tip_TipoPlan_Id _
                        AndAlso .Cells("dtj_idTiposConceptos").Value = dtj_idTiposConceptos _
                        AndAlso .Cells("con_Conceptos_Id").Value = con_Conceptos_Id) Then
                        Return True
                    End If
                End With
                x += 1
            End While

            Return False
        End Function
        Private Sub limpiar()

            txtSerie.Text = ""
            txtNumero.Text = ""
            txtBeneficiario.Tag = ""
            txtBeneficiario.Text = ""
            txtTrabajador.Tag = ""
            txtTrabajador.Text = ""
            txtObservaciones.Text = ""
            chkActivo.Checked = True
            dgvDetalle.Rows.Clear()

        End Sub
        Sub cargar(ByVal serie As String, ByVal numero As String)
            limpiar()
            oDatosTrabajadorJudicial = BCDatosTrabajadorJudicial.DatosTrabajadorJudicialSeek(serie, numero)
            oDatosTrabajadorJudicial.MarkAsModified()

            txtSerie.Text = oDatosTrabajadorJudicial.dtj_SerieJudi
            txtNumero.Text = oDatosTrabajadorJudicial.dtj_NumeroJudi
            dateFechaInicio.Value = oDatosTrabajadorJudicial.dtj_FechaInici
            dateFechaFin.Value = oDatosTrabajadorJudicial.dtj_FechaFin
            txtTrabajador.Tag = oDatosTrabajadorJudicial.per_IdTrab

            txtTrabajador.Text = IIf(IsNothing(oDatosTrabajadorJudicial.Personas1.PER_APE_PAT), "", oDatosTrabajadorJudicial.Personas1.PER_APE_PAT) & " " & _
                IIf(IsNothing(oDatosTrabajadorJudicial.Personas1.PER_APE_MAT), "", oDatosTrabajadorJudicial.Personas1.PER_APE_MAT) & " " & _
                IIf(IsNothing(oDatosTrabajadorJudicial.Personas1.PER_NOMBRES), "", oDatosTrabajadorJudicial.Personas1.PER_NOMBRES)

            txtBeneficiario.Tag = oDatosTrabajadorJudicial.per_IdBeneficiario

            txtBeneficiario.Text = IIf(IsNothing(oDatosTrabajadorJudicial.Personas.PER_APE_PAT), "", oDatosTrabajadorJudicial.Personas.PER_APE_PAT) & " " & _
                IIf(IsNothing(oDatosTrabajadorJudicial.Personas.PER_APE_MAT), "", oDatosTrabajadorJudicial.Personas.PER_APE_MAT) & " " & _
                IIf(IsNothing(oDatosTrabajadorJudicial.Personas.PER_NOMBRES), "", oDatosTrabajadorJudicial.Personas.PER_NOMBRES)
            txtObservaciones.Text = oDatosTrabajadorJudicial.dtj_Observaciones

            For Each mItem In oDatosTrabajadorJudicial.DetalleTrabajadorJudicial
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Value = mItem.dtj_NumeroJudi
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Tag = mItem
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tip_TipoPlan_Id").Value = mItem.tip_TipoPlan_Id
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Planilla").Value = mItem.TiposPlanillas.tip_Descripcion
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtj_idTiposConceptos").Value = mItem.dtj_idTiposConceptos
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("con_Conceptos_Id").Value = mItem.con_Conceptos_Id
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Conceptos").Value = mItem.Conceptos.con_Concepto
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Importe").Value = mItem.dtj_Importe
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("EsPorcentaje").Value = mItem.dtj_EsPorcenteje

            Next

        End Sub
        Public Overrides Sub OnManAgregarFilaGrid()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.campo1 = Nothing
            frm.campo2 = 1
            frm.campo3 = Nothing
            frm.inicio(Constants.BuscadoresNames.DetalleConceptosPlanillasLista)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                If Not (validarCeldas(frm.dgbRegistro.CurrentRow.Cells(0).Value, frm.dgbRegistro.CurrentRow.Cells(2).Value, frm.dgbRegistro.CurrentRow.Cells(4).Value)) Then

                    Dim nRow As New DataGridViewRow
                    dgvDetalle.Rows.Add(nRow)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Value = Nothing
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Tag = Nothing
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tip_TipoPlan_Id").Value = frm.dgbRegistro.CurrentRow.Cells(0).Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Planilla").Value = frm.dgbRegistro.CurrentRow.Cells(1).Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtj_idTiposConceptos").Value = frm.dgbRegistro.CurrentRow.Cells(2).Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("con_Conceptos_Id").Value = frm.dgbRegistro.CurrentRow.Cells(4).Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Conceptos").Value = frm.dgbRegistro.CurrentRow.Cells(5).Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Importe").Value = "0.00"
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("EsPorcentaje").Value = False
                Else
                    MsgBox("Ya existe esta planilla")
                End If
            End If
            frm.Dispose()

        End Sub
        Public Overrides Sub OnManQuitarFilaGrid()




            If (dgvDetalle.SelectedRows.Count > 0) Then

                For Each mDetalle As DataGridViewRow In dgvDetalle.SelectedRows
                    If Not mDetalle.Cells("Numero").Value Is Nothing Then
                        With CType(mDetalle.Cells("Numero").Tag, BE.DetalleTrabajadorJudicial)
                            .MarkAsDeleted()
                        End With
                    End If
                Next

                dgvDetalle.Rows.Remove(dgvDetalle.SelectedRows(0))
            Else
                MsgBox("Seleccione un registro")
            End If
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.DatosTrabajadorJudicial)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value, frm.dgbRegistro.CurrentRow.Cells(1).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            If (validar()) Then
                Try
                    If oDatosTrabajadorJudicial IsNot Nothing Then
                        dgvDetalle.EndEdit()

                        oDatosTrabajadorJudicial.per_IdTrab = txtTrabajador.Tag
                        oDatosTrabajadorJudicial.dtj_Observaciones = txtObservaciones.Text
                        oDatosTrabajadorJudicial.dtj_FechaInici = dateFechaInicio.Value
                        oDatosTrabajadorJudicial.dtj_Estado = chkActivo.Checked
                        oDatosTrabajadorJudicial.dtj_SerieJudi = txtSerie.Text
                        oDatosTrabajadorJudicial.dtj_NumeroJudi = txtNumero.Text
                        oDatosTrabajadorJudicial.per_IdBeneficiario = txtBeneficiario.Tag
                        oDatosTrabajadorJudicial.Usu_Id = SessionServer.UserId
                        oDatosTrabajadorJudicial.dtj_FECGRAB = Now
                        oDatosTrabajadorJudicial.dtj_FechaFin = dateFechaFin.Value

                        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                            If Not mDetalle.Cells("Numero").Value Is Nothing Then
                                With CType(mDetalle.Cells("Numero").Tag, BE.DetalleTrabajadorJudicial)

                                    .con_Conceptos_Id = mDetalle.Cells("con_Conceptos_Id").Value
                                    .dtj_idTiposConceptos = mDetalle.Cells("dtj_idTiposConceptos").Value
                                    .dtj_Importe = mDetalle.Cells("Importe").Value
                                    .dtj_EsPorcenteje = mDetalle.Cells("EsPorcentaje").Value
                                    .tip_TipoPlan_Id = mDetalle.Cells("tip_TipoPlan_Id").Value
                                    .Usu_Id = SessionServer.UserId
                                    .dtj_FECGRAB = Now
                                    .MarkAsModified()
                                End With
                            ElseIf Not mDetalle.Cells("Importe").Value Is Nothing Then
                                Dim nOSD As New DetalleTrabajadorJudicial
                                With nOSD
                                    .con_Conceptos_Id = mDetalle.Cells("con_Conceptos_Id").Value
                                    .dtj_idTiposConceptos = mDetalle.Cells("dtj_idTiposConceptos").Value
                                    .dtj_Importe = mDetalle.Cells("Importe").Value
                                    .dtj_EsPorcenteje = IIf(IsNothing(mDetalle.Cells("EsPorcentaje").Value), False, mDetalle.Cells("EsPorcentaje").Value)
                                    .tip_TipoPlan_Id = mDetalle.Cells("tip_TipoPlan_Id").Value
                                    .Usu_Id = SessionServer.UserId
                                    .dtj_FECGRAB = Now
                                    .MarkAsAdded()
                                End With
                                oDatosTrabajadorJudicial.DetalleTrabajadorJudicial.Add(nOSD)
                            End If
                        Next

                        BCDatosTrabajadorJudicial.Maintenance(oDatosTrabajadorJudicial)
                        MsgBox("Datos Guardados")
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()
                        DeshabilitarElementoGrid()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If

        End Sub

        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oDatosTrabajadorJudicial = New BE.DatosTrabajadorJudicial
            oDatosTrabajadorJudicial.MarkAsAdded()
            HabilitarElementoGrid()
            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            MsgBox("Estos Datos No se Eliminan solo se Desactivan ")
        End Sub

        Public Overrides Sub OnManCancelarEdicion()
            menuInicio()
            Panel1.Enabled = False
            limpiar()
        End Sub
        Public Overrides Sub OnManEditar()
            menuEditar()
            Panel1.Enabled = True
            HabilitarElementoGrid()
        End Sub
        Public Overrides Sub OnManDeshacerCambios()
            menuInicio()
            Panel1.Enabled = False
            limpiar()
        End Sub

        Private Sub frmDatosTrabajadorJudicial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
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
            ' Panel1.Enabled = False

        End Sub

        Private Sub btnBeneficiario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeneficiario.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.BuscarPersona)
            If (frm.ShowDialog = DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtBeneficiario.Tag = .Cells(0).Value
                    txtBeneficiario.Text = .Cells(1).Value
                End With
            End If
        End Sub
    End Class
End Namespace