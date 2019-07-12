Imports Ladisac.BE
Imports Microsoft.Practices.Unity

Namespace Ladisac.DA

    Public Class TiposConceptosRepositorio
        Implements ITiposConceptosRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function GetById(ByVal id As String) As BE.TiposConceptos Implements ITiposConceptosRepositorio.GetById
            Dim result As TiposConceptos = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.TiposConceptos Where c.tic_TipoConcep_Id = id Select c).FirstOrDefault()
                ' context.LoadProperty(result, "Documentos")

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result

        End Function

        Public Sub Maintenance(ByVal item As BE.TiposConceptos) Implements ITiposConceptosRepositorio.Maintenance

            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.TiposConceptos.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.DataAccess)
                If (rethrow) Then
                    Throw
                End If
            End Try

        End Sub

        Public Sub ModificarDescripcion(ByVal Id As String, ByVal descripcion As String, ByVal usuario As String) Implements ITiposConceptosRepositorio.ModificarDescripcion

            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

                Dim cmd = context.GetStoredProcCommand(DA.SPNames.SPTiposConceptosUpdate)
                context.AddInParameter(cmd, TiposConceptos.PropertyNames.tic_TipoConcep_Id, DbType.String, Id)
                context.AddInParameter(cmd, TiposConceptos.PropertyNames.tic_Descripcion, DbType.String, descripcion)
                context.AddInParameter(cmd, TiposConceptos.PropertyNames.Usu_Id, DbType.String, usuario)
                context.ExecuteNonQuery(cmd)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.DataAccess)
                If (rethrow) Then
                    Throw
                End If

            End Try


        End Sub
    End Class
End Namespace
