Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISancionRepositorio
        Function GetById(ByVal SAN_Id As Integer) As Sancion
        Sub Maintenance(ByVal Sancion As Sancion)
        Function ListaSancion() As String
    End Interface

End Namespace

