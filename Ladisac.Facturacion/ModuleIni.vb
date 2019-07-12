Imports Microsoft.Practices.Prism.Modularity
Imports Microsoft.Practices.Unity
Namespace Ladisac.Facturacion
    Public Class ModuleIni
        Implements IModule
        ''
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Sub Initialize() Implements Microsoft.Practices.Prism.Modularity.IModule.Initialize
            RegistrarDA()
            RegistrarBL()
            RegistrarVistas()
            RegistrarComponentes()
        End Sub
        Public Sub RegistrarVistas()
            ' Ladisac
            ContainerService.RegisterType(Of Ladisac.frmBusqueda)()
            ContainerService.RegisterType(Of Ladisac.frmBusquedaDetracciones)()
            ' Maestros
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmDatosUsuarios)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmPuntoVentaDatosUsuarios)()

            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmRolArticulosTipoArticulos)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmRolAlmacenTipoArticulos)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmPesosArticulos)()

            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmTipoUnidad)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmConfiguracionVehicular)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmUnidadesTransporte)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmPlacas)()


            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmTipoDocPersonas)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmTipoPersonas)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmPersonas)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmDocPersonas)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmDireccionesPersonas)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmContactoPersona)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmRolPersonaTipoPersona)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmBloqueosCodigoPersona)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmBloqueoVendedor)()

            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmPais)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmDepartamento)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmProvincia)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmDistrito)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmPuntoVenta)()

            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmMoneda)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmTipoCambioMoneda)()

            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmTipoDocumentos)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmCorrelativoTipoDocumento)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmRolPuntoVentaAlmacen)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmCierre)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmCentroCostos)()
            ContainerService.RegisterType(Of Ladisac.Maestros.Views.frmRolOpeCtaCte)()

            ' Facturación
            ContainerService.RegisterType(Of Ladisac.Facturacion.Views.frmRestriccionArticulo)()

            ContainerService.RegisterType(Of Ladisac.Facturacion.Views.frmComision)()
            ContainerService.RegisterType(Of Ladisac.Facturacion.Views.frmFletesTransportes)()

            ContainerService.RegisterType(Of Ladisac.Facturacion.Views.frmDocumentos)()

            ContainerService.RegisterType(Of Ladisac.Facturacion.Views.frmGenerarDocumentoPromocion)()
            ContainerService.RegisterType(Of frmSolicitudAjustePrecio)()

            'analisis gerencial monulo facturacion 
            ContainerService.RegisterType(Of Ladisac.Facturacion.Views.frmReporteAnalisisVentas)()
            ContainerService.RegisterType(Of Ladisac.Facturacion.Views.frmEstadoDeDocumentosFechasVentas)()

            ' Despachos
            ContainerService.RegisterType(Of Ladisac.Despachos.Views.frmDespachos)()
            ContainerService.RegisterType(Of Ladisac.Despachos.Views.frmDespachosalida)()

            ' Tesorería
            ContainerService.RegisterType(Of Ladisac.Tesoreria.Views.frmCajaCtaCte)()
            ContainerService.RegisterType(Of Ladisac.Tesoreria.Views.frmCheques)()
            ContainerService.RegisterType(Of Ladisac.Tesoreria.Views.frmTesoreriaEditar)()
            ContainerService.RegisterType(Of Ladisac.Tesoreria.Views.frmCajeroAnexo)()

            ContainerService.RegisterType(Of Ladisac.Tesoreria.Views.frmTesoreria)()
            ContainerService.RegisterType(Of Ladisac.Tesoreria.Views.frmTesoreriaExtorno)()
            ContainerService.RegisterType(Of Ladisac.Tesoreria.Views.frmTesoreriaCobranza)()
            ContainerService.RegisterType(Of Ladisac.Tesoreria.Views.frmTesoreriaCobranzaLegal)()
            ContainerService.RegisterType(Of Ladisac.Tesoreria.Views.frmPrestamo)()

            ' Cuentas Corrientes
            ContainerService.RegisterType(Of Ladisac.CuentasCorrientes.Views.frmListaPreciosArticulos)()
            ContainerService.RegisterType(Of Ladisac.CuentasCorrientes.Views.frmDescuentoIncrementoTipoVentaPersonas)()

            ContainerService.RegisterType(Of Ladisac.CuentasCorrientes.Views.frmTipoVenta)()
            ContainerService.RegisterType(Of Ladisac.CuentasCorrientes.Views.frmPermisoCuentaCorriente)()

            ContainerService.RegisterType(Of Ladisac.CuentasCorrientes.Views.frmCartaFianza)()
            ContainerService.RegisterType(Of Ladisac.CuentasCorrientes.Views.frmReporteDepositoTerceros)()
            ContainerService.RegisterType(Of Ladisac.CuentasCorrientes.Views.frmActualizarListaPreciosArticulos)()

            ' Activos fijos
            ContainerService.RegisterType(Of Ladisac.ActivosFijos.Views.frmIncidencias)()
            ContainerService.RegisterType(Of Ladisac.ActivosFijos.Views.frmCuentasActivos)()
            ContainerService.RegisterType(Of Ladisac.ActivosFijos.Views.frmEdificios)()
            ContainerService.RegisterType(Of Ladisac.ActivosFijos.Views.frmOficinas)()
            ContainerService.RegisterType(Of Ladisac.ActivosFijos.Views.frmDepartamentosAdministrativos)()

            'ContainerService.RegisterType(Of Ladisac.Facturacion.Views.frmProvincia)(New ContainerControlledLifetimeManager)
        End Sub
        Public Sub RegistrarDA()
            ContainerService.RegisterType(Of DA.IMaestroRepositorio, DA.MaestroRepositorio)(New ContainerControlledLifetimeManager)
            ContainerService.RegisterType(Of DA.IBusquedaRepositorio, DA.BusquedaRepositorio)()

            ' Maestros
            ContainerService.RegisterType(Of DA.IDatosUsuariosRepositorio, DA.DatosUsuariosRepositorio)()
            ContainerService.RegisterType(Of DA.IPuntoVentaDatosUsuariosRepositorio, DA.PuntoVentaDatosUsuariosRepositorio)()
            ContainerService.RegisterType(Of DA.ISeriesDatosUsuariosRepositorio, DA.SeriesDatosUsuariosRepositorio)()

            ContainerService.RegisterType(Of DA.IRolArticulosTipoArticulosRepositorio, DA.RolArticulosTipoArticulosRepositorio)()
            ContainerService.RegisterType(Of DA.IRolAlmacenTipoArticulosRepositorio, DA.RolAlmacenTipoArticulosRepositorio)()
            ContainerService.RegisterType(Of DA.IPesosArticulosRepositorio, DA.PesosArticulosRepositorio)()

            ContainerService.RegisterType(Of DA.ITipoUnidadRepositorio, DA.TipoUnidadRepositorio)()
            ContainerService.RegisterType(Of DA.IConfiguracionVehicularRepositorio, DA.ConfiguracionVehicularRepositorio)()
            ContainerService.RegisterType(Of DA.IUnidadesTransporteRepositorio, DA.UnidadesTransporteRepositorio)()
            ContainerService.RegisterType(Of DA.IPlacasRepositorio, DA.PlacasRepositorio)()

            ContainerService.RegisterType(Of DA.ITipoPersonasRepositorio, DA.TipoPersonasRepositorio)()
            ContainerService.RegisterType(Of DA.ITipoDocPersonasRepositorio, DA.TipoDocPersonasRepositorio)()
            ContainerService.RegisterType(Of DA.IPersonaRepositorio, DA.PersonaRepositorio)()
            ContainerService.RegisterType(Of DA.IDocPersonasRepositorio, DA.DocPersonasRepositorio)()
            ContainerService.RegisterType(Of DA.IDireccionesPersonasRepositorio, DA.DireccionesPersonasRepositorio)()
            ContainerService.RegisterType(Of DA.IContactoPersonaRepositorio, DA.ContactoPersonaRepositorio)()
            ContainerService.RegisterType(Of DA.IRolPersonaTipoPersonaRepositorio, DA.RolPersonaTipoPersonaRepositorio)()
            ContainerService.RegisterType(Of DA.IBloqueosCodigoPersonaRepositorio, DA.BloqueosCodigoPersonaRepositorio)()
            ContainerService.RegisterType(Of DA.IBloqueoVendedorRepositorio, DA.BloqueoVendedorRepositorio)()

            ContainerService.RegisterType(Of DA.IPaisRepositorio, DA.PaisRepositorio)()
            ContainerService.RegisterType(Of DA.IDepartamentoRepositorio, DA.DepartamentoRepositorio)()
            ContainerService.RegisterType(Of DA.IProvinciaRepositorio, DA.ProvinciaRepositorio)()
            ContainerService.RegisterType(Of DA.IDistritoRepositorio, DA.DistritoRepositorio)()
            ContainerService.RegisterType(Of DA.IPuntoVentaRepositorio, DA.PuntoVentaRepositorio)()

            ContainerService.RegisterType(Of DA.IMonedaRepositorio, DA.MonedaRepositorio)()
            ContainerService.RegisterType(Of DA.ITipoCambioMonedaRepositorio, DA.TipoCambioMonedaRepositorio)()

            ContainerService.RegisterType(Of DA.ITipoDocumentoRepositorio, DA.TipoDocumentoRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleTipoDocumentoRepositorio, DA.DetalleTipoDocumentoRepositorio)()
            ContainerService.RegisterType(Of DA.ICorrelativoTipoDocumentoRepositorio, DA.CorrelativoTipoDocumentoRepositorio)()
            ContainerService.RegisterType(Of DA.IRolPuntoVentaAlmacenRepositorio, DA.RolPuntoVentaAlmacenRepositorio)()
            ContainerService.RegisterType(Of DA.ICierreRepositorio, DA.CierreRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleCierreRepositorio, DA.DetalleCierreRepositorio)()
            ContainerService.RegisterType(Of DA.ICentroCostosRepositorio, DA.CentroCostosRepositorio)()

            ContainerService.RegisterType(Of DA.IRolOpeCtaCteRepositorio, DA.RolOpeCtaCteRepositorio)()
            ContainerService.RegisterType(Of DA.ISancionRepositorio, DA.SancionRepositorio)()
            ContainerService.RegisterType(Of DA.ISancionDetalleRepositorio, DA.SancionDetalleRepositorio)()
            ContainerService.RegisterType(Of DA.IFaltaSancionRepositorio, DA.FaltaSancionRepositorio)()

            ' Facturación
            ContainerService.RegisterType(Of DA.IRestriccionArticuloRepositorio, DA.RestriccionArticuloRepositorio)()

            ContainerService.RegisterType(Of DA.IComisionRepositorio, DA.ComisionRepositorio)()
            ContainerService.RegisterType(Of DA.IFletesTransporteRepositorio, DA.FletesTransporteRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleFletesTransporteRepositorio, DA.DetalleFletesTransporteRepositorio)()

            ContainerService.RegisterType(Of DA.IDocumentosRepositorio, DA.DocumentosRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleDocumentosRepositorio, DA.DetalleDocumentosRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleAfectaDocumentosRepositorio, DA.DetalleAfectaDocumentosRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleAfectaProductoDocumentosRepositorio, DA.DetalleAfectaProductoDocumentosRepositorio)()

            ContainerService.RegisterType(Of DA.IDocumentosPromocionRepositorio, DA.DocumentosPromocionRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleDocumentosPromocionRepositorio, DA.DetalleDocumentosPromocionRepositorio)()
            ContainerService.RegisterType(Of DA.ISolicitudAjustePrecioRepositorio, DA.SolicitudAjustePrecioRepositorio)()
            ContainerService.RegisterType(Of DA.ISolicitudAjustePrecioDetalleRepositorio, DA.SolicitudAjustePrecioDetalleRepositorio)()

            ' Despachos
            ContainerService.RegisterType(Of DA.IDespachosRepositorio, DA.DespachosRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleDespachosRepositorio, DA.DetalleDespachosRepositorio)()
            ContainerService.RegisterType(Of DA.IDespachoSalidaRepositorio, DA.DespachoSalidaRepositorio)()
            ContainerService.RegisterType(Of DA.IDespachoSalidaDetalleRepositorio, DA.DespachoSalidaDetalleRepositorio)()
            ContainerService.RegisterType(Of DA.IOrdenDespachoRepositorio, DA.OrdenDespachoRepositorio)()
            ContainerService.RegisterType(Of DA.IOrdenDespachoDetalleRepositorio, DA.OrdenDespachoDetalleRepositorio)()
            ContainerService.RegisterType(Of DA.ISalidaVigilanciaRepositorio, DA.SalidaVigilanciaRepositorio)()

            ' Tesorería
            ContainerService.RegisterType(Of DA.ICajaCtaCteRepositorio, DA.CajaCtaCteRepositorio)()
            ContainerService.RegisterType(Of DA.IChequesRepositorio, DA.ChequesRepositorio)()
            ContainerService.RegisterType(Of DA.ITesoreriaEditarRepositorio, DA.TesoreriaEditarRepositorio)()
            ContainerService.RegisterType(Of DA.ICajeroAnexoRepositorio, DA.CajeroAnexoRepositorio)()

            ContainerService.RegisterType(Of DA.ITesoreriaRepositorio, DA.TesoreriaRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleTesoreriaRepositorio, DA.DetalleTesoreriaRepositorio)()
            ContainerService.RegisterType(Of DA.IMedioPagoTesoreriaRepositorio, DA.MedioPagoTesoreriaRepositorio)()

            ContainerService.RegisterType(Of DA.IPrestamoRepositorio, DA.PrestamoRepositorio)()
            ContainerService.RegisterType(Of DA.IDetallePrestamoRepositorio, DA.DetallePrestamoRepositorio)()

            ContainerService.RegisterType(Of DA.IKardexCtaCteDetraccionesRepositorio, DA.KardexCtaCteDetraccionesRepositorio)()
            ContainerService.RegisterType(Of DA.IKardexCtaCteRepositorio, DA.KardexCtaCteRepositorio)()
            ContainerService.RegisterType(Of DA.IMovimientoCajaBancoRepositorio, DA.MovimientoCajaBancoRepositorio)()

            ContainerService.RegisterType(Of DA.ITesoreriaExtornoRepositorio, DA.TesoreriaExtornoRepositorio)()
            ContainerService.RegisterType(Of DA.ITesoreriaCobranzaRepositorio, DA.TesoreriaCobranzaRepositorio)()
            ContainerService.RegisterType(Of DA.ITesoreriaCobranzaLegalRepositorio, DA.TesoreriaCobranzaLegalRepositorio)()

            ' Cuentas Corrientes
            ContainerService.RegisterType(Of DA.IListaPreciosArticulosRepositorio, DA.ListaPreciosArticulosRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleListaPreciosRepositorio, DA.DetalleListaPreciosRepositorio)()
            ContainerService.RegisterType(Of DA.IDescuentoIncrementoTipoVentaPersonasRepositorio, DA.DescuentoIncrementoTipoVentaPersonasRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleDescuentoIncrementoTipoVentaPersonasRepositorio, DA.DetalleDescuentoIncrementoTipoVentaPersonasRepositorio)()

            ContainerService.RegisterType(Of DA.IPermisoCuentaCorrienteRepositorio, DA.PermisoCuentaCorrienteRepositorio)()
            ContainerService.RegisterType(Of DA.IDetallePermisoCuentaCorrienteRepositorio, DA.DetallePermisoCuentaCorrienteRepositorio)()

            ContainerService.RegisterType(Of DA.ITipoVentaRepositorio, DA.TipoVentaRepositorio)()

            ContainerService.RegisterType(Of DA.ICartaFianzaRepositorio, DA.CartaFianzaRepositorio)()

            ' Activos Fijos
            ContainerService.RegisterType(Of DA.IIncidenciasRepositorio, DA.IncidenciasRepositorio)()
            ContainerService.RegisterType(Of DA.ICuentasActivosRepositorio, DA.CuentasActivosRepositorio)()
            ContainerService.RegisterType(Of DA.IEdificiosRepositorio, DA.EdificiosRepositorio)()
            ContainerService.RegisterType(Of DA.IOficinasRepositorio, DA.OficinasRepositorio)()
            ContainerService.RegisterType(Of DA.IDepartamentosAdministrativosRepositorio, DA.DepartamentosAdministrativosRepositorio)()
        End Sub
        Public Sub RegistrarBL()
            ContainerService.RegisterType(Of Ladisac.BL.IBCMaestro, Ladisac.BL.BCMaestro)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCBusqueda, Ladisac.BL.BCBusqueda)()

            ' Maestros
            ContainerService.RegisterType(Of Ladisac.BL.IBCDatosUsuarios, Ladisac.BL.BCDatosUsuarios)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCPuntoVentaDatosUsuarios, Ladisac.BL.BCPuntoVentaDatosUsuarios)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCSeriesDatosUsuarios, Ladisac.BL.BCSeriesDatosUsuarios)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCRolArticulosTipoArticulos, Ladisac.BL.BCRolArticulosTipoArticulos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCRolAlmacenTipoArticulos, Ladisac.BL.BCRolAlmacenTipoArticulos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCPesosArticulos, Ladisac.BL.BCPesosArticulos)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCTipoUnidad, Ladisac.BL.BCTipoUnidad)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCConfiguracionVehicular, Ladisac.BL.BCConfiguracionVehicular)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCUnidadesTransporte, Ladisac.BL.BCUnidadesTransporte)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCPlacas, Ladisac.BL.BCPlacas)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCTipoPersonas, Ladisac.BL.BCTipoPersonas)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCTipoDocPersonas, Ladisac.BL.BCTipoDocPersonas)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCPersona, Ladisac.BL.BCPersona)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDocPersonas, Ladisac.BL.BCDocPersonas)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDireccionesPersonas, Ladisac.BL.BCDireccionesPersonas)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCContactoPersona, Ladisac.BL.BCContactoPersona)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCRolPersonaTipoPersona, Ladisac.BL.BCRolPersonaTipoPersona)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCBloqueosCodigoPersona, Ladisac.BL.BCBloqueosCodigoPersona)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCBloqueoVendedor, Ladisac.BL.BCBloqueoVendedor)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCPais, Ladisac.BL.BCPais)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDepartamento, Ladisac.BL.BCDepartamento)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCProvincia, Ladisac.BL.BCProvincia)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDistrito, Ladisac.BL.BCDistrito)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCPuntoVenta, Ladisac.BL.BCPuntoVenta)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCMoneda, Ladisac.BL.BCMoneda)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCTipoCambioMoneda, Ladisac.BL.BCTipoCambioMoneda)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCTipoDocumento, Ladisac.BL.BCTipoDocumento)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetalleTipoDocumento, Ladisac.BL.BCDetalleTipoDocumento)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCCorrelativoTipoDocumento, Ladisac.BL.BCCorrelativoTipoDocumento)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCRolPuntoVentaAlmacen, Ladisac.BL.BCRolPuntoVentaAlmacen)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCCierre, Ladisac.BL.BCCierre)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetalleCierre, Ladisac.BL.BCDetalleCierre)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCCentroCostos, Ladisac.BL.BCCentroCostos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCRolOpeCtaCte, Ladisac.BL.BCRolOpeCtaCte)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCSancion, Ladisac.BL.BCSancion)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCFaltaSancion, Ladisac.BL.BCFaltaSancion)()


            ' Facturación
            ContainerService.RegisterType(Of Ladisac.BL.IBCRestriccionArticulo, Ladisac.BL.BCRestriccionArticulo)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCComision, Ladisac.BL.BCComision)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCFletesTransporte, Ladisac.BL.BCFletesTransporte)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetalleFletesTransporte, Ladisac.BL.BCDetalleFletesTransporte)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCDocumentos, Ladisac.BL.BCDocumentos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetalleDocumentos, Ladisac.BL.BCDetalleDocumentos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetalleAfectaDocumentos, Ladisac.BL.BCDetalleAfectaDocumentos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetalleAfectaProductoDocumentos, Ladisac.BL.BCDetalleAfectaProductoDocumentos)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCDocumentosPromocion, Ladisac.BL.BCDocumentosPromocion)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetalleDocumentosPromocion, Ladisac.BL.BCDetalleDocumentosPromocion)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCSolicitudAjustePrecio, Ladisac.BL.BCSolicitudAjustePrecio)()

            ' Despachos
            ContainerService.RegisterType(Of Ladisac.BL.IBCDespachos, Ladisac.BL.BCDespachos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetalleDespachos, Ladisac.BL.BCDetalleDespachos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDespachoSalida, Ladisac.BL.BCDespachoSalida)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCOrdenDespacho, Ladisac.BL.BCOrdenDespacho)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCSalidaVigilancia, Ladisac.BL.BCSalidaVigilancia)()

            ' Tesorería
            ContainerService.RegisterType(Of Ladisac.BL.IBCCajaCtaCte, Ladisac.BL.BCCajaCtaCte)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCCheques, Ladisac.BL.BCCheques)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCTesoreriaEditar, Ladisac.BL.BCTesoreriaEditar)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCCajeroAnexo, Ladisac.BL.BCCajeroAnexo)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCTesoreria, Ladisac.BL.BCTesoreria)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetalleTesoreria, Ladisac.BL.BCDetalleTesoreria)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCMedioPagoTesoreria, Ladisac.BL.BCMedioPagoTesoreria)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCPrestamo, Ladisac.BL.BCPrestamo)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetallePrestamo, Ladisac.BL.BCDetallePrestamo)()


            ContainerService.RegisterType(Of Ladisac.BL.IBCKardexCtaCteDetracciones, Ladisac.BL.BCKardexCtaCteDetracciones)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCKardexCtaCte, Ladisac.BL.BCKardexCtaCte)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCMovimientoCajaBanco, Ladisac.BL.BCMovimientoCajaBanco)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCTesoreriaExtorno, Ladisac.BL.BCTesoreriaExtorno)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCTesoreriaCobranza, Ladisac.BL.BCTesoreriaCobranza)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCTesoreriaCobranzaLegal, Ladisac.BL.BCTesoreriaCobranzaLegal)()

            ' Cuentas Corrientes
            ContainerService.RegisterType(Of Ladisac.BL.IBCListaPreciosArticulos, Ladisac.BL.BCListaPreciosArticulos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetalleListaPrecios, Ladisac.BL.BCDetalleListaPrecios)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDescuentoIncrementoTipoVentaPersonas, Ladisac.BL.BCDescuentoIncrementoTipoVentaPersonas)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetalleDescuentoIncrementoTipoVentaPersonas, Ladisac.BL.BCDetalleDescuentoIncrementoTipoVentaPersonas)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCPermisoCuentaCorriente, Ladisac.BL.BCPermisoCuentaCorriente)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetallePermisoCuentaCorriente, Ladisac.BL.BCDetallePermisoCuentaCorriente)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCTipoVenta, Ladisac.BL.BCTipoVenta)()

            ContainerService.RegisterType(Of Ladisac.BL.IBCCartaFianza, Ladisac.BL.BCCartaFianza)()

            ' Activos Fijos
            ContainerService.RegisterType(Of Ladisac.BL.IBCIncidencias, Ladisac.BL.BCIncidencias)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCCuentasActivos, Ladisac.BL.BCCuentasActivos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCEdificios, Ladisac.BL.BCEdificios)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCOficinas, Ladisac.BL.BCOficinas)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDepartamentosAdministrativos, Ladisac.BL.BCDepartamentosAdministrativos)()
        End Sub

        Private Sub RegistrarComponentes()
            ContainerService.RegisterType(Of Ladisac.Facturacion.ModuleController) _
                (New Microsoft.Practices.Unity.ContainerControlledLifetimeManager)
            Dim controller = ContainerService.Resolve(Of Ladisac.Facturacion.ModuleController)()
            controller.run()
        End Sub
    End Class
End Namespace
