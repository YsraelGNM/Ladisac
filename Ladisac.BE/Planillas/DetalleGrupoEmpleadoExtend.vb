

Imports Ladisac.BE

Partial Public Class DetalleGrupoEmpleado
    Public Function Clone() As DetalleGrupoEmpleado
        Return DirectCast(Me.MemberwiseClone, DetalleGrupoEmpleado)

    End Function
End Class

