Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCRendicionGastos

#Region "Mantenimientos"
        Function MantenimientoRendicionGastos(ByVal mRendicionGastos As RendicionGastos) As Integer
#End Region

#Region "Querys"
        Function RendicionGastosGetById(ByVal RGA_ID As Integer) As RendicionGastos
        Function ListaRendicionGastos() As String
        Function ImprimirRendicionGastos(ByVal RGA_ID As Integer) As DataTable
#End Region

    End Interface

End Namespace
