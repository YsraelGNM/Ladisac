
Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCDetalleTrabajadorHoras
        Implements IBCDetalleTrabajadorHoras
        <Dependency()> _
        Public Property ContainerService As IUnityContainer



        Public Function maintenance(ByVal item As BE.DetalleTrabajadorHoras) As Object Implements IBCDetalleTrabajadorHoras.maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleTrabajadorHorasRepositorio)()
                Return rep.Maintenance(item)

            Catch ex As Exception
                Dim rethorw = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethorw) Then
                    Throw
                End If
            End Try
            Return False
        End Function
    End Class
End Namespace



