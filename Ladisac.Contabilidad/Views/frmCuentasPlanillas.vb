Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Contabilidad.Views
    Public Class frmCuentasPlanillas
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil
        <Dependency()> _
        Public Property BCDetalleConceptosPlanillas As Ladisac.BL.IBCDetalleConceptosPlanillas
        <Dependency()> _
        Public Property BCConceptosPlanilla As BL.IBCConceptosPlanilla

        Protected oDetalleConceptosPlanillas As New DetalleConceptosPlanillas
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtConcepto.Text.Trim = "") Then
                ErrorProvider1.SetError(txtConcepto, "Concepto")
                result = False
            Else
                ErrorProvider1.SetError(txtConcepto, Nothing)
            End If
            Return result

        End Function
        Private Sub limpiar()

            txtTipoConcepto.Tag = ""
            txtTipoConcepto.Text = ""

            txtConcepto.Tag = ""
            txtConcepto.Text = ""
            txtPasivo.Text = ""
            txtGasto.Text = ""



        End Sub


        Sub cargar(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, Optional ByVal cop_Descripcion As String = Nothing)
            Dim query As String
            limpiar()
            '----------------------------------------------------------
            query = Me.BCConceptosPlanilla.ConceptosPlanillasDetalleQuery(tit_TipoTrab_Id, tip_TipoPlan_Id, ItemConceptoPlanilla, Nothing)
            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)

                    txtPlanilla.Tag = ds.Tables(0).Rows(0).Item("ItemConceptoPlanilla").ToString ' oConceptosPlanilla.tit_TipoTrab_Id 
                    txtPlanilla.Text = ds.Tables(0).Rows(0).Item("cop_Descripcion").ToString
                    txtTipoPlanilla.Tag = ds.Tables(0).Rows(0).Item("tip_TipoPlan_Id").ToString 'oConceptosPlanilla.tip_TipoPlan_Id '
                    txtTipoPlanilla.Text = ds.Tables(0).Rows(0).Item("tip_Descripcion").ToString
                    txtTipoTrabajador.Tag = ds.Tables(0).Rows(0).Item("tit_TipoTrab_Id").ToString 'ds.Tables(0).Rows(0).Item("tip_Descripcion").ToString
                    ' txtPasivo.Text = ds.Tables(0).Rows(0).Item("cuc_IdPasivo").ToString
                    'txtGasto.Text = ds.Tables(0).Rows(0).Item("cuc_IdGasto").ToString

                End If
            End If
            '-----------------------------------
        End Sub
        Public Overrides Sub OnManBuscar()
            If (txtPlanilla.Tag <> "") Then
                limpiar()
                conceptoDetalle()
                Panel2.Enabled = True
                dataRegimen.Enabled = True
                ErrorProvider1.SetError(txtPlanilla, Nothing)
            Else
                ErrorProvider1.SetError(txtPlanilla, "Planilla")
            End If

        End Sub

        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            MsgBox("La Operacion  de guardar se  realizara por el fromulario de :" & Chr(3) & _
                   "Modulo Planillas ->configuracion PLanillas -> Detalle Conceptos Planillas ")

            Exit Sub
            'If (validar()) Then

            '    oDetalleConceptosPlanillas.tip_TipoPlan_Id = txtTipoPlanilla.Tag
            '    oDetalleConceptosPlanillas.tit_TipoTrab_Id = txtTipoTrabajador.Tag
            '    oDetalleConceptosPlanillas.con_Conceptos_Id = txtConcepto.Tag
            '    oDetalleConceptosPlanillas.tic_TipoConcep_Id = txtTipoConcepto.Tag

            '    oDetalleConceptosPlanillas.ItemConceptoPlanilla = txtPlanilla.Tag

            '    oDetalleConceptosPlanillas.cuc_IdGasto = IIf(txtGasto.Text = "", Nothing, txtGasto.Text)
            '    oDetalleConceptosPlanillas.cuc_IdPasivo = IIf(txtPasivo.Text = "", Nothing, txtPasivo.Text)


            '    If (oDetalleConceptosPlanillas.ChangeTracker.State = ObjectState.Added) Then
            '        sCorrelativo = BCUtil.GetId("pla.DetalleConceptosPlanillas", "dcp_ItemDetConcPlan", 3, _
            '                                    " where tit_TipoTrab_Id='" & txtTipoTrabajador.Tag & _
            '                                    "' and  tip_TipoPlan_Id='" & txtTipoPlanilla.Tag & _
            '                                    "' and ItemConceptoPlanilla='" & txtPlanilla.Tag & "' ")
            '    End If

            '    oDetalleConceptosPlanillas.dcp_ItemDetConcPlan = IIf(txtItem.Text = "", sCorrelativo, txtItem.Text)

            '    oDetalleConceptosPlanillas.Usu_Id = SessionServer.UserId
            '    oDetalleConceptosPlanillas.dcp_FECGRAB = Now

            '    Try
            '        BCDetalleConceptosPlanillas.Maintenance(oDetalleConceptosPlanillas)
            '        MsgBox("Datos Guardados")
            '        menuBuscar()
            '        Panel2.Enabled = False
            '        dataRegimen.Enabled = False
            '        limpiar()
            '        conceptoDetalle()

            '    Catch ex As Exception
            '        Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
            '        If (rethrow) Then
            '            Throw
            '        End If
            '    End Try

            '    'finde verificar
            'End If
        End Sub

        Public Overrides Sub OnManNuevo()
            MsgBox("Solo se Puede Crear Nuevos Conceptos en Planillas")

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            MsgBox("Para eliminar tiene que entara a Planillas ")
        End Sub

        Public Overrides Sub OnManCancelarEdicion()
            menuInicio()
            Panel2.Enabled = False
            limpiar()
        End Sub
        Public Overrides Sub OnManEditar()
            pasarValores()
            If (txtConcepto.Tag <> "") Then

                menuEditar()
                Panel2.Enabled = True
                menuEditar()
                ErrorProvider1.SetError(txtPlanilla, Nothing)
            Else
                ErrorProvider1.SetError(txtPlanilla, "Planilla")

            End If

        End Sub
        Public Overrides Sub OnManDeshacerCambios()
            menuInicio()
            Panel2.Enabled = False
            dataRegimen.Enabled = True
            limpiar()
        End Sub
        Public Sub conceptoDetalle()
            Dim query As String

            Try

                oDetalleConceptosPlanillas = BCDetalleConceptosPlanillas.DetalleConceptosPlanillasSeek(txtTipoTrabajador.Tag, txtTipoPlanilla.Tag, txtPlanilla.Tag, Nothing)
                oDetalleConceptosPlanillas.MarkAsModified()
                query = Me.BCDetalleConceptosPlanillas.DetalleConceptosPlanillasDetalleQuery(txtTipoTrabajador.Tag, _
                                                                                              txtTipoPlanilla.Tag, _
                                                                                              txtPlanilla.Tag, _
                                                                                           Nothing)
                dataRegimen.DataSource = Nothing
                If (query <> Nothing) Then

                    Dim ds As New DataSet
                    Dim rea As New StringReader(query)

                    If (query <> "") Then
                        ds.ReadXml(rea)
                        dataRegimen.DataSource = ds.Tables(0)
                    Else
                        dataRegimen.DataSource = Nothing
                    End If

                End If
            Catch ex As Exception

                MsgBox("No se pudo mostrar los datos")
                dataRegimen.DataSource = Nothing

            End Try


        End Sub

        Private Sub btnTipoTrabaBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoTrabaBuscar.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.ConceptosPlanilla)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    cargar(.Cells("tit_TipoTrab_Id").Value, .Cells("tip_TipoPlan_Id").Value, .Cells("ItemConceptoPlanilla").Value, Nothing)

                End With
            End If

            frm.Dispose()
        End Sub





        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            If (txtPlanilla.Tag = "") Then
                ErrorProvider1.SetError(txtPlanilla, "Planilla")
            Else
                ErrorProvider1.SetError(txtPlanilla, Nothing)
                conceptoDetalle()
            End If


        End Sub

        Private Sub pasarValores()
            If (dataRegimen.SelectedRows.Count > 0) Then
                'cargar datos de conceptos
                '-------------------------

                With dataRegimen.SelectedRows(0)

                    txtConcepto.Tag = .Cells("con_Conceptos_Id").Value
                    txtConcepto.Text = .Cells("Concepto").Value

                    txtTipoConcepto.Tag = .Cells("tic_TipoConcep_Id").Value
                    txtTipoConcepto.Text = .Cells("Tipo").Value '=ticon.tic_Descripcion 
                    txtItem.Text = .Cells("dcp_ItemDetConcPlan").Value
                    txtPasivo.Text = IIf(IsDBNull(.Cells("cuc_IdPasivo").Value), "", .Cells("cuc_IdPasivo").Value)
                    txtGasto.Text = IIf(IsDBNull(.Cells("cuc_IdGasto").Value), "", .Cells("cuc_IdGasto").Value)


                End With

            Else
                MsgBox("Seleccione un Registro ")
            End If
        End Sub

        Private Sub dataRegimen_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dataRegimen.RowHeaderMouseDoubleClick
            pasarValores()
        End Sub

        Private Sub dataRegimen_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataRegimen.CellDoubleClick
            pasarValores()
        End Sub

        Private Sub frmCuentasPlanillas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuBuscar()

            Panel2.Enabled = False
        End Sub

        Private Sub btnPasivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasivo.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.CuentasContables)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtPasivo.Text = .Cells(0).Value
                End With
            End If

            frm.Dispose()
        End Sub

        Private Sub btngasto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngasto.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.CuentasContables)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtGasto.Text = .Cells(0).Value
                End With
            End If

            frm.Dispose()
        End Sub

        Private Sub btnLImpiarPasivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLImpiarPasivo.Click
            txtPasivo.Tag = ""
            txtPasivo.Text = ""

        End Sub

        Private Sub btnLimpiarGasto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarGasto.Click
            txtGasto.Tag = ""
            txtGasto.Text = ""
        End Sub
    End Class
End Namespace