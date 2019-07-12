Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IOrdenServicioRepositorio
        Function GetById(ByVal OSE_Id As Integer) As OrdenServicio
        Sub Maintenance(ByVal OrdenServicio As OrdenServicio)
        Function ListaOrdenServicio() As String
        Function ListaOrdenServicioID(ByVal OSE_ID As Nullable(Of Integer)) As DataSet
    End Interface

End Namespace

