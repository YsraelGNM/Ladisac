Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class PlanCargaDescargaHornoRepositorio
        Implements IPlanCargaDescargaHornoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal CDH_ID As Integer) As BE.PlanCargaDescargaHorno Implements IPlanCargaDescargaHornoRepositorio.GetById
            Dim result As PlanCargaDescargaHorno = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.PlanCargaDescargaHorno.Include("Entidad").Include("Entidad1").Include("Entidad2").Include("Entidad3").Include("Produccion.Ladrillo.Articulos").Include("Produccion.Planta") Where c.CDH_ID = CDH_ID Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaPlanCargaDescargaHorno() As String Implements IPlanCargaDescargaHornoRepositorio.ListaPlanCargaDescargaHorno
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaPlanCargaDescargaHorno")
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

        Public Sub Maintenance(ByVal PlanCargaDescargaHorno As BE.PlanCargaDescargaHorno) Implements IPlanCargaDescargaHornoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.PlanCargaDescargaHorno.ApplyChanges(PlanCargaDescargaHorno)
                context.SaveChanges()
                PlanCargaDescargaHorno.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace


