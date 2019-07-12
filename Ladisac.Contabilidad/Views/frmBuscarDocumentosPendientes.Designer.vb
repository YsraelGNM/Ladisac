Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmBuscarDocumentosPendientes
        Inherits Foundation.Views.ViewMaster

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
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnEnviar = New System.Windows.Forms.Button()
            Me.txtTipoDocumento = New System.Windows.Forms.TextBox()
            Me.btnBuscar = New System.Windows.Forms.Button()
            Me.txtPersona = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.txtSerie = New System.Windows.Forms.TextBox()
            Me.btnDocumento = New System.Windows.Forms.Button()
            Me.txtDocumento = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(741, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 33)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(733, 296)
            Me.Panel1.TabIndex = 2
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Location = New System.Drawing.Point(4, 64)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.ReadOnly = True
            Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvDetalle.Size = New System.Drawing.Size(725, 227)
            Me.dgvDetalle.TabIndex = 1
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.Controls.Add(Me.btnEnviar)
            Me.Panel2.Controls.Add(Me.txtTipoDocumento)
            Me.Panel2.Controls.Add(Me.btnBuscar)
            Me.Panel2.Controls.Add(Me.txtPersona)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.txtNumero)
            Me.Panel2.Controls.Add(Me.txtSerie)
            Me.Panel2.Controls.Add(Me.btnDocumento)
            Me.Panel2.Controls.Add(Me.txtDocumento)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Location = New System.Drawing.Point(4, 5)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(725, 56)
            Me.Panel2.TabIndex = 0
            '
            'btnEnviar
            '
            Me.btnEnviar.Location = New System.Drawing.Point(460, 29)
            Me.btnEnviar.Name = "btnEnviar"
            Me.btnEnviar.Size = New System.Drawing.Size(75, 23)
            Me.btnEnviar.TabIndex = 14
            Me.btnEnviar.Text = "Enviar"
            Me.btnEnviar.UseVisualStyleBackColor = True
            '
            'txtTipoDocumento
            '
            Me.txtTipoDocumento.Location = New System.Drawing.Point(400, 9)
            Me.txtTipoDocumento.Name = "txtTipoDocumento"
            Me.txtTipoDocumento.Size = New System.Drawing.Size(15, 20)
            Me.txtTipoDocumento.TabIndex = 13
            Me.txtTipoDocumento.Visible = False
            '
            'btnBuscar
            '
            Me.btnBuscar.Location = New System.Drawing.Point(460, 6)
            Me.btnBuscar.Name = "btnBuscar"
            Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
            Me.btnBuscar.TabIndex = 12
            Me.btnBuscar.Text = "Buscar"
            Me.btnBuscar.UseVisualStyleBackColor = True
            '
            'txtPersona
            '
            Me.txtPersona.Location = New System.Drawing.Point(74, 31)
            Me.txtPersona.Name = "txtPersona"
            Me.txtPersona.Size = New System.Drawing.Size(323, 20)
            Me.txtPersona.TabIndex = 10
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(22, 34)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(46, 13)
            Me.Label4.TabIndex = 9
            Me.Label4.Text = "Persona"
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(297, 9)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.Size = New System.Drawing.Size(100, 20)
            Me.txtNumero.TabIndex = 8
            '
            'txtSerie
            '
            Me.txtSerie.Location = New System.Drawing.Point(242, 9)
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.Size = New System.Drawing.Size(51, 20)
            Me.txtSerie.TabIndex = 7
            '
            'btnDocumento
            '
            Me.btnDocumento.Location = New System.Drawing.Point(208, 6)
            Me.btnDocumento.Name = "btnDocumento"
            Me.btnDocumento.Size = New System.Drawing.Size(30, 23)
            Me.btnDocumento.TabIndex = 6
            Me.btnDocumento.Text = ":::"
            Me.btnDocumento.UseVisualStyleBackColor = True
            '
            'txtDocumento
            '
            Me.txtDocumento.Location = New System.Drawing.Point(74, 9)
            Me.txtDocumento.Name = "txtDocumento"
            Me.txtDocumento.ReadOnly = True
            Me.txtDocumento.Size = New System.Drawing.Size(130, 20)
            Me.txtDocumento.TabIndex = 5
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(6, 12)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(62, 13)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Documento"
            '
            'frmBuscarDocumentosPendientes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(741, 330)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmBuscarDocumentosPendientes"
            Me.Text = "frmBuscarDocumentosPendientes"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents btnEnviar As System.Windows.Forms.Button
        Friend WithEvents txtTipoDocumento As System.Windows.Forms.TextBox
        Friend WithEvents btnBuscar As System.Windows.Forms.Button
        Friend WithEvents txtPersona As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents txtSerie As System.Windows.Forms.TextBox
        Friend WithEvents btnDocumento As System.Windows.Forms.Button
        Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
    End Class

End Namespace