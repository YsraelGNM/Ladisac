Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IProcesoCompraDetalleRepositorio
        Function GetById(ByVal PCD_ID As Integer) As ProcesoCompraDetalle
        Function GetById2(ByVal OCD_ID As Integer) As ProcesoCompraDetalle
        Sub Maintenance(ByVal ProcesoCompraDetalle As ProcesoCompraDetalle)
        Function ListaProcesoCompraDetalle() As String
    End Interface

End Namespace

