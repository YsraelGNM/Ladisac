Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCDetalleConceptoPensionario
#Region "Mantenimiento"
        Function Maintenance(ByVal item As DetalleConceptosPensionarios)

#End Region

#Region "Consulta"
        Function DetalleConceptosPensionariosQuery(ByVal rep_RegiPension_id As String)
        Function DetalleConceptosPensionariosSeek(ByVal rep_RegiPension_id As String, ByVal tic_TipoConcep_Id As String, ByVal con_Conceptos_Id As String) As BE.DetalleConceptosPensionarios
        Function DetalleConceptosPensionariosDetalleQuery(ByVal rep_RegiPension_id As String, ByVal tic_TipoConcep_Id As String, ByVal con_Conceptos_Id As String)

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
