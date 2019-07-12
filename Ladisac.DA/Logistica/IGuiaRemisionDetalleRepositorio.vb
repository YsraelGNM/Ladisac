Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IGuiaRemisionDetalleRepositorio
        Function GetById(ByVal GUD_Id As Integer) As GuiaRemisionDetalle
        Sub Maintenance(ByVal GuiaRemisionDetalle As GuiaRemisionDetalle)
        Function ListaGuiaRemisionDetalle() As String
    End Interface

End Namespace

