Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface IPeriodisidadRepositorio
        Function GetId(ByVal id As String) As Periodisidad
        Sub Mantenance(ByVal item As Periodisidad)

    End Interface

End Namespace
