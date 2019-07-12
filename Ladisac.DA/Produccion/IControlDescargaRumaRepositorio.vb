Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlDescargaRumaRepositorio
        Function GetById(ByVal DRU_Id As Integer) As ControlDescargaRuma
        Sub Maintenance(ByVal ControlDescargaRuma As ControlDescargaRuma)
        Function ListaControlDescargaRuma() As String
    End Interface

End Namespace

