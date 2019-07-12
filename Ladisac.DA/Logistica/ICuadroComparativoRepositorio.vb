Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ICuadroComparativoRepositorio
        Function GetById(ByVal CUC_Id As Integer) As CuadroComparativo
        Sub Maintenance(ByVal CuadroComparativo As CuadroComparativo)
        Function ListaCuadroComparativo() As String
    End Interface

End Namespace

