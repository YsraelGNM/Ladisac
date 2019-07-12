Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IConfiguracionFormatosRepositorio
        Function GetById(ByVal id As String) As BE.ConfiguracionFormatos
        Function Mantenance(ByVal item As BE.ConfiguracionFormatos) As Boolean

    End Interface

End Namespace


'Imports Ladisac.BE

'Namespace Ladisac.DA
'    Public Interface ICtaCteRepositorio


'        Function GetById(ByVal id As String) As CtaCte
'        Function Mantenance(ByVal item As CtaCte) As Boolean

'    End Interface

'End Namespace