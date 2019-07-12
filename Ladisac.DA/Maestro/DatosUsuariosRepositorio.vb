Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DatosUsuariosRepositorio
        Implements IDatosUsuariosRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.DatosUsuarios) As Short Implements IDatosUsuariosRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DatosUsuarios.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Maintenance = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                Maintenance = 0
            End Try
        End Function
        Public Function DeleteRegistro(ByVal item As BE.DatosUsuarios, ByVal cDAU_ID As String) As Short Implements IDatosUsuariosRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.DatosUsuarios Where c.DAU_ID = cDAU_ID Select c).FirstOrDefault()
                item.MarkAsDeleted()
                DeleteRegistro = Maintenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                DeleteRegistro = 0
            End Try
        End Function

        Public Function GetById(ByVal DAU_Id As String) As BE.DatosUsuarios Implements IDatosUsuariosRepositorio.GetById
            Dim result As DatosUsuarios = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DatosUsuarios.Include("Personas") Where c.DAU_ID = DAU_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetByIdByUSU(ByVal USU_Id As String) As BE.DatosUsuarios Implements IDatosUsuariosRepositorio.GetByIdByUSU
            Dim result As DatosUsuarios = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DatosUsuarios.Include("Personas") Where c.USU_ID.Trim = USU_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetByIdByPER(ByVal PER_Id As String) As BE.DatosUsuarios Implements IDatosUsuariosRepositorio.GetByIdByPER
            Dim result As DatosUsuarios = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DatosUsuarios.Include("Personas") Where c.PER_ID.Trim = PER_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
    End Class
End Namespace
