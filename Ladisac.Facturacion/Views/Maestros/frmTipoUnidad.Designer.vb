Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmTipoUnidad
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
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.lblTUN_ESTADO = New System.Windows.Forms.Label()
            Me.lblTUN_DESCRIPCION = New System.Windows.Forms.Label()
            Me.lblTUN_ID = New System.Windows.Forms.Label()
            Me.chkTUN_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtTUN_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtTUN_ID = New System.Windows.Forms.TextBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(598, 28)
            Me.lblTitle.Text = "Tipo de unidad"
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
            Me.pnCuerpo.Controls.Add(Me.lblTUN_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblTUN_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.lblTUN_ID)
            Me.pnCuerpo.Controls.Add(Me.chkTUN_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtTUN_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTUN_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(31, 28)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(527, 110)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblTUN_ESTADO
            '
            Me.lblTUN_ESTADO.AutoSize = True
            Me.lblTUN_ESTADO.Location = New System.Drawing.Point(18, 75)
            Me.lblTUN_ESTADO.Name = "lblTUN_ESTADO"
            Me.lblTUN_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblTUN_ESTADO.TabIndex = 36
            Me.lblTUN_ESTADO.Text = "Estado"
            '
            'lblTUN_DESCRIPCION
            '
            Me.lblTUN_DESCRIPCION.AutoSize = True
            Me.lblTUN_DESCRIPCION.Location = New System.Drawing.Point(18, 42)
            Me.lblTUN_DESCRIPCION.Name = "lblTUN_DESCRIPCION"
            Me.lblTUN_DESCRIPCION.Size = New System.Drawing.Size(63, 13)
            Me.lblTUN_DESCRIPCION.TabIndex = 30
            Me.lblTUN_DESCRIPCION.Text = "Descripción"
            '
            'lblTUN_ID
            '
            Me.lblTUN_ID.AutoSize = True
            Me.lblTUN_ID.Location = New System.Drawing.Point(18, 14)
            Me.lblTUN_ID.Name = "lblTUN_ID"
            Me.lblTUN_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblTUN_ID.TabIndex = 25
            Me.lblTUN_ID.Text = "Código"
            '
            'chkTUN_ESTADO
            '
            Me.chkTUN_ESTADO.AutoSize = True
            Me.chkTUN_ESTADO.Location = New System.Drawing.Point(85, 74)
            Me.chkTUN_ESTADO.Name = "chkTUN_ESTADO"
            Me.chkTUN_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTUN_ESTADO.TabIndex = 2
            Me.chkTUN_ESTADO.UseVisualStyleBackColor = True
            '
            'txtTUN_DESCRIPCION
            '
            Me.txtTUN_DESCRIPCION.Location = New System.Drawing.Point(85, 42)
            Me.txtTUN_DESCRIPCION.Name = "txtTUN_DESCRIPCION"
            Me.txtTUN_DESCRIPCION.Size = New System.Drawing.Size(424, 20)
            Me.txtTUN_DESCRIPCION.TabIndex = 1
            '
            'txtTUN_ID
            '
            Me.txtTUN_ID.Location = New System.Drawing.Point(85, 14)
            Me.txtTUN_ID.Name = "txtTUN_ID"
            Me.txtTUN_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtTUN_ID.TabIndex = 0
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(513, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 119
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'frmTipoUnidad
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(598, 176)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmTipoUnidad"
            Me.Text = "Tipo de unidad"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents lblTUN_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblTUN_DESCRIPCION As System.Windows.Forms.Label
        Friend WithEvents lblTUN_ID As System.Windows.Forms.Label
        Public WithEvents chkTUN_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtTUN_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtTUN_ID As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
    End Class
End Namespace