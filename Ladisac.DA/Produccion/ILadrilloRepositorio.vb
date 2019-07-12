Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ILadrilloRepositorio
        Function GetById(ByVal LAD_ID As String) As Ladrillo
        Sub Maintenance(ByVal Ladrillo As Ladrillo)
        Function ListaLadrillo() As String
    End Interface

End Namespace

