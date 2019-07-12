Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCRegistroEquipo

#Region "Mantenimientos"
        Sub MantenimientoRegistroEquipo(ByVal mRegistroEquipo As RegistroEquipo)
#End Region

#Region "Querys"
        Function RegistroEquipoGetById(ByVal REQ_ID As Integer) As RegistroEquipo
        Function ListaRegistroEquipo() As String
        Function ListaArea() As String
        Function ListaTarea() As String
        Function ListaUbicacionTrabajo() As String
        Function ReporteRegistroEquipo(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Are_Id As Nullable(Of Integer), ByVal Tar_Id As Nullable(Of Integer), ByVal Eno_Id As Nullable(Of Integer), ByVal Per_Id As String, ByVal Utr_Id As Nullable(Of Integer), ByVal Req_Turno As Nullable(Of Integer)) As String
#End Region

    End Interface

End Namespace
