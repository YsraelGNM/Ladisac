Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCSalidaSecadero

#Region "Mantenimientos"
        Sub MantenimientoSalidaSecadero(ByVal mSalidaSecadero As SalidaSecadero)
#End Region

#Region "Querys"
        Function SalidaSecaderoGetById(ByVal SSE_ID As Integer) As BE.SalidaSecadero
        Function ListaSalidaSecadero() As String
        Function ListaSalidaSecaderoCombustible() As String
#End Region

    End Interface

End Namespace
