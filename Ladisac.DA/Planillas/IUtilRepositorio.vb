Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IUtilRepositorio
        Function GetId(ByVal sTabla As String, ByVal sCampo As String, ByVal sNumeroDigitos As Integer, Optional ByVal sWhere As String = Nothing) As String

    End Interface

End Namespace
