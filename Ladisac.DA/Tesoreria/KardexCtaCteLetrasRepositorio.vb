Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class KardexCtaCteLetrasRepositorio
        Implements IKardexCtaCteLetrasRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.KardexCtaCteLetras) As Short Implements IKardexCtaCteLetrasRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.KardexCtaCteLetras.ApplyChanges(item)
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

        Public Function DeleteRegistro(ByVal item As BE.KardexCtaCteLetras) As Short Implements IKardexCtaCteLetrasRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.KardexCtaCteLetras Where c.CCT_ID_REF = item.CCT_ID_REF And c.TDO_ID_REF = item.TDO_ID_REF And c.DTD_ID_REF = item.DTD_ID_REF And c.DOC_SERIE_REF = item.DOC_SERIE_REF And c.DOC_NUMERO_REF = item.DOC_NUMERO_REF And c.ITEM_REF = item.ITEM_REF Select c).FirstOrDefault()
                item.MarkAsDeleted()
                DeleteRegistro = Maintenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                DeleteRegistro = 0
            End Try
        End Function

        Public Function spActualizarRegistro(ByVal Orm As KardexCtaCteLetras) As Short Implements IKardexCtaCteLetrasRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroKardexCtaCteLetras)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.CCT_ID_REF, DbType.String, Orm.CCT_ID_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.TDO_ID_REF, DbType.String, Orm.TDO_ID_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.DTD_ID_REF, DbType.String, Orm.DTD_ID_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.DOC_SERIE_REF, DbType.String, Orm.DOC_SERIE_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.DOC_NUMERO_REF, DbType.String, Orm.DOC_NUMERO_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.ITEM_REF, DbType.Int16, Orm.ITEM_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.DOC_NUMERO, DbType.String, Orm.DOC_NUMERO)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.KCL_FEC_GRAB, DbType.DateTime, Orm.KCL_FEC_GRAB)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.KCL_ESTADO, DbType.Boolean, Orm.KCL_ESTADO)
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

        Public Function spEliminarRegistro(ByVal Orm As KardexCtaCteLetras) As Short Implements IKardexCtaCteLetrasRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroKardexCtaCteLetras)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.CCT_ID_REF, DbType.String, Orm.CCT_ID_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.TDO_ID_REF, DbType.String, Orm.TDO_ID_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.DTD_ID_REF, DbType.String, Orm.DTD_ID_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.DOC_SERIE_REF, DbType.String, Orm.DOC_SERIE_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.DOC_NUMERO_REF, DbType.String, Orm.DOC_NUMERO_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.ITEM_REF, DbType.Int16, Orm.ITEM_REF)
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

        Public Function spInsertarRegistro(ByVal Orm As KardexCtaCteLetras) As Short Implements IKardexCtaCteLetrasRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroKardexCtaCteLetras)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.CCT_ID_REF, DbType.String, Orm.CCT_ID_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.TDO_ID_REF, DbType.String, Orm.TDO_ID_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.DTD_ID_REF, DbType.String, Orm.DTD_ID_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.DOC_SERIE_REF, DbType.String, Orm.DOC_SERIE_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.DOC_NUMERO_REF, DbType.String, Orm.DOC_NUMERO_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.ITEM_REF, DbType.Int16, Orm.ITEM_REF)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.DOC_NUMERO, DbType.String, Orm.DOC_NUMERO)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.KCL_FEC_GRAB, DbType.DateTime, Orm.KCL_FEC_GRAB)
                context.AddInParameter(cmd, KardexCtaCteLetras.PropertyNames.KCL_ESTADO, DbType.Boolean, Orm.KCL_ESTADO)
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
