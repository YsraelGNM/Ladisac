Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing


Namespace Ladisac.Logistica.Views

    Public Class frmOrdenRequerimiento
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCOrdenRequerimiento As Ladisac.BL.IBCOrdenRequerimiento
        <Dependency()> _
        Public Property BCOrdenTrabajo As Ladisac.BL.IBCOrdenTrabajo
        <Dependency()> _
        Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
        <Dependency()> _
        Public Property BCArticulo As Ladisac.BL.IBCArticulo
        <Dependency()> _
        Public Property BCEntidad As Ladisac.BL.IBCEntidad
        <Dependency()> _
        Public Property BCArticuloAlmacen As Ladisac.BL.IBCArticuloAlmacen
        <Dependency()> _
        Public Property BCParametro As Ladisac.BL.IBCParametro
        <Dependency()>
        Public Property BCPermisoUsuario As Ladisac.BL.BCPermisoUsuario
        <Dependency()>
        Public Property BCDatosUsuarios As Ladisac.BL.BCDatosUsuarios

        Public mOR As OrdenRequerimiento
        Public FlagOT As Boolean = False
        Protected mArticuloAlmacen As ArticuloAlmacen
        Dim Arti As Articulos

        'Para impresion
        Dim mNuevaPag As Integer
        Dim mIndexItem As Integer
        Dim mCantLinea As Integer

        Dim frmInputBox As New frmInputBox
        Public Consulta As Boolean


        'ingreso de codigo
        Private Sub frmOrdenRequerimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If FlagOT = False Then
                LimpiarControles()

                '==========================================================================
                'se llama al procedimiento de paso rapido entre cajas de texto.
                'se declara los objetos.---------    1->tipo textbox     2->combo

                Call validar_longitud()
                Call validacion_desactivacion(False, 1)
            End If


            If mOR IsNot Nothing Then
                If mOR.ORR_ID > 0 Then LlenarControles()
                '---------------------------------
                Call validacion_desactivacion(True, 5)
            End If


            txtCodigo.TabIndex = 7
            dtpFecha.TabIndex = 1
            dtpFechaMax.TabIndex = 2
            txtSolicitado.TabIndex = 3
            cboImportancia.TabIndex = 4
            chkNuevo.TabIndex = 5
            dgvDetalle.TabIndex = 6

        End Sub

        'ingreso de codigo
        Sub LimpiarControles()
            mOR = Nothing
            mArticuloAlmacen = Nothing
            Art = Nothing
            FlagOT = False

            txtCodigo.Text = String.Empty
            txtSolicitado.Text = String.Empty
            txtSolicitado.Tag = Nothing
            txtAutorizado.Text = String.Empty
            txtAutorizado.Tag = Nothing
            cboImportancia.SelectedIndex = 2
            dtpFecha.Value = Now
            dtpFechaMax.Value = Now
            dtpTiempo.Value = Date.Now
            chkNuevo.Checked = False
            chkLadrillo.Checked = False
            chkCerrada.Checked = False
            CambiarORLadrillo()
            dgvDetalle.Rows.Clear()


            '--------------------------
            Error_Validacion.Clear()
        End Sub

        Private Sub txtSolicitado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSolicitado.DoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
            frm.Tabla = "Persona"
            frm.Tipo = "Trabajador"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtSolicitado.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                txtSolicitado.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
            End If
            frm.Dispose()
        End Sub

        Private Sub txtAutorizado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAutorizado.DoubleClick
            'If Not chkLadrillo.Checked Then
            '    Try
            '        Dim Her = ContainerService.Resolve(Of Herramientas)()
            '        For Each mItem As DataGridViewRow In dgvDetalle.Rows
            '            If Her.PermisoEntidad(mItem.Cells("ENO_ID").Tag) = False Then
            '                MessageBox.Show("No le corresponde esta area.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '                Exit Sub
            '            End If
            '        Next

            '        If SessionServer.UserId <> "ADMIN" Then
            '            If frmInputBox.ShowDialog = Windows.Forms.DialogResult.OK Then
            '                If Not frmInputBox.txtPassword.Text = BCParametro.ParametroGetById(SessionServer.UserId & "PermReq").PAR_VALOR1 Then
            '                    MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
            '                    Exit Sub
            '                End If
            '            Else
            '                MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
            '                Exit Sub
            '            End If
            '        End If

            '        Dim DAU As DatosUsuarios
            '        DAU = BCDatosUsuarios.GetByIdByUSU(SessionServer.UserId)
            '        txtAutorizado.Tag = DAU.PER_ID  'Per_Id
            '        txtAutorizado.Text = DAU.Personas.PER_APE_PAT & " " & DAU.Personas.PER_APE_MAT & " " & DAU.Personas.PER_NOMBRES  'Nombres
            '    Catch ex As Exception
            '        MessageBox.Show(ex.Message)
            '        MessageBox.Show("Error al momento de autorizar.")
            '        Exit Sub
            '    End Try

            'Else 'Cuando se pide ladrillo
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
            frm.Tabla = "Persona"
            frm.Tipo = "Trabajador"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtAutorizado.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
                txtAutorizado.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
            End If
            frm.Dispose()
            'End If
        End Sub

        Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
            Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
                Case "OT"
                    frm.Tabla = "OrdenTrabajoOR"
                    frm.Tipo = dgvDetalle.CurrentCell.Value
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value  'OTR_Id

                        dgvDetalle.CurrentCell.Tag = BCOrdenTrabajo.OrdenTrabajoGetById(dgvDetalle.CurrentCell.Value)
                        dgvDetalle.CurrentRow.Cells("ENO_ID").Value = frm.dgvLista.CurrentRow.Cells(1).Value 'Entidad
                        dgvDetalle.CurrentRow.Cells("ENO_ID").Tag = CType(dgvDetalle.CurrentCell.Tag, OrdenTrabajo).ENO_ID
                        dgvDetalle.CurrentRow.Cells("Mantenimiento").Value = frm.dgvLista.CurrentRow.Cells(2).Value 'Mantto
                        dgvDetalle.CurrentRow.Cells("Mantenimiento").Tag = CType(dgvDetalle.CurrentCell.Tag, OrdenTrabajo).MTO_ID
                    End If
                Case "ENO_ID"
                    frm.Tabla = "EntidadOT"
                    frm.Tipo = dgvDetalle.CurrentRow.Cells("OT").Value
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value  'ENO_DESCRIPCION
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(2).Value 'ENO_ID
                        dgvDetalle.CurrentRow.Cells("Mantenimiento").Value = frm.dgvLista.CurrentRow.Cells(1).Value 'Mantto
                        dgvDetalle.CurrentRow.Cells("Mantenimiento").Tag = frm.dgvLista.CurrentRow.Cells(3).Value 'Mantto
                    End If
                Case "Art"
                    If dgvDetalle.CurrentRow.Cells("CantAtendida").Value > 0 Then Exit Sub
                    If dgvDetalle.CurrentRow.Cells("ORD_ID").Tag IsNot Nothing Then If CType(dgvDetalle.CurrentRow.Cells("ORD_ID").Tag, OrdenRequerimientoDetalle).ORD_ESTADO_COMPRA = "CS" Then MessageBox.Show("El item ya esta consolidado.") : Exit Sub
                    frm.Tabla = "ArticuloOTSumins"
                    frm.Tipo = dgvDetalle.CurrentRow.Cells("ENO_ID").Tag
                    frm.Tipo2 = dgvDetalle.CurrentRow.Cells("Mantenimiento").Tag
                    frm.Art_Id = dgvDetalle.CurrentRow.Cells("Art").Value
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " " & frm.dgvLista.CurrentRow.Cells(2).Value 'ART_Descripcion
                        dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(3).Value 'UnidadMedida

                        'Dim Lista1 = From mGrid As DataGridViewRow In frm.dgvLista.Rows Where mGrid.Cells(0).Value = dgvDetalle.CurrentCell.Tag And mGrid.Cells(4).Value.ToString.Contains("Suministro") _
                        '             Select mGrid
                        'dgvDetalle.CurrentRow.Cells("UM").Tag = Lista1.Sum(Function(x As DataGridViewRow) x.Cells("Stock").Value)
                    End If
                Case "ALM_ID"
                    If dgvDetalle.CurrentRow.Cells("CantAtendida").Value > 0 Then Exit Sub
                    frm.Tabla = "ArticuloAlmacen"
                    frm.Art_Id = dgvDetalle.CurrentRow.Cells("Art").Tag
                    frm.Alm_Id = Nothing
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        CargarArticuloAlmacen(frm.dgvLista.CurrentRow.Cells(0).Value)
                        dgvDetalle.CurrentCell.Tag = mArticuloAlmacen.ALM_ID  'ALM_Id
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(3).Value 'ALM_Descripcion
                    End If
            End Select
            frm.Dispose()
        End Sub

        Sub CargarArticuloAlmacen(ByVal ARA_Id As Integer)
            mArticuloAlmacen = BCArticuloAlmacen.ArticuloAlmacenGetById(ARA_Id)
        End Sub

        'ingreso de codigo
        Public Overrides Sub OnManGuardar()
            If Consulta Then Exit Sub
            'cod ingresado q llama ala funcion para validar
            If Not validar_controles() Then Exit Sub
            '----------------------------------------------------

            If mOR IsNot Nothing Then
                dgvDetalle.EndEdit()
                mOR.ORR_FECHA = dtpFecha.Value
                mOR.ORR_FEC_MAX_ENTREGA = dtpFechaMax.Value
                mOR.PER_ID_SOLICITADO = txtSolicitado.Tag
                mOR.PER_ID_AUTORIZADO = txtAutorizado.Tag
                mOR.ORR_IMPORTANCIA = cboImportancia.SelectedIndex
                If chkCerrada.Checked Then mOR.ORR_CERRADA = 1 Else mOR.ORR_CERRADA = 0

                mOR.ORR_ESTADO = True
                mOR.ORR_FEC_GRAB = Now
                mOR.USU_ID = SessionServer.UserId
                For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                    If Not mDetalle.Cells("ORD_ID").Value Is Nothing Then
                        With CType(mDetalle.Cells("ORD_ID").Tag, OrdenRequerimientoDetalle)
                            .ORD_ID = CInt(mDetalle.Cells("ORD_ID").Value)
                            If CInt(mDetalle.Cells("OT").Value) > 0 Then .OTR_ID = CInt(mDetalle.Cells("OT").Value)
                            .ART_ID = mDetalle.Cells("ART").Tag
                            .ORD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                            .ORD_CANTIDAD_ATENDIDA = CDec(mDetalle.Cells("CantAtendida").Value)
                            .ORD_OBSERVACION = mDetalle.Cells("Observacion").Value
                            .ALM_ID = mDetalle.Cells("ALM_ID").Tag
                            If CInt(mDetalle.Cells("ENO_ID").Tag) > 0 Then .ENO_ID = CInt(mDetalle.Cells("ENO_ID").Tag)
                            If mDetalle.Cells("ORD_CONFORMIDAD").Value IsNot Nothing Then If mDetalle.Cells("ORD_CONFORMIDAD").Value Then .ORD_CONFORMIDAD = 1 Else .ORD_CONFORMIDAD = 0

                            'If txtAutorizado.Tag IsNot Nothing Then
                            '    If BCArticuloAlmacen.TotalStock(mDetalle.Cells("ART").Tag) - CDec(mDetalle.Cells("Cantidad").Value) < 0 Then
                            '        .ORD_ESTADO_COMPRA = "PC"
                            '        .ORD_OBS_COMPRA = "Automatico"
                            '        .ORD_CANTIDAD_COMPRA = Math.Abs(BCArticuloAlmacen.TotalStock(mDetalle.Cells("ART").Tag) - CDec(mDetalle.Cells("Cantidad").Value))
                            '    End If
                            'End If

                            .MarkAsModified()
                        End With
                    ElseIf Not mDetalle.Cells("Cantidad").Value Is Nothing Then
                        Dim nORD As New OrdenRequerimientoDetalle
                        With nORD
                            If CInt(mDetalle.Cells("OT").Value) > 0 Then .OTR_ID = CInt(mDetalle.Cells("OT").Value)
                            .ART_ID = mDetalle.Cells("ART").Tag
                            .ORD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                            .ORD_CANTIDAD_ATENDIDA = CDec(mDetalle.Cells("CantAtendida").Value)
                            .ORD_OBSERVACION = mDetalle.Cells("Observacion").Value
                            .ALM_ID = mDetalle.Cells("ALM_ID").Tag
                            If CInt(mDetalle.Cells("ENO_ID").Tag) > 0 Then .ENO_ID = CInt(mDetalle.Cells("ENO_ID").Tag)
                            If mDetalle.Cells("ORD_CONFORMIDAD").Value IsNot Nothing Then If mDetalle.Cells("ORD_CONFORMIDAD").Value Then .ORD_CONFORMIDAD = 1 Else .ORD_CONFORMIDAD = 0

                            'If txtAutorizado.Tag IsNot Nothing Then
                            '    If BCArticuloAlmacen.TotalStock(mDetalle.Cells("ART").Tag) - CDec(mDetalle.Cells("Cantidad").Value) < 0 Then
                            '        .ORD_ESTADO_COMPRA = "PC"
                            '        .ORD_OBS_COMPRA = "Automatico"
                            '        .ORD_CANTIDAD_COMPRA = Math.Abs(BCArticuloAlmacen.TotalStock(mDetalle.Cells("ART").Tag) - CDec(mDetalle.Cells("Cantidad").Value))
                            '    End If
                            'End If

                            .MarkAsAdded()
                        End With
                        mOR.OrdenRequerimientoDetalle.Add(nORD)
                    End If
                Next

                If BCOrdenRequerimiento.MantenimientoOrdenRequerimiento(mOR) = 1 Then
                    MessageBox.Show(mOR.ORR_ID)
                    mOR = BCOrdenRequerimiento.OrdenRequerimientoGetById(mOR.ORR_ID)
                    OnReportes()
                    If chkLadrillo.Checked Then BCOrdenRequerimiento.EnviarCorreoPermisoCargaSinDocumento(mOR.ORR_ID)
                    LimpiarControles()
                Else
                    MessageBox.Show("Error al insertar.")
                    LimpiarControles()
                    Exit Sub
                End If


                '------------------------------------------
                Call validacion_desactivacion(False, 3)
            End If
        End Sub

        'ingreso de codigo
        Public Overrides Sub OnManNuevo()
            LimpiarControles()
            mOR = New OrdenRequerimiento
            mOR.MarkAsAdded()

            '---------------------------------------
            Call validacion_desactivacion(True, 2)
            txtSolicitado.Focus()
        End Sub

        'ingreso de codigo
        Public Overrides Sub OnManBuscar()
            LimpiarControles()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
            frm.Tabla = "OrdenRequerimiento"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
                CargarOrdenRequerimiento(key)
                LlenarControles()
                '---------------------------------
                Call validacion_desactivacion(True, 5)

            End If
            frm.Dispose()
        End Sub

        Sub CargarOrdenRequerimiento(ByVal ORR_Id As Integer)
            mOR = BCOrdenRequerimiento.OrdenRequerimientoGetById(ORR_Id)
            mOR.MarkAsModified()
        End Sub

        Sub LlenarControles()
            txtCodigo.Text = mOR.ORR_ID
            dtpFecha.Value = mOR.ORR_FECHA
            dtpFechaMax.Value = mOR.ORR_FEC_MAX_ENTREGA
            txtSolicitado.Text = mOR.Personas.PER_APE_PAT & " " & mOR.Personas.PER_APE_MAT
            txtSolicitado.Tag = mOR.PER_ID_SOLICITADO
            If mOR.Personas1 IsNot Nothing Then txtAutorizado.Text = mOR.Personas1.PER_APE_PAT & " " & mOR.Personas1.PER_APE_MAT & " " & mOR.Personas1.PER_NOMBRES
            If mOR.Personas1 IsNot Nothing Then txtAutorizado.Tag = mOR.PER_ID_AUTORIZADO
            cboImportancia.SelectedIndex = mOR.ORR_IMPORTANCIA
            If mOR.ORR_CERRADA = 1 Then chkCerrada.Checked = True Else chkCerrada.Checked = False


            For Each mItem In mOR.OrdenRequerimientoDetalle
                If mItem.ENO_ID = 0 Then chkLadrillo.Checked = True : CambiarORLadrillo()
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ORD_ID").Value = mItem.ORD_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ORD_ID").Tag = mItem
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("OT").Value = mItem.OTR_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ENO_ID").Value = mItem.Entidad.ENO_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ENO_ID").Tag = mItem.ENO_ID
                If mItem.ENO_ID <> 0 Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Mantenimiento").Value = mItem.OrdenTrabajo.Mantto.MTO_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art").Value = mItem.Articulos.ART_Codigo & " - " & mItem.Articulos.ART_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art").Tag = mItem.ART_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("UM").Value = mItem.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value = mItem.ORD_CANTIDAD
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CantAtendida").Value = mItem.ORD_CANTIDAD_ATENDIDA
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Observacion").Value = mItem.ORD_OBSERVACION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID").Tag = mItem.ALM_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID").Value = mItem.ALM_ID
                If mItem.ORD_CONFORMIDAD IsNot Nothing Then
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ORD_CONFORMIDAD").Value = IIf(mItem.ORD_CONFORMIDAD = 1, True, False)
                End If

                If mItem.ORD_CANTIDAD_ATENDIDA > 0 Or (mItem.ORD_ESTADO_COMPRA & "").ToString = "CS" Or (mItem.USU_ID_AUT & "").ToString <> "" Then
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).ReadOnly = True
                End If

            Next
            '''''Para saber quien lo hizo
            Dim Hecho As Usuarios
            Hecho = BCPermisoUsuario.UsuarioGetById(mOR.USU_ID)
            lblHecho.Text = "Hecho por: " & Hecho.USU_DESCRIPCION
        End Sub

        Private Sub chkNuevo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNuevo.CheckedChanged
            If chkNuevo.Checked Then
                mOR = New OrdenRequerimiento
                mOR.MarkAsAdded()
                For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                    mDetalle.ReadOnly = False
                    mDetalle.Cells("ORD_ID").Value = Nothing
                    mDetalle.Cells("ORD_ID").Tag = Nothing
                    mDetalle.Cells("OT").Value = Nothing
                    mDetalle.Cells("OT").Tag = Nothing
                    mDetalle.Cells("ALM_ID").Value = Nothing
                    mDetalle.Cells("ALM_ID").Tag = Nothing
                    mDetalle.Cells("CantAtendida").Value = 0
                Next
                dtpFecha.Value = Today
                dtpFechaMax.Value = Today
                txtAutorizado.Text = String.Empty
                txtAutorizado.Tag = Nothing
            Else
                LimpiarControles()
            End If
        End Sub

        Public Sub CargarDeOT(ByVal mLista As Array)
            For Each mItem In mLista
                Arti = BCArticulo.ArticuloGetById(mItem.Art_Id)
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art").Value = Arti.ART_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art").Tag = Arti.ART_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("UM").Value = Arti.UnidadMedidaArticulos.UM_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value = mItem.Cantidad
            Next
        End Sub

        'validamos los campos a llenar
        Function validar_controles()
            Dim flag As Boolean = True

            Error_Validacion.Clear()

            If Len(dtpFecha.Text.Trim) = 0 Then Error_Validacion.SetError(dtpFecha, "Ingrese la Fecha") : dtpFecha.Focus() : flag = False
            If Len(dtpTiempo.Text.Trim) = 0 Then Error_Validacion.SetError(dtpTiempo, "Ingrese la Hora") : dtpTiempo.Focus() : flag = False
            If Len(dtpFechaMax.Text.Trim) = 0 Then Error_Validacion.SetError(dtpFechaMax, "Ingrese la Fecha Maxima") : dtpFechaMax.Focus() : flag = False
            If Len((txtSolicitado.Tag & "").Trim) = 0 Then Error_Validacion.SetError(txtSolicitado, "Ingrese el Nombre de la Persona Solicitante") : txtSolicitado.Focus() : flag = False
            'If Len(txtAutorizado.Text.Trim) = 0 Then Error_Validacion.SetError(txtAutorizado, "Ingrese el Nombre de la Persona Autorizante") : txtAutorizado.Focus() : flag = False 'No va autorizado en Requerimiento
            If Len(cboImportancia.Text.Trim) = 0 Then Error_Validacion.SetError(cboImportancia, "Escoja la Importancia") : cboImportancia.Focus() : flag = False

            If dgvDetalle.RowCount = 0 Then
                MessageBox.Show("No hay detalle, agrege uno.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                flag = False
            End If


            Dim Her = ContainerService.Resolve(Of Herramientas)()
            For Each mItem As DataGridViewRow In dgvDetalle.Rows
                If mItem.Cells("ART").Tag Is Nothing OrElse mItem.Cells("ART").Tag = "" Then
                    MessageBox.Show("Falta agregar un Articulo.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    flag = False
                Else
                    Arti = BCArticulo.ArticuloGetById(mItem.Cells("ART").Tag)
                    If BCParametro.ParametroGetById("ArtTransf").PAR_VALOR2.Contains("/" & Arti.ART_Codigo.Substring(3, 3) & "/") Then
                        If mItem.Cells("ALM_ID").Tag Is Nothing Then
                            MessageBox.Show("Falta agregar Almacen Destino.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            flag = False
                        End If
                    End If
                End If

                If mItem.Cells("Cantidad").Value Is Nothing OrElse mItem.Cells("Cantidad").Value = 0 Then
                    MessageBox.Show("Falta la Cantidad.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    flag = False
                End If

                If Not chkLadrillo.Checked Then
                    If mItem.Cells("OT").Value Is Nothing Then
                        MessageBox.Show("Falta la Orden de Trabajo.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        flag = False
                    End If
                    If Her.PermisoEntidad(mItem.Cells("ENO_ID").Tag) = False Then
                        MessageBox.Show("No le corresponde esta area.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        flag = False
                    End If
                    'If mItem.Cells("ORD_ID").Tag IsNot Nothing Then
                    '    If CType(mItem.Cells("ORD_ID").Tag, OrdenRequerimientoDetalle).ORD_CANTIDAD_ATENDIDA > 0 Or (CType(mItem.Cells("ORD_ID").Tag, OrdenRequerimientoDetalle).ORD_ESTADO_COMPRA & "").ToString = "CS" Then
                    '        MessageBox.Show("No se puede guardar el Requerimiento, porque ya fue procesado por Logistica.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '        flag = False
                    '    End If
                    'End If
                End If
            Next


            If flag = False Then
                MessageBox.Show("Debe de ingresar datos en los campos seleccionados", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Return flag

        End Function

        'validamos la longitud de los campos.
        Private Sub validar_longitud()
            Me.txtSolicitado.MaxLength = 160
            Me.txtAutorizado.MaxLength = 160
            Me.cboImportancia.DropDownStyle = ComboBoxStyle.DropDownList
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
            If Not validar_controles() Then Exit Sub
            For Each mItem In mOR.OrdenRequerimientoDetalle
                If mItem.ORD_CANTIDAD_ATENDIDA > 0 Or mItem.ORD_ESTADO_COMPRA & "" = "CS" Then
                    MessageBox.Show("No se puede eliminar la O.R. por que hay Items atendidos o consolidados.")
                    Exit Sub
                End If
            Next
            For Each mItem In mOR.OrdenRequerimientoDetalle
                mItem.MarkAsDeleted()
            Next
            mOR.MarkAsDeleted()
            If BCOrdenRequerimiento.MantenimientoOrdenRequerimiento(mOR) = 1 Then
                Call LimpiarControles()
                Call validacion_desactivacion(False, 7)
            Else
                MessageBox.Show("Error al eliminar.")
                Exit Sub
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
                chkLadrillo.Enabled = True

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

                chkLadrillo.Enabled = False
            End If
        End Sub

        Public Overrides Sub OnReportes()
            If mOR IsNot Nothing Then
                If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Try
                        mNuevaPag = 0
                        mIndexItem = 0
                        If MessageBox.Show("El tamaño del papel es pequeño?", "Atencion", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                            mCantLinea = 7
                            Dim pkCustomSize1 As New System.Drawing.Printing.PaperSize("Custom Paper Size", 900, 550)
                            PrintDocument1.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1
                            PrintDocument1.DefaultPageSettings.PaperSize = pkCustomSize1
                            PrintDocument1.PrinterSettings.DefaultPageSettings.Landscape = True
                        Else
                            For Each SupportedPaperSize As PaperSize In PrintDocument1.PrinterSettings.PaperSizes
                                If SupportedPaperSize.Kind = PaperKind.A4 Then
                                    mCantLinea = 20
                                    PrintDocument1.PrinterSettings.DefaultPageSettings.PaperSize = SupportedPaperSize
                                    PrintDocument1.DefaultPageSettings.PaperSize = SupportedPaperSize
                                    PrintDocument1.PrinterSettings.DefaultPageSettings.Landscape = False
                                    Exit For
                                End If
                            Next
                        End If
                        PrintDocument1.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(2, 2, 10, 10)
                        PrintDocument1.Print()
                    Catch ex As Exception
                        MessageBox.Show("No hay impresora activa", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End Try
                End If
            End If
        End Sub

        Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
            Dim ft As New System.Drawing.Font("Courier New", 10, FontStyle.Regular)
            Dim ft8 As New System.Drawing.Font("Courier New", 8, FontStyle.Regular)
            Dim ftN As New System.Drawing.Font("Courier New", 10, FontStyle.Bold)
            Dim ftS As New System.Drawing.Font("Courier New", 10, FontStyle.Underline)
            Dim ftCB As New System.Drawing.Font("Bar-Code 39", 36, FontStyle.Regular)
            Dim ftFirma As New System.Drawing.Font("Draft 10cpi", 7, FontStyle.Bold)

            e.Graphics.DrawString(SessionServer.NombreEmpresa, ftN, Brushes.Black, 50, 30)
            e.Graphics.DrawString("ORDEN DE REQUERIMIENTO NRO.: " & mOR.ORR_ID, ftN, Brushes.Black, 50, 50)
            e.Graphics.DrawString("Fecha O.R.", ftN, Brushes.Black, 400, 50)
            e.Graphics.DrawString(": " & mOR.ORR_FECHA, ftN, Brushes.Black, 550, 50)

            e.Graphics.DrawString("Fecha Max Entrega", ftN, Brushes.Black, 400, 70)
            e.Graphics.DrawString(": " & mOR.ORR_FEC_MAX_ENTREGA, ftN, Brushes.Black, 550, 70)

            e.Graphics.DrawString("Solicitado por", ftN, Brushes.Black, 50, 90)
            e.Graphics.DrawString(": " & mOR.Personas.PER_NOMBRES & " " & mOR.Personas.PER_APE_PAT, ft, Brushes.Black, 220, 90)

            e.Graphics.DrawString("Tipo Importancia", ftN, Brushes.Black, 50, 105)
            Select Case mOR.ORR_IMPORTANCIA
                Case 0
                    e.Graphics.DrawString(": A", ft, Brushes.Black, 220, 105)
                Case 1
                    e.Graphics.DrawString(": B", ft, Brushes.Black, 220, 105)
                Case 2
                    e.Graphics.DrawString(": C", ft, Brushes.Black, 220, 105)
                Case 3
                    e.Graphics.DrawString(": D", ft, Brushes.Black, 220, 105)
                Case 4
                    e.Graphics.DrawString(": E", ft, Brushes.Black, 220, 105)
            End Select


            e.Graphics.DrawString("Prioridad de Compra : ", ftN, Brushes.Black, 50, 120)
            e.Graphics.DrawString("| 1 | 2 | 3 |", ftS, Brushes.Black, 230, 120)


            e.Graphics.DrawLine(Pens.Black, 50, 143, 800, 143)

            e.Graphics.DrawString("Codigo", ftN, Brushes.Black, 50, 143)
            e.Graphics.DrawString("Descripcion", ftN, Brushes.Black, 150, 143)
            e.Graphics.DrawString("Und.", ftN, Brushes.Black, 640, 143)
            e.Graphics.DrawString("Cant.", ftN, Brushes.Black, 690, 143)
            e.Graphics.DrawString("Aten.", ftN, Brushes.Black, 740, 143)

            e.Graphics.DrawLine(Pens.Black, 50, 157, 800, 157)

            Dim altu As Integer = -25
            Dim mOt As Integer = 0

            If mNuevaPag = mCantLinea Then mNuevaPag = 0 'Para imprimir varias paginas
            Dim mItem As Object
            Dim mORDetalle = From mORD In mOR.OrdenRequerimientoDetalle Order By mORD.OTR_ID Select mORD

            For mFila = mIndexItem To mORDetalle.ToList.Count - 1
                mItem = mORDetalle(mFila)
                mNuevaPag += 1 'Para imprimir varias paginas
                altu += 16

                If Not mOt = mItem.OTR_ID Then
                    altu += 8
                    e.Graphics.DrawString("O.T.", ftN, Brushes.Black, 50, 175 + altu)
                    e.Graphics.DrawString(mItem.OTR_ID, ft, Brushes.Black, 100, 175 + altu)
                    e.Graphics.DrawString("Horom.", ftN, Brushes.Black, 150, 175 + altu)
                    e.Graphics.DrawString(mItem.OrdenTrabajo.OTR_HORO_FINAL, ft, Brushes.Black, 210, 175 + altu)
                    e.Graphics.DrawString("Destino", ftN, Brushes.Black, 300, 175 + altu)
                    e.Graphics.DrawString(mItem.OrdenTrabajo.Entidad.ENO_Ruta.Substring(0, IIf(mItem.OrdenTrabajo.Entidad.ENO_RUTA.Length > 60, 60, mItem.OrdenTrabajo.Entidad.ENO_RUTA.Length)), ft8, Brushes.Black, 380, 175 + altu)
                    altu += 16
                    If mItem.OrdenTrabajo.Entidad.ENO_RUTA.Length > 60 Then
                        e.Graphics.DrawString(mItem.OrdenTrabajo.Entidad.ENO_Ruta.Substring(60, IIf(mItem.OrdenTrabajo.Entidad.ENO_RUTA.Length > 170, 110, mItem.OrdenTrabajo.Entidad.ENO_RUTA.Length - 60)), ft8, Brushes.Black, 50, 175 + altu)
                        altu += 16
                    End If
                    If mItem.OrdenTrabajo.Entidad.ENO_RUTA.Length > 170 Then
                        e.Graphics.DrawString(mItem.OrdenTrabajo.Entidad.ENO_RUTA.Substring(170, IIf(mItem.OrdenTrabajo.Entidad.ENO_RUTA.Length > 280, 110, mItem.OrdenTrabajo.Entidad.ENO_RUTA.Length - 170)), ft8, Brushes.Black, 50, 175 + altu)
                        altu += 16
                    End If
                    If mItem.OrdenTrabajo.Entidad.ENO_RUTA.Length > 280 Then
                        e.Graphics.DrawString(mItem.OrdenTrabajo.Entidad.ENO_RUTA.Substring(280, IIf(mItem.OrdenTrabajo.Entidad.ENO_RUTA.Length > 390, 110, mItem.OrdenTrabajo.Entidad.ENO_RUTA.Length - 280)), ft8, Brushes.Black, 220, 175 + altu)
                        altu += 16
                    End If
                    mOt = mItem.OTR_ID
                    altu += 8
                End If

                e.Graphics.DrawString(mItem.Articulos.ART_Codigo, ft, Brushes.Black, 50, 175 + altu)
                e.Graphics.DrawString(mItem.Articulos.ART_DESCRIPCION.Substring(0, IIf(mItem.Articulos.ART_DESCRIPCION.Length > 56, 56, mItem.Articulos.ART_DESCRIPCION.Length)), ft, Brushes.Black, 150, 175 + altu)
                e.Graphics.DrawString(mItem.Articulos.UnidadMedidaArticulos.UM_SIMBOLO, ft, Brushes.Black, 640, 175 + altu)
                e.Graphics.DrawString(Math.Round(CType(mItem.ORD_CANTIDAD, Double), 2), ft, Brushes.Black, 690, 175 + altu)
                e.Graphics.DrawString(Math.Round(CType(mItem.ORD_CANTIDAD_ATENDIDA, Double), 2), ft, Brushes.Black, 740, 175 + altu)
                If mItem.ORD_OBSERVACION IsNot Nothing Then
                    If mItem.ORD_OBSERVACION.Length > 0 Then
                        If mItem.ORD_OBSERVACION.Length >= 81 Then
                            altu += 16
                            e.Graphics.DrawString("Obs.: " & mItem.ORD_OBSERVACION.Substring(0, 81), ft, Brushes.Black, 50, 175 + altu)
                            Dim cade As String = ""
                            Dim Num As Integer = 168 'Es la cant. de caracteres que voy a imprimir en una linea de la columna observaciones
                            For ie As Integer = 81 To mItem.ORD_OBSERVACION.Length - 1
                                If ie < Num Then
                                    cade += mItem.ORD_OBSERVACION.Chars(ie)
                                ElseIf ie = Num Then
                                    altu += 16
                                    e.Graphics.DrawString(cade, ft, Brushes.Black, 50, 175 + altu)
                                    cade = ""
                                    Num += 87
                                    ie -= 1
                                End If
                            Next
                            If cade.Length > 0 Then
                                altu += 16
                                e.Graphics.DrawString(cade, ft, Brushes.Black, 50, 175 + altu)
                                cade = ""
                            End If
                        Else
                            altu += 16
                            e.Graphics.DrawString("Obs.: " & mItem.ORD_OBSERVACION, ft, Brushes.Black, 50, 175 + altu)
                        End If

                        altu += 16
                    End If
                End If

                If mNuevaPag = mCantLinea Then
                    e.HasMorePages = True
                    mIndexItem = mFila + 1
                    Exit For
                Else
                    e.HasMorePages = False
                End If
            Next
            e.Graphics.DrawString("RESPONSABLE ALMACEN", ftFirma, Brushes.Black, 50, 195 + altu + 90)
            e.Graphics.DrawString("SUPERINTENDENTE/JEFE AREA", ftFirma, Brushes.Black, 230, 195 + altu + 90)
            e.Graphics.DrawString("SOLICITADO POR", ftFirma, Brushes.Black, 460, 195 + altu + 90)
            e.Graphics.DrawString("*" & mOR.ORR_ID.ToString & "*", ftCB, Brushes.Black, 400, 195 + altu + 100)
        End Sub

        Private Sub txtSolicitado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSolicitado.KeyDown
            If e.KeyCode = Keys.Enter Then txtSolicitado_DoubleClick(Nothing, Nothing)
        End Sub

        Private Sub txtAutorizado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAutorizado.KeyDown
            If e.KeyCode = Keys.Enter Then txtAutorizado_DoubleClick(Nothing, Nothing)
        End Sub

        Public Overrides Sub OnManAgregarFilaGrid()
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
        End Sub

        Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
            Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
                Case "ALM_ID"
                    If (dgvDetalle.CurrentCell.Value & "").ToString.Length = 0 And dgvDetalle.CurrentRow.Cells("CantAtendida").Value = 0 Then
                        dgvDetalle.CurrentCell.Value = String.Empty
                        dgvDetalle.CurrentCell.Tag = Nothing
                    End If
            End Select
        End Sub

        Private Sub dgvDetalle_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellLeave
            dgvDetalle.CurrentRow.Cells("ORD_Id").Selected = True
        End Sub

        Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
            If e.KeyCode = Keys.Enter Then
                dgvDetalle_CellDoubleClick(sender, Nothing)
            End If
            'Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
            'If e.KeyCode = Keys.Enter Then
            '    e.Handled = True
            '    Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            '        Case "OT"
            '            frm.Tabla = "OrdenTrabajoOR"
            '            frm.Tipo = dgvDetalle.CurrentCell.Value
            '            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value  'OTR_Id
            '                dgvDetalle.CurrentCell.Tag = BCOrdenTrabajo.OrdenTrabajoGetById(dgvDetalle.CurrentCell.Value)
            '                dgvDetalle.CurrentRow.Cells("ENO_ID").Value = frm.dgvLista.CurrentRow.Cells(1).Value 'Entidad
            '                dgvDetalle.CurrentRow.Cells("ENO_ID").Tag = CType(dgvDetalle.CurrentCell.Tag, OrdenTrabajo).ENO_ID
            '                dgvDetalle.CurrentRow.Cells("Mantenimiento").Value = frm.dgvLista.CurrentRow.Cells(2).Value 'Mantto
            '                dgvDetalle.CurrentRow.Cells("Mantenimiento").Tag = CType(dgvDetalle.CurrentCell.Tag, OrdenTrabajo).MTO_ID
            '            End If
            '        Case "ENO_ID"
            '            frm.Tabla = "EntidadOT"
            '            frm.Tipo = dgvDetalle.CurrentRow.Cells("OT").Value
            '            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value  'ENO_DESCRIPCION
            '                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(2).Value 'ENO_ID
            '                dgvDetalle.CurrentRow.Cells("Mantenimiento").Value = frm.dgvLista.CurrentRow.Cells(1).Value 'Mantto
            '                dgvDetalle.CurrentRow.Cells("Mantenimiento").Tag = frm.dgvLista.CurrentRow.Cells(3).Value 'Mantto
            '            End If
            '        Case "Art"
            '            If dgvDetalle.CurrentRow.Cells("CantAtendida").Value > 0 Then Exit Sub
            '            If dgvDetalle.CurrentRow.Cells("ORD_ID").Tag IsNot Nothing Then If CType(dgvDetalle.CurrentRow.Cells("ORD_ID").Tag, OrdenRequerimientoDetalle).ORD_ESTADO_COMPRA = "CS" Then MessageBox.Show("El item ya esta consolidado.") : Exit Sub
            '            frm.Tabla = "ArticuloOTSumins"
            '            frm.Tipo = dgvDetalle.CurrentRow.Cells("ENO_ID").Tag
            '            frm.Tipo2 = dgvDetalle.CurrentRow.Cells("Mantenimiento").Tag
            '            frm.Art_Id = dgvDetalle.CurrentRow.Cells("Art").Value
            '            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
            '                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " " & frm.dgvLista.CurrentRow.Cells(2).Value 'ART_Descripcion
            '                dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(3).Value 'UnidadMedida
            '            End If
            '        Case "ALM_ID"
            '            If dgvDetalle.CurrentRow.Cells("CantAtendida").Value > 0 Then Exit Sub
            '            frm.Tabla = "ArticuloAlmacen"
            '            frm.Art_Id = dgvDetalle.CurrentRow.Cells("Art").Tag
            '            frm.Alm_Id = Nothing
            '            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '                CargarArticuloAlmacen(frm.dgvLista.CurrentRow.Cells(0).Value)
            '                dgvDetalle.CurrentCell.Tag = mArticuloAlmacen.ALM_ID  'ALM_Id
            '                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(3).Value 'ALM_Descripcion
            '            End If
            '    End Select

            'End If
            'frm.Dispose()
        End Sub

        Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
            If Not e.Row.Cells("ORD_ID").Tag Is Nothing Then
                If CDbl(e.Row.Cells("CantAtendida").Value) > 0 Or CType(e.Row.Cells("ORD_ID").Tag, OrdenRequerimientoDetalle).ORD_ESTADO_COMPRA & "" = "CS" Then
                    e.Cancel = True
                    MessageBox.Show("No se puede eliminar el Item, porque esta atendido o esta consolidado.")
                    Exit Sub
                Else
                    CType(e.Row.Cells("ORD_ID").Tag, OrdenRequerimientoDetalle).MarkAsDeleted()
                End If

            End If
        End Sub

        Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
            If e.KeyCode = Keys.Enter Then
                Dim key As Integer = txtCodigo.Text
                CargarOrdenRequerimiento(key)
                mOR.ORR_FEC_RECIBIDO = Now
                If BCOrdenRequerimiento.MantenimientoOrdenRequerimiento(mOR) = 1 Then
                    CargarOrdenRequerimiento(key)
                    LlenarControles()
                Else
                    MessageBox.Show("Error al registrar hora recibido.")
                    Exit Sub
                End If
                '---------------------------------
                Call validacion_desactivacion(True, 5)
            End If
        End Sub

        Private Sub chkLadrillo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLadrillo.CheckedChanged
            If mOR IsNot Nothing Then
                If mOR.ChangeTracker.State = ObjectState.Added Then
                    CambiarORLadrillo()
                End If
            End If
        End Sub

        Sub CambiarORLadrillo()
            If chkLadrillo.Checked Then
                txtAutorizado.ReadOnly = False
                dgvDetalle.Columns("OT").Visible = False
                dgvDetalle.Columns("ENO_ID").Visible = False
                dgvDetalle.Columns("Mantenimiento").Visible = False
                dgvDetalle.Columns("ALM_ID").Visible = False
                chkLadrillo.Enabled = False
            Else
                txtAutorizado.ReadOnly = True
                dgvDetalle.Columns("OT").Visible = True
                dgvDetalle.Columns("ENO_ID").Visible = True
                dgvDetalle.Columns("Mantenimiento").Visible = True
                dgvDetalle.Columns("ALM_ID").Visible = True
                chkLadrillo.Enabled = False
            End If
        End Sub

        Private Sub Label6_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.DoubleClick
            Try
                If SessionServer.UserId <> "ADMIN" Then
                    If frmInputBox.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If Not frmInputBox.txtPassword.Text = BCParametro.ParametroGetById(SessionServer.UserId & "OR").PAR_VALOR1 Then
                            MessageBox.Show("No ha ingresado una clave valida. Se cancelara el cambio.")
                        Else
                            For Each mR As DataGridViewRow In dgvDetalle.Rows
                                mR.ReadOnly = False
                            Next
                        End If
                    Else
                        MessageBox.Show("No ha ingresado una clave valida. Se cancelara el cambio.")
                    End If
                Else
                    For Each mR As DataGridViewRow In dgvDetalle.Rows
                        mR.ReadOnly = False
                    Next
                End If

            Catch ex As Exception
                MessageBox.Show("No tiene permiso para ejecutar esta accion.")
            End Try
        End Sub

        Private Sub chkCerrada_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCerrada.CheckedChanged
            If mOR IsNot Nothing Then
                If mOR.ChangeTracker.State = ObjectState.Modified Then
                    If mOR.ORR_CERRADA = 0 Then
                        mOR.ORR_CERRADA = IIf(chkCerrada.Checked, 1, 0)
                        If BCOrdenRequerimiento.MantenimientoOrdenRequerimiento(mOR) = 1 Then
                            MessageBox.Show(mOR.ORR_ID)
                            LimpiarControles()
                            validacion_desactivacion(False, 7)
                            Exit Sub
                        Else
                            MessageBox.Show("Error al insertar.")
                            LimpiarControles()
                            validacion_desactivacion(False, 7)
                            Exit Sub
                        End If
                    End If
                End If
            End If
        End Sub
    End Class

End Namespace
