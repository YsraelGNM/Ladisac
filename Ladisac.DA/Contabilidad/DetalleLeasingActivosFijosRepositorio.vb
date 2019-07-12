Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DetalleLeasingActivosFijosRepositorio
        Implements IDetalleLeasingActivosFijosRepositorio


        <Dependency()> _
        Public Property ContainserService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.DetalleLeasingActivosFijos) As Object Implements IDetalleLeasingActivosFijosRepositorio.Maintenance
            Dim result As BE.DetalleLeasingActivosFijos = Nothing
            Try
                Dim context = ContainserService.Resolve(Of LadisacEntities)()
                context.DetalleLeasingActivosFijos.ApplyChanges(item)
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

