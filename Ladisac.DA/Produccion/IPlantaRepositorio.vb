Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IPlantaRepositorio
        Function GetById(ByVal PLA_Id As Integer) As Planta
        Sub Maintenance(ByVal Planta As Planta)
        Function ListaPlanta() As String
    End Interface

End Namespace

