Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IContactoPersonaRepositorio
        Function Maintenance(ByVal item As ContactoPersona) As Short
        Function spEliminarContactoPersonaPER_ID(ByVal PER_ID As String) As Short
        'Function DeleteRegistro(ByVal item As ContactoPersona, _
        '                        ByVal cPER_ID As String, _
        '                        ByVal cCOP_ID As String) As Short

        Function ActualizarRegistro(ByVal cPER_ID As String, _
                                    ByVal cCOP_ID As String, _
                                    ByVal cCOP_TIPO As Int16, _
                                    ByVal cCOP_DESCRIPCION As String, _
                                    ByVal cCOP_DIRECCION As String, _
                                    ByVal cCOP_TELEFONO As String, _
                                    ByVal cCOP_EMAIL As String, _
                                    ByVal cUSU_ID As String, _
                                    ByVal cCOP_FEC_GRAB As DateTime, _
                                    ByVal cCOP_ESTADO As Boolean) As Short
        Function InsertarRegistro(ByVal cPER_ID As String, _
                                  ByVal cCOP_ID As String, _
                                  ByVal cCOP_TIPO As Int16, _
                                  ByVal cCOP_DESCRIPCION As String, _
                                  ByVal cCOP_DIRECCION As String, _
                                  ByVal cCOP_TELEFONO As String, _
                                  ByVal cCOP_EMAIL As String, _
                                  ByVal cUSU_ID As String, _
                                  ByVal cCOP_FEC_GRAB As DateTime, _
                                  ByVal cCOP_ESTADO As Boolean) As Short
        Function EliminarRegistro(ByVal cPER_ID As String, _
                                  ByVal cCOP_ID As String) As Short

    End Interface
End Namespace
