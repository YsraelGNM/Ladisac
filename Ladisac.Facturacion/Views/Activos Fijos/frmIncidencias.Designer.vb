Namespace Ladisac.ActivosFijos.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmIncidencias
        Inherits Ladisac.Foundation.Views.ViewManMaster

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
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.lblINC_ESTADO = New System.Windows.Forms.Label()
            Me.lblINC_ID = New System.Windows.Forms.Label()
            Me.lblINC_TIPO = New System.Windows.Forms.Label()
            Me.chkINC_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtINC_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtINC_ID = New System.Windows.Forms.TextBox()
            Me.cboINC_TIPO = New System.Windows.Forms.ComboBox()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(670, 28)
            Me.lblTitle.Text = "Incidencias"
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(595, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 117
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblINC_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblINC_ID)
            Me.pnCuerpo.Controls.Add(Me.lblINC_TIPO)
            Me.pnCuerpo.Controls.Add(Me.chkINC_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtINC_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtINC_ID)
            Me.pnCuerpo.Controls.Add(Me.cboINC_TIPO)
            Me.pnCuerpo.Location = New System.Drawing.Point(32, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(608, 99)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblINC_ESTADO
            '
            Me.lblINC_ESTADO.AutoSize = True
            Me.lblINC_ESTADO.Location = New System.Drawing.Point(15, 68)
            Me.lblINC_ESTADO.Name = "lblINC_ESTADO"
            Me.lblINC_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblINC_ESTADO.TabIndex = 36
            Me.lblINC_ESTADO.Text = "Estado"
            '
            'lblINC_ID
            '
            Me.lblINC_ID.AutoSize = True
            Me.lblINC_ID.Location = New System.Drawing.Point(15, 13)
            Me.lblINC_ID.Name = "lblINC_ID"
            Me.lblINC_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblINC_ID.TabIndex = 25
            Me.lblINC_ID.Text = "Código"
            '
            'lblINC_TIPO
            '
            Me.lblINC_TIPO.AutoSize = True
            Me.lblINC_TIPO.Location = New System.Drawing.Point(15, 39)
            Me.lblINC_TIPO.Name = "lblINC_TIPO"
            Me.lblINC_TIPO.Size = New System.Drawing.Size(28, 13)
            Me.lblINC_TIPO.TabIndex = 23
            Me.lblINC_TIPO.Text = "Tipo"
            '
            'chkINC_ESTADO
            '
            Me.chkINC_ESTADO.AutoSize = True
            Me.chkINC_ESTADO.Location = New System.Drawing.Point(67, 68)
            Me.chkINC_ESTADO.Name = "chkINC_ESTADO"
            Me.chkINC_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkINC_ESTADO.TabIndex = 20
            Me.chkINC_ESTADO.UseVisualStyleBackColor = True
            '
            'txtINC_DESCRIPCION
            '
            Me.txtINC_DESCRIPCION.Location = New System.Drawing.Point(107, 13)
            Me.txtINC_DESCRIPCION.Name = "txtINC_DESCRIPCION"
            Me.txtINC_DESCRIPCION.Size = New System.Drawing.Size(481, 20)
            Me.txtINC_DESCRIPCION.TabIndex = 5
            '
            'txtINC_ID
            '
            Me.txtINC_ID.Location = New System.Drawing.Point(67, 13)
            Me.txtINC_ID.Name = "txtINC_ID"
            Me.txtINC_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtINC_ID.TabIndex = 3
            '
            'cboINC_TIPO
            '
            Me.cboINC_TIPO.FormattingEnabled = True
            Me.cboINC_TIPO.Location = New System.Drawing.Point(67, 39)
            Me.cboINC_TIPO.Name = "cboINC_TIPO"
            Me.cboINC_TIPO.Size = New System.Drawing.Size(229, 21)
            Me.cboINC_TIPO.TabIndex = 1
            '
            'frmIncidencias
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(670, 155)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Controls.Add(Me.btnImagen)
            Me.Name = "frmIncidencias"
            Me.Text = "Incidencias"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblINC_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblINC_ID As System.Windows.Forms.Label
        Friend WithEvents lblINC_TIPO As System.Windows.Forms.Label
        Public WithEvents chkINC_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtINC_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtINC_ID As System.Windows.Forms.TextBox
        Public WithEvents cboINC_TIPO As System.Windows.Forms.ComboBox
    End Class
End Namespace