
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmComedorPLL

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property BCComedor As BL.IBCComedor

        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil

        Protected oComedorPLL As New BE.ComedorPLL

        Private Function validar() As Boolean

            Dim result As Boolean = True

            If (txtResponsable.Text.Trim = "") Then
                ErrorProvider1.SetError(txtResponsable, "Responsable")
                result = False
            Else
                ErrorProvider1.SetError(txtResponsable, Nothing)
            End If

            If (txtComedor.Text.Trim = "") Then
                ErrorProvider1.SetError(txtComedor, "Comedor")
                result = False
            Else
                ErrorProvider1.SetError(txtComedor, Nothing)
            End If

            If (txtObservaciones.Text.Trim = "") Then
                ErrorProvider1.SetError(txtObservaciones, "Observaciones")
                result = False
            Else
                ErrorProvider1.SetError(txtObservaciones, Nothing)
            End If

            If (Not validarCeldas()) Then
                result = False
            End If

            If (txtConcepto.Tag = "") Then
                ErrorProvider1.SetError(txtConcepto, " Concepto")
                result = False
            Else
                ErrorProvider1.SetError(txtConcepto, "")
            End If

            Return result
        End Function
        Private Sub limpiar()

            txtComedor.Text = ""
            txtComedor.Tag = ""
            txtResponsable.Text = ""
            txtResponsable.Tag = ""
            txtObservaciones.Text = ""

            txtNumero.Text = ""

            dgvDetalle.Rows.Clear()

        End Sub

        Sub Sumar()
            Dim x As Integer = 0
            Dim dTotal As Double = 0.0

            While (dgvDetalle.Rows.Count > x)
                Try
                    dTotal += dgvDetalle.Rows(x).Cells("Importe").Value
                Catch ex As Exception

                End Try
                x += 1
            End While
            txtTotal.Text = dTotal.ToString
            txtTotalRegistro.Text = x.ToString


        End Sub
        Sub cargar(ByVal numero As String)
            limpiar()
            oComedorPLL = BCComedor.ComedorSeek(numero)
            oComedorPLL.MarkAsModified()

            txtNumero.Text = oComedorPLL.com_Numero
            dateFecha.Value = CDate(oComedorPLL.com_Fecha)

            txtResponsable.Tag = oComedorPLL.per_idResponsable

            txtResponsable.Text = IIf(IsNothing(oComedorPLL.Personas.PER_APE_PAT), "", oComedorPLL.Personas.PER_APE_PAT) & " " & _
                IIf(IsNothing(oComedorPLL.Personas.PER_APE_MAT), "", oComedorPLL.Personas.PER_APE_MAT) & " " & _
                IIf(IsNothing(oComedorPLL.Personas.PER_NOMBRES), "", oComedorPLL.Personas.PER_NOMBRES)


            txtComedor.Tag = oComedorPLL.per_IdComedor

            txtComedor.Text = IIf(IsNothing(oComedorPLL.Personas1.PER_APE_PAT), "", oComedorPLL.Personas1.PER_APE_PAT) & " " & _
                IIf(IsNothing(oComedorPLL.Personas1.PER_APE_MAT), "", oComedorPLL.Personas1.PER_APE_MAT) & " " & _
                IIf(IsNothing(oComedorPLL.Personas1.PER_NOMBRES), "", oComedorPLL.Personas1.PER_NOMBRES)

            txtObservaciones.Text = oComedorPLL.com_Observaciones
         
            txtTipoConcepto.Tag = oComedorPLL.tic_TipoConcep_Id
            txtTipoConcepto.Text = oComedorPLL.Conceptos.TiposConceptos.tic_Descripcion
            txtConcepto.Tag = oComedorPLL.con_Conceptos_Id
            txtConcepto.Text = oComedorPLL.Conceptos.con_Descripcion
            Dim oTable As New DataTable

            oTable = BCComedor.spDetalleComedorMaintenanceSelect(numero)
            Dim x As Integer = 0
            'For Each mItem In oGrupoTrabajo.DetalleGrupoTrabajo
            While x < oTable.Rows.Count

                With oTable.Rows(x)
                    Dim nRow As New DataGridViewRow
                    dgvDetalle.Rows.Add(nRow)

                    Dim oNewDetalleComedorPLL As New BE.DetalleComedorPLL
                    oNewDetalleComedorPLL.com_Numero = .Item("com_Numero")
                    oNewDetalleComedorPLL.deco_Item = .Item("deco_Item")
                    oNewDetalleComedorPLL.per_id = .Item("per_id")
                    oNewDetalleComedorPLL.deco_Importe = .Item("deco_Importe")
                    oNewDetalleComedorPLL.deco_Observaciones = IIf(IsDBNull(.Item("deco_Observaciones")), "", .Item("deco_Observaciones"))

                    oNewDetalleComedorPLL.TDO_ID = IIf(IsDBNull(.Item("tdo_id")), "", .Item("tdo_id"))
                    oNewDetalleComedorPLL.DTD_ID = IIf(IsDBNull(.Item("dtd_id")), "", .Item("dtd_id"))
                    oNewDetalleComedorPLL.CCC_ID = IIf(IsDBNull(.Item("ccc_id")), "", .Item("ccc_id"))
                    oNewDetalleComedorPLL.DPR_SERIE = IIf(IsDBNull(.Item("dpr_serie")), "", .Item("dpr_serie"))
                    oNewDetalleComedorPLL.DPR_NUMERO = IIf(IsDBNull(.Item("dpr_numero")), "", .Item("dpr_numero"))
                    oNewDetalleComedorPLL.DPR_ITEM = IIf(IsDBNull(.Item("dpr_item")), Nothing, .Item("dpr_item"))
                    oNewDetalleComedorPLL.PER_ID_CLI = IIf(IsDBNull(.Item("per_id_cli")), "", .Item("per_id_cli"))

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = .Item("Codigo")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_Id").Value = oNewDetalleComedorPLL.per_id
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_Id").Tag = oNewDetalleComedorPLL.per_id
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Persona").Value = .Item("Nombre")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Value = oNewDetalleComedorPLL.com_Numero
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Value = .Item("deco_Item")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Importe").Value = .Item("deco_Importe")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Observaciones").Value = .Item("deco_Observaciones")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Importe").Value = .Item("deco_Importe")

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tdo_id").Value = .Item("tdo_id")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtd_id").Value = .Item("dtd_id")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ccc_id").Value = .Item("ccc_id")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dpr_serie").Value = .Item("dpr_serie")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dpr_numero").Value = .Item("dpr_numero")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dpr_item").Value = .Item("dpr_item")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_id_cli").Value = .Item("per_id_cli")

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Tag = oNewDetalleComedorPLL

                    oComedorPLL.DetalleComedorPLL.Add(oNewDetalleComedorPLL)

                End With
                x += 1
            End While

            'For Each mItem In oComedorPLL.DetalleComedorPLL

            '    Dim nRow As New DataGridViewRow
            '    dgvDetalle.Rows.Add(nRow)
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Tag = mItem
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Value = mItem.deco_Item
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Value = mItem.com_Numero
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_id").Tag = mItem.per_id
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = ""

            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Persona").Value = IIf(IsNothing(mItem.Personas.PER_APE_PAT), "", mItem.Personas.PER_APE_PAT) & " " & _
            '    IIf(IsNothing(mItem.Personas.PER_APE_MAT), "", mItem.Personas.PER_APE_MAT) & " " & _
            '    IIf(IsNothing(mItem.Personas.PER_NOMBRES), "", mItem.Personas.PER_NOMBRES)

            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Importe").Value = mItem.deco_Importe
            '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Observaciones").Value = mItem.deco_Observaciones

            'Next
            Sumar()
        End Sub
        Public Overrides Sub OnManAgregarFilaGrid()

            Dim iRow As Integer = 0
            dgvDetalle.Rows.Add()
            Sumar()
        End Sub
        Public Overrides Sub OnManQuitarFilaGrid()
            If (dgvDetalle.SelectedRows.Count > 0) Then

                For Each mDetalle As DataGridViewRow In dgvDetalle.SelectedRows
                    If Not mDetalle.Cells("Numero").Value Is Nothing Then
                        With CType(mDetalle.Cells("Numero").Tag, BE.DetalleComedorPLL)
                            .MarkAsDeleted()
                        End With
                    End If
                    dgvDetalle.Rows.Remove(mDetalle)
                Next
                Sumar()

            Else
                MsgBox("Seleccione un registro")
            End If

        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarFecha)()
            frm.inicio(Constants.BuscadoresNames.Comedor)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(1).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False
        End Sub

        Public Overrides Sub OnManGuardar()
            If (validar()) Then
                Try
                    If oComedorPLL IsNot Nothing Then

                        dgvDetalle.EndEdit()

                        oComedorPLL.com_Fecha = CDate(dateFecha.Text)

                        oComedorPLL.com_Numero = txtNumero.Text

                        oComedorPLL.Usu_Id = SessionServer.UserId
                        oComedorPLL.com_FecGrab = CDate(Today)

                        oComedorPLL.com_Observaciones = txtObservaciones.Text

                        oComedorPLL.per_IdComedor = txtComedor.Tag
                        oComedorPLL.per_idResponsable = txtResponsable.Tag
                        oComedorPLL.Conceptos = Nothing
                        oComedorPLL.tic_TipoConcep_Id = txtTipoConcepto.Tag
                        oComedorPLL.con_Conceptos_Id = txtConcepto.Tag


                        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                            If Not mDetalle.Cells("Numero").Value Is Nothing Then
                                With CType(mDetalle.Cells("Numero").Tag, BE.DetalleComedorPLL)
                                    .deco_Item = mDetalle.Cells("Item").Value
                                    .per_id = mDetalle.Cells("per_id").Tag
                                    .deco_Importe = mDetalle.Cells("Importe").Value
                                    .deco_Observaciones = IIf(IsDBNull(mDetalle.Cells("Observaciones").Value), Nothing, mDetalle.Cells("Observaciones").Value)
                                    .Usu_Id = SessionServer.UserId
                                    .deco_FecGrab = CDate(Today)
                                    .TDO_ID = IIf(IsDBNull(mDetalle.Cells("tdo_id").Value), Nothing, mDetalle.Cells("tdo_id").Value)
                                    .DTD_ID = IIf(IsDBNull(mDetalle.Cells("dtd_id").Value), Nothing, mDetalle.Cells("dtd_id").Value)
                                    .CCC_ID = IIf(IsDBNull(mDetalle.Cells("ccc_id").Value), Nothing, mDetalle.Cells("ccc_id").Value)
                                    .DPR_SERIE = IIf(IsDBNull(mDetalle.Cells("dpr_serie").Value), Nothing, mDetalle.Cells("dpr_serie").Value)
                                    .DPR_NUMERO = IIf(IsDBNull(mDetalle.Cells("dpr_numero").Value), Nothing, mDetalle.Cells("dpr_numero").Value)
                                    .DPR_ITEM = IIf(IsDBNull(mDetalle.Cells("dpr_item").Value), Nothing, mDetalle.Cells("dpr_item").Value)
                                    .PER_ID_CLI = IIf(IsDBNull(mDetalle.Cells("per_id_cli").Value), Nothing, mDetalle.Cells("per_id_cli").Value)

                                    .MarkAsModified()

                                End With
                            Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                                Dim nOSD As New DetalleComedorPLL
                                With nOSD

                                    .per_id = mDetalle.Cells("per_id").Tag
                                    .deco_Item = mDetalle.Cells("Item").Value
                                    .deco_Importe = mDetalle.Cells("Importe").Value
                                    .deco_Observaciones = IIf(IsDBNull(mDetalle.Cells("Observaciones").Value), Nothing, mDetalle.Cells("Observaciones").Value)
                                    .Usu_Id = SessionServer.UserId
                                    .deco_FecGrab = CDate(Today)
                                    .TDO_ID = IIf(IsDBNull(mDetalle.Cells("tdo_id").Value), Nothing, mDetalle.Cells("tdo_id").Value)
                                    .DTD_ID = IIf(IsDBNull(mDetalle.Cells("dtd_id").Value), Nothing, mDetalle.Cells("dtd_id").Value)
                                    .CCC_ID = IIf(IsDBNull(mDetalle.Cells("ccc_id").Value), Nothing, mDetalle.Cells("ccc_id").Value)
                                    .DPR_SERIE = IIf(IsDBNull(mDetalle.Cells("dpr_serie").Value), Nothing, mDetalle.Cells("dpr_serie").Value)
                                    .DPR_NUMERO = IIf(IsDBNull(mDetalle.Cells("dpr_numero").Value), Nothing, mDetalle.Cells("dpr_numero").Value)
                                    .DPR_ITEM = IIf(IsDBNull(mDetalle.Cells("dpr_item").Value), Nothing, mDetalle.Cells("dpr_item").Value)
                                    .PER_ID_CLI = IIf(IsDBNull(mDetalle.Cells("per_id_cli").Value), Nothing, mDetalle.Cells("per_id_cli").Value)

                                    .MarkAsAdded()

                                End With
                                oComedorPLL.DetalleComedorPLL.Add(nOSD)
                            End If
                        Next

                        BCComedor.Maintenance(oComedorPLL)
                        MsgBox("Datos Guardados")
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()
                        DeshabilitarElementoGrid()
                    End If
                Catch ex As Exception

                    MsgBox(ex.Message)

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
            oComedorPLL = New BE.ComedorPLL
            oComedorPLL.MarkAsAdded()
            HabilitarElementoGrid()
            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            Try
                If (MsgBox("Esta Seguro de Eliminar ", vbYesNo) = vbYes) Then
                    If oComedorPLL IsNot Nothing Then
                        oComedorPLL.MarkAsDeleted()

                        'Detalle de co.
                        oComedorPLL.com_Numero = txtNumero.Text

                        BCComedor.MaintenanceDelete(oComedorPLL)
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

        Private Sub frmComedorPLL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub


        Function validarCeldas() As Boolean
            Dim result As Boolean = True
            Dim iRow As Integer = 0

            Try
                While (dgvDetalle.Rows.Count > iRow)
                    With dgvDetalle.Rows(iRow)

                        If (Not (IsNumeric(dgvDetalle.Rows(iRow).Cells("Importe").Value)) OrElse Val(dgvDetalle.Rows(iRow).Cells("Importe").Value) <= 0) Then
                            result = False
                            ErrorProvider1.SetError(txtObservaciones, "Importe en el detalle")
                            Return result
                        Else
                            ErrorProvider1.SetError(txtObservaciones, Nothing)
                        End If

                        If (dgvDetalle.Rows(iRow).Cells(2).Tag = "") Then
                            result = False
                            ErrorProvider1.SetError(txtObservaciones, "Verifique las Personas Ingresadas")
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

      

        Private Sub btnResponsable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResponsable.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.DatosLaborales)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtResponsable.Tag = .Cells(0).Value()
                    txtResponsable.Text = .Cells(2).Value
                    ' menuBuscar()
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnComedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComedor.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.BuscarPersona)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtComedor.Tag = .Cells(0).Value()
                    txtComedor.Text = .Cells(1).Value
                    ' menuBuscar()
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
            Select Case dgvDetalle.Columns(e.ColumnIndex).Name

                Case "per_id"

                    Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                    frm.inicio(Constants.BuscadoresNames.DatosLaborales)
                    If (frm.ShowDialog = DialogResult.OK) Then
                        With frm.dgbRegistro.CurrentRow
                            dgvDetalle.Rows(e.RowIndex).Cells("Codigo").Tag = .Cells(0).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("Codigo").Value = .Cells(1).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("Persona").Value = .Cells(2).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("per_id").Tag = .Cells(0).Value
                        End With
                    End If
            End Select
        End Sub

        Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
            Dim sRuta As String = ""
            Dim sNombreHoja As String = "ventas_resumen"
            OpenFileDialog1.ShowDialog()
            Dim oTable As New DataTable
            Dim x As Integer = 0

            If (OpenFileDialog1.FileName <> "") Then
                sNombreHoja = InputBox("Nombre de la Hoja de Excel", "Importar Conceptos", "Hoja4")

                If (sNombreHoja.Trim <> "") Then
                    Try
                        sRuta = OpenFileDialog1.FileName
                        oTable = BCUtil.excelImportacionConFormato(sRuta, "Select  Codigo,Importe,Observacion from [" & sNombreHoja & "$]")

                        While (oTable.Rows.Count > x)
                            With oTable.Rows(x)
                                dgvDetalle.Rows.Add(Nothing, "", "", .Item(0).ToString, "", IIf(IsDBNull(.Item(1)), 0, .Item(1)), IIf(IsDBNull(.Item(2)), "", .Item(2)))
                                CarcarPersona(dgvDetalle.Rows.Count - 1)
                            End With
                            x += 1
                        End While

                    Catch ex As Exception
                        MsgBox("Error de importacion :" & ex.Message)
                    End Try

                Else
                    MsgBox("Si no Ingresa no se puede importar")
                End If

            End If

            OpenFileDialog1.Dispose()


        End Sub

        Private Sub btnPlantillaExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantillaExcel.Click
            Dim oTabble As New DataTable("Comedor")
            oTabble.Columns.Add("Codigo")
            oTabble.Columns.Add("Importe")
            oTabble.Columns.Add("Observacion")

            BCUtil.excelExportar(oTabble)
        End Sub
        Sub CarcarPersona(ByVal iFila As Integer)

            If (dgvDetalle.Rows(iFila).Cells(3).Value <> "") Then
                Try

                    Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                    frm.inicio(Constants.BuscadoresNames.DatosLaborales)
                    frm.llenarCombo()

                    frm.cboBuscar.SelectedIndex = 1
                    frm.txtBuscar.Text = dgvDetalle.Rows(iFila).Cells(3).Value
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
            End If
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
                                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("per_id").Tag = .Cells(0).Value
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

        Private Sub btnConceptoBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConceptoBuscar.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Conceptos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtConcepto.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtTipoConcepto.Text = frm.dgbRegistro.CurrentRow.Cells(2).Value
                txtTipoConcepto.Tag = frm.dgbRegistro.CurrentRow.Cells(1).Value
                txtConcepto.Text = frm.dgbRegistro.CurrentRow.Cells(3).Value

            End If

            frm.Dispose()
        End Sub


        Private Sub txtCodigoBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoBusca.TextChanged

            Dim x As Integer = 0
            x = 0
            If (txtCodigoBusca.Text.Length >= 4) Then
                While (dgvDetalle.Rows.Count > x)
                    Try

                        If (dgvDetalle.Rows(x).Cells("Codigo").Value = txtCodigoBusca.Text) Then
                            dgvDetalle.CurrentCell = dgvDetalle.Rows(x).Cells("Codigo")
                            Exit Sub
                        End If

                    Catch ex As Exception

                    End Try
                    x += 1
                End While

            End If
        End Sub

        Private Sub dgvDetalle_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.RowEnter
            Try
                Sumar()
            Catch ex As Exception

            End Try

        End Sub

        Private Sub btnDescuentoComedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescuentoComedor.Click
            BCComedor.ImportarDescuentoComedor()
        End Sub

        Private Sub btnImprimirComedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirComedor.Click
            Dim oTable As New DataTable
            Dim oreporte As New rptListaDetalleComedorDescuento
            Try
                oTable = Me.BCComedor.spListaDetalleComedorDescuento(dateFecha.Value, dateFecha.Value)
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmVisorReportes)()

                oreporte.Database.Tables(0).SetDataSource(oTable)

                'oreporte.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & " ' "

                frm.Reporte(oreporte)
                frm.ShowDialog()

            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnImportarBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportarBase.Click
            If dgvDetalle.RowCount > 0 Then
                MsgBox("La grilla de datos no debe tener registros. " & Me.Text)
                Exit Sub
            End If
            Dim oTable As New DataTable
            Dim x As Integer = 0
            dgvDetalle.Rows.Clear()
            Try
                oTable = BCComedor.spDetallePrestamoSelect(dateFecha.Value)
                While (oTable.Rows.Count > x)
                    With oTable.Rows(x)
                        dgvDetalle.Rows.Add(Nothing, "", "", .Item(0).ToString, "", IIf(IsDBNull(.Item(1)), 0, .Item(1)), IIf(IsDBNull(.Item(2)), "", .Item(2)), IIf(IsDBNull(.Item(3)), "", .Item(3)), IIf(IsDBNull(.Item(4)), "", .Item(4)), IIf(IsDBNull(.Item(5)), "", .Item(5)), IIf(IsDBNull(.Item(6)), "", .Item(6)), IIf(IsDBNull(.Item(7)), "", .Item(7)), IIf(IsDBNull(.Item(8)), "", .Item(8)), IIf(IsDBNull(.Item(9)), "", .Item(9)))
                        CarcarPersona(dgvDetalle.Rows.Count - 1)
                    End With
                    x += 1
                End While
            Catch ex As Exception
                MsgBox("Error de importacion :" & ex.Message)
            End Try
        End Sub
    End Class
End Namespace
