Namespace Ladisac.BL
    Public Interface IBCGrupoTrabajoDiasDescanso

#Region "Mantenimiento"
        Sub Maintenance(ByVal fechaInicio As Date, ByVal xml As String, ByVal USU_ID As String)
#End Region

#Region "Consulta"
        Function spGrupoTrabajoDiasDescansoSelect(ByVal fechaDesde As Date, Optional ByVal Trabajador As String = "", Optional ByVal filtro As Single = 0)
        Function spGrupoTrabajoDiasDescansoReporte(ByVal fechaDesde As Date, Optional ByVal Trabajador As String = "", Optional ByVal filtro As Single = 0)
#End Region

    End Interface

End Namespace


'Imports Ladisac.BE

'Namespace Ladisac.BL

'    Public Interface IBCConceptos

'#Region "Mantenimiento"

'        Sub Maintenance(ByVal item As Conceptos)
'        Sub spCrearFunctionAcumuladoConcepto(ByVal tic_TipoConcep_Id As String, ByVal con_Conceptos_Id As String, ByVal nombre As String)

'#End Region

'#Region "Consulta"

'        Function ConceptosQuery(Optional ByVal con_Conceptos_Id As String = Nothing, Optional ByVal tic_TipoConcep_Id As String = Nothing, Optional ByVal con_Conceptoas As String = Nothing, Optional ByVal con_Descripcion As String = Nothing) As String
'        Function ConceptosSeek(ByVal tipo As String, ByVal codigoConcepto As String) As BE.Conceptos

'#End Region
'    End Interface


'End Namespace