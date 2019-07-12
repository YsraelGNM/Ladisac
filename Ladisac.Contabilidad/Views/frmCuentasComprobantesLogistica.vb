Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE

Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Contabilidad.Views
    Public Class frmCuentasComprobantesLogistica

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCAlmacen As Ladisac.BL.IBCAlmacen
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        <Dependency()> _
        Public Property BCCuentasComprobantesLogistica As Ladisac.BL.IBCCuentasComprobantesLogistica


        Private Function validar() As Boolean
            Dim result As Boolean = True
            If (dgvDetalle.Rows.Count <= 0) Then
                MsgBox("Ingresar como minimo una cuenta")
                result = False
            End If
            Return result
        End Function

        Private Sub limpiar()
            dgvDetalle.Rows.Clear()

        End Sub
        Sub cargar()
            limpiar()
            Dim x As Integer = 0
            Dim oTable As New DataTable
            Dim query As String
            query = BCCuentasComprobantesLogistica.spCuentasComprobantesLogisticaSelect(0)

            If (query <> Nothing) Then
                Dim ds As New DataSet

                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    oTable = ds.Tables(0)
                Else
                    oTable = Nothing
                End If
            End If

            dgvDetalle.Rows.Clear()

            While (oTable.Rows.Count > x)

                dgvDetalle.Rows.Add()
                dgvDetalle.Rows(x).Cells(1).Value = oTable.Rows(x).Item(0)
                dgvDetalle.Rows(x).Cells(2).Value = oTable.Rows(x).Item(1)

                dgvDetalle.Rows(x).Cells(4).Value = oTable.Rows(x).Item(2)
                dgvDetalle.Rows(x).Cells(5).Value = oTable.Rows(x).Item(3)
                x += 1

            End While
            
        End Sub

        Public Overrides Sub OnManBuscar()

            cargar()
            menuBuscar()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()

            If (validar()) Then

                Try

                    BCCuentasComprobantesLogistica.Maintenance(BCUtil.getXml(dgvDetalle, 1, 4), SessionServer.UserId.ToString)
                    MsgBox("Datos Guardados")
                    menuInicio()
                    Panel1.Enabled = False
                    limpiar()
                    DeshabilitarElementoGrid()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'finde verificar
            End If
        End Sub

        Public Overrides Sub OnManNuevo()




            limpiar()
            menuNuevo()
            cargar()

            HabilitarElementoGrid()
            Panel1.Enabled = True


        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub
        Public Overrides Sub OnManEliminar()
              If (validar()) Then

                Try

                    If (MsgBox("Esta seguro de borra todo", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then

                        BCCuentasComprobantesLogistica.Maintenance(BCUtil.getXml(dgvDetalle, 1, 4), SessionServer.UserId.ToString)
                        MsgBox("Datos Guardados")
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'finde verificar
            End If

        End Sub

        Public Overrides Sub OnManCancelarEdicion()
            menuInicio()
            'Panel1.Enabled = False
            limpiar()
        End Sub
        Public Overrides Sub OnManAgregarFilaGrid()
            dgvDetalle.Rows.Add()
        End Sub
        Public Overrides Sub OnManQuitarFilaGrid()
            If (dgvDetalle.SelectedRows.Count > 0) Then
                If (MsgBox("Se Eliminara los Registros ¿Continuar?", vbYesNo) = vbYes) Then


                    For Each mDetalle As DataGridViewRow In dgvDetalle.SelectedRows
                       
                        dgvDetalle.Rows.Remove(mDetalle)
                    Next



                End If

            End If
        End Sub

        Public Overrides Sub OnManEditar()
            menuEditar()
            Panel1.Enabled = True
            HabilitarElementoGrid()

        End Sub
        Public Overrides Sub OnManDeshacerCambios()
            menuInicio()
            ' Panel1.Enabled = False
            limpiar()
        End Sub

      

        Private Sub frmPeriodisidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
            menuInicio()

            'Panel1.Enabled = False
        End Sub

        Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

        End Sub


        Private Sub dgvDetalle_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
            Try
                Select Case dgvDetalle.Columns(e.ColumnIndex).Name
                    Case "CUC_ID"

                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarDosParametros)()
                        frm.inicio(Constants.BuscadoresNames.CuentasContables)

                        If (frm.ShowDialog = DialogResult.OK) Then
                            dgvDetalle.Rows(e.RowIndex).Cells("cuc_id").Value = frm.dgbRegistro.CurrentRow.Cells(0).Value
                            dgvDetalle.Rows(e.RowIndex).Cells(4).Value = frm.dgbRegistro.CurrentRow.Cells(0).Value
                            dgvDetalle.Rows(e.RowIndex).Cells(5).Value = frm.dgbRegistro.CurrentRow.Cells(1).Value
                       
                        End If
                        frm.Dispose()

                    Case "alm_id"
                        Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                        frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarAlmacen)
                        If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                            With frm.dgbRegistro.CurrentRow
                                dgvDetalle.Rows(e.RowIndex).Cells(1).Value = .Cells(0).Value
                                dgvDetalle.Rows(e.RowIndex).Cells(2).Value = .Cells(1).Value
                            End With
                        End If
                        frm.Dispose()
                End Select

            Catch ex As Exception

            End Try

        End Sub

        Private Sub frmCuentasComprobantesLogistica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()
            Panel1.Enabled = False
        End Sub
    End Class
End Namespace
