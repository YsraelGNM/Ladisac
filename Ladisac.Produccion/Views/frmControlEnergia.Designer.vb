<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlEnergia
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_AR_CON_ENE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONSUMO_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_FACTOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_PROPORCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_HI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_HF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_KWH_INI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_KWH_FIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_HO_PU_IN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_HO_PU_FI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_TOTAL_HO_PUNTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_RE_IN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_RE_FI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_AC_PLA_KWH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_AC_HOR_KWH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_HORAS_TRABAJO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_RE_PLANTA_KVAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_GRUPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEN_TARIFA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(991, 28)
        Me.lblTitle.Text = "Control Energia"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CEN_ID, Me.CEN_AR_CON_ENE, Me.CONSUMO_ID, Me.CEN_DESCRIPCION, Me.CEN_FECHA, Me.CEN_FACTOR, Me.CEN_PROPORCION, Me.CEN_HI, Me.CEN_HF, Me.CEN_KWH_INI, Me.CEN_KWH_FIN, Me.CEN_HO_PU_IN, Me.CEN_HO_PU_FI, Me.CEN_TOTAL_HO_PUNTA, Me.CEN_RE_IN, Me.CEN_RE_FI, Me.CEN_AC_PLA_KWH, Me.CEN_AC_HOR_KWH, Me.CEN_HORAS_TRABAJO, Me.CEN_RE_PLANTA_KVAR, Me.CEN_GRUPO, Me.CEN_TARIFA})
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 68)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(967, 399)
        Me.dgvDetalle.TabIndex = 2
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "CEN_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "AREA CONSUMO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "DESCRIPCION"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "FACTOR"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "PROPORCION"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "H.I."
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        DataGridViewCellStyle2.Format = "00.##"
        DataGridViewCellStyle2.NullValue = "00.00"
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn9.HeaderText = "H.F."
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "KWH_INI"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "KWH_FIN"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "HO_PU_INI"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "HO_PU_FIN"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "TOTAL_HO_PUNTA"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "RE_INI"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "RE_FIN"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "AC_PLA_KWH"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "AC_HOR_KWH"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "HORAS_TRABAJO"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "RE_PLANTA_KVAR"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.HeaderText = "GRUPO"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.HeaderText = "TARIFA"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        '
        'CEN_ID
        '
        Me.CEN_ID.HeaderText = "CEN_ID"
        Me.CEN_ID.Name = "CEN_ID"
        Me.CEN_ID.Visible = False
        '
        'CEN_AR_CON_ENE
        '
        Me.CEN_AR_CON_ENE.HeaderText = "AREA CONSUMO"
        Me.CEN_AR_CON_ENE.Name = "CEN_AR_CON_ENE"
        '
        'CONSUMO_ID
        '
        Me.CONSUMO_ID.HeaderText = "CODIGO"
        Me.CONSUMO_ID.Name = "CONSUMO_ID"
        '
        'CEN_DESCRIPCION
        '
        Me.CEN_DESCRIPCION.HeaderText = "DESCRIPCION"
        Me.CEN_DESCRIPCION.Name = "CEN_DESCRIPCION"
        '
        'CEN_FECHA
        '
        Me.CEN_FECHA.HeaderText = "FECHA"
        Me.CEN_FECHA.Name = "CEN_FECHA"
        '
        'CEN_FACTOR
        '
        Me.CEN_FACTOR.HeaderText = "FACTOR"
        Me.CEN_FACTOR.Name = "CEN_FACTOR"
        '
        'CEN_PROPORCION
        '
        Me.CEN_PROPORCION.HeaderText = "PROPORCION"
        Me.CEN_PROPORCION.Name = "CEN_PROPORCION"
        '
        'CEN_HI
        '
        Me.CEN_HI.HeaderText = "H.I."
        Me.CEN_HI.Name = "CEN_HI"
        '
        'CEN_HF
        '
        DataGridViewCellStyle1.NullValue = Nothing
        Me.CEN_HF.DefaultCellStyle = DataGridViewCellStyle1
        Me.CEN_HF.HeaderText = "H.F."
        Me.CEN_HF.Name = "CEN_HF"
        '
        'CEN_KWH_INI
        '
        Me.CEN_KWH_INI.HeaderText = "KWH_INI"
        Me.CEN_KWH_INI.Name = "CEN_KWH_INI"
        '
        'CEN_KWH_FIN
        '
        Me.CEN_KWH_FIN.HeaderText = "KWH_FIN"
        Me.CEN_KWH_FIN.Name = "CEN_KWH_FIN"
        '
        'CEN_HO_PU_IN
        '
        Me.CEN_HO_PU_IN.HeaderText = "HO_PU_INI"
        Me.CEN_HO_PU_IN.Name = "CEN_HO_PU_IN"
        '
        'CEN_HO_PU_FI
        '
        Me.CEN_HO_PU_FI.HeaderText = "HO_PU_FIN"
        Me.CEN_HO_PU_FI.Name = "CEN_HO_PU_FI"
        '
        'CEN_TOTAL_HO_PUNTA
        '
        Me.CEN_TOTAL_HO_PUNTA.HeaderText = "TOTAL_HO_PUNTA"
        Me.CEN_TOTAL_HO_PUNTA.Name = "CEN_TOTAL_HO_PUNTA"
        '
        'CEN_RE_IN
        '
        Me.CEN_RE_IN.HeaderText = "RE_INI"
        Me.CEN_RE_IN.Name = "CEN_RE_IN"
        '
        'CEN_RE_FI
        '
        Me.CEN_RE_FI.HeaderText = "RE_FIN"
        Me.CEN_RE_FI.Name = "CEN_RE_FI"
        '
        'CEN_AC_PLA_KWH
        '
        Me.CEN_AC_PLA_KWH.HeaderText = "AC_PLA_KWH"
        Me.CEN_AC_PLA_KWH.Name = "CEN_AC_PLA_KWH"
        '
        'CEN_AC_HOR_KWH
        '
        Me.CEN_AC_HOR_KWH.HeaderText = "AC_HOR_KWH"
        Me.CEN_AC_HOR_KWH.Name = "CEN_AC_HOR_KWH"
        '
        'CEN_HORAS_TRABAJO
        '
        Me.CEN_HORAS_TRABAJO.HeaderText = "HORAS_TRABAJO"
        Me.CEN_HORAS_TRABAJO.Name = "CEN_HORAS_TRABAJO"
        '
        'CEN_RE_PLANTA_KVAR
        '
        Me.CEN_RE_PLANTA_KVAR.HeaderText = "RE_PLANTA_KVAR"
        Me.CEN_RE_PLANTA_KVAR.Name = "CEN_RE_PLANTA_KVAR"
        '
        'CEN_GRUPO
        '
        Me.CEN_GRUPO.HeaderText = "GRUPO"
        Me.CEN_GRUPO.Name = "CEN_GRUPO"
        '
        'CEN_TARIFA
        '
        Me.CEN_TARIFA.HeaderText = "TARIFA"
        Me.CEN_TARIFA.Name = "CEN_TARIFA"
        '
        'frmControlEnergia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 479)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Name = "frmControlEnergia"
        Me.Text = "Control Energia"
        Me.Controls.SetChildIndex(Me.dgvDetalle, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_AR_CON_ENE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONSUMO_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_FACTOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_PROPORCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_HI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_HF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_KWH_INI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_KWH_FIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_HO_PU_IN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_HO_PU_FI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_TOTAL_HO_PUNTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_RE_IN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_RE_FI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_AC_PLA_KWH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_AC_HOR_KWH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_HORAS_TRABAJO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_RE_PLANTA_KVAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_GRUPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEN_TARIFA As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
