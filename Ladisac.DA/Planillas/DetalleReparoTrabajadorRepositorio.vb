Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class DetalleReparoTrabajadorRepositorio
        Implements IDetalleReparoTrabajadorRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal numero As String, ByVal item As String) As BE.DetalleReparoTrabajador Implements IDetalleReparoTrabajadorRepositorio.GetById
            Dim result As BE.DetalleReparoTrabajador = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.DetalleReparoTrabajador Where c.ret_Numero = numero And c.dret_Item = item Select c).FirstOrDefault

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function maintenance(ByVal item As BE.DetalleReparoTrabajador) As Object Implements IDetalleReparoTrabajadorRepositorio.maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.DetalleReparoTrabajador.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
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
'    Public Class DetallePermisosTrabajadorRepositorio
'        Implements IDetallePermisosTrabajadorRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function GetById(ByVal numero As String, ByVal item As String) As BE.DetallePermisosTrabajador Implements IDetallePermisosTrabajadorRepositorio.GetById
'            Dim result As BE.DetallePermisosTrabajador = Nothing

'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.DetallePermisosTrabajador Where c.prm_Numero = numero And c.dper_Item = item Select c)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function


'        Public Function Maintenance(ByVal item As BE.DetallePermisosTrabajador) As Object Implements IDetallePermisosTrabajadorRepositorio.Maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.DetallePermisosTrabajador.ApplyChanges(item)
'                context.SaveChanges()
'                item.AcceptChanges()
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
