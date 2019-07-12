<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlantillaDocuIso
    Inherits Ladisac.Foundation.Views.ViewManMaster

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtPDI_Nombre = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.picPlantilla = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ofdImagen = New System.Windows.Forms.OpenFileDialog()
        Me.cmAdjunto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tooAdCargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tooAdDescargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tooAdEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.sfdImagen = New System.Windows.Forms.SaveFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        CType(Me.picPlantilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmAdjunto.SuspendLayout()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(525, 28)
        Me.lblTitle.Text = "Plantilla Documento ISO"
        '
        'txtPDI_Nombre
        '
        Me.txtPDI_Nombre.Location = New System.Drawing.Point(141, 183)
        Me.txtPDI_Nombre.Name = "txtPDI_Nombre"
        Me.txtPDI_Nombre.Size = New System.Drawing.Size(356, 20)
        Me.txtPDI_Nombre.TabIndex = 146
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 187)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(109, 13)
        Me.Label13.TabIndex = 145
        Me.Label13.Text = "Nombre de la Plantilla"
        '
        'picPlantilla
        '
        Me.picPlantilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picPlantilla.ContextMenuStrip = Me.cmAdjunto
        Me.picPlantilla.Location = New System.Drawing.Point(141, 113)
        Me.picPlantilla.Name = "picPlantilla"
        Me.picPlantilla.Size = New System.Drawing.Size(68, 43)
        Me.picPlantilla.TabIndex = 144
        Me.picPlantilla.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 143
        Me.Label12.Text = "Adjunto"
        '
        'ofdImagen
        '
        Me.ofdImagen.Filter = "All files (*.*)|*.*"
        '
        'cmAdjunto
        '
        Me.cmAdjunto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tooAdCargar, Me.tooAdDescargar, Me.tooAdEliminar})
        Me.cmAdjunto.Name = "cmUsc"
        Me.cmAdjunto.Size = New System.Drawing.Size(173, 70)
        '
        'tooAdCargar
        '
        Me.tooAdCargar.Name = "tooAdCargar"
        Me.tooAdCargar.Size = New System.Drawing.Size(172, 22)
        Me.tooAdCargar.Text = "Cargar Adjunto"
        '
        'tooAdDescargar
        '
        Me.tooAdDescargar.Name = "tooAdDescargar"
        Me.tooAdDescargar.Size = New System.Drawing.Size(172, 22)
        Me.tooAdDescargar.Text = "Descargar Adjunto"
        '
        'tooAdEliminar
        '
        Me.tooAdEliminar.Name = "tooAdEliminar"
        Me.tooAdEliminar.Size = New System.Drawing.Size(172, 22)
        Me.tooAdEliminar.Text = "Eliminar Adjunto"
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'sfdImagen
        '
        Me.sfdImagen.Filter = "All files (*.*)|*.*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 149
        Me.Label2.Text = "Codigo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(141, 72)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(68, 20)
        Me.txtCodigo.TabIndex = 148
        '
        'frmPlantillaDocuIso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(525, 235)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.txtPDI_Nombre)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.picPlantilla)
        Me.Controls.Add(Me.Label12)
        Me.Name = "frmPlantillaDocuIso"
        Me.Text = "Plantilla Documento ISO"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.picPlantilla, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.txtPDI_Nombre, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        CType(Me.picPlantilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmAdjunto.ResumeLayout(False)
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPDI_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents picPlantilla As System.Windows.Forms.PictureBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ofdImagen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmAdjunto As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tooAdDescargar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tooAdEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents sfdImagen As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents tooAdCargar As System.Windows.Forms.ToolStripMenuItem

End Class
