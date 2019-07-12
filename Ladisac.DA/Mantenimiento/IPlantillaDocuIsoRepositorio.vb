Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IPlantillaDocuIsoRepositorio
        Function GetById(ByVal PDI_Id As Integer) As PlantillaDocuIso
        Sub Maintenance(ByVal PlantillaDocuIso As PlantillaDocuIso)
        Function ListaPlantillaDocuIso() As String
    End Interface

End Namespace

