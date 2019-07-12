Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCSalidaCombustible

#Region "Mantenimientos"
        Sub MantenimientoSalidaCombustible(ByVal mSalidaCombustible As SalidaCombustible)
        Function ActualizarIdGrifo(ByVal mId_Grifo As Integer) As String
        Function Interfase_SalidaGrifo(ByVal SCO_ID As Integer) As String
        Function Interfase_PasarSpring(ByVal Fecha As Date, ByVal TipoTransaccion As String, Item As String) As String
#End Region

#Region "Querys"
        Function SalidaCombustibleGetById(ByVal SCO_ID As Integer) As SalidaCombustible
        Function ListaSalidaCombustible() As String
        Function ObtenerDatoGrifo() As String
#End Region

    End Interface

End Namespace
