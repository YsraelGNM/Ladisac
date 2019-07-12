Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCCancha

#Region "Mantenimientos"
        Sub MantenimientoCancha(ByVal mCancha As Cancha)
#End Region

#Region "Querys"
        Function CanchaGetById(ByVal CAN_ID As Integer) As BE.Cancha
        Function ListaCancha() As String
#End Region

    End Interface

End Namespace
