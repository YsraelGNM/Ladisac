Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmProveedores
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCPersona As Ladisac.BL.IBCPersona
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCRubro As Ladisac.BL.IBCRubro
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro
    <Dependency()> _
    Public Property BCDocPersona As Ladisac.BL.IBCDocPersonas

    Protected mPer As Personas
    Dim CambioRuc As Boolean = False
    Dim Contacto As New ContactoPersona

    Private Sub frmProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Contacto.CampoId = "COP_TIPO"
        LimpiarControles()

        'se llama al procedimiento de paso rapido entre cajas de texto.
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 15
        txtNombreComercial.TabIndex = 1
        txtRazonSocial.TabIndex = 2
        txtRUC.TabIndex = 3
        txtDireccionFiscal.TabIndex = 4
        txtDireccionDomicilio.TabIndex = 5
        txtCorreo.TabIndex = 6
        txtTelefono.TabIndex = 7
        txtWeb.TabIndex = 8
        txtObservaciones.TabIndex = 9
        dgvContactos.TabIndex = 10
        cboCalificacion.TabIndex = 11
        dgvRubro.TabIndex = 12

        CargarColumnCboTipoContacto()
        Me.ReportViewer1.RefreshReport()
    End Sub

    Sub CargarColumnCboTipoContacto()
       
        Dim mCbo As New DataGridViewComboBoxColumn
        mCbo.Name = "COP_TIPO"
        mCbo.HeaderText = "Cargo"
        For Each mItem In Contacto.DevolverTiposCampos2
            mCbo.Items.Add(mItem)
        Next
        mCbo.Width = 170
        dgvContactos.Columns.Add(mCbo)
        dgvContactos.Columns("COP_TIPO").DisplayIndex = 1
    End Sub

    Sub CargarRubroPersona()
        Dim ds As New DataSet
        Dim query = BCRubro.ListaRubro
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        For Each mItem In ds.Tables(0).Rows
            Dim nRow As New DataGridViewRow
            dgvRubro.Rows.Add(nRow)
            dgvRubro.Rows(dgvRubro.Rows.Count - 1).Cells("RUB_ID").Value = mItem("Codigo")
            dgvRubro.Rows(dgvRubro.Rows.Count - 1).Cells("RUB_DESCRIPCION").Value = mItem("Descripcion")
            ''''
            Dim nRow2 As New DataGridViewRow
            dgvRubro2.Rows.Add(nRow2)
            dgvRubro2.Rows(dgvRubro2.Rows.Count - 1).Cells("RUB_ID2").Value = mItem("Codigo")
            dgvRubro2.Rows(dgvRubro2.Rows.Count - 1).Cells("RUB_DESCRIPCION2").Value = mItem("Descripcion")
        Next
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mPer = Nothing
        txtCodigo.Text = String.Empty
        txtNombreComercial.Text = String.Empty
        txtRazonSocial.Text = String.Empty
        txtRUC.Text = String.Empty
        txtDireccionFiscal.Text = String.Empty
        txtDireccionDomicilio.Text = String.Empty
        txtCorreo.Text = String.Empty
        txtTelefono.Text = String.Empty
        txtWeb.Text = String.Empty
        txtObservaciones.Text = String.Empty
        dgvContactos.Rows.Clear()
        cboCalificacion.SelectedIndex = -1
        dgvRubro.Rows.Clear()
        cboCalificacion2.SelectedIndex = -1
        dgvRubro2.Rows.Clear()
        CargarRubroPersona()
        Error_validacion.Clear()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------
        If mPer IsNot Nothing Then
            dgvContactos.EndEdit()
            mPer.PER_ALIAS = txtNombreComercial.Text
            mPer.PER_APE_PAT = txtRazonSocial.Text
            mPer.PER_PROVEEDOR = True 'Es Proveedor
            mPer.PER_APE_MAT = ""
            mPer.PER_NOMBRES = ""
            If mPer.DocPersonas.Count = 0 Then
                Dim mDP As New DocPersonas
                mDP.TDP_ID = "04" 'Ruc
                mDP.DOP_NUMERO = txtRUC.Text
                mDP.DOP_ESTADO = True
                mDP.DOP_FEC_GRAB = Now
                mDP.USU_ID = SessionServer.UserId
                mDP.MarkAsAdded()
                mPer.DocPersonas.Add(mDP)
            Else
                For Each mDoc In mPer.DocPersonas
                    If mDoc.TDP_ID = "04" Then
                        mDoc.DOP_NUMERO = txtRUC.Text
                        mDoc.DOP_ESTADO = True
                        mDoc.DOP_FEC_GRAB = Now
                        mDoc.USU_ID = SessionServer.UserId
                        mDoc.MarkAsModified()
                    End If
                Next
            End If
            If mPer.DireccionesPersonas.Count = 0 Then
                Dim mDIP As New DireccionesPersonas
                mDIP.DIR_DESCRIPCION = txtDireccionFiscal.Text
                mDIP.DIR_TIPO = 3 'Tipo Fiscal
                mDIP.DIR_REFERENCIA = ""
                mDIP.DIS_ID = "009" 'arequipa por defecto
                mDIP.DIR_ESTADO = True
                mDIP.DIR_FEC_GRAB = Now
                mDIP.USU_ID = SessionServer.UserId
                mDIP.MarkAsAdded()
                mPer.DireccionesPersonas.Add(mDIP)
                If txtDireccionDomicilio.TextLength > 0 Then
                    Dim mDIP2 As New DireccionesPersonas
                    mDIP2.DIR_DESCRIPCION = txtDireccionFiscal.Text
                    mDIP2.DIR_TIPO = 0 'Tipo Domicilio
                    mDIP2.DIR_REFERENCIA = ""
                    mDIP2.DIS_ID = "009" 'arequipa por defecto
                    mDIP2.DIR_ESTADO = True
                    mDIP2.DIR_FEC_GRAB = Now
                    mDIP2.USU_ID = SessionServer.UserId
                    mDIP2.MarkAsAdded()
                    mPer.DireccionesPersonas.Add(mDIP2)
                End If
            Else
                For Each mDir In mPer.DireccionesPersonas
                    If mDir.DIR_TIPO = 3 OrElse mDir.DIR_TIPO = 0 Then
                        mDir.DIR_DESCRIPCION = IIf(mDir.DIR_TIPO = 3, txtDireccionFiscal.Text, txtDireccionDomicilio.Text)
                        mDir.DIR_ESTADO = True
                        mDir.DIR_FEC_GRAB = Now
                        mDir.USU_ID = SessionServer.UserId
                        mDir.MarkAsModified()
                    End If
                Next
            End If

            mPer.PER_EMAIL = txtCorreo.Text
            mPer.PER_TELEFONOS = txtTelefono.Text
            mPer.PER_PAGINA_WEB = txtWeb.Text
            mPer.PER_OBSERVACIONES = txtObservaciones.Text
            mPer.PER_CALIFICACION = cboCalificacion.Text

            For Each mDetalle As DataGridViewRow In dgvContactos.Rows
                If Not mDetalle.Cells("COP_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("COP_ID").Tag, ContactoPersona)
                        .COP_TIPO = mDetalle.Cells("COP_TIPO").Tag
                        .COP_DESCRIPCION = mDetalle.Cells("COP_DESCRIPCION").Value
                        .COP_DIRECCION = mDetalle.Cells("COP_DIRECCION").Value
                        .COP_TELEFONO = mDetalle.Cells("COP_TELEFONO").Value
                        .COP_EMAIL = mDetalle.Cells("COP_EMAIL").Value
                        .COP_ESTADO = True
                        .COP_FEC_GRAB = Now
                        .USU_ID = SessionServer.UserId
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("COP_DESCRIPCION").Value Is Nothing Then
                    Dim nCOP As New ContactoPersona
                    With nCOP
                        .COP_TIPO = mDetalle.Cells("COP_TIPO").Tag
                        .COP_DESCRIPCION = mDetalle.Cells("COP_DESCRIPCION").Value
                        .COP_DIRECCION = mDetalle.Cells("COP_DIRECCION").Value
                        .COP_TELEFONO = mDetalle.Cells("COP_TELEFONO").Value
                        .COP_EMAIL = mDetalle.Cells("COP_EMAIL").Value
                        .COP_ESTADO = True
                        .COP_FEC_GRAB = Now
                        .USU_ID = SessionServer.UserId
                        .MarkAsAdded()
                    End With
                    mPer.ContactoPersona.Add(nCOP)
                End If
            Next

            For Each mDetalle As DataGridViewRow In dgvRubro.Rows
                If mDetalle.Cells("Seleccion").Value Then
                    If Not mDetalle.Cells("RUP_ID").Value Is Nothing Then
                        With CType(mDetalle.Cells("RUP_ID").Tag, RubroPersona)
                            .RUB_ID = mDetalle.Cells("RUB_ID").Value
                            .RUP_ESTADO = True
                            .RUP_FEC_GRAB = Now
                            .USU_ID = SessionServer.UserId
                            .MarkAsModified()
                        End With
                    Else
                        Dim nRUP As New RubroPersona
                        With nRUP
                            .RUB_ID = mDetalle.Cells("RUB_ID").Value
                            .RUP_ESTADO = True
                            .RUP_FEC_GRAB = Now
                            .USU_ID = SessionServer.UserId
                            .MarkAsAdded()
                        End With
                        mPer.RubroPersona.Add(nRUP)
                    End If
                End If
            Next

            mPer.PER_ESTADO = True
            mPer.PER_FEC_GRAB = Now
            mPer.USU_ID = SessionServer.UserId

            BCPersona.MantenimientoPersonas2(mPer)
            MessageBox.Show(mPer.PER_ID)
            LimpiarControles()
            Call validacion_desactivacion(False, 3)
        End If
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mPer = New Personas
        mPer.MarkAsAdded()
        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtNombreComercial.Focus()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Proveedor"

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As String = frm.dgvLista.CurrentRow.Cells("PER_ID").Value
            CargarProveedor(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarProveedor(ByVal PER_Id As String)
        mPer = BCPersona.PersonaGetById(PER_Id)
        mPer.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mPer.PER_ID
        txtNombreComercial.Text = mPer.PER_ALIAS
        txtRazonSocial.Text = mPer.PER_APE_PAT
        For Each mDoc In mPer.DocPersonas
            If mDoc.TDP_ID = "04" Then
                txtRUC.Text = mDoc.DOP_NUMERO
            End If
        Next
        For Each mDir In mPer.DireccionesPersonas
            If mDir.DIR_TIPO = 3 Then
                txtDireccionFiscal.Text = mDir.DIR_DESCRIPCION
            ElseIf mDir.DIR_TIPO = 0 Then
                txtDireccionDomicilio.Text = mDir.DIR_DESCRIPCION
            End If
        Next
        txtCorreo.Text = mPer.PER_EMAIL
        txtTelefono.Text = mPer.PER_TELEFONOS
        txtWeb.Text = mPer.PER_PAGINA_WEB
        txtObservaciones.Text = mPer.PER_OBSERVACIONES
        cboCalificacion.Text = mPer.PER_CALIFICACION
        
        For Each mItem In mPer.ContactoPersona
            Dim nRow As New DataGridViewRow
            dgvContactos.Rows.Add(nRow)
            dgvContactos.Rows(dgvContactos.Rows.Count - 1).Cells("COP_ID").Value = mItem.COP_ID
            dgvContactos.Rows(dgvContactos.Rows.Count - 1).Cells("COP_ID").Tag = mItem

            Dim Cont As Integer = 0
            For Each tc In Contacto.DevolverTiposCampos2
                If Cont = mItem.COP_TIPO Then
                    dgvContactos.Rows(dgvContactos.Rows.Count - 1).Cells("COP_TIPO").Value = tc
                    dgvContactos.Rows(dgvContactos.Rows.Count - 1).Cells("COP_TIPO").Tag = Cont
                End If
                Cont += 1
            Next

            dgvContactos.Rows(dgvContactos.Rows.Count - 1).Cells("COP_DESCRIPCION").Value = mItem.COP_DESCRIPCION
            dgvContactos.Rows(dgvContactos.Rows.Count - 1).Cells("COP_DIRECCION").Value = mItem.COP_DIRECCION
            dgvContactos.Rows(dgvContactos.Rows.Count - 1).Cells("COP_TELEFONO").Value = mItem.COP_TELEFONO
            dgvContactos.Rows(dgvContactos.Rows.Count - 1).Cells("COP_EMAIL").Value = mItem.COP_EMAIL
        Next

        For Each mRub As DataGridViewRow In dgvRubro.Rows
            For Each mItem In mPer.RubroPersona
                If mRub.Cells("RUB_ID").Value = mItem.RUB_ID Then
                    mRub.Cells("RUP_ID").Value = mItem.RUP_ID
                    mRub.Cells("RUP_ID").Tag = mItem
                    mRub.Cells("RUB_DESCRIPCION").Value = mItem.Rubro.RUB_DESCRIPCION
                    mRub.Cells("Seleccion").Value = True
                End If
            Next
        Next
        
    End Sub


    '===================================================================================================================
    '----procedimiento de validaciones
    'tecla enter de paso rapido entre cajas de texto.
    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True
        Dim Verif As Boolean = False
        Error_validacion.Clear()
        If Len(txtNombreComercial.Text.Trim) = 0 Then Error_validacion.SetError(txtNombreComercial, "Ingrese el Nombre Comercial del Proveedor") : txtNombreComercial.Focus() : flag = False
        If Len(txtRazonSocial.Text.Trim) > 0 OrElse Len(txtRUC.Text.Trim) > 0 Then
            If Len(txtRazonSocial.Text.Trim) = 0 Then Error_validacion.SetError(txtRazonSocial, "Ingrese la Razon Social del Proveedor") : txtRazonSocial.Focus() : flag = False
            If Len(txtRUC.Text.Trim) = 0 Then Error_validacion.SetError(txtRUC, "Ingrese el RUC del Proveedor") : txtRUC.Focus() : flag = False
            Verif = True
        End If
        If Not Verif Then
            Error_validacion.SetError(txtRazonSocial, "Ingrese la Razon Social o Nombre del Proveedor") : txtRazonSocial.Focus() : flag = False
        End If
        If Len(txtDireccionFiscal.Text.Trim) = 0 Then Error_validacion.SetError(txtDireccionFiscal, "Ingrese la Direccion del Proveedor") : txtDireccionFiscal.Focus() : flag = False
        If Len(txtRazonSocial.Text.Trim) = 0 Then Error_validacion.SetError(txtRazonSocial, "Ingrese la Razon Social del Proveedor") : txtRazonSocial.Focus() : flag = False

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function


    'codigos agregados===================================================
    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)
    End Sub

    Public Overrides Sub OnManEditar()
        Call validacion_desactivacion(True, 6)
    End Sub

    Public Overrides Sub OnManCancelarEdicion()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub

    'Public Overrides Sub OnManEliminar()
    '    If mOS IsNot Nothing Then
    '        For Con As Integer = 0 To mOS.OrdenSalidaDetalle.Count - 1
    '            mOS.OrdenSalidaDetalle(Con).MarkAsDeleted()
    '        Next
    '        mOS.MarkAsDeleted()
    '        BCOrdenSalida.MantenimientoOrdenSalida(mOS)
    '    End If
    '    Call LimpiarControles()
    '    Call validacion_desactivacion(False, 7)
    'End Sub
    'Public Overrides Sub OnManSalir()
    '    Me.Dispose()
    'End Sub

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

        End If
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvContactos.Rows.Add(nRow)
    End Sub

    Private Sub dgvContactos_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvContactos.EditingControlShowing
        If dgvContactos.CurrentCell.OwningColumn.Name = "COP_TIPO" Then
            ' Check box column
            Dim comboBox As ComboBox = TryCast(e.Control, ComboBox)
            AddHandler comboBox.SelectedIndexChanged, AddressOf comboBox_SelectedIndexChanged
        End If
    End Sub

    Private Sub dgvContactos_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvContactos.UserDeletingRow
        If Not e.Row.Cells("COP_ID").Value Is Nothing Then
            CType(e.Row.Cells("COP_ID").Tag, ContactoPersona).MarkAsDeleted()
        End If
    End Sub

    Private Sub dgvRubro_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRubro.CellEndEdit
        If dgvRubro.CurrentRow.Cells("Seleccion").Value = False Then
            If Not dgvRubro.CurrentRow.Cells("RUP_ID").Value Is Nothing Then
                CType(dgvRubro.CurrentRow.Cells("RUP_ID").Tag, RubroPersona).MarkAsDeleted()
            End If
        End If
    End Sub

    Private Sub comboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim selectedIndex As Integer = DirectCast(sender, ComboBox).SelectedIndex
        'MessageBox.Show("Selected Index = " & selectedIndex)
        dgvContactos.CurrentCell.Tag = selectedIndex
    End Sub

    Private Sub txtRUC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRUC.KeyDown
        CambioRuc = True
    End Sub

    Private Sub txtRUC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRUC.TextChanged
        If txtRUC.TextLength = 11 And CambioRuc Then
            Try
                MessageBox.Show("Ya existe, PER_ID: " & BCDocPersona.DocPersonaGetById_Numero(txtRUC.Text).PER_ID)
                LimpiarControles()
            Catch ex As Exception

            End Try

        End If
    End Sub

    '///////// REPORTE ///////////////////

    Private Sub btnVisualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            Dim ds As New DataSet

            For Each mF As DataGridViewRow In dgvRubro2.Rows
                If mF.Cells("Seleccion2").Value Then
                    ds.Merge(CargarReporte(mF.Cells("RUB_ID2").Value))
                End If
            Next

            If ds.Tables.Count = 0 Then
                Dim query = BCPersona.ListaProveedor(txtProveedor.Tag, cboCalificacion2.Text, Nothing)
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
            End If

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaProveedor", ds.Tables(0)))
            ''ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            'Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text)
            ''parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.DateTime.Date)
            ''parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            ' '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaProveedor", New DataTable()))
            ReportViewer1.RefreshReport()
        End Try
    End Sub

    Private Function CargarReporte(ByVal RUB_ID As Integer) As DataSet
        Dim ds As New DataSet
        Try
            Dim query = BCPersona.ListaProveedor(txtProveedor.Tag, cboCalificacion2.Text, RUB_ID)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
        Catch ex As Exception

        End Try
        Return ds
    End Function

    Private Sub txtProveedor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProveedor.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Proveedor"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProveedor.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
            txtProveedor.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then txtProveedor_DoubleClick(Nothing, Nothing)
    End Sub
End Class
