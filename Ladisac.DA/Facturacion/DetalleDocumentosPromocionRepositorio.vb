Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DetalleDocumentosPromocionRepositorio
        Implements IDetalleDocumentosPromocionRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.DetalleDocumentosPromocion) As Short Implements IDetalleDocumentosPromocionRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DetalleDocumentosPromocion.ApplyChanges(item)
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

        Public Function spActualizarRegistro(ByVal Orm As BE.DetalleDocumentosPromocion) As Short Implements IDetalleDocumentosPromocionRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroDetalleDocumentosPromocion)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_NUMERO, DbType.String, Orm.DDP_NUMERO)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_TIPO_PROMOCION, DbType.Int16, Orm.DDP_TIPO_PROMOCION)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_ITEM, DbType.Int16, Orm.DDP_ITEM)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.TDO_ID_DOC, DbType.String, Orm.TDO_ID_DOC)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DTD_ID_DOC, DbType.String, Orm.DTD_ID_DOC)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.CCT_ID_DOC, DbType.String, Orm.CCT_ID_DOC)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_SERIE_DOC, DbType.String, Orm.DDP_SERIE_DOC)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_NUMERO_DOC, DbType.String, Orm.DDP_NUMERO_DOC)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.ART_ID, DbType.String, Orm.ART_ID)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_PUNTOS, DbType.Double, Orm.DDP_PUNTOS)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_PUNTOS_CONTROL, DbType.Double, Orm.DDP_PUNTOS_CONTROL)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_FEC_GRAB, DbType.DateTime, Orm.DDP_FEC_GRAB)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_ESTADO, DbType.Boolean, Orm.DDP_ESTADO)
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

        Public Function spInsertarRegistro(ByVal Orm As BE.DetalleDocumentosPromocion) As Short Implements IDetalleDocumentosPromocionRepositorio.spInsertarRegistro
            Try

                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroDetalleDocumentosPromocion)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_NUMERO, DbType.String, Orm.DDP_NUMERO)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_TIPO_PROMOCION, DbType.Int16, Orm.DDP_TIPO_PROMOCION)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_ITEM, DbType.Int16, Orm.DDP_ITEM)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.TDO_ID_DOC, DbType.String, Orm.TDO_ID_DOC)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DTD_ID_DOC, DbType.String, Orm.DTD_ID_DOC)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.CCT_ID_DOC, DbType.String, Orm.CCT_ID_DOC)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_SERIE_DOC, DbType.String, Orm.DDP_SERIE_DOC)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_NUMERO_DOC, DbType.String, Orm.DDP_NUMERO_DOC)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.ART_ID, DbType.String, Orm.ART_ID)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_PUNTOS, DbType.Double, Orm.DDP_PUNTOS)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_PUNTOS_CONTROL, DbType.Double, Orm.DDP_PUNTOS_CONTROL)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_FEC_GRAB, DbType.DateTime, Orm.DDP_FEC_GRAB)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_ESTADO, DbType.Boolean, Orm.DDP_ESTADO)
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

        Public Function spEliminarRegistro(ByVal Orm As BE.DetalleDocumentosPromocion) As Short Implements IDetalleDocumentosPromocionRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroDetalleDocumentosPromocion)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_NUMERO, DbType.String, Orm.DDP_NUMERO)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_TIPO_PROMOCION, DbType.Int16, Orm.DDP_TIPO_PROMOCION)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_ITEM, DbType.Int16, Orm.DDP_ITEM)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
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

        Public Function spEliminarRegistroGeneral(ByVal Orm As BE.DetalleDocumentosPromocion) As Short Implements IDetalleDocumentosPromocionRepositorio.spEliminarRegistroGeneral
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroGeneralDetalleDocumentosPromocion)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_NUMERO, DbType.String, Orm.DDP_NUMERO)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.DDP_TIPO_PROMOCION, DbType.Int16, Orm.DDP_TIPO_PROMOCION)
                context.AddInParameter(cmd, DetalleDocumentosPromocion.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.ExecuteNonQuery(cmd)
                spEliminarRegistroGeneral = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarRegistroGeneral = 0
            End Try
        End Function
    End Class
End Namespace
