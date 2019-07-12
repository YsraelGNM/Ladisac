Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCAlmacen

#Region "Mantenimientos"
        Sub MantenimientoAlmacen(ByVal mAlmacen As Almacen)
#End Region

#Region "Querys"
        Function AlmacenGetById(ByVal ALM_ID As Integer) As Almacen
        Function GetByIdPadre(ByVal ALM_Id_Padre As Integer) As List(Of Almacen)
        Function ListaAlmacen() As String
        Function ListaAlmacenRendicion(ByVal ART_ID As String) As String
#End Region

    End Interface

End Namespace
