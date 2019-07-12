Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IInspeccionRepositorio
        Function GetById(ByVal INS_Id As Integer) As Inspeccion
        Sub Maintenance(ByVal Inspeccion As Inspeccion)
        Function ListaInspeccion() As String
    End Interface

End Namespace

