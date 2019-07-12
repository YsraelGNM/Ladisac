Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCDespachoSalida

#Region "Mantenimientos"
        Sub MantenimientoDespachoSalida(ByVal mDespachoSalida As DespachoSalida)
#End Region

#Region "Querys"
        Function DespachoSalidaGetById(ByVal DSA_ID As Integer) As DespachoSalida
        Function ListaDespachoSalida() As String
        Function ListaDespacho(ByVal Numero As String) As String
#End Region

    End Interface

End Namespace
