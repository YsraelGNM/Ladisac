Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCParametro

#Region "Mantenimientos"
        Sub MantenimientoParametro(ByVal mParametro As Parametro)
#End Region

#Region "Querys"
        Function ParametroGetById(ByVal PAR_ID As String) As Parametro
        Function ListaParametro() As String
#End Region

    End Interface

End Namespace
