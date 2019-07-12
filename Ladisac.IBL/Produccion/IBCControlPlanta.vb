Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCControlPlanta

#Region "Mantenimientos"
        Sub MantenimientoControlPlanta(ByVal mControlPlanta As ControlPlanta)
#End Region

#Region "Querys"
        Function ControlPlantaGetById(ByVal CPL_ID As Integer) As BE.ControlPlanta
        Function ListaControlPlanta() As String
#End Region

    End Interface

End Namespace
