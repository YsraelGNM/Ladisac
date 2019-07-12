
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling

Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views

    Public Class frmPlanilla

        <Dependency()> _
        Public Property BCConceptosPlanilla As BL.IBCConceptosPlanilla

        <Dependency()> _
        Public Property BCPlanilla As BL.IBCPlanilla

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil
        <Dependency()> _
        Public Property BCDatosLaborales As BL.IBCDatosLaborales


        <Dependency()> _
        Public Property BCTiposTrabajador As BL.IBCTiposTrabajador

        Protected oPlanillas As New BE.Planillas

        Private Sub btnPlanilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlanilla.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.ConceptosPlanilla)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                With frm.dgbRegistro.CurrentRow
                    cargarTipoPlanilla(.Cells("tit_TipoTrab_Id").Value, .Cells("tip_TipoPlan_Id").Value, .Cells("ItemConceptoPlanilla").Value, Nothing)

                End With

            End If

            frm.Dispose()
        End Sub

        Sub limpiarTipoPlanilla()

            txtPlanilla.Tag = ""
            txtPlanilla.Text = ""

            txtTipoPlanilla.Tag = ""
            txtTipoPlanilla.Text = ""

            txtTipoTrabajador.Tag = ""
            txtTipoTrabajador.Text = ""

        End Sub

        Function SumarCOlumna(ByVal iColumna As Integer) As Double
            Dim x As Integer = 0
            Dim dSuma As Double = 0

            Try
                lblSumar.Text = dgvResultadoCalculoPL.Columns(iColumna).HeaderText

                While (dgvResultadoCalculoPL.Rows.Count > x)

                    dSuma += dgvResultadoCalculoPL.Rows(x).Cells(iColumna).Value
                    x += 1

                End While
            Catch ex As Exception
                lblSumar.Text = ""
                dSuma = 0
            End Try
            Return dSuma

        End Function
        Private Sub limpiar()
            txtDescripcion.Text = ""
            txtDescripcionComedor.Text = ""
            txtNumero.Text = ""
            txtNumeroComedor.Text = ""
            txtNumeroHora.Text = ""
            txtObservacionesHora.Text = ""
            txtPeriodo.Text = ""
            txtPlanilla.Text = ""
            txtSerie.Text = ""
            txtTipoPlanilla.Text = ""
            txtTipoTrabajador.Text = ""
            txtTipotrabajadroHora.Text = ""

            dgvComedor.Rows.Clear()
            dgvDatosPrestamos.DataSource = Nothing
            dgvDescuentoJudicial.Rows.Clear()
            dgvHoraPersonal.Rows.Clear()
            dgvPagosPrestamos.DataSource = Nothing
            dgvPrestamos.DataSource = Nothing
            dgvResultadoCalculoPL.DataSource = Nothing
            dgvSeleccionPersonas.Rows.Clear()
            lblTrabajador.Text = Nothing
            chkMarcarPersonas.Checked = False

            'pbarBarra.Minimum = 0
            'pbarBarra.Maximum = 0
            'pbarBarra.Value = 0
        End Sub
        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of frmBuscarDocumentos)()
            frm.inicio(Constants.BuscadoresNames.BuscarPlanilla)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                With frm.dgbRegistro.CurrentRow

                    cargar(.Cells("Serie").Value(), .Cells("Numero").Value, .Cells("tdo_Id").Value)
                    menuBuscar()
                End With
                Panel1.Enabled = False
            End If
            frm.Dispose()


        End Sub
        Public Sub cargar(ByVal serie As String, ByVal numero As String, ByVal tipo As String)
            limpiar()
            oPlanillas = BCPlanilla.PlanillaSeek(serie, numero, tipo)

            oPlanillas.MarkAsModified()

            txtSerie.Text = oPlanillas.pla_SeriePlani
            txtNumero.Text = oPlanillas.pla_Numero
            dateDesde.Value = CDate(oPlanillas.pla_FechaInicio)
            dateHasta.Value = CDate(oPlanillas.pla_FechaFin)
            txtPeriodo.Text = oPlanillas.prd_Periodo_id
            txtDescripcion.Text = oPlanillas.pla_Descripcion


            For Each mItem In oPlanillas.PlanillasComedorHoras
                Try
                    Dim nRow As New DataGridViewRow

                    If (mItem.esComedorOHora) Then

                        dgvComedor.Rows.Add(nRow)
                        dgvComedor.Rows(dgvComedor.Rows.Count - 1).Cells("Comedor").Value = mItem.ComedorPLL.com_Numero
                        dgvComedor.Rows(dgvComedor.Rows.Count - 1).Cells("Observaciones_Comedor").Value = mItem.ComedorPLL.com_Observaciones

                    Else

                        dgvHoraPersonal.Rows.Add(nRow)
                        dgvHoraPersonal.Rows(dgvHoraPersonal.Rows.Count - 1).Cells("TipoTrabajador").Value = mItem.TrabajadorHoras.tit_TipoTrab_Id
                        dgvHoraPersonal.Rows(dgvHoraPersonal.Rows.Count - 1).Cells("Numero").Value = mItem.TrabajadorHoras.trh_Numero
                        dgvHoraPersonal.Rows(dgvHoraPersonal.Rows.Count - 1).Cells("Descripcion").Value = mItem.TrabajadorHoras.trh_descripcion

                    End If
                Catch ex As Exception

                End Try
               
               



            Next




        End Sub
        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oPlanillas = New BE.Planillas
            oPlanillas.MarkAsAdded()
            Panel1.Enabled = True
        End Sub
        Public Overrides Sub OnManSalir()
            Me.Dispose()
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

        Public Sub ingresar()
            Dim NumeroFila As Integer
            Dim iColumnas As Integer
            Dim dVerificar As Double
            Dim sConceltoJudicial(1) As String
            Dim sConceptoPrestamo(1) As String

            ' toda  planilla al guadar  es una nueva planilla

            oPlanillas = New BE.Planillas
            oPlanillas.MarkAsAdded()

            If (validar()) Then

                Dim result As Integer
                If (dateDesde.Value.Month <> dateHasta.Value.Month) And Me.txtTipoPlanilla.Tag = "001" And txtTipoTrabajador.Tag = "002" Then
                    result = MessageBox.Show("Desea convertir la planilla actual en 2 Boletas?", "Atención", MessageBoxButtons.YesNoCancel)
                End If

                If result = DialogResult.Cancel Then Exit Sub

                Try
                    If (dateDesde.Value.Month <> dateHasta.Value.Month) And Me.txtTipoPlanilla.Tag = "001" And txtTipoTrabajador.Tag = "002" And result = DialogResult.Yes Then
                        'Hay dos meses
                        Dim PorcMesSig As Decimal
                        Dim PorcMesAnt As Decimal
                        Dim Ffi As Date
                        Dim fin As Date

                        Ffi = New DateTime(Me.dateDesde.Value.Year, Me.dateDesde.Value.Month, DateTime.DaysInMonth(Me.dateDesde.Value.Year, Me.dateDesde.Value.Month))
                        fin = "1/" & Me.dateHasta.Value.Month.ToString & "/" & Me.dateHasta.Value.Year.ToString

                        For cont As Integer = 1 To 2
                            If cont = 1 Then 'Cuando es primer mes
                                'pbarBarra.Value = 0


                                sConceltoJudicial = cargarDatosJudiciales()
                                sConceptoPrestamo = cargarDatosPrestamo()

                                If oPlanillas IsNot Nothing Then
                                    dgvResultadoCalculoPL.EndEdit()

                                    oPlanillas.pla_Descripcion = txtDescripcion.Text & " (1)"
                                    oPlanillas.prd_Periodo_id = txtPeriodo.Text
                                    oPlanillas.pla_FechaInicio = Me.dateDesde.Text
                                    oPlanillas.pla_FechaFin = Ffi
                                    oPlanillas.tip_TipoPlan_Id = Me.txtTipoPlanilla.Tag
                                    oPlanillas.tit_TipoTrab_Id = Me.txtTipoTrabajador.Tag
                                    oPlanillas.pla_SeriePlani = txtSerie.Text
                                    oPlanillas.pla_Numero = txtNumero.Text
                                    oPlanillas.ItemConceptoPlanilla = txtPlanilla.Tag
                                    oPlanillas.pla_FECGRAB = Now
                                    oPlanillas.Usu_Id = SessionServer.UserId

                                    NumeroFila = 1

                                    For Each mDetalle As DataGridViewRow In dgvResultadoCalculoPL.Rows
                                        'Cada fila es cada persona
                                        PorcMesAnt = BCPlanilla.spPorcentajeMesPlanilla(oPlanillas.pla_FechaInicio, oPlanillas.pla_FechaFin, fin, dateHasta.Text, mDetalle.Cells("Per_id").Value, 1, dgvHoraPersonal.Rows(0).Cells("Numero").Value)

                                        iColumnas = 0
                                        ' pasamos columna tras columna 
                                        While (dgvResultadoCalculoPL.Columns.Count > iColumnas)
                                            Try
                                                If (IsNumeric(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(1, 2)) AndAlso IsNumeric(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3))) Then
                                                    Dim nOSD As New BE.DetallePlanillas
                                                    With nOSD

                                                        nOSD.dep_FecGrab = CDate(Today)
                                                        If dgvResultadoCalculoPL.Columns(iColumnas).Name.Contains("01005") Then
                                                            nOSD.dep_Importe = Math.Round(IIf(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Contains("¤"), 0, Val(mDetalle.Cells(iColumnas).Value)) * PorcMesAnt, 0)
                                                        Else
                                                            nOSD.dep_Importe = IIf(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Contains("¤"), 0, Val(mDetalle.Cells(iColumnas).Value)) * PorcMesAnt
                                                        End If
                                                        dVerificar = Double.Parse(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3)) * 5
                                                        nOSD.tic_TipoConcep_Id = dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(1, 2)
                                                        nOSD.con_Conceptos_Id = dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3)

                                                        If (nOSD.tic_TipoConcep_Id = sConceltoJudicial(0) AndAlso nOSD.con_Conceptos_Id = sConceltoJudicial(1)) Then

                                                            nOSD.dep_SerieRef = mDetalle.Cells("SerieDocJudicial").Value
                                                            nOSD.dep_NumeroRef = mDetalle.Cells("NumeroDocJudicial").Value
                                                            nOSD.dep_temRef = Nothing
                                                            nOSD.TDO_IDRef = Nothing
                                                        End If

                                                        'sConceptoPrestamo

                                                        If (nOSD.tic_TipoConcep_Id = sConceptoPrestamo(0) AndAlso nOSD.con_Conceptos_Id = sConceptoPrestamo(1)) Then

                                                            nOSD.dep_SerieRef = mDetalle.Cells("SerieDocPrestamo").Value
                                                            nOSD.dep_NumeroRef = mDetalle.Cells("NumeroDocPrestamo").Value

                                                            'nOSD.CCT_IDre = "002"
                                                            nOSD.DTD_IDRef = "054"
                                                            nOSD.TDO_IDRef = "035"
                                                            nOSD.dep_temRef = Nothing

                                                        End If
                                                        nOSD.dep_Item = derecha("00000" & NumeroFila.ToString(), 4)
                                                        nOSD.per_Id = mDetalle.Cells("Per_id").Value

                                                        nOSD.tip_TipoPlan_Id = txtTipoPlanilla.Tag
                                                        nOSD.Usu_Id = SessionServer.UserId
                                                        nOSD.dep_FecGrab = CDate(Today)

                                                        .MarkAsAdded()

                                                        oPlanillas.DetallePlanillas.Add(nOSD)


                                                    End With
                                                End If
                                            Catch ex As Exception

                                            End Try

                                            iColumnas += 1
                                            NumeroFila += 1
                                        End While


                                        'pbarBarra.Value += 1
                                    Next

                                    ' horas planillas 

                                    For Each mDetalle As DataGridViewRow In dgvHoraPersonal.Rows

                                        Dim nOSD As New BE.PlanillasComedorHoras
                                        With nOSD

                                            .esComedorOHora = 0
                                            .com_Numero = Nothing
                                            .tit_TipoTrab_Id = mDetalle.Cells(0).Value()
                                            .trh_Numero = mDetalle.Cells(1).Value()
                                            .MarkAsAdded()

                                        End With
                                        oPlanillas.PlanillasComedorHoras.Add(nOSD)


                                    Next

                                    ' Comedor planillas 
                                    For Each mDetalle As DataGridViewRow In dgvComedor.Rows

                                        Dim nOSD As New BE.PlanillasComedorHoras
                                        With nOSD

                                            .esComedorOHora = 1
                                            .com_Numero = mDetalle.Cells(0).Value()
                                            .tit_TipoTrab_Id = Nothing
                                            .trh_Numero = Nothing

                                            .MarkAsAdded()

                                        End With
                                        oPlanillas.PlanillasComedorHoras.Add(nOSD)

                                    Next

                                    'trabajador  planillas 

                                    For Each mDetalle As DataGridViewRow In dgvSeleccionPersonas.Rows
                                        If (CBool(mDetalle.Cells("ok").Value)) Then
                                            Dim nOSD As New BE.PlanillaTrabajador
                                            With nOSD


                                                .Periodo = Nothing
                                                .Periodo1 = Nothing
                                                .Periodo2 = Nothing
                                                .Periodo3 = Nothing
                                                .Usuarios = Nothing
                                                .Planillas = Nothing
                                                .RegimenLaboral = Nothing
                                                .RegimenPensionario = Nothing
                                                .TiposCargos = Nothing


                                                If (IsDBNull(mDetalle.Cells("cco_Id").Value) OrElse mDetalle.Cells("cco_Id").Value = "") Then
                                                    .cco_Id = Nothing
                                                Else
                                                    .cco_Id = mDetalle.Cells("cco_Id").Value
                                                End If

                                                If (IsDBNull(mDetalle.Cells("tis_TipCargo_Id").Value) OrElse mDetalle.Cells("tis_TipCargo_Id").Value = "") Then
                                                    .tis_TipCargo_Id = Nothing
                                                Else
                                                    .tis_TipCargo_Id = mDetalle.Cells("tis_TipCargo_Id").Value
                                                End If

                                                If (IsDBNull(mDetalle.Cells("rep_RegiPension_id").Value) OrElse mDetalle.Cells("rep_RegiPension_id").Value = "") Then
                                                    .rep_RegiPension_id = Nothing
                                                Else
                                                    .rep_RegiPension_id = mDetalle.Cells("rep_RegiPension_id").Value
                                                End If

                                                If (IsDBNull(mDetalle.Cells("art_AreaTrab_Id").Value) OrElse mDetalle.Cells("art_AreaTrab_Id").Value = "") Then
                                                    .art_AreaTrab_Id = Nothing
                                                Else
                                                    .art_AreaTrab_Id = mDetalle.Cells("art_AreaTrab_Id").Value
                                                End If

                                                If (IsDBNull(mDetalle.Cells("rel_RegLaboral_Id").Value) OrElse mDetalle.Cells("rel_RegLaboral_Id").Value = "") Then
                                                    .rel_RegLaboral_Id = Nothing
                                                Else
                                                    .rel_RegLaboral_Id = mDetalle.Cells("rel_RegLaboral_Id").Value
                                                End If

                                                If (IsDBNull(mDetalle.Cells("plt_NuemroDeCuenta").Value) OrElse mDetalle.Cells("plt_NuemroDeCuenta").Value = "") Then
                                                    .plt_NuemroDeCuenta = Nothing
                                                Else
                                                    .plt_NuemroDeCuenta = mDetalle.Cells("plt_NuemroDeCuenta").Value
                                                End If

                                                If (IsDBNull(mDetalle.Cells("ccc_IdCuenta").Value) OrElse mDetalle.Cells("ccc_IdCuenta").Value = "") Then
                                                    .ccc_IdCuenta = Nothing
                                                Else
                                                    .ccc_IdCuenta = mDetalle.Cells("ccc_IdCuenta").Value
                                                End If

                                                If (IsDBNull(mDetalle.Cells("plt_CodigoTrabajador").Value) OrElse mDetalle.Cells("plt_CodigoTrabajador").Value = "") Then
                                                    .plt_CodigoTrabajador = Nothing
                                                Else
                                                    .plt_CodigoTrabajador = mDetalle.Cells("plt_CodigoTrabajador").Value
                                                End If


                                                .Usu_Id = SessionServer.UserId
                                                .ptr_FecGrab = CDate(Today)

                                                .prd_Periodo_idInicialDias = mDetalle.Cells("prd_Periodo_idInicialDias").Value
                                                .prd_Periodo_idFinalDias = mDetalle.Cells("prd_Periodo_idFinalDias").Value
                                                .prd_Periodo_idInicialIngresos = mDetalle.Cells("prd_Periodo_idInicialIngresos").Value
                                                .prd_Periodo_idFinalIngresos = mDetalle.Cells("prd_Periodo_idFinalIngresos").Value
                                                .per_Id = mDetalle.Cells("per_Id").Value


                                                .MarkAsAdded()

                                            End With
                                            oPlanillas.PlanillaTrabajador.Add(nOSD)
                                        End If

                                    Next
                                    BCPlanilla.Maintenance(oPlanillas)
                                    MsgBox("Datos Guardados Primer Mes")

                                End If


                            Else 'Cuando es segundo mes

                                MessageBox.Show("Asegúrese de tener los valores correctos en las AFP's para este mes.")

                                'pbarBarra.Value = 0

                                oPlanillas = New BE.Planillas
                                oPlanillas.MarkAsAdded()

                                sConceltoJudicial = cargarDatosJudiciales()
                                sConceptoPrestamo = cargarDatosPrestamo()

                                If oPlanillas IsNot Nothing Then
                                    dgvResultadoCalculoPL.EndEdit()
                                    oPlanillas.pla_Descripcion = txtDescripcion.Text & " (2)"
                                    If (CInt(txtPeriodo.Text.Substring(4, 2)) + 1) = 13 Then
                                        oPlanillas.prd_Periodo_id = (CInt(txtPeriodo.Text.Substring(0, 4)) + 1).ToString & "01"
                                    Else
                                        oPlanillas.prd_Periodo_id = txtPeriodo.Text.Substring(0, 4) & (CInt(txtPeriodo.Text.Substring(4, 2)) + 1).ToString.Trim.PadLeft(2, "0")
                                    End If
                                    oPlanillas.pla_FechaInicio = fin
                                    oPlanillas.pla_FechaFin = Me.dateHasta.Text
                                    oPlanillas.tip_TipoPlan_Id = Me.txtTipoPlanilla.Tag
                                    oPlanillas.tit_TipoTrab_Id = Me.txtTipoTrabajador.Tag
                                    oPlanillas.pla_SeriePlani = txtSerie.Text
                                    oPlanillas.pla_Numero = txtNumero.Text
                                    oPlanillas.ItemConceptoPlanilla = txtPlanilla.Tag
                                    oPlanillas.pla_FECGRAB = Now
                                    oPlanillas.Usu_Id = SessionServer.UserId

                                    NumeroFila = 1

                                    For Each mDetalle As DataGridViewRow In dgvResultadoCalculoPL.Rows
                                        'Cada fila es cada persona
                                        PorcMesSig = BCPlanilla.spPorcentajeMesPlanilla(dateDesde.Text, Ffi, oPlanillas.pla_FechaInicio, oPlanillas.pla_FechaFin, mDetalle.Cells("Per_id").Value, 2, dgvHoraPersonal.Rows(0).Cells("Numero").Value)

                                        ' '' ''Recalculo AFP
                                        '' ''Dim dal As DatosLaborales = BCDatosLaborales.GetByCodTrabajador(mDetalle.Cells("Cod").Value)
                                        '' ''If dal.rep_RegiPension_id <> "004" Then
                                        '' ''    Dim TOTALING, VALEALIMEN, GRATIFICAEXTRA As Decimal
                                        '' ''    Try
                                        '' ''        TOTALING = mDetalle.Cells("A02016-TOTALING").Value
                                        '' ''    Catch ex As Exception
                                        '' ''        TOTALING = 0
                                        '' ''    End Try
                                        '' ''    Try
                                        '' ''        VALEALIMEN = mDetalle.Cells("A02026-VALEALIMEN").Value
                                        '' ''    Catch ex As Exception
                                        '' ''        VALEALIMEN = 0
                                        '' ''    End Try
                                        '' ''    Try
                                        '' ''        GRATIFICAEXTRA = mDetalle.Cells("A02033-GRATIFICAEXTRA").Value
                                        '' ''    Catch ex As Exception
                                        '' ''        GRATIFICAEXTRA = 0
                                        '' ''    End Try


                                        '' ''    For Each mCol As DataGridViewColumn In dgvResultadoCalculoPL.Columns
                                        '' ''        If mCol.Name.Contains("03001") Then
                                        '' ''            Dim AFPAPOROBL = (From mItem In dal.RegimenPensionario.DetalleConceptosPensionarios Where mItem.tic_TipoConcep_Id & mItem.con_Conceptos_Id = "03001" Select mItem).FirstOrDefault
                                        '' ''            mDetalle.Cells("A05001-NETO").Value = mDetalle.Cells("A05001-NETO").Value + mDetalle.Cells(mCol.Name).Value
                                        '' ''            mDetalle.Cells(mCol.Name).Value = Math.Round((TOTALING - (VALEALIMEN + GRATIFICAEXTRA)) * CDec(AFPAPOROBL.dcp_Factor), 2)
                                        '' ''            mDetalle.Cells("A05001-NETO").Value = mDetalle.Cells("A05001-NETO").Value - mDetalle.Cells(mCol.Name).Value

                                        '' ''        ElseIf mCol.Name.Contains("03002") Then
                                        '' ''            Dim AFPCOMISI = (From mItem In dal.RegimenPensionario.DetalleConceptosPensionarios Where mItem.tic_TipoConcep_Id & mItem.con_Conceptos_Id = "03002" Select mItem).FirstOrDefault
                                        '' ''            mDetalle.Cells("A05001-NETO").Value = mDetalle.Cells("A05001-NETO").Value + mDetalle.Cells(mCol.Name).Value
                                        '' ''            mDetalle.Cells(mCol.Name).Value = Math.Round((TOTALING - (VALEALIMEN + GRATIFICAEXTRA)) * CDec(AFPCOMISI.dcp_Factor), 2)
                                        '' ''            mDetalle.Cells("A05001-NETO").Value = mDetalle.Cells("A05001-NETO").Value - mDetalle.Cells(mCol.Name).Value

                                        '' ''        ElseIf mCol.Name.Contains("03003") Then
                                        '' ''            Dim AFPSEGURO = (From mItem In dal.RegimenPensionario.DetalleConceptosPensionarios Where mItem.tic_TipoConcep_Id & mItem.con_Conceptos_Id = "03003" Select mItem).FirstOrDefault
                                        '' ''            If Today.Year - dal.dal_FechaNacimiento.Year < 65 Then
                                        '' ''                If Math.Round((TOTALING - (VALEALIMEN + GRATIFICAEXTRA)) * CDec(AFPSEGURO.dcp_Factor), 2) > AFPSEGURO.dcp_importeMaximo Then
                                        '' ''                    mDetalle.Cells("A05001-NETO").Value = mDetalle.Cells("A05001-NETO").Value + mDetalle.Cells(mCol.Name).Value
                                        '' ''                    mDetalle.Cells(mCol.Name).Value = AFPSEGURO.dcp_importeMaximo
                                        '' ''                    mDetalle.Cells("A05001-NETO").Value = mDetalle.Cells("A05001-NETO").Value - mDetalle.Cells(mCol.Name).Value
                                        '' ''                Else
                                        '' ''                    mDetalle.Cells("A05001-NETO").Value = mDetalle.Cells("A05001-NETO").Value + mDetalle.Cells(mCol.Name).Value
                                        '' ''                    mDetalle.Cells(mCol.Name).Value = Math.Round((TOTALING - (VALEALIMEN + GRATIFICAEXTRA)) * CDec(AFPSEGURO.dcp_Factor), 2)
                                        '' ''                    mDetalle.Cells("A05001-NETO").Value = mDetalle.Cells("A05001-NETO").Value - mDetalle.Cells(mCol.Name).Value
                                        '' ''                End If
                                        '' ''            End If
                                        '' ''        End If
                                        '' ''    Next
                                        '' ''End If








                                        iColumnas = 0
                                        ' pasamos columna tras columna 
                                        While (dgvResultadoCalculoPL.Columns.Count > iColumnas)
                                            Try
                                                If (IsNumeric(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(1, 2)) AndAlso IsNumeric(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3))) Then
                                                    Dim nOSD As New BE.DetallePlanillas
                                                    With nOSD

                                                        nOSD.dep_FecGrab = CDate(Today)
                                                        If dgvResultadoCalculoPL.Columns(iColumnas).Name.Contains("01005") Then
                                                            nOSD.dep_Importe = Math.Round(IIf(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Contains("¤"), 0, Val(mDetalle.Cells(iColumnas).Value)) * PorcMesSig, 0)
                                                        Else
                                                            nOSD.dep_Importe = IIf(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Contains("¤"), 0, Val(mDetalle.Cells(iColumnas).Value)) * PorcMesSig
                                                        End If
                                                        dVerificar = Double.Parse(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3)) * 5
                                                        nOSD.tic_TipoConcep_Id = dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(1, 2)
                                                        nOSD.con_Conceptos_Id = dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3)

                                                        If (nOSD.tic_TipoConcep_Id = sConceltoJudicial(0) AndAlso nOSD.con_Conceptos_Id = sConceltoJudicial(1)) Then

                                                            nOSD.dep_SerieRef = mDetalle.Cells("SerieDocJudicial").Value
                                                            nOSD.dep_NumeroRef = mDetalle.Cells("NumeroDocJudicial").Value
                                                            nOSD.dep_temRef = Nothing
                                                            nOSD.TDO_IDRef = Nothing
                                                        End If

                                                        'sConceptoPrestamo

                                                        If (nOSD.tic_TipoConcep_Id = sConceptoPrestamo(0) AndAlso nOSD.con_Conceptos_Id = sConceptoPrestamo(1)) Then

                                                            nOSD.dep_SerieRef = mDetalle.Cells("SerieDocPrestamo").Value
                                                            nOSD.dep_NumeroRef = mDetalle.Cells("NumeroDocPrestamo").Value

                                                            'nOSD.CCT_IDre = "002"
                                                            nOSD.DTD_IDRef = "054"
                                                            nOSD.TDO_IDRef = "035"
                                                            nOSD.dep_temRef = Nothing

                                                        End If
                                                        nOSD.dep_Item = derecha("00000" & NumeroFila.ToString(), 4)
                                                        nOSD.per_Id = mDetalle.Cells("Per_id").Value

                                                        nOSD.tip_TipoPlan_Id = txtTipoPlanilla.Tag
                                                        nOSD.Usu_Id = SessionServer.UserId
                                                        nOSD.dep_FecGrab = CDate(Today)

                                                        .MarkAsAdded()

                                                        oPlanillas.DetallePlanillas.Add(nOSD)


                                                    End With
                                                End If
                                            Catch ex As Exception

                                            End Try

                                            iColumnas += 1
                                            NumeroFila += 1
                                        End While


                                        'pbarBarra.Value += 1
                                    Next

                                    ' horas planillas 

                                    For Each mDetalle As DataGridViewRow In dgvHoraPersonal.Rows

                                        Dim nOSD As New BE.PlanillasComedorHoras
                                        With nOSD

                                            .esComedorOHora = 0
                                            .com_Numero = Nothing
                                            .tit_TipoTrab_Id = mDetalle.Cells(0).Value()
                                            .trh_Numero = mDetalle.Cells(1).Value()
                                            .MarkAsAdded()

                                        End With
                                        oPlanillas.PlanillasComedorHoras.Add(nOSD)


                                    Next

                                    ' Comedor planillas 
                                    For Each mDetalle As DataGridViewRow In dgvComedor.Rows

                                        Dim nOSD As New BE.PlanillasComedorHoras
                                        With nOSD

                                            .esComedorOHora = 1
                                            .com_Numero = mDetalle.Cells(0).Value()
                                            .tit_TipoTrab_Id = Nothing
                                            .trh_Numero = Nothing

                                            .MarkAsAdded()

                                        End With
                                        oPlanillas.PlanillasComedorHoras.Add(nOSD)

                                    Next

                                    'trabajador  planillas 

                                    For Each mDetalle As DataGridViewRow In dgvSeleccionPersonas.Rows
                                        If (CBool(mDetalle.Cells("ok").Value)) Then
                                            Dim nOSD As New BE.PlanillaTrabajador
                                            With nOSD


                                                .Periodo = Nothing
                                                .Periodo1 = Nothing
                                                .Periodo2 = Nothing
                                                .Periodo3 = Nothing
                                                .Usuarios = Nothing
                                                .Planillas = Nothing
                                                .RegimenLaboral = Nothing
                                                .RegimenPensionario = Nothing
                                                .TiposCargos = Nothing


                                                If (IsDBNull(mDetalle.Cells("cco_Id").Value) OrElse mDetalle.Cells("cco_Id").Value = "") Then
                                                    .cco_Id = Nothing
                                                Else
                                                    .cco_Id = mDetalle.Cells("cco_Id").Value
                                                End If

                                                If (IsDBNull(mDetalle.Cells("tis_TipCargo_Id").Value) OrElse mDetalle.Cells("tis_TipCargo_Id").Value = "") Then
                                                    .tis_TipCargo_Id = Nothing
                                                Else
                                                    .tis_TipCargo_Id = mDetalle.Cells("tis_TipCargo_Id").Value
                                                End If

                                                If (IsDBNull(mDetalle.Cells("rep_RegiPension_id").Value) OrElse mDetalle.Cells("rep_RegiPension_id").Value = "") Then
                                                    .rep_RegiPension_id = Nothing
                                                Else
                                                    .rep_RegiPension_id = mDetalle.Cells("rep_RegiPension_id").Value
                                                End If

                                                If (IsDBNull(mDetalle.Cells("art_AreaTrab_Id").Value) OrElse mDetalle.Cells("art_AreaTrab_Id").Value = "") Then
                                                    .art_AreaTrab_Id = Nothing
                                                Else
                                                    .art_AreaTrab_Id = mDetalle.Cells("art_AreaTrab_Id").Value
                                                End If

                                                If (IsDBNull(mDetalle.Cells("rel_RegLaboral_Id").Value) OrElse mDetalle.Cells("rel_RegLaboral_Id").Value = "") Then
                                                    .rel_RegLaboral_Id = Nothing
                                                Else
                                                    .rel_RegLaboral_Id = mDetalle.Cells("rel_RegLaboral_Id").Value
                                                End If

                                                If (IsDBNull(mDetalle.Cells("plt_NuemroDeCuenta").Value) OrElse mDetalle.Cells("plt_NuemroDeCuenta").Value = "") Then
                                                    .plt_NuemroDeCuenta = Nothing
                                                Else
                                                    .plt_NuemroDeCuenta = mDetalle.Cells("plt_NuemroDeCuenta").Value
                                                End If

                                                If (IsDBNull(mDetalle.Cells("ccc_IdCuenta").Value) OrElse mDetalle.Cells("ccc_IdCuenta").Value = "") Then
                                                    .ccc_IdCuenta = Nothing
                                                Else
                                                    .ccc_IdCuenta = mDetalle.Cells("ccc_IdCuenta").Value
                                                End If

                                                If (IsDBNull(mDetalle.Cells("plt_CodigoTrabajador").Value) OrElse mDetalle.Cells("plt_CodigoTrabajador").Value = "") Then
                                                    .plt_CodigoTrabajador = Nothing
                                                Else
                                                    .plt_CodigoTrabajador = mDetalle.Cells("plt_CodigoTrabajador").Value
                                                End If


                                                .Usu_Id = SessionServer.UserId
                                                .ptr_FecGrab = CDate(Today)

                                                .prd_Periodo_idInicialDias = mDetalle.Cells("prd_Periodo_idInicialDias").Value
                                                .prd_Periodo_idFinalDias = mDetalle.Cells("prd_Periodo_idFinalDias").Value
                                                .prd_Periodo_idInicialIngresos = mDetalle.Cells("prd_Periodo_idInicialIngresos").Value
                                                .prd_Periodo_idFinalIngresos = mDetalle.Cells("prd_Periodo_idFinalIngresos").Value
                                                .per_Id = mDetalle.Cells("per_Id").Value


                                                .MarkAsAdded()

                                            End With
                                            oPlanillas.PlanillaTrabajador.Add(nOSD)
                                        End If

                                    Next
                                    BCPlanilla.Maintenance(oPlanillas)
                                    MsgBox("Datos Guardados Segundo Mes")

                                End If

                            End If
                        Next


                    Else 'Dentro del mes

                        'pbarBarra.Value = 0

                        sConceltoJudicial = cargarDatosJudiciales()
                        sConceptoPrestamo = cargarDatosPrestamo()

                        If oPlanillas IsNot Nothing Then
                            dgvResultadoCalculoPL.EndEdit()

                            oPlanillas.pla_Descripcion = txtDescripcion.Text
                            oPlanillas.prd_Periodo_id = txtPeriodo.Text
                            oPlanillas.pla_FechaInicio = Me.dateDesde.Text
                            oPlanillas.pla_FechaFin = Me.dateHasta.Text
                            oPlanillas.tip_TipoPlan_Id = Me.txtTipoPlanilla.Tag
                            oPlanillas.tit_TipoTrab_Id = Me.txtTipoTrabajador.Tag
                            oPlanillas.pla_SeriePlani = txtSerie.Text
                            oPlanillas.pla_Numero = txtNumero.Text
                            oPlanillas.ItemConceptoPlanilla = txtPlanilla.Tag
                            oPlanillas.pla_FECGRAB = Now
                            oPlanillas.Usu_Id = SessionServer.UserId

                            ''--- probando con un procedure cabecera


                            ' Detalle de planillas 
                            ' numeroFila = numero de item para detale planillas  
                            NumeroFila = 1

                            For Each mDetalle As DataGridViewRow In dgvResultadoCalculoPL.Rows

                                iColumnas = 0

                                ' pasamos columna tras columna 



                                While (dgvResultadoCalculoPL.Columns.Count > iColumnas)
                                    Try
                                        If (IsNumeric(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(1, 2)) AndAlso IsNumeric(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3))) Then
                                            Dim nOSD As New BE.DetallePlanillas
                                            With nOSD

                                                nOSD.dep_FecGrab = CDate(Today)
                                                nOSD.dep_Importe = IIf(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Contains("¤"), 0, Val(mDetalle.Cells(iColumnas).Value))
                                                dVerificar = Double.Parse(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3)) * 5
                                                nOSD.tic_TipoConcep_Id = dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(1, 2)
                                                nOSD.con_Conceptos_Id = dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3)

                                                If (nOSD.tic_TipoConcep_Id = sConceltoJudicial(0) AndAlso nOSD.con_Conceptos_Id = sConceltoJudicial(1)) Then

                                                    nOSD.dep_SerieRef = mDetalle.Cells("SerieDocJudicial").Value
                                                    nOSD.dep_NumeroRef = mDetalle.Cells("NumeroDocJudicial").Value
                                                    nOSD.dep_temRef = Nothing
                                                    nOSD.TDO_IDRef = Nothing
                                                End If

                                                'sConceptoPrestamo

                                                If (nOSD.tic_TipoConcep_Id = sConceptoPrestamo(0) AndAlso nOSD.con_Conceptos_Id = sConceptoPrestamo(1)) Then

                                                    nOSD.dep_SerieRef = mDetalle.Cells("SerieDocPrestamo").Value
                                                    nOSD.dep_NumeroRef = mDetalle.Cells("NumeroDocPrestamo").Value

                                                    'nOSD.CCT_IDre = "002"
                                                    nOSD.DTD_IDRef = "054"
                                                    nOSD.TDO_IDRef = "035"
                                                    nOSD.dep_temRef = Nothing

                                                End If
                                                nOSD.dep_Item = derecha("00000" & NumeroFila.ToString(), 4)
                                                nOSD.per_Id = mDetalle.Cells("Per_id").Value

                                                nOSD.tip_TipoPlan_Id = txtTipoPlanilla.Tag
                                                nOSD.Usu_Id = SessionServer.UserId
                                                nOSD.dep_FecGrab = CDate(Today)

                                                .MarkAsAdded()

                                                oPlanillas.DetallePlanillas.Add(nOSD)


                                            End With
                                        End If
                                    Catch ex As Exception

                                    End Try

                                    iColumnas += 1
                                    NumeroFila += 1
                                End While


                                'pbarBarra.Value += 1
                            Next

                            ' horas planillas 

                            For Each mDetalle As DataGridViewRow In dgvHoraPersonal.Rows

                                Dim nOSD As New BE.PlanillasComedorHoras
                                With nOSD

                                    .esComedorOHora = 0
                                    .com_Numero = Nothing
                                    .tit_TipoTrab_Id = mDetalle.Cells(0).Value()
                                    .trh_Numero = mDetalle.Cells(1).Value()
                                    .MarkAsAdded()

                                End With
                                oPlanillas.PlanillasComedorHoras.Add(nOSD)


                            Next

                            ' Comedor planillas 
                            For Each mDetalle As DataGridViewRow In dgvComedor.Rows

                                Dim nOSD As New BE.PlanillasComedorHoras
                                With nOSD

                                    .esComedorOHora = 1
                                    .com_Numero = mDetalle.Cells(0).Value()
                                    .tit_TipoTrab_Id = Nothing
                                    .trh_Numero = Nothing

                                    .MarkAsAdded()

                                End With
                                oPlanillas.PlanillasComedorHoras.Add(nOSD)

                            Next

                            'trabajador  planillas 

                            For Each mDetalle As DataGridViewRow In dgvSeleccionPersonas.Rows
                                If (CBool(mDetalle.Cells("ok").Value)) Then
                                    Dim nOSD As New BE.PlanillaTrabajador
                                    With nOSD


                                        .Periodo = Nothing
                                        .Periodo1 = Nothing
                                        .Periodo2 = Nothing
                                        .Periodo3 = Nothing
                                        .Usuarios = Nothing
                                        .Planillas = Nothing
                                        .RegimenLaboral = Nothing
                                        .RegimenPensionario = Nothing
                                        .TiposCargos = Nothing


                                        If (IsDBNull(mDetalle.Cells("cco_Id").Value) OrElse mDetalle.Cells("cco_Id").Value = "") Then
                                            .cco_Id = Nothing
                                        Else
                                            .cco_Id = mDetalle.Cells("cco_Id").Value
                                        End If

                                        If (IsDBNull(mDetalle.Cells("tis_TipCargo_Id").Value) OrElse mDetalle.Cells("tis_TipCargo_Id").Value = "") Then
                                            .tis_TipCargo_Id = Nothing
                                        Else
                                            .tis_TipCargo_Id = mDetalle.Cells("tis_TipCargo_Id").Value
                                        End If

                                        If (IsDBNull(mDetalle.Cells("rep_RegiPension_id").Value) OrElse mDetalle.Cells("rep_RegiPension_id").Value = "") Then
                                            .rep_RegiPension_id = Nothing
                                        Else
                                            .rep_RegiPension_id = mDetalle.Cells("rep_RegiPension_id").Value
                                        End If

                                        If (IsDBNull(mDetalle.Cells("art_AreaTrab_Id").Value) OrElse mDetalle.Cells("art_AreaTrab_Id").Value = "") Then
                                            .art_AreaTrab_Id = Nothing
                                        Else
                                            .art_AreaTrab_Id = mDetalle.Cells("art_AreaTrab_Id").Value
                                        End If

                                        If (IsDBNull(mDetalle.Cells("rel_RegLaboral_Id").Value) OrElse mDetalle.Cells("rel_RegLaboral_Id").Value = "") Then
                                            .rel_RegLaboral_Id = Nothing
                                        Else
                                            .rel_RegLaboral_Id = mDetalle.Cells("rel_RegLaboral_Id").Value
                                        End If

                                        If (IsDBNull(mDetalle.Cells("plt_NuemroDeCuenta").Value) OrElse mDetalle.Cells("plt_NuemroDeCuenta").Value = "") Then
                                            .plt_NuemroDeCuenta = Nothing
                                        Else
                                            .plt_NuemroDeCuenta = mDetalle.Cells("plt_NuemroDeCuenta").Value
                                        End If

                                        If (IsDBNull(mDetalle.Cells("ccc_IdCuenta").Value) OrElse mDetalle.Cells("ccc_IdCuenta").Value = "") Then
                                            .ccc_IdCuenta = Nothing
                                        Else
                                            .ccc_IdCuenta = mDetalle.Cells("ccc_IdCuenta").Value
                                        End If

                                        If (IsDBNull(mDetalle.Cells("plt_CodigoTrabajador").Value) OrElse mDetalle.Cells("plt_CodigoTrabajador").Value = "") Then
                                            .plt_CodigoTrabajador = Nothing
                                        Else
                                            .plt_CodigoTrabajador = mDetalle.Cells("plt_CodigoTrabajador").Value
                                        End If


                                        .Usu_Id = SessionServer.UserId
                                        .ptr_FecGrab = CDate(Today)

                                        .prd_Periodo_idInicialDias = mDetalle.Cells("prd_Periodo_idInicialDias").Value
                                        .prd_Periodo_idFinalDias = mDetalle.Cells("prd_Periodo_idFinalDias").Value
                                        .prd_Periodo_idInicialIngresos = mDetalle.Cells("prd_Periodo_idInicialIngresos").Value
                                        .prd_Periodo_idFinalIngresos = mDetalle.Cells("prd_Periodo_idFinalIngresos").Value
                                        .per_Id = mDetalle.Cells("per_Id").Value


                                        .MarkAsAdded()

                                    End With
                                    oPlanillas.PlanillaTrabajador.Add(nOSD)
                                End If

                            Next


                            BCPlanilla.Maintenance(oPlanillas)

                            MsgBox("Datos Guardados")

                        End If

                    End If


                Catch ex As Exception
                    Try
                        MsgBox(ex.InnerException.Message)
                    Catch ex2 As Exception
                        MsgBox(ex.Message)
                    End Try

                End Try

            End If

        End Sub

        'Public Sub ingresar()
        '    Dim NumeroFila As Integer
        '    Dim iColumnas As Integer
        '    Dim dVerificar As Double
        '    Dim sConceltoJudicial(1) As String
        '    Dim sConceptoPrestamo(1) As String

        '    ' toda  planilla al guadar  es una nueva planilla

        '    oPlanillas = New BE.Planillas
        '    oPlanillas.MarkAsAdded()

        '    If (validar()) Then

        '        Try
        '            sConceltoJudicial = cargarDatosJudiciales()
        '            sConceptoPrestamo = cargarDatosPrestamo()

        '            If oPlanillas IsNot Nothing Then
        '                dgvResultadoCalculoPL.EndEdit()

        '                oPlanillas.pla_Descripcion = txtDescripcion.Text
        '                oPlanillas.prd_Periodo_id = txtPeriodo.Text
        '                oPlanillas.pla_FechaInicio = Me.dateDesde.Text
        '                oPlanillas.pla_FechaFin = Me.dateHasta.Text
        '                oPlanillas.tip_TipoPlan_Id = Me.txtTipoPlanilla.Tag
        '                oPlanillas.tit_TipoTrab_Id = Me.txtTipoTrabajador.Tag
        '                oPlanillas.pla_SeriePlani = txtSerie.Text
        '                oPlanillas.pla_Numero = txtNumero.Text
        '                oPlanillas.ItemConceptoPlanilla = txtPlanilla.Tag
        '                oPlanillas.pla_FECGRAB = Now
        '                oPlanillas.Usu_Id = SessionServer.UserId

        '                ''--- probando con un procedure cabecera


        '                ' Detalle de planillas 
        '                ' numeroFila = numero de item para detale planillas  
        '                NumeroFila = 1

        '                For Each mDetalle As DataGridViewRow In dgvResultadoCalculoPL.Rows

        '                    iColumnas = 0

        '                    ' pasamos columna tras columna 



        '                    While (dgvResultadoCalculoPL.Columns.Count > iColumnas)
        '                        Try
        '                            If (IsNumeric(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(1, 2)) AndAlso IsNumeric(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3))) Then
        '                                Dim nOSD As New BE.DetallePlanillas
        '                                With nOSD

        '                                    nOSD.dep_FecGrab = CDate(Today)
        '                                    nOSD.dep_Importe = IIf(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Contains("¤"), 0, Val(mDetalle.Cells(iColumnas).Value))
        '                                    dVerificar = Double.Parse(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3)) * 5
        '                                    nOSD.tic_TipoConcep_Id = dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(1, 2)
        '                                    nOSD.con_Conceptos_Id = dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3)

        '                                    If (nOSD.tic_TipoConcep_Id = sConceltoJudicial(0) AndAlso nOSD.con_Conceptos_Id = sConceltoJudicial(1)) Then

        '                                        nOSD.dep_SerieRef = mDetalle.Cells("SerieDocJudicial").Value
        '                                        nOSD.dep_NumeroRef = mDetalle.Cells("NumeroDocJudicial").Value
        '                                        nOSD.dep_temRef = Nothing
        '                                        nOSD.TDO_IDRef = Nothing
        '                                    End If

        '                                    'sConceptoPrestamo

        '                                    If (nOSD.tic_TipoConcep_Id = sConceptoPrestamo(0) AndAlso nOSD.con_Conceptos_Id = sConceptoPrestamo(1)) Then

        '                                        nOSD.dep_SerieRef = mDetalle.Cells("SerieDocPrestamo").Value
        '                                        nOSD.dep_NumeroRef = mDetalle.Cells("NumeroDocPrestamo").Value

        '                                        'nOSD.CCT_IDre = "002"
        '                                        nOSD.DTD_IDRef = "054"
        '                                        nOSD.TDO_IDRef = "035"
        '                                        nOSD.dep_temRef = Nothing

        '                                    End If
        '                                    nOSD.dep_Item = derecha("00000" & NumeroFila.ToString(), 4)
        '                                    nOSD.per_Id = mDetalle.Cells("Per_id").Value

        '                                    nOSD.tip_TipoPlan_Id = txtTipoPlanilla.Tag
        '                                    nOSD.Usu_Id = SessionServer.UserId
        '                                    nOSD.dep_FecGrab = CDate(Today)

        '                                    .MarkAsAdded()

        '                                    oPlanillas.DetallePlanillas.Add(nOSD)


        '                                End With
        '                            End If
        '                        Catch ex As Exception

        '                        End Try

        '                        iColumnas += 1
        '                        NumeroFila += 1
        '                    End While



        '                Next

        '                ' horas planillas 

        '                For Each mDetalle As DataGridViewRow In dgvHoraPersonal.Rows

        '                    Dim nOSD As New BE.PlanillasComedorHoras
        '                    With nOSD

        '                        .esComedorOHora = 0
        '                        .com_Numero = Nothing
        '                        .tit_TipoTrab_Id = mDetalle.Cells(0).Value()
        '                        .trh_Numero = mDetalle.Cells(1).Value()
        '                        .MarkAsAdded()

        '                    End With
        '                    oPlanillas.PlanillasComedorHoras.Add(nOSD)


        '                Next

        '                ' Comedor planillas 
        '                For Each mDetalle As DataGridViewRow In dgvComedor.Rows

        '                    Dim nOSD As New BE.PlanillasComedorHoras
        '                    With nOSD

        '                        .esComedorOHora = 1
        '                        .com_Numero = mDetalle.Cells(0).Value()
        '                        .tit_TipoTrab_Id = Nothing
        '                        .trh_Numero = Nothing

        '                        .MarkAsAdded()

        '                    End With
        '                    oPlanillas.PlanillasComedorHoras.Add(nOSD)

        '                Next

        '                'trabajador  planillas 

        '                For Each mDetalle As DataGridViewRow In dgvSeleccionPersonas.Rows
        '                    If (CBool(mDetalle.Cells("ok").Value)) Then
        '                        Dim nOSD As New BE.PlanillaTrabajador
        '                        With nOSD


        '                            .Periodo = Nothing
        '                            .Periodo1 = Nothing
        '                            .Periodo2 = Nothing
        '                            .Periodo3 = Nothing
        '                            .Usuarios = Nothing
        '                            .Planillas = Nothing
        '                            .RegimenLaboral = Nothing
        '                            .RegimenPensionario = Nothing
        '                            .TiposCargos = Nothing


        '                            If (IsDBNull(mDetalle.Cells("cco_Id").Value) OrElse mDetalle.Cells("cco_Id").Value = "") Then
        '                                .cco_Id = Nothing
        '                            Else
        '                                .cco_Id = mDetalle.Cells("cco_Id").Value
        '                            End If

        '                            If (IsDBNull(mDetalle.Cells("tis_TipCargo_Id").Value) OrElse mDetalle.Cells("tis_TipCargo_Id").Value = "") Then
        '                                .tis_TipCargo_Id = Nothing
        '                            Else
        '                                .tis_TipCargo_Id = mDetalle.Cells("tis_TipCargo_Id").Value
        '                            End If

        '                            If (IsDBNull(mDetalle.Cells("rep_RegiPension_id").Value) OrElse mDetalle.Cells("rep_RegiPension_id").Value = "") Then
        '                                .rep_RegiPension_id = Nothing
        '                            Else
        '                                .rep_RegiPension_id = mDetalle.Cells("rep_RegiPension_id").Value
        '                            End If

        '                            If (IsDBNull(mDetalle.Cells("art_AreaTrab_Id").Value) OrElse mDetalle.Cells("art_AreaTrab_Id").Value = "") Then
        '                                .art_AreaTrab_Id = Nothing
        '                            Else
        '                                .art_AreaTrab_Id = mDetalle.Cells("art_AreaTrab_Id").Value
        '                            End If

        '                            If (IsDBNull(mDetalle.Cells("rel_RegLaboral_Id").Value) OrElse mDetalle.Cells("rel_RegLaboral_Id").Value = "") Then
        '                                .rel_RegLaboral_Id = Nothing
        '                            Else
        '                                .rel_RegLaboral_Id = mDetalle.Cells("rel_RegLaboral_Id").Value
        '                            End If

        '                            If (IsDBNull(mDetalle.Cells("plt_NuemroDeCuenta").Value) OrElse mDetalle.Cells("plt_NuemroDeCuenta").Value = "") Then
        '                                .plt_NuemroDeCuenta = Nothing
        '                            Else
        '                                .plt_NuemroDeCuenta = mDetalle.Cells("plt_NuemroDeCuenta").Value
        '                            End If

        '                            If (IsDBNull(mDetalle.Cells("ccc_IdCuenta").Value) OrElse mDetalle.Cells("ccc_IdCuenta").Value = "") Then
        '                                .ccc_IdCuenta = Nothing
        '                            Else
        '                                .ccc_IdCuenta = mDetalle.Cells("ccc_IdCuenta").Value
        '                            End If

        '                            If (IsDBNull(mDetalle.Cells("plt_CodigoTrabajador").Value) OrElse mDetalle.Cells("plt_CodigoTrabajador").Value = "") Then
        '                                .plt_CodigoTrabajador = Nothing
        '                            Else
        '                                .plt_CodigoTrabajador = mDetalle.Cells("plt_CodigoTrabajador").Value
        '                            End If


        '                            .Usu_Id = SessionServer.UserId
        '                            .ptr_FecGrab = CDate(Today)

        '                            .prd_Periodo_idInicialDias = mDetalle.Cells("prd_Periodo_idInicialDias").Value
        '                            .prd_Periodo_idFinalDias = mDetalle.Cells("prd_Periodo_idFinalDias").Value
        '                            .prd_Periodo_idInicialIngresos = mDetalle.Cells("prd_Periodo_idInicialIngresos").Value
        '                            .prd_Periodo_idFinalIngresos = mDetalle.Cells("prd_Periodo_idFinalIngresos").Value
        '                            .per_Id = mDetalle.Cells("per_Id").Value


        '                            .MarkAsAdded()

        '                        End With
        '                        oPlanillas.PlanillaTrabajador.Add(nOSD)
        '                    End If

        '                Next


        '                BCPlanilla.Maintenance(oPlanillas)

        '                MsgBox("Datos Guardados")
        '                menuInicio()
        '                Panel1.Enabled = False
        '                limpiar()
        '                DeshabilitarElementoGrid()
        '            End If

        '        Catch ex As Exception
        '            Try
        '                MsgBox(ex.InnerException.Message)
        '            Catch ex2 As Exception
        '                MsgBox(ex.Message)
        '            End Try

        '        End Try

        '    End If
        'End Sub

        Public Sub ModificarXML()
            Dim NumeroFila As Integer
            Dim iColumnas As Integer
            Dim dVerificar As Double
            Dim sConceltoJudicial(1) As String
            Dim sConceptoPrestamo(1) As String

            ' toda  planilla al guadar  es una nueva planilla

            oPlanillas = New BE.Planillas
            'oPlanillas.MarkAsAdded()

            If (validar()) Then

                Try
                    sConceltoJudicial = cargarDatosJudiciales()
                    sConceptoPrestamo = cargarDatosPrestamo()

                    If oPlanillas IsNot Nothing Then
                        dgvResultadoCalculoPL.EndEdit()

                        oPlanillas.pla_Descripcion = txtDescripcion.Text
                        oPlanillas.prd_Periodo_id = txtPeriodo.Text
                        oPlanillas.pla_FechaInicio = Me.dateDesde.Text
                        oPlanillas.pla_FechaFin = Me.dateHasta.Text
                        oPlanillas.tip_TipoPlan_Id = Me.txtTipoPlanilla.Tag
                        oPlanillas.tit_TipoTrab_Id = Me.txtTipoTrabajador.Tag
                        oPlanillas.pla_SeriePlani = txtSerie.Text
                        oPlanillas.pla_Numero = txtNumero.Text
                        oPlanillas.ItemConceptoPlanilla = txtPlanilla.Tag
                        oPlanillas.pla_FECGRAB = Now
                        oPlanillas.Usu_Id = SessionServer.UserId

                        ''--- probando con un procedure cabecera
                        ' creamos la tabla cabecera
                        Dim dgvTemporalCABPLL As New DataGridView
                        dgvTemporalCABPLL.Columns.Add("tit_TipoTrab_Id", "")
                        dgvTemporalCABPLL.Columns.Add("tip_TipoPlan_Id", "")
                        dgvTemporalCABPLL.Columns.Add("pla_SeriePlani", "")
                        dgvTemporalCABPLL.Columns.Add("pla_Numero", "")
                        dgvTemporalCABPLL.Columns.Add("tdo_Id", "")
                        dgvTemporalCABPLL.Columns.Add("pla_Descripcion", "")
                        dgvTemporalCABPLL.Columns.Add("pla_FechaInicio", "")
                        dgvTemporalCABPLL.Columns.Add("pla_FechaFin", "")
                        dgvTemporalCABPLL.Columns.Add("ItemConceptoPlanilla", "")
                        dgvTemporalCABPLL.Columns.Add("prd_Periodo_id", "")
                        dgvTemporalCABPLL.Columns.Add("Usu_Id", "")
                        dgvTemporalCABPLL.Rows.Clear()
                        'creamos la tabla detalle
                        Dim dgvTemporalDETPLL As New DataGridView

                        dgvTemporalDETPLL.Columns.Add("tdo_Id", "")
                        dgvTemporalDETPLL.Columns.Add("pla_SeriePlani", "")
                        dgvTemporalDETPLL.Columns.Add("pla_Numero", "")
                        dgvTemporalDETPLL.Columns.Add("dep_Item", "")
                        dgvTemporalDETPLL.Columns.Add("per_Id", "")
                        dgvTemporalDETPLL.Columns.Add("tic_TipoConcep_Id", "")
                        dgvTemporalDETPLL.Columns.Add("con_Conceptos_Id", "")
                        dgvTemporalDETPLL.Columns.Add("dep_Importe", "")
                        dgvTemporalDETPLL.Columns.Add("TDO_IDRef", "")
                        dgvTemporalDETPLL.Columns.Add("DTD_IDRef", "")
                        dgvTemporalDETPLL.Columns.Add("dep_SerieRef", "")
                        dgvTemporalDETPLL.Columns.Add("dep_NumeroRef", "")
                        dgvTemporalDETPLL.Columns.Add("dep_temRef", "")
                        dgvTemporalDETPLL.Columns.Add("tip_TipoPlan_Id", "")
                        dgvTemporalDETPLL.Columns.Add("Usu_Id", "")
                        dgvTemporalDETPLL.Rows.Clear()

                        Dim dgvTemporalComedorHoiraPLL As New DataGridView

                        dgvTemporalComedorHoiraPLL.Columns.Add("pla_SeriePlani", "")
                        dgvTemporalComedorHoiraPLL.Columns.Add("pla_Numero", "")
                        dgvTemporalComedorHoiraPLL.Columns.Add("tdo_Id", "")
                        dgvTemporalComedorHoiraPLL.Columns.Add("item", "")
                        dgvTemporalComedorHoiraPLL.Columns.Add("esComedorOHora", "")
                        dgvTemporalComedorHoiraPLL.Columns.Add("com_Numero", "")
                        dgvTemporalComedorHoiraPLL.Columns.Add("tit_TipoTrab_Id", "")
                        dgvTemporalComedorHoiraPLL.Columns.Add("trh_Numero", "")
                        dgvTemporalComedorHoiraPLL.Rows.Clear()


                        With oPlanillas
                            dgvTemporalCABPLL.Rows.Add(.tit_TipoTrab_Id, _
                                                      .tip_TipoPlan_Id, _
                                                      .pla_SeriePlani, _
                                                      .pla_Numero, _
                                                      .tdo_Id, _
                                                      .pla_Descripcion, _
                                                      .pla_FechaInicio, _
                                                      .pla_FechaFin, _
                                                      .ItemConceptoPlanilla, _
                                                      .prd_Periodo_id, _
                                                      .Usu_Id)
                        End With

                        ' '' fin prueba cabecera

                        ' Detalle de planillas 
                        ' numeroFila = numero de item para detale planillas  
                        NumeroFila = 1

                        For Each mDetalle As DataGridViewRow In dgvResultadoCalculoPL.Rows

                            iColumnas = 0

                            ' pasamos columna tras columna 



                            While (dgvResultadoCalculoPL.Columns.Count > iColumnas)
                                Try
                                    If (IsNumeric(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(1, 2)) AndAlso IsNumeric(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3))) Then
                                        Dim nOSD As New BE.DetallePlanillas
                                        With nOSD

                                            nOSD.dep_FecGrab = CDate(Today)
                                            nOSD.dep_Importe = IIf(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Contains("¤"), 0, CDbl(Val(mDetalle.Cells(iColumnas).Value)))
                                            dVerificar = Double.Parse(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3)) * 5
                                            nOSD.tic_TipoConcep_Id = dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(1, 2)
                                            nOSD.con_Conceptos_Id = dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3)

                                            If (nOSD.tic_TipoConcep_Id = sConceltoJudicial(0) AndAlso nOSD.con_Conceptos_Id = sConceltoJudicial(1)) Then

                                                nOSD.dep_SerieRef = mDetalle.Cells("SerieDocJudicial").Value
                                                nOSD.dep_NumeroRef = mDetalle.Cells("NumeroDocJudicial").Value
                                                nOSD.dep_temRef = Nothing
                                                nOSD.TDO_IDRef = Nothing
                                            End If

                                            'sConceptoPrestamo

                                            If (nOSD.tic_TipoConcep_Id = sConceptoPrestamo(0) AndAlso nOSD.con_Conceptos_Id = sConceptoPrestamo(1)) Then

                                                nOSD.dep_SerieRef = mDetalle.Cells("SerieDocPrestamo").Value
                                                nOSD.dep_NumeroRef = mDetalle.Cells("NumeroDocPrestamo").Value

                                                'nOSD.CCT_IDre = "002"
                                                nOSD.DTD_IDRef = "054"
                                                nOSD.TDO_IDRef = "035"
                                                nOSD.dep_temRef = Nothing

                                            End If
                                            nOSD.dep_Item = derecha("00000" & NumeroFila.ToString(), 4)
                                            nOSD.per_Id = mDetalle.Cells("Per_id").Value

                                            nOSD.tip_TipoPlan_Id = txtTipoPlanilla.Tag
                                            nOSD.Usu_Id = SessionServer.UserId
                                            nOSD.dep_FecGrab = CDate(Today)

                                            .MarkAsAdded()

                                            oPlanillas.DetallePlanillas.Add(nOSD)

                                            '' probando procedure detalle
                                            With nOSD
                                                dgvTemporalDETPLL.Rows.Add(
                                                                  .tdo_Id, _
                                                                  .pla_SeriePlani, _
                                                                  .pla_Numero, _
                                                                  .dep_Item, _
                                                                  .per_Id, _
                                                                  .tic_TipoConcep_Id, _
                                                                  .con_Conceptos_Id, _
                                                                  .dep_Importe, _
                                                                  .TDO_IDRef, _
                                                                  .DTD_IDRef, _
                                                                  .dep_SerieRef, _
                                                                  .dep_NumeroRef, _
                                                                  .dep_temRef, _
                                                                  .tip_TipoPlan_Id, _
                                                                  .Usu_Id)
                                            End With
                                            '' fin de prueba

                                        End With
                                    End If
                                Catch ex As Exception

                                End Try

                                iColumnas += 1
                                NumeroFila += 1
                            End While



                        Next

                        ' horas planillas 

                        For Each mDetalle As DataGridViewRow In dgvHoraPersonal.Rows

                            Dim nOSD As New BE.PlanillasComedorHoras
                            With nOSD

                                .esComedorOHora = 0
                                .com_Numero = Nothing
                                .tit_TipoTrab_Id = mDetalle.Cells(0).Value()
                                .trh_Numero = mDetalle.Cells(1).Value()
                                .MarkAsAdded()

                            End With
                            oPlanillas.PlanillasComedorHoras.Add(nOSD)
                            With nOSD
                                dgvTemporalComedorHoiraPLL.Rows.Add(.pla_SeriePlani, _
                                                                  .pla_Numero, _
                                                                  .tdo_Id, _
                                                                  .item, _
                                                                  .esComedorOHora, _
                                                                  .com_Numero, _
                                                                  .tit_TipoTrab_Id, _
                                                                  .trh_Numero)
                            End With

                        Next

                        ' Comedor planillas 
                        For Each mDetalle As DataGridViewRow In dgvComedor.Rows

                            Dim nOSD As New BE.PlanillasComedorHoras
                            With nOSD

                                .esComedorOHora = 1
                                .com_Numero = mDetalle.Cells(0).Value()
                                .tit_TipoTrab_Id = Nothing
                                .trh_Numero = Nothing

                                .MarkAsAdded()

                            End With
                            oPlanillas.PlanillasComedorHoras.Add(nOSD)

                            With nOSD

                                dgvTemporalComedorHoiraPLL.Rows.Add(.pla_SeriePlani, _
                                                                  .pla_Numero, _
                                                                  .tdo_Id, _
                                                                  .item, _
                                                                  .esComedorOHora, _
                                                                  .com_Numero, _
                                                                  .tit_TipoTrab_Id, _
                                                                  .trh_Numero)
                            End With

                        Next

                        BCPlanilla.SPPlanillaUpdate(getXml(dgvTemporalCABPLL, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10), getXml(dgvTemporalDETPLL, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14), txtSerie.Text, getXml(dgvTemporalComedorHoiraPLL, 0, 1, 2, 3, 4, 5, 6, 7), oPlanillas.pla_Numero)
                        ' BCPlanilla.Maintenance(oPlanillas)

                        MsgBox("Datos Modificados")
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()
                        DeshabilitarElementoGrid()
                    End If

                Catch ex As Exception
                    MsgBox(ex.InnerException.Message)
                End Try

            End If
        End Sub


        Public Overrides Sub OnManGuardar()

            If (txtNumero.Text = "") Then
                If (ValidarNegativos()) Then
                    'pbarBarra.Minimum = 0
                    'pbarBarra.Maximum = dgvResultadoCalculoPL.Rows.Count
                    'ingresar()
                    BackgroundWorker1.RunWorkerAsync()
                End If

            Else
                If (ValidarNegativos()) Then
                    ModificarXML()
                End If

            End If

        End Sub

        Private Function derecha(ByVal sdato As String, ByVal numeros As Int16)
            Return sdato.Substring(sdato.Length - numeros, numeros)

        End Function
        Function cargarDatosJudiciales() As String()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()

            Dim sConceptoJudicial(1) As String

            frm.campo1 = Nothing
            frm.campo2 = 1
            frm.campo3 = Nothing
            Try
                frm.inicio(Constants.BuscadoresNames.DetalleConceptosPlanillasLista)
                frm.cargarDatos()

                sConceptoJudicial(0) = frm.dgbRegistro.CurrentRow.Cells(2).Value 'dtj_idTiposConceptos
                sConceptoJudicial(1) = frm.dgbRegistro.CurrentRow.Cells(4).Value 'con_Conceptos_Id

                frm.Dispose()
            Catch ex As Exception
                sConceptoJudicial(0) = ""
                sConceptoJudicial(1) = "1"
            End Try

            Return sConceptoJudicial

        End Function
        Function cargarDatosPrestamo() As String()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()

            Dim sConceptoPrestamo(1) As String

            frm.campo1 = Nothing
            frm.campo2 = Nothing
            frm.campo3 = 1

            Try

                frm.inicio(Constants.BuscadoresNames.DetalleConceptosPlanillasLista)
                frm.cargarDatos()
                'If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                '  dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Value = frm.dgbRegistro.CurrentRow.Cells(0).Value
                sConceptoPrestamo(0) = frm.dgbRegistro.CurrentRow.Cells(2).Value ' tipo de concepto
                sConceptoPrestamo(1) = frm.dgbRegistro.CurrentRow.Cells(4).Value ' id de concepto

                '  End If

                frm.Dispose()
            Catch ex As Exception

                sConceptoPrestamo(0) = ""
                sConceptoPrestamo(1) = ""

            End Try


            Return sConceptoPrestamo

        End Function
        Sub cargarTipoPlanilla(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, Optional ByVal cop_Descripcion As String = Nothing)
            Dim query As String
            limpiarTipoPlanilla()

            '----------------------------------------------------------
            query = Me.BCConceptosPlanilla.ConceptosPlanillasDetalleQuery(tit_TipoTrab_Id, tip_TipoPlan_Id, ItemConceptoPlanilla, Nothing)
            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)

                    txtPlanilla.Tag = ds.Tables(0).Rows(0).Item("ItemConceptoPlanilla").ToString ' oConceptosPlanilla.tit_TipoTrab_Id 
                    txtPlanilla.Text = ds.Tables(0).Rows(0).Item("cop_Descripcion").ToString
                    txtTipoPlanilla.Tag = ds.Tables(0).Rows(0).Item("tip_TipoPlan_Id").ToString 'oConceptosPlanilla.tip_TipoPlan_Id '
                    txtTipoPlanilla.Text = ds.Tables(0).Rows(0).Item("tip_Descripcion").ToString
                    txtTipoTrabajador.Tag = ds.Tables(0).Rows(0).Item("tit_TipoTrab_Id").ToString 'ds.Tables(0).Rows(0).Item("tip_Descripcion").ToString
                    txtTipoTrabajador.Text = ds.Tables(0).Rows(0).Item("tit_Descripcion").ToString

                End If
            End If
            '-----------------------------------
        End Sub


        Private Sub btnPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodo.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodo.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
            End If

            frm.Dispose()
        End Sub

        Private Sub btnTrabajadorHora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrabajadorHora.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarFecha)()

            frm.inicio(Constants.BuscadoresNames.TrabajadorHoras)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtTipotrabajadroHora.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtNumeroHora.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
                txtObservacionesHora.Text = frm.dgbRegistro.CurrentRow.Cells(6).Value

                'cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value, frm.dgbRegistro.CurrentRow.Cells(1).Value)

            End If
            frm.Dispose()

        End Sub

        Private Sub btnAgregarHora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarHora.Click
            If (validarSeleccionHora()) Then
                dgvHoraPersonal.Rows.Add(txtTipotrabajadroHora.Tag, txtNumeroHora.Text, txtObservacionesHora.Text)

            End If
        End Sub

        Private Function validarSeleccionHora() As Boolean
            Dim result As Boolean = True
            Dim x As Integer = 0
            While (dgvHoraPersonal.RowCount > x)

                If (dgvHoraPersonal.Rows(x).Cells(1).Value = txtNumeroHora.Text) Then
                    ErrorProvider1.SetError(txtNumeroHora, "YA existe EL registro")

                    result = False
                    Exit While
                Else
                    ErrorProvider1.SetError(txtNumeroHora, "")

                End If
                x += 1
            End While

            Return result

        End Function
        Private Function validarSeleccionComedor(ByVal valorAbuscar As String) As Boolean
            Dim result As Boolean = True
            Dim x As Integer = 0
            While (dgvComedor.RowCount > x)

                If (dgvComedor.Rows(x).Cells(0).Value = valorAbuscar) Then
                    ErrorProvider1.SetError(txtNumeroComedor, "Ya existe el Registro")

                    result = False
                    Exit While
                Else
                    ErrorProvider1.SetError(txtNumeroComedor, "")

                End If

                x += 1
            End While

            Return result

        End Function
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtSerie.Text = "") Then
                ErrorProvider1.SetError(txtSerie, "Serie")
                result = False
            Else
                ErrorProvider1.SetError(txtSerie, Nothing)
            End If

            If (txtDescripcion.Text = "") Then
                ErrorProvider1.SetError(txtDescripcion, "Descripcion")
                result = False
            Else
                ErrorProvider1.SetError(txtDescripcion, Nothing)
            End If

            If (txtPlanilla.Text = "") Then
                ErrorProvider1.SetError(txtPlanilla, "planilla")
                result = False
            Else
                ErrorProvider1.SetError(txtPlanilla, Nothing)
            End If

            If (dgvHoraPersonal.Rows.Count <= 0) Then
                ErrorProvider1.SetError(dgvHoraPersonal, "Horas no ingresadas")
                result = False
            Else
                ErrorProvider1.SetError(dgvHoraPersonal, Nothing)
            End If

            If (txtPeriodo.Text = "") Then
                ErrorProvider1.SetError(txtPeriodo, "Periodo")
                result = False
            Else
                ErrorProvider1.SetError(txtPeriodo, Nothing)
            End If


            If (CDate(dateDesde.Text) > CDate(dateHasta.Text)) Then
                ErrorProvider1.SetError(dateDesde, "Fecha no valida")
                result = False
            Else
                ErrorProvider1.SetError(dateDesde, Nothing)
            End If

            'If (rdbPeriodoEspesifico.Checked) Then
            '    If (txtPeriodoDesde.Text = "" OrElse txtPeriodoHasta.Text OrElse Val(txtPeriodoHasta.Text) < Val(txtPeriodoDesde.Text)) Then
            '        ErrorProvider1.SetError(txtPeriodoDesde, "Periodo Desde")
            '        ErrorProvider1.SetError(txtPeriodoHasta, "Periodo Hasta")
            '        result = False
            '    Else
            '        ErrorProvider1.SetError(txtPeriodoDesde, Nothing)
            '        ErrorProvider1.SetError(txtPeriodoHasta, Nothing)
            '    End If
            'End If




            Return result

        End Function

        Public Function ValidarNegativos()


            Dim iColumnas As Integer = 0
            Dim iFila As Integer = 0

            While dgvResultadoCalculoPL.Columns.Count > iColumnas

                If (IsNumeric(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(1, 2)) AndAlso IsNumeric(dgvResultadoCalculoPL.Columns(iColumnas).Name.ToString.Substring(3, 3))) Then
                    iFila = 0
                    While dgvResultadoCalculoPL.Rows.Count > iFila
                        Try

                            If (IsDBNull(dgvResultadoCalculoPL.Rows(iFila).Cells(iColumnas).Value)) Then
                                dgvResultadoCalculoPL.Rows(iFila).Cells(iColumnas).Value = "0.00"
                            End If

                            If (Val(dgvResultadoCalculoPL.Rows(iFila).Cells(iColumnas).Value) < 0) Then

                                dgvResultadoCalculoPL.CurrentCell = dgvResultadoCalculoPL.Rows(iFila).Cells(iColumnas)
                                ErrorProvider1.SetError(txtDescripcion, "Existen valores negativos")

                                Return False

                            End If
                        Catch ex As Exception

                            ErrorProvider1.SetError(txtDescripcion, "Fila:" & iFila.ToString & " ,Columna: " & dgvResultadoCalculoPL.Columns(iColumnas).HeaderText & " Valor no Valido")
                            Return False
                        End Try

                        iFila += 1
                    End While

                End If

                iColumnas += 1
            End While

            ErrorProvider1.SetError(txtDescripcion, Nothing)


            Return True

        End Function

        Private Sub btnQuitarHora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarHora.Click
            Try
                If (dgvHoraPersonal.SelectedRows.Count > 0) Then
                    dgvHoraPersonal.Rows.RemoveAt(dgvHoraPersonal.SelectedRows(0).Index)
                Else
                    MsgBox("Seleccione un registro")
                End If
            Catch ex As Exception

            End Try



        End Sub

        Private Sub btnBuscarComedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarComedor.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarFecha)()
            frm.inicio(Constants.BuscadoresNames.Comedor)
            Dim x As Integer = 0
            Dim paso As Boolean = False
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                frm.dgbRegistro.EndEdit()
                Try
                    While (frm.dgbRegistro.Rows.Count > x)
                        If (CBool(frm.dgbRegistro.Rows(x).Cells(0).Value)) Then

                            If (validarSeleccionComedor(frm.dgbRegistro.Rows(x).Cells(1).Value)) Then
                                dgvComedor.Rows.Add(frm.dgbRegistro.Rows(x).Cells(1).Value, frm.dgbRegistro.Rows(x).Cells(2).Value)
                            End If
                            paso = True
                        End If
                        x += 1
                    End While
                    If Not (paso) Then
                        txtNumeroComedor.Text = frm.dgbRegistro.SelectedRows(0).Cells(1).Value
                        txtDescripcionComedor.Text = frm.dgbRegistro.SelectedRows(0).Cells(2).Value
                    End If

                Catch ex As Exception
                    MsgBox("Error al Obtener los Datos, Intente Nuevamente ," & ex.Message)
                End Try

            End If
            frm.Dispose()
        End Sub
        Private Sub btnAgregarComedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarComedor.Click
            If (validarSeleccionComedor(txtNumeroComedor.Text)) Then
                dgvComedor.Rows.Add(txtNumeroComedor.Text, txtDescripcionComedor.Text)
            End If
        End Sub

        Private Sub btnQuitarComedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarComedor.Click
            Try
                If (dgvComedor.SelectedRows.Count > 0) Then
                    dgvComedor.Rows.RemoveAt(dgvComedor.SelectedRows(0).Index)
                Else
                    MsgBox("Seleccione un Registro")
                End If

            Catch ex As Exception

            End Try

        End Sub

        Public Function getXml(ByVal oDataGridView As DataGridView, ByVal ParamArray Columns() As Integer) As String
            Dim x, y As Int32
            Dim sRes As String
            x = 0
            y = 0

            sRes = "<MAtablita>"
            While (x < oDataGridView.Rows.Count)
                y = 0
                sRes &= " <rows>"
                While (y < Columns.Length)
                    sRes &= "  <campo" & y.ToString() & ">" & oDataGridView.Rows(x).Cells(Columns(y)).Value & "</campo" & y.ToString() & ">"
                    y += 1
                End While
                sRes &= " </rows>"
                x += 1
            End While
            sRes &= "</MAtablita>"
            Return sRes
        End Function
        ' If CBool(dgvSeleccionPersonas.Rows(x).Cells(0).Value) Then
        Public Function getXml(ByVal ColumnaOK As Int16, ByVal oDataGridView As DataGridView, ByVal ParamArray Columns() As Integer) As String
            Dim x, y As Int32
            Dim sRes As String
            x = 0
            y = 0
            sRes = "<MAtablita>"
            While (x < oDataGridView.Rows.Count)
                If CBool(oDataGridView.Rows(x).Cells(ColumnaOK).Value) Then
                    y = 0
                    sRes &= " <rows>"
                    While (y < Columns.Length)
                        sRes &= "  <campo" & y.ToString() & ">" & oDataGridView.Rows(x).Cells(Columns(y)).Value & "</campo" & y.ToString() & ">"
                        y += 1
                    End While
                    sRes &= " </rows>"
                End If
                x += 1
            End While
            sRes &= "</MAtablita>"
            Return sRes
        End Function

        Sub cargarPersonas(ByVal oTable As DataTable)
            Dim x As Integer = 0

            dgvSeleccionPersonas.Rows.Clear()
            dgvDescuentoJudicial.Rows.Clear()

            While (oTable.Rows.Count > x)

                With oTable.Rows(x)

                    dgvSeleccionPersonas.Rows.Add(CType(.Item(0), Boolean), .Item(1), .Item(2), .Item(3), Nothing, Nothing, Nothing, Nothing, .Item("cco_Id"), .Item("tis_TipCargo_Id"), .Item("rep_RegiPension_id"), .Item("art_AreaTrab_Id"), .Item("rel_RegLaboral_Id"), .Item("plt_NuemroDeCuenta"), .Item("ccc_IdCuenta"), .Item("plt_CodigoTrabajador"), .Item("tit_Descripcion"))

                    If Not (IsDBNull(.Item(5)) OrElse .Item(5) Is Nothing OrElse .Item(5) = "" OrElse Len(.Item(5)) <= 0) Then
                        dgvDescuentoJudicial.Rows.Add(CType(.Item(4), Boolean), .Item(5), .Item(6), .Item(7), CType(.Item(8), Boolean), .Item(9), .Item(10), .Item(11), .Item(12))
                        'para mostrar o no en el registro judicial en el caso de de desactivar y luego activar
                        dgvSeleccionPersonas.Rows(x).Cells(1).Tag = oTable.Rows(x)



                    End If

                End With

                x += 1
            End While


        End Sub
        Sub CargarDatosSegunHoras()

            Dim query As String = Nothing
            dgvSeleccionPersonas.Rows.Clear()
            Try
                query = BCPlanilla.TrabajadorParaPlanillasSeek(getXml(dgvHoraPersonal, 0, 1), txtTipoPlanilla.Tag)
                If (query <> Nothing) Then
                    Dim ds As New DataSet
                    Dim rea As New StringReader(query)
                    If (query <> "") Then
                        ds.ReadXml(rea)
                        cargarPersonas(ds.Tables(0))

                    Else
                        dgvSeleccionPersonas.Rows.Clear()

                    End If
                End If

            Catch ex As Exception
                dgvSeleccionPersonas.Rows.Clear()
            End Try
        End Sub

        Sub CargarPagosSegunHoras()
            Dim query As String = Nothing

            dgvPrestamos.Rows.Clear()
            Try
                query = BCPlanilla.spTrabajadorPagosParaPlanillasSeek(getXml(dgvHoraPersonal, 0, 1))
                If (query <> Nothing) Then
                    Dim ds As New DataSet
                    Dim rea As New StringReader(query)
                    If (query <> "") Then
                        ds.ReadXml(rea)
                        '-------------------------------------
                        Dim x As Integer = 0

                        dgvPrestamos.Rows.Clear()

                        While (ds.Tables(0).Rows.Count > x)

                            With ds.Tables(0).Rows(x)

                                dgvPrestamos.Rows.Add(CType(.Item(0), Boolean), .Item(1), .Item(2), .Item(3), .Item(4), .Item(5), .Item(6), .Item(7), .Item(8), .Item(9), .Item(10), .Item(11), .Item(12), .Item(13))

                            End With

                            x += 1
                        End While
                        '-------------------------------------

                    Else
                        dgvPrestamos.Rows.Clear()

                    End If
                End If

            Catch ex As Exception
                dgvPrestamos.Rows.Clear()
            End Try




        End Sub


        Sub CargarPlanilla()

            Dim sPeriodoDesde As String = ""
            Dim sPeriodoHasta As String = ""

            If (rdbPeriodoActual.Checked) Then
                sPeriodoDesde = txtPeriodo.Text
                sPeriodoHasta = txtPeriodo.Text
            End If

            If (rdbPeriodoLiquidacion.Checked) Then
                sPeriodoDesde = Nothing
                sPeriodoHasta = Nothing
            End If
            If (rdbPeriodoEspesifico.Checked) Then
                sPeriodoDesde = txtPeriodoDesde.Text
                sPeriodoHasta = txtPeriodoHasta.Text
            End If

            dgvResultadoCalculoPL.DataSource = Nothing

            Try

                dgvResultadoCalculoPL.DataSource = BCPlanilla.TrabajadorCalculoPlanillas(getXml(dgvComedor, 0), getXml(dgvHoraPersonal, 0, 1), getXml(0, dgvDescuentoJudicial, 1), getXml(0, dgvPrestamos, 13, 10, 11, 4, 5, 1, 6), getXml(0, dgvSeleccionPersonas, 1, 4, 5, 6, 7), txtTipoPlanilla.Tag, sPeriodoDesde, sPeriodoHasta, Me.txtTipoTrabajador.Tag, txtPlanilla.Tag)
                dgvResultadoCalculoPL.Columns(0).Frozen = True
                dgvResultadoCalculoPL.Columns(1).Frozen = True
                dgvResultadoCalculoPL.Columns(2).Frozen = True

            Catch ex As Exception
                MsgBox(ex.Message)
                dgvResultadoCalculoPL.DataSource = Nothing
            End Try
        End Sub
        Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
            Select Case TabPlanillas.SelectedIndex
                Case 0
                    'horas
                    If (validar()) Then
                        If (dgvHoraPersonal.RowCount > 0) Then
                            CargarDatosSegunHoras()
                            TabPlanillas.SelectedIndex = 1
                        Else
                            If (MsgBox("No hay Horas asignado, desea continuar ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                                TabPlanillas.SelectedIndex = 1
                                CargarDatosSegunHoras()
                            End If
                        End If

                    End If
                Case 1
                    'comedor
                    If (dgvComedor.RowCount > 0) Then
                        'CargarDatosSegunHoras()
                        TabPlanillas.SelectedIndex = 2
                    Else
                        If (MsgBox("No hay comedor asignado, desea continuar ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                            TabPlanillas.SelectedIndex = 2
                            'CargarDatosSegunHoras()
                        End If
                    End If
                Case 2
                    'descuento judicial
                    CargarPagosSegunHoras()

                    TabPlanillas.SelectedIndex = 3

                Case 3
                    ' descuento prestamos

                    TabPlanillas.SelectedIndex = 4
                Case 4
                    ' final


                    Dim HayPersonasSelec As Boolean = False
                    Dim x As Int16

                    ' filtramos datos judiciales seleccionados 
                    'filtramos datos de prestamos seleccionados 
                    ' filtramos personas seleccionadas
                    x = 0

                    While (dgvSeleccionPersonas.Rows.Count > x)
                        If CBool(dgvSeleccionPersonas.Rows(x).Cells(0).Value) Then
                            HayPersonasSelec = True
                            Exit While
                        End If
                        x += 1
                    End While

                    If (HayPersonasSelec) Then
                        TabPlanillas.SelectedIndex = 5
                        CargarPlanilla()
                    Else
                        MsgBox("Seleccione como minimo a un trabajador")
                    End If

            End Select

        End Sub

        Private Sub frmPlanilla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            Try
                BackgroundWorker1.CancelAsync()
                BackgroundWorker1.Dispose()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub frmPlanilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            TabPlanillas.SelectedIndex = 0
            menuInicio()
            tipoTrabajadorLista()
            Panel1.Enabled = False
        End Sub

        Private Sub tipoTrabajadorLista()
            Try
                Dim result = Me.BCTiposTrabajador.TiposTrabajadorQuery(Nothing, Nothing)
                Dim ds As New DataSet
                Dim sr As New StringReader(result)
                Dim x As Integer = 0
                Dim oTable As DataTable
                ds.ReadXml(sr)
                chkLista.Items.Clear()
                While (ds.Tables(0).Rows.Count > x)
                    Me.chkLista.Items.Add(ds.Tables(0).Rows(x).Item("tit_Descripcion"), False)
                    x += 1
                End While
                'Me.cboTipoTrabajador.DisplayMember = "tit_Descripcion"
                ' Me.cboTipoTrabajador.ValueMember = "tit_TipoTrab_Id"
            Catch ex As Exception
                MsgBox("No se Pudo cargar los datos")
            End Try
        End Sub

        Private Sub btnPagosYPrestamos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPagosYPrestamos.Click

            dgvPagosPrestamos.DataSource = Nothing
            Try
                If (dgvPrestamos.SelectedRows.Count > 0) Then
                    With dgvPrestamos.SelectedRows(0)
                        lblTrabajador.Text = .Cells(3).Value
                        dgvPagosPrestamos.DataSource = BCPlanilla.spTrabajadorPagosXDocPlanillas( _
                             .Cells("Column10").Value, _
                            .Cells("Column11").Value, _
                            .Cells("Column4").Value, _
                            .Cells("Column5").Value)
                    End With

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                dgvPagosPrestamos.DataSource = Nothing
            End Try


            dgvDatosPrestamos.DataSource = Nothing
            Try
                If (dgvPrestamos.SelectedRows.Count > 0) Then
                    With dgvPrestamos.SelectedRows(0)
                        dgvDatosPrestamos.DataSource = BCPlanilla.spDetallePrestamoParaPlanilla( _
                            .Cells("Column10").Value, _
                            .Cells("Column11").Value, _
                            .Cells("Column4").Value, _
                            .Cells("Column5").Value)
                    End With

                End If



            Catch ex As Exception
                dgvDatosPrestamos.DataSource = Nothing
            End Try

        End Sub


        Private Sub btnInicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInicio.Click
            TabPlanillas.SelectedIndex = 0
        End Sub


        Private Sub dgvResultadoCalculoPL_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvResultadoCalculoPL.CellMouseDoubleClick
            txtSumaPLL.Text = SumarCOlumna(e.ColumnIndex)
        End Sub

        Private Sub chkMarcarPersonas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarcarPersonas.CheckedChanged

            Dim x As Integer = 0

            While (dgvSeleccionPersonas.Rows.Count > x)
                dgvSeleccionPersonas.Rows(x).Cells(0).Value = chkMarcarPersonas.Checked
                x += 1
            End While
            x = 0
            While (chkLista.Items.Count > x)
                chkLista.SetItemChecked(x, chkMarcarPersonas.Checked)
                x += 1
            End While
        End Sub

        Private Sub btnPeriodoDesde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodoDesde.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodoDesde.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value

                pasarPeriodos(1)
            End If

            frm.Dispose()
        End Sub

        Private Sub btnPeriodoHasta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodoHasta.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodoHasta.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value

                pasarPeriodos(2)
            End If

            frm.Dispose()
        End Sub

        Sub pasarPeriodos(ByVal iBusqueda As Integer)
            Dim x As Integer = 0
            While (dgvSeleccionPersonas.Rows.Count > x)

                If (iBusqueda = 1 OrElse iBusqueda = 3) Then
                    dgvSeleccionPersonas.Rows(x).Cells("prd_Periodo_idInicialIngresos").Value = txtPeriodoDesde.Text
                    dgvSeleccionPersonas.Rows(x).Cells("prd_Periodo_idInicialIngresos").Tag = txtPeriodoDesde.Text

                End If

                If (iBusqueda = 2 OrElse iBusqueda = 3) Then
                    dgvSeleccionPersonas.Rows(x).Cells("prd_Periodo_idFinalIngresos").Value = txtPeriodoHasta.Text
                    dgvSeleccionPersonas.Rows(x).Cells("prd_Periodo_idFinalIngresos").Tag = txtPeriodoHasta.Text

                End If

                x += 1
            End While

        End Sub

        Private Sub rdbPeriodoActual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles rdbPeriodoActual.CheckedChanged, _
            rdbPeriodoEspesifico.CheckedChanged, _
            rdbPeriodoLiquidacion.CheckedChanged

            If (rdbPeriodoEspesifico.Checked) Then
                Panel7.Visible = True
            Else
                Panel7.Visible = False
            End If

        End Sub

        Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
            Dim x As Integer = 0
            x = 0
            If (txtCodigo.Text.Length >= 4) Then
                While (dgvSeleccionPersonas.Rows.Count > x)
                    Try
                        If (dgvSeleccionPersonas.Rows(x).Cells("Codigo").Value = txtCodigo.Text) Then
                            dgvSeleccionPersonas.CurrentCell = dgvSeleccionPersonas.Rows(x).Cells(0)
                            Exit Sub
                        End If
                    Catch ex As Exception

                    End Try
                    x += 1
                End While

            End If
        End Sub

        Private Sub txtCodigoBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoBuscar.TextChanged
            Dim x As Integer = 0
            x = 0
            If (txtCodigoBuscar.Text.Length >= 4) Then
                While (dgvResultadoCalculoPL.Rows.Count > x)
                    Try
                        If (dgvResultadoCalculoPL.Rows(x).Cells("Cod").Value = txtCodigoBuscar.Text) Then
                            dgvResultadoCalculoPL.CurrentCell = dgvResultadoCalculoPL.Rows(x).Cells(0)
                            Exit Sub
                        End If
                    Catch ex As Exception

                    End Try
                    x += 1
                End While

            End If
        End Sub

        Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
            Dim oTablita As New DataTable
            If (dgvResultadoCalculoPL.Rows.Count > 0) Then
                oTablita = BCUtil.getTable(dgvResultadoCalculoPL, "MiTablita")
                BCUtil.excelExportar(oTablita)

            End If

        End Sub

        Private Sub chkCalculoDias_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCalculoDias.CheckedChanged
            Panel8.Visible = chkCalculoDias.Checked
        End Sub

        Private Sub dgvSeleccionPersonas_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeleccionPersonas.CellClick
            Try
                Select Case dgvSeleccionPersonas.Columns(e.ColumnIndex).Name

                    Case "prd_Periodo_idInicialIngresos"
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
                        frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
                        If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                            With frm.dgbRegistro.CurrentRow
                                dgvSeleccionPersonas.Rows(e.RowIndex).Cells("prd_Periodo_idInicialIngresos").Tag = .Cells(0).Value
                                dgvSeleccionPersonas.Rows(e.RowIndex).Cells("prd_Periodo_idInicialIngresos").Value = .Cells(0).Value
                            End With
                        End If
                        frm.Dispose()

                    Case "prd_Periodo_idFinalIngresos"
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
                        frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
                        If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                            With frm.dgbRegistro.CurrentRow
                                dgvSeleccionPersonas.Rows(e.RowIndex).Cells("prd_Periodo_idFinalIngresos").Tag = .Cells(0).Value
                                dgvSeleccionPersonas.Rows(e.RowIndex).Cells("prd_Periodo_idFinalIngresos").Value = .Cells(0).Value
                            End With
                        End If
                        frm.Dispose()

                    Case "prd_Periodo_idInicialDias"
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
                        frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
                        If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                            With frm.dgbRegistro.CurrentRow
                                dgvSeleccionPersonas.Rows(e.RowIndex).Cells("prd_Periodo_idInicialDias").Tag = .Cells(0).Value
                                dgvSeleccionPersonas.Rows(e.RowIndex).Cells("prd_Periodo_idInicialDias").Value = .Cells(0).Value
                            End With
                        End If
                        frm.Dispose()

                    Case "prd_Periodo_idFinalDias"
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
                        frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
                        If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                            With frm.dgbRegistro.CurrentRow
                                dgvSeleccionPersonas.Rows(e.RowIndex).Cells("prd_Periodo_idFinalDias").Tag = .Cells(0).Value
                                dgvSeleccionPersonas.Rows(e.RowIndex).Cells("prd_Periodo_idFinalDias").Value = .Cells(0).Value
                            End With
                        End If
                        frm.Dispose()

                End Select

            Catch ex As Exception

            End Try

        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodoDesdeDias.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value

                pasarPeriodosDias(1)

            End If

            frm.Dispose()
        End Sub
        Sub pasarPeriodosDias(ByVal sbuscar As Integer)
            Dim x As Integer = 0
            While (dgvSeleccionPersonas.Rows.Count > x)

                If (sbuscar = 1 OrElse sbuscar = 3) Then
                    dgvSeleccionPersonas.Rows(x).Cells("prd_Periodo_idInicialDias").Value = txtPeriodoDesdeDias.Text
                    dgvSeleccionPersonas.Rows(x).Cells("prd_Periodo_idInicialDias").Tag = txtPeriodoDesdeDias.Text

                End If
                If (sbuscar = 2 OrElse sbuscar = 3) Then
                    dgvSeleccionPersonas.Rows(x).Cells("prd_Periodo_idFinalDias").Value = txtPeriodoHastaDias.Text
                    dgvSeleccionPersonas.Rows(x).Cells("prd_Periodo_idFinalDias").Tag = txtPeriodoHastaDias.Text

                End If
                x += 1
            End While
        End Sub


        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodoHastaDias.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value

                pasarPeriodosDias(2)

            End If

            frm.Dispose()
        End Sub

        Private Sub dgvSeleccionPersonas_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSeleccionPersonas.RowHeaderMouseDoubleClick

            If (dgvSeleccionPersonas.SelectedRows.Count > 0) Then
                Dim frm = Me.ContainerService.Resolve(Of frmDatosLaborales)()
                frm.lblTitle.Text = "Datos Laborales"

                frm.cargar(dgvSeleccionPersonas.SelectedRows(0).Cells("Per_id").Value)
                frm.menuBuscar()
                frm.Panel1.Enabled = False
                frm.esLlamado = True
                frm.ShowDialog()

                frm.Dispose()
            End If

        End Sub

        Private Sub dgvResultadoCalculoPL_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvResultadoCalculoPL.RowHeaderMouseDoubleClick
            If (dgvSeleccionPersonas.SelectedRows.Count > 0) Then
                Dim frm = Me.ContainerService.Resolve(Of frmDatosLaborales)()
                frm.lblTitle.Text = "Datos Laborales"

                frm.cargar(dgvResultadoCalculoPL.SelectedRows(0).Cells("Per_id").Value)
                frm.menuBuscar()
                frm.Panel1.Enabled = False
                frm.esLlamado = True
                frm.ShowDialog()

                frm.Dispose()
            End If
        End Sub

        Private Sub chkLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLista.SelectedIndexChanged


            Dim x As Integer = 0
            Dim y As Integer

            x = 0
            While (dgvSeleccionPersonas.Rows.Count > x)
                dgvSeleccionPersonas.Rows(x).Cells(0).Value = False
                x += 1
            End While

            x = 0
            While (dgvSeleccionPersonas.Rows.Count > x)
                y = 0
                While (chkLista.Items.Count > y)
                    If (chkLista.GetItemChecked(y) = True) Then
                        Try
                            If (dgvSeleccionPersonas.Rows(x).Cells("tit_Descripcion").Value = chkLista.Items(y)) Then
                                dgvSeleccionPersonas.Rows(x).Cells("ok").Value = True
                           
                            End If

                        Catch ex As Exception

                        End Try

                    End If
                    y += 1
                End While
                x += 1

            End While
        End Sub

        Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
            ingresar()
        End Sub

        Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
            menuInicio()
            Panel1.Enabled = False
            limpiar()
            DeshabilitarElementoGrid()
        End Sub
    End Class
End Namespace