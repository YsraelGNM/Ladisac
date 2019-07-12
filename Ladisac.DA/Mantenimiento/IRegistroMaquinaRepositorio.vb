Imports Ladisac.BE


Namespace Ladisac.DA

    Public Interface IRegistroMaquinaRepositorio
        Function GetById(ByVal RMA_Id As Integer) As RegistroMaquina
        Sub Maintenance(ByVal RegistroMaquina As RegistroMaquina)
        Function ListaRegistroMaquina() As String
    End Interface

End Namespace
