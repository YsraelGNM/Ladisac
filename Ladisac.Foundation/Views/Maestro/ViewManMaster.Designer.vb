Namespace Ladisac.Foundation.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ViewManMaster
        Inherits Ladisac.Foundation.Views.ViewMaster

        'Form overrides dispose to clean up the component list.
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

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.tsBarra = New System.Windows.Forms.ToolStrip()
            Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
            Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
            Me.tsbCancelarEditar = New System.Windows.Forms.ToolStripButton()
            Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
            Me.TsbGrabarNuevo = New System.Windows.Forms.ToolStripButton()
            Me.tsbEliminar = New System.Windows.Forms.ToolStripButton()
            Me.tsbDeshacer = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbAgregar = New System.Windows.Forms.ToolStripButton()
            Me.tsbQuitar = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbBuscar = New System.Windows.Forms.ToolStripButton()
            Me.tsbInicio = New System.Windows.Forms.ToolStripButton()
            Me.tsbAnterior = New System.Windows.Forms.ToolStripButton()
            Me.tsbSiguiente = New System.Windows.Forms.ToolStripButton()
            Me.tsbFinal = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbReportes = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
            Me.tscPosicion = New System.Windows.Forms.ToolStripComboBox()
            Me.tsBarra.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Size = New System.Drawing.Size(538, 28)
            '
            'tsBarra
            '
            Me.tsBarra.Dock = System.Windows.Forms.DockStyle.None
            Me.tsBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbCancelarEditar, Me.tsbGrabar, Me.TsbGrabarNuevo, Me.tsbEliminar, Me.tsbDeshacer, Me.ToolStripSeparator3, Me.tsbAgregar, Me.tsbQuitar, Me.ToolStripSeparator4, Me.tsbBuscar, Me.tsbInicio, Me.tsbAnterior, Me.tsbSiguiente, Me.tsbFinal, Me.ToolStripSeparator5, Me.tsbReportes, Me.ToolStripSeparator6, Me.tsbSalir, Me.ToolStripSeparator7, Me.tscPosicion})
            Me.tsBarra.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
            Me.tsBarra.Location = New System.Drawing.Point(0, 28)
            Me.tsBarra.Name = "tsBarra"
            Me.tsBarra.Size = New System.Drawing.Size(475, 25)
            Me.tsBarra.TabIndex = 1
            Me.tsBarra.Text = "Mantenimiento de tablas"
            '
            'tsbNuevo
            '
            Me.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbNuevo.Image = Global.My.Resources.Resources.Nuevo1
            Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbNuevo.Name = "tsbNuevo"
            Me.tsbNuevo.Size = New System.Drawing.Size(23, 22)
            Me.tsbNuevo.Text = "NuevoRegistro"
            Me.tsbNuevo.ToolTipText = "Nuevo registro"
            '
            'tsbEditar
            '
            Me.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbEditar.Image = Global.My.Resources.Resources.Editar
            Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbEditar.Name = "tsbEditar"
            Me.tsbEditar.Size = New System.Drawing.Size(23, 22)
            Me.tsbEditar.Text = "EditarRegistro"
            Me.tsbEditar.ToolTipText = "Editar registro"
            '
            'tsbCancelarEditar
            '
            Me.tsbCancelarEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbCancelarEditar.Image = Global.My.Resources.Resources.CancelarEditar
            Me.tsbCancelarEditar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbCancelarEditar.Name = "tsbCancelarEditar"
            Me.tsbCancelarEditar.Size = New System.Drawing.Size(23, 22)
            Me.tsbCancelarEditar.Text = "CancelarEdicion"
            Me.tsbCancelarEditar.ToolTipText = "Cancelar editar registro"
            '
            'tsbGrabar
            '
            Me.tsbGrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbGrabar.Image = Global.My.Resources.Resources.Grabar
            Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbGrabar.Name = "tsbGrabar"
            Me.tsbGrabar.Size = New System.Drawing.Size(23, 22)
            Me.tsbGrabar.Text = "PrepararGuardar"
            Me.tsbGrabar.ToolTipText = "Grabar registro"
            '
            'TsbGrabarNuevo
            '
            Me.TsbGrabarNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TsbGrabarNuevo.Image = Global.My.Resources.Resources.GrabarNuevo
            Me.TsbGrabarNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TsbGrabarNuevo.Name = "TsbGrabarNuevo"
            Me.TsbGrabarNuevo.Size = New System.Drawing.Size(23, 22)
            Me.TsbGrabarNuevo.Text = "PrepararGuardarNuevo"
            Me.TsbGrabarNuevo.ToolTipText = "Grabar registro y crear nuevo"
            '
            'tsbEliminar
            '
            Me.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbEliminar.Image = Global.My.Resources.Resources.Eliminar
            Me.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbEliminar.Name = "tsbEliminar"
            Me.tsbEliminar.Size = New System.Drawing.Size(23, 22)
            Me.tsbEliminar.Text = "PrepararEliminar"
            Me.tsbEliminar.ToolTipText = "Eliminar registro"
            '
            'tsbDeshacer
            '
            Me.tsbDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbDeshacer.Image = Global.My.Resources.Resources.Deshacer
            Me.tsbDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbDeshacer.Name = "tsbDeshacer"
            Me.tsbDeshacer.Size = New System.Drawing.Size(23, 22)
            Me.tsbDeshacer.Text = "DeshacerCambios"
            Me.tsbDeshacer.ToolTipText = "Deshacer cambios"
            '
            'ToolStripSeparator3
            '
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
            '
            'tsbAgregar
            '
            Me.tsbAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbAgregar.Image = Global.My.Resources.Resources.Agregar
            Me.tsbAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbAgregar.Name = "tsbAgregar"
            Me.tsbAgregar.Size = New System.Drawing.Size(23, 22)
            Me.tsbAgregar.Text = "AgregarFilaGrid"
            Me.tsbAgregar.ToolTipText = "Agregar fila a la grilla"
            '
            'tsbQuitar
            '
            Me.tsbQuitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbQuitar.Image = Global.My.Resources.Resources.Quitar
            Me.tsbQuitar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbQuitar.Name = "tsbQuitar"
            Me.tsbQuitar.Size = New System.Drawing.Size(23, 22)
            Me.tsbQuitar.Text = "QuitarFilaGrid"
            Me.tsbQuitar.ToolTipText = "Quitar fila de la grilla"
            '
            'ToolStripSeparator4
            '
            Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
            Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
            '
            'tsbBuscar
            '
            Me.tsbBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbBuscar.Image = Global.My.Resources.Resources.Buscar
            Me.tsbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbBuscar.Name = "tsbBuscar"
            Me.tsbBuscar.Size = New System.Drawing.Size(23, 22)
            Me.tsbBuscar.Text = "BuscarUnRegistro"
            '
            'tsbInicio
            '
            Me.tsbInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbInicio.Image = Global.My.Resources.Resources.Inicio
            Me.tsbInicio.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbInicio.Name = "tsbInicio"
            Me.tsbInicio.Size = New System.Drawing.Size(23, 22)
            Me.tsbInicio.Text = "PrimerRegistro"
            Me.tsbInicio.ToolTipText = "Primer registro"
            '
            'tsbAnterior
            '
            Me.tsbAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbAnterior.Image = Global.My.Resources.Resources.Anterior
            Me.tsbAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbAnterior.Name = "tsbAnterior"
            Me.tsbAnterior.Size = New System.Drawing.Size(23, 22)
            Me.tsbAnterior.Text = "RegistroAnterior"
            Me.tsbAnterior.ToolTipText = "Registro anterior"
            '
            'tsbSiguiente
            '
            Me.tsbSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbSiguiente.Image = Global.My.Resources.Resources.Siguiente
            Me.tsbSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbSiguiente.Name = "tsbSiguiente"
            Me.tsbSiguiente.Size = New System.Drawing.Size(23, 22)
            Me.tsbSiguiente.Text = "RegistroSiguiente"
            Me.tsbSiguiente.ToolTipText = "Registro siguiente"
            '
            'tsbFinal
            '
            Me.tsbFinal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbFinal.Image = Global.My.Resources.Resources.Final
            Me.tsbFinal.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbFinal.Name = "tsbFinal"
            Me.tsbFinal.Size = New System.Drawing.Size(23, 22)
            Me.tsbFinal.Text = "UltimoRegistro"
            Me.tsbFinal.ToolTipText = "Último registro"
            '
            'ToolStripSeparator5
            '
            Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
            Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
            '
            'tsbReportes
            '
            Me.tsbReportes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbReportes.Image = Global.My.Resources.Resources.Reporte2
            Me.tsbReportes.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbReportes.Name = "tsbReportes"
            Me.tsbReportes.Size = New System.Drawing.Size(23, 22)
            Me.tsbReportes.Text = "Reportes"
            '
            'ToolStripSeparator6
            '
            Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
            Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
            '
            'tsbSalir
            '
            Me.tsbSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbSalir.Image = Global.My.Resources.Resources.Salir
            Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbSalir.Name = "tsbSalir"
            Me.tsbSalir.Size = New System.Drawing.Size(23, 22)
            Me.tsbSalir.Text = "Salir"
            Me.tsbSalir.ToolTipText = "Salir del formulario"
            '
            'ToolStripSeparator7
            '
            Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
            Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
            '
            'tscPosicion
            '
            Me.tscPosicion.AutoSize = False
            Me.tscPosicion.BackColor = System.Drawing.SystemColors.Control
            Me.tscPosicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.tscPosicion.DropDownWidth = 60
            Me.tscPosicion.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tscPosicion.ForeColor = System.Drawing.SystemColors.WindowText
            Me.tscPosicion.Items.AddRange(New Object() {"^", "V", ">", "<"})
            Me.tscPosicion.Name = "tscPosicion"
            Me.tscPosicion.Size = New System.Drawing.Size(30, 18)
            Me.tscPosicion.ToolTipText = "Posición de la barra en la pantalla"
            '
            'ViewManMaster
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(538, 394)
            Me.Controls.Add(Me.tsBarra)
            Me.Name = "ViewManMaster"
            Me.Text = "ViewManMaster"
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.Controls.SetChildIndex(Me.tsBarra, 0)
            Me.tsBarra.ResumeLayout(False)
            Me.tsBarra.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents tsBarra As System.Windows.Forms.ToolStrip
        Public WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbCancelarEditar As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
        Public WithEvents TsbGrabarNuevo As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbEliminar As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbDeshacer As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tsbAgregar As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbQuitar As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tsbBuscar As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbInicio As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbAnterior As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbSiguiente As System.Windows.Forms.ToolStripButton
        Public WithEvents tsbFinal As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tsbReportes As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
        Public WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
        Public WithEvents tscPosicion As System.Windows.Forms.ToolStripComboBox
    End Class

End Namespace
