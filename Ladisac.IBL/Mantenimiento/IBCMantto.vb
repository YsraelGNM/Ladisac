Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCMantto

#Region "Mantenimientos"
        Sub MantenimientoMantto(ByVal mMantto As Mantto)
#End Region

#Region "Querys"
        Function ManttoGetById(ByVal MTO_ID As Integer) As Mantto
        Function ListaMantto() As String
#End Region

    End Interface

End Namespace
