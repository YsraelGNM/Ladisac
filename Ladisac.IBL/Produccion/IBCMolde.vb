Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCMolde

#Region "Mantenimientos"
        Sub MantenimientoMolde(ByVal mMolde As Molde)
#End Region

#Region "Querys"
        Function MoldeGetById(ByVal MOL_ID As Integer) As Molde
        Function ListaMolde() As String
#End Region

    End Interface

End Namespace
