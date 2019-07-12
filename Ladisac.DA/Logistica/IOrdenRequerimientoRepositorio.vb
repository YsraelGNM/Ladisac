Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IOrdenRequerimientoRepositorio
        Function GetById(ByVal ORR_Id As Integer) As OrdenRequerimiento
        Sub Maintenance(ByVal OrdenRequerimiento As OrdenRequerimiento)
        Function ListaOrdenRequerimiento(ByVal Filtro As String) As DataSet
        Function ListaORDocumentacion(ByVal ORR_Id As Nullable(Of Integer)) As DataSet
        Function ListaORSalidaCombustible(ByVal ORR_Id As Nullable(Of Integer)) As DataSet
        Function ListaORLadrillo(ByVal ORR_Id As Nullable(Of Integer)) As DataSet
        Function ListaOrdenRequerimientoServicio(ByVal Filtro As String) As DataSet
        Function CantidadPorComprar(ByVal ART_ID As String) As Double
        Function CantidadPorAtender(ByVal ART_ID As String) As Double
    End Interface

End Namespace

