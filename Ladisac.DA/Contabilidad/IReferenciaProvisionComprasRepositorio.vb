Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IReferenciaProvisionComprasRepositorio

        Function GetById(ByVal prc_Voucher As String, ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal rep_Serie As String, ByVal rep_Numero As String)
        Function Maintenance(ByVal item As BE.ReferenciaProvisionCompras)

    End Interface

End Namespace



'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IProvisionComprasRepositorio
'        Function GetById(ByVal prd_Periodo_id As String, ByVal prc_Voucher As String, ByVal lib_Id As String)
'        Function maintenance(ByVal item As BE.ProvisionCompras)
'    End Interface

'End Namespace