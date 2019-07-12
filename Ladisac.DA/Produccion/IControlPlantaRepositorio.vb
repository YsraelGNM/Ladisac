Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlPlantaRepositorio
        Function GetById(ByVal CPL_Id As Integer) As ControlPlanta
        Sub Maintenance(ByVal ControlPlanta As ControlPlanta)
        Function ListaControlPlanta() As String
    End Interface

End Namespace

