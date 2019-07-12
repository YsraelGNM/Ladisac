Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.Office.Interop

Public Class frmPlantillaDocuIso
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCPlantillaDocuIso As Ladisac.BL.IBCPlantillaDocuIso
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Public mPDI As PlantillaDocuIso

    Private Sub frmPlantillaDocuIso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
    End Sub

    Sub LimpiarControles()
        mPDI = Nothing
        txtPDI_Nombre.Text = String.Empty
        picPlantilla.Image = picPlantilla.ErrorImage
    End Sub

    Public Overrides Sub OnManEliminar()
        If mPDI IsNot Nothing Then
            mPDI.MarkAsDeleted()
            BCPlantillaDocuIso.MantenimientoPlantillaDocuIso(mPDI)
            Call LimpiarControles()
            Call validacion_desactivacion(False, 3)
        End If
    End Sub

    Public Overrides Sub OnManGuardar()
        If mPDI IsNot Nothing Then
            mPDI.PDI_NOMBRE = txtPDI_Nombre.Text
            mPDI.PDI_ESTADO = True
            mPDI.PDI_FEC_GRAB = Now
            mPDI.USU_ID = SessionServer.UserId

            BCPlantillaDocuIso.MantenimientoPlantillaDocuIso(mPDI)
            MessageBox.Show(mPDI.PDI_ID)
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
            mPDI.PDI_ADJUNTO = ReadBinaryFile(ofdImagen.FileName)
            mPDI.PDI_NOMBRE = ofdImagen.SafeFileName
            txtPDI_Nombre.Text = ofdImagen.SafeFileName
            picPlantilla.Image = picPlantilla.InitialImage
        End If
    End Sub

    Private Sub tooAdEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdEliminar.Click
        If mPDI.PDI_ADJUNTO IsNot Nothing Then
            mPDI.PDI_ADJUNTO = Nothing
            mPDI.PDI_NOMBRE = String.Empty
            picPlantilla.Image = picPlantilla.ErrorImage
        End If
    End Sub

    Private Sub tooAdDescargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdDescargar.Click
        If mPDI.PDI_ADJUNTO IsNot Nothing Then
            Dim bits As Byte() = DirectCast(mPDI.PDI_ADJUNTO, Byte())
            sfdImagen.FileName = mPDI.PDI_NOMBRE
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
        mPDI = New PlantillaDocuIso
        mPDI.MarkAsAdded()
        Call validacion_desactivacion(True, 2)
        txtPDI_Nombre.Focus()
    End Sub

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Foundation.Views.frmBuscar)()
        frm.Tabla = "PlantillaDocuIso"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarPlantillaDocuIso(key)
            LlenarControles()
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarPlantillaDocuIso(ByVal PDI_Id As Integer)
        mPDI = BCPlantillaDocuIso.PlantillaDocuIsoGetById(PDI_Id)
        mPDI.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mPDI.PDI_ID
        picPlantilla.Image = picPlantilla.InitialImage
        txtPDI_Nombre.Text = mPDI.PDI_NOMBRE
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        MyBase.OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub

End Class
