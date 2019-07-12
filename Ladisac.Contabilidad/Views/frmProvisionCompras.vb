
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views

    Public Class frmProvisionCompras

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro


        <Dependency()> _
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property BCProvisionCompras As Ladisac.BL.IBCProvisionCompras

        <Dependency()> _
        Public Property BCDetalleProvisionCompras As Ladisac.BL.IBCDetalleProvisionCompras

        <Dependency()> _
        Public Property BCReferenciaProvisionCompras As Ladisac.BL.IBCReferenciaProvisionCompras

        <Dependency()> _
        Public Property BCCuentasComprobantesLogistica As Ladisac.BL.IBCCuentasComprobantesLogistica

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oProvisionCompras As New BE.ProvisionCompras

        Dim oReporte As New rptProvisionComprasImprime
        Private Function validar() As Boolean
            Dim result As Boolean = True
            Dim dImporte As Double = 0

            Try
                dImporte = Math.Round(Val(txtBaseImponible.Text) + Val(txtNoGrvado.Text) + Val(txtOtrosTributos.Text), 2) ' IIf((Val(txtBaseImponible.Text) + Val(txtNoGrvado.Text)) > 0, Val(txtBaseImponible.Text), Val(txtNoGrvado.Text))
            Catch ex As Exception

            End Try

            If (txtPeriodo.Text.Trim = "") Then
                ErrorProvider1.SetError(txtPeriodo, "Periodo")
                result = False
            Else
                ErrorProvider1.SetError(txtPeriodo, Nothing)
            End If

            If (txtLibro.Text.Trim = "") Then
                ErrorProvider1.SetError(txtLibro, "Libro")
                result = False
            Else
                ErrorProvider1.SetError(txtLibro, Nothing)
            End If

            If (txtOtrosTributos.Text.Trim = "") Then
                ErrorProvider1.SetError(txtOtrosTributos, "Otros Tributos , no puede estar en blanco")
                result = False
            Else
                ErrorProvider1.SetError(txtOtrosTributos, Nothing)
            End If

            If (CDate(dateFechaVoucher.Text).ToString("yyyyMM") <> (txtPeriodo.Text)) Then

                ErrorProvider1.SetError(dateFechaVoucher, "Fecha Fuera de Periodo")

                result = False
            Else
                ErrorProvider1.SetError(dateFechaVoucher, Nothing)
            End If

            If (txtImporteISC.Text.Trim = "") Then
                ErrorProvider1.SetError(txtImporteISC, "Importe I.S.C. , no puede estar en blanco")
                result = False
            Else
                ErrorProvider1.SetError(txtImporteISC, Nothing)
            End If

            ' leasing, DUA 
            If Not ((txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "079") Or (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "076")) Then

                If (dgvDetalle.Rows.Count <= 0) Then
                    ErrorProvider1.SetError(dgvDetalle, "Detalle")
                    result = False
                Else
                    ErrorProvider1.SetError(dgvDetalle, Nothing)
                End If

                If (Val(txtSaldoXDistribuir.Text) <> dImporte) Then
                    ErrorProvider1.SetError(txtSaldoXDistribuir, "Distribucion Contable")
                    result = False
                Else
                    ErrorProvider1.SetError(txtSaldoXDistribuir, Nothing)
                End If

            End If
            If Not (IsNumeric(txtTotal.Text) AndAlso Val(txtTotal.Text) > 0) Then
                ErrorProvider1.SetError(txtTotal, "Total")
                result = False
            Else
                ErrorProvider1.SetError(txtTotal, Nothing)
            End If

            If Not (IsNumeric(Val(txtBaseImponible.Text))) Then
                ErrorProvider1.SetError(txtBaseImponible, "Base Imponible")
                result = False
            Else
                ErrorProvider1.SetError(txtBaseImponible, Nothing)
            End If

            If Not (IsNumeric(Val(txtValorCIF.Text))) Then
                ErrorProvider1.SetError(txtValorCIF, "Valor CIF")
                result = False
            Else
                ErrorProvider1.SetError(txtValorCIF, Nothing)
            End If

            If Not (IsNumeric(Val(txtAdvalore.Text))) Then
                ErrorProvider1.SetError(txtAdvalore, "Advalore")
                result = False
            Else
                ErrorProvider1.SetError(txtAdvalore, Nothing)
            End If

            If Not (IsNumeric(Val(txtNoGrvado.Text))) Then
                ErrorProvider1.SetError(txtNoGrvado, "No Gravado")
                result = False
            Else
                ErrorProvider1.SetError(txtNoGrvado, Nothing)
            End If
            If Not (IsNumeric(Val(txtIGV.Text))) Then
                ErrorProvider1.SetError(txtIGV, "IGV")
                result = False
            Else
                ErrorProvider1.SetError(txtIGV, Nothing)
            End If

            If Not (IsNumeric(Val(txtDescuento.Text))) Then
                ErrorProvider1.SetError(txtDescuento, "Descuento")
                result = False
            Else
                ErrorProvider1.SetError(txtDescuento, Nothing)
            End If
            If Not (IsNumeric(Val(txtPercepcion.Text))) Then
                ErrorProvider1.SetError(txtPercepcion, "Percepcion")
                result = False
            Else
                ErrorProvider1.SetError(txtPercepcion, Nothing)
            End If

            If (txtTipoVenta.Tag = "") Then
                ErrorProvider1.SetError(txtTipoVenta, "Condicion Compra")
                result = False
            Else
                ErrorProvider1.SetError(txtTipoVenta, Nothing)
            End If
            If (txtTipoDocumento.Tag = "") Then
                ErrorProvider1.SetError(txtTipoDocumento, "Tipo Documento")
                result = False
            Else
                ErrorProvider1.SetError(txtTipoDocumento, Nothing)
            End If
            If (txtSerie.Text = "") Then
                ErrorProvider1.SetError(txtSerie, "Serie")
                result = False
            Else
                ErrorProvider1.SetError(txtSerie, Nothing)
            End If
            If (txtNumero.Text = "") Then
                ErrorProvider1.SetError(txtNumero, "Numero")
                result = False
            Else
                ErrorProvider1.SetError(txtNumero, Nothing)
            End If
            If (txtPersona.Tag = "") Then
                ErrorProvider1.SetError(txtPersona, "Persona")
                result = False
            Else
                ErrorProvider1.SetError(txtPersona, Nothing)
            End If

            'If (txtPuntoVenta.Tag = "") Then
            '    ErrorProvider1.SetError(txtPuntoVenta, "Dependencia")
            '    result = False
            'Else

            '    ErrorProvider1.SetError(txtPuntoVenta, Nothing)
            'End If

            If (txtFecha.Text = "" OrElse Not IsDate(txtFecha.Text)) Then
                ErrorProvider1.SetError(txtFecha, "Fecha Documento")
                result = False
            Else
                If CDate(IBCMaestro.EjecutarVista("spFechaServidor")) < CDate(txtFecha.Text) Then
                    ErrorProvider1.SetError(txtFecha, "Fecha Documento")
                    result = False
                Else
                    ErrorProvider1.SetError(txtFecha, "")
                End If
            End If


            If (txtMoneda.Tag = "") Then
                ErrorProvider1.SetError(txtMoneda, "Moneda")
                result = False

            Else

                ErrorProvider1.SetError(txtMoneda, "")
            End If

            If (txtFechaVencimiento.Text = "" OrElse Not IsDate(txtFechaVencimiento.Text)) Then
                txtFechaVencimiento.Text = txtFecha.Text
            Else
                If CDate(txtFechaVencimiento.Text) < CDate(txtFecha.Text) Then
                    ErrorProvider1.SetError(txtFechaVencimiento, "Fecha vencimiento")
                    result = False
                Else
                    ErrorProvider1.SetError(txtFechaVencimiento, "")
                End If
            End If

            'If (txtcentroCosto.Tag = "") Then
            '    ErrorProvider1.SetError(txtcentroCosto, "Centro Costo")
            '    result = False
            'Else
            '    ErrorProvider1.SetError(txtcentroCosto, "")
            'End If

            If (chkAfectoSPOT.Checked) Then
                If (txtNumeroSPOT.Text = "") Then
                    If (txtTipoDetraccion.Text = "" AndAlso txtOperacionDetraccion.Text = "") Then
                        result = False
                        ErrorProvider1.SetError(txtTipoDetraccion, "Detraccion")
                    Else
                        ErrorProvider1.SetError(txtTipoDetraccion, "")
                    End If
                Else
                    If (txtFechaSPOT.Text.Length < 6) Then
                        result = False
                        ErrorProvider1.SetError(txtFechaSPOT, "Fecha")
                    Else
                        ErrorProvider1.SetError(txtFechaSPOT, "")
                    End If
                End If
            End If

            If Not (txtTipoDocumento.Tag = "013" And txtCombrobante.Tag = "076") Then
                If (Not validarCeldas()) Then
                    MsgBox("Debe ingresar cuenta contable")
                    result = False
                End If
            End If



            Return result

        End Function
        Sub cargarMonedaDefault()
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Moneda)
            frm.cargarDatos()
            If (frm.dgbRegistro.Rows.Count > 0) Then
                With frm.dgbRegistro.Rows(0)
                    txtMoneda.Tag = .Cells(0).Value
                    txtMoneda.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub
        Sub CargarPuntoVentaDefault()

            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.PuntoVenta)
            frm.cargarDatos()

            If (frm.dgbRegistro.RowCount > 0) Then
                With frm.dgbRegistro.Rows(0)
                    txtPuntoVenta.Tag = .Cells(0).Value
                    txtPuntoVenta.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()

        End Sub
        Sub CargarCondicionCompraDefault()

            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CondicionCompra)
            frm.cargarDatos()
            If (frm.dgbRegistro.Rows.Count > 0) Then
                With frm.dgbRegistro.Rows(0)
                    txtTipoVenta.Tag = .Cells(0).Value
                    txtTipoVenta.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()

        End Sub

        Sub CargarLibroDefault()
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()

            If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.LibrosContablesDividendos)
                frm.txtBuscar.Text = "Diario Aux."
            Else
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.LibrosContables)
                frm.txtBuscar.Text = "Compras"
            End If

            frm.llenarCombo()
            frm.cargarDatos()
            If (frm.dgbRegistro.Rows.Count > 0) Then

                With frm.dgbRegistro.Rows(0)
                    txtLibro.Tag = .Cells(0).Value
                    txtLibro.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
            dateFechaVoucher.Focus()

        End Sub
        Sub totalBase()
            Dim baseImponible, igv, descuentosObtenidos, NOGravado As Double
            If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then
                Try
                    baseImponible = Val(txtBaseImponible.Text) - Val(txtIGV.Text)

                    descuentosObtenidos = Val(txtDescuento.Text)
                    baseImponible = Val(txtBaseImponible.Text)
                    NOGravado = Val(txtNoGrvado.Text)
                    igv = Val(txtIGV.Text)
                    txtTotal.Text = CStr(baseImponible + igv + NOGravado - descuentosObtenidos)

                Catch ex As Exception
                End Try
            Else
                Try
                    descuentosObtenidos = Val(txtDescuento.Text)
                    baseImponible = Val(txtBaseImponible.Text)
                    NOGravado = Val(txtNoGrvado.Text)
                    igv = Val(txtIGV.Text)
                    txtTotal.Text = CStr(baseImponible + igv + NOGravado - descuentosObtenidos)
                Catch ex As Exception
                End Try
            End If
        End Sub
        Sub sumar()
            Dim x As Integer = 0
            Dim dCargo As Double

            If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then
                Try
                    While (dgvDetalle.Rows.Count > x)
                        dCargo += Val(dgvDetalle.Rows(x).Cells("prd_Importe").Value)
                        x += 1
                    End While
                Catch ex As Exception
                End Try
                txtBaseImponible.Text = dCargo.ToString
                txtBaseImponible.Text = Val(txtBaseImponible.Text) - Val(txtIGV.Text)
                txtSaldoXDistribuir.Text = Val(txtBaseImponible.Text)
            Else
                Try
                    While (dgvDetalle.Rows.Count > x)
                        dCargo += Val(dgvDetalle.Rows(x).Cells("prd_Importe").Value)
                        x += 1
                    End While
                    txtSaldoXDistribuir.Text = dCargo.ToString
                Catch ex As Exception
                End Try
                txtSaldoXDistribuir.Text = dCargo.ToString
            End If
            
        End Sub
        Sub sumarAfectaciones()
            Dim x As Integer = 0
            Dim dCargo As Double
            Try
                While (dgvNotaCredito.Rows.Count > x)
                    dCargo += Val(dgvNotaCredito.Rows(x).Cells("DataGridViewTextBoxColumn7").Value)
                    x += 1
                End While
            Catch ex As Exception
                txtDistribucionAfectacion.Text = "0.00"
            End Try
            txtDistribucionAfectacion.Text = dCargo.ToString
        End Sub

        Sub sumarGuias()

            Dim x As Integer = 0
            Dim dCargo As Double = 0
            Try
                While (dgvguias.Rows.Count > x)

                    dCargo += Val(dgvguias.Rows(x).Cells("rep_Importe").Value)

                    x += 1
                End While
                txtDistribucionGuias.Text = dCargo.ToString

            Catch ex As Exception


            End Try
            txtDistribucionGuias.Text = dCargo.ToString
        End Sub

        Private Sub limpiar()
            lblOrdenTrabajo.Text = "0"

            txtAdvalore.Text = "0.00"
            txtBaseImponible.Text = "0.00"
            txtCombrobante.Text = ""
            txtCombrobante.Tag = ""
            txtCPNumero.Text = ""
            txtCPOriginal.Text = ""
            txtCPSerie.Text = ""
            txtCuentaCorriente.Text = ""
            txtCuentaCorriente.Tag = ""
            txtDescuento.Text = "0.00"
            txtCompras.Text = ""


            txtDua.Text = ""
            txtFecha.Text = ""
            txtFechaSPOT.Text = ""
            txtFechaVencimiento.Text = ""
            txtglosa.Text = ""
            txtIGV.Text = "0.00"
            txtLibro.Text = ""
            txtLibro.Tag = ""
            txtMoneda.Text = ""
            txtMoneda.Tag = ""
            txtNoGrvado.Text = "0.00"
            txtNumero.Text = ""
            txtNumeroSPOT.Text = ""
            txtOperacionDetraccion.Text = ""
            txtOperacionDetraccion.Tag = ""
            txtPercepcion.Text = "0.00"
            txtDistribucionAfectacion.Text = "0.00"
            txtDistribucionAfectacion.Text = "0.0"
            'txtPeriodo.Text = ""
            'txtPeriodo.Tag = ""

            txtPersona.Text = ""
            txtPersona.Tag = ""

            txtRuc.Text = ""
            txtSerie.Text = ""
            txtSerieSunat.Text = ""
            txtTipoDetraccion.Text = ""
            txtTipoDetraccion.Tag = ""
            txtTipoDocumento.Text = ""
            txtTipoDocumento.Tag = ""

            txtTotal.Text = "0.00"
            txtValorCIF.Text = "0.00"
            txtVoucher.Text = ""
            txtImporteISC.Text = "0.00"
            txtOtrosTributos.Text = "0.00"
            txtTotalADistribuir.Text = "0.00"
            txtPorDistribuir.Text = "0.00"
            txtPuntoVenta.Tag = ""
            txtPuntoVenta.Text = ""
            txtSaldoXDistribuir.Text = "0.00"
            txtTipoVenta.Tag = ""
            txtTipoVenta.Text = ""

            txtcentroCosto.Tag = ""
            txtcentroCosto.Text = ""
            txtSaldoXDistribuir.Text = ""

            txtCPOriginal.Tag = "" 'dtd
            txtCPOriginal.Text = ""

            txtCPSerie.Text = ""
            txtCPNumero.Text = Nothing

            txtCPSerie.Tag = Nothing ' cct_corriente 
            txtCPNumero.Tag = Nothing 'tdt

            txtReparable.Tag = ""
            txtReparable.Text = ""

            txtResponsable.Tag = Nothing
            txtResponsable.Text = ""

            chkRetencion4ta.Checked = False
            chkRetenerTercera.Checked = False

            chkAfectoSPOT.Checked = False
            txtNumeroSPOT.ReadOnly = Not chkAfectoSPOT.Checked
            txtFechaSPOT.ReadOnly = Not chkAfectoSPOT.Checked
            btnOperacion.Enabled = chkAfectoSPOT.Checked
            btnTipoDetraccion.Enabled = chkAfectoSPOT.Checked

            txtSerie.ReadOnly = False
            txtNumero.ReadOnly = False

            chkRetencion4ta.Enabled = False


            dgvDetalle.Rows.Clear()
            dgvguias.Rows.Clear()
            dgvNotaCredito.Rows.Clear()

            CargarCondicionCompraDefault()
            CargarPuntoVentaDefault()
            cargarMonedaDefault()
            CargarLibroDefault()

            HabilitarReportes = False


        End Sub

        Sub cargar(ByVal prd_Periodo_id As String, ByVal lib_Id As String, ByVal prc_Voucher As String)
            limpiar()
            oProvisionCompras = BCProvisionCompras.ProvisionComprasSeek(prd_Periodo_id, prc_Voucher, lib_Id)
            oProvisionCompras.MarkAsModified()

            txtPeriodo.Text = oProvisionCompras.prd_Periodo_id
            txtVoucher.Text = oProvisionCompras.prc_Voucher
            txtLibro.Tag = oProvisionCompras.lib_Id
            txtLibro.Text = oProvisionCompras.LibrosContables.lib_Descripcion
            txtCompras.Text = IIf(oProvisionCompras.dmo_Id Is Nothing, "", oProvisionCompras.dmo_Id)

            If Not (txtCompras.Text = "") Then
                txtSerie.ReadOnly = True
                txtNumero.ReadOnly = True
            End If

            txtAnioDua.Text = oProvisionCompras.prc_AnioDUA
            txtSerieSunat.Text = oProvisionCompras.prc_SerieSunat
            txtSerie.Text = oProvisionCompras.prc_Serie
            txtNumero.Text = oProvisionCompras.prc_Numero
            txtCuentaCorriente.Text = oProvisionCompras.cct_Id
            dateFechaVoucher.Text = (oProvisionCompras.prc_FechaVoucher)

            If Not IsNumeric(oProvisionCompras.OTR_ID) Then
                lblOrdenTrabajo.Text = "0"
            Else
                lblOrdenTrabajo.Text = oProvisionCompras.OTR_ID
            End If


            If Trim(lblOrdenTrabajo.Text) = "" Or Not IsNumeric(lblOrdenTrabajo.Text) Then
                lblOrdenTrabajo.Text = "0"
            End If


            If (IsDate(oProvisionCompras.prc_FechaDocumento)) Then
                txtFecha.Text = CDate(oProvisionCompras.prc_FechaDocumento)
            Else
                txtFecha.Text = ""
            End If

            If (IsDate(oProvisionCompras.prc_FechaVencimiento)) Then
                txtFechaVencimiento.Text = CDate(oProvisionCompras.prc_FechaVencimiento)
            Else
                txtFechaVencimiento.Text = ""
            End If




            txtglosa.Text = oProvisionCompras.prc_Glosa
            txtMoneda.Tag = oProvisionCompras.mon_Id
            txtMoneda.Text = oProvisionCompras.Moneda.MON_SIMBOLO
            txtValorCIF.Text = oProvisionCompras.prc_ImporteCIF
            txtBaseImponible.Text = oProvisionCompras.prc_BaseImponible

            txtIGV.Text = oProvisionCompras.prc_Igv
            txtNoGrvado.Text = oProvisionCompras.prc_NoGravado
            txtDescuento.Text = oProvisionCompras.prc_DescuentosObtenidos
            txtPercepcion.Text = oProvisionCompras.prc_ImportePercepcion
            txtTotal.Text = oProvisionCompras.prc_Total

            txtImporteISC.Text = oProvisionCompras.prc_ImporteISC
            txtOtrosTributos.Text = oProvisionCompras.prc_OtrosTributos

            If Not (oProvisionCompras.opd_Oper_Detra_Id Is Nothing) Then
                txtOperacionDetraccion.Tag = oProvisionCompras.opd_Oper_Detra_Id
                txtOperacionDetraccion.Text = oProvisionCompras.OperacionDetraciones.opd_Descripcion
            Else
                txtOperacionDetraccion.Tag = ""
                txtOperacionDetraccion.Text = ""
            End If

            If Not (oProvisionCompras.tib_TipoBien_Id Is Nothing) Then
                txtTipoDetraccion.Tag = oProvisionCompras.tib_TipoBien_Id
                txtTipoDetraccion.Text = oProvisionCompras.TiposBienesServicios.tib_Descripcion
            Else
                txtTipoDetraccion.Tag = ""
                txtTipoDetraccion.Text = ""

            End If

            txtTipoDocumento.Text = oProvisionCompras.tdo_Id
            txtTipoDocumento.Tag = oProvisionCompras.tdo_Id
            txtCombrobante.Tag = oProvisionCompras.dtd_Id
            txtCombrobante.Text = oProvisionCompras.RolOpeCtaCte.DetalleTipoDocumentos.DTD_DESCRIPCION
            If (IsDate(oProvisionCompras.prc_FechaSpot)) Then
                txtFechaSPOT.Text = CDate(oProvisionCompras.prc_FechaSpot)
            Else
                txtFechaSPOT.Text = ""
            End If


            txtNumeroSPOT.Text = oProvisionCompras.prc_NumeroSpot
            chkAfectoSPOT.Checked = oProvisionCompras.prc_EsDetraccion

            If (oProvisionCompras.pve_Id Is Nothing) Then
                oProvisionCompras.pve_Id = ""
            Else
                txtPuntoVenta.Tag = oProvisionCompras.pve_Id
                txtPuntoVenta.Text = oProvisionCompras.PuntoVenta.PVE_DESCRIPCION
            End If


            txtDua.Text = oProvisionCompras.prc_NumeroDocAduana

            txtTipoVenta.Tag = oProvisionCompras.TIV_ID
            txtTipoVenta.Text = oProvisionCompras.TipoVenta.TIV_DESCRIPCION
            txtResponsable.Tag = oProvisionCompras.per_idResponsable

            If (oProvisionCompras.per_idResponsable <> "") Then
                txtResponsable.Tag = oProvisionCompras.per_Id
                txtResponsable.Text = IIf(IsNothing(oProvisionCompras.Personas1.PER_APE_PAT), "", oProvisionCompras.Personas1.PER_APE_PAT) & " " & _
              IIf(IsNothing(oProvisionCompras.Personas1.PER_APE_MAT), "", oProvisionCompras.Personas1.PER_APE_MAT) & " " & _
              IIf(IsNothing(oProvisionCompras.Personas1.PER_NOMBRES), "", oProvisionCompras.Personas1.PER_NOMBRES)
            Else
                txtPersona.Tag = Nothing
            End If

            txtAdvalore.Text = oProvisionCompras.prc_Advalorem
            ' =oProvisionCompras.prc_ImporteInvenTotal
            txtPersona.Tag = oProvisionCompras.per_Id
            If (oProvisionCompras.per_Id <> "") Then
                txtPersona.Tag = oProvisionCompras.per_Id
                txtPersona.Text = IIf(IsNothing(oProvisionCompras.Personas.PER_APE_PAT), "", oProvisionCompras.Personas.PER_APE_PAT) & " " & _
              IIf(IsNothing(oProvisionCompras.Personas.PER_APE_MAT), "", oProvisionCompras.Personas.PER_APE_MAT) & " " & _
              IIf(IsNothing(oProvisionCompras.Personas.PER_NOMBRES), "", oProvisionCompras.Personas.PER_NOMBRES)
            Else
                txtPersona.Tag = Nothing
            End If

            txtDistribucionAfectacion.Text = oProvisionCompras.prc_ImporteDocRef
            chkRetencion4ta.Checked = oProvisionCompras.prc_RetenerRenta4ta

            chkRetenerTercera.Checked = IIf(IsDBNull(oProvisionCompras.prc_RetenerRenta3ra), False, oProvisionCompras.prc_RetenerRenta3ra)

            txtCPOriginal.Tag = oProvisionCompras.dtd_IdRef 'dtd

            txtCPSerie.Text = oProvisionCompras.prc_SerieRef
            txtCPNumero.Text = oProvisionCompras.prc_NumeroRef

            txtCPSerie.Tag = oProvisionCompras.cct_IdRef ' cct_corriente 
            txtCPNumero.Tag = oProvisionCompras.tdo_IdRef 'tdt


            If (oProvisionCompras.dtd_IdRef Is Nothing) Then
                txtCPOriginal.Text = Nothing
            Else
                txtCPOriginal.Text = oProvisionCompras.DetalleTipoDocumentos.DTD_DESCRIPCION
            End If

            Try
                If Not (IsDBNull(oProvisionCompras.CCO_ID)) Then
                    txtcentroCosto.Text = oProvisionCompras.CentroCostos.CCO_DESCRIPCION
                    txtcentroCosto.Tag = oProvisionCompras.CCO_ID
                End If
            Catch ex As Exception

            End Try

            Try
                txtReparable.Tag = oProvisionCompras.rep_id
                txtReparable.Text = oProvisionCompras.TiposReparables.rep_Descripcion


            Catch ex As Exception

            End Try

            'cambiar configuracion segun tipo de documento 
            BloquearSegunTipoDoc()

            'cuentas contables 
            For Each mItem In oProvisionCompras.DetalleProvisionCompras

                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("prd_Item").Value = mItem.prd_Item
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("prd_Item").Tag = mItem

                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cuc_Id").Tag = mItem.cuc_Id
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cuc_Id").Value = mItem.cuc_Id
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cuenta").Value = mItem.CuentasContables.CUC_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cls_Id").Tag = mItem.cls_Id

                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("prd_Importe").Value = mItem.prd_Importe

                If Not (IsDBNull(mItem.ALM_ID) OrElse mItem.ALM_ID Is Nothing) Then

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID").Tag = mItem.ALM_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Almacen").Value = mItem.Almacen.ALM_DESCRIPCION
                Else

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID").Tag = mItem.ALM_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID").Value = mItem.ALM_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Almacen").Value = ""

                End If

                If (mItem.cco_Id <> "") Then
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cco_Id").Tag = mItem.cco_Id
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CentroCosto").Value = mItem.CentroCostos.CCO_DESCRIPCION
                Else
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("cco_Id").Tag = Nothing
                End If

                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Glosa").Value = mItem.prd_Glosa

            Next

            ' referencias (logistica) (notas de credito )
            For Each mItem In oProvisionCompras.ReferenciaProvisionCompras

                If (CBool(mItem.rep_EsLogistica)) Then

                    dgvguias.Rows.Add()

                    dgvguias.Rows(dgvDetalle.Rows.Count - 1).Cells("rep_Item").Tag = mItem

                    dgvguias.Rows(dgvDetalle.Rows.Count - 1).Cells("cct_Id").Value = mItem.cct_Id
                    dgvguias.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_Id").Value = mItem.tdo_Id
                    dgvguias.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_Id").Value = mItem.dtd_Id
                    dgvguias.Rows(dgvDetalle.Rows.Count - 1).Cells("rep_Item").Value = mItem.rep_Item
                    dgvguias.Rows(dgvDetalle.Rows.Count - 1).Cells("rep_Item").Tag = mItem

                    dgvguias.Rows(dgvDetalle.Rows.Count - 1).Cells("rep_Serie").Value = mItem.rep_Serie
                    dgvguias.Rows(dgvDetalle.Rows.Count - 1).Cells("rep_Numero").Value = mItem.rep_Numero
                    dgvguias.Rows(dgvDetalle.Rows.Count - 1).Cells("rep_Importe").Value = mItem.rep_Importe
                    dgvguias.Rows(dgvDetalle.Rows.Count - 1).Cells("rep_ContraValor").Value = mItem.rep_ContraValor
                    dgvguias.Rows(dgvDetalle.Rows.Count - 1).Cells("rep_EsLogistica").Value = mItem.rep_EsLogistica

                Else

                    dgvNotaCredito.Rows.Add()

                    dgvNotaCredito.Rows(dgvNotaCredito.Rows.Count - 1).Cells(0).Value = mItem.cct_Id
                    dgvNotaCredito.Rows(dgvNotaCredito.Rows.Count - 1).Cells(1).Value = mItem.tdo_Id
                    dgvNotaCredito.Rows(dgvNotaCredito.Rows.Count - 1).Cells(2).Value = mItem.dtd_Id
                    dgvNotaCredito.Rows(dgvNotaCredito.Rows.Count - 1).Cells(3).Value = mItem.rep_Item
                    dgvNotaCredito.Rows(dgvNotaCredito.Rows.Count - 1).Cells(3).Tag = mItem
                    dgvNotaCredito.Rows(dgvNotaCredito.Rows.Count - 1).Cells(4).Value = mItem.TipoDocumentos.TDO_DESCRIPCION
                    dgvNotaCredito.Rows(dgvNotaCredito.Rows.Count - 1).Cells(5).Value = mItem.rep_Serie
                    dgvNotaCredito.Rows(dgvNotaCredito.Rows.Count - 1).Cells(6).Value = mItem.rep_Numero
                    dgvNotaCredito.Rows(dgvNotaCredito.Rows.Count - 1).Cells(7).Value = mItem.rep_Importe
                    dgvNotaCredito.Rows(dgvNotaCredito.Rows.Count - 1).Cells(8).Value = mItem.rep_ContraValor
                    dgvNotaCredito.Rows(dgvNotaCredito.Rows.Count - 1).Cells(9).Value = mItem.rep_EsLogistica
                    dgvNotaCredito.Rows(dgvNotaCredito.Rows.Count - 1).Cells(10).Value = mItem.rep_ItemDoc

                End If



            Next


            sumar()
        End Sub

        Public Overrides Sub OnManAgregarFilaGrid()
            Dim dImporte As Double = 0.0

            If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then
                If (TabControl1.SelectedIndex = 1) Then
                    If (dgvDetalle.Rows.Count <= 0) Then
                        AddPrimaraCuenta()
                        Exit Sub
                    Else
                        Exit Sub
                    End If

                End If

            End If
            'cuenta contable

            If (TabControl1.SelectedIndex = 1) Then
                If (dgvDetalle.Rows.Count <= 0) Then
                    AddPrimaraCuenta()
                Else
                    dgvDetalle.Rows.Add()
                End If

            End If

            'guia de remicion
            If (TabControl1.SelectedIndex = 2) Then

                If (validar()) Then
                    Dim frm = Me.ContainerService.Resolve(Of frmBuscarDocumentosCompra)()
                    frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.ReferenciaProvisionCompras)

                    Dim X As Integer = 0
                    Dim iRow As Integer = 0

                    frm.txtPersona.Text = txtPersona.Text

                    If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                        While frm.dgvDetalle.SelectedRows.Count > X

                            dgvguias.Rows.Add()
                            iRow = dgvguias.RowCount - 1
                            With frm.dgvDetalle.SelectedRows(X)

                                Try
                                    dgvguias.Rows(iRow).Cells(0).Value = .Cells(2).Value
                                Catch ex As Exception
                                    dgvguias.Rows(iRow).Cells(0).Value = ""
                                End Try

                                dgvguias.Rows(iRow).Cells(1).Value = .Cells(1).Value
                                dgvguias.Rows(iRow).Cells(2).Value = .Cells(2).Value

                                dgvguias.Rows(iRow).Cells(3).Value = "" 'Nothing ''.Cells(11).Value
                                dgvguias.Rows(iRow).Cells(4).Value = .Cells(4).Value
                                dgvguias.Rows(iRow).Cells(5).Value = .Cells(5).Value
                                dgvguias.Rows(iRow).Cells(6).Value = .Cells(15).Value
                                dgvguias.Rows(iRow).Cells(7).Value = 0.0 ''.Cells(11).Value
                                dgvguias.Rows(iRow).Cells(8).Value = True

                            End With
                            X += 1
                        End While

                    End If
                    frm.Dispose()
                    sumarGuias()
                End If
            End If

            'nota de credito
            If (TabControl1.SelectedIndex = 3) Then
                ' preguntamos si es nota de credito o
                If Not (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "079") Then
                    ' nota de credito
                    If (validar()) Then
                        Dim frm = Me.ContainerService.Resolve(Of frmBuscarDocumentosPendientes)()
                        frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.SaldosKardexDocumentosXML)

                        Dim X As Integer = 0
                        Dim iRow As Integer = 0
                        frm.txtPersona.Text = txtPersona.Text
                        frm.txtPersona.Tag = txtPersona.Tag

                        If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                            While frm.dgvDetalle.SelectedRows.Count > X

                                dgvNotaCredito.Rows.Add()
                                iRow = dgvNotaCredito.RowCount - 1

                                With frm.dgvDetalle.SelectedRows(X)
                                    Try
                                        dgvNotaCredito.Rows(iRow).Cells(0).Value = .Cells(2).Value
                                    Catch ex As Exception
                                        dgvNotaCredito.Rows(iRow).Cells(0).Value = ""
                                    End Try

                                    dgvNotaCredito.Rows(iRow).Cells(1).Value = .Cells(6).Value
                                    dgvNotaCredito.Rows(iRow).Cells(2).Value = .Cells(8).Value

                                    dgvNotaCredito.Rows(iRow).Cells(3).Value = Nothing ''.Cells(11).Value
                                    dgvNotaCredito.Rows(iRow).Cells(4).Value = .Cells(9).Value ' descripcion decumento
                                    dgvNotaCredito.Rows(iRow).Cells(5).Value = .Cells(10).Value
                                    dgvNotaCredito.Rows(iRow).Cells(6).Value = .Cells(11).Value
                                    dgvNotaCredito.Rows(iRow).Cells(7).Value = .Cells(12).Value
                                    dgvNotaCredito.Rows(iRow).Cells(8).Value = 0.0 ''.Cells(11).Value
                                    dgvNotaCredito.Rows(iRow).Cells(9).Value = False
                                    dgvNotaCredito.Rows(iRow).Cells("ItemDoc").Value = "0000"

                                End With
                                X += 1
                            End While

                        End If
                        sumarAfectaciones()
                        frm.Dispose()
                    End If
                Else
                    'factura leasing

                    Dim frm = Me.ContainerService.Resolve(Of frmBuscarDocumentosPendientes)()
                    frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.LeasingLista)

                    Dim X As Integer = 0
                    Dim iRow As Integer = 0
                    frm.txtPersona.Text = txtPersona.Text
                    frm.txtPersona.Tag = txtPersona.Tag

                    If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                        While frm.dgvDetalle.SelectedRows.Count > X

                            dgvNotaCredito.Rows.Add()
                            iRow = dgvNotaCredito.RowCount - 1

                            With frm.dgvDetalle.SelectedRows(X)

                                dgvNotaCredito.Rows(iRow).Cells(0).Value = .Cells(0).Value

                                dgvNotaCredito.Rows(iRow).Cells(1).Value = .Cells(1).Value
                                dgvNotaCredito.Rows(iRow).Cells(2).Value = .Cells(2).Value

                                dgvNotaCredito.Rows(iRow).Cells(3).Value = Nothing
                                dgvNotaCredito.Rows(iRow).Cells(4).Value = .Cells(3).Value ' descripcion decumento
                                dgvNotaCredito.Rows(iRow).Cells(5).Value = .Cells(4).Value
                                dgvNotaCredito.Rows(iRow).Cells(6).Value = .Cells(5).Value
                                dgvNotaCredito.Rows(iRow).Cells(7).Value = .Cells(13).Value
                                dgvNotaCredito.Rows(iRow).Cells(8).Value = .Cells(14).Value
                                dgvNotaCredito.Rows(iRow).Cells(9).Value = False
                                dgvNotaCredito.Rows(iRow).Cells(10).Value = .Cells(6).Value

                            End With
                            X += 1
                        End While

                    End If
                    frm.Dispose()
                    sumarAfectaciones()
                End If


            End If


        End Sub
        Public Overrides Sub OnManQuitarFilaGrid()

            'cuentas contables
            If (TabControl1.SelectedIndex = 1) Then

                If (dgvDetalle.SelectedRows.Count > 0) Then


                    For Each mDetalle As DataGridViewRow In dgvDetalle.SelectedRows
                        If (IsDBNull(mDetalle.Cells("ALM_ID").Value) OrElse mDetalle.Cells("ALM_ID").Value = "") Then

                            If Not mDetalle.Cells("prd_Item").Value Is Nothing Then
                                With CType(mDetalle.Cells("prd_Item").Tag, BE.DetalleProvisionCompras)
                                    .MarkAsDeleted()
                                End With

                            End If
                            dgvDetalle.Rows.Remove(mDetalle)
                        Else
                            MsgBox("Cuando una Cuenta Tiene Almacen no se puede Eliminar , solo Modificar " & Chr(13) & "Jalar nuevamente los datos de Logistica 'Compras' ")
                        End If
                    Next
                    sumar()

                Else
                    MsgBox("Seleccione un registro")
                End If

            End If
            ' referencia(logistica)
            '----- rep_Item
            If (TabControl1.SelectedIndex = 2) Then
                If (dgvguias.SelectedRows.Count > 0) Then

                    For Each mDetalle As DataGridViewRow In dgvguias.SelectedRows
                        If Not mDetalle.Cells("rep_Item").Value Is Nothing Then
                            With CType(mDetalle.Cells("rep_Item").Tag, BE.ReferenciaProvisionCompras)
                                .MarkAsDeleted()
                            End With

                        End If
                        dgvguias.Rows.Remove(mDetalle)
                    Next

                Else
                    MsgBox("Seleccione un registro")
                End If
                sumarGuias()
            End If

            'referencia(Nota de credito)
            '----- rep_Item

            If (TabControl1.SelectedIndex = 3) Then
                If (dgvNotaCredito.SelectedRows.Count > 0) Then

                    For Each mDetalle As DataGridViewRow In dgvNotaCredito.SelectedRows
                        If Not mDetalle.Cells("DataGridViewTextBoxColumn4").Value Is Nothing Then
                            With CType(mDetalle.Cells("DataGridViewTextBoxColumn4").Tag, BE.ReferenciaProvisionCompras)
                                .MarkAsDeleted()
                            End With

                        End If
                        dgvNotaCredito.Rows.Remove(mDetalle)

                    Next

                Else
                    MsgBox("Seleccione un registro")
                End If
                sumarAfectaciones()
            End If

        End Sub

        Public Overrides Sub OnManBuscar()
            If lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionComprasServicios Then
                Exit Sub
            End If
            If lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionPlanillasMovilidad Then
                Exit Sub
            End If
            If lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionRendicionEntregas Then
                Exit Sub
            End If

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarCompra)()

            If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then
                frm.inicio(Constants.BuscadoresNames.ProvisionDividendos)
            Else
                frm.inicio(Constants.BuscadoresNames.ProvisionCompras)
            End If

            Try
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value, frm.dgbRegistro.CurrentRow.Cells(2).Value, frm.dgbRegistro.CurrentRow.Cells(1).Value)
                    menuBuscar()
                End If
            Catch ex As Exception
                MsgBox("Seleccione un registro ", vbInformation)
            End Try
            frm.Dispose()
            Panel1.Enabled = False
            HabilitarReportes = True
        End Sub
        Private Function derecha(ByVal sdato As String, ByVal numeros As Int16)
            Return sdato.Substring(sdato.Length - numeros, numeros)
        End Function
        Public Overrides Sub OnReportes()
            imprimir()
        End Sub

        Public Sub imprimir()
            Dim oTable As New DataTable
            Try
                oTable = Me.BCProvisionCompras.spProvisionComprasImprime(txtVoucher.Text, txtLibro.Tag, txtPeriodo.Text)
                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()
                'si es percepcion del cliente de lo contrario otro formato 
                oReporte.Database.Tables(0).SetDataSource(oTable)
                frm.Reporte(oReporte)
                frm.ShowDialog()
            Catch ex As Exception
                MsgBox("No se puede mostrar la informacion :" & ex.Message)
            End Try
        End Sub
        Public Overrides Sub OnManGuardar()

            If (txtTipoDocumento.Text = "041" And txtCombrobante.Tag = "060") Or _
               (txtTipoDocumento.Text = "041" And txtCombrobante.Tag = "218") Or _
               (txtTipoDocumento.Text = "044" And txtCombrobante.Tag = "088") Or _
               (txtTipoDocumento.Text = "044" And txtCombrobante.Tag = "219") Then
                If Trim(txtCPOriginal.Tag) = "" Or Trim(txtCPSerie.Text) = "" Or Trim(txtCPNumero.Text) = "" Then
                    MsgBox("¡Debe de ingresar el documento de referencia!", MsgBoxStyle.Exclamation, Me.Text)
                    ErrorProvider1.SetError(Label13, "¡Debe de ingresar el documento de referencia!")
                    Exit Sub
                End If
            End If
            ErrorProvider1.SetError(Label13, Nothing)
            If (oProvisionCompras.prc_Numero = "") Then
                oProvisionCompras.ChangeTracker.ChangeTrackingEnabled = False
                oProvisionCompras.DetalleProvisionCompras = Nothing
                oProvisionCompras.ReferenciaProvisionCompras = Nothing
                oProvisionCompras.RolOpeCtaCte = Nothing
                oProvisionCompras.ChangeTracker.ChangeTrackingEnabled = True
                oProvisionCompras = Nothing
                oProvisionCompras = New BE.ProvisionCompras
                oProvisionCompras.MarkAsAdded()
            End If
            If (validar() AndAlso validarCeldas()) Then
                Try
                    Dim oTablita As New DataTable
                    oTablita = BCCuentasComprobantesLogistica.spCuentasComprobantesLogisticaValidar(BCUtil.getXml(dgvDetalle, 2, 9))
                    If (CInt(oTablita.Rows(0).Item(0)) = 0) Then
                        MsgBox("La cuenta ingresada , esta asignada a un almacen, verificar en 'Cuenta-Logistica-Validar '")
                        Exit Sub
                    End If
                    If oProvisionCompras IsNot Nothing Then
                        dgvDetalle.EndEdit()
                        oProvisionCompras.TiposBienesServicios = Nothing
                        oProvisionCompras.TipoVenta = Nothing
                        oProvisionCompras.CentroCostos = Nothing
                        ' oProvisionCompras.DocuMovimiento = Nothing
                        oProvisionCompras.LibrosContables = Nothing
                        oProvisionCompras.OperacionDetraciones = Nothing
                        oProvisionCompras.Periodo = Nothing
                        oProvisionCompras.DetalleTipoDocumentos = Nothing
                        oProvisionCompras.DocuMovimiento = Nothing
                        oProvisionCompras.TiposReparables = Nothing
                        oProvisionCompras.prc_AplicarImporteInventarioDocRef = False
                        oProvisionCompras.prd_Periodo_id = txtPeriodo.Text
                        oProvisionCompras.prc_Voucher = txtVoucher.Text
                        oProvisionCompras.lib_Id = txtLibro.Tag
                        oProvisionCompras.OTR_ID = lblOrdenTrabajo.Text

                        Try
                            oProvisionCompras.OSE_ID = lblOrdenServicio.Text
                        Catch ex As Exception
                            oProvisionCompras.OSE_ID = Nothing
                        End Try
                        Try
                            oProvisionCompras.CRD_ID = lblCuentaRendirDetalle.Text
                        Catch ex As Exception
                            oProvisionCompras.CRD_ID = Nothing
                        End Try
                        Try
                            oProvisionCompras.RGA_ID = lblRendicionGastos.Text
                        Catch ex As Exception
                            oProvisionCompras.RGA_ID = Nothing
                        End Try

                        If (txtReparable.Tag = "") Then
                            oProvisionCompras.rep_id = Nothing
                        Else
                            oProvisionCompras.rep_id = txtReparable.Tag
                        End If
                        If (txtCompras.Text = "") Then
                            oProvisionCompras.dmo_Id = Nothing
                        Else
                            oProvisionCompras.dmo_Id = CInt(txtCompras.Text)
                        End If

                        oProvisionCompras.prc_SerieSunat = txtSerieSunat.Text.Trim
                        oProvisionCompras.prc_AnioDUA = txtAnioDua.Text

                        oProvisionCompras.prc_Serie = derecha(("000000000" & txtSerie.Text.Trim), 3)
                        oProvisionCompras.prc_Numero = derecha(("0000000000000" & txtNumero.Text.Trim), 10)
                        oProvisionCompras.cct_Id = txtCuentaCorriente.Text
                        oProvisionCompras.prc_FechaVoucher = CDate(dateFechaVoucher.Text)
                        oProvisionCompras.prc_ImporteDocRef = CDec(Val(txtDistribucionAfectacion.Text))
                        If (IsDate(txtFechaVencimiento.Text)) Then
                            oProvisionCompras.prc_FechaVencimiento = CDate(txtFechaVencimiento.Text)
                        Else
                            oProvisionCompras.prc_FechaVencimiento = Nothing
                        End If
                        If (IsDate(txtFecha.Text)) Then
                            oProvisionCompras.prc_FechaDocumento = CDate(txtFecha.Text)
                        Else
                            oProvisionCompras.prc_FechaDocumento = Nothing
                        End If
                        oProvisionCompras.prc_Glosa = txtglosa.Text
                        oProvisionCompras.mon_Id = txtMoneda.Tag
                        oProvisionCompras.prc_ImporteCIF = CDec(txtValorCIF.Text)
                        oProvisionCompras.prc_BaseImponible = CDec(txtBaseImponible.Text)
                        oProvisionCompras.prc_Total = CDec(txtTotal.Text)
                        oProvisionCompras.prc_Igv = CDec(txtIGV.Text)
                        oProvisionCompras.prc_NoGravado = CDec(txtNoGrvado.Text)
                        oProvisionCompras.prc_DescuentosObtenidos = CDec(txtDescuento.Text)
                        oProvisionCompras.prc_ImportePercepcion = CDec(txtPercepcion.Text)
                        oProvisionCompras.opd_Oper_Detra_Id = IIf(txtOperacionDetraccion.Tag = "", Nothing, txtOperacionDetraccion.Tag)
                        oProvisionCompras.tib_TipoBien_Id = IIf(txtTipoDetraccion.Tag = "", Nothing, txtTipoDetraccion.Tag)
                        oProvisionCompras.tdo_Id = IIf(txtTipoDocumento.Text = "", Nothing, txtTipoDocumento.Text)
                        oProvisionCompras.dtd_Id = IIf(txtCombrobante.Tag = "", Nothing, txtCombrobante.Tag)
                        If (IsDate(txtFechaSPOT.Text)) Then
                            oProvisionCompras.prc_FechaSpot = CDate(txtFechaSPOT.Text)
                        Else
                            oProvisionCompras.prc_FechaSpot = Nothing
                        End If
                        If (txtcentroCosto.Tag = "") Then
                            oProvisionCompras.CCO_ID = Nothing
                        Else
                            oProvisionCompras.CCO_ID = txtcentroCosto.Tag
                        End If
                        oProvisionCompras.prc_NumeroSpot = IIf(txtNumeroSPOT.Text = "", Nothing, txtNumeroSPOT.Text)
                        oProvisionCompras.prc_EsDetraccion = chkAfectoSPOT.Checked
                        oProvisionCompras.pve_Id = IIf(txtPuntoVenta.Tag = "", Nothing, txtPuntoVenta.Tag)
                        oProvisionCompras.TIV_ID = IIf(txtTipoVenta.Tag = "", Nothing, txtTipoVenta.Tag)
                        oProvisionCompras.prc_NumeroDocAduana = IIf(txtDua.Text = "", Nothing, txtDua.Text)
                        oProvisionCompras.prc_Advalorem = CDec(txtAdvalore.Text)
                        oProvisionCompras.per_Id = txtPersona.Tag
                        oProvisionCompras.prc_RetenerRenta4ta = CBool(chkRetencion4ta.Checked)
                        oProvisionCompras.prc_RetenerRenta3ra = CBool(chkRetenerTercera.Checked)
                        oProvisionCompras.prc_ImporteISC = CDec(txtImporteISC.Text)
                        oProvisionCompras.prc_OtrosTributos = CDec(txtOtrosTributos.Text)
                        oProvisionCompras.Usu_Id = SessionService.UserId
                        oProvisionCompras.prc_FecGrab = CDate(Today)
                        oProvisionCompras.dtd_IdRef = IIf(txtCPOriginal.Tag = "", Nothing, txtCPOriginal.Tag) 'dtd
                        oProvisionCompras.prc_SerieRef = txtCPSerie.Text
                        oProvisionCompras.prc_NumeroRef = txtCPNumero.Text
                        oProvisionCompras.cct_IdRef = IIf(txtCPSerie.Tag = "", Nothing, txtCPSerie.Tag) ' cct_corriente 
                        oProvisionCompras.tdo_IdRef = IIf(txtCPNumero.Tag = "", Nothing, txtCPNumero.Tag) 'tdt
                        oProvisionCompras.per_idResponsable = IIf(txtResponsable.Tag = "", Nothing, txtResponsable.Tag)
                        BloquearSegunTipoDoc()
                        'Detalle de compras(cuentas contables)
                        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                            If Not mDetalle.Cells("prd_Item").Value Is Nothing Then
                                With CType(mDetalle.Cells("prd_Item").Tag, BE.DetalleProvisionCompras)
                                    .ChangeTracker.ChangeTrackingEnabled = False
                                    .CuentasContables = Nothing
                                    .CentroCostos = Nothing
                                    .ClaseCuenta = Nothing
                                    .CentroCostos = Nothing
                                    .Almacen = Nothing
                                    .ChangeTracker.ChangeTrackingEnabled = True
                                    .prc_Voucher = txtVoucher.Text
                                    .lib_Id = txtLibro.Tag
                                    .prd_Item = mDetalle.Cells("prd_Item").Value
                                    .prd_Importe = CDec(mDetalle.Cells("prd_Importe").Value)
                                    .cuc_Id = mDetalle.Cells("cuc_Id").Tag
                                    If (IsDBNull(mDetalle.Cells("ALM_ID").Value) OrElse mDetalle.Cells("ALM_ID").Value = "") Then
                                        .ALM_ID = Nothing
                                    Else
                                        .ALM_ID = CInt(mDetalle.Cells("ALM_ID").Value)
                                    End If
                                    If (mDetalle.Cells("cco_Id").Tag = "") Then
                                        If (txtcentroCosto.Tag = "") Then
                                            .cco_Id = Nothing
                                        Else
                                            .cco_Id = txtcentroCosto.Tag
                                        End If
                                    Else
                                        .cco_Id = mDetalle.Cells("cco_Id").Tag
                                    End If
                                    .prd_Glosa = mDetalle.Cells("Glosa").Value
                                    .prd_Periodo_id = txtPeriodo.Text
                                    .cls_Id = mDetalle.Cells("cls_Id").Tag
                                    .Usu_Id = SessionService.UserId
                                    .prd_FECGRAB = Now
                                    .MarkAsModified()
                                End With
                            Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                                Dim nOSD As New BE.DetalleProvisionCompras
                                With nOSD
                                    .ChangeTracker.ChangeTrackingEnabled = False
                                    .CuentasContables = Nothing
                                    .CentroCostos = Nothing
                                    .ClaseCuenta = Nothing
                                    .CentroCostos = Nothing
                                    .Almacen = Nothing
                                    .ChangeTracker.ChangeTrackingEnabled = True
                                    .prc_Voucher = txtVoucher.Text
                                    .lib_Id = txtLibro.Tag
                                    .prd_Item = mDetalle.Cells("prd_Item").Value
                                    .prd_Importe = CDec(mDetalle.Cells("prd_Importe").Value)
                                    .cuc_Id = mDetalle.Cells("cuc_Id").Tag
                                    If (IsDBNull(mDetalle.Cells("ALM_ID").Value) OrElse mDetalle.Cells("ALM_ID").Value = "") Then
                                        .ALM_ID = Nothing
                                    Else
                                        .ALM_ID = CInt(mDetalle.Cells("ALM_ID").Value)
                                    End If
                                    If (mDetalle.Cells("cco_Id").Tag = "") Then
                                        If (txtcentroCosto.Tag = "") Then
                                            .cco_Id = Nothing
                                        Else
                                            .cco_Id = txtcentroCosto.Tag
                                        End If
                                    Else
                                        .cco_Id = mDetalle.Cells("cco_Id").Tag
                                    End If
                                    .prd_Glosa = mDetalle.Cells("Glosa").Value
                                    .prd_Periodo_id = txtPeriodo.Text
                                    .cls_Id = mDetalle.Cells("cls_Id").Tag
                                    .Usu_Id = SessionService.UserId
                                    .prd_FECGRAB = Now
                                    .MarkAsAdded()
                                End With
                                oProvisionCompras.DetalleProvisionCompras.Add(nOSD)
                            End If
                        Next
                        'Referencia de compras(logistica)
                        For Each mDetalle As DataGridViewRow In dgvguias.Rows
                            If Not mDetalle.Cells("rep_Item").Value Is Nothing Then
                                With CType(mDetalle.Cells("rep_Item").Tag, BE.ReferenciaProvisionCompras)
                                    .ChangeTracker.ChangeTrackingEnabled = False
                                    .Personas = Nothing
                                    .TipoDocumentos = Nothing
                                    .ChangeTracker.ChangeTrackingEnabled = True
                                    .prc_Voucher = txtVoucher.Text
                                    .lib_Id = txtLibro.Tag
                                    .rep_Item = mDetalle.Cells("rep_Item").Value
                                    .cct_Id = IIf(IsDBNull(mDetalle.Cells("cct_Id").Value), Nothing, IsDBNull(mDetalle.Cells("cct_Id").Value))
                                    .tdo_Id = mDetalle.Cells("tdo_Id").Value
                                    .rep_Serie = mDetalle.Cells("rep_Serie").Value
                                    .rep_Numero = mDetalle.Cells("rep_Numero").Value
                                    .rep_Importe = CDec(mDetalle.Cells("rep_Importe").Value)
                                    .rep_ContraValor = CDec(mDetalle.Cells("rep_ContraValor").Value)
                                    .rep_EsLogistica = True 'mDetalle.Cells("rep_EsLogistica").Value
                                    .Personas = Nothing
                                    .per_Id = txtPersona.Tag
                                    .MarkAsModified()
                                End With
                            Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                                Dim nOSD As New BE.ReferenciaProvisionCompras
                                With nOSD
                                    .ChangeTracker.ChangeTrackingEnabled = False
                                    .Personas = Nothing
                                    .TipoDocumentos = Nothing
                                    .ChangeTracker.ChangeTrackingEnabled = True
                                    .prc_Voucher = txtVoucher.Text
                                    .lib_Id = txtLibro.Tag
                                    .rep_Item = mDetalle.Cells("rep_Item").Value
                                    .cct_Id = IIf(IsDBNull(mDetalle.Cells("cct_Id").Value), Nothing, IsDBNull(mDetalle.Cells("cct_Id").Value))
                                    .tdo_Id = mDetalle.Cells("tdo_Id").Value
                                    .rep_Serie = mDetalle.Cells("rep_Serie").Value
                                    .rep_Numero = mDetalle.Cells("rep_Numero").Value
                                    .rep_Importe = CDec(mDetalle.Cells("rep_Importe").Value)
                                    .rep_ContraValor = CDec(mDetalle.Cells("rep_ContraValor").Value)
                                    .rep_EsLogistica = True 'mDetalle.Cells("rep_EsLogistica").Value
                                    .MarkAsAdded()
                                End With
                                oProvisionCompras.ReferenciaProvisionCompras.Add(nOSD)
                            End If
                        Next
                        'Referencia de compras(Nota Credito)
                        For Each mDetalleNota As DataGridViewRow In dgvNotaCredito.Rows
                            If Not mDetalleNota.Cells(3).Value Is Nothing Then 'rep_Item
                                With CType(mDetalleNota.Cells(3).Tag, BE.ReferenciaProvisionCompras) 'rep_Item
                                    .ChangeTracker.ChangeTrackingEnabled = False
                                    .Personas = Nothing
                                    ' .ProvisionCompras = Nothing
                                    .TipoDocumentos = Nothing
                                    .ChangeTracker.ChangeTrackingEnabled = True
                                    .prc_Voucher = txtVoucher.Text
                                    .lib_Id = txtLibro.Tag
                                    .rep_Item = mDetalleNota.Cells(3).Value
                                    .cct_Id = IIf(IsDBNull(mDetalleNota.Cells(0).Value), Nothing, mDetalleNota.Cells(0).Value)
                                    .tdo_Id = mDetalleNota.Cells(1).Value
                                    .dtd_Id = mDetalleNota.Cells(2).Value
                                    .rep_Serie = mDetalleNota.Cells(5).Value
                                    .rep_Numero = mDetalleNota.Cells(6).Value
                                    .rep_Importe = CDec(mDetalleNota.Cells(7).Value)
                                    .rep_ContraValor = CDec(IIf(mDetalleNota.Cells(8).Value.ToString = "", "0.00", mDetalleNota.Cells(8).Value))
                                    .rep_EsLogistica = False 'mDetalleNota.Cells(8).Value
                                    .rep_ItemDoc = IIf(IsDBNull(mDetalleNota.Cells("ItemDoc").Value) Or mDetalleNota.Cells("ItemDoc").Value = "", "0000", mDetalleNota.Cells("ItemDoc").Value)
                                    .Personas = Nothing
                                    .per_Id = txtPersona.Tag
                                    .MarkAsModified()
                                End With
                            Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                                Dim nOSD As New BE.ReferenciaProvisionCompras
                                With nOSD
                                    .ChangeTracker.ChangeTrackingEnabled = False
                                    .Personas = Nothing
                                    '.ProvisionCompras = Nothing
                                    .TipoDocumentos = Nothing
                                    .ChangeTracker.ChangeTrackingEnabled = True
                                    .prc_Voucher = txtVoucher.Text
                                    .lib_Id = txtLibro.Tag
                                    .rep_Item = mDetalleNota.Cells(3).Value
                                    .cct_Id = IIf(IsDBNull(mDetalleNota.Cells(0).Value), Nothing, mDetalleNota.Cells(0).Value)
                                    .tdo_Id = mDetalleNota.Cells(1).Value
                                    .dtd_Id = mDetalleNota.Cells(2).Value
                                    .rep_Serie = mDetalleNota.Cells(5).Value
                                    .rep_Numero = mDetalleNota.Cells(6).Value
                                    .rep_Importe = CDec(mDetalleNota.Cells(7).Value)
                                    .rep_ContraValor = CDec(IIf(mDetalleNota.Cells(8).Value.ToString = "", "0.00", mDetalleNota.Cells(8).Value))
                                    .rep_EsLogistica = False 'mDetalleNota.Cells(8).Value
                                    .rep_ItemDoc = mDetalleNota.Cells(10).Value
                                    .Personas = Nothing
                                    .per_Id = txtPersona.Tag
                                    .MarkAsAdded()
                                End With
                                oProvisionCompras.ReferenciaProvisionCompras.Add(nOSD)
                            End If
                        Next
                        BCProvisionCompras.Maintenance(oProvisionCompras)
                        MsgBox("Datos Guardados : " & txtPeriodo.Text & " - " & oProvisionCompras.prc_Voucher)
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()
                        DeshabilitarElementoGrid()
                        OnManNuevo()
                        btnPersona.Focus()
                    End If
                Catch ex As Exception
                    Try
                        MsgBox(ex.Message & Chr(13) & ex.InnerException.Message.ToString, MsgBoxStyle.Critical)
                        'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                        'If (rethrow) Then
                        '    Throw
                        'End If
                    Catch exE As Exception
                        MsgBox(ex.Message & Chr(13) & ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                End Try
            End If
        End Sub

        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oProvisionCompras = New BE.ProvisionCompras
            oProvisionCompras.MarkAsAdded()
            HabilitarElementoGrid()
            Panel1.Enabled = True
            btnPeriodo.Focus()

            dateFechaVoucher.Text = CDate(Today)
        End Sub
        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub

        Public Overrides Sub OnManEliminar()


            Try
                If (MsgBox("Esta seguro de eliminar", vbYesNo) = vbYes) Then
                    If oProvisionCompras IsNot Nothing Then
                        oProvisionCompras.MarkAsDeleted()

                        'Detalle de    
                        oProvisionCompras.prd_Periodo_id = txtPeriodo.Text
                        oProvisionCompras.lib_Id = txtLibro.Tag
                        oProvisionCompras.prc_Voucher = txtVoucher.Text

                        BCProvisionCompras.MaintenanceDelete(oProvisionCompras)
                        MsgBox("Datos Guardados")
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()
                        DeshabilitarElementoGrid()
                        OnManNuevo()
                        btnPersona.Focus()
                    End If

                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                'If (rethrow) Then
                '    Throw
                'End If
            End Try

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

        Function validarCeldas() As Boolean

            Dim result As Boolean = True
            Dim iRow As Integer = 0
            ' si es una dua no ingresa cuentas contables 

            If Not (txtTipoDocumento.Tag = "013" And txtCombrobante.Tag = "076") Then

                While (dgvDetalle.Rows.Count > iRow)
                    If (IsNothing(dgvDetalle.Rows(iRow).Cells("cuc_Id").Tag) OrElse dgvDetalle.Rows(iRow).Cells("cuc_Id").Tag = "") Then
                        result = False
                        ErrorProvider1.SetError(dgvDetalle, "Cuenta contable")
                        Return result
                    Else
                        ErrorProvider1.SetError(dgvDetalle, Nothing)
                    End If


                    If (Not IsNumeric(dgvDetalle.Rows(iRow).Cells("prd_Importe").Value)) Then
                        result = False
                        ErrorProvider1.SetError(dgvDetalle, "Importe")

                        Return result
                    Else

                        ErrorProvider1.SetError(dgvDetalle, Nothing)
                    End If



                    iRow += 1
                End While

                If (result) Then
                    sumar()
                End If
            End If

            Return result
        End Function
        Sub buscarPersona()
            Try

                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.BuscarPersona)
                frm.campo1 = "SI"

                If (frm.ShowDialog = DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow

                        txtPersona.Tag = .Cells(0).Value
                        txtPersona.Text = .Cells(1).Value
                        Try
                            If Not (.Cells(3).Value Is Nothing) Then
                                txtRuc.Text = .Cells(3).Value
                            Else
                                txtRuc.Text = ""
                            End If
                        Catch ex As Exception
                            txtRuc.Text = ""
                        End Try


                    End With
                    txtRuc.Focus()
                End If
            Catch ex As Exception

            End Try

        End Sub

        Private Sub btnLibro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLibro.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()

                If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then
                    frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.LibrosContablesDividendos)
                Else
                    frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.LibrosContables)
                End If




                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                    With frm.dgbRegistro.CurrentRow
                        txtLibro.Tag = .Cells(0).Value
                        txtLibro.Text = .Cells(1).Value
                    End With
                End If
                frm.Dispose()
                dateFechaVoucher.Focus()

            Catch ex As Exception

            End Try


        End Sub

        Private Sub btnOperacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOperacion.Click


            Try
                If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then Exit Sub
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.OperacionDetraciones)
                frm.cargarDatos()
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    txtOperacionDetraccion.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                    txtOperacionDetraccion.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value

                End If
                frm.Dispose()
                btnTipoDetraccion.Focus()
            Catch ex As Exception

            End Try

        End Sub

        Private Sub btnTipoDetraccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoDetraccion.Click
            Try
                If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then Exit Sub
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.TiposBienesServicios)
                frm.cargarDatos()
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    txtTipoDetraccion.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                    txtTipoDetraccion.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value

                End If
                frm.Dispose()
                btnAgencia.Focus()

            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPersona.Click
            Try
                buscarPersona()
                txtRuc.Focus()
            Catch ex As Exception

            End Try

        End Sub

        Private Sub btnPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodo.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
                frm.cargarDatos()
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPeriodo.Text = .Cells(0).Value

                    End With
                End If
                frm.Dispose()
                txtVoucher.Focus()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComprobante.Click
            Try

                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()

                If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then
                    frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.TiposComprobantesDividendosSelectXML)
                Else
                    frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.TiposComprobantesSelectXML)
                End If



                frm.cargarDatos()
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.SelectedRows(0)

                        txtCuentaCorriente.Text = .Cells(0).Value
                        txtTipoDocumento.Text = .Cells(1).Value
                        txtTipoDocumento.Tag = .Cells(1).Value
                        txtCombrobante.Tag = .Cells(2).Value
                        txtCombrobante.Text = .Cells(3).Value

                    End With
                    txtSerie.Focus()

                End If
                frm.Dispose()
                BloquearSegunTipoDoc()
                txtSerie.Focus()

                sumarAfectaciones()
            Catch ex As Exception

            End Try

        End Sub
        Private Sub BloquearSegunTipoDoc()

            btnCPOriginal.Enabled = False
            chkRetencion4ta.Enabled = False
            ' nota 42
            If (txtTipoDocumento.Text = "041" And txtCombrobante.Tag = "060") Then
                btnCPOriginal.Enabled = True
            End If
            'nota 43
            If (txtTipoDocumento.Text = "041" And txtCombrobante.Tag = "218") Then
                btnCPOriginal.Enabled = True
            End If

            'debito 42
            If (txtTipoDocumento.Text = "044" And txtCombrobante.Tag = "088") Then
                btnCPOriginal.Enabled = True

            End If

            'debito 43
            If (txtTipoDocumento.Text = "044" And txtCombrobante.Tag = "219") Then
                btnCPOriginal.Enabled = True

            End If

            ' recibo de honorarios
            If (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "083") Then
                chkRetencion4ta.Enabled = True
            End If

            ' varios recibo de honorarios
            If (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "234") Then
                chkRetencion4ta.Enabled = True

            End If



        End Sub

        Private Sub btnMoneda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoneda.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.Moneda)
                frm.cargarDatos()
                If (frm.ShowDialog = DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow

                        txtMoneda.Tag = .Cells(0).Value
                        txtMoneda.Text = .Cells(1).Value

                    End With
                End If
                frm.Dispose()
                ' si es recibo de honorarios o boleta
                If (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "083") Or (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "234") Or (txtTipoDocumento.Text = "023" And txtCombrobante.Tag = "039") Then
                    txtNoGrvado.Focus()
                Else
                    txtBaseImponible.Focus()
                End If

            Catch ex As Exception
                ' si es recibo de honorarios o boleta
                If (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "083") Or (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "234") Or (txtTipoDocumento.Text = "023" And txtCombrobante.Tag = "039") Then
                    txtNoGrvado.Focus()
                Else
                    txtBaseImponible.Focus()
                End If
            End Try
        End Sub

        Private Sub dgvDetalle_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
            Try
                Select Case dgvDetalle.Columns(e.ColumnIndex).Name
                    Case "cta"

                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarDosParametros)()
                        frm.inicio(Constants.BuscadoresNames.CuentasContables)

                        If (frm.ShowDialog = DialogResult.OK) Then
                            dgvDetalle.Rows(e.RowIndex).Cells("cuc_id").Value = frm.dgbRegistro.CurrentRow.Cells(0).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("cuc_id").Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("cuenta").Value = frm.dgbRegistro.CurrentRow.Cells(1).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("cls_Id").Tag = frm.dgbRegistro.CurrentRow.Cells(5).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("cta").Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                        End If
                        frm.Dispose()

                    Case "cco_Id"
                        Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                        frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CentroCosto)
                        If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                            With frm.dgbRegistro.CurrentRow
                                dgvDetalle.Rows(e.RowIndex).Cells("cco_Id").Tag = .Cells(0).Value
                                dgvDetalle.Rows(e.RowIndex).Cells("CentroCosto").Value = .Cells(1).Value
                            End With
                        End If
                        frm.Dispose()
                End Select

            Catch ex As Exception

            End Try

        End Sub

        Private Sub frmProvisionCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            limpiar()
            menuInicio()
            Panel1.Enabled = False
            OnManNuevo()

            If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then
                txtBaseImponible.Enabled = False
                txtBaseImponible.ReadOnly = True

                Label22.Text = "Retención"
                chkAfectoSPOT.Visible = False
                chkAfectoSPOT.Enabled = False

                chkRetenerTercera.Visible = False
                chkRetenerTercera.Enabled = False

                chkRetencion4ta.Visible = False
                chkRetencion4ta.Enabled = False

                Label24.Visible = False
                txtPercepcion.Visible = False
                txtPercepcion.Enabled = False

                Label21.Visible = False
                txtNoGrvado.Visible = False
                txtNoGrvado.Enabled = False

                Label23.Visible = False
                txtDescuento.Visible = False
                txtDescuento.Enabled = False

                Label31.Visible = False
                txtOtrosTributos.Visible = False
                txtOtrosTributos.Enabled = False

                Label14.Visible = False
                txtImporteISC.Visible = False
                txtImporteISC.Enabled = False

                Label25.Visible = False
                txtValorCIF.Visible = False
                txtValorCIF.Enabled = False

                Label26.Visible = False
                txtAdvalore.Visible = False
                txtAdvalore.Enabled = False

                TabControl1.TabPages.Remove(TabPage3)
                TabControl1.TabPages.Remove(TabPage4)
            End If

        End Sub
        Private Sub btnCentroCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCentroCosto.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CentroCosto)
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtcentroCosto.Tag = .Cells(0).Value
                        txtcentroCosto.Text = .Cells(1).Value
                    End With
                End If
                frm.Dispose()
                btnCompras.Focus()
            Catch ex As Exception
                btnCompras.Focus()
            End Try
        End Sub

        Private Sub btnTipoVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoVenta.Click
            Try
                If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then Exit Sub
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CondicionCompra)
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtTipoVenta.Tag = .Cells(0).Value
                        txtTipoVenta.Text = .Cells(1).Value
                    End With
                End If
                frm.Dispose()
                txtglosa.Focus()
            Catch ex As Exception
                txtglosa.Focus()
            End Try

        End Sub

        Private Sub btnAgencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgencia.Click
            Try
                If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then Exit Sub
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.PuntoVenta)
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPuntoVenta.Tag = .Cells(0).Value
                        txtPuntoVenta.Text = .Cells(1).Value
                    End With
                End If
                frm.Dispose()
                btnCentroCosto.Focus()
            Catch ex As Exception
                btnCentroCosto.Focus()
            End Try

        End Sub
        Sub perderEnfoque()
            If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then

            Else
                Dim dIGVDOC As Double = 0

                dIGVDOC = (Math.Round(CDec(txtBaseImponible.Text) * (SessionService.IGV / 100), 2)).ToString

                If (CDbl(txtIGV.Text) <> dIGVDOC) Then
                    MsgBox("El I.G.V ingresado puede estar errado." & Chr(13) & _
                           "***  Revise ***" & Chr(13) & _
                           "Base Imponible: " & txtBaseImponible.Text & Chr(13) & _
                           "I.G.V Calculado por el sistema: " & dIGVDOC.ToString() & Chr(13) & _
                           "I.G.V Ingresado por el Usuario:" & txtIGV.Text)

                    dIGVDOC = Math.Round(CDec(txtBaseImponible.Text) * (SessionService.IGV / 100), 2)

                End If
            End If
            

        End Sub
        Sub TotalAdistribuir()
            Dim dBaseImponible As Double
            Dim dNoGrabado As Double
            Dim dOtrosTributos As Double



            dBaseImponible = Val(txtBaseImponible.Text)
            dNoGrabado = Val(txtNoGrvado.Text)
            dOtrosTributos = Val(txtOtrosTributos.Text)


            txtTotalADistribuir.Text = (dBaseImponible + dNoGrabado + dOtrosTributos)

        End Sub

        Private Sub txtBaseImponible_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBaseImponible.TextChanged
            Try
                If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then
                Else
                    txtIGV.Text = (Math.Round(CDec(txtBaseImponible.Text) * (SessionService.IGV / 100), 2)).ToString
                End If
            Catch ex As Exception
                txtIGV.Text = "0.00"
            End Try
            totalBase()
            TotalAdistribuir()
            totalBase()
        End Sub

        Private Sub txtIGV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIGV.TextChanged
            Dim dCargo As Double
            Dim x As Integer

            Try
                If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then

                    'Try
                    While (dgvDetalle.Rows.Count > x)
                        dCargo += Val(dgvDetalle.Rows(x).Cells("prd_Importe").Value)
                        x += 1
                    End While
                    txtBaseImponible.Text = dCargo.ToString
                    'Catch ex As Exception
                    'End Try
                    txtBaseImponible.Text = dCargo.ToString
                    txtBaseImponible.Text = Val(txtBaseImponible.Text) - Val(txtIGV.Text)
                    txtSaldoXDistribuir.Text = Val(txtBaseImponible.Text)
                End If
            Catch ex As Exception
                txtBaseImponible.Text = dCargo.ToString
                txtIGV.Text = "0.00"
                txtBaseImponible.Text = Val(txtBaseImponible.Text) - Val(txtIGV.Text)
                txtSaldoXDistribuir.Text = Val(txtBaseImponible.Text)
            End Try

            totalBase()
        End Sub

        Private Sub txtTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.TextChanged
            txtTotalDocumento.Text = txtTotal.Text
        End Sub

        Private Sub dgvDetalle_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellValidated

            If (e.RowIndex >= 0 AndAlso Not IsDBNull(dgvDetalle.Rows(e.RowIndex).Cells("cuc_id")) AndAlso dgvDetalle.Rows(e.RowIndex).Cells("cuc_id").Value <> "") Then
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.CuentasContables)

                frm.txtBuscar.Text = dgvDetalle.Rows(e.RowIndex).Cells("cuc_id").Value

                frm.cargarDatos()

                If (frm.dgbRegistro.SelectedRows.Count > 0) Then
                    dgvDetalle.Rows(e.RowIndex).Cells("cuc_id").Value = frm.dgbRegistro.SelectedRows(0).Cells(0).Value
                    dgvDetalle.Rows(e.RowIndex).Cells("cuc_id").Tag = frm.dgbRegistro.SelectedRows(0).Cells(0).Value
                    dgvDetalle.Rows(e.RowIndex).Cells("cuenta").Value = frm.dgbRegistro.SelectedRows(0).Cells(1).Value
                    dgvDetalle.Rows(e.RowIndex).Cells("cls_Id").Tag = frm.dgbRegistro.SelectedRows(0).Cells(5).Value
                    dgvDetalle.Rows(e.RowIndex).Cells("cta").Tag = frm.dgbRegistro.SelectedRows(0).Cells(0).Value
                End If
                frm.Dispose()
            End If
            sumar()

        End Sub

        Private Sub txtRuc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRuc.TextChanged
            If (IsNumeric(txtRuc.Text) AndAlso txtRuc.Text.Length = 11) Then
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.BuscarPersona)
                frm.llenarCombo()
                frm.cboBuscar.SelectedIndex = 2
                frm.txtBuscar.Text = txtRuc.Text
                frm.cargarDatos()

                If (frm.dgbRegistro.Rows.Count > 0) Then
                    With frm.dgbRegistro.Rows(0)

                        txtPersona.Tag = .Cells(0).Value
                        txtPersona.Text = .Cells(1).Value

                        'If (Not .Cells(3).Value Is Nothing) Then
                        '    txtRuc.Text = .Cells(3).Value
                        'Else
                        '    txtRuc.Text = ""
                        'End If

                    End With
                    btnComprobante.Focus()

                End If

            End If
        End Sub


        Private Sub btnCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompras.Click
            Try
                If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then Exit Sub
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarDocumentosCompra)()

                If lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionComprasServicios Then
                    frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarDocumentosCompraServicio)
                ElseIf lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionPlanillasMovilidad Then
                    frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarDocumentosPlanillaMovilidad)
                ElseIf lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionRendicionEntregas Then
                    frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarDocumentosRendicionEntregas)
                Else
                    frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarDocumentosCompra)
                End If

                frm.txtPersona.Text = Me.txtPersona.Text
                frm.dateDesde.Value = Today.AddMonths(-3)
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    If (CDate(frm.dgvDetalle.CurrentRow.Cells("Fecha").Value).Month <> CDate(frm.dgvDetalle.CurrentRow.Cells("FechaRegistro").Value).Month) Then
                        If (MsgBox("Las fechas del Documento y registro no corresponden al mismo periodo en logistica, " & Chr(13) _
                                   & " continura de todas maneras " & Chr(13) _
                                   & " Fecha documento " & frm.dgvDetalle.CurrentRow.Cells("Fecha").Value & Chr(13) _
                                   & " Fecha registro " & frm.dgvDetalle.CurrentRow.Cells("FechaRegistro").Value _
                                   , MsgBoxStyle.YesNo) = MsgBoxResult.No) Then
                            Exit Sub
                        End If
                    End If
                    If (Val(CDate(frm.dgvDetalle.CurrentRow.Cells("FechaRegistro").Value).Month) <> Val(txtPeriodo.Text.Substring(4, 2)) _
                        OrElse Val(CDate(frm.dgvDetalle.CurrentRow.Cells("FechaRegistro").Value).Year) <> Val(txtPeriodo.Text.Substring(0, 4))) Then
                        ''MsgBox("La fecha del registro esta fuera del periodo")
                        ''Exit Sub
                    End If
                    With frm.dgvDetalle.CurrentRow
                        dgvguias.Rows.Clear()
                        Try
                            If lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionComprasServicios Then
                                lblOrdenTrabajo.Text = .Cells("OTR_ID").Value
                            ElseIf lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionPlanillasMovilidad Then
                                lblOrdenTrabajo.Text = .Cells("OTR_ID").Value
                            ElseIf lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionRendicionEntregas Then
                                lblOrdenTrabajo.Text = .Cells("OTR_ID").Value
                            Else
                                lblOrdenTrabajo.Text = .Cells("OTR_ID").Value
                            End If

                        Catch ex As Exception
                            lblOrdenTrabajo.Text = "0"
                            lblDocuMovimiento.Text = "0"
                        End Try

                        lblDocuMovimiento.Text = .Cells("DMO_ID").Value.ToString
                        lblCuentaRendirDetalle.Text = .Cells("CRD_ID").Value.ToString
                        lblOrdenServicio.Text = .Cells("OSE_ID").Value.ToString
                        lblRendicionGastos.Text = .Cells("RGA_ID").Value.ToString
                        lblCuentaRendirDetalle.Text = .Cells("CRD_ID").Value.ToString

                        Try
                            If IsNothing(.Cells("DMO_ID").Value.ToString) Then
                                txtCompras.Text = ""
                            Else
                                txtCompras.Text = .Cells("DMO_ID").Value.ToString
                            End If
                        Catch ex As Exception
                            txtCompras.Text = ""
                        End Try

                        txtSerieSunat.Text = .Cells("Serie").Value
                        If Len(txtSerieSunat.Text) = 3 Then
                            txtSerieSunat.Text = ""
                        End If

                        txtSerie.Text = Strings.Right(.Cells("Serie").Value, 3)
                        txtNumero.Text = .Cells("Numero").Value

                        txtTipoDocumento.Text = .Cells("TDO_ID").Value
                        txtTipoDocumento.Tag = .Cells("TDO_ID").Value

                        txtCombrobante.Tag = .Cells("DTD_ID").Value
                        txtCombrobante.Text = .Cells("Descripcion").Value

                        txtPersona.Tag = .Cells("persona").Value
                        txtPersona.Text = .Cells("nombre").Value
                        Try
                            txtRuc.Text = .Cells("RUC").Value
                        Catch ex As Exception
                            txtRuc.Text = Nothing
                        End Try

                        txtMoneda.Tag = (.Cells("Cod_Moneda").Value)
                        txtMoneda.Text = (.Cells("Moneda").Value)

                        Try
                            txtCuentaCorriente.Text = .Cells("ctacte").Value
                            txtCuentaCorriente.Tag = .Cells("ctacte").Value
                        Catch ex As Exception
                            txtCuentaCorriente.Text = Nothing
                            txtCuentaCorriente.Tag = Nothing
                        End Try

                        txtFecha.Text = CDate(.Cells("Fecha").Value)
                        txtFechaVencimiento.Text = CDate(.Cells("Fecha").Value)

                        If Not (IsDBNull(.Cells("SubTotal").Value)) Then
                            txtBaseImponible.Text = CDbl(.Cells("SubTotal").Value)
                            txtIGV.Text = CDbl(.Cells("IGV").Value)
                            txtTotal.Text = CDbl(.Cells("Total").Value)
                            txtTotalDocumento.Text = txtTotal.Text
                        End If
                    End With

                    Dim query As String
                    Dim oDataTable As DataTable


                    If lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionComprasServicios Then
                        query = BCProvisionCompras.SPDocuMovimientoDetalleServicioXML(lblOrdenServicio.Text)
                        'query = BCProvisionCompras.SPDocuMovimientoDetalleServicioXML(txtCompras.Text)
                        'txtCompras.Text = ""
                    ElseIf lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionPlanillasMovilidad Then
                        query = BCProvisionCompras.SPDocuMovimientoDetallePlanillaXML(lblRendicionGastos.Text)
                    ElseIf lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionRendicionEntregas Then
                        query = BCProvisionCompras.SPDocuMovimientoDetalleRendicionXML(lblCuentaRendirDetalle.Text)
                    Else
                        query = BCProvisionCompras.SPDocuMovimientoDetalleXML(txtCompras.Text)
                    End If

                    If (query <> Nothing) Then
                        Dim ds As New DataSet
                        dgvDetalle.Rows.Clear()
                        Dim rea As New StringReader(query)
                        Dim x As Integer = 0
                        If (query <> "") Then
                            ds.ReadXml(rea)
                            oDataTable = ds.Tables(0)
                            If (dgvDetalle.SelectedRows.Count > 0) Then
                                For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                                    If Not mDetalle.Cells("prd_Item").Value Is Nothing Then
                                        With CType(mDetalle.Cells("prd_Item").Tag, BE.DetalleProvisionCompras)
                                            .MarkAsDeleted()
                                        End With
                                    End If
                                    dgvDetalle.Rows.Remove(mDetalle)
                                Next
                                sumar()
                            End If
                            While (oDataTable.Rows.Count > x)
                                dgvDetalle.Rows.Add()
                                With oDataTable.Rows(x)
                                    If Not (IsDBNull(.Item("Cuenta"))) Then
                                        dgvDetalle.Rows(x).Cells("cuc_id").Value = .Item("Cuenta")
                                        dgvDetalle.Rows(x).Cells("cuc_id").Tag = .Item("Cuenta") ''.Value
                                        dgvDetalle.Rows(x).Cells("cuenta").Value = .Item("Descripcion") ''.Value
                                        dgvDetalle.Rows(x).Cells("cls_Id").Tag = .Item("cls_Id") ''.Value
                                        dgvDetalle.Rows(x).Cells("cta").Tag = .Item("Cuenta") ''.Value
                                        dgvDetalle.Rows(x).Cells("prd_Importe").Value = .Item("SubTotal")
                                        dgvDetalle.Rows(x).Cells("ALM_ID").Value = .Item("ALM_ID")
                                        ''dgvDetalle.Rows(x).Cells("ALM_DESCRIPCION").Value = .Item("Almacen")
                                        dgvDetalle.Rows(x).Cells("Almacen").Value = .Item("ALM_DESCRIPCION")
                                    Else
                                        dgvDetalle.Rows(x).Cells("prd_Importe").Value = .Item("SubTotal")
                                        dgvDetalle.Rows(x).Cells("ALM_ID").Value = .Item("ALM_ID")
                                        dgvDetalle.Rows(x).Cells("Almacen").Value = .Item("ALM_DESCRIPCION")
                                    End If
                                End With
                                x += 1
                            End While
                        End If
                    End If
                End If
                frm.Dispose()
                btnTipoVenta.Focus()
            Catch ex As Exception
                btnTipoVenta.Focus()
            End Try
        End Sub

        Private Sub txtNoGrvado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoGrvado.TextChanged
            totalBase()
            TotalAdistribuir()
        End Sub

        Private Sub btnCPOriginal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCPOriginal.Click
            Try
                If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then Exit Sub
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarDocumentosCompra)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.ProvisionComprasXRef)
                frm.txtPersona.Text = txtPersona.Text
                frm.txtPersona.Tag = txtPersona.Tag
                frm.txtPersona.ReadOnly = True
                frm.dateDesde.Value = Today.AddMonths(-10)
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgvDetalle.CurrentRow

                        txtCPOriginal.Tag = .Cells(2).Value 'dtd
                        txtCPOriginal.Text = .Cells(3).Value

                        txtCPSerie.Text = .Cells(4).Value
                        txtCPNumero.Text = .Cells(5).Value

                        txtCPSerie.Tag = .Cells(0).Value ' cct_corriente 
                        txtCPNumero.Tag = .Cells(1).Value 'tdt


                    End With
                End If
                frm.Dispose()
            Catch ex As Exception

            End Try

        End Sub

        Private Sub txtFecha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            txtFechaVencimiento.Text = txtFecha.Text
        End Sub

        Private Sub dgvDetalle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDetalle.KeyPress
            Try
                If (e.KeyChar = Chr(Keys.Enter)) Then
                    If (dgvDetalle.SelectedCells(0).ColumnIndex = 2) Then


                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
                        frm.inicio(Constants.BuscadoresNames.CuentasContables)

                        frm.llenarCombo()
                        frm.txtBuscar.Text = dgvDetalle.SelectedCells(0).Value
                        frm.cargarDatos()

                        If (frm.dgbRegistro.Rows.Count > 0) Then
                            With frm.dgbRegistro.Rows(0)

                                dgvDetalle.Rows(dgvDetalle.SelectedCells(0).RowIndex).Cells("cuc_id").Value = .Cells(0).Value
                                dgvDetalle.Rows(dgvDetalle.SelectedCells(0).RowIndex).Cells("cuc_id").Tag = .Cells(0).Value
                                dgvDetalle.Rows(dgvDetalle.SelectedCells(0).RowIndex).Cells("cuenta").Value = .Cells(1).Value
                                dgvDetalle.Rows(dgvDetalle.SelectedCells(0).RowIndex).Cells("cls_Id").Tag = .Cells(5).Value
                                dgvDetalle.Rows(dgvDetalle.SelectedCells(0).RowIndex).Cells("cta").Tag = .Cells(0).Value

                            End With

                        End If
                        frm.Dispose()
                    End If
                End If



                'key =+
                If (Asc(e.KeyChar) = 43) Then
                    OnManAgregarFilaGrid()
                End If
                'key  = -
                If (Asc(e.KeyChar) = 45) Then
                    OnManQuitarFilaGrid()
                End If

                If (e.KeyChar = Chr(Keys.Insert)) Then
                    OnManGuardar()
                End If
            Catch ex As Exception

            End Try

        End Sub
        Protected Overrides Function ProcessTabKey(ByVal forward As Boolean) As Boolean
            Select Case Me.ActiveControl.Name
                Case btnPeriodo.Name
                    btnLibro.Focus()
                Case btnLibro.Name
                    txtVoucher.Focus()
                Case txtVoucher.Name
                    dateFechaVoucher.Focus()
                Case dateFechaVoucher.Name
                    btnPersona.Focus()
                Case btnPersona.Name
                    txtRuc.Focus()
                Case txtRuc.Name
                    btnComprobante.Focus()
                Case btnComprobante.Name
                    txtSerie.Focus()
                Case txtSerie.Name
                    txtNumero.Focus()
                Case txtNumero.Name
                    txtFecha.Focus()
                Case txtFecha.Name
                    txtFechaVencimiento.Focus()
                Case txtFechaVencimiento.Name
                    If (txtTipoDocumento.Text = "041" And txtCombrobante.Tag = "060"
                        ) OrElse (txtTipoDocumento.Text = "044" And txtCombrobante.Tag = "088") Then
                        btnCPOriginal.Focus()

                    Else
                        chkAfectoSPOT.Focus()
                    End If

                Case btnCPOriginal.Name
                    chkAfectoSPOT.Focus()
                Case chkAfectoSPOT.Name
                    If (chkAfectoSPOT.Checked) Then
                        txtNumeroSPOT.Focus()
                    Else
                        btnAgencia.Focus()
                    End If
                Case txtNumeroSPOT.Name
                    txtFechaSPOT.Focus()
                Case txtFechaSPOT.Name
                    btnOperacion.Focus()
                Case btnOperacion.Name
                    btnTipoDetraccion.Focus()
                Case btnTipoDetraccion.Name
                    btnAgencia.Focus()
                Case btnAgencia.Name
                    btnCentroCosto.Focus()
                Case btnCentroCosto.Name
                    btnCompras.Focus()
                Case btnCompras.Name
                    btnTipoVenta.Focus()
                Case btnTipoVenta.Name
                    txtglosa.Focus()
                Case btnResponsable.Name
                    If (chkRetencion4ta.Enabled) Then
                        chkRetencion4ta.Focus()
                    Else
                        chkRetenerTercera.Focus()
                    End If
                Case txtglosa.Name
                    btnResponsable.Focus()

                Case chkRetencion4ta.Name
                    chkRetenerTercera.Focus()
                Case chkRetenerTercera.Name
                    TabControl1.SelectedTab = TabPage1
                    btnMoneda.Focus()
                Case btnMoneda.Name
                    ' recibo de honorarios o boletas
                    If (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "083") Or (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "234") Or (txtTipoDocumento.Text = "023" And txtCombrobante.Tag = "039") Then
                        txtNoGrvado.Focus()
                    Else
                        txtBaseImponible.Focus()
                    End If

                Case txtBaseImponible.Name
                    txtIGV.Focus()
                Case txtIGV.Name
                    txtNoGrvado.Focus()
                Case txtNoGrvado.Name
                    txtDescuento.Focus()
                Case txtDescuento.Name
                    txtPercepcion.Focus()
                Case txtPercepcion.Name

                    If (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "079") Then
                        TabControl1.SelectedTab = TabPage4
                    Else
                        TabControl1.SelectedTab = TabPage2
                        AddPrimaraCuenta()
                    End If

                Case txtDua.Name
                    btnComprobante.Focus()

            End Select
            Return True
            '            MyBase.ProcessTabKey(forward)

        End Function

        Private Sub PasarFocus_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            btnPeriodo.KeyPress, _
            btnLibro.KeyPress, _
            txtVoucher.KeyPress, _
            txtFecha.KeyPress, _
            btnPersona.KeyPress, _
            txtRuc.KeyPress, _
            btnComprobante.KeyPress, _
            txtSerie.KeyPress, _
            txtNumero.KeyPress, _
            txtFechaVencimiento.KeyPress, _
            btnResponsable.KeyPress, _
            dateFechaVoucher.KeyPress, _
            btnCPOriginal.KeyPress, _
            chkAfectoSPOT.KeyPress, _
            txtNumeroSPOT.KeyPress, _
            txtFechaSPOT.KeyPress, _
            btnOperacion.KeyPress, _
            btnTipoDetraccion.KeyPress, _
            btnAgencia.KeyPress, _
            btnCentroCosto.KeyPress, _
            btnCompras.KeyPress, _
            btnTipoVenta.KeyPress, _
            txtglosa.KeyPress, _
            chkRetencion4ta.KeyPress, _
            chkRetenerTercera.KeyPress, _
            btnMoneda.KeyPress, _
            txtBaseImponible.KeyPress, _
            txtIGV.KeyPress, _
            txtNoGrvado.KeyPress, _
            txtDescuento.KeyPress, _
            txtPercepcion.KeyPress, _
            txtDua.KeyPress, _
            chkRetenerTercera.KeyPress


            'If (e.KeyChar = Chr(Keys.F2)) Then
            '    OnManBuscar()
            'End If
            'If (e.KeyChar = Chr(Keys.F3)) Then
            '    OnManNuevo()
            'End If
            'If (e.KeyChar = Chr(Keys.F4)) Then
            '    OnManEditar()
            'End If
            'If (e.KeyChar = Chr(Keys.F5)) Then
            '    OnManEliminar()
            'End If
            'If (e.KeyChar = Chr(Keys.F6)) Then
            '    OnManGuardar()
            'End If
            'If (e.KeyChar = Chr(Keys.F7)) Then
            '    OnManCancelarEdicion()
            'End If

            'Para ir al  casillero anterior 
            If (e.KeyChar = Chr(Keys.Up) OrElse e.KeyChar = Chr(Keys.Left)) Then
                Select Case Me.ActiveControl.Name

                    Case btnLibro.Name
                        btnPeriodo.Focus()
                    Case txtVoucher.Name
                        btnLibro.Focus()
                    Case dateFechaVoucher.Name
                        txtVoucher.Focus()
                    Case btnPersona.Name
                        dateFechaVoucher.Focus()
                    Case txtRuc.Name
                        btnComprobante.Focus()
                    Case btnComprobante.Name
                        txtRuc.Focus()
                    Case txtSerie.Name
                        btnComprobante.Focus()
                    Case txtNumero.Name
                        txtSerie.Focus()
                    Case txtFecha.Name
                        txtNumero.Focus()
                    Case txtFechaVencimiento.Name
                        txtFecha.Focus()
                    Case btnCPOriginal.Name
                        txtFechaVencimiento.Focus()
                    Case chkAfectoSPOT.Name

                        btnCPOriginal.Focus()

                    Case txtNumeroSPOT.Name
                        chkAfectoSPOT.Focus()
                    Case txtFechaSPOT.Name
                        txtNumeroSPOT.Focus()
                    Case btnOperacion.Name
                        txtFechaSPOT.Focus()
                    Case btnTipoDetraccion.Name
                        btnOperacion.Focus()
                    Case btnAgencia.Name
                        btnTipoDetraccion.Focus()
                    Case btnCentroCosto.Name
                        btnAgencia.Focus()
                    Case btnCompras.Name
                        btnCentroCosto.Focus()
                    Case btnTipoVenta.Name
                        btnCompras.Focus()
                    Case txtglosa.Name
                        btnTipoVenta.Focus()
                    Case btnResponsable.Name
                        txtglosa.Focus()
                    Case chkRetencion4ta.Name
                        btnResponsable.Focus()
                    Case chkRetenerTercera.Name

                        chkRetencion4ta.Focus()

                    Case btnMoneda.Name
                        chkRetenerTercera.Focus()
                    Case txtBaseImponible.Name
                        btnMoneda.Focus()
                    Case txtIGV.Name
                        txtBaseImponible.Focus()
                    Case txtNoGrvado.Name
                        txtIGV.Focus()
                    Case txtDescuento.Name
                        txtNoGrvado.Focus()
                    Case txtPercepcion.Name
                        txtDescuento.Focus()


                    Case txtDua.Name
                        btnComprobante.Focus()

                End Select
            End If

            ' para ir al siguiente casillero
            '--------------------------------
            If (e.KeyChar = Chr(Keys.Enter) OrElse e.KeyChar = Chr(Keys.Tab) OrElse e.KeyChar = Chr(Keys.Down) OrElse e.KeyChar = Chr(Keys.Right)) Then
                Select Case Me.ActiveControl.Name
                    Case btnPeriodo.Name
                        btnLibro.Focus()
                    Case btnLibro.Name
                        txtVoucher.Focus()
                    Case txtVoucher.Name
                        dateFechaVoucher.Focus()
                    Case dateFechaVoucher.Name
                        btnPersona.Focus()
                    Case btnPersona.Name
                        txtRuc.Focus()
                    Case txtRuc.Name
                        btnComprobante.Focus()
                    Case btnComprobante.Name
                        txtSerie.Focus()
                    Case txtSerie.Name
                        txtNumero.Focus()
                    Case txtNumero.Name
                        txtFecha.Focus()
                    Case txtFecha.Name
                        txtFechaVencimiento.Focus()
                    Case txtFechaVencimiento.Name
                        If (txtTipoDocumento.Text = "041" And txtCombrobante.Tag = "060") OrElse _
                            (txtTipoDocumento.Text = "044" And txtCombrobante.Tag = "088") Then
                            btnCPOriginal.Focus()

                        Else
                            chkAfectoSPOT.Focus()
                        End If
                    Case btnCPOriginal.Name
                        chkAfectoSPOT.Focus()
                    Case chkAfectoSPOT.Name

                        If (chkAfectoSPOT.Checked) Then
                            txtNumeroSPOT.Focus()
                        Else
                            btnAgencia.Focus()
                        End If

                    Case txtNumeroSPOT.Name
                        txtFechaSPOT.Focus()
                    Case txtFechaSPOT.Name
                        btnOperacion.Focus()
                    Case btnOperacion.Name
                        btnTipoDetraccion.Focus()
                    Case btnTipoDetraccion.Name
                        btnAgencia.Focus()
                    Case btnAgencia.Name
                        btnCentroCosto.Focus()
                    Case btnCentroCosto.Name
                        btnCompras.Focus()
                    Case btnCompras.Name
                        btnTipoVenta.Focus()
                    Case btnTipoVenta.Name
                        txtglosa.Focus()
                    Case btnResponsable.Name
                        If (chkRetencion4ta.Enabled) Then
                            chkRetencion4ta.Focus()
                        Else
                            chkRetenerTercera.Focus()
                        End If
                    Case txtglosa.Name
                        btnResponsable.Focus()
                    Case chkRetencion4ta.Name
                        chkRetenerTercera.Focus()
                    Case chkRetenerTercera.Name

                        If (txtCompras.Text = "") Then
                            TabControl1.SelectedTab = TabPage1
                            btnMoneda.Focus()
                        Else
                            TabControl1.SelectedTab = TabPage2
                        End If

                    Case btnMoneda.Name
                        If (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "083") Or (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "234") Or (txtTipoDocumento.Text = "023" And txtCombrobante.Tag = "039") Then
                            txtNoGrvado.Focus()
                        Else
                            txtBaseImponible.Focus()
                        End If

                    Case txtBaseImponible.Name
                        txtIGV.Focus()
                    Case txtIGV.Name
                        txtNoGrvado.Focus()
                    Case txtNoGrvado.Name
                        txtDescuento.Focus()
                    Case txtDescuento.Name
                        txtPercepcion.Focus()
                    Case txtPercepcion.Name
                        If (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "079") Then
                            TabControl1.SelectedTab = TabPage4
                        Else
                            TabControl1.SelectedTab = TabPage2
                            AddPrimaraCuenta()

                        End If


                    Case txtDua.Name
                        btnComprobante.Focus()

                End Select
            End If





            'key =+
            If (Asc(e.KeyChar) = 43) Then
                OnManAgregarFilaGrid()
            End If
            'key  = -
            If (Asc(e.KeyChar) = 45) Then
                OnManQuitarFilaGrid()
            End If
            If (e.KeyChar = Chr(Keys.Insert)) Then
                OnManGuardar()
            End If


        End Sub

        Sub AddPrimaraCuenta()
            Dim iRow As Integer = 0
            Dim dImporte As Double

            If (dgvDetalle.Rows.Count <= 0) Then

                dImporte = Val(txtBaseImponible.Text) + Val(txtNoGrvado.Text) + Val(txtOtrosTributos.Text)
                dgvDetalle.Rows.Add()
                iRow = dgvDetalle.RowCount - 1
                dgvDetalle.Rows(iRow).Cells("prd_Importe").Value = dImporte.ToString

                sumar()
            End If

        End Sub

        Private Sub dgvguias_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvguias.KeyPress
            'key =+
            If (Asc(e.KeyChar) = 43) Then
                OnManAgregarFilaGrid()
            End If
            'key  = -
            If (Asc(e.KeyChar) = 45) Then
                OnManQuitarFilaGrid()
            End If
        End Sub

        Private Sub dgvNotaCredito_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvNotaCredito.KeyPress
            'key =+
            If (Asc(e.KeyChar) = 43) Then
                OnManAgregarFilaGrid()
            End If
            'key  = -
            If (Asc(e.KeyChar) = 45) Then
                OnManQuitarFilaGrid()
            End If

        End Sub

        Private Sub chkAfectoSPOT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAfectoSPOT.CheckedChanged
            txtNumeroSPOT.ReadOnly = Not chkAfectoSPOT.Checked
            txtFechaSPOT.ReadOnly = Not chkAfectoSPOT.Checked

            btnOperacion.Enabled = chkAfectoSPOT.Checked
            btnTipoDetraccion.Enabled = chkAfectoSPOT.Checked

            If (Not chkAfectoSPOT.Checked) Then
                txtOperacionDetraccion.Text = ""
                txtOperacionDetraccion.Tag = ""

                txtTipoDetraccion.Text = ""
                txtTipoDetraccion.Tag = ""
            End If


        End Sub

        Private Sub TabPage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage4.Click

        End Sub

        Private Sub dgvNotaCredito_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNotaCredito.CellValidated
            sumarAfectaciones()
        End Sub

        Private Sub txtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            txtFechaVencimiento.Text = CDate(txtFecha.Text)
        End Sub

        Private Sub dgvDetalle_CellStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellStateChangedEventArgs) Handles dgvDetalle.CellStateChanged
            Try
                If (Not e.Cell.Value Is Nothing) Then
                    Select Case dgvDetalle.Columns(e.Cell.ColumnIndex).Name

                        Case "cuc_Id"


                            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
                            frm.inicio(Constants.BuscadoresNames.CuentasContables)

                            frm.llenarCombo()
                            frm.txtBuscar.Text = e.Cell.Value
                            frm.cargarDatos()

                            If (frm.dgbRegistro.RowCount > 0) Then
                                With frm.dgbRegistro.Rows(0)

                                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("cuc_id").Value = .Cells(0).Value
                                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("cuc_id").Tag = .Cells(0).Value
                                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("cuenta").Value = .Cells(1).Value
                                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("cls_Id").Tag = .Cells(5).Value
                                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("cta").Tag = .Cells(0).Value

                                End With

                            End If
                            frm.Dispose()

                    End Select
                End If
            Catch ex As Exception

            End Try


        End Sub

        Private Sub txt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
            Handles txtSerie.KeyDown, _
            txtNumero.KeyDown, _
            txtVoucher.KeyDown, _
            txtFecha.KeyDown, _
            txtRuc.KeyDown, _
            txtFechaVencimiento.KeyDown, _
            dateFechaVoucher.KeyDown, _
            txtNumeroSPOT.KeyDown, _
            txtFechaSPOT.KeyDown, _
            txtBaseImponible.KeyDown, _
            txtPercepcion.KeyDown, _
            txtDescuento.KeyDown, _
            txtNoGrvado.KeyDown, _
            txtIGV.KeyDown, _
            txtglosa.KeyDown, _
            btnResponsable.KeyDown, _
            chkRetenerTercera.KeyDown, _
            txtDua.KeyDown, _
            txtcentroCosto.KeyDown, _
            txtCombrobante.KeyDown, _
            txtCompras.KeyDown, _
            txtAdvalore.KeyDown, _
            txtCPNumero.KeyDown, _
            txtCPOriginal.KeyDown, _
            txtCuentaCorriente.KeyDown, _
            dgvDetalle.KeyDown, _
            btnMoneda.KeyDown, _
            btnLibro.KeyDown, _
            btnAgencia.KeyDown, _
            btnCentroCosto.KeyDown, _
            btnCompras.KeyDown, _
            btnComprobante.KeyDown, _
            btnCPOriginal.KeyDown, _
            btnLibro.KeyDown, _
            btnOperacion.KeyDown, _
            btnTipoDetraccion.KeyDown, _
            btnTipoVenta.KeyDown, _
            dgvDetalle.KeyDown, _
            dgvguias.KeyDown, _
            dgvNotaCredito.KeyDown


            If (e.KeyCode = Keys.F2) Then
                OnManBuscar()
            End If
            If (e.KeyCode = Keys.F3) Then
                OnManNuevo()
            End If
            If (e.KeyCode = Keys.F4) Then
                OnManEditar()
            End If
            If (e.KeyCode = Keys.F5) Then
                OnManEliminar()
            End If
            If (e.KeyCode = Keys.F6) Then
                OnManGuardar()
            End If
            If (e.KeyCode = Keys.F7) Then
                OnManCancelarEdicion()
            End If

            ' para ir al anterior registro
            If (e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Left) Then


                Select Case Me.ActiveControl.Name
                    Case txtSerie.Name
                        If (txtSerie.SelectionStart = 0) Then
                            btnComprobante.Focus()
                        End If
                    Case txtNumero.Name
                        If (txtNumero.SelectionStart = 0) Then
                            txtSerie.Focus()
                        End If
                    Case txtVoucher.Name
                        If (txtNumero.SelectionStart = 0) Then
                            btnLibro.Focus()
                        End If
                    Case txtRuc.Name
                        '  If (txtVoucher.SelectionStart = 0) Then
                        btnPersona.Focus()
                        'End If
                    Case txtFechaVencimiento.Name
                        If (txtFechaVencimiento.SelectionStart = 0) Then
                            txtFecha.Focus()
                        End If
                    Case txtFecha.Name
                        If (txtFecha.SelectionStart = 0) Then
                            txtNumero.Focus()
                        End If
                    Case dateFechaVoucher.Name
                        If (dateFechaVoucher.SelectionStart = 0) Then
                            txtVoucher.Focus()
                        End If
                    Case txtNumeroSPOT.Name
                        chkAfectoSPOT.Focus()
                    Case txtFechaSPOT.Name
                        If (txtFechaSPOT.SelectionStart = 0) Then
                            btnOperacion.Focus()
                        End If
                    Case txtPercepcion.Name
                        txtDescuento.Focus()
                    Case txtDescuento.Name
                        txtNoGrvado.Focus()
                    Case txtNoGrvado.Name
                        txtIGV.Focus()
                    Case txtIGV.Name
                        txtBaseImponible.Focus()
                    Case txtBaseImponible.Name
                        btnMoneda.Focus()
                    Case btnMoneda.Name
                        txtglosa.Focus()


                    Case chkRetencion4ta.Name
                        txtglosa.Focus()

                End Select



            End If

            'para ir al siguiente registro  
            If (e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right) Then

                Select Case Me.ActiveControl.Name
                    Case txtSerie.Name

                        '  If (txtSerie.SelectionStart = 0 OrElse txtSerie.SelectionStart = 1 OrElse txtSerie.SelectionStart = 2 OrElse Len(txtSerie.Text) <= 0) Then
                        txtNumero.Focus()
                        '   End If
                    Case txtNumero.Name
                        'If (txtNumero.SelectionStart >= 0) Then
                        txtFecha.Focus()
                        ' End If

                    Case txtVoucher.Name
                        If (txtVoucher.SelectionStart = 0) Then
                            dateFechaVoucher.Focus()
                        End If
                    Case txtRuc.Name
                        '  If (txtVoucher.SelectionStart = 0) Then
                        btnComprobante.Focus()

                        'End If.
                    Case txtFecha.Name
                        If (txtFecha.SelectionStart = 10) Then
                            txtFechaVencimiento.Focus()
                        End If

                    Case txtFechaVencimiento.Name
                        If (txtFechaVencimiento.SelectionStart = 10) Then
                            If (txtTipoDocumento.Text = "041" And txtCombrobante.Tag = "060") OrElse _
                                ((txtTipoDocumento.Text = "044" And txtCombrobante.Tag = "088")) Then
                                btnCPOriginal.Focus()

                            Else
                                chkAfectoSPOT.Focus()
                            End If

                        End If

                    Case dateFechaVoucher.Name
                        If (dateFechaVoucher.SelectionStart = 10) Then
                            btnPersona.Focus()
                        End If

                    Case txtNumeroSPOT.Name
                        txtFechaSPOT.Focus()
                    Case txtFechaSPOT.Name
                        ' If (txtFechaSPOT.SelectionStart = 10) Then
                        btnAgencia.Focus()
                        ' End If
                    Case txtBaseImponible.Name
                        txtIGV.Focus()
                    Case txtIGV.Name
                        txtNoGrvado.Focus()
                    Case txtNoGrvado.Name
                        txtDescuento.Focus()


                    Case txtDescuento.Name
                        txtPercepcion.Focus()
                    Case txtPercepcion.Name
                        If (txtTipoDocumento.Text = "013" And txtCombrobante.Tag = "079") Then
                            TabControl1.SelectedTab = TabPage4
                        Else
                            TabControl1.SelectedTab = TabPage2
                            AddPrimaraCuenta()

                        End If
                    Case btnResponsable.Name
                        If (chkRetencion4ta.Enabled) Then
                            chkRetencion4ta.Focus()
                        Else
                            chkRetenerTercera.Focus()
                        End If
                    Case txtglosa.Name
                        btnResponsable.Focus()
                    Case chkRetenerTercera.Name

                        If (txtCompras.Text = "") Then
                            TabControl1.SelectedTab = TabPage1
                            btnMoneda.Focus()
                        Else
                            TabControl1.SelectedTab = TabPage2
                        End If

                End Select




            End If

        End Sub

        Private Sub txtIGV_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIGV.Leave
            perderEnfoque()
        End Sub

        Private Sub txtOtrosTributos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtrosTributos.TextChanged
            TotalAdistribuir()
        End Sub

        Private Sub txtDescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescuento.TextChanged
            totalBase()
        End Sub

        Private Sub txtTotalADistribuir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalADistribuir.TextChanged
            txtPorDistribuir.Text = Val(txtTotalADistribuir.Text) - Val(txtSaldoXDistribuir.Text)
        End Sub

        Private Sub txtSaldoXDistribuir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSaldoXDistribuir.TextChanged
            txtPorDistribuir.Text = Val(txtTotalADistribuir.Text) - Val(txtSaldoXDistribuir.Text)
        End Sub

        Private Sub btnResponsable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResponsable.Click

            Try
                If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then Exit Sub
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.BuscarPersona)
                frm.campo1 = "SI"

                If (frm.ShowDialog = DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtResponsable.Tag = .Cells(0).Value
                        txtResponsable.Text = .Cells(1).Value
                    End With

                End If
            Catch ex As Exception
            End Try

            chkRetenerTercera.Focus()

        End Sub

        Private Sub ToolStripTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ToolStripTextBox1.KeyPress



            If (Asc(e.KeyChar) = 13) Then

                If (dgvDetalle.SelectedRows.Count > 0) Then




                    If (MessageBox.Show("Esta seguro de realizar el cambio de cuenta" & Chr(13) & "De :" & _
                               dgvDetalle.SelectedRows(0).Cells("cuc_Id").Value.ToString() & _
                               "  -> " & _
                               ToolStripTextBox1.Text, "NUeva Cuenta", _
                               MessageBoxButtons.YesNo, _
                               MessageBoxIcon.Information) = MsgBoxResult.Yes) Then
                        Try
                            BCProvisionCompras.spDetalleProvisionCompras(txtPeriodo.Text, _
                                                                         txtVoucher.Text, _
                                                                         dgvDetalle.SelectedRows(0).Cells("cuc_Id").Value, _
                                                                         ToolStripTextBox1.Text)
                            MsgBox("Cuenta Modificada")
                            OnManNuevo()

                        Catch ex As Exception
                            MsgBox("No se pudo modificar la cuenta ,intente nuevamente")
                        End Try

                    End If

                Else
                    MsgBox("Seleccione un registro")
                End If


            End If
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Try
                If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then Exit Sub
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Reparable)
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtReparable.Tag = .Cells(0).Value
                        txtReparable.Text = .Cells(1).Value
                    End With
                End If
                txtglosa.Focus()
            Catch ex As Exception
                txtglosa.Focus()
            End Try
        End Sub

        Private Sub btnBorarReparable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorarReparable.Click
            If Me.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos Then Exit Sub
            txtReparable.Text = ""
            txtReparable.Tag = Nothing
        End Sub
    End Class
End Namespace
