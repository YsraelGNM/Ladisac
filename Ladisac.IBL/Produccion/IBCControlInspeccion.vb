Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCControlInspeccion

#Region "Mantenimientos"
        Sub MantenimientoControlInspeccion(ByVal mControlInspeccion As ControlInspeccion)
#End Region

#Region "Querys"
        Function ControlInspeccionGetById(ByVal CIN_ID As Integer) As ControlInspeccion
        Function ListaControlInspeccion() As String
#End Region

    End Interface

End Namespace
