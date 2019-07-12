Imports Ladisac.BL
Namespace Ladisac.BL
    Public Class BCDetalleLeasing
        Implements IBCDetalleLeasing
        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function Maintenance(ByVal item As BE.DetalleLeasing) As Object Implements IBCDetalleLeasing.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleLeasingRepositorio)()
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



'Imports Ladisac.BL

'Namespace Ladisac.BL

'    Public Class BCDetalleComprobantes
'        Implements IBCDetalleComprobantes

'        <Dependency()> _
'        Public Property ContainserService As IUnityContainer


'        Public Function Maintenance(ByVal item As BE.DetalleComprobantes) As Object Implements IBCDetalleComprobantes.Maintenance
'            Try
'                Dim rep = ContainserService.Resolve(Of DA.IDetalleComprobantesRepositorio)()
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
