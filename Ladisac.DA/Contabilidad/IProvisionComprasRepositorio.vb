Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface IProvisionComprasRepositorio
        Function GetById(ByVal prd_Periodo_id As String, ByVal prc_Voucher As String, ByVal lib_Id As String)
        Function maintenance(ByVal item As BE.ProvisionCompras)
        Function MaintenanceDelete(ByVal item As BE.ProvisionCompras)
        Function spDetalleProvisionCompras(ByVal prd_Periodo_id As String, ByVal prc_Voucher As String, ByVal cuc_IdOld As String, ByVal cuc_Idnew As String)
    End Interface

End Namespace



'Imports Ladisac.BE
'Namespace Ladisac.DA
'    Public Interface IAsientosManualesRepositorio
'        Function GetById(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String) As AsientosManuales
'        Function Maintenance(ByVal item As AsientosManuales) As Boolean
'    End Interface

'End Namespace
