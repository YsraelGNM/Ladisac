Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISolicitudSoporteRepositorio
        Function GetById(ByVal SOS_ID As Integer) As SolicitudSoporte
        Sub Maintenance(ByVal SolicitudSoporte As SolicitudSoporte)
        Function ListaSolicitudSoporte() As String
    End Interface

End Namespace

