Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCEspecificacion

#Region "Mantenimientos"
        Sub MantenimientoEspecificacion(ByVal mEspecificacion As Especificacion)
#End Region

#Region "Querys"
        Function EspecificacionGetById(ByVal ESP_ID As Integer) As Especificacion
        Function ListaEspecificacion() As String
#End Region

    End Interface

End Namespace
