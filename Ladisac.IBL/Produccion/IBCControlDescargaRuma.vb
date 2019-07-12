Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCControlDescargaRuma

#Region "Mantenimientos"
        Sub MantenimientoControlDescargaRuma(ByVal mControlDescargaRuma As ControlDescargaRuma)
#End Region

#Region "Querys"
        Function ControlDescargaRumaGetById(ByVal DRU_ID As Integer) As ControlDescargaRuma
        Function ListaControlDescargaRuma() As String
        Function ListaDesHorProcesar() As String
        Function ListaReciclajeVentaLadrillo(ByVal Fecha As Date) As String
        Function ListaReciclajeVentaLadrilloDespacho(ByVal FecIni As Date, ByVal FecFin As Date) As String
        Function ListaReciclajeDespachoLadrillo(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Nullable(Of Integer)) As String
        Function spInterfase_DescargaHorno(ByVal DRU_ID As Integer) As String
#End Region

    End Interface

End Namespace
