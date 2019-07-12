Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISancionDetalleRepositorio
        Function GetById(ByVal SAD_Id As Integer) As SancionDetalle
        Sub Maintenance(ByVal SancionDetalle As SancionDetalle)
        Function ListaSancionDetalle() As String
    End Interface

End Namespace

