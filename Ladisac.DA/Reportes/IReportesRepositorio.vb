Namespace Ladisac.DA
    Public Interface IReportesRepositorio
        Function EjecutarReporte(ByVal report As String, ByVal ParamArray params As Object()) As String
        Function EjecutarReporteTable(ByVal report As String, ByVal ParamArray params As Object()) As DataTable
    End Interface
    
End Namespace

