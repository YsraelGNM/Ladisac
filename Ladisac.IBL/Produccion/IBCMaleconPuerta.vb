Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCMaleconPuerta

#Region "Mantenimientos"
        Sub MantenimientoMaleconPuerta(ByVal mMaleconPuerta As MaleconPuerta)
#End Region

#Region "Querys"
        Function MaleconPuertaGetById(ByVal MAL_ID As Integer) As MaleconPuerta
        Function PuertaHornoGetById(ByVal PUE_ID As Integer) As PuertaHorno
        Function ListaMaleconPuerta() As String
#End Region

    End Interface

End Namespace
