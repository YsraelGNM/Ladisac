Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ICuentaRendirRepositorio
        Function GetById(ByVal CRE_ID As Integer) As CuentaRendir
        Function Maintenance(ByVal CuentaRendir As CuentaRendir) As Integer
        Function ListaCuentaRendir() As String
    End Interface

End Namespace

