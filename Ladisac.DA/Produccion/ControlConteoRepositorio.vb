Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ControlConteoRepositorio
        Implements IControlConteoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal CCO_Id As Integer) As BE.ControlConteo Implements IControlConteoRepositorio.GetById
            Dim result As ControlConteo = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ControlConteo.Include("ControlConteoDetalle.Cancha").Include("Personas").Include("Produccion.Ladrillo.Articulos") Where c.CCO_ID = CCO_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlConteo() As String Implements IControlConteoRepositorio.ListaControlConteo
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaControlConteo")
                Dim reader = context.ExecuteReader(cmd)
                Dim sb As New StringBuilder()
                While reader.Read()
                    sb.Append(reader.GetString(0))
                End While
                result = sb.ToString()

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal ControlConteo As BE.ControlConteo) Implements IControlConteoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ControlConteo.ApplyChanges(ControlConteo)
                context.SaveChanges()
                ControlConteo.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function GetByIdPRO(ByVal PRO_Id As Integer) As BE.ControlConteo Implements IControlConteoRepositorio.GetByIdPRO
            Dim result As ControlConteo = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ControlConteo.Include("ControlConteoDetalle.Cancha").Include("Personas").Include("Produccion.Ladrillo.Articulos") Where c.PRO_ID = PRO_Id Select c).FirstOrDefault
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


