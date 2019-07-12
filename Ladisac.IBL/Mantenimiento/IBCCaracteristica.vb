Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCCaracteristica

#Region "Mantenimientos"
        Sub MantenimientoCaracteristica(ByVal mCaracteristica As Caracteristica)
#End Region

#Region "Querys"
        Function CaracteristicaGetById(ByVal CTT_ID As Integer) As Caracteristica
        Function ListaCaracteristica() As String
#End Region

    End Interface

End Namespace
