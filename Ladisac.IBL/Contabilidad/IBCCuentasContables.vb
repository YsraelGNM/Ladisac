Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCCuentasContables

#Region "mantenimiento"
        Function Maintenance(ByVal item As CuentasContables)
#End Region

#Region "Consulta"

        Function CuentasContablesQuery(ByVal CUC_ID As String, ByVal CUC_DESCRIPCION As String, ByVal cuc_Abreviatura As String, ByVal activo As Integer)
        Function CuentasContablesSeek(ByVal id As String) As BE.CuentasContables
        Function CuentasContablesDetalleQuery(ByVal CUC_ID As String, ByVal CUC_DESCRIPCION As String)

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