Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface ITareaTrabajoRepositorio
        Function GetById(ByVal tit_TipTarea_Id As String, ByVal ttr_TareaTrab_Id As String)
        Function Mantenance(ByVal item As TareaTrabajo) As Boolean

    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface INivelEducacionRepositorio

'        Function GetById(ByVal id As String) As NivelEducacion
'        Function Mantenance(ByVal item As NivelEducacion) As Boolean

'    End Interface

'End Namespace
