
Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface IAsientosManualesRepositorio
        Function GetById(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String) As AsientosManuales
        Function Maintenance(ByVal item As AsientosManuales) As Boolean
        Function MaintenanceDelete(ByVal item As BE.AsientosManuales)
    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IClaseCuentaRepositorio
'        Function GetById(ByVal id As String) As ClaseCuenta
'        Function Mantenance(ByVal item As ClaseCuenta) As Boolean
'    End Interface
'End Namespace
