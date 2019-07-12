Namespace Ladisac.BL
    Partial Public Class BCVariablesNames

        Public PorcentajeIGV As Decimal = 18.0
        'Public FormaVenta As String = "NINGUNO"

        Public PuntoVentaPrincipal As String = "001"

        Public Const MonedaSistema As String = "001" ' Soles
        Public MonedaExtrangera As String = "002" ' Dolares
        Public TipoVentaContado = "001"
        Public TipoVentaContraEntrega = "002"

        Public VendedorDefault As String = "000001"
        Public CobradorDefault As String = "000009"

        Public Structure PuntosVentaPlanta
            Public Const Principal As String = "002"
        End Structure
        Public Structure PuntosVentaArequipa
            Public Const Apacheta As String = "009"
            Public Const MariscalCastilla As String = "010"
            Public Const CerroColorado As String = "024"
            Public Const ConoNorte As String = "025"
            Public Const Umacollo As String = "027"
        End Structure
        Public Structure PuntosVentaProvincias
            Public Const Camana As String = "003"
            Public Const Moquegua As String = "004"
            Public Const ElPedregal As String = "005"
            Public Const Juliaca As String = "006"
            Public Const Ica As String = "007"
        End Structure


        Public Structure TipoOrdenCompra
            Public Const Ninguno = "NINGUNO"
            Public Const Reposicion = "REPOSICION"
            Public Const DespachoCliente = "DESPACHO CLIENTE"
        End Structure
        Public Structure FormaVenta
            Public Const Todas = "TODAS"
            Public Const Ninguno = "NINGUNO"
            Public Const Contado = "CONTADO"
            Public Const Contraentrega = "CONTRAENTREGA"
            Public Const Credito = "CREDITO"
        End Structure
        Public Structure TipoArticulos
            Public Const TipoProductoTerminado = "001" ' Producto terminado
            Public Const TipoAnticipo = "005" ' Anticipo
        End Structure
        Public Structure TipoDocumentosPersonas
            Public Const TipoDocumentoDNI = "02"
            Public Const TipoDocumentoRUC = "04"
        End Structure

        Public Structure ProcesosFacturación
            Public Const PedidoBoleta As String = "003"
            Public Const PBBoleta As String = "007"
            Public Const OrdCompraBoleta As String = "189"

            Public Const PedidoFactura As String = "004"
            Public Const PFFactura As String = "009"
            Public Const OrdCompraFactura As String = "190"

            'Public Const OrdenCompraBoleta As String = "033"
            'Public Const OrdCompraBoleta As String = "051"

            'Public Const OrdenCompraFactura As String = "032"
            'Public Const OrdCompraFactura As String = "052"

            Public Const TICKETMAQUINAREGISTRADORA As String = "058"
            Public Const TICKETMR As String = "144"

            Public Const VentaBoleta As String = "001"
            Public Const Boleta As String = "001"
            Public Const BoletaAnticipo As String = "002"
            Public Const BoletaPercepcion As String = "188"

            Public Const VentaFactura As String = "002"
            Public Const Factura As String = "004"
            Public Const FacturaAnticipo As String = "005"
            Public Const FacturaPercepcion As String = "187"

            Public Const NotaCredito As String = "008"
            Public Const NCredito As String = "017"

            Public Const NotaDebito As String = "009"
            Public Const NDebito As String = "018"
        End Structure

        Public Const FleteTransporteCliente As String = "TRANSPORTE CLIENTE"
        Public Const ProcesarDescuento As String = "ACEPTA PROMOCIONES"
        Public Const NoProcesarDescuento As String = "NO ACEPTA PROMOCIONES"
        Public Structure TipoDireccionDescripcion
            Public Const TipoDireccionDescripcion0 As String = "DOMICILIO"
            Public Const TipoDireccionDescripcion1 As String = "ENTREGA"
            Public Const TipoDireccionDescripcion2 As String = "COBRANZA"
            Public Const TipoDireccionDescripcion3 As String = "FISCAL"
        End Structure
        Public Function TipoDireccion(ByVal Definicion As String) As Integer
            Select Case Strings.UCase(Definicion)
                Case "DOMICILIO"
                    Return 0
                Case "ENTREGA"
                    Return 1
                Case "COBRANZA"
                    Return 2
                Case "FISCAL"
                    Return 3
                Case Else
                    Return -1
            End Select
        End Function
    End Class
End Namespace
