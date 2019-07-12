Imports Ladisac.BE

Namespace Ladisac.DA
    Public Interface IControlEnergiaRepositorio
        Function GetById(ByVal CEN_ID As Integer) As ControlEnergia
        Sub Maintenance(ByVal ControlEnergia As ControlEnergia)
        Function ListaControlEnergia() As String
    End Interface
End Namespace

