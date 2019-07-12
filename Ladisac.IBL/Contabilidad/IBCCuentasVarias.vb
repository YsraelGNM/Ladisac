Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCCuentasVarias
#Region "Mantenimiento"
        Function Maintenance(ByVal item As CuentasVarias)

#End Region
#Region "Consulta"
        Function CuentasVariasQuery(ByVal id As String)
        Function CuentasVariasSeek(ByVal id As String) As BE.CuentasVarias

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
