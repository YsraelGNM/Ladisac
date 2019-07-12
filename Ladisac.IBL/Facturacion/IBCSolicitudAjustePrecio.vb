Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCSolicitudAjustePrecio

#Region "Mantenimientos"
        Function MantenimientoSolicitudAjustePrecio(ByVal mSolicitudAjustePrecio As SolicitudAjustePrecio) As Integer
#End Region

#Region "Querys"
        Function SolicitudAjustePrecioGetById(ByVal SAP_ID As Integer) As SolicitudAjustePrecio
        Function ListaSolicitudAjustePrecio() As String
#End Region

    End Interface

End Namespace
