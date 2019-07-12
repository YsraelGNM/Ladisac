
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports System.Globalization

Namespace Ladisac.Planillas.Views
    Public Class frmGrupoTrabajoHora

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCDatosTrabajadorJudicial As Ladisac.BL.IBCDatosTrabajadorJudicial
        <Dependency()> _
        Public Property BCPlanta As Ladisac.BL.IBCPlanta
        <Dependency()> _
        Public Property BCAreaTrabajos As BL.IBCAreaTrabajos
        <Dependency()> _
        Public Property BCGrupoTrabajo As Ladisac.BL.IBCGrupoTrabajo

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        <Dependency()> _
        Public Property BCMarcacion As Ladisac.BL.IBCMarcacion

        Protected oGrupoTrabajo As New BE.GrupoTrabajo
        Dim sArticulo_idProduccion As String

        Private Sub suma()
            Dim x As Integer
            Dim dSuma As Double = 0
            While (dgvDetalle.RowCount > x)
                If (dgvDetalle.Rows(x).Visible) Then
                    Try
                        dSuma += Val(dgvDetalle.Rows(x).Cells("dgt_HoraTotales").Value)
                    Catch ex As Exception

                    End Try

                End If

                x += 1
            End While

            txtSuma.Text = dSuma.ToString()
        End Sub
        Function ValidarCeldasAlGuardar() As Boolean
            Dim x As Integer = 0
            Dim resul As Boolean = True
            ErrorProvider1.SetError(dgvDetalle, "")

            While dgvDetalle.RowCount > x

                If Not (IsNumeric(dgvDetalle.Rows(x).Cells("dgt_HoraTotales").Value)) Then
                    ErrorProvider1.SetError(dgvDetalle, "<< Total de Horas >> debe ser numerico ")
                    dgvDetalle.CurrentCell = dgvDetalle.Rows(x).Cells(2)
                    resul = False
                    Exit While
                End If
                If (Val(dgvDetalle.Rows(x).Cells("dgt_HoraTotales").Value) <= 0) Then
                    ErrorProvider1.SetError(dgvDetalle, "<< Total de Horas >> debe ser  mayor de 0.00 ")
                    dgvDetalle.CurrentCell = dgvDetalle.Rows(x).Cells(2)
                    resul = False
                    Exit While
                End If
                If (Val(dgvDetalle.Rows(x).Cells("dgt_HoraTotales").Value) > 22) Then
                    ErrorProvider1.SetError(dgvDetalle, "<< Total de Horas >> debe ser  menor de 22.00 Horas ")
                    dgvDetalle.CurrentCell = dgvDetalle.Rows(x).Cells(2)
                    resul = False
                    Exit While
                End If

                If (dgvDetalle.Rows(x).Cells("Persona").Value = "") Then
                    ErrorProvider1.SetError(dgvDetalle, "<< Persona >>  no puede estar vacio ")
                    dgvDetalle.CurrentCell = dgvDetalle.Rows(x).Cells(2)
                    resul = False
                    Exit While
                End If

                x += 1
            End While
            Return resul

        End Function
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtPeriodo.Text.Trim = "") Then
                ErrorProvider1.SetError(txtPeriodo, "Periodo")
                result = False
            Else
                ErrorProvider1.SetError(txtPeriodo, Nothing)
            End If

            If (chkEsTareo.Checked) Then
                ErrorProvider1.SetError(chkEsTareo, "Estos datos se modifican por el formulario << Trabajo Tarea >> ")
                result = False
            Else
                ErrorProvider1.SetError(chkEsTareo, Nothing)
            End If

            'If (dgvDetalle.Rows.Count <= 0) Then
            '    ErrorProvider1.SetError(txtObservaciones, "Horas")
            '    result = False
            'Else
            '    ErrorProvider1.SetError(txtObservaciones, Nothing)
            'End If


            Return result
        End Function
        Private Sub limpiar()

            ' txtPeriodo.Text = ""
            txtNumero.Text = ""
            chkEsTareo.Checked = False
            dgvDetalle.Rows.Clear()

        End Sub
        Sub cargarMAEstiloGrilla()

            planta()
            areaTrabajo()

        End Sub
        Sub planta()
            Try
                Dim cboPlanta As New DataGridViewComboBoxColumn
                cboPlanta.HeaderText = dgvDetalle.Columns(7).HeaderText
                cboPlanta.Name = dgvDetalle.Columns(7).Name
                Dim result = BCPlanta.PlantaGrupoTrabajoQuery(0, Nothing)
                Dim ds As New DataSet
                Dim sr As New StringReader(result)
                ds.ReadXml(sr)
                cboPlanta.DataSource = ds.Tables(0)
                cboPlanta.DisplayMember = "Descripcion"
                cboPlanta.ValueMember = "Codigo"
                dgvDetalle.Columns.RemoveAt(7)
                dgvDetalle.Columns.Insert(7, cboPlanta)
                dgvDetalle.Columns("Pla_id").Width = 40
            Catch ex As Exception
                MsgBox("No se Pudo Cargar los Datos de Planta")
            End Try

        End Sub
        Sub LlenarMarcacion(ByVal Fecha As Date, ByVal idpersona As String)
            Try
                dgvMarcacion.DataSource = BCMarcacion.SPMarcacionColtronSelectXML(idpersona, Fecha)
                If (dgvMarcacion.Rows.Count <= 0) Then
                    lblPersonas.Text = Nothing
                End If
            Catch ex As Exception
                lblPersonas.Text = Nothing
                dgvMarcacion.DataSource = Nothing

            End Try
        End Sub
       

        Sub areaTrabajo()
            Try
                Dim cboArea As New DataGridViewComboBoxColumn
                cboArea.HeaderText = dgvDetalle.Columns(8).HeaderText
                cboArea.Name = dgvDetalle.Columns(8).Name
                Dim result = BCAreaTrabajos.AreaTrabajosQuery(Nothing, Nothing, 0)
                Dim ds As New DataSet
                Dim sr As New StringReader(result)
                ds.ReadXml(sr)
                cboArea.DataSource = ds.Tables(0)
                cboArea.DisplayMember = "Descripcion"
                cboArea.ValueMember = "ID"

                ControlFiltroTrareaHoras1.cboAreaFiltro.DataSource = ds.Tables(0)
                ControlFiltroTrareaHoras1.cboAreaFiltro.DisplayMember = "Descripcion"
                ControlFiltroTrareaHoras1.cboAreaFiltro.ValueMember = "ID"

                dgvDetalle.Columns.RemoveAt(8)
                dgvDetalle.Columns.Insert(8, cboArea)
            Catch ex As Exception
                MsgBox("no se pudo cargar las Areas de Trabajo")
            End Try
        End Sub
        Sub cargar(ByVal periodo As String, ByVal numero As String)
            Try

           

                limpiar()
                oGrupoTrabajo = BCGrupoTrabajo.GrupoTrabajoSeek(numero, periodo)
                oGrupoTrabajo.MarkAsModified()
                dateFechaInicio.Value = oGrupoTrabajo.grt_Fecha
                chkEsTareo.Checked = oGrupoTrabajo.grt_EsTareo

                txtPeriodo.Text = oGrupoTrabajo.prd_Periodo_id

                txtNumero.Text = oGrupoTrabajo.grt_NumeroProd

                txtObservaciones.Text = oGrupoTrabajo.grt_observaciones

                Dim oTAble As New DataTable

                oTAble = BCGrupoTrabajo.SPDetalleGrupoTrabajoMaintenanceSelect(oGrupoTrabajo.prd_Periodo_id, oGrupoTrabajo.grt_NumeroProd)
                Dim x As Integer = 0
                'For Each mItem In oGrupoTrabajo.DetalleGrupoTrabajo
                While x < oTAble.Rows.Count


                    With oTAble.Rows(x)
                        Dim nRow As New DataGridViewRow
                        dgvDetalle.Rows.Add(nRow)

                        Dim oNewDetalleGrupo As New BE.DetalleGrupoTrabajo
                        oNewDetalleGrupo.prd_Periodo_id = .Item("prd_Periodo_id")
                        oNewDetalleGrupo.grt_NumeroProd = .Item("grt_NumeroProd")
                        oNewDetalleGrupo.dgt_Item = .Item("dgt_Item")
                        oNewDetalleGrupo.dgt_Descuento = .Item("dgt_Descuento")

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
                        oNewDetalleGrupo.dgt_Bonificacion = .Item("dgt_Bonificacion")
                        oNewDetalleGrupo.dgt_Refrigerio = .Item("dgt_Refrigerio")
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
                            oNewDetalleGrupo.ttr_TareaTrab_Id = .Item("ttr_TareaTrab_Id")
                        Else
                            oNewDetalleGrupo.tit_TipTarea_Id = Nothing
                        End If
                        If Not (IsDBNull(.Item("art_AreaTrab_Id"))) Then
                            oNewDetalleGrupo.art_AreaTrab_Id = .Item("art_AreaTrab_Id")
                        Else
                            oNewDetalleGrupo.art_AreaTrab_Id = Nothing
                        End If

                        ' oNewDetalleGrupo.Usu_Id = .Item("")
                        ' oNewDetalleGrupo.dgt_FecGrab = .Item("")
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


                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = .Item("Codigo")

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_Id").Tag = oNewDetalleGrupo.per_Id
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Persona").Value = .Item("Nombre")

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_HoraDesde").Value = Math.Round(CDec(oNewDetalleGrupo.dgt_HoraDesde), 2)
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_HoraHasta").Value = Math.Round(CDec(oNewDetalleGrupo.dgt_HoraHasta), 2)
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_HoraTotales").Value = oNewDetalleGrupo.dgt_HoraTotales
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Factor").Value = oNewDetalleGrupo.dgt_Factor
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Bonificacion").Value = oNewDetalleGrupo.dgt_Bonificacion
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Descuento").Value = oNewDetalleGrupo.dgt_Descuento

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Refrigerio").Value = oNewDetalleGrupo.dgt_Refrigerio
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Fraccion").Value = oNewDetalleGrupo.dgt_Fraccion
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_CantidadLadrillo").Value = oNewDetalleGrupo.dgt_CantidadLadrillo
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Mesas").Value = oNewDetalleGrupo.dgt_Mesas
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Alas").Value = oNewDetalleGrupo.dgt_Alas
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Observaciones").Value = oNewDetalleGrupo.dgt_Observaciones

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Item").Value = oNewDetalleGrupo.dgt_Item
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_Item").Tag = oNewDetalleGrupo

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_NumPersonas").Value = CInt(oNewDetalleGrupo.dgt_NumPersonas)

                        If Not (IsDBNull(oNewDetalleGrupo.art_AreaTrab_Id) OrElse oNewDetalleGrupo.art_AreaTrab_Id = "") Then
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("art_AreaTrab_Id").Value = oNewDetalleGrupo.art_AreaTrab_Id
                        End If

                        If Not (IsDBNull(oNewDetalleGrupo.tit_TipTarea_Id) OrElse oNewDetalleGrupo.tit_TipTarea_Id = "") Then
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tit_TipTarea_Id").Tag = oNewDetalleGrupo.tit_TipTarea_Id
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tit_TipTarea_Id").Value = oNewDetalleGrupo.tit_TipTarea_Id
                        End If
                        If Not (IsDBNull(oNewDetalleGrupo.art_AreaTrab_Id) OrElse oNewDetalleGrupo.art_AreaTrab_Id = "") Then
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("art_AreaTrab_Id").Value = oNewDetalleGrupo.art_AreaTrab_Id
                        End If


                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Tarea").Value = IIf(IsNothing(.Item("ttr_Tarea")), "", .Item("ttr_Tarea"))
                        '  dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("pro_Id").Value = mItem.pro_Id

                        If Not (IsDBNull(oNewDetalleGrupo.pro_Id) OrElse Val(oNewDetalleGrupo.pro_Id) <= 0) Then
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("pro_Id").Tag = oNewDetalleGrupo.pro_Id


                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Produccion").Value = oNewDetalleGrupo.pro_Id
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Descripcion").Value = .Item("ART_DESCRIPCION")
                        End If

                        If Not (IsDBNull(oNewDetalleGrupo.Pla_id) OrElse Val(oNewDetalleGrupo.Pla_id) <= 0) Then
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Pla_id").Value = oNewDetalleGrupo.Pla_id.ToString
                        End If

                        If Not (IsDBNull(oNewDetalleGrupo.ttr_TareaTrab_Id) OrElse oNewDetalleGrupo.ttr_TareaTrab_Id = "") Then
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ttr_TareaTrab_Id").Value = oNewDetalleGrupo.ttr_TareaTrab_Id
                        End If

                        '  dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("pro_Id").Tag = mItem.pro_Id
                        '  dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Pla_id").Value = mItem.Pla_id

                        If Not (IsDBNull(oNewDetalleGrupo.tit_TipTarea_Id) OrElse oNewDetalleGrupo.tit_TipTarea_Id = "") Then
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tit_TipTarea_Id").Tag = oNewDetalleGrupo.tit_TipTarea_Id
                        End If
                        oGrupoTrabajo.DetalleGrupoTrabajo.Add(oNewDetalleGrupo)
                    End With
                    x += 1
                End While
                suma()
                ' ir la aultima fila
                If (dgvDetalle.Rows.Count > 0) Then

                    dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(0)
                End If

            Catch ex As Exception
                MsgBox("Error al Cargar los datos:" & ex.Message)
            End Try
        End Sub

        Public Overrides Sub OnManAgregarFilaGrid()

            Dim x As Integer = 0
            Dim y As Integer = 0

            Dim iRow As Integer = 0

            If (dgvDetalle.SelectedRows.Count > 0) Then

                x = dgvDetalle.SelectedRows.Count - 1
                While (x >= 0)
                    dgvDetalle.Rows.Add()
                    y = 1
                    While (dgvDetalle.Columns.Count > y)

                        Try
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Value = dgvDetalle.SelectedRows(x).Cells(y).Value
                        Catch ex As Exception
                        End Try

                        Try
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Tag = dgvDetalle.SelectedRows(x).Cells(y).Tag
                        Catch ex As Exception
                        End Try

                        y += 1
                    End While

                    x -= 1
                End While
            Else
                dgvDetalle.Rows.Add()

                iRow = dgvDetalle.RowCount - 1

                dgvDetalle.Rows(iRow).Cells("dgt_HoraDesde").Value = "0.00"
                dgvDetalle.Rows(iRow).Cells("dgt_HoraHasta").Value = "0.00"
                dgvDetalle.Rows(iRow).Cells("dgt_NumPersonas").Value = 1
                dgvDetalle.Rows(iRow).Cells("dgt_CantidadLadrillo").Value = 0
                dgvDetalle.Rows(iRow).Cells("dgt_Fraccion").Value = 1
                dgvDetalle.Rows(iRow).Cells("dgt_Refrigerio").Value = 0
                dgvDetalle.Rows(iRow).Cells("dgt_Bonificacion").Value = 0
                dgvDetalle.Rows(iRow).Cells("dgt_Descuento").Value = 0

                dgvDetalle.Rows(iRow).Cells("dgt_Mesas").Value = 0
                dgvDetalle.Rows(iRow).Cells("dgt_Alas").Value = 0
                dgvDetalle.Rows(iRow).Cells("dgt_HoraTotales").Value = 0

            End If
            suma()
            ' ir la aultima fila
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(2)
        End Sub
        Public Overrides Sub OnManQuitarFilaGrid()

            If (dgvDetalle.SelectedRows.Count > 0) Then
                If (MsgBox("Se Eliminara los Registros ¿Continuar?", vbYesNo) = vbYes) Then


                    For Each mDetalle As DataGridViewRow In dgvDetalle.SelectedRows
                        If Not mDetalle.Cells("dgt_Item").Value Is Nothing Then
                            With CType(mDetalle.Cells("dgt_Item").Tag, BE.DetalleGrupoTrabajo)
                                .MarkAsDeleted()
                            End With
                        End If
                        dgvDetalle.Rows.Remove(mDetalle)
                    Next



                End If
           
            End If

           
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarFecha)()
            frm.inicio(Constants.BuscadoresNames.GrupoTrabajoHoras)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value, frm.dgbRegistro.CurrentRow.Cells(1).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub
      

        Public Overrides Sub OnManGuardar()
            If (validar() And ValidarCeldasAlGuardar()) Then
                dgvDetalle.EndEdit()
                Try
                    If (txtNumero.Text.Trim = "") Then
                        oGrupoTrabajo = New BE.GrupoTrabajo
                        oGrupoTrabajo.MarkAsAdded()

                    End If


                    If oGrupoTrabajo IsNot Nothing Then
                        dgvDetalle.EndEdit()

                        oGrupoTrabajo.grt_Fecha = CDate(dateFechaInicio.Text)
                        oGrupoTrabajo.prd_Periodo_id = txtPeriodo.Text
                        oGrupoTrabajo.grt_NumeroProd = txtNumero.Text

                        oGrupoTrabajo.grt_observaciones = txtObservaciones.Text
                        oGrupoTrabajo.Usu_Id = SessionServer.UserId
                        oGrupoTrabajo.grt_FECGRAB = Now
                        oGrupoTrabajo.grt_EsTareo = False


                        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                            If Not mDetalle.Cells("dgt_Item").Value Is Nothing Then
                                With CType(mDetalle.Cells("dgt_Item").Tag, BE.DetalleGrupoTrabajo)

                                    If Not (mDetalle.Cells("ttr_TareaTrab_Id").Value Is Nothing OrElse Val(mDetalle.Cells("ttr_TareaTrab_Id").Value) <= 0) Then
                                        .ttr_TareaTrab_Id = (mDetalle.Cells("ttr_TareaTrab_Id").Value)
                                    Else
                                        .ttr_TareaTrab_Id = Nothing
                                    End If


                                    .per_Id = mDetalle.Cells("per_Id").Tag
                                    '.dgt_EsTiempoDoble = mDetalle.Cells("dgt_EsTiempoDoble").Value
                                    .dgt_Fecha = dateFechaInicio.Text 'dateFechaInicio.Value = mDetalle.Cells("dgt_Fecha").Value
                                    .dgt_HoraDesde = CDbl(mDetalle.Cells("dgt_HoraDesde").Value)
                                    .dgt_HoraHasta = CDbl(mDetalle.Cells("dgt_HoraHasta").Value)
                                    .dgt_HoraTotales = CDbl(mDetalle.Cells("dgt_HoraTotales").Value)
                                    .dgt_Factor = CDbl(mDetalle.Cells("dgt_Factor").Value)
                                    .dgt_Bonificacion = CDbl(mDetalle.Cells("dgt_Bonificacion").Value)
                                    .dgt_Descuento = CDbl(mDetalle.Cells("dgt_Descuento").Value)
                                    .dgt_Refrigerio = CDbl(mDetalle.Cells("dgt_Refrigerio").Value)
                                    .dgt_Fraccion = CDbl(mDetalle.Cells("dgt_Fraccion").Value)
                                    .dgt_CantidadLadrillo = CDbl(mDetalle.Cells("dgt_CantidadLadrillo").Value)
                                    .dgt_Mesas = CDbl(mDetalle.Cells("dgt_Mesas").Value)
                                    .dgt_Alas = CDbl(mDetalle.Cells("dgt_Alas").Value)
                                    .dgt_Observaciones = mDetalle.Cells("dgt_Observaciones").Value
                                    .dgt_Item = mDetalle.Cells("dgt_Item").Value

                                    .dgt_FraccionGrupo = CDec(0)
                                    .dgt_HoraTotalesGrupo = CDec(0)
                                    .dgt_DescuentoGrupo = CDec(0)
                                    .dgt_RefrigerioGrupo = CDec(0)
                                    .dgt_BonificacionGrupo = CDec(0)

                                    .dgt_NumPersonas = CDbl(mDetalle.Cells("dgt_NumPersonas").Value)


                                    '.tit_TipTarea_Id = mDetalle.Cells("tit_TipTarea_Id").Tag
                                    If Not (mDetalle.Cells("tit_TipTarea_Id").Tag Is Nothing OrElse Val(mDetalle.Cells("tit_TipTarea_Id").Tag) <= 0) Then
                                        .tit_TipTarea_Id = (mDetalle.Cells("tit_TipTarea_Id").Tag)
                                    Else
                                        .tit_TipTarea_Id = Nothing
                                    End If

                                    ' .art_AreaTrab_Id = mDetalle.Cells("art_AreaTrab_Id").Value
                                    If Not (mDetalle.Cells("art_AreaTrab_Id").Value Is Nothing OrElse Val(mDetalle.Cells("art_AreaTrab_Id").Value) <= 0) Then
                                        .art_AreaTrab_Id = (mDetalle.Cells("art_AreaTrab_Id").Value)
                                    Else
                                        .art_AreaTrab_Id = Nothing
                                    End If

                                    .grt_NumeroProd = txtNumero.Text
                                    .prd_Periodo_id = txtPeriodo.Text
                                    .Usu_Id = SessionServer.UserId 'mDetalle.Cells("Usu_Id").Value
                                    .dgt_FECGRAB = Now 'mDetalle.Cells("dgt_FecGrab").Value


                                    If Not (mDetalle.Cells("pro_Id").Tag Is Nothing OrElse Val(mDetalle.Cells("pro_Id").Tag) <= 0) Then
                                        .pro_Id = CInt(mDetalle.Cells("pro_Id").Tag)
                                    Else
                                        .pro_Id = Nothing
                                    End If

                                    If Not (mDetalle.Cells("Pla_id").Value Is Nothing OrElse Val(mDetalle.Cells("Pla_id").Value) <= 0) Then
                                        .Pla_id = CInt(mDetalle.Cells("Pla_id").Value)
                                    Else
                                        .Pla_id = Nothing
                                    End If


                                    .MarkAsModified()

                                End With
                            Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                                Dim nOSD As New DetalleGrupoTrabajo
                                With nOSD

                                    '.ttr_TareaTrab_Id = mDetalle.Cells("ttr_TareaTrab_Id").Value  ' CType(mDetalle.Cells("ttr_TareaTrab_Id").Value, DataGridViewComboBoxColumn).ValueMember
                                    If Not (mDetalle.Cells("ttr_TareaTrab_Id").Value Is Nothing OrElse Val(mDetalle.Cells("ttr_TareaTrab_Id").Value) <= 0) Then
                                        .ttr_TareaTrab_Id = (mDetalle.Cells("ttr_TareaTrab_Id").Value)
                                    Else
                                        .ttr_TareaTrab_Id = Nothing
                                    End If


                                    .per_Id = mDetalle.Cells("per_Id").Tag
                                    '.dgt_EsTiempoDoble = mDetalle.Cells("dgt_EsTiempoDoble").Value
                                    .dgt_Fecha = CDate(dateFechaInicio.Text) 'dateFechaInicio.Value = mDetalle.Cells("dgt_Fecha").Value
                                    .dgt_HoraDesde = CDbl(mDetalle.Cells("dgt_HoraDesde").Value)
                                    .dgt_HoraHasta = CDbl(mDetalle.Cells("dgt_HoraHasta").Value)
                                    .dgt_HoraTotales = CDbl(mDetalle.Cells("dgt_HoraTotales").Value)
                                    .dgt_Factor = CDbl(mDetalle.Cells("dgt_Factor").Value)
                                    .dgt_Bonificacion = CDbl(mDetalle.Cells("dgt_Bonificacion").Value)
                                    .dgt_Descuento = CDbl(mDetalle.Cells("dgt_Descuento").Value)
                                    .dgt_Refrigerio = CDbl(mDetalle.Cells("dgt_Refrigerio").Value)
                                    .dgt_Fraccion = CDbl(mDetalle.Cells("dgt_Fraccion").Value)
                                    .dgt_CantidadLadrillo = CDbl(mDetalle.Cells("dgt_CantidadLadrillo").Value)
                                    .dgt_Mesas = CDbl(mDetalle.Cells("dgt_Mesas").Value)
                                    .dgt_Alas = CDbl(mDetalle.Cells("dgt_Alas").Value)
                                    .dgt_Observaciones = mDetalle.Cells("dgt_Observaciones").Value
                                    .dgt_Item = mDetalle.Cells("dgt_Item").Value

                                    .dgt_FraccionGrupo = CDec(0)
                                    .dgt_HoraTotalesGrupo = CDec(0)
                                    .dgt_DescuentoGrupo = CDec(0)
                                    .dgt_RefrigerioGrupo = CDec(0)
                                    .dgt_BonificacionGrupo = CDec(0)


                                    .dgt_NumPersonas = CDbl(mDetalle.Cells("dgt_NumPersonas").Value)

                                    '.tit_TipTarea_Id = mDetalle.Cells("tit_TipTarea_Id").Tag
                                    If Not (mDetalle.Cells("tit_TipTarea_Id").Tag Is Nothing OrElse Val(mDetalle.Cells("tit_TipTarea_Id").Tag) <= 0) Then
                                        .tit_TipTarea_Id = (mDetalle.Cells("tit_TipTarea_Id").Tag)
                                    Else
                                        .tit_TipTarea_Id = Nothing
                                    End If

                                    ' .art_AreaTrab_Id = mDetalle.Cells("art_AreaTrab_Id").Value
                                    If Not (mDetalle.Cells("art_AreaTrab_Id").Value Is Nothing OrElse Val(mDetalle.Cells("art_AreaTrab_Id").Value) <= 0) Then
                                        .art_AreaTrab_Id = (mDetalle.Cells("art_AreaTrab_Id").Value)
                                    Else
                                        .art_AreaTrab_Id = Nothing
                                    End If

                                    .grt_NumeroProd = txtNumero.Text
                                    .prd_Periodo_id = txtPeriodo.Text
                                    .Usu_Id = SessionServer.UserId 'mDetalle.Cells("Usu_Id").Value
                                    .dgt_FECGRAB = Now 'mDetalle.Cells("dgt_FecGrab").Value

                                    If Not (mDetalle.Cells("pro_Id").Tag Is Nothing OrElse Val(mDetalle.Cells("pro_Id").Tag) <= 0) Then
                                        .pro_Id = CInt(mDetalle.Cells("pro_Id").Tag)
                                    Else
                                        .pro_Id = Nothing
                                    End If

                                    If Not (mDetalle.Cells("Pla_id").Value Is Nothing OrElse Val(mDetalle.Cells("Pla_id").Value) <= 0) Then
                                        .Pla_id = CInt(mDetalle.Cells("Pla_id").Value)
                                    Else
                                        .Pla_id = Nothing
                                    End If

                                    .MarkAsAdded()

                                End With
                                oGrupoTrabajo.DetalleGrupoTrabajo.Add(nOSD)
                            End If
                        Next

                        BCGrupoTrabajo.Maintenance(oGrupoTrabajo)
                        MsgBox("Datos Guardados")
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()
                        DeshabilitarElementoGrid()
                    End If
                Catch ex As Exception
                    Try
                        MsgBox(ex.InnerException.Message)
                    Catch exr As Exception
                        MsgBox(ex.Message)
                    End Try

                End Try

            End If

        End Sub

        Public Overrides Sub OnManNuevo()

            limpiar()
            menuNuevo()
            oGrupoTrabajo = New BE.GrupoTrabajo
            oGrupoTrabajo.MarkAsAdded()
            HabilitarElementoGrid()
            Panel1.Enabled = True
            chkEsTareo.Checked = False

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub

        Public Overrides Sub OnManEliminar()

            If (dgvDetalle.SelectedRows.Count > 0) Then

                oGrupoTrabajo.prd_Periodo_id = txtPeriodo.Text
                oGrupoTrabajo.grt_NumeroProd = txtNumero.Text

                If ((MsgBox("Esta Seguro de Relizar los cambio", vbYesNo) = MsgBoxResult.Yes)) Then
                    If (BCGrupoTrabajo.SPGrupoTrabajoDelete(oGrupoTrabajo)) Then
                        MsgBox("Cambios Realizados")
                        dgvDetalle.DataSource = Nothing
                    Else
                        MsgBox("No se pudo realizar los cambios ", vbExclamation)
                    End If
                End If

            Else
                MsgBox("Seleccione un registro ")
            End If
        End Sub

        Public Overrides Sub OnManCancelarEdicion()
            If (MsgBox("Esta Seguro de Cancelar ", vbYesNo) = vbYes) Then

                menuInicio()
                Panel1.Enabled = False
                limpiar()

            End If

        End Sub
        Public Overrides Sub OnManEditar()
            menuEditar()
            Panel1.Enabled = True
            HabilitarElementoGrid()
        End Sub
        Public Overrides Sub OnManDeshacerCambios()

            If (MsgBox("Esta Seguro de Cancelar ", vbYesNo) = vbYes) Then
                menuInicio()
                Panel1.Enabled = False
                limpiar()
            End If

        End Sub

        Private Sub frmGrupoTrabajoHora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()
            cargarMAEstiloGrilla()
            Panel1.Enabled = False

            ControlFiltroTrareaHoras1.Visible = False
            btnAplicar.Visible = False
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
                    Case "pro_Id"
                        sArticulo_idProduccion = ""
                        Dim frm = Me.ContainerService.Resolve(Of frmBuscarFecha)()

                        frm.inicio(Constants.BuscadoresNames.GrupoTrabajoSinFechaProduccion)


                        frm.BusquedaAutomatica = True
                        frm.dateDesde.Value = Today.AddDays(-10)
                        If (frm.ShowDialog = DialogResult.OK) Then

                            With frm.dgbRegistro.SelectedRows(0)
                                dgvDetalle.Rows(e.RowIndex).Cells("Produccion").Tag = .Cells(0).Value
                                dgvDetalle.Rows(e.RowIndex).Cells("Produccion").Value = .Cells(0).Value

                                dgvDetalle.Rows(e.RowIndex).Cells("Produccion").Value = .Cells(1).Value
                                dgvDetalle.Rows(e.RowIndex).Cells("pro_Id").Tag = .Cells(0).Value
                                dgvDetalle.Rows(e.RowIndex).Cells("pla_id").Value = .Cells("Codigo_Planta").Value
                                dgvDetalle.Rows(e.RowIndex).Cells("Descripcion").Value = .Cells("Ladrillo").Value


                            End With
                            'para buscar  la tarea despues de poner la produccion
                            buscarTareaTrabajo(e.RowIndex, True)
                        End If

                    Case "ttr_TareaTrab_Id"

                        buscarTareaTrabajo(e.RowIndex, False)

                End Select
            Catch ex As Exception

            End Try

        End Sub
        Sub buscarTareaTrabajo(ByVal item As Int16, ByVal conProduccion As Boolean)
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            Dim tipoTarea As String
            frm.inicio(Constants.BuscadoresNames.TareaTrabajo)

            'sArticulo_idProduccion

            If (conProduccion) Then
                frm.campo1 = dgvDetalle.Rows(item).Cells("Produccion").Tag
            End If

            frm.cargarDatos()
            If (frm.ShowDialog = DialogResult.OK) Then
                With frm.dgbRegistro.SelectedRows(0)
                    dgvDetalle.Rows(item).Cells("tit_TipTarea_Id").Tag = .Cells(1).Value
                    dgvDetalle.Rows(item).Cells("tit_TipTarea_Id").Value = .Cells(1).Value

                    dgvDetalle.Rows(item).Cells("ttr_TareaTrab_Id").Tag = .Cells(0).Value
                    dgvDetalle.Rows(item).Cells("ttr_TareaTrab_Id").Value = .Cells(0).Value
                    dgvDetalle.Rows(item).Cells("Tarea").Value = .Cells(2).Value
                    dgvDetalle.Rows(item).Cells("dgt_Factor").Value = .Cells(4).Value

                    bloquearCeldas(item, .Cells(1).Value)


                    ' poner valores por default al buscar una tarea 
                    dgvDetalle.Rows(item).Cells("dgt_HoraDesde").Value = "0.00"
                    dgvDetalle.Rows(item).Cells("dgt_HoraHasta").Value = "0.00"
                    dgvDetalle.Rows(item).Cells("dgt_NumPersonas").Value = 1
                    dgvDetalle.Rows(item).Cells("dgt_CantidadLadrillo").Value = 0
                    dgvDetalle.Rows(item).Cells("dgt_Fraccion").Value = 1
                    dgvDetalle.Rows(item).Cells("dgt_Refrigerio").Value = 0
                    dgvDetalle.Rows(item).Cells("dgt_Bonificacion").Value = 0
                    dgvDetalle.Rows(item).Cells("dgt_Descuento").Value = 0

                    dgvDetalle.Rows(item).Cells("dgt_Mesas").Value = 0
                    dgvDetalle.Rows(item).Cells("dgt_Alas").Value = 0
                    dgvDetalle.Rows(item).Cells("dgt_HoraTotales").Value = 0


                End With

                tipoTarea = dgvDetalle.Rows(item).Cells("tit_TipTarea_Id").Tag

                If (tipoTarea = "004") Then

                    dgvDetalle.Rows(item).Cells("Produccion").Tag = Nothing
                    dgvDetalle.Rows(item).Cells("Produccion").Value = Nothing

                    dgvDetalle.Rows(item).Cells("Produccion").Value = Nothing
                    dgvDetalle.Rows(item).Cells("pro_Id").Tag = Nothing
                    dgvDetalle.Rows(item).Cells("pla_id").Value = Nothing

                    dgvDetalle.Rows(item).Cells("Descripcion").Value = Nothing

                End If

            End If


        End Sub
        Sub bloquearCeldas(ByVal iRow As Integer, ByVal tipoTarea As String)

            Try

          
            'dgvDetalle.Rows(iRow).Cells("dgt_Item").Style.BackColor = Color.White

            Select Case tipoTarea
                Case "001"

                    dgvDetalle.Columns("pro_Id").Visible = True
                    dgvDetalle.Columns("Produccion").Visible = True
                    dgvDetalle.Columns("dgt_Factor").Visible = True
                    dgvDetalle.Columns("dgt_HoraDesde").Visible = True
                    dgvDetalle.Columns("dgt_HoraHasta").Visible = True
                    dgvDetalle.Columns("dgt_NumPersonas").Visible = True
                    dgvDetalle.Columns("dgt_CantidadLadrillo").Visible = True
                    dgvDetalle.Columns("dgt_Fraccion").Visible = True
                    dgvDetalle.Columns("dgt_Refrigerio").Visible = True
                    dgvDetalle.Columns("dgt_Bonificacion").Visible = True
                    dgvDetalle.Columns("dgt_Mesas").Visible = False
                    dgvDetalle.Columns("dgt_Alas").Visible = False
                    dgvDetalle.Columns("dgt_HoraTotales").Visible = True


                    'dgvDetalle.Rows(iRow).Cells("pro_Id").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("Produccion").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_Factor").ReadOnly = True
                    'dgvDetalle.Rows(iRow).Cells("dgt_HoraDesde").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_HoraHasta").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_NumPersonas").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_CantidadLadrillo").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_Fraccion").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_Refrigerio").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_Bonificacion").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_Mesas").ReadOnly = True
                    'dgvDetalle.Rows(iRow).Cells("dgt_Alas").ReadOnly = True
                    'dgvDetalle.Rows(iRow).Cells("dgt_HoraTotales").ReadOnly = True

                Case "002"

                    dgvDetalle.Columns("pro_Id").Visible = True
                    dgvDetalle.Columns("Produccion").Visible = True
                    dgvDetalle.Columns("dgt_Factor").Visible = True
                    dgvDetalle.Columns("dgt_HoraDesde").Visible = True
                    dgvDetalle.Columns("dgt_HoraHasta").Visible = True
                    dgvDetalle.Columns("dgt_NumPersonas").Visible = False
                    dgvDetalle.Columns("dgt_CantidadLadrillo").Visible = False
                    dgvDetalle.Columns("dgt_Fraccion").Visible = True
                    dgvDetalle.Columns("dgt_Refrigerio").Visible = True
                    dgvDetalle.Columns("dgt_Bonificacion").Visible = True
                    dgvDetalle.Columns("dgt_Mesas").Visible = True
                    dgvDetalle.Columns("dgt_Alas").Visible = True
                    dgvDetalle.Columns("dgt_HoraTotales").Visible = True


                    'dgvDetalle.Rows(iRow).Cells("pro_Id").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("Produccion").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_Factor").ReadOnly = True
                    'dgvDetalle.Rows(iRow).Cells("dgt_HoraDesde").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_HoraHasta").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_NumPersonas").ReadOnly = True
                    'dgvDetalle.Rows(iRow).Cells("dgt_CantidadLadrillo").ReadOnly = True
                    'dgvDetalle.Rows(iRow).Cells("dgt_Fraccion").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_Refrigerio").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_Bonificacion").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_Mesas").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_Alas").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_HoraTotales").ReadOnly = True
                Case "003"

                        dgvDetalle.Columns("pro_Id").Visible = True
                        dgvDetalle.Columns("Produccion").Visible = True
                    dgvDetalle.Columns("dgt_Factor").Visible = True
                    dgvDetalle.Columns("dgt_HoraDesde").Visible = True
                    dgvDetalle.Columns("dgt_HoraHasta").Visible = True
                    dgvDetalle.Columns("dgt_NumPersonas").Visible = True
                    dgvDetalle.Columns("dgt_CantidadLadrillo").Visible = True
                    dgvDetalle.Columns("dgt_Fraccion").Visible = True
                    dgvDetalle.Columns("dgt_Refrigerio").Visible = True
                    dgvDetalle.Columns("dgt_Bonificacion").Visible = True
                    dgvDetalle.Columns("dgt_Mesas").Visible = True
                    dgvDetalle.Columns("dgt_Alas").Visible = True
                        dgvDetalle.Columns("dgt_HoraTotales").Visible = True

                Case "004"

                    dgvDetalle.Columns("pro_Id").Visible = True
                    dgvDetalle.Columns("Produccion").Visible = True
                    dgvDetalle.Columns("dgt_Factor").Visible = False
                    dgvDetalle.Columns("dgt_HoraDesde").Visible = True
                    dgvDetalle.Columns("dgt_HoraHasta").Visible = True
                    dgvDetalle.Columns("dgt_NumPersonas").Visible = False
                    dgvDetalle.Columns("dgt_CantidadLadrillo").Visible = False
                    dgvDetalle.Columns("dgt_Fraccion").Visible = True
                    dgvDetalle.Columns("dgt_Refrigerio").Visible = True
                    dgvDetalle.Columns("dgt_Bonificacion").Visible = True
                    dgvDetalle.Columns("dgt_Mesas").Visible = False
                    dgvDetalle.Columns("dgt_Alas").Visible = False
                    dgvDetalle.Columns("dgt_HoraTotales").Visible = True

                    'dgvDetalle.Rows(iRow).Cells("pro_Id").ReadOnly = True
                    'dgvDetalle.Rows(iRow).Cells("Produccion").ReadOnly = True
                    'dgvDetalle.Rows(iRow).Cells("dgt_Factor").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_HoraDesde").ReadOnly = True
                    'dgvDetalle.Rows(iRow).Cells("dgt_HoraHasta").ReadOnly = True
                    'dgvDetalle.Rows(iRow).Cells("dgt_NumPersonas").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_CantidadLadrillo").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_Fraccion").ReadOnly = True
                    'dgvDetalle.Rows(iRow).Cells("dgt_Refrigerio").ReadOnly = True
                    'dgvDetalle.Rows(iRow).Cells("dgt_Bonificacion").ReadOnly = True
                    'dgvDetalle.Rows(iRow).Cells("dgt_Mesas").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_Alas").ReadOnly = False
                    'dgvDetalle.Rows(iRow).Cells("dgt_HoraTotales").ReadOnly = True

                End Select
            Catch ex As Exception

            End Try

        End Sub
        Sub MostrarTodasLasColumnas()
            Try
                dgvDetalle.Columns("pro_Id").Visible = True
                dgvDetalle.Columns("Produccion").Visible = True
                dgvDetalle.Columns("dgt_Factor").Visible = True
                dgvDetalle.Columns("dgt_HoraDesde").Visible = True
                dgvDetalle.Columns("dgt_HoraHasta").Visible = True
                dgvDetalle.Columns("dgt_NumPersonas").Visible = True
                dgvDetalle.Columns("dgt_CantidadLadrillo").Visible = True
                dgvDetalle.Columns("dgt_Fraccion").Visible = True
                dgvDetalle.Columns("dgt_Refrigerio").Visible = True
                dgvDetalle.Columns("dgt_Bonificacion").Visible = True
                dgvDetalle.Columns("dgt_Descuento").Visible = True
                dgvDetalle.Columns("dgt_Mesas").Visible = True
                dgvDetalle.Columns("dgt_Alas").Visible = True
                dgvDetalle.Columns("dgt_HoraTotales").Visible = True
            Catch ex As Exception

            End Try


        End Sub
        Function validarCeldas(ByVal iRow As Integer) As Boolean
            Dim result As Boolean = True
            'If (Not IsNumeric(dgvDetalle.Rows(iRow).Cells("dgt_Factor").Value)) Then
            '    result = False
            '    ErrorProvider1.SetError(dgvDetalle, "Factor")
            '    dgvDetalle.Rows(iRow).Cells("dgt_Factor").Value = "1"
            '    dgvDetalle.Rows(iRow).Cells("dgt_Factor").Selected = True
            '    Return result
            'Else
            '    ErrorProvider1.SetError(dgvDetalle, Nothing)
            'End If
            Try
                If (Not (IsNumeric(dgvDetalle.Rows(iRow).Cells("dgt_NumPersonas").Value))) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Numero de Personas")
                    dgvDetalle.Rows(iRow).Cells("dgt_NumPersonas").Value = "1"
                    dgvDetalle.Rows(iRow).Cells("dgt_NumPersonas").Selected = True
                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                If (Not IsNumeric(dgvDetalle.Rows(iRow).Cells("dgt_CantidadLadrillo").Value)) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Cantidad Ladrillo")
                    dgvDetalle.Rows(iRow).Cells("dgt_CantidadLadrillo").Value = "0"
                    dgvDetalle.Rows(iRow).Cells("dgt_CantidadLadrillo").Selected = True
                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If
                If (Not IsNumeric(dgvDetalle.Rows(iRow).Cells("dgt_Fraccion").Value)) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Fraccion")
                    dgvDetalle.Rows(iRow).Cells("dgt_Fraccion").Value = "1"
                    dgvDetalle.Rows(iRow).Cells("dgt_Fraccion").Selected = True
                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                If Not IsNumeric(dgvDetalle.Rows(iRow).Cells("dgt_Refrigerio").Value) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Refrigerio")
                    dgvDetalle.Rows(iRow).Cells("dgt_Refrigerio").Value = "0"
                    dgvDetalle.Rows(iRow).Cells("dgt_Refrigerio").Selected = True
                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                If Not IsNumeric(dgvDetalle.Rows(iRow).Cells("dgt_Bonificacion").Value) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Bonificacion")
                    dgvDetalle.Rows(iRow).Cells("dgt_Bonificacion").Value = "0"
                    dgvDetalle.Rows(iRow).Cells("dgt_Bonificacion").Selected = True
                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                If Not IsNumeric(dgvDetalle.Rows(iRow).Cells("dgt_Descuento").Value) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Descuento")
                    dgvDetalle.Rows(iRow).Cells("dgt_Descuento").Value = "0"
                    dgvDetalle.Rows(iRow).Cells("dgt_Descuento").Selected = True
                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If


                If Not IsNumeric(dgvDetalle.Rows(iRow).Cells("dgt_Mesas").Value) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Mesas")
                    dgvDetalle.Rows(iRow).Cells("dgt_Mesas").Value = "0"
                    dgvDetalle.Rows(iRow).Cells("dgt_Mesas").Selected = True
                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                If Not IsNumeric(dgvDetalle.Rows(iRow).Cells("dgt_Alas").Value) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Alas")
                    dgvDetalle.Rows(iRow).Cells("dgt_Alas").Value = "0"
                    dgvDetalle.Rows(iRow).Cells("dgt_Alas").Selected = True
                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                If Not IsNumeric(dgvDetalle.Rows(iRow).Cells("dgt_HoraDesde").Value) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Hora Desde")
                    dgvDetalle.Rows(iRow).Cells("dgt_HoraDesde").Value = "0"
                    dgvDetalle.Rows(iRow).Cells("dgt_HoraDesde").Selected = True
                    Return result
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If


                'dgt_NumPersonas

                If Not IsNumeric(dgvDetalle.Rows(iRow).Cells("dgt_NumPersonas").Value) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Numero  de Personas,valores Enteros")
                    dgvDetalle.Rows(iRow).Cells("dgt_NumPersonas").Value = "0"
                    dgvDetalle.Rows(iRow).Cells("dgt_NumPersonas").Selected = True
                    Return result
                Else

                    dgvDetalle.Rows(iRow).Cells("dgt_NumPersonas").Value = CInt(Val(dgvDetalle.Rows(iRow).Cells("dgt_NumPersonas").Value))

                    ErrorProvider1.SetError(dgvDetalle, Nothing)

                End If


                If Not IsNumeric(dgvDetalle.Rows(iRow).Cells("dgt_HoraHasta").Value) Then
                    result = False
                    ErrorProvider1.SetError(dgvDetalle, "Hora Hasta")
                    dgvDetalle.Rows(iRow).Cells("dgt_HoraHasta").Value = "0"
                    dgvDetalle.Rows(iRow).Cells("dgt_HoraHasta").Selected = True
                    Return result
                Else

                    ErrorProvider1.SetError(dgvDetalle, Nothing)

                End If
            Catch ex As Exception
                ErrorProvider1.SetError(dgvDetalle, "Error en la fila Actual ")
                Return False
            End Try
           

            Return result
        End Function
        Sub calculoCeldas(ByVal iRow As Integer)
            Try
                Dim dgt_Factor, dgt_NumPersonas, dgt_CantidadLadrillo, dgt_Fraccion, dgt_Refrigerio, _
                               dgt_Bonificacion, dgt_Mesas, dgt_Alas, dgt_HoraDesde, dgt_HoraHasta, dgt_Descuento As Double
                Dim dgt_HoraTotales As Double
                Dim tipoTarea As String
                dgt_HoraTotales = 0

                If (validarCeldas(iRow)) Then
                    tipoTarea = dgvDetalle.Rows(iRow).Cells("tit_TipTarea_Id").Tag

                    dgt_Factor = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_Factor").Value)
                    dgt_NumPersonas = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_NumPersonas").Value)
                    dgt_CantidadLadrillo = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_CantidadLadrillo").Value)
                    dgt_Fraccion = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_Fraccion").Value)
                    dgt_Refrigerio = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_Refrigerio").Value)
                    dgt_Bonificacion = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_Bonificacion").Value)
                    dgt_Descuento = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_Descuento").Value)
                    dgt_Mesas = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_Mesas").Value)
                    dgt_Alas = CDbl(dgvDetalle.Rows(iRow).Cells("dgt_Alas").Value)

                    dgt_HoraDesde = dgvDetalle.Rows(iRow).Cells("dgt_HoraDesde").Value
                    dgt_HoraHasta = dgvDetalle.Rows(iRow).Cells("dgt_HoraHasta").Value

                    dgvDetalle.Rows(iRow).Cells("dgt_HoraTotales").Value = "0.00"

                    Select Case tipoTarea

                        Case "001" ' por indice
                            dgt_HoraTotales = Math.Round(((((dgt_CantidadLadrillo / dgt_Factor) / dgt_NumPersonas) * dgt_Fraccion) + dgt_Bonificacion - dgt_Descuento) - dgt_Refrigerio, 6)
                        Case "002" ' por  paquete
                            dgt_HoraTotales = Math.Round(((((dgt_Alas + dgt_Mesas) * dgt_Factor) * dgt_Fraccion) - dgt_Refrigerio) + dgt_Bonificacion - dgt_Descuento, 6)
                        Case "003" 'por trabajo en tareo por otro frm frmGrupoTrabajoTareo
                            dgt_HoraTotales = Math.Round((((dgt_Factor / dgt_NumPersonas) * dgt_Fraccion) + dgt_Bonificacion - dgt_Descuento) - dgt_Refrigerio, 6)
                        Case "004" 'por horas 
                            ' dgt_HoraTotales = Math.Round((((diferenciaHorasHH(dgt_HoraDesde, dgt_HoraHasta, 1)) * dgt_Fraccion) - dgt_Refrigerio) - dgt_Bonificacion, 6)

                            Dim dDiferenciHOra As Double
                            dDiferenciHOra = BCUtil.diferenciaHorasHH(dgt_HoraDesde, dgt_HoraHasta)
                            dgt_HoraTotales = (((dDiferenciHOra) * dgt_Fraccion) - dgt_Refrigerio) + dgt_Bonificacion - dgt_Descuento

                            'dgt_HoraTotales = Math.Round(((Math.Abs(((dgt_HoraDesde / 60) - (dgt_HoraHasta / 60))) * dgt_Fraccion) - (dgt_Refrigerio / 60)) - (dgt_Bonificacion / 60), 6)

                    End Select

                    dgvDetalle.Rows(iRow).Cells("dgt_HoraTotales").Value = dgt_HoraTotales.ToString
                    If (dgt_HoraTotales > 22) Then
                        MsgBox("El total de horas no debe ser mayor a 22.00 Horas")
                    End If
                End If
                suma()
            Catch ex As Exception
                ErrorProvider1.SetError(dgvDetalle, "Error de calculo ")
            End Try


        End Sub
        

        Private Sub dgvDetalle_CellStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellStateChangedEventArgs) Handles dgvDetalle.CellStateChanged
            Try

           
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

                                    lblPersonas.Text = .Cells(1).Value & " " & .Cells(2).Value
                                    LlenarMarcacion(CDate(dateFechaInicio.Value), .Cells(0).Value)


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


                    Case "Produccion"
                        ' se desactiva la busqueda directa , al digilar el numero de produccion en la grilla 
                        'Try
                        '    Dim frm = Me.ContainerService.Resolve(Of frmBuscarFecha)()
                        '    frm.inicio(Constants.BuscadoresNames.GrupoTrabajoProduccion)
                        '    frm.llenarCombo()

                        '    frm.cboBuscar.SelectedIndex = 1
                        '    frm.txtBuscar.Text = e.Cell.Value
                        '    frm.cargarDatos()

                        '    If (frm.dgbRegistro.RowCount > 0) Then
                        '        With frm.dgbRegistro.Rows(0)
                        '            dgvDetalle.Rows(e.Cell.RowIndex).Cells("Produccion").Tag = .Cells(0).Value
                        '            dgvDetalle.Rows(e.Cell.RowIndex).Cells("Produccion").Value = .Cells(1).Value
                        '            dgvDetalle.Rows(e.Cell.RowIndex).Cells("pro_Id").Tag = .Cells(0).Value
                        '            dgvDetalle.Rows(e.Cell.RowIndex).Cells("pla_id").Value = .Cells(4).Value
                        '            dgvDetalle.Rows(e.Cell.RowIndex).Cells("Descripcion").Value = .Cells(3).Value
                        '        End With
                        '    Else
                        '        dgvDetalle.Rows(e.Cell.RowIndex).Cells("Produccion").Tag = Nothing
                        '        dgvDetalle.Rows(e.Cell.RowIndex).Cells("Produccion").Value = Nothing
                        '        dgvDetalle.Rows(e.Cell.RowIndex).Cells("pro_Id").Tag = Nothing
                        '        dgvDetalle.Rows(e.Cell.RowIndex).Cells("Descripcion").Value = Nothing
                        '    End If
                        'Catch ex As Exception
                        '    dgvDetalle.Rows(e.Cell.RowIndex).Cells("Produccion").Tag = Nothing
                        '    dgvDetalle.Rows(e.Cell.RowIndex).Cells("Produccion").Value = Nothing
                        '    dgvDetalle.Rows(e.Cell.RowIndex).Cells("pro_Id").Tag = Nothing
                        '    dgvDetalle.Rows(e.Cell.RowIndex).Cells("Descripcion").Value = Nothing
                        'End Try


                End Select

            End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub dgvDetalle_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellValidated
            Try
                If (e.RowIndex >= 0 AndAlso dgvDetalle.Rows(e.RowIndex).Cells("tit_TipTarea_Id").Tag <> "") Then
                    calculoCeldas(e.RowIndex)

                    bloquearCeldas(e.RowIndex, dgvDetalle.Rows(e.RowIndex).Cells("tit_TipTarea_Id").Tag)


                End If
            Catch ex As Exception

            End Try

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
            Try
                If (e.KeyChar = Chr(Keys.Enter)) Then
                    ' codigo
                    If (dgvDetalle.SelectedCells(0).ColumnIndex = 2) Then
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


                    bloquearCeldas(dgvDetalle.SelectedCells(0).RowIndex, dgvDetalle.Rows(dgvDetalle.SelectedCells(0).RowIndex).Cells("tit_TipTarea_Id").Tag)


                End If
            Catch ex As Exception

            End Try

        End Sub



        Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem.Click
            Dim x As Integer = 0
            Dim y As Integer = 0
            x = dgvDetalle.SelectedRows.Count - 1
            While x >= 0
                dgvDetalle.Rows.Add()
                y = 1
                While (dgvDetalle.Columns.Count > y)

                    Try
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Value = dgvDetalle.SelectedRows(x).Cells(y).Value
                    Catch ex As Exception
                    End Try

                    Try
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Tag = dgvDetalle.SelectedRows(x).Cells(y).Tag
                    Catch ex As Exception
                    End Try

                    y += 1
                End While

                x -= 1
            End While
            suma()
        End Sub

        Private Sub CopiarPersonasSegunUnaFilaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarPersonasSegunUnaFilaToolStripMenuItem.Click
            Dim x As Integer = 0
            Dim y As Integer = 0

            x = dgvDetalle.SelectedRows.Count - 2
            While x >= 0
                dgvDetalle.Rows.Add()
                y = 1
                While (dgvDetalle.Columns.Count > y)

                    If (y <= 3) Then
                        Try
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Value = dgvDetalle.SelectedRows(x).Cells(y).Value
                        Catch ex As Exception
                        End Try

                        Try
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Tag = dgvDetalle.SelectedRows(x).Cells(y).Tag
                        Catch ex As Exception
                        End Try

                    Else

                        Try
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Value = dgvDetalle.SelectedRows(dgvDetalle.SelectedRows.Count - 1).Cells(y).Value
                        Catch ex As Exception
                        End Try

                        Try
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Tag = dgvDetalle.SelectedRows(dgvDetalle.SelectedRows.Count - 1).Cells(y).Tag
                        Catch ex As Exception
                        End Try

                    End If


                    y += 1
                End While

                x -= 1
            End While
            ' ir la aultima fila
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(0)
            suma()
        End Sub

        Private Sub btnVerColumnas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerColumnas.Click
            MostrarTodasLasColumnas()


        End Sub


        Private Sub FiltrarPorCeldaActualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FiltrarPorCeldaActualToolStripMenuItem.Click
            Dim valor As String = (dgvDetalle.SelectedCells(0).Value)
            Dim iColumna As Integer = (dgvDetalle.SelectedCells(0).ColumnIndex)
            MsgBox(dgvDetalle.SelectedCells(0).Value)
            Dim x As Integer = 0
            While (dgvDetalle.Rows.Count > x)
                Try
                    If (dgvDetalle.Rows(x).Cells(iColumna).Value <> valor) Then
                        dgvDetalle.Rows(x).Visible = False

                        btnBorrarTodosLosFiltros.BackColor = Color.Red


                    End If
                Catch ex As Exception

                End Try
                x += 1
            End While
            ' ir la aultima fila
            If (dgvDetalle.Rows.Count) Then
                dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(0)
            End If

            suma()

        End Sub
        Sub borrarFiltros()
            Dim x As Integer = 0
            While (dgvDetalle.Rows.Count > x)
                Try

                    btnBorrarTodosLosFiltros.BackColor = btnVerColumnas.BackColor

                    dgvDetalle.Rows(x).Visible = True

                Catch ex As Exception

                End Try
                x += 1
            End While
            suma()
        End Sub
        Private Sub BorrarFiltrosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorrarFiltrosToolStripMenuItem.Click
            borrarFiltros()

            ControlFiltroTrareaHoras1.limpiarFiltro(dgvDetalle)
        End Sub


        Private Sub btnBorrarTodosLosFiltros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarTodosLosFiltros.Click
            borrarFiltros()
            ControlFiltroTrareaHoras1.limpiarFiltro(dgvDetalle)
           
        End Sub

        Private Sub MostrarTodasLasColumnasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MostrarTodasLasColumnasToolStripMenuItem.Click
            MostrarTodasLasColumnas()
        End Sub

        Private Sub MostrarColumnasPorFilaSeleccionadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MostrarColumnasPorFilaSeleccionadaToolStripMenuItem.Click
            Try
                If (dgvDetalle.SelectedRows.Count > 0) Then
                    bloquearCeldas(dgvDetalle.SelectedRows(0).Index, dgvDetalle.SelectedRows(0).Cells("tit_TipTarea_Id").Value)

                End If
            Catch ex As Exception

            End Try


        End Sub


        Private Sub ToolStripTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ToolStripTextBox1.KeyPress
            If (e.KeyChar = Chr(Keys.Enter)) Then
                Dim x As Integer = 0
                Dim y As Integer = 0

                If (dgvDetalle.SelectedRows.Count > 0) Then


                    While Val(ToolStripTextBox1.Text) > x
                        dgvDetalle.Rows.Add()
                        y = 1
                        While (dgvDetalle.Columns.Count > y)

                            Try
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Value = dgvDetalle.SelectedRows(0).Cells(y).Value
                            Catch ex As Exception
                            End Try

                            Try
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Tag = dgvDetalle.SelectedRows(0).Cells(y).Tag
                            Catch ex As Exception
                            End Try

                            y += 1
                        End While

                        x += 1
                    End While
                    ' ir la aultima fila
                    dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(2)
                Else
                    MsgBox("Seleccione una fila para duplicar")
                End If

            End If
            suma()
        End Sub

        Private Sub dgvDetalle_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDetalle.RowHeaderMouseDoubleClick
            Try
                If (dgvDetalle.SelectedRows.Count > 0) Then
                    lblPersonas.Text = dgvDetalle.SelectedRows(0).Cells("Codigo").Value & " " & dgvDetalle.SelectedRows(0).Cells("Persona").Value
                    LlenarMarcacion(CDate(dateFechaInicio.Value), dgvDetalle.SelectedRows(0).Cells("per_Id").Value)
                    bloquearCeldas(dgvDetalle.SelectedRows(0).Index, dgvDetalle.SelectedRows(0).Cells("tit_TipTarea_Id").Tag)
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub dateFechaInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateFechaInicio.ValueChanged

            txtPeriodo.Text = dateFechaInicio.Value.Year.ToString & dateFechaInicio.Value.ToString("MM")

        End Sub

        Private Sub dgvDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown

            ' solo puede copiar y pegar en  las siguientes columnas 
            Try

                'If e.KeyCode = Keys.Enter Then
                '    e.SuppressKeyPress = True
                '    SendKeys.Send("{TAB}")
                'End If

                If (dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "Codigo" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_HoraDesde" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_HoraHasta" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_Factor" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_Bonificacion" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_Refrigerio" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_Fraccion" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_CantidadLadrillo" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_Mesas" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_Alas" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_Observaciones" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_Descuento" OrElse _
              dgvDetalle.Columns(dgvDetalle.SelectedCells(0).ColumnIndex).Name = "dgt_NumPersonas") Then


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

      


        Private Sub btnFiltros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltros.Click
            ControlFiltroTrareaHoras1.Visible = Not ControlFiltroTrareaHoras1.Visible
            btnAplicar.Visible = Not btnAplicar.Visible
            ControlFiltroTrareaHoras1.aplicarFiltros(dgvDetalle)

        End Sub

       


        Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click

            borrarFiltros()
            ControlFiltroTrareaHoras1.PocesarFiltros(dgvDetalle)

            suma()
            ControlFiltroTrareaHoras1.aplicarFiltros(dgvDetalle)

        End Sub
       
       
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarFecha)()
            frm.inicio(Constants.BuscadoresNames.GrupoTrabajoHoras)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                Dim frm2 = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmGrupoTrabajoHoraClonar)()
                frm2.cargarMAEstiloGrilla()
                frm2.getDataGrid(dgvDetalle)
                frm2.cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value, frm.dgbRegistro.CurrentRow.Cells(1).Value)
                frm.Close()
                frm2.ShowDialog()

            End If
            frm.Dispose()


        End Sub


    End Class
End Namespace