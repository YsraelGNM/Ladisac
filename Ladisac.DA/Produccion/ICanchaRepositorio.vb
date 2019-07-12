Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ICanchaRepositorio
        Function GetById(ByVal CAN_Id As Integer) As Cancha
        Sub Maintenance(ByVal Cancha As Cancha)
        Function ListaCancha() As String
    End Interface

End Namespace

