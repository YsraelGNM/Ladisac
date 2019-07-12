Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCTransformacion

#Region "Mantenimientos"
        Sub MantenimientoTransformacion(ByVal mTransformacion As Transformacion)
        Sub ActualizarPUServicioTransformacion(ByVal TFO_ID As Nullable(Of Integer), ByVal ART_ID As String, ByVal PU As Nullable(Of Decimal), ByVal TRD_NRO_SERVICIO As String, ByVal PER_ID As String)
#End Region

#Region "Querys"
        Function TransformacionGetById(ByVal TFO_ID As Integer) As Transformacion
        Function ListaTransformacion() As String
        Function ImpresionTransformacion(ByVal TFO_ID As Integer) As String
        Function ListaTransformacionID(ByVal TFO_ID As Nullable(Of Integer)) As DataSet
        Function TransformacionxTFO() As DataTable
#End Region

    End Interface

End Namespace
