Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCRecepcionDocumento

#Region "Mantenimientos"
        Sub MantenimientoRecepcionDocumento(ByVal mRecepcionDocumento As RecepcionDocumento)
#End Region

#Region "Querys"
        Function RecepcionDocumentoGetById(ByVal RDO_ID As Integer) As RecepcionDocumento
        Function ListaRecepcionDocumento() As String
        Function ListaDarRecepcion(ByVal PER_ID_RECIBIDO As String) As List(Of RecepcionDocumento)
        Function ListaReporteSeguimientoDocumento(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Serie As String, ByVal Numero As String, ByVal Per_Id_Proveedor As String, ByVal USU_ID As String) As DataTable
        Function RecepcionDocumentoGetById2(ByVal Per_Id As String, ByVal Dtd_Id As String, ByVal Serie As String, ByVal Numero As String) As RecepcionDocumento
#End Region

    End Interface

End Namespace
