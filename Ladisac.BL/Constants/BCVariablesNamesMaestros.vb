Namespace Ladisac.BL
    Partial Public Class BCVariablesNames
        'Public Structure DatosUsuario
        'Public Const PrevisualizarBvFv As Boolean = False
        'Public Const ModificarFechaProcesoBvFv As Boolean = False
        'End Structure

        Public Const PlacaElMismoLadrillera As String = "AO1"
        Public Const PlacaElMismoComercializadora As String = "AKX"

        Public Const CodigoPersonaElMismo = "005835"
        Public Const CodigoAlmacenPrincipal = "2"

        Public Structure AgenteCliente
            Public Const AgenteRetencion0 = "NINGUNO"
            Public Const AgenteRetencion1 = "AGENTE DE RETENCION"
        End Structure

        Public Structure AgenteProveedor
            Public Const AgentePercepcion0 = "NINGUNO"
            Public Const AgentePercepcion1 = "AGENTE DE PERCEPCION"
        End Structure

        Public Structure TipoContacto
            Public Const TipoContacto0 As String = "OTROS"
            Public Const TipoContacto1 As String = "INGENIERO"
            Public Const TipoContacto2 As String = "ARQUITECTO"
            Public Const TipoContacto3 As String = "MAESTRO DE OBRA"
            Public Const TipoContacto4 As String = "JEFE DE COMPRAS"
        End Structure
        Public Structure TipoArticulo
            Public Const ProductoTerminado As String = "001"
            Public Const ProductoAnticipo As String = "005"
        End Structure
        Public Structure TipoPersonas
            Public Const Vendedor As String = "001"
            Public Const Cobrador As String = "002"
            Public Const Transportista As String = "006"
            Public Const Banco As String = "008"
            Public Const PersonaNatural As String = "010"
            Public Const PersonaJuridica As String = "011"
            Public Const Grupo As String = "%"
            Public Const PersonaQueRecepciona As String = "%"
        End Structure

        Public Structure TipoUnidadTransporte
            Public Const TipoUnidadTransporte0 As String = "TRACTO"
            Public Const TipoUnidadTransporte1 As String = "SEMIREMOLQUE"
            Public Const TipoUnidadTransporte2 As String = "CAMION"
            Public Const TipoUnidadTransporte3 As String = "REMOLQUE"
            Public Const TipoUnidadTransporte4 As String = "AUTOBUS"
            Public Const TipoUnidadTransporte5 As String = "CAMIONETA"
            Public Const TipoUnidadTransporte6 As String = "VEHICULO"
            Public Const TipoUnidadTransporte7 As String = "MONTACARGA"
            Public Const TipoUnidadTransporte8 As String = "TRACTOR"
            Public Const TipoUnidadTransporte9 As String = "MOTO"
            Public Const TipoUnidadTransporte10 As String = "OTRO"
        End Structure

        Public Structure TipoVentaDescripcion
            Public Const Todas As String = "TODAS"
            Public Const Ninguno As String = "NINGUNO"
            Public Const Contado As String = "CONTADO"
            Public Const Contraentrega As String = "CONTRAENTREGA"
            Public Const Credito As String = "CREDITO"
            Public Const ContraentregaEnPlanta As String = "CONTRAENTREGA EN PLANTA"

            Public Const Credito1Dias As String = "CRÉDITO A 1 DÍA"
            Public Const Credito2Dias As String = "CRÉDITO A 2 DÍAS"
            Public Const Credito3Dias As String = "CRÉDITO A 3 DÍAS"
            Public Const Cobrador As String = "COBRADOR"
            Public Const ContadoConDeposito As String = "CONTADO CON DEPOSITO"
        End Structure

        Public Structure TipoVenta
            Public Const Todas As String = "0"
            Public Const Ninguno As String = "1"
            Public Const Contado As String = "2"
            Public Const Contraentrega As String = "3"
            Public Const Credito As String = "4"
        End Structure

        Public Structure PuntoVentaDatosUsuarios
            Public Structure TipoLista
                Public Const Ambos As String = "AMBOS"
                Public Const Segun As String = "SEGUN PUNTO DE VENTA"
            End Structure
            Public Structure Entrega
                Public Const Ambos As String = "AMBOS"
                Public Const Local As String = "EN LOCAL"
                Public Const Obra As String = "EN OBRA"
            End Structure
        End Structure
        Public Structure TipoPuntoVenta
            Public Const Planta As String = "PLANTA"
            Public Const PlantaObra As String = "PLANTA - OBRA"
            Public Const Punto As String = "PUNTO DE VENTA"
            Public Const PuntoObra As String = "PUNTO DE VENTA - OBRA"
        End Structure
        Public Structure IncluyeIgv
            Public Const IncluyeIGV As String = "INCLUYE IGV"
            Public Const NoIncluyeIGV As String = "NO INCLUYE IGV"
            Public Const NoGrabadoIGV As String = "NO GRABADO CON IGV"
        End Structure

        Public Structure EstadoRegistro
            Public Const NoActivo As String = "NO ACTIVO"
            Public Const Activo As String = "ACTIVO"
            Public Const PorProcesar As String = "POR PROCESAR"
            Public Const Procesado As String = "PROCESADO"
        End Structure

        'Public Structure DatosImprimirDocumento
        'Public Const NuevaDireccion As String = "NUEVA DIRECCION VARIANTE DE UCHUMAYO KM. 04, CERRO COLORADO - AREQUIPA"
        'Public Const NoDevoluciones As String = "NO SE ACEPTAN CAMBIOS NI DEVOLUCIONES"
        'End Structure

        Public Structure ProcesosCompras
            Public Const PrestamoPersonal As String = "035"
            Public Const PrePersonal As String = "054"
        End Structure

        Public Structure ComportamientoCierre
            Public Const Abierto As String = "ABIERTO"
            Public Const Cerrado As String = "CERRADO"
            Public Const Atender As String = "ATENDER"
        End Structure
    End Class
End Namespace
