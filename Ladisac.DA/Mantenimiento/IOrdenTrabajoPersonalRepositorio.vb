Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IOrdenTrabajoPersonalRepositorio
        Function GetById(ByVal OTP_Id As Integer) As OrdenTrabajoPersonal
        Sub Maintenance(ByVal OrdenTrabajoPersonal As OrdenTrabajoPersonal)
        Function ListaOrdenTrabajoPersonal() As String
    End Interface

End Namespace

