Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IManttoRepositorio
        Function GetById(ByVal MTO_Id As Integer) As Mantto
        Sub Maintenance(ByVal Mantto As Mantto)
        Function ListaMantto() As String
    End Interface

End Namespace

