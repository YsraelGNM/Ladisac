Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCCuadroComparativo

#Region "Mantenimientos"
        Sub MantenimientoCuadroComparativo(ByVal mCuadroComparativo As CuadroComparativo)
#End Region

#Region "Querys"
        Function CuadroComparativoGetById(ByVal CUC_ID As Integer) As CuadroComparativo
        Function ListaCuadroComparativo() As String
        Function ImprimirCuadroComparativo(ByVal CUC_ID As Integer) As String
#End Region

    End Interface

End Namespace
