Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmGrupoTrabajoHoraClonar
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
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.dgt_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.per_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Persona = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pro_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Produccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Pla_id = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.art_AreaTrab_Id = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.tit_TipTarea_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ttr_TareaTrab_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Tarea = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Factor = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_HoraDesde = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_HoraHasta = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_NumPersonas = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_CantidadLadrillo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Mesas = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Alas = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Fraccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Refrigerio = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Bonificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_HoraTotales = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgt_Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.btnAplicar = New System.Windows.Forms.Button()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.ControlFiltroTrareaHoras1 = New Ladisac.Planillas.Views.ControlFiltroTrareaHoras()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(1244, 28)
            Me.lblTitle.Text = ""
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgt_Item, Me.per_Id, Me.Codigo, Me.Persona, Me.pro_Id, Me.Produccion, Me.Descripcion, Me.Pla_id, Me.art_AreaTrab_Id, Me.tit_TipTarea_Id, Me.ttr_TareaTrab_Id, Me.Tarea, Me.dgt_Factor, Me.dgt_HoraDesde, Me.dgt_HoraHasta, Me.dgt_NumPersonas, Me.dgt_CantidadLadrillo, Me.dgt_Mesas, Me.dgt_Alas, Me.dgt_Fraccion, Me.dgt_Refrigerio, Me.dgt_Bonificacion, Me.dgt_Descuento, Me.dgt_HoraTotales, Me.dgt_Observaciones})
            Me.dgvDetalle.Location = New System.Drawing.Point(4, 31)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.RowTemplate.Height = 20
            Me.dgvDetalle.Size = New System.Drawing.Size(1231, 168)
            Me.dgvDetalle.TabIndex = 125
            '
            'dgt_Item
            '
            Me.dgt_Item.HeaderText = "dgt_Item"
            Me.dgt_Item.Name = "dgt_Item"
            Me.dgt_Item.ReadOnly = True
            Me.dgt_Item.Width = 40
            '
            'per_Id
            '
            Me.per_Id.HeaderText = "per"
            Me.per_Id.Name = "per_Id"
            Me.per_Id.Width = 30
            '
            'Codigo
            '
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
            DataGridViewCellStyle11.NullValue = Nothing
            Me.Codigo.DefaultCellStyle = DataGridViewCellStyle11
            Me.Codigo.HeaderText = "Codigo"
            Me.Codigo.Name = "Codigo"
            Me.Codigo.Width = 50
            '
            'Persona
            '
            Me.Persona.HeaderText = "Persona"
            Me.Persona.Name = "Persona"
            Me.Persona.ReadOnly = True
            Me.Persona.Width = 150
            '
            'pro_Id
            '
            Me.pro_Id.HeaderText = "Prod"
            Me.pro_Id.Name = "pro_Id"
            Me.pro_Id.Width = 30
            '
            'Produccion
            '
            Me.Produccion.HeaderText = "Produccion"
            Me.Produccion.Name = "Produccion"
            Me.Produccion.ReadOnly = True
            Me.Produccion.Width = 50
            '
            'Descripcion
            '
            Me.Descripcion.HeaderText = "Descripcion"
            Me.Descripcion.Name = "Descripcion"
            Me.Descripcion.ReadOnly = True
            Me.Descripcion.Width = 50
            '
            'Pla_id
            '
            Me.Pla_id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
            Me.Pla_id.HeaderText = "Pla_id"
            Me.Pla_id.Name = "Pla_id"
            Me.Pla_id.Width = 30
            '
            'art_AreaTrab_Id
            '
            Me.art_AreaTrab_Id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
            Me.art_AreaTrab_Id.HeaderText = "AreaTrab"
            Me.art_AreaTrab_Id.Name = "art_AreaTrab_Id"
            Me.art_AreaTrab_Id.Width = 60
            '
            'tit_TipTarea_Id
            '
            Me.tit_TipTarea_Id.HeaderText = "TipTarea"
            Me.tit_TipTarea_Id.Name = "tit_TipTarea_Id"
            Me.tit_TipTarea_Id.Visible = False
            Me.tit_TipTarea_Id.Width = 50
            '
            'ttr_TareaTrab_Id
            '
            Me.ttr_TareaTrab_Id.HeaderText = "TareaTrab"
            Me.ttr_TareaTrab_Id.Name = "ttr_TareaTrab_Id"
            Me.ttr_TareaTrab_Id.Width = 30
            '
            'Tarea
            '
            Me.Tarea.HeaderText = "Tarea"
            Me.Tarea.Name = "Tarea"
            Me.Tarea.ReadOnly = True
            Me.Tarea.Width = 50
            '
            'dgt_Factor
            '
            Me.dgt_Factor.HeaderText = "Factor"
            Me.dgt_Factor.Name = "dgt_Factor"
            Me.dgt_Factor.ReadOnly = True
            Me.dgt_Factor.Width = 50
            '
            'dgt_HoraDesde
            '
            DataGridViewCellStyle12.NullValue = Nothing
            Me.dgt_HoraDesde.DefaultCellStyle = DataGridViewCellStyle12
            Me.dgt_HoraDesde.HeaderText = "HoraDesde"
            Me.dgt_HoraDesde.Name = "dgt_HoraDesde"
            Me.dgt_HoraDesde.Width = 50
            '
            'dgt_HoraHasta
            '
            Me.dgt_HoraHasta.HeaderText = "HoraHasta"
            Me.dgt_HoraHasta.Name = "dgt_HoraHasta"
            Me.dgt_HoraHasta.Width = 50
            '
            'dgt_NumPersonas
            '
            Me.dgt_NumPersonas.HeaderText = "NumPersonas"
            Me.dgt_NumPersonas.Name = "dgt_NumPersonas"
            Me.dgt_NumPersonas.Width = 50
            '
            'dgt_CantidadLadrillo
            '
            Me.dgt_CantidadLadrillo.HeaderText = "Cant.Ladrillo"
            Me.dgt_CantidadLadrillo.Name = "dgt_CantidadLadrillo"
            Me.dgt_CantidadLadrillo.Width = 50
            '
            'dgt_Mesas
            '
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.Lime
            Me.dgt_Mesas.DefaultCellStyle = DataGridViewCellStyle13
            Me.dgt_Mesas.HeaderText = "Mesas"
            Me.dgt_Mesas.Name = "dgt_Mesas"
            Me.dgt_Mesas.Width = 50
            '
            'dgt_Alas
            '
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.Lime
            Me.dgt_Alas.DefaultCellStyle = DataGridViewCellStyle14
            Me.dgt_Alas.HeaderText = "Alas"
            Me.dgt_Alas.Name = "dgt_Alas"
            Me.dgt_Alas.Width = 50
            '
            'dgt_Fraccion
            '
            Me.dgt_Fraccion.HeaderText = "Fraccion"
            Me.dgt_Fraccion.Name = "dgt_Fraccion"
            Me.dgt_Fraccion.Width = 50
            '
            'dgt_Refrigerio
            '
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.dgt_Refrigerio.DefaultCellStyle = DataGridViewCellStyle15
            Me.dgt_Refrigerio.HeaderText = "Refrigerio"
            Me.dgt_Refrigerio.Name = "dgt_Refrigerio"
            Me.dgt_Refrigerio.Width = 50
            '
            'dgt_Bonificacion
            '
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.dgt_Bonificacion.DefaultCellStyle = DataGridViewCellStyle16
            Me.dgt_Bonificacion.HeaderText = "Bonificacion"
            Me.dgt_Bonificacion.Name = "dgt_Bonificacion"
            Me.dgt_Bonificacion.Width = 50
            '
            'dgt_Descuento
            '
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.Red
            Me.dgt_Descuento.DefaultCellStyle = DataGridViewCellStyle17
            Me.dgt_Descuento.HeaderText = "Descuento"
            Me.dgt_Descuento.Name = "dgt_Descuento"
            '
            'dgt_HoraTotales
            '
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.dgt_HoraTotales.DefaultCellStyle = DataGridViewCellStyle18
            Me.dgt_HoraTotales.HeaderText = "HotaTotales"
            Me.dgt_HoraTotales.Name = "dgt_HoraTotales"
            Me.dgt_HoraTotales.ReadOnly = True
            Me.dgt_HoraTotales.Width = 50
            '
            'dgt_Observaciones
            '
            Me.dgt_Observaciones.HeaderText = "Observaciones"
            Me.dgt_Observaciones.Name = "dgt_Observaciones"
            Me.dgt_Observaciones.Width = 50
            '
            'btnAplicar
            '
            Me.btnAplicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnAplicar.Location = New System.Drawing.Point(31, 372)
            Me.btnAplicar.Name = "btnAplicar"
            Me.btnAplicar.Size = New System.Drawing.Size(75, 23)
            Me.btnAplicar.TabIndex = 127
            Me.btnAplicar.Text = "Aplicar Filtro"
            Me.btnAplicar.UseVisualStyleBackColor = True
            '
            'Button1
            '
            Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Button1.Location = New System.Drawing.Point(31, 343)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(75, 23)
            Me.Button1.TabIndex = 128
            Me.Button1.Text = "Copar Filas"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'ControlFiltroTrareaHoras1
            '
            Me.ControlFiltroTrareaHoras1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ControlFiltroTrareaHoras1.Location = New System.Drawing.Point(7, 201)
            Me.ControlFiltroTrareaHoras1.Name = "ControlFiltroTrareaHoras1"
            Me.ControlFiltroTrareaHoras1.Size = New System.Drawing.Size(1237, 205)
            Me.ControlFiltroTrareaHoras1.TabIndex = 126
            '
            'frmGrupoTrabajoHoraClonar
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1244, 407)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.btnAplicar)
            Me.Controls.Add(Me.ControlFiltroTrareaHoras1)
            Me.Controls.Add(Me.dgvDetalle)
            Me.Name = "frmGrupoTrabajoHoraClonar"
            Me.Text = "Grupo Trabajo x Hora Clonar"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
            Me.Controls.SetChildIndex(Me.ControlFiltroTrareaHoras1, 0)
            Me.Controls.SetChildIndex(Me.btnAplicar, 0)
            Me.Controls.SetChildIndex(Me.Button1, 0)
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ControlFiltroTrareaHoras1 As Ladisac.Planillas.Views.ControlFiltroTrareaHoras
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents dgt_Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents per_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Persona As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents pro_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Produccion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Pla_id As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents art_AreaTrab_Id As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents tit_TipTarea_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ttr_TareaTrab_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Tarea As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Factor As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_HoraDesde As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_HoraHasta As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_NumPersonas As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_CantidadLadrillo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Mesas As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Alas As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Fraccion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Refrigerio As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Bonificacion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Descuento As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_HoraTotales As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgt_Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents btnAplicar As System.Windows.Forms.Button
        Friend WithEvents Button1 As System.Windows.Forms.Button
    End Class

End Namespace
