Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCCaCoDeDetalle

#Region "Mantenimientos"
        Sub MantenimientoCaCoDeDetalle(ByVal mCaCoDeDetalle As CaCoDe_Detalle)
        Sub MantenimientoCaCoDeDetalle2(ByVal colCaCoDeDetalle As List(Of CaCoDe_Detalle), ByVal Carga As ControlCarga, ByVal Quema As ControlQuema, ByVal Descarga As ControlDescarga)
        Function CargarCaCoDeDetalle(ByVal mItem As DataRow) As CaCoDe_Detalle
#End Region

#Region "Querys"
        Function CaCoDeDetalleGetById(ByVal CCD_ID As Integer) As CaCoDe_Detalle
        Function ListaCaCoDeDetalle(ByVal Dia As Date, ByVal HOR_ID As Integer) As String
        Function ValidarCarga(ByVal PRO_ID As Integer) As DataSet
#End Region

    End Interface

End Namespace
