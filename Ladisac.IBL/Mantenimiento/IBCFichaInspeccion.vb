Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCFichaInspeccion

#Region "Mantenimientos"
        Sub MantenimientoFichaInspeccion(ByVal mFichaInspeccion As FichaInspeccion)
#End Region

#Region "Querys"
        Function FichaInspeccionGetById(ByVal FIN_ID As Integer) As FichaInspeccion
        Function ListaFichaInspeccion() As String
        Function ReporteFichaInspeccion() As DataTable
#End Region

    End Interface

End Namespace
