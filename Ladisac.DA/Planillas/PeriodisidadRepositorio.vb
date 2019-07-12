Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA
    Public Class PeriodisidadRepositorio
        Implements IPeriodisidadRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetId(ByVal id As String) As BE.Periodisidad Implements IPeriodisidadRepositorio.GetId

            Dim result As Periodisidad = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.Periodisidad Where c.pec_Periodisidad_Id = id Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Sub Mantenance(ByVal item As BE.Periodisidad) Implements IPeriodisidadRepositorio.Mantenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.Periodisidad.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

        End Sub
    End Class


End Namespace
