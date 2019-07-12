Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCParametroEntidad

#Region "Mantenimientos"
        Sub MantenimientoParametroEntidad(ByVal mParametroEntidad As ParametroEntidad)
#End Region

#Region "Querys"
        Function ParametroEntidadGetById(ByVal PAE_ID As Integer) As ParametroEntidad
        Function ListaParametroEntidad() As String
#End Region

    End Interface

End Namespace
