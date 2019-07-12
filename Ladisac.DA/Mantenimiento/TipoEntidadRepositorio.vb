Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class TipoEntidadRepositorio
        Implements ITipoEntidadRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal TEN_Id As Integer) As BE.TipoEntidad Implements ITipoEntidadRepositorio.GetById
            Dim result As TipoEntidad = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.TipoEntidad Where c.TEN_ID = TEN_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaTipoEntidad() As String Implements ITipoEntidadRepositorio.ListaTipoEntidad
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaTipoEntidad")
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

        Public Sub Maintenance(ByVal TipoEntidad As BE.TipoEntidad) Implements ITipoEntidadRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.TipoEntidad.ApplyChanges(TipoEntidad)
                context.SaveChanges()
                TipoEntidad.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace


