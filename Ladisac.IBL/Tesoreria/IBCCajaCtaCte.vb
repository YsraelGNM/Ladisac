Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCCajaCtaCte
        Function MantenimientoCajaCtaCte(ByVal Item As CajaCtaCte) As Short
        Function spCajaCtaCteSelectXML(ByVal codigo As String, ByVal descripcion As String) As String
    End Interface
End Namespace
