Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCFamiliaArticulo

#Region "Mantenimientos"
        Sub MantenimientoFamiliaArticulo(ByVal mFamiliaArticulo As FamiliaArticulos)
#End Region

#Region "Querys"
        Function FamiliaArticuloGetById(ByVal FAM_ID As String) As FamiliaArticulos
        Function ListaFamiliaArticulo() As String
#End Region

    End Interface

End Namespace
