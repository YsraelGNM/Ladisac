Imports Ladisac.BE

Partial Public Class DetalleGrupoTrabajo
    Public Function Clone() As DetalleGrupoTrabajo
        Return DirectCast(Me.MemberwiseClone, DetalleGrupoTrabajo)

    End Function
End Class


'Imports Ladisac.BE
'Partial Public Class DetalleTrabajadorJudicial

'    Public Function Clone() As DetalleTrabajadorJudicial
'        Return DirectCast(Me.MemberwiseClone(), DetalleTrabajadorJudicial)
'    End Function

'End Class
