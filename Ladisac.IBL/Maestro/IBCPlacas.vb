Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCPlacas
        Function Mantenimiento(ByVal Item As Placas) As Short
        Function spActualizarRegistro(ByVal cPLA_ID As String,
            ByVal cUNT_ID_1 As String,
            ByVal cUNT_ID_2 As String,
            ByVal cPER_ID As String,
            ByVal cUSU_ID As String,
            ByVal cPLA_FEC_GRAB As DateTime,
            ByVal cPLA_ESTADO As Boolean) As Short
        Function spInsertarRegistro(ByVal cPLA_ID As String,
           ByVal cUNT_ID_1 As String,
           ByVal cUNT_ID_2 As String,
           ByVal cPER_ID As String,
           ByVal cUSU_ID As String,
           ByVal cPLA_FEC_GRAB As DateTime,
           ByVal cPLA_ESTADO As Boolean) As Short
        Function spEliminarRegistro(ByVal cPLA_ID As String) As Short
        Function ListaPlacas(ByVal PER_Id As String) As String
    End Interface
End Namespace
