Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling


Namespace Ladisac.Planillas.Views
    Public Class frmConceptosPlanilla

        <Dependency()> _
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property BCConceptosPlanilla As Ladisac.BL.IBCConceptosPlanilla

        <Dependency()> _
        Public Property BCTiposTareos As Ladisac.BL.IBCTiposTareos

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oConceptosPlanilla As New BE.ConceptosPlanilla

        Private Sub buscarTipos()
            Dim result = Me.BCTiposTareos.TiposTareosQuery(Nothing, Nothing)

            Dim ds As New DataSet
            Dim sr As New StringReader(result)
            ds.ReadXml(sr)
            Me.cboTipoTareo.DataSource = ds.Tables(0)

            Me.cboTipoTareo.DisplayMember = "tio_Descripcion"
            Me.cboTipoTareo.ValueMember = "tio_TiposTareo_Id"

        End Sub

        Private Function validar() As Boolean
            Dim result As Boolean = True
            If (txtDescripcion.Text.Trim = "") Then
                ErrorProvider1.SetError(txtDescripcion, "Descripcion")
                result = False
            Else
                ErrorProvider1.SetError(txtDescripcion, Nothing)
            End If
            If (txtTipoPlanilla.Tag = "") Then
                ErrorProvider1.SetError(txtTipoPlanilla, "Tipo Planilla")
                result = False
            Else
                ErrorProvider1.SetError(txtTipoPlanilla, Nothing)
            End If
            If (txtTipoTrabajador.Tag = "") Then
                ErrorProvider1.SetError(txtTipoTrabajador, "Tipo Trabajador")
                result = False

            Else
                ErrorProvider1.SetError(txtTipoTrabajador, Nothing)
            End If

            Return result
        End Function

        Private Sub limpiar()

            txtPeriodisidad.Text = ""
            txtPeriodisidad.Tag = ""

            txtTipoPlanilla.Text = ""
            txtTipoPlanilla.Tag = ""

            txtTipoTrabajador.Text = ""
            txtTipoTrabajador.Tag = ""

            txtDescripcion.Text = ""

            txtItem.Text = ""
            txtItem.Tag = ""
            chkEsPDT.Checked = False
            chkActivo.Checked = False

        End Sub

        Sub cargar(ByVal tit_TipoTrab_Id As String, ByVal tip_TipoPlan_Id As String, ByVal ItemConceptoPlanilla As String, Optional ByVal cop_Descripcion As String = Nothing)

            Dim query As String
            limpiar()

            oConceptosPlanilla = BCConceptosPlanilla.ConceptosPlanillaSeek(tit_TipoTrab_Id, tip_TipoPlan_Id, ItemConceptoPlanilla)

            oConceptosPlanilla.MarkAsModified()
            '-----------------------------------

            query = Me.BCConceptosPlanilla.ConceptosPlanillasDetalleQuery(tit_TipoTrab_Id, tip_TipoPlan_Id, ItemConceptoPlanilla, Nothing)

            If (query <> Nothing) Then
                Dim ds As New DataSet

                Dim rea As New StringReader(query)

                If (query <> "") Then
                    ds.ReadXml(rea)
                    txtTipoTrabajador.Tag = ds.Tables(0).Rows(0).Item("tit_TipoTrab_Id").ToString ' oConceptosPlanilla.tit_TipoTrab_Id 
                    txtTipoTrabajador.Text = ds.Tables(0).Rows(0).Item("tit_Descripcion").ToString

                    txtTipoPlanilla.Tag = ds.Tables(0).Rows(0).Item("tip_TipoPlan_Id").ToString 'oConceptosPlanilla.tip_TipoPlan_Id '
                    txtTipoPlanilla.Text = ds.Tables(0).Rows(0).Item("tip_Descripcion").ToString

                    txtItem.Text = oConceptosPlanilla.ItemConceptoPlanilla 'ds.Tables(0).Rows(0).Item("tip_Descripcion").ToString
                    txtItem.Tag = oConceptosPlanilla.ItemConceptoPlanilla

                    txtPeriodisidad.Tag = ds.Tables(0).Rows(0).Item("pec_Periodisidad_Id").ToString
                    txtPeriodisidad.Text = ds.Tables(0).Rows(0).Item("pec_Descripcion").ToString

                    cboTipoTareo.SelectedValue = ds.Tables(0).Rows(0).Item("tio_TiposTareo_Id")

                    chkEsPDT.Checked = ds.Tables(0).Rows(0).Item("cop_EsPDT")
                    chkActivo.Checked = ds.Tables(0).Rows(0).Item("cop_EsActivo")
                    txtDescripcion.Text = ds.Tables(0).Rows(0).Item("cop_Descripcion").ToString

                End If
            End If
            '-----------------------------------
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.ConceptosPlanilla)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    cargar(.Cells("tit_TipoTrab_Id").Value, .Cells("tip_TipoPlan_Id").Value, .Cells("ItemConceptoPlanilla").Value, Nothing)
                    menuBuscar()
                End With
            End If
            frm.Dispose()
            Panel1.Enabled = False
        End Sub
        Public Overrides Sub OnManGuardar()
            Try
                Dim sCorrelativo As String = ""
                If (validar()) Then

                    If (oConceptosPlanilla.ChangeTracker.State = ObjectState.Added) Then
                        sCorrelativo = BCUtil.GetId("pla.ConceptosPlanilla", "ItemConceptoPlanilla", 3, _
                                                    " where tit_TipoTrab_Id='" & txtTipoTrabajador.Tag & _
                                                    "'  and  tip_TipoPlan_Id='" & txtTipoPlanilla.Tag & "'")
                    End If
                    oConceptosPlanilla.tip_TipoPlan_Id = txtTipoPlanilla.Tag
                    oConceptosPlanilla.tit_TipoTrab_Id = txtTipoTrabajador.Tag
                    oConceptosPlanilla.ItemConceptoPlanilla = IIf(txtItem.Text = "", sCorrelativo, txtItem.Text)

                    oConceptosPlanilla.pec_Periodisidad_Id = txtPeriodisidad.Tag
                    oConceptosPlanilla.tio_TiposTareo_Id = cboTipoTareo.SelectedValue
                    oConceptosPlanilla.cop_EsPDT = chkEsPDT.Checked
                    oConceptosPlanilla.cop_EsActivo = chkActivo.Checked
                    oConceptosPlanilla.cop_Descripcion = txtDescripcion.Text
                    oConceptosPlanilla.Usu_Id = SessionService.UserId
                    oConceptosPlanilla.cop_FECGRAB = Now

                    BCConceptosPlanilla.Mantenance(oConceptosPlanilla)
                    MsgBox("Dato Guardados")
                    menuInicio()
                    Panel1.Enabled = False
                    limpiar()

                    'fin de verificar
                End If
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                If (rethrow) Then
                    Throw
                End If
            End Try

        End Sub
        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oConceptosPlanilla = New ConceptosPlanilla
            oConceptosPlanilla.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub



        Public Overrides Sub OnManEliminar()
            oConceptosPlanilla.MarkAsDeleted()

            oConceptosPlanilla.tip_TipoPlan_Id = txtTipoPlanilla.Tag
            oConceptosPlanilla.tit_TipoTrab_Id = txtTipoTrabajador.Tag
            oConceptosPlanilla.ItemConceptoPlanilla = txtItem.Text

            oConceptosPlanilla.pec_Periodisidad_Id = txtPeriodisidad.Tag
            oConceptosPlanilla.tio_TiposTareo_Id = cboTipoTareo.SelectedValue
            oConceptosPlanilla.cop_EsPDT = chkEsPDT.Checked
            oConceptosPlanilla.cop_EsActivo = chkActivo.Checked
            oConceptosPlanilla.cop_Descripcion = txtDescripcion.Text
            oConceptosPlanilla.Usu_Id = SessionService.UserId
            oConceptosPlanilla.cop_FECGRAB = Now
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCConceptosPlanilla.Mantenance(oConceptosPlanilla)
                    MsgBox("Dato Eliminados")
                    Panel1.Enabled = False
                    limpiar()
                End If
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                If (rethrow) Then
                    Throw
                End If
            End Try


            ' fin de  verificar
        End Sub

        Public Overrides Sub OnManCancelarEdicion()
            menuInicio()
            Panel1.Enabled = False
            limpiar()
        End Sub
        Public Overrides Sub OnManEditar()
            menuEditar()
            Panel1.Enabled = True
        End Sub
        Public Overrides Sub OnManDeshacerCambios()
            menuInicio()
            Panel1.Enabled = False
            limpiar()
        End Sub

        Private Sub frmConceptosPlanilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            menuInicio()
            Panel1.Enabled = False

            buscarTipos()

        End Sub

        Private Sub btnTipoPlanilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoPlanilla.Click


            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposPlanillas)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtTipoPlanilla.Tag = .Cells(0).Value()
                    txtTipoPlanilla.Text = .Cells(1).Value()
                End With
            End If
            frm.Dispose()

        End Sub


        Private Sub btnTipoTrabajador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoTrabajador.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposTrabajador)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtTipoTrabajador.Tag = .Cells(0).Value()
                    txtTipoTrabajador.Text = .Cells(1).Value()

                End With
            End If
            frm.Dispose()

        End Sub

        Private Sub btnPeriodisidadAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodisidadAdd.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Periodisidad)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtPeriodisidad.Tag = .Cells(0).Value()
                    txtPeriodisidad.Text = .Cells(1).Value()
                End With
            End If
            frm.Dispose()


        End Sub
    End Class


End Namespace


'Imports Microsoft.Practices.Unity
'Imports System.IO
'Imports Ladisac.BE
'Namespace Ladisac.Planillas.Views
'    Public Class frmNivelEducacion

'        <Dependency()> _
'        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
'        <Dependency()> _
'        Public Property BCNivelEducacion As Ladisac.BL.IBCNivelEducacion
'        <Dependency()> _
'        Public Property BCUtil As Ladisac.BL.IBCUtil

'        Protected oNIvelEducacion As New NivelEducacion
'        Private Function validar() As Boolean
'            Dim result As Boolean = True

'            If (txtNivelEducacion.Text.Trim = "") Then
'                ErrorProvider1.SetError(txtNivelEducacion, "Nivel de Educacion")
'                result = False
'            Else
'                ErrorProvider1.SetError(txtNivelEducacion, Nothing)
'            End If

'            Return result
'        End Function
'        Private Sub limpiar()
'            txtNivelEducacion.Text = ""
'            txtCodigo.Text = ""
'            txtCodigoSunat.Text = ""

'        End Sub
'        Sub cargarNivelEducacion(ByVal id As String)
'            limpiar()
'            oNIvelEducacion = BCNivelEducacion.NivelEducacionSeek(id)

'            oNIvelEducacion.MarkAsModified()

'            txtCodigo.Text = oNIvelEducacion.nie_NiveEduc_Id
'            txtNivelEducacion.Text = oNIvelEducacion.nie_Descipcion
'            txtCodigoSunat.Text = oNIvelEducacion.nie_CodigoSunat
'        End Sub

'        Public Overrides Sub OnManBuscar()

'            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
'            frm.inicio(Constants.BuscadoresNames.NIvelEducacion)

'            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
'                cargarNivelEducacion(frm.dgbRegistro.CurrentRow.Cells(0).Value)
'                menuBuscar()
'            End If
'            frm.Dispose()
'            Panel1.Enabled = False

'        End Sub

'        Public Overrides Sub OnManGuardar()
'            Dim sCorrelativo As String = ""
'            If (validar()) Then
'                If (oNIvelEducacion.ChangeTracker.State = ObjectState.Added) Then
'                    sCorrelativo = BCUtil.GetId("pla.NivelEducacion", "nie_NiveEduc_Id", 3, "")
'                End If

'                oNIvelEducacion.nie_NiveEduc_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
'                oNIvelEducacion.nie_Descipcion = txtNivelEducacion.Text
'                oNIvelEducacion.nie_CodigoSunat = txtCodigoSunat.Text
'                oNIvelEducacion.Usu_Id = SessionServer.UserId
'                oNIvelEducacion.nie_FECGRAB = Now
'                If (BCNivelEducacion.Maintenance(oNIvelEducacion)) Then
'                    MsgBox("ingreso")
'                    menuInicio()
'                    Panel1.Enabled = False
'                    limpiar()
'                Else
'                    MsgBox("no ingreso")
'                End If

'                'finde verificar
'            End If

'        End Sub
'        Public Overrides Sub OnManNuevo()
'            limpiar()
'            menuNuevo()
'            oNIvelEducacion = New NivelEducacion
'            oNIvelEducacion.MarkAsAdded()

'            Panel1.Enabled = True

'        End Sub

'        Public Overrides Sub OnManSalir()
'            Me.Dispose()
'        End Sub


'        Public Overrides Sub OnManEliminar()
'            oNIvelEducacion.MarkAsDeleted()

'            oNIvelEducacion.nie_NiveEduc_Id = txtCodigo.Text
'            oNIvelEducacion.nie_Descipcion = txtNivelEducacion.Text
'            oNIvelEducacion.nie_CodigoSunat = txtCodigoSunat.Text
'            oNIvelEducacion.Usu_Id = SessionServer.UserId
'            oNIvelEducacion.nie_FECGRAB = Now
'            ' verificar si se elimino
'            BCNivelEducacion.Maintenance(oNIvelEducacion)

'            Panel1.Enabled = False
'            limpiar()
'            ' fin de  verificar
'        End Sub

'        Public Overrides Sub OnManCancelarEdicion()
'            menuInicio()
'            Panel1.Enabled = False
'            limpiar()
'        End Sub
'        Public Overrides Sub OnManEditar()
'            menuEditar()
'            Panel1.Enabled = True
'        End Sub
'        Public Overrides Sub OnManDeshacerCambios()
'            menuInicio()
'            Panel1.Enabled = False
'            limpiar()
'        End Sub

'        Private Sub frmPeriodisidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'            menuInicio()

'            Panel1.Enabled = False
'        End Sub

'        Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

'        End Sub
'    End Class
'End Namespace
