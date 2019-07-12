Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCTiposBienesServicios
#Region "Mantenimiento"
        Function Maintenance(ByVal item As TiposBienesServicios)

#End Region

#Region "Consultas"
        Function TiposBienesServiciosQuery(ByVal tib_TipoBien_Id As String, ByVal tib_Descripcion As String)
        Function TiposBienesServiciosSeek(ByVal id As String) As BE.TiposBienesServicios

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

