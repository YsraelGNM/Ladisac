Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views
    Public Class frmConfiguracionFormatos

       
        <Dependency()> _
        Public Property BCConfiguracionFormatos As Ladisac.BL.IBCConfiguracionFormatos
        
        Protected oConfiguracionFormatos As New BE.ConfiguracionFormatos

        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtDescripcion.Text.Trim = "") Then
                ErrorProvider1.SetError(txtDescripcion, "Descripcion")
                result = False
            Else
                ErrorProvider1.SetError(txtDescripcion, Nothing)
            End If

            If (txtCuentaDesde.Text <> "") Then
                If (txtCuentaHasta.Text = "") Then
                    ErrorProvider1.SetError(txtCuentaHasta, "Cuenta Hasta ")
                    result = False
                Else
                    ErrorProvider1.SetError(txtCuentaHasta, Nothing)
                End If
            End If

            If (txtCuentaHasta.Text <> "") Then
                If (txtCuentaDesde.Text = "") Then
                    ErrorProvider1.SetError(txtCuentaDesde, "Cuenta Desde ")
                    result = False
                Else
                    ErrorProvider1.SetError(txtCuentaDesde, Nothing)
                End If
            End If



            Return result
        End Function
        Private Sub limpiar()
            txtDescripcion.Text = ""
            txtCodigo.Text = ""
            txtCuentaDesde.Text = Nothing
            txtCuentaHasta.Text = Nothing
            txtCuentaDesdeDescripcion.Text = Nothing
            txtCuentaHastaDescripcion.Text = Nothing

        End Sub
        Sub cargar(ByVal id As String)
            limpiar()
            oConfiguracionFormatos = BCConfiguracionFormatos.ConfiguracionFormatosSeek(id)

            oConfiguracionFormatos.MarkAsModified()

            txtCodigo.Text = oConfiguracionFormatos.cofo_Id
            txtDescripcion.Text = oConfiguracionFormatos.cofo_Descripcion

            If (IsDBNull(oConfiguracionFormatos.cuc_IdInicio) OrElse oConfiguracionFormatos.cuc_IdInicio = "") Then
                txtCuentaDesde.Text = Nothing
                txtCuentaDesdeDescripcion.Text = Nothing
            Else
                txtCuentaDesde.Text = oConfiguracionFormatos.cuc_IdInicio
                txtCuentaDesdeDescripcion.Text = oConfiguracionFormatos.CuentasContables.CUC_DESCRIPCION
            End If
            If (IsDBNull(oConfiguracionFormatos.cuc_IdIFin) OrElse oConfiguracionFormatos.cuc_IdIFin = "") Then
                txtCuentaHasta.Text = Nothing
                txtCuentaHastaDescripcion.Text = Nothing

            Else
                txtCuentaHasta.Text = oConfiguracionFormatos.cuc_IdIFin
                txtCuentaHastaDescripcion.Text = oConfiguracionFormatos.CuentasContables1.CUC_DESCRIPCION

            End If

          
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.ConfiguracionFormatos)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            Try
                Dim sCorrelativo As String = ""
                If (validar()) Then

                    oConfiguracionFormatos.CuentasContables = Nothing
                    oConfiguracionFormatos.CuentasContables1 = Nothing

                    oConfiguracionFormatos.cofo_Id = txtCodigo.Text
                    oConfiguracionFormatos.cuc_IdInicio = txtCuentaDesde.Text
                    oConfiguracionFormatos.cuc_IdIFin = txtCuentaHasta.Text
                    oConfiguracionFormatos.cofo_Descripcion = txtDescripcion.Text

                    BCConfiguracionFormatos.Maintenance(oConfiguracionFormatos)
                    MsgBox("Datos Guardados")
                    menuInicio()
                    Panel1.Enabled = False
                    limpiar()

                End If
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                If (rethrow) Then
                    Throw
                End If
            End Try

        End Sub
        Public Overrides Sub OnManNuevo()
            MsgBox("No se puede implementar un nuevo registro,Solo Modificar los Existentes")
            'limpiar()
            'menuNuevo()
            'oConfiguracionFormatos = New BE.ConfiguracionFormatos
            'oConfiguracionFormatos.MarkAsAdded()

            'Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()

            Me.Dispose()
        End Sub

        Public Overrides Sub OnManEliminar()

            MsgBox("No se Puede Eliminar Libros")
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

        Private Sub frmConfiguracionFormatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()
            Panel1.Enabled = False

        End Sub

        Private Sub btnCuentaDesde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCuentaDesde.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CuentasContables)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtCuentaDesde.Text = .Cells(0).Value
                    txtCuentaDesdeDescripcion.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnCuentaHasta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCuentaHasta.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.CuentasContables)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtCuentaHasta.Text = .Cells(0).Value
                    txtCuentaHastaDescripcion.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub
    End Class
End Namespace