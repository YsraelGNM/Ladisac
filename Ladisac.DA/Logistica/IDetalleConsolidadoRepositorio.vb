Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IDetalleConsolidadoRepositorio
        Function GetById(ByVal PRC_ID As Integer) As DetalleConsolidado
        Sub Maintenance(ByVal DetalleConsolidado As DetalleConsolidado)
        Function ListaDetalleConsolidado() As String
    End Interface

End Namespace

