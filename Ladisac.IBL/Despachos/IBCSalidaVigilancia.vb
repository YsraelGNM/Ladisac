Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCSalidaVigilancia

#Region "Mantenimientos"
        Sub MantenimientoSalidaVigilancia(ByVal mSalidaVigilancia As SalidaVigilancia)
#End Region

#Region "Querys"
        Function SalidaVigilanciaGetById(ByVal SVI_ID As Integer) As SalidaVigilancia
        Function SalidaVigilanciaGetByDocumento(ByVal Documento As String) As SalidaVigilancia
        Function ListaSalidaVigilancia() As String
#End Region

    End Interface

End Namespace
