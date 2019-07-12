Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCKardexCtaCteDetracciones
        Implements IBCKardexCtaCteDetracciones


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro



        Public Function spActualizarEstadoRegistroDetracciones(ByVal cCCT_ID_REF As String, ByVal cTDO_ID_REF As String, ByVal cDTD_ID_REF As String, ByVal cDOC_SERIE_REF As String, ByVal cDOC_NUMERO_REF As String, ByVal cESTADO As Boolean) As Short Implements IBCKardexCtaCteDetracciones.spActualizarEstadoRegistroDetracciones
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IKardexCtaCteDetraccionesRepositorio)()
                    rep.spActualizarEstadoRegistroDetracciones(cCCT_ID_REF, cTDO_ID_REF, cDTD_ID_REF, cDOC_SERIE_REF, cDOC_NUMERO_REF, cESTADO)
                    Scope.Complete()
                    spActualizarEstadoRegistroDetracciones = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spActualizarEstadoRegistroDetracciones = 0
                End Try
            End Using
        End Function

        Public Function spListaDetracciones() As Object Implements IBCKardexCtaCteDetracciones.spListaDetracciones
            Dim result As DataTable = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spListaDetracciones)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function
    End Class
End Namespace
