Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IConceptosRepositorio

        Function GetById(ByVal tipo As String, ByVal codigoConcepto As String) As Conceptos
        Sub Maintenance(ByVal item As Conceptos)
        Sub Load(ByVal Item As Conceptos, ByVal extends As ConceptosExtend)


    End Interface

End Namespace


'Imports Ladisac.BE

'Namespace Ladisac.DA
'    Public Interface IMonedasRepositorio
'        Function GetById(ByVal id As String) As Moneda
'        Sub Maintenance(ByVal item As Moneda)
'        Sub ModificarDescription(ByVal Id As String, ByVal Description As String)
'    End Interface
'End Namespace

