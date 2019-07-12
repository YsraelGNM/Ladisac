Imports Ladisac.BE
Namespace Ladisac.BL
    ''' <summary>
    ''' 
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class BCBusqueda
        Implements IBCBusqueda

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro


        Public Function CrearCodigoSimpleXML(ByVal CampoPrincipal As String, ByVal NombreLargo As String) As String Implements IBCBusqueda.CrearCodigoSimpleXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spCrearCodigoSimple, CampoPrincipal, NombreLargo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function CrearCodigoSimple(ByVal CampoPrincipal As String, ByVal NombreLargo As String) As String Implements IBCBusqueda.CrearCodigoSimple
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spCrearCodigoSimple, CampoPrincipal, NombreLargo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function CrearCodigoCompuesto(ByVal CampoPk As String, ByVal NombreLargoTabla As String, ByVal Filtro As String) As String Implements IBCBusqueda.CrearCodigoCompuesto
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spCrearCodigoCompuesto, CampoPk, NombreLargoTabla, Filtro)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PrimerRegistro(ByVal CampoPrincipal As String, _
                                       ByVal NombreLargo As String, _
                                       Optional ByVal CampoFiltro As String = "") As String Implements IBCBusqueda.PrimerRegistro
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spPrimerRegistro, CampoPrincipal, NombreLargo, CampoFiltro)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function RegistroAnterior(ByVal CampoPrincipal As String, _
                                         ByVal CampoPrincipalValor As String, _
                                         ByVal NombreLargo As String, _
                                         Optional ByVal CampoFiltro As String = "") As String Implements IBCBusqueda.RegistroAnterior
            Dim result As String = Nothing
            Try
                Dim reps = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = reps.SolicitarString(DA.SPNames.spRegistroAnterior, CampoPrincipal, CampoPrincipalValor, NombreLargo, CampoFiltro)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function RegistroSiguiente(ByVal CampoPrincipal As String, _
                                          ByVal CampoPrincipalValor As String, _
                                          ByVal NombreLargo As String, _
                                          Optional ByVal CampoFiltro As String = "") As String Implements IBCBusqueda.RegistroSiguiente
            Dim result As String = Nothing
            Try
                Dim reps = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = reps.SolicitarString(DA.SPNames.spRegistroSiguiente, CampoPrincipal, CampoPrincipalValor, NombreLargo, CampoFiltro)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function UltimoRegistro(ByVal CampoPrincipal As String, _
                                       ByVal NombreLargo As String, _
                                       Optional ByVal CampoFiltro As String = "") As String Implements IBCBusqueda.UltimoRegistro
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spUltimoRegistro, CampoPrincipal, NombreLargo, CampoFiltro)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PrimerRegistroCompuesto(ByVal CampoPrincipal As String, ByVal CampoPrincipalSecundario As String, ByVal NombreLargo As String) As String Implements IBCBusqueda.PrimerRegistroCompuesto
            Dim result As String = Nothing
            Try
                Dim reps = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = reps.SolicitarString(DA.SPNames.spPrimerRegistroCompuesto, CampoPrincipal, CampoPrincipalSecundario, NombreLargo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function RegistroAnteriorCompuesto(ByVal CampoPrincipal As String, ByVal CampoPrincipalValor As String, ByVal CampoPrincipalSecundario As String, ByVal CampoPrincipalSecundarioValor As String, ByVal NombreLargo As String) As String Implements IBCBusqueda.RegistroAnteriorCompuesto
            Dim result As String = Nothing
            Try
                Dim reps = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = reps.SolicitarString(DA.SPNames.spRegistroAnteriorCompuesto, CampoPrincipal, CampoPrincipalValor, CampoPrincipalSecundario, CampoPrincipalSecundarioValor, NombreLargo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function RegistroSiguienteCompuesto(ByVal CampoPrincipal As String, ByVal CampoPrincipalValor As String, ByVal CampoPrincipalSecundario As String, ByVal CampoPrincipalSecundarioValor As String, ByVal NombreLargo As String) As String Implements IBCBusqueda.RegistroSiguienteCompuesto
            Dim result As String = Nothing
            Try
                Dim reps = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = reps.SolicitarString(DA.SPNames.spRegistroSiguienteCompuesto, CampoPrincipal, CampoPrincipalValor, CampoPrincipalSecundario, CampoPrincipalSecundarioValor, NombreLargo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function UltimoRegistroCompuesto(ByVal CampoPrincipal As String, ByVal CampoPrincipalSecundario As String, ByVal NombreLargo As String) As String Implements IBCBusqueda.UltimoRegistroCompuesto
            Dim result As String = Nothing
            Try
                Dim reps = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = reps.SolicitarString(DA.SPNames.spUltimoRegistroCompuesto, CampoPrincipal, CampoPrincipalSecundario, NombreLargo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PrimerRegistroCompuesto3(ByVal CampoPrincipal As String, _
                                                 ByVal CampoPrincipalSecundario As String, _
                                                 ByVal CampoPrincipalTercero As String, _
                                                 ByVal NombreLargo As String) As String Implements IBCBusqueda.PrimerRegistroCompuesto3
            Dim result As String = Nothing
            Try
                Dim reps = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = reps.SolicitarString(DA.SPNames.spPrimerRegistroCompuesto3, _
                                              CampoPrincipal, CampoPrincipalSecundario, CampoPrincipalTercero, _
                                              NombreLargo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function RegistroAnteriorCompuesto3(ByVal CampoPrincipal As String, ByVal CampoPrincipalValor As String, _
                                                   ByVal CampoPrincipalSecundario As String, ByVal CampoPrincipalSecundarioValor As String, _
                                                   ByVal CampoPrincipalTercero As String, ByVal CampoPrincipalTerceroValor As String, _
                                                   ByVal NombreLargo As String) As String Implements IBCBusqueda.RegistroAnteriorCompuesto3
            Dim result As String = Nothing
            Try
                Dim reps = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = reps.SolicitarString(DA.SPNames.spRegistroAnteriorCompuesto3, CampoPrincipal, CampoPrincipalValor, _
                                                                                       CampoPrincipalSecundario, CampoPrincipalSecundarioValor, _
                                                                                       CampoPrincipalTercero, CampoPrincipalTerceroValor, _
                                                                                       NombreLargo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function RegistroSiguienteCompuesto3(ByVal CampoPrincipal As String, ByVal CampoPrincipalValor As String, _
                                                    ByVal CampoPrincipalSecundario As String, ByVal CampoPrincipalSecundarioValor As String, _
                                                    ByVal CampoPrincipalTercero As String, ByVal CampoPrincipalTerceroValor As String, _
                                                    ByVal NombreLargo As String) As String Implements IBCBusqueda.RegistroSiguienteCompuesto3
            Dim result As String = Nothing
            Try
                Dim reps = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = reps.SolicitarString(DA.SPNames.spRegistroSiguienteCompuesto3, CampoPrincipal, CampoPrincipalValor, _
                                                                                       CampoPrincipalSecundario, CampoPrincipalSecundarioValor, _
                                                                                       CampoPrincipalTercero, CampoPrincipalTerceroValor, _
                                                                                       NombreLargo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function UltimoRegistroCompuesto3(ByVal CampoPrincipal As String, _
                                                 ByVal CampoPrincipalSecundario As String, _
                                                 ByVal CampoPrincipalTercero As String, _
                                                 ByVal NombreLargo As String) As String Implements IBCBusqueda.UltimoRegistroCompuesto3
            Dim result As String = Nothing
            Try
                Dim reps = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = reps.SolicitarString(DA.SPNames.spUltimoRegistroCompuesto3, _
                                              CampoPrincipal, CampoPrincipalSecundario, CampoPrincipalTercero, _
                                              NombreLargo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PrimerRegistroFiltro(ByVal CampoPrincipal As String, _
                                             ByVal NombreLargo As String, _
                                             ByVal CampoFiltro As String) As String Implements IBCBusqueda.PrimerRegistroFiltro
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spPrimerRegistro, CampoPrincipal, NombreLargo, CampoFiltro)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function RegistroAnteriorFiltro(ByVal CampoPrincipal As String, _
                                               ByVal CampoPrincipalValor As String, _
                                               ByVal NombreLargo As String, _
                                               ByVal CampoFiltro As String) As String Implements IBCBusqueda.RegistroAnteriorFiltro
            Dim result As String = Nothing
            Try
                Dim reps = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = reps.SolicitarString(DA.SPNames.spRegistroAnterior, CampoPrincipal, CampoPrincipalValor, NombreLargo, CampoFiltro)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function RegistroSiguienteFiltro(ByVal CampoPrincipal As String, _
                                                ByVal CampoPrincipalValor As String, _
                                                ByVal NombreLargo As String, _
                                                ByVal CampoFiltro As String) As String Implements IBCBusqueda.RegistroSiguienteFiltro
            Dim result As String = Nothing
            Try
                Dim reps = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = reps.SolicitarString(DA.SPNames.spRegistroSiguiente, CampoPrincipal, CampoPrincipalValor, NombreLargo, CampoFiltro)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function UltimoRegistroFiltro(ByVal CampoPrincipal As String, _
                                             ByVal NombreLargo As String, _
                                             ByVal CampoFiltro As String) As String Implements IBCBusqueda.UltimoRegistroFiltro
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spUltimoRegistro, CampoPrincipal, NombreLargo, CampoFiltro)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function NuevoCodigoDireccionPersona() As String Implements IBCBusqueda.NuevoCodigoDireccionPersona
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spNuevoCodigoDireccionPersona)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function CodigoDireccionPersona(ByVal PER_ID As String, ByVal DIR_TIPO As Short) As String Implements IBCBusqueda.CodigoDireccionPersona
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spCodigoDireccionPersona, PER_ID, DIR_TIPO)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function TotalPrestamoPersonal(ByVal CCT_ID As String, ByVal PRE_SERIE As String, ByVal PRE_NUMERO As String) As Decimal Implements IBCBusqueda.TotalPrestamoPersonal
            Dim result As Decimal = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarDecimal(DA.SPNames.spTotalPrestamoPersonal, CCT_ID, PRE_SERIE, PRE_NUMERO)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function TotalPrestamoPersonalCliente(ByVal CCT_ID As String, ByVal PER_ID_CLI As String, ByVal PRE_SERIE As String, ByVal PRE_NUMERO As String) As Decimal Implements IBCBusqueda.TotalPrestamoPersonalCliente
            Dim result As Decimal = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarDecimal(DA.SPNames.spTotalPrestamoPersonalCliente, CCT_ID, PER_ID_CLI, PRE_SERIE, PRE_NUMERO)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function LineaCreditoPersona(ByVal PER_ID As String) As Decimal Implements IBCBusqueda.LineaCreditoPersona
            Dim result As Decimal = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarDecimal(DA.SPNames.spLineaCreditoPersona, PER_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function LineaCreditoPersonaEstado(ByVal PER_ID As String) As Boolean Implements IBCBusqueda.LineaCreditoPersonaEstado
            Dim result As Boolean = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spLineaCreditoPersonaEstado, PER_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function DiasCreditoPersona(ByVal PER_ID As String) As Decimal Implements IBCBusqueda.DiasCreditoPersona
            Dim result As Decimal = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarDecimal(DA.SPNames.spDiasCreditoPersona, PER_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function EsPersonaAgentePercepcion(ByVal PER_ID As String) As String Implements IBCBusqueda.EsPersonaAgentePercepcion
            Dim result As String = "NINGUNO"
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spEsPersonaAgentePercepcionXML, PER_ID))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarStringXML(sr, "PER_PROVEEDOR_OP_CON")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PedidoDocumento(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DOC_SERIE As String, ByVal DOC_NUMERO As String) As String Implements IBCBusqueda.PedidoDocumento
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spPedidoDocumento, TDO_ID, DTD_ID, DOC_SERIE, DOC_NUMERO)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function EsPersonaAgenteRetencion(ByVal PER_ID As String) As String Implements IBCBusqueda.EsPersonaAgenteRetencion
            Dim result As String = "NINGUNO"
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spEsPersonaAgenteRetencionXML, PER_ID))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarStringXML(sr, "PER_CLIENTE_OP_CON")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SignoCuentaContable(ByVal CUC_ID As String) As Integer Implements IBCBusqueda.SignoCuentaContable
            Dim result As Integer = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarEntero(DA.SPNames.spSignoCuentaContable, CUC_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function FormaVentaPersona(ByVal PER_ID As String) As String Implements IBCBusqueda.FormaVentaPersona
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spFormaVentaPersona, PER_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function CambioDia(ByVal Campo As String, ByVal Mon_Id_1 As String, ByVal Mon_Id_0 As String, ByVal Tca_Fecha As String) As Double Implements IBCBusqueda.CambioDia
            Dim result As Double = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarDecimal(DA.SPNames.spCambioDia, Campo, Mon_Id_1, Mon_Id_0, Tca_Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function FechaServidor() As String Implements IBCBusqueda.FechaServidor
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spFechaServidor)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function


        Public Function FormaVentaTipoVenta(ByVal TIV_ID As String) As String Implements IBCBusqueda.FormaVentaTipoVenta
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spFormaVentaTipoVenta, TIV_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PromocionPersona(ByVal PER_ID As String) As String Implements IBCBusqueda.PromocionPersona
            Dim result As String = ""
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spPromocionPersonaXML, PER_ID))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarStringXML(sr, "PER_PROMOCIONES")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SaldoFnKardex(ByVal PER_ID As String, ByVal Filtro As String) As Double Implements IBCBusqueda.SaldoFnKardex
            SaldoFnKardex = 0
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spVistaSaldosDTDXML, PER_ID, Filtro))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                SaldoFnKardex = rep.SolicitarDecimalXML(sr, "SALDO")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return SaldoFnKardex
        End Function

        Public Function ComportamientoCierre(ByVal PVE_ID As String, ByVal DTD_ID As String, ByVal Mes As String, ByVal Anio As Int16) As String Implements IBCBusqueda.ComportamientoCierre
            Dim result As String = ""
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spComportamientoCierreXML, PVE_ID, DTD_ID, Mes, Anio))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarStringXML(sr, "DCI_COMPORTAMIENTO")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PesoArticulo(ByVal ART_ID As String, ByVal Anio As Short, ByVal Mes As String) As Double Implements IBCBusqueda.PesoArticulo
            Dim result As Double = 0
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spPesoMaximoPesosArticulosXML, ART_ID, Anio, Mes))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarDecimalXML(sr, "PAR_PESO_MAX")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function UnidadMedidaArticulo(ByVal ART_ID As String) As String Implements IBCBusqueda.UnidadMedidaArticulo
            Dim result As String = 0
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spUnidadMedidaArticulosXML, ART_ID))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarStringXML(sr, "UM_DESCRIPCION")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function NuevoPla_IdPlacas() As String Implements IBCBusqueda.NuevoPla_IdPlacas
            Dim result As String = 0
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spNuevoPla_IdPlacasXML))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarStringXML(sr, "Pla_Id")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function VerificarExisteRolPersonaTipoPersona(ByVal PER_ID As String, ByVal TPE_ID As String) As String Implements IBCBusqueda.VerificarExisteRolPersonaTipoPersona
            Dim result As Integer = 1
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spVerificarExisteRolPersonaTipoPersonaXML, PER_ID, TPE_ID))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarEnteroXML(sr, "Cantidad")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListarIdPermisoUsuario(ByVal USU_ID As String) As String Implements IBCBusqueda.ListarIdPermisoUsuario
            Dim result As String = ""
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spListarIdPermisoUsuarioXML, USU_ID))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarStringXML(sr, "PEU_ID")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function spInsertarDespachoDistribuidora(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCT_ID As String, ByVal cDES_FEC_EMI As Date, ByVal cDES_FEC_TRA As Date, ByVal cPVE_ID As String, ByVal cALM_ID As Short, ByVal cALM_ID_LLEGADA As Short, ByVal cDES_SERIE As String, ByVal cDES_NUMERO As String, ByVal cTDO_ID_DOC As String, ByVal cDTD_ID_DOC As String, ByVal cDES_SERIE_DOC As String, ByVal cDES_NUMERO_DOC As String, ByVal cPER_ID_REC As String, ByVal cTDP_ID_REC As String, ByVal cDIR_ID_ENT_REC As String, ByVal cDIR_ID_ENT As String, ByVal cPLA_ID As String, ByVal cFLE_ID As String, ByVal cMON_ID As String, ByVal cDES_MONTO_FLETE As Double, ByVal cDES_CONTRAVALOR As Double, ByVal cDES_OBSERVACIONES As String, ByVal cUSU_ID As String, ByVal cDES_FEC_GRAB As Date, ByVal cDES_ESTADO As Short, ByVal cDES_FEC_PRO_CRO As Date, ByVal cDES_FEC_CAR_DES As Date, ByVal cDES_FEC_SAL_PLA As Date) As Integer Implements IBCBusqueda.spInsertarDespachoDistribuidora
            Dim result As Integer = 0
            Try
                result = IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spInsertarRegistroDespachos, cTDO_ID, cDTD_ID, cCCT_ID, cDES_FEC_EMI, cDES_FEC_TRA, cPVE_ID, cALM_ID, cALM_ID_LLEGADA, cDES_SERIE, cDES_NUMERO, cTDO_ID_DOC, cDTD_ID_DOC, cDES_SERIE_DOC, cDES_NUMERO_DOC, cPER_ID_REC, cTDP_ID_REC, cDIR_ID_ENT_REC, cDIR_ID_ENT, cPLA_ID, cFLE_ID, cMON_ID, cDES_MONTO_FLETE, cDES_CONTRAVALOR, cDES_OBSERVACIONES, cUSU_ID, cDES_FEC_GRAB, cDES_ESTADO, cDES_FEC_PRO_CRO, cDES_FEC_CAR_DES, cDES_FEC_SAL_PLA)
                'Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                'result = rep.SolicitarStringXML(sr, "PEU_ID")
            Catch ex As Exception
                result = 0
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function userMensaje(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.userMensaje
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan("dbo.spUserMensaje", USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function userFactura(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.userFactura
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan("dbo.spUserFactura", USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function EditarFechaEmisionDespachos(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.EditarFechaEmisionDespachos
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spEditarFechaEmisionDespachos, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function TelefonoPersona(ByVal PER_ID As String) As String Implements IBCBusqueda.TelefonoPersona
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spTelefonoPersona, PER_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function DescripcionCortaTipoDocumento(ByVal TDO_ID As String) As String Implements IBCBusqueda.DescripcionCortaTipoDocumento
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spDescripcionCortaTipoDocumento, TDO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PermisoCronograma(ByVal USU_ID As String) As Short Implements IBCBusqueda.PermisoCronograma
            Dim result As Short = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarDecimal(DA.SPNames.spPermisoCronograma, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function EditarFechaEmisionTesoreria(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.EditarFechaEmisionTesoreria
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spEditarFechaEmisionTesoreria, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function EditarFechaEmisionDocumento(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.EditarFechaEmisionDocumento
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spEditarFechaEmisionDocumentos, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function NoCajeroEnTesoreria(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.NoCajeroEnTesoreria
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spNoCajeroEnTesoreria, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReciboEgresoPlanillaTesoreria(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.ReciboEgresoPlanillaTesoreria
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spReciboEgresoPlanillaTesoreria, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReciboIngresoPlanillaTesoreria(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.ReciboIngresoPlanillaTesoreria
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spReciboEgresoPlanillaTesoreria, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function CorrelativoSerie(ByVal CTD_COR_SERIE As String, ByVal TDO_ID As String) As String Implements IBCBusqueda.CorrelativoSerie
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spCorrelativoSerie, CTD_COR_SERIE, TDO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function FechaDocumento(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DOC_SERIE As String, ByVal DOC_NUMERO As String) As String Implements IBCBusqueda.FechaDocumento
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spFechaDocumento, TDO_ID, DTD_ID, DOC_SERIE, DOC_NUMERO)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function EditarCampo(ByVal IdUsuario As String, ByVal NombreFormulario As String, ByVal CampoEditar As String) As Boolean Implements IBCBusqueda.EditarCampo
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spEditarCampo, IdUsuario, NombreFormulario, CampoEditar)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function NuevoLpr_IdListaPreciosArticulos() As String Implements IBCBusqueda.NuevoLpr_IdListaPreciosArticulos
            Dim result As String = 0
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spNuevoLpr_IdListaPreciosArticulosXML))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarStringXML(sr, "Lpr_Id")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ObligadoOrdenCompra(ByVal PER_ID_CLI As String) As Boolean Implements IBCBusqueda.ObligadoOrdenCompra
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spObligadoOrdenCompra, PER_ID_CLI)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ModificarNombreEnPersona(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.ModificarNombreEnPersona
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spModificarNombreEnPersona, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ModificarEstadoEnPersona(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.ModificarEstadoEnPersona
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spModificarEstadoEnPersona, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ModificarEsBancoEnPersona(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.ModificarEsBancoEnPersona
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spModificarEsBancoEnPersona, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ModificarFinanzasEnPersona(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.ModificarFinanzasEnPersona
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spModificarFinanzasEnPersona, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ModificarFormaVentaEnPersona(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.ModificarFormaVentaEnPersona
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spModificarFormaVentaEnPersona, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ModificarObservacionesEnPersona(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.ModificarObservacionesEnPersona
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spModificarObservacionesEnPersona, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function EMailPersona(ByVal PER_ID As String) As String Implements IBCBusqueda.EMailPersona
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spEMailPersona, PER_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function DireccionPuntoVenta(ByVal PVE_ID As String) As String Implements IBCBusqueda.DireccionPuntoVenta
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spDireccionPuntoVenta, PVE_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ModificarContactoEnPersona(ByVal USU_ID As String) As Boolean Implements IBCBusqueda.ModificarContactoEnPersona
            Dim result As Boolean = False
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spModificarContactoEnPersona, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function


        Public Function ReciboCCO_IDCUC_ID(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cDTE_SERIE As String, ByVal cDTE_NUMERO As String) As Integer Implements IBCBusqueda.ReciboCCO_IDCUC_ID
            Dim result As Integer = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarEntero(DA.SPNames.spReciboCCO_IDCUC_ID, cTDO_ID, cDTD_ID, cCCC_ID, cDTE_SERIE, cDTE_NUMERO)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ContraEntregaDocumento(ByVal PER_ID As String) As Boolean Implements IBCBusqueda.ContraEntregaDocumento
            Dim result As Boolean = True
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spContraEntregaDocumentos, PER_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ClienteSoloVentaContado(ByVal PER_ID As String) As Boolean Implements IBCBusqueda.ClienteSoloVentaContado
            Dim result As Boolean = True
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarBooelan(DA.SPNames.spClienteSoloVentaContado, PER_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function CodigoPersonaEnPlanilla(ByVal PER_ID As String) As String Implements IBCBusqueda.CodigoPersonaEnPlanilla
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spCodigoPersonaEnPlanilla, PER_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function LimiteContraEntrega(ByVal PAR_ID As String) As Double Implements IBCBusqueda.LimiteContraEntrega
            Dim result As Double = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarDecimal(DA.SPNames.spLimiteContraEntrega, PAR_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function DiasRetraso(ByVal PER_ID As String, ByVal Codigo As String) As Double Implements IBCBusqueda.DiasRetraso
            Dim result As Double = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarDecimal(DA.SPNames.spDiasRetraso, PER_ID, Codigo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
        Public Function DiasRetrasoGeneral(ByVal PER_ID As String) As Double Implements IBCBusqueda.DiasRetrasoGeneral
            Dim result As Double = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarDecimal("dbo.spDiasRetrasoGeneral", PER_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function


        Public Function FormaVentaGuiaLadrillo(ByVal DTD_ID As String, ByVal DES_SERIE As String, ByVal DES_NUMERO As String) As String Implements IBCBusqueda.FormaVentaGuiaLadrillo
            Dim result As String = Nothing
            Try
                Dim reps = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = reps.SolicitarString("spFormaVentaGuiaLadrillo", DTD_ID, DES_SERIE, DES_NUMERO)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
    End Class
End Namespace
