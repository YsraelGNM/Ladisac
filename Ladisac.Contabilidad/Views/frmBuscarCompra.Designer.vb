Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmBuscarCompra
        Inherits Ladisac.Foundation.Views.ViewMaster

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
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.txtpersona = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnBuscarPeriodo = New System.Windows.Forms.Button()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnBuscar = New System.Windows.Forms.Button()
            Me.txtVoucher = New System.Windows.Forms.TextBox()
            Me.cboLIbro = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.dgbRegistro = New System.Windows.Forms.DataGridView()
            Me.Panel1.SuspendLayout()
            CType(Me.dgbRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(661, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.txtNumero)
            Me.Panel1.Controls.Add(Me.txtSerie)
            Me.Panel1.Controls.Add(Me.txtpersona)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.btnBuscarPeriodo)
            Me.Panel1.Controls.Add(Me.txtPeriodo)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.btnBuscar)
            Me.Panel1.Controls.Add(Me.txtVoucher)
            Me.Panel1.Controls.Add(Me.cboLIbro)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(4, 33)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(652, 98)
            Me.Panel1.TabIndex = 6
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(8, 80)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(73, 13)
            Me.Label4.TabIndex = 16
            Me.Label4.Text = "Serie/Numero"
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(180, 74)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.Size = New System.Drawing.Size(100, 20)
            Me.txtNumero.TabIndex = 15
            '
            'txtSerie
            '
            Me.txtSerie.Location = New System.Drawing.Point(112, 74)
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.Size = New System.Drawing.Size(62, 20)
            Me.txtSerie.TabIndex = 14
            '
            'txtpersona
            '
            Me.txtpersona.Location = New System.Drawing.Point(112, 52)
            Me.txtpersona.Name = "txtpersona"
            Me.txtpersona.Size = New System.Drawing.Size(342, 20)
            Me.txtpersona.TabIndex = 13
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(35, 56)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(46, 13)
            Me.Label3.TabIndex = 12
            Me.Label3.Text = "Persona"
            '
            'btnBuscarPeriodo
            '
            Me.btnBuscarPeriodo.Location = New System.Drawing.Point(218, 5)
            Me.btnBuscarPeriodo.Name = "btnBuscarPeriodo"
            Me.btnBuscarPeriodo.Size = New System.Drawing.Size(27, 23)
            Me.btnBuscarPeriodo.TabIndex = 11
            Me.btnBuscarPeriodo.Text = ":::"
            Me.btnBuscarPeriodo.UseVisualStyleBackColor = True
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(112, 7)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(100, 20)
            Me.txtPeriodo.TabIndex = 10
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(38, 10)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(43, 13)
            Me.Label2.TabIndex = 9
            Me.Label2.Text = "Periodo"
            '
            'btnBuscar
            '
            Me.btnBuscar.Location = New System.Drawing.Point(494, 70)
            Me.btnBuscar.Name = "btnBuscar"
            Me.btnBuscar.Size = New System.Drawing.Size(67, 23)
            Me.btnBuscar.TabIndex = 8
            Me.btnBuscar.Text = "Buscar"
            Me.btnBuscar.UseVisualStyleBackColor = True
            '
            'txtVoucher
            '
            Me.txtVoucher.Location = New System.Drawing.Point(301, 30)
            Me.txtVoucher.Name = "txtVoucher"
            Me.txtVoucher.Size = New System.Drawing.Size(153, 20)
            Me.txtVoucher.TabIndex = 7
            '
            'cboLIbro
            '
            Me.cboLIbro.FormattingEnabled = True
            Me.cboLIbro.Location = New System.Drawing.Point(112, 29)
            Me.cboLIbro.Name = "cboLIbro"
            Me.cboLIbro.Size = New System.Drawing.Size(182, 21)
            Me.cboLIbro.TabIndex = 6
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(37, 35)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(44, 13)
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "Numero"
            '
            'dgbRegistro
            '
            Me.dgbRegistro.AllowUserToAddRows = False
            Me.dgbRegistro.AllowUserToDeleteRows = False
            Me.dgbRegistro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgbRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgbRegistro.Location = New System.Drawing.Point(4, 133)
            Me.dgbRegistro.MultiSelect = False
            Me.dgbRegistro.Name = "dgbRegistro"
            Me.dgbRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgbRegistro.Size = New System.Drawing.Size(652, 271)
            Me.dgbRegistro.TabIndex = 5
            '
            'frmBuscarCompra
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(661, 407)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.dgbRegistro)
            Me.Name = "frmBuscarCompra"
            Me.Text = "Buscar"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.dgbRegistro, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.dgbRegistro, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnBuscarPeriodo As System.Windows.Forms.Button
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnBuscar As System.Windows.Forms.Button
        Friend WithEvents txtVoucher As System.Windows.Forms.TextBox
        Friend WithEvents cboLIbro As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Public WithEvents dgbRegistro As System.Windows.Forms.DataGridView
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents txtSerie As System.Windows.Forms.TextBox
        Friend WithEvents txtpersona As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
    End Class
End Namespace
