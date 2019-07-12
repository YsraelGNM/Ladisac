Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCOrdenDespacho

#Region "Mantenimientos"
        Sub MantenimientoOrdenDespacho(ByVal mOrdenDespacho As OrdenDespacho)
#End Region

#Region "Querys"
        Function OrdenDespachoGetById(ByVal ODE_ID As Integer) As OrdenDespacho
        Function ListaOrdenDespacho() As String
        Function ListaPesaje(ByVal Ticket As Nullable(Of Integer)) As String
        Function ListaPlacaPesaje(ByVal Uni_id As String) As String
        Function ListaLadrilloDespacho() As String
        Function ListaCronogramaXdespachar(ByVal Fecha As Date) As String
#End Region

    End Interface

End Namespace
