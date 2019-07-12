Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views
    Public Class frmCuentasVarias

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property BCCuentasVarias As Ladisac.BL.IBCCuentasVarias

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Protected oCuentasVarias As New CuentasVarias

        Private Function validar() As Boolean
            Dim result As Boolean = True

            Return result
        End Function
        Private Sub limpiar()
            txtCodigo.Text = ""

            txtIGVVentas.Text = ""
            txtIgvCompras.Text = ""
            txtIgvPercepcionVenta.Text = ""
            txtIgvRetencionVenta.Text = ""
            txtRentaCuarta.Text = ""
            txtComprasExisten.Text = ""
            txtGDC.Text = ""
            txtGRD.Text = ""
            txtPDC.Text = ""
            txtPRD.Text = ""

            txtIGVVentasDescripcion.Text = ""
            txtIgvComprasDescripcion.Text = ""

            txtIgvPercepcionDescripcionVenta.Text = ""
            txtIgvRetencionDescripcionVenta.Text = ""

            txtIgvPercepcionCompra.Text = ""
            txtIgvPercepcionDescripcionCompra.Text = ""

            txtIgvRetencionCompra.Text = ""
            txtIgvRetencionDescripcionCompra.Text = ""

            txtRentaCuartaDescripcion.Text = ""
            txtComprasExistenDescripcion.Text = ""
            txtGDCDescripcion.Text = ""
            txtGRDDescripcion.Text = ""
            txtPDCDescripcion.Text = ""
            txtPRDDescripcion.Text = ""



        End Sub
        Sub cargar(ByVal id As String)
            limpiar()

            oCuentasVarias = BCCuentasVarias.CuentasVariasSeek(id)
            oCuentasVarias.MarkAsModified()

            txtCodigo.Text = oCuentasVarias.cuv_Id

            If (oCuentasVarias.cuc_IdIgvVentas Is Nothing OrElse oCuentasVarias.cuc_IdIgvVentas = "") Then
                txtIGVVentas.Text = Nothing
                txtIGVVentasDescripcion.Text = Nothing

            Else
                txtIGVVentas.Text = oCuentasVarias.cuc_IdIgvVentas
                txtIGVVentasDescripcion.Text = oCuentasVarias.CuentasContables.CUC_DESCRIPCION

            End If

            If (oCuentasVarias.cuc_IdIgvCompras Is Nothing OrElse oCuentasVarias.cuc_IdIgvCompras = "") Then
                txtIgvCompras.Text = Nothing
                txtIgvComprasDescripcion.Text = Nothing
            Else
                txtIgvCompras.Text = oCuentasVarias.cuc_IdIgvCompras
                txtIgvComprasDescripcion.Text = oCuentasVarias.CuentasContables1.CUC_DESCRIPCION

            End If
            ' para ventas 
            If (oCuentasVarias.cuc_IdIgvPerceVenta Is Nothing OrElse oCuentasVarias.cuc_IdIgvPerceVenta = "") Then
                txtIgvPercepcionVenta.Text = Nothing
                txtIgvPercepcionDescripcionVenta.Text = Nothing
            Else
                txtIgvPercepcionVenta.Text = oCuentasVarias.cuc_IdIgvPerceVenta
                txtIgvPercepcionDescripcionVenta.Text = oCuentasVarias.CuentasContables2.CUC_DESCRIPCION
            End If

            If (oCuentasVarias.cuc_IdIgvReteVenta Is Nothing OrElse oCuentasVarias.cuc_IdIgvReteVenta = "") Then
                txtIgvRetencionVenta.Text = Nothing
                txtIgvRetencionDescripcionVenta.Text = Nothing
            Else
                txtIgvRetencionVenta.Text = oCuentasVarias.cuc_IdIgvReteVenta
                txtIgvRetencionDescripcionVenta.Text = oCuentasVarias.CuentasContables3.CUC_DESCRIPCION
            End If
            ' para compras 
            If (oCuentasVarias.cuc_IdIgvPerceCompra Is Nothing OrElse oCuentasVarias.cuc_IdIgvPerceCompra = "") Then
                txtIgvPercepcionCompra.Text = Nothing
                txtIgvPercepcionDescripcionCompra.Text = Nothing
            Else
                txtIgvPercepcionCompra.Text = oCuentasVarias.cuc_IdIgvPerceCompra
                txtIgvPercepcionDescripcionCompra.Text = oCuentasVarias.CuentasContables4.CUC_DESCRIPCION
            End If

            If (oCuentasVarias.cuc_IdIgvReteCompra Is Nothing OrElse oCuentasVarias.cuc_IdIgvReteVenta = "") Then
                txtIgvRetencionCompra.Text = Nothing
                txtIgvRetencionDescripcionCompra.Text = Nothing
            Else
                txtIgvRetencionCompra.Text = oCuentasVarias.cuc_IdIgvReteCompra
                txtIgvRetencionDescripcionCompra.Text = oCuentasVarias.CuentasContables5.CUC_DESCRIPCION
            End If


            If (oCuentasVarias.cuc_IdRentaCuarta Is Nothing OrElse oCuentasVarias.cuc_IdRentaCuarta = "") Then
                txtRentaCuarta.Text = Nothing
                txtRentaCuartaDescripcion.Text = Nothing
            Else
                txtRentaCuarta.Text = oCuentasVarias.cuc_IdRentaCuarta
                txtRentaCuartaDescripcion.Text = oCuentasVarias.CuentasContables6.CUC_DESCRIPCION
            End If


            If (oCuentasVarias.cuc_IdComprasExisten Is Nothing OrElse oCuentasVarias.cuc_IdComprasExisten = "") Then
                txtComprasExisten.Text = Nothing
                txtComprasExistenDescripcion.Text = Nothing
            Else
                txtComprasExisten.Text = oCuentasVarias.cuc_IdComprasExisten
                txtComprasExistenDescripcion.Text = oCuentasVarias.CuentasContables7.CUC_DESCRIPCION
            End If


            If (oCuentasVarias.cuc_IdPDC Is Nothing OrElse oCuentasVarias.cuc_IdPDC = "") Then
                txtPDC.Text = Nothing
                txtPDCDescripcion.Text = Nothing

            Else
                txtPDC.Text = oCuentasVarias.cuc_IdPDC
                txtPDCDescripcion.Text = oCuentasVarias.CuentasContables8.CUC_DESCRIPCION

            End If

            If (oCuentasVarias.cuc_IdGDC Is Nothing OrElse oCuentasVarias.cuc_IdGDC = "") Then
                txtGDC.Text = Nothing
                txtGDCDescripcion.Text = Nothing

            Else
                txtGDC.Text = oCuentasVarias.cuc_IdGDC
                txtGDCDescripcion.Text = oCuentasVarias.CuentasContables9.CUC_DESCRIPCION

            End If

            If (oCuentasVarias.cuc_IdGRD Is Nothing OrElse oCuentasVarias.cuc_IdGRD = "") Then
                txtGRD.Text = Nothing
                txtGRDDescripcion.Text = Nothing
            Else
                txtGRD.Text = oCuentasVarias.cuc_IdGRD
                txtGRDDescripcion.Text = oCuentasVarias.CuentasContables10.CUC_DESCRIPCION

            End If


            If (oCuentasVarias.cuc_IdPRD Is Nothing OrElse oCuentasVarias.cuc_IdPRD = "") Then
                txtPRD.Text = Nothing
                txtPRDDescripcion.Text = Nothing
            Else
                txtPRD.Text = oCuentasVarias.cuc_IdPRD
                txtPRDDescripcion.Text = oCuentasVarias.CuentasContables11.CUC_DESCRIPCION

            End If


        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.CuentasVarias)

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

                    If (oCuentasVarias.ChangeTracker.State = ObjectState.Added) Then
                        sCorrelativo = BCUtil.GetId("Mae.CuentasVarias", "cuv_Id ", 3, "")
                        oCuentasVarias.cuv_Id = sCorrelativo
                    End If

                    oCuentasVarias.cuc_IdIgvVentas = IIf(txtIGVVentas.Text <> "", txtIGVVentas.Text, Nothing)
                    oCuentasVarias.cuc_IdIgvCompras = IIf(txtIgvCompras.Text = "", Nothing, txtIgvCompras.Text)
                    oCuentasVarias.cuc_IdIgvPerceCompra = IIf(txtIgvPercepcionCompra.Text = "", Nothing, txtIgvPercepcionCompra.Text)
                    oCuentasVarias.cuc_IdIgvReteCompra = IIf(txtIgvRetencionCompra.Text = "", Nothing, txtIgvRetencionCompra.Text)
                    oCuentasVarias.cuc_IdIgvPerceVenta = IIf(txtIgvPercepcionVenta.Text = "", Nothing, txtIgvPercepcionVenta.Text)
                    oCuentasVarias.cuc_IdIgvReteVenta = IIf(txtIgvRetencionVenta.Text = "", Nothing, txtIgvRetencionVenta.Text)
                    oCuentasVarias.cuc_IdRentaCuarta = IIf(txtRentaCuarta.Text = "", Nothing, txtRentaCuarta.Text)
                    oCuentasVarias.cuc_IdComprasExisten = IIf(txtComprasExisten.Text = "", Nothing, txtComprasExisten.Text)
                    oCuentasVarias.cuc_IdGDC = IIf(txtGDC.Text = "", Nothing, txtGDC.Text)
                    oCuentasVarias.cuc_IdGRD = IIf(txtGRD.Text = "", Nothing, txtGRD.Text)
                    oCuentasVarias.cuc_IdPDC = IIf(txtPDC.Text = "", Nothing, txtPDC.Text)
                    oCuentasVarias.cuc_IdPRD = IIf(txtPRD.Text = "", Nothing, txtPRD.Text)
                    oCuentasVarias.cue_FECGRAB = Now

                    oCuentasVarias.Usu_Id = SessionServer.UserId

                    BCCuentasVarias.Maintenance(oCuentasVarias)

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
            Dim sCorrelativo As String

            sCorrelativo = BCUtil.GetId("Mae.CuentasVarias", "cuv_Id    ", 3, "")
            If (Val(sCorrelativo) <= 1) Then
                limpiar()
                menuNuevo()
                oCuentasVarias = New BE.CuentasVarias
                oCuentasVarias.MarkAsAdded()

                Panel1.Enabled = True
            Else
                MessageBox.Show("YA existe una Confuguracion en el sistema ( Edite la Actual) ")
            End If
        End Sub

        Public Overrides Sub OnManSalir()

            Me.Dispose()
        End Sub

        Public Overrides Sub OnManEliminar()

            MsgBox("NO esta disponibles esta accion")
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

        Private Sub frmCuentasVarias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            menuInicio()
            Panel1.Enabled = False

        End Sub

        Private Sub buscarCuentas(ByVal num As Int16)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.CuentasContables)

            If (frm.ShowDialog = DialogResult.OK) Then
                Select Case num
                    Case 0
                        txtIgvCompras.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                        txtIgvComprasDescripcion.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
                    Case 1
                        txtIGVVentas.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                        txtIGVVentasDescripcion.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
                    Case 2
                        txtIgvPercepcionVenta.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                        txtIgvPercepcionDescripcionVenta.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
                    Case 3
                        txtIgvRetencionVenta.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                        txtIgvRetencionDescripcionVenta.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
                    Case 4
                        txtRentaCuarta.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                        txtRentaCuartaDescripcion.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
                    Case 5
                        txtComprasExisten.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                        txtComprasExistenDescripcion.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
                    Case 6
                        txtGDC.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                        txtGDCDescripcion.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
                    Case 7
                        txtPDC.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                        txtPDCDescripcion.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
                    Case 8
                        txtGRD.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                        txtGRDDescripcion.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value

                    Case 9
                        txtPRD.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                        txtPRDDescripcion.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
                    Case 10
                        txtIgvPercepcionCompra.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                        txtIgvPercepcionDescripcionCompra.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value

                    Case 11
                        txtIgvRetencionCompra.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
                        txtIgvRetencionDescripcionCompra.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
                End Select

            End If

            frm.Dispose()

        End Sub


        Private Sub btnIgvCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIgvCompras.Click
            buscarCuentas(0)
        End Sub

        Private Sub btnIGVVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIGVVentas.Click
            buscarCuentas(1)
        End Sub

        Private Sub btnIgvPercepcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIgvPercepcion.Click
            buscarCuentas(2)
        End Sub

        Private Sub btnIgvRetencion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIgvRetencion.Click
            buscarCuentas(3)
        End Sub

        Private Sub btnRentaCuarta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRentaCuarta.Click
            buscarCuentas(4)
        End Sub

        Private Sub btnComprasExisten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComprasExisten.Click
            buscarCuentas(5)
        End Sub

        Private Sub btnGDC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGDC.Click
            buscarCuentas(6)
        End Sub

        Private Sub btnPDC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPDC.Click
            buscarCuentas(7)
        End Sub

        Private Sub btnGRD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGRD.Click
            buscarCuentas(8)
        End Sub

        Private Sub btnPRD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPRD.Click
            buscarCuentas(9)
        End Sub

        Private Sub btnPercCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPercCompra.Click
            buscarCuentas(10)
        End Sub

        Private Sub btnRetCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetCompra.Click
            buscarCuentas(11)
        End Sub
    End Class
End Namespace

