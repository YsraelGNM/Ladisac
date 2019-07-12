Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCSancion

#Region "Mantenimientos"
        Sub MantenimientoSancion(ByVal mSancion As Sancion)
#End Region

#Region "Querys"
        Function SancionGetById(ByVal SAN_ID As Integer) As Sancion
        Function ListaSancion() As String
        Function ListaControlSanciones(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Per_Id_Falta As String, ByVal DNI As String, ByVal Per_Id_Empresa As String, ByVal Placa As String) As String
#End Region

    End Interface

End Namespace
