Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.IO

Public Class frmDotacion
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCDotacion As Ladisac.BL.IBCDotacion
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mDotacion As Dotacion

    Private Sub frmDotacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
    End Sub

    Sub LimpiarControles()
        dtpFecha.Value = Today
        dgvDetalle.Rows.Clear()
    End Sub

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Dotacion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarDotacion(key)
            LlenarControles()
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()

    End Sub

    Sub CargarDotacion(ByVal DOT_Id As Integer)
        mDotacion = BCDotacion.DotacionGetById(DOT_Id)
        mDotacion.MarkAsModified()
    End Sub

    Sub LlenarControles()
        dtpFecha.Value = mDotacion.DOT_FECHA
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DOT_ID").Value = mDotacion.DOT_ID
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DOT_ID").Tag = mDotacion
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PER_ID_PROVEEDOR").Value = mDotacion.Personas.PER_NOMBRES & " " & mDotacion.Personas.PER_APE_PAT
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PER_ID_PROVEEDOR").Tag = mDotacion.PER_ID_PROVEEDOR
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Art_Id").Value = mDotacion.Articulos.ART_Codigo & " - " & mDotacion.Articulos.ART_DESCRIPCION & " - " & mDotacion.Articulos.UnidadMedidaArticulos.UM_SIMBOLO
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Art_Id").Tag = mDotacion.ART_ID
        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("UM").Value = mItem.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value = mDotacion.DOT_CANTIDAD
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Observacion").Value = mDotacion.DOT_OBSERVACION
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Vigente").Value = mDotacion.DOT_VIGENTE
    End Sub

    Public Overrides Sub OnManGuardar()
        dgvDetalle.EndEdit()
        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
            If Not mDetalle.Cells("DOT_ID").Value Is Nothing Then
                With CType(mDetalle.Cells("DOT_ID").Tag, Dotacion)
                    .DOT_FECHA = dtpFecha.Value
                    .PER_ID_PROVEEDOR = mDetalle.Cells("PER_ID_PROVEEDOR").Tag
                    .ART_ID = mDetalle.Cells("ART_ID").Tag
                    .DOT_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                    .DOT_OBSERVACION = mDetalle.Cells("Observacion").Value
                    .DOT_VIGENTE = mDetalle.Cells("Vigente").Value
                    .DOT_ESTADO = True
                    .DOT_FEC_GRAB = Now
                    .USU_ID = SessionServer.UserId
                    .MarkAsModified()
                End With
                BCDotacion.MantenimientoDotacion(mDotacion)
            ElseIf Not mDetalle.Cells("Cantidad").Value Is Nothing Then
                Dim mDot As New Dotacion
                With mDot
                    .DOT_FECHA = dtpFecha.Value
                    .PER_ID_PROVEEDOR = mDetalle.Cells("PER_ID_PROVEEDOR").Tag
                    .ART_ID = mDetalle.Cells("ART_ID").Tag
                    .DOT_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                    .DOT_OBSERVACION = mDetalle.Cells("Observacion").Value
                    .DOT_VIGENTE = mDetalle.Cells("Vigente").Value
                    .DOT_ESTADO = True
                    .DOT_FEC_GRAB = Now
                    .USU_ID = SessionServer.UserId
                    .MarkAsAdded()
                End With
                BCDotacion.MantenimientoDotacion(mDot)
            End If
        Next
        LimpiarControles()
        Call validacion_desactivacion(False, 3)
    End Sub

    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        'mArticuloAlmacen = New ArticuloAlmacen
        'mArticuloAlmacen.MarkAsAdded()
        Call validacion_desactivacion(True, 2)
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        Select Case e.ColumnIndex
            Case 1
                frm.Tabla = "Persona"
                frm.Tipo = "Proveedor"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
                End If
            Case 2
                frm.Tabla = "ArticuloMateriaPrima"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " - " & frm.dgvLista.CurrentRow.Cells(2).Value & " - " & frm.dgvLista.CurrentRow.Cells(3).Value 'ART_Descripcion
                    'dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(3).Value  'UnidadMedida
                End If
        End Select
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        If e.KeyCode = Keys.Enter Then
            Select Case dgvDetalle.CurrentCell.ColumnIndex
                Case 1
                    frm.Tabla = "Persona"
                    frm.Tipo = "Proveedor"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
                    End If
                Case 2
                    frm.Tabla = "ArticuloMateriaPrima"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " - " & frm.dgvLista.CurrentRow.Cells(2).Value & " - " & frm.dgvLista.CurrentRow.Cells(2).Value 'ART_Descripcion
                        'dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(3).Value  'UnidadMedida
                    End If
            End Select
        End If

        frm.Dispose()
    End Sub
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
End Class
