
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views

    Public Class frmGrupoTrabajoTarea

        <Dependency()> _
        Public Property BCAreaTrabajos As BL.IBCAreaTrabajos

        <Dependency()> _
        Public Property BCGrupoTrabajo As Ladisac.BL.IBCGrupoTrabajo

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oGrupoTrabajo As New BE.GrupoTrabajo

        Protected oGrupoTrabajoDelete As New BE.GrupoTrabajo


        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtPeriodo.Text.Trim = "") Then
                ErrorProvider1.SetError(txtPeriodo, "Periodo")
                result = False
            Else
                ErrorProvider1.SetError(txtPeriodo, Nothing)
            End If

            If (txtTarea.Text = "") Then
                ErrorProvider1.SetError(txtTarea, "Tarea")
                result = False
            Else
                ErrorProvider1.SetError(txtTarea, Nothing)
            End If
            If (txtHoraInicio.Text = "" OrElse Not IsNumeric(txtHoraInicio.Text)) Then
                ErrorProvider1.SetError(txtHoraInicio, "Hora Inicio")
                result = False
            Else
                ErrorProvider1.SetError(txtHoraInicio, Nothing)
            End If

            If (txtHoraFin.Text = "" OrElse Not IsNumeric(txtHoraFin.Text)) Then
                ErrorProvider1.SetError(txtHoraFin, "Hora Inicio")
                result = False
            Else
                ErrorProvider1.SetError(txtHoraFin, Nothing)
            End If

            If (txtObservaciones.Text = "") Then
                ErrorProvider1.SetError(txtObservaciones, "Observaciones")
                result = False
            Else
                ErrorProvider1.SetError(txtObservaciones, Nothing)
            End If

            If Not (chkEsTareo.Checked) Then
                ErrorProvider1.SetError(chkEsTareo, "Estos datos se modifican por el formulario << Trabajo Hora >> ")
                result = False
            Else
                ErrorProvider1.SetError(chkEsTareo, Nothing)
            End If


            Return result
        End Function
        Private Sub limpiar()


            'txtPeriodo.Text = ""
            txtTarea.Text = ""
            txtTarea.Tag = ""
            lblTipoArea.Tag = ""
            txtHoraFin.Text = ""
            txtHoraInicio.Text = ""
            txtNumero.Text = ""
            txtTarifa.Text = "0.00"

            dgvDetalle.Rows.Clear()
            dgvProduccion.Rows.Clear()
            txtgrt_EsSecaderoQuema.Text = ""
            txtgrt_ResponsableSecaderoQuemas.Text = ""
            rdbPorCarga.Checked = True



        End Sub

        Function validarCarga() As Boolean

            Dim x As Integer = 0
            Dim result As Boolean = True
            While (dgvProduccion.Rows.Count > x)
                If (Val(dgvProduccion.Rows(x).Cells("Carga").Value) <= 0) Then
                    result = False
                    Exit While

                End If
                x += 1
            End While

            Return result

        End Function

        Sub repartirTarifa()
            Dim dTarifa As Double
            'Dim dTotal As Double
            Dim x As Int16 = 0


            If (dgvDetalle.Rows.Count > 0) Then

                If (lblTipoArea.Tag <> "004") Then
                    dTarifa = Math.Round(Val(txtTarifa.Text) / dgvDetalle.Rows.Count, 6)
                Else

                    If (txtHoraInicio.Text <> "" AndAlso txtHoraFin.Text <> "") Then
                        dTarifa = BCUtil.diferenciaHorasHH(txtHoraInicio.Text, txtHoraFin.Text)
                    Else
                        MsgBox("Ingesar Hora Inicio, Hora Fin")
                        Exit Sub
                    End If


                End If


                'If (dgvProduccion.Rows.Count > 0) Then
                '    dTotal = Math.Round(dTarifa / dgvProduccion.Rows.Count, 6)
                'Else
                '    dTotal = 0.0

                'End If

                While (dgvDetalle.Rows.Count > x)
                    dgvDetalle.Rows(x).Cells("dgt_Factor").Value = dTarifa
                    calculoCeldas(x)
                    '  dgvDetalle.Rows(x).Cells("dgt_HoraTotales").Value = dTotal
                    x += 1
                End While

            End If

        End Sub
        Sub calculoCeldas(ByVal iRow As Integer)

            Dim dgt_Factor, dgt_NumPersonas, dgt_CantidadLadrillo, dgt_Fraccion, dgt_Refrigerio, _
                dgt_Bonificacion, dgt_Mesas, dgt_Alas, dgt_HoraDesde, dgt_HoraHasta, dgt_Descuento As Double
            Dim dgt_HoraTotales As Double
            Dim tipoTarea As String
            dgt_HoraTotales = 0

            'If (validarCeldas(iRow)) Then

            tipoTarea = lblTipoArea.Tag

            dgt_Factor = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_Factor").Value)
            'dgt_NumPersonas = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_NumPersonas").Value)
            'dgt_CantidadLadrillo = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_CantidadLadrillo").Value)
            dgt_Fraccion = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_Fraccion").Value)
            dgt_Refrigerio = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_Refrigerio").Value)
            dgt_Bonificacion = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_Bonificacion").Value)
            dgt_Descuento = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_Descuento").Value)
            'dgt_Mesas = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_Mesas").Value)
            'dgt_Alas = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_Alas").Value)

            'dgt_HoraDesde = dgvDetalle.Rows(iRow).Cells("dgt_HoraDesde").Value
            'dgt_HoraHasta = dgvDetalle.Rows(iRow).Cells("dgt_HoraHasta").Value



            dgvDetalle.Rows(iRow).Cells("dgt_HoraTotales").Value = "0.00"

            dgt_HoraTotales = Math.Round(((dgt_Factor * dgt_Fraccion) + dgt_Bonificacion - dgt_Descuento) - dgt_Refrigerio, 6)


            'Select Case tipoTarea

            '    Case "001" ' por indice
            '        dgt_HoraTotales = Math.Round(((((dgt_CantidadLadrillo / dgt_Factor) / dgt_NumPersonas) * dgt_Fraccion) - dgt_Bonificacion) - dgt_Refrigerio, 6)
            '    Case "002" ' por  paquete
            '        dgt_HoraTotales = Math.Round(((((dgt_Alas + dgt_Mesas) * dgt_Factor) * dgt_Fraccion) - dgt_Refrigerio) - dgt_Bonificacion, 6)
            '    Case "003" 'por trabajo en tareo por otro frm frmGrupoTrabajoTareo

            '    Case "004" 'por horas 
            '        ' dgt_HoraTotales = Math.Round((((diferenciaHorasHH(dgt_HoraDesde, dgt_HoraHasta, 1)) * dgt_Fraccion) - dgt_Refrigerio) - dgt_Bonificacion, 6)

            '        Dim dDiferenciHOra As Double
            '        dDiferenciHOra = BCUtil.diferenciaHorasHH(dgt_HoraDesde, dgt_HoraHasta)
            '        dgt_HoraTotales = (((dDiferenciHOra) * dgt_Fraccion) - dgt_Refrigerio) - dgt_Bonificacion

            '        'dgt_HoraTotales = Math.Round(((Math.Abs(((dgt_HoraDesde / 60) - (dgt_HoraHasta / 60))) * dgt_Fraccion) - (dgt_Refrigerio / 60)) - (dgt_Bonificacion / 60), 6)

            'End Select

            dgvDetalle.Rows(iRow).Cells("dgt_HoraTotales").Value = dgt_HoraTotales.ToString
            ' End If
        End Sub
        Private Sub dgvDetalle_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellValidated
            If (e.RowIndex >= 0 AndAlso lblTipoArea.Tag <> "") Then
                calculoCeldas(e.RowIndex)

            End If
        End Sub
        Sub llenarAreas()

            Dim result = BCAreaTrabajos.AreaTrabajosQuery()
            Dim ds As New DataSet
            Dim sr As New StringReader(result)
            ds.ReadXml(sr)
            cboArea.DataSource = ds.Tables(0)
            cboArea.DisplayMember = "Descripcion"
            cboArea.ValueMember = "ID"

        End Sub
        Public Overrides Sub OnManAgregarFilaGrid()

            Dim iRow As Int16 = 0
            If (dgvDetalle.Focused) Then

                If (txtTarea.Text <> "") Then

                    dgvDetalle.Rows.Add()
                    iRow = dgvDetalle.RowCount - 1

                    dgvDetalle.Rows(iRow).Cells("dgt_Fraccion").Value = 1
                    dgvDetalle.Rows(iRow).Cells("dgt_Refrigerio").Value = 0
                    dgvDetalle.Rows(iRow).Cells("dgt_Bonificacion").Value = 0
                    dgvDetalle.Rows(iRow).Cells("dgt_Descuento").Value = 0
                    dgvDetalle.Rows(iRow).Cells("dgt_Factor").Value = 0
                    repartirTarifa()
                Else
                    MsgBox("Seleccione una Tarea ")
                End If

            End If


            If (dgvProduccion.Focused) Then

                dgvProduccion.Rows.Add()
                repartirTarifa()

            End If

        End Sub
        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarFecha)()
            frm.inicio(Constants.BuscadoresNames.GrupoTrabajoHoras)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value, frm.dgbRegistro.CurrentRow.Cells(1).Value)
                menuBuscar()
                chkEsTareo.Checked = frm.dgbRegistro.CurrentRow.Cells("Tipo").Value
            End If
            frm.Dispose()
            Panel1.Enabled = False
        End Sub

        Public Overrides Sub OnManQuitarFilaGrid()

            If (dgvDetalle.Focused) Then
                If (dgvDetalle.SelectedRows.Count > 0) Then
                    For Each mDetalle As DataGridViewRow In dgvDetalle.SelectedRows

                        dgvDetalle.Rows.Remove(mDetalle)
                    Next
                Else
                    MsgBox("Seleccione un registro")
                End If
            End If

            If (dgvProduccion.Focused) Then
                If (dgvProduccion.SelectedRows.Count > 0) Then
                    For Each mDetalle As DataGridViewRow In dgvProduccion.SelectedRows

                        dgvProduccion.Rows.Remove(mDetalle)
                    Next
                Else
                    MsgBox("Seleccione un registro")
                End If
            End If

            repartirTarifa()
        End Sub
        Private Sub frmGrupoTrabajoTarea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            llenarAreas()

            menuInicio()
            Panel1.Enabled = False
        End Sub

        Private Sub btnTarea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTarea.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TareaTrabajo)
            If (frm.ShowDialog = DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow

                    lblTipoArea.Tag = .Cells(1).Value
                    txtTarea.Tag = .Cells(0).Value
                    txtTarea.Text = .Cells(2).Value
                    txtTarifa.Text = .Cells(4).Value

                End With
            End If
            frm.Dispose()
            repartirTarifa()
            BuscarQuemaSecadero()
            repartirTarifa()
        End Sub
        Sub BuscarQuemaSecadero()

            Dim frm = Me.ContainerService.Resolve(Of frmBuscarFecha)()
            frm.inicio(Constants.BuscadoresNames.GrupoTrabajoQuemaSecadeo)



            frm.BusquedaAutomatica = True
            frm.dateDesde.Value = dateFechaInicio.Value
            frm.dateDesde.Enabled = True
            If (frm.ShowDialog = DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow

                    txtHoraInicio.Text = .Cells("MLC_Inicio").Value
                    txtHoraFin.Text = .Cells("MLC_final").Value


                    'dgvProduccion.Rows.Clear()
                    dgvDetalle.Rows.Add()

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Tag = .Cells("Codigo").Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = .Cells("Codigo").Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Persona").Value = .Cells("Operador").Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_Id").Tag = .Cells("per_Id").Value
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Fraccion").Value = "1"
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Refrigerio").Value = "0"
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Bonificacion").Value = "0"

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Descuento").Value = "0"

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Factor").Value = "0"
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_HoraTotales").Value = "0"

                    calculoCeldas(dgvDetalle.Rows.Count - 1)
                    'lblTipoArea.Tag = .Cells(1).Value
                    'txtTarea.Tag = .Cells(0).Value
                    'txtTarea.Text = .Cells(2).Value
                    'txtTarifa.Text = .Cells(4).Value
                    CargarProducciones(.Cells("Fecha").Value, .Cells("CodigoOP").Value, .Cells("Tipo").Value)

                End With

            End If


            frm.Dispose()
        End Sub
        Sub cargarProduccionModificar(ByVal fecha As Date, ByVal periodo As String, ByVal numero As String)


            Dim query As String = Nothing
            Dim x As Int16
            dgvProduccion.DataSource = Nothing

            query = Me.BCGrupoTrabajo.spGrupoTrabajoSecaderoAgrupagoModificarSelectXML(fecha, periodo, numero)
            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)

                    While (ds.Tables(0).Rows.Count > x)
                        With ds.Tables(0).Rows(x)

                            dgvProduccion.Rows.Add()
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("Produccion").Tag = .Item("Produccion")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("Produccion").Value = .Item("Descripcion")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("por_Id").Tag = .Item("Produccion")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("por_Id").Value = .Item("Produccion")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("pla_id").Tag = .Item("PLA_ID")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("pla_id").Value = .Item("PLA_ID")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("Conteo").Value = .Item("Conteo")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("Carga").Value = .Item("carga")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("Descripcion").Value = .Item("Descripcion")


                        End With
                        x += 1
                    End While


                Else
                    dgvProduccion.Rows.Clear()

                End If
            End If

        End Sub

        Sub CargarProducciones(ByVal fecha As Date, ByVal codigoCP As String, ByVal tipo As String)
            Dim query As String = Nothing
            Dim x As Int16
            dgvProduccion.DataSource = Nothing

            query = Me.BCGrupoTrabajo.spGrupoTrabajoQuemaSecaderoAgrupagoSelectXML(fecha, codigoCP, tipo)
            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)

                    While (ds.Tables(0).Rows.Count > x)
                        With ds.Tables(0).Rows(x)
                            dgvProduccion.Rows.Add()
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("Produccion").Tag = .Item("Produccion")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("Produccion").Value = .Item("Descripcion")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("por_Id").Tag = .Item("Produccion")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("por_Id").Value = .Item("Produccion")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("pla_id").Tag = .Item("PLA_ID")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("pla_id").Value = .Item("PLA_ID")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("Conteo").Value = .Item("Conteo")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("Carga").Value = .Item("carga")
                            dgvProduccion.Rows(dgvProduccion.Rows.Count - 1).Cells("Descripcion").Value = .Item("Descripcion")


                        End With
                        x += 1
                    End While


                Else
                    dgvProduccion.Rows.Clear()

                End If
            End If

        End Sub

        Private Sub btnSerie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerie.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodo.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
            End If

            frm.Dispose()
        End Sub


        Private Sub dgvDetalle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDetalle.KeyPress
            If (e.KeyChar = Chr(Keys.Enter)) Then
                ' codigo
                If (dgvDetalle.SelectedCells(0).ColumnIndex = 1) Then
                    Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                    frm.inicio(Constants.BuscadoresNames.DatosLaborales)
                    frm.cboBuscar.SelectedIndex = 1
                    frm.txtBuscar.Text = dgvDetalle.SelectedCells(0).Value
                    frm.cargarDatos()

                    If (frm.dgbRegistro.Rows.Count > 0) Then
                        With frm.dgbRegistro.Rows(0)

                            dgvDetalle.Rows(dgvDetalle.SelectedCells(0).RowIndex).Cells("Codigo").Tag = .Cells(0).Value
                            dgvDetalle.Rows(dgvDetalle.SelectedCells(0).RowIndex).Cells("Codigo").Value = .Cells(1).Value
                            dgvDetalle.Rows(dgvDetalle.SelectedCells(0).RowIndex).Cells("Persona").Value = .Cells(2).Value
                            dgvDetalle.Rows(dgvDetalle.SelectedCells(0).RowIndex).Cells("per_Id").Tag = .Cells(0).Value

                        End With
                    End If
                End If

            End If
        End Sub

        Private Sub dgvDetalle_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
            Try
                Select Case dgvDetalle.Columns(e.ColumnIndex).Name
                    Case "per_Id"
                        Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                        frm.inicio(Constants.BuscadoresNames.DatosLaborales)
                        If (frm.ShowDialog() = DialogResult.OK) Then
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

        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oGrupoTrabajo = New BE.GrupoTrabajo
            oGrupoTrabajo.MarkAsAdded()
            HabilitarElementoGrid()
            Panel1.Enabled = True
            chkEsTareo.Checked = True

            txtHoraFin.Text = "0.00"
            txtHoraInicio.Text = "0.00"

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

        Sub cargar(ByVal periodo As String, ByVal numero As String)
            limpiar()
            ' Dim sSumaFactor As Double = 0

            oGrupoTrabajo = BCGrupoTrabajo.GrupoTrabajoSeek(numero, periodo)

            oGrupoTrabajo.MarkAsModified()


            txtNumero.Text = oGrupoTrabajo.grt_NumeroProd
            dateFechaInicio.Value = oGrupoTrabajo.grt_Fecha
            txtPeriodo.Text = oGrupoTrabajo.prd_Periodo_id
            txtObservaciones.Text = oGrupoTrabajo.grt_observaciones


            Dim oTAble As New DataTable


            oTAble = BCGrupoTrabajo.SPDetalleGrupoTrabajoMaintenanceSelect(oGrupoTrabajo.prd_Periodo_id, oGrupoTrabajo.grt_NumeroProd)
            Dim x As Integer = 0
            Dim bBonificacionGrupo As Boolean = False
            'For Each mItem In oGrupoTrabajo.DetalleGrupoTrabajo

            While x < oTAble.Rows.Count


                With oTAble.Rows(x)

                    Dim oNewDetalleGrupo As New BE.DetalleGrupoTrabajo
                    oNewDetalleGrupo.prd_Periodo_id = .Item("prd_Periodo_id")
                    oNewDetalleGrupo.grt_NumeroProd = .Item("grt_NumeroProd")
                    oNewDetalleGrupo.dgt_Item = .Item("dgt_Item")
                    oNewDetalleGrupo.ttr_TareaTrab_Id = .Item("ttr_TareaTrab_Id")
                    oNewDetalleGrupo.per_Id = .Item("per_Id")

                    If Not (IsDBNull(.Item("dgt_EsTiempoDoble")) OrElse .Item("dgt_EsTiempoDoble") = "") Then
                        oNewDetalleGrupo.dgt_EsTiempoDoble = .Item("dgt_EsTiempoDoble")
                    Else
                        oNewDetalleGrupo.dgt_EsTiempoDoble = Nothing
                    End If


                    oNewDetalleGrupo.dgt_Fecha = .Item("dgt_Fecha")
                    oNewDetalleGrupo.dgt_HoraDesde = .Item("dgt_HoraDesde")
                    oNewDetalleGrupo.dgt_HoraHasta = .Item("dgt_HoraHasta")
                    oNewDetalleGrupo.dgt_HoraTotales = .Item("dgt_HoraTotales")
                    oNewDetalleGrupo.dgt_Factor = .Item("dgt_Factor")


                    '----------------
                    If (IsDBNull(.Item("dgt_BonificacionGrupo"))) Then
                        oNewDetalleGrupo.dgt_Bonificacion = .Item("dgt_Bonificacion")
                        oNewDetalleGrupo.dgt_BonificacionGrupo = Nothing
                    Else
                        oNewDetalleGrupo.dgt_Bonificacion = .Item("dgt_BonificacionGrupo")
                        oNewDetalleGrupo.dgt_BonificacionGrupo = .Item("dgt_BonificacionGrupo")
                        bBonificacionGrupo = True
                    End If

                    If (IsDBNull(.Item("dgt_DescuentoGrupo"))) Then
                        oNewDetalleGrupo.dgt_Descuento = .Item("dgt_Descuento")
                        oNewDetalleGrupo.dgt_DescuentoGrupo = Nothing
                    Else
                        oNewDetalleGrupo.dgt_Descuento = .Item("dgt_DescuentoGrupo")
                        oNewDetalleGrupo.dgt_DescuentoGrupo = .Item("dgt_DescuentoGrupo")
                    End If

                    If (IsDBNull(.Item("dgt_RefrigerioGrupo"))) Then
                        oNewDetalleGrupo.dgt_Refrigerio = .Item("dgt_Refrigerio")
                        oNewDetalleGrupo.dgt_RefrigerioGrupo = Nothing
                    Else
                        oNewDetalleGrupo.dgt_Refrigerio = .Item("dgt_RefrigerioGrupo")
                        oNewDetalleGrupo.dgt_RefrigerioGrupo = .Item("dgt_RefrigerioGrupo")
                    End If


                    'If (IsDBNull(.Item("dgt_HoraTotalesGrupo"))) Then
                    '    oNewDetalleGrupo.dgt_HoraTotales = .Item("dgt_HoraTotales")
                    '    oNewDetalleGrupo.dgt_HoraTotalesGrupo = Nothing
                    'Else
                    '    oNewDetalleGrupo.dgt_HoraTotales = .Item("dgt_HoraTotalesGrupo")
                    '    oNewDetalleGrupo.dgt_HoraTotalesGrupo = .Item("dgt_HoraTotalesGrupo")
                    'End If




                    '----------------


                    oNewDetalleGrupo.dgt_Fraccion = .Item("dgt_Fraccion")
                    oNewDetalleGrupo.dgt_CantidadLadrillo = .Item("dgt_CantidadLadrillo")
                    oNewDetalleGrupo.dgt_Mesas = .Item("dgt_Mesas")
                    oNewDetalleGrupo.dgt_Alas = .Item("dgt_Alas")
                    If Not (IsDBNull(.Item("dgt_Observaciones"))) Then
                        oNewDetalleGrupo.dgt_Observaciones = .Item("dgt_Observaciones")
                    Else
                        oNewDetalleGrupo.dgt_Observaciones = Nothing
                    End If


                    oNewDetalleGrupo.dgt_NumPersonas = .Item("dgt_NumPersonas")
                    If Not (IsDBNull(.Item("tit_TipTarea_Id"))) Then
                        oNewDetalleGrupo.tit_TipTarea_Id = .Item("tit_TipTarea_Id")
                    Else
                        oNewDetalleGrupo.tit_TipTarea_Id = Nothing
                    End If
                    If Not (IsDBNull(.Item("art_AreaTrab_Id"))) Then
                        oNewDetalleGrupo.art_AreaTrab_Id = .Item("art_AreaTrab_Id")
                    Else
                        oNewDetalleGrupo.art_AreaTrab_Id = Nothing
                    End If

                    If Not (IsDBNull(.Item("pro_Id"))) Then
                        oNewDetalleGrupo.pro_Id = .Item("pro_Id")
                    Else
                        oNewDetalleGrupo.pro_Id = Nothing
                    End If

                    If Not (IsDBNull(.Item("Pla_id"))) Then
                        oNewDetalleGrupo.Pla_id = .Item("Pla_id")
                    Else
                        oNewDetalleGrupo.Pla_id = Nothing
                    End If

                    If Not IsDBNull(oTAble.Rows(0).Item("pro_Id")) Then


                        If (oTAble.Rows(0).Item("pro_Id") = oTAble.Rows(x).Item("pro_Id")) Then

                            Dim nRow As New DataGridViewRow
                            dgvDetalle.Rows.Add(nRow)

                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = .Item("Codigo")

                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_Id").Tag = oNewDetalleGrupo.per_Id
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Persona").Value = .Item("Nombre")

                            txtHoraInicio.Text = oNewDetalleGrupo.dgt_HoraDesde
                            txtHoraFin.Text = oNewDetalleGrupo.dgt_HoraHasta

                            'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_HoraTotales").Value = oNewDetalleGrupo.dgt_HoraTotales

                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Factor").Value = oNewDetalleGrupo.dgt_Factor ' (oNewDetalleGrupo.dgt_HoraTotales + oNewDetalleGrupo.dgt_Bonificacion + oNewDetalleGrupo.dgt_Refrigerio) / oNewDetalleGrupo.dgt_Fraccion

                            'If (oNewDetalleGrupo.tit_TipTarea_Id <> "004") Then
                            '    txtTarifa.Text = (oNewDetalleGrupo.dgt_HoraTotales + oNewDetalleGrupo.dgt_Bonificacion + oNewDetalleGrupo.dgt_Refrigerio) / oNewDetalleGrupo.dgt_Fraccion

                            'End If

                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_HoraTotales").Value = "0.00" ' oNewDetalleGrupo.dgt_Factor

                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Bonificacion").Value = oNewDetalleGrupo.dgt_Bonificacion
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Descuento").Value = oNewDetalleGrupo.dgt_Descuento
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Refrigerio").Value = oNewDetalleGrupo.dgt_Refrigerio


                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Fraccion").Value = oNewDetalleGrupo.dgt_Fraccion
                            'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_CantidadLadrillo").Value = oNewDetalleGrupo.dgt_CantidadLadrillo
                            ' dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Mesas").Value = oNewDetalleGrupo.dgt_Mesas
                            'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Alas").Value = oNewDetalleGrupo.dgt_Alas
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Observaciones").Value = oNewDetalleGrupo.dgt_Observaciones

                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Item").Value = oNewDetalleGrupo.dgt_Item
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Item").Tag = oNewDetalleGrupo

                            'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_NumPersonas").Value = oNewDetalleGrupo.dgt_NumPersonas

                            If Not (IsDBNull(oNewDetalleGrupo.art_AreaTrab_Id) OrElse oNewDetalleGrupo.art_AreaTrab_Id = "") Then
                                cboArea.SelectedValue = oNewDetalleGrupo.art_AreaTrab_Id
                            End If

                            If Not (IsDBNull(oNewDetalleGrupo.tit_TipTarea_Id) OrElse oNewDetalleGrupo.tit_TipTarea_Id = "") Then

                                lblTipoArea.Tag = oNewDetalleGrupo.tit_TipTarea_Id
                                txtTarea.Text = IIf(IsNothing(.Item("ttr_Tarea")), "", .Item("ttr_Tarea"))
                            End If

                            If Not (IsDBNull(oNewDetalleGrupo.ttr_TareaTrab_Id) OrElse oNewDetalleGrupo.ttr_TareaTrab_Id = "") Then
                                txtTarea.Tag = .Item("ttr_TareaTrab_Id") 'oNewDetalleGrupo.ttr_TareaTrab_Id
                            End If


                            '  dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("pro_Id").Value = mItem.pro_Id
                            'If Not (IsDBNull(oNewDetalleGrupo.pro_Id) OrElse Val(oNewDetalleGrupo.pro_Id) <= 0) Then
                            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("pro_Id").Tag = oNewDetalleGrupo.pro_Id
                            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Produccion").Value = oNewDetalleGrupo.pro_Id
                            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Descripcion").Value = .Item("ART_DESCRIPCION")
                            'End If

                            'If Not (IsDBNull(oNewDetalleGrupo.Pla_id) OrElse Val(oNewDetalleGrupo.Pla_id) <= 0) Then
                            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Pla_id").Value = oNewDetalleGrupo.Pla_id.ToString
                            'End If 
                            '  dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("pro_Id").Tag = mItem.pro_Id
                            '  dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Pla_id").Value = mItem.Pla_id

                            'If Not (IsDBNull(oNewDetalleGrupo.tit_TipTarea_Id) OrElse oNewDetalleGrupo.tit_TipTarea_Id = "") Then
                            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tit_TipTarea_Id").Tag = oNewDetalleGrupo.tit_TipTarea_Id
                            'End If


                        End If
                    End If

                    oGrupoTrabajo.DetalleGrupoTrabajo.Add(oNewDetalleGrupo)
                End With


                x += 1

            End While
            txtTarifa.Text = oGrupoTrabajo.grt_Factor
            'If (lblTipoArea.Tag <> "004") Then
            '    txtTarifa.Text = oGrupoTrabajo.grt_Factor
            'Else
            '    txtTarifa.Text = "0.00"
            'End If

            cargarProduccionModificar(oGrupoTrabajo.grt_Fecha, oGrupoTrabajo.prd_Periodo_id, oGrupoTrabajo.grt_NumeroProd)

            ' actualizar detalle de bonificaciones, refrigerios y descuentos 
            Dim f As Int16 = 0
            If (Not bBonificacionGrupo) Then
                While (dgvDetalle.Rows.Count > f)

                    dgvDetalle.Rows(f).Cells("dgt_Bonificacion").Value = Math.Round(CDbl(dgvProduccion.Rows.Count) * CDbl(dgvDetalle.Rows(f).Cells("dgt_Bonificacion").Value), 2)
                    dgvDetalle.Rows(f).Cells("dgt_Refrigerio").Value = Math.Round(CDbl(dgvProduccion.Rows.Count) * CDbl(dgvDetalle.Rows(f).Cells("dgt_Refrigerio").Value), 2)
                    dgvDetalle.Rows(f).Cells("dgt_Descuento").Value = Math.Round(CDbl(dgvProduccion.Rows.Count) * CDbl(dgvDetalle.Rows(f).Cells("dgt_Descuento").Value), 2)

                    calculoCeldas(f)

                    f += 1
                End While
            Else
                While (dgvDetalle.Rows.Count > f)
                    calculoCeldas(f)

                    f += 1
                End While
            End If


            ' Clonamos los datos obtenidos del sistema 
            'oGrupoTrabajoDelete = oGrupoTrabajo.Clone()
        End Sub

        Public Overrides Sub OnManGuardar()
            dgvDetalle.EndEdit()
            If rdbPorCarga.Checked Then
                GuardarPorCarga()
            End If

            If (rdbPorProduccion.Checked) Then
                GuardarPorNumeroProduccion()

            End If

        End Sub
        Sub GuardarPorCarga()
            Dim iPlanta, iProduccion As Integer
            Dim dSumaCargas As Double
            Dim dCarga As Double = 0
            Dim x_Cuenta As Integer = 0

            If Not (validarCarga()) Then

                MsgBox("La carga debe ser mayor de Cero '0.00' ")
                Exit Sub

            End If


            If (validar()) Then
                Try
                    If oGrupoTrabajo IsNot Nothing Then
                        dgvDetalle.EndEdit()

                        oGrupoTrabajo.grt_Fecha = CDate(dateFechaInicio.Text)

                        oGrupoTrabajo.prd_Periodo_id = txtPeriodo.Text
                        oGrupoTrabajo.grt_NumeroProd = txtNumero.Text

                        oGrupoTrabajo.grt_observaciones = txtObservaciones.Text
                        oGrupoTrabajo.Usu_Id = SessionServer.UserId
                        oGrupoTrabajo.grt_FECGRAB = Now

                        dSumaCargas = SumarCargaProduccion()
                        oGrupoTrabajo.grt_EsTareo = True

                        oGrupoTrabajo.grt_Factor = Val(txtTarifa.Text)
                        Dim z As Integer
                        While (oGrupoTrabajo.DetalleGrupoTrabajo.Count > z)
                            oGrupoTrabajo.DetalleGrupoTrabajo(z).MarkAsDeleted()
                            z += 1
                        End While




                        While (dgvProduccion.Rows.Count > x_Cuenta)

                            iPlanta = dgvProduccion.Rows(x_Cuenta).Cells("pla_id").Value
                            iProduccion = dgvProduccion.Rows(x_Cuenta).Cells("por_Id").Tag
                            dCarga = Val(dgvProduccion.Rows(x_Cuenta).Cells("Carga").Value)

                            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                                Dim nOSD As New DetalleGrupoTrabajo
                                With nOSD

                                    '.ttr_TareaTrab_Id = mDetalle.Cells("ttr_TareaTrab_Id").Value  ' CType(mDetalle.Cells("ttr_TareaTrab_Id").Value, DataGridViewComboBoxColumn).ValueMember

                                    .ttr_TareaTrab_Id = txtTarea.Tag


                                    .per_Id = mDetalle.Cells("per_Id").Tag
                                    '.dgt_EsTiempoDoble = mDetalle.Cells("dgt_EsTiempoDoble").Value
                                    .dgt_Fecha = CDate(dateFechaInicio.Text) 'dateFechaInicio.Value = mDetalle.Cells("dgt_Fecha").Value
                                    .dgt_HoraDesde = CDbl(txtHoraInicio.Text)
                                    .dgt_HoraHasta = CDbl(txtHoraFin.Text)
                                    .dgt_HoraTotales = CDbl((Val(mDetalle.Cells("dgt_HoraTotales").Value) / dSumaCargas) * dCarga)
                                    .dgt_Factor = CDbl(mDetalle.Cells("dgt_Factor").Value)
                                    .dgt_Bonificacion = CDbl((Val(mDetalle.Cells("dgt_Bonificacion").Value) / dSumaCargas) * dCarga)
                                    .dgt_Descuento = CDbl((Val(mDetalle.Cells("dgt_Descuento").Value) / dSumaCargas) * dCarga)
                                    .dgt_Refrigerio = CDbl((Val(mDetalle.Cells("dgt_Refrigerio").Value) / dSumaCargas) * dCarga)
                                    .dgt_Fraccion = CDbl(mDetalle.Cells("dgt_Fraccion").Value)
                                    .dgt_CantidadLadrillo = 0.0 'CDbl(mDetalle.Cells("dgt_CantidadLadrillo").Value)
                                    .dgt_Mesas = 0.0 'CDbl(mDetalle.Cells("dgt_Mesas").Value)
                                    .dgt_Alas = 0.0 'CDbl(mDetalle.Cells("dgt_Alas").Value)
                                    .dgt_Observaciones = mDetalle.Cells("dgt_Observaciones").Value
                                    .dgt_Item = Nothing 'mDetalle.Cells("dgt_Item").Value

                                    .dgt_NumPersonas = 0 ' CDbl(mDetalle.Cells("dgt_NumPersonas").Value)

                                    .tit_TipTarea_Id = lblTipoArea.Tag

                                    .dgt_BonificacionGrupo = CDbl(mDetalle.Cells("dgt_Bonificacion").Value)
                                    .dgt_DescuentoGrupo = CDbl(mDetalle.Cells("dgt_Descuento").Value)
                                    .dgt_RefrigerioGrupo = CDbl(mDetalle.Cells("dgt_Refrigerio").Value)
                                    .dgt_FraccionGrupo = CDbl(mDetalle.Cells("dgt_Fraccion").Value)
                                    .dgt_HoraTotalesGrupo = CDbl(mDetalle.Cells("dgt_HoraTotales").Value)



                                    If Not (cboArea.SelectedValue Is Nothing Or cboArea.SelectedValue = "") Then
                                        .art_AreaTrab_Id = cboArea.SelectedValue
                                    Else
                                        .art_AreaTrab_Id = Nothing
                                    End If


                                    .grt_NumeroProd = txtNumero.Text
                                    .prd_Periodo_id = txtPeriodo.Text
                                    .Usu_Id = SessionServer.UserId 'mDetalle.Cells("Usu_Id").Value
                                    .dgt_FECGRAB = Now 'mDetalle.Cells("dgt_FecGrab").Value

                                    If Not (iProduccion <= 0) Then
                                        .pro_Id = iProduccion
                                    Else
                                        .pro_Id = Nothing
                                    End If

                                    If Not (iPlanta <= 0) Then
                                        .Pla_id = iPlanta
                                    Else
                                        .Pla_id = Nothing
                                    End If

                                    .MarkAsAdded()

                                End With
                                oGrupoTrabajo.DetalleGrupoTrabajo.Add(nOSD)

                            Next
                            x_Cuenta += 1
                        End While

                        BCGrupoTrabajo.MaintenanceTarea(oGrupoTrabajo)
                        MsgBox("Datos Guardados")
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
        Sub GuardarPorNumeroProduccion()
            Dim iPlanta, iProduccion As Integer
            Dim dSumaCargas As Double
            Dim dCarga As Double = 0
            Dim x_Cuenta As Integer = 0
            If (validar()) Then
                Try
                    If oGrupoTrabajo IsNot Nothing Then
                        dgvDetalle.EndEdit()

                        oGrupoTrabajo.grt_Fecha = CDate(dateFechaInicio.Text)

                        oGrupoTrabajo.prd_Periodo_id = txtPeriodo.Text
                        oGrupoTrabajo.grt_NumeroProd = txtNumero.Text

                        oGrupoTrabajo.grt_observaciones = txtObservaciones.Text
                        oGrupoTrabajo.Usu_Id = SessionServer.UserId
                        oGrupoTrabajo.grt_FECGRAB = Now

                        dSumaCargas = SumarCargaProduccion()
                        oGrupoTrabajo.grt_EsTareo = True
                        oGrupoTrabajo.grt_Factor = Val(txtTarifa.Text)
                        Dim z As Integer
                        While (oGrupoTrabajo.DetalleGrupoTrabajo.Count > z)
                            oGrupoTrabajo.DetalleGrupoTrabajo(z).MarkAsDeleted()
                            z += 1
                        End While




                        While (dgvProduccion.Rows.Count > x_Cuenta)

                            iPlanta = dgvProduccion.Rows(x_Cuenta).Cells("pla_id").Value
                            iProduccion = dgvProduccion.Rows(x_Cuenta).Cells("por_Id").Tag
                            dCarga = Val(dgvProduccion.Rows(x_Cuenta).Cells("Carga").Value)

                            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                                Dim nOSD As New DetalleGrupoTrabajo
                                With nOSD

                                    '.ttr_TareaTrab_Id = mDetalle.Cells("ttr_TareaTrab_Id").Value  ' CType(mDetalle.Cells("ttr_TareaTrab_Id").Value, DataGridViewComboBoxColumn).ValueMember

                                    .ttr_TareaTrab_Id = txtTarea.Tag

                                    .per_Id = mDetalle.Cells("per_Id").Tag
                                    '.dgt_EsTiempoDoble = mDetalle.Cells("dgt_EsTiempoDoble").Value
                                    .dgt_Fecha = CDate(dateFechaInicio.Text) 'dateFechaInicio.Value = mDetalle.Cells("dgt_Fecha").Value
                                    .dgt_HoraDesde = CDbl(txtHoraInicio.Text)
                                    .dgt_HoraHasta = CDbl(txtHoraFin.Text)
                                    .dgt_HoraTotales = CDbl((Val(mDetalle.Cells("dgt_HoraTotales").Value) / dgvProduccion.Rows.Count))
                                    .dgt_Factor = CDbl(mDetalle.Cells("dgt_Factor").Value)
                                    .dgt_Bonificacion = CDbl(CDbl(mDetalle.Cells("dgt_Bonificacion").Value) / CDbl(dgvProduccion.Rows.Count))
                                    .dgt_Descuento = CDbl(CDbl(mDetalle.Cells("dgt_Descuento").Value) / CDbl(dgvProduccion.Rows.Count))
                                    .dgt_Refrigerio = CDbl(CDbl(mDetalle.Cells("dgt_Refrigerio").Value) / CDbl(dgvProduccion.Rows.Count))
                                    .dgt_Fraccion = CDbl(mDetalle.Cells("dgt_Fraccion").Value)
                                    .dgt_CantidadLadrillo = 0.0 'CDbl(mDetalle.Cells("dgt_CantidadLadrillo").Value)
                                    .dgt_Mesas = 0.0 'CDbl(mDetalle.Cells("dgt_Mesas").Value)
                                    .dgt_Alas = 0.0 'CDbl(mDetalle.Cells("dgt_Alas").Value)
                                    .dgt_Observaciones = mDetalle.Cells("dgt_Observaciones").Value
                                    .dgt_Item = Nothing 'mDetalle.Cells("dgt_Item").Value

                                    .dgt_NumPersonas = 0 ' CDbl(mDetalle.Cells("dgt_NumPersonas").Value)

                                    .tit_TipTarea_Id = lblTipoArea.Tag

                                    If Not (cboArea.SelectedValue Is Nothing Or cboArea.SelectedValue = "") Then
                                        .art_AreaTrab_Id = cboArea.SelectedValue
                                    Else
                                        .art_AreaTrab_Id = Nothing
                                    End If

                                    .dgt_BonificacionGrupo = CDbl(mDetalle.Cells("dgt_Bonificacion").Value)
                                    .dgt_DescuentoGrupo = CDbl(mDetalle.Cells("dgt_Descuento").Value)
                                    .dgt_RefrigerioGrupo = CDbl(mDetalle.Cells("dgt_Refrigerio").Value)
                                    .dgt_FraccionGrupo = CDbl(mDetalle.Cells("dgt_Fraccion").Value)
                                    .dgt_HoraTotalesGrupo = CDbl(mDetalle.Cells("dgt_HoraTotales").Value)

                                    .grt_NumeroProd = txtNumero.Text
                                    .prd_Periodo_id = txtPeriodo.Text
                                    .Usu_Id = SessionServer.UserId 'mDetalle.Cells("Usu_Id").Value
                                    .dgt_FECGRAB = Now 'mDetalle.Cells("dgt_FecGrab").Value

                                    If Not (iProduccion <= 0) Then
                                        .pro_Id = iProduccion
                                    Else
                                        .pro_Id = Nothing
                                    End If

                                    If Not (iPlanta <= 0) Then
                                        .Pla_id = iPlanta
                                    Else
                                        .Pla_id = Nothing
                                    End If

                                    .MarkAsAdded()

                                End With
                                oGrupoTrabajo.DetalleGrupoTrabajo.Add(nOSD)

                            Next
                            x_Cuenta += 1
                        End While

                        BCGrupoTrabajo.MaintenanceTarea(oGrupoTrabajo)
                        MsgBox("Datos Guardados")
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

        Function SumarCargaProduccion()
            Dim x As Integer = 0
            Dim dSuma As Double = 0

            While (dgvProduccion.RowCount > x)
                dSuma += Val(dgvProduccion.Rows(x).Cells("Carga").Value)
                x += 1
            End While

            Return dSuma

        End Function
        Private Sub dgvProduccion_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProduccion.CellClick
            Try
                Select Case dgvProduccion.Columns(e.ColumnIndex).Name
                    Case "por_Id"
                        Dim frm = Me.ContainerService.Resolve(Of frmBuscarFecha)()
                        frm.campo1 = dateFechaInicio.Value
                        frm.BusquedaAutomatica = True
                        frm.inicio(Constants.BuscadoresNames.GrupoTrabajoConteoCargaProduccion)

                        If (frm.ShowDialog = DialogResult.OK) Then

                            With frm.dgbRegistro.SelectedRows(0)

                                dgvProduccion.Rows(e.RowIndex).Cells("Produccion").Tag = .Cells("Produccion").Value
                                dgvProduccion.Rows(e.RowIndex).Cells("Produccion").Value = .Cells("Ladrillo").Value
                                dgvProduccion.Rows(e.RowIndex).Cells("por_Id").Tag = .Cells("ID").Value
                                dgvProduccion.Rows(e.RowIndex).Cells("pla_id").Tag = .Cells("Codigo_planta").Value
                                dgvProduccion.Rows(e.RowIndex).Cells("pla_id").Value = .Cells("Codigo_planta").Value
                                dgvProduccion.Rows(e.RowIndex).Cells("Conteo").Value = .Cells("Conteo").Value
                                dgvProduccion.Rows(e.RowIndex).Cells("Carga").Value = .Cells("Carga").Value
                                dgvProduccion.Rows(e.RowIndex).Cells("Descripcion").Value = .Cells("Ladrillo").Value

                            End With
                        End If
                End Select


            Catch ex As Exception

            End Try

        End Sub


        Private Sub txtHoraInicio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHoraInicio.TextChanged
            repartirTarifa()


        End Sub

        Private Sub txtHoraFin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHoraFin.TextChanged
            repartirTarifa()
        End Sub

        Private Sub dgvDetalle_CellStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellStateChangedEventArgs) Handles dgvDetalle.CellStateChanged


            If (Not e.Cell.Value Is Nothing) Then
                Select Case dgvDetalle.Columns(e.Cell.ColumnIndex).Name

                    Case "Codigo"
                        Try
                            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                            frm.inicio(Constants.BuscadoresNames.DatosLaborales)
                            frm.llenarCombo()

                            frm.cboBuscar.SelectedIndex = 1
                            frm.txtBuscar.Text = e.Cell.Value
                            frm.cargarDatos()

                            If (frm.dgbRegistro.RowCount > 0) Then
                                With frm.dgbRegistro.Rows(0)
                                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("Codigo").Tag = .Cells(0).Value
                                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("Codigo").Value = .Cells(1).Value
                                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("Persona").Value = .Cells(2).Value
                                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("per_Id").Tag = .Cells(0).Value

                                End With


                            Else
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("Codigo").Tag = Nothing
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("Codigo").Value = Nothing
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("Persona").Value = Nothing
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("per_Id").Tag = Nothing

                            End If
                        Catch ex As Exception
                            dgvDetalle.Rows(e.Cell.RowIndex).Cells("Codigo").Tag = Nothing
                            dgvDetalle.Rows(e.Cell.RowIndex).Cells("Codigo").Value = Nothing
                            dgvDetalle.Rows(e.Cell.RowIndex).Cells("Persona").Value = Nothing
                            dgvDetalle.Rows(e.Cell.RowIndex).Cells("per_Id").Tag = Nothing
                        End Try
                End Select
            End If

        End Sub

        Private Sub dateFechaInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateFechaInicio.ValueChanged
            txtPeriodo.Text = dateFechaInicio.Value.Year.ToString & dateFechaInicio.Value.ToString("MM")
        End Sub

        Private Sub dgvDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
            ' solo puede copiar y pegar en  las siguientes columnas 
            Try
                If (dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "Codigo" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_Factor" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_Bonificacion" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_Descuento" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_Refrigerio" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_Fraccion" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_Observaciones") Then


                    Try
                        If ((e.Control And e.KeyCode = Keys.C)) Then
                            Clipboard.SetText(dgvDetalle.SelectedCells(0).Value)

                        End If
                    Catch ex As Exception
                    End Try

                    Try
                        If ((e.Control And e.KeyCode = Keys.V)) Then
                            dgvDetalle.SelectedCells(0).Value = Clipboard.GetText()
                            If (dgvDetalle.SelectedCells(0).RowIndex < dgvDetalle.Rows.Count - 1) Then
                                dgvDetalle.Rows(dgvDetalle.SelectedCells(0).RowIndex + 1).Cells(dgvDetalle.SelectedCells(0).ColumnIndex).Selected = True


                                Try
                                    calculoCeldas(dgvDetalle.SelectedCells(0).RowIndex - 1)
                                Catch exe As Exception

                                End Try

                            End If

                        End If
                    Catch ex As Exception
                    End Try

                End If
            Catch ex As Exception

            End Try
        End Sub
    End Class

End Namespace