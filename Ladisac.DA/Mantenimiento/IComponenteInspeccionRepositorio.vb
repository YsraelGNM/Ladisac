Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IComponenteInspeccionRepositorio
        Function GetById(ByVal COM_Id As Integer) As ComponenteInspeccion
        Sub Maintenance(ByVal ComponenteInspeccion As ComponenteInspeccion)
        Function ListaComponenteInspeccion() As String
    End Interface

End Namespace

