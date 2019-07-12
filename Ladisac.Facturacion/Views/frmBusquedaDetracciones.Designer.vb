Namespace Ladisac
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmBusquedaDetracciones
        'Inherits System.Windows.Forms.Form
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.tsSubBarra = New System.Windows.Forms.ToolStrip()
            Me.tsbOkBusqueda = New System.Windows.Forms.ToolStripButton()
            Me.tss1 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbInicio = New System.Windows.Forms.ToolStripButton()
            Me.tsbAnterior = New System.Windows.Forms.ToolStripButton()
            Me.tsbSiguiente = New System.Windows.Forms.ToolStripButton()
            Me.tsbFinal = New System.Windows.Forms.ToolStripButton()
            Me.tss2 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.cboDetalleTipoDocumento = New System.Windows.Forms.ComboBox()
            Me.btnExportarExcel = New System.Windows.Forms.Button()
            Me.lblTotal = New System.Windows.Forms.Label()
            Me.txtTotal = New System.Windows.Forms.TextBox()
            Me.txtBuscarSerie = New System.Windows.Forms.TextBox()
            Me.lblBuscar = New System.Windows.Forms.Label()
            Me.cboBuscar = New System.Windows.Forms.ComboBox()
            Me.txtBuscar = New System.Windows.Forms.TextBox()
            Me.cboDatoBuscar = New System.Windows.Forms.ComboBox()
            Me.chkTipoBusqueda = New System.Windows.Forms.CheckBox()
            Me.chkBusquedaTiempoReal = New System.Windows.Forms.CheckBox()
            Me.btnRefrescar = New System.Windows.Forms.Button()
            Me.btnBuscar = New System.Windows.Forms.Button()
            Me.dgvDatos = New System.Windows.Forms.DataGridView()
            Me.tsSubBarra.SuspendLayout()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTitle.Dock = System.Windows.Forms.DockStyle.None
            Me.lblTitle.Size = New System.Drawing.Size(688, 28)
            Me.lblTitle.Text = "Búsqueda"
            '
            'tsSubBarra
            '
            Me.tsSubBarra.BackColor = System.Drawing.SystemColors.Control
            Me.tsSubBarra.Dock = System.Windows.Forms.DockStyle.None
            Me.tsSubBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbOkBusqueda, Me.tss1, Me.tsbInicio, Me.tsbAnterior, Me.tsbSiguiente, Me.tsbFinal, Me.tss2, Me.tsbSalir})
            Me.tsSubBarra.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
            Me.tsSubBarra.Location = New System.Drawing.Point(1, 28)
            Me.tsSubBarra.Name = "tsSubBarra"
            Me.tsSubBarra.Size = New System.Drawing.Size(162, 25)
            Me.tsSubBarra.TabIndex = 2
            Me.tsSubBarra.Text = "Búsqueda de datos"
            '
            'tsbOkBusqueda
            '
            Me.tsbOkBusqueda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbOkBusqueda.Image = Global.My.Resources.Resource1.OkBusqueda
            Me.tsbOkBusqueda.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbOkBusqueda.Name = "tsbOkBusqueda"
            Me.tsbOkBusqueda.Size = New System.Drawing.Size(23, 22)
            Me.tsbOkBusqueda.Text = "DevolverDatos"
            Me.tsbOkBusqueda.ToolTipText = "Aceptar registro buscado, Ctrl + D"
            '
            'tss1
            '
            Me.tss1.Name = "tss1"
            Me.tss1.Size = New System.Drawing.Size(6, 25)
            '
            'tsbInicio
            '
            Me.tsbInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbInicio.Image = Global.My.Resources.Resource1.Inicio
            Me.tsbInicio.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbInicio.Name = "tsbInicio"
            Me.tsbInicio.Size = New System.Drawing.Size(23, 22)
            Me.tsbInicio.Text = "PrimerRegistro"
            Me.tsbInicio.ToolTipText = "Primer registro, Alt + Q"
            '
            'tsbAnterior
            '
            Me.tsbAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbAnterior.Image = Global.My.Resources.Resource1.Anterior
            Me.tsbAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbAnterior.Name = "tsbAnterior"
            Me.tsbAnterior.Size = New System.Drawing.Size(23, 22)
            Me.tsbAnterior.Text = "RegistroAnterior"
            Me.tsbAnterior.ToolTipText = "Registro anterior, Alt + A"
            '
            'tsbSiguiente
            '
            Me.tsbSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbSiguiente.ForeColor = System.Drawing.SystemColors.ControlText
            Me.tsbSiguiente.Image = Global.My.Resources.Resource1.Siguiente
            Me.tsbSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbSiguiente.Name = "tsbSiguiente"
            Me.tsbSiguiente.Size = New System.Drawing.Size(23, 22)
            Me.tsbSiguiente.Text = "RegistroSiguiente"
            Me.tsbSiguiente.ToolTipText = "Registro siguiente, Alt + S"
            '
            'tsbFinal
            '
            Me.tsbFinal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbFinal.Image = Global.My.Resources.Resource1.Final
            Me.tsbFinal.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbFinal.Name = "tsbFinal"
            Me.tsbFinal.Size = New System.Drawing.Size(23, 22)
            Me.tsbFinal.Text = "UltimoRegistro"
            Me.tsbFinal.ToolTipText = "Último registro, Alt + W"
            '
            'tss2
            '
            Me.tss2.Name = "tss2"
            Me.tss2.Size = New System.Drawing.Size(6, 25)
            '
            'tsbSalir
            '
            Me.tsbSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbSalir.Image = Global.My.Resources.Resource1.Salir
            Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbSalir.Name = "tsbSalir"
            Me.tsbSalir.Size = New System.Drawing.Size(23, 22)
            Me.tsbSalir.Text = "Salir"
            Me.tsbSalir.ToolTipText = "Salir del formulario, Ctrl + S"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.cboDetalleTipoDocumento)
            Me.pnCuerpo.Controls.Add(Me.btnExportarExcel)
            Me.pnCuerpo.Controls.Add(Me.lblTotal)
            Me.pnCuerpo.Controls.Add(Me.txtTotal)
            Me.pnCuerpo.Controls.Add(Me.txtBuscarSerie)
            Me.pnCuerpo.Controls.Add(Me.lblBuscar)
            Me.pnCuerpo.Controls.Add(Me.cboBuscar)
            Me.pnCuerpo.Controls.Add(Me.txtBuscar)
            Me.pnCuerpo.Controls.Add(Me.cboDatoBuscar)
            Me.pnCuerpo.Controls.Add(Me.chkTipoBusqueda)
            Me.pnCuerpo.Controls.Add(Me.chkBusquedaTiempoReal)
            Me.pnCuerpo.Controls.Add(Me.btnRefrescar)
            Me.pnCuerpo.Controls.Add(Me.btnBuscar)
            Me.pnCuerpo.Controls.Add(Me.dgvDatos)
            Me.pnCuerpo.Location = New System.Drawing.Point(5, 56)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(679, 349)
            Me.pnCuerpo.TabIndex = 9
            '
            'cboDetalleTipoDocumento
            '
            Me.cboDetalleTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboDetalleTipoDocumento.FormattingEnabled = True
            Me.cboDetalleTipoDocumento.Location = New System.Drawing.Point(476, 6)
            Me.cboDetalleTipoDocumento.Name = "cboDetalleTipoDocumento"
            Me.cboDetalleTipoDocumento.Size = New System.Drawing.Size(190, 21)
            Me.cboDetalleTipoDocumento.TabIndex = 13
            Me.cboDetalleTipoDocumento.Visible = False
            '
            'btnExportarExcel
            '
            Me.btnExportarExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnExportarExcel.Location = New System.Drawing.Point(405, 28)
            Me.btnExportarExcel.Name = "btnExportarExcel"
            Me.btnExportarExcel.Size = New System.Drawing.Size(101, 23)
            Me.btnExportarExcel.TabIndex = 12
            Me.btnExportarExcel.Text = "Exportar Excel"
            Me.btnExportarExcel.UseVisualStyleBackColor = True
            '
            'lblTotal
            '
            Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTotal.AutoSize = True
            Me.lblTotal.Location = New System.Drawing.Point(528, 318)
            Me.lblTotal.Name = "lblTotal"
            Me.lblTotal.Size = New System.Drawing.Size(34, 13)
            Me.lblTotal.TabIndex = 11
            Me.lblTotal.Text = "Total:"
            '
            'txtTotal
            '
            Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtTotal.Enabled = False
            Me.txtTotal.Location = New System.Drawing.Point(568, 318)
            Me.txtTotal.MaxLength = 3
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.Size = New System.Drawing.Size(98, 20)
            Me.txtTotal.TabIndex = 10
            '
            'txtBuscarSerie
            '
            Me.txtBuscarSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtBuscarSerie.Location = New System.Drawing.Point(626, 6)
            Me.txtBuscarSerie.MaxLength = 3
            Me.txtBuscarSerie.Name = "txtBuscarSerie"
            Me.txtBuscarSerie.Size = New System.Drawing.Size(40, 20)
            Me.txtBuscarSerie.TabIndex = 3
            '
            'lblBuscar
            '
            Me.lblBuscar.AutoSize = True
            Me.lblBuscar.Location = New System.Drawing.Point(7, 6)
            Me.lblBuscar.Name = "lblBuscar"
            Me.lblBuscar.Size = New System.Drawing.Size(40, 13)
            Me.lblBuscar.TabIndex = 2
            Me.lblBuscar.Text = "Buscar"
            '
            'cboBuscar
            '
            Me.cboBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboBuscar.FormattingEnabled = True
            Me.cboBuscar.Location = New System.Drawing.Point(53, 6)
            Me.cboBuscar.Name = "cboBuscar"
            Me.cboBuscar.Size = New System.Drawing.Size(150, 21)
            Me.cboBuscar.TabIndex = 1
            '
            'txtBuscar
            '
            Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtBuscar.Location = New System.Drawing.Point(209, 6)
            Me.txtBuscar.Name = "txtBuscar"
            Me.txtBuscar.Size = New System.Drawing.Size(457, 20)
            Me.txtBuscar.TabIndex = 0
            '
            'cboDatoBuscar
            '
            Me.cboDatoBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboDatoBuscar.FormattingEnabled = True
            Me.cboDatoBuscar.Location = New System.Drawing.Point(209, 6)
            Me.cboDatoBuscar.Name = "cboDatoBuscar"
            Me.cboDatoBuscar.Size = New System.Drawing.Size(457, 21)
            Me.cboDatoBuscar.TabIndex = 2
            '
            'chkTipoBusqueda
            '
            Me.chkTipoBusqueda.AutoSize = True
            Me.chkTipoBusqueda.Location = New System.Drawing.Point(7, 28)
            Me.chkTipoBusqueda.Name = "chkTipoBusqueda"
            Me.chkTipoBusqueda.Size = New System.Drawing.Size(127, 17)
            Me.chkTipoBusqueda.TabIndex = 5
            Me.chkTipoBusqueda.Text = "En cualquier posición"
            Me.chkTipoBusqueda.UseVisualStyleBackColor = True
            '
            'chkBusquedaTiempoReal
            '
            Me.chkBusquedaTiempoReal.AutoSize = True
            Me.chkBusquedaTiempoReal.Location = New System.Drawing.Point(209, 28)
            Me.chkBusquedaTiempoReal.Name = "chkBusquedaTiempoReal"
            Me.chkBusquedaTiempoReal.Size = New System.Drawing.Size(74, 17)
            Me.chkBusquedaTiempoReal.TabIndex = 6
            Me.chkBusquedaTiempoReal.Text = "A solicitud"
            Me.chkBusquedaTiempoReal.UseVisualStyleBackColor = True
            '
            'btnRefrescar
            '
            Me.btnRefrescar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnRefrescar.Enabled = False
            Me.btnRefrescar.Location = New System.Drawing.Point(512, 28)
            Me.btnRefrescar.Name = "btnRefrescar"
            Me.btnRefrescar.Size = New System.Drawing.Size(75, 23)
            Me.btnRefrescar.TabIndex = 7
            Me.btnRefrescar.Text = "Refrescar"
            Me.btnRefrescar.UseVisualStyleBackColor = True
            Me.btnRefrescar.Visible = False
            '
            'btnBuscar
            '
            Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnBuscar.Location = New System.Drawing.Point(593, 28)
            Me.btnBuscar.Name = "btnBuscar"
            Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
            Me.btnBuscar.TabIndex = 8
            Me.btnBuscar.Text = "Buscar"
            Me.btnBuscar.UseVisualStyleBackColor = True
            '
            'dgvDatos
            '
            Me.dgvDatos.AllowUserToAddRows = False
            Me.dgvDatos.AllowUserToDeleteRows = False
            Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 5.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvDatos.ColumnHeadersHeight = 15
            Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvDatos.Location = New System.Drawing.Point(7, 51)
            Me.dgvDatos.MultiSelect = False
            Me.dgvDatos.Name = "dgvDatos"
            Me.dgvDatos.ReadOnly = True
            Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvDatos.Size = New System.Drawing.Size(659, 253)
            Me.dgvDatos.TabIndex = 9
            '
            'frmBusquedaDetracciones
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(688, 408)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Controls.Add(Me.tsSubBarra)
            Me.Name = "frmBusquedaDetracciones"
            Me.Text = "Búsqueda"
            Me.Controls.SetChildIndex(Me.tsSubBarra, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.tsSubBarra.ResumeLayout(False)
            Me.tsSubBarra.PerformLayout()
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents tsSubBarra As System.Windows.Forms.ToolStrip
        Friend WithEvents tsbOkBusqueda As System.Windows.Forms.ToolStripButton
        Friend WithEvents tss1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents tsbInicio As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbAnterior As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbSiguiente As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbFinal As System.Windows.Forms.ToolStripButton
        Friend WithEvents tss2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
        Protected Friend WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents cboDetalleTipoDocumento As System.Windows.Forms.ComboBox
        Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
        Friend WithEvents lblTotal As System.Windows.Forms.Label
        Friend WithEvents txtTotal As System.Windows.Forms.TextBox
        Friend WithEvents txtBuscarSerie As System.Windows.Forms.TextBox
        Friend WithEvents lblBuscar As System.Windows.Forms.Label
        Friend WithEvents cboBuscar As System.Windows.Forms.ComboBox
        Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
        Friend WithEvents cboDatoBuscar As System.Windows.Forms.ComboBox
        Friend WithEvents chkTipoBusqueda As System.Windows.Forms.CheckBox
        Friend WithEvents chkBusquedaTiempoReal As System.Windows.Forms.CheckBox
        Friend WithEvents btnRefrescar As System.Windows.Forms.Button
        Friend WithEvents btnBuscar As System.Windows.Forms.Button
        Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    End Class
End Namespace
