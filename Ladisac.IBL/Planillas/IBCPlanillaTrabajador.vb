
Imports Ladisac.BE
Namespace Ladisac.BL
    '0

    Public Interface IBCPlanillaTrabajador

#Region "Maintenance"
        Function Maintenance(ByVal item As BE.PlanillaTrabajador)

#End Region
#Region "Consulta"
        Function spDatosLaboralesXPlanillaTrabajador(ByVal sXml As String)

#End Region
    End Interface
End Namespace


