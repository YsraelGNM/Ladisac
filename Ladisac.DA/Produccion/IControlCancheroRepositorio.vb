Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlCancheroRepositorio
        Function GetById(ByVal CCA_Id As Integer) As ControlCanchero
        Sub Maintenance(ByVal ControlCanchero As ControlCanchero)
        Function ListaControlCanchero() As String
        Function GetByPro_Id(ByVal PRO_Id As Integer) As List(Of ControlCanchero)
    End Interface

End Namespace

