﻿Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmExportarSunatPDT626
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
            Me.btnGenerar = New System.Windows.Forms.Button()
            Me.btnPeriodo = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(380, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.btnGenerar)
            Me.Panel1.Controls.Add(Me.btnPeriodo)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.txtPeriodo)
            Me.Panel1.Location = New System.Drawing.Point(4, 31)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(372, 110)
            Me.Panel1.TabIndex = 2
            '
            'btnGenerar
            '
            Me.btnGenerar.Location = New System.Drawing.Point(120, 64)
            Me.btnGenerar.Name = "btnGenerar"
            Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
            Me.btnGenerar.TabIndex = 14
            Me.btnGenerar.Text = "Generar"
            Me.btnGenerar.UseVisualStyleBackColor = True
            '
            'btnPeriodo
            '
            Me.btnPeriodo.Location = New System.Drawing.Point(167, 13)
            Me.btnPeriodo.Name = "btnPeriodo"
            Me.btnPeriodo.Size = New System.Drawing.Size(28, 23)
            Me.btnPeriodo.TabIndex = 9
            Me.btnPeriodo.Text = ":::"
            Me.btnPeriodo.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(33, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(43, 13)
            Me.Label1.TabIndex = 10
            Me.Label1.Text = "Periodo"
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Enabled = False
            Me.txtPeriodo.Location = New System.Drawing.Point(86, 13)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(75, 20)
            Me.txtPeriodo.TabIndex = 11
            '
            'frmExportarSunatPDT626
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(380, 145)
            Me.Controls.Add(Me.Panel1)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmExportarSunatPDT626"
            Me.Text = "frmExportarSunatPDT626"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnGenerar As System.Windows.Forms.Button
        Friend WithEvents btnPeriodo As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    End Class

End Namespace