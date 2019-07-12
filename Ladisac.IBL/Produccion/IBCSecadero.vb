Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCSecadero

#Region "Mantenimientos"
        Sub MantenimientoSecadero(ByVal mSecadero As Secadero)
#End Region

#Region "Querys"
        Function SecaderoGetById(ByVal SEC_ID As Integer) As BE.Secadero
        Function ListaSecadero() As String
#End Region

    End Interface

End Namespace
