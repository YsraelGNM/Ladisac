Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlInspeccionRepositorio
        Function GetById(ByVal CIN_Id As Integer) As ControlInspeccion
        Sub Maintenance(ByVal ControlInspeccion As ControlInspeccion)
        Function ListaControlInspeccion() As String
    End Interface

End Namespace

