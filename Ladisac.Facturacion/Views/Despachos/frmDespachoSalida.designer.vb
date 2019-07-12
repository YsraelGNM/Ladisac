Namespace Ladisac.Despachos.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDespachoSalida
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
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.dgvArticuloSalida = New System.Windows.Forms.DataGridView()
            Me.CodArticulo1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Descripcion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Cantidad1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.dgvArticuloOriginal = New System.Windows.Forms.DataGridView()
            Me.CodArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtGuiaRemision = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.label4 = New System.Windows.Forms.Label()
            Me.Error_Validacion = New System.Windows.Forms.ErrorProvider()
            Me.GroupBox2.SuspendLayout()
            CType(Me.dgvArticuloSalida, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.dgvArticuloOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(867, 28)
            Me.lblTitle.Text = "Despacho Salida"
            '
            'GroupBox2
            '
            Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox2.Controls.Add(Me.dgvArticuloSalida)
            Me.GroupBox2.Location = New System.Drawing.Point(444, 151)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(411, 270)
            Me.GroupBox2.TabIndex = 64
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Items Articulo Salida"
            '
            'dgvArticuloSalida
            '
            Me.dgvArticuloSalida.AllowUserToAddRows = False
            Me.dgvArticuloSalida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvArticuloSalida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvArticuloSalida.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodArticulo1, Me.Descripcion1, Me.Cantidad1})
            Me.dgvArticuloSalida.Location = New System.Drawing.Point(6, 15)
            Me.dgvArticuloSalida.Name = "dgvArticuloSalida"
            Me.dgvArticuloSalida.Size = New System.Drawing.Size(399, 249)
            Me.dgvArticuloSalida.TabIndex = 1
            '
            'CodArticulo1
            '
            Me.CodArticulo1.HeaderText = "Cod. Articulo"
            Me.CodArticulo1.Name = "CodArticulo1"
            '
            'Descripcion1
            '
            Me.Descripcion1.HeaderText = "Descripcion"
            Me.Descripcion1.Name = "Descripcion1"
            '
            'Cantidad1
            '
            Me.Cantidad1.HeaderText = "Cantidad"
            Me.Cantidad1.Name = "Cantidad1"
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.GroupBox1.Controls.Add(Me.dgvArticuloOriginal)
            Me.GroupBox1.Location = New System.Drawing.Point(10, 151)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(420, 270)
            Me.GroupBox1.TabIndex = 63
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Items Articulo Original"
            '
            'dgvArticuloOriginal
            '
            Me.dgvArticuloOriginal.AllowUserToAddRows = False
            Me.dgvArticuloOriginal.AllowUserToDeleteRows = False
            Me.dgvArticuloOriginal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.dgvArticuloOriginal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvArticuloOriginal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodArticulo, Me.Descripcion, Me.Cantidad})
            Me.dgvArticuloOriginal.Location = New System.Drawing.Point(3, 15)
            Me.dgvArticuloOriginal.Name = "dgvArticuloOriginal"
            Me.dgvArticuloOriginal.ReadOnly = True
            Me.dgvArticuloOriginal.Size = New System.Drawing.Size(411, 249)
            Me.dgvArticuloOriginal.TabIndex = 0
            '
            'CodArticulo
            '
            Me.CodArticulo.HeaderText = "Cod. Articulo"
            Me.CodArticulo.Name = "CodArticulo"
            Me.CodArticulo.ReadOnly = True
            '
            'Descripcion
            '
            Me.Descripcion.HeaderText = "Descripcion"
            Me.Descripcion.Name = "Descripcion"
            Me.Descripcion.ReadOnly = True
            '
            'Cantidad
            '
            Me.Cantidad.HeaderText = "Cantidad"
            Me.Cantidad.Name = "Cantidad"
            Me.Cantidad.ReadOnly = True
            '
            'dtpFecha
            '
            Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFecha.Location = New System.Drawing.Point(586, 66)
            Me.dtpFecha.Name = "dtpFecha"
            Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
            Me.dtpFecha.TabIndex = 60
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(123, 120)
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(558, 20)
            Me.txtObservaciones.TabIndex = 59
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(23, 124)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(78, 13)
            Me.Label3.TabIndex = 58
            Me.Label3.Text = "Observaciones"
            '
            'txtGuiaRemision
            '
            Me.txtGuiaRemision.Location = New System.Drawing.Point(123, 92)
            Me.txtGuiaRemision.Name = "txtGuiaRemision"
            Me.txtGuiaRemision.Size = New System.Drawing.Size(181, 20)
            Me.txtGuiaRemision.TabIndex = 57
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(23, 96)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(75, 13)
            Me.Label2.TabIndex = 56
            Me.Label2.Text = "Guia Remision"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(543, 70)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(37, 13)
            Me.Label1.TabIndex = 55
            Me.Label1.Text = "Fecha"
            '
            'txtCodigo
            '
            Me.txtCodigo.Enabled = False
            Me.txtCodigo.Location = New System.Drawing.Point(123, 66)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
            Me.txtCodigo.TabIndex = 54
            '
            'label4
            '
            Me.label4.AutoSize = True
            Me.label4.Location = New System.Drawing.Point(23, 70)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(40, 13)
            Me.label4.TabIndex = 53
            Me.label4.Text = "Codigo"
            '
            'Error_Validacion
            '
            Me.Error_Validacion.ContainerControl = Me
            '
            'frmDespachoSalida
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(867, 433)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.dtpFecha)
            Me.Controls.Add(Me.txtObservaciones)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.txtGuiaRemision)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.txtCodigo)
            Me.Controls.Add(Me.label4)
            Me.Name = "frmDespachoSalida"
            Me.Text = "Despacho Salida"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.label4, 0)
            Me.Controls.SetChildIndex(Me.txtCodigo, 0)
            Me.Controls.SetChildIndex(Me.Label1, 0)
            Me.Controls.SetChildIndex(Me.Label2, 0)
            Me.Controls.SetChildIndex(Me.txtGuiaRemision, 0)
            Me.Controls.SetChildIndex(Me.Label3, 0)
            Me.Controls.SetChildIndex(Me.txtObservaciones, 0)
            Me.Controls.SetChildIndex(Me.dtpFecha, 0)
            Me.Controls.SetChildIndex(Me.GroupBox1, 0)
            Me.Controls.SetChildIndex(Me.GroupBox2, 0)
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.dgvArticuloSalida, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.dgvArticuloOriginal, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Error_Validacion, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents dgvArticuloSalida As System.Windows.Forms.DataGridView
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents dgvArticuloOriginal As System.Windows.Forms.DataGridView
        Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtGuiaRemision As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents label4 As System.Windows.Forms.Label
        Friend WithEvents CodArticulo1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Descripcion1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Cantidad1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CodArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Error_Validacion As System.Windows.Forms.ErrorProvider

    End Class

End Namespace