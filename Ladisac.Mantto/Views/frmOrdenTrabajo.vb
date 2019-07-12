Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Namespace Ladisac.Mantto.Views
    Public Class frmOrdenTrabajo
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCOrdenTrabajo As Ladisac.BL.IBCOrdenTrabajo
        <Dependency()> _
        Public Property BCMantto As Ladisac.BL.IBCMantto
        <Dependency()> _
        Public Property BCTpoFalla As Ladisac.BL.IBCTipoFalla
        <Dependency()> _
        Public Property BCTipoClaseMantto As Ladisac.BL.IBCTipoClaseMantto
        <Dependency()> _
        Public Property BCGrupo As Ladisac.BL.IBCGrupo
        <Dependency()> _
        Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
        <Dependency()> _
        Public Property BCParametro As Ladisac.BL.IBCParametro
        <Dependency()>
        Public Property BCPermisoUsuario As Ladisac.BL.BCPermisoUsuario

        Protected mOT As OrdenTrabajo
        Dim query As String
        Dim ds As New DataSet

        'Cuando viene de InspeccionPreOrdenTrabajo
        Public IOT_CodEntidad As Integer
        Public IOT_CodOT As Integer
        Public IOT_DesEntidad As String
        Public IOT_Observacion As String

        Dim frmInputBox As New frmInputBox 

        Private Sub frmOrdenTrabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            llenarCbo()
            LimpiarControles()

            Call validacion_desactivacion(False, 1)

            If Not IOT_CodEntidad = Nothing Then
                OnManNuevo()
                txtEntidad.Tag = IOT_CodEntidad  'ENO_Id
                txtEntidad.Text = IOT_DesEntidad  'Descripcion
                txtObservacion.Text = IOT_Observacion 'Observacion
            End If

            txtCodigo.TabIndex = 23
            txtEntidad.TabIndex = 1
            cboMantenimiento.TabIndex = 2
            cboTipoFalla.TabIndex = 3
            cboClaseMantto.TabIndex = 4
            cboGrupo.TabIndex = 5
            numCriticidad.TabIndex = 6
            dtpFecEmi.TabIndex = 7
            dtpFecIni.TabIndex = 8
            dtpFecTer.TabIndex = 9
            dtpFecMax.TabIndex = 10
            numHrEstim.TabIndex = 11
            numHrReal.TabIndex = 12
            cboFase.TabIndex = 13
            numHoroFinal.TabIndex = 14
            numHoras.TabIndex = 15
            numToneladas.TabIndex = 16
            dtpFechaIngreso.TabIndex = 17
            NumHoroInicial.TabIndex = 18
            txtEmitido.TabIndex = 19
            txtSolicitado.TabIndex = 20
            txtAutorizado.TabIndex = 21
            txtObservacion.TabIndex = 22
            Me.ReportViewer1.RefreshReport()
        End Sub

        Sub LimpiarControles()
            mOT = Nothing
            txtCodigo.Text = String.Empty
            txtEntidad.Text = String.Empty
            txtEntidad.Tag = Nothing
            cboMantenimiento.SelectedIndex = -1
            cboTipoFalla.SelectedIndex = -1
            cboClaseMantto.SelectedIndex = -1
            cboGrupo.SelectedIndex = -1
            numCriticidad.Value = 0
            dtpFecEmi.Value = Date.Now
            dtpFecIni.Value = Date.Now
            dtpFecTer.Value = Date.Now
            dtpFecMax.Value = Date.Now
            numHrEstim.Value = 0
            numHrReal.Value = 0
            cboFase.SelectedIndex = 1
            numHoroFinal.Value = 0
            numHoras.Value = 0
            numToneladas.Value = 0
            dtpFechaIngreso.Value = Date.Now
            NumHoroInicial.Value = 0
            txtEmitido.Text = String.Empty
            txtEmitido.Tag = Nothing
            txtSolicitado.Text = String.Empty
            txtSolicitado.Tag = Nothing
            txtAutorizado.Text = String.Empty
            txtAutorizado.Tag = Nothing
            txtObservacion.Text = String.Empty
            dgvPersonal.Rows.Clear()
            dgvEntidad.Rows.Clear()
            treHijosEntidad.Nodes(0).Nodes.Clear()
            dgvSuministro.DataSource = Nothing
        End Sub

        Sub llenarCbo()
            Try
                ds = New DataSet
                query = BCMantto.ListaMantto()
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
                cboMantenimiento.DisplayMember = "MTO_DESCRIPCION"
                cboMantenimiento.ValueMember = "MTO_ID"
                cboMantenimiento.DataSource = ds.Tables(0)

                ds = New DataSet
                query = BCTpoFalla.ListaTipoFalla
                rea = New StringReader(query)
                ds.ReadXml(rea)
                cboTipoFalla.DisplayMember = "TFA_DESCRIPCION"
                cboTipoFalla.ValueMember = "TFA_ID"
                cboTipoFalla.DataSource = ds.Tables(0)

                ds = New DataSet
                query = BCTipoClaseMantto.ListaTipoClaseMantto
                rea = New StringReader(query)
                ds.ReadXml(rea)
                cboClaseMantto.DisplayMember = "TCM_DESCRIPCION"
                cboClaseMantto.ValueMember = "TCM_ID"
                cboClaseMantto.DataSource = ds.Tables(0)

                ds = New DataSet
                query = BCGrupo.ListaGrupo
                rea = New StringReader(query)
                ds.ReadXml(rea)
                cboGrupo.DisplayMember = "GRU_DESCRIPCION"
                cboGrupo.ValueMember = "GRU_ID"
                cboGrupo.DataSource = ds.Tables(0)
            Catch ex As Exception

            End Try
        End Sub

        Private Sub txtEntidad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntidad.DoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
            frm.Tabla = "Entidad"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtEntidad.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ENO_Id
                txtEntidad.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
            End If
            frm.Dispose()
        End Sub

        Private Sub txtAutorizado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAutorizado.DoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
            frm.Tabla = "Persona"
            frm.Tipo = "Trabajador"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtAutorizado.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PER_Id
                txtAutorizado.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Descripcion
            End If
            frm.Dispose()
        End Sub


        Private Sub dgvPersonal_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPersonal.CellDoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
            Select Case e.ColumnIndex
                Case 1
                    frm.Tabla = "Persona"
                    frm.Tipo = "Trabajador"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvPersonal.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'PER_Id
                        dgvPersonal.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(2).Value  'PER_Descripcion
                        dgvPersonal.CurrentRow.Cells("OTP_HORA_NORMAL").Value = 0
                        dgvPersonal.CurrentRow.Cells("OTP_HORA_EXTRA").Value = 0
                        dgvPersonal.CurrentRow.Cells("OTP_HORA_ESPECIAL").Value = 0
                    End If
            End Select
            frm.Dispose()
        End Sub

        Private Sub dgvEntidad_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEntidad.CellDoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
            Select Case e.ColumnIndex
                Case 1
                    frm.Tabla = "Entidad"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvEntidad.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'ENO_Id
                        dgvEntidad.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'ENO_Descripcion
                    End If
                Case 2
                    frm.Tabla = "Mantto"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvEntidad.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'MTO_Id
                        dgvEntidad.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'MTO_Descripcion
                    End If
            End Select
            frm.Dispose()
        End Sub

        Function validar_controles()
            'aqui se ingresara los objetos del formulario a validar
            Dim flag As Boolean = True

            Error_validacion.Clear()
            If Len(txtSolicitado.Text.Trim) = 0 Then Error_Validacion.SetError(txtSolicitado, "Ingrese Solicitado por") : txtSolicitado.Focus() : flag = False
            If Len(txtEmitido.Text.Trim) = 0 Then Error_Validacion.SetError(txtEmitido, "Ingrese Emitido por") : txtEmitido.Focus() : flag = False
            If Len(txtAutorizado.Text.Trim) = 0 Then Error_Validacion.SetError(txtAutorizado, "Ingrese Autorizado por") : txtAutorizado.Focus() : flag = False
            'If Len(cboTipoVenta.Text.Trim) = 0 Then Error_validacion.SetError(cboTipoVenta, "Ingrese el Tipo de Venta") : cboTipoVenta.Focus() : flag = False
            'If Len(txtObservaciones.Text.Trim) = 0 Then Error_validacion.SetError(txtObservaciones, "Ingrese las Observaciones") : txtObservaciones.Focus() : flag = False
            'If Len(cboMoneda.Text.Trim) = 0 Then Error_validacion.SetError(cboMoneda, "Ingrese el Tipo de Moneda") : cboMoneda.Focus() : flag = False
            'If Len(txtIGV.Text.Trim) = 0 Then Error_validacion.SetError(txtIGV, "Ingrese el IGV") : txtIGV.Focus() : flag = False
            'If Len(txtTipoCambio.Text.Trim) = 0 Then Error_validacion.SetError(txtTipoCambio, "Ingrese el Tipo de Cambio") : txtTipoCambio.Focus() : flag = False
            'If flag = False Then
            '    MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If
            'If mOC.ChangeTracker.State = ObjectState.Modified Or mOC.ChangeTracker.State = ObjectState.Added Then
            '    If Not InputBox("Ingrese la clave", "Autorizacion de Ingreso") = BCParametro.ParametroGetById(SessionServer.UserId & "OC").PAR_VALOR1 Then
            '        MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
            '        flag = False
            '    End If
            'End If

            Dim Her = ContainerService.Resolve(Of Herramientas)()
            If Her.PermisoEntidad(txtEntidad.Tag) = False Then
                MessageBox.Show("No le corresponde esta area.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                flag = False
            End If

            Return flag
        End Function

        Public Overrides Sub OnManGuardar()
            If Not validar_controles() Then Exit Sub
            If mOT IsNot Nothing Then
                dgvPersonal.EndEdit()
                dgvEntidad.EndEdit()
                mOT.ENO_ID = CInt(txtEntidad.Tag)
                mOT.MTO_ID = CInt(cboMantenimiento.SelectedValue)
                mOT.TFA_ID = CInt(cboTipoFalla.SelectedValue)
                mOT.TCM_ID = CInt(cboClaseMantto.SelectedValue)
                mOT.GRU_ID = CInt(cboGrupo.SelectedValue)
                mOT.OTR_CRITICIDAD = numCriticidad.Value
                mOT.OTR_FECHA_INGRESO = dtpFechaIngreso.Value
                mOT.OTR_HORO_INICIAL = NumHoroInicial.Value
                mOT.OTR_HORO_FINAL = numHoroFinal.Value
                mOT.OTR_TOTAL_HORA = numHoras.Value
                mOT.OTR_TOTAL_TN = numToneladas.Value
                mOT.OTR_FEC_EMI = dtpFecEmi.Value
                mOT.OTR_FEC_INI = dtpFecIni.Value
                mOT.OTR_FEC_FIN = dtpFecTer.Value
                mOT.OTR_FEC_MAX = dtpFecMax.Value
                mOT.OTR_HORA_EST = numHrEstim.Value
                mOT.OTR_HORA_REAL = numHrReal.Value
                mOT.PER_ID_SOLICITADO = txtSolicitado.Tag
                mOT.PER_ID_AUTORIZADO = txtAutorizado.Tag
                mOT.PER_ID_EMITIDO = txtEmitido.Tag
                mOT.OTR_FASE = cboFase.Text
                mOT.OTR_OBSERVACION = txtObservacion.Text
                mOT.OTR_ESTADO = True
                mOT.OTR_FEC_GRAB = Now
                mOT.USU_ID = SessionServer.UserId
                For Each mDetalle As DataGridViewRow In dgvPersonal.Rows
                    If Not mDetalle.Cells("OTP_ID").Value Is Nothing Then
                        With CType(mDetalle.Cells("OTP_ID").Tag, OrdenTrabajoPersonal)
                            .PER_ID_OPERADOR = mDetalle.Cells("PER_ID").Tag
                            .OTP_FECHA = mDetalle.Cells("OTP_FECHA").Value
                            .OTP_HORA_NORMAL = mDetalle.Cells("OTP_HORA_NORMAL").Value
                            .OTP_HORA_EXTRA = mDetalle.Cells("OTP_HORA_EXTRA").Value
                            .OTP_HORA_ESPECIAL = mDetalle.Cells("OTP_HORA_ESPECIAL").Value
                            .MarkAsModified()
                        End With
                    ElseIf Not mDetalle.Cells("PER_ID").Value Is Nothing Then
                        Dim nOTP As New OrdenTrabajoPersonal
                        With nOTP
                            .PER_ID_OPERADOR = mDetalle.Cells("PER_ID").Tag
                            .OTP_FECHA = mDetalle.Cells("OTP_FECHA").Value
                            .OTP_HORA_NORMAL = CDec(mDetalle.Cells("OTP_HORA_NORMAL").Value)
                            .OTP_HORA_EXTRA = CDec(mDetalle.Cells("OTP_HORA_EXTRA").Value)
                            .OTP_HORA_ESPECIAL = CDec(mDetalle.Cells("OTP_HORA_ESPECIAL").Value)
                            .MarkAsAdded()
                        End With
                        mOT.OrdenTrabajoPersonal.Add(nOTP)
                    End If
                Next
                For Each mDetalle As DataGridViewRow In dgvEntidad.Rows
                    If Not mDetalle.Cells("OTE_ID").Value Is Nothing Then
                        With CType(mDetalle.Cells("OTE_ID").Tag, OrdenTrabajoEntidad)
                            .ENO_ID = CInt(mDetalle.Cells("ENO_ID").Tag)
                            .MTO_ID = CInt(mDetalle.Cells("MTO_ID").Tag)
                            .MarkAsModified()
                        End With
                    ElseIf Not mDetalle.Cells("ENO_ID").Value Is Nothing Then
                        Dim nOTE As New OrdenTrabajoEntidad
                        With nOTE
                            .ENO_ID = CInt(mDetalle.Cells("ENO_ID").Tag)
                            .MTO_ID = CInt(mDetalle.Cells("MTO_ID").Tag)
                            .MarkAsAdded()
                        End With
                        mOT.OrdenTrabajoEntidad.Add(nOTE)
                    End If
                Next

                BCOrdenTrabajo.MantenimientoOrdenTrabajo(mOT)
                MessageBox.Show(mOT.OTR_ID)

                'Cuando viene de InspeccionPreOrdenTrabajo
                If Not IOT_CodEntidad = Nothing Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    IOT_CodOT = mOT.OTR_ID
                    Me.Dispose()
                End If


                LimpiarControles()
            End If
            Call validacion_desactivacion(False, 3)

        End Sub

        Public Overrides Sub OnManNuevo()
            LimpiarControles()
            mOT = New OrdenTrabajo
            mOT.MarkAsAdded()
            Call validacion_desactivacion(True, 2)
            txtEntidad.Focus()
        End Sub

        Public Overrides Sub OnManBuscar()
            LimpiarControles()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
            frm.Tabla = "OrdenTrabajo"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
                CargarOrdenTrabajo(key)
                LlenarControles()
                Call validacion_desactivacion(True, 5)
            End If
            frm.Dispose()
        End Sub

        Sub CargarOrdenTrabajo(ByVal OTR_Id As Integer)
            mOT = BCOrdenTrabajo.OrdenTrabajoGetById(OTR_Id)
            mOT.MarkAsModified()
        End Sub

        Sub LlenarControles()
            txtCodigo.Text = mOT.OTR_ID
            txtEntidad.Tag = mOT.ENO_ID
            txtEntidad.Text = mOT.Entidad.ENO_DESCRIPCION
            cboMantenimiento.SelectedValue = mOT.MTO_ID
            cboTipoFalla.SelectedValue = mOT.TFA_ID
            cboClaseMantto.SelectedValue = mOT.TCM_ID
            cboGrupo.SelectedValue = mOT.GRU_ID
            numCriticidad.Value = mOT.OTR_CRITICIDAD
            dtpFechaIngreso.Value = mOT.OTR_FECHA_INGRESO
            NumHoroInicial.Value = mOT.OTR_HORO_INICIAL
            numHoroFinal.Value = mOT.OTR_HORO_FINAL
            numHoras.Value = mOT.OTR_TOTAL_HORA
            numToneladas.Value = mOT.OTR_TOTAL_TN
            dtpFecEmi.Value = mOT.OTR_FEC_EMI
            dtpFecIni.Value = mOT.OTR_FEC_INI
            dtpFecTer.Value = mOT.OTR_FEC_FIN
            dtpFecMax.Value = mOT.OTR_FEC_MAX
            numHrEstim.Value = mOT.OTR_HORA_EST
            numHrReal.Value = mOT.OTR_HORA_REAL
            txtSolicitado.Tag = mOT.PER_ID_SOLICITADO
            txtSolicitado.Text = mOT.Personas.PER_NOMBRES & " " & mOT.Personas.PER_APE_PAT
            txtAutorizado.Tag = mOT.PER_ID_AUTORIZADO
            txtAutorizado.Text = mOT.Personas1.PER_NOMBRES & " " & mOT.Personas1.PER_APE_PAT
            txtEmitido.Tag = mOT.PER_ID_EMITIDO
            txtEmitido.Text = mOT.Personas2.PER_NOMBRES & " " & mOT.Personas2.PER_APE_PAT
            cboFase.Text = mOT.OTR_FASE
            txtObservacion.Text = mOT.OTR_OBSERVACION

            LLenarHijosEntidad()

            'For Each mItem In mOT.OrdenTrabajoPersonal
            '    Dim nRow As New DataGridViewRow
            '    dgvPersonal.Rows.Add(nRow)
            '    dgvPersonal.Rows(dgvPersonal.Rows.Count - 2).Cells("OTP_ID").Value = mItem.OTP_ID
            '    dgvPersonal.Rows(dgvPersonal.Rows.Count - 2).Cells("OTP_ID").Tag = mItem
            '    dgvPersonal.Rows(dgvPersonal.Rows.Count - 2).Cells("PER_ID").Value = mItem.Personas.PER_NOMBRES
            '    dgvPersonal.Rows(dgvPersonal.Rows.Count - 2).Cells("PER_ID").Tag = mItem.PER_ID_OPERADOR
            '    dgvPersonal.Rows(dgvPersonal.Rows.Count - 2).Cells("OTP_HORA_NORMAL").Value = mItem.OTP_HORA_NORMAL
            '    dgvPersonal.Rows(dgvPersonal.Rows.Count - 2).Cells("OTP_HORA_EXTRA").Value = mItem.OTP_HORA_EXTRA
            '    dgvPersonal.Rows(dgvPersonal.Rows.Count - 2).Cells("OTP_HORA_ESPECIAL").Value = mItem.OTP_HORA_ESPECIAL
            'Next

            For Each mItem In mOT.OrdenTrabajoEntidad
                Dim nRow As New DataGridViewRow
                dgvEntidad.Rows.Add(nRow)
                dgvEntidad.Rows(dgvEntidad.Rows.Count - 2).Cells("OTE_ID").Value = mItem.OTE_ID
                dgvEntidad.Rows(dgvEntidad.Rows.Count - 2).Cells("OTE_ID").Tag = mItem
                dgvEntidad.Rows(dgvEntidad.Rows.Count - 2).Cells("ENO_ID").Tag = mItem.ENO_ID
                dgvEntidad.Rows(dgvEntidad.Rows.Count - 2).Cells("ENO_ID").Value = mItem.Entidad.ENO_DESCRIPCION
                dgvEntidad.Rows(dgvEntidad.Rows.Count - 2).Cells("MTO_ID").Tag = mItem.MTO_ID
                dgvEntidad.Rows(dgvEntidad.Rows.Count - 2).Cells("MTO_ID").Value = mItem.Mantto.MTO_DESCRIPCION
            Next

            ds = New DataSet
            Dim query = BCOrdenTrabajo.ListaArticulosXOT(mOT.OTR_ID)
            If Not query = "" Then
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
                dgvSuministro.DataSource = ds.Tables(0)
            End If

            ds = New DataSet
            query = BCOrdenTrabajo.ListaPersonalXOT(mOT.OTR_ID)
            If Not query = "" Then
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
                For Each mItem In ds.Tables(0).Rows
                    Dim nRow As New DataGridViewRow
                    dgvPersonal.Rows.Add(nRow)
                    dgvPersonal.Rows(dgvPersonal.Rows.Count - 2).Cells("OTP_ID").Value = mItem("OTP_ID")
                    dgvPersonal.Rows(dgvPersonal.Rows.Count - 2).Cells("OTP_FECHA").Value = mItem("OTP_FECHA")
                    dgvPersonal.Rows(dgvPersonal.Rows.Count - 2).Cells("PER_ID").Value = mItem("Nombre")
                    dgvPersonal.Rows(dgvPersonal.Rows.Count - 2).Cells("OTP_HORA_NORMAL").Value = mItem("OTP_HORA_NORMAL")
                    dgvPersonal.Rows(dgvPersonal.Rows.Count - 2).Cells("OTP_HORA_EXTRA").Value = mItem("OTP_HORA_EXTRA")
                    dgvPersonal.Rows(dgvPersonal.Rows.Count - 2).Cells("OTP_HORA_ESPECIAL").Value = mItem("OTP_HORA_ESPECIAL")
                Next
            End If
            '''''Para saber quien lo hizo
            Dim Hecho As Usuarios
            Hecho = BCPermisoUsuario.UsuarioGetById(mOT.USU_ID)
            lblHecho.Text = "Hecho por: " & Hecho.USU_DESCRIPCION
        End Sub

        Sub LLenarHijosEntidad()
            Dim ds As New DataSet
            Dim query = BCOrdenTrabajo.ListaHijosEntidad(mOT.ENO_ID)
            If query.ToString.Length > 0 Then
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
                CargarHijosEntidad(treHijosEntidad.Nodes.Item(0), mOT.ENO_ID, ds.Tables(0))
            End If
        End Sub

        Sub CargarHijosEntidad(ByVal nodHijo As TreeNode, ByVal EnoId As Integer, ByVal dt As DataTable)
            Dim Query = From z In dt.AsEnumerable Where z("ENO_Id_Padre") = EnoId Select z
            For Each Fila In Query
                Dim nNodo As New TreeNode
                nNodo.Name = Fila("ENO_ID")
                nNodo.Text = Fila("ENO_Descripcion")
                nNodo.Tag = Fila
                nodHijo.Nodes.Add(nNodo)
                CargarHijosEntidad(nNodo, Fila("ENO_ID"), dt)
            Next
        End Sub

        Private Sub btnCrearOR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearOR.Click
            Dim mLista = From mGrid In CType(dgvSuministro.DataSource, DataTable).AsEnumerable Group mGrid By Art_Id = mGrid.Field(Of String)("ART_Id") Into Group Select Art_Id, Cantidad = Group.Sum(Function(busq) busq.Field(Of String)("DMD_Cantidad"))

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmOrdenRequerimiento)()
            frm.FlagOT = True
            frm.OnManNuevo()
            frm.CargarDeOT(mLista.ToArray)
            frm.Show()
        End Sub

        Private Sub treHijosEntidad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles treHijosEntidad.DoubleClick
            Dim nRow As New DataGridViewRow
            dgvEntidad.Rows.Add(nRow)
            dgvEntidad.Rows(dgvEntidad.Rows.Count - 2).Cells("ENO_ID").Value = treHijosEntidad.SelectedNode.Text
            dgvEntidad.Rows(dgvEntidad.Rows.Count - 2).Cells("ENO_ID").Tag = treHijosEntidad.SelectedNode.Name
        End Sub

        Public Overrides Sub OnReportes()
            Try
                MyBase.OnReportes()
                tabOT.SelectedIndex = 4
                Dim ds As New DataSet
                Dim query = BCOrdenTrabajo.ImprimirOrdenTrabajo(txtCodigo.Text)
                Dim rea As New StringReader(query)

                If query.ToString.Length > 0 Then
                    ds.ReadXml(rea)
                End If


                ReportViewer1.LocalReport.DataSources.Clear()
                ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsImprimirOrdenTrabajo", ds.Tables(0)))
                'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
                'Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
                'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text)
                'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.DateTime.Date)
                'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

                '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
                'Me.ReportViewer1.LocalReport.SetParameters(parametro)
                ReportViewer1.RefreshReport()
            Catch ex As Exception
                ReportViewer1.LocalReport.DataSources.Clear()
                ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsImprimirOrdenTrabajo", New DataTable()))
                ReportViewer1.RefreshReport()
            End Try
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
            If mOT IsNot Nothing Then
                If MessageBox.Show("Seguro de Eliminar el Documento?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = vbOK Then
                    For Each mItem In mOT.OrdenTrabajoPersonal
                        mItem.MarkAsDeleted()
                    Next
                    For Each mItem In mOT.OrdenTrabajoEntidad
                        mItem.MarkAsDeleted()
                    Next
                    mOT.MarkAsDeleted()
                    BCOrdenTrabajo.MantenimientoOrdenTrabajo(mOT)
                    LimpiarControles()
                End If
            End If
            Call LimpiarControles()
            Call validacion_desactivacion(False, 7)
        End Sub
        Public Overrides Sub OnManSalir()
            Me.Dispose()
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
                'Me.tscPosicion.Enabled = Not op
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
                '----
                If cboFase.Text = "Finalizado" Then
                    cboFase.Enabled = False
                Else
                    cboFase.Enabled = True
                End If
            End If
        End Sub

        Private Sub txtEntidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntidad.KeyDown
            If e.KeyCode = Keys.Enter Then txtEntidad_DoubleClick(Nothing, Nothing)
        End Sub

        Private Sub txtAutorizado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAutorizado.KeyDown
            If e.KeyCode = Keys.Enter Then txtAutorizado_DoubleClick(Nothing, Nothing)
        End Sub

        Private Sub txtSolicitado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSolicitado.DoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
            frm.Tabla = "Persona"
            frm.Tipo = "Trabajador"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtSolicitado.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PER_Id
                txtSolicitado.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Descripcion
            End If
            frm.Dispose()
        End Sub

        Private Sub txtEmitido_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmitido.DoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
            frm.Tabla = "Persona"
            frm.Tipo = "Trabajador"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtEmitido.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PER_Id
                txtEmitido.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Descripcion
            End If
            frm.Dispose()
        End Sub
        Private Sub txtSolicitado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSolicitado.KeyDown
            If e.KeyCode = Keys.Enter Then txtSolicitado_DoubleClick(Nothing, Nothing)
        End Sub

        Private Sub txtEmitido_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmitido.KeyDown
            If e.KeyCode = Keys.Enter Then txtEmitido_DoubleClick(Nothing, Nothing)
        End Sub

        Private Sub dgvPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPersonal.KeyDown
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
            If dgvPersonal.CurrentCell.ColumnIndex = 1 And e.KeyCode = Keys.Enter Then
                frm.Tabla = "Persona"
                frm.Tipo = "Trabajador"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvPersonal.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'PER_Id
                    dgvPersonal.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(2).Value  'PER_Descripcion
                    dgvPersonal.CurrentRow.Cells("OTP_HORA_NORMAL").Value = 0
                    dgvPersonal.CurrentRow.Cells("OTP_HORA_EXTRA").Value = 0
                    dgvPersonal.CurrentRow.Cells("OTP_HORA_ESPECIAL").Value = 0
                End If
            End If

            frm.Dispose()
        End Sub

        Private Sub dgvEntidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvEntidad.KeyDown
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
            If e.KeyCode = Keys.Enter Then
                Select Case dgvEntidad.CurrentCell.ColumnIndex
                    Case 1
                        frm.Tabla = "Entidad"
                        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            dgvEntidad.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'ENO_Id
                            dgvEntidad.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'ENO_Descripcion
                        End If
                    Case 2
                        frm.Tabla = "Mantto"
                        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            dgvEntidad.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'MTO_Id
                            dgvEntidad.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'MTO_Descripcion
                        End If
                End Select
            End If
            frm.Dispose()
        End Sub

        Private Sub Label14_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.DoubleClick
            If cboFase.Text = "Finalizado" Then
                If SessionServer.UserId <> "ADMIN" Then
                    If frmInputBox.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If Not frmInputBox.txtPassword.Text = BCParametro.ParametroGetById(SessionServer.UserId & "PC").PAR_VALOR1 Then
                            MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
                        Else
                            cboFase.Enabled = True
                        End If
                    Else
                        MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
                    End If
                Else
                    cboFase.Enabled = True
                End If
            End If
        End Sub

        Private Sub tabOT_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tabOT.Selected
            If tabOT.SelectedIndex = 4 Then
                OnReportes()
            End If
        End Sub
    End Class
End Namespace


