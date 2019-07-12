Namespace Ladisac.Contabilidad.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmAsientosManuales
        Inherits ViewManMasterContabilidad

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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.txtResta = New System.Windows.Forms.TextBox()
            Me.txtAbono = New System.Windows.Forms.TextBox()
            Me.txtCArgo = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.cuc_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.DescripcionCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CargoMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AbonoMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CargoME = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AbonoME = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.mon_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cco_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.CentroCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.per_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Persona = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cct_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.cls_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CuentaCorriente = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tdo_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.dtd_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dam_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tdo_IdRef = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.dtd_IdRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TipoDocumentoRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.SerieRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.NumeroRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ItemRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtPeriodo = New System.Windows.Forms.TextBox()
            Me.btnPeriodo = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtLibro = New System.Windows.Forms.TextBox()
            Me.btnLibroContable = New System.Windows.Forms.Button()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.dateFecha = New System.Windows.Forms.DateTimePicker()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtGlosa = New System.Windows.Forms.TextBox()
            Me.btnImportar = New System.Windows.Forms.Button()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Panel1.SuspendLayout()
            Me.Panel3.SuspendLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(799, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.Panel3)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(792, 360)
            Me.Panel1.TabIndex = 2
            '
            'Panel3
            '
            Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.txtResta)
            Me.Panel3.Controls.Add(Me.txtAbono)
            Me.Panel3.Controls.Add(Me.txtCArgo)
            Me.Panel3.Controls.Add(Me.Label6)
            Me.Panel3.Controls.Add(Me.Label5)
            Me.Panel3.Location = New System.Drawing.Point(9, 327)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(776, 30)
            Me.Panel3.TabIndex = 2
            '
            'txtResta
            '
            Me.txtResta.ForeColor = System.Drawing.Color.Red
            Me.txtResta.Location = New System.Drawing.Point(671, 3)
            Me.txtResta.Name = "txtResta"
            Me.txtResta.ReadOnly = True
            Me.txtResta.Size = New System.Drawing.Size(100, 20)
            Me.txtResta.TabIndex = 4
            '
            'txtAbono
            '
            Me.txtAbono.Location = New System.Drawing.Point(546, 4)
            Me.txtAbono.Name = "txtAbono"
            Me.txtAbono.ReadOnly = True
            Me.txtAbono.Size = New System.Drawing.Size(100, 20)
            Me.txtAbono.TabIndex = 3
            '
            'txtCArgo
            '
            Me.txtCArgo.Location = New System.Drawing.Point(396, 5)
            Me.txtCArgo.Name = "txtCArgo"
            Me.txtCArgo.ReadOnly = True
            Me.txtCArgo.Size = New System.Drawing.Size(100, 20)
            Me.txtCArgo.TabIndex = 2
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(355, 7)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(35, 13)
            Me.Label6.TabIndex = 1
            Me.Label6.Text = "Cargo"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(502, 8)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(38, 13)
            Me.Label5.TabIndex = 0
            Me.Label5.Text = "Abono"
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cuc_Id, Me.DescripcionCuenta, Me.CargoMN, Me.AbonoMN, Me.CargoME, Me.AbonoME, Me.mon_Id, Me.Moneda, Me.cco_Id, Me.CentroCosto, Me.per_Id, Me.Persona, Me.cct_Id, Me.cls_Id, Me.CuentaCorriente, Me.tdo_Id, Me.dtd_Id, Me.TipoDocumento, Me.Serie, Me.Numero, Me.Item, Me.dam_Item, Me.tdo_IdRef, Me.dtd_IdRef, Me.TipoDocumentoRef, Me.SerieRef, Me.NumeroRef, Me.ItemRef})
            Me.dgvDetalle.Location = New System.Drawing.Point(9, 106)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(775, 219)
            Me.dgvDetalle.TabIndex = 1
            '
            'cuc_Id
            '
            Me.cuc_Id.HeaderText = "cuc_Id"
            Me.cuc_Id.Name = "cuc_Id"
            Me.cuc_Id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cuc_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'DescripcionCuenta
            '
            Me.DescripcionCuenta.HeaderText = "DescripcionCuenta"
            Me.DescripcionCuenta.Name = "DescripcionCuenta"
            '
            'CargoMN
            '
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle1.Format = "N2"
            DataGridViewCellStyle1.NullValue = Nothing
            Me.CargoMN.DefaultCellStyle = DataGridViewCellStyle1
            Me.CargoMN.HeaderText = "CargoMN"
            Me.CargoMN.Name = "CargoMN"
            '
            'AbonoMN
            '
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle2.Format = "N2"
            DataGridViewCellStyle2.NullValue = Nothing
            Me.AbonoMN.DefaultCellStyle = DataGridViewCellStyle2
            Me.AbonoMN.HeaderText = "AbonoMN"
            Me.AbonoMN.Name = "AbonoMN"
            '
            'CargoME
            '
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.Format = "N2"
            DataGridViewCellStyle3.NullValue = Nothing
            Me.CargoME.DefaultCellStyle = DataGridViewCellStyle3
            Me.CargoME.HeaderText = "CargoME"
            Me.CargoME.Name = "CargoME"
            '
            'AbonoME
            '
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle4.Format = "N2"
            DataGridViewCellStyle4.NullValue = Nothing
            Me.AbonoME.DefaultCellStyle = DataGridViewCellStyle4
            Me.AbonoME.HeaderText = "AbonoME"
            Me.AbonoME.Name = "AbonoME"
            '
            'mon_Id
            '
            Me.mon_Id.HeaderText = "mon_Id"
            Me.mon_Id.Name = "mon_Id"
            Me.mon_Id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.mon_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'Moneda
            '
            Me.Moneda.HeaderText = "Moneda"
            Me.Moneda.Name = "Moneda"
            '
            'cco_Id
            '
            Me.cco_Id.HeaderText = "cco_Id"
            Me.cco_Id.Name = "cco_Id"
            Me.cco_Id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cco_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'CentroCosto
            '
            Me.CentroCosto.HeaderText = "CentroCosto"
            Me.CentroCosto.Name = "CentroCosto"
            '
            'per_Id
            '
            Me.per_Id.HeaderText = "per_Id"
            Me.per_Id.Name = "per_Id"
            Me.per_Id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.per_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'Persona
            '
            Me.Persona.HeaderText = "Persona"
            Me.Persona.Name = "Persona"
            '
            'cct_Id
            '
            Me.cct_Id.HeaderText = "cct_Id"
            Me.cct_Id.Name = "cct_Id"
            Me.cct_Id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.cct_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'cls_Id
            '
            Me.cls_Id.HeaderText = "cls_Id"
            Me.cls_Id.Name = "cls_Id"
            Me.cls_Id.Visible = False
            '
            'CuentaCorriente
            '
            Me.CuentaCorriente.HeaderText = "CuentaCorriente"
            Me.CuentaCorriente.Name = "CuentaCorriente"
            '
            'tdo_Id
            '
            Me.tdo_Id.HeaderText = "tdo_Id"
            Me.tdo_Id.Name = "tdo_Id"
            Me.tdo_Id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.tdo_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dtd_Id
            '
            Me.dtd_Id.HeaderText = "dtd_Id"
            Me.dtd_Id.Name = "dtd_Id"
            Me.dtd_Id.Visible = False
            '
            'TipoDocumento
            '
            Me.TipoDocumento.HeaderText = "TipoDocumento"
            Me.TipoDocumento.Name = "TipoDocumento"
            '
            'Serie
            '
            Me.Serie.HeaderText = "Serie"
            Me.Serie.Name = "Serie"
            '
            'Numero
            '
            Me.Numero.HeaderText = "Numero"
            Me.Numero.Name = "Numero"
            '
            'Item
            '
            Me.Item.HeaderText = "Item"
            Me.Item.Name = "Item"
            '
            'dam_Item
            '
            Me.dam_Item.HeaderText = "dam_Item"
            Me.dam_Item.Name = "dam_Item"
            Me.dam_Item.Visible = False
            '
            'tdo_IdRef
            '
            Me.tdo_IdRef.HeaderText = "tdo_IdRef"
            Me.tdo_IdRef.Name = "tdo_IdRef"
            Me.tdo_IdRef.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.tdo_IdRef.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dtd_IdRef
            '
            Me.dtd_IdRef.HeaderText = "dtd_IdRef"
            Me.dtd_IdRef.Name = "dtd_IdRef"
            Me.dtd_IdRef.Visible = False
            '
            'TipoDocumentoRef
            '
            Me.TipoDocumentoRef.HeaderText = "TipoDocumentoRef"
            Me.TipoDocumentoRef.Name = "TipoDocumentoRef"
            '
            'SerieRef
            '
            Me.SerieRef.HeaderText = "SerieRef"
            Me.SerieRef.Name = "SerieRef"
            '
            'NumeroRef
            '
            Me.NumeroRef.HeaderText = "NumeroRef"
            Me.NumeroRef.Name = "NumeroRef"
            '
            'ItemRef
            '
            Me.ItemRef.HeaderText = "ItemRef"
            Me.ItemRef.Name = "ItemRef"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(40, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(43, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Periodo"
            '
            'txtPeriodo
            '
            Me.txtPeriodo.Location = New System.Drawing.Point(87, 7)
            Me.txtPeriodo.Name = "txtPeriodo"
            Me.txtPeriodo.ReadOnly = True
            Me.txtPeriodo.Size = New System.Drawing.Size(67, 20)
            Me.txtPeriodo.TabIndex = 1
            '
            'btnPeriodo
            '
            Me.btnPeriodo.Location = New System.Drawing.Point(157, 5)
            Me.btnPeriodo.Name = "btnPeriodo"
            Me.btnPeriodo.Size = New System.Drawing.Size(24, 23)
            Me.btnPeriodo.TabIndex = 2
            Me.btnPeriodo.Text = ":::"
            Me.btnPeriodo.UseVisualStyleBackColor = True
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(8, 33)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(75, 13)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Libro Contable"
            '
            'txtLibro
            '
            Me.txtLibro.Location = New System.Drawing.Point(87, 29)
            Me.txtLibro.Name = "txtLibro"
            Me.txtLibro.ReadOnly = True
            Me.txtLibro.Size = New System.Drawing.Size(133, 20)
            Me.txtLibro.TabIndex = 4
            '
            'btnLibroContable
            '
            Me.btnLibroContable.Location = New System.Drawing.Point(224, 27)
            Me.btnLibroContable.Name = "btnLibroContable"
            Me.btnLibroContable.Size = New System.Drawing.Size(25, 23)
            Me.btnLibroContable.TabIndex = 5
            Me.btnLibroContable.Text = ":::"
            Me.btnLibroContable.UseVisualStyleBackColor = True
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(255, 29)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.Size = New System.Drawing.Size(100, 20)
            Me.txtNumero.TabIndex = 6
            '
            'dateFecha
            '
            Me.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateFecha.Location = New System.Drawing.Point(459, 7)
            Me.dateFecha.Name = "dateFecha"
            Me.dateFecha.Size = New System.Drawing.Size(87, 20)
            Me.dateFecha.TabIndex = 7
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(417, 10)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(37, 13)
            Me.Label3.TabIndex = 8
            Me.Label3.Text = "Fecha"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(49, 55)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(34, 13)
            Me.Label4.TabIndex = 9
            Me.Label4.Text = "Glosa"
            '
            'txtGlosa
            '
            Me.txtGlosa.Location = New System.Drawing.Point(87, 51)
            Me.txtGlosa.Name = "txtGlosa"
            Me.txtGlosa.Size = New System.Drawing.Size(459, 20)
            Me.txtGlosa.TabIndex = 10
            '
            'btnImportar
            '
            Me.btnImportar.Location = New System.Drawing.Point(685, 50)
            Me.btnImportar.Name = "btnImportar"
            Me.btnImportar.Size = New System.Drawing.Size(61, 23)
            Me.btnImportar.TabIndex = 12
            Me.btnImportar.Text = "Importar"
            Me.btnImportar.UseVisualStyleBackColor = True
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.btnImportar)
            Me.Panel2.Controls.Add(Me.txtGlosa)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.dateFecha)
            Me.Panel2.Controls.Add(Me.txtNumero)
            Me.Panel2.Controls.Add(Me.btnLibroContable)
            Me.Panel2.Controls.Add(Me.txtLibro)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.btnPeriodo)
            Me.Panel2.Controls.Add(Me.txtPeriodo)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Location = New System.Drawing.Point(9, 13)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(776, 91)
            Me.Panel2.TabIndex = 0
            '
            'frmAsientosManuales
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(799, 422)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmAsientosManuales"
            Me.Text = " "
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents txtAbono As System.Windows.Forms.TextBox
        Friend WithEvents txtCArgo As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cuc_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents DescripcionCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CargoMN As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents AbonoMN As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CargoME As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents AbonoME As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents mon_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cco_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents CentroCosto As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents per_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Persona As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cct_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents cls_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CuentaCorriente As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tdo_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents dtd_Id As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TipoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Serie As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dam_Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tdo_IdRef As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents dtd_IdRef As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TipoDocumentoRef As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents SerieRef As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents NumeroRef As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ItemRef As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents txtResta As System.Windows.Forms.TextBox
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents btnImportar As System.Windows.Forms.Button
        Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents dateFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents btnLibroContable As System.Windows.Forms.Button
        Friend WithEvents txtLibro As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnPeriodo As System.Windows.Forms.Button
        Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
    End Class

End Namespace