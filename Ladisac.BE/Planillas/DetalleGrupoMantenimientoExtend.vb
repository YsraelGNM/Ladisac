Imports Ladisac.BE

Partial Public Class DetalleGrupoMantenimiento
    Public Function Clone() As DetalleGrupoMantenimiento
        Return DirectCast(Me.MemberwiseClone, DetalleGrupoMantenimiento)

    End Function
End Class
