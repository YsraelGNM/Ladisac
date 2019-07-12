Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views
    Public Class frmCuentasArticulo

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCCuentasArticulo As Ladisac.BL.IBCCuentasArticulo
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Property oCuentasArticulo As New CuentasArticulo
        Private Function validar() As Boolean
            Dim result As Boolean = True
            If (txtLinea.Text.Trim = "") Then
                ErrorProvider1.SetError(txtLinea, "Linea")
                result = False
            Else
                ErrorProvider1.SetError(txtLinea, Nothing)
            End If
            'If (txtCompra.Text.Trim = "") Then
            '    ErrorProvider1.SetError(txtCompra, "Descripcion")
            '    result = False
            'Else
            '    ErrorProvider1.SetError(txtCompra, Nothing)
            'End If
            Return result
        End Function

        Private Sub limpiar()

            txtLinea.Text = ""
            txtVenta.Text = ""
            txtCompra.Text = ""
            txtExistencias.Text = ""

        End Sub

        Sub cargar(ByVal id As String)
            limpiar()
            oCuentasArticulo = BCCuentasArticulo.CuentasArticuloSeek(id)
            oCuentasArticulo.MarkAsModified()

            txtLinea.Tag = oCuentasArticulo.lin_Id
            txtVenta.Text = oCuentasArticulo.cuc_IdVenta
            txtCompra.Text = oCuentasArticulo.cuc_IdCompra
            txtExistencias.Text = oCuentasArticulo.cuc_IdExistencias

        End Sub
        Private Sub buscarCuentas(ByVal num As Int16)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.CuentasContables)

            If (frm.ShowDialog = DialogResult.OK) Then
                Select Case num
                    Case 0
                        txtVenta.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                    Case 1
                        txtCompra.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                    Case 2
                        txtExistencias.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value

                End Select

            End If

            frm.Dispose()

        End Sub
        Public Overrides Sub OnManBuscar()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.CuentasArticulo)

            If (frm.ShowDialog = DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                txtLinea.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
                menuBuscar()

            End If
            frm.Dispose()
            Panel1.Enabled = False
        End Sub

        Public Overrides Sub OnManGuardar()
            Dim sCorrelativo As String = ""
            If (validar()) Then

                oCuentasArticulo.lin_Id = txtLinea.Tag
                oCuentasArticulo.cuc_IdVenta = IIf(txtVenta.Text = "", Nothing, txtVenta.Text)
                oCuentasArticulo.cuc_IdCompra = IIf(txtCompra.Text = "", Nothing, txtCompra.Text)
                oCuentasArticulo.cuc_IdExistencias = IIf(txtExistencias.Text = "", Nothing, txtExistencias.Text)
                oCuentasArticulo.lin_FECGRAB = Now
                oCuentasArticulo.Usu_Id = SessionServer.UserId

                Try
                    BCCuentasArticulo.Maintenance(oCuentasArticulo)
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
            oCuentasArticulo = New BE.CuentasArticulo
            oCuentasArticulo.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oCuentasArticulo.MarkAsDeleted()

            oCuentasArticulo.lin_Id = txtLinea.Tag
            oCuentasArticulo.cuc_IdVenta = txtVenta.Text
            oCuentasArticulo.cuc_IdCompra = txtCompra.Text
            oCuentasArticulo.cuc_IdExistencias = txtExistencias.Text
            oCuentasArticulo.lin_FECGRAB = Now
            oCuentasArticulo.Usu_Id = SessionServer.UserId

            ' verificar si se elimino
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCCuentasArticulo.Maintenance(oCuentasArticulo)

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

        Private Sub btnVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVenta.Click
            buscarCuentas(0)
        End Sub

        Private Sub btnCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompra.Click
            buscarCuentas(1)
        End Sub

        Private Sub btnexistencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexistencias.Click
            buscarCuentas(2)
        End Sub

        Private Sub btnLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLinea.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.LineaFamilia)

            If (frm.ShowDialog = DialogResult.OK) Then
                txtLinea.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtLinea.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
              
            End If
            frm.Dispose()

        End Sub

       
        Private Sub btnCompraBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompraBorrar.Click
            txtCompra.Text = ""

        End Sub
    End Class

End Namespace
