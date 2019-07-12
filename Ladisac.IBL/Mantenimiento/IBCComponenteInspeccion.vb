Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCComponenteInspeccion

#Region "Mantenimientos"
        Sub MantenimientoComponenteInspeccion(ByVal mComponenteInspeccion As ComponenteInspeccion)
#End Region

#Region "Querys"
        Function ComponenteInspeccionGetById(ByVal COM_ID As Integer) As ComponenteInspeccion
        Function ListaComponenteInspeccion() As String
#End Region

    End Interface

End Namespace
