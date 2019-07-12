Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IPuertaHornoRepositorio
        Function GetById(ByVal PUE_Id As Integer) As PuertaHorno
        Sub Maintenance(ByVal PuertaHorno As PuertaHorno)
        Function ListaPuertaHorno() As String
        Function ListaPuertaHornoByHorno(ByVal HOR_ID As Integer) As String
    End Interface

End Namespace

