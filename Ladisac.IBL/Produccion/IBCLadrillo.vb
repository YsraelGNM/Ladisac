Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCLadrillo

#Region "Mantenimientos"
        Sub MantenimientoLadrillo(ByVal mLadrillo As Ladrillo)
#End Region

#Region "Querys"
        Function LadrilloGetById(ByVal LAD_ID As String) As Ladrillo
        Function ListaLadrillo() As String
#End Region

    End Interface

End Namespace
