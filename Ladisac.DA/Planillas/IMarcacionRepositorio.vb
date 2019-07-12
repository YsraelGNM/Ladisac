Imports Ladisac.DA
Namespace Ladisac.DA

    Public Interface IMarcacionRepositorio
        Function GetId(ByVal fecha As Date, ByVal spersonas As String) As List(Of BE.Marcaciones)
        Sub Maintenance(ByVal item As BE.Marcaciones)

    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IPeriodisidadRepositorio
'        Function GetId(ByVal id As String) As Periodisidad
'        Sub Mantenance(ByVal item As Periodisidad)

'    End Interface

'End Namespace

