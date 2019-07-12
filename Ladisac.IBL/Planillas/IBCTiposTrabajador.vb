Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCTiposTrabajador
#Region "Mantenimiento"
        Function Maintenance(ByVal item As TiposTrabajador) As Boolean
#End Region
#Region "consulta"
        Function TiposTrabajadorQuery(ByVal tit_TipoTrab_Id As String, ByVal tit_Descripcion As String)
        Function TiposTrabajadorSeek(ByVal id As String) As BE.TiposTrabajador

#End Region

    End Interface
End Namespace



'Imports Ladisac.BE

'Namespace Ladisac.BL
'    Public Interface IBCTiposContratos


'#Region "Mantenimiento"
'        Sub Maintenance(ByVal item As TiposContratos)
'#End Region

'#Region "Consulta"
'        Function TiposContratosQuery(ByVal tic_TipoCont_Id As String, ByVal tico_Descripcion As String)
'        Function TiposContratosSeek(ByVal id As String) As BE.TiposContratos
'#End Region

'    End Interface

'End Namespace