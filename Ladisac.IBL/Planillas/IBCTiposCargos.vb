Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCTiposCargos
#Region "Mantenimiento"
        Sub Maintenance(ByVal item As TiposCargos)

#End Region

#Region "Consulta"
        Function TiposCargosQuery(ByVal tis_TipCargo_Id As String, ByVal tis_Descripcion As String)
        Function TiposCargosSeek(ByVal id As String) As TiposCargos

#End Region

    End Interface


End Namespace
