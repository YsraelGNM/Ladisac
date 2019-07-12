Imports Ladisac.BE
Namespace Ladisac.BL
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IBCBusqueda
        Function CrearCodigoSimpleXML(ByVal CampoPrincipal As String, ByVal NombreLargo As String) As String
        Function CrearCodigoSimple(ByVal CampoPrincipal As String, ByVal NombreLargo As String) As String
        Function CrearCodigoCompuesto(ByVal CampoPk As String, ByVal NombreLargoTabla As String, ByVal Filtro As String) As String

        Function PrimerRegistro(ByVal CampoPrincipal As String, ByVal NombreLargo As String, Optional ByVal CampoFiltro As String = "") As String
        Function RegistroAnterior(ByVal CampoPrincipal As String, ByVal CampoPrincipalValor As String, ByVal NombreLargo As String, Optional ByVal CampoFiltro As String = "") As String
        Function RegistroSiguiente(ByVal CampoPrincipal As String, ByVal CampoPrincipalValor As String, ByVal NombreLargo As String, Optional ByVal CampoFiltro As String = "") As String
        Function UltimoRegistro(ByVal CampoPrincipal As String, ByVal NombreLargo As String, Optional ByVal CampoFiltro As String = "") As String


        Function PrimerRegistroCompuesto(ByVal CampoPrincipal As String, _
                                         ByVal CampoPrincipalSecundario As String, _
                                         ByVal NombreLargo As String) As String
        Function RegistroAnteriorCompuesto(ByVal CampoPrincipal As String, ByVal CampoPrincipalValor As String, _
                                           ByVal CampoPrincipalSecundario As String, ByVal CampoPrincipalSecundarioValor As String, _
                                           ByVal NombreLargo As String) As String
        Function RegistroSiguienteCompuesto(ByVal CampoPrincipal As String, ByVal CampoPrincipalValor As String, _
                                            ByVal CampoPrincipalSecundario As String, ByVal CampoPrincipalSecundarioValor As String, _
                                            ByVal NombreLargo As String) As String
        Function UltimoRegistroCompuesto(ByVal CampoPrincipal As String, _
                                         ByVal CampoPrincipalSecundario As String, _
                                         ByVal NombreLargo As String) As String


        Function PrimerRegistroCompuesto3(ByVal CampoPrincipal As String, _
                                          ByVal CampoPrincipalSecundario As String, _
                                          ByVal CampoPrincipalTercero As String, _
                                          ByVal NombreLargo As String) As String
        Function RegistroAnteriorCompuesto3(ByVal CampoPrincipal As String, ByVal CampoPrincipalValor As String, _
                                            ByVal CampoPrincipalSecundario As String, ByVal CampoPrincipalSecundarioValor As String, _
                                            ByVal CampoPrincipalTercero As String, ByVal CampoPrincipalTerceroValor As String, _
                                            ByVal NombreLargo As String) As String
        Function RegistroSiguienteCompuesto3(ByVal CampoPrincipal As String, ByVal CampoPrincipalValor As String, _
                                             ByVal CampoPrincipalSecundario As String, ByVal CampoPrincipalSecundarioValor As String, _
                                             ByVal CampoPrincipalTercero As String, ByVal CampoPrincipalTerceroValor As String, _
                                             ByVal NombreLargo As String) As String
        Function UltimoRegistroCompuesto3(ByVal CampoPrincipal As String, _
                                          ByVal CampoPrincipalSecundario As String, _
                                          ByVal CampoPrincipalTercero As String, _
                                          ByVal NombreLargo As String) As String


        Function PrimerRegistroFiltro(ByVal CampoPrincipal As String, ByVal NombreLargo As String, ByVal CampoFiltro As String) As String
        Function RegistroAnteriorFiltro(ByVal CampoPrincipal As String, ByVal CampoPrincipalValor As String, ByVal NombreLargo As String, ByVal CampoFiltro As String) As String
        Function RegistroSiguienteFiltro(ByVal CampoPrincipal As String, ByVal CampoPrincipalValor As String, ByVal NombreLargo As String, ByVal CampoFiltro As String) As String
        Function UltimoRegistroFiltro(ByVal CampoPrincipal As String, ByVal NombreLargo As String, ByVal CampoFiltro As String) As String

        Function EditarFechaEmisionDespachos(ByVal USU_ID As String) As Boolean
        Function EditarFechaEmisionTesoreria(ByVal USU_ID As String) As Boolean
        Function NoCajeroEnTesoreria(ByVal USU_ID As String) As Boolean
        Function ReciboEgresoPlanillaTesoreria(ByVal USU_ID As String) As Boolean
        Function ReciboIngresoPlanillaTesoreria(ByVal USU_ID As String) As Boolean

        Function userMensaje(ByVal USU_ID As String) As Boolean
        Function userFactura(ByVal USU_ID As String) As Boolean
        Function EditarFechaEmisionDocumento(ByVal USU_ID As String) As Boolean
        Function ContraEntregaDocumento(ByVal PER_ID As String) As Boolean
        Function LimiteContraEntrega(ByVal PAR_ID As String) As Double

        Function DiasRetraso(ByVal PER_ID As String, ByVal Codigo As String) As Double
        Function DiasRetrasoGeneral(ByVal PER_ID As String) As Double

        Function ModificarNombreEnPersona(ByVal USU_ID As String) As Boolean
        Function ModificarEstadoEnPersona(ByVal USU_ID As String) As Boolean
        Function ModificarFormaVentaEnPersona(ByVal USU_ID As String) As Boolean
        Function ModificarEsBancoEnPersona(ByVal USU_ID As String) As Boolean
        Function ModificarFinanzasEnPersona(ByVal USU_ID As String) As Boolean
        Function ModificarObservacionesEnPersona(ByVal USU_ID As String) As Boolean
        Function ModificarContactoEnPersona(ByVal USU_ID As String) As Boolean

        Function ObligadoOrdenCompra(ByVal PER_ID_CLI As String) As Boolean


        Function TotalPrestamoPersonal(ByVal CCT_ID As String, ByVal PRE_SERIE As String, ByVal PRE_NUMERO As String) As Decimal
        Function TotalPrestamoPersonalCliente(ByVal CCT_ID As String, ByVal PER_ID_CLI As String, ByVal PRE_SERIE As String, ByVal PRE_NUMERO As String) As Decimal
        Function NuevoCodigoDireccionPersona() As String
        Function CodigoDireccionPersona(ByVal PER_ID As String, ByVal DIR_TIPO As Int16) As String
        Function LineaCreditoPersona(ByVal PER_ID As String) As Decimal
        Function LineaCreditoPersonaEstado(ByVal PER_ID As String) As Boolean
        Function DiasCreditoPersona(ByVal PER_ID As String) As Decimal
        Function EsPersonaAgentePercepcion(ByVal PER_ID As String) As String
        Function EsPersonaAgenteRetencion(ByVal PER_ID As String) As String
        Function FormaVentaPersona(ByVal PER_ID As String) As String
        Function PromocionPersona(ByVal PER_ID As String) As String
        Function TelefonoPersona(ByVal PER_ID As String) As String
        Function FechaDocumento(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DOC_SERIE As String, ByVal DOC_NUMERO As String) As String
        Function EMailPersona(ByVal PER_ID As String) As String
        Function DireccionPuntoVenta(ByVal PVE_ID As String) As String
        Function ClienteSoloVentaContado(ByVal PER_ID As String) As Boolean

        Function PedidoDocumento(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DOC_SERIE As String, ByVal DOC_NUMERO As String) As String

        Function SignoCuentaContable(ByVal CUC_ID As String) As Integer

        Function PermisoCronograma(ByVal USU_ID As String) As Int16

        Function DescripcionCortaTipoDocumento(ByVal TDO_ID As String) As String

        Function VerificarExisteRolPersonaTipoPersona(ByVal PER_ID As String, ByVal TPE_ID As String) As String

        Function SaldoFnKardex(ByVal PER_ID As String, ByVal Filtro As String) As Double

        Function FormaVentaTipoVenta(ByVal TIV_ID As String) As String

        Function CorrelativoSerie(ByVal CTD_COR_SERIE As String, ByVal TDO_ID As String) As String

        Function CambioDia(ByVal Campo As String, ByVal Mon_Id_1 As String, ByVal Mon_Id_0 As String, ByVal Tca_Fecha As String) As Double
        Function FechaServidor() As String

        Function EditarCampo(ByVal IdUsuario As String, ByVal NombreFormulario As String, ByVal CampoEditar As String) As Boolean

        Function ComportamientoCierre(ByVal PVE_ID As String, ByVal DTD_ID As String, ByVal Mes As String, ByVal Anio As Int16) As String

        Function PesoArticulo(ByVal ART_ID As String, ByVal Anio As Int16, ByVal Mes As String) As Double
        Function UnidadMedidaArticulo(ByVal ART_ID As String) As String

        Function NuevoPla_IdPlacas() As String
        Function NuevoLpr_IdListaPreciosArticulos() As String

        Function ListarIdPermisoUsuario(ByVal USU_ID As String) As String

        Function ReciboCCO_IDCUC_ID(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cDTE_SERIE As String, ByVal cDTE_NUMERO As String) As Integer

        Function CodigoPersonaEnPlanilla(ByVal PER_ID As String) As String

        Function spInsertarDespachoDistribuidora(ByVal cTDO_ID As String, _
                            ByVal cDTD_ID As String, _
                            ByVal cCCT_ID As String, _
                            ByVal cDES_FEC_EMI As DateTime, _
                            ByVal cDES_FEC_TRA As DateTime, _
                            ByVal cPVE_ID As String, _
                            ByVal cALM_ID As Int16, _
                            ByVal cALM_ID_LLEGADA As Int16, _
                            ByVal cDES_SERIE As String, _
                            ByVal cDES_NUMERO As String, _
                            ByVal cTDO_ID_DOC As String, _
                            ByVal cDTD_ID_DOC As String, _
                            ByVal cDES_SERIE_DOC As String, _
                            ByVal cDES_NUMERO_DOC As String, _
                            ByVal cPER_ID_REC As String, _
                            ByVal cTDP_ID_REC As String, _
                            ByVal cDIR_ID_ENT_REC As String, _
                            ByVal cDIR_ID_ENT As String, _
                            ByVal cPLA_ID As String, _
                            ByVal cFLE_ID As String, _
                            ByVal cMON_ID As String, _
                            ByVal cDES_MONTO_FLETE As Double, _
                            ByVal cDES_CONTRAVALOR As Double, _
                            ByVal cDES_OBSERVACIONES As String, _
                            ByVal cUSU_ID As String, _
                            ByVal cDES_FEC_GRAB As DateTime, _
                            ByVal cDES_ESTADO As Int16, _
                            ByVal cDES_FEC_PRO_CRO As DateTime, _
                            ByVal cDES_FEC_CAR_DES As DateTime, _
                            ByVal cDES_FEC_SAL_PLA As DateTime) As Integer

        Function FormaVentaGuiaLadrillo(ByVal DTD_ID As String, ByVal DES_SERIE As String, ByVal DES_NUMERO As String) As String

    End Interface
End Namespace

