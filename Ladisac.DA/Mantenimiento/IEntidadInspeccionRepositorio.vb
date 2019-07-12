Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IEntidadInspeccionRepositorio
        Function GetById(ByVal EIN_Id As Integer) As EntidadInspeccion
        Sub Maintenance(ByVal EntidadInspeccion As EntidadInspeccion)
        Function ListaEntidadInspeccion() As String
    End Interface

End Namespace

