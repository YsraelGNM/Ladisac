Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface ICronogramaVacacionesRepositorio

        Function getById(ByVal per_Id As String, ByVal crv_ItemCroVaca As String) As CronogramaVacaciones
        Function Mantenace(ByVal item As BE.CronogramaVacaciones) As Boolean
        End Interface
End Namespace



'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface INivelEducacionRepositorio

'        Function GetById(ByVal id As String) As NivelEducacion
'        Function Mantenance(ByVal item As NivelEducacion) As Boolean

'    End Interface

'End Namespace