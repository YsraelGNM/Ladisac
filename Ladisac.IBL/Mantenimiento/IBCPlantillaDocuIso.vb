Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCPlantillaDocuIso

#Region "Mantenimientos"
        Sub MantenimientoPlantillaDocuIso(ByVal mPlantillaDocuIso As PlantillaDocuIso)
#End Region

#Region "Querys"
        Function PlantillaDocuIsoGetById(ByVal PDI_ID As Integer) As PlantillaDocuIso
        Function ListaPlantillaDocuIso() As String
#End Region

    End Interface

End Namespace
