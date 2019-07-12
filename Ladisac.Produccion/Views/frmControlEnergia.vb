Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmControlEnergia
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCControlEnergia As Ladisac.BL.IBCControlEnergia
    Protected mCEN As ControlEnergia

    Private Sub frmControlEnergia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        Try
            Dim query = BCControlEnergia.ListadoControlEnergia
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            For Each mFila As DataRow In ds.Tables(0).Rows
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_ID").Value = mFila.Item("CEN_ID")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_AR_CON_ENE").Tag = mFila.Item("CEN_AR_CON_ENE")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CONSUMO_ID").Value = mFila.Item("CONSUMO_ID")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_DESCRIPCION").Value = mFila.Item("CEN_DESCRIPCION")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_FECHA").Value = mFila.Item("CEN_FECHA")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_FACTOR").Value = mFila.Item("CEN_FACTOR")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_PROPORCION").Value = mFila.Item("CEN_PROPORCION")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_HI").Value = mFila.Item("CEN_HI")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_HF").Value = mFila.Item("CEN_HF")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_KWH_INI").Value = mFila.Item("CEN_KWH_INI")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_KWH_FIN").Value = mFila.Item("CEN_KWH_FIN")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_HO_PU_IN").Value = mFila.Item("CEN_HO_PU_IN")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_HO_PU_FI").Value = mFila.Item("CEN_HO_PU_FI")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_TOTAL_HO_PUNTA").Value = mFila.Item("CEN_TOTAL_HO_PUNTA")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_RE_IN").Value = mFila.Item("CEN_RE_IN")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_RE_FI").Value = mFila.Item("CEN_RE_FI")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_AC_PLA_KWH").Value = mFila.Item("CEN_AC_PLA_KWH")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_AC_HOR_KWH").Value = mFila.Item("CEN_AC_HOR_KWH")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_HORAS_TRABAJO").Value = mFila.Item("CEN_HORAS_TRABAJO")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_RE_PLANTA_KVAR").Value = mFila.Item("CEN_RE_PLANTA_KVAR")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_GRUPO").Value = mFila.Item("CEN_GRUPO")
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CEN_TARIFA").Value = mFila.Item("CEN_TARIFA")
            Next
        Catch ex As Exception
            MessageBox.Show("Error al cargar la data.")
        End Try

    End Sub

    Public Overrides Sub OnReportes()
        MyBase.OnReportes()
        Dim Her As New Herramientas
        Her.excelExportar(Her.ToTable(dgvDetalle, "Energia"))
    End Sub

    Public Overrides Sub OnManGuardar()
        dgvDetalle.EndEdit()
        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
            If mDetalle.Cells("CEN_ID").Value IsNot Nothing Then
                mCEN = BCControlEnergia.ControlEnergiaGetById(mDetalle.Cells("CEN_ID").Value)
                With mCEN
                    .CEN_ID = CInt(mDetalle.Cells("CEN_ID").Value)
                    .CEN_AR_CON_ENE = CInt(mDetalle.Cells("CEN_AR_CON_ENE").Tag)
                    .CONSUMO_ID = CInt(mDetalle.Cells("CONSUMO_ID").Value)
                    .CEN_DESCRIPCION = mDetalle.Cells("CEN_DESCRIPCION").Value
                    .CEN_FECHA = CDate(mDetalle.Cells("CEN_FECHA").Value)
                    .CEN_FACTOR = CDec(mDetalle.Cells("CEN_FACTOR").Value)
                    .CEN_PROPORCION = CDec(mDetalle.Cells("CEN_PROPORCION").Value)
                    .CEN_HI = CDec(mDetalle.Cells("CEN_HI").Value)
                    .CEN_HF = CDec(mDetalle.Cells("CEN_HF").Value)
                    .CEN_KWH_INI = CDec(mDetalle.Cells("CEN_KWH_INI").Value)
                    .CEN_KWH_FIN = CDec(mDetalle.Cells("CEN_KWH_FIN").Value)
                    .CEN_HO_PU_IN = CDec(mDetalle.Cells("CEN_HO_PU_IN").Value)
                    .CEN_HO_PU_FI = CDec(mDetalle.Cells("CEN_HO_PU_FI").Value)
                    .CEN_TOTAL_HO_PUNTA = CDec(mDetalle.Cells("CEN_TOTAL_HO_PUNTA").Value)
                    .CEN_RE_IN = CDec(mDetalle.Cells("CEN_RE_IN").Value)
                    .CEN_RE_FI = CDec(mDetalle.Cells("CEN_RE_FI").Value)
                    .CEN_AC_PLA_KWH = CDec(mDetalle.Cells("CEN_AC_PLA_KWH").Value)
                    .CEN_AC_HOR_KWH = CDec(mDetalle.Cells("CEN_AC_HOR_KWH").Value)
                    .CEN_HORAS_TRABAJO = CDec(mDetalle.Cells("CEN_HORAS_TRABAJO").Value)
                    .CEN_RE_PLANTA_KVAR = CDec(mDetalle.Cells("CEN_RE_PLANTA_KVAR").Value)
                    .CEN_GRUPO = CDec(mDetalle.Cells("CEN_GRUPO").Value)
                    .CEN_TARIFA = mDetalle.Cells("CEN_TARIFA").Value
                    .CEN_ESTADO = True
                    .CEN_FEC_GRAB = Now
                    .USU_ID = SessionServer.UserId
                    .MarkAsModified()
                    BCControlEnergia.MantenimientoControlEnergia(mCEN)
                End With
            Else

                If mDetalle.Cells("CONSUMO_ID").Value > 0 Then
                    mCEN = New ControlEnergia
                    With mCEN
                        .CEN_AR_CON_ENE = CInt(mDetalle.Cells("CEN_AR_CON_ENE").Tag)
                        .CONSUMO_ID = CInt(mDetalle.Cells("CONSUMO_ID").Value)
                        .CEN_DESCRIPCION = mDetalle.Cells("CEN_DESCRIPCION").Value
                        .CEN_FECHA = CDate(mDetalle.Cells("CEN_FECHA").Value)
                        .CEN_FACTOR = CDec(mDetalle.Cells("CEN_FACTOR").Value)
                        .CEN_PROPORCION = CDec(mDetalle.Cells("CEN_PROPORCION").Value)
                        .CEN_HI = CDec(mDetalle.Cells("CEN_HI").Value)
                        .CEN_HF = CDec(mDetalle.Cells("CEN_HF").Value)
                        .CEN_KWH_INI = CDec(mDetalle.Cells("CEN_KWH_INI").Value)
                        .CEN_KWH_FIN = CDec(mDetalle.Cells("CEN_KWH_FIN").Value)
                        .CEN_HO_PU_IN = CDec(mDetalle.Cells("CEN_HO_PU_IN").Value)
                        .CEN_HO_PU_FI = CDec(mDetalle.Cells("CEN_HO_PU_FI").Value)
                        .CEN_TOTAL_HO_PUNTA = CDec(mDetalle.Cells("CEN_TOTAL_HO_PUNTA").Value)
                        .CEN_RE_IN = CDec(mDetalle.Cells("CEN_RE_IN").Value)
                        .CEN_RE_FI = CDec(mDetalle.Cells("CEN_RE_FI").Value)
                        .CEN_AC_PLA_KWH = CDec(mDetalle.Cells("CEN_AC_PLA_KWH").Value)
                        .CEN_AC_HOR_KWH = CDec(mDetalle.Cells("CEN_AC_HOR_KWH").Value)
                        .CEN_HORAS_TRABAJO = CDec(mDetalle.Cells("CEN_HORAS_TRABAJO").Value)
                        .CEN_RE_PLANTA_KVAR = CDec(mDetalle.Cells("CEN_RE_PLANTA_KVAR").Value)
                        .CEN_GRUPO = CDec(mDetalle.Cells("CEN_GRUPO").Value)
                        .CEN_TARIFA = mDetalle.Cells("CEN_TARIFA").Value
                        .CEN_ESTADO = True
                        .CEN_FEC_GRAB = Now
                        .USU_ID = SessionServer.UserId
                        .MarkAsAdded()
                        BCControlEnergia.MantenimientoControlEnergia(mCEN)
                    End With
                End If
            End If
        Next

    End Sub


    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "CEN_AR_CON_ENE"
                frm.Tabla = "AreaConsumoEnergia"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'eno_Id
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'ENO_Descripcion
                    dgvDetalle.CurrentRow.Cells("CEN_TARIFA").Value = frm.dgvLista.CurrentRow.Cells(2).Value  'tarifa
                    dgvDetalle.CurrentRow.Cells("CEN_FACTOR").Value = frm.dgvLista.CurrentRow.Cells(3).Value  'factor
                    dgvDetalle.CurrentRow.Cells("CEN_GRUPO").Value = frm.dgvLista.CurrentRow.Cells(4).Value  'grupo
                End If
            Case "CONSUMO_ID"
                frm.Tabla = "ArConEne"
                frm.Tipo = dgvDetalle.CurrentRow.Cells("CEN_AR_CON_ENE").Tag
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value  'Codigo
                    dgvDetalle.CurrentRow.Cells("CEN_DESCRIPCION").Value = frm.dgvLista.CurrentRow.Cells(1).Value  'descripcion
                    dgvDetalle.CurrentRow.Cells("CEN_FECHA").Value = frm.dgvLista.CurrentRow.Cells(2).Value  'fecha
                    dgvDetalle.CurrentRow.Cells("CEN_HI").Value = frm.dgvLista.CurrentRow.Cells(3).Value  'hi
                    dgvDetalle.CurrentRow.Cells("CEN_HF").Value = frm.dgvLista.CurrentRow.Cells(4).Value  'hf
                End If
        End Select
        frm.Dispose()
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
        dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(1)
        If dgvDetalle.CurrentRow.Index > 0 Then
            For Each mCol As DataGridViewColumn In dgvDetalle.Columns
                dgvDetalle.CurrentRow.Cells(mCol.Index).Value = dgvDetalle.Rows(dgvDetalle.CurrentRow.Index - 1).Cells(mCol.Index).Value
                dgvDetalle.CurrentRow.Cells(mCol.Index).Tag = dgvDetalle.Rows(dgvDetalle.CurrentRow.Index - 1).Cells(mCol.Index).Tag
            Next
            dgvDetalle.CurrentRow.Cells("CEN_ID").Value = Nothing
        End If
    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        Dim HoraI As Double = 0
        Dim HoraF As Double = 0

        Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "CEN_HI", "CEN_HF"
                Try
                    If Not IsDate(Replace(dgvDetalle.CurrentCell.Value, ".", ":")) Then
                        dgvDetalle.CurrentCell.Value = "00.00"
                        Exit Sub
                    Else
                        If dgvDetalle.CurrentCell.Value.ToString.Length = 3 Then dgvDetalle.CurrentCell.Value = dgvDetalle.CurrentCell.Value.ToString & "0"
                        If dgvDetalle.CurrentCell.Value.ToString.Length = 4 Then dgvDetalle.CurrentCell.Value = "0" & dgvDetalle.CurrentCell.Value.ToString
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
        End Select

        If dgvDetalle.CurrentRow.Cells("CEN_HI").Value IsNot Nothing And dgvDetalle.CurrentRow.Cells("CEN_HF").Value IsNot Nothing Then
            If dgvDetalle.CurrentRow.Cells("CEN_HI").Value < dgvDetalle.CurrentRow.Cells("CEN_HF").Value Then
                HoraI = Double.Parse(dgvDetalle.CurrentRow.Cells("CEN_HI").Value.ToString.Substring(0, 2)) + Double.Parse(dgvDetalle.CurrentRow.Cells("CEN_HI").Value.ToString.Substring(3, 2)) / 60
                HoraF = Double.Parse(dgvDetalle.CurrentRow.Cells("CEN_HF").Value.ToString.Substring(0, 2)) + Double.Parse(dgvDetalle.CurrentRow.Cells("CEN_HF").Value.ToString.Substring(3, 2)) / 60
                dgvDetalle.CurrentRow.Cells("CEN_HORAS_TRABAJO").Value = HoraF - HoraI
            Else
                HoraI = 24 - (Double.Parse(dgvDetalle.CurrentRow.Cells("CEN_HI").Value.ToString.Substring(0, 2)) + Double.Parse(dgvDetalle.CurrentRow.Cells("CEN_HI").Value.ToString.Substring(3, 2)) / 60)
                HoraF = Double.Parse(dgvDetalle.CurrentRow.Cells("CEN_HF").Value.ToString.Substring(0, 2)) + Double.Parse(dgvDetalle.CurrentRow.Cells("CEN_HF").Value.ToString.Substring(3, 2)) / 60
                dgvDetalle.CurrentRow.Cells("CEN_HORAS_TRABAJO").Value = HoraF + HoraI
            End If
        End If

        '''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''
        '((( ([EnHoPuFi] - [EnHoPuIn]))* [Factor] )   )* [Proporcion]
        dgvDetalle.CurrentRow.Cells("CEN_TOTAL_HO_PUNTA").Value = ((((dgvDetalle.CurrentRow.Cells("CEN_HO_PU_FI").Value - dgvDetalle.CurrentRow.Cells("CEN_HO_PU_IN").Value)) * dgvDetalle.CurrentRow.Cells("CEN_FACTOR").Value)) * dgvDetalle.CurrentRow.Cells("CEN_PROPORCION").Value
        'if( [Tarifa]="A" , ((([TotalKWhFinal]-[TotalKWhInicio])*[Factor])*[Proporcion]),
        'if( [Tarifa]="B" , ((([TotalKWhFinal]-[TotalKWhInicio])*[Factor])*[Proporcion])  , 0 ) )
        dgvDetalle.CurrentRow.Cells("CEN_AC_PLA_KWH").Value = IIf(CInt(dgvDetalle.CurrentRow.Cells("CEN_TARIFA").Value) = 1, (((dgvDetalle.CurrentRow.Cells("CEN_KWH_FIN").Value - dgvDetalle.CurrentRow.Cells("CEN_KWH_INI").Value) * dgvDetalle.CurrentRow.Cells("CEN_FACTOR").Value) * dgvDetalle.CurrentRow.Cells("CEN_PROPORCION").Value), If(CInt(dgvDetalle.CurrentRow.Cells("CEN_TARIFA").Value) = 2, (((dgvDetalle.CurrentRow.Cells("CEN_KWH_FIN").Value - dgvDetalle.CurrentRow.Cells("CEN_KWH_INI").Value) * dgvDetalle.CurrentRow.Cells("CEN_FACTOR").Value) * dgvDetalle.CurrentRow.Cells("CEN_PROPORCION").Value), 0))
        'if( [Tarifa]="A" ,(([EnReFi]-[EnReIn])*[Factor])*[Proporcion], 0 )
        dgvDetalle.CurrentRow.Cells("CEN_RE_PLANTA_KVAR").Value = IIf(CInt(dgvDetalle.CurrentRow.Cells("CEN_TARIFA").Value) = 1, ((dgvDetalle.CurrentRow.Cells("CEN_RE_FI").Value - dgvDetalle.CurrentRow.Cells("CEN_RE_IN").Value) * dgvDetalle.CurrentRow.Cells("CEN_FACTOR").Value) * dgvDetalle.CurrentRow.Cells("CEN_PROPORCION").Value, 0)
        '''''''''''''''''''''''''''
        '''''''''''''''''''''''''''

    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle_CellDoubleClick(sender, Nothing)
        End If
    End Sub
End Class