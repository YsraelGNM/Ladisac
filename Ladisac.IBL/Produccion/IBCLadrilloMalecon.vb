Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCLadrilloMalecon

#Region "Mantenimientos"
        Sub MantenimientoLadrilloMalecon(ByVal mLadrilloMalecon As LadrilloMalecon)
#End Region

#Region "Querys"
        Function LadrilloMaleconGetById(ByVal LMA_ID As Integer) As LadrilloMalecon
        Function LadrilloMaleconGetById2(ByVal HOR_Id As Integer, ByVal Nro_Male As String, ByVal PRO_Id As Integer) As LadrilloMalecon
        Function MaleconPuertaGetById(ByVal MAL_ID As Integer) As MaleconPuerta
        Function ArticuloGetById(ByVal ART_ID As String) As Articulos
        Function ListaLadrilloMalecon() As String
#End Region

    End Interface

End Namespace
