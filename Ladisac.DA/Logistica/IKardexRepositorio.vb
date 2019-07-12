Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IKardexRepositorio
        Function GetById(ByVal KAR_Id As Integer) As kardex
        Sub Maintenance(ByVal Kardex As Kardex)
        Function ListaKardex(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Integer, ByVal ART_Id As String) As String
        Sub RehacerKardex(ByVal ART_Id As String, ByVal Alm_Id As Integer, ByVal Fecha As Date)
        Function StockCostoPromedio(ByVal ART_Id As String, ByVal Alm_Id As Integer, ByVal Fecha As Date, ByVal Flag As Integer) As Decimal
        Function ListaDocOperacion(ByVal IngresoSalida As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal ALM_ID As Nullable(Of Integer), ByVal ART_Id As String) As String

    End Interface

End Namespace

