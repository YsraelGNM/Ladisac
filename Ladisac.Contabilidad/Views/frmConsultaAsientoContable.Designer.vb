Namespace Ladisac.Contabilidad.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmConsultaAsientoContable
        Inherits Foundation.Views.ViewMaster
        '        Inherits System.Windows.Forms.Form

        'Form reemplaza a Dispose para limpiar la lista de componentes.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Requerido por el Diseñador de Windows Forms
        Private components As System.ComponentModel.IContainer

        'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
        'Se puede modificar usando el Diseñador de Windows Forms.  
        'No lo modifique con el editor de código.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.dgvCabecera = New System.Windows.Forms.DataGridView()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.lblNumero = New System.Windows.Forms.Label()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.lblSerie = New System.Windows.Forms.Label()
            Me.txtNombre = New System.Windows.Forms.TextBox()
            Me.lblNombre = New System.Windows.Forms.Label()
            Me.txtVoucher = New System.Windows.Forms.TextBox()
            Me.lblVoucher = New System.Windows.Forms.Label()
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.btnLibro = New System.Windows.Forms.Button()
            Me.txtLibro = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnPeriodo = New System.Windows.Forms.Button()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Panel1.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(750, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Controls.Add(Me.dgvCabecera)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(741, 437)
            Me.Panel1.TabIndex = 1
            '
            'Label4
            '
            Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(7, 234)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(117, 13)
            Me.Label4.TabIndex = 4
            Me.Label4.Text = "Detalle de Asientos"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(4, 67)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(118, 13)
            Me.Label3.TabIndex = 3
            Me.Label3.Text = "Listado de Asientos"
            '
            'dgvDetalle
            '
            Me.dgvDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Location = New System.Drawing.Point(4, 250)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvDetalle.Size = New System.Drawing.Size(732, 181)
            Me.dgvDetalle.TabIndex = 2
            '
            'dgvCabecera
            '
            Me.dgvCabecera.AllowUserToAddRows = False
            Me.dgvCabecera.AllowUserToDeleteRows = False
            Me.dgvCabecera.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvCabecera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvCabecera.Location = New System.Drawing.Point(4, 87)
            Me.dgvCabecera.Name = "dgvCabecera"
            Me.dgvCabecera.ReadOnly = True
            Me.dgvCabecera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvCabecera.Size = New System.Drawing.Size(732, 143)
            Me.dgvCabecera.TabIndex = 1
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.txtNumero)
            Me.Panel2.Controls.Add(Me.lblNumero)
            Me.Panel2.Controls.Add(Me.txtSerie)
            Me.Panel2.Controls.Add(Me.lblSerie)
            Me.Panel2.Controls.Add(Me.txtNombre)
            Me.Panel2.Controls.Add(Me.lblNombre)
            Me.Panel2.Controls.Add(Me.txtVoucher)
            Me.Panel2.Controls.Add(Me.lblVoucher)
            Me.Panel2.Controls.Add(Me.btnGenerar)
            Me.Panel2.Controls.Add(Me.btnLibro)
            Me.Panel2.Controls.Add(Me.txtLibro)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.btnPeriodo)
            Me.Panel2.Controls.Add(Me.txtPeriodo)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Location = New System.Drawing.Point(5, 4)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(731, 60)
            Me.Panel2.TabIndex = 0
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(641, 36)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.Size = New System.Drawing.Size(85, 20)
            Me.txtNumero.TabIndex = 13
            '
            'lblNumero
            '
            Me.lblNumero.AutoSize = True
            Me.lblNumero.Location = New System.Drawing.Point(594, 36)
            Me.lblNumero.Name = "lblNumero"
            Me.lblNumero.Size = New System.Drawing.Size(44, 13)
            Me.lblNumero.TabIndex = 12
            Me.lblNumero.Text = "Número"
            '
            'txtSerie
            '
            Me.txtSerie.Location = New System.Drawing.Point(515, 36)
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.Size = New System.Drawing.Size(50, 20)
            Me.txtSerie.TabIndex = 11
            '
            'lblSerie
            '
            Me.lblSerie.AutoSize = True
            Me.lblSerie.Location = New System.Drawing.Point(481, 36)
            Me.lblSerie.Name = "lblSerie"
            Me.lblSerie.Size = New System.Drawing.Size(31, 13)
            Me.lblSerie.TabIndex = 10
            Me.lblSerie.Text = "Serie"
            '
            'txtNombre
            '
            Me.txtNombre.Location = New System.Drawing.Point(232, 36)
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.Size = New System.Drawing.Size(229, 20)
            Me.txtNombre.TabIndex = 9
            '
            'lblNombre
            '
            Me.lblNombre.AutoSize = True
            Me.lblNombre.Location = New System.Drawing.Point(185, 36)
            Me.lblNombre.Name = "lblNombre"
            Me.lblNombre.Size = New System.Drawing.Size(44, 13)
            Me.lblNombre.TabIndex = 8
            Me.lblNombre.Text = "Nombre"
            '
            'txtVoucher
            '
            Me.txtVoucher.Location = New System.Drawing.Point(50, 36)
            Me.txtVoucher.MaxLength = 6
            Me.txtVoucher.Name = "txtVoucher"
            Me.txtVoucher.Size = New System.Drawing.Size(75, 20)
            Me.txtVoucher.TabIndex = 7
            '
            'lblVoucher
            '
            Me.lblVoucher.AutoSize = True
            Me.lblVoucher.Location = New System.Drawing.Point(3, 36)
            Me.lblVoucher.Name = "lblVoucher"
            Me.lblVoucher.Size = New System.Drawing.Size(47, 13)
            Me.lblVoucher.TabIndex = 6
            Me.lblVoucher.Text = "Voucher"
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(641, 9)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(85, 23)
            Me.btnGenerar.TabIndex = 14
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'btnLibro
            '
            Me.btnLibro.Location = New System.Drawing.Point(433, 8)
            Me.btnLibro.Name = "btnLibro"
            Me.btnLibro.Size = New System.Drawing.Size(28, 23)
            Me.btnLibro.TabIndex = 5
            Me.btnLibro.Text = ":::"
            Me.btnLibro.UseVisualStyleBackColor = True
            '
            'txtLibro
            '
            Me.txtLibro.Location = New System.Drawing.Point(232, 9)
            Me.txtLibro.Name = "txtLibro"
            Me.txtLibro.ReadOnly = True
            Me.txtLibro.Size = New System.Drawing.Size(201, 20)
            Me.txtLibro.TabIndex = 4
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(185, 12)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(30, 13)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Libro"
            '
            'btnPeriodo
            '
            Me.btnPeriodo.Location = New System.Drawing.Point(127, 5)
            Me.btnPeriodo.Name = "btnPeriodo"
            Me.btnPeriodo.Size = New System.Drawing.Size(28, 23)
            Me.btnPeriodo.TabIndex = 2
            Me.btnPeriodo.Text = ":::"
            Me.btnPeriodo.UseVisualStyleBackColor = True
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(50, 7)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(75, 20)
            Me.txtPeriodo.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(3, 9)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(43, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Periodo"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmConsultaAsientoContable
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(750, 473)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmConsultaAsientoContable"
            Me.Text = "frmConsultaAsientoContable"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvCabecera, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents dgvCabecera As System.Windows.Forms.DataGridView
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents btnLibro As System.Windows.Forms.Button
        Friend WithEvents txtLibro As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnPeriodo As System.Windows.Forms.Button
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtVoucher As System.Windows.Forms.TextBox
        Friend WithEvents lblVoucher As System.Windows.Forms.Label
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents lblNumero As System.Windows.Forms.Label
        Friend WithEvents txtSerie As System.Windows.Forms.TextBox
        Friend WithEvents lblSerie As System.Windows.Forms.Label
        Friend WithEvents txtNombre As System.Windows.Forms.TextBox
        Friend WithEvents lblNombre As System.Windows.Forms.Label
    End Class

End Namespace