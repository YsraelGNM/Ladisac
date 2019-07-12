Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCControlPeso

#Region "Mantenimientos"
        Sub MantenimientoControlPeso(ByVal mControlPeso As ControlPeso)
#End Region

#Region "Querys"
        Function ControlPesoGetById(ByVal CPE_ID As Integer) As BE.ControlPeso
        Function ControlPesoGetByIdPRO(ByVal PRO_ID As Integer) As BE.ControlPeso
        Function ListaControlPeso() As String
#End Region

    End Interface

End Namespace
