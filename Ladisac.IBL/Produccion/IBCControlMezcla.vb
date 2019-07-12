Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCControlMezcla

#Region "Mantenimientos"
        Sub MantenimientoControlMezcla(ByVal mControlMezcla As ControlMezcla)
#End Region

#Region "Querys"
        Function ControlMezclaGetById(ByVal CME_ID As Integer) As BE.ControlMezcla
        Function ControlMezclaGetByIdPRO(ByVal PRO_Id As Integer) As List(Of ControlMezcla)
        Function ListaControlMezcla() As String
        Function MezclaxFecha() As DataTable
        Function Interfase_MateriaPrima(ByVal CME_ID As Integer) As String
#End Region

    End Interface

End Namespace
