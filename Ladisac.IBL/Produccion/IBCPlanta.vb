Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCPlanta

#Region "Mantenimientos"
        Sub MantenimientoPlanta(ByVal mPlanta As Planta)
#End Region

#Region "Querys"
        Function PlantaGetById(ByVal PLA_ID As Integer) As Planta
        Function ListaPlanta() As String
        Function PlantaGrupoTrabajoQuery(ByVal id As Integer, ByVal descripcion As String)
#End Region

    End Interface

End Namespace
