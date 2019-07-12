Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class OrdenTrabajoRepositorio
        Implements IOrdenTrabajoRepositorio


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal OTR_Id As Integer) As BE.OrdenTrabajo Implements IOrdenTrabajoRepositorio.GetById
            Dim result As OrdenTrabajo = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.OrdenTrabajo.Include("OrdenTrabajoPersonal.Personas").Include("Entidad").Include("Mantto").Include("Personas").Include("Personas1").Include("Personas2").Include("OrdenTrabajoEntidad.Entidad").Include("OrdenTrabajoEntidad.Mantto") Where c.OTR_ID = OTR_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaOrdenTrabajo() As String Implements IOrdenTrabajoRepositorio.ListaOrdenTrabajo
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenTrabajo")
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

        Public Sub Maintenance(ByVal OrdenTrabajo As BE.OrdenTrabajo) Implements IOrdenTrabajoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.OrdenTrabajo.ApplyChanges(OrdenTrabajo)
                context.SaveChanges()
                OrdenTrabajo.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaOrdenTrabajoOR(ByVal OTR_ID As Integer?) As System.Data.DataSet Implements IOrdenTrabajoRepositorio.ListaOrdenTrabajoOR
            Dim result As New DataSet
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaOrdenTrabajoORR", OTR_ID)
                result = context.ExecuteDataSet(cmd)
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


