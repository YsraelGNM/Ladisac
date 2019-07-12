Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ICargaDescargaTransporteRepositorio
        Function GetById(ByVal CDT_ID As Integer) As CargaDescargaTransporte
        Sub Maintenance(ByVal CargaDescargaTransporte As CargaDescargaTransporte)
        Function ListaCargaDescargaTransporte() As String
    End Interface

End Namespace

