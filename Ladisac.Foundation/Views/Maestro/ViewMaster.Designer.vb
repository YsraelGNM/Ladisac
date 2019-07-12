Namespace Ladisac.Foundation.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewMaster
        Inherits System.Windows.Forms.Form

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
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.BackColor = System.Drawing.Color.LightSteelBlue
            Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblTitle.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.Location = New System.Drawing.Point(0, 0)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(635, 28)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "Label1"
            '
            'ViewMaster
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(635, 408)
            Me.Controls.Add(Me.lblTitle)
            Me.Name = "ViewMaster"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = " ViewMaster "
            Me.ResumeLayout(False)
        End Sub
        Public WithEvents lblTitle As System.Windows.Forms.Label
    End Class

End Namespace
