Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCClaseCuenta

#Region "Mantenimiento"
        Function Maintenance(ByVal item As ClaseCuenta)
#End Region

#Region "Consulta"

        Function ClaseCuentaQuery(ByVal cls_Id As String, ByVal cls_Clase As String)
        Function ClaseCuentaSeek(ByVal id As String) As BE.ClaseCuenta

#End Region

    End Interface


End Namespace



'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCCuentasContables

'#Region "mantenimiento"
'        Function Maintenance(ByVal item As CuentasContables)
'#End Region

'#Region "Consulta"

'        Function CuentasContablesQuery(ByVal CUC_ID As String, ByVal CUC_DESCRIPCION As String)
'        Function CuentasContablesSeek(ByVal id As String) As BE.CuentasContables

'#End Region
'    End Interface

'End Namespace