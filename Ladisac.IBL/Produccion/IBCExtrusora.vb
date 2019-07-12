Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCExtrusora

#Region "Mantenimientos"
        Sub MantenimientoExtrusora(ByVal mExtrusora As Extrusora)
#End Region

#Region "Querys"
        Function ExtrusoraGetById(ByVal EXT_ID As Integer) As BE.Extrusora
        Function ListaExtrusora() As String

#End Region

    End Interface

End Namespace
