Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IProcesoCompraRepositorio
        Function GetById(ByVal PRC_ID As Integer) As ProcesoCompra
        Sub Maintenance(ByVal ProcesoCompra As ProcesoCompra)
        Function ListaProcesoCompra(ByVal USU_ID As String) As String
    End Interface

End Namespace

