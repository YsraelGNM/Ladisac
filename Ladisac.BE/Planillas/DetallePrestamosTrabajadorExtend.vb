Imports Ladisac.BE

Partial Public Class DetallePrestamosTrabajador
    Public Function Clone() As DetallePrestamosTrabajador
        Return DirectCast(Me.MemberwiseClone(), DetallePrestamosTrabajador)

    End Function

End Class
