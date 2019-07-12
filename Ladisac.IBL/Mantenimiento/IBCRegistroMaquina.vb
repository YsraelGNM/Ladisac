Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCRegistroMaquina

#Region "Mantenimientos"
        Sub MantenimientoRegistroMaquina(ByVal mRegistroMaquina As RegistroMaquina)
#End Region

#Region "Querys"
        Function RegistroMaquinaGetById(ByVal RMA_ID As Integer) As RegistroMaquina
        Function ListaRegistroMaquina() As String
#End Region

    End Interface

End Namespace
