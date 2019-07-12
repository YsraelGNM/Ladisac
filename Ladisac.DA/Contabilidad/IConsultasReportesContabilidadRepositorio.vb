Namespace Ladisac.DA

    Public Interface IConsultasReportesContabilidadRepositorio
        Function EjecutarReporte(ByVal report As String, ByVal ParamArray params As Object()) As DataTable

    End Interface
End Namespace

'Namespace Ladisac.DA
'    Public Interface IReportesRepositorio
'        Function EjecutarReporte(ByVal report As String, ByVal ParamArray params As Object()) As String
'    End Interface

'End Namespace