Imports Ladisac.BE

Partial Public Class DatosLaborales
    Public Function Clone() As DatosLaborales
        Return DirectCast(Me.MemberwiseClone, DatosLaborales)
    End Function

End Class
