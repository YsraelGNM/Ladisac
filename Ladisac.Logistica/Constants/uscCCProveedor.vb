Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO



Public Class uscCCProveedor
    <Dependency()>
    Public Property ContainerService As IUnityContainer

    Public mCCP As CCProveedorDetalle
    Public mDgvArt As DataGridView

    Public Sub uscCCProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If mCCP Is Nothing Then
            mCCP = New CCProveedorDetalle
            mCCP.CPD_APROBADO = False
            mCCP.MarkAsAdded()
            picDoc.Image = picDoc.ErrorImage
            picPre.Image = picPre.ErrorImage
        Else
            mCCP.MarkAsModified()
            txtProveedor.Text = mCCP.PER_DESCRIPCION
            txtDocumento.Text = mCCP.CPD_DOCUMENTO
            If mCCP.CPD_ADJUNTO_DOCUMENTO Is Nothing Then
                picDoc.Image = picDoc.ErrorImage
            Else
                picDoc.Image = picDoc.InitialImage
            End If
            If mCCP.CPD_ADJUNTO_PRESUPUESTO Is Nothing Then
                picPre.Image = picPre.ErrorImage
            Else
                picPre.Image = picPre.InitialImage
            End If
            chkAprobado.Checked = mCCP.CPD_APROBADO
            For Each mItem In mCCP.CCArticuloProveedorDetalle
                mItem.MarkAsModified()
                Dim mRow As New DataGridViewRow
                dgvProveedor.Rows.Add(mRow)
                dgvProveedor.Rows(dgvProveedor.Rows.Count - 1).Cells("CAP_CANT").Value = mItem.CAP_CANTIDAD
                dgvProveedor.Rows(dgvProveedor.Rows.Count - 1).Cells("CAP_PU").Value = mItem.CAP_PU
                dgvProveedor.Rows(dgvProveedor.Rows.Count - 1).Cells("CAP_PU").Tag = mItem
                dgvProveedor.Rows(dgvProveedor.Rows.Count - 1).Cells("Total").Value = mItem.CAP_PU * mItem.CAP_CANTIDAD
                dgvProveedor.Rows(dgvProveedor.Rows.Count - 1).Cells("CAP_APROBADO").Value = mItem.CAP_APROBADO
            Next
        End If
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
            Dim data() As Byte = New Byte(Convert.ToInt32(fs.Length - 1)) {}

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

    Private Sub tooAdDocuCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdDocuCargar.Click
        If Me.ofdImagen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            mCCP.CPD_ADJUNTO_DOCUMENTO = ReadBinaryFile(ofdImagen.FileName)
            mCCP.CPD_ADJUNTO_DOCUMENTO_DESCRI = ofdImagen.SafeFileName
            picDoc.Image = picDoc.InitialImage
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProveedor.TextChanged
        mCCP.PER_DESCRIPCION = txtProveedor.Text
    End Sub

    Private Sub txtDocumento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDocumento.TextChanged
        mCCP.CPD_DOCUMENTO = txtDocumento.Text
    End Sub

    Private Sub tooAdDocuEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdDocuEliminar.Click
        If mCCP.CPD_ADJUNTO_DOCUMENTO IsNot Nothing Then
            mCCP.CPD_ADJUNTO_DOCUMENTO = Nothing
            mCCP.CPD_ADJUNTO_DOCUMENTO_DESCRI = String.Empty
            picDoc.Image = picDoc.ErrorImage
        End If
    End Sub

    Private Sub tooAdDocuDescargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdDocuDescargar.Click
        If mCCP.CPD_ADJUNTO_DOCUMENTO IsNot Nothing Then
            Dim bits As Byte() = DirectCast(mCCP.CPD_ADJUNTO_DOCUMENTO, Byte())
            sfdImagen.FileName = mCCP.CPD_ADJUNTO_DOCUMENTO_DESCRI
            If sfdImagen.ShowDialog = DialogResult.OK Then
                Dim fs As New FileStream(sfdImagen.FileName, FileMode.Create)
                fs.Write(bits, 0, Convert.ToInt32(bits.Length))
                fs.Close()
                MessageBox.Show("El Archivo se guardo y se mostrara.")
                Process.Start(sfdImagen.FileName)
            End If
        End If
    End Sub

    Private Sub tooAdPreCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdPreCargar.Click
        If Me.ofdImagen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            mCCP.CPD_ADJUNTO_PRESUPUESTO = ReadBinaryFile(ofdImagen.FileName)
            mCCP.CPD_ADJUNTO_PRESUPUESTO_DESCRI = ofdImagen.SafeFileName
            picPre.Image = picPre.InitialImage
        End If
    End Sub

    Private Sub tooAdPreDescargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdPreDescargar.Click
        If mCCP.CPD_ADJUNTO_PRESUPUESTO IsNot Nothing Then
            Dim bits As Byte() = DirectCast(mCCP.CPD_ADJUNTO_PRESUPUESTO, Byte())
            sfdImagen.FileName = mCCP.CPD_ADJUNTO_PRESUPUESTO_DESCRI
            If sfdImagen.ShowDialog = DialogResult.OK Then
                Dim fs As New FileStream(sfdImagen.FileName, FileMode.Create)
                fs.Write(bits, 0, Convert.ToInt32(bits.Length))
                fs.Close()
                MessageBox.Show("El Archivo se guardo y se mostrara.")
                Process.Start(sfdImagen.FileName)
            End If
        End If
    End Sub

    Private Sub tooAdPreEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdPreEliminar.Click
        If mCCP.CPD_ADJUNTO_PRESUPUESTO IsNot Nothing Then
            mCCP.CPD_ADJUNTO_PRESUPUESTO = Nothing
            mCCP.CPD_ADJUNTO_PRESUPUESTO_DESCRI = String.Empty
            picPre.Image = picPre.ErrorImage
        End If
    End Sub

    Private Sub chkAprobado_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAprobado.CheckedChanged
        mCCP.CPD_APROBADO = chkAprobado.Checked
        For Each mFila As DataGridViewRow In dgvProveedor.Rows
            mFila.Cells("CAP_APROBADO").Value = chkAprobado.Checked
        Next
    End Sub

    Private Sub tooUscEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooUscEliminar.Click
        If mCCP IsNot Nothing Then
            mCCP.MarkAsDeleted()
        End If
    End Sub

    Private Sub dgvProveedor_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProveedor.CellEndEdit
        If mDgvArt IsNot Nothing Then
            dgvProveedor.CurrentRow.Cells("Total").Value = dgvProveedor.CurrentRow.Cells("CAP_PU").Value * dgvProveedor.CurrentRow.Cells("CAP_CANT").Value
        End If
    End Sub

    Private Sub btnOC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOC.Click
        'Try
        '    Dim flag As Boolean = False
        '    Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmOrdenCompra)()

        '    For Each item In dgvProveedor.Rows
        '        If item.Cells("CAP_APROBADO").Value = True Then
        '            frm.mPCDE.Add(CType(item.Cells("CAP_CANT").Tag, ProcesoCompraDetalle))
        '            flag = True
        '        Else
        '            item.Cells("OC").Value = False
        '        End If
        '    Next

        '    If flag Then
        '        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
        '        End If
        '    End If
        '    frm.Dispose()

        'Catch ex As Exception
        '    MessageBox.Show("Existe un Error, verificar datos " & ex.Message, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End Try
    End Sub
End Class
