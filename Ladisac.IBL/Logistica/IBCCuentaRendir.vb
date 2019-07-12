Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCCuentaRendir

#Region "Mantenimientos"
        Function MantenimientoCuentaRendir(ByVal mCuentaRendir As CuentaRendir) As Integer
#End Region

#Region "Querys"
        Function CuentaRendirGetById(ByVal CRE_ID As Integer) As CuentaRendir
        Function ListaCuentaRendir() As String
        Function CuentaRendirTesoreria() As String
        Function ImprimirCuentaRendir(ByVal CRE_ID As Integer) As DataTable
#End Region

    End Interface

End Namespace
