Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCControlGrifo

#Region "Mantenimientos"
        Sub MantenimientoControlGrifo(ByVal mControlGrifo As ControlGrifo)
#End Region

#Region "Querys"
        Function ControlGrifoGetById(ByVal MessageID As String) As ControlGrifo
        Function ListaControlGrifo() As String
#End Region

    End Interface

End Namespace
