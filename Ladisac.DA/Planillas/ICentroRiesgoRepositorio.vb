Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface ICentroRiesgoRepositorio
        Function GetById(ByVal id As String) As BE.CentroRiesgo
        Function Maintenance(ByVal item As BE.CentroRiesgo)

    End Interface
End Namespace



'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IPlanillaRepositorio

'        Function GetbyId(ByVal serie As String, ByVal numero As String, ByVal tipoDoc As String) As BE.Planillas
'        Function Maintenance(ByVal item As BE.Planillas)

'    End Interface

'End Namespace
