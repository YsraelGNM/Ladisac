Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCControlConteo

#Region "Mantenimientos"
        Sub MantenimientoControlConteo(ByVal mControlConteo As ControlConteo)
#End Region

#Region "Querys"
        Function ControlConteoGetById(ByVal CCO_ID As Integer) As BE.ControlConteo
        Function ControlConteoGetByIdPRO(ByVal PRO_ID As Integer) As BE.ControlConteo
        Function ListaControlConteo() As String
        Function ValidarConteo(ByVal CPA_ID As Integer) As String
        Function Interfase_Pre_Conteo(ByVal PRO_ID) As DataTable
        Function ConteoxFecha() As DataTable
        Function Interfase_Conteo(ByVal CCO_ID As Integer) As String
        Function Interfase_IngresoMP(ByVal DMO_ID As Integer) As String

#End Region

    End Interface

End Namespace
