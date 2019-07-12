Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DetalleDespachosRepositorio
        Implements IDetalleDespachosRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.DetalleDespachos) As Short Implements IDetalleDespachosRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DetalleDespachos.ApplyChanges(item)
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

        Public Function DeleteRegistro(ByVal item As BE.DetalleDespachos, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDE_SERIE As String, ByVal cDDE_NUMERO As String, ByVal cDDE_ITEM As Int16) As Short Implements IDetalleDespachosRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.DetalleDespachos Where c.TDO_ID = cTDO_ID And c.DTD_ID = cDTD_ID And c.DDE_SERIE = cDDE_SERIE And c.DDE_NUMERO = cDDE_NUMERO And c.DDE_ITEM = cDDE_ITEM Select c).FirstOrDefault()
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

        Public Function spActualizarRegistro(ByVal orm As DetalleDespachos) As Short Implements IDetalleDespachosRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroDetalleDespachos)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.TDO_ID, DbType.String, orm.TDO_ID)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DTD_ID, DbType.String, orm.DTD_ID)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_SERIE, DbType.String, orm.DDE_SERIE)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_NUMERO, DbType.String, orm.DDE_NUMERO)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_ITEM, DbType.Int16, orm.DDE_ITEM)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.ART_ID_IMP, DbType.String, orm.ART_ID_IMP)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.ART_ID_KAR, DbType.String, orm.ART_ID_KAR)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_CANTIDAD, DbType.Double, orm.DDE_CANTIDAD)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.USU_ID, DbType.String, orm.USU_ID)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_FEC_GRAB, DbType.DateTime, orm.DDE_FEC_GRAB)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_ESTADO, DbType.Boolean, orm.DDE_ESTADO)
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

        Public Function spEliminarRegistro(ByVal Orm As DetalleDespachos) As Short Implements IDetalleDespachosRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroDetalleDespachos)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DTD_ID, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_SERIE, DbType.String, Orm.DDE_SERIE)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_NUMERO, DbType.String, Orm.DDE_NUMERO)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_ITEM, DbType.Int16, Orm.DDE_ITEM)
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

        Public Function spInsertarRegistro(ByVal Orm As DetalleDespachos) As Short Implements IDetalleDespachosRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroDetalleDespachos)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.TDO_ID, DbType.String, Orm.TDO_ID)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DTD_ID, DbType.String, Orm.DTD_ID)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_SERIE, DbType.String, Orm.DDE_SERIE)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_NUMERO, DbType.String, Orm.DDE_NUMERO)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_ITEM, DbType.Int16, Orm.DDE_ITEM)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.ART_ID_IMP, DbType.String, Orm.ART_ID_IMP)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.ART_ID_KAR, DbType.String, Orm.ART_ID_KAR)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_CANTIDAD, DbType.Double, Orm.DDE_CANTIDAD)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.USU_ID, DbType.String, Orm.USU_ID)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_FEC_GRAB, DbType.DateTime, Orm.DDE_FEC_GRAB)
                context.AddInParameter(cmd, DetalleDespachos.PropertyNames.DDE_ESTADO, DbType.Boolean, Orm.DDE_ESTADO)
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
