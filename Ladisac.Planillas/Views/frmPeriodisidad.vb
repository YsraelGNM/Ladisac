Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE

Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmPeriodisidad

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCPeriodisidad As Ladisac.BL.IBCPeriodisidad
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oPeriodisidad As New Periodisidad
        Private Function validar() As Boolean
            Dim result As Boolean = True
            If (txtPeriodisidad.Text.Trim = "") Then
                ErrorProvider1.SetError(txtPeriodisidad, "Periodisidad")
                result = False
            Else
                ErrorProvider1.SetError(txtPeriodisidad, Nothing)

            End If

            Return result
        End Function
        Private Sub limpiar()
            txtPeriodisidad.Text = ""
            txtCodigo.Text = ""
            txtCodigoSunat.Text = ""

        End Sub
        Sub cargarPeriodisidad(ByVal id As String)
            limpiar()
            oPeriodisidad = BCPeriodisidad.PeriodisidadSeek(id)

            oPeriodisidad.MarkAsModified()

            txtCodigo.Text = oPeriodisidad.pec_Periodisidad_Id
            txtPeriodisidad.Text = oPeriodisidad.pec_Descripcion
            txtCodigoSunat.Text = oPeriodisidad.pec_CodigoSunat
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Periodisidad)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargarPeriodisidad(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            If (validar()) Then
                If (oPeriodisidad.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.Periodisidad", "pec_Periodisidad_Id", 3, "")
                End If

                oPeriodisidad.pec_Periodisidad_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                oPeriodisidad.pec_Descripcion = txtPeriodisidad.Text
                oPeriodisidad.pec_CodigoSunat = txtCodigoSunat.Text
                oPeriodisidad.Usu_Id = SessionServer.UserId
                oPeriodisidad.pec_FECGRAB = Now
                Try
                    BCPeriodisidad.Maintenance(oPeriodisidad)

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
            oPeriodisidad = New Periodisidad
            oPeriodisidad.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oPeriodisidad.MarkAsDeleted()

            oPeriodisidad.pec_Periodisidad_Id = IIf(txtCodigo.Text = "", Nothing, txtCodigo.Text)
            oPeriodisidad.pec_Descripcion = txtPeriodisidad.Text
            oPeriodisidad.pec_CodigoSunat = txtCodigoSunat.Text
            oPeriodisidad.Usu_Id = SessionServer.UserId
            oPeriodisidad.pec_FECGRAB = Now
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCPeriodisidad.Maintenance(oPeriodisidad)

                    Panel1.Enabled = False
                    limpiar()
                    ' fin de  verificar
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

        Private Sub frmPeriodisidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub
    End Class
End Namespace

'Imports Microsoft.Practices.Unity
'Imports System.IO
'Imports Ladisac.BE

'Namespace Ladisac.Planillas.Views
'    Public Class frmTiposContratos
'        <Dependency()> _
'        Public Property SessionService As Ladisac.Foundation.Services.ISessionService
'        <Dependency()> _
'        Public Property BCTiposContratos As Ladisac.BL.IBCTiposContratos

'        <Dependency()> _
'        Public Property BCUtil As Ladisac.BL.IBCUtil


'        Protected oTiposContratos As New TiposContratos
'        Private Function validar() As Boolean
'            Dim result As Boolean = True

'            If (txtContrato.Text.Trim = "") Then
'                ErrorProvider1.SetError(txtContrato, "Contrato")
'                result = False
'            Else
'                ErrorProvider1.SetError(txtContrato, Nothing)
'            End If

'            Return result
'        End Function
'        Sub cargarTiposContratos(ByVal id As String)
'            limpiar()
'            oTiposContratos = BCTiposContratos.TiposContratosSeek(id)
'            oTiposContratos.MarkAsModified()

'            txtCodigo.Text = oTiposContratos.tic_TipoCont_Id
'            txtContrato.Text = oTiposContratos.tico_Descripcion
'            txtCodigoSunat.Text = oTiposContratos.tic_CodigoSunat

'        End Sub
'        Public Overrides Sub OnManBuscar()

'            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
'            frm.inicio(Constants.BuscadoresNames.TiposContratos)

'            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
'                cargarTiposContratos(frm.dgbRegistro.CurrentRow.Cells(0).Value)
'                menuBuscar()
'            End If
'            frm.Dispose()
'            Panel1.Enabled = False

'        End Sub

'        Public Overrides Sub OnManGuardar()
'            Dim sCorrelativo As String = ""
'            If (validar()) Then
'                If (oTiposContratos.ChangeTracker.State = ObjectState.Added) Then
'                    sCorrelativo = BCUtil.GetId("pla.TiposContratos", "tic_TipoCont_Id", 3, "")
'                End If

'                oTiposContratos.tic_TipoCont_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
'                oTiposContratos.tico_Descripcion = txtContrato.Text
'                oTiposContratos.tic_CodigoSunat = txtCodigoSunat.Text
'                oTiposContratos.Usu_Id = SessionService.UserId
'                oTiposContratos.tic_FECGRAB = Now
'                BCTiposContratos.Maintenance(oTiposContratos)
'                ' verificar si se guardo o se edito
'                menuInicio()
'                Panel1.Enabled = False
'                limpiar()
'                'finde verificar
'            End If

'        End Sub
'        Public Overrides Sub OnManNuevo()
'            limpiar()
'            menuNuevo()
'            oTiposContratos = New TiposContratos
'            oTiposContratos.MarkAsAdded()

'            Panel1.Enabled = True

'        End Sub

'        Public Overrides Sub OnManSalir()
'            Me.Dispose()
'        End Sub


'        Public Overrides Sub OnManEliminar()
'            oTiposContratos.MarkAsDeleted()
'            oTiposContratos.tic_TipoCont_Id = IIf(txtCodigo.Text = "", Nothing, txtCodigo.Text)
'            oTiposContratos.tico_Descripcion = txtContrato.Text
'            oTiposContratos.tic_CodigoSunat = txtCodigoSunat.Text
'            oTiposContratos.Usu_Id = SessionService.UserId
'            oTiposContratos.tic_FECGRAB = Now
'            BCTiposContratos.Maintenance(oTiposContratos)
'            ' verificar si se elimino
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

'        Private Sub limpiar()
'            txtCodigo.Text = ""
'            txtCodigoSunat.Text = ""
'            txtContrato.Text = ""
'        End Sub

'        Private Sub frmTiposContratos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'            menuInicio()

'            Panel1.Enabled = False
'        End Sub
'    End Class
'End Namespace
