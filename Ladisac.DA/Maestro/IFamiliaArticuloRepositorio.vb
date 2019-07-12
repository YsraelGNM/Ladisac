Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IFamiliaArticuloRepositorio
        Function GetById(ByVal FAM_Id As String) As FamiliaArticulos
        Sub Maintenance(ByVal FamiliaArticulo As FamiliaArticulos)
        Function ListaFamiliaArticulo() As String
    End Interface

End Namespace

