Namespace Ladisac.Planillas.Views


    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmTrabajadorHoras
        Inherits ViewManMasterPlanillas
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
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.txtHoraEssalud = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.txtSumaHoraDobTotalExtra = New System.Windows.Forms.TextBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.txtHoraSimTotalExtra = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtSumaBonificacion = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.chkLista = New System.Windows.Forms.CheckedListBox()
            Me.chkImportarEmpleado = New System.Windows.Forms.RadioButton()
            Me.chkImportarMantenimiento = New System.Windows.Forms.RadioButton()
            Me.chkEsdeProduccion = New System.Windows.Forms.RadioButton()
            Me.btnExportarExcel = New System.Windows.Forms.Button()
            Me.txtCodigo = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnImportarDeGrupoTrabajo = New System.Windows.Forms.Button()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.btnPLantillaExcel = New System.Windows.Forms.Button()
            Me.btnImportar = New System.Windows.Forms.Button()
            Me.chkEsdeExcel = New System.Windows.Forms.CheckBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtCodigoBusqueda = New System.Windows.Forms.TextBox()
            Me.txtNombre = New System.Windows.Forms.TextBox()
            Me.txtNumeroRegistros = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.dgvHoraXTrabajador = New System.Windows.Forms.DataGridView()
            Me.dgvDetalle = New System.Windows.Forms.DataGridView()
            Me.trh_Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.per_Id = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Persona = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraSimpProduccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraDobleProduccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraBonificadaProduccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraSimpProduccionDestajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraDobleProduccionDestajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraSimCambios = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraDobCambios = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraBonificadaCambios = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraSimCambiosDestajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraDobCambiosDestajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraSimReparoHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraSimReparoDia = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_horaDobReparo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraEssalud = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraSimTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraDobTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_DiasTrabajador = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_DiasTrabajadorXHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_observacion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_Observacion2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraSimTotalExtra = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraDobTotalExtra = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraBonificadaExtra = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraSimTotalDestajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.trh_HoraDobTotalDestajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.ObtenerDaHorasDeEstaPersonaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.chkBloquear = New System.Windows.Forms.CheckBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dateHasta = New System.Windows.Forms.DateTimePicker()
            Me.dateDesde = New System.Windows.Forms.DateTimePicker()
            Me.txtObservaciones = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtNumero = New System.Windows.Forms.TextBox()
            Me.cboTipoTrabajador = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.Panel1.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.Panel4.SuspendLayout()
            CType(Me.dgvHoraXTrabajador, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ContextMenuStrip1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(1012, 28)
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.txtHoraEssalud)
            Me.Panel1.Controls.Add(Me.Label12)
            Me.Panel1.Controls.Add(Me.txtSumaHoraDobTotalExtra)
            Me.Panel1.Controls.Add(Me.Label11)
            Me.Panel1.Controls.Add(Me.txtHoraSimTotalExtra)
            Me.Panel1.Controls.Add(Me.Label10)
            Me.Panel1.Controls.Add(Me.txtSumaBonificacion)
            Me.Panel1.Controls.Add(Me.Label9)
            Me.Panel1.Controls.Add(Me.Label8)
            Me.Panel1.Controls.Add(Me.Panel3)
            Me.Panel1.Controls.Add(Me.Label7)
            Me.Panel1.Controls.Add(Me.txtCodigoBusqueda)
            Me.Panel1.Controls.Add(Me.txtNombre)
            Me.Panel1.Controls.Add(Me.txtNumeroRegistros)
            Me.Panel1.Controls.Add(Me.Label6)
            Me.Panel1.Controls.Add(Me.dgvHoraXTrabajador)
            Me.Panel1.Controls.Add(Me.dgvDetalle)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1003, 481)
            Me.Panel1.TabIndex = 2
            '
            'txtHoraEssalud
            '
            Me.txtHoraEssalud.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtHoraEssalud.Location = New System.Drawing.Point(648, 362)
            Me.txtHoraEssalud.Name = "txtHoraEssalud"
            Me.txtHoraEssalud.ReadOnly = True
            Me.txtHoraEssalud.Size = New System.Drawing.Size(53, 20)
            Me.txtHoraEssalud.TabIndex = 19
            '
            'Label12
            '
            Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(605, 366)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(44, 13)
            Me.Label12.TabIndex = 18
            Me.Label12.Text = "Essalud"
            '
            'txtSumaHoraDobTotalExtra
            '
            Me.txtSumaHoraDobTotalExtra.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtSumaHoraDobTotalExtra.Location = New System.Drawing.Point(893, 362)
            Me.txtSumaHoraDobTotalExtra.Name = "txtSumaHoraDobTotalExtra"
            Me.txtSumaHoraDobTotalExtra.ReadOnly = True
            Me.txtSumaHoraDobTotalExtra.Size = New System.Drawing.Size(72, 20)
            Me.txtSumaHoraDobTotalExtra.TabIndex = 17
            '
            'Label11
            '
            Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(832, 365)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(61, 13)
            Me.Label11.TabIndex = 16
            Me.Label11.Text = "Hora Doble"
            '
            'txtHoraSimTotalExtra
            '
            Me.txtHoraSimTotalExtra.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtHoraSimTotalExtra.Location = New System.Drawing.Point(766, 362)
            Me.txtHoraSimTotalExtra.Name = "txtHoraSimTotalExtra"
            Me.txtHoraSimTotalExtra.ReadOnly = True
            Me.txtHoraSimTotalExtra.Size = New System.Drawing.Size(63, 20)
            Me.txtHoraSimTotalExtra.TabIndex = 15
            '
            'Label10
            '
            Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(703, 365)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(64, 13)
            Me.Label10.TabIndex = 14
            Me.Label10.Text = "Hora Simple"
            '
            'txtSumaBonificacion
            '
            Me.txtSumaBonificacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtSumaBonificacion.Location = New System.Drawing.Point(550, 362)
            Me.txtSumaBonificacion.Name = "txtSumaBonificacion"
            Me.txtSumaBonificacion.ReadOnly = True
            Me.txtSumaBonificacion.Size = New System.Drawing.Size(53, 20)
            Me.txtSumaBonificacion.TabIndex = 13
            '
            'Label9
            '
            Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(487, 365)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(65, 13)
            Me.Label9.TabIndex = 12
            Me.Label9.Text = "Bonificacion"
            '
            'Label8
            '
            Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(3, 465)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(192, 13)
            Me.Label8.TabIndex = 11
            Me.Label8.Text = "Doble click para ver los datos laborales"
            '
            'Panel3
            '
            Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.chkLista)
            Me.Panel3.Controls.Add(Me.chkImportarEmpleado)
            Me.Panel3.Controls.Add(Me.chkImportarMantenimiento)
            Me.Panel3.Controls.Add(Me.chkEsdeProduccion)
            Me.Panel3.Controls.Add(Me.btnExportarExcel)
            Me.Panel3.Controls.Add(Me.txtCodigo)
            Me.Panel3.Controls.Add(Me.Label5)
            Me.Panel3.Controls.Add(Me.btnImportarDeGrupoTrabajo)
            Me.Panel3.Controls.Add(Me.Panel4)
            Me.Panel3.Controls.Add(Me.chkEsdeExcel)
            Me.Panel3.Location = New System.Drawing.Point(5, 63)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(994, 58)
            Me.Panel3.TabIndex = 10
            '
            'chkLista
            '
            Me.chkLista.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkLista.FormattingEnabled = True
            Me.chkLista.Location = New System.Drawing.Point(831, 2)
            Me.chkLista.Name = "chkLista"
            Me.chkLista.Size = New System.Drawing.Size(158, 49)
            Me.chkLista.TabIndex = 25
            '
            'chkImportarEmpleado
            '
            Me.chkImportarEmpleado.AutoSize = True
            Me.chkImportarEmpleado.Location = New System.Drawing.Point(265, 8)
            Me.chkImportarEmpleado.Name = "chkImportarEmpleado"
            Me.chkImportarEmpleado.Size = New System.Drawing.Size(110, 17)
            Me.chkImportarEmpleado.TabIndex = 24
            Me.chkImportarEmpleado.TabStop = True
            Me.chkImportarEmpleado.Text = "Importe Empleado"
            Me.chkImportarEmpleado.UseVisualStyleBackColor = True
            '
            'chkImportarMantenimiento
            '
            Me.chkImportarMantenimiento.AutoSize = True
            Me.chkImportarMantenimiento.Location = New System.Drawing.Point(130, 8)
            Me.chkImportarMantenimiento.Name = "chkImportarMantenimiento"
            Me.chkImportarMantenimiento.Size = New System.Drawing.Size(135, 17)
            Me.chkImportarMantenimiento.TabIndex = 23
            Me.chkImportarMantenimiento.TabStop = True
            Me.chkImportarMantenimiento.Text = "Importar Mantenimiento"
            Me.chkImportarMantenimiento.UseVisualStyleBackColor = True
            '
            'chkEsdeProduccion
            '
            Me.chkEsdeProduccion.AutoSize = True
            Me.chkEsdeProduccion.Location = New System.Drawing.Point(12, 8)
            Me.chkEsdeProduccion.Name = "chkEsdeProduccion"
            Me.chkEsdeProduccion.Size = New System.Drawing.Size(120, 17)
            Me.chkEsdeProduccion.TabIndex = 22
            Me.chkEsdeProduccion.TabStop = True
            Me.chkEsdeProduccion.Text = "Importar Produccion"
            Me.chkEsdeProduccion.UseVisualStyleBackColor = True
            '
            'btnExportarExcel
            '
            Me.btnExportarExcel.Location = New System.Drawing.Point(375, 30)
            Me.btnExportarExcel.Name = "btnExportarExcel"
            Me.btnExportarExcel.Size = New System.Drawing.Size(107, 23)
            Me.btnExportarExcel.TabIndex = 21
            Me.btnExportarExcel.Text = "Exportar Excel"
            Me.btnExportarExcel.UseVisualStyleBackColor = True
            '
            'txtCodigo
            '
            Me.txtCodigo.Location = New System.Drawing.Point(89, 33)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
            Me.txtCodigo.TabIndex = 20
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(11, 37)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(76, 13)
            Me.Label5.TabIndex = 19
            Me.Label5.Text = "Buscar Codigo"
            '
            'btnImportarDeGrupoTrabajo
            '
            Me.btnImportarDeGrupoTrabajo.Location = New System.Drawing.Point(375, 6)
            Me.btnImportarDeGrupoTrabajo.Name = "btnImportarDeGrupoTrabajo"
            Me.btnImportarDeGrupoTrabajo.Size = New System.Drawing.Size(107, 23)
            Me.btnImportarDeGrupoTrabajo.TabIndex = 17
            Me.btnImportarDeGrupoTrabajo.Text = "Importar de Grupo"
            Me.btnImportarDeGrupoTrabajo.UseVisualStyleBackColor = True
            Me.btnImportarDeGrupoTrabajo.Visible = False
            '
            'Panel4
            '
            Me.Panel4.Controls.Add(Me.btnPLantillaExcel)
            Me.Panel4.Controls.Add(Me.btnImportar)
            Me.Panel4.Location = New System.Drawing.Point(488, 29)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(181, 24)
            Me.Panel4.TabIndex = 16
            Me.Panel4.Visible = False
            '
            'btnPLantillaExcel
            '
            Me.btnPLantillaExcel.Location = New System.Drawing.Point(94, 1)
            Me.btnPLantillaExcel.Name = "btnPLantillaExcel"
            Me.btnPLantillaExcel.Size = New System.Drawing.Size(82, 23)
            Me.btnPLantillaExcel.TabIndex = 14
            Me.btnPLantillaExcel.Text = "Plantilla Excel"
            Me.btnPLantillaExcel.UseVisualStyleBackColor = True
            '
            'btnImportar
            '
            Me.btnImportar.Location = New System.Drawing.Point(4, 1)
            Me.btnImportar.Name = "btnImportar"
            Me.btnImportar.Size = New System.Drawing.Size(84, 23)
            Me.btnImportar.TabIndex = 13
            Me.btnImportar.Text = "Importar Excel"
            Me.btnImportar.UseVisualStyleBackColor = True
            '
            'chkEsdeExcel
            '
            Me.chkEsdeExcel.AutoSize = True
            Me.chkEsdeExcel.Location = New System.Drawing.Point(488, 10)
            Me.chkEsdeExcel.Name = "chkEsdeExcel"
            Me.chkEsdeExcel.Size = New System.Drawing.Size(108, 17)
            Me.chkEsdeExcel.TabIndex = 15
            Me.chkEsdeExcel.Text = "Importar de Excel"
            Me.chkEsdeExcel.UseVisualStyleBackColor = True
            '
            'Label7
            '
            Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(3, 366)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(82, 13)
            Me.Label7.TabIndex = 7
            Me.Label7.Text = "Codigo/Nombre"
            '
            'txtCodigoBusqueda
            '
            Me.txtCodigoBusqueda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtCodigoBusqueda.Location = New System.Drawing.Point(88, 362)
            Me.txtCodigoBusqueda.Name = "txtCodigoBusqueda"
            Me.txtCodigoBusqueda.ReadOnly = True
            Me.txtCodigoBusqueda.Size = New System.Drawing.Size(46, 20)
            Me.txtCodigoBusqueda.TabIndex = 6
            '
            'txtNombre
            '
            Me.txtNombre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtNombre.Location = New System.Drawing.Point(136, 362)
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.ReadOnly = True
            Me.txtNombre.Size = New System.Drawing.Size(245, 20)
            Me.txtNombre.TabIndex = 5
            '
            'txtNumeroRegistros
            '
            Me.txtNumeroRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtNumeroRegistros.Location = New System.Drawing.Point(452, 362)
            Me.txtNumeroRegistros.Name = "txtNumeroRegistros"
            Me.txtNumeroRegistros.ReadOnly = True
            Me.txtNumeroRegistros.Size = New System.Drawing.Size(34, 20)
            Me.txtNumeroRegistros.TabIndex = 4
            '
            'Label6
            '
            Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(387, 365)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(66, 13)
            Me.Label6.TabIndex = 3
            Me.Label6.Text = "N° Registros"
            '
            'dgvHoraXTrabajador
            '
            Me.dgvHoraXTrabajador.AllowUserToAddRows = False
            Me.dgvHoraXTrabajador.AllowUserToDeleteRows = False
            Me.dgvHoraXTrabajador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvHoraXTrabajador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvHoraXTrabajador.Location = New System.Drawing.Point(5, 385)
            Me.dgvHoraXTrabajador.Name = "dgvHoraXTrabajador"
            Me.dgvHoraXTrabajador.ReadOnly = True
            Me.dgvHoraXTrabajador.Size = New System.Drawing.Size(991, 78)
            Me.dgvHoraXTrabajador.TabIndex = 2
            '
            'dgvDetalle
            '
            Me.dgvDetalle.AllowUserToAddRows = False
            Me.dgvDetalle.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.dgvDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvDetalle.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.trh_Item, Me.per_Id, Me.Codigo, Me.Persona, Me.trh_HoraSimpProduccion, Me.trh_HoraDobleProduccion, Me.trh_HoraBonificadaProduccion, Me.trh_HoraSimpProduccionDestajo, Me.trh_HoraDobleProduccionDestajo, Me.trh_HoraSimCambios, Me.trh_HoraDobCambios, Me.trh_HoraBonificadaCambios, Me.trh_HoraSimCambiosDestajo, Me.trh_HoraDobCambiosDestajo, Me.trh_HoraSimReparoHora, Me.trh_HoraSimReparoDia, Me.trh_horaDobReparo, Me.trh_HoraEssalud, Me.trh_HoraSimTotal, Me.trh_HoraDobTotal, Me.trh_DiasTrabajador, Me.trh_DiasTrabajadorXHora, Me.trh_observacion1, Me.trh_Observacion2, Me.trh_HoraSimTotalExtra, Me.trh_HoraDobTotalExtra, Me.trh_HoraBonificadaExtra, Me.trh_HoraSimTotalDestajo, Me.trh_HoraDobTotalDestajo})
            Me.dgvDetalle.ContextMenuStrip = Me.ContextMenuStrip1
            Me.dgvDetalle.Location = New System.Drawing.Point(5, 125)
            Me.dgvDetalle.Name = "dgvDetalle"
            Me.dgvDetalle.Size = New System.Drawing.Size(991, 235)
            Me.dgvDetalle.TabIndex = 1
            '
            'trh_Item
            '
            Me.trh_Item.Frozen = True
            Me.trh_Item.HeaderText = "trh_Item"
            Me.trh_Item.Name = "trh_Item"
            Me.trh_Item.Visible = False
            '
            'per_Id
            '
            Me.per_Id.Frozen = True
            Me.per_Id.HeaderText = "per_Id"
            Me.per_Id.Name = "per_Id"
            Me.per_Id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.per_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.per_Id.Width = 20
            '
            'Codigo
            '
            Me.Codigo.Frozen = True
            Me.Codigo.HeaderText = "Codigo"
            Me.Codigo.Name = "Codigo"
            Me.Codigo.ReadOnly = True
            Me.Codigo.Width = 50
            '
            'Persona
            '
            Me.Persona.Frozen = True
            Me.Persona.HeaderText = "Persona"
            Me.Persona.Name = "Persona"
            Me.Persona.ReadOnly = True
            '
            'trh_HoraSimpProduccion
            '
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.trh_HoraSimpProduccion.DefaultCellStyle = DataGridViewCellStyle2
            Me.trh_HoraSimpProduccion.HeaderText = "HoraSimpProduccion"
            Me.trh_HoraSimpProduccion.Name = "trh_HoraSimpProduccion"
            Me.trh_HoraSimpProduccion.ReadOnly = True
            Me.trh_HoraSimpProduccion.Width = 70
            '
            'trh_HoraDobleProduccion
            '
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.trh_HoraDobleProduccion.DefaultCellStyle = DataGridViewCellStyle3
            Me.trh_HoraDobleProduccion.HeaderText = "HoraDobleProduccion"
            Me.trh_HoraDobleProduccion.Name = "trh_HoraDobleProduccion"
            Me.trh_HoraDobleProduccion.ReadOnly = True
            Me.trh_HoraDobleProduccion.Width = 70
            '
            'trh_HoraBonificadaProduccion
            '
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.trh_HoraBonificadaProduccion.DefaultCellStyle = DataGridViewCellStyle4
            Me.trh_HoraBonificadaProduccion.HeaderText = "BonificacionProduccion"
            Me.trh_HoraBonificadaProduccion.Name = "trh_HoraBonificadaProduccion"
            Me.trh_HoraBonificadaProduccion.Width = 70
            '
            'trh_HoraSimpProduccionDestajo
            '
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.trh_HoraSimpProduccionDestajo.DefaultCellStyle = DataGridViewCellStyle5
            Me.trh_HoraSimpProduccionDestajo.HeaderText = "HoraSimpDestajoProduccion"
            Me.trh_HoraSimpProduccionDestajo.Name = "trh_HoraSimpProduccionDestajo"
            Me.trh_HoraSimpProduccionDestajo.Width = 70
            '
            'trh_HoraDobleProduccionDestajo
            '
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.trh_HoraDobleProduccionDestajo.DefaultCellStyle = DataGridViewCellStyle6
            Me.trh_HoraDobleProduccionDestajo.HeaderText = "HoraDbleDestajoProduccion"
            Me.trh_HoraDobleProduccionDestajo.Name = "trh_HoraDobleProduccionDestajo"
            Me.trh_HoraDobleProduccionDestajo.Width = 70
            '
            'trh_HoraSimCambios
            '
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.trh_HoraSimCambios.DefaultCellStyle = DataGridViewCellStyle7
            Me.trh_HoraSimCambios.HeaderText = "HoraSimCambios"
            Me.trh_HoraSimCambios.Name = "trh_HoraSimCambios"
            Me.trh_HoraSimCambios.Width = 70
            '
            'trh_HoraDobCambios
            '
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.trh_HoraDobCambios.DefaultCellStyle = DataGridViewCellStyle8
            Me.trh_HoraDobCambios.HeaderText = "HoraDobCambios"
            Me.trh_HoraDobCambios.Name = "trh_HoraDobCambios"
            Me.trh_HoraDobCambios.Width = 70
            '
            'trh_HoraBonificadaCambios
            '
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.trh_HoraBonificadaCambios.DefaultCellStyle = DataGridViewCellStyle9
            Me.trh_HoraBonificadaCambios.HeaderText = "HoraBonificadaCambios"
            Me.trh_HoraBonificadaCambios.Name = "trh_HoraBonificadaCambios"
            Me.trh_HoraBonificadaCambios.Width = 70
            '
            'trh_HoraSimCambiosDestajo
            '
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.trh_HoraSimCambiosDestajo.DefaultCellStyle = DataGridViewCellStyle10
            Me.trh_HoraSimCambiosDestajo.HeaderText = "HoraSimCambiosDestajo"
            Me.trh_HoraSimCambiosDestajo.Name = "trh_HoraSimCambiosDestajo"
            Me.trh_HoraSimCambiosDestajo.Width = 70
            '
            'trh_HoraDobCambiosDestajo
            '
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.trh_HoraDobCambiosDestajo.DefaultCellStyle = DataGridViewCellStyle11
            Me.trh_HoraDobCambiosDestajo.HeaderText = "HoraDobCambiosDestajo"
            Me.trh_HoraDobCambiosDestajo.Name = "trh_HoraDobCambiosDestajo"
            Me.trh_HoraDobCambiosDestajo.Width = 70
            '
            'trh_HoraSimReparoHora
            '
            Me.trh_HoraSimReparoHora.HeaderText = "HoraSimReparoHora"
            Me.trh_HoraSimReparoHora.Name = "trh_HoraSimReparoHora"
            Me.trh_HoraSimReparoHora.Width = 70
            '
            'trh_HoraSimReparoDia
            '
            Me.trh_HoraSimReparoDia.HeaderText = "HoraSimReparoDia"
            Me.trh_HoraSimReparoDia.Name = "trh_HoraSimReparoDia"
            Me.trh_HoraSimReparoDia.Width = 70
            '
            'trh_horaDobReparo
            '
            Me.trh_horaDobReparo.HeaderText = "horaDobReparo"
            Me.trh_horaDobReparo.Name = "trh_horaDobReparo"
            Me.trh_horaDobReparo.Width = 70
            '
            'trh_HoraEssalud
            '
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.trh_HoraEssalud.DefaultCellStyle = DataGridViewCellStyle12
            Me.trh_HoraEssalud.HeaderText = "HoraEssalud"
            Me.trh_HoraEssalud.Name = "trh_HoraEssalud"
            Me.trh_HoraEssalud.Width = 70
            '
            'trh_HoraSimTotal
            '
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.trh_HoraSimTotal.DefaultCellStyle = DataGridViewCellStyle13
            Me.trh_HoraSimTotal.HeaderText = "HoraSimTotal"
            Me.trh_HoraSimTotal.Name = "trh_HoraSimTotal"
            Me.trh_HoraSimTotal.Width = 70
            '
            'trh_HoraDobTotal
            '
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.trh_HoraDobTotal.DefaultCellStyle = DataGridViewCellStyle14
            Me.trh_HoraDobTotal.HeaderText = "HoraDobTotal"
            Me.trh_HoraDobTotal.Name = "trh_HoraDobTotal"
            Me.trh_HoraDobTotal.Width = 70
            '
            'trh_DiasTrabajador
            '
            Me.trh_DiasTrabajador.HeaderText = "DiasTrabajador"
            Me.trh_DiasTrabajador.Name = "trh_DiasTrabajador"
            Me.trh_DiasTrabajador.Width = 70
            '
            'trh_DiasTrabajadorXHora
            '
            Me.trh_DiasTrabajadorXHora.HeaderText = "DiasTrabajadorXHora"
            Me.trh_DiasTrabajadorXHora.Name = "trh_DiasTrabajadorXHora"
            Me.trh_DiasTrabajadorXHora.Width = 70
            '
            'trh_observacion1
            '
            Me.trh_observacion1.HeaderText = "observacion1"
            Me.trh_observacion1.Name = "trh_observacion1"
            Me.trh_observacion1.Width = 45
            '
            'trh_Observacion2
            '
            Me.trh_Observacion2.HeaderText = "Observacion2"
            Me.trh_Observacion2.Name = "trh_Observacion2"
            Me.trh_Observacion2.Width = 45
            '
            'trh_HoraSimTotalExtra
            '
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.trh_HoraSimTotalExtra.DefaultCellStyle = DataGridViewCellStyle15
            Me.trh_HoraSimTotalExtra.HeaderText = "HoraSimTotalExtra"
            Me.trh_HoraSimTotalExtra.Name = "trh_HoraSimTotalExtra"
            Me.trh_HoraSimTotalExtra.Width = 50
            '
            'trh_HoraDobTotalExtra
            '
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.trh_HoraDobTotalExtra.DefaultCellStyle = DataGridViewCellStyle16
            Me.trh_HoraDobTotalExtra.HeaderText = "HoraDobTotalExtra"
            Me.trh_HoraDobTotalExtra.Name = "trh_HoraDobTotalExtra"
            Me.trh_HoraDobTotalExtra.Width = 70
            '
            'trh_HoraBonificadaExtra
            '
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.trh_HoraBonificadaExtra.DefaultCellStyle = DataGridViewCellStyle17
            Me.trh_HoraBonificadaExtra.HeaderText = "HoraBonificadaExtra"
            Me.trh_HoraBonificadaExtra.Name = "trh_HoraBonificadaExtra"
            Me.trh_HoraBonificadaExtra.Width = 75
            '
            'trh_HoraSimTotalDestajo
            '
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.trh_HoraSimTotalDestajo.DefaultCellStyle = DataGridViewCellStyle18
            Me.trh_HoraSimTotalDestajo.HeaderText = "HoraSimTotalDestajo"
            Me.trh_HoraSimTotalDestajo.Name = "trh_HoraSimTotalDestajo"
            '
            'trh_HoraDobTotalDestajo
            '
            DataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.trh_HoraDobTotalDestajo.DefaultCellStyle = DataGridViewCellStyle19
            Me.trh_HoraDobTotalDestajo.HeaderText = "HoraDobTotalDestajo"
            Me.trh_HoraDobTotalDestajo.Name = "trh_HoraDobTotalDestajo"
            '
            'ContextMenuStrip1
            '
            Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ObtenerDaHorasDeEstaPersonaToolStripMenuItem})
            Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
            Me.ContextMenuStrip1.Size = New System.Drawing.Size(235, 26)
            '
            'ObtenerDaHorasDeEstaPersonaToolStripMenuItem
            '
            Me.ObtenerDaHorasDeEstaPersonaToolStripMenuItem.Name = "ObtenerDaHorasDeEstaPersonaToolStripMenuItem"
            Me.ObtenerDaHorasDeEstaPersonaToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
            Me.ObtenerDaHorasDeEstaPersonaToolStripMenuItem.Text = "Obtener horas de esta persona"
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.chkBloquear)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.dateHasta)
            Me.Panel2.Controls.Add(Me.dateDesde)
            Me.Panel2.Controls.Add(Me.txtObservaciones)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.txtNumero)
            Me.Panel2.Controls.Add(Me.cboTipoTrabajador)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Location = New System.Drawing.Point(4, 6)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(994, 54)
            Me.Panel2.TabIndex = 0
            '
            'chkBloquear
            '
            Me.chkBloquear.AutoSize = True
            Me.chkBloquear.Checked = True
            Me.chkBloquear.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkBloquear.Location = New System.Drawing.Point(606, 29)
            Me.chkBloquear.Name = "chkBloquear"
            Me.chkBloquear.Size = New System.Drawing.Size(171, 17)
            Me.chkBloquear.TabIndex = 9
            Me.chkBloquear.Text = "Bloquear fecha segun el rango"
            Me.chkBloquear.UseVisualStyleBackColor = True
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(409, 9)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(38, 13)
            Me.Label4.TabIndex = 8
            Me.Label4.Text = "Desde"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(603, 6)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(35, 13)
            Me.Label3.TabIndex = 7
            Me.Label3.Text = "Hasta"
            '
            'dateHasta
            '
            Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateHasta.Location = New System.Drawing.Point(641, 3)
            Me.dateHasta.Name = "dateHasta"
            Me.dateHasta.Size = New System.Drawing.Size(93, 20)
            Me.dateHasta.TabIndex = 6
            '
            'dateDesde
            '
            Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dateDesde.Location = New System.Drawing.Point(452, 6)
            Me.dateDesde.Name = "dateDesde"
            Me.dateDesde.Size = New System.Drawing.Size(93, 20)
            Me.dateDesde.TabIndex = 5
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(117, 28)
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Size = New System.Drawing.Size(428, 20)
            Me.txtObservaciones.TabIndex = 4
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(32, 31)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(78, 13)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Observaciones"
            '
            'txtNumero
            '
            Me.txtNumero.Location = New System.Drawing.Point(245, 4)
            Me.txtNumero.Name = "txtNumero"
            Me.txtNumero.ReadOnly = True
            Me.txtNumero.Size = New System.Drawing.Size(100, 20)
            Me.txtNumero.TabIndex = 2
            '
            'cboTipoTrabajador
            '
            Me.cboTipoTrabajador.FormattingEnabled = True
            Me.cboTipoTrabajador.Location = New System.Drawing.Point(117, 4)
            Me.cboTipoTrabajador.Name = "cboTipoTrabajador"
            Me.cboTipoTrabajador.Size = New System.Drawing.Size(121, 21)
            Me.cboTipoTrabajador.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(14, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(97, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "PLanilla Emp. Obre"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'frmTrabajadorHoras
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1012, 543)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmTrabajadorHoras"
            Me.Text = "     "
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            Me.Panel4.ResumeLayout(False)
            CType(Me.dgvHoraXTrabajador, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ContextMenuStrip1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents cboTipoTrabajador As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents dateHasta As System.Windows.Forms.DateTimePicker
        Friend WithEvents dateDesde As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtNumero As System.Windows.Forms.TextBox
        Friend WithEvents chkBloquear As System.Windows.Forms.CheckBox
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents chkEsdeExcel As System.Windows.Forms.CheckBox
        Friend WithEvents btnImportar As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents dgvHoraXTrabajador As System.Windows.Forms.DataGridView
        Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents btnPLantillaExcel As System.Windows.Forms.Button
        Friend WithEvents btnImportarDeGrupoTrabajo As System.Windows.Forms.Button
        Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtNumeroRegistros As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtNombre As System.Windows.Forms.TextBox
        Friend WithEvents txtCodigoBusqueda As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents ObtenerDaHorasDeEstaPersonaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
        Friend WithEvents chkEsdeProduccion As System.Windows.Forms.RadioButton
        Friend WithEvents chkImportarMantenimiento As System.Windows.Forms.RadioButton
        Friend WithEvents chkImportarEmpleado As System.Windows.Forms.RadioButton
        Friend WithEvents chkLista As System.Windows.Forms.CheckedListBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtSumaBonificacion As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtHoraSimTotalExtra As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtSumaHoraDobTotalExtra As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents txtHoraEssalud As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents trh_Item As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents per_Id As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Persona As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraSimpProduccion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraDobleProduccion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraBonificadaProduccion As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraSimpProduccionDestajo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraDobleProduccionDestajo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraSimCambios As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraDobCambios As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraBonificadaCambios As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraSimCambiosDestajo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraDobCambiosDestajo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraSimReparoHora As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraSimReparoDia As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_horaDobReparo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraEssalud As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraSimTotal As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraDobTotal As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_DiasTrabajador As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_DiasTrabajadorXHora As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_observacion1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_Observacion2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraSimTotalExtra As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraDobTotalExtra As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraBonificadaExtra As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraSimTotalDestajo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents trh_HoraDobTotalDestajo As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class

End Namespace