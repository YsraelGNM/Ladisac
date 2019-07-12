Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCPuertaHorno

#Region "Mantenimientos"
        Sub MantenimientoPuertaHorno(ByVal mPuertaHorno As PuertaHorno)
#End Region

#Region "Querys"
        Function PuertaHornoGetById(ByVal PUE_ID As Integer) As PuertaHorno
        Function HornoGetById(ByVal HOR_ID As Integer) As Horno
        Function ListaPuertaHorno() As String
        Function ListaPuertaHornoByHorno(ByVal HOR_ID As Integer) As String

#End Region

    End Interface

End Namespace
