Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmUnidadesTransporte
        Inherits Ladisac.Foundation.Views.ViewManMaster

        'Form invalida a Dispose para limpiar la lista de componentes.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
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
            Me.txtDOP_NUMERO = New System.Windows.Forms.TextBox()
            Me.lblTDP_ID = New System.Windows.Forms.Label()
            Me.chkDOP_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtTDP_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtTDP_ID = New System.Windows.Forms.TextBox()
            Me.lblUNT_ESTADO = New System.Windows.Forms.Label()
            Me.lblFECHA_ADQUISICION = New System.Windows.Forms.Label()
            Me.lblUNT_ANIO_FABRICACION = New System.Windows.Forms.Label()
            Me.lblUNT_NRO_MOTOR = New System.Windows.Forms.Label()
            Me.lblUNT_NRO_SERIE = New System.Windows.Forms.Label()
            Me.lblUNT_HOROMETRO = New System.Windows.Forms.Label()
            Me.lblUNT_KILOMETRAJE = New System.Windows.Forms.Label()
            Me.lblPER_ID = New System.Windows.Forms.Label()
            Me.lblUNT_NRO_INS = New System.Windows.Forms.Label()
            Me.lblUNT_TARA = New System.Windows.Forms.Label()
            Me.lblMOD_ID = New System.Windows.Forms.Label()
            Me.lblMAR_ID = New System.Windows.Forms.Label()
            Me.lblUNT_TIPO = New System.Windows.Forms.Label()
            Me.lblUNT_COMPORTAMIENTO = New System.Windows.Forms.Label()
            Me.lblUNT_ID = New System.Windows.Forms.Label()
            Me.dtpUNT_FECHA_ADQUISICION = New System.Windows.Forms.DateTimePicker()
            Me.chkUNT_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtUNT_ANIO_FABRICACION = New System.Windows.Forms.TextBox()
            Me.txtUNT_NRO_MOTOR = New System.Windows.Forms.TextBox()
            Me.txtUNT_NRO_SERIE = New System.Windows.Forms.TextBox()
            Me.txtUNT_HOROMETRO = New System.Windows.Forms.TextBox()
            Me.txtUNT_KILOMETRAJE = New System.Windows.Forms.TextBox()
            Me.chkPER_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtPER_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtPER_ID = New System.Windows.Forms.TextBox()
            Me.txtUNT_NRO_INS = New System.Windows.Forms.TextBox()
            Me.txtUNT_TARA = New System.Windows.Forms.TextBox()
            Me.chkMOD_ESTADO = New System.Windows.Forms.CheckBox()
            Me.chkMAR_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtMOD_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtMAR_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtMOD_ID = New System.Windows.Forms.TextBox()
            Me.txtMAR_ID = New System.Windows.Forms.TextBox()
            Me.cboUNT_TIPO = New System.Windows.Forms.ComboBox()
            Me.cboUNT_COMPORTAMIENTO = New System.Windows.Forms.ComboBox()
            Me.txtUNT_ID = New System.Windows.Forms.TextBox()
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.lblTUN_ID = New System.Windows.Forms.Label()
            Me.chkTUN_ESTADO = New System.Windows.Forms.CheckBox()
            Me.txtTUN_DESCRIPCION = New System.Windows.Forms.TextBox()
            Me.txtTUN_ID = New System.Windows.Forms.TextBox()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(704, 28)
            Me.lblTitle.Text = "Unidades transporte"
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
            Me.pnCuerpo.Controls.Add(Me.lblTUN_ID)
            Me.pnCuerpo.Controls.Add(Me.chkTUN_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtTUN_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTUN_ID)
            Me.pnCuerpo.Controls.Add(Me.txtDOP_NUMERO)
            Me.pnCuerpo.Controls.Add(Me.lblTDP_ID)
            Me.pnCuerpo.Controls.Add(Me.chkDOP_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtTDP_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtTDP_ID)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblFECHA_ADQUISICION)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_ANIO_FABRICACION)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_NRO_MOTOR)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_NRO_SERIE)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_HOROMETRO)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_KILOMETRAJE)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_NRO_INS)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_TARA)
            Me.pnCuerpo.Controls.Add(Me.lblMOD_ID)
            Me.pnCuerpo.Controls.Add(Me.lblMAR_ID)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_TIPO)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_COMPORTAMIENTO)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_ID)
            Me.pnCuerpo.Controls.Add(Me.dtpUNT_FECHA_ADQUISICION)
            Me.pnCuerpo.Controls.Add(Me.chkUNT_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_ANIO_FABRICACION)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_NRO_MOTOR)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_NRO_SERIE)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_HOROMETRO)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_KILOMETRAJE)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_NRO_INS)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_TARA)
            Me.pnCuerpo.Controls.Add(Me.chkMOD_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkMAR_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.txtMOD_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtMAR_DESCRIPCION)
            Me.pnCuerpo.Controls.Add(Me.txtMOD_ID)
            Me.pnCuerpo.Controls.Add(Me.txtMAR_ID)
            Me.pnCuerpo.Controls.Add(Me.cboUNT_TIPO)
            Me.pnCuerpo.Controls.Add(Me.cboUNT_COMPORTAMIENTO)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_ID)
            Me.pnCuerpo.Location = New System.Drawing.Point(34, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(638, 299)
            Me.pnCuerpo.TabIndex = 114
            '
            'txtDOP_NUMERO
            '
            Me.txtDOP_NUMERO.Enabled = False
            Me.txtDOP_NUMERO.Location = New System.Drawing.Point(341, 172)
            Me.txtDOP_NUMERO.Name = "txtDOP_NUMERO"
            Me.txtDOP_NUMERO.ReadOnly = True
            Me.txtDOP_NUMERO.Size = New System.Drawing.Size(182, 20)
            Me.txtDOP_NUMERO.TabIndex = 19
            '
            'lblTDP_ID
            '
            Me.lblTDP_ID.AutoSize = True
            Me.lblTDP_ID.Location = New System.Drawing.Point(6, 172)
            Me.lblTDP_ID.Name = "lblTDP_ID"
            Me.lblTDP_ID.Size = New System.Drawing.Size(69, 13)
            Me.lblTDP_ID.TabIndex = 40
            Me.lblTDP_ID.Text = "Doc. Transp."
            '
            'chkDOP_ESTADO
            '
            Me.chkDOP_ESTADO.AutoSize = True
            Me.chkDOP_ESTADO.Enabled = False
            Me.chkDOP_ESTADO.Location = New System.Drawing.Point(529, 172)
            Me.chkDOP_ESTADO.Name = "chkDOP_ESTADO"
            Me.chkDOP_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkDOP_ESTADO.TabIndex = 20
            Me.chkDOP_ESTADO.UseVisualStyleBackColor = True
            '
            'txtTDP_DESCRIPCION
            '
            Me.txtTDP_DESCRIPCION.Enabled = False
            Me.txtTDP_DESCRIPCION.Location = New System.Drawing.Point(112, 172)
            Me.txtTDP_DESCRIPCION.Name = "txtTDP_DESCRIPCION"
            Me.txtTDP_DESCRIPCION.ReadOnly = True
            Me.txtTDP_DESCRIPCION.Size = New System.Drawing.Size(217, 20)
            Me.txtTDP_DESCRIPCION.TabIndex = 18
            '
            'txtTDP_ID
            '
            Me.txtTDP_ID.Enabled = False
            Me.txtTDP_ID.Location = New System.Drawing.Point(79, 172)
            Me.txtTDP_ID.Name = "txtTDP_ID"
            Me.txtTDP_ID.ReadOnly = True
            Me.txtTDP_ID.Size = New System.Drawing.Size(27, 20)
            Me.txtTDP_ID.TabIndex = 17
            '
            'lblUNT_ESTADO
            '
            Me.lblUNT_ESTADO.AutoSize = True
            Me.lblUNT_ESTADO.Location = New System.Drawing.Point(6, 273)
            Me.lblUNT_ESTADO.Name = "lblUNT_ESTADO"
            Me.lblUNT_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblUNT_ESTADO.TabIndex = 36
            Me.lblUNT_ESTADO.Text = "Estado"
            '
            'lblFECHA_ADQUISICION
            '
            Me.lblFECHA_ADQUISICION.AutoSize = True
            Me.lblFECHA_ADQUISICION.Location = New System.Drawing.Point(438, 240)
            Me.lblFECHA_ADQUISICION.Name = "lblFECHA_ADQUISICION"
            Me.lblFECHA_ADQUISICION.Size = New System.Drawing.Size(65, 13)
            Me.lblFECHA_ADQUISICION.TabIndex = 35
            Me.lblFECHA_ADQUISICION.Text = "Fecha. Adq."
            '
            'lblUNT_ANIO_FABRICACION
            '
            Me.lblUNT_ANIO_FABRICACION.AutoSize = True
            Me.lblUNT_ANIO_FABRICACION.Location = New System.Drawing.Point(233, 240)
            Me.lblUNT_ANIO_FABRICACION.Name = "lblUNT_ANIO_FABRICACION"
            Me.lblUNT_ANIO_FABRICACION.Size = New System.Drawing.Size(53, 13)
            Me.lblUNT_ANIO_FABRICACION.TabIndex = 34
            Me.lblUNT_ANIO_FABRICACION.Text = "Año. Fab."
            '
            'lblUNT_NRO_MOTOR
            '
            Me.lblUNT_NRO_MOTOR.AutoSize = True
            Me.lblUNT_NRO_MOTOR.Location = New System.Drawing.Point(6, 240)
            Me.lblUNT_NRO_MOTOR.Name = "lblUNT_NRO_MOTOR"
            Me.lblUNT_NRO_MOTOR.Size = New System.Drawing.Size(57, 13)
            Me.lblUNT_NRO_MOTOR.TabIndex = 33
            Me.lblUNT_NRO_MOTOR.Text = "Nro. Motor"
            '
            'lblUNT_NRO_SERIE
            '
            Me.lblUNT_NRO_SERIE.AutoSize = True
            Me.lblUNT_NRO_SERIE.Location = New System.Drawing.Point(436, 202)
            Me.lblUNT_NRO_SERIE.Name = "lblUNT_NRO_SERIE"
            Me.lblUNT_NRO_SERIE.Size = New System.Drawing.Size(54, 13)
            Me.lblUNT_NRO_SERIE.TabIndex = 32
            Me.lblUNT_NRO_SERIE.Text = "Nro. Serie"
            '
            'lblUNT_HOROMETRO
            '
            Me.lblUNT_HOROMETRO.AutoSize = True
            Me.lblUNT_HOROMETRO.Location = New System.Drawing.Point(233, 202)
            Me.lblUNT_HOROMETRO.Name = "lblUNT_HOROMETRO"
            Me.lblUNT_HOROMETRO.Size = New System.Drawing.Size(56, 13)
            Me.lblUNT_HOROMETRO.TabIndex = 31
            Me.lblUNT_HOROMETRO.Text = "Horometro"
            '
            'lblUNT_KILOMETRAJE
            '
            Me.lblUNT_KILOMETRAJE.AutoSize = True
            Me.lblUNT_KILOMETRAJE.Location = New System.Drawing.Point(6, 202)
            Me.lblUNT_KILOMETRAJE.Name = "lblUNT_KILOMETRAJE"
            Me.lblUNT_KILOMETRAJE.Size = New System.Drawing.Size(58, 13)
            Me.lblUNT_KILOMETRAJE.TabIndex = 30
            Me.lblUNT_KILOMETRAJE.Text = "Kilometraje"
            '
            'lblPER_ID
            '
            Me.lblPER_ID.AutoSize = True
            Me.lblPER_ID.Location = New System.Drawing.Point(6, 146)
            Me.lblPER_ID.Name = "lblPER_ID"
            Me.lblPER_ID.Size = New System.Drawing.Size(68, 13)
            Me.lblPER_ID.TabIndex = 29
            Me.lblPER_ID.Text = "Transportista"
            '
            'lblUNT_NRO_INS
            '
            Me.lblUNT_NRO_INS.AutoSize = True
            Me.lblUNT_NRO_INS.Location = New System.Drawing.Point(256, 121)
            Me.lblUNT_NRO_INS.Name = "lblUNT_NRO_INS"
            Me.lblUNT_NRO_INS.Size = New System.Drawing.Size(81, 13)
            Me.lblUNT_NRO_INS.TabIndex = 28
            Me.lblUNT_NRO_INS.Text = "Nro. Inscripción"
            '
            'lblUNT_TARA
            '
            Me.lblUNT_TARA.AutoSize = True
            Me.lblUNT_TARA.Location = New System.Drawing.Point(6, 118)
            Me.lblUNT_TARA.Name = "lblUNT_TARA"
            Me.lblUNT_TARA.Size = New System.Drawing.Size(29, 13)
            Me.lblUNT_TARA.TabIndex = 27
            Me.lblUNT_TARA.Text = "Tara"
            '
            'lblMOD_ID
            '
            Me.lblMOD_ID.AutoSize = True
            Me.lblMOD_ID.Location = New System.Drawing.Point(6, 92)
            Me.lblMOD_ID.Name = "lblMOD_ID"
            Me.lblMOD_ID.Size = New System.Drawing.Size(42, 13)
            Me.lblMOD_ID.TabIndex = 26
            Me.lblMOD_ID.Text = "Modelo"
            '
            'lblMAR_ID
            '
            Me.lblMAR_ID.AutoSize = True
            Me.lblMAR_ID.Location = New System.Drawing.Point(6, 66)
            Me.lblMAR_ID.Name = "lblMAR_ID"
            Me.lblMAR_ID.Size = New System.Drawing.Size(37, 13)
            Me.lblMAR_ID.TabIndex = 25
            Me.lblMAR_ID.Text = "Marca"
            '
            'lblUNT_TIPO
            '
            Me.lblUNT_TIPO.AutoSize = True
            Me.lblUNT_TIPO.Location = New System.Drawing.Point(464, 13)
            Me.lblUNT_TIPO.Name = "lblUNT_TIPO"
            Me.lblUNT_TIPO.Size = New System.Drawing.Size(28, 13)
            Me.lblUNT_TIPO.TabIndex = 24
            Me.lblUNT_TIPO.Text = "Tipo"
            '
            'lblUNT_COMPORTAMIENTO
            '
            Me.lblUNT_COMPORTAMIENTO.AutoSize = True
            Me.lblUNT_COMPORTAMIENTO.Location = New System.Drawing.Point(185, 13)
            Me.lblUNT_COMPORTAMIENTO.Name = "lblUNT_COMPORTAMIENTO"
            Me.lblUNT_COMPORTAMIENTO.Size = New System.Drawing.Size(83, 13)
            Me.lblUNT_COMPORTAMIENTO.TabIndex = 23
            Me.lblUNT_COMPORTAMIENTO.Text = "Comportamiento"
            '
            'lblUNT_ID
            '
            Me.lblUNT_ID.AutoSize = True
            Me.lblUNT_ID.Location = New System.Drawing.Point(6, 13)
            Me.lblUNT_ID.Name = "lblUNT_ID"
            Me.lblUNT_ID.Size = New System.Drawing.Size(40, 13)
            Me.lblUNT_ID.TabIndex = 22
            Me.lblUNT_ID.Text = "Código"
            '
            'dtpUNT_FECHA_ADQUISICION
            '
            Me.dtpUNT_FECHA_ADQUISICION.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpUNT_FECHA_ADQUISICION.Location = New System.Drawing.Point(507, 240)
            Me.dtpUNT_FECHA_ADQUISICION.Name = "dtpUNT_FECHA_ADQUISICION"
            Me.dtpUNT_FECHA_ADQUISICION.Size = New System.Drawing.Size(103, 20)
            Me.dtpUNT_FECHA_ADQUISICION.TabIndex = 26
            '
            'chkUNT_ESTADO
            '
            Me.chkUNT_ESTADO.AutoSize = True
            Me.chkUNT_ESTADO.Location = New System.Drawing.Point(58, 272)
            Me.chkUNT_ESTADO.Name = "chkUNT_ESTADO"
            Me.chkUNT_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkUNT_ESTADO.TabIndex = 27
            Me.chkUNT_ESTADO.UseVisualStyleBackColor = True
            '
            'txtUNT_ANIO_FABRICACION
            '
            Me.txtUNT_ANIO_FABRICACION.Location = New System.Drawing.Point(295, 240)
            Me.txtUNT_ANIO_FABRICACION.Name = "txtUNT_ANIO_FABRICACION"
            Me.txtUNT_ANIO_FABRICACION.Size = New System.Drawing.Size(100, 20)
            Me.txtUNT_ANIO_FABRICACION.TabIndex = 25
            Me.txtUNT_ANIO_FABRICACION.Text = "0"
            '
            'txtUNT_NRO_MOTOR
            '
            Me.txtUNT_NRO_MOTOR.Location = New System.Drawing.Point(79, 240)
            Me.txtUNT_NRO_MOTOR.Name = "txtUNT_NRO_MOTOR"
            Me.txtUNT_NRO_MOTOR.Size = New System.Drawing.Size(100, 20)
            Me.txtUNT_NRO_MOTOR.TabIndex = 24
            '
            'txtUNT_NRO_SERIE
            '
            Me.txtUNT_NRO_SERIE.Location = New System.Drawing.Point(507, 202)
            Me.txtUNT_NRO_SERIE.Name = "txtUNT_NRO_SERIE"
            Me.txtUNT_NRO_SERIE.Size = New System.Drawing.Size(103, 20)
            Me.txtUNT_NRO_SERIE.TabIndex = 23
            '
            'txtUNT_HOROMETRO
            '
            Me.txtUNT_HOROMETRO.Location = New System.Drawing.Point(295, 202)
            Me.txtUNT_HOROMETRO.Name = "txtUNT_HOROMETRO"
            Me.txtUNT_HOROMETRO.Size = New System.Drawing.Size(100, 20)
            Me.txtUNT_HOROMETRO.TabIndex = 22
            Me.txtUNT_HOROMETRO.Text = "0"
            '
            'txtUNT_KILOMETRAJE
            '
            Me.txtUNT_KILOMETRAJE.Location = New System.Drawing.Point(79, 202)
            Me.txtUNT_KILOMETRAJE.Name = "txtUNT_KILOMETRAJE"
            Me.txtUNT_KILOMETRAJE.Size = New System.Drawing.Size(100, 20)
            Me.txtUNT_KILOMETRAJE.TabIndex = 21
            Me.txtUNT_KILOMETRAJE.Text = "0"
            '
            'chkPER_ESTADO
            '
            Me.chkPER_ESTADO.AutoSize = True
            Me.chkPER_ESTADO.Enabled = False
            Me.chkPER_ESTADO.Location = New System.Drawing.Point(529, 146)
            Me.chkPER_ESTADO.Name = "chkPER_ESTADO"
            Me.chkPER_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO.TabIndex = 16
            Me.chkPER_ESTADO.UseVisualStyleBackColor = True
            '
            'txtPER_DESCRIPCION
            '
            Me.txtPER_DESCRIPCION.Enabled = False
            Me.txtPER_DESCRIPCION.Location = New System.Drawing.Point(151, 146)
            Me.txtPER_DESCRIPCION.Name = "txtPER_DESCRIPCION"
            Me.txtPER_DESCRIPCION.ReadOnly = True
            Me.txtPER_DESCRIPCION.Size = New System.Drawing.Size(372, 20)
            Me.txtPER_DESCRIPCION.TabIndex = 15
            '
            'txtPER_ID
            '
            Me.txtPER_ID.Location = New System.Drawing.Point(79, 146)
            Me.txtPER_ID.Name = "txtPER_ID"
            Me.txtPER_ID.ReadOnly = True
            Me.txtPER_ID.Size = New System.Drawing.Size(66, 20)
            Me.txtPER_ID.TabIndex = 14
            '
            'txtUNT_NRO_INS
            '
            Me.txtUNT_NRO_INS.Location = New System.Drawing.Point(341, 121)
            Me.txtUNT_NRO_INS.Name = "txtUNT_NRO_INS"
            Me.txtUNT_NRO_INS.Size = New System.Drawing.Size(269, 20)
            Me.txtUNT_NRO_INS.TabIndex = 13
            '
            'txtUNT_TARA
            '
            Me.txtUNT_TARA.Location = New System.Drawing.Point(58, 118)
            Me.txtUNT_TARA.Name = "txtUNT_TARA"
            Me.txtUNT_TARA.Size = New System.Drawing.Size(100, 20)
            Me.txtUNT_TARA.TabIndex = 12
            Me.txtUNT_TARA.Text = "0"
            '
            'chkMOD_ESTADO
            '
            Me.chkMOD_ESTADO.AutoSize = True
            Me.chkMOD_ESTADO.Enabled = False
            Me.chkMOD_ESTADO.Location = New System.Drawing.Point(529, 92)
            Me.chkMOD_ESTADO.Name = "chkMOD_ESTADO"
            Me.chkMOD_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkMOD_ESTADO.TabIndex = 11
            Me.chkMOD_ESTADO.UseVisualStyleBackColor = True
            '
            'chkMAR_ESTADO
            '
            Me.chkMAR_ESTADO.AutoSize = True
            Me.chkMAR_ESTADO.Enabled = False
            Me.chkMAR_ESTADO.Location = New System.Drawing.Point(529, 66)
            Me.chkMAR_ESTADO.Name = "chkMAR_ESTADO"
            Me.chkMAR_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkMAR_ESTADO.TabIndex = 8
            Me.chkMAR_ESTADO.UseVisualStyleBackColor = True
            '
            'txtMOD_DESCRIPCION
            '
            Me.txtMOD_DESCRIPCION.Enabled = False
            Me.txtMOD_DESCRIPCION.Location = New System.Drawing.Point(98, 92)
            Me.txtMOD_DESCRIPCION.Name = "txtMOD_DESCRIPCION"
            Me.txtMOD_DESCRIPCION.ReadOnly = True
            Me.txtMOD_DESCRIPCION.Size = New System.Drawing.Size(425, 20)
            Me.txtMOD_DESCRIPCION.TabIndex = 10
            '
            'txtMAR_DESCRIPCION
            '
            Me.txtMAR_DESCRIPCION.Enabled = False
            Me.txtMAR_DESCRIPCION.Location = New System.Drawing.Point(98, 66)
            Me.txtMAR_DESCRIPCION.Name = "txtMAR_DESCRIPCION"
            Me.txtMAR_DESCRIPCION.ReadOnly = True
            Me.txtMAR_DESCRIPCION.Size = New System.Drawing.Size(425, 20)
            Me.txtMAR_DESCRIPCION.TabIndex = 7
            '
            'txtMOD_ID
            '
            Me.txtMOD_ID.Location = New System.Drawing.Point(58, 92)
            Me.txtMOD_ID.Name = "txtMOD_ID"
            Me.txtMOD_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtMOD_ID.TabIndex = 9
            '
            'txtMAR_ID
            '
            Me.txtMAR_ID.Location = New System.Drawing.Point(58, 66)
            Me.txtMAR_ID.Name = "txtMAR_ID"
            Me.txtMAR_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtMAR_ID.TabIndex = 6
            '
            'cboUNT_TIPO
            '
            Me.cboUNT_TIPO.FormattingEnabled = True
            Me.cboUNT_TIPO.Location = New System.Drawing.Point(496, 13)
            Me.cboUNT_TIPO.Name = "cboUNT_TIPO"
            Me.cboUNT_TIPO.Size = New System.Drawing.Size(114, 21)
            Me.cboUNT_TIPO.TabIndex = 2
            '
            'cboUNT_COMPORTAMIENTO
            '
            Me.cboUNT_COMPORTAMIENTO.FormattingEnabled = True
            Me.cboUNT_COMPORTAMIENTO.Location = New System.Drawing.Point(274, 13)
            Me.cboUNT_COMPORTAMIENTO.Name = "cboUNT_COMPORTAMIENTO"
            Me.cboUNT_COMPORTAMIENTO.Size = New System.Drawing.Size(121, 21)
            Me.cboUNT_COMPORTAMIENTO.TabIndex = 1
            '
            'txtUNT_ID
            '
            Me.txtUNT_ID.Location = New System.Drawing.Point(58, 13)
            Me.txtUNT_ID.Name = "txtUNT_ID"
            Me.txtUNT_ID.Size = New System.Drawing.Size(100, 20)
            Me.txtUNT_ID.TabIndex = 0
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(627, 1)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(45, 26)
            Me.btnImagen.TabIndex = 115
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'lblTUN_ID
            '
            Me.lblTUN_ID.AutoSize = True
            Me.lblTUN_ID.Location = New System.Drawing.Point(6, 40)
            Me.lblTUN_ID.Name = "lblTUN_ID"
            Me.lblTUN_ID.Size = New System.Drawing.Size(49, 13)
            Me.lblTUN_ID.TabIndex = 45
            Me.lblTUN_ID.Text = "Tracción"
            '
            'chkTUN_ESTADO
            '
            Me.chkTUN_ESTADO.AutoSize = True
            Me.chkTUN_ESTADO.Enabled = False
            Me.chkTUN_ESTADO.Location = New System.Drawing.Point(529, 40)
            Me.chkTUN_ESTADO.Name = "chkTUN_ESTADO"
            Me.chkTUN_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkTUN_ESTADO.TabIndex = 5
            Me.chkTUN_ESTADO.UseVisualStyleBackColor = True
            '
            'txtTUN_DESCRIPCION
            '
            Me.txtTUN_DESCRIPCION.Enabled = False
            Me.txtTUN_DESCRIPCION.Location = New System.Drawing.Point(98, 40)
            Me.txtTUN_DESCRIPCION.Name = "txtTUN_DESCRIPCION"
            Me.txtTUN_DESCRIPCION.ReadOnly = True
            Me.txtTUN_DESCRIPCION.Size = New System.Drawing.Size(425, 20)
            Me.txtTUN_DESCRIPCION.TabIndex = 4
            '
            'txtTUN_ID
            '
            Me.txtTUN_ID.Location = New System.Drawing.Point(58, 40)
            Me.txtTUN_ID.Name = "txtTUN_ID"
            Me.txtTUN_ID.Size = New System.Drawing.Size(34, 20)
            Me.txtTUN_ID.TabIndex = 3
            '
            'frmUnidadesTransporte
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(704, 371)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmUnidadesTransporte"
            Me.Text = "Unidades transporte"
            Me.Controls.SetChildIndex(Me.pnCuerpo, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.btnImagen, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnCuerpo.ResumeLayout(False)
            Me.pnCuerpo.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Friend WithEvents lblUNT_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblFECHA_ADQUISICION As System.Windows.Forms.Label
        Friend WithEvents lblUNT_ANIO_FABRICACION As System.Windows.Forms.Label
        Friend WithEvents lblUNT_NRO_MOTOR As System.Windows.Forms.Label
        Friend WithEvents lblUNT_NRO_SERIE As System.Windows.Forms.Label
        Friend WithEvents lblUNT_HOROMETRO As System.Windows.Forms.Label
        Friend WithEvents lblUNT_KILOMETRAJE As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID As System.Windows.Forms.Label
        Friend WithEvents lblUNT_NRO_INS As System.Windows.Forms.Label
        Friend WithEvents lblUNT_TARA As System.Windows.Forms.Label
        Friend WithEvents lblMOD_ID As System.Windows.Forms.Label
        Friend WithEvents lblMAR_ID As System.Windows.Forms.Label
        Friend WithEvents lblUNT_TIPO As System.Windows.Forms.Label
        Friend WithEvents lblUNT_COMPORTAMIENTO As System.Windows.Forms.Label
        Friend WithEvents lblUNT_ID As System.Windows.Forms.Label
        Friend WithEvents lblTDP_ID As System.Windows.Forms.Label
        Public WithEvents cboUNT_COMPORTAMIENTO As System.Windows.Forms.ComboBox
        Public WithEvents txtUNT_ID As System.Windows.Forms.TextBox
        Public WithEvents cboUNT_TIPO As System.Windows.Forms.ComboBox
        Public WithEvents chkMOD_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkMAR_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtMOD_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtMAR_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtMOD_ID As System.Windows.Forms.TextBox
        Public WithEvents txtMAR_ID As System.Windows.Forms.TextBox
        Public WithEvents txtUNT_NRO_INS As System.Windows.Forms.TextBox
        Public WithEvents txtUNT_TARA As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID As System.Windows.Forms.TextBox
        Public WithEvents chkUNT_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtUNT_ANIO_FABRICACION As System.Windows.Forms.TextBox
        Public WithEvents txtUNT_NRO_MOTOR As System.Windows.Forms.TextBox
        Public WithEvents txtUNT_NRO_SERIE As System.Windows.Forms.TextBox
        Public WithEvents txtUNT_HOROMETRO As System.Windows.Forms.TextBox
        Public WithEvents txtUNT_KILOMETRAJE As System.Windows.Forms.TextBox
        Public WithEvents chkPER_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtPER_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents dtpUNT_FECHA_ADQUISICION As System.Windows.Forms.DateTimePicker
        Public WithEvents chkDOP_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtTDP_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtTDP_ID As System.Windows.Forms.TextBox
        Public WithEvents txtDOP_NUMERO As System.Windows.Forms.TextBox
        Friend WithEvents lblTUN_ID As System.Windows.Forms.Label
        Public WithEvents chkTUN_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents txtTUN_DESCRIPCION As System.Windows.Forms.TextBox
        Public WithEvents txtTUN_ID As System.Windows.Forms.TextBox

    End Class
End Namespace