Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Namespace Ladisac.Produccion.Views


    Public Class frmControlConteo
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCControlConteo As Ladisac.BL.IBCControlConteo
        <Dependency()> _
        Public Property BCControlCanchero As Ladisac.BL.IBCControlCanchero
        <Dependency()> _
        Public Property BCControlParada As Ladisac.BL.IBCControlParada
        <Dependency()> _
        Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
        <Dependency()> _
        Public Property BCProduccion As Ladisac.BL.IBCProduccion

        Protected mCC As ControlConteo
        Protected mConteo As Integer
        Public mProduccion As BE.Produccion
        Dim mListCCanchero As List(Of ControlCanchero)
        Dim mListCParada As List(Of ControlParada)
        Dim Total As Integer

        'ingreso de codigo
        Private Sub frmControlConteo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


            'Dim mDt As DataTable = BCControlConteo.ConteoxFecha()
            'Dim COUNT As Integer = 0
            'For Each mRow As DataRow In mDt.Rows
            '    mCC = BCControlConteo.ControlConteoGetById(mRow("CCO_ID"))
            '    mCC.MarkAsModified()
            '    Try
            '        BCControlConteo.MantenimientoControlConteo(mCC)
            '    Catch ex As Exception
            '        MsgBox(mCC.CCO_ID)
            '    End Try
            'Next





            LimpiarControles()

            '==========================================================================
            'se llama al procedimiento de paso rapido entre cajas de texto.
            'se declara los objetos.

            Call validar_longitud()
            Call validacion_desactivacion(False, 1)

            If mProduccion IsNot Nothing Then
                OnManNuevo()
                mProduccion = mProduccion
                txtProduccion.Tag = mProduccion.PRO_ID  'PRO_Id
                txtProduccion.Text = mProduccion.PRO_ID & " " & mProduccion.Ladrillo.Articulos.ART_DESCRIPCION  'Nombres
                dtpFecha.Value = mProduccion.PRO_FECHA
                txtResponsable.Text = mProduccion.Personas.PER_NOMBRES & " " & mProduccion.Personas.PER_APE_PAT & " " & mProduccion.Personas.PER_APE_MAT
                txtResponsable.Tag = mProduccion.PER_ID_ING
                If (mCC.ChangeTracker.State = ObjectState.Added) Then 'Si es nuevo
                    dgvDetalle.Rows.Clear()
                    mListCCanchero = BCControlCanchero.GetByPro_Id(mProduccion.PRO_ID)
                    mListCParada = BCControlParada.GetByPro_Id(mProduccion.PRO_ID)
                    If mListCParada.Count > 0 Then mConteo = ValidarConteo(mListCParada(0).CPA_ID)
                    For Each mItem In mListCCanchero
                        For Each mCancha In mItem.ControlCancheroDetalle
                            Dim nRow As New DataGridViewRow
                            dgvDetalle.Rows.Add(nRow)
                            If mListCParada.Count > 0 Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CPA_Id").Value = mListCParada(0).CPA_ID
                            If mListCParada.Count > 0 Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CPA_Id").Tag = mListCParada(0).CPA_ID
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAN_ID").Value = mCancha.Cancha.CAN_DESCRIPCION
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAN_ID").Tag = mCancha.CAN_ID
                            'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCC_CANTIDAD").Value = mConteo
                        Next

                        For Each mFila In dgvDetalle.Rows
                            If mFila.Cells("CAN_ID").Tag IsNot Nothing Then
                                mFila.Cells("DCC_CANTIDAD").Value = mConteo / mListCCanchero.Count
                                mFila.Cells("DCC_CANTIDAD").Tag = mConteo / mListCCanchero.Count
                            End If
                        Next

                    Next
                End If
            End If

            txtProduccion.TabIndex = 0
            txtResponsable.TabIndex = 1

        End Sub

        'ingreso de codigo
        Sub LimpiarControles()
            mCC = Nothing
            txtProduccion.Text = String.Empty
            txtProduccion.Tag = Nothing
            txtResponsable.Text = String.Empty
            txtResponsable.Tag = Nothing
            dtpFecha.Value = Today
            dgvDetalle.Rows.Clear()


            '------------------------------------------
            Error_validacion.Clear()
        End Sub
        Private Sub txtProduccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProduccion.DoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            frm.Tabla = "Produccion"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtProduccion.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PRO_Id
                txtProduccion.Text = frm.dgvLista.CurrentRow.Cells(0).Value & " " & frm.dgvLista.CurrentRow.Cells("ART_DESCRIPCION").Value 'Nombres
                Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value 'PRO_ID
                CargarProduccion(key)
                txtResponsable.Text = mProduccion.Personas.PER_NOMBRES & " " & mProduccion.Personas.PER_APE_PAT & " " & mProduccion.Personas.PER_APE_MAT
                txtResponsable.Tag = mProduccion.PER_ID_ING
                If (mCC.ChangeTracker.State = ObjectState.Added) Then 'Si es nuevo
                    dgvDetalle.Rows.Clear()
                    mListCCanchero = BCControlCanchero.GetByPro_Id(mProduccion.PRO_ID)
                    mListCParada = BCControlParada.GetByPro_Id(mProduccion.PRO_ID)

                    For Each mItem In mListCCanchero
                        For Each mCancha In mItem.ControlCancheroDetalle
                            Dim nRow As New DataGridViewRow
                            dgvDetalle.Rows.Add(nRow)
                            If mListCParada.Count > 0 Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CPA_Id").Value = mListCParada(0).CPA_ID
                            If mListCParada.Count > 0 Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CPA_Id").Tag = mListCParada(0).CPA_ID
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAN_ID").Value = mCancha.Cancha.CAN_DESCRIPCION
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAN_ID").Tag = mCancha.CAN_ID
                        Next
                    Next
                End If
            End If
            frm.Dispose()
        End Sub

        Sub CargarProduccion(ByVal PRO_Id As Integer)
            mProduccion = BCProduccion.ProduccionGetById(PRO_Id)
        End Sub

        Private Sub txtResponsable_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResponsable.DoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            frm.Tabla = "Persona"
            frm.Tipo = "Trabajador"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtResponsable.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                txtResponsable.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
            End If
            frm.Dispose()
        End Sub

        Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            Select Case e.ColumnIndex
                Case 1
                    frm.Tabla = "ControlParada"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value  'ENO_Descripcion
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'ENO_Id
                        mConteo = ValidarConteo(dgvDetalle.CurrentCell.Tag)
                        dgvDetalle.CurrentRow.Cells("DCC_CANTIDAD").Value = mConteo
                    End If
                Case 2
                    frm.Tabla = "Cancha"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'ENO_Descripcion
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'ENO_Id
                    End If
                Case 3
                    frm.Tabla = "Secadero"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'ENO_Descripcion
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'ENO_Id
                    End If
            End Select
            frm.Dispose()
        End Sub

        'ingreso de codigo
        Public Overrides Sub OnManGuardar()
            'cod ingresado q llama ala funcion para validar
            If Not validar_controles() Then Exit Sub
            '---------------------------------------------


            If mCC IsNot Nothing Then
                dgvDetalle.EndEdit()
                mCC.CCO_FECHA = dtpFecha.Value
                mCC.PRO_ID = CInt(txtProduccion.Tag)
                mCC.PER_ID_OPERADOR = txtResponsable.Tag

                Total = dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToInt32(row.Cells("DCC_CANTIDAD").Value))

                mCC.CCO_TOTAL_CONTEO = Total
                mCC.CCO_ESTADO = True
                mCC.CCO_FEC_GRAB = Now
                mCC.USU_ID = SessionServer.UserId
                For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                    If Not mDetalle.Cells("DCC_ID").Value Is Nothing Then
                        With CType(mDetalle.Cells("DCC_ID").Tag, ControlConteoDetalle)
                            .CPA_ID = CInt(mDetalle.Cells("CPA_ID").Tag)
                            .CAN_ID = CInt(mDetalle.Cells("CAN_ID").Tag)
                            .DCC_FALTANTES = CInt(mDetalle.Cells("DCC_FALTANTES").Value)
                            .DCC_MALOGRADOS = CInt(mDetalle.Cells("DCC_MALOGRADOS").Value)
                            .DCC_CANTIDAD = CInt(mDetalle.Cells("DCC_CANTIDAD").Value)
                            .MarkAsModified()
                        End With
                    ElseIf Not mDetalle.Cells("DCC_CANTIDAD").Value Is Nothing Then
                        Dim nCCD As New ControlConteoDetalle
                        With nCCD
                            .CPA_ID = CInt(mDetalle.Cells("CPA_ID").Tag)
                            .CAN_ID = CInt(mDetalle.Cells("CAN_ID").Tag)
                            .DCC_FALTANTES = CInt(mDetalle.Cells("DCC_FALTANTES").Value)
                            .DCC_MALOGRADOS = CInt(mDetalle.Cells("DCC_MALOGRADOS").Value)
                            .DCC_CANTIDAD = CInt(mDetalle.Cells("DCC_CANTIDAD").Value)
                            .MarkAsAdded()
                        End With
                        mCC.ControlConteoDetalle.Add(nCCD)
                    End If
                Next

                BCControlConteo.MantenimientoControlConteo(mCC)
                LimpiarControles()
            End If


            '------------------------------------------
            Call validacion_desactivacion(False, 3)
        End Sub

        'ingreso de codigo
        Public Overrides Sub OnManNuevo()
            LimpiarControles()
            mCC = New ControlConteo
            mCC.MarkAsAdded()


            '---------------------------------------
            Call validacion_desactivacion(True, 2)
            txtProduccion.Focus()
        End Sub

        'ingreso de codigo
        Public Overrides Sub OnManBuscar()
            LimpiarControles()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            frm.Tabla = "ControlConteo"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
                CargarControlConteo(key)
                LlenarControles()
                '---------------------------------
                Call validacion_desactivacion(True, 5)
            End If
            frm.Dispose()
        End Sub

        Sub CargarControlConteo(ByVal CCO_Id As Integer)
            mCC = BCControlConteo.ControlConteoGetById(CCO_Id)
            mCC.MarkAsModified()
        End Sub

        Sub LlenarControles()
            dtpFecha.Value = mCC.CCO_FECHA
            txtProduccion.Text = mCC.Produccion.PRO_ID & " " & mCC.Produccion.Ladrillo.Articulos.ART_DESCRIPCION
            txtProduccion.Tag = mCC.PRO_ID
            txtResponsable.Text = mCC.Personas.PER_NOMBRES & " " & mCC.Personas.PER_APE_PAT & " " & mCC.Personas.PER_APE_MAT
            txtResponsable.Tag = mCC.PER_ID_OPERADOR
            mConteo = mCC.CCO_TOTAL_CONTEO
            For Each mItem In mCC.ControlConteoDetalle
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCC_ID").Value = mItem.DCC_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCC_ID").Tag = mItem
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CPA_Id").Value = mItem.CPA_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CPA_Id").Tag = mItem.CPA_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAN_ID").Value = mItem.Cancha.CAN_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAN_ID").Tag = mItem.CAN_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCC_FALTANTES").Value = mItem.DCC_FALTANTES
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCC_MALOGRADOS").Value = mItem.DCC_MALOGRADOS
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCC_CANTIDAD").Value = mItem.DCC_CANTIDAD
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCC_CANTIDAD").Tag = mItem.DCC_CANTIDAD
            Next
        End Sub


        '===================================================================================================================
        '----procedimiento de validaciones
        'tecla enter de paso rapido entre cajas de texto.

        'validamos los campos a llenar
        Function validar_controles()
            'aqui se ingresara los objetos del formulario a validar
            Dim flag As Boolean = True

            Error_validacion.Clear()
            If Len(txtProduccion.Text.Trim) = 0 Then Error_validacion.SetError(txtProduccion, "Ingrese la Producción") : txtProduccion.Focus() : flag = False
            If Len(txtResponsable.Text.Trim) = 0 Then Error_validacion.SetError(txtResponsable, "Ingrese el Nombre del Responsable") : txtResponsable.Focus() : flag = False

            Dim Lista1 = From mGrid As DataGridViewRow In dgvDetalle.Rows Group mGrid By CpaId = mGrid.Cells("CPA_ID").Value Into Gpr = Group _
                         Select CpaId, Cantidad = Gpr.Sum(Function(mgrid) CDec(mgrid.Cells("DCC_CANTIDAD").Value))

            For Each mItem In Lista1.ToList
                mConteo = ValidarConteo(mItem.CpaId)
                If mItem.Cantidad > mConteo Then
                    Error_validacion.SetError(txtResponsable, "El Conteo esta por encima de lo computado.") : dgvDetalle.Focus() : flag = False
                    Exit For
                End If
            Next

            If flag = False Then
                MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Return flag

        End Function

        'validamos la longitud de los campos.
        Private Sub validar_longitud()
            Me.txtProduccion.MaxLength = 160
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
            If mCC IsNot Nothing Then
                For Each mItem In mCC.ControlConteoDetalle
                    mItem.MarkAsDeleted()
                Next
                mCC.MarkAsDeleted()
                BCControlConteo.MantenimientoControlConteo(mCC)
                Call LimpiarControles()
                Call validacion_desactivacion(False, 7)
            End If
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

        Private Sub txtProduccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProduccion.KeyDown
            If e.KeyCode = Keys.Enter Then txtProduccion_DoubleClick(Nothing, Nothing)
        End Sub

        Private Sub txtResponsable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResponsable.KeyDown
            'MsgBox(e.KeyCode)
            If e.KeyCode = Keys.Enter Then txtResponsable_DoubleClick(Nothing, Nothing)
        End Sub

        Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
            Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
                Case "DCC_FALTANTES", "DCC_MALOGRADOS"
                    CType(sender, DataGridView).CurrentRow.Cells("DCC_CANTIDAD").Value = CInt(CType(sender, DataGridView).CurrentRow.Cells("DCC_CANTIDAD").Tag) - CInt((CType(sender, DataGridView).CurrentRow.Cells("DCC_MALOGRADOS").Value) + CInt(CType(sender, DataGridView).CurrentRow.Cells("DCC_FALTANTES").Value))
                Case "DCC_CANTIDAD"
                    CType(sender, DataGridView).CurrentRow.Cells("DCC_CANTIDAD").Tag = CType(sender, DataGridView).CurrentRow.Cells("DCC_CANTIDAD").Value
            End Select
        End Sub

        Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
            If dgvDetalle.CurrentCell.ColumnIndex = 1 And e.KeyCode = Keys.Enter Then
                frm.Tabla = "ControlParada"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value  'ENO_Descripcion
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'ENO_Id
                    mConteo = ValidarConteo(dgvDetalle.CurrentCell.Tag)
                    dgvDetalle.CurrentRow.Cells("DCC_CANTIDAD").Value = mConteo
                End If
            ElseIf dgvDetalle.CurrentCell.ColumnIndex = 2 And e.KeyCode = Keys.Enter Then
                frm.Tabla = "Cancha"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'ENO_Descripcion
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'ENO_Id
                End If
            ElseIf dgvDetalle.CurrentCell.ColumnIndex = 3 And e.KeyCode = Keys.Enter Then
                frm.Tabla = "Secadero"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'ENO_Descripcion
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'ENO_Id
                End If
            End If
            frm.Dispose()
        End Sub

        Function ValidarConteo(ByVal CPA_ID As Integer) As Integer
            Dim vConteo As Integer = 0
            vConteo = BCControlConteo.ValidarConteo(CPA_ID)
            Return vConteo
        End Function

    End Class
End Namespace