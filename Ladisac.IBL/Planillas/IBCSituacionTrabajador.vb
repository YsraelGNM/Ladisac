Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCSituacionTrabajador
#Region "Mantenimientos"
        Function Mantenance(ByVal item As SituacionTrabajador)
#End Region
#Region "Consulta"

        Function SituacionTrabajadorQuery(ByVal sit_SituaTrab_Id As String, ByVal sit_Descripcion As String)
        Function SituacionTrabajadorSeek(ByVal id As String) As SituacionTrabajador

#End Region
    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCSituacionEspecialTrabajador

'#Region "mantenimiento"

'        Function Mantenance(ByVal item As SituacionEspecialTrabajador)

'#End Region

'#Region "Consulta"

'        Function SituacionEspecialTrabajadorQuery(ByVal set_SituEspe_Id As String, ByVal set_Descripcion As String)
'        Function SituacionEspecialTrabajadorSeek(ByVal id As String) As SituacionEspecialTrabajador

'#End Region

'    End Interface

'End Namespace
