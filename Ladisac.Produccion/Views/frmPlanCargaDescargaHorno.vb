Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmPlanCargaDescargaHorno
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCHorno As Ladisac.BL.IBCHorno
    <Dependency()> _
    Public Property BCPuertaHorno As Ladisac.BL.IBCPuertaHorno
    <Dependency()> _
    Public Property BCPlanCargaDescargaHorno As Ladisac.BL.IBCPlanCargaDescargaHorno

    Protected mPlanCargaDescargaHorno As PlanCargaDescargaHorno
    Protected mHorno As Horno

    Private Sub frmPlanCargaDescargaHorno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarHornos()
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        tabProHor.SelectedIndex = 0
        cboHorno.SelectedIndex = -1
        cboPuerta.DataSource = Nothing
        dtpFecha.Value = Today
        txtUNT_ID_1.Text = String.Empty
        txtUNT_ID_1.Tag = Nothing
        txtUNT_ID_2.Text = String.Empty
        txtUNT_ID_2.Tag = Nothing
        txtUNT_ID_3.Text = String.Empty
        txtUNT_ID_3.Tag = Nothing
        txtUNT_ID_4.Text = String.Empty
        txtUNT_ID_4.Tag = Nothing
        txtUNT_ID_5.Text = String.Empty
        txtUNT_ID_5.Tag = Nothing
        txtUNT_ID_6.Text = String.Empty
        txtUNT_ID_6.Tag = Nothing
        txtUNT_ID_7.Text = String.Empty
        txtUNT_ID_7.Tag = Nothing
        txtUNT_ID_8.Text = String.Empty
        txtUNT_ID_8.Tag = Nothing
        txtUNT_ID_9.Text = String.Empty
        txtUNT_ID_9.Tag = Nothing
        txtUNT_ID_10.Text = String.Empty
        txtUNT_ID_10.Tag = Nothing
        txtENO_ID_1.Text = String.Empty
        txtENO_ID_1.Tag = Nothing
        txtENO_ID_2.Text = String.Empty
        txtENO_ID_2.Tag = Nothing
        txtENO_ID_3.Text = String.Empty
        txtENO_ID_3.Tag = Nothing
        txtENO_ID_4.Text = String.Empty
        txtENO_ID_4.Tag = Nothing

        rbtCV.Checked = False
        rbtCR.Checked = False
        rbtCC.Checked = False
        rbtDV.Checked = False
        rbtDR.Checked = False
        rbtDC.Checked = False

        txtProduccion.Text = String.Empty
        txtProduccion.Tag = Nothing
        txtPlanta.Text = String.Empty

        '--------------------------
        Error_Validacion.Clear()
    End Sub

    Sub CargarHornos()
        Dim ds As New DataSet
        Dim query = BCHorno.ListaHorno
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboHorno
            .DisplayMember = "HOR_Descripcion"
            .ValueMember = "HOR_ID"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    Sub CargarPuertaHorno(ByVal HOR_ID As Integer)
        Dim ds As New DataSet
        Dim query = BCPuertaHorno.ListaPuertaHornoByHorno(HOR_ID)
        If query.Length > 0 Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            With cboPuerta
                .DisplayMember = "PUE_Descripcion"
                .ValueMember = "PUE_ID"
                .DataSource = ds.Tables(0)
            End With
            cboPuerta.SelectedIndex = -1
        End If
    End Sub

    Private Sub cboHorno_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHorno.SelectedValueChanged
        If cboHorno.DataSource IsNot Nothing Then CargarPuertaHorno(cboHorno.SelectedValue) : mHorno = BCHorno.HornoGetById(cboHorno.SelectedValue)
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


    Sub LlenarControles()
        If mPlanCargaDescargaHorno.CDH_TIPO = "G" Then
            tabProHor.SelectedIndex = 1
            txtProduccion.Text = mPlanCargaDescargaHorno.PRO_ID & mPlanCargaDescargaHorno.Produccion.Ladrillo.Articulos.ART_DESCRIPCION
            txtProduccion.Tag = mPlanCargaDescargaHorno.PRO_ID
            txtPlanta.Text = mPlanCargaDescargaHorno.Produccion.Planta.PLA_DESCRIPCION

        Else
            tabProHor.SelectedIndex = 0
            cboHorno.SelectedValue = mPlanCargaDescargaHorno.HOR_ID
            cboPuerta.SelectedValue = mPlanCargaDescargaHorno.PUE_ID
        End If
        dtpFecha.Value = mPlanCargaDescargaHorno.CDH_FECHA_HORA
        txtUNT_ID_1.Text = mPlanCargaDescargaHorno.UNT_ID_1
        txtUNT_ID_1.Tag = mPlanCargaDescargaHorno.UNT_ID_1
        txtUNT_ID_2.Text = mPlanCargaDescargaHorno.UNT_ID_2
        txtUNT_ID_2.Tag = mPlanCargaDescargaHorno.UNT_ID_2
        txtUNT_ID_3.Text = mPlanCargaDescargaHorno.UNT_ID_3
        txtUNT_ID_3.Tag = mPlanCargaDescargaHorno.UNT_ID_3
        txtUNT_ID_4.Text = mPlanCargaDescargaHorno.UNT_ID_4
        txtUNT_ID_4.Tag = mPlanCargaDescargaHorno.UNT_ID_4
        txtUNT_ID_5.Text = mPlanCargaDescargaHorno.UNT_ID_5
        txtUNT_ID_5.Tag = mPlanCargaDescargaHorno.UNT_ID_5
        txtUNT_ID_6.Text = mPlanCargaDescargaHorno.UNT_ID_6
        txtUNT_ID_6.Tag = mPlanCargaDescargaHorno.UNT_ID_6
        txtUNT_ID_7.Text = mPlanCargaDescargaHorno.UNT_ID_7
        txtUNT_ID_7.Tag = mPlanCargaDescargaHorno.UNT_ID_7
        txtUNT_ID_8.Text = mPlanCargaDescargaHorno.UNT_ID_8
        txtUNT_ID_8.Tag = mPlanCargaDescargaHorno.UNT_ID_8
        txtUNT_ID_9.Text = mPlanCargaDescargaHorno.UNT_ID_9
        txtUNT_ID_9.Tag = mPlanCargaDescargaHorno.UNT_ID_9
        txtUNT_ID_10.Text = mPlanCargaDescargaHorno.UNT_ID_10
        txtUNT_ID_10.Tag = mPlanCargaDescargaHorno.UNT_ID_10

        If mPlanCargaDescargaHorno.Entidad IsNot Nothing Then txtENO_ID_1.Text = mPlanCargaDescargaHorno.Entidad.ENO_DESCRIPCION
        If mPlanCargaDescargaHorno.Entidad IsNot Nothing Then txtENO_ID_1.Tag = mPlanCargaDescargaHorno.Entidad.ENO_ID
        If mPlanCargaDescargaHorno.Entidad1 IsNot Nothing Then txtENO_ID_2.Text = mPlanCargaDescargaHorno.Entidad1.ENO_DESCRIPCION
        If mPlanCargaDescargaHorno.Entidad1 IsNot Nothing Then txtENO_ID_2.Tag = mPlanCargaDescargaHorno.Entidad1.ENO_ID
        If mPlanCargaDescargaHorno.Entidad2 IsNot Nothing Then txtENO_ID_3.Text = mPlanCargaDescargaHorno.Entidad2.ENO_DESCRIPCION
        If mPlanCargaDescargaHorno.Entidad2 IsNot Nothing Then txtENO_ID_3.Tag = mPlanCargaDescargaHorno.Entidad2.ENO_ID
        If mPlanCargaDescargaHorno.Entidad3 IsNot Nothing Then txtENO_ID_4.Text = mPlanCargaDescargaHorno.Entidad3.ENO_DESCRIPCION
        If mPlanCargaDescargaHorno.Entidad3 IsNot Nothing Then txtENO_ID_4.Tag = mPlanCargaDescargaHorno.Entidad3.ENO_ID
        Select Case mPlanCargaDescargaHorno.CDH_TIPO
            Case "A"
                rbtCV.Checked = True
            Case "B"
                rbtCR.Checked = True
            Case "C"
                rbtCC.Checked = True
            Case "D"
                rbtDV.Checked = True
            Case "E"
                rbtDR.Checked = True
            Case "F"
                rbtDC.Checked = True
        End Select
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)

    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "PlanCargaDescargaHorno"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarPlanCargaDescargaHorno(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarPlanCargaDescargaHorno(ByVal CDH_Id As Integer)
        mPlanCargaDescargaHorno = BCPlanCargaDescargaHorno.PlanCargaDescargaHornoGetById(CDH_Id)
        mPlanCargaDescargaHorno.MarkAsModified()
    End Sub

    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()


        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '---------------------------------------------

        If mPlanCargaDescargaHorno IsNot Nothing Then
            With mPlanCargaDescargaHorno
                If tabProHor.SelectedIndex = 0 Then
                    .HOR_ID = CInt(cboHorno.SelectedValue)
                    .PUE_ID = CInt(cboPuerta.SelectedValue)
                Else
                    .PRO_ID = CInt(txtProduccion.Tag)
                End If
                .CDH_FECHA_HORA = dtpFecha.Value
                .UNT_ID_1 = txtUNT_ID_1.Tag
                .UNT_ID_2 = txtUNT_ID_2.Tag
                .UNT_ID_3 = txtUNT_ID_3.Tag
                .UNT_ID_4 = txtUNT_ID_4.Tag
                .UNT_ID_5 = txtUNT_ID_5.Tag
                .UNT_ID_6 = txtUNT_ID_6.Tag
                .UNT_ID_7 = txtUNT_ID_7.Tag
                .UNT_ID_8 = txtUNT_ID_8.Tag
                .UNT_ID_9 = txtUNT_ID_9.Tag
                .UNT_ID_10 = txtUNT_ID_10.Tag
                .ENO_ID_1 = txtENO_ID_1.Tag
                .ENO_ID_2 = txtENO_ID_2.Tag
                .ENO_ID_3 = txtENO_ID_3.Tag
                .ENO_ID_4 = txtENO_ID_4.Tag
                If rbtCV.Checked Then
                    .CDH_TIPO = "A"
                ElseIf rbtCR.Checked Then
                    .CDH_TIPO = "B"
                ElseIf rbtCC.Checked Then
                    .CDH_TIPO = "C"
                ElseIf rbtDV.Checked Then
                    .CDH_TIPO = "D"
                ElseIf rbtDR.Checked Then
                    .CDH_TIPO = "E"
                ElseIf rbtDC.Checked Then
                    .CDH_TIPO = "F"
                Else
                    .CDH_TIPO = "G"
                End If
                .CDH_ESTADO = True
                .CDH_FEC_GRAB = Now
                .USU_ID = SessionServer.UserId
            End With
            BCPlanCargaDescargaHorno.MantenimientoPlanCargaDescargaHorno(mPlanCargaDescargaHorno)
            MessageBox.Show(mPlanCargaDescargaHorno.CDH_ID)
            LimpiarControles()
        End If


        '------------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mPlanCargaDescargaHorno = New PlanCargaDescargaHorno
        mPlanCargaDescargaHorno.MarkAsAdded()
        '---------------------------------------
        Call validacion_desactivacion(True, 2)
    End Sub

    Private Sub txtUNT_ID_1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUNT_ID_1.DoubleClick, txtUNT_ID_2.DoubleClick, txtUNT_ID_3.DoubleClick, txtUNT_ID_4.DoubleClick, txtUNT_ID_5.DoubleClick, txtUNT_ID_6.DoubleClick, txtUNT_ID_7.DoubleClick, txtUNT_ID_8.DoubleClick, txtUNT_ID_9.DoubleClick, txtUNT_ID_10.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "UnidadesTransporte"
        frm.Tipo = CType(sender, TextBox).Text
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            CType(sender, TextBox).Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'UNT_Id
            CType(sender, TextBox).Text = frm.dgvLista.CurrentRow.Cells(0).Value 'UNT_Id
        End If
        frm.Dispose()
    End Sub

    Private Sub txtUNT_ID_1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUNT_ID_1.KeyDown, txtUNT_ID_2.KeyDown, txtUNT_ID_3.KeyDown, txtUNT_ID_4.KeyDown, txtUNT_ID_5.KeyDown, txtUNT_ID_6.KeyDown, txtUNT_ID_7.KeyDown, txtUNT_ID_8.KeyDown, txtUNT_ID_9.KeyDown, txtUNT_ID_10.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtUNT_ID_1_DoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub txtENO_ID_1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtENO_ID_1.DoubleClick, txtENO_ID_2.DoubleClick, txtENO_ID_3.DoubleClick, txtENO_ID_4.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Cancha"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            CType(sender, TextBox).Text = frm.dgvLista.CurrentRow.Cells(1).Value  'CAN_Descripcion
            CType(sender, TextBox).Tag = CInt(frm.dgvLista.CurrentRow.Cells(2).Value)  'ENO_ID_CANCHA
        End If
    End Sub

    Private Sub txtENO_ID_1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtENO_ID_1.KeyDown, txtENO_ID_2.KeyDown, txtENO_ID_3.KeyDown, txtENO_ID_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtENO_ID_1_DoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub txtProduccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProduccion.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Produccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProduccion.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PRO_Id
            txtProduccion.Text = frm.dgvLista.CurrentRow.Cells(0).Value & " " & frm.dgvLista.CurrentRow.Cells("ART_DESCRIPCION").Value 'Nombres
            dtpFecha.Value = frm.dgvLista.CurrentRow.Cells(2).Value
            txtPlanta.Text = frm.dgvLista.CurrentRow.Cells(4).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub txtProduccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProduccion.KeyDown
        If e.KeyCode = Keys.Enter Then txtProduccion_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub tabProHor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabProHor.SelectedIndexChanged
        If tabProHor.SelectedIndex = 0 Then
            txtProduccion.Text = String.Empty
            txtProduccion.Tag = Nothing
        Else
            cboHorno.SelectedIndex = -1
            cboPuerta.DataSource = Nothing

            rbtCV.Checked = False
            rbtCR.Checked = False
            rbtCC.Checked = False
            rbtDV.Checked = False
            rbtDR.Checked = False
            rbtDC.Checked = False

        End If
    End Sub
End Class
