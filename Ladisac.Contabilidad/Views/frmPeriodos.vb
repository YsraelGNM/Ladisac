
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views
    Public Class frmPeriodos
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCPeriodo As Ladisac.BL.IBCPeriodos

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oPeriodo As New Periodo
        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtCodigo.Text.Trim = "") Then
                ErrorProvider1.SetError(txtCodigo, "Periodo")
                result = False
            Else
                ErrorProvider1.SetError(txtCodigo, Nothing)
            End If
            If (Not IsNumeric(txtCodigo.Text)) Then
                ErrorProvider1.SetError(txtCodigo, "Periodo")
                result = False
            Else
                ErrorProvider1.SetError(txtCodigo, Nothing)
            End If

            If (txtCodigo.Text.Length <> 6) Then
                ErrorProvider1.SetError(txtCodigo, "Periodo")
                result = False
            Else
                ErrorProvider1.SetError(txtCodigo, Nothing)
            End If



            Return result
        End Function
        Private Sub limpiar()

            txtCodigo.Text = ""
            txtCodigo.Enabled = False

        End Sub
        Sub cargar(ByVal id As String)
            limpiar()
            oPeriodo = BCPeriodo.PeriodoSeek(id)

            oPeriodo.MarkAsModified()

            txtCodigo.Text = oPeriodo.prd_Periodo_id
            'chkActivo.Checked = oPeriodo.prd_Activo ' cls_Clase
            chkCompras.Checked = oPeriodo.prd_compras
            chkContabilidad.Checked = oPeriodo.prd_Contabilidad
            chkFacturacion.Checked = oPeriodo.prd_Facturacion
            chkTesoreria.Checked = oPeriodo.prd_Tesoretia


        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.Periodo)

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
                    If (oPeriodo.ChangeTracker.State = ObjectState.Added) Then
                        sCorrelativo = BCUtil.GetId("con.ClaseCuenta", "cls_Id", 2, "")
                    End If

                    oPeriodo.prd_Periodo_id = IIf(txtCodigo.Text = "", sCorrelativo, txtCodigo.Text)
                    'oPeriodo.prd_Activo = chkActivo.Checked
                    oPeriodo.prd_Contabilidad = chkContabilidad.Checked
                    oPeriodo.prd_Facturacion = chkFacturacion.Checked
                    oPeriodo.prd_compras = chkCompras.Checked
                    oPeriodo.prd_Tesoretia = chkTesoreria.Checked



                    oPeriodo.Usu_Id = SessionServer.UserId
                    oPeriodo.prd_FECGRAB = Now
                    BCPeriodo.Maintenance(oPeriodo)
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

            limpiar()

            txtCodigo.Enabled = True
            menuNuevo()
            oPeriodo = New BE.Periodo
            oPeriodo.MarkAsAdded()

            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()

            Me.Dispose()
        End Sub

        Public Overrides Sub OnManEliminar()

            oPeriodo.MarkAsDeleted()

            oPeriodo.prd_Periodo_id = txtCodigo.Text
            'oPeriodo.prd_Activo = chkActivo.Checked

            oPeriodo.prd_Contabilidad = chkContabilidad.Checked
            oPeriodo.prd_Facturacion = chkFacturacion.Checked
            oPeriodo.prd_compras = chkCompras.Checked
            oPeriodo.prd_Tesoretia = chkTesoreria.Checked


            oPeriodo.Usu_Id = SessionServer.UserId
            oPeriodo.prd_FECGRAB = Now

            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCPeriodo.Maintenance(oPeriodo)
                    Panel1.Enabled = False
                    limpiar()
                    MsgBox("Datos Eliminados")

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
    End Class
End Namespace

