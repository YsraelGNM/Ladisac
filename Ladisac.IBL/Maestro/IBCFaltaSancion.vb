Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCFaltaSancion

#Region "Mantenimientos"
        Sub MantenimientoFaltaSancion(ByVal mFaltaSancion As FaltaSancion)
#End Region

#Region "Querys"
        Function FaltaSancionGetById(ByVal FSA_ID As Integer) As FaltaSancion
        Function ListaFaltaSancion() As String
#End Region

    End Interface

End Namespace
