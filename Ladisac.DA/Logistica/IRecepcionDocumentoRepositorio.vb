Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IRecepcionDocumentoRepositorio
        Function GetById(ByVal RDO_Id As Integer) As RecepcionDocumento
        Sub Maintenance(ByVal RecepcionDocumento As RecepcionDocumento)
        Function ListaRecepcionDocumento() As String
        Function ListaDarRecepcion(ByVal PER_ID_RECIBIDO As String) As List(Of RecepcionDocumento)
        Function GetById2(ByVal Per_Id As String, ByVal Dtd_Id As String, ByVal Serie As String, ByVal Numero As String) As RecepcionDocumento
    End Interface

End Namespace

