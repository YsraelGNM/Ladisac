Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlPaqueteoRepositorio
        Function GetById(ByVal PQT_ID As Integer) As ControlPaqueteo
        Function GetByPro_Id(ByVal PRO_ID As Integer) As ControlPaqueteo
        Sub Maintenance(ByVal ControlPaqueteo As ControlPaqueteo)
        Function ListaControlPaqueteo(ByVal FecIni As Date, ByVal FecFin As Date) As String
    End Interface

End Namespace

