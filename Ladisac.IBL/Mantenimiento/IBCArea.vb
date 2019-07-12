Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCArea

#Region "Mantenimientos"
        Sub MantenimientoArea(ByVal mArea As Area)
#End Region

#Region "Querys"
        Function AreaGetById(ByVal ARE_ID As Integer) As Area
        Function ListaArea() As String
        Function ListaAreaRRHH() As String
#End Region

    End Interface

End Namespace
