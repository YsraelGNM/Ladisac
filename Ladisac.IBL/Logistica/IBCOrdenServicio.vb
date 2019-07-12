Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCOrdenServicio

#Region "Mantenimientos"
        Function MantenimientoOrdenServicio(ByVal mOrdenServicio As OrdenServicio) As Integer
        Sub MantenimientoOrdenServicioDetalle(ByVal mOrdenServicioDetalle As OrdenServicioDetalle)
#End Region

#Region "Querys"
        Function OrdenServicioGetById(ByVal OSE_ID As Integer) As OrdenServicio
        Function OrdenServicioDetalleGetById(ByVal OSD_ID As Integer) As OrdenServicioDetalle
        Function ListaOrdenServicio() As String
        Function ImpresionOrdenServicio(ByVal OSE_ID) As String
        Function ListaOrdenServicioID(ByVal OSE_ID As Nullable(Of Integer)) As DataSet
        Function ListaProgramacionPagoProveedor(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Per_Id_Proveedor As String) As String
#End Region

    End Interface

End Namespace
