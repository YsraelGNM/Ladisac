Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IOrdenSalidaRepositorio
        Function GetById(ByVal OSA_Id As Integer) As OrdenSalida
        Sub Maintenance(ByVal OrdenSalida As OrdenSalida)
        Function ListaOrdenSalida() As String
    End Interface

End Namespace

