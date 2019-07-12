Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCLineaFamilia

#Region "Mantenimientos"
        Sub MantenimientoLineaFamilia(ByVal mLineaFamilia As LineasFamilia)
#End Region

#Region "Querys"
        Function LineaFamiliaGetById(ByVal LIN_ID As String) As LineasFamilia
        Function ListaLineaFamilia() As String
#End Region

    End Interface

End Namespace
