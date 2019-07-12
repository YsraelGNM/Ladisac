Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCControlExtrusora

#Region "Mantenimientos"
        Sub MantenimientoControlExtrusora(ByVal mControlExtrusora As ControlExtrusora)
#End Region

#Region "Querys"
        Function ControlExtrusoraGetById(ByVal CEX_ID As Integer) As BE.ControlExtrusora
        Function ListaControlExtrusora() As String
        Function ValidarHoroDigital(ByVal CPA_ID As Integer, ByVal HoroDigital As Decimal) As String
#End Region

    End Interface

End Namespace
