Imports Microsoft.Practices.Unity
Imports Ladisac.BE


Namespace Ladisac.DA
    Public Class DatosLaboralesHorarioRepositorio
        Implements IDatosLaboralesHorarioRepositorio


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function getById(ByVal per_Id As String, ByVal crv_ItemCroVaca As String) As BE.DatosLaboralesHorario Implements IDatosLaboralesHorarioRepositorio.getById
            Dim result As BE.DatosLaboralesHorario = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.DatosLaboralesHorario Where c.per_Id = per_Id And c.dah_item = crv_ItemCroVaca Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Mantenace(ByVal item As BE.DatosLaboralesHorario) As Boolean Implements IDatosLaboralesHorarioRepositorio.Mantenace
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DatosLaboralesHorario.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False
        End Function
    End Class
End Namespace

