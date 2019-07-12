Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCDetalleListaPrecios
        Function MantenimientoDetalleListaPrecios(ByVal Item As DetalleListaPrecios) As Short
        'Function DeleteRegistroDetalleListaPrecios(ByVal item As DetalleListaPrecios, ByVal cLPR_ID As String, ByVal cART_ID As String) As Short

        Function spActualizarRegistro(ByVal cLPR_ID As String,
                              ByVal cART_ID As String,
                              ByVal cDLP_PRECIO_MINIMO As Double,
                              ByVal cDLP_PRECIO_UNITARIO As Double,
                              ByVal cDLP_RECARGO_ENVIO As Double,
                              ByVal cUSU_ID As String,
                              ByVal cDLP_FEC_GRAB As DateTime,
                              ByVal cDLP_ESTADO As Boolean) As Short
        Function spInsertarRegistro(ByVal cLPR_ID As String,
                                    ByVal cART_ID As String,
                                    ByVal cDLP_PRECIO_MINIMO As Double,
                                    ByVal cDLP_PRECIO_UNITARIO As Double,
                                    ByVal cDLP_RECARGO_ENVIO As Double,
                                    ByVal cUSU_ID As String,
                                    ByVal cDLP_FEC_GRAB As DateTime,
                                    ByVal cDLP_ESTADO As Boolean) As Short
        Function spEliminarRegistro(ByVal cLPR_ID As String,
                                    ByVal cART_ID As String) As Short
    End Interface
End Namespace
