Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPlanillasPanelAdministracionDetalle
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.dgvPersonas2 = New System.Windows.Forms.DataGridView()
            Me.Serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.per_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TotalIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.totalEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Neto = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvConceptos2 = New System.Windows.Forms.DataGridView()
            Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvConceptos = New System.Windows.Forms.DataGridView()
            Me.ok = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.tic_TipoConcep_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.con_Conceptos_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.btnImprimir = New System.Windows.Forms.Button()
            Me.btnLimpiar = New System.Windows.Forms.Button()
            Me.btnQuitar = New System.Windows.Forms.Button()
            Me.btnPasar = New System.Windows.Forms.Button()
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel1.SuspendLayout()
            CType(Me.dgvPersonas2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvConceptos2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(716, 28)
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.dgvPersonas2)
            Me.Panel1.Controls.Add(Me.dgvConceptos2)
            Me.Panel1.Controls.Add(Me.dgvConceptos)
            Me.Panel1.Controls.Add(Me.btnImprimir)
            Me.Panel1.Controls.Add(Me.btnLimpiar)
            Me.Panel1.Controls.Add(Me.btnQuitar)
            Me.Panel1.Controls.Add(Me.btnPasar)
            Me.Panel1.Location = New System.Drawing.Point(5, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(707, 341)
            Me.Panel1.TabIndex = 1
            '
            'dgvPersonas2
            '
            Me.dgvPersonas2.AllowUserToAddRows = False
            Me.dgvPersonas2.AllowUserToDeleteRows = False
            Me.dgvPersonas2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvPersonas2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Serie, Me.Numero, Me.per_Id, Me.Codigo, Me.Nombre, Me.TotalIngreso, Me.totalEgreso, Me.Neto})
            Me.dgvPersonas2.Location = New System.Drawing.Point(12, 280)
            Me.dgvPersonas2.Name = "dgvPersonas2"
            Me.dgvPersonas2.ReadOnly = True
            Me.dgvPersonas2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvPersonas2.Size = New System.Drawing.Size(314, 50)
            Me.dgvPersonas2.TabIndex = 8
            '
            'Serie
            '
            Me.Serie.HeaderText = "Serie"
            Me.Serie.Name = "Serie"
            Me.Serie.ReadOnly = True
            '
            'Numero
            '
            Me.Numero.HeaderText = "Numero"
            Me.Numero.Name = "Numero"
            Me.Numero.ReadOnly = True
            '
            'per_Id
            '
            Me.per_Id.HeaderText = "per_Id"
            Me.per_Id.Name = "per_Id"
            Me.per_Id.ReadOnly = True
            '
            'Codigo
            '
            Me.Codigo.HeaderText = "Codigo"
            Me.Codigo.Name = "Codigo"
            Me.Codigo.ReadOnly = True
            '
            'Nombre
            '
            Me.Nombre.HeaderText = "Nombre"
            Me.Nombre.Name = "Nombre"
            Me.Nombre.ReadOnly = True
            '
            'TotalIngreso
            '
            Me.TotalIngreso.HeaderText = "TotalIngreso"
            Me.TotalIngreso.Name = "TotalIngreso"
            Me.TotalIngreso.ReadOnly = True
            '
            'totalEgreso
            '
            Me.totalEgreso.HeaderText = "totalEgreso"
            Me.totalEgreso.Name = "totalEgreso"
            Me.totalEgreso.ReadOnly = True
            '
            'Neto
            '
            Me.Neto.HeaderText = "Neto"
            Me.Neto.Name = "Neto"
            Me.Neto.ReadOnly = True
            '
            'dgvConceptos2
            '
            Me.dgvConceptos2.AllowUserToAddRows = False
            Me.dgvConceptos2.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvConceptos2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvConceptos2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvConceptos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvConceptos2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
            Me.dgvConceptos2.Location = New System.Drawing.Point(346, 29)
            Me.dgvConceptos2.Name = "dgvConceptos2"
            Me.dgvConceptos2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvConceptos2.Size = New System.Drawing.Size(350, 245)
            Me.dgvConceptos2.TabIndex = 7
            '
            'DataGridViewCheckBoxColumn1
            '
            Me.DataGridViewCheckBoxColumn1.HeaderText = "ok"
            Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
            Me.DataGridViewCheckBoxColumn1.Visible = False
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "tic_TipoConcep_Id"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            Me.DataGridViewTextBoxColumn1.Visible = False
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "con_Conceptos_Id"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.ReadOnly = True
            Me.DataGridViewTextBoxColumn2.Visible = False
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.HeaderText = "Orden"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.HeaderText = "Concepto"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            Me.DataGridViewTextBoxColumn4.Width = 110
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.HeaderText = "Descripcion"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.ReadOnly = True
            Me.DataGridViewTextBoxColumn5.Width = 200
            '
            'dgvConceptos
            '
            Me.dgvConceptos.AllowUserToAddRows = False
            Me.dgvConceptos.AllowUserToDeleteRows = False
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvConceptos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
            Me.dgvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvConceptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ok, Me.tic_TipoConcep_Id, Me.con_Conceptos_Id, Me.Orden, Me.Concepto, Me.Descripcion})
            Me.dgvConceptos.Location = New System.Drawing.Point(11, 29)
            Me.dgvConceptos.Name = "dgvConceptos"
            Me.dgvConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvConceptos.Size = New System.Drawing.Size(315, 248)
            Me.dgvConceptos.TabIndex = 6
            '
            'ok
            '
            Me.ok.HeaderText = "ok"
            Me.ok.Name = "ok"
            Me.ok.Visible = False
            '
            'tic_TipoConcep_Id
            '
            Me.tic_TipoConcep_Id.HeaderText = "tic_TipoConcep_Id"
            Me.tic_TipoConcep_Id.Name = "tic_TipoConcep_Id"
            Me.tic_TipoConcep_Id.Visible = False
            '
            'con_Conceptos_Id
            '
            Me.con_Conceptos_Id.HeaderText = "con_Conceptos_Id"
            Me.con_Conceptos_Id.Name = "con_Conceptos_Id"
            Me.con_Conceptos_Id.Visible = False
            '
            'Orden
            '
            Me.Orden.HeaderText = "Orden"
            Me.Orden.Name = "Orden"
            Me.Orden.Visible = False
            '
            'Concepto
            '
            Me.Concepto.HeaderText = "Concepto"
            Me.Concepto.Name = "Concepto"
            Me.Concepto.Width = 110
            '
            'Descripcion
            '
            Me.Descripcion.HeaderText = "Descripcion"
            Me.Descripcion.Name = "Descripcion"
            Me.Descripcion.Width = 200
            '
            'btnImprimir
            '
            Me.btnImprimir.Location = New System.Drawing.Point(621, 307)
            Me.btnImprimir.Name = "btnImprimir"
            Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
            Me.btnImprimir.TabIndex = 5
            Me.btnImprimir.Text = "Imprimir"
            Me.btnImprimir.UseVisualStyleBackColor = True
            '
            'btnLimpiar
            '
            Me.btnLimpiar.Location = New System.Drawing.Point(444, 307)
            Me.btnLimpiar.Name = "btnLimpiar"
            Me.btnLimpiar.Size = New System.Drawing.Size(75, 23)
            Me.btnLimpiar.TabIndex = 4
            Me.btnLimpiar.Text = "Limpiar"
            Me.btnLimpiar.UseVisualStyleBackColor = True
            '
            'btnQuitar
            '
            Me.btnQuitar.Location = New System.Drawing.Point(363, 307)
            Me.btnQuitar.Name = "btnQuitar"
            Me.btnQuitar.Size = New System.Drawing.Size(75, 23)
            Me.btnQuitar.TabIndex = 3
            Me.btnQuitar.Text = "<<Quitar"
            Me.btnQuitar.UseVisualStyleBackColor = True
            '
            'btnPasar
            '
            Me.btnPasar.Location = New System.Drawing.Point(363, 280)
            Me.btnPasar.Name = "btnPasar"
            Me.btnPasar.Size = New System.Drawing.Size(75, 23)
            Me.btnPasar.TabIndex = 2
            Me.btnPasar.Text = "Pasar>>"
            Me.btnPasar.UseVisualStyleBackColor = True
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.HeaderText = "TotalIngreso"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.HeaderText = "totalEgreso"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            Me.DataGridViewTextBoxColumn7.ReadOnly = True
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.HeaderText = "Neto"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.HeaderText = "tic_TipoConcep_Id"
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            Me.DataGridViewTextBoxColumn9.ReadOnly = True
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.HeaderText = "con_Conceptos_Id"
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            Me.DataGridViewTextBoxColumn10.ReadOnly = True
            '
            'DataGridViewTextBoxColumn11
            '
            Me.DataGridViewTextBoxColumn11.HeaderText = "Orden"
            Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
            Me.DataGridViewTextBoxColumn11.ReadOnly = True
            '
            'DataGridViewTextBoxColumn12
            '
            Me.DataGridViewTextBoxColumn12.HeaderText = "Concepto"
            Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
            Me.DataGridViewTextBoxColumn12.ReadOnly = True
            Me.DataGridViewTextBoxColumn12.Width = 110
            '
            'DataGridViewTextBoxColumn13
            '
            Me.DataGridViewTextBoxColumn13.HeaderText = "Descripcion"
            Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
            Me.DataGridViewTextBoxColumn13.ReadOnly = True
            Me.DataGridViewTextBoxColumn13.Width = 200
            '
            'DataGridViewTextBoxColumn14
            '
            Me.DataGridViewTextBoxColumn14.HeaderText = "tic_TipoConcep_Id"
            Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
            '
            'DataGridViewTextBoxColumn15
            '
            Me.DataGridViewTextBoxColumn15.HeaderText = "con_Conceptos_Id"
            Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
            '
            'DataGridViewTextBoxColumn16
            '
            Me.DataGridViewTextBoxColumn16.HeaderText = "Orden"
            Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
            '
            'DataGridViewTextBoxColumn17
            '
            Me.DataGridViewTextBoxColumn17.HeaderText = "Concepto"
            Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
            Me.DataGridViewTextBoxColumn17.Width = 110
            '
            'DataGridViewTextBoxColumn18
            '
            Me.DataGridViewTextBoxColumn18.HeaderText = "Descripcion"
            Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
            Me.DataGridViewTextBoxColumn18.Width = 200
            '
            'frmPlanillasPanelAdministracionDetalle
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(716, 380)
            Me.Controls.Add(Me.Panel1)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmPlanillasPanelAdministracionDetalle"
            Me.Text = "frmPlanillasPanelAdministracionDetalle"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            CType(Me.dgvPersonas2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvConceptos2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvConceptos, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnLimpiar As System.Windows.Forms.Button
        Friend WithEvents btnQuitar As System.Windows.Forms.Button
        Friend WithEvents btnPasar As System.Windows.Forms.Button
        Friend WithEvents btnImprimir As System.Windows.Forms.Button
        Friend WithEvents dgvConceptos2 As System.Windows.Forms.DataGridView
        Friend WithEvents dgvConceptos As System.Windows.Forms.DataGridView
        Friend WithEvents dgvPersonas2 As System.Windows.Forms.DataGridView
        Friend WithEvents Serie As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents per_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TotalIngreso As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents totalEgreso As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Neto As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ok As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents tic_TipoConcep_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents con_Conceptos_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Concepto As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class

End Namespace
