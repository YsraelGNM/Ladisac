<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArbolEntidad
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
        Me.components = New System.ComponentModel.Container()
        Me.tviEntidades = New System.Windows.Forms.TreeView()
        Me.cmsNodos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuOT = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsNodos.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(669, 28)
        Me.lblTitle.Text = "Arbol de entidades"
        '
        'tviEntidades
        '
        Me.tviEntidades.Location = New System.Drawing.Point(43, 49)
        Me.tviEntidades.Name = "tviEntidades"
        Me.tviEntidades.Size = New System.Drawing.Size(576, 401)
        Me.tviEntidades.TabIndex = 0
        '
        'cmsNodos
        '
        Me.cmsNodos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOT})
        Me.cmsNodos.Name = "cmsNodos"
        Me.cmsNodos.Size = New System.Drawing.Size(171, 48)
        '
        'mnuOT
        '
        Me.mnuOT.Name = "mnuOT"
        Me.mnuOT.Size = New System.Drawing.Size(170, 22)
        Me.mnuOT.Text = "Orden de Trabajo"
        '
        'frmEntidadTV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 476)
        Me.Controls.Add(Me.tviEntidades)
        Me.Name = "frmEntidadTV"
        Me.Text = "Entidades"
        Me.Controls.SetChildIndex(Me.tviEntidades, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.cmsNodos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tviEntidades As System.Windows.Forms.TreeView
    Friend WithEvents cmsNodos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuOT As System.Windows.Forms.ToolStripMenuItem
End Class
