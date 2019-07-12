Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IMoldeRepositorio
        Function GetById(ByVal MOL_Id As Integer) As Molde
        Sub Maintenance(ByVal Molde As Molde)
        Function ListaMolde() As String
    End Interface

End Namespace

