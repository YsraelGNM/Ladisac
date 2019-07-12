Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IUbicacionAlmacenRepositorio
        Function GetById(ByVal UBI_Id As Integer) As UbicacionAlmacen
        Sub Maintenance(ByVal UbicacionAlmacen As UbicacionAlmacen)
        Function ListaUbicacionAlmacen() As String
    End Interface

End Namespace

