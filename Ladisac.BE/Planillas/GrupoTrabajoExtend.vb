Imports Ladisac.BE

Partial Public Class GrupoTrabajo
    Public Function Clone() As GrupoTrabajo
        Return DirectCast(Me.MemberwiseClone, GrupoTrabajo)

    End Function
End Class