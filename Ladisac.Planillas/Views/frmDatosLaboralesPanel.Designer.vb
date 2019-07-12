Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDatosLaboralesPanel
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
            Me.Label2 = New System.Windows.Forms.Label()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.cboAreaTrabajo = New System.Windows.Forms.ComboBox()
            Me.chkAreaTrabajo = New System.Windows.Forms.CheckBox()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.btnActualizar = New System.Windows.Forms.Button()
            Me.dateFechaDesde = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dateFechaHasta = New System.Windows.Forms.DateTimePicker()
            Me.btnExportarExcel = New System.Windows.Forms.Button()
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.cboActivarSituacion = New System.Windows.Forms.ComboBox()
            Me.cboActivarTipo = New System.Windows.Forms.ComboBox()
            Me.chkActivarSituacion = New System.Windows.Forms.CheckBox()
            Me.chkActivarTipo = New System.Windows.Forms.CheckBox()
            Me.Panel1.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.Panel4.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(800, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(2, 31)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(795, 316)
            Me.Panel1.TabIndex = 1
            '
            'Label2
            '
            Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(6, 298)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(361, 13)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Hacer doble Click en la cabecera de la fila para administrar datos laborales "
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Location = New System.Drawing.Point(4, 62)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.ReadOnly = True
            Me.dgvDetalle.Size = New System.Drawing.Size(788, 232)
            Me.dgvDetalle.TabIndex = 1
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.Controls.Add(Me.cboAreaTrabajo)
            Me.Panel2.Controls.Add(Me.chkAreaTrabajo)
            Me.Panel2.Controls.Add(Me.Panel4)
            Me.Panel2.Controls.Add(Me.btnExportarExcel)
            Me.Panel2.Controls.Add(Me.txtCodigo)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Controls.Add(Me.Panel3)
            Me.Panel2.Location = New System.Drawing.Point(4, 4)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(788, 56)
            Me.Panel2.TabIndex = 0
            '
            'cboAreaTrabajo
            '
            Me.cboAreaTrabajo.Enabled = False
            Me.cboAreaTrabajo.FormattingEnabled = True
            Me.cboAreaTrabajo.Location = New System.Drawing.Point(369, 31)
            Me.cboAreaTrabajo.Name = "cboAreaTrabajo"
            Me.cboAreaTrabajo.Size = New System.Drawing.Size(205, 21)
            Me.cboAreaTrabajo.TabIndex = 5
            '
            'chkAreaTrabajo
            '
            Me.chkAreaTrabajo.AutoSize = True
            Me.chkAreaTrabajo.Location = New System.Drawing.Point(303, 33)
            Me.chkAreaTrabajo.Name = "chkAreaTrabajo"
            Me.chkAreaTrabajo.Size = New System.Drawing.Size(59, 17)
            Me.chkAreaTrabajo.TabIndex = 4
            Me.chkAreaTrabajo.Text = "Activar"
            Me.chkAreaTrabajo.UseVisualStyleBackColor = True
            '
            'Panel4
            '
            Me.Panel4.Controls.Add(Me.btnActualizar)
            Me.Panel4.Controls.Add(Me.dateFechaDesde)
            Me.Panel4.Controls.Add(Me.Label4)
            Me.Panel4.Controls.Add(Me.Label3)
            Me.Panel4.Controls.Add(Me.dateFechaHasta)
            Me.Panel4.Location = New System.Drawing.Point(303, 4)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(479, 27)
            Me.Panel4.TabIndex = 4
            Me.Panel4.Visible = False
            '
            'btnActualizar
            '
            Me.btnActualizar.Location = New System.Drawing.Point(375, 2)
            Me.btnActualizar.Name = "btnActualizar"
            Me.btnActualizar.Size = New System.Drawing.Size(63, 23)
            Me.btnActualizar.TabIndex = 4
            Me.btnActualizar.Text = "Actualizar"
            Me.btnActualizar.UseVisualStyleBackColor = True
            '
            'dateFechaDesde
            '
            Me.dateFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFechaDesde.Location = New System.Drawing.Point(141, 3)
            Me.dateFechaDesde.Name = "dateFechaDesde"
            Me.dateFechaDesde.Size = New System.Drawing.Size(91, 20)
            Me.dateFechaDesde.TabIndex = 3
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(236, 5)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(35, 13)
            Me.Label4.TabIndex = 2
            Me.Label4.Text = "Hasta"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(7, 6)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(128, 13)
            Me.Label3.TabIndex = 1
            Me.Label3.Text = "Fecha -Horas Produccion"
            '
            'dateFechaHasta
            '
            Me.dateFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFechaHasta.Location = New System.Drawing.Point(277, 3)
            Me.dateFechaHasta.Name = "dateFechaHasta"
            Me.dateFechaHasta.Size = New System.Drawing.Size(91, 20)
            Me.dateFechaHasta.TabIndex = 0
            '
            'btnExportarExcel
            '
            Me.btnExportarExcel.Location = New System.Drawing.Point(695, 32)
            Me.btnExportarExcel.Name = "btnExportarExcel"
            Me.btnExportarExcel.Size = New System.Drawing.Size(85, 23)
            Me.btnExportarExcel.TabIndex = 3
            Me.btnExportarExcel.Text = "Exportar Excel"
            Me.btnExportarExcel.UseVisualStyleBackColor = True
            '
            'txtCodigo
            '
            Me.txtCodigo.Location = New System.Drawing.Point(633, 33)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Size = New System.Drawing.Size(56, 20)
            Me.txtCodigo.TabIndex = 2
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(586, 34)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(40, 13)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Codigo"
            '
            'Panel3
            '
            Me.Panel3.Controls.Add(Me.cboActivarSituacion)
            Me.Panel3.Controls.Add(Me.cboActivarTipo)
            Me.Panel3.Controls.Add(Me.chkActivarSituacion)
            Me.Panel3.Controls.Add(Me.chkActivarTipo)
            Me.Panel3.Location = New System.Drawing.Point(7, 4)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(289, 48)
            Me.Panel3.TabIndex = 0
            '
            'cboActivarSituacion
            '
            Me.cboActivarSituacion.Enabled = False
            Me.cboActivarSituacion.FormattingEnabled = True
            Me.cboActivarSituacion.Location = New System.Drawing.Point(79, 25)
            Me.cboActivarSituacion.Name = "cboActivarSituacion"
            Me.cboActivarSituacion.Size = New System.Drawing.Size(205, 21)
            Me.cboActivarSituacion.TabIndex = 3
            '
            'cboActivarTipo
            '
            Me.cboActivarTipo.Enabled = False
            Me.cboActivarTipo.FormattingEnabled = True
            Me.cboActivarTipo.Location = New System.Drawing.Point(79, 3)
            Me.cboActivarTipo.Name = "cboActivarTipo"
            Me.cboActivarTipo.Size = New System.Drawing.Size(205, 21)
            Me.cboActivarTipo.TabIndex = 2
            '
            'chkActivarSituacion
            '
            Me.chkActivarSituacion.AutoSize = True
            Me.chkActivarSituacion.Location = New System.Drawing.Point(13, 27)
            Me.chkActivarSituacion.Name = "chkActivarSituacion"
            Me.chkActivarSituacion.Size = New System.Drawing.Size(59, 17)
            Me.chkActivarSituacion.TabIndex = 1
            Me.chkActivarSituacion.Text = "Activar"
            Me.chkActivarSituacion.UseVisualStyleBackColor = True
            '
            'chkActivarTipo
            '
            Me.chkActivarTipo.AutoSize = True
            Me.chkActivarTipo.Location = New System.Drawing.Point(13, 5)
            Me.chkActivarTipo.Name = "chkActivarTipo"
            Me.chkActivarTipo.Size = New System.Drawing.Size(59, 17)
            Me.chkActivarTipo.TabIndex = 0
            Me.chkActivarTipo.Text = "Activar"
            Me.chkActivarTipo.UseVisualStyleBackColor = True
            '
            'frmDatosLaboralesPanel
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(800, 351)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmDatosLaboralesPanel"
            Me.Text = "frmDatosLaboralesPanel"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cboActivarSituacion As System.Windows.Forms.ComboBox
        Friend WithEvents cboActivarTipo As System.Windows.Forms.ComboBox
        Friend WithEvents chkActivarSituacion As System.Windows.Forms.CheckBox
        Friend WithEvents chkActivarTipo As System.Windows.Forms.CheckBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents dateFechaHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateFechaDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnActualizar As System.Windows.Forms.Button
        Friend WithEvents cboAreaTrabajo As System.Windows.Forms.ComboBox
        Friend WithEvents chkAreaTrabajo As System.Windows.Forms.CheckBox
    End Class

End Namespace