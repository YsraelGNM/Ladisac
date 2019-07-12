Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports System.Globalization

Namespace Ladisac.Planillas.Views
    Public Class frmGrupoTrabajoHoraClonar

        <Dependency()> _
        Public Property BCGrupoTrabajo As Ladisac.BL.IBCGrupoTrabajo

        Protected oGrupoTrabajo As New BE.GrupoTrabajo
        <Dependency()> _
        Public Property BCPlanta As Ladisac.BL.IBCPlanta
        <Dependency()> _
        Public Property BCAreaTrabajos As BL.IBCAreaTrabajos


        Dim odataGrid As New DataGridView

          

        Public Sub getDataGrid(ByRef odataGridEnViado As DataGridView)
            odataGrid = odataGridEnViado
        End Sub



        Public Sub cargarMAEstiloGrilla()

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

        Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click
            borrarFiltros()
            ControlFiltroTrareaHoras1.PocesarFiltros(dgvDetalle)


            ControlFiltroTrareaHoras1.aplicarFiltros(dgvDetalle)
        End Sub


        Sub borrarFiltros()
            Dim x As Integer = 0
            While (dgvDetalle.Rows.Count > x)
                Try
                    dgvDetalle.Rows(x).Visible = True

                Catch ex As Exception

                End Try
                x += 1
            End While

        End Sub


        Public Sub cargar(ByVal periodo As String, ByVal numero As String)




            Dim oTAble As New DataTable

            oTAble = BCGrupoTrabajo.SPDetalleGrupoTrabajoMaintenanceSelect(periodo, numero)
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

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_HoraDesde").Value = oNewDetalleGrupo.dgt_HoraDesde
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_HoraHasta").Value = oNewDetalleGrupo.dgt_HoraHasta
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

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dgt_NumPersonas").Value = oNewDetalleGrupo.dgt_NumPersonas

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

                End With
                x += 1
            End While

            ' ir la aultima fila
            If (dgvDetalle.Rows.Count > 0) Then

                dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(0)
            End If

        End Sub


        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim x As Integer = 0
            Dim y As Integer = 0
            If (dgvDetalle.SelectedRows.Count > 0) Then
                x = dgvDetalle.SelectedRows.Count - 1
                While x >= 0
                    odataGrid.Rows.Add()
                    y = 1
                    While (dgvDetalle.Columns.Count > y)

                        Try
                            odataGrid.Rows(odataGrid.Rows.Count - 1).Cells(y).Value = dgvDetalle.SelectedRows(x).Cells(y).Value
                        Catch ex As Exception
                        End Try

                        Try
                            odataGrid.Rows(odataGrid.Rows.Count - 1).Cells(y).Tag = dgvDetalle.SelectedRows(x).Cells(y).Tag
                        Catch ex As Exception
                        End Try

                        y += 1
                    End While

                    x -= 1
                End While
            Else
                MsgBox("Seleccione filas a clonar")
            End If

        End Sub

        Private Sub frmGrupoTrabajoHoraClonar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ControlFiltroTrareaHoras1.aplicarFiltros(dgvDetalle)
        End Sub
    End Class

End Namespace
