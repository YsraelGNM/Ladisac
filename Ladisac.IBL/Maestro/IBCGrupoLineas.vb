Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCGrupoLineas

#Region "Mantenimientos"
        Sub MantenimientoGrupoLineas(ByVal mGrupoLineas As GrupoLineas)
#End Region

#Region "Querys"
        Function GrupoLineasGetById(ByVal GLI_ID As String) As GrupoLineas
        Function ListaGrupoLineas() As String
#End Region

    End Interface

End Namespace
