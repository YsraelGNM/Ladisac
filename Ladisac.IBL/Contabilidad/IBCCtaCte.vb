Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCCtaCte

#Region "Mantenimiento"
        Function Maintenance(ByVal item As CtaCte)
#End Region

#Region "Consulta"
        Function CtaCteQuery(ByVal CCT_ID As String, ByVal CCT_DESCRIPCION As String)
        Function CtaCteSeek(ByVal id As String) As BE.CtaCte
#End Region

    End Interface

End Namespace


'Imports Ladisac.BE

'Namespace Ladisac.BL

'Public Interface IBCClaseCuenta
'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As ClaseCuenta)
'#End Region

'#Region "Consulta"

'        Function ClaseCuentaQuery(ByVal cls_Id As String, ByVal cls_Clase As String)
'        Function ClaseCuentaSeek(ByVal id As String) As BE.ClaseCuenta

'#End Region

'    End Interface


'End Namespace