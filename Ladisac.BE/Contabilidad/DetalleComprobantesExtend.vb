Imports Ladisac.BE


Partial Public Class DetalleComprobantes
    Public Function Clone()
        Return DirectCast(Me.MemberwiseClone, BE.DetalleComprobantes)
    End Function

End Class


