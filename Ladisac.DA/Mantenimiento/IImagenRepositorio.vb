Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IImagenRepositorio
        Function GetById(ByVal IMA_Id As Integer) As Imagen
        Sub Maintenance(ByVal Imagen As Imagen)
        Function ListaImagen() As String
    End Interface

End Namespace

