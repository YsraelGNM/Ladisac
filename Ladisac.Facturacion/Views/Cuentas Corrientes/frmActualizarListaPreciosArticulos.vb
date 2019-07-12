Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms

Namespace Ladisac.CuentasCorrientes.Views

    Public Class frmActualizarListaPreciosArticulos

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro
        <Dependency()> _
        Public Property BCListaPreciosArticulos As Ladisac.BL.IBCListaPreciosArticulos

      
        Private Simple3 As New Ladisac.BE.RolPersonaTipoPersona

        <Dependency()> _
        Public Property BCKardexCtaCte As BL.IBCKardexCtaCte
        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil

        Private Sub frmActualizarListaPreciosArticulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            lblTitle.Dock = DockStyle.None
            lblTitle.Visible = False
            lblTitle.Enabled = False

            BuscarTipoCliente("000001")

        End Sub

        Public Sub BuscarTipoCliente(ByVal CodigoPER_ID As String)
            Simple3.Vista = "ListarRegistros"
            Dim NombreProcedimiento As String = Simple3.SentenciaSqlBusqueda()
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                CodigoPER_ID, Nothing))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                Dim vCadenaGeType As String = ""
                If (ds.Tables(0).Rows.Count > 0) Then
                    cboTipoCliente.DataSource = ds.Tables(0)
                    cboTipoCliente.DisplayMember = "Descripción"
                    cboTipoCliente.ValueMember = "Código"
                End If
            Else
                cboTipoCliente.DataSource = Nothing
            End If
        End Sub

        Private Sub btnArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArticulo.Click
            Try
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
                frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.ArticulosLadrillo)

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtArticulo.Tag = .Cells(0).Value()
                        txtArticulo.Text = .Cells(2).Value()
                    End With
                End If
                frm.Dispose()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            Dim oTble As New DataTable
            Dim x As Integer = 0

            dgvDetalle.Rows.Clear()
            oTble = BCListaPreciosArticulos.spListaPreciosXTipo(cboTipoCliente.SelectedValue.ToString())
            While (oTble.Rows.Count > x)
                dgvDetalle.Rows.Add(False, oTble.Rows(x).Item(0).ToString, oTble.Rows(x).Item(1).ToString, oTble.Rows(x).Item(2).ToString)
                x += 1
            End While
        End Sub
        Function validar() As Boolean
            Dim res As Boolean = True
            If Not (txtPrecio.Text <> "" AndAlso IsNumeric(txtPrecio.Text)) Then
                ErrorProvider1.SetError(txtPrecio, "Precio ")
                res = False
            Else
                ErrorProvider1.SetError(txtPrecio, "")
            End If

            If (txtArticulo.Text = "") Then
                ErrorProvider1.SetError(txtArticulo, "Articulo")
                res = False
            Else
                ErrorProvider1.SetError(txtArticulo, "")
            End If

            Return res
        End Function

        Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
            If (validar()) Then
                Try

                    BCListaPreciosArticulos.spDetalleListaPreciosUpdate(BCUtil.getXml(0, dgvDetalle, 1), txtArticulo.Tag, txtPrecio.Text)

                    MsgBox("Datos Administrador")
                Catch ex As Exception
                    MsgBox("NO se pudo Procesar la informacion " & vbInformation)
                End Try
            End If
        End Sub

        Private Sub chkMarcar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarcar.CheckedChanged
            Dim x As Integer = 0

            While (dgvDetalle.Rows.Count > x)
                dgvDetalle.Rows(x).Cells(0).Value = chkMarcar.Checked
                x += 1
            End While
           
        End Sub

        Private Sub btnModificarRecarga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarRecarga.Click
            If (validar()) Then
                Try

                    BCListaPreciosArticulos.spDetalleListaPreciosRecargaUpdate(BCUtil.getXml(0, dgvDetalle, 1), txtArticulo.Tag, txtPrecio.Text)

                    MsgBox("Datos Administrador")
                Catch ex As Exception
                    MsgBox("NO se pudo Procesar la informacion " & vbInformation)
                End Try
            End If
        End Sub
    End Class
End Namespace
