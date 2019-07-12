
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmReparoTrabajador
        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCReparoTrabajador As Ladisac.BL.IBCReparoTrabajador

        Protected oReparoTrabajador As New BE.ReparoTrabajador

        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtTrabajador.Text.Trim = "") Then
                ErrorProvider1.SetError(txtTrabajador, "Responsable")
                result = False
            Else
                ErrorProvider1.SetError(txtTrabajador, Nothing)
            End If

            If (txtObservaciones.Text.Trim = "") Then
                ErrorProvider1.SetError(txtObservaciones, "Observaciones")
                result = False
            Else
                ErrorProvider1.SetError(txtObservaciones, Nothing)
            End If
            If (Not validarCeldas()) Then
                result = False
            End If

            Return result
        End Function
        Private Sub limpiar()

            txtNumero.Text = ""
            txtTrabajador.Text = ""
            txtTrabajador.Tag = ""
            txtObservaciones.Text = ""

            dgvDetalle.Rows.Clear()

        End Sub
        Sub cargar(ByVal numero As String)
            limpiar()
            oReparoTrabajador = BCReparoTrabajador.ReparoTrabajadorSeek(numero)
            oReparoTrabajador.MarkAsModified()

            txtNumero.Text = oReparoTrabajador.ret_Numero
            dateFecha.Value = oReparoTrabajador.prm_Fecha

            txtTrabajador.Tag = oReparoTrabajador.per_IdSolitadoPor

            txtTrabajador.Text = IIf(IsNothing(oReparoTrabajador.Personas.PER_APE_PAT), "", oReparoTrabajador.Personas.PER_APE_PAT) & " " & _
                IIf(IsNothing(oReparoTrabajador.Personas.PER_APE_MAT), "", oReparoTrabajador.Personas.PER_APE_MAT) & " " & _
                IIf(IsNothing(oReparoTrabajador.Personas.PER_NOMBRES), "", oReparoTrabajador.Personas.PER_NOMBRES)


            txtObservaciones.Text = oReparoTrabajador.prm_Motivo

            Dim oTable As New DataTable

            oTable = BCReparoTrabajador.SPDetalleReparoTrabajadorSelect(numero)
            Dim x As Integer = 0
            'For Each mItem In oGrupoTrabajo.DetalleGrupoTrabajo
            While x < oTable.Rows.Count

                With oTable.Rows(x)
                    Dim nRow As New DataGridViewRow
                    dgvDetalle.Rows.Add(nRow)

                    Dim oDetalleReparoTrabajadorPLL As New BE.DetalleReparoTrabajador

                    oDetalleReparoTrabajadorPLL.ret_Numero = .Item("ret_Numero")
                    oDetalleReparoTrabajadorPLL.dret_Item = .Item("dret_Item")
                    oDetalleReparoTrabajadorPLL.per_Id = .Item("per_Id")
                    oDetalleReparoTrabajadorPLL.dret_AplicaDia = IIf(IsDBNull(.Item("dret_AplicaDia")), False, .Item("dret_AplicaDia"))
                    oDetalleReparoTrabajadorPLL.dret_AplicaDoble = IIf(IsDBNull(.Item("dret_AplicaDoble")), False, .Item("dret_AplicaDoble"))
                    oDetalleReparoTrabajadorPLL.dret_fecha = CDate(.Item("dret_fecha"))

                    oDetalleReparoTrabajadorPLL.dret_HoraProd = .Item("dret_HoraProd")
                    oDetalleReparoTrabajadorPLL.dret_HoraPll = .Item("dret_HoraPll")

                    oDetalleReparoTrabajadorPLL.dret_Observaciones1 = IIf(IsDBNull(.Item("dret_Observaciones1")), "", .Item("dret_Observaciones1"))
                    oDetalleReparoTrabajadorPLL.dret_Observaciones2 = IIf(IsDBNull(.Item("dret_Observaciones2")), "", .Item("dret_Observaciones2"))


                    ' dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Tag = mItem

                    '  dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Value = mItem.dper_Item

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dret_Item").Tag = oDetalleReparoTrabajadorPLL
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dret_Item").Value = oDetalleReparoTrabajadorPLL.dret_Item
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_Id").Tag = oDetalleReparoTrabajadorPLL.per_Id
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = .Item("Codigo")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Persona").Value = .Item("Nombre")

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dret_AplicaDia").Value = oDetalleReparoTrabajadorPLL.dret_AplicaDia
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dret_AplicaDoble").Value = oDetalleReparoTrabajadorPLL.dret_AplicaDoble

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dret_fecha").Value = CDate(oDetalleReparoTrabajadorPLL.dret_fecha)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dret_HoraProd").Value = oDetalleReparoTrabajadorPLL.dret_HoraProd
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dret_HoraPll").Value = oDetalleReparoTrabajadorPLL.dret_HoraPll
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dret_Observaciones1").Value = oDetalleReparoTrabajadorPLL.dret_Observaciones1
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dret_Observaciones2").Value = oDetalleReparoTrabajadorPLL.dret_Observaciones2

                    oReparoTrabajador.DetalleReparoTrabajador.Add(oDetalleReparoTrabajadorPLL)

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
                    If Not mDetalle.Cells("dret_Item").Value Is Nothing Then
                        With CType(mDetalle.Cells("dret_Item").Tag, BE.DetalleReparoTrabajador)
                            .MarkAsDeleted()
                        End With
                    End If
                    dgvDetalle.Rows.Remove(mDetalle)
                Next

            Else
                MsgBox("Seleccione un registro")
            End If
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarFecha)()
            frm.inicio(Constants.BuscadoresNames.ReparoTrabajador)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False
        End Sub

        Public Overrides Sub OnManGuardar()
            If (validar()) Then
                Try
                    '  If oReparoTrabajador Is Nothing Then
                    dgvDetalle.EndEdit()

                    oReparoTrabajador.prm_Fecha = dateFecha.Value

                    oReparoTrabajador.ret_Numero = txtNumero.Text

                    oReparoTrabajador.Usu_Id = SessionServer.UserId
                    oReparoTrabajador.prm_FECGRAB = Now

                    oReparoTrabajador.prm_Motivo = txtObservaciones.Text

                    oReparoTrabajador.per_IdSolitadoPor = txtTrabajador.Tag

                    For Each mDetalle As DataGridViewRow In dgvDetalle.Rows

                        If (mDetalle.Cells("dret_HoraProd").Value Is Nothing OrElse mDetalle.Cells("dret_HoraProd").Value.ToString = "") Then
                            mDetalle.Cells("dret_HoraProd").Value = 0
                        End If

                        If (mDetalle.Cells("dret_HoraPll").Value Is Nothing OrElse mDetalle.Cells("dret_HoraPll").Value.ToString = "") Then
                            mDetalle.Cells("dret_HoraPll").Value = 0
                        End If

                        If Not mDetalle.Cells("dret_Item").Value Is Nothing Then

                            With CType(mDetalle.Cells("dret_Item").Tag, BE.DetalleReparoTrabajador)


                                .dret_Item = mDetalle.Cells("dret_Item").Value
                                .per_Id = mDetalle.Cells("per_Id").Tag

                                If (IsDBNull(mDetalle.Cells("dret_AplicaDia").Value) OrElse mDetalle.Cells("dret_AplicaDia").Value Is Nothing) Then
                                    .dret_AplicaDia = False
                                Else
                                    .dret_AplicaDia = mDetalle.Cells("dret_AplicaDia").Value
                                End If


                                If (IsDBNull(mDetalle.Cells("dret_AplicaDoble").Value) OrElse mDetalle.Cells("dret_AplicaDoble").Value Is Nothing) Then
                                    .dret_AplicaDoble = False
                                Else
                                    .dret_AplicaDoble = mDetalle.Cells("dret_AplicaDoble").Value
                                End If


                                .dret_fecha = CDate(mDetalle.Cells("dret_fecha").Value)
                                .dret_HoraProd = CDbl(mDetalle.Cells("dret_HoraProd").Value)
                                .dret_HoraPll = CDbl(mDetalle.Cells("dret_HoraPll").Value)
                                .dret_Observaciones1 = mDetalle.Cells("dret_Observaciones1").Value
                                .dret_Observaciones2 = mDetalle.Cells("dret_Observaciones2").Value

                                .Usu_Id = SessionServer.UserId
                                .dret_FECGRAB = Now


                                .MarkAsModified()

                            End With
                        Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                            Dim nOSD As New DetalleReparoTrabajador
                            With nOSD

                                .dret_Item = mDetalle.Cells("dret_Item").Value
                                .per_Id = mDetalle.Cells("per_Id").Tag

                                If (IsDBNull(mDetalle.Cells("dret_AplicaDia").Value) OrElse mDetalle.Cells("dret_AplicaDia").Value Is Nothing) Then
                                    .dret_AplicaDia = False
                                Else
                                    .dret_AplicaDia = mDetalle.Cells("dret_AplicaDia").Value
                                End If

                                If (IsDBNull(mDetalle.Cells("dret_AplicaDoble").Value) OrElse mDetalle.Cells("dret_AplicaDoble").Value Is Nothing) Then
                                    .dret_AplicaDoble = False
                                Else
                                    .dret_AplicaDoble = mDetalle.Cells("dret_AplicaDoble").Value
                                End If


                                .dret_fecha = CDate(mDetalle.Cells("dret_fecha").Value)
                                .dret_HoraProd = CDbl(mDetalle.Cells("dret_HoraProd").Value)
                                .dret_HoraPll = CDbl(mDetalle.Cells("dret_HoraPll").Value)
                                .dret_Observaciones1 = mDetalle.Cells("dret_Observaciones1").Value
                                .dret_Observaciones2 = mDetalle.Cells("dret_Observaciones2").Value

                                .Usu_Id = SessionServer.UserId
                                .dret_FECGRAB = Now

                                .MarkAsAdded()

                            End With
                            oReparoTrabajador.DetalleReparoTrabajador.Add(nOSD)
                        End If
                    Next

                    BCReparoTrabajador.Maintenance(oReparoTrabajador)
                    MsgBox("Datos Guardados")
                    menuInicio()
                    Panel1.Enabled = False
                    limpiar()
                    DeshabilitarElementoGrid()
                    '  End If
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
            oReparoTrabajador = New BE.ReparoTrabajador
            oReparoTrabajador.MarkAsAdded()
            HabilitarElementoGrid()
            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            MsgBox("Estos Datos No se Eliminan solo se Desactivan ")
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


        Private Sub frmReparoTrabajador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub
        Function validarCeldas() As Boolean
            Dim result As Boolean = True
            Dim iRow As Integer = 0

            Try
                While (dgvDetalle.Rows.Count > iRow)
                    With dgvDetalle.Rows(iRow)

                        If (Not (IsNumeric(dgvDetalle.Rows(iRow).Cells("dret_HoraProd").Value)) OrElse Val(dgvDetalle.Rows(iRow).Cells("dret_HoraProd").Value) = 0) Then
                            result = False
                            ErrorProvider1.SetError(dgvDetalle, "Horas")
                            Return result
                        Else
                            ErrorProvider1.SetError(dgvDetalle, Nothing)
                        End If

                        If Not IsDate(dgvDetalle.Rows(iRow).Cells("dret_fecha").Value) Then
                            result = False
                            ErrorProvider1.SetError(dgvDetalle, "Fecha ")
                            Return result
                        Else
                            ErrorProvider1.SetError(dgvDetalle, Nothing)
                        End If

                    End With
                    iRow += 1
                End While
            Catch ex As Exception
                result = False
            End Try

            Return result

            Return result
        End Function
        Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
            Select Case dgvDetalle.Columns(e.ColumnIndex).Name

                Case "per_Id"

                    Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                    frm.inicio(Constants.BuscadoresNames.DatosLaborales)
                    If (frm.ShowDialog = DialogResult.OK) Then
                        With frm.dgbRegistro.CurrentRow

                            dgvDetalle.Rows(e.RowIndex).Cells("Codigo").Value = .Cells(1).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("Persona").Value = .Cells(2).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("per_Id").Tag = .Cells(0).Value
                        End With
                    End If
            End Select
        End Sub

        Private Sub btnTrabajador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrabajador.Click

            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.DatosLaborales)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtTrabajador.Tag = .Cells(0).Value()
                    txtTrabajador.Text = .Cells(2).Value
                    ' menuBuscar()
                End With
            End If
            frm.Dispose()
        End Sub

       
        Private Sub txtCodigoBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoBusca.TextChanged

            Dim x As Integer = 0
            x = 0
            If (txtCodigoBusca.Text.Length >= 4) Then
                While (dgvDetalle.Rows.Count > x)
                    Try
                        If (dgvDetalle.Rows(x).Cells("Codigo").Value = txtCodigoBusca.Text) Then
                            dgvDetalle.CurrentCell = dgvDetalle.Rows(x).Cells("Codigo")
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