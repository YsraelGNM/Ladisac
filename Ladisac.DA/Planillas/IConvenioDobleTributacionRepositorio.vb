Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface IConvenioDobleTributacionRepositorio
        Function GetById(ByVal id As String) As ConvenioDobleTributacion
        Function Maintenance(ByVal item As ConvenioDobleTributacion) As Boolean

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface INivelEducacionRepositorio

'        Function GetById(ByVal id As String) As NivelEducacion
'        Function Mantenance(ByVal item As NivelEducacion) As Boolean

'    End Interface

'End Namespace
