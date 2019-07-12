Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports System.Data

Public Class frmGuiasAutorizadas
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCDespachos As Ladisac.BL.IBCDespachos

    Dim mGuia As Despachos


    Private Sub frmGuiasAutorizadas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        txtSerie.Focus()
        Call validacion_desactivacion(False, 1)
    End Sub

    Sub LimpiarControles()
        mGuia = Nothing
        txtSerie.Text = String.Empty
        txtNumero.Text = String.Empty
        txtAutorizado.Text = String.Empty
        txtAutorizado.Tag = Nothing
    End Sub

    Sub CargarGuia()
        Dim Serie As String
        Dim Numero As String
        Serie = txtSerie.Text.Trim.PadLeft(3, "0")
        Numero = txtNumero.Text.Trim.PadLeft(10, "0")
        mGuia = BCDespachos.DespachosGetById("005", "011", Serie, Numero)
        If mGuia IsNot Nothing Then
            txtSerie.Text = mGuia.DES_SERIE
            txtNumero.Text = mGuia.DES_NUMERO
            mGuia.MarkAsModified()
        End If

    End Sub

    Private Sub txtSerie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerie.LostFocus, txtNumero.LostFocus
        If txtSerie.TextLength > 0 And txtNumero.TextLength > 0 Then
            CargarGuia()
            If mGuia Is Nothing Then
                MessageBox.Show("No se encontro la Guia Despacho.")
                LimpiarControles()
            End If
        End If
    End Sub

    Public Overrides Sub OnManGuardar()
        If mGuia IsNot Nothing Then
            mGuia.PER_ID_AUTORIZADO = txtAutorizado.Tag
            If BCDespachos.Mantenimiento(mGuia) = 1 Then
                MessageBox.Show("Informacion ingresada.")
                LimpiarControles()
            Else
                MessageBox.Show("Error al momento de actualizar la informacion.")
            End If
        End If
    End Sub

    Private Sub txtAutorizado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAutorizado.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtAutorizado.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            txtAutorizado.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtAutorizado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAutorizado.KeyDown
        If e.KeyCode = Keys.Enter Then txtAutorizado_DoubleClick(Nothing, Nothing)
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)
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
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        Call validacion_desactivacion(True, 2)
        txtSerie.Focus()
    End Sub
End Class
