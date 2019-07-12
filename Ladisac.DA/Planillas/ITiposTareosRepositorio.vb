Imports Ladisac.BE

Namespace Ladisac.DA


    Public Interface ITiposTareosRepositorio
        Function GetById(ByVal id As String) As TiposTareos
        Function Mantenance(ByVal item As TiposTareos) As Boolean


    End Interface

End Namespace


'Namespace Ladisac.DA
'    Public Interface ITiposConceptosRepositorio

'        Function GetById(ByVal id As String) As TiposConceptos
'        Sub Maintenance(ByVal item As TiposConceptos)
'        Sub ModificarDescripcion(ByVal Id As String, ByVal descripcion As String, ByVal Usuario As String)


'    End Interface


'End Namespace

