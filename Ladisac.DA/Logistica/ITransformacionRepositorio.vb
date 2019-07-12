Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ITransformacionRepositorio
        Function GetById(ByVal TFO_ID As Integer) As Transformacion
        Sub Maintenance(ByVal Transformacion As Transformacion)
        Function ListaTransformacion() As String
        Function ListaTransformacionID(ByVal TFO_ID As Nullable(Of Integer)) As DataSet
        Sub ActualizarPUServicioTransformacion(ByVal TFO_ID As Nullable(Of Integer), ByVal ART_ID As String, ByVal PU As Nullable(Of Decimal), ByVal TRD_NRO_SERVICIO As String, ByVal PER_ID As String)
    End Interface

End Namespace

