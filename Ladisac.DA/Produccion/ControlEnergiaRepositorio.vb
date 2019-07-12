Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class ControlEnergiaRepositorio
        Implements IControlEnergiaRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal CEN_ID As Integer) As BE.ControlEnergia Implements IControlEnergiaRepositorio.GetById
            Dim result As ControlEnergia = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ControlEnergia Where c.CEN_ID = CEN_ID Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlEnergia() As String Implements IControlEnergiaRepositorio.ListaControlEnergia
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaControlEnergia")
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

        Public Sub Maintenance(ByVal ControlEnergia As BE.ControlEnergia) Implements IControlEnergiaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ControlEnergia.ApplyChanges(ControlEnergia)
                context.SaveChanges()
                ControlEnergia.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class
End Namespace

