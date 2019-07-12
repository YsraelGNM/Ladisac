Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Text



Public Class frmDocuIso
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCPlantillaDocuIso As Ladisac.BL.IBCPlantillaDocuIso
    <Dependency()> _
    Public Property BCDocuIso As Ladisac.BL.IBCDocuIso
    <Dependency()> _
    Public Property BCPersona As Ladisac.BL.IBCPersona
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Public mPDI As PlantillaDocuIso
    Dim WordApp As Object
    Dim aDoc As Word.Document
    Dim Range As Word.Range
    Dim mDocuIso As DocuIso

    Structure Ruta
        Dim Destino As String
        Dim Elaborado As String
        Dim Revisado As String
        Dim Aprobado As String
    End Structure

    Dim mRuta As New Ruta
    Dim Per As Personas

    Private Sub frmDocuIso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
    End Sub

    Private Sub txtPDI_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPDI_ID.DoubleClick
        If txtDTD_ID.Tag IsNot Nothing And txtARE_ID.Tag IsNot Nothing Then
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Foundation.Views.frmBuscar)()
            frm.Tabla = "PlantillaDocuIso"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
                CargarPlantillaDocuIso(key)
                LLenarGridPlantilla(True)
                txtPDI_ID.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
                txtPDI_ID.Text = frm.dgvLista.CurrentRow.Cells(1).Value
            End If
            frm.Dispose()
        Else
            MessageBox.Show("Primero debe de escoger un Tipo Documento y una Area.")
        End If
        
    End Sub

    Private Sub txtPDI_ID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPDI_ID.KeyDown
        If e.KeyCode = Keys.Enter Then txtPDI_DoubleClick(Nothing, Nothing)
    End Sub

    Sub CargarPlantillaDocuIso(ByVal PDI_Id As Integer)
        mPDI = BCPlantillaDocuIso.PlantillaDocuIsoGetById(PDI_Id)
        mPDI.MarkAsModified()
    End Sub

    Public Function InsertarFirma(ByVal FileName As String) As Integer
        Dim Resp As Integer = 0
        If FileName.Length > 0 Then
            Try
                WordApp = CreateObject("Word.Application")
                'Dim fileName As Object = sfdImagen.FileName
                Dim soloLectura As Object = False
                Dim isVisible As Object = False
                Dim missing As Object = System.Reflection.Missing.Value
                WordApp.Visible = True

                aDoc = WordApp.Documents.Open(FileName, missing, missing, missing, missing, missing, missing, missing, missing, missing, isVisible)
                aDoc.Activate()

                If mRuta.Elaborado.Length > 0 Then
                    ''''''''''WordApp.Selection.GoTo(What:=-1, Name:="ELA")
                    aDoc.Bookmarks.Item("ELA").Range.InlineShapes.AddPicture(mRuta.Elaborado)
                    '' Limpia el Clipboard  
                    'Clipboard.Clear()

                    '' Pasa el gráfico al portapapeles  
                    'Clipboard.SetData(Grafico, Bitmap)

                    '' Pega la imagen en la selección  
                    'WordApp.Selection.Paste()
                    '''''''''''''aDoc.Shapes.AddPicture(FileName:=mRuta.Elaborado, SaveWithDocument:=True)
                End If

                If mRuta.Revisado.Length > 0 Then
                    'WordApp.Selection.GoTo(What:=-1, Name:="REV")
                    'aDoc.Shapes.AddPicture(FileName:=mRuta.Revisado, SaveWithDocument:=True)
                    aDoc.Bookmarks.Item("REV").Range.InlineShapes.AddPicture(mRuta.Revisado)
                End If

                If mRuta.Aprobado.Length > 0 Then
                    'WordApp.Selection.GoTo(What:=-1, Name:="APR")
                    'aDoc.Shapes.AddPicture(FileName:=mRuta.Aprobado, SaveWithDocument:=True)
                    aDoc.Bookmarks.Item("APR").Range.InlineShapes.AddPicture(mRuta.Aprobado)
                End If

                WordApp.Documents.Item(1).Save()
                WordApp.Documents.Close(Word.WdSaveOptions.wdDoNotSaveChanges)

                Resp = 1
            Catch ex As Exception
                MsgBox("El Documento no esta preparado para recibir firmas.")
                'MsgBox(ex.Message)
            End Try

            WordApp.Quit()

            If System.IO.File.Exists(mRuta.Elaborado) = True Then System.IO.File.Delete(mRuta.Elaborado)
            If System.IO.File.Exists(mRuta.Revisado) = True Then System.IO.File.Delete(mRuta.Revisado)
            If System.IO.File.Exists(mRuta.Aprobado) = True Then System.IO.File.Delete(mRuta.Aprobado)
        End If

        Return Resp
    End Function

    Sub LLenarGridPlantilla(ByVal Nuevo As Boolean)
        If mPDI IsNot Nothing Then
            Dim bits As Byte() = DirectCast(mPDI.PDI_ADJUNTO, Byte())
            If Nuevo Then
                sfdImagen.FileName = txtCodDoc.Text & "-" & txtCodArea.Text & "-" & txtDIS_CODIGO.Text & "-" & mPDI.PDI_NOMBRE
            Else
                sfdImagen.FileName = txtDIS_ADJUNTO_DESCRI.Text
            End If

            If sfdImagen.ShowDialog = DialogResult.OK Then
                Dim fs As New FileStream(sfdImagen.FileName, FileMode.Create)
                fs.Write(bits, 0, Convert.ToInt32(bits.Length))
                fs.Close()

                mRuta.Destino = Path.GetDirectoryName(sfdImagen.FileName) & "\"
                txtDIS_ADJUNTO_DESCRI.Text = Path.GetFileName(sfdImagen.FileName)
                txtDIS_ADJUNTO_DESCRI.Tag = sfdImagen.FileName

                WordApp = CreateObject("Word.Application")
                Dim fileName As Object = sfdImagen.FileName
                Dim soloLectura As Object = False
                Dim isVisible As Object = False
                Dim missing As Object = System.Reflection.Missing.Value
                WordApp.Visible = True

                aDoc = WordApp.Documents.Open(fileName, missing, missing, missing, missing, missing, missing, missing, missing, missing, isVisible)
                aDoc.Activate()

                If Nuevo Then 'Si es nueva la plantilla se rellena el grid
                    dgvDetalle.Rows.Clear()
                    Dim sb As New StringBuilder()

                    Dim cadena As String = ""
                    sb.AppendLine(aDoc.Sections(1).Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.Text.Trim)

                    For Each paragraph As Word.Paragraph In aDoc.Content.Paragraphs
                        sb.AppendLine(paragraph.Range.Text.Trim)
                    Next paragraph


                    Dim flag As Boolean = False
                    For cont As Integer = 0 To sb.Length - 1
                        If sb.Chars(cont) = "<" Then
                            flag = True
                            cadena = cadena & "<"
                        ElseIf flag = True Then
                            cadena = cadena & sb.Chars(cont)
                            If sb.Chars(cont) = ">" Then
                                flag = False
                            End If
                        End If
                    Next

                    'Dim mListaMarca() As String = sb.ToString.Split(">")
                    Dim mListaMarca() As String = cadena.ToString.Split(">")
                    For Each mItem In mListaMarca
                        If mItem.ToString.Trim.Length > 0 Then
                            Dim nRow As New DataGridViewRow
                            dgvDetalle.Rows.Add(nRow)
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("MARCA").Value = mItem
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Public Overrides Sub OnManEliminar()
        If mDocuIso IsNot Nothing Then
            If MessageBox.Show("Seguro de Eliminar el Documento?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = vbOK Then
                For cont = mDocuIso.DocuIsoDetalle.Count - 1 To 0 Step -1
                    mDocuIso.DocuIsoDetalle(cont).MarkAsDeleted()
                Next
                mDocuIso.MarkAsDeleted()
                BCDocuIso.MantenimientoDocuIso(mDocuIso)
            End If
            Call LimpiarControles()
            Call validacion_desactivacion(False, 3)
        End If
    End Sub

    Public Overrides Sub OnManGuardar()
        dgvDetalle.EndEdit()

        For Each mRow As DataGridViewRow In dgvDetalle.Rows
            If mRow.Cells("Marca").Value = "<codigo" Then
                mRow.Cells("Texto").Value = txtCodDoc.Text & "-" & txtCodArea.Text & "-" & txtDIS_CODIGO.Text
            ElseIf mRow.Cells("Marca").Value = "<ver" Then
                mRow.Cells("Texto").Value = txtDIS_VERSION.Text
            ElseIf mRow.Cells("Marca").Value = "<elaborado" Then
                mRow.Cells("Texto").Value = txtPER_ID_ELABORACION.Text
            ElseIf mRow.Cells("Marca").Value = "<revisado" Then
                mRow.Cells("Texto").Value = txtPER_ID_REVISION.Text
            ElseIf mRow.Cells("Marca").Value = "<aprobado" Then
                mRow.Cells("Texto").Value = txtPER_ID_APROBACION.Text
            End If
        Next

        If mDocuIso IsNot Nothing Then

            If txtDIS_ADJUNTO_DESCRI.Text.Contains(".doc") Then CargarAdjuntoToolStripMenuItem_Click(Nothing, Nothing)

            mDocuIso.ARE_ID = txtARE_ID.Tag
            mDocuIso.DTD_ID = CInt(txtDTD_ID.Tag)
            'mDocuIso.PDI_ID = CInt(txtPDI_ID.Tag)
            'mDocuIso.DIS_CODIGO = txtDIS_CODIGO.Text

            ''Para el archivo de texto
            'If txtDIS_ADJUNTO_DESCRI.Tag IsNot Nothing Then
            '    mDocuIso.DIS_ADJUNTO_DESCRI = txtDIS_ADJUNTO_DESCRI.Text

            '    Range = aDoc.Sections(1).Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range
            '    For Each mRow As DataGridViewRow In dgvDetalle.Rows
            '        With Range.Find
            '            .Text = mRow.Cells("marca").Value.ToString.Trim & ">"
            '            .Forward = True
            '            .Wrap = Word.WdFindWrap.wdFindContinue
            '            Do While .Execute
            '                Range.Text = mRow.Cells("Texto").Value
            '            Loop
            '        End With
            '    Next

            '    Range = aDoc.Range()
            '    For Each mRow As DataGridViewRow In dgvDetalle.Rows
            '        With Range.Find
            '            .Text = mRow.Cells("marca").Value.ToString.Trim & ">"
            '            .Forward = True
            '            .Wrap = Word.WdFindWrap.wdFindContinue
            '            Do While .Execute
            '                Range.Text = mRow.Cells("Texto").Value
            '            Loop
            '        End With
            '    Next

            '    'Dim PIctureLocation As String = "H:\Liberalogo.jpg"
            '    'aDoc.Bookmarks.Item("\endofdoc").Range.InlineShapes.AddPicture(PIctureLocation)

            '    Dim myTable As Word.Table
            '    myTable = aDoc.Tables.Add(aDoc.Bookmarks.Item("\endofdoc").Range, NumRows:=1, NumColumns:=3)


            '    If txtPER_ID_ELABORACION.Tag IsNot Nothing Then
            '        myTable.Cell(1, 1).Range.InlineShapes.AddPicture(mRuta.Elaborado)
            '    End If
            '    If txtPER_ID_REVISION.Tag IsNot Nothing Then
            '        myTable.Cell(1, 2).Range.InlineShapes.AddPicture(mRuta.Revisado)
            '    End If
            '    If txtPER_ID_APROBACION.Tag IsNot Nothing Then
            '        myTable.Cell(1, 3).Range.InlineShapes.AddPicture(mRuta.Aprobado)
            '    End If

            '    MsgBox("PAUSE")

            '    WordApp.Documents.Item(1).Save()
            '    WordApp.Documents.Close(Word.WdSaveOptions.wdDoNotSaveChanges)
            '    WordApp.Quit()

            '    mDocuIso.DIS_ADJUNTO = ReadBinaryFile(txtDIS_ADJUNTO_DESCRI.Tag)
            'End If
            ''Fin archivo de texto

            mDocuIso.DIS_VIGENTE = IIf(chkDIS_VIGENTE.Checked, 1, 0)
            mDocuIso.DIS_VERSION = txtDIS_VERSION.Text

            mDocuIso.DIS_DESCARGA = IIf(rbtSi.Checked, 1, 0)
            mDocuIso.DIS_PU_AR_PR = IIf(rbtPrivado.Checked, 2, IIf(rbtArea.Checked, 1, 0)) 'publico 0, area 1, privado 2



            mDocuIso.PER_ID_ELABORACION = txtPER_ID_ELABORACION.Tag
            mDocuIso.DIS_FECHA_ELABORACION = dtpDIS_FECHA_ELABORACION.Value
            mDocuIso.PER_ID_REVISION = txtPER_ID_REVISION.Tag
            mDocuIso.DIS_FECHA_REVISION = dtpDIS_FECHA_REVISION.Value
            mDocuIso.PER_ID_APROBACION = txtPER_ID_APROBACION.Tag
            mDocuIso.DIS_FECHA_APROBACION = dtpDIS_FECHA_APROBACION.Value
            mDocuIso.DIS_ESTADO = True
            mDocuIso.DIS_FEC_GRAB = Now
            mDocuIso.USU_ID = SessionServer.UserId

            'For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
            '    If Not mDetalle.Cells("DID_ID").Value Is Nothing Then
            '        With CType(mDetalle.Cells("DID_ID").Tag, DocuIsoDetalle)
            '            .DID_MARCA = mDetalle.Cells("Marca").Value.ToString.Trim
            '            .DID_DESCRIPCION = mDetalle.Cells("Texto").Value
            '            .MarkAsModified()
            '        End With
            '    ElseIf mDetalle.Cells("DID_ID").Value Is Nothing Then
            '        Dim nDID As New DocuIsoDetalle
            '        With nDID
            '            .DID_MARCA = mDetalle.Cells("Marca").Value.ToString.Trim
            '            .DID_DESCRIPCION = mDetalle.Cells("Texto").Value
            '            .MarkAsAdded()
            '        End With
            '        mDocuIso.DocuIsoDetalle.Add(nDID)
            '    End If
            'Next

            BCDocuIso.MantenimientoDocuIso(mDocuIso)
            MessageBox.Show(mDocuIso.DIS_ID)

            ''BORRAR ARCHIVOS
            'If System.IO.File.Exists(txtDIS_ADJUNTO_DESCRI.Tag) = True Then System.IO.File.Delete(txtDIS_ADJUNTO_DESCRI.Tag)
            'If System.IO.File.Exists(mRuta.Elaborado) = True Then System.IO.File.Delete(mRuta.Elaborado)
            'If System.IO.File.Exists(mRuta.Revisado) = True Then System.IO.File.Delete(mRuta.Revisado)
            'If System.IO.File.Exists(mRuta.Aprobado) = True Then System.IO.File.Delete(mRuta.Aprobado)

            LimpiarControles()
            Call validacion_desactivacion(False, 3)
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
            MessageBox.Show(ex.Message)
            Return Nothing

        End Try

    End Function

    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mDocuIso = New DocuIso
        mDocuIso.MarkAsAdded()
        Call validacion_desactivacion(True, 2)
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

    Sub LimpiarControles()
        mRuta.Destino = String.Empty
        mRuta.Elaborado = String.Empty
        mRuta.Revisado = String.Empty
        mRuta.aprobado = String.Empty

        ofdImagen.FileName = String.Empty
        sfdImagen.FileName = String.Empty

        mPDI = Nothing
        WordApp = Nothing
        aDoc = Nothing
        Range = Nothing
        mDocuIso = Nothing

        txtCodigo.Text = String.Empty
        txtDIS_CODIGO.Text = String.Empty
        txtARE_ID.Text = String.Empty
        txtARE_ID.Tag = Nothing
        txtCodArea.Text = String.Empty
        txtDTD_ID.Text = String.Empty
        txtDTD_ID.Tag = Nothing
        txtCodDoc.Text = String.Empty
        txtDIS_VERSION.Text = String.Empty
        chkDIS_VIGENTE.Checked = False
        txtPDI_ID.Text = String.Empty
        txtPDI_ID.Tag = Nothing
        txtPER_ID_ELABORACION.Text = String.Empty
        txtPER_ID_ELABORACION.Tag = Nothing
        dtpDIS_FECHA_ELABORACION.Value = Today
        txtPER_ID_REVISION.Text = String.Empty
        txtPER_ID_REVISION.Tag = Nothing
        dtpDIS_FECHA_REVISION.Value = Today
        txtPER_ID_APROBACION.Text = String.Empty
        txtPER_ID_APROBACION.Tag = Nothing
        dtpDIS_FECHA_APROBACION.Value = Today
        picDIS_ADJUNTO.Image = picDIS_ADJUNTO.ErrorImage
        txtDIS_ADJUNTO_DESCRI.Text = String.Empty
        txtDIS_ADJUNTO_DESCRI.Tag = Nothing

        dgvDetalle.Rows.Clear()

        rbtNo.Checked = True
        rbtPrivado.Checked = True

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

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Foundation.Views.frmBuscar)()
        frm.Tabla = "DocuIso"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarDocuIso(key)
            LlenarControles()
            Call validacion_desactivacion(True, 5)
            'ConvertirNuevo()
        End If
        frm.Dispose()
    End Sub

    Sub ConvertirNuevo()
        mDocuIso.MarkAsAdded()
        txtCodigo.Text = String.Empty
        For Each mItem As DataGridViewRow In dgvDetalle.Rows
            mItem.Cells("DID_ID").Value = Nothing
            mItem.Cells("DID_ID").Tag = Nothing
        Next
    End Sub

    Sub CargarDocuIso(ByVal DIS_Id As Integer)
        mDocuIso = BCDocuIso.DocuIsoGetById(DIS_Id)
        mDocuIso.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mDocuIso.DIS_ID
        txtARE_ID.Text = mDocuIso.AreaTrabajos.art_Descripcion
        txtARE_ID.Tag = mDocuIso.ARE_ID
        txtCodArea.Text = mDocuIso.AreaTrabajos.art_Codigo
        txtDIS_CODIGO.Text = mDocuIso.DIS_CODIGO
        txtDTD_ID.Text = mDocuIso.DetalleTipoDocumentos.DTD_DESCRIPCION
        txtDTD_ID.Tag = mDocuIso.DTD_ID
        txtCodDoc.Text = mDocuIso.DetalleTipoDocumentos.TipoDocumentos.TDO_DESCRIPCION_CORTA
        txtDIS_VERSION.Text = mDocuIso.DIS_VERSION
        chkDIS_VIGENTE.Checked = IIf(mDocuIso.DIS_VIGENTE = 1, True, False)
        'txtPDI_ID.Text = mDocuIso.PlantillaDocuIso.PDI_NOMBRE
        'txtPDI_ID.Tag = mDocuIso.PDI_ID

        If mDocuIso.DIS_ADJUNTO IsNot Nothing Then
            picDIS_ADJUNTO.Image = picDIS_ADJUNTO.InitialImage
        Else
            picDIS_ADJUNTO.Image = picDIS_ADJUNTO.ErrorImage
        End If
        txtDIS_ADJUNTO_DESCRI.Text = mDocuIso.DIS_ADJUNTO_DESCRI

        'CargarPlantillaDocuIso(mDocuIso.PDI_ID)
        'LLenarGridPlantilla(False)

        If mDocuIso.Personas IsNot Nothing Then
            txtPER_ID_ELABORACION.Text = mDocuIso.Personas.PER_APE_PAT & " " & mDocuIso.Personas.PER_APE_MAT & " " & mDocuIso.Personas.PER_NOMBRES
            txtPER_ID_ELABORACION.Tag = mDocuIso.PER_ID_ELABORACION
            'With mDocuIso.Personas
            '    If .FotoPersonas IsNot Nothing Then
            '        If .FotoPersonas.Count > 0 Then
            '            If .FotoPersonas(0).FOP_ADJUNTO_DESCRI1.Length > 0 Then
            '                Dim bits As Byte() = DirectCast(.FotoPersonas(0).FOP_ADJUNTO1, Byte())
            '                Dim FileName As String = mRuta.Destino & .FotoPersonas(0).FOP_ADJUNTO_DESCRI1
            '                Dim fs As New FileStream(FileName, FileMode.Create)
            '                fs.Write(bits, 0, Convert.ToInt32(bits.Length))
            '                fs.Close()
            '                mRuta.Elaborado = FileName
            '            End If
            '        End If
            '    End If
            'End With
            dtpDIS_FECHA_ELABORACION.Value = mDocuIso.DIS_FECHA_ELABORACION
        End If
        If mDocuIso.Personas1 IsNot Nothing Then
            txtPER_ID_REVISION.Text = mDocuIso.Personas1.PER_APE_PAT & " " & mDocuIso.Personas1.PER_APE_MAT & " " & mDocuIso.Personas1.PER_NOMBRES
            txtPER_ID_REVISION.Tag = mDocuIso.PER_ID_REVISION
            'With mDocuIso.Personas1
            '    If .FotoPersonas IsNot Nothing Then
            '        If .FotoPersonas.Count > 0 Then
            '            If .FotoPersonas(0).FOP_ADJUNTO_DESCRI1.Length > 0 Then
            '                Dim bits As Byte() = DirectCast(.FotoPersonas(0).FOP_ADJUNTO1, Byte())
            '                Dim FileName As String = mRuta.Destino & .FotoPersonas(0).FOP_ADJUNTO_DESCRI1
            '                Dim fs As New FileStream(FileName, FileMode.Create)
            '                fs.Write(bits, 0, Convert.ToInt32(bits.Length))
            '                fs.Close()
            '                mRuta.Revisado = FileName
            '            End If
            '        End If
            '    End If
            'End With
            dtpDIS_FECHA_REVISION.Value = mDocuIso.DIS_FECHA_REVISION
        End If
        If mDocuIso.Personas2 IsNot Nothing Then
            txtPER_ID_APROBACION.Text = mDocuIso.Personas2.PER_APE_PAT & " " & mDocuIso.Personas2.PER_APE_MAT & " " & mDocuIso.Personas2.PER_NOMBRES
            txtPER_ID_APROBACION.Tag = mDocuIso.PER_ID_APROBACION
            'With mDocuIso.Personas2
            '    If .FotoPersonas IsNot Nothing Then
            '        If .FotoPersonas.Count > 0 Then
            '            If .FotoPersonas(0).FOP_ADJUNTO_DESCRI1.Length > 0 Then
            '                Dim bits As Byte() = DirectCast(.FotoPersonas(0).FOP_ADJUNTO1, Byte())
            '                Dim FileName As String = mRuta.Destino & .FotoPersonas(0).FOP_ADJUNTO_DESCRI1
            '                Dim fs As New FileStream(FileName, FileMode.Create)
            '                fs.Write(bits, 0, Convert.ToInt32(bits.Length))
            '                fs.Close()
            '                mRuta.Aprobado = FileName
            '            End If
            '        End If
            '    End If
            'End With
            dtpDIS_FECHA_APROBACION.Value = mDocuIso.DIS_FECHA_APROBACION
        End If

        'For Each mItem In mDocuIso.DocuIsoDetalle
        '    Dim nRow As New DataGridViewRow
        '    dgvDetalle.Rows.Add(nRow)
        '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DID_ID").Value = mItem.DID_ID
        '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DID_ID").Tag = mItem
        '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("MARCA").Value = mItem.DID_MARCA
        '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Texto").Value = mItem.DID_DESCRIPCION
        'Next

        If mDocuIso.DIS_DESCARGA = 1 Then
            rbtSi.Checked = True
            rbtNo.Checked = False
        Else
            rbtSi.Checked = False
            rbtNo.Checked = True
        End If

        If mDocuIso.DIS_PU_AR_PR = 0 Then
            rbtPublico.Checked = True
            rbtArea.Checked = False
            rbtPrivado.Checked = False
        ElseIf mDocuIso.DIS_PU_AR_PR = 1 Then
            rbtPublico.Checked = False
            rbtArea.Checked = True
            rbtPrivado.Checked = False
        Else
            rbtPublico.Checked = False
            rbtArea.Checked = False
            rbtPrivado.Checked = True
        End If

    End Sub

    Private Sub txtPER_ID_ELABORACION_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPER_ID_ELABORACION.DoubleClick
        If (mRuta.Destino & "").ToString.Length = 0 Then MsgBox("Por favor , cargar primero el archivo.") : Exit Sub

        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Foundation.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPER_ID_ELABORACION.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PER_Id
            txtPER_ID_ELABORACION.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Descripcion
            Per = BCPersona.PersonaGetById(txtPER_ID_ELABORACION.Tag)
            If Per.FotoPersonas IsNot Nothing Then
                If Per.FotoPersonas.Count > 0 Then
                    If Per.FotoPersonas(0).FOP_ADJUNTO_DESCRI1.Length > 0 Then
                        Dim bits As Byte() = DirectCast(Per.FotoPersonas(0).FOP_ADJUNTO1, Byte())
                        Dim FileName As String = mRuta.Destino & Per.FotoPersonas(0).FOP_ADJUNTO_DESCRI1
                        Dim fs As New FileStream(FileName, FileMode.Create)
                        fs.Write(bits, 0, Convert.ToInt32(bits.Length))
                        fs.Close()
                        mRuta.Elaborado = FileName
                    End If
                End If
            End If
        End If
        frm.Dispose()
    End Sub

    Private Sub txtPER_ID_ELABORACION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPER_ID_ELABORACION.KeyDown
        If e.KeyCode = Keys.Enter Then txtPER_ID_ELABORACION_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtPER_ID_REVISION_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPER_ID_REVISION.DoubleClick
        If (mRuta.Destino & "").ToString.Length = 0 Then MsgBox("Por favor , cargar primero el archivo.") : Exit Sub

        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Foundation.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPER_ID_REVISION.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PER_Id
            txtPER_ID_REVISION.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Descripcion
            Per = BCPersona.PersonaGetById(txtPER_ID_REVISION.Tag)
            If Per.FotoPersonas IsNot Nothing Then
                If Per.FotoPersonas.Count > 0 Then
                    If Per.FotoPersonas(0).FOP_ADJUNTO_DESCRI1.Length > 0 Then
                        Dim bits As Byte() = DirectCast(Per.FotoPersonas(0).FOP_ADJUNTO1, Byte())
                        Dim FileName As String = mRuta.Destino & Per.FotoPersonas(0).FOP_ADJUNTO_DESCRI1
                        Dim fs As New FileStream(FileName, FileMode.Create)
                        fs.Write(bits, 0, Convert.ToInt32(bits.Length))
                        fs.Close()
                        mRuta.Revisado = FileName
                    End If
                End If
            End If
        End If
        frm.Dispose()
    End Sub

    Private Sub txtPER_ID_REVISION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPER_ID_REVISION.KeyDown
        If e.KeyCode = Keys.Enter Then txtPER_ID_REVISION_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtPER_ID_APROBACION_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPER_ID_APROBACION.DoubleClick
        If (mRuta.Destino & "").ToString.Length = 0 Then MsgBox("Por favor , cargar primero el archivo.") : Exit Sub

        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Foundation.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPER_ID_APROBACION.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PER_Id
            txtPER_ID_APROBACION.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Descripcion
            Per = BCPersona.PersonaGetById(txtPER_ID_APROBACION.Tag)
            If Per.FotoPersonas IsNot Nothing Then
                If Per.FotoPersonas.Count > 0 Then
                    If Per.FotoPersonas(0).FOP_ADJUNTO_DESCRI1.Length > 0 Then
                        Dim bits As Byte() = DirectCast(Per.FotoPersonas(0).FOP_ADJUNTO1, Byte())
                        Dim FileName As String = mRuta.Destino & Per.FotoPersonas(0).FOP_ADJUNTO_DESCRI1
                        Dim fs As New FileStream(FileName, FileMode.Create)
                        fs.Write(bits, 0, Convert.ToInt32(bits.Length))
                        fs.Close()
                        mRuta.Aprobado = FileName
                    End If
                End If
            End If
        End If
        frm.Dispose()
    End Sub

    Private Sub txtPER_ID_APROBACION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPER_ID_APROBACION.KeyDown
        If e.KeyCode = Keys.Enter Then txtPER_ID_APROBACION_DoubleClick(Nothing, Nothing)
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        ''BORRAR ARCHIVOS
        If WordApp IsNot Nothing Then
            WordApp.Documents.Close(Word.WdSaveOptions.wdDoNotSaveChanges)
            WordApp.Quit()
            WordApp = Nothing
            aDoc = Nothing
        End If
        If System.IO.File.Exists(txtDIS_ADJUNTO_DESCRI.Tag) = True Then System.IO.File.Delete(txtDIS_ADJUNTO_DESCRI.Tag)
        If System.IO.File.Exists(mRuta.Elaborado) = True Then System.IO.File.Delete(mRuta.Elaborado)
        If System.IO.File.Exists(mRuta.Revisado) = True Then System.IO.File.Delete(mRuta.Revisado)
        If System.IO.File.Exists(mRuta.Aprobado) = True Then System.IO.File.Delete(mRuta.Aprobado)
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub


    Private Sub tooAdDescargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdDescargar.Click
        If mDocuIso.DIS_ADJUNTO IsNot Nothing Then
            Dim bits As Byte() = DirectCast(mDocuIso.DIS_ADJUNTO, Byte())
            sfdImagen.FileName = "_" & mDocuIso.DIS_ADJUNTO_DESCRI
            If sfdImagen.ShowDialog = DialogResult.OK Then
                Dim fs As New FileStream(sfdImagen.FileName, FileMode.Create)
                fs.Write(bits, 0, Convert.ToInt32(bits.Length))
                fs.Close()
                ' ''txtDIS_ADJUNTO_DESCRI.Tag = sfdImagen.FileName
                ''MessageBox.Show("El Archivo se guardo y se mostrara.")
                ''Process.Start(sfdImagen.FileName)

                'Dim WordApp_1 As Object
                'Dim aDoc_1 As Word.Document
                'WordApp_1 = CreateObject("Word.Application")
                'Dim fileName As Object = sfdImagen.FileName
                'Dim isVisible As Object = False
                'Dim missing As Object = System.Reflection.Missing.Value
                'WordApp_1.Visible = False
                'aDoc_1 = WordApp_1.Documents.Open(fileName, missing, missing, missing, missing, missing, missing, missing, missing, missing, isVisible)
                'aDoc_1.Activate()
                'Dim outputfilename = aDoc_1.FullName.Replace(".docx", ".pdf")
                'Dim mformato = Word.WdSaveFormat.wdFormatPDF
                'aDoc_1.SaveAs2(outputfilename, mformato, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing)

                'WordApp_1.Documents.Item(1).Save()
                'WordApp_1.Documents.Close(Word.WdSaveOptions.wdDoNotSaveChanges)
                'WordApp_1.Quit()
                'WordApp_1 = Nothing
                'aDoc_1 = Nothing
                'System.IO.File.Delete(sfdImagen.FileName)
                Process.Start(sfdImagen.FileName)
            End If
        End If
    End Sub

    Private Sub CargarAdjuntoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CargarAdjuntoToolStripMenuItem.Click
        If ofdImagen.FileName = "" And mDocuIso.DIS_ADJUNTO Is Nothing Then
            If Me.ofdImagen.ShowDialog() = Windows.Forms.DialogResult.OK Then
                mRuta.Destino = Path.GetDirectoryName(ofdImagen.FileName) & "\"
                mDocuIso.DIS_ADJUNTO = ReadBinaryFile(ofdImagen.FileName)
                mDocuIso.DIS_ADJUNTO_DESCRI = ofdImagen.SafeFileName
                picDIS_ADJUNTO.Image = picDIS_ADJUNTO.InitialImage
                txtDIS_ADJUNTO_DESCRI.Text = mDocuIso.DIS_ADJUNTO_DESCRI
            End If
        Else
            If InsertarFirma(ofdImagen.FileName) = 1 Then
                mDocuIso.DIS_ADJUNTO = ReadBinaryFile(ofdImagen.FileName)
                mDocuIso.DIS_ADJUNTO_DESCRI = ofdImagen.SafeFileName
                picDIS_ADJUNTO.Image = picDIS_ADJUNTO.InitialImage
                txtDIS_ADJUNTO_DESCRI.Text = mDocuIso.DIS_ADJUNTO_DESCRI
            Else
                MessageBox.Show("Para cargar un Adjunto debe de eliminar el Anterior.")
            End If
        End If
    End Sub

    Private Sub EliminarAdjuntoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EliminarAdjuntoToolStripMenuItem.Click
        If mDocuIso.DIS_ADJUNTO IsNot Nothing Then
            mDocuIso.DIS_ADJUNTO = Nothing
            mDocuIso.DIS_ADJUNTO_DESCRI = String.Empty
            picDIS_ADJUNTO.Image = picDIS_ADJUNTO.ErrorImage
        End If
    End Sub
End Class
