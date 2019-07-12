Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCRegimenLaboral
#Region "Mantenimiento"
        Function MAintenance(ByVal item As RegimenLaboral)
#End Region

#Region "Consulta"
        Function RegimenLaboralQuery(ByVal rel_RegLaboral_Id As String, ByVal rel_Descripcioren As String)
        Function RegimenLaboralSeek(ByVal id As String) As BE.RegimenLaboral
#End Region
    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCNivelEducacion
'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As NivelEducacion)
'#End Region
'#Region "Consulta"
'        Function NivelEducacionQuery(ByVal nie_NiveEduc_Id As String, ByVal nie_Descipcion As String)
'        Function NivelEducacionSeek(ByVal id As String) As BE.NivelEducacion

'#End Region


'    End Interface

'End Namespace

