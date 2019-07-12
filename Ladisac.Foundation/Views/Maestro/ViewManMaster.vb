Imports Microsoft.Practices.Prism.Events
Imports Microsoft.Practices.Unity

Namespace Ladisac.Foundation.Views
    Public Class ViewManMaster
        <Dependency()>
        Public Property ContainerService As IUnityContainer
        <Dependency()> _
        Public Property EventAggregator As IEventAggregator

        Private Sub ViewManMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If (Not DesignMode) Then
            End If
        End Sub

        Protected Overridable Sub tsb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles tsbNuevo.Click, tsbEditar.Click, tsbCancelarEditar.Click, tsbGrabar.Click, TsbGrabarNuevo.Click, _
            tsbEliminar.Click, tsbDeshacer.Click, tsbAgregar.Click, tsbQuitar.Click, _
            tsbBuscar.Click, tsbInicio.Click, tsbAnterior.Click, tsbSiguiente.Click, tsbFinal.Click, _
            tsbSalir.Click, tsbReportes.Click
            If (DesignMode) Then Return
            LlamarMetodo(sender.ToString)
        End Sub

        Protected Overridable Sub tscPosicion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscPosicion.SelectedIndexChanged
            If (DesignMode) Then Return
            PosicionBarra(sender.text)
        End Sub

        Public Overridable Sub LlamarMetodo(ByVal NombreMetodo As String)
            Select Case NombreMetodo
                Case "NuevoRegistro"
                    OnManNuevo()
                Case "EditarRegistro"
                    OnManEditar()
                Case "CancelarEdicion"
                    OnManCancelarEdicion()
                Case "PrepararGuardar"
                    OnManGuardar()
                Case "PrepararGuardarNuevo"
                Case "PrepararEliminar"
                    OnManEliminar()
                Case "DeshacerCambios"
                    OnManDeshacerCambios()
                Case "AgregarFilaGrid"
                    OnManAgregarFilaGrid()
                Case "QuitarFilaGrid"
                    OnManQuitarFilaGrid()
                Case "BuscarUnRegistro"
                    OnManBuscar()
                Case "PrimerRegistro"
                Case "RegistroAnterior"
                Case "RegistroSiguiente"
                Case "UltimoRegistro"
                Case "Reportes"
                    OnReportes()
                Case "Salir"
                    OnManSalir()
            End Select
        End Sub

        Public Overridable Sub OnManAgregarFilaGrid()
        End Sub
        Public Overridable Sub OnManQuitarFilaGrid()
        End Sub
        Public Overridable Sub OnManDeshacerCambios()
        End Sub
        Public Overridable Sub OnManNuevo()
        End Sub
        Public Overridable Sub OnManSalir()
        End Sub
        Public Overridable Sub OnManEliminar()
        End Sub
        Public Overridable Sub OnManCancelarEdicion()
        End Sub
        Public Overridable Sub OnManEditar()
        End Sub
        Public Overridable Sub OnManGuardar()
        End Sub
        Public Overridable Sub OnManBuscar()
        End Sub
        Public Overridable Sub OnReportes()
        End Sub

        Public Overridable Sub PosicionBarra(ByVal Metodo As String)
        End Sub

        Private Sub frm_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MouseEnter
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = False
            Me.ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = False
        End Sub
    End Class
End Namespace
