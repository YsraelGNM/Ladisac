Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlDescargaRepositorio
        Function GetById(ByVal DES_Id As Integer) As ControlDescarga
        Sub Maintenance(ByVal ControlDescarga As ControlDescarga)
        Function ListaControlDescarga() As String
    End Interface

End Namespace

