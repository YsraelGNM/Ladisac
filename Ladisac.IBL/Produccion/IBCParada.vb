Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCParada

#Region "Mantenimientos"
        Sub MantenimientoParada(ByVal mParada As Parada)
#End Region

#Region "Querys"
        Function ParadaGetById(ByVal PAR_ID As Integer) As BE.Parada
        Function ListaParada(ByVal PAR_ID As Integer) As String
#End Region

    End Interface

End Namespace
