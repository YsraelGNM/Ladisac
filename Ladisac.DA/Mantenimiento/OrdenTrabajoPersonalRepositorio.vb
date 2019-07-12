Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class OrdenTrabajoPersonalRepositorio
        Implements IOrdenTrabajoPersonalRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaOrdenTrabajoPersonal() As String Implements IOrdenTrabajoPersonalRepositorio.ListaOrdenTrabajoPersonal
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenTrabajoPersonal")
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

        Public Sub Maintenance(ByVal OrdenTrabajoPersonal As BE.OrdenTrabajoPersonal) Implements IOrdenTrabajoPersonalRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.OrdenTrabajoPersonal.ApplyChanges(OrdenTrabajoPersonal)
                context.SaveChanges()
                OrdenTrabajoPersonal.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function GetById(ByVal OTP_Id As Integer) As BE.OrdenTrabajoPersonal Implements IOrdenTrabajoPersonalRepositorio.GetById
            Dim result As OrdenTrabajoPersonal = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.OrdenTrabajoPersonal Where c.OTP_ID = OTP_Id Select c).FirstOrDefault
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


