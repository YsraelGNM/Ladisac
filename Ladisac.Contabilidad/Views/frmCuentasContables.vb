Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE

Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views
    Public Class frmCuentasContables

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCCuentasContables As Ladisac.BL.IBCCuentasContables
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oCuentasContables As New CuentasContables

        Private Function validar() As Boolean

            Dim result As Boolean = True
            If (txtCuentaGeneral.Text.Trim = "") Then
                ErrorProvider1.SetError(txtCuentaGeneral, "Cuenta")
                result = False
            Else
                ErrorProvider1.SetError(txtCuentaGeneral, Nothing)
            End If

            If (txtDescripcionGeneral.Text.Trim = "") Then
                ErrorProvider1.SetError(txtDescripcionGeneral, "Cuenta Contable ")
                result = False
            Else
                ErrorProvider1.SetError(txtDescripcionGeneral, Nothing)
            End If

            Return result

        End Function
        Private Sub limpiar()

            txtDescripcionGeneral.Text = ""
            txtCuentaGeneral.Text = ""

            txtClase.Tag = Nothing
            txtClase.Text = ""

            txtCuentaCargo.Text = Nothing
            txtDescripcioncargo.Text = Nothing

            txtCuentaAbono.Text = Nothing
            txtDescripcionAbono.Text = Nothing
            txtAbreviatura.Text = Nothing



        End Sub
        Sub cargarDatos(ByVal id As String)
            limpiar()
            Dim query As String = Nothing
            oCuentasContables = BCCuentasContables.CuentasContablesSeek(id)

            oCuentasContables.MarkAsModified()

            query = Me.BCCuentasContables.CuentasContablesDetalleQuery(id, Nothing)

            If (query <> Nothing) Then
                Dim ds As New DataSet

                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    txtCuentaGeneral.Text = oCuentasContables.CUC_ID
                    txtDescripcionGeneral.Text = oCuentasContables.CUC_DESCRIPCION

                    txtClase.Tag = oCuentasContables.cls_Id
                    txtClase.Text = ds.Tables(0).Rows(0).Item("cls_Clase").ToString

                    txtCuentaCargo.Text = ds.Tables(0).Rows(0).Item("cuc_IdCargo").ToString ' oCuentasContables.cuc_IdCargo
                    txtDescripcioncargo.Text = ds.Tables(0).Rows(0).Item("CUC_DESCRIPCION_CARGO").ToString

                    txtCuentaAbono.Text = ds.Tables(0).Rows(0).Item("cuc_IdAbono").ToString 'oCuentasContables.cuc_IdAbono
                    txtDescripcionAbono.Text = ds.Tables(0).Rows(0).Item("CUC_DESCRIPCION_ABONO").ToString

                    chkActivo.Checked = oCuentasContables.CUC_ESTADO
                    chkCentroCosto.Checked = IIf(IsDBNull(oCuentasContables.cuc_EsCentroCosto), False, oCuentasContables.cuc_EsCentroCosto)
                    Try
                        txtAbreviatura.Text = oCuentasContables.cuc_Abreviatura
                    Catch ex As Exception
                        txtAbreviatura.Text = Nothing
                    End Try



                    Select Case oCuentasContables.cuc_EsMovimiento
                        Case "C"
                            cboEsCuentaDe.SelectedIndex = 0
                        Case "A"
                            cboEsCuentaDe.SelectedIndex = 1
                        Case "M"
                            cboEsCuentaDe.SelectedIndex = 2
                    End Select

                End If
            End If



        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.CuentasContables)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargarDatos(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            Dim estadoObjeto As Boolean
            If (validar()) Then
                If (oCuentasContables.ChangeTracker.State = ObjectState.Modified) Then
                    estadoObjeto = True
                End If
                oCuentasContables.ClaseCuenta = Nothing
                oCuentasContables.CuentasActivos = Nothing
                oCuentasContables.CuentasActivos1 = Nothing
                oCuentasContables.CuentasActivos2 = Nothing
                oCuentasContables.CuentasActivos3 = Nothing
                oCuentasContables.CuentasActivos4 = Nothing
                oCuentasContables.CuentasActivos5 = Nothing
                oCuentasContables.CuentasArticulo1 = Nothing
                oCuentasContables.CuentasArticulo = Nothing
                oCuentasContables.CuentasArticulo2 = Nothing
                oCuentasContables.CuentasVarias = Nothing
                oCuentasContables.CuentasVarias1 = Nothing
                oCuentasContables.CuentasVarias2 = Nothing
                oCuentasContables.CuentasVarias3 = Nothing
                oCuentasContables.CuentasVarias4 = Nothing
                oCuentasContables.CuentasVarias5 = Nothing
                oCuentasContables.CuentasVarias6 = Nothing
                oCuentasContables.CuentasVarias7 = Nothing
                oCuentasContables.CuentasVarias8 = Nothing
                oCuentasContables.CuentasVarias9 = Nothing
                oCuentasContables.CuentasContables1 = Nothing

                oCuentasContables.CuentasContables2 = Nothing
                oCuentasContables.CuentasContables3 = Nothing
                oCuentasContables.CuentasContables11 = Nothing


                oCuentasContables.CUC_ID = txtCuentaGeneral.Text
                oCuentasContables.CUC_DESCRIPCION = txtDescripcionGeneral.Text

                oCuentasContables.cls_Id = txtClase.Tag

                oCuentasContables.cuc_IdCargo = IIf(txtCuentaCargo.Text = "", Nothing, txtCuentaCargo.Text)
                oCuentasContables.cuc_IdAbono = IIf(txtCuentaAbono.Text = "", Nothing, txtCuentaAbono.Text)


                oCuentasContables.cuc_Abreviatura = txtAbreviatura.Text
                oCuentasContables.CUC_ESTADO = chkActivo.Checked

                oCuentasContables.cuc_EsCentroCosto = chkCentroCosto.Checked
                oCuentasContables.USU_ID = SessionServer.UserId

                oCuentasContables.CUC_FEC_GRAB = Now


                Select Case cboEsCuentaDe.SelectedIndex
                    Case 0
                        oCuentasContables.cuc_EsMovimiento = "C"
                    Case 1
                        oCuentasContables.cuc_EsMovimiento = "A"
                    Case 2
                        oCuentasContables.cuc_EsMovimiento = "M"
                End Select
                ' al poner muchos nothing  se pone automaticamenete delete , para evitar eso poer lo siguiente
                If (estadoObjeto) Then
                    oCuentasContables.ChangeTracker.State = ObjectState.Modified
                End If


                Try

                    BCCuentasContables.Maintenance(oCuentasContables)
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
            oCuentasContables = New BE.CuentasContables
            oCuentasContables.MarkAsAdded()
            Panel1.Enabled = True
        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            oCuentasContables.MarkAsDeleted()
            oCuentasContables.CUC_ID = txtCuentaGeneral.Text
            oCuentasContables.CUC_DESCRIPCION = txtCuentaGeneral.Text
            Try
                If (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes) Then
                    BCCuentasContables.Maintenance(oCuentasContables)

                    Panel1.Enabled = False
                    limpiar()
                    ' fin de  verificar
                    MsgBox("Datos Eliminados")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                'If (rethrow) Then
                '    Throw
                'End If
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


        Private Sub frmCuentasContables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub

        Private Sub btnBuscarClase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarClase.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.ClaseCuenta)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                txtClase.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtClase.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value

            End If
            frm.Dispose()
        End Sub

        Private Sub btnEliminarClase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarClase.Click

            txtClase.Tag = Nothing
            txtClase.Text = Nothing

        End Sub

        Private Sub btbBuscarCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btbBuscarCargo.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.CuentasContables)
            If (frm.ShowDialog = Windows.Forms.DialogResult.OK) Then
                txtCuentaCargo.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtDescripcioncargo.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
            End If
            frm.Dispose()

        End Sub

        Private Sub btnEliminarCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarCargo.Click
            txtCuentaCargo.Text = ""
            txtDescripcioncargo.Text = "" 'frm.dgbRegistro.CurrentRow.Cells(1).Value
        End Sub

        Private Sub btnBuscarAbono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAbono.Click
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.CuentasContables)
            If (frm.ShowDialog = Windows.Forms.DialogResult.OK) Then
                txtCuentaAbono.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                txtDescripcionAbono.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
            End If

        End Sub

        Private Sub btnEliminarAbono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarAbono.Click
            txtCuentaAbono.Text = Nothing
            txtDescripcionAbono.Text = Nothing
        End Sub

        Private Sub txtCuentaCargo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuentaCargo.TextChanged

        End Sub
    End Class
End Namespace
