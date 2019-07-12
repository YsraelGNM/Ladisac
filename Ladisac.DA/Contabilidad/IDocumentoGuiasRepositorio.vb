Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IDocumentoGuiasRepositorio
        Function GetById(ByVal DGU_Id As Integer) As DocumentoGuias
        Sub Maintenance(ByVal DocumentoGuias As DocumentoGuias)
        Function ListaDocumentoGuias() As String
    End Interface

End Namespace

