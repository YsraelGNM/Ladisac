Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IDetalleFletesTransporteRepositorio
        Function Maintenance(ByVal item As DetalleFletesTransporte) As Short
        Function DeleteRegistro(ByVal item As DetalleFletesTransporte, ByVal cFLE_ID As String, ByVal cFDE_ID As String, ByVal cDIS_ID As String) As Short
    End Interface
End Namespace
