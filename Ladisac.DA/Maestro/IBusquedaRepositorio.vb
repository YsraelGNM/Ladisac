Namespace Ladisac.DA
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IBusquedaRepositorio
        Function InsertarPorProcedimiento(ByVal procedimiento As String, ByVal ParamArray params As Object()) As Integer
        Function SolicitarString(ByVal report As String, ByVal ParamArray params As Object()) As String
        Function SolicitarDecimal(ByVal report As String, ByVal ParamArray params As Object()) As Decimal
        Function SolicitarBooelan(ByVal report As String, ByVal ParamArray params As Object()) As Boolean
        Function SolicitarEntero(ByVal report As String, ByVal ParamArray params As Object()) As Integer

        Function SolicitarStringXML(ByVal DatosXml As IO.StringReader, ByVal NombreCampo As String) As String
        Function SolicitarDecimalXML(ByVal DatosXml As IO.StringReader, ByVal NombreCampo As String) As Decimal
        Function SolicitarEnteroXML(ByVal DatosXml As IO.StringReader, ByVal NombreCampo As String) As Integer
    End Interface
End Namespace
