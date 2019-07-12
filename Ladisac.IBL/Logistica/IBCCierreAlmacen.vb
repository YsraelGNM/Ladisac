Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCCierreAlmacen

#Region "Mantenimientos"
        Sub MantenimientoCierreAlmacen(ByVal mCierreAlmacen As CierreAlmacen)
#End Region

#Region "Querys"
        Function CierreAlmacenGetById(ByVal CIA_ID As Integer) As CierreAlmacen
        Function CierreAlmacenGetByCierre(ByVal Anio As String, ByVal Mes As String, ByVal Alm_id As String) As Boolean
        Function CierreAlmacenGetByCierreAlmacen(ByVal Anio As String, ByVal Mes As String, ByVal Alm_id As String) As CierreAlmacen
        Function ListaCierreAlmacen() As String
#End Region

    End Interface

End Namespace
