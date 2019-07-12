Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCGrupo

#Region "Mantenimientos"
        Sub MantenimientoGrupo(ByVal mGrupo As Grupo)
#End Region

#Region "Querys"
        Function GrupoGetById(ByVal GRU_ID As Integer) As Grupo
        Function ListaGrupo() As String
#End Region

    End Interface

End Namespace
