Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IFaltaSancionRepositorio
        Function GetById(ByVal FSA_Id As Integer) As FaltaSancion
        Sub Maintenance(ByVal FaltaSancion As FaltaSancion)
        Function ListaFaltaSancion() As String
    End Interface

End Namespace

