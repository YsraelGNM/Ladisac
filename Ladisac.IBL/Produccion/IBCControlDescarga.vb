Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCControlDescarga

#Region "Mantenimientos"
        Sub MantenimientoControlDescarga(ByVal mControlDescarga As ControlDescarga)
#End Region

#Region "Querys"
        Function ControlDescargaGetById(ByVal DES_ID As Integer) As ControlDescarga
        Function ListaControlDescarga() As String
#End Region

    End Interface

End Namespace
