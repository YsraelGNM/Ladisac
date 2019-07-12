Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCAsientoAutomatico

#Region "Procedures"

        Function AsientoAutomaticoCompras(ByVal periodo As String)
        Function AsientoAutomaticoDividendos(ByVal periodo As String)
        Function AsientoAutomaticoVentas(ByVal periodo As String)
        Function AsientoAutomaticoTesoreria(ByVal periodo As String)
        Function AsientoAutomaticoPersonal(ByVal periodo As String)
        Function RecarculoKardex(ByVal periodo As String)

        ' SP

#End Region
    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Interface IBCAsientosManuales
'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As BE.AsientosManuales)

'#End Region
'#Region "Consulta"
'        Function AsientosManualesQuery(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String)
'        Function AsientosManualesSeek(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String)

'#End Region
'    End Interface
