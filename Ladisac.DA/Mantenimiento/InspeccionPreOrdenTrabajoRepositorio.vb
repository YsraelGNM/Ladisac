Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class InspeccionPreOrdenTrabajoRepositorio
        Implements IInspeccionPreOrdenTrabajoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal IOT_Id As Integer) As BE.InspeccionPreOrdenTrabajo Implements IInspeccionPreOrdenTrabajoRepositorio.GetById
            Dim result As InspeccionPreOrdenTrabajo = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.InspeccionPreOrdenTrabajo.Include("Entidad") Where c.IOT_ID = IOT_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaInspeccionPreOrdenTrabajo() As String Implements IInspeccionPreOrdenTrabajoRepositorio.ListaInspeccionPreOrdenTrabajo
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaInspeccionPreOrdenTrabajo")
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

        Public Sub Maintenance(ByVal InspeccionPreOrdenTrabajo As BE.InspeccionPreOrdenTrabajo) Implements IInspeccionPreOrdenTrabajoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.InspeccionPreOrdenTrabajo.ApplyChanges(InspeccionPreOrdenTrabajo)
                context.SaveChanges()
                InspeccionPreOrdenTrabajo.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace


