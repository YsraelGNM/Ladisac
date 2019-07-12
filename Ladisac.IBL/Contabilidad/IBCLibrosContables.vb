Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCLibrosContables
#Region "Mantenimiento"
        Function Maintenance(ByVal item As LibrosContables)
#End Region

#Region "Consulta"
        Function LibrosContablesQuery(ByVal lib_Id As String, ByVal lib_Libro As String, ByVal lib_Descripcion As String)
        Function LibrosContablesDividendosQuery(ByVal lib_Id As String, ByVal lib_Libro As String, ByVal lib_Descripcion As String)
        Function LibrosContablesSeek(ByVal id As String) As BE.LibrosContables
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