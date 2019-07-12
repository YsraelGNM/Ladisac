Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlQuemaRepositorio
        Function GetById(ByVal COQ_Id As Integer) As ControlQuema
        Sub Maintenance(ByVal ControlQuema As ControlQuema)
        Function ListaControlQuema() As String
    End Interface

End Namespace

