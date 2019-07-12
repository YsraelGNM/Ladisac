Imports Microsoft.Practices.Unity
Imports System.IO
Namespace Ladisac.Planillas.Views

    Public Class frmBuscarSimple

        Private sBuscar As String()
        Private sbusco As String
        <Dependency()> _
        Public Property BCConceptos As Ladisac.BL.IBCConceptos

        <Dependency()>
        Public Property BCTiposConceptosQueries As Ladisac.BL.IBCTiposConceptosQueries

        <Dependency()> _
        Public Property BCTiposContratos As Ladisac.BL.IBCTiposContratos

        <Dependency()> _
        Public Property BCPeriodisidad As Ladisac.BL.IBCPeriodisidad
        <Dependency()> _
        Public Property BCTiposCargos As Ladisac.BL.IBCTiposCargos
        <Dependency()> _
        Public Property BCNivelEducacion As Ladisac.BL.IBCNivelEducacion
        <Dependency()> _
        Public Property BCConvenioDobleTributacion As Ladisac.BL.IBCConvenioDobleTributacion
        <Dependency()> _
        Public Property BCTiposTrabajador As Ladisac.BL.IBCTiposTrabajador

        <Dependency()> _
        Public Property BCRegimenLaboral As Ladisac.BL.IBCRegimenLaboral

        <Dependency()> _
        Public Property BCRegimenPensionario As Ladisac.BL.IBCRegimenPensionario


        <Dependency()> _
        Public Property BCSituacionEspecialTrabajador As Ladisac.BL.IBCSituacionEspecialTrabajador

        <Dependency()> _
        Public Property BCSituacionTrabajador As Ladisac.BL.IBCSituacionTrabajador

        <Dependency()> _
        Public Property BCTiposPlanillas As Ladisac.BL.IBCTiposPlanillas
        <Dependency()> _
        Public Property BCConceptosPlanilla As Ladisac.BL.IBCConceptosPlanilla

        <Dependency()> _
        Public Property BCDatosLaborales As Ladisac.BL.IBCDatosLaborales
        <Dependency()> _
        Public Property BCCentroCosto As Ladisac.BL.IBCCentroCosto

        <Dependency()> _
        Public Property BCAreaTrabajos As Ladisac.BL.IBCAreaTrabajos

        <Dependency()> _
        Public Property BCDetalleConceptoPensionario As Ladisac.BL.IBCDetalleConceptoPensionario
        <Dependency()> _
        Public Property BCTiposTareaTrabajo As BL.IBCTiposTareaTrabajo

        <Dependency()> _
        Public Property BCDatosTrabajadorJudicial As BL.IBCDatosTrabajadorJudicial

        <Dependency()> _
        Public Property BCDetalleConceptosPlanillas As BL.IBCDetalleConceptosPlanillas
        <Dependency()> _
        Public Property BCPrestamosTrabajador As BL.IBCPrestamosTrabajador

        <Dependency()> _
        Public Property BCTareaTrabajo As BL.IBCTareaTrabajo

        <Dependency()> _
        Public Property BCPermisosTrabajador As BL.IBCPermisosTrabajador
        <Dependency()> _
        Public Property BCCentroRiesgo As BL.IBCCentroRiesgo


        Public Sub inicio(ByVal queBusco As String)

            sbusco = queBusco
            llenarCombo()

        End Sub
        Public Property campo1() As String = Nothing
        Public Property campo2() As String = Nothing
        Public Property campo3() As String = Nothing


        Public Sub llenarCombo()

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.Conceptos) Then
                lblTitle.Text = "Conceptos Generales"

                'BCTiposConceptosQueries.TiposDocumentosQuery()

                Dim result = Me.BCTiposConceptosQueries.TiposDocumentosQuery()
                Dim ds As New DataSet
                Dim sr As New StringReader(result)
                ds.ReadXml(sr)
                Me.cboBuscar.DataSource = ds.Tables(0)
                Me.cboBuscar.DisplayMember = "tic_Descripcion"
                Me.cboBuscar.ValueMember = "tic_TipoConcep_Id"

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TiposContratos) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.Periodisidad) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TiposCargos) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.NIvelEducacion) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ConvenioDobleTributacion) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TiposTrabajador) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.RegimenLaboral) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.RegimenPensionario) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.SituacionEspecialTrabajador) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.SituacionTrabajador) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TiposPlanillas) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ConceptosPlanilla) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.DatosLaborales) Then
                cboBuscar.Items.Add("ID")
                cboBuscar.Items.Add("Codigo")
                cboBuscar.Items.Add("Nombre")
                cboBuscar.SelectedIndex = 1
            End If

            If (sbusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CentroCosto) Then
                cboBuscar.Items.Add("Codigo")
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 1
            End If

            If (sbusco = Constants.BuscadoresNames.BuscarPersona) Then
                cboBuscar.Items.Add("ID")
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 1
            End If
            If (sbusco = Constants.BuscadoresNames.Bancos) Then
                cboBuscar.Items.Add("ID")
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 1
            End If
            If (sbusco = Constants.BuscadoresNames.AreaTrabajos) Then
                cboBuscar.Items.Add("ID")
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 1
            End If
            If (sbusco = Constants.BuscadoresNames.DetalleConceptoPensionario) Then
                lblTitle.Text = "Conceptos Pensionarios"


                Dim result = Me.BCRegimenPensionario.RegimenPensionarioQuery(Nothing, Nothing)
                Dim ds As New DataSet
                Dim sr As New StringReader(result)
                ds.ReadXml(sr)
                Me.cboBuscar.DataSource = ds.Tables(0)
                Me.cboBuscar.DisplayMember = ds.Tables(0).Columns(1).ColumnName
                Me.cboBuscar.ValueMember = ds.Tables(0).Columns(0).ColumnName

            End If

            If (sbusco = Constants.BuscadoresNames.TiposTareaTrabajo) Then
                cboBuscar.Items.Add("ID")
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 1
            End If

            If (sbusco = Constants.BuscadoresNames.DatosTrabajadorJudicial) Then
                cboBuscar.Items.Add("Codigo")
                cboBuscar.Items.Add("Nombre")
                cboBuscar.SelectedIndex = 1
            End If
            '
            If (sbusco = Constants.BuscadoresNames.DetalleConceptosPlanillasLista) Then
                cboBuscar.Items.Add("Tipo Planilla")

                cboBuscar.SelectedIndex = 0
            End If
            If (sbusco = Constants.BuscadoresNames.PrestamosTrabajador) Then
                cboBuscar.Items.Add("Codigo")
                cboBuscar.Items.Add("Nombre")
                cboBuscar.SelectedIndex = 1
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.PrestamosTrabajador) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If


            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TareaTrabajo) Then
                Dim result = Me.BCTiposTareaTrabajo.TiposTareaTrabajoQuery(Nothing, Nothing)
                Dim ds As New DataSet
                Dim sr As New StringReader(result)
                ds.ReadXml(sr)
                Me.cboBuscar.DataSource = ds.Tables(0)
                Me.cboBuscar.DisplayMember = "Descripcion"
                Me.cboBuscar.ValueMember = "Id"

            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ArticulosLista) Then
                cboBuscar.Items.Add("Codigo")
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 1
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.PermisosTrabajador) Then
                cboBuscar.Items.Add("Numero")
                cboBuscar.Items.Add("Persona")
                cboBuscar.Items.Add("Codigo")
                cboBuscar.SelectedIndex = 1
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.CentroRiesgo) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If

            'cboBuscar.Items.Add("NObre")
            'cboBuscar.Items.Add("descripcion")
            'cboBuscar.Items.AddRange(sBuscar)
            'cboBuscar.SelectedIndex = 0

        End Sub
        Public Sub cargarDatos()

            Dim query As String = Nothing
            Dim sFiltro As String
            dgbRegistro.DataSource = Nothing

            If (chkUsarFiltro.Checked) Then
                sFiltro = cboBuscar.SelectedValue
            Else
                sFiltro = Nothing
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.Conceptos) Then

                query = Me.BCConceptos.ConceptosQuery(Nothing, sFiltro, txtBuscar.Text.Trim)

            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TiposContratos) Then
                query = Me.BCTiposContratos.TiposContratosQuery(Nothing, txtBuscar.Text.Trim)

            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.Periodisidad) Then
                query = Me.BCPeriodisidad.PeriodisidadQuery(Nothing, txtBuscar.Text.Trim)

            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TiposCargos) Then
                query = Me.BCTiposCargos.TiposCargosQuery(Nothing, txtBuscar.Text.Trim)

            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.NIvelEducacion) Then
                query = Me.BCNivelEducacion.NivelEducacionQuery(Nothing, txtBuscar.Text.Trim)

            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ConvenioDobleTributacion) Then
                query = Me.BCConvenioDobleTributacion.ConvenioDobleTributacionQuery(Nothing, txtBuscar.Text.Trim)

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TiposTrabajador) Then
                query = Me.BCTiposTrabajador.TiposTrabajadorQuery(Nothing, txtBuscar.Text.Trim)

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.RegimenLaboral) Then
                query = Me.BCRegimenLaboral.RegimenLaboralQuery(Nothing, txtBuscar.Text.Trim)

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.RegimenPensionario) Then
                query = Me.BCRegimenPensionario.RegimenPensionarioQuery(Nothing, txtBuscar.Text.Trim)

            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.SituacionEspecialTrabajador) Then
                query = Me.BCSituacionEspecialTrabajador.SituacionEspecialTrabajadorQuery(Nothing, txtBuscar.Text.Trim)

            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.SituacionTrabajador) Then
                query = Me.BCSituacionTrabajador.SituacionTrabajadorQuery(Nothing, txtBuscar.Text.Trim)

            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TiposPlanillas) Then
                query = Me.BCTiposPlanillas.TiposPlanillasQuery(Nothing, txtBuscar.Text.Trim)

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ConceptosPlanilla) Then
                query = Me.BCConceptosPlanilla.ConceptosPlanillasDetalleQuery(Nothing, Nothing, Nothing, txtBuscar.Text)

            End If


            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.DatosLaborales) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCDatosLaborales.DatosLaboralesListaQuery(txtBuscar.Text, Nothing, Nothing)
                    Case 1
                        query = Me.BCDatosLaborales.DatosLaboralesListaQuery(Nothing, txtBuscar.Text, Nothing)

                    Case 2
                        query = Me.BCDatosLaborales.DatosLaboralesListaQuery(Nothing, Nothing, txtBuscar.Text)

                End Select
            End If
            If (sbusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CentroCosto) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCCentroCosto.CentroCostoQuery(txtBuscar.Text, Nothing)
                    Case 1
                        query = Me.BCCentroCosto.CentroCostoQuery(Nothing, txtBuscar.Text)
                End Select
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.BuscarPersona) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCDatosLaborales.BuscarPersonaEntidad(txtBuscar.Text, Nothing, "si")
                    Case 1
                        query = Me.BCDatosLaborales.BuscarPersonaEntidad(Nothing, txtBuscar.Text, "si")

                End Select


            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TiposTareaTrabajo) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCTiposTareaTrabajo.TiposTareaTrabajoQuery(txtBuscar.Text, Nothing)
                    Case 1
                        query = Me.BCTiposTareaTrabajo.TiposTareaTrabajoQuery(Nothing, txtBuscar.Text)

                End Select


            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.Bancos) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCDatosLaborales.BuscarPersonaEntidad(txtBuscar.Text, Nothing, Nothing, "si")
                    Case 1
                        query = Me.BCDatosLaborales.BuscarPersonaEntidad(Nothing, txtBuscar.Text, Nothing, "si")

                End Select


            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.AreaTrabajos) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCAreaTrabajos.AreaTrabajosQuery(txtBuscar.Text, Nothing, -1)
                    Case 1
                        query = Me.BCAreaTrabajos.AreaTrabajosQuery(Nothing, txtBuscar.Text, -1)

                End Select


            End If


            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.DetalleConceptoPensionario) Then

                query = Me.BCDetalleConceptoPensionario.DetalleConceptosPensionariosQuery(sFiltro)

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.DatosTrabajadorJudicial) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCDatosTrabajadorJudicial.DatosTrabajadorJudicialQuery(txtBuscar.Text, Nothing)
                    Case 1
                        query = Me.BCDatosTrabajadorJudicial.DatosTrabajadorJudicialQuery(Nothing, txtBuscar.Text)
                End Select


            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.DetalleConceptosPlanillasLista) Then

                query = Me.BCDetalleConceptosPlanillas.DetalleConceptosPlanillasListaQuery(campo1, txtBuscar.Text, Nothing, IIf(campo2 = "" Or IsNothing(campo2), Nothing, campo2), IIf(campo3 = "" Or IsNothing(campo3), Nothing, campo3))

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.PrestamosTrabajador) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCPrestamosTrabajador.PrestamosTrabajadorQuery(txtBuscar.Text, Nothing)
                    Case 1
                        query = Me.BCPrestamosTrabajador.PrestamosTrabajadorQuery(Nothing, txtBuscar.Text)
                End Select

            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TareaTrabajo) Then
                query = Me.BCTareaTrabajo.TareaTrabajoQuery(sFiltro, txtBuscar.Text, campo1)
            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ArticulosLista) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCTareaTrabajo.ArticulosQuery(txtBuscar.Text, Nothing)
                    Case 1
                        query = Me.BCTareaTrabajo.ArticulosQuery(Nothing, txtBuscar.Text)
                End Select

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.PermisosTrabajador) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCPermisosTrabajador.PermisosTrabajadorQuery(txtBuscar.Text, Nothing, Nothing)
                    Case 1
                        query = Me.BCPermisosTrabajador.PermisosTrabajadorQuery(Nothing, txtBuscar.Text, Nothing)
                    Case 2
                        query = Me.BCPermisosTrabajador.PermisosTrabajadorQuery(Nothing, Nothing, txtBuscar.Text)
                End Select
            End If


            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.CentroRiesgo) Then

                query = Me.BCCentroRiesgo.CentroRiesgoQuery(Nothing, txtBuscar.Text.Trim)

            End If


            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    dgbRegistro.DataSource = ds.Tables(0)
                    ocultarColumnas()
                Else
                    dgbRegistro.DataSource = Nothing
                End If
            End If

          
        End Sub
        Private Sub ocultarColumnas()
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.TareaTrabajo) Then
                dgbRegistro.Columns("tit_TipTarea_Id").Visible = False
                dgbRegistro.Columns("Activo").Visible = False
                'dgbRegistro.Columns("Tarea").Visible = False

                dgbRegistro.Columns("Tarea").Width = dgbRegistro.Columns("Tarea").Width + 160
                dgbRegistro.Columns("Articulo").Width = dgbRegistro.Columns("Articulo").Width + 50


            End If
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.ConceptosPlanilla) Then
                dgbRegistro.Columns(0).Visible = False
                ' dgbRegistro.Columns(1).Visible = False
                dgbRegistro.Columns(1).HeaderText = "Trabajador"

                dgbRegistro.Columns(2).Visible = False
                ' dgbRegistro.Columns(3).Visible = False
                dgbRegistro.Columns(3).HeaderText = "Planilla"

                dgbRegistro.Columns(4).Visible = False
                dgbRegistro.Columns(5).Visible = False
                dgbRegistro.Columns(6).Visible = False
                dgbRegistro.Columns(7).Visible = False
                dgbRegistro.Columns(8).Visible = False
                dgbRegistro.Columns(9).Visible = False
                dgbRegistro.Columns(10).Visible = False
                dgbRegistro.Columns(11).HeaderText = "Descripcion"
                dgbRegistro.Columns(12).Visible = False
                dgbRegistro.Columns(13).Visible = False

            End If
        End Sub

        Private Sub frmBuscarConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            cargarDatos()
        End Sub

        Private Sub dgbRegistro_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgbRegistro.CellDoubleClick

            If e.RowIndex >= 0 Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End Sub

        Private Sub frmBuscarSimple_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
            txtBuscar.Focus()
        End Sub

        Private Sub frmBuscarSimple_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtBuscar.Focus()
        End Sub

        Private Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
  Handles txtBuscar.KeyDown, cboBuscar.KeyDown

            Select Case e.KeyValue
                Case 13
                    If dgbRegistro.SelectedRows.Count >= 0 Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If
                Case 27 : Me.Close()
                Case 40 : dgbRegistro.Focus()
            End Select



        End Sub

        Private Sub dataRegistros_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgbRegistro.KeyDown
            Select Case e.KeyValue
                Case 13
                    If dgbRegistro.SelectedRows.Count >= 0 Then

                        e.SuppressKeyPress = True

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If
                Case 27 : Me.Close()
            End Select

        End Sub

        Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
            If (txtBuscar.Text.Length >= 3) Then
                cargarDatos()
            End If
        End Sub
       
        Private Sub chkUsarFiltro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUsarFiltro.CheckedChanged

            cboBuscar.Enabled = chkUsarFiltro.Checked
            dgbRegistro.DataSource = Nothing

        End Sub

    End Class

End Namespace
