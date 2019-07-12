Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCOrdenRequerimiento

#Region "Mantenimientos"
        Function MantenimientoOrdenRequerimiento(ByVal mOrdenRequerimiento As OrdenRequerimiento) As Integer
        Sub MantenimientoOrdenRequerimientoDetalle(ByVal mOrdenRequerimientoDetalle As OrdenRequerimientoDetalle)
#End Region

#Region "Querys"
        Function OrdenRequerimientoGetById(ByVal ORR_ID As Integer) As OrdenRequerimiento
        Function OrdenRequerimientoDetalleGetById(ByVal ORD_ID As Integer) As OrdenRequerimientoDetalle
        Function ListaOrdenRequerimiento(ByVal Filtro As String) As DataSet
        Function ListadoOrdenRequerimiento(ByVal FecIni As Date, ByVal FecFin As Date, ByVal ORR_Importancia As Integer, ByVal ORT_Id As Integer, ByVal Estado As Integer, ByVal Grupo As Integer) As String
        Function ListaORDocumentacion(ByVal ORR_Id As Nullable(Of Integer)) As DataSet
        Function ListaORSalidaCombustible(ByVal ORR_Id As Nullable(Of Integer)) As DataSet
        Function ListaORLadrillo(ByVal ORR_Id As Nullable(Of Integer)) As DataSet
        Function EnviarCorreoPermisoCargaSinDocumento(ByVal ORR_Id As Nullable(Of Integer)) As String
        Function ListaOrdenRequerimientoServicio(ByVal Filtro As String) As DataSet
        Function CantidadPorComprar(ByVal ART_ID As String) As Double
        Function CantidadPorAtender(ByVal ART_ID As String) As Double
#End Region

    End Interface

End Namespace
