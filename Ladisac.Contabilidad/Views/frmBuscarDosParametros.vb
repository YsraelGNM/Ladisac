
Imports Microsoft.Practices.Unity
Imports System.IO
Namespace Ladisac.Contabilidad.Views
    Public Class frmBuscarDosParametros
        Private sBuscar As String
        Private sBusco As String
        Public Property campo1() As String = Nothing
        Public Property campo2() As String = Nothing
        Public Property campo3() As String = Nothing

        <Dependency()> _
        Public Property BCCuentasContables As Ladisac.BL.IBCCuentasContables

        Public Sub inicio(ByVal queBusco As String)
            sBusco = queBusco

        End Sub
     

        Public Sub OcultarColumnas()

            Try
                If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.TiposComprobantesSelectXML) Then
                    dgbRegistro.Columns(0).Visible = False
                    dgbRegistro.Columns(1).Visible = False
                    dgbRegistro.Columns(2).Visible = False
                    dgbRegistro.Columns(3).Width = "140"
                End If
            Catch ex As Exception

            End Try
        End Sub
        Public Sub cargarDatos()
            Dim query As String = Nothing


          

            If (sBusco = Ladisac.Contabilidad.Constants.BuscadoresNames.CuentasContables) Then

                query = Me.BCCuentasContables.CuentasContablesQuery(txtCuenta.Text, txtDescripcion.Text, txtabrevitura.Text, 1)

            End If

           

            If (query <> Nothing) Then
                Dim ds As New DataSet

                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    dgbRegistro.DataSource = ds.Tables(0)
                Else
                    dgbRegistro.DataSource = Nothing
                End If
            End If
            OcultarColumnas()
        End Sub

        Private Sub dgbRegistro_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgbRegistro.CellDoubleClick
            If e.RowIndex >= 0 Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            cargarDatos()
        End Sub


        Private Sub frmBuscarDosParametros_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
            txtCuenta.Focus()
        End Sub

        Private Sub frmBuscarDosParametros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtCuenta.Focus()
        End Sub

        Private Sub _KeyDownTexto(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtCuenta.KeyDown, txtDescripcion.KeyDown, txtabrevitura.KeyDown

            If (e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Enter) Then

                If (txtCuenta.Focused = True) Then
                    txtDescripcion.Focus()
                    Exit Sub
                End If
                If (txtDescripcion.Focused = True) Then
                    dgbRegistro.Focus()
                    Exit Sub
                End If
                If (txtabrevitura.Focused = True) Then
                    txtDescripcion.Focus()
                    Exit Sub
                End If

            End If

            If (e.KeyCode = Keys.Up) Then
                If (txtDescripcion.Focused = True) Then
                    txtCuenta.Focus()
                    Exit Sub
                End If

            End If
            If (e.KeyCode = Keys.Right) Then
                If (txtDescripcion.Focused = True) Then
                    txtabrevitura.Focus()
                    Exit Sub
                End If

            End If


            Select Case e.KeyValue
                Case 13
                    If dgbRegistro.SelectedRows.Count >= 0 Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If
                Case 27 : Me.Close()

            End Select

        End Sub


        Private Sub dataRegistros_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgbRegistro.KeyDown
            Select Case e.KeyValue
                Case 13
                    If dgbRegistro.SelectedRows.Count >= 0 Then

                        e.SuppressKeyPress = True

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If
                Case 27 : Me.Close()
            End Select

        End Sub


        Private Sub txtCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuenta.TextChanged
            If (txtCuenta.Text.Length >= 1) Then
                cargarDatos()
            End If
        End Sub

        Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
            If (txtDescripcion.Text.Length >= 1) Then
                cargarDatos()
            End If
        End Sub

        Private Sub txtabrevitura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtabrevitura.TextChanged
            If (txtabrevitura.Text.Length >= 1) Then
                cargarDatos()
            End If
        End Sub
    End Class
End Namespace
