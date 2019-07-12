Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlCargaRepositorio
        Function GetById(ByVal CAR_Id As Integer) As ControlCarga
        Sub Maintenance(ByVal ControlCarga As ControlCarga)
        Function ListaControlCarga(ByVal PRO_ID As Nullable(Of Integer)) As String
    End Interface

End Namespace

