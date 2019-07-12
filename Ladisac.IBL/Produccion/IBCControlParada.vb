Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCControlParada

#Region "Mantenimientos"
        Sub MantenimientoControlParada(ByVal mControlParada As ControlParada)
#End Region

#Region "Querys"
        Function ControlParadaGetById(ByVal CPA_ID As Integer) As BE.ControlParada
        Function ListaControlParada() As String
        Function GetByPro_Id(ByVal PRO_Id As Integer) As List(Of ControlParada)
#End Region

    End Interface

End Namespace
