Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCDistrito

#Region "Mantenimientos"
        Function MantenimientoDistrito(ByVal Item As Distrito) As Short
#End Region

#Region "Querys"
        'Function DistritoGetById(ByVal DIS_ID As Integer) As Distrito
        Function ListaDistrito() As String
#End Region

    End Interface

End Namespace
