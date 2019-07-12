Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlGrifoRepositorio
        Function GetById(ByVal MessageId As String) As ControlGrifo
        Sub Maintenance(ByVal ControlGrifo As ControlGrifo)
        Function ListaControlGrifo() As String
    End Interface

End Namespace

