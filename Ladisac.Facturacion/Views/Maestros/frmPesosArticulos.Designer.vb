Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPesosArticulos
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
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.cboPAR_MES = New System.Windows.Forms.ComboBox()
            Me.lblPAR_ESTADO = New System.Windows.Forms.Label()
            Me.chkPAR_ESTADO = New System.Windows.Forms.CheckBox()
            Me.lblUM_ID = New System.Windows.Forms.Label()
            Me.chkUM_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtUM_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtUM_ID = New System.Windows.Forms.TextBox()
            Me.lblPAR_PESO_MIN = New System.Windows.Forms.Label()
            Me.txtPAR_PESO_MIN = New System.Windows.Forms.TextBox()
            Me.lblPAR_PESO_MAX = New System.Windows.Forms.Label()
            Me.txtPAR_PESO_MAX = New System.Windows.Forms.TextBox()
            Me.lblPAR_ANIO = New System.Windows.Forms.Label()
            Me.txtPAR_ANIO = New System.Windows.Forms.TextBox()
            Me.lblPAR_MES = New System.Windows.Forms.Label()
            Me.lblART_ID = New System.Windows.Forms.Label()
            Me.txtART_ID = New System.Windows.Forms.TextBox()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.chkART_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtART_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.pnCuerpo.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(722, 28)
            Me.lblTitle.Text = "Pesos artículos"
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.chkART_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtART_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.cboPAR_MES)
            Me.pnCuerpo.Controls.Add(Me.lblPAR_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkPAR_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblUM_ID)
            Me.pnCuerpo.Controls.Add(Me.chkUM_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtUM_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtUM_ID)
            Me.pnCuerpo.Controls.Add(Me.lblPAR_PESO_MIN)
            Me.pnCuerpo.Controls.Add(Me.txtPAR_PESO_MIN)
            Me.pnCuerpo.Controls.Add(Me.lblPAR_PESO_MAX)
            Me.pnCuerpo.Controls.Add(Me.txtPAR_PESO_MAX)
            Me.pnCuerpo.Controls.Add(Me.lblPAR_ANIO)
            Me.pnCuerpo.Controls.Add(Me.txtPAR_ANIO)
            Me.pnCuerpo.Controls.Add(Me.lblPAR_MES)
            Me.pnCuerpo.Controls.Add(Me.lblART_ID)
            Me.pnCuerpo.Controls.Add(Me.txtART_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(30, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(657, 164)
            Me.pnCuerpo.TabIndex = 118
            '
            'cboPAR_MES
            '
            Me.cboPAR_MES.FormattingEnabled = True
            Me.cboPAR_MES.Location = New System.Drawing.Point(94, 47)
            Me.cboPAR_MES.Name = "cboPAR_MES"
            Me.cboPAR_MES.Size = New System.Drawing.Size(100, 21)
            Me.cboPAR_MES.TabIndex = 1
            '
            'lblPAR_ESTADO
            '
            Me.lblPAR_ESTADO.AutoSize = True
            Me.lblPAR_ESTADO.Location = New System.Drawing.Point(11, 134)
            Me.lblPAR_ESTADO.Name = "lblPAR_ESTADO"
            Me.lblPAR_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblPAR_ESTADO.TabIndex = 134
            Me.lblPAR_ESTADO.Text = "Estado"
            '
            'chkPAR_ESTADO
            '
            Me.chkPAR_ESTADO.AutoSize = True
            Me.chkPAR_ESTADO.Location = New System.Drawing.Point(94, 134)
            Me.chkPAR_ESTADO.Name = "chkPAR_ESTADO"
            Me.chkPAR_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPAR_ESTADO.TabIndex = 8
            Me.chkPAR_ESTADO.UseVisualStyleBackColor = True
            '
            'lblUM_ID
            '
            Me.lblUM_ID.AutoSize = True
            Me.lblUM_ID.Location = New System.Drawing.Point(11, 106)
            Me.lblUM_ID.Name = "lblUM_ID"
            Me.lblUM_ID.Size = New System.Drawing.Size(64, 13)
            Me.lblUM_ID.TabIndex = 132
            Me.lblUM_ID.Text = "Uni. Medida"
            '
            'chkUM_ESTADO
            '
            Me.chkUM_ESTADO.AutoSize = True
            Me.chkUM_ESTADO.Enabled = False
            Me.chkUM_ESTADO.Location = New System.Drawing.Point(567, 106)
            Me.chkUM_ESTADO.Name = "chkUM_ESTADO"
            Me.chkUM_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkUM_ESTADO.TabIndex = 7
            Me.chkUM_ESTADO.UseVisualStyleBackColor = True
            '
            'txtUM_DESCRIPCION
            '
            Me.txtUM_DESCRIPCION.Enabled = False
            Me.txtUM_DESCRIPCION.Location = New System.Drawing.Point(133, 106)
            Me.txtUM_DESCRIPCION.Name = "txtUM_DESCRIPCION"
            Me.txtUM_DESCRIPCION.ReadOnly = True
            Me.txtUM_DESCRIPCION.Size = New System.Drawing.Size(425, 20)
            Me.txtUM_DESCRIPCION.TabIndex = 6
            '
            'txtUM_ID
            '
            Me.txtUM_ID.Location = New System.Drawing.Point(94, 106)
            Me.txtUM_ID.Name = "txtUM_ID"
            Me.txtUM_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtUM_ID.TabIndex = 5
            '
            'lblPAR_PESO_MIN
            '
            Me.lblPAR_PESO_MIN.AutoSize = True
            Me.lblPAR_PESO_MIN.Location = New System.Drawing.Point(11, 77)
            Me.lblPAR_PESO_MIN.Name = "lblPAR_PESO_MIN"
            Me.lblPAR_PESO_MIN.Size = New System.Drawing.Size(68, 13)
            Me.lblPAR_PESO_MIN.TabIndex = 128
            Me.lblPAR_PESO_MIN.Text = "Peso mínimo"
            '
            'txtPAR_PESO_MIN
            '
            Me.txtPAR_PESO_MIN.Location = New System.Drawing.Point(94, 77)
            Me.txtPAR_PESO_MIN.Name = "txtPAR_PESO_MIN"
            Me.txtPAR_PESO_MIN.Size = New System.Drawing.Size(100, 20)
            Me.txtPAR_PESO_MIN.TabIndex = 3
            Me.txtPAR_PESO_MIN.Text = "0"
            '
            'lblPAR_PESO_MAX
            '
            Me.lblPAR_PESO_MAX.AutoSize = True
            Me.lblPAR_PESO_MAX.Location = New System.Drawing.Point(246, 77)
            Me.lblPAR_PESO_MAX.Name = "lblPAR_PESO_MAX"
            Me.lblPAR_PESO_MAX.Size = New System.Drawing.Size(69, 13)
            Me.lblPAR_PESO_MAX.TabIndex = 126
            Me.lblPAR_PESO_MAX.Text = "Peso máximo"
            '
            'txtPAR_PESO_MAX
            '
            Me.txtPAR_PESO_MAX.Location = New System.Drawing.Point(320, 77)
            Me.txtPAR_PESO_MAX.Name = "txtPAR_PESO_MAX"
            Me.txtPAR_PESO_MAX.Size = New System.Drawing.Size(100, 20)
            Me.txtPAR_PESO_MAX.TabIndex = 4
            Me.txtPAR_PESO_MAX.Text = "0"
            '
            'lblPAR_ANIO
            '
            Me.lblPAR_ANIO.AutoSize = True
            Me.lblPAR_ANIO.Location = New System.Drawing.Point(246, 47)
            Me.lblPAR_ANIO.Name = "lblPAR_ANIO"
            Me.lblPAR_ANIO.Size = New System.Drawing.Size(26, 13)
            Me.lblPAR_ANIO.TabIndex = 124
            Me.lblPAR_ANIO.Text = "Año"
            '
            'txtPAR_ANIO
            '
            Me.txtPAR_ANIO.Location = New System.Drawing.Point(320, 47)
            Me.txtPAR_ANIO.Name = "txtPAR_ANIO"
            Me.txtPAR_ANIO.Size = New System.Drawing.Size(100, 20)
            Me.txtPAR_ANIO.TabIndex = 2
            Me.txtPAR_ANIO.Text = "0"
            '
            'lblPAR_MES
            '
            Me.lblPAR_MES.AutoSize = True
            Me.lblPAR_MES.Location = New System.Drawing.Point(11, 47)
            Me.lblPAR_MES.Name = "lblPAR_MES"
            Me.lblPAR_MES.Size = New System.Drawing.Size(27, 13)
            Me.lblPAR_MES.TabIndex = 122
            Me.lblPAR_MES.Text = "Mes"
            '
            'lblART_ID
            '
            Me.lblART_ID.AutoSize = True
            Me.lblART_ID.Location = New System.Drawing.Point(11, 16)
            Me.lblART_ID.Name = "lblART_ID"
            Me.lblART_ID.Size = New System.Drawing.Size(79, 13)
            Me.lblART_ID.TabIndex = 120
            Me.lblART_ID.Text = "Código artículo"
            '
            'txtART_ID
            '
            Me.txtART_ID.Location = New System.Drawing.Point(94, 16)
            Me.txtART_ID.Name = "txtART_ID"
            Me.txtART_ID.Size = New System.Drawing.Size(100, 20)
            Me.txtART_ID.TabIndex = 0
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(642, 0)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 24)
            Me.btnImagen.TabIndex = 135
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'chkART_ESTADO
            '
            Me.chkART_ESTADO.AutoSize = True
            Me.chkART_ESTADO.Enabled = False
            Me.chkART_ESTADO.Location = New System.Drawing.Point(567, 16)
            Me.chkART_ESTADO.Name = "chkART_ESTADO"
            Me.chkART_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkART_ESTADO.TabIndex = 136
            Me.chkART_ESTADO.UseVisualStyleBackColor = True
            '
            'txtART_DESCRIPCION
            '
            Me.txtART_DESCRIPCION.Enabled = False
            Me.txtART_DESCRIPCION.Location = New System.Drawing.Point(200, 16)
            Me.txtART_DESCRIPCION.Name = "txtART_DESCRIPCION"
            Me.txtART_DESCRIPCION.ReadOnly = True
            Me.txtART_DESCRIPCION.Size = New System.Drawing.Size(358, 20)
            Me.txtART_DESCRIPCION.TabIndex = 135
            '
            'frmPesosArticulos
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(722, 233)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmPesosArticulos"
            Me.Text = "Pesos artículos"
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblART_ID As System.Windows.Forms.Label
        Public WithEvents txtART_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblPAR_PESO_MIN As System.Windows.Forms.Label
        Public WithEvents txtPAR_PESO_MIN As System.Windows.Forms.TextBox
        Friend WithEvents lblPAR_PESO_MAX As System.Windows.Forms.Label
        Public WithEvents txtPAR_PESO_MAX As System.Windows.Forms.TextBox
        Friend WithEvents lblPAR_ANIO As System.Windows.Forms.Label
        Public WithEvents txtPAR_ANIO As System.Windows.Forms.TextBox
        Friend WithEvents lblPAR_MES As System.Windows.Forms.Label
        Friend WithEvents lblUM_ID As System.Windows.Forms.Label
        Public WithEvents chkUM_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtUM_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtUM_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblPAR_ESTADO As System.Windows.Forms.Label
        Public WithEvents chkPAR_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents cboPAR_MES As System.Windows.Forms.ComboBox
        Public WithEvents chkART_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtART_DESCRIPCION As System.Windows.Forms.TextBox
    End Class
End Namespace