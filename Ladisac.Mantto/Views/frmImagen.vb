Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO

Public Class frmImagen
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCEntidad As Ladisac.BL.IBCEntidad
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mENO As Entidad

    Private Sub frmImagen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()

        Call validacion_desactivacion(False, 1)
        txtEntidad.TabIndex = 2
        dgvDetalle.TabIndex = 1

    End Sub

    Sub LimpiarControles()
        mENO = Nothing
        txtEntidad.Text = String.Empty
        txtEntidad.Tag = Nothing
        picImagen.Image = Nothing
        dgvDetalle.Rows.Clear()
        lblRuta.Text = String.Empty
    End Sub

    Private Sub txtEntidad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntidad.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Entidad"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtEntidad.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ENO_Id
            txtEntidad.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
            lblRuta.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Ruta
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value 'ENO_Id
            CargarEntidad(key)
            LlenarControles()
        End If
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        Select Case e.ColumnIndex
            Case 2
                Try
                    ResetRutaImagen()
                    If Me.ofdImagen.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        'Me.picImagen.Image = Image.FromFile(ofdImagen.FileName)
                        dgvDetalle.CurrentCell.Value = ofdImagen.FileName
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
        End Select
        frm.Dispose()
    End Sub

    Public Overrides Sub OnManEliminar()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 3)
    End Sub

    Public Overrides Sub OnManGuardar()
        If mENO IsNot Nothing Then
            dgvDetalle.EndEdit()
            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("IMA_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("IMA_ID").Tag, Imagen)
                        .IMA_DESCRIPCION = mDetalle.Cells("IMA_DESCRIPCION").Value
                        '.IMA_RUTA = mDetalle.Cells("IMA_RUTA").Value 'MMMMMMMMM no se puede cambiar por ahora
                        .IMA_OBSERVACION = mDetalle.Cells("IMA_OBSERVACION").Value
                        '.IMA_ARCHIVO = Nothing
                        .IMA_ESTADO = True
                        .IMA_FEC_GRAB = Now
                        .USU_ID = SessionServer.UserId
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("IMA_DESCRIPCION").Value Is Nothing Then
                    Dim nIMA As New Imagen
                    With nIMA
                        .IMA_DESCRIPCION = mDetalle.Cells("IMA_DESCRIPCION").Value
                        .IMA_RUTA = NombreArchivo(mDetalle.Cells("IMA_RUTA").Value)
                        .IMA_OBSERVACION = mDetalle.Cells("IMA_OBSERVACION").Value
                        .IMA_ARCHIVO = ReadBinaryFile(mDetalle.Cells("IMA_RUTA").Value)
                        .IMA_ESTADO = True
                        .IMA_FEC_GRAB = Now
                        .USU_ID = SessionServer.UserId
                        .MarkAsAdded()
                    End With
                    mENO.Imagen.Add(nIMA)
                End If
            Next

            BCEntidad.MantenimientoEntidad(mENO)
            MessageBox.Show(mENO.ENO_ID)
            LimpiarControles()
        End If
        Call validacion_desactivacion(False, 3)
    End Sub

    Function NombreArchivo(ByVal Cadena As String) As String
        Dim Archivo As New FileInfo(Cadena)
        Return Archivo.Name
    End Function

    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mENO = New Entidad
        mENO.MarkAsAdded()
        Call validacion_desactivacion(True, 2)
        txtEntidad.Focus()
    End Sub

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Entidad"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarEntidad(key)
            LlenarControles()
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarEntidad(ByVal ENO_Id As Integer)
        mENO = BCEntidad.EntidadGetById(ENO_Id)
        mENO.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtEntidad.Text = mENO.ENO_DESCRIPCION
        txtEntidad.Tag = mENO.ENO_ID
        lblRuta.Text = mENO.ENO_RUTA
        For Each mItem In mENO.Imagen
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IMA_ID").Value = mItem.IMA_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IMA_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IMA_DESCRIPCION").Value = mItem.IMA_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IMA_RUTA").Value = mItem.IMA_RUTA
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IMA_OBSERVACION").Value = mItem.IMA_OBSERVACION
        Next
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)
    End Sub
    'Private Sub dgvDetalle_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEnter
    '    Try
    '        Dim ruta As String = Convert.ToString(dgvDetalle.CurrentRow.Cells("IMA_Ruta").Value)
    '        If ruta.Length > 0 Then
    '            Me.picImagen.Image = Image.FromFile(ruta)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("La imagen ha sido borrada o movida de su sitio original", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End Try
    'End Sub

    Private Sub ResetRutaImagen()
        With ofdImagen
            .Reset()
            .InitialDirectory = "D:\"
            .Filter = "Bmp files (*.bmp)|*.bmp|Jpg files (*.jpg)|*.jpg|All files (*.*)|*.*"
            .FilterIndex = -1
        End With
    End Sub

    Private Sub picImagen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picImagen.DoubleClick
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.Show()
    End Sub

    Private Sub picImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picImagen.Click
        Me.PrintDocument1.DefaultPageSettings.Landscape = True
        Me.PrintDocument1.DefaultPageSettings.Margins.Right = 0.5
        Me.PrintDocument1.DefaultPageSettings.Margins.Left = 0.5
        Me.PrintDocument1.DefaultPageSettings.Margins.Bottom = 0.5
        Me.PrintDocument1.DefaultPageSettings.Margins.Top = 0.5
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            Dim fnt As Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)
            e.Graphics.DrawString("Entidad :", fnt, Brushes.Black, 10, 20)
            e.Graphics.DrawString(txtEntidad.Text, fnt, Brushes.Black, 100, 20)
            e.Graphics.DrawString("Titulo :", fnt, Brushes.Black, 10, 50)
            e.Graphics.DrawString(dgvDetalle.CurrentRow.Cells("IMA_Ruta").Value.ToString, fnt, Brushes.Black, 100, 50)
            e.Graphics.DrawImage(picImagen.Image, 10, 65, 790, 1100)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function ReadBinaryFile(ByVal fileName As String) As Byte()

        ' Si no existe el archivo, abandono la función.
        '
        If Not System.IO.File.Exists(fileName) Then Return Nothing

        Try
            ' Creamos un objeto Stream para poder leer el archivo especificado.
            '
            Dim fs As New FileStream(fileName, FileMode.Open, FileAccess.Read)

            ' Creamos un array de bytes, cuyo límite superior se corresponderá
            ' con la longitud en bytes de la secuencia.
            '
            Dim data() As Byte = New Byte(Convert.ToInt32(fs.Length)) {}

            ' Al leer la secuencia, se rellenará la matriz.
            '
            fs.Read(data, 0, Convert.ToInt32(fs.Length))

            ' Cerramos la secuencia.
            '
            fs.Close()

            ' Devolvemos el array de bytes.
            '
            Return data

        Catch ex As Exception
            ' Cualquier excepción producida, hace que la
            ' función devuelva el valor Nothing.
            '
            Return Nothing

        End Try

    End Function

    Private Sub DescargarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescargarToolStripMenuItem.Click
        Dim bits As Byte() = DirectCast(CType(dgvDetalle.CurrentRow.Cells("IMA_ID").Tag, Imagen).IMA_ARCHIVO, Byte())
        If fbdImagen.ShowDialog = DialogResult.OK Then
            Dim fs As New FileStream(fbdImagen.SelectedPath & "\" & dgvDetalle.CurrentRow.Cells("IMA_RUTA").Value, FileMode.Create)
            fs.Write(bits, 0, Convert.ToInt32(bits.Length))
            fs.Close()
            MessageBox.Show("El Archivo se guardo y se mostrara.")
            Process.Start(fbdImagen.SelectedPath & "\" & dgvDetalle.CurrentRow.Cells("IMA_RUTA").Value)
        End If

    End Sub
    Sub validacion_desactivacion(ByVal op As Boolean, ByVal flag As Integer)
        'datos a tener en cuenta
        '1=load
        '2=nuevo
        '3=guardar
        '4=DeshacerCambios
        '5=buscar
        '6=editar
        '7=deshacer,eliminar

        If flag = 1 Or flag = 3 Or flag = 4 Or flag = 7 Then

            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbNuevo.Enabled = Not op
            Me.tsbBuscar.Enabled = Not op
            Me.tsbSalir.Enabled = Not op
            Me.tscPosicion.Enabled = Not op
            Me.tsbReportes.Enabled = Not op


        ElseIf flag = 2 Or flag = 6 Then 'evento nuevo registro
            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = Not op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbGrabar.Enabled = op
            Me.TsbGrabarNuevo.Enabled = op
            Me.tsbDeshacer.Enabled = op
            Me.tsbAgregar.Enabled = op
            Me.tsbQuitar.Enabled = op


        ElseIf flag = 5 Then 'evento buscar/editar
            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbNuevo.Enabled = Not op
            Me.tsbEditar.Enabled = Not op
            Me.tsbCancelarEditar.Enabled = Not op
            Me.tsbReportes.Enabled = Not op

        End If
    End Sub

    Private Sub txtEntidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntidad.KeyDown
        If e.KeyCode = Keys.Enter Then txtEntidad_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        If e.KeyCode = Keys.Enter Then
            Select Case dgvDetalle.CurrentCell.ColumnIndex
                Case 2
                    Try
                        ResetRutaImagen()
                        If Me.ofdImagen.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            'Me.picImagen.Image = Image.FromFile(ofdImagen.FileName)
                            dgvDetalle.CurrentCell.Value = ofdImagen.FileName
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
            End Select
        End If

        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        If Not e.Row.Cells("IMA_ID").Tag Is Nothing Then
            CType(e.Row.Cells("IMA_ID").Tag, Imagen).MarkAsDeleted()
        End If
    End Sub
End Class
