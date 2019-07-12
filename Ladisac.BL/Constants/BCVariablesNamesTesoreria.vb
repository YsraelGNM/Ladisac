Namespace Ladisac.BL
    Partial Public Class BCVariablesNames
        'Public CtaCte As String = "001"

        'OOOO'

        Public CajeroDefault As String = "000007"
        Public CajeroManejaraCtaBanco As Boolean = True

        Public Structure CerrarCaja
            Public Const IngresoCaja As String = ProcesosCaja.CajaIngreso
            Public Const EgresoCaja As String = ProcesosCaja.CajaEgreso
            Public Const IngresoBanco As String = ProcesosCaja.NotaAbonoCtaBanco
            Public Const EgresoBanco As String = ProcesosCaja.NotaCargoCtaBanco
            Public Const Transferencias As String = ProcesosCaja.TransferenciaEntreCajas
            Public Const Liquidacion As String = ProcesosCtaCte.LiquidacionDocumento
        End Structure
        Public Structure TipoCajaCtaCte
            Public Const Caja As String = "CAJA"
            Public Const CtaBanco As String = "CUENTA DE BANCO"
            Public Const LiquidacionDocumento As String = "LIQUIDACION DE DOCUMENTOS"
            Public Const CtaBancoDetraccion As String = "CUENTA DE BANCO DE DETRACCION"
            Public Const RetencionesPercepciones As String = "RETENCIONES/PERCEPCIONES"
            Public Const RendicionCuentas As String = "RENDICION DE CUENTAS"
        End Structure

        Public Structure ProcesosCtaCte
            Public Const LiquidacionDocumento As String = "020"
            Public Const LiqDocLiquidacionDocumento As String = "028"

            Public Const PlanillaRendicionCuentas As String = "049"
            Public Const EntRenCuePlanillaRendicionCuentas As String = "160"

            Public Const ReembolsoPlaRenCtas As String = "129"
            Public Const SinDocumentoPlaRenCtas As String = "193"
        End Structure
        Public Structure ModulosCaja
            Public Const ReciboIngresoEgreso As String = "RECIBO"
            Public Const PlanillaIngresoEgreso As String = "PLANILLA"
            Public Const DepositoDeTerceros As String = "DEPOSITOTERCERO"
            Public Const VoucherDeCheque As String = "VOUCHER"
            Public Const PlanillaRendicionCuenta As String = "RENDICIONCUENTA"
            Public Const TransferenciaEntreCajaBanco As String = "TRANSFERENCIA"
        End Structure
        Public Structure ProcesosCaja
            Public Const PrestamoPersonal As String = "035"
            Public Const PrestamoPersonalEntregaRendir As String = "288"

            Public Const CajaIngreso As String = "010"
            Public Const ReciboIngresoCajaIngreso As String = "019"
            Public Const AnticipoRecibidoCajaIngreso As String = "097"

            Public Const CajaEgreso As String = "016"
            Public Const ReciboEgresoCajaEgreso As String = "020"
            Public Const EntregaRendirCuentaReciboEgreso As String = "158"

            Public Const PlanillaEgreso As String = "054"
            Public Const PlaEgrPlanillaEgreso As String = "084"
            Public Const EntregaRendirCuentaPlanillaEgreso As String = "178"

            Public Const AnticipoOtorgado As String = "151"

            Public Const DepositoTercero As String = "055"
            Public Const DepTerDepositoTercero As String = "022"
            Public Const AnticipoRecibidoDepositoTercero As String = "145"

            Public Const NotaAbonoCtaBanco As String = "011"
            Public Const NABNotaAbonoCtaBanco As String = "085"
            Public Const AnticipoRecibidoNotaAbonoCtaBanco As String = "153"

            Public Const NotaCargoCtaBanco As String = "017"
            'Public Const RetiroCuentaBanco As String = "021"
            Public Const NCBNotaCargoCtaBanco As String = "086"
            Public Const ChequeDevueltoNotaCargoCtaBanco As String = "103"
            Public Const AnticipoOtorgadoNotaCargoCtaBanco As String = "142"

            Public Const DetraccionesNotaCargoCtaBanco As String = "059"
            Public Const NCBDetraccionesNotaCargoCtaBanco As String = "208"

            Public Const VoucherCheque As String = "056"
            Public Const VCVoucherCheque As String = "143"
            Public Const AnticipoOtorgadoVoucherCheque As String = "163"

            'Public Const CajaPlanillaEgresos As String = "021"
            'Public Const PlanillaEgresos As String = "030"

            Public Const TransferenciaEntreCajas As String = "018"
            Public Const TECBTransferenciaEntreCajas As String = "186"
            Public Const TECBDepositosBancarios As String = "035"



            'Public Const NotaAbonoCuentaBanco As String = "026"
            'Public Const NotaCargoCuentaBanco As String = "027"

            'Public Const TransferenciaEntreBancos As String = "019"
            'Public Const TransfEntreBancos As String = "036"
        End Structure
        Public Structure CCC_ID
            'Public Const CajaPrincipal As String = "001" ' CAJA PRINCIPAL SOLES
            Public Const CajaDefaul = "001"
            Public Const CuentaBancoDefault = "201"
            Public Const LiqDocumentoDefault = "000"
            Public Const LiqDocumentoDefaultDolares = "246"
            Public Const PlaRenCtasDefault = "100"
        End Structure
        Public Structure CCT_ID
            Public Const SinCtaCte As String = "000" ' SIN CUENTA CORRIENTE
            Public Const CxCComerciales As String = "001" ' CUENTAS X COBRAR COMERCIALES (CLIENTES)
            Public Const EaRendirCuentas As String = "009" ' ENTREGAS A RENDIR CUENTA
            Public Const ReembolsoPlanillaRendicionCuentas As String = "025" ' REEMBOLSO - PLANILLA DE RENDICION CTA
            Public Const CxPComerciales As String = "012" ' CUENTAS X PAGAR COMERCIALES (PROVEEDORES)
            Public Const TransferenciaEntreCajaCtaCteBanco As String = "020" 'TRANSFERENCIAS ENTRE CAJAS, CTA. CTE. BANCOS
            Public Const Preventas As String = "022" ' PREVENTAS
            Public Const PrestamosPersonal As String = "002" ' PRÉSTAMOS A PERSONAL
            Public Const Remuneraciones As String = "010" ' REMUNERACIONES
        End Structure
        Public Structure Movimiento
            Public Const Movimiento0 As String = "NINGUNO"
            Public Const Movimiento1 As String = "ANTICIPO RECIBIDO"
            Public Const Movimiento2 As String = "LIQUIDACION DE DOCUMENTOS"
            Public Const Movimiento3 As String = "PLANILLA DE RENDICION DE CUENTAS"
            Public Const Movimiento4 As String = "SOLO RETIRO - DEPOSITO"
            Public Const Movimiento5 As String = "PRESTAMO POR COBRAR"
            Public Const Movimiento6 As String = "NINGUNO CON CARGO A DOCUMENTO"
            Public Const Movimiento7 As String = "VENTA POR DESPACHAR"
        End Structure
        Public Structure Destino
            Public Const Destino0 As String = "NINGUNO"
            Public Const Destino1 As String = "A TERCERA PERSONA"
            Public Const Destino2 As String = "A CAJA"
            Public Const Destino3 As String = "A CUENTA CORRIENTE DE BANCO"
        End Structure
        Public Structure MedioPago
            Public Const MedioPago0 As String = "EFECTIVO"
            Public Const MedioPago1 As String = "CHEQUE"
            Public Const MedioPago2 As String = "TARJETA DE CREDITO"
            Public Const MedioPago3 As String = "DEPOSITO BANCARIO"
            Public Const MedioPago4 As String = "DOCUMENTO"
            Public Const MedioPago5 As String = "TRANSFERENCIA BANCARIA"
            Public Const MedioPago6 As String = "RETENCION DE IGV"
        End Structure
        Public Structure Diferido
            Public Const Diferido0 As String = "NO"
            Public Const Diferido1 As String = "SI"
        End Structure
        Public Structure Ubicacion
            Public Const Ubicacion0 As String = "NINGUNO"
            Public Const Ubicacion1 As String = "EN CAJA"
            Public Const Ubicacion2 As String = "EN CUENTA DE BANCO"
        End Structure
        Public Structure UbicacionCodigo
            Public Const Ubicacion0 As String = "0"
            Public Const Ubicacion1 As String = "1"
            Public Const Ubicacion2 As String = "2"
        End Structure

        Public Structure Recepcion
            Public Const Recepcion0 As String = "NINGUNO"
            Public Const Recepcion1 As String = "NO RECEPCIONADO"
            Public Const Recepcion2 As String = "RECEPCIONADO"
        End Structure
        Public Structure OperacionContable
            Public Const OperacionContable0 As String = "NINGUNO"
            Public Const OperacionContable1 As String = "PAGO DETRACCION"
        End Structure
    End Class
End Namespace

