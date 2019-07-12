
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports Ladisac.Planillas.Constants

Namespace Ladisac.Planillas.Views
    Public Class frmDatosLaboralesPanel

        <Dependency()> _
        Public Property BCDatosLaborales As Ladisac.BL.BCDatosLaborales
        <Dependency()> _
        Public Property BCSituacionTrabajador As BL.IBCSituacionTrabajador

        <Dependency()> _
        Public Property BCAreaTrabajos As BL.IBCAreaTrabajos

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        <Dependency()> _
        Public Property BCTiposTrabajador As Ladisac.BL.IBCTiposTrabajador

        Public sBuscar As String
        Dim bCargo As Boolean = False

        Private Sub chkActivarTipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivarTipo.CheckedChanged
            cboActivarTipo.Enabled = chkActivarTipo.Checked
            cargar()
        End Sub

        Private Sub chkActivarSituacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivarSituacion.CheckedChanged
            cboActivarSituacion.Enabled = chkActivarSituacion.Checked
            cargar()
        End Sub

        Private Sub frmDatosLaboralesPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            bCargo = False
            llenarCombos()
            bCargo = True
            cargar()
            If (sBuscar = Ladisac.Planillas.Constants.MenuNames.DatosLaboralesPanelHoras) Then
                Panel4.Visible = True
            End If



        End Sub
        Sub llenarCombos()
            Dim query As String = Nothing

                  query = Me.BCSituacionTrabajador.SituacionTrabajadorQuery(Nothing, Nothing)




            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    cboActivarSituacion.DataSource = ds.Tables(0)
                    cboActivarSituacion.ValueMember = ds.Tables(0).Columns(0).ColumnName
                    cboActivarSituacion.DisplayMember = ds.Tables(0).Columns(1).ColumnName
                Else
                    cboActivarSituacion.DataSource = Nothing
                End If
            End If

            query = Nothing
            query = Me.BCTiposTrabajador.TiposTrabajadorQuery(Nothing, Nothing)

            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    cboActivarTipo.DataSource = ds.Tables(0)
                    cboActivarTipo.ValueMember = ds.Tables(0).Columns(0).ColumnName
                    cboActivarTipo.DisplayMember = ds.Tables(0).Columns(1).ColumnName
                Else
                    cboActivarTipo.DataSource = Nothing
                End If
            End If

            'BCAreaTrabajos

            query = Nothing
            query = Me.BCAreaTrabajos.AreaTrabajosQuery(Nothing, Nothing, 1)

            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    cboAreaTrabajo.DataSource = ds.Tables(0)
                    cboAreaTrabajo.ValueMember = ds.Tables(0).Columns(0).ColumnName
                    cboAreaTrabajo.DisplayMember = ds.Tables(0).Columns(1).ColumnName
                Else
                    cboAreaTrabajo.DataSource = Nothing
                End If
            End If


        End Sub
        Sub cargar()
            If (bCargo) Then

                Dim sTipoTra As String = ""
                Dim sSituacionTRab As String = ""
                Dim sAreaTrabajo As String = ""

                If (chkActivarSituacion.Checked) Then
                    sSituacionTRab = cboActivarSituacion.SelectedValue
                End If

                If (chkActivarTipo.Checked) Then
                    sTipoTra = cboActivarTipo.SelectedValue
                End If
                If (chkAreaTrabajo.Checked) Then
                    sAreaTrabajo = cboAreaTrabajo.SelectedValue
                End If


                If (sBuscar = Ladisac.Planillas.Constants.MenuNames.DatosLaboralesPanel) Then

                    dgvDetalle.DataSource = BCDatosLaborales.spDatosLaboralesPanelSelect(sTipoTra, sSituacionTRab, sAreaTrabajo)

                End If
                If (sBuscar = Ladisac.Planillas.Constants.MenuNames.DatosLaboralesPanelHoras) Then

                    dgvDetalle.DataSource = BCDatosLaborales.spDatosLaboralesPanelHorasSelect(sTipoTra, sSituacionTRab, CDate(dateFechaDesde.Value), CDate(dateFechaHasta.Value))

                End If
                'spDatosLaboralesPanelHorasSelect5
            End If
        End Sub

        Sub buscarPorCodigo()
            Dim x As Integer = 0
            x = 0
            If (txtCodigo.Text.Length >= 4) Then
                While (dgvDetalle.Rows.Count > x)
                    Try
                        If (dgvDetalle.Rows(x).Cells("Codigo").Value = txtCodigo.Text) Then
                            dgvDetalle.CurrentCell = dgvDetalle.Rows(x).Cells(1)
                            Exit Sub
                        End If
                    Catch ex As Exception

                    End Try
                    x += 1
                End While

            End If
        End Sub

        Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
            buscarPorCodigo()
        End Sub

        Private Sub cboActivarTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboActivarTipo.SelectedIndexChanged
            cargar()
        End Sub

        Private Sub cboActivarSituacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboActivarSituacion.SelectedIndexChanged
            cargar()
        End Sub

        Private Sub dgvDetalle_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDetalle.RowHeaderMouseDoubleClick

            If (dgvDetalle.SelectedRows.Count > 0) Then
                Dim frm = Me.ContainerService.Resolve(Of frmDatosLaborales)()
                frm.lblTitle.Text = BuscadoresNames.DatosLaborales

                frm.cargar(dgvDetalle.SelectedRows(0).Cells(0).Value)
                frm.menuBuscar()
                frm.Panel1.Enabled = False
                frm.esLlamado = True
                frm.ShowDialog()

                frm.Dispose()
            End If

        End Sub

        Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
            'Dim oTablita As New DataTable
            If (dgvDetalle.Rows.Count > 0) Then
                'oTablita = BCUtil.getTable(dgvDetalle, "MiTablita")
                'BCUtil.excelExportar(oTablita)
                BCUtil.excelExportar(CType(dgvDetalle.DataSource, DataTable))
            End If
        End Sub

        Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
            cargar()
        End Sub


        Private Sub chkAreaTrabajo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAreaTrabajo.CheckedChanged
            cboAreaTrabajo.Enabled = chkAreaTrabajo.Checked
            cargar()
        End Sub

        Private Sub cboAreaTrabajo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAreaTrabajo.SelectedIndexChanged
            cargar()
        End Sub
    End Class
End Namespace