Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCRubro

#Region "Mantenimientos"
        Sub MantenimientoRubro(ByVal mRubro As Rubro)
#End Region

#Region "Querys"
        Function RubroGetById(ByVal RUB_ID As Integer) As Rubro
        Function ListaRubro() As String
#End Region

    End Interface

End Namespace
