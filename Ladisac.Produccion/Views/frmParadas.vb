Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmParadas

    <Dependency()> _
    Public Property BCParada As Ladisac.BL.IBCParada
    <Dependency()> _
    Public Property BCTipoParada As Ladisac.BL.IBCTipoParada
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mParada As Parada

    'ingreso de codigo
    Private Sub frmParada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        CargarColumnCboTipoParada()

        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.
        'se declara los objetos.

        Call validar_longitud()
        Call validacion_desactivacion(False, 1)
        txtCodigo.TabIndex = 2
        txtDescripcion.TabIndex = 0
        dgvTipoParada.TabIndex = 1

    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mParada.PAR_ID
        txtDescripcion.Text = mParada.PAR_DESCRIPCION
        For Each mItem In mParada.ParadasTipos
            Dim nRow As New DataGridViewRow
            dgvTipoParada.Rows.Add(nRow)
            dgvTipoParada.Rows(dgvTipoParada.Rows.Count - 2).Cells("PAT_ID").Value = mItem.PAT_ID
            dgvTipoParada.Rows(dgvTipoParada.Rows.Count - 2).Cells("TPA_ID").Value = mItem.TipoParada.TPA_ID.ToString
            dgvTipoParada.Rows(dgvTipoParada.Rows.Count - 2).Cells("TPA_ID").Tag = mItem
        Next
    End Sub

    Sub CargarColumnCboTipoParada()
        Dim ds As New DataSet
        Dim query = BCTipoParada.ListaTipoParada(0)
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        Dim mCbo As New DataGridViewComboBoxColumn
        With mCbo
            .Name = "TPA_ID"
            .HeaderText = "Tipo de Parada"
            .Width = 250
            .DisplayMember = "TPA_Descripcion"
            .ValueMember = "TPA_ID"
            .DataSource = ds.Tables(0)
        End With
        dgvTipoParada.Columns.Add(mCbo)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Parada"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarParada(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarParada(ByVal PAR_Id As Integer)
        mParada = BCParada.ParadaGetById(PAR_Id)
        mParada.MarkAsModified()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '---------------------------------------------




        If mParada IsNot Nothing Then
            dgvTipoParada.EndEdit()
            mParada.PAR_DESCRIPCION = txtDescripcion.Text
            mParada.PAR_ESTADO = True
            mParada.PAR_FEC_GRAB = Now
            mParada.USU_ID = 1
            For Each mParadasTipos As DataGridViewRow In dgvTipoParada.Rows
                If Not mParadasTipos.Cells("PAT_ID").Value Is Nothing Then
                    With CType(mParadasTipos.Cells("TPA_ID").Tag, ParadasTipos)
                        .TPA_ID = CInt(mParadasTipos.Cells("TPA_ID").Value)
                        .PAT_FEC_GRAB = Now
                        .USU_ID = 1
                        .MarkAsModified()
                    End With
                ElseIf Not mParadasTipos.Cells("TPA_ID").Value Is Nothing Then
                    Dim nPaTi As New ParadasTipos
                    With nPaTi
                        .TPA_ID = CInt(mParadasTipos.Cells("TPA_ID").Value)
                        .PAT_FEC_GRAB = Now
                        .PAT_ESTADO = True
                        .USU_ID = 1
                        .MarkAsAdded()
                    End With
                    mParada.ParadasTipos.Add(nPaTi)
                End If
            Next
            BCParada.MantenimientoParada(mParada)
            LimpiarControles()
        End If



        '------------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mParada = New Parada
        mParada.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtDescripcion.Focus()
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mParada = Nothing
        txtCodigo.Text = String.Empty
        txtDescripcion.Text = String.Empty
        dgvTipoParada.Rows.Clear()

        '---------------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub dgvTipoParada_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvTipoParada.UserDeletingRow
        CType(e.Row.Cells("TPA_ID").Tag, ParadasTipos).MarkAsDeleted()
    End Sub

    '===================================================================================================================
    '----procedimiento de validaciones
    'tecla enter de paso rapido entre cajas de texto.
 

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(txtDescripcion.Text.Trim) = 0 Then Error_validacion.SetError(txtDescripcion, "Ingrese la Descripcion") : txtDescripcion.Focus() : flag = False
        'If Len(dgvTipoParada.Text.Trim) = 0 Then Error_validacion.SetError(dgvTipoParada, "Ingrese el Tipo de Parda") : dgvTipoParada.Focus() : flag = False
       
        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos
    Private Sub validar_longitud()
        Me.txtDescripcion.MaxLength = 45
    End Sub

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



End Class
