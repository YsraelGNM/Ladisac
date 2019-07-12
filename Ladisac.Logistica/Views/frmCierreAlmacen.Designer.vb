<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCierreAlmacen
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
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Almacenes")
        Me.treeAlmacen = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbtAbrir = New System.Windows.Forms.RadioButton()
        Me.rbtCerrar = New System.Windows.Forms.RadioButton()
        Me.Error_validacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.numAnio = New System.Windows.Forms.NumericUpDown()
        Me.numMes = New System.Windows.Forms.NumericUpDown()
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(582, 28)
        Me.lblTitle.Text = "Cierre Almacen"
        '
        'treeAlmacen
        '
        Me.treeAlmacen.CheckBoxes = True
        Me.treeAlmacen.Location = New System.Drawing.Point(12, 90)
        Me.treeAlmacen.Name = "treeAlmacen"
        TreeNode2.Name = "Node0"
        TreeNode2.Tag = "-1"
        TreeNode2.Text = "Almacenes"
        Me.treeAlmacen.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})
        Me.treeAlmacen.Size = New System.Drawing.Size(413, 353)
        Me.treeAlmacen.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(432, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nro. Año"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(432, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nro. Mes"
        '
        'rbtAbrir
        '
        Me.rbtAbrir.AutoSize = True
        Me.rbtAbrir.Location = New System.Drawing.Point(435, 206)
        Me.rbtAbrir.Name = "rbtAbrir"
        Me.rbtAbrir.Size = New System.Drawing.Size(90, 17)
        Me.rbtAbrir.TabIndex = 7
        Me.rbtAbrir.TabStop = True
        Me.rbtAbrir.Text = "Abrir Almacen"
        Me.rbtAbrir.UseVisualStyleBackColor = True
        '
        'rbtCerrar
        '
        Me.rbtCerrar.AutoSize = True
        Me.rbtCerrar.Location = New System.Drawing.Point(435, 247)
        Me.rbtCerrar.Name = "rbtCerrar"
        Me.rbtCerrar.Size = New System.Drawing.Size(97, 17)
        Me.rbtCerrar.TabIndex = 8
        Me.rbtCerrar.TabStop = True
        Me.rbtCerrar.Text = "Cerrar Almacen"
        Me.rbtCerrar.UseVisualStyleBackColor = True
        '
        'Error_validacion
        '
        Me.Error_validacion.ContainerControl = Me
        '
        'numAnio
        '
        Me.numAnio.Location = New System.Drawing.Point(487, 95)
        Me.numAnio.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.numAnio.Name = "numAnio"
        Me.numAnio.Size = New System.Drawing.Size(81, 20)
        Me.numAnio.TabIndex = 9
        '
        'numMes
        '
        Me.numMes.Location = New System.Drawing.Point(487, 140)
        Me.numMes.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.numMes.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numMes.Name = "numMes"
        Me.numMes.Size = New System.Drawing.Size(45, 20)
        Me.numMes.TabIndex = 10
        Me.numMes.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'frmCierreAlmacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(582, 477)
        Me.Controls.Add(Me.numMes)
        Me.Controls.Add(Me.numAnio)
        Me.Controls.Add(Me.rbtCerrar)
        Me.Controls.Add(Me.rbtAbrir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.treeAlmacen)
        Me.Name = "frmCierreAlmacen"
        Me.Text = "Cierre Almacen"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.treeAlmacen, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.rbtAbrir, 0)
        Me.Controls.SetChildIndex(Me.rbtCerrar, 0)
        Me.Controls.SetChildIndex(Me.numAnio, 0)
        Me.Controls.SetChildIndex(Me.numMes, 0)
        CType(Me.Error_validacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents treeAlmacen As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbtAbrir As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCerrar As System.Windows.Forms.RadioButton
    Friend WithEvents Error_validacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents numMes As System.Windows.Forms.NumericUpDown
    Friend WithEvents numAnio As System.Windows.Forms.NumericUpDown

End Class
