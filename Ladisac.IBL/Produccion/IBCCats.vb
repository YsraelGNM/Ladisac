Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCCats

#Region "Mantenimientos"
        Sub MantenimientoCats(ByVal mCats As Cats)
#End Region

#Region "Querys"
        Function CatsGetById(ByVal CAT_ID As Integer) As Cats
        Function ListaCats() As String
        Function ListaCatsMezcla() As String
#End Region

    End Interface

End Namespace
