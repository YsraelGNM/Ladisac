Namespace Ladisac.Foundation.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmMonedas
        Inherits Views.ViewMaster

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
            Me.Button1 = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(481, 13)
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(394, 264)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(75, 23)
            Me.Button1.TabIndex = 1
            Me.Button1.Text = "Button1"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'frmMonedas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(481, 299)
            Me.Controls.Add(Me.Button1)
            Me.Name = "frmMonedas"
            Me.Text = " "
            Me.Controls.SetChildIndex(Me.Button1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Button1 As System.Windows.Forms.Button
    End Class

End Namespace
