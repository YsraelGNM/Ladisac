Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    Public Class DetalleComedorRepositorio
        Implements IDetalleComedorRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal numero As String, ByVal persona As String) As Object Implements IDetalleComedorRepositorio.GetById
            Dim result As BE.DetalleComedorPLL = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.DetalleComedorPLL Where c.com_Numero = numero And c.per_id = persona Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.DetalleComedorPLL) As Object Implements IDetalleComedorRepositorio.Maintenance
            Try

                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.DetalleComedorPLL.ApplyChanges(item)
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