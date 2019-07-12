Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    Public Class DetallePermisosTrabajadorRepositorio
        Implements IDetallePermisosTrabajadorRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal numero As String, ByVal item As String) As BE.DetallePermisosTrabajador Implements IDetallePermisosTrabajadorRepositorio.GetById
            Dim result As BE.DetallePermisosTrabajador = Nothing

            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.DetallePermisosTrabajador Where c.prm_Numero = numero And c.dper_Item = item Select c)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function


        Public Function Maintenance(ByVal item As BE.DetallePermisosTrabajador) As Object Implements IDetallePermisosTrabajadorRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.DetallePermisosTrabajador.ApplyChanges(item)
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
'    Public Class DetallePrestamosTrabajadorRepositorio
'        Implements IDetallePrestamosTrabajadorRepositorio
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function GetById(ByVal serie As String, ByVal numero As String, ByVal item As String) As BE.DetallePrestamosTrabajador Implements IDetallePrestamosTrabajadorRepositorio.GetById
'            Dim result As DetallePrestamosTrabajador = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.DetallePrestamosTrabajador _
'                           Where c.prt_SeriePres = serie And c.prt_NumeroPres = numero And c.dpt_ItemPresta = item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.DetallePrestamosTrabajador) As Boolean Implements IDetallePrestamosTrabajadorRepositorio.Maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.DetallePrestamosTrabajador.ApplyChanges(item)
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
