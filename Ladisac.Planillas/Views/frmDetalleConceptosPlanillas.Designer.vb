
Namespace Ladisac.Planillas.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleConceptosPlanillas
        Inherits ViewManMasterPlanillas

        ' Inherits System.Windows.Forms.Form

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
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.btnDocumento = New System.Windows.Forms.Button()
            Me.txtDetalleDoc = New System.Windows.Forms.TextBox()
            Me.txtTipoDoc = New System.Windows.Forms.TextBox()
            Me.btnCtaCte = New System.Windows.Forms.Button()
            Me.txtCtaCte = New System.Windows.Forms.TextBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtTipoTrabajador = New System.Windows.Forms.TextBox()
            Me.btnBuscar = New System.Windows.Forms.Button()
            Me.btnTipoTrabaBuscar = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtPlanilla = New System.Windows.Forms.TextBox()
            Me.txtTipoPlanilla = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.dataRegimen = New System.Windows.Forms.DataGridView()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.btnLimpiarGasto = New System.Windows.Forms.Button()
            Me.btnLImpiarPasivo = New System.Windows.Forms.Button()
            Me.btngasto = New System.Windows.Forms.Button()
            Me.btnPasivo = New System.Windows.Forms.Button()
            Me.txtGasto = New System.Windows.Forms.TextBox()
            Me.txtPasivo = New System.Windows.Forms.TextBox()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.btnLimpiarInterno = New System.Windows.Forms.Button()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.txtTipoConceptoInterno = New System.Windows.Forms.TextBox()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.txtConceptoInterno = New System.Windows.Forms.TextBox()
            Me.txtFilaOrden = New System.Windows.Forms.TextBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.txtOrdenDeVista = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtItem = New System.Windows.Forms.TextBox()
            Me.chkActivo = New System.Windows.Forms.CheckBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtFactor = New System.Windows.Forms.TextBox()
            Me.chkEsMayorCero = New System.Windows.Forms.CheckBox()
            Me.txtFila = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtColumna = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.chkSeImprimeSiempre = New System.Windows.Forms.CheckBox()
            Me.txtFormula = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.chkEsVariable = New System.Windows.Forms.CheckBox()
            Me.btnConceptoBuscar = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtTipoConcepto = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtConcepto = New System.Windows.Forms.TextBox()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.Panel4.SuspendLayout()
            Me.Panel3.SuspendLayout()
            CType(Me.dataRegimen, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(991, 28)
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.Panel4)
            Me.Panel1.Controls.Add(Me.Panel3)
            Me.Panel1.Controls.Add(Me.dataRegimen)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Location = New System.Drawing.Point(4, 57)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(983, 458)
            Me.Panel1.TabIndex = 4
            '
            'Panel4
            '
            Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel4.Controls.Add(Me.Label13)
            Me.Panel4.Controls.Add(Me.btnDocumento)
            Me.Panel4.Controls.Add(Me.txtDetalleDoc)
            Me.Panel4.Controls.Add(Me.txtTipoDoc)
            Me.Panel4.Controls.Add(Me.btnCtaCte)
            Me.Panel4.Controls.Add(Me.txtCtaCte)
            Me.Panel4.Controls.Add(Me.Label11)
            Me.Panel4.Location = New System.Drawing.Point(7, 257)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(971, 33)
            Me.Panel4.TabIndex = 15
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(248, 6)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(62, 13)
            Me.Label13.TabIndex = 6
            Me.Label13.Text = "Documento"
            '
            'btnDocumento
            '
            Me.btnDocumento.Location = New System.Drawing.Point(631, 3)
            Me.btnDocumento.Name = "btnDocumento"
            Me.btnDocumento.Size = New System.Drawing.Size(28, 23)
            Me.btnDocumento.TabIndex = 5
            Me.btnDocumento.Text = ":::"
            Me.btnDocumento.UseVisualStyleBackColor = True
            '
            'txtDetalleDoc
            '
            Me.txtDetalleDoc.Location = New System.Drawing.Point(319, 4)
            Me.txtDetalleDoc.Name = "txtDetalleDoc"
            Me.txtDetalleDoc.ReadOnly = True
            Me.txtDetalleDoc.Size = New System.Drawing.Size(307, 20)
            Me.txtDetalleDoc.TabIndex = 4
            '
            'txtTipoDoc
            '
            Me.txtTipoDoc.Location = New System.Drawing.Point(230, 5)
            Me.txtTipoDoc.Name = "txtTipoDoc"
            Me.txtTipoDoc.Size = New System.Drawing.Size(11, 20)
            Me.txtTipoDoc.TabIndex = 3
            Me.txtTipoDoc.Visible = False
            '
            'btnCtaCte
            '
            Me.btnCtaCte.Location = New System.Drawing.Point(202, 3)
            Me.btnCtaCte.Name = "btnCtaCte"
            Me.btnCtaCte.Size = New System.Drawing.Size(24, 23)
            Me.btnCtaCte.TabIndex = 2
            Me.btnCtaCte.Text = ":::"
            Me.btnCtaCte.UseVisualStyleBackColor = True
            '
            'txtCtaCte
            '
            Me.txtCtaCte.Location = New System.Drawing.Point(50, 4)
            Me.txtCtaCte.Name = "txtCtaCte"
            Me.txtCtaCte.ReadOnly = True
            Me.txtCtaCte.Size = New System.Drawing.Size(147, 20)
            Me.txtCtaCte.TabIndex = 1
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(4, 4)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(39, 13)
            Me.Label11.TabIndex = 0
            Me.Label11.Text = "CtaCte"
            '
            'Panel3
            '
            Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.Label7)
            Me.Panel3.Controls.Add(Me.txtTipoTrabajador)
            Me.Panel3.Controls.Add(Me.btnBuscar)
            Me.Panel3.Controls.Add(Me.btnTipoTrabaBuscar)
            Me.Panel3.Controls.Add(Me.Label5)
            Me.Panel3.Controls.Add(Me.txtPlanilla)
            Me.Panel3.Controls.Add(Me.txtTipoPlanilla)
            Me.Panel3.Controls.Add(Me.Label4)
            Me.Panel3.Location = New System.Drawing.Point(7, 2)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(970, 54)
            Me.Panel3.TabIndex = 14
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(436, 9)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(76, 13)
            Me.Label7.TabIndex = 11
            Me.Label7.Text = "Tipo Trabajaro"
            '
            'txtTipoTrabajador
            '
            Me.txtTipoTrabajador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtTipoTrabajador.Location = New System.Drawing.Point(518, 6)
            Me.txtTipoTrabajador.Name = "txtTipoTrabajador"
            Me.txtTipoTrabajador.ReadOnly = True
            Me.txtTipoTrabajador.Size = New System.Drawing.Size(332, 20)
            Me.txtTipoTrabajador.TabIndex = 10
            '
            'btnBuscar
            '
            Me.btnBuscar.Location = New System.Drawing.Point(518, 27)
            Me.btnBuscar.Name = "btnBuscar"
            Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
            Me.btnBuscar.TabIndex = 9
            Me.btnBuscar.Text = "Buscar"
            Me.btnBuscar.UseVisualStyleBackColor = True
            '
            'btnTipoTrabaBuscar
            '
            Me.btnTipoTrabaBuscar.Location = New System.Drawing.Point(395, 27)
            Me.btnTipoTrabaBuscar.Name = "btnTipoTrabaBuscar"
            Me.btnTipoTrabaBuscar.Size = New System.Drawing.Size(30, 23)
            Me.btnTipoTrabaBuscar.TabIndex = 7
            Me.btnTipoTrabaBuscar.Text = ":::"
            Me.btnTipoTrabaBuscar.UseVisualStyleBackColor = True
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(52, 32)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(40, 13)
            Me.Label5.TabIndex = 5
            Me.Label5.Text = "Planilla"
            '
            'txtPlanilla
            '
            Me.txtPlanilla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtPlanilla.Location = New System.Drawing.Point(98, 29)
            Me.txtPlanilla.Name = "txtPlanilla"
            Me.txtPlanilla.ReadOnly = True
            Me.txtPlanilla.Size = New System.Drawing.Size(297, 20)
            Me.txtPlanilla.TabIndex = 4
            '
            'txtTipoPlanilla
            '
            Me.txtTipoPlanilla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtTipoPlanilla.Location = New System.Drawing.Point(98, 6)
            Me.txtTipoPlanilla.Name = "txtTipoPlanilla"
            Me.txtTipoPlanilla.ReadOnly = True
            Me.txtTipoPlanilla.Size = New System.Drawing.Size(297, 20)
            Me.txtTipoPlanilla.TabIndex = 1
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(14, 9)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(78, 13)
            Me.Label4.TabIndex = 0
            Me.Label4.Text = "Tipo de planilla"
            '
            'dataRegimen
            '
            Me.dataRegimen.AllowUserToAddRows = False
            Me.dataRegimen.AllowUserToDeleteRows = False
            Me.dataRegimen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dataRegimen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dataRegimen.Location = New System.Drawing.Point(7, 295)
            Me.dataRegimen.Name = "dataRegimen"
            Me.dataRegimen.ReadOnly = True
            Me.dataRegimen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dataRegimen.Size = New System.Drawing.Size(970, 157)
            Me.dataRegimen.TabIndex = 13
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.GroupBox2)
            Me.Panel2.Controls.Add(Me.GroupBox1)
            Me.Panel2.Controls.Add(Me.txtFilaOrden)
            Me.Panel2.Controls.Add(Me.Label14)
            Me.Panel2.Controls.Add(Me.txtOrdenDeVista)
            Me.Panel2.Controls.Add(Me.Label12)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.txtItem)
            Me.Panel2.Controls.Add(Me.chkActivo)
            Me.Panel2.Controls.Add(Me.Label10)
            Me.Panel2.Controls.Add(Me.txtFactor)
            Me.Panel2.Controls.Add(Me.chkEsMayorCero)
            Me.Panel2.Controls.Add(Me.txtFila)
            Me.Panel2.Controls.Add(Me.Label9)
            Me.Panel2.Controls.Add(Me.txtColumna)
            Me.Panel2.Controls.Add(Me.Label8)
            Me.Panel2.Controls.Add(Me.chkSeImprimeSiempre)
            Me.Panel2.Controls.Add(Me.txtFormula)
            Me.Panel2.Controls.Add(Me.Label6)
            Me.Panel2.Controls.Add(Me.chkEsVariable)
            Me.Panel2.Controls.Add(Me.btnConceptoBuscar)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Controls.Add(Me.txtTipoConcepto)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.txtConcepto)
            Me.Panel2.Location = New System.Drawing.Point(7, 59)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(970, 196)
            Me.Panel2.TabIndex = 12
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.btnLimpiarGasto)
            Me.GroupBox2.Controls.Add(Me.btnLImpiarPasivo)
            Me.GroupBox2.Controls.Add(Me.btngasto)
            Me.GroupBox2.Controls.Add(Me.btnPasivo)
            Me.GroupBox2.Controls.Add(Me.txtGasto)
            Me.GroupBox2.Controls.Add(Me.txtPasivo)
            Me.GroupBox2.Controls.Add(Me.Label17)
            Me.GroupBox2.Controls.Add(Me.Label18)
            Me.GroupBox2.Location = New System.Drawing.Point(595, 58)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(328, 71)
            Me.GroupBox2.TabIndex = 35
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Cuentas Contables "
            '
            'btnLimpiarGasto
            '
            Me.btnLimpiarGasto.Location = New System.Drawing.Point(231, 38)
            Me.btnLimpiarGasto.Name = "btnLimpiarGasto"
            Me.btnLimpiarGasto.Size = New System.Drawing.Size(48, 23)
            Me.btnLimpiarGasto.TabIndex = 41
            Me.btnLimpiarGasto.Text = "Limpiar"
            Me.btnLimpiarGasto.UseVisualStyleBackColor = True
            '
            'btnLImpiarPasivo
            '
            Me.btnLImpiarPasivo.Location = New System.Drawing.Point(231, 13)
            Me.btnLImpiarPasivo.Name = "btnLImpiarPasivo"
            Me.btnLImpiarPasivo.Size = New System.Drawing.Size(48, 23)
            Me.btnLImpiarPasivo.TabIndex = 40
            Me.btnLImpiarPasivo.Text = "Limpiar"
            Me.btnLImpiarPasivo.UseVisualStyleBackColor = True
            '
            'btngasto
            '
            Me.btngasto.Location = New System.Drawing.Point(195, 36)
            Me.btngasto.Name = "btngasto"
            Me.btngasto.Size = New System.Drawing.Size(28, 23)
            Me.btngasto.TabIndex = 39
            Me.btngasto.Text = ":::"
            Me.btngasto.UseVisualStyleBackColor = True
            '
            'btnPasivo
            '
            Me.btnPasivo.Location = New System.Drawing.Point(194, 13)
            Me.btnPasivo.Name = "btnPasivo"
            Me.btnPasivo.Size = New System.Drawing.Size(30, 23)
            Me.btnPasivo.TabIndex = 38
            Me.btnPasivo.Text = ":::"
            Me.btnPasivo.UseVisualStyleBackColor = True
            '
            'txtGasto
            '
            Me.txtGasto.Location = New System.Drawing.Point(88, 38)
            Me.txtGasto.Name = "txtGasto"
            Me.txtGasto.ReadOnly = True
            Me.txtGasto.Size = New System.Drawing.Size(100, 20)
            Me.txtGasto.TabIndex = 37
            '
            'txtPasivo
            '
            Me.txtPasivo.Location = New System.Drawing.Point(88, 15)
            Me.txtPasivo.Name = "txtPasivo"
            Me.txtPasivo.ReadOnly = True
            Me.txtPasivo.Size = New System.Drawing.Size(100, 20)
            Me.txtPasivo.TabIndex = 36
            '
            'Label17
            '
            Me.Label17.AutoSize = True
            Me.Label17.Location = New System.Drawing.Point(7, 19)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(76, 13)
            Me.Label17.TabIndex = 35
            Me.Label17.Text = "Cuenta Pasivo"
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.Location = New System.Drawing.Point(11, 43)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(72, 13)
            Me.Label18.TabIndex = 34
            Me.Label18.Text = "Cuenta Gasto"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.btnLimpiarInterno)
            Me.GroupBox1.Controls.Add(Me.Button1)
            Me.GroupBox1.Controls.Add(Me.Label15)
            Me.GroupBox1.Controls.Add(Me.txtTipoConceptoInterno)
            Me.GroupBox1.Controls.Add(Me.Label16)
            Me.GroupBox1.Controls.Add(Me.txtConceptoInterno)
            Me.GroupBox1.Location = New System.Drawing.Point(593, -2)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(329, 52)
            Me.GroupBox1.TabIndex = 34
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "ConceptoInterno Imprimir"
            '
            'btnLimpiarInterno
            '
            Me.btnLimpiarInterno.Location = New System.Drawing.Point(280, 19)
            Me.btnLimpiarInterno.Name = "btnLimpiarInterno"
            Me.btnLimpiarInterno.Size = New System.Drawing.Size(48, 23)
            Me.btnLimpiarInterno.TabIndex = 19
            Me.btnLimpiarInterno.Text = "Limpiar"
            Me.btnLimpiarInterno.UseVisualStyleBackColor = True
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(257, 19)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(24, 23)
            Me.Button1.TabIndex = 18
            Me.Button1.Text = ":::"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'Label15
            '
            Me.Label15.AutoSize = True
            Me.Label15.Location = New System.Drawing.Point(1, 21)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(28, 13)
            Me.Label15.TabIndex = 14
            Me.Label15.Text = "Tipo"
            '
            'txtTipoConceptoInterno
            '
            Me.txtTipoConceptoInterno.Location = New System.Drawing.Point(29, 19)
            Me.txtTipoConceptoInterno.Name = "txtTipoConceptoInterno"
            Me.txtTipoConceptoInterno.ReadOnly = True
            Me.txtTipoConceptoInterno.Size = New System.Drawing.Size(61, 20)
            Me.txtTipoConceptoInterno.TabIndex = 15
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Location = New System.Drawing.Point(89, 23)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(53, 13)
            Me.Label16.TabIndex = 16
            Me.Label16.Text = "Concepto"
            '
            'txtConceptoInterno
            '
            Me.txtConceptoInterno.Location = New System.Drawing.Point(143, 20)
            Me.txtConceptoInterno.MaxLength = 45
            Me.txtConceptoInterno.Name = "txtConceptoInterno"
            Me.txtConceptoInterno.ReadOnly = True
            Me.txtConceptoInterno.Size = New System.Drawing.Size(114, 20)
            Me.txtConceptoInterno.TabIndex = 17
            '
            'txtFilaOrden
            '
            Me.txtFilaOrden.Location = New System.Drawing.Point(394, 47)
            Me.txtFilaOrden.Name = "txtFilaOrden"
            Me.txtFilaOrden.Size = New System.Drawing.Size(31, 20)
            Me.txtFilaOrden.TabIndex = 33
            '
            'Label14
            '
            Me.Label14.AutoSize = True
            Me.Label14.Location = New System.Drawing.Point(324, 49)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(55, 13)
            Me.Label14.TabIndex = 32
            Me.Label14.Text = "Fila Orden"
            '
            'txtOrdenDeVista
            '
            Me.txtOrdenDeVista.Location = New System.Drawing.Point(97, 74)
            Me.txtOrdenDeVista.Name = "txtOrdenDeVista"
            Me.txtOrdenDeVista.Size = New System.Drawing.Size(30, 20)
            Me.txtOrdenDeVista.TabIndex = 31
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(15, 77)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(77, 13)
            Me.Label12.TabIndex = 29
            Me.Label12.Text = "Orden de Vista"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(219, 10)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(16, 13)
            Me.Label3.TabIndex = 27
            Me.Label3.Text = "Id"
            '
            'txtItem
            '
            Me.txtItem.Location = New System.Drawing.Point(241, 7)
            Me.txtItem.Name = "txtItem"
            Me.txtItem.ReadOnly = True
            Me.txtItem.Size = New System.Drawing.Size(41, 20)
            Me.txtItem.TabIndex = 26
            '
            'chkActivo
            '
            Me.chkActivo.AutoSize = True
            Me.chkActivo.Location = New System.Drawing.Point(433, 73)
            Me.chkActivo.Name = "chkActivo"
            Me.chkActivo.Size = New System.Drawing.Size(56, 17)
            Me.chkActivo.TabIndex = 25
            Me.chkActivo.Text = "Activo"
            Me.chkActivo.UseVisualStyleBackColor = True
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(55, 57)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(37, 13)
            Me.Label10.TabIndex = 24
            Me.Label10.Text = "Factor"
            '
            'txtFactor
            '
            Me.txtFactor.Location = New System.Drawing.Point(98, 51)
            Me.txtFactor.Name = "txtFactor"
            Me.txtFactor.Size = New System.Drawing.Size(100, 20)
            Me.txtFactor.TabIndex = 23
            '
            'chkEsMayorCero
            '
            Me.chkEsMayorCero.AutoSize = True
            Me.chkEsMayorCero.Location = New System.Drawing.Point(433, 49)
            Me.chkEsMayorCero.Name = "chkEsMayorCero"
            Me.chkEsMayorCero.Size = New System.Drawing.Size(163, 17)
            Me.chkEsMayorCero.TabIndex = 22
            Me.chkEsMayorCero.Text = "Imprimir si es Mayor que Cero"
            Me.chkEsMayorCero.UseVisualStyleBackColor = True
            '
            'txtFila
            '
            Me.txtFila.Location = New System.Drawing.Point(394, 25)
            Me.txtFila.Name = "txtFila"
            Me.txtFila.Size = New System.Drawing.Size(31, 20)
            Me.txtFila.TabIndex = 21
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(324, 27)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(62, 13)
            Me.Label9.TabIndex = 20
            Me.Label9.Text = "Fila Imprime"
            '
            'txtColumna
            '
            Me.txtColumna.Location = New System.Drawing.Point(394, 3)
            Me.txtColumna.Name = "txtColumna"
            Me.txtColumna.Size = New System.Drawing.Size(31, 20)
            Me.txtColumna.TabIndex = 19
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(299, 5)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(87, 13)
            Me.Label8.TabIndex = 18
            Me.Label8.Text = "Columna Imprime"
            '
            'chkSeImprimeSiempre
            '
            Me.chkSeImprimeSiempre.AutoSize = True
            Me.chkSeImprimeSiempre.Location = New System.Drawing.Point(433, 29)
            Me.chkSeImprimeSiempre.Name = "chkSeImprimeSiempre"
            Me.chkSeImprimeSiempre.Size = New System.Drawing.Size(75, 17)
            Me.chkSeImprimeSiempre.TabIndex = 17
            Me.chkSeImprimeSiempre.Text = "se imprime"
            Me.chkSeImprimeSiempre.UseVisualStyleBackColor = True
            '
            'txtFormula
            '
            Me.txtFormula.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtFormula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtFormula.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtFormula.Location = New System.Drawing.Point(97, 138)
            Me.txtFormula.Multiline = True
            Me.txtFormula.Name = "txtFormula"
            Me.txtFormula.Size = New System.Drawing.Size(867, 53)
            Me.txtFormula.TabIndex = 16
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(48, 141)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(44, 13)
            Me.Label6.TabIndex = 15
            Me.Label6.Text = "Formula"
            '
            'chkEsVariable
            '
            Me.chkEsVariable.AutoSize = True
            Me.chkEsVariable.Location = New System.Drawing.Point(433, 6)
            Me.chkEsVariable.Name = "chkEsVariable"
            Me.chkEsVariable.Size = New System.Drawing.Size(100, 17)
            Me.chkEsVariable.TabIndex = 14
            Me.chkEsVariable.Text = "Es una Variable"
            Me.chkEsVariable.UseVisualStyleBackColor = True
            '
            'btnConceptoBuscar
            '
            Me.btnConceptoBuscar.Location = New System.Drawing.Point(284, 28)
            Me.btnConceptoBuscar.Name = "btnConceptoBuscar"
            Me.btnConceptoBuscar.Size = New System.Drawing.Size(24, 23)
            Me.btnConceptoBuscar.TabIndex = 13
            Me.btnConceptoBuscar.Text = ":::"
            Me.btnConceptoBuscar.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(64, 10)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(28, 13)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Tipo"
            '
            'txtTipoConcepto
            '
            Me.txtTipoConcepto.Location = New System.Drawing.Point(98, 7)
            Me.txtTipoConcepto.Name = "txtTipoConcepto"
            Me.txtTipoConcepto.ReadOnly = True
            Me.txtTipoConcepto.Size = New System.Drawing.Size(115, 20)
            Me.txtTipoConcepto.TabIndex = 7
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(39, 32)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(53, 13)
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "Concepto"
            '
            'txtConcepto
            '
            Me.txtConcepto.Location = New System.Drawing.Point(98, 29)
            Me.txtConcepto.MaxLength = 45
            Me.txtConcepto.Name = "txtConcepto"
            Me.txtConcepto.ReadOnly = True
            Me.txtConcepto.Size = New System.Drawing.Size(185, 20)
            Me.txtConcepto.TabIndex = 9
            '
            'frmDetalleConceptosPlanillas
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(991, 520)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "frmDetalleConceptosPlanillas"
            Me.Text = "frmDetalleConceptosPlanillas"
            Me.Controls.SetChildIndex(Me.Panel1, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            CType(Me.dataRegimen, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents btnBuscar As System.Windows.Forms.Button
        Friend WithEvents btnTipoTrabaBuscar As System.Windows.Forms.Button
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtPlanilla As System.Windows.Forms.TextBox
        Friend WithEvents txtTipoPlanilla As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents dataRegimen As System.Windows.Forms.DataGridView
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents btnConceptoBuscar As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtTipoConcepto As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtTipoTrabajador As System.Windows.Forms.TextBox
        Friend WithEvents chkEsVariable As System.Windows.Forms.CheckBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtFactor As System.Windows.Forms.TextBox
        Friend WithEvents chkEsMayorCero As System.Windows.Forms.CheckBox
        Friend WithEvents txtFila As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtColumna As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents chkSeImprimeSiempre As System.Windows.Forms.CheckBox
        Friend WithEvents txtFormula As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtItem As System.Windows.Forms.TextBox
        Friend WithEvents txtOrdenDeVista As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents btnDocumento As System.Windows.Forms.Button
        Friend WithEvents txtDetalleDoc As System.Windows.Forms.TextBox
        Friend WithEvents txtTipoDoc As System.Windows.Forms.TextBox
        Friend WithEvents btnCtaCte As System.Windows.Forms.Button
        Friend WithEvents txtCtaCte As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents txtFilaOrden As System.Windows.Forms.TextBox
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents txtTipoConceptoInterno As System.Windows.Forms.TextBox
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents txtConceptoInterno As System.Windows.Forms.TextBox
        Friend WithEvents btnLimpiarInterno As System.Windows.Forms.Button
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents btnLimpiarGasto As System.Windows.Forms.Button
        Friend WithEvents btnLImpiarPasivo As System.Windows.Forms.Button
        Friend WithEvents btngasto As System.Windows.Forms.Button
        Friend WithEvents btnPasivo As System.Windows.Forms.Button
        Friend WithEvents txtGasto As System.Windows.Forms.TextBox
        Friend WithEvents txtPasivo As System.Windows.Forms.TextBox
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
    End Class

End Namespace