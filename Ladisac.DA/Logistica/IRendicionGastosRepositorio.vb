Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IRendicionGastosRepositorio
        Function GetById(ByVal RGA_ID As Integer) As RendicionGastos
        Function Maintenance(ByVal RendicionGastos As RendicionGastos) As Integer
        Function ListaRendicionGastos() As String
    End Interface

End Namespace
