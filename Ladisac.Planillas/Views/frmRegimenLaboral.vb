Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE

Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views

    Public Class frmRegimenLaboral
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCRegimenLaboral As Ladisac.BL.IBCRegimenLaboral
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oRegimenLaboral As New RegimenLaboral
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtNivelEducacion.Text.Trim = "") Then
                ErrorProvider1.SetError(txtNivelEducacion, "Descripcion")
                result = False
            Else
                ErrorProvider1.SetError(txtNivelEducacion, Nothing)
            End If

            Return result
        End Function
        Private Sub limpiar()
            txtNivelEducacion.Text = ""
            txtCodigo.Text = ""
            txtCodigoSunat.Text = ""

        End Sub
        Sub cargarRegimenLaboral(ByVal id As String)
            limpiar()
            oRegimenLaboral = BCRegimenLaboral.RegimenLaboralSeek(id)

            oRegimenLaboral.MarkAsModified()

            txtCodigo.Text = oRegimenLaboral.rel_RegLaboral_Id
            txtNivelEducacion.Text = oRegimenLaboral.rel_Descripcioren
            txtCodigoSunat.Text = oRegimenLaboral.rel_CodigoSunat
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.RegimenLaboral)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargarRegimenLaboral(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            If (validar()) Then
                If (oRegimenLaboral.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.RegimenLaboral", "rel_RegLaboral_Id", 3, "")
                End If

                oRegimenLaboral.rel_RegLaboral_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                oRegimenLaboral.rel_Descripcioren = txtNivelEducacion.Text
                oRegimenLaboral.rel_CodigoSunat = txtCodigoSunat.Text
                oRegimenLaboral.Usu_Id = SessionServer.UserId
                oRegimenLaboral.rel_FECGRAB = Now
                Try
                    BCRegimenLaboral.MAintenance(oRegimenLaboral)
                    MsgBox("Datos Guardados")
                    menuInicio()
                    Panel1.Enabled = False
                    limpiar()

                    'finde verificar
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
            oRegimenLaboral = New RegimenLaboral
            oRegimenLaboral.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oRegimenLaboral.MarkAsDeleted()

            oRegimenLaboral.rel_RegLaboral_Id = txtCodigo.Text
            oRegimenLaboral.rel_Descripcioren = txtNivelEducacion.Text
            oRegimenLaboral.rel_CodigoSunat = txtCodigoSunat.Text
            oRegimenLaboral.Usu_Id = SessionServer.UserId
            oRegimenLaboral.rel_FECGRAB = Now
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCRegimenLaboral.MAintenance(oRegimenLaboral)
                    MsgBox("Datos Eliminados")
                End If


            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                If (rethrow) Then
                    Throw
                End If
            End Try


            Panel1.Enabled = False
            limpiar()
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


        Private Sub frmRegimenLaboral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
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