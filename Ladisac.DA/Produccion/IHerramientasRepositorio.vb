Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IHerramientasRepositorio
        Function GetId(ByVal Tabla As String) As Integer
        Function GetIdTx(ByVal Tabla As String) As String
        Function Get_CodSegundaLadrillo(ByVal Art_Id_Ladrillo As String) As String
        Function GetCodigoArticuloTx(ByVal GLI_ID As String) As String
    End Interface

End Namespace
