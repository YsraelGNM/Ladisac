Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCOperacionDetraciones

#Region "Mantenimiento"
        Function Maintenance(ByVal item As OperacionDetraciones)
#End Region
#Region "Consulta"
        Function OperacionDetracionesQuery(ByVal opd_Oper_Detra_Id As String, ByVal opd_Descripcion As String)
        Function OperacionDetracionesSeek(ByVal id As String) As OperacionDetraciones

#End Region

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Interface IBCClaseCuenta

'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As ClaseCuenta)
'#End Region

'#Region "Consulta"

'        Function ClaseCuentaQuery(ByVal cls_Id As String, ByVal cls_Clase As String)
'        Function ClaseCuentaSeek(ByVal id As String) As BE.ClaseCuenta

'#End Region

'    End Interface


'End Namespace
