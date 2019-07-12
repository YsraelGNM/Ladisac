<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisualizarISO
    Inherits Ladisac.Foundation.Views.ViewMaster

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
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.sfdImagen = New System.Windows.Forms.SaveFileDialog()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.txtCodDoc = New System.Windows.Forms.TextBox()
        Me.txtCodArea = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtARE_ID = New System.Windows.Forms.TextBox()
        Me.txtDTD_ID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fila = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Version = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecApro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Elaborado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Revisado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aprobado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(944, 28)
        Me.lblTitle.Text = "Listado Documentos ISO"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToOrderColumns = True
        Me.dgvDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fila, Me.Nombre, Me.Version, Me.FecApro, Me.Elaborado, Me.Revisado, Me.Aprobado})
        Me.dgvDetalle.Location = New System.Drawing.Point(8, 76)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.Size = New System.Drawing.Size(628, 428)
        Me.dgvDetalle.TabIndex = 1
        '
        'sfdImagen
        '
        Me.sfdImagen.Filter = "All files (*.*)|*.*"
        Me.sfdImagen.InitialDirectory = "D:\"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(293, 516)
        Me.WebBrowser1.TabIndex = 2
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False
        '
        'txtCodDoc
        '
        Me.txtCodDoc.Location = New System.Drawing.Point(491, 38)
        Me.txtCodDoc.Name = "txtCodDoc"
        Me.txtCodDoc.ReadOnly = True
        Me.txtCodDoc.Size = New System.Drawing.Size(62, 20)
        Me.txtCodDoc.TabIndex = 153
        '
        'txtCodArea
        '
        Me.txtCodArea.Location = New System.Drawing.Point(491, 12)
        Me.txtCodArea.Name = "txtCodArea"
        Me.txtCodArea.ReadOnly = True
        Me.txtCodArea.Size = New System.Drawing.Size(62, 20)
        Me.txtCodArea.TabIndex = 152
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "Area"
        '
        'txtARE_ID
        '
        Me.txtARE_ID.Location = New System.Drawing.Point(97, 12)
        Me.txtARE_ID.Name = "txtARE_ID"
        Me.txtARE_ID.Size = New System.Drawing.Size(388, 20)
        Me.txtARE_ID.TabIndex = 149
        '
        'txtDTD_ID
        '
        Me.txtDTD_ID.Location = New System.Drawing.Point(97, 38)
        Me.txtDTD_ID.Name = "txtDTD_ID"
        Me.txtDTD_ID.Size = New System.Drawing.Size(388, 20)
        Me.txtDTD_ID.TabIndex = 150
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 151
        Me.Label4.Text = "Tipo Documento"
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(560, 12)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(75, 46)
        Me.btnCargar.TabIndex = 154
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtARE_ID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCargar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvDetalle)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCodDoc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCodArea)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDTD_ID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.WebBrowser1)
        Me.SplitContainer1.Size = New System.Drawing.Size(944, 516)
        Me.SplitContainer1.SplitterDistance = 643
        Me.SplitContainer1.SplitterWidth = 8
        Me.SplitContainer1.TabIndex = 155
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 30.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Nombre Documento"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 402
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 51
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nombre Documento"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 50
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Nº Version"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 50
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Fecha Aprobacion"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 50
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Elaborado por"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 51
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Revisado por"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 50
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Aprobado por"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 50
        '
        'Fila
        '
        Me.Fila.FillWeight = 30.0!
        Me.Fila.HeaderText = "Nº"
        Me.Fila.Name = "Fila"
        Me.Fila.ReadOnly = True
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre Documento"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'Version
        '
        Me.Version.HeaderText = "Nº Version"
        Me.Version.Name = "Version"
        Me.Version.ReadOnly = True
        '
        'FecApro
        '
        Me.FecApro.HeaderText = "Fecha Aprobacion"
        Me.FecApro.Name = "FecApro"
        Me.FecApro.ReadOnly = True
        '
        'Elaborado
        '
        Me.Elaborado.HeaderText = "Elaborado por"
        Me.Elaborado.Name = "Elaborado"
        Me.Elaborado.ReadOnly = True
        '
        'Revisado
        '
        Me.Revisado.HeaderText = "Revisado por"
        Me.Revisado.Name = "Revisado"
        Me.Revisado.ReadOnly = True
        '
        'Aprobado
        '
        Me.Aprobado.HeaderText = "Aprobado por"
        Me.Aprobado.Name = "Aprobado"
        Me.Aprobado.ReadOnly = True
        '
        'frmVisualizarISO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(944, 544)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmVisualizarISO"
        Me.Text = "Listado Documentos ISO"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents sfdImagen As System.Windows.Forms.SaveFileDialog
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCodDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtCodArea As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtARE_ID As System.Windows.Forms.TextBox
    Friend WithEvents txtDTD_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Fila As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Version As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecApro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Elaborado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Revisado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aprobado As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
