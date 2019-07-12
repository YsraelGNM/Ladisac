Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmCuadroComparativo
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCMoneda As Ladisac.BL.IBCMoneda
    <Dependency()> _
    Public Property BCDocuMovimiento As Ladisac.BL.IBCDocuMovimiento
    <Dependency()> _
    Public Property BCCuadroComparativo As Ladisac.BL.IBCCuadroComparativo
    <Dependency()> _
    Public Property BCProcesoCompra As Ladisac.BL.IBCProcesoCompra

    Dim mUscPro As uscCCProveedor
    Dim mCC As CuadroComparativo
    Dim mPRC As ProcesoCompra

    Private Sub frmCuadroComparativo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarMoneda()
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
    End Sub

    Sub LimpiarControles()
        mCC = Nothing
        txtCodigo.Text = String.Empty
        txtNombreProyecto.Text = String.Empty
        txtElaborado.Text = String.Empty
        txtElaborado.Tag = Nothing
        dtpFecha.Value = Today
        cboMoneda.SelectedIndex = -1
        numTipoCambio.Value = 0
        dgvArticulos.Rows.Clear()
        flpProveedor.Controls.Clear()
        txtObservacion.Text = String.Empty
    End Sub

    'valida controles desactivacion
    Sub validacion_desactivacion(ByVal op As Boolean, ByVal flag As Integer)
        'datos a tener en cuenta
        '1=load
        '2=nuevo
        '3=guardar
        '4=DeshacerCambios
        '5=buscar
        '6=editar
        '7=deshacer,eliminar

        If flag = 1 Or flag = 3 Or flag = 4 Or flag = 7 Then

            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbNuevo.Enabled = Not op
            Me.tsbBuscar.Enabled = Not op
            Me.tsbSalir.Enabled = Not op
            Me.tscPosicion.Enabled = Not op
            Me.tsbReportes.Enabled = Not op


        ElseIf flag = 2 Or flag = 6 Then 'evento nuevo registro
            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = Not op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbGrabar.Enabled = op
            Me.TsbGrabarNuevo.Enabled = op
            Me.tsbDeshacer.Enabled = op
            Me.tsbAgregar.Enabled = op
            Me.tsbQuitar.Enabled = op


        ElseIf flag = 5 Then 'evento buscar/editar
            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbNuevo.Enabled = Not op
            Me.tsbEditar.Enabled = Not op
            Me.tsbCancelarEditar.Enabled = Not op
            Me.tsbReportes.Enabled = Not op

        End If
    End Sub

    Sub CargarMoneda()
        Dim ds As New DataSet
        Dim query = BCMoneda.ListaMoneda
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboMoneda
            .DisplayMember = "MON_Simbolo"
            .ValueMember = "MON_ID"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    Private Sub btnAgregarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarProveedor.Click
        Dim mProveedor As New uscCCProveedor
        AddHandler mProveedor.Enter, AddressOf UscCCProveedor_Enter
        AddHandler mProveedor.tooUscEliminar.Click, AddressOf EliminarUscCCProveedor_Click
        AddHandler mProveedor.btnOC.Click, AddressOf btnOC_Click
        AgregarFilasProveedores(mProveedor)
        flpProveedor.Controls.Add(mProveedor)
        mUscPro = mProveedor
        AutoSizeUsc()
    End Sub

    Private Sub cboMoneda_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMoneda.SelectedValueChanged
        numTipoCambio.Value = BCDocuMovimiento.TCCompraDia(cboMoneda.SelectedValue, dtpFecha.Value)
    End Sub

    Private Sub txtElaborado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtElaborado.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtElaborado.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            txtElaborado.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtElaborado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtElaborado.KeyDown
        If e.KeyCode = Keys.Enter Then txtElaborado_DoubleClick(Nothing, Nothing)
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvArticulos.Rows.Add(nRow)
        'dgvArticulos.Rows(dgvArticulos.Rows.Count - 1).Cells("CPD_APROBADO").Value = False
        For Each mItem As uscCCProveedor In flpProveedor.Controls
            nRow = New DataGridViewRow
            mItem.dgvProveedor.Rows.Add(nRow)
            mItem.dgvProveedor.Rows(mItem.dgvProveedor.Rows.Count - 1).Cells("CAP_APROBADO").Value = False
        Next
    End Sub

    Sub AgregarFilasProveedores(ByVal uscCCP As uscCCProveedor)
        For Fila As Integer = 0 To dgvArticulos.Rows.Count - 1
            Dim nRow As New DataGridViewRow
            uscCCP.dgvProveedor.Rows.Add(nRow)
            uscCCP.dgvProveedor.Rows(uscCCP.dgvProveedor.Rows.Count - 1).Cells("CAP_CANT").Value = dgvArticulos.Rows(Fila).Cells("CAP_CANTIDAD").Value
            uscCCP.dgvProveedor.Rows(uscCCP.dgvProveedor.Rows.Count - 1).Cells("CAP_CANT").Tag = dgvArticulos.Rows(Fila).Cells("CAP_UM").Tag 'PCD object
        Next
    End Sub

    Private Sub UscCCProveedor_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        mUscPro = DirectCast(sender, uscCCProveedor)
        mUscPro.BackColor = Color.LightSteelBlue
        For Each mC As uscCCProveedor In flpProveedor.Controls
            If Not mC Is mUscPro Then
                mC.BackColor = Color.AliceBlue
            End If
        Next
    End Sub

    Private Sub btnOC_Click()
        Try
            If Not mCC.ChangeTracker.State = ObjectState.Modified Then
                MsgBox("Debe Guardar antes el Cuadro Comparativo")
                Exit Sub
            End If

            Dim flag As Boolean = False
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmOrdenCompra)()
            frm.mProveeText = mUscPro.txtProveedor.Text
            frm.mProveeTag = mUscPro.txtProveedor.Tag
            For Each item As DataGridViewRow In mUscPro.dgvProveedor.Rows
                If item.Cells("CAP_APROBADO").Value = True Then
                    Dim mPCD As New ProcesoCompraDetalle
                    mPCD = BCProcesoCompra.ProcesoCompraDetalleGetById(CType(item.Cells("CAP_PU").Tag, CCArticuloProveedorDetalle).PCD_ID)
                    frm.mPCDE.Add(mPCD)
                    Dim mFila As New Ladisac.Logistica.Views.frmOrdenCompra.CuadroComparativo
                    mFila.ART_ID = CType(item.Cells("CAP_PU").Tag, CCArticuloProveedorDetalle).ART_ID
                    mFila.Cantidad = CType(item.Cells("CAP_PU").Tag, CCArticuloProveedorDetalle).CAP_CANTIDAD
                    mFila.PU = CType(item.Cells("CAP_PU").Tag, CCArticuloProveedorDetalle).CAP_PU
                    frm.mCuCo.Add(mFila)
                    flag = True
                Else
                    item.Cells("OC").Value = False
                End If
            Next

            If flag Then
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                End If
            End If
            frm.Dispose()

        Catch ex As Exception
            MessageBox.Show("Existe un Error, verificar datos " & ex.Message, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub EliminarUscCCProveedor_Click()
        flpProveedor.Controls.Remove(mUscPro)
    End Sub

    Private Sub flpProveedor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles flpProveedor.Enter
        PasarGrid()
    End Sub

    Private Sub flpProveedor_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles flpProveedor.SizeChanged
        AutoSizeUsc()
    End Sub

    Sub AutoSizeUsc()
        For Each mC As uscCCProveedor In flpProveedor.Controls
            mC.Size = New System.Drawing.Size(mC.Size.Width, flpProveedor.Size.Height - 10)
        Next
    End Sub

    Sub PasarGrid()
        For Each mC As uscCCProveedor In flpProveedor.Controls
            mC.mDgvArt = dgvArticulos
        Next
    End Sub

    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mCC = New CuadroComparativo
        mCC.MarkAsAdded()
        Call validacion_desactivacion(True, 2)
        txtNombreProyecto.Focus()
    End Sub

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(txtNombreProyecto.Text.Trim) = 0 Then Error_validacion.SetError(txtNombreProyecto, "Ingrese el Nombre del Proyecto") : txtNombreProyecto.Focus() : flag = False
        If Len(txtElaborado.Text.Trim) = 0 Then Error_validacion.SetError(txtElaborado, "Ingrese el Nombre en Elaborado") : txtElaborado.Focus() : flag = False
        If cboMoneda.SelectedIndex = -1 Then Error_validacion.SetError(cboMoneda, "Elija la Moneda") : cboMoneda.Focus() : flag = False
        If numTipoCambio.Value = 0 Then Error_validacion.SetError(numTipoCambio, "Ingrese el Tipo de Cambio") : numTipoCambio.Focus() : flag = False

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "CuadroComparativo"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As String = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarCuadroComparativo(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarCuadroComparativo(ByVal CUC_ID As Integer)
        mCC = BCCuadroComparativo.CuadroComparativoGetById(CUC_ID)
        mCC.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mCC.CUC_ID
        txtNombreProyecto.Text = mCC.CUC_NOMBRE_PROYECTO
        txtElaborado.Text = mCC.Personas.PER_APE_PAT & mCC.Personas.PER_APE_MAT & mCC.Personas.PER_NOMBRES
        txtElaborado.Tag = mCC.PER_ID_ELABORADO
        dtpFecha.Value = mCC.CUC_FECHA
        cboMoneda.SelectedValue = mCC.MON_ID
        numTipoCambio.Value = mCC.CUC_TCAMBIO
        txtObservacion.Text = mCC.CUC_OBSERVACION

        For Each mCCP In mCC.CCProveedorDetalle
            btnAgregarProveedor_Click(Nothing, Nothing)
            mUscPro.mCCP = mCCP
            mUscPro.uscCCProveedor_Load(Nothing, Nothing)
        Next

        For Each mItem In mUscPro.mCCP.CCArticuloProveedorDetalle
            Dim nRow As New DataGridViewRow
            dgvArticulos.Rows.Add(nRow)
            dgvArticulos.Rows(dgvArticulos.Rows.Count - 1).Cells("ART_ID").Value = mItem.ART_DESCRIPCION
            dgvArticulos.Rows(dgvArticulos.Rows.Count - 1).Cells("ART_ID").Tag = mItem.ART_ID
            dgvArticulos.Rows(dgvArticulos.Rows.Count - 1).Cells("CAP_CANTIDAD").Value = mItem.CAP_CANTIDAD
            dgvArticulos.Rows(dgvArticulos.Rows.Count - 1).Cells("CAP_UM").Value = mItem.CAP_UM
        Next

        PasarGrid()
    End Sub

    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub

        If mCC IsNot Nothing Then
            mCC.CUC_NOMBRE_PROYECTO = txtNombreProyecto.Text
            mCC.PER_ID_ELABORADO = txtElaborado.Tag
            mCC.CUC_FECHA = dtpFecha.Value
            mCC.MON_ID = cboMoneda.SelectedValue
            mCC.CUC_TCAMBIO = numTipoCambio.Value
            mCC.CUC_OBSERVACION = txtObservacion.Text

            For Each mP As uscCCProveedor In flpProveedor.Controls
                If mP.mCCP.CPD_ID = 0 Then
                    For CONT As Integer = 0 To dgvArticulos.Rows.Count - 1
                        Dim mCCA As New CCArticuloProveedorDetalle
                        mCCA.ART_ID = dgvArticulos.Rows(CONT).Cells("ART_ID").Tag
                        mCCA.ART_DESCRIPCION = dgvArticulos.Rows(CONT).Cells("ART_ID").Value
                        mCCA.CAP_UM = dgvArticulos.Rows(CONT).Cells("CAP_UM").Value
                        mCCA.CAP_CANTIDAD = CDbl(mP.dgvProveedor.Rows(CONT).Cells("CAP_CANT").Value)

                        mCCA.CAP_PU = CDbl(mP.dgvProveedor.Rows(CONT).Cells("CAP_PU").Value)
                        mCCA.CAP_APROBADO = IIf(mP.dgvProveedor.Rows(CONT).Cells("CAP_APROBADO").Value Is Nothing, False, mP.dgvProveedor.Rows(CONT).Cells("CAP_APROBADO").Value)

                        If dgvArticulos.Rows(CONT).Cells("CAP_UM").Tag IsNot Nothing Then
                            mCCA.PCD_ID = CType(dgvArticulos.Rows(CONT).Cells("CAP_UM").Tag, ProcesoCompraDetalle).PCD_ID
                        End If

                        mCCA.MarkAsAdded()
                        mP.mCCP.CCArticuloProveedorDetalle.Add(mCCA)
                    Next
                    mCC.CCProveedorDetalle.Add(mP.mCCP)
                Else
                    For CONT As Integer = 0 To dgvArticulos.Rows.Count - 1
                        With CType(mP.dgvProveedor.Rows(CONT).Cells("CAP_PU").Tag, CCArticuloProveedorDetalle)
                            .ART_ID = dgvArticulos.Rows(CONT).Cells("ART_ID").Tag
                            .ART_DESCRIPCION = dgvArticulos.Rows(CONT).Cells("ART_ID").Value
                            .CAP_UM = dgvArticulos.Rows(CONT).Cells("CAP_UM").Value
                            .CAP_CANTIDAD = CDbl(mP.dgvProveedor.Rows(CONT).Cells("CAP_CANT").Value)

                            .CAP_PU = CDbl(mP.dgvProveedor.Rows(CONT).Cells("CAP_PU").Value)
                            .CAP_APROBADO = IIf(mP.dgvProveedor.Rows(CONT).Cells("CAP_APROBADO").Value Is Nothing, False, mP.dgvProveedor.Rows(CONT).Cells("CAP_APROBADO").Value)

                            .MarkAsModified()
                        End With
                    Next
                End If
            Next
            mCC.CUC_ESTADO = True
            mCC.CUC_FECHA_GRAB = Today
            mCC.USU_ID = SessionServer.UserId
            BCCuadroComparativo.MantenimientoCuadroComparativo(mCC)
            MessageBox.Show(mCC.CUC_ID)
            LimpiarControles()
        End If
        Call validacion_desactivacion(False, 3)
    End Sub

    Private Sub dgvArticulos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArticulos.CellEndEdit
        For Each mC As uscCCProveedor In flpProveedor.Controls
            mC.dgvProveedor.Rows(dgvArticulos.CurrentRow.Index).Cells("Total").Value = mC.dgvProveedor.Rows(dgvArticulos.CurrentRow.Index).Cells("CAP_PU").Value * dgvArticulos.CurrentRow.Cells("CAP_CANTIDAD").Value
        Next
    End Sub

    Private Sub dgvArticulos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvArticulos.Enter
        PasarGrid()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            If mCC IsNot Nothing Then
                If mCC.CUC_ID > 0 Then
                    Try
                        Dim ds As New DataSet
                        Dim query = BCCuadroComparativo.ImprimirCuadroComparativo(mCC.CUC_ID)

                        Dim rea As New StringReader(query)
                        ds.ReadXml(rea)

                        Dim rpt As New rptCuadroComp
                        ds.Tables(0).TableName = "CuadroComparativo"

                        rpt.SetDataSource(ds.Tables(0))
                        CrystalReportViewer1.ReportSource = rpt
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                End If
            End If
        End If
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManEliminar()
        MyBase.OnManEliminar()
        If mCC IsNot Nothing Then
            If MessageBox.Show("Seguro de Eliminar el Cuadro Comparativo?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = vbOK Then
                mCC.MarkAsDeleted()
                BCCuadroComparativo.MantenimientoCuadroComparativo(mCC)
                LimpiarControles()
            End If
        End If

        '--------------------------------------------------
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub

    'codigos agregados===================================================
    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)

    End Sub

    Private Sub btnCotizaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCotizaciones.Click
        OnManNuevo()

        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "ProcesoCompra"
        frm.Tipo = SessionServer.UserId
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As String = frm.dgvLista.CurrentRow.Cells("PRC_ID").Value
            CargarProcesoCompra(key)
            LlenarControlesPRC()
        End If
        frm.Dispose()
    End Sub

    Sub CargarProcesoCompra(ByVal PRC_ID As Integer)
        mPRC = BCProcesoCompra.ProcesoCompraGetById(PRC_ID)
        mPRC.MarkAsModified()
    End Sub

    Sub LlenarControlesPRC()
        'txtCodigo.Text = mCC.CUC_ID
        'txtNombreProyecto.Text = mCC.CUC_NOMBRE_PROYECTO
        'txtElaborado.Text = mCC.Personas.PER_APE_PAT & mCC.Personas.PER_APE_MAT & mCC.Personas.PER_NOMBRES
        'txtElaborado.Tag = mCC.PER_ID_ELABORADO
        'dtpFecha.Value = mCC.CUC_FECHA
        'cboMoneda.SelectedValue = mCC.MON_ID
        'numTipoCambio.Value = mCC.CUC_TCAMBIO
        'txtObservacion.Text = mCC.CUC_OBSERVACION
      

        Dim mArti = From mItem In mPRC.ProcesoCompraDetalle Select mItem

        For Each mItem In mArti.ToList
            Dim nRow As New DataGridViewRow
            dgvArticulos.Rows.Add(nRow)
            dgvArticulos.Rows(dgvArticulos.Rows.Count - 1).Cells("ART_ID").Value = mItem.Articulos.ART_DESCRIPCION
            dgvArticulos.Rows(dgvArticulos.Rows.Count - 1).Cells("ART_ID").Tag = mItem.ART_ID
            dgvArticulos.Rows(dgvArticulos.Rows.Count - 1).Cells("CAP_CANTIDAD").Value = mItem.PCD_CANT
            dgvArticulos.Rows(dgvArticulos.Rows.Count - 1).Cells("CAP_UM").Value = mItem.Articulos.UnidadMedidaArticulos.UM_SIMBOLO
            dgvArticulos.Rows(dgvArticulos.Rows.Count - 1).Cells("CAP_UM").Tag = mItem 'PCD object
        Next

        Dim mProv = From mItem In mPRC.ProcesoCompraDetalle(0).PCDCotizacionDetalle Select mItem.Personas

        For Each mItem In mProv.ToList
            btnAgregarProveedor_Click(Nothing, Nothing)
            mUscPro.txtProveedor.Text = mItem.PER_ALIAS
            mUscPro.txtProveedor.Tag = mItem.PER_ID
        Next
    End Sub
End Class
