Namespace Ladisac.Maestros.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPlacas
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
            Me.btnImagen = New System.Windows.Forms.Button()
            Me.pnCuerpo = New System.Windows.Forms.Panel()
            Me.lblPLA_ID = New System.Windows.Forms.Label()
            Me.txtPLA_ID = New System.Windows.Forms.TextBox()
            Me.txtPER_BREVETE_CHO = New System.Windows.Forms.TextBox()
            Me.lblPER_BREVETE_CHO = New System.Windows.Forms.Label()
            Me.lblPER_ID_CHO = New System.Windows.Forms.Label()
            Me.chkPER_ESTADO_CHO = New System.Windows.Forms.CheckBox()
            Me.txtPER_DESCRIPCION_CHO = New System.Windows.Forms.TextBox()
            Me.txtPER_ID_CHO = New System.Windows.Forms.TextBox()
            Me.chkPER_ESTADO_TRA2 = New System.Windows.Forms.CheckBox()
            Me.txtRUC_TRA2 = New System.Windows.Forms.TextBox()
            Me.lblTDP_ID2 = New System.Windows.Forms.Label()
            Me.lblPER_ID2 = New System.Windows.Forms.Label()
            Me.lblUNT_NRO_INS2 = New System.Windows.Forms.Label()
            Me.lblUNT_TARA2 = New System.Windows.Forms.Label()
            Me.txtMAR_DESCRIPCION_TRA2 = New System.Windows.Forms.TextBox()
            Me.lblMOD_ID2 = New System.Windows.Forms.Label()
            Me.txtUNT_ID_2 = New System.Windows.Forms.TextBox()
            Me.lblMAR_ID2 = New System.Windows.Forms.Label()
            Me.txtMOD_DESCRIPCION_TRA2 = New System.Windows.Forms.TextBox()
            Me.lblUNT_ID2 = New System.Windows.Forms.Label()
            Me.txtUNT_TARA_TRA2 = New System.Windows.Forms.TextBox()
            Me.txtUNT_NRO_INS_TRA2 = New System.Windows.Forms.TextBox()
            Me.txtPER_DESCRIPCION_TRA2 = New System.Windows.Forms.TextBox()
            Me.txtPER_ID_TRA2 = New System.Windows.Forms.TextBox()
            Me.txtRUC_TRA1 = New System.Windows.Forms.TextBox()
            Me.lblTDP_ID1 = New System.Windows.Forms.Label()
            Me.lblUNT_ESTADO = New System.Windows.Forms.Label()
            Me.lblPER_ID1 = New System.Windows.Forms.Label()
            Me.lblUNT_NRO_INS1 = New System.Windows.Forms.Label()
            Me.lblUNT_TARA1 = New System.Windows.Forms.Label()
            Me.lblMOD_ID1 = New System.Windows.Forms.Label()
            Me.lblMAR_ID1 = New System.Windows.Forms.Label()
            Me.lblUNT_ID1 = New System.Windows.Forms.Label()
            Me.chkPLA_ESTADO = New System.Windows.Forms.CheckBox()
            Me.chkPER_ESTADO_TRA1 = New System.Windows.Forms.CheckBox()
            Me.txtPER_DESCRIPCION_TRA1 = New System.Windows.Forms.TextBox()
            Me.txtPER_ID_TRA1 = New System.Windows.Forms.TextBox()
            Me.txtUNT_NRO_INS_TRA1 = New System.Windows.Forms.TextBox()
            Me.txtUNT_TARA_TRA1 = New System.Windows.Forms.TextBox()
            Me.txtMOD_DESCRIPCION_TRA1 = New System.Windows.Forms.TextBox()
            Me.txtMAR_DESCRIPCION_TRA1 = New System.Windows.Forms.TextBox()
            Me.txtUNT_ID_1 = New System.Windows.Forms.TextBox()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnCuerpo.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(780, 28)
            Me.lblTitle.Text = "Placas"
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'btnImagen
            '
            Me.btnImagen.Image = Global.My.Resources.Resource1.d3A_big_pack_foldersubscriptions
            Me.btnImagen.Location = New System.Drawing.Point(701, 2)
            Me.btnImagen.Name = "btnImagen"
            Me.btnImagen.Size = New System.Drawing.Size(46, 24)
            Me.btnImagen.TabIndex = 117
            Me.btnImagen.UseVisualStyleBackColor = True
            '
            'pnCuerpo
            '
            Me.pnCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnCuerpo.BackColor = System.Drawing.SystemColors.Control
            Me.pnCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnCuerpo.Controls.Add(Me.lblPLA_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPLA_ID)
            Me.pnCuerpo.Controls.Add(Me.txtPER_BREVETE_CHO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_BREVETE_CHO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID_CHO)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO_CHO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_CHO)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_CHO)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO_TRA2)
            Me.pnCuerpo.Controls.Add(Me.txtRUC_TRA2)
            Me.pnCuerpo.Controls.Add(Me.lblTDP_ID2)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID2)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_NRO_INS2)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_TARA2)
            Me.pnCuerpo.Controls.Add(Me.txtMAR_DESCRIPCION_TRA2)
            Me.pnCuerpo.Controls.Add(Me.lblMOD_ID2)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_ID_2)
            Me.pnCuerpo.Controls.Add(Me.lblMAR_ID2)
            Me.pnCuerpo.Controls.Add(Me.txtMOD_DESCRIPCION_TRA2)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_ID2)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_TARA_TRA2)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_NRO_INS_TRA2)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_TRA2)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_TRA2)
            Me.pnCuerpo.Controls.Add(Me.txtRUC_TRA1)
            Me.pnCuerpo.Controls.Add(Me.lblTDP_ID1)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.lblPER_ID1)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_NRO_INS1)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_TARA1)
            Me.pnCuerpo.Controls.Add(Me.lblMOD_ID1)
            Me.pnCuerpo.Controls.Add(Me.lblMAR_ID1)
            Me.pnCuerpo.Controls.Add(Me.lblUNT_ID1)
            Me.pnCuerpo.Controls.Add(Me.chkPLA_ESTADO)
            Me.pnCuerpo.Controls.Add(Me.chkPER_ESTADO_TRA1)
            Me.pnCuerpo.Controls.Add(Me.txtPER_DESCRIPCION_TRA1)
            Me.pnCuerpo.Controls.Add(Me.txtPER_ID_TRA1)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_NRO_INS_TRA1)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_TARA_TRA1)
            Me.pnCuerpo.Controls.Add(Me.txtMOD_DESCRIPCION_TRA1)
            Me.pnCuerpo.Controls.Add(Me.txtMAR_DESCRIPCION_TRA1)
            Me.pnCuerpo.Controls.Add(Me.txtUNT_ID_1)
            Me.pnCuerpo.Location = New System.Drawing.Point(33, 31)
            Me.pnCuerpo.Name = "pnCuerpo"
            Me.pnCuerpo.Size = New System.Drawing.Size(714, 273)
            Me.pnCuerpo.TabIndex = 118
            '
            'lblPLA_ID
            '
            Me.lblPLA_ID.AutoSize = True
            Me.lblPLA_ID.Location = New System.Drawing.Point(6, 21)
            Me.lblPLA_ID.Name = "lblPLA_ID"
            Me.lblPLA_ID.Size = New System.Drawing.Size(59, 13)
            Me.lblPLA_ID.TabIndex = 81
            Me.lblPLA_ID.Text = "Cód. Placa"
            '
            'txtPLA_ID
            '
            Me.txtPLA_ID.Location = New System.Drawing.Point(75, 21)
            Me.txtPLA_ID.Name = "txtPLA_ID"
            Me.txtPLA_ID.Size = New System.Drawing.Size(66, 20)
            Me.txtPLA_ID.TabIndex = 0
            '
            'txtPER_BREVETE_CHO
            '
            Me.txtPER_BREVETE_CHO.Enabled = False
            Me.txtPER_BREVETE_CHO.Location = New System.Drawing.Point(439, 213)
            Me.txtPER_BREVETE_CHO.Name = "txtPER_BREVETE_CHO"
            Me.txtPER_BREVETE_CHO.ReadOnly = True
            Me.txtPER_BREVETE_CHO.Size = New System.Drawing.Size(182, 20)
            Me.txtPER_BREVETE_CHO.TabIndex = 21
            '
            'lblPER_BREVETE_CHO
            '
            Me.lblPER_BREVETE_CHO.AutoSize = True
            Me.lblPER_BREVETE_CHO.Location = New System.Drawing.Point(367, 213)
            Me.lblPER_BREVETE_CHO.Name = "lblPER_BREVETE_CHO"
            Me.lblPER_BREVETE_CHO.Size = New System.Drawing.Size(44, 13)
            Me.lblPER_BREVETE_CHO.TabIndex = 78
            Me.lblPER_BREVETE_CHO.Text = "Brevete"
            '
            'lblPER_ID_CHO
            '
            Me.lblPER_ID_CHO.AutoSize = True
            Me.lblPER_ID_CHO.Location = New System.Drawing.Point(6, 213)
            Me.lblPER_ID_CHO.Name = "lblPER_ID_CHO"
            Me.lblPER_ID_CHO.Size = New System.Drawing.Size(38, 13)
            Me.lblPER_ID_CHO.TabIndex = 77
            Me.lblPER_ID_CHO.Text = "Chofer"
            '
            'chkPER_ESTADO_CHO
            '
            Me.chkPER_ESTADO_CHO.AutoSize = True
            Me.chkPER_ESTADO_CHO.Enabled = False
            Me.chkPER_ESTADO_CHO.Location = New System.Drawing.Point(627, 213)
            Me.chkPER_ESTADO_CHO.Name = "chkPER_ESTADO_CHO"
            Me.chkPER_ESTADO_CHO.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO_CHO.TabIndex = 22
            Me.chkPER_ESTADO_CHO.UseVisualStyleBackColor = True
            '
            'txtPER_DESCRIPCION_CHO
            '
            Me.txtPER_DESCRIPCION_CHO.Enabled = False
            Me.txtPER_DESCRIPCION_CHO.Location = New System.Drawing.Point(146, 213)
            Me.txtPER_DESCRIPCION_CHO.Name = "txtPER_DESCRIPCION_CHO"
            Me.txtPER_DESCRIPCION_CHO.ReadOnly = True
            Me.txtPER_DESCRIPCION_CHO.Size = New System.Drawing.Size(204, 20)
            Me.txtPER_DESCRIPCION_CHO.TabIndex = 20
            '
            'txtPER_ID_CHO
            '
            Me.txtPER_ID_CHO.Location = New System.Drawing.Point(75, 213)
            Me.txtPER_ID_CHO.Name = "txtPER_ID_CHO"
            Me.txtPER_ID_CHO.Size = New System.Drawing.Size(66, 20)
            Me.txtPER_ID_CHO.TabIndex = 19
            '
            'chkPER_ESTADO_TRA2
            '
            Me.chkPER_ESTADO_TRA2.AutoSize = True
            Me.chkPER_ESTADO_TRA2.Enabled = False
            Me.chkPER_ESTADO_TRA2.Location = New System.Drawing.Point(627, 156)
            Me.chkPER_ESTADO_TRA2.Name = "chkPER_ESTADO_TRA2"
            Me.chkPER_ESTADO_TRA2.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO_TRA2.TabIndex = 16
            Me.chkPER_ESTADO_TRA2.UseVisualStyleBackColor = True
            '
            'txtRUC_TRA2
            '
            Me.txtRUC_TRA2.Enabled = False
            Me.txtRUC_TRA2.Location = New System.Drawing.Point(439, 156)
            Me.txtRUC_TRA2.Name = "txtRUC_TRA2"
            Me.txtRUC_TRA2.ReadOnly = True
            Me.txtRUC_TRA2.Size = New System.Drawing.Size(182, 20)
            Me.txtRUC_TRA2.TabIndex = 15
            '
            'lblTDP_ID2
            '
            Me.lblTDP_ID2.AutoSize = True
            Me.lblTDP_ID2.Location = New System.Drawing.Point(367, 156)
            Me.lblTDP_ID2.Name = "lblTDP_ID2"
            Me.lblTDP_ID2.Size = New System.Drawing.Size(69, 13)
            Me.lblTDP_ID2.TabIndex = 71
            Me.lblTDP_ID2.Text = "Doc. Transp."
            '
            'lblPER_ID2
            '
            Me.lblPER_ID2.AutoSize = True
            Me.lblPER_ID2.Location = New System.Drawing.Point(6, 156)
            Me.lblPER_ID2.Name = "lblPER_ID2"
            Me.lblPER_ID2.Size = New System.Drawing.Size(68, 13)
            Me.lblPER_ID2.TabIndex = 70
            Me.lblPER_ID2.Text = "Transportista"
            '
            'lblUNT_NRO_INS2
            '
            Me.lblUNT_NRO_INS2.AutoSize = True
            Me.lblUNT_NRO_INS2.Location = New System.Drawing.Point(218, 182)
            Me.lblUNT_NRO_INS2.Name = "lblUNT_NRO_INS2"
            Me.lblUNT_NRO_INS2.Size = New System.Drawing.Size(81, 13)
            Me.lblUNT_NRO_INS2.TabIndex = 69
            Me.lblUNT_NRO_INS2.Text = "Nro. Inscripción"
            '
            'lblUNT_TARA2
            '
            Me.lblUNT_TARA2.AutoSize = True
            Me.lblUNT_TARA2.Location = New System.Drawing.Point(6, 182)
            Me.lblUNT_TARA2.Name = "lblUNT_TARA2"
            Me.lblUNT_TARA2.Size = New System.Drawing.Size(29, 13)
            Me.lblUNT_TARA2.TabIndex = 68
            Me.lblUNT_TARA2.Text = "Tara"
            '
            'txtMAR_DESCRIPCION_TRA2
            '
            Me.txtMAR_DESCRIPCION_TRA2.Enabled = False
            Me.txtMAR_DESCRIPCION_TRA2.Location = New System.Drawing.Point(259, 130)
            Me.txtMAR_DESCRIPCION_TRA2.Name = "txtMAR_DESCRIPCION_TRA2"
            Me.txtMAR_DESCRIPCION_TRA2.ReadOnly = True
            Me.txtMAR_DESCRIPCION_TRA2.Size = New System.Drawing.Size(180, 20)
            Me.txtMAR_DESCRIPCION_TRA2.TabIndex = 11
            '
            'lblMOD_ID2
            '
            Me.lblMOD_ID2.AutoSize = True
            Me.lblMOD_ID2.Location = New System.Drawing.Point(466, 130)
            Me.lblMOD_ID2.Name = "lblMOD_ID2"
            Me.lblMOD_ID2.Size = New System.Drawing.Size(42, 13)
            Me.lblMOD_ID2.TabIndex = 67
            Me.lblMOD_ID2.Text = "Modelo"
            '
            'txtUNT_ID_2
            '
            Me.txtUNT_ID_2.Location = New System.Drawing.Point(75, 130)
            Me.txtUNT_ID_2.Name = "txtUNT_ID_2"
            Me.txtUNT_ID_2.Size = New System.Drawing.Size(137, 20)
            Me.txtUNT_ID_2.TabIndex = 10
            '
            'lblMAR_ID2
            '
            Me.lblMAR_ID2.AutoSize = True
            Me.lblMAR_ID2.Location = New System.Drawing.Point(218, 130)
            Me.lblMAR_ID2.Name = "lblMAR_ID2"
            Me.lblMAR_ID2.Size = New System.Drawing.Size(37, 13)
            Me.lblMAR_ID2.TabIndex = 66
            Me.lblMAR_ID2.Text = "Marca"
            '
            'txtMOD_DESCRIPCION_TRA2
            '
            Me.txtMOD_DESCRIPCION_TRA2.Enabled = False
            Me.txtMOD_DESCRIPCION_TRA2.Location = New System.Drawing.Point(514, 130)
            Me.txtMOD_DESCRIPCION_TRA2.Name = "txtMOD_DESCRIPCION_TRA2"
            Me.txtMOD_DESCRIPCION_TRA2.ReadOnly = True
            Me.txtMOD_DESCRIPCION_TRA2.Size = New System.Drawing.Size(180, 20)
            Me.txtMOD_DESCRIPCION_TRA2.TabIndex = 12
            '
            'lblUNT_ID2
            '
            Me.lblUNT_ID2.AutoSize = True
            Me.lblUNT_ID2.Location = New System.Drawing.Point(6, 130)
            Me.lblUNT_ID2.Name = "lblUNT_ID2"
            Me.lblUNT_ID2.Size = New System.Drawing.Size(66, 13)
            Me.lblUNT_ID2.TabIndex = 65
            Me.lblUNT_ID2.Text = "Cód. Carreta"
            '
            'txtUNT_TARA_TRA2
            '
            Me.txtUNT_TARA_TRA2.Enabled = False
            Me.txtUNT_TARA_TRA2.Location = New System.Drawing.Point(75, 182)
            Me.txtUNT_TARA_TRA2.Name = "txtUNT_TARA_TRA2"
            Me.txtUNT_TARA_TRA2.ReadOnly = True
            Me.txtUNT_TARA_TRA2.Size = New System.Drawing.Size(88, 20)
            Me.txtUNT_TARA_TRA2.TabIndex = 17
            Me.txtUNT_TARA_TRA2.Text = "0"
            '
            'txtUNT_NRO_INS_TRA2
            '
            Me.txtUNT_NRO_INS_TRA2.Enabled = False
            Me.txtUNT_NRO_INS_TRA2.Location = New System.Drawing.Point(305, 182)
            Me.txtUNT_NRO_INS_TRA2.Name = "txtUNT_NRO_INS_TRA2"
            Me.txtUNT_NRO_INS_TRA2.ReadOnly = True
            Me.txtUNT_NRO_INS_TRA2.Size = New System.Drawing.Size(389, 20)
            Me.txtUNT_NRO_INS_TRA2.TabIndex = 18
            '
            'txtPER_DESCRIPCION_TRA2
            '
            Me.txtPER_DESCRIPCION_TRA2.Enabled = False
            Me.txtPER_DESCRIPCION_TRA2.Location = New System.Drawing.Point(146, 156)
            Me.txtPER_DESCRIPCION_TRA2.Name = "txtPER_DESCRIPCION_TRA2"
            Me.txtPER_DESCRIPCION_TRA2.ReadOnly = True
            Me.txtPER_DESCRIPCION_TRA2.Size = New System.Drawing.Size(204, 20)
            Me.txtPER_DESCRIPCION_TRA2.TabIndex = 14
            '
            'txtPER_ID_TRA2
            '
            Me.txtPER_ID_TRA2.Location = New System.Drawing.Point(75, 156)
            Me.txtPER_ID_TRA2.Name = "txtPER_ID_TRA2"
            Me.txtPER_ID_TRA2.ReadOnly = True
            Me.txtPER_ID_TRA2.Size = New System.Drawing.Size(66, 20)
            Me.txtPER_ID_TRA2.TabIndex = 13
            '
            'txtRUC_TRA1
            '
            Me.txtRUC_TRA1.Enabled = False
            Me.txtRUC_TRA1.Location = New System.Drawing.Point(439, 73)
            Me.txtRUC_TRA1.Name = "txtRUC_TRA1"
            Me.txtRUC_TRA1.ReadOnly = True
            Me.txtRUC_TRA1.Size = New System.Drawing.Size(182, 20)
            Me.txtRUC_TRA1.TabIndex = 6
            '
            'lblTDP_ID1
            '
            Me.lblTDP_ID1.AutoSize = True
            Me.lblTDP_ID1.Location = New System.Drawing.Point(367, 73)
            Me.lblTDP_ID1.Name = "lblTDP_ID1"
            Me.lblTDP_ID1.Size = New System.Drawing.Size(69, 13)
            Me.lblTDP_ID1.TabIndex = 40
            Me.lblTDP_ID1.Text = "Doc. Transp."
            '
            'lblUNT_ESTADO
            '
            Me.lblUNT_ESTADO.AutoSize = True
            Me.lblUNT_ESTADO.Location = New System.Drawing.Point(6, 246)
            Me.lblUNT_ESTADO.Name = "lblUNT_ESTADO"
            Me.lblUNT_ESTADO.Size = New System.Drawing.Size(40, 13)
            Me.lblUNT_ESTADO.TabIndex = 36
            Me.lblUNT_ESTADO.Text = "Estado"
            '
            'lblPER_ID1
            '
            Me.lblPER_ID1.AutoSize = True
            Me.lblPER_ID1.Location = New System.Drawing.Point(6, 73)
            Me.lblPER_ID1.Name = "lblPER_ID1"
            Me.lblPER_ID1.Size = New System.Drawing.Size(68, 13)
            Me.lblPER_ID1.TabIndex = 29
            Me.lblPER_ID1.Text = "Transportista"
            '
            'lblUNT_NRO_INS1
            '
            Me.lblUNT_NRO_INS1.AutoSize = True
            Me.lblUNT_NRO_INS1.Location = New System.Drawing.Point(218, 99)
            Me.lblUNT_NRO_INS1.Name = "lblUNT_NRO_INS1"
            Me.lblUNT_NRO_INS1.Size = New System.Drawing.Size(81, 13)
            Me.lblUNT_NRO_INS1.TabIndex = 28
            Me.lblUNT_NRO_INS1.Text = "Nro. Inscripción"
            '
            'lblUNT_TARA1
            '
            Me.lblUNT_TARA1.AutoSize = True
            Me.lblUNT_TARA1.Location = New System.Drawing.Point(6, 99)
            Me.lblUNT_TARA1.Name = "lblUNT_TARA1"
            Me.lblUNT_TARA1.Size = New System.Drawing.Size(29, 13)
            Me.lblUNT_TARA1.TabIndex = 27
            Me.lblUNT_TARA1.Text = "Tara"
            '
            'lblMOD_ID1
            '
            Me.lblMOD_ID1.AutoSize = True
            Me.lblMOD_ID1.Location = New System.Drawing.Point(466, 47)
            Me.lblMOD_ID1.Name = "lblMOD_ID1"
            Me.lblMOD_ID1.Size = New System.Drawing.Size(42, 13)
            Me.lblMOD_ID1.TabIndex = 26
            Me.lblMOD_ID1.Text = "Modelo"
            '
            'lblMAR_ID1
            '
            Me.lblMAR_ID1.AutoSize = True
            Me.lblMAR_ID1.Location = New System.Drawing.Point(218, 47)
            Me.lblMAR_ID1.Name = "lblMAR_ID1"
            Me.lblMAR_ID1.Size = New System.Drawing.Size(37, 13)
            Me.lblMAR_ID1.TabIndex = 25
            Me.lblMAR_ID1.Text = "Marca"
            '
            'lblUNT_ID1
            '
            Me.lblUNT_ID1.AutoSize = True
            Me.lblUNT_ID1.Location = New System.Drawing.Point(6, 47)
            Me.lblUNT_ID1.Name = "lblUNT_ID1"
            Me.lblUNT_ID1.Size = New System.Drawing.Size(63, 13)
            Me.lblUNT_ID1.TabIndex = 22
            Me.lblUNT_ID1.Text = "Cód. Tracto"
            '
            'chkPLA_ESTADO
            '
            Me.chkPLA_ESTADO.AutoSize = True
            Me.chkPLA_ESTADO.Location = New System.Drawing.Point(75, 245)
            Me.chkPLA_ESTADO.Name = "chkPLA_ESTADO"
            Me.chkPLA_ESTADO.Size = New System.Drawing.Size(15, 14)
            Me.chkPLA_ESTADO.TabIndex = 23
            Me.chkPLA_ESTADO.UseVisualStyleBackColor = True
            '
            'chkPER_ESTADO_TRA1
            '
            Me.chkPER_ESTADO_TRA1.AutoSize = True
            Me.chkPER_ESTADO_TRA1.Enabled = False
            Me.chkPER_ESTADO_TRA1.Location = New System.Drawing.Point(627, 73)
            Me.chkPER_ESTADO_TRA1.Name = "chkPER_ESTADO_TRA1"
            Me.chkPER_ESTADO_TRA1.Size = New System.Drawing.Size(15, 14)
            Me.chkPER_ESTADO_TRA1.TabIndex = 7
            Me.chkPER_ESTADO_TRA1.UseVisualStyleBackColor = True
            '
            'txtPER_DESCRIPCION_TRA1
            '
            Me.txtPER_DESCRIPCION_TRA1.Enabled = False
            Me.txtPER_DESCRIPCION_TRA1.Location = New System.Drawing.Point(146, 73)
            Me.txtPER_DESCRIPCION_TRA1.Name = "txtPER_DESCRIPCION_TRA1"
            Me.txtPER_DESCRIPCION_TRA1.ReadOnly = True
            Me.txtPER_DESCRIPCION_TRA1.Size = New System.Drawing.Size(204, 20)
            Me.txtPER_DESCRIPCION_TRA1.TabIndex = 5
            '
            'txtPER_ID_TRA1
            '
            Me.txtPER_ID_TRA1.Location = New System.Drawing.Point(75, 73)
            Me.txtPER_ID_TRA1.Name = "txtPER_ID_TRA1"
            Me.txtPER_ID_TRA1.ReadOnly = True
            Me.txtPER_ID_TRA1.Size = New System.Drawing.Size(66, 20)
            Me.txtPER_ID_TRA1.TabIndex = 4
            '
            'txtUNT_NRO_INS_TRA1
            '
            Me.txtUNT_NRO_INS_TRA1.Enabled = False
            Me.txtUNT_NRO_INS_TRA1.Location = New System.Drawing.Point(305, 99)
            Me.txtUNT_NRO_INS_TRA1.Name = "txtUNT_NRO_INS_TRA1"
            Me.txtUNT_NRO_INS_TRA1.ReadOnly = True
            Me.txtUNT_NRO_INS_TRA1.Size = New System.Drawing.Size(389, 20)
            Me.txtUNT_NRO_INS_TRA1.TabIndex = 9
            '
            'txtUNT_TARA_TRA1
            '
            Me.txtUNT_TARA_TRA1.Enabled = False
            Me.txtUNT_TARA_TRA1.Location = New System.Drawing.Point(75, 99)
            Me.txtUNT_TARA_TRA1.Name = "txtUNT_TARA_TRA1"
            Me.txtUNT_TARA_TRA1.ReadOnly = True
            Me.txtUNT_TARA_TRA1.Size = New System.Drawing.Size(88, 20)
            Me.txtUNT_TARA_TRA1.TabIndex = 8
            Me.txtUNT_TARA_TRA1.Text = "0"
            '
            'txtMOD_DESCRIPCION_TRA1
            '
            Me.txtMOD_DESCRIPCION_TRA1.Enabled = False
            Me.txtMOD_DESCRIPCION_TRA1.Location = New System.Drawing.Point(514, 47)
            Me.txtMOD_DESCRIPCION_TRA1.Name = "txtMOD_DESCRIPCION_TRA1"
            Me.txtMOD_DESCRIPCION_TRA1.ReadOnly = True
            Me.txtMOD_DESCRIPCION_TRA1.Size = New System.Drawing.Size(180, 20)
            Me.txtMOD_DESCRIPCION_TRA1.TabIndex = 3
            '
            'txtMAR_DESCRIPCION_TRA1
            '
            Me.txtMAR_DESCRIPCION_TRA1.Enabled = False
            Me.txtMAR_DESCRIPCION_TRA1.Location = New System.Drawing.Point(259, 47)
            Me.txtMAR_DESCRIPCION_TRA1.Name = "txtMAR_DESCRIPCION_TRA1"
            Me.txtMAR_DESCRIPCION_TRA1.ReadOnly = True
            Me.txtMAR_DESCRIPCION_TRA1.Size = New System.Drawing.Size(180, 20)
            Me.txtMAR_DESCRIPCION_TRA1.TabIndex = 2
            '
            'txtUNT_ID_1
            '
            Me.txtUNT_ID_1.Location = New System.Drawing.Point(75, 47)
            Me.txtUNT_ID_1.Name = "txtUNT_ID_1"
            Me.txtUNT_ID_1.Size = New System.Drawing.Size(137, 20)
            Me.txtUNT_ID_1.TabIndex = 1
            '
            'frmPlacas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(780, 340)
            Me.Controls.Add(Me.btnImagen)
            Me.Controls.Add(Me.pnCuerpo)
            Me.Name = "frmPlacas"
            Me.Text = "Placas"
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
        Public WithEvents btnImagen As System.Windows.Forms.Button
        Public WithEvents pnCuerpo As System.Windows.Forms.Panel
        Public WithEvents txtRUC_TRA1 As System.Windows.Forms.TextBox
        Friend WithEvents lblTDP_ID1 As System.Windows.Forms.Label
        Friend WithEvents lblUNT_ESTADO As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID1 As System.Windows.Forms.Label
        Friend WithEvents lblUNT_NRO_INS1 As System.Windows.Forms.Label
        Friend WithEvents lblUNT_TARA1 As System.Windows.Forms.Label
        Friend WithEvents lblMOD_ID1 As System.Windows.Forms.Label
        Friend WithEvents lblMAR_ID1 As System.Windows.Forms.Label
        Friend WithEvents lblUNT_ID1 As System.Windows.Forms.Label
        Public WithEvents chkPLA_ESTADO As System.Windows.Forms.CheckBox
        Public WithEvents chkPER_ESTADO_TRA1 As System.Windows.Forms.CheckBox
        Public WithEvents txtPER_DESCRIPCION_TRA1 As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_TRA1 As System.Windows.Forms.TextBox
        Public WithEvents txtUNT_NRO_INS_TRA1 As System.Windows.Forms.TextBox
        Public WithEvents txtUNT_TARA_TRA1 As System.Windows.Forms.TextBox
        Public WithEvents txtMOD_DESCRIPCION_TRA1 As System.Windows.Forms.TextBox
        Public WithEvents txtMAR_DESCRIPCION_TRA1 As System.Windows.Forms.TextBox
        Public WithEvents txtUNT_ID_1 As System.Windows.Forms.TextBox
        Public WithEvents txtRUC_TRA2 As System.Windows.Forms.TextBox
        Friend WithEvents lblTDP_ID2 As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID2 As System.Windows.Forms.Label
        Friend WithEvents lblUNT_NRO_INS2 As System.Windows.Forms.Label
        Friend WithEvents lblUNT_TARA2 As System.Windows.Forms.Label
        Public WithEvents txtMAR_DESCRIPCION_TRA2 As System.Windows.Forms.TextBox
        Friend WithEvents lblMOD_ID2 As System.Windows.Forms.Label
        Public WithEvents txtUNT_ID_2 As System.Windows.Forms.TextBox
        Friend WithEvents lblMAR_ID2 As System.Windows.Forms.Label
        Public WithEvents txtMOD_DESCRIPCION_TRA2 As System.Windows.Forms.TextBox
        Friend WithEvents lblUNT_ID2 As System.Windows.Forms.Label
        Public WithEvents txtUNT_TARA_TRA2 As System.Windows.Forms.TextBox
        Public WithEvents txtUNT_NRO_INS_TRA2 As System.Windows.Forms.TextBox
        Public WithEvents txtPER_DESCRIPCION_TRA2 As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_TRA2 As System.Windows.Forms.TextBox
        Friend WithEvents lblPLA_ID As System.Windows.Forms.Label
        Public WithEvents txtPLA_ID As System.Windows.Forms.TextBox
        Public WithEvents txtPER_BREVETE_CHO As System.Windows.Forms.TextBox
        Friend WithEvents lblPER_BREVETE_CHO As System.Windows.Forms.Label
        Friend WithEvents lblPER_ID_CHO As System.Windows.Forms.Label
        Public WithEvents chkPER_ESTADO_CHO As System.Windows.Forms.CheckBox
        Public WithEvents txtPER_DESCRIPCION_CHO As System.Windows.Forms.TextBox
        Public WithEvents txtPER_ID_CHO As System.Windows.Forms.TextBox
        Public WithEvents chkPER_ESTADO_TRA2 As System.Windows.Forms.CheckBox
    End Class
End Namespace