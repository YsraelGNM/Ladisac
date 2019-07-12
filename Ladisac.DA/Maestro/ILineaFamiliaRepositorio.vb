Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ILineaFamiliaRepositorio
        Function GetById(ByVal LIN_Id As String) As LineasFamilia
        Sub Maintenance(ByVal LineaFamilia As LineasFamilia)
        Function ListaLineaFamilia() As String
    End Interface

End Namespace

