
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling


Namespace Ladisac.Planillas.Views
    Public Class frmDatosLaborales
        <Dependency()> _
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property BCDatosLaborales As Ladisac.BL.BCDatosLaborales

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oDatosLaborales As New BE.DatosLaborales
        Public Property esLlamado As Boolean


        Private Function validar() As Boolean
            Dim result As Boolean = True
            If (txtPersona.Text.Trim = "") Then
                ErrorProvider1.SetError(txtPersona, "Persona")
                result = False
            Else
                ErrorProvider1.SetError(txtPersona, Nothing)
            End If

            If (txtRegimenLaboral.Tag = "") Then
                ErrorProvider1.SetError(txtRegimenLaboral, "Regimen Laboral")
                result = False
            Else
                ErrorProvider1.SetError(txtRegimenLaboral, Nothing)
            End If

            If (txtRegimenPensionario.Tag = "") Then
                ErrorProvider1.SetError(txtRegimenPensionario, "Regimen Pensionario")
                result = False

            Else
                ErrorProvider1.SetError(txtRegimenPensionario, Nothing)
            End If

            If (txtTipoTrabajador.Tag = "") Then
                ErrorProvider1.SetError(txtTipoTrabajador, "Tipo Trabajador ")
                result = False

            Else
                ErrorProvider1.SetError(txtTipoTrabajador, Nothing)
            End If

            If (txtCargo.Tag = "") Then
                ErrorProvider1.SetError(txtCargo, "Cargo")
                result = False

            Else
                ErrorProvider1.SetError(txtCargo, Nothing)
            End If


            If (txtSituacionTrabajador.Tag = "") Then
                ErrorProvider1.SetError(txtSituacionTrabajador, "Situacion Trabajador")
                result = False

            Else
                ErrorProvider1.SetError(txtSituacionTrabajador, Nothing)
            End If

            'If (txtSituacionEspecial.Tag = "") Then
            '    ErrorProvider1.SetError(txtSituacionEspecial, "Situacion Especial")
            '    result = False

            'Else
            '    ErrorProvider1.SetError(txtSituacionEspecial, Nothing)
            'End If


            If (txtAreaTrabajo.Tag = "") Then
                ErrorProvider1.SetError(txtAreaTrabajo, "Area Trabajo")
                result = False

            Else
                ErrorProvider1.SetError(txtAreaTrabajo, Nothing)
            End If


            If (txtPeriodisidad.Tag = "") Then
                ErrorProvider1.SetError(txtPeriodisidad, "Periodisidad")
                result = False

            Else
                ErrorProvider1.SetError(txtPeriodisidad, Nothing)
            End If


            'If (txtDobleTributacion.Tag = "") Then
            '    ErrorProvider1.SetError(txtDobleTributacion, "Doble Tributacion")
            '    result = False

            'Else
            '    ErrorProvider1.SetError(txtDobleTributacion, Nothing)
            'End If

            If (txtTipoContrato.Tag = "") Then
                ErrorProvider1.SetError(txtTipoContrato, "Tipo Contrato")
                result = False
            Else
                ErrorProvider1.SetError(txtTipoContrato, Nothing)
            End If

            If (txtCentroRiesgo.Tag = "") Then
                ErrorProvider1.SetError(txtCentroRiesgo, "Centro de Riesgo")
                result = False
            Else
                ErrorProvider1.SetError(txtTipoContrato, Nothing)
            End If



            'arp


            If (Not validarDetalle()) Then
                ErrorProvider1.SetError(dataCronograma, "Fecha no valida")
                result = False
            Else
                ErrorProvider1.SetError(dataCronograma, "")
            End If


            If (Not validarDetallePeriodoLaboral()) Then
                ErrorProvider1.SetError(dataPeriodoLaboral, "Fechas,solo un periodo y liquidacion Activa")
                result = False
            Else
                ErrorProvider1.SetError(dataPeriodoLaboral, Nothing)
            End If


            Return result
        End Function

        Private Sub limpiar()
            txtAreaTrabajo.Text = ""
            txtAreaTrabajo.Tag = ""

            txtAutoGeneradoEssalud.Text = ""
            txtAutoGeneradoEssalud.Tag = ""

            txtBancoCTS.Text = ""
            txtBancoCTS.Tag = ""

            txtBancoRenumeracion.Text = ""
            txtBancoRenumeracion.Tag = ""

            txtNumeroCuentaRenumeraciones.Text = ""
            txtNumeroCuentaCTS.Text = ""

            txtCargo.Text = ""
            txtCargo.Tag = ""

            txtCentroCosto.Text = ""
            txtCentroCosto.Tag = ""

            txtCodigo.Text = ""
            txtCodigo.Tag = ""

            txtCussp.Text = ""
            txtCussp.Tag = ""

            txtDobleTributacion.Text = ""
            txtDobleTributacion.Tag = ""

            txtNivelEducacion.Text = ""
            txtNivelEducacion.Tag = ""

            txtObservaciones.Text = ""
            txtObservaciones.Tag = ""

            txtPeriodisidad.Text = ""
            txtPeriodisidad.Tag = ""

            txtPersona.Text = ""
            txtPersona.Tag = ""

            txtRegimenLaboral.Text = ""
            txtRegimenLaboral.Tag = ""

            txtRegimenPensionario.Text = ""
            txtRegimenPensionario.Tag = ""

            txtSituacionEspecial.Text = ""
            txtSituacionEspecial.Tag = ""

            txtSituacionTrabajador.Text = ""
            txtSituacionTrabajador.Tag = ""

            txtTipoContrato.Text = ""
            txtTipoContrato.Tag = ""

            txtTipoTrabajador.Text = ""
            txtTipoTrabajador.Tag = ""
            chkAsignacionFaniliar.Checked = False
            chkestaEnPLanillas.Checked = False
            chkEsPDT.Checked = False
            dataCronograma.Rows.Clear()
            dataPeriodoLaboral.Rows.Clear()
            dgvHorarioTrabajo.Rows.Clear()
            cboSexo.SelectedIndex = 0
            txtCentroRiesgo.Tag = Nothing
            txtCentroRiesgo.Text = Nothing
            chkRentaQuinta.Checked = False
            chkTareoPll.Checked = False

            txtDni.Text = Nothing
            PictureImagen.Image = Nothing

            dateFechaCese.Text = String.Empty
        End Sub

        Private Function validarDetalle()

            Dim result As Boolean = True
            Dim x As Integer = 0

            Try
                While (dataCronograma.Rows.Count > x)
                    With dataCronograma.Rows(x)
                        If (Not IsDate(.Cells("crv_FechaInicio").Value) OrElse Not IsDate(.Cells("crv_FechaFin").Value)) Then
                            result = False
                        End If
                    End With
                    x += 1
                End While
            Catch ex As Exception
                result = False
            End Try

            Return result

        End Function


        Private Function validarDetallePeriodoLaboral()

            Dim result As Boolean = True
            Dim x As Integer = 0
            Dim countPeriodoActivo As Integer = 0
            Dim countLiquidacionActiva As Integer = 0

            Try
                While (dataPeriodoLaboral.Rows.Count > x)
                    With dataPeriodoLaboral.Rows(x)
                        If (Not IsDate(.Cells(1).Value) OrElse Not IsDate(.Cells(2).Value)) Then
                            result = False
                            Exit While
                        End If
                        If (CBool(.Cells(4).Value)) Then
                            countPeriodoActivo += 1
                        End If
                        If (CBool(.Cells(5).Value)) Then
                            countLiquidacionActiva += 1
                        End If

                    End With
                    x += 1
                End While
            Catch ex As Exception
                result = False
            End Try

            If (countLiquidacionActiva >= 2 OrElse countPeriodoActivo >= 2) Then
                result = False
            End If

            Return result

        End Function

        Sub cargar(ByVal id As String)

            Dim query As String
            limpiar()

            oDatosLaborales = BCDatosLaborales.DatosLaboralesSeek(id)

            oDatosLaborales.MarkAsModified()
            '-----------------------------------

            query = Me.BCDatosLaborales.DatosLaboralesDetalleQuery(id, Nothing, Nothing)

            If (query <> Nothing) Then
                Dim ds As New DataSet

                Dim rea As New StringReader(query)
                If (query <> "") Then

                    ds.ReadXml(rea)
                    txtPersona.Tag = oDatosLaborales.per_Id
                    txtDni.Text = ds.Tables(0).Rows(0).Item("Dni").ToString
                    txtPersona.Text = ds.Tables(0).Rows(0).Item("Nombre").ToString
                    txtDireccion.Text = ds.Tables(0).Rows(0).Item("DIR_DESCRIPCION").ToString
                    txtDistrito.Text = ds.Tables(0).Rows(0).Item("DIS_DESCRIPCION").ToString
                    txtCodigo.Text = oDatosLaborales.dal_CodigoTrabajador
                    txtAreaTrabajo.Tag = oDatosLaborales.art_AreaTrab_Id
                    txtAreaTrabajo.Text = ds.Tables(0).Rows(0).Item("tis_Descripcion").ToString
                    txtRegimenLaboral.Tag = oDatosLaborales.rel_RegLaboral_Id
                    txtRegimenLaboral.Text = ds.Tables(0).Rows(0).Item("rel_Descripcioren").ToString
                    txtAreaTrabajo.Tag = oDatosLaborales.art_AreaTrab_Id
                    txtAreaTrabajo.Text = ds.Tables(0).Rows(0).Item("art_Descripcion").ToString
                    txtNivelEducacion.Tag = oDatosLaborales.nie_NiveEduc_Id
                    txtNivelEducacion.Text = ds.Tables(0).Rows(0).Item("nie_Descipcion").ToString
                    txtSituacionTrabajador.Tag = oDatosLaborales.sit_SituaTrab_Id
                    txtSituacionTrabajador.Text = ds.Tables(0).Rows(0).Item("sit_Descripcion").ToString
                    txtSituacionEspecial.Tag = oDatosLaborales.set_SituEspe_Id
                    txtSituacionEspecial.Text = ds.Tables(0).Rows(0).Item("set_Descripcion").ToString
                    txtPeriodisidad.Tag = oDatosLaborales.pec_Periodisidad_Id
                    txtPeriodisidad.Text = ds.Tables(0).Rows(0).Item("pec_Descripcion").ToString
                    txtDobleTributacion.Tag = oDatosLaborales.cod_DobleTribu_Id
                    txtDobleTributacion.Text = ds.Tables(0).Rows(0).Item("cod_Descripcion").ToString
                    txtCentroCosto.Tag = oDatosLaborales.cco_Id
                    txtCentroCosto.Text = ds.Tables(0).Rows(0).Item("CCO_DESCRIPCION").ToString
                    txtTipoTrabajador.Tag = oDatosLaborales.tit_TipoTrab_Id
                    txtTipoTrabajador.Text = ds.Tables(0).Rows(0).Item("tit_Descripcion")
                    txtRegimenPensionario.Tag = oDatosLaborales.rep_RegiPension_id
                    txtRegimenPensionario.Text = ds.Tables(0).Rows(0).Item("rep_Descripcion").ToString
                    cboSexo.SelectedIndex = oDatosLaborales.dal_Sexo
                    dateFechaNacimiento.Value = oDatosLaborales.dal_FechaNacimiento
                    dateFechaInscripReg.Value = oDatosLaborales.dal_FechaInscripcionRegimen
                    txtCussp.Text = oDatosLaborales.dal_Cuspp
                    txtAutoGeneradoEssalud.Text = oDatosLaborales.dal_CodigoGeneradoEssalud
                    txtNumeroCuentaRenumeraciones.Text = oDatosLaborales.dal_NumeroCuentabancoRenumeracion
                    txtNumeroCuentaCTS.Text = oDatosLaborales.dal_NumeroCuentaBancoCTS
                    txtObservaciones.Text = oDatosLaborales.dal_Observaciones
                    chkAsignacionFaniliar.Checked = oDatosLaborales.dal_EsAsignacionFamiliar

                    txtBancoRenumeracion.Tag = oDatosLaborales.ccc_IdCuentaCorrienteRenumeracion
                    txtBancoRenumeracion.Text = ds.Tables(0).Rows(0).Item("bancoRenumeracion").ToString
                    txtBancoCTS.Tag = oDatosLaborales.ccc_IdCuentaCorrienteCTs
                    txtBancoCTS.Text = ds.Tables(0).Rows(0).Item("bancoRenumCTS").ToString
                    txtTipoContrato.Tag = oDatosLaborales.tic_TipoCont_Id
                    txtTipoContrato.Text = ds.Tables(0).Rows(0).Item("tico_Descripcion").ToString
                    chkestaEnPLanillas.Checked = oDatosLaborales.dal_EsTrabajadorPlanillas
                    chkEsPDT.Checked = oDatosLaborales.dal_EsExportadoPDT


                    If (IsDBNull(oDatosLaborales.dal_HoraRrefrigerio)) Then
                        txtHoraRefregerio.Text = "0.00"
                    Else

                        txtHoraRefregerio.Text = oDatosLaborales.dal_HoraRrefrigerio
                    End If


                    If (IsDBNull(oDatosLaborales.dal_HoraMes)) Then
                        txtHorasMes.Text = "0.00"
                    Else
                        txtHorasMes.Text = oDatosLaborales.dal_HoraMes
                    End If


                    If (IsDBNull(oDatosLaborales.dal_HoraFijaExtra)) Then
                        txtHorasMes.Text = "0.00"
                    Else
                        txtHorasFijas.Text = oDatosLaborales.dal_HoraFijaExtra
                    End If


                    txtCargo.Tag = oDatosLaborales.tis_TipCargo_Id
                    txtCargo.Text = ds.Tables(0).Rows(0).Item("tis_Descripcion").ToString

                    chkRentaQuinta.Checked = oDatosLaborales.dal_AfectoQuinta

                    dateFechaIngreso.Value = oDatosLaborales.dal_FechaIngreso

                    chkTareoPll.Checked = IIf(IsDBNull(oDatosLaborales.ttr_DestajoTrabajadorPll), False, oDatosLaborales.ttr_DestajoTrabajadorPll)

                    Try
                        dateFechaCese.Text = oDatosLaborales.dal_FechaCese

                    Catch ex As Exception

                    End Try

                    '---imAGEN
                    Try
                        Dim stmBLOBData As New MemoryStream(oDatosLaborales.dal_Imagen)
                        PictureImagen.Image = Image.FromStream(stmBLOBData)

                    Catch ex As Exception

                    End Try
                    Try
                        cboEstadoCivil.SelectedValue = oDatosLaborales.dal_EstadoCivil

                    Catch ex As Exception
                        cboEstadoCivil.SelectedValue = "01"
                    End Try

                    Try
                        txtCentroRiesgo.Tag = oDatosLaborales.cer_ID
                        txtCentroRiesgo.Text = oDatosLaborales.CentroRiesgo.cer_Descripcion

                    Catch ex As Exception
                        txtCentroRiesgo.Tag = Nothing
                        txtCentroRiesgo.Text = Nothing
                    End Try

                    ' vacaciones
                    For Each mItem In oDatosLaborales.CronogramaVacaciones
                        Dim nRow As New DataGridViewRow
                        dataCronograma.Rows.Add(nRow)


                        dataCronograma.Rows(dataCronograma.Rows.Count - 1).Cells("crv_ItemCroVaca").Value = mItem.crv_ItemCroVaca
                        dataCronograma.Rows(dataCronograma.Rows.Count - 1).Cells("crv_ItemCroVaca").Tag = mItem

                        dataCronograma.Rows(dataCronograma.Rows.Count - 1).Cells("crv_FechaInicio").Value = mItem.crv_FechaInicio
                        dataCronograma.Rows(dataCronograma.Rows.Count - 1).Cells("crv_FechaFin").Value = mItem.crv_FechaFin
                        dataCronograma.Rows(dataCronograma.Rows.Count - 1).Cells("crv_Observaciones").Value = mItem.crv_Observaciones
                        dataCronograma.Rows(dataCronograma.Rows.Count - 1).Cells("crv_Estado").Value = mItem.crv_Estado
                        dataCronograma.Rows(dataCronograma.Rows.Count - 1).Cells("crv_Periodo").Value = mItem.crv_Periodo
                        Try
                            dataCronograma.Rows(dataCronograma.Rows.Count - 1).Cells("crv_periodoAsignado").Value = mItem.crv_periodoAsignado

                        Catch ex As Exception

                        End Try


                        '------
                        dataCronograma.Rows(dataCronograma.Rows.Count - 1).Cells("tdo_Id").Tag = mItem.tdo_Id
                        dataCronograma.Rows(dataCronograma.Rows.Count - 1).Cells("pla_SeriePlani").Value = mItem.pla_SeriePlani
                        dataCronograma.Rows(dataCronograma.Rows.Count - 1).Cells("pla_Numero").Value = mItem.pla_Numero
                        Try
                            dataCronograma.Rows(dataCronograma.Rows.Count - 1).Cells("Dias").Value = mItem.crv_dias
                            dataCronograma.Rows(dataCronograma.Rows.Count - 1).Cells("Domingo").Value = mItem.crv_Domingos

                        Catch ex As Exception

                        End Try



                    Next

                    ' Horario de Trabajo
                    For Each mItem In oDatosLaborales.DatosLaboralesHorario
                        Dim nRow As New DataGridViewRow
                        dgvHorarioTrabajo.Rows.Add(nRow)


                        dgvHorarioTrabajo.Rows(dgvHorarioTrabajo.Rows.Count - 1).Cells("dah_item").Value = mItem.dah_item
                        dgvHorarioTrabajo.Rows(dgvHorarioTrabajo.Rows.Count - 1).Cells("dah_item").Tag = mItem

                        dgvHorarioTrabajo.Rows(dgvHorarioTrabajo.Rows.Count - 1).Cells("dah_Ingreso").Value = mItem.dah_Ingreso
                        dgvHorarioTrabajo.Rows(dgvHorarioTrabajo.Rows.Count - 1).Cells("dah_Salida").Value = mItem.dah_Salida
                        dgvHorarioTrabajo.Rows(dgvHorarioTrabajo.Rows.Count - 1).Cells("dah_estado").Value = mItem.dah_estado
                        dgvHorarioTrabajo.Rows(dgvHorarioTrabajo.Rows.Count - 1).Cells("dah_Observaciones").Value = mItem.dah_Observaciones

                        dgvHorarioTrabajo.Rows(dgvHorarioTrabajo.Rows.Count - 1).Cells("Dia").Value = WeekdayName(CInt(mItem.dah_item))

                    Next


                    'periodo laboral
                    For Each mItem In oDatosLaborales.PeriodoLaboral
                        Dim nRow As New DataGridViewRow
                        dataPeriodoLaboral.Rows.Add(nRow)


                        dataPeriodoLaboral.Rows(dataPeriodoLaboral.Rows.Count - 1).Cells(0).Value = mItem.ItemPeriodoLaboral
                        dataPeriodoLaboral.Rows(dataPeriodoLaboral.Rows.Count - 1).Cells(0).Tag = mItem

                        dataPeriodoLaboral.Rows(dataPeriodoLaboral.Rows.Count - 1).Cells(1).Value = mItem.pel_FechaInicio
                        dataPeriodoLaboral.Rows(dataPeriodoLaboral.Rows.Count - 1).Cells(2).Value = mItem.pel_FechaFin
                        dataPeriodoLaboral.Rows(dataPeriodoLaboral.Rows.Count - 1).Cells(3).Value = mItem.pel_Apuntes
                        dataPeriodoLaboral.Rows(dataPeriodoLaboral.Rows.Count - 1).Cells(4).Value = (mItem.pel_EsPeriodoActivo)
                        dataPeriodoLaboral.Rows(dataPeriodoLaboral.Rows.Count - 1).Cells(5).Value = (mItem.pel_EsPeriodoLiquidacion)


                        If Not (mItem.tic_TipoCont_Id Is Nothing) Then
                            dataPeriodoLaboral.Rows(dataPeriodoLaboral.Rows.Count - 1).Cells(6).Tag = mItem.tic_TipoCont_Id
                            dataPeriodoLaboral.Rows(dataPeriodoLaboral.Rows.Count - 1).Cells(7).Value = mItem.TiposContratos.tico_Descripcion
                        End If

                    Next


                End If
            End If
            '-----------------------------------
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.DatosLaborales)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    cargar(.Cells("ID").Value)
                    menuBuscar()
                End With
            End If
            frm.Dispose()
            Panel1.Enabled = False
        End Sub
        Public Overrides Sub OnManGuardar()
            Try
                Dim sCorrelativo As String = ""
                If (validar()) Then
                    btnPersona.Focus()

                    oDatosLaborales.tis_TipCargo_Id = IIf(txtCargo.Tag = "", Nothing, txtCargo.Tag)
                    oDatosLaborales.rel_RegLaboral_Id = IIf(txtRegimenLaboral.Tag = "", Nothing, txtRegimenLaboral.Tag)
                    oDatosLaborales.art_AreaTrab_Id = IIf(txtAreaTrabajo.Tag = "", Nothing, txtAreaTrabajo.Tag)
                    oDatosLaborales.nie_NiveEduc_Id = IIf(txtNivelEducacion.Tag = "", Nothing, txtNivelEducacion.Tag)
                    oDatosLaborales.sit_SituaTrab_Id = IIf(txtSituacionTrabajador.Tag = "", Nothing, txtSituacionTrabajador.Tag)
                    oDatosLaborales.set_SituEspe_Id = IIf(txtSituacionEspecial.Tag = "", Nothing, txtSituacionEspecial.Tag)
                    oDatosLaborales.pec_Periodisidad_Id = IIf(txtPeriodisidad.Tag = "", Nothing, txtPeriodisidad.Tag)
                    oDatosLaborales.cod_DobleTribu_Id = IIf(txtDobleTributacion.Tag = "", Nothing, txtDobleTributacion.Tag)
                    oDatosLaborales.cco_Id = IIf(txtCentroCosto.Tag = "", Nothing, txtCentroCosto.Tag)
                    oDatosLaborales.tit_TipoTrab_Id = IIf(txtTipoTrabajador.Tag = "", Nothing, txtTipoTrabajador.Tag)
                    oDatosLaborales.rep_RegiPension_id = IIf(txtRegimenPensionario.Tag = "", Nothing, txtRegimenPensionario.Tag)
                    oDatosLaborales.dal_Sexo = cboSexo.SelectedIndex
                    oDatosLaborales.dal_FechaNacimiento = dateFechaNacimiento.Text
                    oDatosLaborales.dal_FechaInscripcionRegimen = dateFechaInscripReg.Text
                    oDatosLaborales.dal_Cuspp = txtCussp.Text
                    oDatosLaborales.dal_CodigoGeneradoEssalud = txtAutoGeneradoEssalud.Text
                    oDatosLaborales.dal_NumeroCuentabancoRenumeracion = txtNumeroCuentaRenumeraciones.Text
                    oDatosLaborales.dal_NumeroCuentaBancoCTS = txtNumeroCuentaCTS.Text
                    oDatosLaborales.dal_EsAsignacionFamiliar = chkAsignacionFaniliar.Checked
                    oDatosLaborales.per_Id = txtPersona.Tag
                    oDatosLaborales.dal_Observaciones = txtObservaciones.Text
                    oDatosLaborales.ccc_IdCuentaCorrienteRenumeracion = IIf(txtBancoRenumeracion.Tag = "", Nothing, txtBancoRenumeracion.Tag)
                    oDatosLaborales.ccc_IdCuentaCorrienteCTs = IIf(txtBancoCTS.Tag = "", Nothing, txtBancoCTS.Tag)
                    oDatosLaborales.tic_TipoCont_Id = IIf(txtTipoContrato.Tag = "", Nothing, txtTipoContrato.Tag)
                    oDatosLaborales.dal_EsTrabajadorPlanillas = chkestaEnPLanillas.Checked
                    oDatosLaborales.dal_CodigoTrabajador = txtCodigo.Text
                    oDatosLaborales.dal_EsExportadoPDT = chkEsPDT.Checked
                    oDatosLaborales.Usu_Id = SessionService.UserId
                    oDatosLaborales.dal_FecGrab = CDate(Today)
                    oDatosLaborales.dal_FechaIngreso = CDate(dateFechaIngreso.Text)
                    oDatosLaborales.ttr_DestajoTrabajadorPll = chkTareoPll.Checked

                    oDatosLaborales.dal_HoraRrefrigerio = CDec(Val(txtHoraRefregerio.Text))
                    oDatosLaborales.dal_HoraMes = CDec(Val(txtHorasMes.Text))
                    oDatosLaborales.dal_HoraFijaExtra = CDec(Val(txtHorasFijas.Text))


                    If (dateFechaCese.Text.Trim.Length >= 9) Then
                        oDatosLaborales.dal_FechaCese = IIf(dateFechaCese.Text.Trim.Length < 10, Nothing, CDate(dateFechaCese.Text))
                    Else
                        oDatosLaborales.dal_FechaCese = Nothing
                    End If

                    oDatosLaborales.dal_EstadoCivil = cboEstadoCivil.SelectedValue
                    oDatosLaborales.dal_AfectoQuinta = chkRentaQuinta.Checked

                    If (txtCentroRiesgo.Tag <> "") Then
                        oDatosLaborales.cer_ID = txtCentroRiesgo.Tag
                    Else
                        oDatosLaborales.cer_ID = Nothing
                    End If
                    '-------------------imagen
                    Try
                        Dim ms As New MemoryStream
                        PictureImagen.Image.Save(ms, PictureImagen.Image.RawFormat)
                        Dim arrImage() As Byte = ms.GetBuffer
                        oDatosLaborales.dal_Imagen = arrImage

                    Catch ex As Exception
                        oDatosLaborales.dal_Imagen = Nothing
                    End Try

                    '----------------------

                    ' cronograma de vacaciones
                    For Each mDetalle As DataGridViewRow In dataCronograma.Rows
                        If Not mDetalle.Cells("crv_ItemCroVaca").Value Is Nothing Then
                            With CType(mDetalle.Cells("crv_ItemCroVaca").Tag, BE.CronogramaVacaciones)

                                .crv_Estado = mDetalle.Cells("crv_Estado").Value()
                                .crv_FECGRAB = Now
                                .crv_FechaFin = mDetalle.Cells("crv_FechaFin").Value
                                .crv_FechaInicio = mDetalle.Cells("crv_FechaInicio").Value
                                .crv_ItemCroVaca = mDetalle.Cells("crv_ItemCroVaca").Value
                                .crv_Observaciones = mDetalle.Cells("crv_Observaciones").Value
                                .crv_Periodo = mDetalle.Cells("crv_Periodo").Value
                                .tdo_Id = mDetalle.Cells("tdo_Id").Value
                                .pla_SeriePlani = mDetalle.Cells("pla_SeriePlani").Value
                                .pla_Numero = mDetalle.Cells("pla_Numero").Value
                                .crv_dias = CInt(Val(mDetalle.Cells("Dias").Value))
                                .crv_Domingos = CInt(Val(mDetalle.Cells("Domingo").Value))
                                .crv_periodoAsignado = mDetalle.Cells("crv_periodoAsignado").Value


                                .per_Id = txtPersona.Tag
                                .Usu_Id = SessionService.UserId

                                .MarkAsModified()
                            End With
                        ElseIf mDetalle.Cells("crv_ItemCroVaca").Value Is Nothing Then
                            Dim nOSD As New BE.CronogramaVacaciones
                            With nOSD

                                .crv_Estado = mDetalle.Cells("crv_Estado").Value()
                                .crv_FECGRAB = Now
                                .crv_FechaFin = mDetalle.Cells("crv_FechaFin").Value
                                .crv_FechaInicio = mDetalle.Cells("crv_FechaInicio").Value
                                .crv_ItemCroVaca = mDetalle.Cells("crv_ItemCroVaca").Value
                                .crv_Observaciones = mDetalle.Cells("crv_Observaciones").Value
                                .crv_Periodo = mDetalle.Cells("crv_Periodo").Value
                                .tdo_Id = mDetalle.Cells("tdo_Id").Value
                                .pla_SeriePlani = mDetalle.Cells("pla_SeriePlani").Value
                                .pla_Numero = mDetalle.Cells("pla_Numero").Value
                                .crv_dias = CInt(Val(mDetalle.Cells("Dias").Value))
                                .crv_Domingos = CInt(Val(mDetalle.Cells("Domingo").Value))
                                .crv_periodoAsignado = mDetalle.Cells("crv_periodoAsignado").Value

                                .per_Id = txtPersona.Tag

                                .Usu_Id = SessionService.UserId
                                .Usu_Id = SessionService.UserId

                                .MarkAsAdded()
                            End With
                            oDatosLaborales.CronogramaVacaciones.Add(nOSD)
                        End If
                    Next

                    'horario de trabajo
                    For Each mDetalle As DataGridViewRow In dgvHorarioTrabajo.Rows
                        If Not mDetalle.Cells("dah_item").Tag Is Nothing Then
                            With CType(mDetalle.Cells("dah_item").Tag, BE.DatosLaboralesHorario)

                                .dah_item = mDetalle.Cells("dah_item").Value()

                                If mDetalle.Cells("dah_Ingreso").Value IsNot Nothing Then .dah_Ingreso = New TimeSpan(mDetalle.Cells("dah_Ingreso").Value.ToString().Substring(0, 2), mDetalle.Cells("dah_Ingreso").Value.ToString().Substring(3, 2), 0)
                                If mDetalle.Cells("dah_Salida").Value IsNot Nothing Then .dah_Salida = New TimeSpan(mDetalle.Cells("dah_Salida").Value.ToString().Substring(0, 2), mDetalle.Cells("dah_Salida").Value.ToString().Substring(3, 2), 0)

                                .dah_Observaciones = mDetalle.Cells("dah_Observaciones").Value
                                .dah_estado = mDetalle.Cells("dah_estado").Value

                                .per_Id = txtPersona.Tag

                                .MarkAsModified()
                            End With
                        ElseIf mDetalle.Cells("dah_item").Tag Is Nothing Then
                            Dim nOSD As New BE.DatosLaboralesHorario
                            With nOSD

                                .dah_item = mDetalle.Cells("dah_item").Value()


                                .dah_Salida = New TimeSpan(mDetalle.Cells("dah_Salida").Value.ToString().Substring(0, 2), mDetalle.Cells("dah_Salida").Value.ToString().Substring(3, 2), 0)

                                .dah_Salida = New TimeSpan(mDetalle.Cells("dah_Salida").Value.ToString().Substring(0, 2), mDetalle.Cells("dah_Salida").Value.ToString().Substring(3, 2), 0)

                                .dah_Observaciones = mDetalle.Cells("dah_Observaciones").Value
                                .dah_estado = mDetalle.Cells("dah_estado").Value

                                .per_Id = txtPersona.Tag

                                .MarkAsAdded()
                            End With

                            oDatosLaborales.DatosLaboralesHorario.Add(nOSD)

                        End If
                    Next


                    ' Periodos laborales
                    For Each mDetalle As DataGridViewRow In dataPeriodoLaboral.Rows
                        If Not mDetalle.Cells("Item").Value Is Nothing Then
                            With CType(mDetalle.Cells("Item").Tag, BE.PeriodoLaboral)

                                '.crv_Estado = mDetalle.Cells("crv_Estado").Value()

                                .ItemPeriodoLaboral = mDetalle.Cells(0).Value
                                .pel_FechaInicio = CDate(mDetalle.Cells(1).Value)
                                .pel_FechaFin = CDate(mDetalle.Cells(2).Value)
                                .pel_Apuntes = mDetalle.Cells(3).Value
                                .pel_EsPeriodoActivo = mDetalle.Cells(4).Value
                                .pel_EsPeriodoLiquidacion = mDetalle.Cells(5).Value
                                .tic_TipoCont_Id = mDetalle.Cells(6).Tag

                                .pel_FECGRAB = Now
                                .per_Id = txtPersona.Tag

                                .Usu_Id = SessionService.UserId

                                .MarkAsModified()

                            End With
                        ElseIf mDetalle.Cells("Item").Value Is Nothing Then
                            Dim nOSD As New BE.PeriodoLaboral
                            With nOSD

                                .ItemPeriodoLaboral = Nothing
                                .pel_FechaInicio = CDate(mDetalle.Cells(1).Value)
                                .pel_FechaFin = CDate(mDetalle.Cells(2).Value)
                                .pel_Apuntes = mDetalle.Cells(3).Value
                                .pel_EsPeriodoActivo = mDetalle.Cells(4).Value
                                .pel_EsPeriodoLiquidacion = mDetalle.Cells(5).Value
                                .tic_TipoCont_Id = mDetalle.Cells(6).Tag


                                .pel_FECGRAB = Now
                                .per_Id = txtPersona.Tag

                                .Usu_Id = SessionService.UserId

                                .MarkAsAdded()
                            End With
                            oDatosLaborales.PeriodoLaboral.Add(nOSD)

                        End If
                    Next

                    BCDatosLaborales.Mantenance(oDatosLaborales)
                    MsgBox("Dato Guardados")
                    menuInicio()
                    Panel1.Enabled = False
                    limpiar()

                    'fin de verificar
                End If

            Catch ex As Exception
                Try
                    MsgBox(ex.InnerException.Message)
                Catch exe As Exception
                    MsgBox(ex.Message)
                End Try

                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                'If (rethrow) Then
                '    Throw
                'End If
            End Try

        End Sub
        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oDatosLaborales = New DatosLaborales
            oDatosLaborales.MarkAsAdded()

            Panel1.Enabled = True
            Dim x As Integer = 1

            dgvHorarioTrabajo.Rows.Clear()

            While (x <= 7)
                Dim nRow As New DataGridViewRow

                dgvHorarioTrabajo.Rows.Add(nRow)

                dgvHorarioTrabajo.Rows(dgvHorarioTrabajo.Rows.Count - 1).Cells("dah_item").Value = "0" & x.ToString
                dgvHorarioTrabajo.Rows(dgvHorarioTrabajo.Rows.Count - 1).Cells("dah_item").Tag = Nothing
                dgvHorarioTrabajo.Rows(dgvHorarioTrabajo.Rows.Count - 1).Cells("dah_Ingreso").Value = "08:00:00"
                dgvHorarioTrabajo.Rows(dgvHorarioTrabajo.Rows.Count - 1).Cells("dah_Salida").Value = "18:00:00"
                dgvHorarioTrabajo.Rows(dgvHorarioTrabajo.Rows.Count - 1).Cells("dah_estado").Value = False
                dgvHorarioTrabajo.Rows(dgvHorarioTrabajo.Rows.Count - 1).Cells("dah_Observaciones").Value = ""
                dgvHorarioTrabajo.Rows(dgvHorarioTrabajo.Rows.Count - 1).Cells("Dia").Value = WeekdayName(CInt(x))

                x += 1

            End While





        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub



        Public Overrides Sub OnManEliminar()
            oDatosLaborales.MarkAsDeleted()
            oDatosLaborales.per_Id = txtPersona.Tag
            oDatosLaborales.Usu_Id = SessionService.UserId
            oDatosLaborales.dal_FECGRAB = Now
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCDatosLaborales.Mantenance(oDatosLaborales)
                    MsgBox("Datos Eliminados")
                    Panel1.Enabled = False
                    limpiar()
                End If
            Catch ex As Exception

                MsgBox(ex.Message)

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

        Private Sub frmDatosLaborales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not (esLlamado) Then
                menuInicio()
                esLlamado = False
            End If


            Panel1.Enabled = False

            EstadoCivil()

        End Sub

        Private Sub btnNivelEducacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNivelEducacion.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.NIvelEducacion)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtNivelEducacion.Tag = .Cells(0).Value
                    txtNivelEducacion.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnCentroCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCentroCosto.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CentroCosto)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtCentroCosto.Tag = .Cells(0).Value
                    txtCentroCosto.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnRegimenLaboral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegimenLaboral.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.RegimenLaboral)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtRegimenLaboral.Tag = .Cells(0).Value
                    txtRegimenLaboral.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnRegimenPensionario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegimenPensionario.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.RegimenPensionario)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtRegimenPensionario.Tag = .Cells(0).Value
                    txtRegimenPensionario.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPersona.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.BuscarPersona)

                If (frm.ShowDialog = DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPersona.Tag = .Cells(0).Value
                        txtPersona.Text = .Cells(1).Value
                    End With
                End If
                frm.Dispose()
            Catch ex As Exception

            End Try

        End Sub

        Private Sub btnTipoTrabajador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoTrabajador.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposTrabajador)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtTipoTrabajador.Tag = .Cells(0).Value
                    txtTipoTrabajador.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargo.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposCargos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtCargo.Tag = .Cells(0).Value
                    txtCargo.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnTipoContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoContrato.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposContratos)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtTipoContrato.Tag = .Cells(0).Value
                    txtTipoContrato.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnBancoRenumeracio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBancoRenumeracio.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Bancos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtBancoRenumeracion.Tag = .Cells(0).Value
                    txtBancoRenumeracion.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnCuentaCTS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCuentaCTS.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Bancos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtBancoCTS.Tag = .Cells(0).Value
                    txtBancoCTS.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnSituacionTrabajador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSituacionTrabajador.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.SituacionTrabajador)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtSituacionTrabajador.Tag = .Cells(0).Value
                    txtSituacionTrabajador.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnSituacionEspecial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSituacionEspecial.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.SituacionEspecialTrabajador)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtSituacionEspecial.Tag = .Cells(0).Value
                    txtSituacionEspecial.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnAreaTrabajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAreaTrabajo.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.AreaTrabajos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtAreaTrabajo.Tag = .Cells(0).Value
                    txtAreaTrabajo.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnPeriodisidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodisidad.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Periodisidad)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtPeriodisidad.Tag = .Cells(0).Value
                    txtPeriodisidad.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnDobleTributacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDobleTributacion.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.ConvenioDobleTributacion)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtDobleTributacion.Tag = .Cells(0).Value
                    txtDobleTributacion.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
            If (TabControl1.SelectedIndex >= 3) Then
                HabilitarElementoGrid()
            Else
                DeshabilitarElementoGrid()

            End If
        End Sub

        Public Overrides Sub OnManQuitarFilaGrid()

            If (TabControl1.SelectedIndex = 3) Then
                If (dataCronograma.SelectedRows.Count > 0) Then

                    For Each mDetalle As DataGridViewRow In dataCronograma.SelectedRows
                        If Not mDetalle.Cells("crv_ItemCroVaca").Value Is Nothing Then
                            With CType(mDetalle.Cells("crv_ItemCroVaca").Tag, BE.CronogramaVacaciones)
                                .MarkAsDeleted()
                            End With
                        End If
                    Next

                    dataCronograma.Rows.Remove(dataCronograma.SelectedRows(0))
                Else
                    MsgBox("Seleccione un registro")
                End If
            End If

            If (TabControl1.SelectedIndex = 4) Then
                If (dataCronograma.SelectedRows.Count > 0) Then

                    For Each mDetalle As DataGridViewRow In dataPeriodoLaboral.SelectedRows
                        If Not mDetalle.Cells("Item").Value Is Nothing Then
                            With CType(mDetalle.Cells("Item").Tag, BE.PeriodoLaboral)
                                .MarkAsDeleted()
                            End With
                        End If
                    Next

                    dataPeriodoLaboral.Rows.Remove(dataPeriodoLaboral.SelectedRows(0))
                Else
                    MsgBox("Seleccione un registro")
                End If
            End If

        End Sub
        Public Overrides Sub OnManAgregarFilaGrid()
            If (TabControl1.SelectedIndex = 3) Then
                dataCronograma.Rows.Add()

            End If
            If (TabControl1.SelectedIndex = 4) Then
                dataPeriodoLaboral.Rows.Add()

            End If


        End Sub
        Public Sub EstadoCivil()
            Dim query As String = Nothing

            Dim oDAta As New DataTable


            query = Me.BCDatosLaborales.EstadoCivilXML()



            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    oDAta = ds.Tables(0)
                    cboEstadoCivil.DataSource = oDAta
                    cboEstadoCivil.ValueMember = "Codigo"
                    cboEstadoCivil.DisplayMember = "Descripcion"
                End If
            End If

        End Sub


        Private Sub btnCentroRiesgo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCentroRiesgo.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.CentroRiesgo)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtCentroRiesgo.Tag = .Cells(0).Value
                    txtCentroRiesgo.Text = .Cells(1).Value
                End With
            End If
        End Sub

        Private Sub dataPeriodoLaboral_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataPeriodoLaboral.CellContentClick

            If (e.ColumnIndex = 6) Then

                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.TiposContratos)

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    If (frm.dgbRegistro.SelectedRows.Count > 0) Then
                        With frm.dgbRegistro.CurrentRow
                            dataPeriodoLaboral.Rows(e.RowIndex).Cells(6).Tag = .Cells(0).Value
                            dataPeriodoLaboral.Rows(e.RowIndex).Cells(7).Value = .Cells(1).Value
                        End With
                    Else
                        MsgBox("Seleccione un registro")
                    End If

                End If
                frm.Dispose()
            End If


        End Sub

        Private Sub dataCronograma_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataCronograma.CellContentClick
            Select Case dataCronograma.Columns(e.ColumnIndex).Name

                Case "tdo_Id"

                    Dim frm = Me.ContainerService.Resolve(Of frmBuscarFechaPersona)()
                    frm.inicio(Constants.BuscadoresNames.CronogramaVacaciones)
                    If (frm.ShowDialog = DialogResult.OK) Then
                        With frm.dgbRegistro.CurrentRow
                            dataCronograma.Rows(e.RowIndex).Cells("tdo_Id").Tag = .Cells(0).Value
                            dataCronograma.Rows(e.RowIndex).Cells("pla_SeriePlani").Value = .Cells(1).Value
                            dataCronograma.Rows(e.RowIndex).Cells("pla_Numero").Value = .Cells(2).Value

                        End With
                    End If
            End Select

        End Sub

        Private Sub dataCronograma_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataCronograma.CellEnter
            Try
                dataCronograma.Rows(e.RowIndex).Cells("Dias").Value = DateDiff(DateInterval.Day, dataCronograma.Rows(e.RowIndex).Cells("crv_FechaInicio").Value, dataCronograma.Rows(e.RowIndex).Cells("crv_FechaFin").Value) + 1
                dataCronograma.Rows(e.RowIndex).Cells("Domingo").Value = diasDomingos(e.RowIndex)


            Catch ex As Exception

            End Try


        End Sub

        Private Sub dataCronograma_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dataCronograma.CellValidating
            Try
                dataCronograma.Rows(e.RowIndex).Cells("Dias").Value = DateDiff(DateInterval.Day, dataCronograma.Rows(e.RowIndex).Cells("crv_FechaInicio").Value, dataCronograma.Rows(e.RowIndex).Cells("crv_FechaFin").Value) + 1
                dataCronograma.Rows(e.RowIndex).Cells("Domingo").Value = diasDomingos(e.RowIndex)

            Catch ex As Exception

            End Try
        End Sub
        Private Function diasDomingos(ByVal fila As Integer) As Integer
            Dim dFechaInicio As Date
            Dim dfechaFin As Date
            Dim cuenta As Integer = 0
            dFechaInicio = CDate(dataCronograma.Rows(fila).Cells("crv_FechaInicio").Value)
            dfechaFin = CDate(dataCronograma.Rows(fila).Cells("crv_FechaFin").Value)

            While (dFechaInicio <= dfechaFin)

                If (dFechaInicio.DayOfWeek = DayOfWeek.Sunday) Then
                    cuenta += 1
                End If
                dFechaInicio = dFechaInicio.AddDays(1)

            End While
            Return cuenta
        End Function


        Private Sub btnImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImagen.Click
            Dim abrir As New OpenFileDialog
            With abrir

                .InitialDirectory = ""
                .Filter = "Todos los Archivos|*.*|JPEGs|*.jpg|GIFs|*.gif|Bitmaps|*.bmp"
                .FilterIndex = 2

            End With
            If (abrir.ShowDialog = DialogResult.OK) Then
                Dim dir As String = abrir.FileName
                PictureImagen.Image = New Bitmap(dir)
                With PictureImagen
                    ' .Image = PictureImagen
                    .SizeMode = PictureBoxSizeMode.StretchImage
                    .BorderStyle = BorderStyle.Fixed3D
                End With
            End If
        End Sub

        Private Sub btnBorrarImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarImagen.Click

            PictureImagen.Image = Nothing

        End Sub
    End Class
End Namespace