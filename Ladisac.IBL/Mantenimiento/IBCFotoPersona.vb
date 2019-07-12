Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCFotoPersona

#Region "Mantenimientos"
        Sub MantenimientoFotoPersona(ByVal mFotoPersona As FotoPersonas)
#End Region

#Region "Querys"
        Function FotoPersonaGetById(ByVal FOP_ID As Integer) As FotoPersonas
        Function ListaFotoPersonas() As String
#End Region

    End Interface

End Namespace
