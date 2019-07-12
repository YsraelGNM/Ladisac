Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmRegularizarLadrillo
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCDocuMovimiento As Ladisac.BL.IBCDocuMovimiento
    <Dependency()> _
    Public Property BCTipoDocumento As Ladisac.BL.IBCTipoDocumento
    <Dependency()> _
    Public Property BCArticuloAlmacen As Ladisac.BL.IBCArticuloAlmacen
    <Dependency()> _
    Public Property BCReciclajeLadrilloVenta As Ladisac.BL.IBCReciclajeLadrilloVenta

    Dim ARA_Salida As ArticuloAlmacen
    Dim ARA_Ingreso As ArticuloAlmacen
    Dim RCL As ReciclajeLadrilloVenta

    Private Sub frmRegularizarLadrillo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        Select Case CType(sender, DataGridView).Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "ART_ID_SALIDA"
                frm.Tabla = "ArticuloAlmacen"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ARA_Id
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " - " & frm.dgvLista.CurrentRow.Cells(2).Value & " - " & frm.dgvLista.CurrentRow.Cells(7).Value & " - " & frm.dgvLista.CurrentRow.Cells(3).Value 'Codigo + ART_Descripcion + UM + ALMACEN
                End If
            Case "ART_ID_INGRESO"
                frm.Tabla = "ArticuloAlmacen"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ARA_Id
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " - " & frm.dgvLista.CurrentRow.Cells(2).Value & " - " & frm.dgvLista.CurrentRow.Cells(7).Value & " - " & frm.dgvLista.CurrentRow.Cells(3).Value 'Codigo + ART_Descripcion + UM + ALMACEN
                End If
        End Select
        frm.Dispose()
    End Sub

    Public Overrides Sub OnManGuardar()
        Try
            dgvDetalle.EndEdit()
            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If mDetalle.Cells("ART_ID_SALIDA").Tag Is Nothing Or mDetalle.Cells("ART_ID_INGRESO").Tag Is Nothing Then
                    MessageBox.Show("Hay filas que no contienen el Articulo. No se puede guardar")
                    Exit Sub
                End If
            Next

            'Dim ts1 As New TimeSpan(0, 40, 0)
            'Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

            '' '' '' ''SALIDA
            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows

                ARA_Salida = BCArticuloAlmacen.ArticuloAlmacenGetById(mDetalle.Cells("ART_ID_SALIDA").Tag)

                Dim mDocuSA As New DocuMovimiento

                mDocuSA.DMO_FECHA = dtpFecha.Value
                mDocuSA.DTD_ID = "016"
                mDocuSA.TDO_ID = "007"
                mDocuSA.CCT_ID = ""
                mDocuSA.DetalleTipoDocumentos = BCTipoDocumento.TipoDocumentoGetById("016")
                mDocuSA.DMO_SERIE = "009"
                mDocuSA.DMO_NRO = dtpFecha.Value.Ticks.ToString
                mDocuSA.DMO_FECHA_DOCUMENTO = dtpFecha.Value
                mDocuSA.MON_ID = "001" 'Soles
                mDocuSA.DOCU_AFECTA_KARDEX = True
                mDocuSA.DMO_ESTADO = True
                mDocuSA.DMO_FEC_GRAB = Now
                mDocuSA.USU_ID = SessionServer.UserId
                mDocuSA.MarkAsAdded()

                Dim nDMDSA As New DocuMovimientoDetalle
                With nDMDSA
                    .ALM_ID = ARA_Salida.ALM_ID
                    .ART_ID = ARA_Salida.ART_ID
                    .DMD_CANTIDAD = CDbl(mDetalle.Cells("CANT_SALIDA").Value)
                    .DMD_PRECIO_UNITARIO = 1
                    .DMD_IGV = 0
                    .DMD_CONTRAVALOR = CDbl(mDetalle.Cells("CANT_SALIDA").Value)
                    .DMD_GLOSA = "Salida Regularizacion hacia " & mDetalle.Cells("ART_ID_INGRESO").Value
                    .MarkAsAdded()
                End With
                mDocuSA.DocuMovimientoDetalle.Add(nDMDSA)
                If BCDocuMovimiento.MantenimientoDocuMovimiento(mDocuSA) <> 1 Then
                    mDocuSA.MarkAsDeleted()
                    If mDocuSA.DMO_ID > 0 Then BCDocuMovimiento.MantenimientoDocuMovimiento(mDocuSA)
                    MessageBox.Show("Error al Insertar.")
                    Exit Sub
                End If
                ' '' '' '' ''Next

                '' '' '' '' ''INGRESO
                ' '' '' '' ''For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                ARA_Ingreso = BCArticuloAlmacen.ArticuloAlmacenGetById(mDetalle.Cells("ART_ID_INGRESO").Tag)

                Dim mDocuIN As New DocuMovimiento

                mDocuIN.DMO_FECHA = dtpFecha.Value
                mDocuIN.DTD_ID = "015"
                mDocuIN.TDO_ID = "006"
                mDocuIN.CCT_ID = ""
                mDocuIN.DetalleTipoDocumentos = BCTipoDocumento.TipoDocumentoGetById("015")
                mDocuIN.DMO_SERIE = "009"
                mDocuIN.DMO_NRO = mDocuSA.DMO_ID
                mDocuIN.DMO_FECHA_DOCUMENTO = dtpFecha.Value
                mDocuIN.MON_ID = "001" 'Soles
                mDocuIN.DOCU_AFECTA_KARDEX = True
                mDocuIN.DMO_ID_REF = mDocuSA.DMO_ID
                mDocuIN.DMO_ESTADO = True
                mDocuIN.DMO_FEC_GRAB = Now
                mDocuIN.USU_ID = SessionServer.UserId
                mDocuIN.MarkAsAdded()

                Dim nDMDIN As New DocuMovimientoDetalle
                With nDMDIN
                    .ALM_ID = ARA_Ingreso.ALM_ID
                    .ART_ID = ARA_Ingreso.ART_ID
                    .DMD_CANTIDAD = CDbl(mDetalle.Cells("CANT_INGRESO").Value)
                    .DMD_PRECIO_UNITARIO = 1
                    .DMD_IGV = 0
                    .DMD_CONTRAVALOR = CDbl(mDetalle.Cells("CANT_INGRESO").Value)
                    .DMD_GLOSA = "Ingreso Regularizacion de " & mDetalle.Cells("ART_ID_SALIDA").Value
                    .MarkAsAdded()
                End With
                mDocuIN.DocuMovimientoDetalle.Add(nDMDIN)
                If BCDocuMovimiento.MantenimientoDocuMovimiento(mDocuIN) <> 1 Then
                    mDocuSA.MarkAsDeleted()
                    mDocuIN.MarkAsDeleted()
                    If mDocuSA.DMO_ID > 0 Then BCDocuMovimiento.MantenimientoDocuMovimiento(mDocuSA)
                    If mDocuIN.DMO_ID > 0 Then BCDocuMovimiento.MantenimientoDocuMovimiento(mDocuIN)
                    MessageBox.Show("Error al Insertar.")
                    Exit Sub
                End If

                If mDocuSA.DMO_ID > 0 And mDocuIN.DMO_ID > 0 Then
                    'Lleno para guardar el reciclaje 
                    RCL = New ReciclajeLadrilloVenta
                    RCL.MarkAsAdded()
                    RCL.ART_ID = ARA_Salida.ART_ID
                    RCL.RCL_Fecha = mDocuIN.DMO_FECHA
                    If mDetalle.Cells("ART_ID_INGRESO").Value.ToString.Contains("SEGUNDA") Then
                        RCL.RCL_IN_SEGUNDA_HORNO = CInt(mDetalle.Cells("Horno").Value)
                        RCL.RCL_IN_SEGUNDA_SECADO = CInt(mDetalle.Cells("Secado").Value)
                        RCL.RCL_IN_SEGUNDA_DESPACHO = CInt(mDetalle.Cells("Despacho").Value)
                        RCL.RCL_IN_SEGUNDA_TRANSPORTE = CInt(mDetalle.Cells("Transporte").Value)
                    Else
                        RCL.RCL_IN_ESCOMBRO_HORNO = CInt(mDetalle.Cells("Horno").Value)
                        RCL.RCL_IN_ESCOMBRO_SECADO = CInt(mDetalle.Cells("Secado").Value)
                        RCL.RCL_IN_ESCOMBRO_DESPACHO = CInt(mDetalle.Cells("Despacho").Value)
                        RCL.RCL_IN_ESCOMBRO_TRANSPORTE = CInt(mDetalle.Cells("Transporte").Value)
                    End If
                    BCReciclajeLadrilloVenta.MantenimientoReciclajeLadrilloVenta(RCL)
                Else
                    mDocuSA.MarkAsDeleted()
                    mDocuIN.MarkAsDeleted()
                    If mDocuSA.DMO_ID > 0 Then BCDocuMovimiento.MantenimientoDocuMovimiento(mDocuSA)
                    If mDocuIN.DMO_ID > 0 Then BCDocuMovimiento.MantenimientoDocuMovimiento(mDocuIN)
                    MessageBox.Show("Error al insertar, revisar informacion")
                    Exit For
                End If
            Next

            '    Scope.Complete()
            'End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        
        dgvDetalle.Rows.Clear()
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        dgvDetalle.CurrentRow.Cells("CANT_SALIDA").Value = (CInt(dgvDetalle.CurrentRow.Cells("Horno").Value) + CInt(dgvDetalle.CurrentRow.Cells("Secado").Value) + CInt(dgvDetalle.CurrentRow.Cells("Despacho").Value) + CInt(dgvDetalle.CurrentRow.Cells("Transporte").Value)) / 1000
        dgvDetalle.CurrentRow.Cells("CANT_INGRESO").Value = (CInt(dgvDetalle.CurrentRow.Cells("Horno").Value) + CInt(dgvDetalle.CurrentRow.Cells("Secado").Value) + CInt(dgvDetalle.CurrentRow.Cells("Despacho").Value) + CInt(dgvDetalle.CurrentRow.Cells("Transporte").Value)) / 1000
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle_CellDoubleClick(sender, Nothing)
        End If
    End Sub
End Class
