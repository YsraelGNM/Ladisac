Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCDocPersonas
        Function MantenimientoDocPersonas(ByVal Item As DocPersonas) As Short
        Function spEliminarDocPersonasPER_ID(ByVal PER_ID As String) As Short
        'Function DeleteRegistro(ByVal item As DocPersonas, _
        '                        ByVal cPER_ID As String, _
        '                        ByVal cTDP_ID As String) As Short

        Function ActualizarRegistro(ByVal cPER_ID As String, _
                              ByVal cTDP_ID As String, _
                              ByVal cDOP_NUMERO As String, _
                              ByVal cUSU_ID As String, _
                              ByVal cDOP_FEC_GRAB As DateTime, _
                              ByVal cDOP_ESTADO As Boolean
                             ) As Short
        Function InsertarRegistro(ByVal cPER_ID As String, _
                                      ByVal cTDP_ID As String, _
                                      ByVal cDOP_NUMERO As String, _
                                      ByVal cUSU_ID As String, _
                                      ByVal cDOP_FEC_GRAB As DateTime, _
                                      ByVal cDOP_ESTADO As Boolean
                                     ) As Short
        Function EliminarRegistro(ByVal cPER_ID As String, _
                                  ByVal cTDP_ID As String) As Short

        Function DocPersonaGetById_Numero(ByVal DOP_Numero As String) As DocPersonas
    End Interface
End Namespace
