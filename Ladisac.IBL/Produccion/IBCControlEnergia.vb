Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCControlEnergia
#Region "Mantenimientos"
        Sub MantenimientoControlEnergia(ByVal mControlEnergia As ControlEnergia)

#End Region

#Region "Querys"
        Function ControlEnergiaGetById(ByVal CEN_ID As Integer) As ControlEnergia
        Function ListadoControlEnergia() As String
        Function ListadoAreaConsumoEnergia() As String
        Function ListaArConEne(ByVal ArConEne As Nullable(Of Integer)) As String
#End Region

    End Interface


End Namespace