Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IRendicionCuentaRepositorio
        Function GetById(ByVal REC_ID As Integer) As RendicionCuenta
        Sub Maintenance(ByVal RendicionCuenta As RendicionCuenta)
        Function ListaRendicionCuenta() As String
    End Interface

End Namespace

