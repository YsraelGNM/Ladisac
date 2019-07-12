Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface ILeasingRepositorio
        Function GetById(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal lea_Serie As String, ByVal lea_Numero As String) As BE.Leasing
        Function Maintenance(ByVal item As BE.Leasing) As Boolean
        Function MaintenanceDelete(ByVal item As BE.Leasing) As Boolean

    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IComprobantesRepositorio

'        Function GetById(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String)

'        Function Maintenance(ByVal item As Comprobantes) As Boolean
'        Function MaintenanceDelete(ByVal item As Comprobantes) As Boolean


'    End Interface


'End Namespace