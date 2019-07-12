Imports Microsoft.Practices.Unity

Namespace Ladisac.Foundation.Services
    Public Class SessionService
        Implements ISessionService

        Public Property mUsuario As BE.Usuarios
        Public Property UserName As String Implements ISessionService.UserName
        Public Property UserId As String Implements ISessionService.UserId
        Public Property userMensaje As Boolean Implements ISessionService.userMensaje
        Public Property userFactura As Boolean Implements ISessionService.userFactura
        Public Property UserTipo As String Implements ISessionService.UserTipo
        Public Property PermisoUsuario As String Implements ISessionService.PermisoUsuario

        Public Property TC As Decimal Implements ISessionService.TC
        Public Property IGV As Decimal Implements ISessionService.IGV

        Public Property DiasXSemana As Decimal Implements ISessionService.DiasXSemana
        Public Property HoraXDia As Decimal Implements ISessionService.HoraXDia
        Public Property MinimoHoraParaSerDia As Decimal Implements ISessionService.MinimoHoraParaSerDia

        Public Property UIT As Decimal Implements ISessionService.UIT

        Public Property PuntoVentaPrincipal As String Implements ISessionService.PuntoVentaPrincipal


        Public Property PrevisualizarImpresionEnDocumento As Boolean Implements ISessionService.PrevisualizarImpresionEnDocumento

        Public Property ModificarFechaProcesoEnDocumento As Boolean Implements ISessionService.ModificarFechaProcesoEnDocumento
        Public Property ModificarFechaProcesoEnTesoreria As Boolean Implements ISessionService.ModificarFechaProcesoEnTesoreria
        Public Property NoCajeroEnTesoreria As Boolean Implements ISessionService.NoCajeroEnTesoreria
        Public Property ReciboEgresoPlanilla As Boolean Implements ISessionService.ReciboEgresoPlanilla
        Public Property ReciboIngresoPlanilla As Boolean Implements ISessionService.ReciboIngresoPlanilla


        Public Property NombreEmpresa As String Implements ISessionService.NombreEmpresa
        Public Property RUCEmpresa As String Implements ISessionService.RUCEmpresa
        Public Property DireccionEmpresa As String Implements ISessionService.DireccionEmpresa
        Public Property ConectadoDesde As String Implements ISessionService.ConectadoDesde
        Public Property RutaDocumentoImpresion As String Implements ISessionService.RutaDocumentoImpresion

        Public Property EmpresaEsAgenteRetenedorPercepcion As Boolean Implements ISessionService.EmpresaEsAgenteRetenedorPercepcion
        Public Property PorcentajePercepcionGeneral As Double Implements ISessionService.PorcentajePercepcionGeneral
        Public Property PorcentajePercepcionAgentePercepcion As Double Implements ISessionService.PorcentajePercepcionAgentePercepcion
        Public Property MontoEnDocumentoVentaParaPercepcion As Double Implements ISessionService.MontoEnDocumentoVentaParaPercepcion

        Public Property MontoEnDocumentoVentaParaSolicitarDNI As Double Implements ISessionService.MontoEnDocumentoVentaParaSolicitarDNI

        Public Property GlosaOperacionSujetoPercepcion As String Implements ISessionService.GlosaOperacionSujetoPercepcion
        Public Property GlosaNoAfectoRetenciones As String Implements ISessionService.GlosaNoAfectoRetenciones
        Public Property GlosaNuevaDireccion As String Implements ISessionService.GlosaNuevaDireccion
        Public Property GlosaNoDevoluciones As String Implements ISessionService.GlosaNoDevoluciones

        Public Property PlacaElMismo As String Implements ISessionService.PlacaElMismo
        Public Property Usuario As BE.Usuarios Implements ISessionService.Usuario

        Public Property ModificarNombreEnPersona As Boolean Implements ISessionService.ModificarNombreEnPersona
        Public Property ModificarEstadoEnPersona As Boolean Implements ISessionService.ModificarEstadoEnPersona
        Public Property ModificarEsBancoEnPersona As Boolean Implements ISessionService.ModificarEsBancoEnPersona
        Public Property ModificarFinanzasEnPersona As Boolean Implements ISessionService.ModificarFinanzasEnPersona
        Public Property ModificarFormaVentaEnPersona As Boolean Implements ISessionService.ModificarFormaVentaEnPersona
        Public Property ModificarObservacionesEnPersona As Boolean Implements ISessionService.ModificarObservacionesEnPersona
        Public Property ModificarContactoEnPersona As Boolean Implements ISessionService.ModificarContactoEnPersona

    End Class
End Namespace
