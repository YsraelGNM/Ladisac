Imports System.Windows.Forms
Namespace Ladisac.BL
    Public Interface IBCUtil

#Region "Otros"
        Sub excelExportar(ByVal oDAta As System.Data.DataTable)
        Function excelImportacionConFormato(ByVal sRuta As String, ByVal sCabecere As String) As DataTable
        Function getXml(ByVal oDataGridView As DataGridView, ByVal ParamArray Columns() As Integer) As String
        Function getXml(ByVal ColumnaOK As Int16, ByVal oDataGridView As DataGridView, ByVal ParamArray Columns() As Integer) As String
        Function diferenciaHorasHH(ByVal desde As Double, ByVal hasta As Double) As Double
        Function derecha(ByVal sdato As String, ByVal numeros As Int16)
        Function getTable(ByVal DataGridView As DataGridView, ByVal tableName As String) As DataTable
#End Region


#Region "Consulta"
        Function CorrelativoQuery(ByVal sTabla As String, ByVal sCampo As String, ByVal sNumeroDigitos As Integer, Optional ByVal sWhere As String = Nothing) As String

        Function GetId(ByVal sTabla As String, ByVal sCampo As String, ByVal sNumeroDigitos As Integer, Optional ByVal sWhere As String = Nothing) As String
#End Region

    End Interface

End Namespace
