
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views

    Public Class frmTrabajadorHoras

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property BCDatosTrabajadorJudicial As Ladisac.BL.IBCDatosTrabajadorJudicial

        <Dependency()> _
        Public Property BCTrabajadorHoras As Ladisac.BL.IBCTrabajadorHoras

        <Dependency()> _
        Public Property BCTiposTrabajador As Ladisac.BL.IBCTiposTrabajador

        <Dependency()> _
        Public Property BCGrupoTrabajo As Ladisac.BL.IBCGrupoTrabajo

        <Dependency()> _
        Public Property BCGrupoMantenimiento As Ladisac.BL.IBCGrupoMantenimiento

        <Dependency()> _
        Public Property BCGrupoEmpleado As Ladisac.BL.IBCGrupoEmpleado

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oTrabajadorHoras As New BE.TrabajadorHoras

        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtObservaciones.Text.Trim = "") Then
                ErrorProvider1.SetError(txtObservaciones, "Observaciones")
                result = False
            Else
                ErrorProvider1.SetError(txtObservaciones, Nothing)
            End If

            If (Not validarCeldas()) Then
                result = False
            End If

            Return result

        End Function
        Private Sub limpiar()

            txtNumero.Text = ""

            chkBloquear.Checked = False
            chkEsdeExcel.Checked = False
            chkEsdeProduccion.Checked = False

            dgvDetalle.Rows.Clear()
            dgvHoraXTrabajador.DataSource = Nothing


        End Sub
        Private Sub tipoTrabajador()

            Try
                Dim result = Me.BCTiposTrabajador.TiposTrabajadorQuery(Nothing, Nothing)

                Dim ds As New DataSet
                Dim sr As New StringReader(result)

                ds.ReadXml(sr)

                Dim rows As DataRow()

                Dim dtNew As DataTable

                ' copy table structure
                dtNew = ds.Tables(0).Clone()

                ' sort and filter data
                rows = ds.Tables(0).Select(" tit_TipoTrab_Id in('001','002')")

                ' fill dtNew with selected rows

                For Each dr As DataRow In rows
                    dtNew.ImportRow(dr)

                Next

                Me.cboTipoTrabajador.DataSource = dtNew
                Me.cboTipoTrabajador.DisplayMember = "tit_Descripcion"
                Me.cboTipoTrabajador.ValueMember = "tit_TipoTrab_Id"

            Catch ex As Exception
                MsgBox("No se Pudo cargar los datos")
            End Try

        End Sub
        Private Sub DetalleHoraXTrabajador(ByVal idpersona As String)

            Try

                Dim result As String = ""
                If (chkEsdeProduccion.Checked) Then
                    result = Me.BCGrupoTrabajo.DetalleHorasXTrabajador(CDate(dateDesde.Text), CDate(dateHasta.Text), idpersona)
                End If

                If (chkImportarMantenimiento.Checked) Then
                    result = Me.BCGrupoMantenimiento.SPDetalleHorasXTrabajadorMantenimiento(CDate(dateDesde.Text), CDate(dateHasta.Text), idpersona)
                End If

                If (chkImportarEmpleado.Checked) Then
                    result = Me.BCGrupoEmpleado.SPDetalleHorasXTrabajadorEmpleado(CDate(dateDesde.Text), CDate(dateHasta.Text), idpersona)
                End If

                Dim ds As New DataSet
                Dim sr As New StringReader(result)
                ds.ReadXml(sr)
                dgvHoraXTrabajador.DataSource = ds.Tables(0)

                If (dgvHoraXTrabajador.Rows.Count > 0) Then
                    dgvHoraXTrabajador.Columns(0).Visible = False
                End If

                Try
                    '--------------------------------
                    dgvHoraXTrabajador.Columns("d0").Visible = False
                    dgvHoraXTrabajador.Columns("d1").Visible = False
                    dgvHoraXTrabajador.Columns("d2").Visible = False
                    dgvHoraXTrabajador.Columns("d3").Visible = False
                    dgvHoraXTrabajador.Columns("d4").Visible = False
                    dgvHoraXTrabajador.Columns("d5").Visible = False
                    dgvHoraXTrabajador.Columns("d6").Visible = False
                    dgvHoraXTrabajador.Columns("Tipo").Visible = True
                    ponerColor()
                    '-------------------------------------------
                Catch ex As Exception

                End Try



            Catch ex As Exception
                dgvHoraXTrabajador.DataSource = Nothing
            End Try
        End Sub


        Private Sub ponerColor()

            Dim x As Integer

            While (dgvHoraXTrabajador.RowCount > x)

                With dgvHoraXTrabajador.Rows(x)
                    Try
                        If (.Cells("d0").Value > 0) Then
                            dgvHoraXTrabajador.Rows(x).Cells(1).Style.BackColor = Drawing.Color.Red

                        End If
                        If (.Cells("d1").Value > 0) Then
                            dgvHoraXTrabajador.Rows(x).Cells(2).Style.BackColor = Drawing.Color.Red

                        End If
                        If (.Cells("d2").Value > 0) Then
                            dgvHoraXTrabajador.Rows(x).Cells(3).Style.BackColor = Drawing.Color.Red

                        End If
                        If (.Cells("d3").Value > 0) Then
                            dgvHoraXTrabajador.Rows(x).Cells(4).Style.BackColor = Drawing.Color.Red

                        End If
                        If (.Cells("d4").Value > 0) Then
                            dgvHoraXTrabajador.Rows(x).Cells(5).Style.BackColor = Drawing.Color.Red

                        End If
                        If (.Cells("d5").Value > 0) Then
                            dgvDetalle.Rows(x).Cells(6).Style.BackColor = Drawing.Color.Red

                        End If
                        If (.Cells("d6").Value > 0) Then
                            dgvHoraXTrabajador.Rows(x).Cells(7).Style.BackColor = Drawing.Color.Red

                        End If
                    Catch ex As Exception

                    End Try

                End With


                x += 1
            End While

        End Sub

        Sub cargar(ByVal tipo As String, ByVal numero As String)
            limpiar()
            oTrabajadorHoras = BCTrabajadorHoras.TrabajadorHorasSeek(tipo ,numero)
            oTrabajadorHoras.MarkAsModified()

            txtNumero.Text = oTrabajadorHoras.trh_Numero
            txtObservaciones.Text = oTrabajadorHoras.trh_descripcion
            cboTipoTrabajador.SelectedValue = oTrabajadorHoras.tit_TipoTrab_Id
            dateDesde.Value = oTrabajadorHoras.trh_FechaDesde
            dateHasta.Value = oTrabajadorHoras.trh_FechaHasta
            chkBloquear.Checked = oTrabajadorHoras.trh_BloquearFechas

            chkEsdeExcel.Checked = oTrabajadorHoras.trh_EsImportadoExcel
            chkEsdeProduccion.Checked = oTrabajadorHoras.trh_EsImportadoProduc

            Dim oTAble As New DataTable
            Dim x As Integer = 0
            oTAble = BCTrabajadorHoras.SPDetalleTrabajadorHorasMaintenanceSelect(oTrabajadorHoras.tit_TipoTrab_Id, oTrabajadorHoras.trh_Numero)

            'For Each mItem In oTrabajadorHoras.DetalleTrabajadorHoras
            While x < oTAble.Rows.Count

                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)


                Dim oNewDetalleGrupo As New BE.DetalleTrabajadorHoras
                'oNewDetalleGrupo.prd_Periodo_id = .Item("prd_Periodo_id")
                With oTAble.Rows(x)



                    oNewDetalleGrupo.trh_Item = .Item("trh_Item")
                    oNewDetalleGrupo.per_Id = .Item("per_Id")

                    ' oNewDetalleGrupo.Persona = .Item("Nombre")
                    oNewDetalleGrupo.trh_HoraSimpProduccion = .Item("trh_HoraSimpProduccion")
                    oNewDetalleGrupo.trh_HoraDobleProduccion = .Item("trh_HoraDobleProduccion")
                    oNewDetalleGrupo.trh_HoraSimCambios = .Item("trh_HoraSimCambios")
                    oNewDetalleGrupo.trh_HoraDobCambios = .Item("trh_HoraDobCambios")
                    oNewDetalleGrupo.trh_HoraSimReparoHora = .Item("trh_HoraSimReparoHora")
                    oNewDetalleGrupo.trh_HoraSimReparoDia = .Item("trh_HoraSimReparoDia")
                    oNewDetalleGrupo.trh_horaDobReparo = .Item("trh_horaDobReparo")
                    oNewDetalleGrupo.trh_HoraEssalud = .Item("trh_HoraEssalud")
                    oNewDetalleGrupo.trh_HoraSimTotal = .Item("trh_HoraSimTotal")
                    oNewDetalleGrupo.trh_HoraDobTotal = .Item("trh_HoraDobTotal")
                    oNewDetalleGrupo.trh_DiasTrabajador = .Item("trh_DiasTrabajador")
                    oNewDetalleGrupo.trh_DiasTrabajadorXHora = .Item("trh_DiasTrabajadorXHora")
                    oNewDetalleGrupo.trh_observacion1 = .Item("trh_observacion1")
                    oNewDetalleGrupo.trh_Observacion2 = .Item("trh_Observacion2")

                    'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_DiasTrabajo").Value = mItem.trh_DiasTrabajo
                    'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_DiasTrabajoXHora").Value = mItem.trh_DiasTrabajoXHora

                    oNewDetalleGrupo.trh_HoraBonificadaProduccion = .Item("trh_HoraBonificadaProduccion")
                    oNewDetalleGrupo.trh_HoraBonificadaCambios = .Item("trh_HoraBonificadaCambios")
                    oNewDetalleGrupo.trh_HoraBonificadaExtra = .Item("trh_HoraBonificadaExtra")

                    oNewDetalleGrupo.trh_HoraSimTotalExtra = .Item("trh_HoraSimTotalExtra")
                    oNewDetalleGrupo.trh_HoraDobTotalExtra = .Item("trh_HoraDobTotalExtra")


                    If IsDBNull(.Item("trh_HoraSimpProduccionDestajo")) Then
                        oNewDetalleGrupo.trh_HoraSimpProduccionDestajo = 0
                    Else
                        oNewDetalleGrupo.trh_HoraSimpProduccionDestajo = .Item("trh_HoraSimpProduccionDestajo")
                    End If

                        If (IsDBNull(.Item("trh_HoraSimCambiosDestajo"))) Then
                            oNewDetalleGrupo.trh_HoraSimCambiosDestajo = 0
                        Else
                        oNewDetalleGrupo.trh_HoraSimCambiosDestajo = .Item("trh_HoraSimCambiosDestajo")
                        End If

                    If (IsDBNull(.Item("trh_HoraSimTotalDestajo"))) Then
                        oNewDetalleGrupo.trh_HoraSimTotalDestajo = 0
                    Else
                        oNewDetalleGrupo.trh_HoraSimTotalDestajo = .Item("trh_HoraSimTotalDestajo")
                    End If

                    If (IsDBNull(.Item("trh_HoraDobleProduccionDestajo"))) Then
                        oNewDetalleGrupo.trh_HoraDobleProduccionDestajo = 0
                    Else

                        oNewDetalleGrupo.trh_HoraDobleProduccionDestajo = .Item("trh_HoraDobleProduccionDestajo")
                    End If

                    If IsDBNull(.Item("trh_HoraDobCambiosDestajo")) Then
                        oNewDetalleGrupo.trh_HoraDobCambiosDestajo = 0
                    Else
                        oNewDetalleGrupo.trh_HoraDobCambiosDestajo = .Item("trh_HoraDobCambiosDestajo")
                    End If

                    If (IsDBNull(.Item("trh_HoraDobTotalDestajo"))) Then
                        oNewDetalleGrupo.trh_HoraDobTotalDestajo = 0
                    Else
                        oNewDetalleGrupo.trh_HoraDobTotalDestajo = .Item("trh_HoraDobTotalDestajo")
                    End If



                    '---------------------------------------


                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_Item").Tag = oNewDetalleGrupo

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_Item").Value = oNewDetalleGrupo.trh_Item
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_Id").Tag = oNewDetalleGrupo.per_Id
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Persona").Value = .Item("Nombre")

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = .Item("Codigo")

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimpProduccion").Value = CDbl(oNewDetalleGrupo.trh_HoraSimpProduccion)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobleProduccion").Value = CDbl(oNewDetalleGrupo.trh_HoraDobleProduccion)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimCambios").Value = CDbl(oNewDetalleGrupo.trh_HoraSimCambios)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobCambios").Value = CDbl(oNewDetalleGrupo.trh_HoraDobCambios)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimReparoHora").Value = CDbl(oNewDetalleGrupo.trh_HoraSimReparoHora)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimReparoDia").Value = CDbl(oNewDetalleGrupo.trh_HoraSimReparoDia)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_horaDobReparo").Value = CDbl(oNewDetalleGrupo.trh_horaDobReparo)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraEssalud").Value = CDbl(oNewDetalleGrupo.trh_HoraEssalud)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimTotal").Value = CDbl(oNewDetalleGrupo.trh_HoraSimTotal)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobTotal").Value = CDbl(oNewDetalleGrupo.trh_HoraDobTotal)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_DiasTrabajador").Value = CDbl(oNewDetalleGrupo.trh_DiasTrabajador)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_DiasTrabajadorXHora").Value = CDbl(oNewDetalleGrupo.trh_DiasTrabajadorXHora)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_observacion1").Value = oNewDetalleGrupo.trh_observacion1
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_Observacion2").Value = oNewDetalleGrupo.trh_Observacion2
                    'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_DiasTrabajo").Value = mItem.trh_DiasTrabajo
                    'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_DiasTrabajoXHora").Value = mItem.trh_DiasTrabajoXHora

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraBonificadaProduccion").Value = CDbl(oNewDetalleGrupo.trh_HoraBonificadaProduccion)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraBonificadaCambios").Value = CDbl(oNewDetalleGrupo.trh_HoraBonificadaCambios)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraBonificadaExtra").Value = CDbl(oNewDetalleGrupo.trh_HoraBonificadaExtra)

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimTotalExtra").Value = CDbl(oNewDetalleGrupo.trh_HoraSimTotalExtra)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobTotalExtra").Value = CDbl(oNewDetalleGrupo.trh_HoraDobTotalExtra)



                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimpProduccionDestajo").Value = CDbl(oNewDetalleGrupo.trh_HoraSimpProduccionDestajo)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimCambiosDestajo").Value = CDbl(oNewDetalleGrupo.trh_HoraSimCambiosDestajo)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimTotalDestajo").Value = CDbl(oNewDetalleGrupo.trh_HoraSimTotalDestajo)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobleProduccionDestajo").Value = CDbl(oNewDetalleGrupo.trh_HoraDobleProduccionDestajo)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobCambiosDestajo").Value = CDbl(oNewDetalleGrupo.trh_HoraDobCambiosDestajo)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobTotalDestajo").Value = CDbl(oNewDetalleGrupo.trh_HoraDobTotalDestajo)




                End With
                oTrabajadorHoras.DetalleTrabajadorHoras.Add(oNewDetalleGrupo)


              
                ' Next
                x += 1
            End While
            txtNumeroRegistros.Text = dgvDetalle.Rows.Count
        End Sub
        Public Sub SumaDatos()
            Dim dBonificacion As Double
            Dim trh_HoraSimTotalExtra As Double = 0
            Dim SumaHoraDobTotalExtra As Double = 0
            Dim SumaHoraEssalud As Double = 0
            Dim x As Integer = 0

            dBonificacion = 0
            Try
                While (dgvDetalle.Rows.Count > x)

                    dBonificacion += Val(dgvDetalle.Rows(x).Cells("trh_HoraBonificadaExtra").Value)
                    trh_HoraSimTotalExtra += Val(dgvDetalle.Rows(x).Cells("trh_HoraSimTotalExtra").Value)
                    SumaHoraDobTotalExtra += Val(dgvDetalle.Rows(x).Cells("trh_HoraDobTotalExtra").Value)
                    SumaHoraEssalud += Val(dgvDetalle.Rows(x).Cells("trh_HoraEssalud").Value)
                    x += 1
                End While
            Catch ex As Exception

            End Try


            txtSumaBonificacion.Text = dBonificacion
            txtHoraSimTotalExtra.Text = trh_HoraSimTotalExtra
            txtSumaHoraDobTotalExtra.Text = SumaHoraDobTotalExtra
            txtHoraEssalud.Text = SumaHoraEssalud

        End Sub
        Public Overrides Sub OnManAgregarFilaGrid()
            Dim iRow As Integer = 0
            dgvDetalle.Rows.Add()
            txtNumeroRegistros.Text = dgvDetalle.Rows.Count
        End Sub

        Public Overrides Sub OnManQuitarFilaGrid()
            If (dgvDetalle.SelectedRows.Count > 0) Then

                For Each mDetalle As DataGridViewRow In dgvDetalle.SelectedRows
                    If Not mDetalle.Cells("trh_Item").Value Is Nothing Then
                        With CType(mDetalle.Cells("trh_Item").Tag, BE.DetalleTrabajadorHoras)
                            .MarkAsDeleted()
                        End With
                    End If
                    dgvDetalle.Rows.Remove(mDetalle)
                Next

            Else
                MsgBox("Seleccione un registro")
            End If
            txtNumeroRegistros.Text = dgvDetalle.Rows.Count
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarFecha)()

            frm.inicio(Constants.BuscadoresNames.TrabajadorHoras)

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
                    If oTrabajadorHoras IsNot Nothing Then
                        dgvDetalle.EndEdit()

                        oTrabajadorHoras.trh_FechaDesde = CDate(dateDesde.Text)
                        oTrabajadorHoras.trh_FechaHasta = CDate(dateHasta.Text)
                        oTrabajadorHoras.trh_descripcion = txtObservaciones.Text
                        oTrabajadorHoras.tit_TipoTrab_Id = cboTipoTrabajador.SelectedValue

                        oTrabajadorHoras.trh_Numero = txtNumero.Text
                        oTrabajadorHoras.trh_BloquearFechas = chkBloquear.Checked
                        oTrabajadorHoras.trh_EsImportadoExcel = chkEsdeExcel.Checked
                        oTrabajadorHoras.trh_EsImportadoProduc = chkEsdeExcel.Checked

                        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                            If Not mDetalle.Cells("trh_Item").Value Is Nothing Then
                                With CType(mDetalle.Cells("trh_Item").Tag, BE.DetalleTrabajadorHoras)

                                    .tit_TipoTrab_Id = cboTipoTrabajador.SelectedValue
                                    .trh_Numero = txtNumero.Text
                                    .trh_Item = mDetalle.Cells("trh_Item").Value
                                    .per_Id = mDetalle.Cells("per_Id").Tag

                                    If mDetalle.Cells("trh_HoraSimpProduccion").Value Is Nothing Then
                                        .trh_HoraSimpProduccion = 0
                                    Else
                                        .trh_HoraSimpProduccion = CDec(Val(mDetalle.Cells("trh_HoraSimpProduccion").Value.ToString))
                                    End If

                                    If (mDetalle.Cells("trh_HoraDobleProduccion").Value Is Nothing) Then
                                        .trh_HoraDobleProduccion = 0
                                    Else
                                        .trh_HoraDobleProduccion = CDec(Val(mDetalle.Cells("trh_HoraDobleProduccion").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraSimCambios").Value Is Nothing) Then
                                        .trh_HoraSimCambios = 0
                                    Else
                                        .trh_HoraSimCambios = CDec(Val(mDetalle.Cells("trh_HoraSimCambios").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraDobCambios").Value Is Nothing) Then
                                        .trh_HoraDobCambios = 0
                                    Else
                                        .trh_HoraDobCambios = CDec(Val(mDetalle.Cells("trh_HoraDobCambios").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraSimReparoHora").Value Is Nothing) Then
                                        .trh_HoraSimReparoHora = 0
                                    Else
                                        .trh_HoraSimReparoHora = CDec(Val(mDetalle.Cells("trh_HoraSimReparoHora").Value))
                                    End If
                                    If (mDetalle.Cells("trh_HoraSimReparoDia").Value Is Nothing) Then
                                        .trh_HoraSimReparoDia = 0
                                    Else
                                        .trh_HoraSimReparoDia = CDec(Val(mDetalle.Cells("trh_HoraSimReparoDia").Value.ToString))
                                    End If

                                    If (mDetalle.Cells("trh_horaDobReparo").Value Is Nothing) Then
                                        .trh_horaDobReparo = 0
                                    Else
                                        .trh_horaDobReparo = CDec(Val(mDetalle.Cells("trh_horaDobReparo").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraEssalud").Value Is Nothing) Then
                                        .trh_HoraEssalud = 0
                                    Else
                                        .trh_HoraEssalud = CDec(Val(mDetalle.Cells("trh_HoraEssalud").Value))
                                    End If

                                    If (mDetalle.Cells("trh_HoraSimTotal").Value Is Nothing) Then
                                        .trh_HoraSimTotal = 0
                                    Else
                                        .trh_HoraSimTotal = CDec(Val(mDetalle.Cells("trh_HoraSimTotal").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraDobTotal").Value Is Nothing) Then
                                        .trh_HoraDobTotal = 0
                                    Else
                                        .trh_HoraDobTotal = CDec(Val(mDetalle.Cells("trh_HoraDobTotal").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_DiasTrabajador").Value Is Nothing) Then
                                        .trh_DiasTrabajador = 0
                                    Else
                                        .trh_DiasTrabajador = CInt(Val(mDetalle.Cells("trh_DiasTrabajador").Value.ToString))
                                    End If

                                    If (mDetalle.Cells("trh_DiasTrabajadorXHora").Value Is Nothing) Then
                                        .trh_DiasTrabajadorXHora = 0
                                    Else
                                        .trh_DiasTrabajadorXHora = CDec(Val(mDetalle.Cells("trh_DiasTrabajadorXHora").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraSimTotalExtra").Value Is Nothing) Then
                                        .trh_HoraSimTotalExtra = 0
                                    Else
                                        .trh_HoraSimTotalExtra = CDec(Val(mDetalle.Cells("trh_HoraSimTotalExtra").Value.ToString))
                                    End If



                                    If (mDetalle.Cells("trh_HoraBonificadaProduccion").Value Is Nothing) Then
                                        .trh_HoraBonificadaProduccion = 0
                                    Else
                                        .trh_HoraBonificadaProduccion = CDec(Val(mDetalle.Cells("trh_HoraBonificadaProduccion").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraBonificadaCambios").Value Is Nothing) Then
                                        .trh_HoraBonificadaCambios = 0
                                    Else
                                        .trh_HoraBonificadaCambios = CDec(Val(mDetalle.Cells("trh_HoraBonificadaCambios").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraBonificadaExtra").Value Is Nothing) Then
                                        .trh_HoraBonificadaExtra = 0
                                    Else
                                        .trh_HoraBonificadaExtra = CDec(Val(mDetalle.Cells("trh_HoraBonificadaExtra").Value.ToString))
                                    End If



                                    If (mDetalle.Cells("trh_HoraDobTotalExtra").Value Is Nothing) Then
                                        .trh_HoraDobTotalExtra = 0
                                    Else
                                        .trh_HoraDobTotalExtra = CDec(Val(mDetalle.Cells("trh_HoraDobTotalExtra").Value.ToString))
                                    End If


                                    If (mDetalle.Cells("trh_HoraSimpProduccionDestajo").Value Is Nothing) Then
                                        .trh_HoraSimpProduccionDestajo = 0
                                    Else
                                        .trh_HoraSimpProduccionDestajo = CDec(Val(mDetalle.Cells("trh_HoraSimpProduccionDestajo").Value.ToString))
                                    End If

                                    If (mDetalle.Cells("trh_HoraSimCambiosDestajo").Value Is Nothing) Then
                                        .trh_HoraSimCambiosDestajo = 0
                                    Else
                                        .trh_HoraSimCambiosDestajo = CDec(Val(mDetalle.Cells("trh_HoraSimCambiosDestajo").Value.ToString))
                                    End If

                                    If (mDetalle.Cells("trh_HoraSimTotalDestajo").Value Is Nothing) Then
                                        .trh_HoraSimTotalDestajo = 0
                                    Else
                                        .trh_HoraSimTotalDestajo = CDec(Val(mDetalle.Cells("trh_HoraSimTotalDestajo").Value.ToString))
                                    End If

                                    If (mDetalle.Cells("trh_HoraDobleProduccionDestajo").Value Is Nothing) Then
                                        .trh_HoraDobleProduccionDestajo = 0
                                    Else
                                        .trh_HoraDobleProduccionDestajo = CDec(Val(mDetalle.Cells("trh_HoraDobleProduccionDestajo").Value.ToString))
                                    End If


                                    If (mDetalle.Cells("trh_HoraDobCambiosDestajo").Value Is Nothing) Then
                                        .trh_HoraDobCambiosDestajo = 0
                                    Else
                                        .trh_HoraDobCambiosDestajo = CDec(Val(mDetalle.Cells("trh_HoraDobCambiosDestajo").Value.ToString))
                                    End If


                                    If (mDetalle.Cells("trh_HoraDobTotalDestajo").Value Is Nothing) Then
                                        .trh_HoraDobTotalDestajo = 0
                                    Else
                                        .trh_HoraDobTotalDestajo = CDec(Val(mDetalle.Cells("trh_HoraDobTotalDestajo").Value.ToString))
                                    End If


                                    .Usu_Id = SessionServer.UserId
                                    .trh_FECGRAB = Now


                                    .MarkAsModified()

                                End With
                            Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                                Dim nOSD As New DetalleTrabajadorHoras
                                With nOSD


                                    .tit_TipoTrab_Id = cboTipoTrabajador.SelectedValue
                                    .trh_Numero = txtNumero.Text
                                    .trh_Item = mDetalle.Cells("trh_Item").Value
                                    .per_Id = mDetalle.Cells("per_Id").Tag

                                    If mDetalle.Cells("trh_HoraSimpProduccion").Value Is Nothing Then
                                        .trh_HoraSimpProduccion = 0
                                    Else
                                        .trh_HoraSimpProduccion = CDec(Val(mDetalle.Cells("trh_HoraSimpProduccion").Value.ToString))
                                    End If

                                    If (mDetalle.Cells("trh_HoraDobleProduccion").Value Is Nothing) Then
                                        .trh_HoraDobleProduccion = 0
                                    Else
                                        .trh_HoraDobleProduccion = CDec(Val(mDetalle.Cells("trh_HoraDobleProduccion").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraSimCambios").Value Is Nothing) Then
                                        .trh_HoraSimCambios = 0
                                    Else
                                        .trh_HoraSimCambios = CDec(Val(mDetalle.Cells("trh_HoraSimCambios").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraDobCambios").Value Is Nothing) Then
                                        .trh_HoraDobCambios = 0
                                    Else
                                        .trh_HoraDobCambios = CDec(Val(mDetalle.Cells("trh_HoraDobCambios").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraSimReparoHora").Value Is Nothing) Then
                                        .trh_HoraSimReparoHora = 0
                                    Else
                                        .trh_HoraSimReparoHora = CDec(Val(mDetalle.Cells("trh_HoraSimReparoHora").Value))
                                    End If
                                    If (mDetalle.Cells("trh_HoraSimReparoDia").Value Is Nothing) Then
                                        .trh_HoraSimReparoDia = 0
                                    Else
                                        .trh_HoraSimReparoDia = CDec(Val(mDetalle.Cells("trh_HoraSimReparoDia").Value.ToString))
                                    End If

                                    If (mDetalle.Cells("trh_horaDobReparo").Value Is Nothing) Then
                                        .trh_horaDobReparo = 0
                                    Else
                                        .trh_horaDobReparo = CDec(Val(mDetalle.Cells("trh_horaDobReparo").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraEssalud").Value Is Nothing) Then
                                        .trh_HoraEssalud = 0
                                    Else
                                        .trh_HoraEssalud = CDec(Val(mDetalle.Cells("trh_HoraEssalud").Value))
                                    End If

                                    If (mDetalle.Cells("trh_HoraSimTotal").Value Is Nothing) Then
                                        .trh_HoraSimTotal = 0
                                    Else
                                        .trh_HoraSimTotal = CDec(Val(mDetalle.Cells("trh_HoraSimTotal").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraDobTotal").Value Is Nothing) Then
                                        .trh_HoraDobTotal = 0
                                    Else
                                        .trh_HoraDobTotal = CDec(Val(mDetalle.Cells("trh_HoraDobTotal").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_DiasTrabajador").Value Is Nothing) Then
                                        .trh_DiasTrabajador = 0
                                    Else
                                        .trh_DiasTrabajador = CInt(Val(mDetalle.Cells("trh_DiasTrabajador").Value.ToString))
                                    End If

                                    If (mDetalle.Cells("trh_DiasTrabajadorXHora").Value Is Nothing) Then
                                        .trh_DiasTrabajadorXHora = 0
                                    Else
                                        .trh_DiasTrabajadorXHora = CDec(Val(mDetalle.Cells("trh_DiasTrabajadorXHora").Value.ToString))
                                    End If


                                    If (mDetalle.Cells("trh_HoraBonificadaProduccion").Value Is Nothing) Then
                                        .trh_HoraBonificadaProduccion = 0
                                    Else
                                        .trh_HoraBonificadaProduccion = CDec(Val(mDetalle.Cells("trh_HoraBonificadaProduccion").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraBonificadaCambios").Value Is Nothing) Then
                                        .trh_HoraBonificadaCambios = 0
                                    Else
                                        .trh_HoraBonificadaCambios = CDec(Val(mDetalle.Cells("trh_HoraBonificadaCambios").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraBonificadaExtra").Value Is Nothing) Then
                                        .trh_HoraBonificadaExtra = 0
                                    Else
                                        .trh_HoraBonificadaExtra = CDec(Val(mDetalle.Cells("trh_HoraBonificadaExtra").Value.ToString))
                                    End If


                                    If (mDetalle.Cells("trh_HoraSimTotalExtra").Value Is Nothing) Then
                                        .trh_HoraSimTotalExtra = 0
                                    Else
                                        .trh_HoraSimTotalExtra = CDec(Val(mDetalle.Cells("trh_HoraSimTotalExtra").Value.ToString))
                                    End If
                                    If (mDetalle.Cells("trh_HoraDobTotalExtra").Value Is Nothing) Then
                                        .trh_HoraDobTotalExtra = 0
                                    Else
                                        .trh_HoraDobTotalExtra = CDec(Val(mDetalle.Cells("trh_HoraDobTotalExtra").Value.ToString))
                                    End If


                                    If (mDetalle.Cells("trh_HoraSimpProduccionDestajo").Value Is Nothing) Then
                                        .trh_HoraSimpProduccionDestajo = 0
                                    Else
                                        .trh_HoraSimpProduccionDestajo = CDec(Val(mDetalle.Cells("trh_HoraSimpProduccionDestajo").Value.ToString))
                                    End If

                                    If (mDetalle.Cells("trh_HoraSimCambiosDestajo").Value Is Nothing) Then
                                        .trh_HoraSimCambiosDestajo = 0
                                    Else
                                        .trh_HoraSimCambiosDestajo = CDec(Val(mDetalle.Cells("trh_HoraSimCambiosDestajo").Value.ToString))
                                    End If

                                    If (mDetalle.Cells("trh_HoraSimTotalDestajo").Value Is Nothing) Then
                                        .trh_HoraSimTotalDestajo = 0
                                    Else
                                        .trh_HoraSimTotalDestajo = CDec(Val(mDetalle.Cells("trh_HoraSimTotalDestajo").Value.ToString))
                                    End If

                                    If (mDetalle.Cells("trh_HoraDobleProduccionDestajo").Value Is Nothing) Then
                                        .trh_HoraDobleProduccionDestajo = 0
                                    Else
                                        .trh_HoraDobleProduccionDestajo = CDec(Val(mDetalle.Cells("trh_HoraDobleProduccionDestajo").Value.ToString))
                                    End If


                                    If (mDetalle.Cells("trh_HoraDobCambiosDestajo").Value Is Nothing) Then
                                        .trh_HoraDobCambiosDestajo = 0
                                    Else
                                        .trh_HoraDobCambiosDestajo = CDec(Val(mDetalle.Cells("trh_HoraDobCambiosDestajo").Value.ToString))
                                    End If


                                    If (mDetalle.Cells("trh_HoraDobTotalDestajo").Value Is Nothing) Then
                                        .trh_HoraDobTotalDestajo = 0
                                    Else
                                        .trh_HoraDobTotalDestajo = CDec(Val(mDetalle.Cells("trh_HoraDobTotalDestajo").Value.ToString))
                                    End If



                                    .trh_observacion1 = mDetalle.Cells("trh_observacion1").Value
                                    .trh_Observacion2 = mDetalle.Cells("trh_Observacion2").Value
                                    '.trh_DiasTrabajo = IIf(mDetalle.Cells("trh_DiasTrabajo").Value Is Nothing, 0, CInt(Val(mDetalle.Cells("trh_DiasTrabajo").Value.ToString)))
                                    '.trh_DiasTrabajoXHora = IIf(mDetalle.Cells("trh_DiasTrabajoXHora").Value Is Nothing, 0, CDec(Val(mDetalle.Cells("trh_DiasTrabajoXHora").Value.ToString)))
                                    .Usu_Id = SessionServer.UserId
                                    .trh_FecGrab = CDate(Today)

                                    .MarkAsAdded()

                                End With
                                oTrabajadorHoras.DetalleTrabajadorHoras.Add(nOSD)
                            End If
                        Next

                        BCTrabajadorHoras.Maintenance(oTrabajadorHoras)
                        MsgBox("Datos Guardados")
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()
                        DeshabilitarElementoGrid()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Try
                        MsgBox(ex.InnerException.Message)
                    Catch exee As Exception

                    End Try
                    'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                    'If (rethrow) Then
                    '    Throw
                    'End If
                End Try

            End If

        End Sub

        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oTrabajadorHoras = New BE.TrabajadorHoras
            oTrabajadorHoras.MarkAsAdded()
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

        Private Sub frmTrabajadorHoras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
            tipoTrabajador()
            tipoTrabajadorLista()

        End Sub


        Private Sub tipoTrabajadorLista()

            Try
                Dim result = Me.BCTiposTrabajador.TiposTrabajadorQuery(Nothing, Nothing)

                Dim ds As New DataSet
                Dim sr As New StringReader(result)
                Dim x As Integer = 0
                ds.ReadXml(sr)

                Dim rows As DataRow()

                Dim dtNew As DataTable

                ' copy table structure
                dtNew = ds.Tables(0).Clone()

                ' sort and filter data
                rows = ds.Tables(0).Select(" tit_TipoTrab_Id <>'002'")

                ' fill dtNew with selected rows

                For Each dr As DataRow In rows
                    dtNew.ImportRow(dr)

                Next


                While (dtNew.Rows.Count > x)

                    Me.chkLista.Items.Add(dtNew.Rows(x).Item("tit_Descripcion"), True)
                    x += 1

                End While

            Catch ex As Exception
                MsgBox("No se Pudo cargar los datos")
            End Try




        End Sub

        Function validarCeldas() As Boolean
            Dim result As Boolean = True
            Dim iRow As Integer = 0

            Try
                While (dgvDetalle.Rows.Count > iRow)
                    With dgvDetalle.Rows(iRow)

                        If IsNothing(dgvDetalle.Rows(iRow).Cells("per_Id").Tag) OrElse dgvDetalle.Rows(iRow).Cells("per_Id").Tag = "" Then
                            result = False
                            ErrorProvider1.SetError(txtObservaciones, "Persona")
                            Return result
                        Else
                            ErrorProvider1.SetError(txtObservaciones, Nothing)
                        End If

                        If IsNothing(dgvDetalle.Rows(iRow).Cells("Persona").Value) OrElse dgvDetalle.Rows(iRow).Cells("Persona").Value = "" Then
                            result = False
                            ErrorProvider1.SetError(txtObservaciones, "Persona")
                            Return result
                        Else
                            ErrorProvider1.SetError(txtObservaciones, Nothing)
                        End If

                    End With
                    iRow += 1
                End While
            Catch ex As Exception
                result = False
            End Try

            Return result
        End Function

        Function validarCeldas(ByVal iRow As Integer) As Boolean
            Return True
        End Function

       
        Function FiltroConsulta() As DataGridView

            Dim OdataGrd As New DataGridView

            OdataGrd.Columns.Add("Filtro", "Filtro")
            Dim x As Integer = 0
            Dim y As Integer

            x = 0
          
                y = 0
                While (chkLista.Items.Count > y)
                    If (chkLista.GetItemChecked(y) = True) Then
                        Try
                        OdataGrd.Rows.Add(chkLista.Items(y))

                       

                        Catch ex As Exception

                        End Try

                    End If
                    y += 1
                End While
           
            Return OdataGrd
        End Function

        Private Sub ImportarHoras()
            Dim x As Integer = 0
            Try

                Dim result As String = ""

                If (chkEsdeProduccion.Checked) Then
                    result = Me.BCGrupoTrabajo.GrupoTrabajoHorasSeek(dateDesde.Text, dateHasta.Text, "")
                End If

                If (chkImportarMantenimiento.Checked) Then
                    result = Me.BCGrupoMantenimiento.SPPvwGrupoMantenimientoHorasSelectXML(dateDesde.Text, dateHasta.Text, "")
                End If
                If (chkImportarEmpleado.Checked) Then
                    result = BCGrupoEmpleado.SPPvwGrupoEmpleadoHorasSelectXML(dateDesde.Text, dateHasta.Text, "", BCUtil.getXml(FiltroConsulta, 0))
                End If

                Dim ds As New DataSet
                Dim sr As New StringReader(result)

                ds.ReadXml(sr)
                If (Not IsNothing(ds.Tables(0)) OrElse ds.Tables(0).Rows.Count > 0) Then
                    dgvDetalle.Rows.Clear()

                    While (ds.Tables(0).Rows.Count > x)

                        Dim nRow As New DataGridViewRow
                        dgvDetalle.Rows.Add(nRow)
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_Item").Tag = Nothing

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_Item").Value = Nothing
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_Id").Tag = ds.Tables(0).Rows(x).Item("per_id")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = ds.Tables(0).Rows(x).Item("dal_CodigoTrabajador")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Persona").Value = ds.Tables(0).Rows(x).Item("Trabajador")

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraBonificadaProduccion").Value = ds.Tables(0).Rows(x).Item("Bonificacion")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraBonificadaCambios").Value = ds.Tables(0).Rows(x).Item("Bonificacion")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraBonificadaExtra").Value = ds.Tables(0).Rows(x).Item("Bonificacion")


                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimpProduccionDestajo").Value = ds.Tables(0).Rows(x).Item("HoraSimpleDestajo")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimCambiosDestajo").Value = ds.Tables(0).Rows(x).Item("HoraSimpleDestajo")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimTotalDestajo").Value = ds.Tables(0).Rows(x).Item("HoraSimpleDestajo")

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobleProduccionDestajo").Value = ds.Tables(0).Rows(x).Item("HoraDobleDestajo")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobCambiosDestajo").Value = ds.Tables(0).Rows(x).Item("HoraDobleDestajo")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobTotalDestajo").Value = ds.Tables(0).Rows(x).Item("HoraDobleDestajo")

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimpProduccion").Value = ds.Tables(0).Rows(x).Item("HoraSimple")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobleProduccion").Value = ds.Tables(0).Rows(x).Item("Horadoble")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimCambios").Value = ds.Tables(0).Rows(x).Item("HoraSimple")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobCambios").Value = ds.Tables(0).Rows(x).Item("Horadoble")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimReparoHora").Value = ds.Tables(0).Rows(x).Item("ReintegroHora")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimReparoDia").Value = ds.Tables(0).Rows(x).Item("ReintegroDia")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_horaDobReparo").Value = ds.Tables(0).Rows(x).Item("ReintegroDoble")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraEssalud").Value = ds.Tables(0).Rows(x).Item("HoraEssalud")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimTotal").Value = ds.Tables(0).Rows(x).Item("TotalHoraSim")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobTotal").Value = ds.Tables(0).Rows(x).Item("TotalHoraDob")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_DiasTrabajador").Value = ds.Tables(0).Rows(x).Item("DiasTrabajador")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_DiasTrabajadorXHora").Value = ds.Tables(0).Rows(x).Item("DiasTrabajadorXHora")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_observacion1").Value = Nothing
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_Observacion2").Value = Nothing
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimTotalExtra").Value = ds.Tables(0).Rows(x).Item("HoraSimTotalExtra")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobTotalExtra").Value = ds.Tables(0).Rows(x).Item("HoraDobTotalExtra")

                        ' si es obrero
                        If Not (cboTipoTrabajador.SelectedValue = "001") Then
                            CalculoHorasObreros(x)
                        Else
                            CalculoHorasEmpleado(x)
                        End If

                        x += 1
                    End While


                End If
            Catch ex As Exception

            End Try
        End Sub


        Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
            Dim x As Integer = 0
            dgvHoraXTrabajador.DataSource = Nothing

            If (chkEsdeExcel.Checked) Then
                ImportarExcel()

                While (dgvDetalle.Rows.Count > x)
                    Try
                        ' si es obrero
                        If Not (cboTipoTrabajador.SelectedValue = "001") Then
                            CalculoHorasObreros(x)
                        Else
                            CalculoHorasEmpleado(x)
                        End If
                    Catch ex As Exception
                    End Try

                    x += 1
                End While

                SumaDatos()
            End If
        End Sub
        Private Sub ImportarExcel()

            Dim sRuta As String = ""
            Dim sNombreHoja As String = "Hoja4"
            OpenFileDialog1.ShowDialog()
            Dim oTable As New DataTable
            Dim x As Integer = 0
            If (OpenFileDialog1.FileName <> "") Then
                sNombreHoja = InputBox("Nombre de la Hoja de Excel", "Inportar Comedor", "Hoja4")

                If (sNombreHoja.Trim <> "") Then

                    Try
                        sRuta = OpenFileDialog1.FileName
                        oTable = BCUtil.excelImportacionConFormato(sRuta, "Select  Codigo, DiasTrabajo, HoraSimple, HoraDoble, HorasTrabajadas,HoraBonificada from [" & sNombreHoja & "$]")

                        While (oTable.Rows.Count > x)
                            With oTable.Rows(x)

                                'dgvDetalle.Rows.Add(Nothing, "", .Item(0), "", 0, 0, IIf(IsDBNull(.Item(2)), 0, .Item(2)), IIf(IsDBNull(.Item(3)), 0, .Item(3)), 0, 0, 0, 0, IIf(IsDBNull(.Item(2)), 0, .Item(2)), IIf(IsDBNull(.Item(3)), 0, .Item(3)), IIf(IsDBNull(.Item(1)), 0, .Item(1)), IIf(IsDBNull(.Item(4)), 0, .Item(4)), IIf(IsDBNull(.Item(2)), 0, .Item(2)), IIf(IsDBNull(.Item(3)), 0, .Item(3)))
                                dgvDetalle.Rows.Add()
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = .Item("Codigo")
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_DiasTrabajador").Value = IIf(IsDBNull(.Item("DiasTrabajo")), 0, .Item("DiasTrabajo"))
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimpProduccion").Value = IIf(IsDBNull(.Item("HoraSimple")), 0, .Item("HoraSimple"))
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobleProduccion").Value = IIf(IsDBNull(.Item("HoraDoble")), 0, .Item("HoraDoble"))
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraBonificadaProduccion").Value = IIf(IsDBNull(.Item("HoraBonificada")), 0, .Item("HoraBonificada"))


                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimCambios").Value = IIf(IsDBNull(.Item("HoraSimple")), 0, .Item("HoraSimple"))
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobCambios").Value = IIf(IsDBNull(.Item("HoraDoble")), 0, .Item("HoraDoble"))
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_DiasTrabajadorXHora").Value = IIf(IsDBNull(.Item("HorasTrabajadas")), 0, .Item("HorasTrabajadas"))
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraBonificadaProduccion").Value = IIf(IsDBNull(.Item("HoraBonificada")), 0, .Item("HoraBonificada"))
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraEssalud").Value = "0.00"

                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimTotal").Value = IIf(IsDBNull(.Item("HoraSimple")), 0, .Item("HoraSimple"))
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobTotal").Value = IIf(IsDBNull(.Item("HoraDoble")), 0, .Item("HoraDoble"))


                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraSimTotalExtra").Value = IIf(IsDBNull(.Item("HoraSimple")), 0, .Item("HoraSimple"))
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraDobTotalExtra").Value = IIf(IsDBNull(.Item("HoraDoble")), 0, .Item("HoraDoble"))
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_HoraBonificadaExtra").Value = IIf(IsDBNull(.Item("HoraBonificada")), 0, .Item("HoraBonificada"))



                                CargarPersona(dgvDetalle.Rows.Count - 1)

                                Try
                                    If (dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = "") Then
                                        MsgBox("NO existe el Trabajador :" & .Item("Codigo") & " ,Fila:" & (dgvDetalle.Rows.Count - 1).ToString)
                                    End If
                                Catch ex As Exception
                                    MsgBox("NO existe el Trabajador :" & .Item("Codigo") & " ,Fila:" & (dgvDetalle.Rows.Count - 1).ToString)
                                End Try


                            End With
                            x += 1
                        End While

                    Catch ex As Exception
                        MsgBox("Error de importacion", ex.Message)
                    End Try

                Else
                    MsgBox("Si no Ingresa no se puede importar")
                End If
            Else
            End If

            OpenFileDialog1.Dispose()

        End Sub

        Sub CargarPersona(ByVal iFila As Integer)

            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.DatosLaborales)
                frm.llenarCombo()

                frm.cboBuscar.SelectedIndex = 1
                frm.txtBuscar.Text = dgvDetalle.Rows(iFila).Cells(2).Value
                frm.cargarDatos()

                If (frm.dgbRegistro.RowCount > 0) Then
                    With frm.dgbRegistro.Rows(0)
                        dgvDetalle.Rows(iFila).Cells("Codigo").Tag = .Cells(0).Value
                        dgvDetalle.Rows(iFila).Cells("Codigo").Value = .Cells(1).Value
                        dgvDetalle.Rows(iFila).Cells("Persona").Value = .Cells(2).Value
                        dgvDetalle.Rows(iFila).Cells("per_id").Tag = .Cells(0).Value
                    End With
                Else
                    dgvDetalle.Rows(iFila).Cells("Codigo").Tag = Nothing
                    dgvDetalle.Rows(iFila).Cells("Codigo").Value = Nothing
                    dgvDetalle.Rows(iFila).Cells("Persona").Value = Nothing
                    dgvDetalle.Rows(iFila).Cells("per_id").Tag = Nothing

                End If
            Catch ex As Exception
                dgvDetalle.Rows(iFila).Cells("Codigo").Tag = Nothing
                dgvDetalle.Rows(iFila).Cells("Codigo").Value = Nothing
                dgvDetalle.Rows(iFila).Cells("Persona").Value = Nothing
                dgvDetalle.Rows(iFila).Cells("per_id").Tag = Nothing
            End Try




        End Sub


        Private Sub CalculoHorasObreros(ByVal iRow As Int16)

            Dim trh_HoraSimCambios, trh_HoraDobCambios, _
                trh_HoraSimReparoHora, trh_HoraSimReparoDia, _
                trh_horaDobReparo, trh_HoraEssalud, _
                trh_DiasTrabajador, trh_DiasTrabajadorXHora, _
                trh_HoraSimTotal, trh_HoraDobTotal, _
                trh_HoraBonificadaCambios, trh_HoraSimTotalDestajo As Double

            trh_HoraSimCambios = 0
            trh_HoraDobCambios = 0
            trh_HoraSimReparoHora = 0
            trh_horaDobReparo = 0
            trh_HoraEssalud = 0

            trh_HoraSimTotal = 0
            trh_HoraDobTotal = 0

            trh_DiasTrabajador = 0
            trh_HoraSimTotalDestajo = 0

            If (dgvDetalle.Rows(iRow).Cells("trh_HoraSimCambios").Value Is Nothing OrElse dgvDetalle.Rows(iRow).Cells("trh_HoraSimCambios").Value.ToString = "") Then
                dgvDetalle.Rows(iRow).Cells("trh_HoraSimCambios").Value = 0.0
            End If

            If (dgvDetalle.Rows(iRow).Cells("trh_HoraDobCambios").Value Is Nothing OrElse dgvDetalle.Rows(iRow).Cells("trh_HoraDobCambios").Value.ToString = "") Then
                dgvDetalle.Rows(iRow).Cells("trh_HoraDobCambios").Value = 0.0
            End If

            trh_HoraBonificadaCambios = Val(dgvDetalle.Rows(iRow).Cells("trh_HoraBonificadaCambios").Value)

            trh_HoraSimCambios = Val(dgvDetalle.Rows(iRow).Cells("trh_HoraSimCambios").Value)
            trh_HoraDobCambios = Val(dgvDetalle.Rows(iRow).Cells("trh_HoraDobCambios").Value)

            trh_HoraSimReparoHora = Val(dgvDetalle.Rows(iRow).Cells("trh_HoraSimReparoHora").Value)
            trh_HoraSimReparoDia = Val(dgvDetalle.Rows(iRow).Cells("trh_HoraSimReparoDia").Value)
            trh_horaDobReparo = Val(dgvDetalle.Rows(iRow).Cells("trh_horaDobReparo").Value)

            trh_HoraEssalud = Val(dgvDetalle.Rows(iRow).Cells("trh_HoraEssalud").Value)

            trh_HoraSimTotal = trh_HoraSimCambios + trh_HoraSimReparoHora + trh_HoraSimReparoDia + trh_HoraEssalud
            trh_HoraDobTotal = trh_HoraDobCambios + trh_horaDobReparo

            dgvDetalle.Rows(iRow).Cells("trh_HoraSimTotal").Value = trh_HoraSimTotal
            dgvDetalle.Rows(iRow).Cells("trh_HoraDobTotal").Value = trh_HoraDobTotal
            dgvDetalle.Rows(iRow).Cells("trh_HoraBonificadaExtra").Value = trh_HoraBonificadaCambios


            If (dgvDetalle.Rows(iRow).Cells("trh_DiasTrabajador").Value Is Nothing OrElse dgvDetalle.Rows(iRow).Cells("trh_DiasTrabajador").Value.ToString = "") Then
                dgvDetalle.Rows(iRow).Cells("trh_DiasTrabajador").Value = 0
            End If



            trh_DiasTrabajador = Val(dgvDetalle.Rows(iRow).Cells("trh_DiasTrabajador").Value)

            trh_DiasTrabajadorXHora = trh_DiasTrabajador * SessionServer.HoraXDia
            dgvDetalle.Rows(iRow).Cells("trh_DiasTrabajadorXHora").Value = trh_DiasTrabajadorXHora

            ' dgvDetalle.Rows(iRow).Cells("trh_observacion1").Value = Nothing
            'dgvDetalle.Rows(iRow).Cells("trh_Observacion2").Value = Nothing

            dgvDetalle.Rows(iRow).Cells("trh_HoraSimTotalDestajo").Value = dgvDetalle.Rows(iRow).Cells("trh_HoraSimCambiosDestajo").Value
            dgvDetalle.Rows(iRow).Cells("trh_HoraDobTotalDestajo").Value = dgvDetalle.Rows(iRow).Cells("trh_HoraDobCambiosDestajo").Value

            trh_HoraSimTotalDestajo = Val(dgvDetalle.Rows(iRow).Cells("trh_HoraSimTotalDestajo").Value)


            If (trh_HoraSimTotalDestajo > 0) Then
                If (trh_HoraSimTotal - trh_DiasTrabajadorXHora) > 0 Then
                    dgvDetalle.Rows(iRow).Cells("trh_HoraSimTotalExtra").Value = trh_HoraSimTotal - trh_DiasTrabajadorXHora
                Else
                    dgvDetalle.Rows(iRow).Cells("trh_HoraSimTotalExtra").Value = 0.0
                End If
            Else
                dgvDetalle.Rows(iRow).Cells("trh_HoraSimTotalExtra").Value = trh_HoraSimTotal - trh_DiasTrabajadorXHora
            End If



            dgvDetalle.Rows(iRow).Cells("trh_HoraDobTotalExtra").Value = trh_HoraDobTotal

        End Sub
        Private Sub CalculoHorasEmpleado(ByVal iRow As Int16)

            Dim trh_HoraSimCambios, trh_HoraDobCambios, _
                trh_HoraSimReparoHora, trh_HoraSimReparoDia, _
                trh_horaDobReparo, trh_HoraEssalud, _
                trh_DiasTrabajador, trh_DiasTrabajadorXHora, _
                trh_HoraSimTotal, trh_HoraDobTotal, _
                trh_HoraBonificadaCambios As Double

            trh_HoraSimCambios = 0
            trh_HoraDobCambios = 0
            trh_HoraSimReparoHora = 0
            trh_horaDobReparo = 0
            trh_HoraEssalud = 0

            trh_HoraSimTotal = 0
            trh_HoraDobTotal = 0
            trh_DiasTrabajador = 0

            If (dgvDetalle.Rows(iRow).Cells("trh_HoraSimCambios").Value Is Nothing OrElse dgvDetalle.Rows(iRow).Cells("trh_HoraSimCambios").Value.ToString = "") Then
                dgvDetalle.Rows(iRow).Cells("trh_HoraSimCambios").Value = 0.0
            End If

            If (dgvDetalle.Rows(iRow).Cells("trh_HoraDobCambios").Value Is Nothing OrElse dgvDetalle.Rows(iRow).Cells("trh_HoraDobCambios").Value.ToString = "") Then
                dgvDetalle.Rows(iRow).Cells("trh_HoraDobCambios").Value = 0.0
            End If
            trh_HoraSimCambios = Val(dgvDetalle.Rows(iRow).Cells("trh_HoraSimCambios").Value)
            trh_HoraDobCambios = Val(dgvDetalle.Rows(iRow).Cells("trh_HoraDobCambios").Value)

            trh_HoraBonificadaCambios = Val(dgvDetalle.Rows(iRow).Cells("trh_HoraBonificadaCambios").Value)

            trh_HoraSimReparoHora = Val(dgvDetalle.Rows(iRow).Cells("trh_HoraSimReparoHora").Value)
            trh_HoraSimReparoDia = Val(dgvDetalle.Rows(iRow).Cells("trh_HoraSimReparoDia").Value)
            trh_horaDobReparo = Val(dgvDetalle.Rows(iRow).Cells("trh_horaDobReparo").Value)

            trh_HoraEssalud = Val(dgvDetalle.Rows(iRow).Cells("trh_HoraEssalud").Value)

            trh_HoraSimTotal = Math.Round(trh_HoraSimCambios + trh_HoraSimReparoHora + trh_HoraSimReparoDia + trh_HoraEssalud, 2)
            trh_HoraDobTotal = Math.Round(trh_HoraDobCambios + trh_horaDobReparo, 2)

            dgvDetalle.Rows(iRow).Cells("trh_HoraSimTotal").Value = trh_HoraSimTotal
            dgvDetalle.Rows(iRow).Cells("trh_HoraDobTotal").Value = trh_HoraDobTotal

            dgvDetalle.Rows(iRow).Cells("trh_HoraBonificadaExtra").Value = trh_HoraBonificadaCambios

            If (dgvDetalle.Rows(iRow).Cells("trh_DiasTrabajador").Value Is Nothing OrElse dgvDetalle.Rows(iRow).Cells("trh_DiasTrabajador").Value.ToString = "") Then
                dgvDetalle.Rows(iRow).Cells("trh_DiasTrabajador").Value = 0
            End If

            trh_DiasTrabajador = Val(dgvDetalle.Rows(iRow).Cells("trh_DiasTrabajador").Value)

            trh_DiasTrabajadorXHora = trh_DiasTrabajador * SessionServer.HoraXDia
            dgvDetalle.Rows(iRow).Cells("trh_DiasTrabajadorXHora").Value = trh_DiasTrabajadorXHora


            'dgvDetalle.Rows(iRow).Cells("trh_observacion1").Value = Nothing
            'dgvDetalle.Rows(iRow).Cells("trh_Observacion2").Value = Nothing


            dgvDetalle.Rows(iRow).Cells("trh_HoraSimTotalExtra").Value = Math.Round(trh_HoraSimTotal - trh_DiasTrabajadorXHora, 2)
            dgvDetalle.Rows(iRow).Cells("trh_HoraDobTotalExtra").Value = trh_HoraDobTotal

        End Sub
        Private Sub chkEsdeProduccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEsdeProduccion.CheckedChanged
            btnImportarDeGrupoTrabajo.Visible = (chkEsdeProduccion.Checked Or chkImportarMantenimiento.Checked Or chkImportarEmpleado.Checked)
            chkLista.Visible = chkImportarEmpleado.Checked
        End Sub

        Private Sub chkEsdeExcel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEsdeExcel.CheckedChanged


            chkEsdeProduccion.Checked = Not chkEsdeExcel.Checked
            Panel4.Visible = chkEsdeExcel.Checked

        End Sub

        Private Sub dgvDetalle_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDetalle.RowHeaderMouseDoubleClick

            ' MsgBox(dgvDetalle.Rows(e.RowIndex).Cells("per_Id").Tag)

            If (dgvDetalle.SelectedRows.Count > 0) Then

                Dim frm = Me.ContainerService.Resolve(Of frmDatosLaborales)()
                frm.lblTitle.Text = "Datos Laborales"

                frm.cargar(dgvDetalle.SelectedRows(0).Cells("per_Id").Tag)
                frm.menuBuscar()
                frm.Panel1.Enabled = False
                frm.esLlamado = True
                frm.ShowDialog()

                frm.Dispose()
            End If


        End Sub

        Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
            Try
                Select Case dgvDetalle.Columns(e.ColumnIndex).Name

                    Case "per_Id"

                        Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                        frm.inicio(Constants.BuscadoresNames.DatosLaborales)
                        If (frm.ShowDialog = DialogResult.OK) Then
                            With frm.dgbRegistro.CurrentRow

                                dgvDetalle.Rows(e.RowIndex).Cells("Codigo").Tag = .Cells(0).Value
                                dgvDetalle.Rows(e.RowIndex).Cells("Codigo").Value = .Cells(1).Value
                                dgvDetalle.Rows(e.RowIndex).Cells("Persona").Value = .Cells(2).Value
                                dgvDetalle.Rows(e.RowIndex).Cells("per_Id").Tag = .Cells(0).Value

                            End With
                        End If
                End Select
            Catch ex As Exception

            End Try

        End Sub

        Private Sub dgvDetalle_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellValidated
            Try
                If (e.RowIndex >= 0) Then
                    ' si es obrero
                    If Not (cboTipoTrabajador.SelectedValue = "001") Then
                        CalculoHorasObreros(e.RowIndex)
                    Else
                        CalculoHorasEmpleado(e.RowIndex)
                    End If

                End If
                SumaDatos()
            Catch ex As Exception

            End Try

        End Sub


        Private Sub btnPLantillaExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPLantillaExcel.Click
            Dim oTabble As New DataTable("Horas")
            oTabble.Columns.Add("Codigo")

            oTabble.Columns.Add("DiasTrabajo")
            oTabble.Columns.Add("HoraSimple")
            oTabble.Columns.Add("HoraDoble")
            oTabble.Columns.Add("HorasTrabajadas")
            oTabble.Columns.Add("HoraBonificada")

            BCUtil.excelExportar(oTabble)

        End Sub

        Private Sub btnImportarDeGrupoTrabajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportarDeGrupoTrabajo.Click

            ' si ya existen registos registros grabados e importamos , preguntamos si laja datos o no ya que se pierden los datos
            If (txtNumero.Text <> "") Then
                If (dgvDetalle.Rows.Count > 0) Then
                    MsgBox("Primero elimine Todos los Registros")
                    Exit Sub
                End If

            End If


            If (chkEsdeProduccion.Checked Or chkImportarMantenimiento.Checked Or chkImportarEmpleado.Checked) Then
                ImportarHoras()
            End If

            txtNumeroRegistros.Text = dgvDetalle.Rows.Count
        End Sub

        Private Sub chkImportarMantenimiento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkImportarMantenimiento.CheckedChanged



            btnImportarDeGrupoTrabajo.Visible = (chkEsdeProduccion.Checked Or chkImportarMantenimiento.Checked Or chkImportarEmpleado.Checked)

            chkLista.Visible = chkImportarEmpleado.Checked

        End Sub

        Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
            Dim x As Integer = 0
            x = 0
            If (txtCodigo.Text.Length >= 4) Then
                While (dgvDetalle.Rows.Count > x)
                    Try
                        If (dgvDetalle.Rows(x).Cells("Codigo").Value = txtCodigo.Text) Then
                            dgvDetalle.CurrentCell = dgvDetalle.Rows(x).Cells("Codigo")
                            Exit Sub
                        End If
                    Catch ex As Exception

                    End Try
                    x += 1
                End While

            End If
        End Sub

      

        Private Sub dgvDetalle_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEnter
            Try
                If ((chkEsdeProduccion.Checked OrElse chkImportarMantenimiento.Checked OrElse chkImportarEmpleado.Checked) AndAlso Not dgvDetalle.Rows(e.RowIndex).Cells("per_Id").Tag Is Nothing) Then
                    DetalleHoraXTrabajador(dgvDetalle.Rows(e.RowIndex).Cells("per_Id").Tag)

                    txtNombre.Text = dgvDetalle.Rows(e.RowIndex).Cells("Persona").Value
                    txtCodigoBusqueda.Text = dgvDetalle.Rows(e.RowIndex).Cells("Codigo").Value
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub ObtenerDaHorasDeEstaPersonaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObtenerDaHorasDeEstaPersonaToolStripMenuItem.Click


            If (chkEsdeProduccion.Checked Or chkImportarMantenimiento.Checked) Then

                If (dgvDetalle.SelectedRows.Count > 0) Then

                    With dgvDetalle.SelectedRows(0)



                        Dim x As Integer = 0
                        Try

                            Dim result As String = ""

                            If (chkEsdeProduccion.Checked) Then
                                result = Me.BCGrupoTrabajo.GrupoTrabajoHorasSeek(dateDesde.Text, dateHasta.Text, .Cells("per_Id").Tag)
                            End If

                            If (chkImportarMantenimiento.Checked) Then
                                result = Me.BCGrupoMantenimiento.SPPvwGrupoMantenimientoHorasSelectXML(dateDesde.Text, dateHasta.Text, .Cells("per_Id").Tag)
                            End If

                            Dim ds As New DataSet
                            Dim sr As New StringReader(result)

                            ds.ReadXml(sr)
                            If (Not IsNothing(ds.Tables(0)) OrElse ds.Tables(0).Rows.Count > 0) Then
                              
                                ' dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_Item").Tag = Nothing

                                ' dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("trh_Item").Value = Nothing
                                .Cells("per_Id").Tag = ds.Tables(0).Rows(0).Item("per_id")
                                .Cells("Codigo").Value = ds.Tables(0).Rows(0).Item("dal_CodigoTrabajador")
                                .Cells("Persona").Value = ds.Tables(0).Rows(0).Item("Trabajador")

                                .Cells("trh_HoraBonificadaProduccion").Value = ds.Tables(0).Rows(0).Item("Bonificacion")
                                .Cells("trh_HoraBonificadaCambios").Value = ds.Tables(0).Rows(0).Item("Bonificacion")
                                .Cells("trh_HoraBonificadaExtra").Value = ds.Tables(0).Rows(0).Item("Bonificacion")



                                .Cells("trh_HoraSimpProduccion").Value = ds.Tables(0).Rows(0).Item("HoraSimple")
                                .Cells("trh_HoraDobleProduccion").Value = ds.Tables(0).Rows(0).Item("Horadoble")
                                .Cells("trh_HoraSimCambios").Value = ds.Tables(0).Rows(0).Item("HoraSimple")
                                .Cells("trh_HoraDobCambios").Value = ds.Tables(0).Rows(0).Item("Horadoble")
                                .Cells("trh_HoraSimReparoHora").Value = ds.Tables(0).Rows(0).Item("ReintegroHora")
                                .Cells("trh_HoraSimReparoDia").Value = ds.Tables(0).Rows(0).Item("ReintegroDia")
                                .Cells("trh_horaDobReparo").Value = ds.Tables(0).Rows(0).Item("ReintegroDoble")
                                .Cells("trh_HoraEssalud").Value = ds.Tables(0).Rows(0).Item("HoraEssalud")
                                .Cells("trh_HoraSimTotal").Value = ds.Tables(0).Rows(0).Item("TotalHoraSim")
                                .Cells("trh_HoraDobTotal").Value = ds.Tables(0).Rows(0).Item("TotalHoraDob")
                                .Cells("trh_DiasTrabajador").Value = ds.Tables(0).Rows(0).Item("DiasTrabajador")
                                .Cells("trh_DiasTrabajadorXHora").Value = ds.Tables(0).Rows(0).Item("DiasTrabajadorXHora")
                                .Cells("trh_observacion1").Value = Nothing
                                .Cells("trh_Observacion2").Value = Nothing
                                .Cells("trh_HoraSimTotalExtra").Value = ds.Tables(0).Rows(0).Item("HoraSimTotalExtra")
                                .Cells("trh_HoraDobTotalExtra").Value = ds.Tables(0).Rows(0).Item("HoraDobTotalExtra")

                                .Cells("trh_HoraSimpProduccionDestajo").Value = ds.Tables(0).Rows(0).Item("HoraSimpleDestajo")
                                .Cells("trh_HoraSimCambiosDestajo").Value = ds.Tables(0).Rows(0).Item("HoraSimpleDestajo")
                                .Cells("trh_HoraSimTotalDestajo").Value = ds.Tables(0).Rows(0).Item("HoraSimpleDestajo")

                                .Cells("trh_HoraDobleProduccionDestajo").Value = ds.Tables(0).Rows(0).Item("HoraDobleDestajo")
                                .Cells("trh_HoraDobCambiosDestajo").Value = ds.Tables(0).Rows(0).Item("HoraDobleDestajo")
                                .Cells("trh_HoraDobTotalDestajo").Value = ds.Tables(0).Rows(0).Item("HoraDobleDestajo")


                                ' si es obrero
                                If Not (cboTipoTrabajador.SelectedValue = "001") Then
                                    CalculoHorasObreros(.Index)
                                Else
                                    CalculoHorasEmpleado(.Index)
                                End If


                            End If
                        Catch ex As Exception

                        End Try

                    End With

                Else
                    MsgBox("Seleccione un registro ")
                End If
            Else
                MsgBox("No esta habilitada esta acción")
            End If

        End Sub

      
        Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
            Dim oTablita As New DataTable
            If (dgvDetalle.Rows.Count > 0) Then
                oTablita = BCUtil.getTable(dgvDetalle, "MiTablita")
                BCUtil.excelExportar(oTablita)

            End If
        End Sub

        Private Sub chkImportarEmpleado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkImportarEmpleado.CheckedChanged
            chkLista.Visible = chkImportarEmpleado.Checked
        End Sub

       
    End Class

End Namespace
