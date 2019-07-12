Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface IComprobantesRepositorio

        Function GetById(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String)

        Function Maintenance(ByVal item As Comprobantes) As Boolean
        Function MaintenanceDelete(ByVal item As Comprobantes) As Boolean


    End Interface


End Namespace




'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface IAsientosManualesRepositorio
'        Function GetById(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String) As AsientosManuales
'        Function Maintenance(ByVal item As AsientosManuales) As Boolean
'    End Interface

'End Namespace