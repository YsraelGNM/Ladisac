Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class CorrelativoTipoDocumentoRepositorio
        Implements ICorrelativoTipoDocumentoRepositorio

        <Dependency()> _
                Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.CorrelativoTipoDocumento) As Short Implements ICorrelativoTipoDocumentoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.CorrelativoTipoDocumento.ApplyChanges(item)
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

        Public Function spActualizarRegistro(ByVal Orm As CorrelativoTipoDocumento) As Short Implements ICorrelativoTipoDocumentoRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroCorrelativoTipoDocumento)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.PVE_ID, DbType.String, Orm.PVE_ID)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.CTD_COR_SERIE, DbType.String, Orm.CTD_COR_SERIE)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.CTD_COR_NUMERO, DbType.Int32, Orm.CTD_COR_NUMERO)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.CTD_USAR_COR, DbType.Boolean, Orm.CTD_COR_NUMERO)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.CTD_FEC_GRAB, DbType.DateTime, Orm.CTD_FEC_GRAB)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.CTD_ESTADO, DbType.Boolean, Orm.CTD_ESTADO)
                context.ExecuteNonQuery(cmd)
                spActualizarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarRegistro = 0
            End Try
        End Function

        Public Function spEliminarRegistro(ByVal Orm As CorrelativoTipoDocumento) As Short Implements ICorrelativoTipoDocumentoRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroCorrelativoTipoDocumento)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.CTD_COR_SERIE, DbType.String, Orm.CTD_COR_SERIE)
                context.ExecuteNonQuery(cmd)
                spEliminarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarRegistro = 0
            End Try
        End Function

        Public Function spInsertarRegistro(ByVal Orm As CorrelativoTipoDocumento) As Short Implements ICorrelativoTipoDocumentoRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroCorrelativoTipoDocumento)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.PVE_ID, DbType.String, Orm.PVE_ID)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.CTD_COR_SERIE, DbType.String, Orm.CTD_COR_SERIE)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.CTD_COR_NUMERO, DbType.Int16, Orm.CTD_COR_NUMERO)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.CTD_USAR_COR, DbType.Boolean, Orm.CTD_COR_NUMERO)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.CTD_FEC_GRAB, DbType.DateTime, Orm.CTD_FEC_GRAB)
                context.AddInParameter(cmd, CorrelativoTipoDocumento.PropertyNames.CTD_ESTADO, DbType.Boolean, Orm.CTD_ESTADO)
                context.ExecuteNonQuery(cmd)
                spInsertarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spInsertarRegistro = 0
            End Try
        End Function
    End Class
End Namespace
