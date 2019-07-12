Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCCuentasArticulo
#Region "mantenimiento"
        Function Maintenance(ByVal item As CuentasArticulo)

#End Region
#Region "Consultas"

        Function CuentasArticuloQuery(ByVal id As String)
        Function CuentasArticuloSeek(ByVal id As String) As BE.CuentasArticulo
        Function SPArticulosLadrillo(ByVal ART_ID As String, ByVal ART_COD_FAB As String, ByVal ART_DESCRIPCION As String)
#End Region
    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Interface IBCLibrosContables
'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As LibrosContables)
'#End Region

'#Region "Consulta"
'        Function LibrosContablesQuery(ByVal lib_Id As String, ByVal lib_Libro As String, ByVal lib_Descripcion As String)
'        Function LibrosContablesSeek(ByVal id As String) As BE.LibrosContables
'#End Region

'    End Interface

'End Namespace