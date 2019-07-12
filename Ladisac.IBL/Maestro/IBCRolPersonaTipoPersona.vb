Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCRolPersonaTipoPersona
        Function MantenimientoRolPersonaTipoPersona(ByVal Item As RolPersonaTipoPersona) As Short
        Function spEliminarRolPersonaTipoPersonaPER_ID(ByVal PER_ID As String) As Short
        'Function DeleteRegistro(ByVal item As RolPersonaTipoPersona, _
        '                        ByVal cPER_ID As String, _
        '                        ByVal cTPE_ID As String) As Short
        Function spActualizarRegistro(ByVal cPER_ID As String, _
                              ByVal cTPE_ID As String, _
                              ByVal cUSU_ID As String, _
                              ByVal cRTP_FEC_GRAB As DateTime, _
                              ByVal cRTP_ESTADO As Boolean) As Short
        Function spInsertarRegistro(ByVal cPER_ID As String, _
                                    ByVal cTPE_ID As String, _
                                    ByVal cUSU_ID As String, _
                                    ByVal cRTP_FEC_GRAB As DateTime, _
                                    ByVal cRTP_ESTADO As Boolean) As Short
        Function spEliminarRegistro(ByVal cPER_ID As String, _
                                    ByVal cTPE_ID As String) As Short
    End Interface
End Namespace
