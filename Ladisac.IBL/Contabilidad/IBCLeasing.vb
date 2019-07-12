Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCLeasing
#Region "Maintenance"

        Function Maintenance(ByVal item As BE.Leasing)
        Function MAintenanceDelete(ByVal item As BE.Leasing)

#End Region

#Region "Consultas"

        Function LeasingQuery(ByVal serie As String, ByVal numero As String, ByVal Nombre As String, ByVal FechaDesde As Date, ByVal FechaHasta As Date)
        Function LeasingSeek(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal lea_Serie As String, ByVal lea_Numero As String)
        Function LeasingListaQuery(ByVal serie As String, ByVal numero As String, ByVal per_id As String)

#End Region
    End Interface

End Namespace



'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Interface IBCComprobantes

'#Region "Maintenanace "
'        Function Maintenance(ByRef item As BE.Comprobantes)
'        Function MaintenanceDelete(ByVal item As BE.Comprobantes)
'#End Region

'#Region "Consulta"

'        Function ComprobantesQuery(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal tdo_Id As String, ByVal dtd_Id As String, _
'                                   ByVal cob_Serie As String, ByVal cob_Numero As String, ByVal Nombre As String)

'        Function ComprobantesSeek(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String)

'        Function ComprobantesListaQuery(ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String, ByVal idpersona As String, ByVal desde As DateTime, ByVal hasta As DateTime, ByVal tdo_IdBuscar As String, ByVal dtd_IdBuscar As String)


'#End Region



'    End Interface


'End Namespace
