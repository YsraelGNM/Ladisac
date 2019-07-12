Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCHorno

#Region "Mantenimientos"
        Sub MantenimientoHorno(ByVal mHorno As Horno)
#End Region

#Region "Querys"
        Function HornoGetById(ByVal HOR_ID As Integer) As Horno
        Function ListaHorno() As String
        Function ListaCanchaSecadero(ByVal ENO_ID As String) As String
#End Region

    End Interface

End Namespace
