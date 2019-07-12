Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCDotacion

#Region "Mantenimientos"
        Sub MantenimientoDotacion(ByVal mDotacion As Dotacion)
#End Region

#Region "Querys"
        Function DotacionGetById(ByVal DOT_ID As Integer) As Dotacion
        Function ListaDotacion() As String
#End Region

    End Interface

End Namespace
