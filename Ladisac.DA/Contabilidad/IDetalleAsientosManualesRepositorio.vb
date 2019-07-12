Imports Ladisac.BE
Namespace Ladisac.DA

    Public Interface IDetalleAsientosManualesRepositorio
        Function GetById(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String, ByVal dam_Item As String) As DetalleAsientosManuales
        Function Maintenance(ByVal item As DetalleAsientosManuales) As Boolean
        Function MaintenanceDelete(ByVal item As BE.DetalleAsientosManuales)
    End Interface

End Namespace

