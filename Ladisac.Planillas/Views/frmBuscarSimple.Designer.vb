﻿Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmBuscarSimple
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
            Me.dgbRegistro = New System.Windows.Forms.DataGridView()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.chkUsarFiltro = New System.Windows.Forms.CheckBox()
            Me.btnBuscar = New System.Windows.Forms.Button()
            Me.txtBuscar = New System.Windows.Forms.TextBox()
            Me.cboBuscar = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            CType(Me.dgbRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(734, 28)
            Me.lblTitle.Text = "Buscar"
            '
            'dgbRegistro
            '
            Me.dgbRegistro.AllowUserToAddRows = False
            Me.dgbRegistro.AllowUserToDeleteRows = False
            Me.dgbRegistro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgbRegistro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.dgbRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgbRegistro.Location = New System.Drawing.Point(4, 88)
            Me.dgbRegistro.MultiSelect = False
            Me.dgbRegistro.Name = "dgbRegistro"
            Me.dgbRegistro.ReadOnly = True
            Me.dgbRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgbRegistro.Size = New System.Drawing.Size(726, 267)
            Me.dgbRegistro.TabIndex = 1
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.chkUsarFiltro)
            Me.Panel1.Controls.Add(Me.btnBuscar)
            Me.Panel1.Controls.Add(Me.txtBuscar)
            Me.Panel1.Controls.Add(Me.cboBuscar)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(3, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(728, 54)
            Me.Panel1.TabIndex = 2
            '
            'chkUsarFiltro
            '
            Me.chkUsarFiltro.AutoSize = True
            Me.chkUsarFiltro.Location = New System.Drawing.Point(64, 32)
            Me.chkUsarFiltro.Name = "chkUsarFiltro"
            Me.chkUsarFiltro.Size = New System.Drawing.Size(73, 17)
            Me.chkUsarFiltro.TabIndex = 9
            Me.chkUsarFiltro.Text = "Usar Filtro"
            Me.chkUsarFiltro.UseVisualStyleBackColor = True
            '
            'btnBuscar
            '
            Me.btnBuscar.Location = New System.Drawing.Point(458, 11)
            Me.btnBuscar.Name = "btnBuscar"
            Me.btnBuscar.Size = New System.Drawing.Size(67, 23)
            Me.btnBuscar.TabIndex = 8
            Me.btnBuscar.Text = "Buscar"
            Me.btnBuscar.UseVisualStyleBackColor = True
            '
            'txtBuscar
            '
            Me.txtBuscar.Location = New System.Drawing.Point(252, 11)
            Me.txtBuscar.Name = "txtBuscar"
            Me.txtBuscar.Size = New System.Drawing.Size(200, 20)
            Me.txtBuscar.TabIndex = 7
            '
            'cboBuscar
            '
            Me.cboBuscar.Enabled = False
            Me.cboBuscar.FormattingEnabled = True
            Me.cboBuscar.Location = New System.Drawing.Point(64, 10)
            Me.cboBuscar.Name = "cboBuscar"
            Me.cboBuscar.Size = New System.Drawing.Size(182, 21)
            Me.cboBuscar.TabIndex = 6
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(18, 15)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(40, 13)
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "Buscar"
            '
            'frmBuscarSimple
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(734, 361)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.dgbRegistro)
            Me.Name = "frmBuscarSimple"
            Me.Text = "Buscar"
            Me.Controls.SetChildIndex(Me.dgbRegistro, 0)
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            CType(Me.dgbRegistro, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents dgbRegistro As System.Windows.Forms.DataGridView
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
        Friend WithEvents cboBuscar As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnBuscar As System.Windows.Forms.Button
        Friend WithEvents chkUsarFiltro As System.Windows.Forms.CheckBox
    End Class
End Namespace