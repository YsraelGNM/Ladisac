Imports Ladisac.BE


Partial Public Class DetalleProvisionCompras
    Public Function Clone()
        Return DirectCast(Me.MemberwiseClone, BE.DetalleProvisionCompras)
    End Function

End Class


'Imports Ladisac.BE

'Partial Public Class DetalleAsientosManuales
'    Public Function Clone() As DetalleAsientosManuales
'        Return DirectCast(Me.MemberwiseClone, BE.DetalleAsientosManuales)
'    End Function
'End Class