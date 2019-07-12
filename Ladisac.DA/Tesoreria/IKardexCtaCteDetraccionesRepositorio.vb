Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IKardexCtaCteDetraccionesRepositorio
        Function spActualizarEstadoRegistroDetracciones(ByVal cCCT_ID_REF As String, _
            ByVal cTDO_ID_REF As String, _
            ByVal cDTD_ID_REF As String, _
            ByVal cDOC_SERIE_REF As String, _
            ByVal cDOC_NUMERO_REF As String, _
            ByVal cESTADO As Boolean) As Short
    End Interface
End Namespace
