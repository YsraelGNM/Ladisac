Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlPesoRepositorio
        Function GetById(ByVal CPE_Id As Integer) As ControlPeso
        Function GetByIdPRO(ByVal PRO_Id As Integer) As ControlPeso
        Sub Maintenance(ByVal ControlPeso As ControlPeso)
        Function ListaControlPeso() As String
        Function GetPromPesoByIdPRO(ByVal PRO_Id As Integer) As Decimal
    End Interface

End Namespace

