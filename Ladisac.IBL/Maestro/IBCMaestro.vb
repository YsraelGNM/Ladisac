Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCMaestro
        Function EjecutarVista(ByVal vista As String, ByVal ParamArray params As Object()) As String
        Function EjecutarPendienteAtencion(ByVal Procedimiento As String, ByVal ParamArray params As Object()) As String

        Sub MantenimientoMonedas(ByVal Item As Moneda)
        Sub MantenimientoMonedasDescripcion(ByVal id As String, ByVal descripcion As String)

    End Interface
End Namespace

