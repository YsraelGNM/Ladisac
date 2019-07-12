
Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA

    Public Class DetalleLeasingRepositorio
        Implements IDetalleLeasingRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As Ladisac.BE.DetalleLeasing) As Object Implements IDetalleLeasingRepositorio.Maintenance
            Dim result As BE.DetalleLeasing = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.DetalleLeasing.ApplyChanges(item)
                context.SaveChanges()
                context.AcceptAllChanges()
                Return True
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


'Imports Microsoft.Practices.Unity
'Imports Ladisac.BE
'Imports System.Text
'Namespace Ladisac.DA

'    Public Class DetalleProvisionComprasRepositorio
'        Implements IDetalleProvisionComprasRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function Maintenance(ByVal item As BE.DetalleProvisionCompras) As Object Implements IDetalleProvisionComprasRepositorio.Maintenance
'            Dim result As BE.DetalleProvisionCompras = Nothing

'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.DetalleProvisionCompras.ApplyChanges(item)
'                context.SaveChanges()
'                context.AcceptAllChanges()
'                Return True

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
