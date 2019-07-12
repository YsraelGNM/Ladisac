Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    

    Public Class TipoParadasRepositorio
        Implements ITipoParadasRepositorio


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal TPA_Id As Integer) As BE.TipoParada Implements ITipoParadasRepositorio.GetById
            Dim result As TipoParada = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.TipoParada Where c.TPA_ID = TPA_Id Select c).FirstOrDefault
                'context.LoadProperty(result, "ParadasTipos")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal TipoParada As BE.TipoParada) Implements ITipoParadasRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.TipoParada.ApplyChanges(TipoParada)
                context.SaveChanges()
                TipoParada.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaTipoParada(ByVal TPA_ID As Integer) As String Implements ITipoParadasRepositorio.ListaTipoParada
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaTipoParada")
                context.AddInParameter(cmd, "TPA_ID", DbType.Int16, TPA_ID)
                Dim reader = context.ExecuteReader(cmd)
                Dim sb As New StringBuilder()
                While reader.Read()
                    sb.Append(reader.GetString(0))
                End While
                result = sb.ToString()

                'Dim context = ContainerService.Resolve(Of LadisacEntities)()
                'result = context.spListaTipoParada(TPA_ID).FirstOrDefault

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
