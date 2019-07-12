Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ICaCoDeDetalleRepositorio
        Function GetById(ByVal CCD_Id As Integer) As CaCoDe_Detalle
        Sub Maintenance(ByVal CaCoDeDetalle As CaCoDe_Detalle)
        Function ListaCaCoDeDetalle(ByVal Dia As Date, ByVal HOR_ID As Integer) As String
        Function ListaCaCoDeDetalleObj(ByVal Dia As Date, ByVal HOR_ID As Integer) As ICollection(Of CaCoDe_Detalle)
        Function ValidarCarga(ByVal PRO_ID As Integer) As DataSet
    End Interface

End Namespace

