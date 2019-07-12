Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCDireccionesPersonas
        Function MantenimientoDireccionesPersonas(ByVal Item As DireccionesPersonas) As Short
        Function spEliminarDireccionesPersonasPER_ID(ByVal PER_ID As String) As Short
        Function DeleteRegistro(ByVal item As DireccionesPersonas, _
                                ByVal cPER_ID As String, _
                                ByVal cDIR_ID As String) As Short
        Function spActualizarRegistro(ByVal cDIR_ID As String, _
                                      ByVal cPER_ID As String, _
                                      ByVal cDIR_DESCRIPCION As String, _
                                      ByVal cDIR_TIPO As Int16, _
                                      ByVal cDIR_REFERENCIA As String, _
                                      ByVal cDIS_ID As String, _
                                      ByVal cUSU_ID As String, _
                                      ByVal cDIR_FEC_GRAB As DateTime, _
                                      ByVal cDIR_ESTADO As Boolean) As Short
        Function spInsertarRegistro(ByVal cDIR_ID As String, _
                                      ByVal cPER_ID As String, _
                                      ByVal cDIR_DESCRIPCION As String, _
                                      ByVal cDIR_TIPO As Int16, _
                                      ByVal cDIR_REFERENCIA As String, _
                                      ByVal cDIS_ID As String, _
                                      ByVal cUSU_ID As String, _
                                      ByVal cDIR_FEC_GRAB As DateTime, _
                                      ByVal cDIR_ESTADO As Boolean) As Short
        Function spEliminarRegistro(ByVal cDIR_ID As String, _
                                    ByVal cPER_ID As String) As Short
        Function spEliminarRegistroNuevo(ByVal cDIR_ID As String, _
                                    ByVal cPER_ID As String, _
                                    ByVal cUSU_ID As String) As Short
    End Interface
End Namespace
