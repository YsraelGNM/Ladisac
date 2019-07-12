Namespace Ladisac.BL
    Public Interface IBCCuentasComprobantesLogistica
#Region "Mantenimiento"
        Sub Maintenance(ByVal xml As String, ByVal USU_ID As String)
#End Region

#Region "Consulta"


        Function spCuentasComprobantesLogisticaSelect(ByVal idAlmacen As Integer)
        Function spAlmacenSelect(ByVal sDescripcion As String)
        Function spCuentasComprobantesLogisticaValidar(ByVal sXml As String)

#End Region
    End Interface
End Namespace





'Namespace Ladisac.BL
'    Public Interface IBCGrupoTrabajoDiasDescanso

'#Region "Mantenimiento"
'        Sub Maintenance(ByVal fechaInicio As Date, ByVal xml As String, ByVal USU_ID As String)
'#End Region

'#Region "Consulta"
'        Function spGrupoTrabajoDiasDescansoSelect(ByVal fechaDesde As Date, Optional ByVal Trabajador As String = "", Optional ByVal filtro As Single = 0)
'        Function spGrupoTrabajoDiasDescansoReporte(ByVal fechaDesde As Date, Optional ByVal Trabajador As String = "", Optional ByVal filtro As Single = 0)
'#End Region

'    End Interface

'End Namespace
