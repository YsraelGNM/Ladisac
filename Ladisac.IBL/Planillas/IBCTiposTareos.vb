Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCTiposTareos

#Region "Mantenimiento"
        Function Maintenance(ByVal item As TiposTareos)
#End Region
#Region "Consulta"
        Function TiposTareosQuery(ByVal tio_TiposTareo_Id As String, ByVal tio_Descripcion As String)
        Function TiposTareosSeek(ByVal id As String) As BE.TiposTareos
#End Region
    End Interface
End Namespace

