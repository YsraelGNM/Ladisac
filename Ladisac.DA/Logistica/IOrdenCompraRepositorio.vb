Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IOrdenCompraRepositorio
        Function GetById(ByVal OCO_Id As Integer) As OrdenCompra
        Sub Maintenance(ByVal OrdenCompra As OrdenCompra)
        Function ListaOrdenCompra() As String
        Function ListaOrdenCompraID(ByVal OCO_ID As Nullable(Of Integer)) As DataSet
    End Interface

End Namespace

