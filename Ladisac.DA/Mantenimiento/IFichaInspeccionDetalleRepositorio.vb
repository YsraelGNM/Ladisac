Imports Ladisac.BE


Namespace Ladisac.DA

    Public Interface IFichaInspeccionDetalleRepositorio
        Function GetById(ByVal FID_Id As Integer) As FichaInspeccionDetalle
        Sub Maintenance(ByVal FichaInspeccionDetalle As FichaInspeccionDetalle)
        Function ListaFichaInspeccionDetalle() As String
    End Interface

End Namespace
