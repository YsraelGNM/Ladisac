Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IAreaTrabajosRepositorio
        Function GetById(ByVal id As String) As AreaTrabajos
        Function Mantenance(ByVal item As AreaTrabajos) As Boolean

    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface INivelEducacionRepositorio

'        Function GetById(ByVal id As String) As NivelEducacion
'        Function Mantenance(ByVal item As NivelEducacion) As Boolean

'    End Interface

'End Namespace