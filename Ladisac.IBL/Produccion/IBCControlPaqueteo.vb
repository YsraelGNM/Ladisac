Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCControlPaqueteo

#Region "Mantenimientos"
        Sub MantenimientoControlPaqueteo(ByVal mControlPaqueteo As ControlPaqueteo)
#End Region

#Region "Querys"
        Function ControlPaqueteoGetById(ByVal PQT_ID As Integer) As ControlPaqueteo
        Function ControlPaqueteoGetByPro_Id(ByVal PRO_ID As Integer) As ControlPaqueteo
        Function ListaControlPaqueteo(ByVal FecIni As Date, ByVal FecFin As Date) As String
#End Region

    End Interface

End Namespace
