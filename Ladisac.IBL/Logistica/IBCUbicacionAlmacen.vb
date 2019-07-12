Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCUbicacionAlmacen

#Region "Mantenimientos"
        Sub MantenimientoUbicacionAlmacen(ByVal mUbicacionAlmacen As UbicacionAlmacen)
#End Region

#Region "Querys"
        Function UbicacionAlmacenGetById(ByVal UBI_ID As Integer) As UbicacionAlmacen
        Function ListaUbicacionAlmacen() As String
#End Region

    End Interface

End Namespace
