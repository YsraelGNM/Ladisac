Imports Ladisac.BE


Namespace Ladisac.DA

    Public Interface IFichaInspeccionRepositorio
        Function GetById(ByVal FIN_Id As Integer) As FichaInspeccion
        Sub Maintenance(ByVal FichaInspeccion As FichaInspeccion)
        Function ListaFichaInspeccion() As String
    End Interface

End Namespace
