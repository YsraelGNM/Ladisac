Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IOrdenDespachoRepositorio
        Function GetById(ByVal ODE_ID As String) As OrdenDespacho
        Sub Maintenance(ByVal OrdenDespacho As OrdenDespacho)
        Function ListaOrdenDespacho() As String
    End Interface

End Namespace

