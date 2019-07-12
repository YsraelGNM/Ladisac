Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCPlanilla
#Region "Mantenimiento"
        'kk
        Function Maintenance(ByVal item As BE.Planillas)
        Function MaintenanceInsert(ByVal sXmlCabecera As String, ByVal sXmlDetalle As String, ByVal pla_SeriePlani As String, ByVal xmlComedorHora As String)
        Function SPPlanillaDelete(ByVal serie As String, ByVal numero As String, ByVal persona_id As String)
        Function SPPlanillaUpdate(ByVal sXmlCabecera As String, ByVal sXmlDetalle As String, ByVal pla_SeriePlani As String, ByVal xmlComedorHora As String, ByVal numero As String)
#End Region
#Region "Consulta"

        Function PlanillaQuery(ByVal numero As String, ByVal descripcion As String, ByVal fechaDesde As DateTime, ByVal fechaHasta As DateTime)
        Function PlanillaSeek(ByVal pla_SeriePlani As String, ByVal pla_Numero As String, ByVal tdo_Id As String)
        Function TrabajadorParaPlanillasSeek(ByVal sXml As String, Optional ByVal tip_TipoPlan_Id As String = "")
        Function ListaDescuentoJudicialXPlanilla(Optional ByVal tipoPlanilla As String = "")
        Function TrabajadorCalculoPlanillas(ByVal listaComedorXML As String, _
                                            ByVal listaHoraXML As String, _
                                            ByVal listaJudicialXML As String, _
                                            ByVal ListaPagosAplicarXML As String, _
                                            ByVal ListaPersonas As String, _
                                            ByVal tipoPlanilla As String, _
                                            ByVal PeriodoDesde As String, _
                                            ByVal PeriodoHasta As String, _
                                            ByVal tit_TipoTrab_Id As String, _
                                            ByVal ItemConceptoPlanilla As String)

        Function spTrabajadorPagosParaPlanillasSeek(ByVal sXml As String)

        Function spTrabajadorPagosXDocPlanillas(ByVal TDO_ID_DOC As String, _
                                                   ByVal DTD_ID_DOC As String, _
                                                   ByVal SerieRef As String, _
                                                   ByVal NumeroRef As String)

        Function spDetallePrestamoParaPlanilla(ByVal TDO_ID_DOC As String, _
                                                   ByVal DTD_ID_DOC As String, _
                                                   ByVal SerieRef As String, _
                                                   ByVal NumeroRef As String)

        Function spPlanillaBuscarSelectXML(ByVal periodoDesde As String, _
                                           ByVal periodoHasta As String, _
                                           ByVal serie As String, _
                                           ByVal numero As String, _
                                           ByVal descripcion As String)

        Function spPlanillaPersonaSelectXML(ByVal serie As String, ByVal numero As String)
        Function spPlanillaPersonaDetalleSelectXML(ByVal serie As String, ByVal numero As String, ByVal personas_id As String)

        Function spPlanillaPersonaTotalesSelectXML(ByVal xmlLista As String)

        Function SPPlanillasDetatalleKardexCtaCteRegenerar(ByVal serie As String, ByVal numero As String, ByVal listadoPersonas As String)
        Function spPorcentajeMesPlanilla(ByVal FI As Date, ByVal Ffi As Date, ByVal Fin As Date, ByVal FF As Date, ByVal Per_id As String, ByVal ElegirMes As Integer, ByVal trh_Numero As String) As Decimal

#End Region
    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCPermisosTrabajador
'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As BE.PermisosTrabajador)
'#End Region
'#Region "Consulta"
'        Function PermisosTrabajadorQuery(ByVal numero As String, ByVal persona As String, ByVal codigo As String)
'        Function PermisosTrabajadorSeek(ByVal numero As String)
'#End Region
'    End Interface

'End Namespace