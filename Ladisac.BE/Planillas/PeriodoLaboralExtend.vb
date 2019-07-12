Imports Ladisac.BE

Partial Public Class PeriodoLaboral
    Public Function Clone() As BE.PeriodoLaboral
        Return DirectCast(Me.MemberwiseClone, PeriodoLaboral)
    End Function
End Class


'Imports Ladisac.BE

'Partial Public Class CronogramaVacaciones
'    Public Function Clone() As CronogramaVacaciones
'        Return DirectCast(Me.MemberwiseClone, CronogramaVacaciones)
'    End Function
'End Class