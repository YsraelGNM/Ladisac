Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCKardexCtaCteDetracciones
        Function spActualizarEstadoRegistroDetracciones(ByVal cCCT_ID_REF As String, _
            ByVal cTDO_ID_REF As String, _
            ByVal cDTD_ID_REF As String, _
            ByVal cDOC_SERIE_REF As String, _
            ByVal cDOC_NUMERO_REF As String, _
            ByVal cESTADO As Boolean) As Short
        Function spListaDetracciones()
    End Interface
End Namespace
