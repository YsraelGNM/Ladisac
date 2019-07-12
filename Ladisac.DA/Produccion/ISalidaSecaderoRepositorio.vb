Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISalidaSecaderoRepositorio
        Function GetById(ByVal SSE_Id As Integer) As SalidaSecadero
        Sub Maintenance(ByVal SalidaSecadero As SalidaSecadero)
        Function ListaSalidaSecadero() As String
    End Interface

End Namespace

