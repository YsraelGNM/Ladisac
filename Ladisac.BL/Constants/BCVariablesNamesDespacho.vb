Namespace Ladisac.BL
    Partial Public Class BCVariablesNames
        Public Structure ProcesosDespacho
            Public Const Guia As String = "005" ' Cabecera
            Public Const GuiaDespacho As String = "011" ' Detalle
            Public Const GuiaIngreso As String = "012" ' Detalle
            Public Const GuiaTransferencia As String = "013" ' Detalle
            Public Const GuiaDevolucion As String = "014" ' Detalle
            Public Const GuiaSalida As String = "096" ' Detalle

            Public Const GuiaPorNotaCredito As String = "089" ' Detalle

            Public Const GuiaSalidaDesdeDistribuidora As String = "207" ' Detalle
            Public Const GuiaDevolucionDesdeDistribuidora As String = "211" ' Detalle

            Public Const CronogramaDespacho As String = "024" ' Cabecera
            Public Const CroDesCronogramaDespacho As String = "021" ' Detalle
        End Structure
        Public Structure TransportistasPropios
            Public Const Exodo As String = "000443"
            Public Const TransportesKala As String = "000455"
            Public Const ComercialAceHome As String = "000664"
            Public Const Extrames As String = "000689"
            Public Const TransportesGeminis As String = "000490"
        End Structure

    End Class
End Namespace
