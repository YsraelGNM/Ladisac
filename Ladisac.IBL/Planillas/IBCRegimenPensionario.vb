Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCRegimenPensionario

#Region "Mantenimiento"
        Function Mantenance(ByVal item As RegimenPensionario)
#End Region


#Region "Consulta"

        Function RegimenPensionarioQuery(ByVal rep_RegiPension_id As String, ByVal rep_Descripcion As String)
        Function RegimenPensionarioSeek(ByVal id As String) As RegimenPensionario

#End Region

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCRegimenLaboral
'#Region "Mantenimiento"
'        Function MAintenance(ByVal item As RegimenLaboral)
'#End Region

'#Region "Consulta"
'        Function RegimenLaboralQuery(ByVal rel_RegLaboral_Id As String, ByVal rel_Descripcioren As String)
'        Function RegimenLaboralSeek(ByVal id As String) As BE.RegimenLaboral
'#End Region
'    End Interface

'End Namespace