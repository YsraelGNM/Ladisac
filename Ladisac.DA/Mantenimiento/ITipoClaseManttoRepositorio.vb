Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ITipoClaseManttoRepositorio
        Function GetById(ByVal TCM_Id As Integer) As Tipoclasemantto
        Sub Maintenance(ByVal TipoClaseMantto As TipoClaseMantto)
        Function ListaTipoClaseMantto() As String
    End Interface

End Namespace

