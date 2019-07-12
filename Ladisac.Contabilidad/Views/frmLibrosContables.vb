Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views

    Public Class frmLibrosContables

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCLibrosContables As Ladisac.BL.IBCLibrosContables
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Property oLibrosContables As New LibrosContables
        Private Function validar() As Boolean
            Dim result As Boolean = True
            If (txtAbreviatura.Text.Trim = "") Then
                ErrorProvider1.SetError(txtAbreviatura, "Abreviatura ")
                result = False
            Else
                ErrorProvider1.SetError(txtAbreviatura, Nothing)
            End If
            If (txtDescripcion.Text.Trim = "") Then
                ErrorProvider1.SetError(txtDescripcion, "Descripcion")
                result = False
            Else
                ErrorProvider1.SetError(txtDescripcion, Nothing)
            End If

            Return result
        End Function

        Private Sub limpiar()

            txtCodigo.Text = ""
            txtAbreviatura.Text = ""
            txtDescripcion.Text = ""
            txtCodigoSunat.Text = ""

        End Sub

        Sub cargar(ByVal id As String)
            limpiar()
            oLibrosContables = BCLibrosContables.LibrosContablesSeek(id)
            oLibrosContables.MarkAsModified()

            txtCodigo.Text = oLibrosContables.lib_Id
            txtAbreviatura.Text = oLibrosContables.lib_Libro
            txtDescripcion.Text = oLibrosContables.lib_Descripcion
            txtCodigoSunat.Text = oLibrosContables.lib_CodigoSuant

        End Sub
        Public Overrides Sub OnManBuscar()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.LibrosContables)

            If (frm.ShowDialog = DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False
        End Sub

        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            If (validar()) Then
                If (oLibrosContables.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("con.LibrosContables", "lib_Id", 2, "")
                End If

                oLibrosContables.lib_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                oLibrosContables.lib_Libro = txtAbreviatura.Text
                oLibrosContables.lib_Descripcion = txtDescripcion.Text
                oLibrosContables.lib_CodigoSuant = txtCodigoSunat.Text
                oLibrosContables.lib_FECGRAB = Now
                oLibrosContables.Usu_Id = SessionServer.UserId



                Try
                    BCLibrosContables.Maintenance(oLibrosContables)
                    MsgBox("Datos Guardados")
                    menuInicio()
                    Panel1.Enabled = False
                    limpiar()
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
            oLibrosContables = New BE.LibrosContables
            oLibrosContables.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oLibrosContables.MarkAsDeleted()

            oLibrosContables.lib_Id = txtCodigo.Text
            oLibrosContables.Usu_Id = SessionServer.UserId
            oLibrosContables.lib_FECGRAB = Now
            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCLibrosContables.Maintenance(oLibrosContables)

                    Panel1.Enabled = False
                    limpiar()
                    ' fin de  verificar
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


        Private Sub frmLibrosContables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()
            Panel1.Enabled = False

        End Sub
    End Class

End Namespace

'Imports Microsoft.Practices.Unity
'Imports System.IO
'Imports Ladisac.BE

'Namespace Ladisac.Contabilidad.Views
'    Public Class frmClaseCuenta
'        <Dependency()> _
'        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
'        <Dependency()> _
'        Public Property IBCClaseCuenta As Ladisac.BL.IBCClaseCuenta
'        <Dependency()> _
'        Public Property BCUtil As Ladisac.BL.IBCUtil

'        Protected oClaseCuenta As New ClaseCuenta
'        Private Function validar() As Boolean
'            Dim result As Boolean = True

'            If (txtDescripcion.Text.Trim = "") Then
'                ErrorProvider1.SetError(txtDescripcion, "Clase")
'                result = False
'            Else
'                ErrorProvider1.SetError(txtDescripcion, Nothing)
'            End If
'            Return result
'        End Function
'        Private Sub limpiar()
'            txtDescripcion.Text = ""
'            txtCodigo.Text = ""

'        End Sub
'        Sub cargarNivelEducacion(ByVal id As String)
'            limpiar()
'            oClaseCuenta = IBCClaseCuenta.ClaseCuentaSeek(id)

'            oClaseCuenta.MarkAsModified()

'            txtCodigo.Text = oClaseCuenta.cls_Id
'            txtDescripcion.Text = oClaseCuenta.cls_Clase

'        End Sub

'        Public Overrides Sub OnManBuscar()

'            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
'            frm.inicio(Constants.BuscadoresNames.ClaseCuenta)
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
'                If (oClaseCuenta.ChangeTracker.State = ObjectState.Added) Then
'                    sCorrelativo = BCUtil.GetId("con.ClaseCuenta", "cls_Id", 2, "")
'                End If

'                oClaseCuenta.cls_Id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
'                oClaseCuenta.cls_Clase = txtDescripcion.Text

'                oClaseCuenta.Usu_Id = SessionServer.UserId
'                oClaseCuenta.cls_FECGRAB = Now
'                If (IBCClaseCuenta.Maintenance(oClaseCuenta)) Then
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
'            oClaseCuenta = New BE.ClaseCuenta
'            oClaseCuenta.MarkAsAdded()

'            Panel1.Enabled = True

'        End Sub

'        Public Overrides Sub OnManSalir()
'            Me.Dispose()
'        End Sub


'        Public Overrides Sub OnManEliminar()
'            oClaseCuenta.MarkAsDeleted()

'            oClaseCuenta.cls_Id = txtCodigo.Text
'            oClaseCuenta.cls_Clase = txtDescripcion.Text

'            oClaseCuenta.Usu_Id = SessionServer.UserId
'            oClaseCuenta.cls_FECGRAB = Now
'            ' verificar si se elimino
'            IBCClaseCuenta.Maintenance(oClaseCuenta)

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

'        Private Sub frmClaseCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'            menuInicio()

'            Panel1.Enabled = False
'        End Sub
'    End Class
'End Namespace