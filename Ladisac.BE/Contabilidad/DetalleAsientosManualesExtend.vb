Imports Ladisac.BE

Partial Public Class DetalleAsientosManuales
    Public Function Clone() As DetalleAsientosManuales
        Return DirectCast(Me.MemberwiseClone, BE.DetalleAsientosManuales)
    End Function
End Class


'Imports Ladisac.BE

'Partial Public Class CronogramaVacaciones
'    Public Function Close() As CronogramaVacaciones
'        Return DirectCast(Me.MemberwiseClone, CronogramaVacaciones)
'    End Function
'End Class
