Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IEntidadRepositorio
        Function GetById(ByVal ENO_Id As Integer) As Entidad
        Sub Maintenance(ByVal Entidad As Entidad)
        Function ListaEntidad() As String
        Function ListaHijos(ByVal ENO_Id As Integer) As List(Of Entidad)
        Function ListaConsumoEntidad(ByVal Eno_Id As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal Art_Id As String, ByVal OTR_ID As Integer, ByVal MTO_ID As Integer, ByVal TCM_ID As Integer, ByVal GRU_ID As Integer) As DataSet
        Function ListaEntidadID(ByVal ENO_ID As Nullable(Of Integer)) As DataSet
        Function ListaEntidadCuentaContable() As List(Of Entidad)
        Function UltimoHorometro(ByVal ENO_ID As Integer, ByVal Tipo As String) As Decimal
    End Interface

End Namespace

