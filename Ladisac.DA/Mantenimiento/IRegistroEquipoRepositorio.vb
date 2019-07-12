Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IRegistroEquipoRepositorio
        Function GetById(ByVal REQ_Id As Integer) As RegistroEquipo
        Sub Maintenance(ByVal RegistroEquipo As RegistroEquipo)
        Function ListaRegistroEquipo() As String
    End Interface

End Namespace

