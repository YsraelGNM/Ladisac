Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmRolPuntoVentaAlmacen
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
            Me.lblUNT_ESTADO = New System.Windows.Forms.Label()
            Me.lblALM_ID = New System.Windows.Forms.Label()
            Me.lblPVE_ID = New System.Windows.Forms.Label()
            Me.chkRPA_ESTADO = New System.Windows.Forms.CheckBox()
            Me.chkALM_ESTADO = New System.Windows.Forms.CheckBox()
            Me.chkPVE_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtALM_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtPVE_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtALM_ID = New System.Windows.Forms.TextBox()
            Me.txtPVE_ID = New System.Windows.Forms.TextBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(749, 28)
            Me.lblTitle.Text = "Rol punto de venta almacén"
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
            Me.pnCuerpo.Controls.Add(Me.lblUNT_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblALM_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPVE_ID)
            Me.pnCuerpo.Controls.Add(Me.chkRPA_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkALM_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkPVE_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtALM_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtALM_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPVE_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(34, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(683, 117)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblUNT_ESTADO
            '
            Me.lblUNT_ESTADO.AutoSize = True
            Me.lblUNT_ESTADO.Location = New System.Drawing.Point(14, 78)
            Me.lblUNT_ESTADO.Name = "lblUNT_ESTADO"
            Me.lblUNT_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblUNT_ESTADO.TabIndex = 36
            Me.lblUNT_ESTADO.Text = "Estado"
            '
            'lblALM_ID
            '
            Me.lblALM_ID.AutoSize = True
            Me.lblALM_ID.Location = New System.Drawing.Point(14, 44)
            Me.lblALM_ID.Name = "lblALM_ID"
            Me.lblALM_ID.Size = New System.Drawing.Size(48, 13)
            Me.lblALM_ID.TabIndex = 26
            Me.lblALM_ID.Text = "Almacén"
            '
            'lblPVE_ID
            '
            Me.lblPVE_ID.AutoSize = True
            Me.lblPVE_ID.Location = New System.Drawing.Point(14, 13)
            Me.lblPVE_ID.Name = "lblPVE_ID"
            Me.lblPVE_ID.Size = New System.Drawing.Size(80, 13)
            Me.lblPVE_ID.TabIndex = 25
            Me.lblPVE_ID.Text = "Punto de venta"
            '
            'chkRPA_ESTADO
            '
            Me.chkRPA_ESTADO.AutoSize = True
            Me.chkRPA_ESTADO.Location = New System.Drawing.Point(102, 78)
            Me.chkRPA_ESTADO.Name = "chkRPA_ESTADO"
            Me.chkRPA_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkRPA_ESTADO.TabIndex = 7
            Me.chkRPA_ESTADO.UseVisualStyleBackColor = True
            '
            'chkALM_ESTADO
            '
            Me.chkALM_ESTADO.AutoSize = True
            Me.chkALM_ESTADO.Enabled = False
            Me.chkALM_ESTADO.Location = New System.Drawing.Point(573, 44)
            Me.chkALM_ESTADO.Name = "chkALM_ESTADO"
            Me.chkALM_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkALM_ESTADO.TabIndex = 6
            Me.chkALM_ESTADO.UseVisualStyleBackColor = True
            '
            'chkPVE_ESTADO
            '
            Me.chkPVE_ESTADO.AutoSize = True
            Me.chkPVE_ESTADO.Enabled = False
            Me.chkPVE_ESTADO.Location = New System.Drawing.Point(573, 13)
            Me.chkPVE_ESTADO.Name = "chkPVE_ESTADO"
            Me.chkPVE_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPVE_ESTADO.TabIndex = 3
            Me.chkPVE_ESTADO.UseVisualStyleBackColor = True
            '
            'txtALM_DESCRIPCION
            '
            Me.txtALM_DESCRIPCION.Enabled = False
            Me.txtALM_DESCRIPCION.Location = New System.Drawing.Point(154, 44)
            Me.txtALM_DESCRIPCION.Name = "txtALM_DESCRIPCION"
            Me.txtALM_DESCRIPCION.ReadOnly = True
            Me.txtALM_DESCRIPCION.Size = New System.Drawing.Size(413, 20)
            Me.txtALM_DESCRIPCION.TabIndex = 5
            '
            'txtPVE_DESCRIPCION
            '
            Me.txtPVE_DESCRIPCION.Enabled = False
            Me.txtPVE_DESCRIPCION.Location = New System.Drawing.Point(154, 13)
            Me.txtPVE_DESCRIPCION.Name = "txtPVE_DESCRIPCION"
            Me.txtPVE_DESCRIPCION.ReadOnly = True
            Me.txtPVE_DESCRIPCION.Size = New System.Drawing.Size(413, 20)
            Me.txtPVE_DESCRIPCION.TabIndex = 2
            '
            'txtALM_ID
            '
            Me.txtALM_ID.Location = New System.Drawing.Point(102, 44)
            Me.txtALM_ID.Name = "txtALM_ID"
            Me.txtALM_ID.Size = New System.Drawing.Size(46, 20)
            Me.txtALM_ID.TabIndex = 4
            '
            'txtPVE_ID
            '
            Me.txtPVE_ID.Location = New System.Drawing.Point(102, 13)
            Me.txtPVE_ID.Name = "txtPVE_ID"
            Me.txtPVE_ID.Size = New System.Drawing.Size(46, 20)
            Me.txtPVE_ID.TabIndex = 1
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(672, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 119
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'frmRolPuntoVentaAlmacen
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(749, 181)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmRolPuntoVentaAlmacen"
            Me.Text = "Rol punto de venta almacén"
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
        Friend WithEvents lblUNT_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblALM_ID As System.Windows.Forms.Label
        Friend WithEvents lblPVE_ID As System.Windows.Forms.Label
        Public WithEvents chkRPA_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkALM_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkPVE_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtALM_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtPVE_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtALM_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPVE_ID As System.Windows.Forms.TextBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
    End Class
End Namespace