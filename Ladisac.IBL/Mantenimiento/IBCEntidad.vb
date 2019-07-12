Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCEntidad

#Region "Mantenimientos"
        Sub MantenimientoEntidad(ByVal mEntidad As Entidad)
#End Region

#Region "Querys"
        Function EntidadGetById(ByVal ENO_ID As Integer) As Entidad
        Function ListaEntidad() As String
        Function ListaConsumoEntidad(ByVal Eno_Id As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal Art_Id As String, ByVal OTR_ID As Integer, ByVal MTO_ID As Integer, ByVal TCM_ID As Integer, ByVal GRU_ID As Integer) As DataSet
        Function ListaAlertaCambios() As String
        Function EstadoTrabajoMantto(ByVal Eno_Id As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal CompFI As Date, ByVal CompFF As Date, ByVal Gru_Id As Nullable(Of Integer), ByVal OTR_Fase As String) As String
        Function EstadoTrabajoManttoDetallado(ByVal Eno_Id As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal Gru_Id As Nullable(Of Integer), ByVal OTR_Fase As String) As String
        Function ListaHijos(ByVal ENO_Id As Integer) As List(Of Entidad)
        Function ListaHijosEntidad(ByVal ENO_ID As Integer) As String
        Function ListaEntidadOrdenTrabajo(ByVal OTR_ID As String) As String
        Function ListaEntidadID(ByVal ENO_ID As Nullable(Of Integer)) As DataSet
        Function ListaUsuarioEntidad(ByVal USU_ID As String, ByVal ENO_ID As Nullable(Of Integer)) As String
        Function CargarDataVisionLink(ByVal ENO_ID As Integer) As String
        Function VLConsumoCombustible(ByVal ENO_ID As Nullable(Of Integer), ByVal FecIni As Date, ByVal FecFin As Date) As String
        Function ListaEntidadCuentaContable() As List(Of Entidad)
        Function ListaEntidadRegistro() As String
        Function ListaEntidadPlaca() As String
        Function UltimoHorometro(ByVal ENO_ID As Integer, ByVal Tipo As String) As Decimal
#End Region

    End Interface

End Namespace
