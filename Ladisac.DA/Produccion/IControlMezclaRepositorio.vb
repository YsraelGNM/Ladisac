Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlMezclaRepositorio
        Function GetById(ByVal CME_Id As Integer) As ControlMezcla
        Function GetByIdPRO(ByVal PRO_Id As Integer) As List(Of ControlMezcla)
        Sub Maintenance(ByVal ControlMezcla As ControlMezcla)
        Function ListaControlMezcla() As String
    End Interface

End Namespace

