Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCSituacionEspecialTrabajador

#Region "mantenimiento"

        Function Mantenance(ByVal item As SituacionEspecialTrabajador)

#End Region

#Region "Consulta"

        Function SituacionEspecialTrabajadorQuery(ByVal set_SituEspe_Id As String, ByVal set_Descripcion As String)
        Function SituacionEspecialTrabajadorSeek(ByVal id As String) As SituacionEspecialTrabajador

#End Region

    End Interface

End Namespace

'Imports Ladisac.BE

'Namespace Ladisac.BL
'    Public Interface IBCRegimenPensionario

'#Region "Mantenimiento"
'        Function Mantenance(ByVal item As RegimenPensionario)
'#End Region


'#Region "Consulta"

'        Function RegimenPensionarioQuery(ByVal rep_RegiPension_id As String, ByVal rep_Descripcion As String)
'        Function RegimenPensionarioSeek(ByVal id As String) As RegimenPensionario

'#End Region

'    End Interface

'End Namespace
