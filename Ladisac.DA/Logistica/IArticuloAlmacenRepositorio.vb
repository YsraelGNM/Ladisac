Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IArticuloAlmacenRepositorio
        Function GetById(ByVal ARA_Id As String) As ArticuloAlmacen
        Sub Maintenance(ByVal ArticuloAlamacen As ArticuloAlmacen)
        Function ListaArticuloAlmacen(ByVal Art_Id As String, ByVal ALM_Id As Nullable(Of Integer)) As String
        Function ListaArticuloAlmacenPermitido(ByVal Art_Id As String, ByVal ALM_Id As Nullable(Of Integer)) As String
        Function GetById(ByVal Art_Id As String, ByVal ALM_Id As Integer) As ArticuloAlmacen
        Function TotalStock(ByVal Art_Id As String) As Decimal
    End Interface

End Namespace

