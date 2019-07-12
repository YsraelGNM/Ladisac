Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IFotoPersonaRepositorio
        Function GetById(ByVal FOP_Id As Integer) As FotoPersonas
        Sub Maintenance(ByVal FotoPersona As FotoPersonas)
        Function ListaFotoPersona() As String
    End Interface

End Namespace

