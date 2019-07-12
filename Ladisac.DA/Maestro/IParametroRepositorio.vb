Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IParametroRepositorio
        Function GetById(ByVal PAR_ID As String) As Parametro
        Sub Maintenance(ByVal mParametro As Parametro)
        Function ListaParametro() As String
    End Interface

End Namespace

