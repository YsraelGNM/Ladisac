Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IAlmacenRepositorio
        Function GetById(ByVal ALM_Id As Integer) As Almacen
        Function GetByIdPadre(ByVal ALM_Id_Padre As Integer) As List(Of Almacen)
        Sub Maintenance(ByVal Almacen As Almacen)
        Function ListaAlmacen() As String
    End Interface

End Namespace

