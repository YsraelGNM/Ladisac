Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCControlCanchero

#Region "Mantenimientos"
        Sub MantenimientoControlCanchero(ByVal mControlCanchero As ControlCanchero)
#End Region

#Region "Querys"
        Function ControlCancheroGetById(ByVal CCA_ID As Integer) As BE.ControlCanchero
        Function ListaControlCanchero() As String
        Function GetByPro_Id(ByVal PRO_Id As Integer) As List(Of ControlCanchero)
#End Region

    End Interface

End Namespace
