Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views
    Public Class frmTiposContratos
        <Dependency()> _
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCTiposContratos As Ladisac.BL.IBCTiposContratos

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil


        Protected oTiposContratos As New TiposContratos
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtContrato.Text.Trim = "") Then
                ErrorProvider1.SetError(txtContrato, "Contrato")
                result = False
            Else
                ErrorProvider1.SetError(txtContrato, Nothing)
            End If

            Return result
        End Function
        Sub cargarTiposContratos(ByVal id As String)
            limpiar()
            oTiposContratos = BCTiposContratos.TiposContratosSeek(id)
            oTiposContratos.MarkAsModified()

            txtCodigo.Text = oTiposContratos.tic_TipoCont_Id
            txtContrato.Text = oTiposContratos.tico_Descripcion
            txtCodigoSunat.Text = oTiposContratos.tic_CodigoSunat

        End Sub
        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.TiposContratos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargarTiposContratos(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            If (validar()) Then
                If (oTiposContratos.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.TiposContratos", "tic_TipoCont_Id", 3, "")
                End If

                oTiposContratos.tic_TipoCont_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                oTiposContratos.tico_Descripcion = txtContrato.Text
                oTiposContratos.tic_CodigoSunat = txtCodigoSunat.Text
                oTiposContratos.Usu_Id = SessionService.UserId
                oTiposContratos.tic_FECGRAB = Now
                Try
                    BCTiposContratos.Maintenance(oTiposContratos)
                    ' verificar si se guardo o se edito
                    menuInicio()
                    Panel1.Enabled = False
                    limpiar()
                    'finde verificar
                    MsgBox("Datos Guardados")
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                    If (rethrow) Then
                        Throw
                    End If
                End Try

            End If

        End Sub
        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oTiposContratos = New TiposContratos
            oTiposContratos.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oTiposContratos.MarkAsDeleted()
            oTiposContratos.tic_TipoCont_Id = IIf(txtCodigo.Text = "", Nothing, txtCodigo.Text)
            oTiposContratos.tico_Descripcion = txtContrato.Text
            oTiposContratos.tic_CodigoSunat = txtCodigoSunat.Text
            oTiposContratos.Usu_Id = SessionService.UserId
            oTiposContratos.tic_FECGRAB = Now
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCTiposContratos.Maintenance(oTiposContratos)
                    ' verificar si se elimino
                    Panel1.Enabled = False
                    limpiar()
                    'fin de verificar
                    MsgBox("Datos Eliminados")
                End If


            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                If (rethrow) Then
                    Throw
                End If
            End Try

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

        Private Sub limpiar()
            txtCodigo.Text = ""
            txtCodigoSunat.Text = ""
            txtContrato.Text = ""
        End Sub

        Private Sub frmTiposContratos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub
    End Class
End Namespace

'Imports Microsoft.Practices.Unity
'Imports System.IO
'Imports Ladisac.BE
'Namespace Ladisac.Planillas.Views
'    Public Class frmConceptos

'        <Dependency()>
'        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

'        <Dependency()>
'        Public Property BCConceptos As Ladisac.BL.IBCConceptos

'        <Dependency()>
'        Public Property BCTiposConceptosQueries As Ladisac.BL.IBCTiposConceptosQueries

'        <Dependency()> _
'        Public Property BC As Ladisac.BL.IBCConceptos

'        Protected oConceptos As New Conceptos

'        Private Function validar()
'            Dim result As Boolean = True
'            If (txtConcepto.Text.Trim = "") Then
'                ErrorProvider1.SetError(txtConcepto, "Concepto")
'                result = False
'            Else
'                ErrorProvider1.SetError(txtConcepto, Nothing)
'            End If
'            If (txtDescripcion.Text.Trim = "") Then
'                ErrorProvider1.SetError(txtDescripcion, "Concepto")
'                result = False
'            Else
'                ErrorProvider1.SetError(txtDescripcion, Nothing)
'            End If
'            Return result
'        End Function

'        Private Sub buscarTipos()
'            Dim result = Me.BCTiposConceptosQueries.TiposDocumentosQuery()

'            Dim ds As New DataSet
'            Dim sr As New StringReader(result)
'            ds.ReadXml(sr)
'            Me.cboTipoConcepto.DataSource = ds.Tables(0)
'            Me.cboTipoConcepto.DisplayMember = "tic_Descripcion"
'            Me.cboTipoConcepto.ValueMember = "tic_TipoConcep_Id"
'        End Sub
'        Sub CargarConceptos(ByVal Id As String)
'            limpiar()
'            oConceptos = BCConceptos.ConceptosSeek(Id)
'            oConceptos.MarkAsModified()

'            txtCodigo.Text = oConceptos.con_Conceptos_Id
'            cboTipoConcepto.SelectedValue = oConceptos.tic_TipoConcep_Id
'            txtConcepto.Text = oConceptos.con_Concepto
'            chkEsFijo.Checked = oConceptos.con_EsFijoTrabajador
'            txtCodigoSunat.Text = oConceptos.con_CodigoSunat
'            chkEsCalculo.Checked = oConceptos.con_Escalculo
'            chkEsCalculoHoras.Checked = oConceptos.con_EsTareoHoras
'            txtDescripcion.Text = oConceptos.con_Descripcion
'            chkEsJuridico.Checked = oConceptos.con_EsConceptoDscJudi



'        End Sub

'        Public Overrides Sub OnManBuscar()

'            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
'            frm.inicio(Constants.BuscadoresNames.Conceptos)

'            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
'                CargarConceptos(frm.dgbRegistro.CurrentRow.Cells(0).Value)
'                menuBuscar()
'            End If
'            frm.Dispose()
'            Pan.Enabled = False

'        End Sub
'        Public Overrides Sub OnManGuardar()
'            If (validar()) Then
'                oConceptos.con_Conceptos_Id = IIf(txtCodigo.Text = "", Nothing, txtCodigo.Text)
'                oConceptos.tic_TipoConcep_Id = cboTipoConcepto.SelectedValue
'                oConceptos.con_Concepto = txtConcepto.Text
'                oConceptos.con_EsFijoTrabajador = chkEsFijo.Checked
'                oConceptos.con_CodigoSunat = txtCodigoSunat.Text
'                oConceptos.con_Escalculo = chkEsCalculo.Checked
'                oConceptos.con_EsTareoHoras = chkEsCalculoHoras.Checked
'                oConceptos.con_Descripcion = txtDescripcion.Text
'                oConceptos.con_EsConceptoDscJudi = chkEsJuridico.Checked
'                oConceptos.Usu_Id = SessionService.UserId
'                oConceptos.con_FECGRAB = Now
'                BCConceptos.Maintenance(oConceptos)
'                ' verificar si se guardo o se edito
'                menuInicio()
'                Pan.Enabled = False
'                limpiar()
'                'finde verificar
'            End If

'        End Sub

'        Public Overrides Sub OnManNuevo()
'            limpiar()
'            menuNuevo()
'            oConceptos = New Conceptos
'            oConceptos.MarkAsAdded()

'            Pan.Enabled = True

'        End Sub

'        Public Overrides Sub OnManSalir()
'            Me.Dispose()
'        End Sub

'        Public Overrides Sub OnManEliminar()
'            oConceptos.MarkAsDeleted()
'            oConceptos.con_Conceptos_Id = IIf(txtCodigo.Text = "", Nothing, txtCodigo.Text)
'            oConceptos.tic_TipoConcep_Id = cboTipoConcepto.SelectedValue
'            oConceptos.con_Concepto = txtConcepto.Text
'            oConceptos.con_EsFijoTrabajador = chkEsFijo.Checked
'            oConceptos.con_CodigoSunat = txtCodigoSunat.Text
'            oConceptos.con_Escalculo = chkEsCalculo.Checked
'            oConceptos.con_EsTareoHoras = chkEsCalculoHoras.Checked
'            oConceptos.con_Descripcion = txtDescripcion.Text
'            oConceptos.con_EsConceptoDscJudi = chkEsJuridico.Checked
'            oConceptos.Usu_Id = SessionService.UserId
'            oConceptos.con_FECGRAB = Now
'            BCConceptos.Maintenance(oConceptos)
'            ' verificar si se elimino
'            Pan.Enabled = False
'            limpiar()
'            ' fin de  verificar
'        End Sub
'        Public Overrides Sub OnManCancelarEdicion()
'            menuInicio()
'            Pan.Enabled = False
'            limpiar()
'        End Sub
'        Public Overrides Sub OnManEditar()
'            menuEditar()
'            Pan.Enabled = True
'        End Sub
'        Public Overrides Sub OnManDeshacerCambios()
'            menuInicio()
'            Pan.Enabled = False
'            limpiar()
'        End Sub

'        Private Sub frmConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'            menuInicio()
'            buscarTipos()
'            Pan.Enabled = False
'        End Sub

'        Private Sub limpiar()
'            txtCodigo.Text = ""
'            txtCodigoSunat.Text = ""
'            txtConcepto.Text = ""
'            txtDescripcion.Text = ""
'            chkEsCalculo.Checked = False
'            chkEsCalculoHoras.Checked = False
'            chkEsFijo.Checked = False
'            chkEsJuridico.Checked = False
'        End Sub

'    End Class
'End Namespace

