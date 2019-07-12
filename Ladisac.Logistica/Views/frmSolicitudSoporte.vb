Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmSolicitudSoporte
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCSolicitudSoporte As Ladisac.BL.IBCSolicitudSoporte
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected SoSo As SolicitudSoporte
   
    Private Sub frmSolicitudSoporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        SoSo = Nothing
        dtpfecha.Value = Now
        txtCodigo.Text = String.Empty
        txtSolicitado.Text = String.Empty
        txtSolicitado.Tag = Nothing
        cboArea.SelectedIndex = -1
        txtAutorizado.Text = String.Empty
        txtAutorizado.Tag = Nothing
        txtDescripcion.Text = String.Empty
        dgvDetalle.Rows.Clear()
        rdbConforme.Checked = False
        rdbNoConforme.Checked = False
        txtConformidad.Text = String.Empty
        '------------------------
        Error_validacion.Clear()
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

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "SolicitudSoporte"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarSolicitudSoporte(key)
            LlenarControles()
            ''---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarSolicitudSoporte(ByVal SOS_ID As Integer)
        SoSo = BCSolicitudSoporte.SolicitudSoporteGetById(SOS_ID)
        SoSo.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = SoSo.SOS_ID
        dtpfecha.Value = SoSo.SOS_FECHA
        txtSolicitado.Text = SoSo.Personas.PER_APE_PAT & " " & SoSo.Personas.PER_APE_MAT & " " & SoSo.Personas.PER_NOMBRES
        txtSolicitado.Tag = SoSo.PER_ID_SOLICITADO
        cboArea.SelectedText = SoSo.SOS_AREA
        txtAutorizado.Text = SoSo.Personas1.PER_APE_PAT & " " & SoSo.Personas1.PER_APE_MAT & " " & SoSo.Personas1.PER_NOMBRES
        txtAutorizado.Tag = SoSo.PER_ID_AUTORIZADO
        txtDescripcion.Text = SoSo.SOS_DESCRIPCION

        For Each mItem In SoSo.SolicitudSoporteDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SSD_MENSAJE").Value = mItem.SSD_MENSAJE.ToString
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SSD_MENSAJE").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SSD_FECHA").Value = mItem.SSD_FECHA
        Next
        If SoSo.SOS_CONFORMIDAD = 1 Then
            rdbConforme.Checked = True
        Else
            rdbNoConforme.Checked = True
        End If
        txtConformidad.Text = SoSo.SOS_DESCRIPCION_CONFORMIDAD
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------
        If SoSo IsNot Nothing Then
            SoSo.SOS_FECHA = dtpfecha.Value
            SoSo.PER_ID_SOLICITADO = txtSolicitado.Tag
            SoSo.SOS_AREA = cboArea.SelectedText
            SoSo.PER_ID_AUTORIZADO = txtAutorizado.Text
            SoSo.SOS_DESCRIPCION = txtDescripcion.Text

            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("SSD_MENSAJE").Tag Is Nothing Then
                    With CType(mDetalle.Cells("SSD_MENSAJE").Tag, SolicitudSoporteDetalle)
                        .SSD_MENSAJE = mDetalle.Cells("SSD_MENSAJE").Value
                        .SSD_FECHA = mDetalle.Cells("SSD_FECHA").Value
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("SSD_MENSAJE").Value Is Nothing Then
                    Dim nSSD As New SolicitudSoporteDetalle
                    With nSSD
                        .SSD_MENSAJE = mDetalle.Cells("SSD_MENSAJE").Value
                        .SSD_FECHA = mDetalle.Cells("SSD_FECHA").Value
                        .MarkAsAdded()
                    End With
                    SoSo.SolicitudSoporteDetalle.Add(nSSD)
                End If
            Next

            SoSo.SOS_ESTADO = True
            SoSo.SOS_FEC_GRAB = Now
            SoSo.USU_ID = SessionServer.UserId

            BCSolicitudSoporte.MantenimientoSolicitudSoporte(SoSo)
            MessageBox.Show(SoSo.SOS_ID)
            LimpiarControles()
        End If


        '------------------------------------------
        Call validacion_desactivacion(False, 3)

    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        SoSo = New SolicitudSoporte
        SoSo.MarkAsAdded()

        '---------------------------------------
        Call validacion_desactivacion(True, 2)
    End Sub

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True
        Error_validacion.Clear()
        If Len(txtSolicitado.Text.Trim) = 0 Then Error_Validacion.SetError(txtSolicitado, "Ingrese Solicitado") : txtSolicitado.Focus() : flag = False
        If cboArea.SelectedIndex = -1 Then Error_Validacion.SetError(cboArea, "Ingrese el Area") : cboArea.Focus() : flag = False
        If Len(txtDescripcion.Text.Trim) = 0 Then Error_Validacion.SetError(txtDescripcion, "Ingrese descripcion del problema") : txtDescripcion.Focus() : flag = False

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
        If SoSo IsNot Nothing Then
            SoSo.MarkAsDeleted()
            BCSolicitudSoporte.MantenimientoSolicitudSoporte(SoSo)
        End If
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub
    Public Overrides Sub OnManSalir()
        Me.Dispose()
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
    End Sub
End Class
