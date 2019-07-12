Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views

    Public Class frmLeasing

        <Dependency()> _
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCLeasing As Ladisac.BL.IBCLeasing
        <Dependency()> _
        Public Property BCDetalleLeasing As Ladisac.BL.IBCDetalleLeasing

        <Dependency()> _
        Public Property BCDetalleLeasingActivosFijos As Ladisac.BL.IBCDetalleLeasingActivosFijos

        Protected oLeasing As New BE.Leasing

        Public Property sTipoDocumento As String
        Public Property sDetalleTipoDocumento As String
        Public Property scuentaCorriente As String

        
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
        End Sub
        Private Function validarCuotas()
            Dim x As Integer = 0
            While (dgvCuotas.Rows.Count > x)
                With dgvCuotas.Rows(x)
                    If Not (IsDate(.Cells(1).Value)) AndAlso IsNumeric(.Cells(2).Value) AndAlso IsNumeric(.Cells(3).Value) AndAlso IsNumeric(.Cells(4).Value) AndAlso IsNumeric(.Cells(5).Value) Then
                        ErrorProvider1.SetError(txtObservaciones, "Error en la cuota Nº" & (x + 1).ToString)
                        Return False
                    End If

                End With
                x += 1
            End While
            Return True

        End Function

        Private Function validar() As Boolean
            Dim result As Boolean = True


            'If (dgvActivos.Rows.Count <= 0) Then
            '    ErrorProvider1.SetError(txtObservaciones, "Detalle")
            '    result = False
            'Else
            '    ErrorProvider1.SetError(txtObservaciones, Nothing)
            'End If

            'If (dgvActivos.Rows.Count <= 0) Then
            '    ErrorProvider1.SetError(txtObservaciones, "Detalle")
            '    result = False
            'Else
            '    ErrorProvider1.SetError(txtObservaciones, Nothing)
            'End If
            If Not (validarCuotas()) Then
                Return False
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


            If (Val(txtSumaCapital.Text) <= 0) Then
                ErrorProvider1.SetError(txtObservaciones, "Capital")
                result = False

            Else

                ErrorProvider1.SetError(txtObservaciones, "")
            End If


            Return result

        End Function

        Sub cargar(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String)

            limpiar()

            oLeasing = BCLeasing.LeasingSeek(cct_Id, tdo_Id, dtd_Id, cob_Serie, cob_Numero)
            oLeasing.MarkAsModified()

            txtMoneda.Tag = oLeasing.mon_Id
            txtMoneda.Text = oLeasing.Moneda.MON_SIMBOLO
            txtNumero.Text = oLeasing.lea_Numero
            txtSerie.Text = oLeasing.lea_Serie

            txtObservaciones.Text = oLeasing.lea_Observaciones
            txtNumeroContrato.Text = oLeasing.lea_NumeroContrato


            If (oLeasing.per_Id <> "") Then

                txtPersona.Tag = oLeasing.per_Id
                txtPersona.Text = IIf(IsNothing(oLeasing.Personas.PER_APE_PAT), "", oLeasing.Personas.PER_APE_PAT) & " " & _
                  IIf(IsNothing(oLeasing.Personas.PER_APE_MAT), "", oLeasing.Personas.PER_APE_MAT) & " " & _
                  IIf(IsNothing(oLeasing.Personas.PER_NOMBRES), "", oLeasing.Personas.PER_NOMBRES)

            End If

            If (oLeasing.CCO_ID <> "") Then
                txtcentroCosto.Tag = oLeasing.CCO_ID
                txtcentroCosto.Text = oLeasing.CentroCostos.CCO_DESCRIPCION
            End If

            dateFecha.Value = CDate(oLeasing.lea_fecha)


            For Each mItem In oLeasing.DetalleLeasing

                Dim nRow As New DataGridViewRow
                dgvCuotas.Rows.Add(nRow)

                dgvCuotas.Rows(dgvCuotas.Rows.Count - 1).Cells(0).Value = mItem.dele_item
                dgvCuotas.Rows(dgvCuotas.Rows.Count - 1).Cells(0).Tag = mItem
                dgvCuotas.Rows(dgvCuotas.Rows.Count - 1).Cells(1).Value = mItem.dele_vencimiento
                dgvCuotas.Rows(dgvCuotas.Rows.Count - 1).Cells(2).Value = mItem.dele_capital
                dgvCuotas.Rows(dgvCuotas.Rows.Count - 1).Cells(3).Value = mItem.dele_interes
                dgvCuotas.Rows(dgvCuotas.Rows.Count - 1).Cells(4).Value = mItem.dele_otrosGastos
                dgvCuotas.Rows(dgvCuotas.Rows.Count - 1).Cells(5).Value = mItem.dele_igv
            Next

            For Each mItem In oLeasing.DetalleLeasingActivosFijos

                Dim nRow As New DataGridViewRow
                dgvActivos.Rows.Add(nRow)

                dgvActivos.Rows(dgvActivos.Rows.Count - 1).Cells(0).Value = mItem.lea_Item
                dgvActivos.Rows(dgvActivos.Rows.Count - 1).Cells(0).Tag = mItem
                dgvActivos.Rows(dgvActivos.Rows.Count - 1).Cells(1).Value = mItem.ACF_COR_INCIDENCIA
                dgvActivos.Rows(dgvActivos.Rows.Count - 1).Cells(2).Tag = mItem.ACF_ID
                dgvActivos.Rows(dgvActivos.Rows.Count - 1).Cells(2).Value = mItem.ActivosFijos.ACF_DESCRIPCION
                dgvActivos.Rows(dgvActivos.Rows.Count - 1).Cells(3).Value = mItem.dele_valor

            Next



            sumar()
        End Sub
        Public Overrides Sub OnManAgregarFilaGrid()

            ' buscar Activos a financiar
            ' esta  incompleto
            If (TabControl1.SelectedIndex = 0) Then
                Exit Sub
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarDocumentosCompra)()
                frm.inicio(Constants.BuscadoresNames.DetalleComprobantesLista)

                frm.txtPersona.Tag = txtPersona.Tag
                frm.txtPersona.Text = txtPersona.Text
                frm.campo1 = sTipoDocumento
                frm.campo2 = sDetalleTipoDocumento
                Dim x As Integer = 0
                frm.txtPersona.ReadOnly = True
                If (frm.ShowDialog = DialogResult.OK) Then

                    While (frm.dgvDetalle.Rows.Count > x)
                        With frm.dgvDetalle.SelectedRows(x)
                            dgvCuotas.Rows.Add(Nothing, .Cells(2).Value, .Cells(3).Value, .Cells(1).Value, .Cells(4).Value, .Cells(5).Value, .Cells(7).Value, .Cells(8).Value, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value)

                        End With
                        x += 1
                    End While

                End If
                frm.Dispose()
                ErrorProvider1.SetError(txtPersona, "")
                sumar()

            End If

            ' numero de cuotas
            If (TabControl1.SelectedIndex = 1) Then

                dgvCuotas.Rows.Add()

            End If


        End Sub
        Public Overrides Sub OnManQuitarFilaGrid()
            ' activo 
            If (TabControl1.SelectedIndex = 0) Then
                If (dgvActivos.SelectedRows.Count > 0) Then

                    For Each mDetalle As DataGridViewRow In dgvActivos.SelectedRows
                        If Not mDetalle.Cells(0).Value Is Nothing Then
                            With CType(mDetalle.Cells(0).Tag, BE.DetalleLeasingActivosFijos)
                                .MarkAsDeleted()
                            End With

                        End If
                        dgvActivos.Rows.Remove(mDetalle)
                        sumar()
                    Next

                Else
                    MsgBox("Seleccione un Activo")
                End If
            End If
            ' cuotas 
            If (TabControl1.SelectedIndex = 1) Then
                If (dgvCuotas.SelectedRows.Count > 0) Then

                    For Each mDetalle As DataGridViewRow In dgvCuotas.SelectedRows
                        If Not mDetalle.Cells(0).Value Is Nothing Then
                            With CType(mDetalle.Cells(0).Tag, BE.DetalleLeasing)
                                .MarkAsDeleted()
                            End With

                        End If
                        dgvCuotas.Rows.Remove(mDetalle)
                        sumar()
                    Next

                Else
                    MsgBox("Seleccione un registro")
                End If
            End If

        End Sub
        Public Overrides Sub OnReportes()
            ' imprimir()
        End Sub
        Public Overrides Sub OnManBuscar()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarDocumentosCompra)()
            frm.inicio(Constants.BuscadoresNames.Leasing)
            frm.btnDocumento.Visible = False
            frm.campo1 = sTipoDocumento
            frm.campo2 = sDetalleTipoDocumento
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgvDetalle.CurrentRow.Cells(0).Value, frm.dgvDetalle.CurrentRow.Cells(1).Value, frm.dgvDetalle.CurrentRow.Cells(2).Value, frm.dgvDetalle.CurrentRow.Cells(4).Value, frm.dgvDetalle.CurrentRow.Cells(5).Value)
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



        Public Overrides Sub OnManGuardar()
            sumar()
            If (validar() AndAlso validarCeldas()) Then
                Try



                    If oLeasing IsNot Nothing Then

                        dgvActivos.EndEdit()
                        dgvCuotas.EndEdit()

                        oLeasing.cct_Id = Nothing ' esta en BCLeasing
                        oLeasing.tdo_Id = Nothing ' esta en BCLeasing
                        oLeasing.dtd_Id = Nothing ' esta en BCLeasing
                        oLeasing.CentroCostos = Nothing
                        oLeasing.Moneda = Nothing
                        oLeasing.Personas = Nothing
                        oLeasing.RolOpeCtaCte = Nothing

                        oLeasing.lea_Serie = txtSerie.Text
                        oLeasing.lea_Numero = txtNumero.Text
                        oLeasing.lea_fecha = CDate(dateFecha.Text)
                        oLeasing.lea_Observaciones = txtObservaciones.Text
                        oLeasing.lea_NumeroContrato = txtNumeroContrato.Text
                        oLeasing.CCO_ID = IIf(txtcentroCosto.Tag = "", Nothing, txtcentroCosto.Tag)
                        oLeasing.per_Id = txtPersona.Tag
                        oLeasing.mon_Id = txtMoneda.Tag

                        oLeasing.Usu_Id = SessionService.UserId
                        oLeasing.lea_fechaSistema = Today

                        'activo fijo detalle
                        For Each mDetalle As DataGridViewRow In dgvActivos.Rows
                            If Not mDetalle.Cells(0).Value Is Nothing Then
                                With CType(mDetalle.Cells(0).Tag, BE.DetalleLeasingActivosFijos)

                                    .lea_Serie = txtSerie.Text
                                    .lea_Numero = txtNumero.Text
                                    .lea_Item = mDetalle.Cells(0).Value()
                                    .ACF_ID = mDetalle.Cells(2).Value()
                                    .ACF_COR_INCIDENCIA = mDetalle.Cells(1).Value()
                                    .dele_valor = mDetalle.Cells(3).Value()
                                    .MarkAsModified()

                                End With
                            Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                                Dim nOSD As New DetalleLeasingActivosFijos
                                With nOSD

                                    .lea_Serie = txtSerie.Text
                                    .lea_Numero = txtNumero.Text
                                    .lea_Item = mDetalle.Cells(0).Value()
                                    .ACF_ID = mDetalle.Cells(2).Value()
                                    .ACF_COR_INCIDENCIA = mDetalle.Cells(1).Value()
                                    .dele_valor = mDetalle.Cells(3).Value()

                                    .MarkAsAdded()

                                End With
                                oLeasing.DetalleLeasingActivosFijos.Add(nOSD)
                            End If
                        Next

                        'cuotas detalle
                        For Each mDetalle As DataGridViewRow In dgvCuotas.Rows
                            If Not mDetalle.Cells(0).Value Is Nothing Then
                                With CType(mDetalle.Cells(0).Tag, BE.DetalleLeasing)

                                    .lea_Serie = txtSerie.Text
                                    .lea_Numero = txtNumero.Text
                                 
                                    .dele_item = mDetalle.Cells(0).Value()
                                    .dele_vencimiento = mDetalle.Cells(1).Value()
                                    .dele_capital = mDetalle.Cells(2).Value()
                                    .dele_interes = mDetalle.Cells(3).Value()
                                    .dele_otrosGastos = mDetalle.Cells(4).Value()
                                    .dele_igv = mDetalle.Cells(5).Value()

                                    .MarkAsModified()

                                End With
                            Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                                Dim nOSD As New DetalleLeasing
                                With nOSD

                                    .lea_Serie = txtSerie.Text
                                    .lea_Numero = txtNumero.Text

                                    .dele_item = mDetalle.Cells(0).Value()
                                    .dele_vencimiento = mDetalle.Cells(1).Value()
                                    .dele_capital = mDetalle.Cells(2).Value()
                                    .dele_interes = mDetalle.Cells(3).Value()
                                    .dele_otrosGastos = mDetalle.Cells(4).Value()
                                    .dele_igv = mDetalle.Cells(5).Value()

                                    .MarkAsAdded()

                                End With
                                oLeasing.DetalleLeasing.Add(nOSD)
                            End If
                        Next

                        BCLeasing.Maintenance(oLeasing)
                        MsgBox("Datos Guardados")
                        'If (MsgBox("Datos Guardados, Se imprimira", vbYesNo) = MsgBoxResult.Yes) Then
                        '    Try
                        '        txtNumero.Text = oLeasing.lea_Numero

                        '        imprimir()

                        '    Catch ex As Exception
                        '        MsgBox("No se Pudo Imprimir")
                        '    End Try

                        'End If
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()
                        DeshabilitarElementoGrid()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If

        End Sub
        Private Sub imprimir()
            Dim oTable As New DataTable

            Try


                'oTable = Me.BCConsultasReportesContabilidad.RPTReportComprobantes(CDate(dateFecha.Value), CDate(dateFecha.Value), sTipoDocumento, sDetalleTipoDocumento, txtSerie.Text, txtNumero.Text)

                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()


                'oRptComprobantesFormato.Database.Tables(0).SetDataSource(oTable)
                'oRptComprobantesFormato.DataDefinition.FormulaFields("SubTitulo").Text = "'" & lblTitle.Text & "'"

                'frm.Reporte(oRptComprobantesFormato)




                frm.ShowDialog()
            Catch ex As Exception
                MsgBox("No se puede mostrar la informacion :" & ex.Message)
            End Try

        End Sub

        Public Overrides Sub OnManEditar()
            menuEditar()
            Panel1.Enabled = True
            HabilitarElementoGrid()
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
            menuInicio()
            Panel1.Enabled = False
        End Sub

        Sub sumar()
            Dim x As Integer = 0
            Dim dActivo, dCapital, dInteres, dOtros, digv As Double
            dActivo = 0
            dCapital = 0
            dInteres = 0
            dOtros = 0
            digv = 0

            Try
                While (dgvActivos.Rows.Count > x)
                    dActivo += Val(dgvActivos.Rows(x).Cells(3).Value)
                    x += 1
                End While
                x = 0
                While (dgvCuotas.Rows.Count > x)
                    dCapital += Val(dgvCuotas.Rows(x).Cells(2).Value)
                    dInteres += Val(dgvCuotas.Rows(x).Cells(3).Value)
                    dOtros += Val(dgvCuotas.Rows(x).Cells(4).Value)
                    digv += Val(dgvCuotas.Rows(x).Cells(5).Value)

                    x += 1
                End While

            Catch ex As Exception


            End Try

            txtSumaActivo.Text = dActivo.ToString
            txtSumaCapital.Text = dCapital.ToString
            txtSumaInteres.Text = dInteres.ToString
            txtSUmaOtrosGastos.Text = dOtros.ToString
            txtSumaIGV.Text = digv.ToString


        End Sub

        Private Sub limpiar()

            txtMoneda.Text = ""
            txtMoneda.Tag = ""
            txtNumero.Text = ""
            txtObservaciones.Text = ""
            txtPersona.Text = ""
            txtPersona.Tag = ""
            txtSerie.Text = ""
            txtcentroCosto.Text = ""
            txtcentroCosto.Tag = ""
            txtNumeroContrato.Text = ""
            txtSumaActivo.Text = "0.00"
            txtSumaCapital.Text = "0.00"
            txtSumaIGV.Text = "0.00"
            txtSumaInteres.Text = "0.00"
            txtSUmaOtrosGastos.Text = "0.00"
           
            dgvActivos.Rows.Clear()
            dgvCuotas.Rows.Clear()
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

        Private Sub btnPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPersona.Click
            buscarPersona()
        End Sub


        Public Overrides Sub OnManEliminar()


            Try
                If oLeasing IsNot Nothing Then

                    If (MsgBox("Esta Seguro de Eliminar ", vbYesNo) = vbYes) Then
                        oLeasing.MarkAsDeleted()

                        'Detalle de co.
                        oLeasing.tdo_Id = sTipoDocumento
                        oLeasing.dtd_Id = sDetalleTipoDocumento

                        oLeasing.lea_Serie = txtSerie.Text
                        oLeasing.lea_Numero = txtNumero.Text

                        BCLeasing.MAintenanceDelete(oLeasing)
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
            oLeasing = New BE.Leasing
            oLeasing.MarkAsAdded()
            HabilitarElementoGrid()
            Panel1.Enabled = True

        End Sub

        Private Sub btnCentroCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCentroCosto.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CentroCosto)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtcentroCosto.Tag = .Cells(0).Value
                    txtcentroCosto.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub dgvCuotas_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCuotas.CellValidated
            sumar()
        End Sub

        Private Sub dgvActivos_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvActivos.CellValidated
            sumar()
        End Sub
    End Class
End Namespace