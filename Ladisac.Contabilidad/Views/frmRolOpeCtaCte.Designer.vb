
Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmRolOpeCtaCte
        Inherits ViewManMasterContabilidad
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
            Me.dataRegistro = New System.Windows.Forms.DataGridView()
            Me.TDO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DTD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DetalleDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cuc_IdMN = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.CuentaMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cuc_IdME = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.CuentaME = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel1.SuspendLayout()
            CType(Me.dataRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(990, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.dataRegistro)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(986, 204)
            Me.Panel1.TabIndex = 2
            '
            'dataRegistro
            '
            Me.dataRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dataRegistro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TDO_ID, Me.TipoDocumento, Me.DTD_ID, Me.DetalleDocumento, Me.cuc_IdMN, Me.CuentaMN, Me.cuc_IdME, Me.CuentaME})
            Me.dataRegistro.Location = New System.Drawing.Point(5, 8)
            Me.dataRegistro.Name = "dataRegistro"
            Me.dataRegistro.Size = New System.Drawing.Size(981, 188)
            Me.dataRegistro.TabIndex = 0
            '
            'TDO_ID
            '
            Me.TDO_ID.HeaderText = "TDO_ID"
            Me.TDO_ID.Name = "TDO_ID"
            '
            'TipoDocumento
            '
            Me.TipoDocumento.HeaderText = "TipoDocumento"
            Me.TipoDocumento.Name = "TipoDocumento"
            '
            'DTD_ID
            '
            Me.DTD_ID.HeaderText = "DTD_ID"
            Me.DTD_ID.Name = "DTD_ID"
            '
            'DetalleDocumento
            '
            Me.DetalleDocumento.HeaderText = "DetalleDocumento"
            Me.DetalleDocumento.Name = "DetalleDocumento"
            '
            'cuc_IdMN
            '
            Me.cuc_IdMN.HeaderText = "cuc_IdMN"
            Me.cuc_IdMN.Name = "cuc_IdMN"
            Me.cuc_IdMN.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cuc_IdMN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cuc_IdMN.Width = 60
            '
            'CuentaMN
            '
            Me.CuentaMN.HeaderText = "CuentaMN"
            Me.CuentaMN.Name = "CuentaMN"
            '
            'cuc_IdME
            '
            Me.cuc_IdME.HeaderText = "cuc_IdME"
            Me.cuc_IdME.Name = "cuc_IdME"
            Me.cuc_IdME.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cuc_IdME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.cuc_IdME.Width = 60
            '
            'CuentaME
            '
            Me.CuentaME.HeaderText = "CuentaME"
            Me.CuentaME.Name = "CuentaME"
            '
            'frmRolOpeCtaCte
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(990, 273)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmRolOpeCtaCte"
            Me.Text = "frmRolOpeCtaCte"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            CType(Me.dataRegistro, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dataRegistro As System.Windows.Forms.DataGridView
        Friend WithEvents TDO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TipoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DTD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DetalleDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cuc_IdMN As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents CuentaMN As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cuc_IdME As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents CuentaME As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace