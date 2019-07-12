Imports Ladisac.BE

Namespace Ladisac.DA
    Public Interface IListaPreciosArticulosRepositorio
        Function Maintenance(ByVal item As ListaPreciosArticulos) As Short
        Function spActualizarRegistro(ByVal cLPR_ID As String,
                                      ByVal cLPR_DESCRIPCION As String,
                                      ByVal cLPR_PRINCIPAL As Boolean,
                                      ByVal cPER_ID As String,
                                      ByVal cMON_ID As String,
                                      ByVal cUSU_ID As String,
                                      ByVal cLPR_FEC_GRAB As DateTime,
                                      ByVal cLPR_ESTADO As Boolean,
                                      ByVal cLPR_CONTROL As Boolean,
                                      ByVal cLPR_ID_ADJ As String) As Short

        Function spInsertarRegistro(ByVal cLPR_ID As String,
                                    ByVal cLPR_DESCRIPCION As String,
                                    ByVal cLPR_PRINCIPAL As Boolean,
                                    ByVal cPER_ID As String,
                                    ByVal cMON_ID As String,
                                    ByVal cUSU_ID As String,
                                    ByVal cLPR_FEC_GRAB As DateTime,
                                    ByVal cLPR_ESTADO As Boolean,
                                    ByVal cLPR_CONTROL As Boolean,
                                    ByVal cLPR_ID_ADJ As String) As Short
        Function spEliminarRegistro(ByVal cLPR_ID As String) As Short

        Function spDetalleListaPreciosUpdateInsert(ByVal DatosModeloXml As String, ByVal DatosListaXml As String, ByVal cUSU_ID As String)

        Function spDetalleListaPreciosUpdate(ByVal registroxm As String, ByVal art_id As String, ByVal precio As Double)
        Function spDetalleListaPreciosRecargaUpdate(ByVal registroxm As String, ByVal art_id As String, ByVal precio As Double)

    End Interface
End Namespace
