Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlConteoRepositorio
        Function GetById(ByVal CCO_Id As Integer) As ControlConteo
        Function GetByIdPRO(ByVal PRO_Id As Integer) As ControlConteo
        Sub Maintenance(ByVal ControlConteo As ControlConteo)
        Function ListaControlConteo() As String
    End Interface

End Namespace

