Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISalidaSecaderoDetalleRepositorio
        Function GetById(ByVal DSE_Id As Integer) As SalidaSecaderoDetalle
        Sub Maintenance(ByVal SalidaSecaderoDetalle As SalidaSecaderoDetalle)
        Function ListaSalidaSecaderoDetalle() As String
    End Interface

End Namespace

