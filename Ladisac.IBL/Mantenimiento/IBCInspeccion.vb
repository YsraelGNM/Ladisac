Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCInspeccion

#Region "Mantenimientos"
        Sub MantenimientoInspeccion(ByVal mInspeccion As Inspeccion)
#End Region

#Region "Querys"
        Function InspeccionGetById(ByVal INS_ID As Integer) As Inspeccion
        Function ListaInspeccion() As String
#End Region

    End Interface

End Namespace
