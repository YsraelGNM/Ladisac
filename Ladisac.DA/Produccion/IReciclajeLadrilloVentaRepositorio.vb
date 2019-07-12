Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IReciclajeLadrilloVentaRepositorio
        Function GetById(ByVal RCL_Id As Integer) As ReciclajeLadrilloVenta
        Sub Maintenance(ByVal ReciclajeLadrilloVenta As ReciclajeLadrilloVenta)
        Function ListaReciclajeLadrilloVenta() As String
    End Interface

End Namespace

