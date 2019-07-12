Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IKardexLoteRepositorio
        Function GetById(ByVal KAL_Id As Integer) As KardexLote
        Function GetByIdDRU_ID(ByVal DRU_Id As Integer) As List(Of KardexLote)
        Sub Maintenance(ByVal KardexLote As KardexLote)
        'Function ListaKardex(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Integer, ByVal ART_Id As String) As String
        'Sub RehacerKardex(ByVal ART_Id As String, ByVal Alm_Id As Integer, ByVal Fecha As Date)
        'Function StockCostoPromedio(ByVal ART_Id As String, ByVal Alm_Id As Integer, ByVal Fecha As Date, ByVal Flag As Integer) As Decimal
        'Function ListaDocOperacion(ByVal IngresoSalida As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal ALM_ID As Nullable(Of Integer)) As String

    End Interface

End Namespace

