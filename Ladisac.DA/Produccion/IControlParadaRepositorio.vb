Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlParadaRepositorio
        Function GetById(ByVal CPA_Id As Integer) As ControlParada
        Sub Maintenance(ByVal ControlParada As ControlParada)
        Function ListaControlParada() As String
        Function GetByPro_Id(ByVal PRO_Id As Integer) As List(Of ControlParada)
    End Interface

End Namespace

