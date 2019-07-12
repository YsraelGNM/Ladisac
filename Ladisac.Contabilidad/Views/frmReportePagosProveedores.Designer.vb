Namespace Ladisac.Contabilidad.Views


    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmReportePagosProveedores
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
            Me.chkEncabezados = New System.Windows.Forms.CheckBox()
            Me.txtAbono = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtCargo = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnImprimir = New System.Windows.Forms.Button()
            Me.btnQuitar = New System.Windows.Forms.Button()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnObtenerDetracciones = New System.Windows.Forms.Button()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.txtPersona = New System.Windows.Forms.TextBox()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnBuscarpersona = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.rdbDetracciones = New System.Windows.Forms.RadioButton()
            Me.rdbPagos = New System.Windows.Forms.RadioButton()
            Me.btnPasar = New System.Windows.Forms.Button()
            Me.dgvImprime = New System.Windows.Forms.DataGridView()
            Me.dgvDocumenos = New System.Windows.Forms.DataGridView()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.dgvImprime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvDocumenos, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(701, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.chkEncabezados)
            Me.Panel1.Controls.Add(Me.txtAbono)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.txtCargo)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.btnImprimir)
            Me.Panel1.Controls.Add(Me.btnQuitar)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Controls.Add(Me.dgvImprime)
            Me.Panel1.Controls.Add(Me.dgvDocumenos)
            Me.Panel1.Location = New System.Drawing.Point(4, 31)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(692, 437)
            Me.Panel1.TabIndex = 1
            '
            'chkEncabezados
            '
            Me.chkEncabezados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.chkEncabezados.AutoSize = True
            Me.chkEncabezados.Location = New System.Drawing.Point(195, 414)
            Me.chkEncabezados.Name = "chkEncabezados"
            Me.chkEncabezados.Size = New System.Drawing.Size(91, 17)
            Me.chkEncabezados.TabIndex = 9
            Me.chkEncabezados.Text = "Encabezados"
            Me.chkEncabezados.UseVisualStyleBackColor = True
            '
            'txtAbono
            '
            Me.txtAbono.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtAbono.Location = New System.Drawing.Point(609, 410)
            Me.txtAbono.Name = "txtAbono"
            Me.txtAbono.Size = New System.Drawing.Size(72, 20)
            Me.txtAbono.TabIndex = 8
            '
            'Label4
            '
            Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(564, 413)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(38, 13)
            Me.Label4.TabIndex = 7
            Me.Label4.Text = "Abono"
            '
            'txtCargo
            '
            Me.txtCargo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtCargo.Location = New System.Drawing.Point(461, 407)
            Me.txtCargo.Name = "txtCargo"
            Me.txtCargo.Size = New System.Drawing.Size(72, 20)
            Me.txtCargo.TabIndex = 6
            '
            'Label3
            '
            Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(416, 410)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(35, 13)
            Me.Label3.TabIndex = 5
            Me.Label3.Text = "Cargo"
            '
            'btnImprimir
            '
            Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnImprimir.Location = New System.Drawing.Point(91, 410)
            Me.btnImprimir.Name = "btnImprimir"
            Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
            Me.btnImprimir.TabIndex = 4
            Me.btnImprimir.Text = " Imprimir"
            Me.btnImprimir.UseVisualStyleBackColor = True
            '
            'btnQuitar
            '
            Me.btnQuitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnQuitar.Location = New System.Drawing.Point(9, 409)
            Me.btnQuitar.Name = "btnQuitar"
            Me.btnQuitar.Size = New System.Drawing.Size(75, 23)
            Me.btnQuitar.TabIndex = 3
            Me.btnQuitar.Text = "Quitar"
            Me.btnQuitar.UseVisualStyleBackColor = True
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.btnObtenerDetracciones)
            Me.Panel2.Controls.Add(Me.Panel3)
            Me.Panel2.Controls.Add(Me.GroupBox1)
            Me.Panel2.Controls.Add(Me.btnPasar)
            Me.Panel2.Location = New System.Drawing.Point(9, 4)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(678, 71)
            Me.Panel2.TabIndex = 2
            '
            'btnObtenerDetracciones
            '
            Me.btnObtenerDetracciones.Enabled = False
            Me.btnObtenerDetracciones.Location = New System.Drawing.Point(286, 39)
            Me.btnObtenerDetracciones.Name = "btnObtenerDetracciones"
            Me.btnObtenerDetracciones.Size = New System.Drawing.Size(123, 23)
            Me.btnObtenerDetracciones.TabIndex = 7
            Me.btnObtenerDetracciones.Text = "Obtener Detracciones"
            Me.btnObtenerDetracciones.UseVisualStyleBackColor = True
            '
            'Panel3
            '
            Me.Panel3.Controls.Add(Me.txtPersona)
            Me.Panel3.Controls.Add(Me.txtNumero)
            Me.Panel3.Controls.Add(Me.Label1)
            Me.Panel3.Controls.Add(Me.Label2)
            Me.Panel3.Controls.Add(Me.btnBuscarpersona)
            Me.Panel3.Location = New System.Drawing.Point(3, 3)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(398, 57)
            Me.Panel3.TabIndex = 8
            '
            'txtPersona
            '
            Me.txtPersona.Location = New System.Drawing.Point(95, 6)
            Me.txtPersona.Name = "txtPersona"
            Me.txtPersona.ReadOnly = True
            Me.txtPersona.Size = New System.Drawing.Size(251, 20)
            Me.txtPersona.TabIndex = 2
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(95, 29)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.Size = New System.Drawing.Size(69, 20)
            Me.txtNumero.TabIndex = 6
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(34, 9)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(56, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Proveedor"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(11, 33)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 13)
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "Buscar Numero"
            '
            'btnBuscarpersona
            '
            Me.btnBuscarpersona.Location = New System.Drawing.Point(350, 4)
            Me.btnBuscarpersona.Name = "btnBuscarpersona"
            Me.btnBuscarpersona.Size = New System.Drawing.Size(27, 23)
            Me.btnBuscarpersona.TabIndex = 1
            Me.btnBuscarpersona.Text = ":::"
            Me.btnBuscarpersona.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.rdbDetracciones)
            Me.GroupBox1.Controls.Add(Me.rdbPagos)
            Me.GroupBox1.Location = New System.Drawing.Point(429, 0)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(140, 63)
            Me.GroupBox1.TabIndex = 7
            Me.GroupBox1.TabStop = False
            '
            'rdbDetracciones
            '
            Me.rdbDetracciones.AutoSize = True
            Me.rdbDetracciones.Location = New System.Drawing.Point(7, 33)
            Me.rdbDetracciones.Name = "rdbDetracciones"
            Me.rdbDetracciones.Size = New System.Drawing.Size(130, 17)
            Me.rdbDetracciones.TabIndex = 1
            Me.rdbDetracciones.Text = "Registro Detracciones"
            Me.rdbDetracciones.UseVisualStyleBackColor = True
            '
            'rdbPagos
            '
            Me.rdbPagos.AutoSize = True
            Me.rdbPagos.Checked = True
            Me.rdbPagos.Location = New System.Drawing.Point(7, 10)
            Me.rdbPagos.Name = "rdbPagos"
            Me.rdbPagos.Size = New System.Drawing.Size(111, 17)
            Me.rdbPagos.TabIndex = 0
            Me.rdbPagos.TabStop = True
            Me.rdbPagos.Text = "Registro de pagos"
            Me.rdbPagos.UseVisualStyleBackColor = True
            '
            'btnPasar
            '
            Me.btnPasar.Location = New System.Drawing.Point(587, 40)
            Me.btnPasar.Name = "btnPasar"
            Me.btnPasar.Size = New System.Drawing.Size(75, 23)
            Me.btnPasar.TabIndex = 3
            Me.btnPasar.Text = "Pasar =>"
            Me.btnPasar.UseVisualStyleBackColor = True
            '
            'dgvImprime
            '
            Me.dgvImprime.AllowUserToAddRows = False
            Me.dgvImprime.AllowUserToDeleteRows = False
            Me.dgvImprime.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvImprime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvImprime.Location = New System.Drawing.Point(8, 238)
            Me.dgvImprime.Name = "dgvImprime"
            Me.dgvImprime.Size = New System.Drawing.Size(677, 165)
            Me.dgvImprime.TabIndex = 1
            '
            'dgvDocumenos
            '
            Me.dgvDocumenos.AllowUserToAddRows = False
            Me.dgvDocumenos.AllowUserToDeleteRows = False
            Me.dgvDocumenos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDocumenos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDocumenos.Location = New System.Drawing.Point(9, 81)
            Me.dgvDocumenos.Name = "dgvDocumenos"
            Me.dgvDocumenos.ReadOnly = True
            Me.dgvDocumenos.Size = New System.Drawing.Size(677, 151)
            Me.dgvDocumenos.TabIndex = 0
            '
            'frmReportePagosProveedores
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(701, 476)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmReportePagosProveedores"
            Me.Text = "frmReportePagosProveedores"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            CType(Me.dgvImprime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvDocumenos, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dgvImprime As System.Windows.Forms.DataGridView
        Friend WithEvents dgvDocumenos As System.Windows.Forms.DataGridView
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents txtPersona As System.Windows.Forms.TextBox
        Friend WithEvents btnBuscarpersona As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnPasar As System.Windows.Forms.Button
        Friend WithEvents btnQuitar As System.Windows.Forms.Button
        Friend WithEvents btnImprimir As System.Windows.Forms.Button
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtAbono As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtCargo As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents chkEncabezados As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents rdbDetracciones As System.Windows.Forms.RadioButton
        Friend WithEvents rdbPagos As System.Windows.Forms.RadioButton
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents btnObtenerDetracciones As System.Windows.Forms.Button
    End Class


End Namespace
