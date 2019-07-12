Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Text

Public Class frmVisualizarISO
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCPlantillaDocuIso As Ladisac.BL.IBCPlantillaDocuIso
    <Dependency()> _
    Public Property BCDocuIso As Ladisac.BL.IBCDocuIso
    <Dependency()> _
    Public Property BCPersona As Ladisac.BL.IBCPersona
    <Dependency()> _
    Public Property BCDatosLab As Ladisac.BL.IBCDatosLaborales
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Dim mCol As List(Of DocuIso)
    Dim outputfilename As Object

    Private Sub frmVisualizarISO_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If outputfilename IsNot Nothing Then
            LimpiarDescarga(outputfilename)
        End If
    End Sub

    Private Sub frmVisualizarISO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Sub LlenarGrid()
        dgvDetalle.Rows.Clear()
        'If txtARE_ID.Tag IsNot Nothing Then

        mCol = BCDocuIso.ListaDocuIsoVigente(txtARE_ID.Tag, txtDTD_ID.Tag, SessionServer.Usuario.PER_ID, BCDatosLab.DatosLaboralesSeek(SessionServer.Usuario.PER_ID).AreaTrabajos.art_Descripcion)

        If mCol IsNot Nothing Then
            For Each mItem In mCol
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Fila").Value = dgvDetalle.Rows.Count
                'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = mItem.DIS_CODIGO
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Nombre").Value = mItem.DIS_ADJUNTO_DESCRI
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Nombre").Tag = mItem
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Version").Value = mItem.DIS_VERSION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("FecApro").Value = mItem.DIS_FECHA_APROBACION
                If mItem.Personas IsNot Nothing Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Elaborado").Value = mItem.Personas.PER_APE_PAT & " " & mItem.Personas.PER_APE_MAT & " " & mItem.Personas.PER_NOMBRES
                If mItem.Personas1 IsNot Nothing Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Revisado").Value = mItem.Personas1.PER_APE_PAT & " " & mItem.Personas1.PER_APE_MAT & " " & mItem.Personas1.PER_NOMBRES
                If mItem.Personas2 IsNot Nothing Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Aprobado").Value = mItem.Personas2.PER_APE_PAT & " " & mItem.Personas2.PER_APE_MAT & " " & mItem.Personas2.PER_NOMBRES
            Next
        End If

        If dgvDetalle.Rows.Count = 0 Then
            MsgBox("No hay documentos que mostrar.")
            Limpiar()
        End If

        'Else
        'MsgBox("El Area debe de ser seleccionada.")
        'End If
    End Sub

    Sub Limpiar()
        txtARE_ID.Text = String.Empty
        txtARE_ID.Tag = Nothing
        txtDTD_ID.Text = String.Empty
        txtDTD_ID.Tag = Nothing
        txtCodArea.Text = String.Empty
        txtCodDoc.Text = String.Empty
        dgvDetalle.Rows.Clear()
        WebBrowser1.Navigate("about:blank")
    End Sub

    Sub LimpiarDescarga(ByVal Archivo As String)
        Try
            Try
                System.IO.File.Delete(Archivo)
                My.Computer.FileSystem.DeleteDirectory(Archivo.Split(".")(0) & "_archivos", FileIO.DeleteDirectoryOption.DeleteAllContents)
                Archivo = String.Empty
            Catch ex As Exception
                'MessageBox.Show(ex.Message)
            Finally
                My.Computer.FileSystem.DeleteDirectory(Archivo, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        frmVisualizarISO_FormClosing(Nothing, Nothing)

        Try

            If dgvDetalle.CurrentRow.Cells("Nombre").Tag IsNot Nothing Then


                If CType(dgvDetalle.CurrentRow.Cells("Nombre").Tag, DocuIso).DIS_ADJUNTO IsNot Nothing Then



                    Dim bits As Byte() = DirectCast(CType(dgvDetalle.CurrentRow.Cells("Nombre").Tag, DocuIso).DIS_ADJUNTO, Byte())
                    sfdImagen.FileName = "v" & CType(dgvDetalle.CurrentRow.Cells("Nombre").Tag, DocuIso).DIS_ADJUNTO_DESCRI
                    If sfdImagen.ShowDialog = DialogResult.OK Then
                        Dim fs As New FileStream(sfdImagen.FileName, FileMode.Create)
                        fs.Write(bits, 0, Convert.ToInt32(bits.Length))
                        fs.Close()
                        ''txtDIS_ADJUNTO_DESCRI.Tag = sfdImagen.FileName
                        'MessageBox.Show("El Archivo se guardo y se mostrara.")
                        'Process.Start(sfdImagen.FileName)



                        Dim WordApp_1 As Object
                        WordApp_1 = CreateObject("Word.Application")
                        WordApp_1.Visible = False
                        Dim aDoc_1 As Word.Document


                        Dim ExcelApp_1 As Object
                        ExcelApp_1 = CreateObject("Excel.Application")
                        ExcelApp_1.Visible = False
                        Dim aExc_1 As Excel.Workbook


                        Dim fileName As Object = sfdImagen.FileName
                        Dim isVisible As Object = False
                        Dim missing As Object = System.Reflection.Missing.Value




                        If sfdImagen.FileName.Contains(".docx") Then
                            'aDoc_1 = WordApp_1.Documents.Open(fileName, missing, missing, missing, missing, missing, missing, missing, missing, missing, isVisible)
                            'aDoc_1.Activate()
                            aDoc_1 = WordApp_1.Documents.Open(fileName:=fileName, ReadOnly:=False)
                            aDoc_1.Activate()
                            outputfilename = aDoc_1.FullName.Replace(".docx", ".htm")
                            Dim mformato = Word.WdSaveFormat.wdFormatHTML
                            'aDoc_1.SaveAs2(FileName:=outputfilename, FileFormat:=mformato, AddBiDiMarks:=missing, AddToRecentFiles:=missing, AllowSubstitutions:=missing, CompatibilityMode:=missing, EmbedTrueTypeFonts:=missing, Encoding:=missing, InsertLineBreaks:=missing, LineEnding:=missing, LockComments:=missing, Password:=missing, ReadOnlyRecommended:=missing, SaveAsAOCELetter:=missing, SaveFormsData:=missing, SaveNativePictureFormat:=missing, WritePassword:=missing)
                            aDoc_1.SaveAs(outputfilename, mformato, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing)

                            WordApp_1.Documents.Item(1).Save()
                            WordApp_1.Documents.Close(Word.WdSaveOptions.wdDoNotSaveChanges)
                            WordApp_1.Quit()
                            WordApp_1 = Nothing
                            aDoc_1 = Nothing
                            Try
                                ExcelApp_1.Quit()
                            Catch ex As Exception

                            End Try



                        ElseIf sfdImagen.FileName.Contains(".doc") Then
                            'aDoc_1 = WordApp_1.Documents.Open(fileName, missing, missing, missing, missing, missing, missing, missing, missing, missing, isVisible)
                            'aDoc_1.Activate()
                            aDoc_1 = WordApp_1.Documents.Open(fileName:=fileName, ReadOnly:=False)
                            aDoc_1.Activate()
                            outputfilename = aDoc_1.FullName.Replace(".doc", ".htm")
                            Dim mformato = Word.WdSaveFormat.wdFormatHTML
                            aDoc_1.SaveAs(outputfilename, mformato, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing)

                            WordApp_1.Documents.Item(1).Save()
                            WordApp_1.Documents.Close(Word.WdSaveOptions.wdDoNotSaveChanges)
                            WordApp_1.Quit()
                            WordApp_1 = Nothing
                            aDoc_1 = Nothing
                            Try
                                ExcelApp_1.Quit()
                            Catch ex As Exception

                            End Try


                        ElseIf sfdImagen.FileName.Contains(".xlsx") Then
                            aExc_1 = ExcelApp_1.Workbooks.Open(fileName)
                            outputfilename = aExc_1.FullName.Replace(".xlsx", ".htm")
                            ExcelApp_1.ActiveWorkbook.SaveAs(outputfilename, 44)
                            ExcelApp_1.Quit()
                            Try
                                WordApp_1.Quit()
                            Catch ex As Exception

                            End Try


                        ElseIf sfdImagen.FileName.Contains(".xls") Then
                            aExc_1 = ExcelApp_1.Workbooks.Open(fileName)
                            outputfilename = aExc_1.FullName.Replace(".xls", ".htm")
                            ExcelApp_1.ActiveWorkbook.SaveAs(outputfilename, 44)
                            ExcelApp_1.Quit()
                            Try
                                WordApp_1.Quit()
                            Catch ex As Exception

                            End Try

                        ElseIf sfdImagen.FileName.Contains(".pdf") Then

                            Dim attributes As FileAttributes
                            attributes = File.GetAttributes(sfdImagen.FileName)
                            File.SetAttributes(sfdImagen.FileName, File.GetAttributes(sfdImagen.FileName) Or FileAttributes.Hidden)
                            outputfilename = sfdImagen.FileName

                        End If

                        If CType(dgvDetalle.CurrentRow.Cells("Nombre").Tag, DocuIso).DIS_DESCARGA = 0 Then
                            If sfdImagen.FileName.Contains(".pdf") Then
                                'Que lo ponga invisible el pdf.
                            Else
                                System.IO.File.Delete(sfdImagen.FileName)
                            End If

                        Else
                            Process.Start(sfdImagen.FileName)
                        End If

                        Try
                            WebBrowser1.Navigate(outputfilename)
                        Catch ex As Exception
                            MessageBox.Show("No hay Adjunto o no esta permitido descargar.")
                        End Try

                    End If
                Else
                    MessageBox.Show("No hay Adjunto.")
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtARE_ID_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtARE_ID.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Foundation.Views.frmBuscar)()
        frm.Tabla = "AreaRRHH"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtARE_ID.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'are_Id
            txtARE_ID.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
            txtCodArea.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Codigo
        End If
        frm.Dispose()
    End Sub

    Private Sub txtARE_ID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtARE_ID.KeyDown
        If e.KeyCode = Keys.Enter Then txtARE_ID_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtDTD_ID_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDTD_ID.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Foundation.Views.frmBuscar)()
        frm.Tabla = "TipoDocumentoISO"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtDTD_ID.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'dtd_Id
            txtDTD_ID.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
            txtCodDoc.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'codigo
        End If
        frm.Dispose()
    End Sub

    Private Sub txtDTD_ID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDTD_ID.KeyDown
        If e.KeyCode = Keys.Enter Then txtDTD_ID_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        frmVisualizarISO_FormClosing(Nothing, Nothing)
        LlenarGrid()
    End Sub
End Class
