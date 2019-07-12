Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class SuministroPlanManttoRepositorio
        Implements ISuministroPlanManttoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal SPM_Id As Integer) As BE.SuministroPlanMantto Implements ISuministroPlanManttoRepositorio.GetById
            Dim result As SuministroPlanMantto = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.SuministroPlanMantto.Include("Articulos") Where c.SPM_ID = SPM_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaSuministroPlanMantto() As String Implements ISuministroPlanManttoRepositorio.ListaSuministroPlanMantto
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaSuministroPlanMantto")
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

        Public Sub Maintenance(ByVal SuministroPlanMantto As BE.SuministroPlanMantto) Implements ISuministroPlanManttoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.SuministroPlanMantto.ApplyChanges(SuministroPlanMantto)
                context.SaveChanges()
                SuministroPlanMantto.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace


