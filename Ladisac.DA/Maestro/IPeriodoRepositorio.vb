Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IPeriodoRepositorio

        Function GetById(ByVal id As String) As Periodo
        Function Maintenance(ByVal item As Periodo) As Boolean

    End Interface


End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface INivelEducacionRepositorio

'        Function GetById(ByVal id As String) As NivelEducacion
'        Function Mantenance(ByVal item As NivelEducacion) As Boolean

'    End Interface

'End Namespace