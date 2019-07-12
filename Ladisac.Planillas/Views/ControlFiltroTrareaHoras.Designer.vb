Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ControlFiltroTrareaHoras
        Inherits System.Windows.Forms.UserControl

        'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.listAlas = New System.Windows.Forms.ListBox()
            Me.chkAlas = New System.Windows.Forms.CheckBox()
            Me.listMesa = New System.Windows.Forms.ListBox()
            Me.chkMesa = New System.Windows.Forms.CheckBox()
            Me.listCanTidadLadrillo = New System.Windows.Forms.ListBox()
            Me.chkCanTidadLadrillo = New System.Windows.Forms.CheckBox()
            Me.listNumeroPersonas = New System.Windows.Forms.ListBox()
            Me.chkNumeroPersonas = New System.Windows.Forms.CheckBox()
            Me.listFactor = New System.Windows.Forms.ListBox()
            Me.chkFactor = New System.Windows.Forms.CheckBox()
            Me.listDescuentos = New System.Windows.Forms.ListBox()
            Me.chkDescuento = New System.Windows.Forms.CheckBox()
            Me.cboAreaFiltro = New System.Windows.Forms.ComboBox()
            Me.listBonificacion = New System.Windows.Forms.ListBox()
            Me.chkBonificacion = New System.Windows.Forms.CheckBox()
            Me.listRefrigerio = New System.Windows.Forms.ListBox()
            Me.chkRefrigerio = New System.Windows.Forms.CheckBox()
            Me.listTotal = New System.Windows.Forms.ListBox()
            Me.chkTotal = New System.Windows.Forms.CheckBox()
            Me.chkArea = New System.Windows.Forms.CheckBox()
            Me.btnAplicar = New System.Windows.Forms.Button()
            Me.listTarea = New System.Windows.Forms.ListBox()
            Me.chkTarea = New System.Windows.Forms.CheckBox()
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.chkCodigo = New System.Windows.Forms.CheckBox()
            Me.listFraccion = New System.Windows.Forms.ListBox()
            Me.chkFraccion = New System.Windows.Forms.CheckBox()
            Me.Panel4.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel4
            '
            Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Panel4.BackColor = System.Drawing.SystemColors.Control
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel4.Controls.Add(Me.listFraccion)
            Me.Panel4.Controls.Add(Me.chkFraccion)
            Me.Panel4.Controls.Add(Me.listAlas)
            Me.Panel4.Controls.Add(Me.chkAlas)
            Me.Panel4.Controls.Add(Me.listMesa)
            Me.Panel4.Controls.Add(Me.chkMesa)
            Me.Panel4.Controls.Add(Me.listCanTidadLadrillo)
            Me.Panel4.Controls.Add(Me.chkCanTidadLadrillo)
            Me.Panel4.Controls.Add(Me.listNumeroPersonas)
            Me.Panel4.Controls.Add(Me.chkNumeroPersonas)
            Me.Panel4.Controls.Add(Me.listFactor)
            Me.Panel4.Controls.Add(Me.chkFactor)
            Me.Panel4.Controls.Add(Me.listDescuentos)
            Me.Panel4.Controls.Add(Me.chkDescuento)
            Me.Panel4.Controls.Add(Me.cboAreaFiltro)
            Me.Panel4.Controls.Add(Me.listBonificacion)
            Me.Panel4.Controls.Add(Me.chkBonificacion)
            Me.Panel4.Controls.Add(Me.listRefrigerio)
            Me.Panel4.Controls.Add(Me.chkRefrigerio)
            Me.Panel4.Controls.Add(Me.listTotal)
            Me.Panel4.Controls.Add(Me.chkTotal)
            Me.Panel4.Controls.Add(Me.chkArea)
            Me.Panel4.Controls.Add(Me.btnAplicar)
            Me.Panel4.Controls.Add(Me.listTarea)
            Me.Panel4.Controls.Add(Me.chkTarea)
            Me.Panel4.Controls.Add(Me.txtCodigo)
            Me.Panel4.Controls.Add(Me.chkCodigo)
            Me.Panel4.Location = New System.Drawing.Point(1, 2)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(1231, 198)
            Me.Panel4.TabIndex = 124
            '
            'listAlas
            '
            Me.listAlas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.listAlas.FormattingEnabled = True
            Me.listAlas.Location = New System.Drawing.Point(782, 20)
            Me.listAlas.Name = "listAlas"
            Me.listAlas.Size = New System.Drawing.Size(59, 173)
            Me.listAlas.TabIndex = 26
            '
            'chkAlas
            '
            Me.chkAlas.AutoSize = True
            Me.chkAlas.Location = New System.Drawing.Point(782, 4)
            Me.chkAlas.Name = "chkAlas"
            Me.chkAlas.Size = New System.Drawing.Size(46, 17)
            Me.chkAlas.TabIndex = 25
            Me.chkAlas.Text = "Alas"
            Me.chkAlas.UseVisualStyleBackColor = True
            '
            'listMesa
            '
            Me.listMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.listMesa.FormattingEnabled = True
            Me.listMesa.Location = New System.Drawing.Point(719, 20)
            Me.listMesa.Name = "listMesa"
            Me.listMesa.Size = New System.Drawing.Size(61, 173)
            Me.listMesa.TabIndex = 24
            '
            'chkMesa
            '
            Me.chkMesa.AutoSize = True
            Me.chkMesa.Location = New System.Drawing.Point(719, 4)
            Me.chkMesa.Name = "chkMesa"
            Me.chkMesa.Size = New System.Drawing.Size(52, 17)
            Me.chkMesa.TabIndex = 23
            Me.chkMesa.Text = "Mesa"
            Me.chkMesa.UseVisualStyleBackColor = True
            '
            'listCanTidadLadrillo
            '
            Me.listCanTidadLadrillo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.listCanTidadLadrillo.FormattingEnabled = True
            Me.listCanTidadLadrillo.Location = New System.Drawing.Point(640, 20)
            Me.listCanTidadLadrillo.Name = "listCanTidadLadrillo"
            Me.listCanTidadLadrillo.Size = New System.Drawing.Size(77, 173)
            Me.listCanTidadLadrillo.TabIndex = 22
            '
            'chkCanTidadLadrillo
            '
            Me.chkCanTidadLadrillo.AutoSize = True
            Me.chkCanTidadLadrillo.Location = New System.Drawing.Point(640, 4)
            Me.chkCanTidadLadrillo.Name = "chkCanTidadLadrillo"
            Me.chkCanTidadLadrillo.Size = New System.Drawing.Size(84, 17)
            Me.chkCanTidadLadrillo.TabIndex = 21
            Me.chkCanTidadLadrillo.Text = "Can. Ladrillo"
            Me.chkCanTidadLadrillo.UseVisualStyleBackColor = True
            '
            'listNumeroPersonas
            '
            Me.listNumeroPersonas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.listNumeroPersonas.FormattingEnabled = True
            Me.listNumeroPersonas.Location = New System.Drawing.Point(553, 20)
            Me.listNumeroPersonas.Name = "listNumeroPersonas"
            Me.listNumeroPersonas.Size = New System.Drawing.Size(85, 173)
            Me.listNumeroPersonas.TabIndex = 20
            '
            'chkNumeroPersonas
            '
            Me.chkNumeroPersonas.AutoSize = True
            Me.chkNumeroPersonas.Location = New System.Drawing.Point(553, 4)
            Me.chkNumeroPersonas.Name = "chkNumeroPersonas"
            Me.chkNumeroPersonas.Size = New System.Drawing.Size(85, 17)
            Me.chkNumeroPersonas.TabIndex = 19
            Me.chkNumeroPersonas.Text = "Nº Personas"
            Me.chkNumeroPersonas.UseVisualStyleBackColor = True
            '
            'listFactor
            '
            Me.listFactor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.listFactor.FormattingEnabled = True
            Me.listFactor.Location = New System.Drawing.Point(485, 20)
            Me.listFactor.Name = "listFactor"
            Me.listFactor.Size = New System.Drawing.Size(66, 173)
            Me.listFactor.TabIndex = 18
            '
            'chkFactor
            '
            Me.chkFactor.AutoSize = True
            Me.chkFactor.Location = New System.Drawing.Point(485, 4)
            Me.chkFactor.Name = "chkFactor"
            Me.chkFactor.Size = New System.Drawing.Size(56, 17)
            Me.chkFactor.TabIndex = 17
            Me.chkFactor.Text = "Factor"
            Me.chkFactor.UseVisualStyleBackColor = True
            '
            'listDescuentos
            '
            Me.listDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.listDescuentos.FormattingEnabled = True
            Me.listDescuentos.Location = New System.Drawing.Point(1074, 20)
            Me.listDescuentos.Name = "listDescuentos"
            Me.listDescuentos.Size = New System.Drawing.Size(74, 173)
            Me.listDescuentos.TabIndex = 16
            '
            'chkDescuento
            '
            Me.chkDescuento.AutoSize = True
            Me.chkDescuento.Location = New System.Drawing.Point(1071, 4)
            Me.chkDescuento.Name = "chkDescuento"
            Me.chkDescuento.Size = New System.Drawing.Size(78, 17)
            Me.chkDescuento.TabIndex = 15
            Me.chkDescuento.Text = "Descuento"
            Me.chkDescuento.UseVisualStyleBackColor = True
            '
            'cboAreaFiltro
            '
            Me.cboAreaFiltro.FormattingEnabled = True
            Me.cboAreaFiltro.Location = New System.Drawing.Point(344, 28)
            Me.cboAreaFiltro.Name = "cboAreaFiltro"
            Me.cboAreaFiltro.Size = New System.Drawing.Size(133, 21)
            Me.cboAreaFiltro.TabIndex = 14
            '
            'listBonificacion
            '
            Me.listBonificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.listBonificacion.FormattingEnabled = True
            Me.listBonificacion.Location = New System.Drawing.Point(989, 20)
            Me.listBonificacion.Name = "listBonificacion"
            Me.listBonificacion.Size = New System.Drawing.Size(83, 173)
            Me.listBonificacion.TabIndex = 13
            '
            'chkBonificacion
            '
            Me.chkBonificacion.AutoSize = True
            Me.chkBonificacion.Location = New System.Drawing.Point(989, 4)
            Me.chkBonificacion.Name = "chkBonificacion"
            Me.chkBonificacion.Size = New System.Drawing.Size(84, 17)
            Me.chkBonificacion.TabIndex = 12
            Me.chkBonificacion.Text = "Bonificacion"
            Me.chkBonificacion.UseVisualStyleBackColor = True
            '
            'listRefrigerio
            '
            Me.listRefrigerio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.listRefrigerio.FormattingEnabled = True
            Me.listRefrigerio.Location = New System.Drawing.Point(918, 20)
            Me.listRefrigerio.Name = "listRefrigerio"
            Me.listRefrigerio.Size = New System.Drawing.Size(70, 173)
            Me.listRefrigerio.TabIndex = 11
            '
            'chkRefrigerio
            '
            Me.chkRefrigerio.AutoSize = True
            Me.chkRefrigerio.Location = New System.Drawing.Point(918, 4)
            Me.chkRefrigerio.Name = "chkRefrigerio"
            Me.chkRefrigerio.Size = New System.Drawing.Size(71, 17)
            Me.chkRefrigerio.TabIndex = 10
            Me.chkRefrigerio.Text = "Refrigerio"
            Me.chkRefrigerio.UseVisualStyleBackColor = True
            '
            'listTotal
            '
            Me.listTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.listTotal.FormattingEnabled = True
            Me.listTotal.Location = New System.Drawing.Point(1150, 20)
            Me.listTotal.Name = "listTotal"
            Me.listTotal.Size = New System.Drawing.Size(77, 173)
            Me.listTotal.TabIndex = 9
            '
            'chkTotal
            '
            Me.chkTotal.AutoSize = True
            Me.chkTotal.Location = New System.Drawing.Point(1149, 4)
            Me.chkTotal.Name = "chkTotal"
            Me.chkTotal.Size = New System.Drawing.Size(81, 17)
            Me.chkTotal.TabIndex = 8
            Me.chkTotal.Text = "Total Horas"
            Me.chkTotal.UseVisualStyleBackColor = True
            '
            'chkArea
            '
            Me.chkArea.AutoSize = True
            Me.chkArea.Location = New System.Drawing.Point(343, 4)
            Me.chkArea.Name = "chkArea"
            Me.chkArea.Size = New System.Drawing.Size(48, 17)
            Me.chkArea.TabIndex = 6
            Me.chkArea.Text = "Area"
            Me.chkArea.UseVisualStyleBackColor = True
            '
            'btnAplicar
            '
            Me.btnAplicar.Location = New System.Drawing.Point(20, 168)
            Me.btnAplicar.Name = "btnAplicar"
            Me.btnAplicar.Size = New System.Drawing.Size(75, 23)
            Me.btnAplicar.TabIndex = 4
            Me.btnAplicar.Text = "Aplicar"
            Me.btnAplicar.UseVisualStyleBackColor = True
            '
            'listTarea
            '
            Me.listTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.listTarea.FormattingEnabled = True
            Me.listTarea.Location = New System.Drawing.Point(136, 20)
            Me.listTarea.Name = "listTarea"
            Me.listTarea.Size = New System.Drawing.Size(201, 173)
            Me.listTarea.TabIndex = 3
            '
            'chkTarea
            '
            Me.chkTarea.AutoSize = True
            Me.chkTarea.Location = New System.Drawing.Point(136, 4)
            Me.chkTarea.Name = "chkTarea"
            Me.chkTarea.Size = New System.Drawing.Size(54, 17)
            Me.chkTarea.TabIndex = 2
            Me.chkTarea.Text = "Tarea"
            Me.chkTarea.UseVisualStyleBackColor = True
            '
            'txtCodigo
            '
            Me.txtCodigo.Location = New System.Drawing.Point(20, 20)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
            Me.txtCodigo.TabIndex = 1
            '
            'chkCodigo
            '
            Me.chkCodigo.AutoSize = True
            Me.chkCodigo.Location = New System.Drawing.Point(4, 4)
            Me.chkCodigo.Name = "chkCodigo"
            Me.chkCodigo.Size = New System.Drawing.Size(128, 17)
            Me.chkCodigo.TabIndex = 0
            Me.chkCodigo.Text = "Codigo de Trabajador"
            Me.chkCodigo.UseVisualStyleBackColor = True
            '
            'listFraccion
            '
            Me.listFraccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.listFraccion.FormattingEnabled = True
            Me.listFraccion.Location = New System.Drawing.Point(843, 20)
            Me.listFraccion.Name = "listFraccion"
            Me.listFraccion.Size = New System.Drawing.Size(59, 173)
            Me.listFraccion.TabIndex = 28
            '
            'chkFraccion
            '
            Me.chkFraccion.AutoSize = True
            Me.chkFraccion.Location = New System.Drawing.Point(843, 4)
            Me.chkFraccion.Name = "chkFraccion"
            Me.chkFraccion.Size = New System.Drawing.Size(67, 17)
            Me.chkFraccion.TabIndex = 27
            Me.chkFraccion.Text = "Fraccion"
            Me.chkFraccion.UseVisualStyleBackColor = True
            '
            'ControlFiltroTrareaHoras
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.Panel4)
            Me.Name = "ControlFiltroTrareaHoras"
            Me.Size = New System.Drawing.Size(1237, 205)
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents listAlas As System.Windows.Forms.ListBox
        Friend WithEvents chkAlas As System.Windows.Forms.CheckBox
        Friend WithEvents listMesa As System.Windows.Forms.ListBox
        Friend WithEvents chkMesa As System.Windows.Forms.CheckBox
        Friend WithEvents listCanTidadLadrillo As System.Windows.Forms.ListBox
        Friend WithEvents chkCanTidadLadrillo As System.Windows.Forms.CheckBox
        Friend WithEvents listNumeroPersonas As System.Windows.Forms.ListBox
        Friend WithEvents chkNumeroPersonas As System.Windows.Forms.CheckBox
        Friend WithEvents listFactor As System.Windows.Forms.ListBox
        Friend WithEvents chkFactor As System.Windows.Forms.CheckBox
        Friend WithEvents listDescuentos As System.Windows.Forms.ListBox
        Friend WithEvents chkDescuento As System.Windows.Forms.CheckBox
        Friend WithEvents cboAreaFiltro As System.Windows.Forms.ComboBox
        Friend WithEvents listBonificacion As System.Windows.Forms.ListBox
        Friend WithEvents chkBonificacion As System.Windows.Forms.CheckBox
        Friend WithEvents listRefrigerio As System.Windows.Forms.ListBox
        Friend WithEvents chkRefrigerio As System.Windows.Forms.CheckBox
        Friend WithEvents listTotal As System.Windows.Forms.ListBox
        Friend WithEvents chkTotal As System.Windows.Forms.CheckBox
        Friend WithEvents chkArea As System.Windows.Forms.CheckBox
        Friend WithEvents btnAplicar As System.Windows.Forms.Button
        Friend WithEvents listTarea As System.Windows.Forms.ListBox
        Friend WithEvents chkTarea As System.Windows.Forms.CheckBox
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents chkCodigo As System.Windows.Forms.CheckBox
        Friend WithEvents listFraccion As System.Windows.Forms.ListBox
        Friend WithEvents chkFraccion As System.Windows.Forms.CheckBox

    End Class

End Namespace