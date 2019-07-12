Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCReferenciaProvisionCompras
        Implements IBCReferenciaProvisionCompras
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.ReferenciaProvisionCompras) As Object Implements IBCReferenciaProvisionCompras.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReferenciaProvisionComprasRepositorio)()

                Return rep.Maintenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False
        End Function
    End Class

End Namespace


'Imports Ladisac.BE

'Namespace Ladisac.BL

'    Public Class BCDetalleProvisionCompras
'        Implements IBCDetalleProvisionCompras

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function Maintenance(ByVal item As BE.DetalleProvisionCompras) As Object Implements IBCDetalleProvisionCompras.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IDetalleProvisionComprasRepositorio)()
'                Return rep.Maintenance(item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return False
'        End Function
'    End Class

'End Namespace