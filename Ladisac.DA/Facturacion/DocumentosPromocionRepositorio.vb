Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DocumentosPromocionRepositorio
        Implements IDocumentosPromocionRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.DocumentosPromocion) As Short Implements IDocumentosPromocionRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DocumentosPromocion.ApplyChanges(item)
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
        Public Function DeleteRegistro(ByVal item As BE.DocumentosPromocion, ByVal cDPR_NUMERO As String, ByVal cDPR_TIPO_PROMOCION As String) As Short Implements IDocumentosPromocionRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.DocumentosPromocion Where c.DPR_NUMERO = cDPR_NUMERO And c.DPR_TIPO_PROMOCION = cDPR_TIPO_PROMOCION Select c).FirstOrDefault()
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

        Public Function spActualizarRegistro(ByVal Orm As BE.DocumentosPromocion) As Short Implements IDocumentosPromocionRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroDocumentosPromocion)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.DPR_NUMERO, DbType.String, Orm.DPR_NUMERO)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.DPR_TIPO_PROMOCION, DbType.Int16, Orm.DPR_TIPO_PROMOCION)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.DPR_FECHA, DbType.Date, Orm.DPR_FECHA)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.PER_ID_PRO, DbType.String, Orm.PER_ID_PRO)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.DPR_FEC_GRAB, DbType.DateTime, Orm.DPR_FEC_GRAB)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.DPR_ESTADO, DbType.Boolean, Orm.DPR_ESTADO)
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

        Public Function spEliminarRegistro(ByVal Orm As BE.DocumentosPromocion) As Short Implements IDocumentosPromocionRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroDocumentosPromocion)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.DPR_NUMERO, DbType.String, Orm.DPR_NUMERO)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.DPR_TIPO_PROMOCION, DbType.Int16, Orm.DPR_TIPO_PROMOCION)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
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

        Public Function spInsertarRegistro(ByVal Orm As BE.DocumentosPromocion) As Short Implements IDocumentosPromocionRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroDocumentosPromocion)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.DPR_NUMERO, DbType.String, Orm.DPR_NUMERO)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.DPR_TIPO_PROMOCION, DbType.Int16, Orm.DPR_TIPO_PROMOCION)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.DPR_FECHA, DbType.Date, Orm.DPR_FECHA)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.PER_ID_PRO, DbType.String, Orm.PER_ID_PRO)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.DPR_FEC_GRAB, DbType.DateTime, Orm.DPR_FEC_GRAB)
                context.AddInParameter(cmd, DocumentosPromocion.PropertyNames.DPR_ESTADO, DbType.Boolean, Orm.DPR_ESTADO)
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
