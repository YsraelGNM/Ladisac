Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCMaestro
        Implements IBCMaestro

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function EjecutarVista(ByVal vista As String, ByVal ParamArray params() As Object) As String Implements IBCMaestro.EjecutarVista
            EjecutarVista = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMaestroRepositorio)()
                EjecutarVista = rep.EjecutarVista(vista, params)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
            End Try
        End Function

        Public Sub MantenimientoMonedas(ByVal Item As BE.Moneda) Implements IBCMaestro.MantenimientoMonedas
        End Sub

        Public Sub MantenimientoMonedasDescripcion(ByVal id As String, ByVal descripcion As String) Implements IBCMaestro.MantenimientoMonedasDescripcion
        End Sub

        Public Function EjecutarPendienteAtencion(ByVal Procedimiento As String, ByVal ParamArray params() As Object) As String Implements IBCMaestro.EjecutarPendienteAtencion
            EjecutarPendienteAtencion = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMaestroRepositorio)()
                EjecutarPendienteAtencion = rep.EjecutarPendientesAtencion(Procedimiento, params)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
            End Try
        End Function
    End Class
End Namespace
