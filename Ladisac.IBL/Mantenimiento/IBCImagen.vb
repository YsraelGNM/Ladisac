Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCImagen

#Region "Mantenimientos"
        Sub MantenimientoImagen(ByVal mImagen As Imagen)
#End Region

#Region "Querys"
        Function ImagenGetById(ByVal IMA_ID As Integer) As Imagen
        Function ListaImagen() As String
#End Region

    End Interface

End Namespace
