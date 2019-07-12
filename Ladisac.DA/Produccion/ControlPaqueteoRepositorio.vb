Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ControlPaqueteoRepositorio
        Implements IControlPaqueteoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal PQT_ID As Integer) As BE.ControlPaqueteo Implements IControlPaqueteoRepositorio.GetById
            Dim result As ControlPaqueteo = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ControlPaqueteo Where c.PQT_ID = PQT_ID Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlPaqueteo(ByVal FecIni As Date, ByVal FecFin As Date) As String Implements IControlPaqueteoRepositorio.ListaControlPaqueteo
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaControlPaqueteo")
                context.AddInParameter(cmd, "FecIni", DbType.Date, FecIni)
                context.AddInParameter(cmd, "FecFin", DbType.Date, FecFin)
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

        Public Sub Maintenance(ByVal ControlPaqueteo As BE.ControlPaqueteo) Implements IControlPaqueteoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.ControlPaqueteo.ApplyChanges(ControlPaqueteo)
                context.SaveChanges()
                ControlPaqueteo.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function GetByPro_Id(ByVal PRO_ID As Integer) As BE.ControlPaqueteo Implements IControlPaqueteoRepositorio.GetByPro_Id
            Dim result As ControlPaqueteo = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.ControlPaqueteo Where c.PRO_ID = PRO_ID Select c).FirstOrDefault
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


