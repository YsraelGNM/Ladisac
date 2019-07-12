Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.Office.Interop

Public Class frmFotoPersona
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCFotoPersona As Ladisac.BL.IBCFotoPersona
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Public mFOP As FotoPersonas

    Private Sub frmFotoPersona_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
    End Sub

    Sub LimpiarControles()
        mFOP = Nothing
        txtFOP_ADJUNTO_DESCRI1.Text = String.Empty
        txtPER_ID.Text = String.Empty
        txtPER_ID.Tag = Nothing
        picFirma.Image = picFirma.ErrorImage
    End Sub

    Public Overrides Sub OnManEliminar()
        If mFOP IsNot Nothing Then
            mFOP.MarkAsDeleted()
            BCFotoPersona.MantenimientoFotoPersona(mFOP)
            Call LimpiarControles()
            Call validacion_desactivacion(False, 3)
        End If
    End Sub

    Public Overrides Sub OnManGuardar()
        If mFOP IsNot Nothing Then
            mFOP.PER_ID = txtPER_ID.Tag
            mFOP.FOP_ADJUNTO_DESCRI1 = txtFOP_ADJUNTO_DESCRI1.Text
            mFOP.FOP_ESTADO = True
            mFOP.FOP_FEC_GRAB = Now
            mFOP.USU_ID = SessionServer.UserId

            BCFotoPersona.MantenimientoFotoPersona(mFOP)
            MessageBox.Show(mFOP.FOP_ID)
            LimpiarControles()
        End If
        Call validacion_desactivacion(False, 3)
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

    Private Sub tooAdCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdCargar.Click
        If Me.ofdImagen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            mFOP.FOP_ADJUNTO1 = ReadBinaryFile(ofdImagen.FileName)
            mFOP.FOP_ADJUNTO_DESCRI1 = ofdImagen.SafeFileName
            txtFOP_ADJUNTO_DESCRI1.Text = ofdImagen.SafeFileName
            picFirma.Image = picFirma.InitialImage
        End If
    End Sub

    Private Sub tooAdEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdEliminar.Click
        If mFOP.FOP_ADJUNTO1 IsNot Nothing Then
            mFOP.FOP_ADJUNTO1 = Nothing
            mFOP.FOP_ADJUNTO_DESCRI1 = String.Empty
            picFirma.Image = picFirma.ErrorImage
        End If
    End Sub

    Private Sub tooAdDescargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdDescargar.Click
        If mFOP.FOP_ADJUNTO1 IsNot Nothing Then
            Dim bits As Byte() = DirectCast(mFOP.FOP_ADJUNTO1, Byte())
            sfdImagen.FileName = mFOP.FOP_ADJUNTO_DESCRI1
            If sfdImagen.ShowDialog = DialogResult.OK Then
                Dim fs As New FileStream(sfdImagen.FileName, FileMode.Create)
                fs.Write(bits, 0, Convert.ToInt32(bits.Length))
                fs.Close()
                MessageBox.Show("El Archivo se guardo y se mostrara.")
                Process.Start(sfdImagen.FileName)



                'Dim WordApp As Object
                'WordApp = CreateObject("Word.Application")
                'Dim fileName As Object = sfdImagen.FileName
                'Dim soloLectura As Object = False
                'Dim isVisible As Object = True
                'Dim missing As Object = System.Reflection.Missing.Value
                'WordApp.Visible = True
                'Dim aDoc As word.document
                'aDoc = WordApp.Documents.Open(fileName, missing, missing, missing, missing, missing, missing, missing, missing, missing, isVisible)
                'aDoc.Activate()
            End If
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

    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mFOP = New FotoPersonas
        mFOP.MarkAsAdded()
        Call validacion_desactivacion(True, 2)
    End Sub

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "FotoPersona"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarFotoPersona(key)
            LlenarControles()
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarFotoPersona(ByVal PDI_Id As Integer)
        mFOP = BCFotoPersona.FotoPersonaGetById(PDI_Id)
        mFOP.MarkAsModified()
    End Sub

    Sub LlenarControles()
        picFirma.Image = picFirma.InitialImage
        txtFOP_ADJUNTO_DESCRI1.Text = mFOP.FOP_ADJUNTO_DESCRI1
        txtPER_ID.Text = mFOP.Personas.PER_APE_PAT & " " & mFOP.Personas.PER_APE_MAT & " " & mFOP.Personas.PER_NOMBRES
        txtPER_ID.Tag = mFOP.PER_ID
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        MyBase.OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub

    Private Sub txtPER_ID_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPER_ID.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPER_ID.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PER_Id
            txtPER_ID.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    Private Sub txtPER_ID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPER_ID.KeyDown
        If e.KeyCode = Keys.Enter Then txtPER_ID_DoubleClick(Nothing, Nothing)
    End Sub
End Class
