
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports System.Drawing.Printing

Namespace Ladisac.Contabilidad.Views

    Public Class frmComprobantes

        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad

        <Dependency()> _
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCComprobantes As Ladisac.BL.IBCComprobantes
        <Dependency()> _
        Public Property BCDetalleComprobantes As Ladisac.BL.IBCDetalleComprobantes


        Protected oComprobantes As New BE.Comprobantes

        Public Property sTipoDocumento As String
        Public Property sDetalleTipoDocumento As String

        Public Property sTipoDocumentoB As String
        Public Property sDetalleTipoDocumentoB As String

        Public Property scuentaCorriente As String
        Public Property sCampoImprimirPie As String


        Dim oRptComprobantesFormato As New rptComprobantesFormato
        Dim orptComprobantesFormatoPercepcionCliente As New rptComprobantesFormatoPercepcionCliente
        Sub buscarPersona()
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
            '''
            '''

        End Sub
        Private Function validar() As Boolean
            Dim result As Boolean = True
            If (dgvDetalle.Rows.Count <= 0) Then
                ErrorProvider1.SetError(dgvDetalle, "Detalle")
                result = False
            Else
                ErrorProvider1.SetError(dgvDetalle, Nothing)
            End If

            If (txtSerie.Text = "") Then
                ErrorProvider1.SetError(txtSerie, "Serie")
                result = False
            Else
                ErrorProvider1.SetError(txtSerie, Nothing)
            End If



            If (txtPersona.Tag = "") Then
                ErrorProvider1.SetError(txtPersona, "Persona")
                result = False
            Else
                ErrorProvider1.SetError(txtPersona, Nothing)
            End If


            If (txtMoneda.Tag = "") Then
                ErrorProvider1.SetError(txtMoneda, "Moneda")
                result = False
            Else

                ErrorProvider1.SetError(txtMoneda, "")
            End If

            If (txtTotal.Text = "") Then
                ErrorProvider1.SetError(txtTotal, "Total")
                result = False
            Else

                ErrorProvider1.SetError(txtTotal, "")
            End If


            Return result

        End Function

        Sub cargar(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String)

            limpiar()

            oComprobantes = BCComprobantes.ComprobantesSeek(cct_Id, tdo_Id, dtd_Id, cob_Serie, cob_Numero)
            oComprobantes.MarkAsModified()

            txtMoneda.Tag = oComprobantes.mon_Id
            txtMoneda.Text = oComprobantes.Moneda.MON_SIMBOLO
            txtNumero.Text = oComprobantes.cob_Numero
            txtSerie.Text = oComprobantes.cob_Serie
            txtTotal.Text = oComprobantes.cbo_TotalImporte
            txtObservaciones.Text = oComprobantes.cbo_Observaciones
            chkActivo.Checked = CBool(oComprobantes.cbo_EsRecogido)

            If (oComprobantes.per_Id <> "") Then

                txtPersona.Tag = oComprobantes.per_Id
                txtPersona.Text = IIf(IsNothing(oComprobantes.Personas.PER_APE_PAT), "", oComprobantes.Personas.PER_APE_PAT) & " " & _
                  IIf(IsNothing(oComprobantes.Personas.PER_APE_MAT), "", oComprobantes.Personas.PER_APE_MAT) & " " & _
                  IIf(IsNothing(oComprobantes.Personas.PER_NOMBRES), "", oComprobantes.Personas.PER_NOMBRES)

            End If

            dateFecha.Value = CDate(oComprobantes.cob_Fecha)
            Try
                dateComprobante.Value = IIf(IsDBNull(oComprobantes.cob_FechaComprobante), CDate(oComprobantes.cob_Fecha), CDate(oComprobantes.cob_FechaComprobante))

            Catch ex As Exception
                dateComprobante.Value = CDate(oComprobantes.cob_Fecha)
            End Try

            If (IsDBNull(oComprobantes.cbo_SerieComprobante)) Then
                txtSerieComprobante.Text = ""
            Else
                txtSerieComprobante.Text = oComprobantes.cbo_SerieComprobante
            End If


            If (IsDBNull(oComprobantes.cbo_NumeroComprobante)) Then
                txtNumeroComprobante.Text = ""
            Else
                txtNumeroComprobante.Text = oComprobantes.cbo_NumeroComprobante
            End If

            Dim oTable As New DataTable
            oTable = BCComprobantes.SPDetalleComprobantes(oComprobantes.cct_Id, oComprobantes.tdo_Id, oComprobantes.dtd_Id, oComprobantes.cob_Serie, oComprobantes.cob_Numero)
            oComprobantes.ChangeTracker.ChangeTrackingEnabled = False
            oComprobantes.DetalleComprobantes = Nothing
            oComprobantes.ChangeTracker.ChangeTrackingEnabled = True


            Dim x As Integer = 0
            'For Each mItem In oGrupoTrabajo.DetalleGrupoTrabajo
            While x < oTable.Rows.Count
                With oTable.Rows(x)

                    Dim nRow As New DataGridViewRow
                    dgvDetalle.Rows.Add(nRow)

                    Dim oNewDetalleComprobantes As New BE.DetalleComprobantes

                    oNewDetalleComprobantes.cct_Id = .Item("cct_Id")
                    oNewDetalleComprobantes.cob_Serie = .Item("cob_Serie")
                    oNewDetalleComprobantes.cob_Numero = .Item("cob_Numero")
                    oNewDetalleComprobantes.tdo_Id = .Item("tdo_Id")
                    oNewDetalleComprobantes.dtd_Id = .Item("dtd_Id")
                    oNewDetalleComprobantes.dco_Item = .Item("dco_Item")
                    oNewDetalleComprobantes.tdo_IdRef = .Item("tdo_IdRef")
                    oNewDetalleComprobantes.dtd_IdRef = .Item("dtd_IdRef")
                    oNewDetalleComprobantes.dco_SerieRef = .Item("dco_SerieRef")
                    oNewDetalleComprobantes.dco_NumeroRef = .Item("dco_NumeroRef")
                    oNewDetalleComprobantes.dco_Importe = .Item("dco_Importe")
                    oNewDetalleComprobantes.dco_ContraValor = .Item("dco_ContraValor")
                    oNewDetalleComprobantes.per_IdRef = .Item("per_IdRef")
                    oNewDetalleComprobantes.Usu_Id = .Item("Usu_Id")
                    oNewDetalleComprobantes.dco_FecGrab = .Item("dco_FecGrab")
                    oNewDetalleComprobantes.mon_Id = .Item("mon_Id")


                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_IdRef").Value = oNewDetalleComprobantes.tdo_IdRef
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_IdRef").Tag = oNewDetalleComprobantes.tdo_IdRef

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_IdRef").Value = oNewDetalleComprobantes.dtd_IdRef
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Documento").Value = .Item("DTD_DESCRIPCION")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Serie").Value = oNewDetalleComprobantes.dco_SerieRef
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Value = oNewDetalleComprobantes.dco_NumeroRef
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Importe").Value = oNewDetalleComprobantes.dco_Importe
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ContraValor").Value = oNewDetalleComprobantes.dco_ContraValor
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("MontoOriginal").Value = .Item("MontoOriginal")


                    If (IsDBNull(.Item("DTD_DESCRIPCION")) OrElse .Item("DTD_DESCRIPCION") Is Nothing) Then
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Moneda").Value = Nothing
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mon_Id").Value = Nothing
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mon_Id").Tag = Nothing
                    Else

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Moneda").Value = .Item("MON_SIMBOLO")
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mon_Id").Value = oNewDetalleComprobantes.mon_Id
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mon_Id").Tag = oNewDetalleComprobantes.mon_Id
                    End If



                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Value = oNewDetalleComprobantes.dco_Item
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Tag = oNewDetalleComprobantes

                    oNewDetalleComprobantes.MarkAsModified()

                    oComprobantes.DetalleComprobantes.Add(oNewDetalleComprobantes)




                End With
                x += 1
            End While



            'For Each mItem In oComprobantes.DetalleComprobantes

            '    Dim nRow As New DataGridViewRow
            '    dgvDetalle.Rows.Add(nRow)
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_IdRef").Value = mItem.tdo_IdRef
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_IdRef").Tag = mItem.tdo_IdRef

            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_IdRef").Value = mItem.dtd_IdRef
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Documento").Value = mItem.TipoDocumentos.TDO_DESCRIPCION
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Serie").Value = mItem.dco_SerieRef
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Value = mItem.dco_NumeroRef
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Importe").Value = mItem.dco_Importe
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ContraValor").Value = mItem.dco_ContraValor

            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Moneda").Value = mItem.Moneda.MON_SIMBOLO

            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mon_Id").Value = mItem.mon_Id
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mon_Id").Tag = mItem.mon_Id

            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Value = mItem.dco_Item
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Tag = mItem

            'Next


            sumar()
        End Sub
        Public Overrides Sub OnManAgregarFilaGrid()

            'frmBuscarDocumentosCompras
            If (txtPersona.Text <> "") Then
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarDocumentosCompra)()
                frm.inicio(Constants.BuscadoresNames.DetalleComprobantesLista, dateFecha.Value)

                frm.txtPersona.Tag = txtPersona.Tag
                frm.txtPersona.Text = txtPersona.Text
                frm.campo1 = sTipoDocumentoB
                frm.campo2 = sDetalleTipoDocumentoB

                frm.dateDesde.Value = CDate(Today.AddYears(-5))

                Dim x As Integer = 0
                frm.txtPersona.ReadOnly = True
                If (frm.ShowDialog = DialogResult.OK) Then

                    While (frm.dgvDetalle.SelectedRows.Count > x)
                        With frm.dgvDetalle.SelectedRows(x)
                            dgvDetalle.Rows.Add(Nothing, .Cells(2).Value, .Cells(3).Value, .Cells(1).Value, .Cells(4).Value, .Cells(5).Value, .Cells("Total").Value, .Cells(7).Value, .Cells(8).Value, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value)

                        End With
                        x += 1
                    End While

                End If
                frm.Dispose()
                ErrorProvider1.SetError(txtPersona, "")
                sumar()
            Else
                ErrorProvider1.SetError(txtPersona, "Persona")
            End If
            If dgvDetalle.RowCount > 0 Then
                dateFecha.Enabled = False
                'dateComprobante.Enabled = False
            End If
        End Sub
        Public Overrides Sub OnManQuitarFilaGrid()
            If (dgvDetalle.SelectedRows.Count > 0) Then

                For Each mDetalle As DataGridViewRow In dgvDetalle.SelectedRows
                    If Not mDetalle.Cells("Item").Value Is Nothing Then
                        With CType(mDetalle.Cells("Item").Tag, BE.DetalleComprobantes)
                            .MarkAsDeleted()
                        End With

                    End If
                    dgvDetalle.Rows.Remove(mDetalle)
                    sumar()
                Next

            Else
                MsgBox("Seleccione un registro")
            End If
            If dgvDetalle.RowCount = 0 Then
                dateFecha.Enabled = True
                'dateComprobante.Enabled = True
            End If

        End Sub
        Public Overrides Sub OnReportes()
            imprimir()
        End Sub
        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarDocumentosCompra)()
            frm.inicio(Constants.BuscadoresNames.Comprobantes)
            frm.btnDocumento.Visible = False
            frm.campo1 = sTipoDocumento
            frm.campo2 = sDetalleTipoDocumento

            '''
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgvDetalle.CurrentRow.Cells(0).Value, frm.dgvDetalle.CurrentRow.Cells(1).Value, frm.dgvDetalle.CurrentRow.Cells(2).Value, frm.dgvDetalle.CurrentRow.Cells(3).Value, frm.dgvDetalle.CurrentRow.Cells(4).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False
            HabilitarReportes = True

        End Sub

        Function validarCeldas() As Boolean

            Dim result As Boolean = True
            'Dim iRow As Integer = 0

            'While (dgvDetalle.Rows.Count > iRow)

            'End While
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

        'Private Function VerificarDocumento() As Boolean
        '    Dim vControl As String = ""
        '    Dim vFilGrid As Int16 = 0
        '    VerificarDocumento = True
        '    While (dgvDetalle.Rows.Count() > vFilGrid)
        '        With dgvDetalle.Rows(vFilGrid)
        '            If vFilGrid = 0 Then
        '                vControl = .Cells("dtd_IdRef").Value
        '            End If
        '            If vControl <> .Cells("dtd_IdRef").Value Then
        '                VerificarDocumento = False
        '                Return VerificarDocumento
        '            End If
        '        End With
        '        vFilGrid += 1
        '    End While

        '    Return VerificarDocumento
        'End Function
        Public Overrides Sub OnManGuardar()

            If (validar() AndAlso validarCeldas()) Then
                Try

                    If oComprobantes IsNot Nothing Then

                        dgvDetalle.EndEdit()

                        oComprobantes.cct_Id = scuentaCorriente
                        oComprobantes.tdo_Id = sTipoDocumento
                        oComprobantes.dtd_Id = sDetalleTipoDocumento

                        oComprobantes.cob_Serie = txtSerie.Text
                        oComprobantes.cob_Numero = txtNumero.Text
                        oComprobantes.cob_Fecha = CDate(dateFecha.Text)
                        oComprobantes.cbo_SerieComprobante = txtSerieComprobante.Text
                        oComprobantes.cbo_NumeroComprobante = txtNumeroComprobante.Text
                        oComprobantes.cbo_Observaciones = txtObservaciones.Text
                        oComprobantes.mon_Id = txtMoneda.Tag
                        oComprobantes.per_Id = txtPersona.Tag

                        oComprobantes.cbo_EsRecogido = chkActivo.Checked

                        oComprobantes.cob_FechaComprobante = CDate(dateComprobante.Text)
                        oComprobantes.cbo_TotalImporte = txtTotal.Text
                        oComprobantes.Usu_Id = SessionService.UserId
                        oComprobantes.cbo_FECGRAB = Now

                        'Rompiendo relaciones 

                        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows

                            If Not mDetalle.Cells("Item").Value Is Nothing Then
                                With CType(mDetalle.Cells("Item").Tag, BE.DetalleComprobantes)

                                    .dco_Item = mDetalle.Cells("Item").Value()
                                    .tdo_IdRef = mDetalle.Cells("tdo_IdRef").Value()
                                    .dtd_IdRef = mDetalle.Cells("dtd_IdRef").Value()
                                    .dco_SerieRef = mDetalle.Cells("Serie").Value()
                                    .dco_NumeroRef = mDetalle.Cells("Numero").Value()
                                    .dco_Importe = CDec(mDetalle.Cells("Importe").Value())
                                    .dco_ContraValor = CDec(mDetalle.Cells("ContraValor").Value())
                                    .mon_Id = mDetalle.Cells("mon_Id").Value()
                                    .per_IdRef = txtPersona.Tag
                                    .Usu_Id = SessionService.UserId
                                    .dco_FecGrab = CDate(Today)
                                    .MarkAsModified()

                                End With
                            Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                                Dim nOSD As New DetalleComprobantes
                                With nOSD

                                    .dco_Item = mDetalle.Cells("Item").Value()
                                    .tdo_IdRef = mDetalle.Cells("tdo_IdRef").Value()
                                    .dtd_IdRef = mDetalle.Cells("dtd_IdRef").Value()
                                    .dco_SerieRef = mDetalle.Cells("Serie").Value()
                                    .dco_NumeroRef = mDetalle.Cells("Numero").Value()
                                    .dco_Importe = CDec(mDetalle.Cells("Importe").Value())
                                    .dco_ContraValor = CDec(mDetalle.Cells("ContraValor").Value())
                                    .mon_Id = mDetalle.Cells("mon_Id").Value()
                                    .per_IdRef = txtPersona.Tag
                                    .Usu_Id = SessionService.UserId
                                    .dco_FecGrab = CDate(Today)
                                    .MarkAsAdded()

                                End With
                                oComprobantes.DetalleComprobantes.Add(nOSD)
                            End If
                        Next

                        BCComprobantes.Maintenance(oComprobantes)

                        If (MsgBox("Datos Guardados Numero: " & oComprobantes.cob_Serie & " - " & oComprobantes.cob_Numero & " , ¿Se imprimirá el Comprobante?", vbYesNo + vbExclamation) = MsgBoxResult.Yes) Then
                            Try

                                txtNumero.Text = oComprobantes.cob_Numero
                                txtSerie.Text = oComprobantes.cob_Serie
                                imprimir()

                            Catch ex As Exception
                                MsgBox("No se Pudo Imprimir,Intentar mas tarde")
                            End Try

                        End If
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()
                        DeshabilitarElementoGrid()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Try
                        MsgBox(ex.InnerException.Message.ToString)
                    Catch ex2 As Exception

                    End Try
                    'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                    'If (rethrow) Then
                    '    msbox()
                    '    Throw
                    'End If
                End Try

            End If

        End Sub
        Private Sub imprimir(Optional ByVal vControl As Int16 = 1)
            Dim oTable As New DataTable
            Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

            Try
                oTable = Me.BCConsultasReportesContabilidad.RPTReportComprobantes(CDate(dateFecha.Value), CDate(dateFecha.Value), sTipoDocumento, sDetalleTipoDocumento, txtSerie.Text, txtNumero.Text)
                ''oTable = Me.BCConsultasReportesContabilidad.RPTReportComprobantes(CDate(dateFecha.Value), CDate(dateFecha.Value), sTipoDocumentoB, sDetalleTipoDocumentoB, txtSerie.Text, txtNumero.Text)
                Dim pd As New PrintDocument

                'si es percepcion del cliente de lo contrario otro formato 
                If (sTipoDocumento = "025" AndAlso sDetalleTipoDocumento = "185") Then

                    If (txtNumeroComprobante.Text <> "") Then
                        orptComprobantesFormatoPercepcionCliente.DataDefinition.FormulaFields("NumeroComprobante").Text = "'Numero Comprobante: " & txtSerieComprobante.Text & " - " & txtNumeroComprobante.Text & "'"
                    End If
                    orptComprobantesFormatoPercepcionCliente.DataDefinition.FormulaFields("Empresa").Text = "'" & SessionService.NombreEmpresa & "'"
                    orptComprobantesFormatoPercepcionCliente.DataDefinition.FormulaFields("Ruc").Text = "'" & SessionService.RUCEmpresa & "'"

                    orptComprobantesFormatoPercepcionCliente.Database.Tables(0).SetDataSource(oTable)
                    orptComprobantesFormatoPercepcionCliente.DataDefinition.FormulaFields("SubTitulo").Text = "'" & lblTitle.Text & "'"
                    orptComprobantesFormatoPercepcionCliente.PrintOptions.PrinterName = pd.PrinterSettings.PrinterName

                    orptComprobantesFormatoPercepcionCliente.DataDefinition.FormulaFields("CopiaNombre").Text = "'" & sCampoImprimirPie & "'" ' PROVEEDOR, CLIENTES , 
                    orptComprobantesFormatoPercepcionCliente.PrintToPrinter(1, False, 1, 1)
                    orptComprobantesFormatoPercepcionCliente.DataDefinition.FormulaFields("CopiaNombre").Text = "'EMISOR-AGENTE'"
                    orptComprobantesFormatoPercepcionCliente.PrintToPrinter(1, False, 1, 1)
                    orptComprobantesFormatoPercepcionCliente.DataDefinition.FormulaFields("CopiaNombre").Text = "'SUNAT'"
                    orptComprobantesFormatoPercepcionCliente.PrintToPrinter(1, False, 1, 1)

                Else

                    oRptComprobantesFormato.Database.Tables(0).SetDataSource(oTable)
                    If (txtNumeroComprobante.Text <> "") Then
                        oRptComprobantesFormato.DataDefinition.FormulaFields("NumeroComprobante").Text = "'Numero Comprobante: " & txtSerieComprobante.Text & " - " & txtNumeroComprobante.Text & "'"
                    End If

                    oRptComprobantesFormato.DataDefinition.FormulaFields("Empresa").Text = "'" & SessionService.NombreEmpresa & "'"
                    oRptComprobantesFormato.DataDefinition.FormulaFields("Ruc").Text = "'" & SessionService.RUCEmpresa & "'"

                    oRptComprobantesFormato.DataDefinition.FormulaFields("SubTitulo").Text = "'" & lblTitle.Text & "'"
                    oRptComprobantesFormato.PrintOptions.PrinterName = pd.PrinterSettings.PrinterName

                    oRptComprobantesFormato.DataDefinition.FormulaFields("CopiaNombre").Text = "'" & sCampoImprimirPie & "'" ' PROVEEDOR, CLIENTES , 
                    oRptComprobantesFormato.PrintToPrinter(1, False, 1, 1)
                    oRptComprobantesFormato.DataDefinition.FormulaFields("CopiaNombre").Text = "'EMISOR-AGENTE'"
                    oRptComprobantesFormato.PrintToPrinter(1, False, 1, 1)
                    oRptComprobantesFormato.DataDefinition.FormulaFields("CopiaNombre").Text = "'SUNAT'"


                    If vControl = 1 Then
                        oRptComprobantesFormato.PrintToPrinter(1, False, 1, 1)
                    End If


                End If

                If vControl = 2 Then
                    frm.Reporte(oRptComprobantesFormato)
                    frm.ShowDialog()
                End If


            Catch ex As Exception
                MsgBox("No se puede mostrar la informacion :" & ex.Message)
            End Try

        End Sub

        Public Overrides Sub OnManEditar()

            menuEditar()
            Panel1.Enabled = True
            HabilitarElementoGrid()
            dateFecha.Enabled = False
        End Sub

        Public Overrides Sub OnManCancelarEdicion()
            menuInicio()
            Panel1.Enabled = False
            limpiar()
        End Sub

        Public Overrides Sub OnManDeshacerCambios()
            menuInicio()
            Panel1.Enabled = False
            limpiar()
        End Sub
        Private Sub frmComprobantes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If (sTipoDocumento = "025" AndAlso sDetalleTipoDocumento = "045") Then
                dgvDetalle.Columns(6).ReadOnly = False
            End If
            menuInicio()
            Panel1.Enabled = False
        End Sub

        Sub sumar()
            Dim x As Integer = 0
            Dim dCargo As Double
            Try
                While (dgvDetalle.Rows.Count > x)

                    If (Val(dgvDetalle.Rows(x).Cells("ContraValor").Value) <= 0) Then
                        dCargo += Val(dgvDetalle.Rows(x).Cells("Importe").Value)
                    Else
                        dCargo += Val(dgvDetalle.Rows(x).Cells("ContraValor").Value)
                    End If


                    x += 1
                End While
                txtTotal.Text = dCargo.ToString

            Catch ex As Exception

                txtTotal.Text = "0.00"
            End Try
        End Sub

        Private Sub limpiar()


            txtMoneda.Text = ""
            txtMoneda.Tag = ""
            txtNumero.Text = ""
            txtObservaciones.Text = ""
            txtPersona.Text = ""
            txtPersona.Tag = ""
            txtSerie.Text = ""
            txtTotal.Text = ""
            chkActivo.Checked = True


            dgvDetalle.Rows.Clear()
            cargarMonedaDefault()
            HabilitarReportes = False

        End Sub

        Private Sub btnMoneda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoneda.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Moneda)
            If (frm.ShowDialog = DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow

                    txtMoneda.Tag = .Cells(0).Value
                    txtMoneda.Text = .Cells(1).Value

                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnPersonas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPersonas.Click
            buscarPersona()
        End Sub

        Public Overrides Sub OnManEliminar()


            Try
                If (MsgBox("Esta Seguro de Eliminar ", vbYesNo) = vbYes) Then
                    If oComprobantes IsNot Nothing Then
                        oComprobantes.MarkAsDeleted()

                        'Detalle de co.
                        oComprobantes.tdo_Id = sTipoDocumento
                        oComprobantes.dtd_Id = sDetalleTipoDocumento

                        oComprobantes.cob_Serie = txtSerie.Text
                        oComprobantes.cob_Numero = txtNumero.Text

                        BCComprobantes.MaintenanceDelete(oComprobantes)
                        MsgBox("Datos Guardados")
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()
                        DeshabilitarElementoGrid()
                    End If
                End If

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                If (rethrow) Then
                    Throw
                End If
            End Try

        End Sub

        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oComprobantes = New BE.Comprobantes
            oComprobantes.MarkAsAdded()
            HabilitarElementoGrid()
            Panel1.Enabled = True
            dateFecha.Enabled = True
        End Sub



        Private Sub dgvDetalle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDetalle.KeyPress
            'key =+
            If (Asc(e.KeyChar) = 43) Then
                OnManAgregarFilaGrid()
            End If
            'key  = -
            If (Asc(e.KeyChar) = 45) Then
                OnManQuitarFilaGrid()
            End If
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            imprimir(2)
        End Sub
    End Class

End Namespace