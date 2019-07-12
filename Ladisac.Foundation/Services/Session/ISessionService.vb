Namespace Ladisac.Foundation.Services
    Public Interface ISessionService
        Property Usuario As Ladisac.BE.Usuarios
        Property UserName As String
        Property UserId As String
        Property userMensaje As Boolean
        Property userFactura As Boolean
        Property UserTipo As String
        Property PermisoUsuario As String
        Property TC As Decimal
        Property IGV As Decimal

        Property NombreEmpresa As String
        Property RUCEmpresa As String
        Property DireccionEmpresa As String
        Property ConectadoDesde As String
        Property RutaDocumentoImpresion As String

        Property MinimoHoraParaSerDia As Decimal
        Property HoraXDia As Decimal
        Property DiasXSemana As Decimal
        Property UIT As Decimal


        Property PuntoVentaPrincipal As String


        Property PrevisualizarImpresionEnDocumento As Boolean

        Property ModificarFechaProcesoEnTesoreria As Boolean
        Property NoCajeroEnTesoreria As Boolean
        Property ModificarFechaProcesoEnDocumento As Boolean
        Property ReciboEgresoPlanilla As Boolean
        Property ReciboIngresoPlanilla As Boolean

        Property ModificarNombreEnPersona As Boolean
        Property ModificarEstadoEnPersona As Boolean
        Property ModificarFormaVentaEnPersona As Boolean
        Property ModificarEsBancoEnPersona As Boolean
        Property ModificarFinanzasEnPersona As Boolean
        Property ModificarObservacionesEnPersona As Boolean
        Property ModificarContactoEnPersona As Boolean


        Property EmpresaEsAgenteRetenedorPercepcion As Boolean
        Property PorcentajePercepcionGeneral As Double
        Property PorcentajePercepcionAgentePercepcion As Double
        Property MontoEnDocumentoVentaParaPercepcion As Double

        Property MontoEnDocumentoVentaParaSolicitarDNI As Double

        Property GlosaOperacionSujetoPercepcion As String
        Property GlosaNoAfectoRetenciones As String
        Property GlosaNuevaDireccion As String
        Property GlosaNoDevoluciones As String

        Property PlacaElMismo As String

    End Interface
End Namespace



