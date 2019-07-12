Imports Microsoft.Practices.Unity
Imports System.IO

Namespace Ladisac.Contabilidad.Views

    Public Class frmBuscarSimple
        Private sBuscar As String
        Private sBusco As String

        <Dependency()> _
        Public Property IBCClaseCuenta As Ladisac.BL.IBCClaseCuenta

        <Dependency()> _
        Public Property BCCuentasContables As Ladisac.BL.IBCCuentasContables
        <Dependency()> _
        Public Property BCLibrosContables As BL.IBCLibrosContables
        <Dependency()> _
        Public Property BCTiposBienesServicios As BL.IBCTiposBienesServicios
        <Dependency()> _
        Public Property BCCtaCte As BL.IBCCtaCte
        <Dependency()> _
        Public Property BCOperacionDetraciones As BL.IBCOperacionDetraciones
        <Dependency()> _
        Public Property BCCuentasArticulo As BL.IBCCuentasArticulo
        <Dependency()> _
        Public Property BCLineaFamilia As BL.IBCLineaFamilia
        <Dependency()> _
        Public Property BCConceptosPlanilla As BL.IBCConceptosPlanilla
        <Dependency()> _
        Public Property BCPeriodos As BL.IBCPeriodos

        <Dependency()> _
        Public Property BCCuentasVarias As BL.IBCCuentasVarias

        <Dependency()> _
        Public Property BCDatosLaborales As Ladisac.BL.IBCDatosLaborales
        <Dependency()> _
        Public Property BCMoneda As Ladisac.BL.IBCMoneda
        <Dependency()> _
        Public Property BCDetalleAsientosManuales As Ladisac.BL.IBCDetalleAsientosManuales

        <Dependency()> _
        Public Property BCCentroCosto As Ladisac.BL.IBCCentroCosto

        <Dependency()> _
        Public Property BCProvisionCompras As BL.IBCProvisionCompras
        <Dependency()> _
        Public Property BCConfiguracionFormatos As BL.IBCConfiguracionFormatos

        <Dependency()> _
        Public Property BCCuentasComprobantesLogistica As BL.IBCCuentasComprobantesLogistica

        <Dependency()> _
        Public Property BCCajaCtaCte As BL.IBCCajaCtaCte

        <Dependency()> _
        Public Property BCReparables As BL.IBCReparables

        <Dependency()> _
        Public Property BCDocumentoGuias As BL.IBCDocumentoGuias

        Public Property campo1() As String = Nothing
        Public Property campo2() As String = Nothing
        Public Property campo3() As String = Nothing


        Public Sub inicio(ByVal queBusco As String)
            sBusco = queBusco
            Me.lblTitle.Text = queBusco
            llenarCombo()

        End Sub
        Public Sub llenarCombo()
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ClaseCuenta) Then
                lblTitle.Text = "Clase-Cuentas"
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If

            '

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CuentasContables) Then
                lblTitle.Text = "Cuentas Contables"
                cboBuscar.Items.Add("Cuenta")
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.LibrosContables) Then
                lblTitle.Text = "Libros Contables"
                cboBuscar.Items.Add("Abreviatura")
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.LibrosContablesDividendos) Then
                lblTitle.Text = "Libros Contables"
                cboBuscar.Items.Add("Abreviatura")
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.TiposBienesServicios) Then
                lblTitle.Text = "Tipos de Bienes y Servicios"
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CtaCte) Then
                lblTitle.Text = "Cuentas Corrientes"
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.OperacionDetraciones) Then
                lblTitle.Text = "Operacion Detraciones"
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CuentasArticulo) Then
                lblTitle.Text = "Cuentas Articulos"
                cboBuscar.Items.Add("ID Linea")
                cboBuscar.SelectedIndex = 0
            End If
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.LineaFamilia) Then
                lblTitle.Text = "Familia LInea"
                cboBuscar.Items.Add("Todo")
                cboBuscar.SelectedIndex = 0
            End If
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ConceptosPlanilla) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo) Then
                cboBuscar.Items.Add("Periodo")
                cboBuscar.SelectedIndex = 0
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CuentasVarias) Then
                cboBuscar.Items.Add("ID")
                cboBuscar.SelectedIndex = 0
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.DatosLaborales) Then
                cboBuscar.Items.Add("ID")
                cboBuscar.Items.Add("Codigo")
                cboBuscar.Items.Add("Nombre")
                cboBuscar.SelectedIndex = 1
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Moneda) Then
                cboBuscar.Items.Add("Todo")
                cboBuscar.SelectedIndex = 0
            End If
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.RolOpeCtaCte) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CentroCosto) Then
                cboBuscar.Items.Add("Codigo")
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 1
            End If
            If (sBusco = Constants.BuscadoresNames.BuscarPersona) Then
                cboBuscar.Items.Add("ID")
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.Items.Add("RUC")
                cboBuscar.Items.Add("DNI")
                cboBuscar.SelectedIndex = 1
            End If

            If (sBusco = Constants.BuscadoresNames.TiposComprobantesSelectXML) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If

            If (sBusco = Constants.BuscadoresNames.TiposComprobantesDividendosSelectXML) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If

            If (sBusco = Constants.BuscadoresNames.PuntoVenta) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If
            If (sBusco = Constants.BuscadoresNames.CondicionCompra) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If
            If (sBusco = Constants.BuscadoresNames.ConfiguracionFormatos ) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If


            If (sBusco = Constants.BuscadoresNames.BuscarAlmacen) Then
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If


            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ArticulosLadrillo) Then
                cboBuscar.Items.Add("ID")
                cboBuscar.Items.Add("Codigo Fabrica")
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 2
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CajaCtaCteSelectXML) Then
                lblTitle.Text = "Descripcion"
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Reparable) Then
                lblTitle.Text = "Descripcion"
                cboBuscar.Items.Add("Descripcion")
                cboBuscar.SelectedIndex = 0
            End If
            If (sBusco = "DocumentoGuias") Then
                lblTitle.Text = "Descripcion"
                cboBuscar.Items.Add("Codigo")
                cboBuscar.Items.Add("Proveedor")
                cboBuscar.Items.Add("Serie")
                cboBuscar.Items.Add("Numero")
                cboBuscar.SelectedIndex = 0
            End If

        End Sub

        Public Sub OcultarColumnas()

            Try
                If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.TiposComprobantesSelectXML) Then
                    dgbRegistro.Columns(0).Visible = False
                    dgbRegistro.Columns(1).Visible = False
                    dgbRegistro.Columns(2).Visible = False
                    dgbRegistro.Columns(3).Width = "140"
                End If
                If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.OperacionDetraciones) Then

                    dgbRegistro.Columns(2).Visible = False
                    dgbRegistro.Columns(3).Visible = False

                    dgbRegistro.Columns(1).Width = "170"
                End If
                If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.TiposBienesServicios) Then
                    dgbRegistro.Columns(3).Visible = False
                    dgbRegistro.Columns(4).Visible = False
                    dgbRegistro.Columns(3).HeaderText = "%"
                    dgbRegistro.Columns(3).Width = "70"
                    dgbRegistro.Columns(1).Width = "140"
                End If

                If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CentroCosto) Then
                    dgbRegistro.Columns(2).Visible = False
                    dgbRegistro.Columns(3).Visible = False
                    dgbRegistro.Columns(4).Visible = False

                    dgbRegistro.Columns(1).Width = "170"

                End If
            Catch ex As Exception

            End Try
        End Sub
        Public Sub cargarDatos()
            Dim query As String = Nothing


            dgbRegistro.DataSource = Nothing

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ClaseCuenta) Then
                query = Me.IBCClaseCuenta.ClaseCuentaQuery(Nothing, txtBuscar.Text.Trim)

            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CuentasContables) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCCuentasContables.CuentasContablesQuery(txtBuscar.Text, Nothing, Nothing, 2)
                    Case 1
                        query = Me.BCCuentasContables.CuentasContablesQuery(Nothing, txtBuscar.Text, Nothing, 2)
                End Select

            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.LibrosContables) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCLibrosContables.LibrosContablesQuery(Nothing, txtBuscar.Text, Nothing)
                    Case 1
                        query = Me.BCLibrosContables.LibrosContablesQuery(Nothing, Nothing, txtBuscar.Text)
                End Select
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.LibrosContablesDividendos) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCLibrosContables.LibrosContablesDividendosQuery(Nothing, txtBuscar.Text, Nothing)
                    Case 1
                        query = Me.BCLibrosContables.LibrosContablesDividendosQuery(Nothing, Nothing, txtBuscar.Text)
                End Select
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.TiposBienesServicios) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCTiposBienesServicios.TiposBienesServiciosQuery(Nothing, txtBuscar.Text)
                End Select
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CtaCte) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCCtaCte.CtaCteQuery(Nothing, txtBuscar.Text)
                End Select
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.OperacionDetraciones) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCOperacionDetraciones.OperacionDetracionesQuery(Nothing, txtBuscar.Text)
                End Select
            End If


            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CuentasArticulo) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCCuentasArticulo.CuentasArticuloQuery(txtBuscar.Text)
                End Select
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.LineaFamilia) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCLineaFamilia.ListaLineaFamilia()
                End Select
            End If
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ConceptosPlanilla) Then
                query = Me.BCConceptosPlanilla.ConceptosPlanillasDetalleQuery(Nothing, Nothing, Nothing, txtBuscar.Text)

            End If
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo) Then
                query = Me.BCPeriodos.PeriodoQuery(txtBuscar.Text.Trim())

            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CuentasVarias) Then
                query = Me.BCCuentasVarias.CuentasVariasQuery(txtBuscar.Text.Trim())
            End If


            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.DatosLaborales) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCDatosLaborales.DatosLaboralesListaQuery(txtBuscar.Text, Nothing, Nothing)
                    Case 1
                        query = Me.BCDatosLaborales.DatosLaboralesListaQuery(Nothing, txtBuscar.Text, Nothing)

                    Case 2
                        query = Me.BCDatosLaborales.DatosLaboralesListaQuery(Nothing, Nothing, txtBuscar.Text)

                End Select
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Moneda) Then
                query = Me.BCMoneda.ListaMoneda()
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.RolOpeCtaCte) Then
                query = Me.BCDetalleAsientosManuales.RolOpeCtaCteQuery(campo1, Nothing, Nothing, txtBuscar.Text)
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CentroCosto) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCCentroCosto.CentroCostoQuery(txtBuscar.Text, Nothing)
                    Case 1
                        query = Me.BCCentroCosto.CentroCostoQuery(Nothing, txtBuscar.Text)
                End Select
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarPersona) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCDatosLaborales.BuscarPersonaEntidad(txtBuscar.Text, Nothing, "NO", "NO", Nothing, Nothing)
                    Case 1
                        query = Me.BCDatosLaborales.BuscarPersonaEntidad(Nothing, txtBuscar.Text, "NO", "NO", Nothing, Nothing)
                    Case 2
                        query = Me.BCDatosLaborales.BuscarPersonaEntidad(Nothing, Nothing, "NO", "NO", txtBuscar.Text, Nothing)
                    Case 3
                        query = Me.BCDatosLaborales.BuscarPersonaEntidad(Nothing, Nothing, "NO", "NO", Nothing, txtBuscar.Text)

                End Select


            End If


            If (sBusco = Constants.BuscadoresNames.TiposComprobantesSelectXML) Then
                query = Me.BCProvisionCompras.ProvisionComprasTipoComprobantes(txtBuscar.Text)
            End If

            If (sBusco = Constants.BuscadoresNames.TiposComprobantesDividendosSelectXML) Then
                query = Me.BCProvisionCompras.ProvisionComprasTipoComprobantesDividendos(txtBuscar.Text)

            End If


            If (sBusco = Constants.BuscadoresNames.PuntoVenta) Then
                query = Me.BCProvisionCompras.PuntoVenta(txtBuscar.Text)

            End If

            If (sBusco = Constants.BuscadoresNames.CondicionCompra) Then
                query = Me.BCProvisionCompras.TipoVenta(txtBuscar.Text)

            End If

            If (sBusco = Constants.BuscadoresNames.ConfiguracionFormatos) Then
                query = Me.BCConfiguracionFormatos.ConfiguracionFormatosQuery(txtBuscar.Text)

            End If

            If (sBusco = Constants.BuscadoresNames.BuscarAlmacen) Then
                query = Me.BCCuentasComprobantesLogistica.spAlmacenSelect(txtBuscar.Text)
            End If

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.ArticulosLadrillo) Then

                Select Case cboBuscar.SelectedIndex
                    Case 0 'Add("ID")
                        query = Me.BCCuentasArticulo.SPArticulosLadrillo(txtBuscar.Text, Nothing, Nothing)
                    Case 1 'Add("Codigo Fabrica")
                        query = Me.BCCuentasArticulo.SPArticulosLadrillo(Nothing, txtBuscar.Text, Nothing)
                    Case 2 'Add("Descripcion")
                        query = Me.BCCuentasArticulo.SPArticulosLadrillo(Nothing, Nothing, txtBuscar.Text)
                 
                End Select

            End If

            'CajaCtaCteSelectXML
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CajaCtaCteSelectXML) Then
                Select Case cboBuscar.SelectedIndex
                    Case 0
                        query = Me.BCCajaCtaCte.spCajaCtaCteSelectXML(txtBuscar.Text, Nothing)
                    Case 1
                        query = Me.BCCajaCtaCte.spCajaCtaCteSelectXML(Nothing, txtBuscar.Text)
                  
                End Select
            End If
            'reparable 
            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.Reparable) Then
              
                        query = Me.BCReparables.spTiposReparablesSelectXML(txtBuscar.Text)
                 
            End If

            If (sBusco = "DocumentoGuias") Then
                query = BCDocumentoGuias.ListaDocumentoGuias()

            End If

            If (query <> Nothing) Then
                Dim ds As New DataSet

                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    dgbRegistro.DataSource = ds.Tables(0)
                Else
                    dgbRegistro.DataSource = Nothing
                End If
            End If
            OcultarColumnas()
        End Sub
        Private Sub dgbRegistro_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgbRegistro.CellDoubleClick
            If e.RowIndex >= 0 Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            cargarDatos()
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


            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CentroCosto OrElse _
                sBusco = Constants.BuscadoresNames.TiposComprobantesSelectXML) Then
                cargarDatos()
            Else
                If (txtBuscar.Text.Length >= 4) Then
                    cargarDatos()
                End If
            End If
           
        End Sub

        Private Sub txtBuscar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress

            If (e.KeyChar = Chr(Keys.Enter)) Then
                If (dgbRegistro.RowCount <= 0) Then
                    Me.Dispose()
                End If

            End If

        End Sub
    End Class

End Namespace

