Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface IDetalleComprobantesRepositorio

        Function GetById(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String)
        Function Maintenance(ByVal item As BE.DetalleComprobantes) As Boolean

    End Interface

End Namespace



'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IDetalleAsientosManualesRepositorio
'        Function GetById(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String, ByVal dam_Item As String) As DetalleAsientosManuales
'        Function Maintenance(ByVal item As DetalleAsientosManuales) As Boolean

'    End Interface

'End Namespace