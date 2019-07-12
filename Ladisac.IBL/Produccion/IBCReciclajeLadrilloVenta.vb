Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCReciclajeLadrilloVenta

#Region "Mantenimientos"
        Sub MantenimientoReciclajeLadrilloVenta(ByVal mReciclajeLadrilloVenta As ReciclajeLadrilloVenta)
#End Region

#Region "Querys"
        Function ReciclajeLadrilloVentaGetById(ByVal RCL_ID As Integer) As BE.ReciclajeLadrilloVenta
        Function ListaReciclajeLadrilloVenta() As String
#End Region

    End Interface

End Namespace
