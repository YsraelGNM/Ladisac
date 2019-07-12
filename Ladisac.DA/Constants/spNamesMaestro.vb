Namespace Ladisac.DA
    '
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class SpNames
        Public Shared ReadOnly spEditarCampo As String = "dbo.spEditarCampo"
        Public Shared ReadOnly spCodigoPersonaPermisoUsuario As String = "dbo.spCodigoPersonaPermisoUsuario"

        Public Shared ReadOnly spCorrelativoSerie As String = "dbo.spCorrelativoSerie"

        Public Shared ReadOnly spListarDatosUsuariosUSU_IDXML As String = "dbo.spListarDatosUsuariosUSU_IDXML"
        Public Shared ReadOnly spListarPuntoVentaDatosUsuariosPVE_IDXML As String = "dbo.spListarPuntoVentaDatosUsuariosPVE_IDXML"

        Public Shared ReadOnly spListarPuntoVentaPVE_IDXML As String = "dbo.spListarPuntoVentaPVE_IDXML"

        Public Shared ReadOnly spVistaMonedaXML As String = "dbo.spVistaMonedaXML"
        Public Shared ReadOnly spVistaPaisXML As String = "dbo.spVistaPaisXML"
        Public Shared ReadOnly spVistaDepartamentoXML As String = "dbo.spVistaDepartamentoXML"
        Public Shared ReadOnly spVistaProvinciaXML As String = "dbo.spVistaProvinciaXML"
        Public Shared ReadOnly spVistaDistritoXML As String = "dbo.spVistaDistritoXML"
        Public Shared ReadOnly spVistaListaPreciosArticulosXML As String = "dbo.spVistaListaPreciosArticulosXML"
        Public Shared ReadOnly spVistaDetalleListaPreciosXML As String = "dbo.spVistaDetalleListaPreciosXML"
        'lista de centros de costo
        Public Shared ReadOnly spCentroCostoXML As String = "dbo.spCentroCostoXML"
        ' lista articulos por (id, codigo, nombre)
        Public Shared ReadOnly SPArticulosSelectXML As String = "pla.SPArticulosSelectXML"

        ' Código de dirección de persona  (PER_ID, DIR_TIPO)
        Public Shared ReadOnly spObligadoOrdenCompra As String = "dbo.spObligadoOrdenCompra"
        Public Shared ReadOnly spCodigoDireccionPersona As String = "dbo.spCodigoDireccionPersona"
        Public Shared ReadOnly spNuevoCodigoDireccionPersona As String = "dbo.spNuevoCodigoDireccionPersona"
        Public Shared ReadOnly SPPeriodosSelectXML As String = "Mae.SPPeriodosSelectXML"

        Public Shared ReadOnly spCodigoVentaContado As String = "dbo.spCodigoVentaContado"
        Public Shared ReadOnly spCambioDia As String = "dbo.spCambioDia"
        Public Shared ReadOnly spCambioDiaXML As String = "dbo.spCambioDiaXML"
        Public Shared ReadOnly spFechaServidor As String = "dbo.spFechaServidor"
        Public Shared ReadOnly spVistaTotalDocumentoXML As String = "dbo.spVistaTotalDocumentoXML"

        Public Shared ReadOnly spSaldosContadoClienteXML As String = "dbo.spSaldosClienteContadoXML"
        Public Shared ReadOnly spSaldosContraentregaCredito123ClienteXML As String = "dbo.spSaldosClienteContraentregaCredito123XML"
        Public Shared ReadOnly spSaldosClienteXML As String = "dbo.spSaldosClienteXML"
        Public Shared ReadOnly spSaldoskardexDocumentosXML As String = "dbo.spSaldoskardexDocumentosXML"
        Public Shared ReadOnly spVistaSaldosDTDXML As String = "dbo.spVistaSaldosDTDXML"

        Public Shared ReadOnly spActualizarPersonasDIR_ID As String = "dbo.spActualizarPersonasDIR_ID"
        Public Shared ReadOnly spActualizarPersonasPER_LINEA_CREDITO As String = "dbo.spActualizarPersonasPER_LINEA_CREDITO"
        Public Shared ReadOnly spEliminarPersonas As String = "dbo.spEliminarPersonas"
        Public Shared ReadOnly spTelefonoPersona As String = "dbo.spTelefonoPersona"
        Public Shared ReadOnly spEMailPersona As String = "dbo.spEMailPersona"
        Public Shared ReadOnly spDireccionPuntoVenta As String = "dbo.spDireccionPuntoVenta"

        Public Shared ReadOnly spDescripcionCortaTipoDocumento As String = "dbo.spDescripcionCortaTipoDocumento"

        Public Shared ReadOnly spTotalPrestamoPersonal As String = "dbo.spTotalPrestamoPersonal"
        Public Shared ReadOnly spTotalPrestamoPersonalCliente As String = "dbo.spTotalPrestamoPersonalCliente"
        Public Shared ReadOnly spEliminarDocPersonasPER_ID As String = "dbo.spEliminarDocPersonasPER_ID"
        Public Shared ReadOnly spEliminarRolPersonaTipoPersonaPER_ID As String = "dbo.spEliminarRolPersonaTipoPersonaPER_ID"
        Public Shared ReadOnly spLineaCreditoPersona As String = "dbo.spLineaCreditoPersonaNuevo"
        Public Shared ReadOnly spLineaCreditoPersonaEstado As String = "dbo.spLineaCreditoPersonaEstado"
        Public Shared ReadOnly spDiasCreditoPersona As String = "dbo.spDiasCreditoPersona"
        Public Shared ReadOnly spCodigoPersonaEnPlanilla As String = "dbo.spCodigoPersonaEnPlanilla"
        Public Shared ReadOnly spEsPersonaAgentePercepcionXML As String = "dbo.spEsPersonaAgentePercepcionXML"
        Public Shared ReadOnly spEsPersonaAgenteRetencionXML As String = "dbo.spEsPersonaAgenteRetencionXML"
        Public Shared ReadOnly spFormaVentaPersona As String = "dbo.spFormaVentaPersona"
        Public Shared ReadOnly spPromocionPersonaXML As String = "spPromocionPersonaXML"

        Public Shared ReadOnly spSignoCuentaContable As String = "dbo.spSignoCuentaContable"

        Public Shared ReadOnly spActualizarRegistroDireccionesPersonas As String = "dbo.spActualizarDireccionesPersonas"
        Public Shared ReadOnly spInsertarRegistroDireccionesPersonas As String = "dbo.spInsertarDireccionesPersonas"
        Public Shared ReadOnly spEliminarRegistroDireccionesPersonas As String = "dbo.spEliminarDireccionesPersonas"
        Public Shared ReadOnly spEliminarRegistroDireccionesPersonasNuevo As String = "dbo.spEliminarDireccionesPersonasNuevo"
        Public Shared ReadOnly spEliminarDireccionesPersonasPER_ID As String = "dbo.spEliminarDireccionesPersonasPER_ID"

        Public Shared ReadOnly spVerificarExisteRolPersonaTipoPersonaXML As String = "spVerificarExisteRolPersonaTipoPersonaXML"

        Public Shared ReadOnly spFormaVentaTipoVenta As String = "dbo.spFormaVentaTipoVenta"

        Public Shared ReadOnly spCargoAbonoRolOpeCtaCte As String = "dbo.spCargoAbonoRolOpeCtaCte"
        Public Shared ReadOnly spSignoCargoAbonoRolOpeCtaCte As String = "dbo.spSignoCargoAbonoRolOpeCtaCte"
        Public Shared ReadOnly spSigno_DCargoAbonoRolOpeCtaCte As String = "dbo.spSigno_DCargoAbonoRolOpeCtaCte"
        Public Shared ReadOnly spSigno_D_1CargoAbonoRolOpeCtaCte As String = "dbo.spSigno_D_1CargoAbonoRolOpeCtaCte"
        Public Shared ReadOnly spMovimientoCargoAbonoRolOpeCtaCte As String = "dbo.spMovimientoCargoAbonoRolOpeCtaCte"

        Public Shared ReadOnly spDescuentoIncrementoMONTO_TIV As String = "spVistaDetalleDescuentoIncrementoTipoVentaPersonasMONTO_TIVXML"
        Public Shared ReadOnly spArticuloAnticipo As String = "spVistaDetalleListaPreciosXML"

        Public Shared ReadOnly spComportamientoCierreXML As String = "spComportamientoCierreXML"

        Public Shared ReadOnly spPesoMaximoPesosArticulosXML As String = "spPesoMaximoPesosArticulosXML"
        Public Shared ReadOnly spUnidadMedidaArticulosXML As String = "spUnidadMedidaArticulosXML"

        Public Shared ReadOnly spNuevoPla_IdPlacasXML As String = "spNuevoPla_IdPlacasXML"
        Public Shared ReadOnly spNuevoLpr_IdListaPreciosArticulosXML As String = "spNuevoLpr_IdListaPreciosArticulosXML"

        Public Shared ReadOnly spListarIdPermisoUsuarioXML As String = "spListarIdPermisoUsuarioXML"

        Public Shared ReadOnly spRoc_TipoRolOpeCtaCteXML As String = "dbo.spRoc_TipoRolOpeCtaCteXML"

        Public Shared ReadOnly spActualizarRegistroCorrelativoTipoDocumento As String = "dbo.spActualizarCorrelativoTipoDocumento"
        Public Shared ReadOnly spInsertarRegistroCorrelativoTipoDocumento As String = "dbo.spInsertarCorrelativoTipoDocumento"
        Public Shared ReadOnly spEliminarRegistroCorrelativoTipoDocumento As String = "dbo.spEliminarCorrelativoTipoDocumento"

        Public Shared ReadOnly spActualizarRegistroUnidadesTransporte As String = "dbo.spActualizarUnidadesTransporte"
        Public Shared ReadOnly spInsertarRegistroUnidadesTransporte As String = "dbo.spInsertarUnidadesTransporte"
        Public Shared ReadOnly spEliminarRegistroUnidadesTransporte As String = "dbo.spEliminarUnidadesTransporte"

        Public Shared ReadOnly spActualizarRegistroPlacas As String = "dbo.spActualizarPlacas"
        Public Shared ReadOnly spInsertarRegistroPlacas As String = "dbo.spInsertarPlacas"
        Public Shared ReadOnly spEliminarRegistroPlacas As String = "dbo.spEliminarPlacas"

        Public Shared ReadOnly spActualizarRegistroPersonas As String = "dbo.spActualizarPersonas"
        Public Shared ReadOnly spInsertarRegistroPersonas As String = "dbo.spInsertarPersonas"
        Public Shared ReadOnly spEliminarRegistroPersonas As String = "dbo.spEliminarPersonas"
        Public Shared ReadOnly spModificarNombreEnPersona As String = "dbo.spModificarNombreEnPersona"
        Public Shared ReadOnly spModificarEstadoEnPersona As String = "dbo.spModificarEstadoEnPersona"

        Public Shared ReadOnly spModificarFormaVentaEnPersona As String = "dbo.spModificarFormaVentaEnPersona"
        Public Shared ReadOnly spModificarEsBancoEnPersona As String = "dbo.spModificarEsBancoEnPersona"
        Public Shared ReadOnly spModificarFinanzasEnPersona As String = "dbo.spModificarFinanzasEnPersona"
        Public Shared ReadOnly spModificarObservacionesEnPersona As String = "dbo.spModificarObservacionesEnPersona"
        Public Shared ReadOnly spModificarContactoEnPersona As String = "dbo.spModificarContactoEnPersona"

        Public Shared ReadOnly spActualizarRegistroDocPersonas As String = "dbo.spActualizarDocPersonas"
        Public Shared ReadOnly spInsertarRegistroDocPersonas As String = "dbo.spInsertarDocPersonas"
        Public Shared ReadOnly spEliminarRegistroDocPersonas As String = "dbo.spEliminarDocPersonas"

        Public Shared ReadOnly spActualizarRegistroContactoPersona As String = "dbo.spActualizarContactoPersona"
        Public Shared ReadOnly spInsertarRegistroContactoPersona As String = "dbo.spInsertarContactoPersona"
        Public Shared ReadOnly spEliminarRegistroContactoPersona As String = "dbo.spEliminarContactoPersona"
        Public Shared ReadOnly spEliminarContactoPersonaPER_ID As String = "dbo.spEliminarContactoPersonaPER_ID"

        Public Shared ReadOnly spActualizarRegistroRolPersonaTipoPersona As String = "dbo.spActualizarRolPersonaTipoPersona"
        Public Shared ReadOnly spInsertarRegistroRolPersonaTipoPersona As String = "dbo.spInsertarRolPersonaTipoPersona"
        Public Shared ReadOnly spEliminarRegistroRolPersonaTipoPersona As String = "dbo.spEliminarRolPersonaTipoPersona"
    End Class
End Namespace

