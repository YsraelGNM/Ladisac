Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class ChequesRepositorio
        Implements IChequesRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.Cheques) As Short Implements IChequesRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.Cheques.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Maintenance = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                Maintenance = 0
            End Try
        End Function

        Public Function spActualizarCorrelativo(ByVal Orm As BE.Cheques) As Short Implements IChequesRepositorio.spActualizarCorrelativo
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarCorrelativoCheques)
                context.AddInParameter(cmd, Cheques.PropertyNames.CHE_ID, DbType.String, Orm.CHE_ID)
                context.AddInParameter(cmd, Cheques.PropertyNames.CCC_ID, DbType.String, Orm.CCC_ID)
                context.AddInParameter(cmd, Cheques.PropertyNames.CHE_CORRELATIVO, DbType.Int32, Orm.CHE_CORRELATIVO)
                context.AddInParameter(cmd, Cheques.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, Cheques.PropertyNames.CHE_FEC_GRAB, DbType.DateTime, Orm.CHE_FEC_GRAB)
                context.AddInParameter(cmd, Cheques.PropertyNames.CHE_ESTADO, DbType.Boolean, Orm.CHE_ESTADO)
                context.ExecuteNonQuery(cmd)
                spActualizarCorrelativo = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarCorrelativo = 0
            End Try
        End Function
    End Class
End Namespace
