
Namespace Ladisac.Despacho.Views

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmBuscar
        Inherits Ladisac.Foundation.Views.ViewMaster

        'Form overrides dispose to clean up the component list.
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

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.dgvLista = New System.Windows.Forms.DataGridView()
            Me.lblView = New System.Windows.Forms.Label()
            Me.dgvBuscar = New System.Windows.Forms.DataGridView()
            Me.btnFind = New System.Windows.Forms.Button()
            CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(950, 28)
            '
            'dgvLista
            '
            Me.dgvLista.AllowUserToAddRows = False
            Me.dgvLista.AllowUserToDeleteRows = False
            Me.dgvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
            Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvLista.ColumnHeadersVisible = False
            Me.dgvLista.Location = New System.Drawing.Point(4, 103)
            Me.dgvLista.Name = "dgvLista"
            Me.dgvLista.ReadOnly = True
            Me.dgvLista.Size = New System.Drawing.Size(892, 263)
            Me.dgvLista.TabIndex = 1
            '
            'lblView
            '
            Me.lblView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblView.Location = New System.Drawing.Point(1, 374)
            Me.lblView.Name = "lblView"
            Me.lblView.Size = New System.Drawing.Size(895, 40)
            Me.lblView.TabIndex = 8
            '
            'dgvBuscar
            '
            Me.dgvBuscar.AllowUserToAddRows = False
            Me.dgvBuscar.AllowUserToDeleteRows = False
            Me.dgvBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvBuscar.BackgroundColor = System.Drawing.Color.SteelBlue
            Me.dgvBuscar.Location = New System.Drawing.Point(4, 41)
            Me.dgvBuscar.Name = "dgvBuscar"
            Me.dgvBuscar.Size = New System.Drawing.Size(892, 64)
            Me.dgvBuscar.TabIndex = 0
            '
            'btnFind
            '
            Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnFind.Location = New System.Drawing.Point(902, 41)
            Me.btnFind.Name = "btnFind"
            Me.btnFind.Size = New System.Drawing.Size(36, 64)
            Me.btnFind.TabIndex = 9
            Me.btnFind.Text = "Find"
            Me.btnFind.UseVisualStyleBackColor = True
            '
            'frmBuscar
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(950, 423)
            Me.Controls.Add(Me.btnFind)
            Me.Controls.Add(Me.dgvBuscar)
            Me.Controls.Add(Me.lblView)
            Me.Controls.Add(Me.dgvLista)
            Me.Name = "frmBuscar"
            Me.Text = "Buscar"
            Me.Controls.SetChildIndex(Me.dgvLista, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.lblView, 0)
            Me.Controls.SetChildIndex(Me.dgvBuscar, 0)
            Me.Controls.SetChildIndex(Me.btnFind, 0)
            CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvBuscar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Public WithEvents dgvLista As System.Windows.Forms.DataGridView
        Friend WithEvents lblView As System.Windows.Forms.Label
        Public WithEvents dgvBuscar As System.Windows.Forms.DataGridView
        Friend WithEvents btnFind As System.Windows.Forms.Button
    End Class
End Namespace