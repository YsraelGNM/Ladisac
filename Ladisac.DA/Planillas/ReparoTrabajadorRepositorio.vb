Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ReparoTrabajadorRepositorio
        Implements IReparoTrabajadorRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal numero As String) As BE.ReparoTrabajador Implements IReparoTrabajadorRepositorio.GetById
            Dim result As BE.ReparoTrabajador = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.ReparoTrabajador _
                          .Include("Personas") _
                          .Include("DetalleReparoTrabajador") _
                          .Include("DetalleReparoTrabajador.Personas") _
                          .Include("DetalleReparoTrabajador.Personas.DatosLaborales") Where c.ret_Numero = numero Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.ReparoTrabajador) As Object Implements IReparoTrabajadorRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.ReparoTrabajador.ApplyChanges(item)
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
'    Public Class PermisosTrabajadorRepositorio
'        Implements IPermisosTrabajadorRepositorio


'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer



'        Public Function GetbyId(ByVal numero As String) As BE.PermisosTrabajador Implements IPermisosTrabajadorRepositorio.GetbyId
'            Dim result As PermisosTrabajador = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.PermisosTrabajador.Include("Personas").Include("Personas1").Include("DetallePermisosTrabajador") Where c.prm_Numero = numero Select c).FirstOrDefault
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function

'        Public Function Maintenance(ByVal item As BE.PermisosTrabajador) As Object Implements IPermisosTrabajadorRepositorio.Maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.PermisosTrabajador.ApplyChanges(item)
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
