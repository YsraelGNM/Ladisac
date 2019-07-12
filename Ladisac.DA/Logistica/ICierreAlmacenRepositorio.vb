Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ICierreAlmacenRepositorio
        Function GetById(ByVal CIA_ID As Integer) As CierreAlmacen
        Function GetByCierreAlmacen(ByVal Anio As String, ByVal Mes As String, ByVal Alm_id As String) As CierreAlmacen
        Function GetByCierre(ByVal Anio As String, ByVal Mes As String, ByVal Alm_id As String) As Boolean
        Sub Maintenance(ByVal Cierrealmacen As CierreAlmacen)
        Function ListaCierreAlmacen() As String
    End Interface

End Namespace

