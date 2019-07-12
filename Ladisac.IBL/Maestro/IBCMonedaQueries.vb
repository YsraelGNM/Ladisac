Namespace Ladisac.BL
    Public Interface IBCMonedaQueries
        Function MonedaQuery(Optional ByVal monId As String = Nothing) As String
        Function MonedaSeek(ByVal monId As String) As BE.Moneda
    End Interface
End Namespace

