
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling


Namespace Ladisac.Planillas.Views
    Public Class frmMarcacion


        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil

        <Dependency()> _
        Public Property BCMarcacion As BL.IBCMarcacion


        Protected oMarcaciones As New List(Of BE.Marcaciones)
        Private Function validar() As Boolean
            Dim result As Boolean = False
            Return True

        End Function

        Private Sub limpiar()
            dgvDetalle.Rows.Clear()

        End Sub
        Sub cargar(ByVal fecha As Date, ByVal persona As String)
            limpiar()
            Dim oTAble As New DataTable

            oTAble = BCMarcacion.SPDetalleMarcacionSelect(persona, fecha)
            Dim x As Integer = 0

            While x < oTAble.Rows.Count

                With oTAble.Rows(x)
                    'Dim nRow As New DataGridViewRow
                    dgvDetalle.Rows.Add()

                    Dim oNewDetalleMarcacion As New BE.Marcaciones
                    oNewDetalleMarcacion.mar_estado = .Item("estado")
                    oNewDetalleMarcacion.PER_ID = .Item("PER_ID")
                    oNewDetalleMarcacion.mar_marcacion = .Item("marcacion")
                    oNewDetalleMarcacion.mar_Movimiento = .Item("Movimiento")
                    oNewDetalleMarcacion.mar_tipo = .Item("tipo")
                    oNewDetalleMarcacion.mar_observaciones = .Item("observaciones")

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PER_ID").Value = .Item("PER_ID")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PER_ID").Tag = .Item("PER_ID")

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = .Item("Codigo")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Nombre").Value = .Item("Nombre")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mar_marcacion").Value = .Item("marcacion")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mar_estado").Value = .Item("estado")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mar_Movimiento").Value = .Item("Movimiento")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mar_tipo").Value = .Item("tipo")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("mar_observaciones").Value = .Item("observaciones")

                    oMarcaciones.Add(oNewDetalleMarcacion)

                End With

                x += 1
            End While
        End Sub

        Public Overrides Sub OnManAgregarFilaGrid()

            Dim iRow As Integer = 0
            dgvDetalle.Rows.Add()
        End Sub

        Public Overrides Sub OnManQuitarFilaGrid()
            If (dgvDetalle.SelectedRows.Count > 0) Then

                For Each mDetalle As DataGridViewRow In dgvDetalle.SelectedRows
                    'If Not mDetalle.Cells("Numero").Value Is Nothing Then
                    '    With CType(mDetalle.Cells("Numero").Tag, BE.DetalleComedorPLL)
                    '        .MarkAsDeleted()
                    '    End With
                    'End If
                    dgvDetalle.Rows.Remove(mDetalle)
                Next

            Else
                MsgBox("Seleccione un registro")
            End If
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarFechaPersona)()
            frm.inicio(Constants.BuscadoresNames.Marcacion)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value, "")
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False
        End Sub
        Public Overrides Sub OnManGuardar()
            If (validar()) Then
                Try
                    oMarcaciones = New List(Of BE.Marcaciones)



                    For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                       
                        Dim nOSD As New BE.Marcaciones

                        With nOSD

                            .PER_ID = mDetalle.Cells("per_id").Tag
                            .mar_marcacion = mDetalle.Cells("mar_marcacion").Value
                            .mar_estado = IIf(IsDBNull(mDetalle.Cells("mar_estado").Value), "", mDetalle.Cells("mar_estado").Value)
                            .mar_Movimiento = IIf(IsDBNull(mDetalle.Cells("mar_Movimiento").Value), "", mDetalle.Cells("mar_Movimiento").Value)
                            .mar_tipo = IIf(IsDBNull(mDetalle.Cells("mar_Tipo").Value), "", mDetalle.Cells("mar_Tipo").Value)
                            .mar_observaciones = IIf(IsDBNull(mDetalle.Cells("mar_Observaciones").Value), "", mDetalle.Cells("mar_Observaciones").Value)
                            .mar_FECGRAB = Now

                            .USU_ID = SessionServer.UserId

                            .MarkAsAdded()

                        End With

                        oMarcaciones.Add(nOSD)

                    Next

                    BCMarcacion.maintenance(oMarcaciones)
                    MsgBox("Datos Guardados")
                    menuInicio()
                    Panel1.Enabled = False
                    limpiar()
                    DeshabilitarElementoGrid()

                Catch ex As Exception

                    MsgBox(ex.Message)

                    'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                    'If (rethrow) Then
                    '    Throw
                    'End If

                End Try

            End If

        End Sub
        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oMarcaciones = Nothing
            'oComedorPLL.MarkAsAdded()
            HabilitarElementoGrid()
            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            Try
                For Each mDetalle As DataGridViewRow In dgvDetalle.Rows

                    Dim nOSD As New BE.Marcaciones

                    With nOSD


                        .PER_ID = mDetalle.Cells("per_id").Tag
                        .mar_marcacion = mDetalle.Cells("mar_marcacion").Value
                        .mar_estado = mDetalle.Cells("mar_estado").Value
                        .mar_Movimiento = mDetalle.Cells("mar_estado").Value
                        .mar_tipo = mDetalle.Cells("mar_estado").Value
                        .mar_observaciones = mDetalle.Cells("mar_estado").Value
                        .mar_FECGRAB = Now

                        .USU_ID = SessionServer.UserId

                        .MarkAsDeleted()

                    End With

                    oMarcaciones.Add(nOSD)

                Next

                BCMarcacion.maintenance(oMarcaciones)
                MsgBox("Datos Eliminados")
                menuInicio()
                Panel1.Enabled = False
                limpiar()
                DeshabilitarElementoGrid()

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
            HabilitarElementoGrid()
        End Sub
        Public Overrides Sub OnManDeshacerCambios()
            menuInicio()
            Panel1.Enabled = False
            limpiar()
        End Sub

        Private Sub btnPlantillaExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantillaExcel.Click

            Dim oTabble As New DataTable("Comedor")

            oTabble.Columns.Add("ACNo")
            oTabble.Columns.Add("Nombre")
            oTabble.Columns.Add("Marc")
            oTabble.Columns.Add("Estado")
            oTabble.Columns.Add("NvoEstado")
            oTabble.Columns.Add("Tipo")
            oTabble.Columns.Add("Operacion")

            BCUtil.excelExportar(oTabble)

        End Sub


        Sub CarcarPersona(ByVal iFila As Integer)

            If (dgvDetalle.Rows(iFila).Cells(1).Value <> "") Then
                Try

                    Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                    frm.inicio(Constants.BuscadoresNames.DatosLaborales)
                    frm.llenarCombo()

                    frm.cboBuscar.SelectedIndex = 1
                    frm.txtBuscar.Text = dgvDetalle.Rows(iFila).Cells(1).Value
                    frm.cargarDatos()

                    If (frm.dgbRegistro.RowCount > 0) Then
                        With frm.dgbRegistro.Rows(0)
                            dgvDetalle.Rows(iFila).Cells("Codigo").Tag = .Cells(0).Value
                            dgvDetalle.Rows(iFila).Cells("Codigo").Value = .Cells(1).Value
                            dgvDetalle.Rows(iFila).Cells("Nombre").Value = .Cells(2).Value
                            dgvDetalle.Rows(iFila).Cells("per_id").Tag = .Cells(0).Value
                        End With
                    Else
                        dgvDetalle.Rows(iFila).Cells("Codigo").Tag = Nothing
                        dgvDetalle.Rows(iFila).Cells("Codigo").Value = Nothing
                        dgvDetalle.Rows(iFila).Cells("Nombre").Value = Nothing
                        dgvDetalle.Rows(iFila).Cells("per_id").Tag = Nothing

                    End If
                Catch ex As Exception
                    dgvDetalle.Rows(iFila).Cells("Codigo").Tag = Nothing
                    dgvDetalle.Rows(iFila).Cells("Codigo").Value = Nothing
                    dgvDetalle.Rows(iFila).Cells("Nombre").Value = Nothing
                    dgvDetalle.Rows(iFila).Cells("per_id").Tag = Nothing
                End Try
            End If




        End Sub

        Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
            Dim sRuta As String = ""
            Dim sNombreHoja As String = "Hoja4"
            OpenFileDialog1.ShowDialog()
            Dim oTable As New DataTable
            Dim x As Integer = 0
            If (OpenFileDialog1.FileName <> "") Then

                sNombreHoja = InputBox("Nombre de la Hoja de Excel", "Inportar Marcaciones", "Hoja4")

                If (sNombreHoja.Trim <> "") Then

                    Try
                        sRuta = OpenFileDialog1.FileName
                        oTable = BCUtil.excelImportacionConFormato(sRuta, "Select ACNo,	Nombre,Marc,Estado,NvoEstado,Tipo,Operacion from [" & sNombreHoja & "$]")

                        While (oTable.Rows.Count > x)
                            With oTable.Rows(x)
                                If (IsDBNull(.Item(0)) OrElse .Item(0) = "") Then
                                    x = oTable.Rows.Count
                                Else
                                    dgvDetalle.Rows.Add(Nothing, _
                                                                                      .Item(0), _
                                                                                      Nothing, _
                                                                                      .Item(2), _
                                                                                      .Item(3), _
                                                                                       .Item(4), _
                                                                                         .Item(5), _
                                                                                         .Item(6))
                                End If





                                CarcarPersona(dgvDetalle.Rows.Count - 1)
                            End With
                            x += 1
                        End While

                    Catch ex As Exception
                        MsgBox("Error de importacion :" & ex.Message)
                    End Try

                Else
                    MsgBox("Si no Ingresa no se puede importar")
                End If
            Else
            End If

            OpenFileDialog1.Dispose()
        End Sub

        Private Sub frmMarcacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub

        Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
            Select Case dgvDetalle.Columns(e.ColumnIndex).Name

                Case "per_id"

                    Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                    frm.inicio(Constants.BuscadoresNames.DatosLaborales)

                    If (frm.ShowDialog = DialogResult.OK) Then

                        With frm.dgbRegistro.CurrentRow
                            dgvDetalle.Rows(e.RowIndex).Cells("Codigo").Tag = .Cells(0).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("Codigo").Value = .Cells(1).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("Nombre").Value = .Cells(2).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("per_id").Tag = .Cells(0).Value
                        End With

                    End If

            End Select
        End Sub

        Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
            Dim x As Integer = 0
            x = 0
            If (txtCodigo.Text.Length >= 4) Then
                While (dgvDetalle.Rows.Count > x)
                    Try
                        If (dgvDetalle.Rows(x).Cells("Codigo").Value = txtCodigo.Text) Then
                            dgvDetalle.CurrentCell = dgvDetalle.Rows(x).Cells(0)
                            Exit Sub
                        End If
                    Catch ex As Exception

                    End Try
                    x += 1
                End While

            End If
        End Sub
    End Class
End Namespace
