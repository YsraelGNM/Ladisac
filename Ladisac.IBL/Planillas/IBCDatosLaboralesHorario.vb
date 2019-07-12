Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCDatosLaboralesHorario
#Region "Mantenimiento"
        Function Maintenance(ByVal items As List(Of DatosLaboralesHorario))


#End Region
#Region "Consultas"
        Function DatosLaboralesHorarioQuery(ByVal per_Id As String, ByVal crv_ItemCroVaca As String)
        Function DatosLaboralesHorarioSeek(ByVal per_Id As String, ByVal crv_ItemCroVaca As String) As BE.DatosLaboralesHorario

#End Region
    End Interface


End Namespace
