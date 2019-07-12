Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCControlCarga

#Region "Mantenimientos"
        Sub MantenimientoControlCarga(ByVal mControlCarga As ControlCarga)
#End Region

#Region "Querys"
        Function ControlCargaGetById(ByVal CAR_ID As Integer) As ControlCarga
        Function ListaControlCarga(ByVal PRO_ID As Nullable(Of Integer)) As String
        Function Interfase_CargaHorno(ByVal CAR_ID As Integer) As String
#End Region

    End Interface

End Namespace
