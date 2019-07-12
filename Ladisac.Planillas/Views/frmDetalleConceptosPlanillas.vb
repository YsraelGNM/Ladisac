Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmDetalleConceptosPlanillas
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

            If (txtFactor.Text = "" OrElse Not IsNumeric(txtFactor.Text)) Then
                ErrorProvider1.SetError(txtFactor, "Importe")
                result = False
            Else
                ErrorProvider1.SetError(txtFactor, Nothing)
            End If

            If (txtColumna.Text = "" OrElse Not IsNumeric(txtColumna.Text)) Then
                ErrorProvider1.SetError(txtColumna, "Columna")
                result = False
            Else
                ErrorProvider1.SetError(txtColumna, Nothing)
            End If

            If (txtFila.Text = "" OrElse Not IsNumeric(txtFila.Text)) Then
                ErrorProvider1.SetError(txtFila, "Importe")
                result = False
            Else
                ErrorProvider1.SetError(txtFila, Nothing)
            End If

            If (txtOrdenDeVista.Text = "" Or Not IsNumeric(txtOrdenDeVista.Text)) Then
                ErrorProvider1.SetError(txtOrdenDeVista, "Orde de Vista")
                result = False
            Else
                ErrorProvider1.SetError(txtOrdenDeVista, Nothing)
            End If
            'txtFilaOrden.Text

            If (txtFilaOrden.Text = "" Or Not IsNumeric(txtFilaOrden.Text)) Then
                ErrorProvider1.SetError(txtFilaOrden, "Orde de Fila")
                result = False
            Else
                ErrorProvider1.SetError(txtFilaOrden, Nothing)
            End If



            Return result
        End Function
        Private Sub limpiar()

            txtTipoConcepto.Tag = ""
            txtTipoConcepto.Text = ""

            txtConcepto.Tag = ""
            txtConcepto.Text = ""

            txtFactor.Text = "0"
            txtFormula.Text = ""
            txtColumna.Text = "0"
            txtFila.Text = "0"
            txtFilaOrden.Text = "0"

            chkEsMayorCero.Checked = False
            chkEsVariable.Checked = False
            chkSeImprimeSiempre.Checked = False

            txtCtaCte.Text = ""
            txtCtaCte.Tag = ""
            txtTipoDoc.Text = ""
            txtTipoDoc.Tag = ""
            txtDetalleDoc.Text = ""
            txtDetalleDoc.Tag = ""

            txtTipoConceptoInterno.Tag = ""
            txtTipoConceptoInterno.Text = ""

            txtConceptoInterno.Tag = ""
            txtConceptoInterno.Text = ""
            txtPasivo.Text = ""
            txtGasto.Text = ""

            txtItem.Text = ""
            dataRegimen.DataSource = Nothing

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
                    txtTipoTrabajador.Text = ds.Tables(0).Rows(0).Item("tit_Descripcion").ToString
                End If
            End If
            '-----------------------------------
        End Sub
        Public Overrides Sub OnManBuscar()
            If (txtPlanilla.Tag <> "") Then
                limpiar()
                menuBuscar()
                conceptoDetalle()
                Panel2.Enabled = True
                dataRegimen.Enabled = True
                btnConceptoBuscar.Enabled = False
                ErrorProvider1.SetError(txtPlanilla, Nothing)
            Else
                ErrorProvider1.SetError(txtPlanilla, "Planilla")
            End If

        End Sub

        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            If (validar()) Then

                oDetalleConceptosPlanillas.tip_TipoPlan_Id = txtTipoPlanilla.Tag
                oDetalleConceptosPlanillas.tit_TipoTrab_Id = txtTipoTrabajador.Tag
                oDetalleConceptosPlanillas.con_Conceptos_Id = txtConcepto.Tag
                oDetalleConceptosPlanillas.tic_TipoConcep_Id = txtTipoConcepto.Tag
                oDetalleConceptosPlanillas.dcp_EsVariable = chkEsVariable.Checked
                oDetalleConceptosPlanillas.dcp_Formula = txtFormula.Text
                oDetalleConceptosPlanillas.dcp_EsImprimibleSiempre = chkSeImprimeSiempre.Checked
                oDetalleConceptosPlanillas.dcp_ColumnaImprime = txtColumna.Text
                oDetalleConceptosPlanillas.dcp_FilaImprime = txtFila.Text
                oDetalleConceptosPlanillas.dcp_EsImprimibleMayorCero = chkEsMayorCero.Checked
                oDetalleConceptosPlanillas.dcp_Factor = txtFactor.Text
                oDetalleConceptosPlanillas.ItemConceptoPlanilla = txtPlanilla.Tag
                oDetalleConceptosPlanillas.dcp_Activa = chkActivo.Checked
                oDetalleConceptosPlanillas.dcp_OrdenFila = txtFilaOrden.Text

                oDetalleConceptosPlanillas.dcp_OrdenVista = txtOrdenDeVista.Text

                Try

                    If Not (IsDBNull(txtCtaCte.Tag) OrElse txtCtaCte.Tag = "") Then
                        oDetalleConceptosPlanillas.cct_Id = txtCtaCte.Tag
                        oDetalleConceptosPlanillas.tdo_Id = txtTipoDoc.Tag
                        oDetalleConceptosPlanillas.dtd_Id = txtDetalleDoc.Tag

                    Else
                        oDetalleConceptosPlanillas.cct_Id = Nothing
                        oDetalleConceptosPlanillas.tdo_Id = Nothing
                        oDetalleConceptosPlanillas.dtd_Id = Nothing

                    End If

                Catch ex As Exception
                    oDetalleConceptosPlanillas.cct_Id = Nothing
                    oDetalleConceptosPlanillas.tdo_Id = Nothing
                    oDetalleConceptosPlanillas.dtd_Id = Nothing
                End Try

                Try
                    oDetalleConceptosPlanillas.cuc_IdPasivo = txtPasivo.Text

                Catch ex As Exception
                    oDetalleConceptosPlanillas.cuc_IdPasivo = Nothing
                End Try

                Try
                    oDetalleConceptosPlanillas.cuc_IdGasto = txtGasto.Text

                Catch ex As Exception
                    oDetalleConceptosPlanillas.cuc_IdGasto = Nothing
                End Try


                Try

                    If Not (IsDBNull(txtConceptoInterno.Tag) OrElse txtConceptoInterno.Tag = "") Then

                        oDetalleConceptosPlanillas.con_Conceptos_IdInternoPrint = txtConceptoInterno.Tag
                        oDetalleConceptosPlanillas.tic_TipoConcep_IdInternoPrint = txtTipoConceptoInterno.Tag

                    Else

                        oDetalleConceptosPlanillas.con_Conceptos_IdInternoPrint = Nothing
                        oDetalleConceptosPlanillas.tic_TipoConcep_IdInternoPrint = Nothing

                    End If

                Catch ex As Exception
                    oDetalleConceptosPlanillas.con_Conceptos_IdInternoPrint = Nothing
                    oDetalleConceptosPlanillas.tic_TipoConcep_IdInternoPrint = Nothing
                End Try




                If (oDetalleConceptosPlanillas.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.DetalleConceptosPlanillas", "dcp_ItemDetConcPlan", 3, _
                                                " where tit_TipoTrab_Id='" & txtTipoTrabajador.Tag & _
                                                "' and  tip_TipoPlan_Id='" & txtTipoPlanilla.Tag & _
                                                "' and ItemConceptoPlanilla='" & txtPlanilla.Tag & "' ")
                End If

                oDetalleConceptosPlanillas.dcp_ItemDetConcPlan = IIf(txtItem.Text = "", sCorrelativo, txtItem.Text)

                oDetalleConceptosPlanillas.Usu_Id = SessionServer.UserId
                oDetalleConceptosPlanillas.dcp_FECGRAB = Now

                Try
                    BCDetalleConceptosPlanillas.Maintenance(oDetalleConceptosPlanillas)
                    MsgBox("Datos Guardados")
                    menuInicio()
                    Panel2.Enabled = False
                    dataRegimen.Enabled = False
                    limpiar()
                    conceptoDetalle()

                Catch ex As Exception
                    MsgBox(ex.Message)
                    'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                    'If (rethrow) Then
                    '    Throw
                    'End If
                End Try

                'finde verificar
            End If
        End Sub

        Public Overrides Sub OnManNuevo()

            If (txtPlanilla.Tag <> "") Then

                limpiar()
                oDetalleConceptosPlanillas = New DetalleConceptosPlanillas
                oDetalleConceptosPlanillas.MarkAsAdded()
                Panel2.Enabled = True
                dataRegimen.Enabled = False
                '  btnBucarRegimen.Enabled = True
                menuNuevo()
                ErrorProvider1.SetError(txtPlanilla, Nothing)
                btnConceptoBuscar.Enabled = True
            Else
                ErrorProvider1.SetError(txtPlanilla, "Planilla")
            End If

        End Sub
        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oDetalleConceptosPlanillas.MarkAsDeleted()


            oDetalleConceptosPlanillas.tip_TipoPlan_Id = txtTipoPlanilla.Tag
            oDetalleConceptosPlanillas.con_Conceptos_Id = txtConcepto.Tag
            oDetalleConceptosPlanillas.tic_TipoConcep_Id = txtTipoConcepto.Tag
            oDetalleConceptosPlanillas.dcp_EsVariable = chkEsVariable.Checked
            oDetalleConceptosPlanillas.dcp_Formula = txtFormula.Text
            oDetalleConceptosPlanillas.dcp_EsImprimibleSiempre = chkSeImprimeSiempre.Checked
            oDetalleConceptosPlanillas.dcp_ColumnaImprime = txtColumna.Text
            oDetalleConceptosPlanillas.dcp_FilaImprime = txtFila.Text
            oDetalleConceptosPlanillas.dcp_EsImprimibleMayorCero = chkEsMayorCero.Checked
            oDetalleConceptosPlanillas.dcp_Factor = txtFactor.Text
            oDetalleConceptosPlanillas.ItemConceptoPlanilla = txtPlanilla.Tag
            oDetalleConceptosPlanillas.dcp_Activa = chkActivo.Checked

            oDetalleConceptosPlanillas.dcp_ItemDetConcPlan = txtItem.Text

            oDetalleConceptosPlanillas.Usu_Id = SessionServer.UserId
            oDetalleConceptosPlanillas.dcp_FECGRAB = Now

            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCDetalleConceptosPlanillas.Maintenance(oDetalleConceptosPlanillas)

                    MsgBox("Datos Eliminados")

                    menuInicio()
                    Panel2.Enabled = False
                    dataRegimen.Enabled = False
                    limpiar()
                    conceptoDetalle()

                End If

            Catch ex As Exception

                MsgBox(ex.Message)

            End Try

            ' fin de  verificar
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

                txtCtaCte.Tag = oDetalleConceptosPlanillas.cct_Id
                txtTipoDoc.Tag = oDetalleConceptosPlanillas.tdo_Id
                txtDetalleDoc.Tag = oDetalleConceptosPlanillas.dtd_Id
                txtFilaOrden.Text = oDetalleConceptosPlanillas.dcp_OrdenFila
                txtOrdenDeVista.Text = oDetalleConceptosPlanillas.dcp_OrdenVista

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

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.ConceptosPlanilla)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    cargar(.Cells("tit_TipoTrab_Id").Value, .Cells("tip_TipoPlan_Id").Value, .Cells("ItemConceptoPlanilla").Value, Nothing)

                End With
            End If

            frm.Dispose()
        End Sub

        Private Sub btnConceptoBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConceptoBuscar.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()

            Try
                frm.inicio(Constants.BuscadoresNames.Conceptos)

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    txtConcepto.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                    txtTipoConcepto.Text = frm.dgbRegistro.CurrentRow.Cells(2).Value
                    txtTipoConcepto.Tag = frm.dgbRegistro.CurrentRow.Cells(1).Value
                    txtConcepto.Text = frm.dgbRegistro.CurrentRow.Cells(3).Value
                End If

                frm.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


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
                    chkEsVariable.Checked = .Cells("Variable").Value ' =cab.[dcp_EsVariable]
                    txtFormula.Text = .Cells("Formula").Value '=cab.[dcp_Formula]
                    chkSeImprimeSiempre.Checked = .Cells("Imprimir").Value '=cab.[dcp_EsImprimibleSiempre]
                    txtColumna.Text = .Cells("Columna").Value '=cab.[dcp_ColumnaImprime]
                    txtFila.Text = .Cells("Fila").Value '=cab.[dcp_FilaImprime]
                    chkEsMayorCero.Checked = .Cells("Cero").Value '=cab.[dcp_EsImprimibleMayorCero]
                    txtFactor.Text = .Cells("Factor").Value '=cab.[dcp_Factor]
                    txtItem.Text = .Cells("dcp_ItemDetConcPlan").Value

                    txtFilaOrden.Text = .Cells("OrdenFila").Value
                    txtOrdenDeVista.Text = .Cells("OrdenVista").Value

                    Try
                        txtPasivo.Text = .Cells("cuc_idPasivo").Value
                    Catch ex As Exception
                        txtPasivo.Text = Nothing
                    End Try

                    Try
                        txtGasto.Text = .Cells("cuc_idGasto").Value
                    Catch ex As Exception
                        txtGasto.Text = Nothing
                    End Try



                    Try

                        txtCtaCte.Tag = .Cells("cct_Id").Value
                        txtCtaCte.Text = .Cells("CCT_DESCRIPCION").Value
                        txtTipoDoc.Tag = .Cells("tdo_Id").Value
                        txtDetalleDoc.Tag = .Cells("dtd_Id").Value
                        txtDetalleDoc.Text = .Cells("DTD_DESCRIPCION").Value

                    Catch ex As Exception

                        txtCtaCte.Tag = Nothing
                        txtCtaCte.Text = Nothing

                        txtTipoDoc.Tag = Nothing
                        txtDetalleDoc.Tag = Nothing

                        txtDetalleDoc.Text = Nothing


                    End Try

                    Try

                        txtConceptoInterno.Tag = .Cells("con_Conceptos_IdInternoPrint").Value
                        txtConceptoInterno.Text = .Cells("ConceptoInterno").Value
                        txtTipoConceptoInterno.Tag = .Cells("tic_TipoConcep_IdInternoPrint").Value
                        txtTipoConceptoInterno.Text = .Cells("TipoInterno").Value '=ticon.tic_Descripcion 

                    Catch ex As Exception


                        txtConceptoInterno.Tag = Nothing
                        txtConceptoInterno.Text = Nothing
                        txtTipoConceptoInterno.Tag = Nothing
                        txtTipoConceptoInterno.Text = Nothing

                    End Try



                End With
              
            Else
                MsgBox("Seleccione un Registro ")
            End If
        End Sub

        Private Sub frmDetalleConceptosPlanillas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel2.Enabled = False
        End Sub

        Private Sub dataRegimen_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dataRegimen.RowHeaderMouseDoubleClick
            pasarValores()
        End Sub

        Private Sub dataRegimen_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataRegimen.CellDoubleClick
            pasarValores()
        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocumento.Click

            If (txtCtaCte.Tag <> "" OrElse IsDBNull(txtCtaCte.Tag)) Then

                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.RolOpeCtaCte)
                frm.campo1 = txtCtaCte.Tag

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtTipoDoc.Tag = .Cells(2).Value
                        txtDetalleDoc.Tag = .Cells(4).Value
                        txtDetalleDoc.Text = .Cells(5).Value
                    End With
                End If
                frm.Dispose()
            Else
                MessageBox.Show("Debe Ingresar antes la Cuenta Corriente")
            End If

        End Sub

        Private Sub btnCtaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtaCte.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CtaCte)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtCtaCte.Tag = .Cells(0).Value
                    txtCtaCte.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Conceptos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtConceptoInterno.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtTipoConceptoInterno.Text = frm.dgbRegistro.CurrentRow.Cells(2).Value
                txtTipoConceptoInterno.Tag = frm.dgbRegistro.CurrentRow.Cells(1).Value
                txtConceptoInterno.Text = frm.dgbRegistro.CurrentRow.Cells(3).Value
            End If

            frm.Dispose()
        End Sub

        Private Sub btnLimpiarInterno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarInterno.Click
            txtConceptoInterno.Tag = Nothing
            txtTipoConceptoInterno.Text = Nothing
            txtTipoConceptoInterno.Tag = Nothing
            txtConceptoInterno.Text = Nothing
        End Sub

        Private Sub btnPasivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasivo.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CuentasContables)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtPasivo.Text = .Cells(0).Value
                End With
            End If

            frm.Dispose()
        End Sub

        Private Sub btngasto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngasto.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CuentasContables)

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