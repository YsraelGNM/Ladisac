
Imports Microsoft.Practices.Unity
Imports System.IO
Namespace Ladisac.Planillas.Views
    Public Class frmBuscarFechaPersona
        Private sBuscar As String()
        Private sbusco As String


       
        <Dependency()> _
        Public Property BCMarcacion As BL.IBCMarcacion
        <Dependency()> _
        Public Property BCCronogramaVacaciones As BL.IBCCronogramaVacaciones


        Public Sub inicio(ByVal queBusco As String)
            sbusco = queBusco
            ocultarColumnas()

        End Sub

        Public Property campo1() As String = Nothing
        Public Property campo2() As String = Nothing
        Public Property campo3() As String = Nothing


       
        Private Sub ocultarColumnas()

        End Sub
        Public Sub cargarDatos()

            Dim query As String = Nothing
            dgbRegistro.DataSource = Nothing

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.Marcacion) Then
                query = BCMarcacion.MarcacionQuery(CDate(dateDesde.Text), CDate(dateHasta.Text), txtPersona.Tag)
            End If


            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.CronogramaVacaciones) Then
                query = BCCronogramaVacaciones.spPlanillaCronogramaVacacionesBuscarSelectXML(campo1, CDate(dateDesde.Value), CDate(dateHasta.Value), txtPersona.Tag)
            End If


            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    dgbRegistro.DataSource = ds.Tables(0)
                    ocultarColumnas()
                Else
                    dgbRegistro.DataSource = Nothing
                End If
            End If

        End Sub
        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            cargarDatos()
        End Sub

        Private Sub dgbRegistro_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgbRegistro.CellDoubleClick

            If e.RowIndex >= 0 Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        End Sub


        Private Sub frmBuscarFecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoProduccion) Then
                dateDesde.Text = Today.AddMonths(-5)
                dateHasta.Text = Today.AddMonths(2)
            End If



        End Sub


        Private Sub frmBuscarSimple_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
            txtPersona.Focus()
        End Sub

        Private Sub frmBuscarSimple_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtPersona.Focus()
        End Sub

        Private Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
  Handles txtPersona.KeyDown

            Select Case e.KeyValue
                Case 13
                    If dgbRegistro.SelectedRows.Count >= 0 Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If
                Case 27 : Me.Close()
                Case 40 : dgbRegistro.Focus()
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

        Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPersona.TextChanged
            If (txtPersona.Text.Length >= 4) Then
                cargarDatos()
            End If
        End Sub



        Private Sub dateDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateDesde.ValueChanged
            cargarDatos()
        End Sub

        Private Sub btnPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPersona.Click

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.GrupoTrabajoProduccion) Then
                ' busca personas
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.BuscarPersona)

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPersona.Tag = .Cells(0).Value()
                        txtPersona.Text = .Cells(1).Value
                        ' menuBuscar()
                    End With
                End If
                frm.Dispose()

            End If

            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.Marcacion) Then
                'buscar personas 
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.BuscarPersona)

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPersona.Tag = .Cells(0).Value()
                        txtPersona.Text = .Cells(1).Value
                        ' menuBuscar()
                    End With
                End If
                frm.Dispose()
            End If

            ' buscar tipo de planillas 
            If (sbusco = Ladisac.Planillas.Constants.BuscadoresNames.CronogramaVacaciones) Then
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.TiposPlanillas)

                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    txtPersona.Tag = frm.dgbRegistro.CurrentRow.Cells(0).Value
                    txtPersona.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value
                End If
                frm.Dispose()
            End If



        End Sub
    End Class
End Namespace
