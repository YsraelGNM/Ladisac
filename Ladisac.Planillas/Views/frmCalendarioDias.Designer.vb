Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCalendarioDias
        Inherits ViewManMasterPlanillas

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
            Me.components = New System.ComponentModel.Container()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.dateCalendario = New System.Windows.Forms.MonthCalendar()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(413, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.dateCalendario)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(397, 192)
            Me.Panel1.TabIndex = 2
            '
            'dateCalendario
            '
            Me.dateCalendario.Location = New System.Drawing.Point(117, 9)
            Me.dateCalendario.Name = "dateCalendario"
            Me.dateCalendario.TabIndex = 4
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(9, 173)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(254, 13)
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "Seleccione el dia que sera considedado como doble"
            '
            'frmCalendarioDias
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(413, 255)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmCalendarioDias"
            Me.Text = "frmCalendarioDias"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents dateCalendario As System.Windows.Forms.MonthCalendar
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Label1 As System.Windows.Forms.Label
    End Class

End Namespace