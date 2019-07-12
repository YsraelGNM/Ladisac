Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISalidaCombustibleRepositorio
        Function GetById(ByVal SCO_Id As Integer) As SalidaCombustible
        Sub Maintenance(ByVal SalidaCombustible As SalidaCombustible)
        Function ListaSalidaCombustible() As String
    End Interface

End Namespace

