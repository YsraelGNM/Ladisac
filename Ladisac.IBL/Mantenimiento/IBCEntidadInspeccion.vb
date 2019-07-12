Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCEntidadInspeccion

#Region "Mantenimientos"
        Sub MantenimientoEntidadInspeccion(ByVal mEntidadInspeccion As EntidadInspeccion)
#End Region

#Region "Querys"
        Function EntidadInspeccionGetById(ByVal EIN_ID As Integer) As EntidadInspeccion
        Function ListaEntidadInspeccion() As String
#End Region

    End Interface

End Namespace
