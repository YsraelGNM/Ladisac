Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class UnidadMedidaRepositorio
        Implements IUnidadMedidaRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaUnidadMedida() As String Implements IUnidadMedidaRepositorio.ListaUnidadMedida
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaUnidadMedida")
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

        Public Function GetById(ByVal UM_Id As String) As BE.UnidadMedidaArticulos Implements IUnidadMedidaRepositorio.GetById
            Dim result As UnidadMedidaArticulos = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.UnidadMedidaArticulos Where c.UM_ID = UM_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal UnidadMedida As BE.UnidadMedidaArticulos) Implements IUnidadMedidaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.UnidadMedidaArticulos.ApplyChanges(UnidadMedida)
                context.SaveChanges()
                UnidadMedida.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace


