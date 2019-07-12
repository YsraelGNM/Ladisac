Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA
    Public Class DetalleListaPreciosRepositorio
        Implements DA.IDetalleListaPreciosRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.DetalleListaPrecios) As Short Implements IDetalleListaPreciosRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DetalleListaPrecios.ApplyChanges(item)
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

        'Public Function DeleteRegistro(ByVal item As BE.DetalleListaPrecios, _
        '                               ByVal cLPR_ID As String,
        '                               ByVal cART_ID As String) As Short Implements IDetalleListaPreciosRepositorio.DeleteRegistro
        '    Try
        '        Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()

        '        item = (From c In context.DetalleListaPrecios Where c.LPR_ID = cLPR_ID And c.ART_ID = cART_ID Select c).FirstOrDefault()
        '        item.MarkAsDeleted()
        '        DeleteRegistro = Maintenance(item)
        '        'context.DetalleListaPrecios.ApplyChanges(item)
        '        'context.SaveChanges()
        '        'item.AcceptChanges()
        '        'DeleteRegistro = 1
        '    Catch ex As Exception
        '        Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
        '        If (rethrow) Then
        '            Throw
        '        End If
        '        DeleteRegistro = 0
        '    End Try
        'End Function

        Public Function spActualizarRegistro(ByVal cLPR_ID As String, ByVal cART_ID As String, ByVal cDLP_PRECIO_MINIMO As Double, ByVal cDLP_PRECIO_UNITARIO As Double, ByVal cDLP_RECARGO_ENVIO As Double, ByVal cUSU_ID As String, ByVal cDLP_FEC_GRAB As Date, ByVal cDLP_ESTADO As Boolean) As Short Implements IDetalleListaPreciosRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroDetalleListaPrecios)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.LPR_ID, DbType.String, cLPR_ID)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.ART_ID, DbType.String, cART_ID)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.DLP_PRECIO_MINIMO, DbType.Double, cDLP_PRECIO_MINIMO)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.DLP_PRECIO_UNITARIO, DbType.Double, cDLP_PRECIO_UNITARIO)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.DLP_RECARGO_ENVIO, DbType.Double, cDLP_RECARGO_ENVIO)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.DLP_FEC_GRAB, DbType.DateTime, cDLP_FEC_GRAB)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.DLP_ESTADO, DbType.Boolean, cDLP_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cLPR_ID As String, ByVal cART_ID As String) As Short Implements IDetalleListaPreciosRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroDetalleListaPrecios)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.LPR_ID, DbType.String, cLPR_ID)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.ART_ID, DbType.String, cART_ID)
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

        Public Function spInsertarRegistro(ByVal cLPR_ID As String, ByVal cART_ID As String, ByVal cDLP_PRECIO_MINIMO As Double, ByVal cDLP_PRECIO_UNITARIO As Double, ByVal cDLP_RECARGO_ENVIO As Double, ByVal cUSU_ID As String, ByVal cDLP_FEC_GRAB As Date, ByVal cDLP_ESTADO As Boolean) As Short Implements IDetalleListaPreciosRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroDetalleListaPrecios)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.LPR_ID, DbType.String, cLPR_ID)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.ART_ID, DbType.String, cART_ID)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.DLP_PRECIO_MINIMO, DbType.Double, cDLP_PRECIO_MINIMO)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.DLP_PRECIO_UNITARIO, DbType.Double, cDLP_PRECIO_UNITARIO)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.DLP_RECARGO_ENVIO, DbType.Double, cDLP_RECARGO_ENVIO)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.DLP_FEC_GRAB, DbType.DateTime, cDLP_FEC_GRAB)
                context.AddInParameter(cmd, DetalleListaPrecios.PropertyNames.DLP_ESTADO, DbType.Boolean, cDLP_ESTADO)
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
