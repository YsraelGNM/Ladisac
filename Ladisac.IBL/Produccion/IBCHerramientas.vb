Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCHerramientas

#Region "Querys"
        Function Get_Id(ByVal Tabla As String) As Integer
        Function Get_IdTx(ByVal Tabla As String) As String
        Function Get_CodSegundaLadrillo(ByVal Art_Id_Ladrillo As String) As String
        Function Get_CodigoArticuloTx(ByVal GLI_ID As String) As String
#End Region

    End Interface

End Namespace
