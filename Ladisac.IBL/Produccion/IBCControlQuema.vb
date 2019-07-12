Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCControlQuema

#Region "Mantenimientos"
        Sub MantenimientoControlQuema(ByVal mControlQuema As ControlQuema)
#End Region

#Region "Querys"
        Function ControlQuemaGetById(ByVal COQ_ID As Integer) As ControlQuema
        Function ListaControlQuema() As String
        Function ListaControlQuemaCombustible() As String
#End Region

    End Interface

End Namespace
