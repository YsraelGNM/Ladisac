
Imports Ladisac.BE

Namespace Ladisac.BL
    Public Interface IBCPeriodisidad
#Region "Mantenimiento"
        Sub Maintenance(ByVal item As Periodisidad)

#End Region

#Region "Consulta"
        Function PeriodisidadQuery(ByVal pec_Periodisidad_Id As String, ByVal pec_Descripcion As String)
        Function PeriodisidadSeek(ByVal id As String) As BE.Periodisidad

#End Region

    End Interface
End Namespace

