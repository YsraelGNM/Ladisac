Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCComprobantes

#Region "Maintenanace "
        Function Maintenance(ByRef item As BE.Comprobantes)
        Function MaintenanceDelete(ByVal item As BE.Comprobantes)
#End Region

#Region "Consulta"

        Function ComprobantesQuery(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal tdo_Id As String, ByVal dtd_Id As String, _
                                   ByVal cob_Serie As String, ByVal cob_Numero As String, ByVal Nombre As String)

        Function ComprobantesSeek(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String)

        Function ComprobantesListaQuery(ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String, ByVal idpersona As String, ByVal desde As DateTime, ByVal hasta As DateTime, ByVal tdo_IdBuscar As String, ByVal dtd_IdBuscar As String)
        Function ComprobantesListaQuery1(ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String, ByVal idpersona As String, ByVal desde As DateTime, ByVal hasta As DateTime, ByVal tdo_IdBuscar As String, ByVal dtd_IdBuscar As String, Optional ByVal fechas As Date = #1/1/2000#)
        Function SPDetalleComprobantes(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String)


#End Region



    End Interface


End Namespace



'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Interface IBCAsientosManuales
'#Region Class1.vb"Mantenimiento"
'        Function Maintenance(ByVal item As BE.AsientosManuales)

'#End Region
'#Region "Consulta"
'        Function AsientosManualesQuery(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String)
'        Function AsientosManualesSeek(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String)

'#End Region
'    End Interface

'End Namespace