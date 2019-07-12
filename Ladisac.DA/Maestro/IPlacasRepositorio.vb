Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IPlacasRepositorio
        Function Maintenance(ByVal item As Placas) As Short
        Function spActualizarRegistro( Byval cPLA_ID as string,
           ByVal cUNT_ID_1 As String,
           ByVal cUNT_ID_2 As String,
           ByVal cPER_ID As String,
           ByVal cUSU_ID As String,
           ByVal cPLA_FEC_GRAB As DateTime,
           ByVal cPLA_ESTADO As Boolean) As Short
        Function spInsertarRegistro( Byval cPLA_ID as string,
           ByVal cUNT_ID_1 As String,
           ByVal cUNT_ID_2 As String,
           ByVal cPER_ID As String,
           ByVal cUSU_ID As String,
           ByVal cPLA_FEC_GRAB As DateTime,
           ByVal cPLA_ESTADO As Boolean) As Short
        Function spEliminarRegistro(ByVal cPLA_ID As String) As Short
    End Interface
End Namespace