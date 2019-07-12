Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCCortadora

#Region "Mantenimientos"
        Sub MantenimientoCortadora(ByVal mCortadora As Cortadora)
#End Region

#Region "Querys"
        Function CortadoraGetById(ByVal COR_ID As Integer) As BE.Cortadora
        Function ListaCortadora() As String
#End Region

    End Interface

End Namespace
