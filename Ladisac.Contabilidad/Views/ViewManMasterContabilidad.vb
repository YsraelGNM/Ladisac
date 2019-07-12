Namespace Ladisac.Contabilidad.Views
    Public Class ViewManMasterContabilidad
        Public Sub menuTodo()
            ' todos

            tsbNuevo.Enabled = False
            tsbEditar.Enabled = False
            tsbCancelarEditar.Enabled = False
            tsbGrabar.Enabled = False
            TsbGrabarNuevo.Enabled = False
            tsbEliminar.Enabled = False
            tsbDeshacer.Enabled = False
            tsbAgregar.Enabled = False
            tsbQuitar.Enabled = False
            tsbBuscar.Enabled = False

            tsbInicio.Enabled = False
            tsbAnterior.Enabled = False
            tsbSiguiente.Enabled = False
            tsbFinal.Enabled = False

            tsbReportes.Enabled = False
            tsbSalir.Enabled = False
            tscPosicion.Visible = False

        End Sub
        Public Sub menuInicio()

            'inicio

            tsbNuevo.Enabled = True
            tsbEditar.Enabled = False
            tsbCancelarEditar.Enabled = False
            tsbGrabar.Enabled = False
            TsbGrabarNuevo.Enabled = False
            tsbEliminar.Enabled = False
            tsbDeshacer.Enabled = False
            tsbAgregar.Enabled = False
            tsbQuitar.Enabled = False
            tsbBuscar.Enabled = True
            tsbInicio.Enabled = False
            tsbAnterior.Enabled = False
            tsbSiguiente.Enabled = False
            tsbFinal.Enabled = False
            tsbReportes.Enabled = False
            tsbSalir.Enabled = True
            tscPosicion.Visible = False


        End Sub
        Public Sub menuBuscar()
            'buscar
            tsbNuevo.Enabled = True
            tsbEditar.Enabled = True
            tsbCancelarEditar.Enabled = False
            tsbGrabar.Enabled = False
            TsbGrabarNuevo.Enabled = False
            tsbEliminar.Enabled = True
            tsbDeshacer.Enabled = False
            tsbAgregar.Enabled = False
            tsbQuitar.Enabled = False
            tsbBuscar.Enabled = True
            tsbInicio.Enabled = False
            tsbAnterior.Enabled = False
            tsbSiguiente.Enabled = False
            tsbFinal.Enabled = False
            tsbReportes.Enabled = False
            tsbSalir.Enabled = True
            tscPosicion.Visible = False
        End Sub

        Public Sub menuEditar()
            'editar
            tsbNuevo.Enabled = False
            tsbEditar.Enabled = False
            tsbCancelarEditar.Enabled = True
            tsbGrabar.Enabled = True
            TsbGrabarNuevo.Enabled = False
            tsbEliminar.Enabled = False
            tsbDeshacer.Enabled = False
            tsbAgregar.Enabled = False
            tsbQuitar.Enabled = False
            tsbBuscar.Enabled = False
            tsbInicio.Enabled = False
            tsbAnterior.Enabled = False
            tsbSiguiente.Enabled = False
            tsbFinal.Enabled = False
            tsbReportes.Enabled = False
            tsbSalir.Enabled = False
            tscPosicion.Visible = False
        End Sub

        Public Sub menuNuevo()
            'nuevo
            tsbNuevo.Enabled = False
            tsbEditar.Enabled = False
            tsbCancelarEditar.Enabled = False
            tsbGrabar.Enabled = True
            TsbGrabarNuevo.Enabled = False
            tsbEliminar.Enabled = False
            tsbDeshacer.Enabled = True
            tsbAgregar.Enabled = False
            tsbQuitar.Enabled = False
            tsbBuscar.Enabled = False
            tsbInicio.Enabled = False
            tsbAnterior.Enabled = False
            tsbSiguiente.Enabled = False
            tsbFinal.Enabled = False
            tsbReportes.Enabled = False
            tsbSalir.Enabled = False
            tscPosicion.Visible = False



        End Sub

        Public Sub HabilitarElementoGrid()
            tsbAgregar.Enabled = True
            tsbQuitar.Enabled = True
        End Sub

        Public Sub DeshabilitarElementoGrid()
            tsbAgregar.Enabled = False
            tsbQuitar.Enabled = False
        End Sub

        Public Property HabilitarReportes As Boolean
            Set(ByVal value As Boolean)
                tsbReportes.Enabled = value
            End Set
            Get
                Return tsbReportes.Enabled
            End Get
        End Property

        Private Sub ViewManMasterContabilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub
    End Class
End Namespace
