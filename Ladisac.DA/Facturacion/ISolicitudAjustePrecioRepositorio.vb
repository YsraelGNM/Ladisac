Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISolicitudAjustePrecioRepositorio
        Function GetById(ByVal SAP_ID As Integer) As SolicitudAjustePrecio
        Sub Maintenance(ByVal SolicitudAjustePrecio As SolicitudAjustePrecio)
        Function ListaSolicitudAjustePrecio() As String
    End Interface

End Namespace

