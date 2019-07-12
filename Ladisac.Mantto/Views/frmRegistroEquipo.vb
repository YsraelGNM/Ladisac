Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmRegistroEquipo
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCRegEquipo As Ladisac.BL.IBCRegistroEquipo
    <Dependency()> _
    Public Property BCDatosLaborales As Ladisac.BL.IBCDatosLaborales
    <Dependency()> _
    Public Property BCEntidad As Ladisac.BL.IBCEntidad
    <Dependency()> _
    Public Property BCSalidaCombustible As Ladisac.BL.IBCSalidaCombustible
    <Dependency()> _
    Public Property BCOrdenRequerimiento As Ladisac.BL.IBCOrdenRequerimiento

    Dim mREQ As RegistroEquipo
    Dim mCoPeV As String
    Dim mCoPeO As Object

    Private Sub frmRegistroEquipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        CargarUbicacion()
        CargarColumnArea()
        CargarColumnTarea()
        Call validacion_desactivacion(False, 1)
    End Sub

    Sub CargarUbicacion()
        Dim ds As New DataSet
        Dim query = BCRegEquipo.ListaUbicacionTrabajo
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboUbicacion
            .DisplayMember = "UTR_Descripcion"
            .ValueMember = "Codigo"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    Sub CargarColumnArea()
        Dim ds As New DataSet
        Dim query = BCRegEquipo.ListaArea
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        Dim mCbo As New DataGridViewComboBoxColumn
        With mCbo
            .Name = "ARE_ID"
            .HeaderText = "Area"
            .DisplayMember = "ARE_Descripcion"
            .ValueMember = "Codigo"
            .DataSource = ds.Tables(0)
        End With
        dgvDetalle.Columns.Add(mCbo)
        dgvDetalle.Columns("ARE_ID").DisplayIndex = 0
    End Sub

    Sub CargarColumnTarea()
        Dim ds As New DataSet
        Dim query = BCRegEquipo.ListaTarea
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        Dim mCbo As New DataGridViewComboBoxColumn
        With mCbo
            .Name = "TAR_ID"
            .HeaderText = "Tarea"
            .DisplayMember = "TAR_Descripcion"
            .ValueMember = "Codigo"
            .DataSource = ds.Tables(0)
        End With
        dgvDetalle.Columns.Add(mCbo)
        dgvDetalle.Columns("TAR_ID").Width = 180
        dgvDetalle.Columns("TAR_ID").DisplayIndex = 1
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mREQ = Nothing
        txtCodigo.Text = String.Empty
        txtSCO_ID.Text = String.Empty
        txtGalones.Text = String.Empty
        txtOperador.Text = String.Empty
        txtOperador.Tag = Nothing
        txtProduccion.Text = String.Empty
        txtProduccion.Tag = Nothing
        txtENO_ID.Text = String.Empty
        txtENO_ID.Tag = Nothing
        dtpFecha.Value = Today
        cboUbicacion.SelectedIndex = -1
        cboTurno.SelectedIndex = -1
        txtProduccionGrupo.Text = String.Empty
        txtProduccionGrupo.Tag = Nothing
        cboTurnoGrupo.SelectedIndex = -1
        dgvDetalle.Rows.Clear()
        dgvDetalleGrupo.Rows.Clear()
        '------------------------
        Error_validacion.Clear()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "RegistroEquipo"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TabControl1.SelectedIndex = 1
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarRegistroEquipo(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarRegistroEquipo(ByVal REQ_Id As Integer)
        mREQ = BCRegEquipo.RegistroEquipoGetById(REQ_Id)
        mREQ.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mREQ.REQ_ID
        If mREQ.SCO_ID IsNot Nothing Then
            txtSCO_ID.Text = mREQ.SCO_ID
            txtGalones.Text = mREQ.SalidaCombustible.SCO_CANTIDAD
        End If
        If mREQ.PER_ID_OPERADOR IsNot Nothing Then
            txtOperador.Text = mREQ.Personas.PER_APE_PAT & " " & mREQ.Personas.PER_APE_MAT & " " & mREQ.Personas.PER_NOMBRES
            txtOperador.Tag = mREQ.PER_ID_OPERADOR
        End If
        
        txtENO_ID.Text = mREQ.Entidad.ENO_DESCRIPCION
        txtENO_ID.Tag = mREQ.ENO_ID
        dtpFecha.Value = mREQ.REQ_FECHA
        If mREQ.UTR_ID IsNot Nothing Then
            cboUbicacion.SelectedValue = mREQ.UTR_ID
        End If
        If mREQ.REQ_TURNO = 1 Then cboTurno.SelectedIndex = 0 Else cboTurno.SelectedIndex = 1

        If mREQ.PRO_ID IsNot Nothing Then
            txtProduccion.Text = mREQ.PRO_ID & " - " & mREQ.Produccion.Ladrillo.Articulos.ART_DESCRIPCION
            txtProduccion.Tag = mREQ.PRO_ID
        End If

        For Each mItem In mREQ.RegistroEquipoDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ARE_ID").Value = mItem.ARE_ID.ToString
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TAR_ID").Value = mItem.TAR_ID.ToString
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HI").Value = String.Format("{0:00.00}", mItem.RED_HI)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HI").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HF").Value = String.Format("{0:00.00}", mItem.RED_HF)
            Dim HoraI As Double = 0
            Dim HoraF As Double = 0
            If dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HI").Value IsNot Nothing And dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HF").Value IsNot Nothing Then
                If dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HI").Value < dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HF").Value Then
                    HoraI = Double.Parse(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HI").Value.ToString.Substring(0, 2)) + Double.Parse(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HI").Value.ToString.Substring(3, 2)) / 60
                    HoraF = Double.Parse(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HF").Value.ToString.Substring(0, 2)) + Double.Parse(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HF").Value.ToString.Substring(3, 2)) / 60
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DiferenciaHora").Value = HoraF - HoraI
                Else
                    HoraI = 24 - (Double.Parse(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HI").Value.ToString.Substring(0, 2)) + Double.Parse(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HI").Value.ToString.Substring(3, 2)) / 60)
                    HoraF = Double.Parse(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HF").Value.ToString.Substring(0, 2)) + Double.Parse(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HF").Value.ToString.Substring(3, 2)) / 60
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DiferenciaHora").Value = HoraF + HoraI
                End If
            End If
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HOROI").Value = mItem.RED_HOROI
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HOROF").Value = mItem.RED_HOROF
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DiferenciaHorometro").Value = mItem.RED_HOROF - mItem.RED_HOROI
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_OBSERVACION").Value = mItem.RED_OBSERVACION
            If mItem.CAN_ID IsNot Nothing Then
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CAN_ID").Value = mItem.Cancha.CAN_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CAN_ID").Tag = mItem.CAN_ID
            End If
        Next
        Totales()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        Select Case TabControl1.SelectedIndex
            Case 0
                ProcesarGuardarGrupo()
            Case 1
                'cod ingresado q llama ala funcion para validar
                If Not validar_controles() Then Exit Sub
                '----------------------------------------------------

                If mREQ IsNot Nothing Then
                    If txtSCO_ID.Text <> "" Then mREQ.SCO_ID = CInt(txtSCO_ID.Text)
                    mREQ.PER_ID_OPERADOR = txtOperador.Tag
                    mREQ.ENO_ID = txtENO_ID.Tag
                    mREQ.REQ_FECHA = dtpFecha.Value
                    If cboUbicacion.SelectedIndex <> -1 Then mREQ.UTR_ID = CInt(cboUbicacion.SelectedValue)
                    mREQ.REQ_TURNO = IIf(cboTurno.SelectedIndex = 0, 1, 2)
                    If txtProduccion.Tag IsNot Nothing Then mREQ.PRO_ID = CInt(txtProduccion.Tag)

                    For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                        If Not mDetalle.Cells("RED_HI").Tag Is Nothing Then
                            With CType(mDetalle.Cells("RED_HI").Tag, RegistroEquipoDetalle)
                                If mDetalle.Cells("TAR_ID").Value <> "" Then .ARE_ID = CInt(mDetalle.Cells("ARE_ID").Value)
                                If mDetalle.Cells("TAR_ID").Value <> "" Then .TAR_ID = CInt(mDetalle.Cells("TAR_ID").Value)
                                .RED_HI = CDbl(mDetalle.Cells("RED_HI").Value)
                                .RED_HF = CDbl(mDetalle.Cells("RED_HF").Value)
                                .RED_HOROI = CDbl(mDetalle.Cells("RED_HOROI").Value)
                                .RED_HOROF = CDbl(mDetalle.Cells("RED_HOROF").Value)
                                .RED_OBSERVACION = mDetalle.Cells("RED_OBSERVACION").Value
                                .CAN_ID = CInt(mDetalle.Cells("CAN_ID").Tag)
                                .MarkAsModified()
                            End With
                        ElseIf Not mDetalle.Cells("RED_HI").Value Is Nothing Then
                            Dim nRED As New RegistroEquipoDetalle
                            With nRED
                                .ARE_ID = CInt(mDetalle.Cells("ARE_ID").Value)
                                .TAR_ID = CInt(mDetalle.Cells("TAR_ID").Value)
                                .RED_HI = CDbl(mDetalle.Cells("RED_HI").Value)
                                .RED_HF = CDbl(mDetalle.Cells("RED_HF").Value)
                                .RED_HOROI = CDbl(mDetalle.Cells("RED_HOROI").Value)
                                .RED_HOROF = CDbl(mDetalle.Cells("RED_HOROF").Value)
                                .RED_OBSERVACION = mDetalle.Cells("RED_OBSERVACION").Value
                                .CAN_ID = CInt(mDetalle.Cells("CAN_ID").Value)
                                .MarkAsAdded()
                            End With
                            mREQ.RegistroEquipoDetalle.Add(nRED)
                        End If
                    Next

                    mREQ.REQ_ESTADO = True
                    mREQ.REQ_FEC_GRAB = Now
                    mREQ.USU_ID = SessionServer.UserId

                    BCRegEquipo.MantenimientoRegistroEquipo(mREQ)
                    MessageBox.Show(mREQ.REQ_ID)
                    LimpiarControles()
                End If
                '------------------------------------------
                Call validacion_desactivacion(False, 3)
        End Select
    End Sub

    Sub ProcesarGuardarGrupo()
        If Not validar_controles_Grupo() Then Exit Sub

        For Each mPlaca As DataGridViewRow In dgvDetalleGrupo.Rows

            If mREQ IsNot Nothing Then

                mREQ.ENO_ID = CInt(mPlaca.Cells("ENO_ID1").Value)
                mREQ.UNT_ID = mPlaca.Cells("PLACA").Tag
                mREQ.PER_ID_EMPRESA = mPlaca.Cells("PER_ID_EMPRESA1").Value
                mREQ.REQ_FECHA = dtpFechaGrupo.Value
                mREQ.REQ_TURNO = IIf(cboTurnoGrupo.SelectedIndex = 0, 1, 2)
                mREQ.PRO_ID = CInt(txtProduccionGrupo.Tag)


                Dim nRED As New RegistroEquipoDetalle
                With nRED
                    .RED_HI = CDbl(mPlaca.Cells("HORAINICIO").Value)
                    .RED_HF = CDbl(mPlaca.Cells("HORAFINAL").Value)
                    .CAN_ID = CInt(mPlaca.Cells("CAN_ID1").Tag)
                    .MarkAsAdded()
                End With

                mREQ.RegistroEquipoDetalle.Add(nRED)

                mREQ.REQ_ESTADO = True
                mREQ.REQ_FEC_GRAB = Now
                mREQ.USU_ID = SessionServer.UserId

                BCRegEquipo.MantenimientoRegistroEquipo(mREQ)
                MessageBox.Show(mREQ.REQ_ID)

            End If

            mREQ = New RegistroEquipo
            mREQ.MarkAsAdded()

        Next
        LimpiarControles()
        '------------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mREQ = New RegistroEquipo
        mREQ.MarkAsAdded()

        '---------------------------------------
        Call validacion_desactivacion(True, 2)
    End Sub

    Private Sub txtOperador_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOperador.DoubleClick
        If IsNumeric(txtOperador.Text) Then
            Dim mPer As DatosLaborales
            mPer = BCDatosLaborales.GetByCodTrabajador(txtOperador.Text)
            txtOperador.Tag = mPer.per_Id  'Per_Id
            txtOperador.Text = mPer.Personas.PER_APE_PAT & " " & mPer.Personas.PER_APE_MAT & " " & mPer.Personas.PER_NOMBRES  'Nombres
        Else
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
            frm.Tabla = "Persona"
            frm.Tipo = "Trabajador"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtOperador.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                txtOperador.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
            End If
            frm.Dispose()
        End If
    End Sub

    Private Sub txtOperador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOperador.KeyDown
        If e.KeyCode = Keys.Enter Then txtOperador_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtENO_ID_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtENO_ID.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "EntidadPlaca"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtENO_ID.Tag = CInt(frm.dgvLista.CurrentRow.Cells(0).Value) 'ENO_Id
            txtENO_ID.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion

            If mREQ.ChangeTracker.State = ObjectState.Modified Then
                mREQ.UNT_ID = frm.dgvLista.CurrentRow.Cells(3).Value 'unt
                mREQ.PER_ID_EMPRESA = frm.dgvLista.CurrentRow.Cells(4).Value 'per_id
            End If
        End If
        frm.Dispose()
    End Sub

    Private Sub txtENO_ID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtENO_ID.KeyDown
        If e.KeyCode = Keys.Enter Then txtENO_ID_DoubleClick(Nothing, Nothing)
    End Sub

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True
        Error_validacion.Clear()
        'If Len(txtSCO_ID.Text.Trim) = 0 Then Error_Validacion.SetError(txtSCO_ID, "Ingrese el Nro de Ticket") : txtSCO_ID.Focus() : flag = False
        'If Len(txtOperador.Text.Trim) = 0 Then Error_Validacion.SetError(txtOperador, "Ingrese el Operador") : txtOperador.Focus() : flag = False
        If Len(txtENO_ID.Text.Trim) = 0 Then Error_Validacion.SetError(txtENO_ID, "Ingrese la Maquinaria") : txtENO_ID.Focus() : flag = False
        'If cboUbicacion.SelectedIndex = -1 Then Error_Validacion.SetError(cboUbicacion, "Ingrese la Ubicacion") : cboUbicacion.Focus() : flag = False
        If cboTurno.SelectedIndex = -1 Then Error_Validacion.SetError(cboTurno, "Ingrese el Turno") : cboTurno.Focus() : flag = False

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    Private Sub txtProduccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProduccion.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Produccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProduccion.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PRO_Id
            txtProduccion.Text = frm.dgvLista.CurrentRow.Cells(0).Value & " " & frm.dgvLista.CurrentRow.Cells("ART_DESCRIPCION").Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Function validar_controles_Grupo()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True
        Error_Validacion.Clear()
        If Len(txtProduccionGrupo.Text.Trim) = 0 Then Error_Validacion.SetError(txtProduccionGrupo, "Ingrese el Nro de Ticket") : txtProduccionGrupo.Focus() : flag = False
        If cboTurnoGrupo.SelectedIndex = -1 Then Error_Validacion.SetError(cboTurnoGrupo, "Ingrese el Turno") : cboTurnoGrupo.Focus() : flag = False

        For Each mFila As DataGridViewRow In dgvDetalleGrupo.Rows
            If Len((mFila.Cells("PLACA").Value & "").ToString.Trim) = 0 Then Error_Validacion.SetError(dgvDetalleGrupo, "Ingrese la Placa") : dgvDetalleGrupo.Focus() : flag = False
            If Len((mFila.Cells("HORAINICIO").Value & "").ToString.Trim) <= 1 Then Error_Validacion.SetError(dgvDetalleGrupo, "Ingrese la Hora Inicio") : dgvDetalleGrupo.Focus() : flag = False
            If Len((mFila.Cells("HORAFINAL").Value & "").ToString.Trim) <= 1 Then Error_Validacion.SetError(dgvDetalleGrupo, "Ingrese la Hora Final") : dgvDetalleGrupo.Focus() : flag = False
            If Len((mFila.Cells("CAN_ID1").Tag & "").ToString.Trim) = 0 Then Error_Validacion.SetError(dgvDetalleGrupo, "Ingrese la Cancha") : dgvDetalleGrupo.Focus() : flag = False
        Next

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
    Public Overrides Sub OnManEliminar()
        If mREQ IsNot Nothing Then
            mREQ.MarkAsDeleted()
            BCRegEquipo.MantenimientoRegistroEquipo(mREQ)
        End If
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub
    Public Overrides Sub OnManSalir()
        Me.Dispose()
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

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        Select Case TabControl1.SelectedIndex
            Case 0
                dgvDetalleGrupo.Rows.Add(nRow)
            Case 1
                dgvDetalle.Rows.Add(nRow)
                If dgvDetalle.Rows.Count = 1 Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RED_HOROI").Value = BCEntidad.UltimoHorometro(txtENO_ID.Tag, "RegistroEquipo")
        End Select
    End Sub

    Private Sub txtSCO_ID_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSCO_ID.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "SalidaCombustible"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtSCO_ID.Text = frm.dgvLista.CurrentRow.Cells("Codigo").Value
            txtGalones.Text = frm.dgvLista.CurrentRow.Cells("Cantidad").Value
            Dim mSco As SalidaCombustible = BCSalidaCombustible.SalidaCombustibleGetById(txtSCO_ID.Text)
            dtpFecha.Value = mSco.SCO_FECHA
            txtOperador.Text = mSco.Personas1.PER_APE_PAT & mSco.Personas1.PER_APE_MAT & mSco.Personas1.PER_NOMBRES
            txtOperador.Tag = mSco.PER_ID_CHOFER
            txtENO_ID.Text = BCOrdenRequerimiento.OrdenRequerimientoDetalleGetById(mSco.ORD_ID).Entidad.ENO_DESCRIPCION
            txtENO_ID.Tag = BCOrdenRequerimiento.OrdenRequerimientoDetalleGetById(mSco.ORD_ID).ENO_ID
        End If
        frm.Dispose()
    End Sub

    Private Sub txtSCO_ID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSCO_ID.KeyDown
        If e.KeyCode = Keys.Enter Then txtSCO_ID_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        Dim HoraI As Double = 0
        Dim HoraF As Double = 0

        Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "RED_HI", "RED_HF"
                Try
                    If Not IsDate(Replace(dgvDetalle.CurrentCell.Value, ".", ":")) Or dgvDetalle.CurrentCell.Value.ToString.Length <> 5 Then
                        dgvDetalle.CurrentCell.Value = "00.00"
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
        End Select

        If dgvDetalle.CurrentRow.Cells("RED_HI").Value IsNot Nothing And dgvDetalle.CurrentRow.Cells("RED_HF").Value IsNot Nothing Then
            If dgvDetalle.CurrentRow.Cells("RED_HI").Value < dgvDetalle.CurrentRow.Cells("RED_HF").Value Then
                HoraI = Double.Parse(dgvDetalle.CurrentRow.Cells("RED_HI").Value.ToString.Substring(0, 2)) + Double.Parse(dgvDetalle.CurrentRow.Cells("RED_HI").Value.ToString.Substring(3, 2)) / 60
                HoraF = Double.Parse(dgvDetalle.CurrentRow.Cells("RED_HF").Value.ToString.Substring(0, 2)) + Double.Parse(dgvDetalle.CurrentRow.Cells("RED_HF").Value.ToString.Substring(3, 2)) / 60
                dgvDetalle.CurrentRow.Cells("DiferenciaHora").Value = HoraF - HoraI
            Else
                HoraI = 24 - (Double.Parse(dgvDetalle.CurrentRow.Cells("RED_HI").Value.ToString.Substring(0, 2)) + Double.Parse(dgvDetalle.CurrentRow.Cells("RED_HI").Value.ToString.Substring(3, 2)) / 60)
                HoraF = Double.Parse(dgvDetalle.CurrentRow.Cells("RED_HF").Value.ToString.Substring(0, 2)) + Double.Parse(dgvDetalle.CurrentRow.Cells("RED_HF").Value.ToString.Substring(3, 2)) / 60
                dgvDetalle.CurrentRow.Cells("DiferenciaHora").Value = HoraF + HoraI
            End If
        End If

        Try
            dgvDetalle.Rows(dgvDetalle.CurrentRow.Index + 1).Cells("RED_HI").Value = dgvDetalle.CurrentRow.Cells("RED_HF").Value
            dgvDetalle.Rows(dgvDetalle.CurrentRow.Index + 1).Cells("RED_HOROI").Value = dgvDetalle.CurrentRow.Cells("RED_HOROF").Value
        Catch ex As Exception

        End Try

        'CType(sender, DataGridView).CurrentRow.Cells("DiferenciaHora").Value = CType(sender, DataGridView).CurrentRow.Cells("RED_HF").Value - CType(sender, DataGridView).CurrentRow.Cells("RED_HI").Value
        CType(sender, DataGridView).CurrentRow.Cells("DiferenciaHorometro").Value = CType(sender, DataGridView).CurrentRow.Cells("RED_HOROF").Value - CType(sender, DataGridView).CurrentRow.Cells("RED_HOROI").Value
        Totales()
    End Sub

    Sub Totales()
        Try
            txtTotalHoras.Text = Math.Round(dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToDouble(row.Cells("DiferenciaHora").Value)), 2)
            txtTotalHorometro.Text = Math.Round(dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToDouble(row.Cells("DiferenciaHorometro").Value)), 2)
            txtHoroGlns.Text = Math.Round(txtGalones.Text / txtTotalHorometro.Text, 4)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarToolStripMenuItem.Click
        mCoPeV = dgvDetalle.CurrentCell.Value
        mCoPeO = dgvDetalle.CurrentCell.Tag
    End Sub

    Private Sub PegarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PegarToolStripMenuItem.Click
        For Each mFila As DataGridViewRow In dgvDetalle.Rows
            For Each mCol As DataGridViewColumn In dgvDetalle.Columns
                If mFila.Cells(mCol.Index).Selected Then
                    mFila.Cells(mCol.Index).Value = mCoPeV
                    mFila.Cells(mCol.Index).Tag = mCoPeO
                End If
            Next
        Next
    End Sub

    Private Sub DuplicarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DuplicarToolStripMenuItem.Click
        Dim x As Integer = 0
        Dim y As Integer = 0

        If (dgvDetalle.SelectedRows.Count > 0) Then

            For Each mFila As DataGridViewRow In dgvDetalle.SelectedRows
                dgvDetalle.Rows.Add()
                y = 0
                While (dgvDetalle.Columns.Count - 1 > y)

                    Try
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Value = mFila.Cells(y).Value
                    Catch ex As Exception
                    End Try

                    Try
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Tag = mFila.Cells(y).Tag
                    Catch ex As Exception
                    End Try

                    y += 1
                End While
            Next

            ' ir la aultima fila
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(0)
        Else
            MsgBox("Seleccione una fila para duplicar")
        End If

    End Sub

    Private Sub dgvDetalleGrupo_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleGrupo.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        Select Case dgvDetalleGrupo.Columns(dgvDetalleGrupo.CurrentCell.ColumnIndex).Name
            Case "PLACA"
                frm.Tabla = "UnidadesTransporte"
                frm.Tipo = dgvDetalleGrupo.CurrentCell.EditedFormattedValue
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalleGrupo.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value  'Placa
                    dgvDetalleGrupo.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'Placa
                    dgvDetalleGrupo.CurrentRow.Cells("PER_ID_EMPRESA1").Value = frm.dgvLista.CurrentRow.Cells(1).Value  'PER_ID_EMPRESA
                    dgvDetalleGrupo.CurrentRow.Cells("ENO_ID1").Value = frm.dgvLista.CurrentRow.Cells(3).Value  'ENO_ID
                End If
            Case "CAN_ID1"
                frm.Tabla = "Cancha"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalleGrupo.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'cancha
                    dgvDetalleGrupo.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'can_id
                End If
        End Select
        frm.Dispose()
    End Sub

    Private Sub dgvDetalleGrupo_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleGrupo.CellEndEdit
        Select Case dgvDetalleGrupo.Columns(dgvDetalleGrupo.CurrentCell.ColumnIndex).Name
            Case "HORAINICIO", "HORAFINAL"
                Try
                    If Not IsDate(Replace(dgvDetalleGrupo.CurrentCell.Value, ".", ":")) Then
                        dgvDetalleGrupo.CurrentCell.Value = 0
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
        End Select
    End Sub

    Private Sub dgvDetalleGrupo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalleGrupo.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalleGrupo_CellDoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub txtProduccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProduccion.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtProduccion_DoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub txtProduccionGrupo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProduccionGrupo.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Produccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProduccionGrupo.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PRO_Id
            txtProduccionGrupo.Text = frm.dgvLista.CurrentRow.Cells(0).Value & " " & frm.dgvLista.CurrentRow.Cells("ART_DESCRIPCION").Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtProduccionGrupo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProduccionGrupo.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtProduccionGrupo_DoubleClick(sender, Nothing)
        End If
    End Sub
End Class
