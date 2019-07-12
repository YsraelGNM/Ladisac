Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCGuiaRemision

#Region "Mantenimientos"
        Function MantenimientoGuiaRemision(ByVal mGuiaRemision As GuiaRemision) As Integer
#End Region

#Region "Querys"
        Function GuiaRemisionGetById(ByVal GUI_ID As Integer) As GuiaRemision
        Function ListaGuiaRemision() As String
        Function ListaGuiaRemisionAProcesar(ByVal FecIni As Date, ByVal FecFin As Date) As String
        Function PrecioMateriaPrima(ByVal ART_ID As String, ByVal Fecha As Date) As Decimal
        Function StockCostoPromedio(ByVal ART_Id As String, ByVal Alm_Id As Integer, ByVal Fecha As Date, ByVal Flag As Integer) As Decimal
#End Region

    End Interface

End Namespace
