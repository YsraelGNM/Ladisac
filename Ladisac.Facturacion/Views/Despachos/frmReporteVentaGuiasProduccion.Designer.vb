<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteVentaGuiasProduccion
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
        Me.rbtDocumentoFacturas = New System.Windows.Forms.RadioButton()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rbtProcesoTerminado = New System.Windows.Forms.RadioButton()
        Me.rbtStockLadrillo = New System.Windows.Forms.RadioButton()
        Me.rbtDocumentoGuias = New System.Windows.Forms.RadioButton()
        Me.rbtPendientesEntrega = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(940, 28)
        Me.lblTitle.Text = "Reporte Proyeccion"
        '
        'rbtDocumentoFacturas
        '
        Me.rbtDocumentoFacturas.AutoSize = True
        Me.rbtDocumentoFacturas.Location = New System.Drawing.Point(15, 80)
        Me.rbtDocumentoFacturas.Name = "rbtDocumentoFacturas"
        Me.rbtDocumentoFacturas.Size = New System.Drawing.Size(129, 17)
        Me.rbtDocumentoFacturas.TabIndex = 176
        Me.rbtDocumentoFacturas.TabStop = True
        Me.rbtDocumentoFacturas.Text = "Documentos Facturas"
        Me.rbtDocumentoFacturas.UseVisualStyleBackColor = True
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(783, 54)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(101, 43)
        Me.btnCargar.TabIndex = 174
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(270, 43)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(93, 20)
        Me.dtpFechaFin.TabIndex = 173
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(214, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 172
        Me.Label4.Text = "Hasta"
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIni.Location = New System.Drawing.Point(80, 43)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(93, 20)
        Me.dtpFechaIni.TabIndex = 171
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 170
        Me.Label6.Text = "Desde"
        '
        'rbtProcesoTerminado
        '
        Me.rbtProcesoTerminado.AutoSize = True
        Me.rbtProcesoTerminado.Location = New System.Drawing.Point(165, 80)
        Me.rbtProcesoTerminado.Name = "rbtProcesoTerminado"
        Me.rbtProcesoTerminado.Size = New System.Drawing.Size(125, 17)
        Me.rbtProcesoTerminado.TabIndex = 177
        Me.rbtProcesoTerminado.TabStop = True
        Me.rbtProcesoTerminado.Text = "Proceso y Terminado"
        Me.rbtProcesoTerminado.UseVisualStyleBackColor = True
        '
        'rbtStockLadrillo
        '
        Me.rbtStockLadrillo.AutoSize = True
        Me.rbtStockLadrillo.Location = New System.Drawing.Point(312, 80)
        Me.rbtStockLadrillo.Name = "rbtStockLadrillo"
        Me.rbtStockLadrillo.Size = New System.Drawing.Size(89, 17)
        Me.rbtStockLadrillo.TabIndex = 178
        Me.rbtStockLadrillo.TabStop = True
        Me.rbtStockLadrillo.Text = "Stock Ladrillo"
        Me.rbtStockLadrillo.UseVisualStyleBackColor = True
        '
        'rbtDocumentoGuias
        '
        Me.rbtDocumentoGuias.AutoSize = True
        Me.rbtDocumentoGuias.Location = New System.Drawing.Point(418, 80)
        Me.rbtDocumentoGuias.Name = "rbtDocumentoGuias"
        Me.rbtDocumentoGuias.Size = New System.Drawing.Size(115, 17)
        Me.rbtDocumentoGuias.TabIndex = 179
        Me.rbtDocumentoGuias.TabStop = True
        Me.rbtDocumentoGuias.Text = "Documentos Guias"
        Me.rbtDocumentoGuias.UseVisualStyleBackColor = True
        '
        'rbtPendientesEntrega
        '
        Me.rbtPendientesEntrega.AutoSize = True
        Me.rbtPendientesEntrega.Location = New System.Drawing.Point(560, 80)
        Me.rbtPendientesEntrega.Name = "rbtPendientesEntrega"
        Me.rbtPendientesEntrega.Size = New System.Drawing.Size(133, 17)
        Me.rbtPendientesEntrega.TabIndex = 180
        Me.rbtPendientesEntrega.TabStop = True
        Me.rbtPendientesEntrega.Text = "Pendientes de Entrega"
        Me.rbtPendientesEntrega.UseVisualStyleBackColor = True
        '
        'frmReporteVentaGuiasProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(940, 124)
        Me.Controls.Add(Me.rbtPendientesEntrega)
        Me.Controls.Add(Me.rbtDocumentoGuias)
        Me.Controls.Add(Me.rbtStockLadrillo)
        Me.Controls.Add(Me.rbtProcesoTerminado)
        Me.Controls.Add(Me.rbtDocumentoFacturas)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.dtpFechaFin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpFechaIni)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmReporteVentaGuiasProduccion"
        Me.Text = "Reporte Proyeccion"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaIni, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaFin, 0)
        Me.Controls.SetChildIndex(Me.btnCargar, 0)
        Me.Controls.SetChildIndex(Me.rbtDocumentoFacturas, 0)
        Me.Controls.SetChildIndex(Me.rbtProcesoTerminado, 0)
        Me.Controls.SetChildIndex(Me.rbtStockLadrillo, 0)
        Me.Controls.SetChildIndex(Me.rbtDocumentoGuias, 0)
        Me.Controls.SetChildIndex(Me.rbtPendientesEntrega, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbtDocumentoFacturas As System.Windows.Forms.RadioButton
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rbtProcesoTerminado As System.Windows.Forms.RadioButton
    Friend WithEvents rbtStockLadrillo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDocumentoGuias As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPendientesEntrega As System.Windows.Forms.RadioButton

End Class
