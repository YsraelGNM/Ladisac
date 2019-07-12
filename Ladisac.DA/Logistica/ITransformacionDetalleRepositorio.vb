Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ITransformacionDetalleRepositorio
        Function GetById(ByVal TRD_ID As Integer) As TransformacionDetalle
        Sub Maintenance(ByVal TransformacionDetalle As TransformacionDetalle)
        Function ListaTransformacionDetalle() As String
    End Interface

End Namespace

