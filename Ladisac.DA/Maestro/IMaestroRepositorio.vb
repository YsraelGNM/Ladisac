Imports Ladisac.BE
Namespace Ladisac.DA
    '
    Public Interface IMaestroRepositorio
        Function EjecutarVista(ByVal vista As String, ByVal ParamArray params As Object()) As String
        Function EjecutarPendientesAtencion(ByVal Procedimiento As String, ByVal ParamArray params As Object()) As String
    End Interface
End Namespace
