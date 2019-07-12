Namespace Ladisac.BL
    Public Interface IBCTiposConceptosQueries
        Function TiposDocumentosQuery(Optional ByVal codigo As String = Nothing, Optional ByVal des As String = Nothing) As String
        Function TiposDocumentosSeek(ByVal id As String) As BE.TiposConceptos
    End Interface


End Namespace


'Namespace Ladisac.BL
'    Public Interface IBCMaestroQueries
'        Function MonedasQuery(Optional ByVal monId As String = Nothing) As String
'        Function MonedasSeek(ByVal monId As String) As BE.Moneda
'    End Interface
'End Namespace