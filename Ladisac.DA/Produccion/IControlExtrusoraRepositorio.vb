Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlExtrusoraRepositorio
        Function GetById(ByVal CEX_Id As Integer) As ControlExtrusora
        Sub Maintenance(ByVal ControlExtrusora As ControlExtrusora)
        Function ListaControlExtrusora() As String
    End Interface

End Namespace

