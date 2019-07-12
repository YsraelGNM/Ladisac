<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFotoPersona
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
        Me.txtFOP_ADJUNTO_DESCRI1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.picFirma = New System.Windows.Forms.PictureBox()
        Me.cmAdjunto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tooAdCargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tooAdDescargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tooAdEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ofdImagen = New System.Windows.Forms.OpenFileDialog()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.sfdImagen = New System.Windows.Forms.SaveFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtPER_ID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.picFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmAdjunto.SuspendLayout()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(525, 28)
        Me.lblTitle.Text = "Firma ISO"
        '
        'txtFOP_ADJUNTO_DESCRI1
        '
        Me.txtFOP_ADJUNTO_DESCRI1.Location = New System.Drawing.Point(141, 227)
        Me.txtFOP_ADJUNTO_DESCRI1.Name = "txtFOP_ADJUNTO_DESCRI1"
        Me.txtFOP_ADJUNTO_DESCRI1.Size = New System.Drawing.Size(356, 20)
        Me.txtFOP_ADJUNTO_DESCRI1.TabIndex = 146
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 231)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 13)
        Me.Label13.TabIndex = 145
        Me.Label13.Text = "Nombre de la Firma"
        '
        'picFirma
        '
        Me.picFirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picFirma.ContextMenuStrip = Me.cmAdjunto
        Me.picFirma.Location = New System.Drawing.Point(141, 113)
        Me.picFirma.Name = "picFirma"
        Me.picFirma.Size = New System.Drawing.Size(68, 43)
        Me.picFirma.TabIndex = 144
        Me.picFirma.TabStop = False
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
        'txtPER_ID
        '
        Me.txtPER_ID.Location = New System.Drawing.Point(141, 185)
        Me.txtPER_ID.Name = "txtPER_ID"
        Me.txtPER_ID.Size = New System.Drawing.Size(356, 20)
        Me.txtPER_ID.TabIndex = 151
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 150
        Me.Label5.Text = "Trabajador"
        '
        'frmFotoPersona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(525, 275)
        Me.Controls.Add(Me.txtPER_ID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.txtFOP_ADJUNTO_DESCRI1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.picFirma)
        Me.Controls.Add(Me.Label12)
        Me.Name = "frmFotoPersona"
        Me.Text = "Firma ISO"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.picFirma, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.txtFOP_ADJUNTO_DESCRI1, 0)
        Me.Controls.SetChildIndex(Me.txtCodigo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtPER_ID, 0)
        CType(Me.picFirma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmAdjunto.ResumeLayout(False)
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFOP_ADJUNTO_DESCRI1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents picFirma As System.Windows.Forms.PictureBox
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
    Friend WithEvents txtPER_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
