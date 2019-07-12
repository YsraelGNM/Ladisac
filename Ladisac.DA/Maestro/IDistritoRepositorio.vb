Imports Ladisac.BE

Namespace Ladisac.DA
    Public Interface IDistritoRepositorio
        Function Maintenance(ByVal item As Distrito) As Short
        ''Function GetById(ByVal DIS_Id As Integer) As Distrito
        Function ListaDistrito() As String
    End Interface
End Namespace

