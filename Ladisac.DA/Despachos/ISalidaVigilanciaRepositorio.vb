Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISalidaVigilanciaRepositorio
        Function GetById(ByVal SVI_Id As Integer) As SalidaVigilancia
        Function GetByIdDocumento(ByVal Documento As String) As SalidaVigilancia
        Sub Maintenance(ByVal SalidaVigilancia As SalidaVigilancia)
        Function ListaSalidaVigilancia() As String
    End Interface

End Namespace

