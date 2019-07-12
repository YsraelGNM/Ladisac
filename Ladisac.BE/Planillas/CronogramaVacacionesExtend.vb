Imports Ladisac.BE

Partial Public Class CronogramaVacaciones
    Public Function Clone() As CronogramaVacaciones
        Return DirectCast(Me.MemberwiseClone, CronogramaVacaciones)
    End Function
End Class

'Imports Ladisac.BE

'Partial Public Class DetalleGrupoTrabajo
'    Public Function Close() As DetalleGrupoTrabajo
'        Return DirectCast(Me.MemberwiseClone, DetalleGrupoTrabajo)
'    End Function
'End Class
