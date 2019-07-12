Imports Ladisac.BE
Namespace Ladisac.BL


    Public Interface IBCDatosLaborales

#Region "Mantenimientos"
        Function Mantenance(ByVal item As DatosLaborales)
#End Region

#Region "consultas"

        Function DatosLaboralesListaQuery(ByVal per_Id As String, ByVal dal_CodigoTrabajador As String, ByVal nombre As String, Optional ByVal tit_TipoTrab_Id As String = Nothing, Optional ByVal rep_RegiPension_id As String = Nothing)
        Function DatosLaboralesQuery(ByVal per_Id As String)
        Function DatosLaboralesSeek(ByVal per_Id As String)
        Function BuscarPersonaEntidad(Optional ByVal id As String = Nothing, Optional ByVal nombre As String = Nothing, Optional ByVal trabajador As String = Nothing, Optional ByVal banco As String = Nothing, Optional ByVal ruc As String = Nothing, Optional ByVal dni As String = Nothing)
        Function DatosLaboralesDetalleQuery(ByVal per_Id As String, ByVal codigo As String, ByVal nombre As String)
        Function EstadoCivilXML()
        Function spDatosLaboralesPanelSelect(ByVal TipoTRabajador As String, ByVal situacionTrabajador As String, ByVal AreaTrabajo As String)
        Function spDatosLaboralesPanelHorasSelect(ByVal TipoTRabajador As String, ByVal situacionTrabajador As String, ByVal fechaInicio As Date, ByVal fechaHasta As Date)
        Function GetByCodTrabajador(ByVal Codigo As String) As DatosLaborales

#End Region

    End Interface

End Namespace


