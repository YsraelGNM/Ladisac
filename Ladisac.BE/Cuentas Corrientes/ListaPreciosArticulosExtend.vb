﻿Imports Ladisac.BE
        Try
            Dim oVerificarDatos As New ErrorData
            oVerificarDatos = VerificarDatos(Parametros)
            If oVerificarDatos.NumeroError = 0 Then
                vMensajeError = oVerificarDatos.MensajeGeneral
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            vMensajeError = ex.Message
            Return 0
        End Try
    End Function