Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IGuiaRemisionRepositorio
        Function GetById(ByVal GUI_Id As Integer) As GuiaRemision
        Sub Maintenance(ByVal GuiaRemision As GuiaRemision)
        Function ListaGuiaRemision() As String
    End Interface

End Namespace

