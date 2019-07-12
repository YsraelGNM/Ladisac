Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DetalleAfectaProductoDocumentosRepositorio
        Implements IDetalleAfectaProductoDocumentosRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.DetalleAfectaProductoDocumentos) As Short Implements IDetalleAfectaProductoDocumentosRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DetalleAfectaProductoDocumentos.ApplyChanges(item)
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

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDAP_SERIE As String, ByVal cDAP_NUMERO As String, ByVal cDAP_ITEM As Short, ByVal cTDO_ID_AFP As String, ByVal cDTD_ID_AFP As String, ByVal cCCT_ID_AFP As String, ByVal cDOC_SERIE_AFP As String, ByVal cDOC_NUMERO_AFP As String, ByVal cART_ID As String, ByVal cDAP_CANTIDAD As Double, ByVal cDAP_OBS As String, ByVal cTDO_ID_DEV As String, ByVal cDTD_ID_DEV As String, ByVal cCCT_ID_DEV As String, ByVal cDES_SERIE_DEV As String, ByVal cDES_NUMERO_DEV As String, ByVal cART_ID_DEV As String, ByVal cDDE_CANTIDAD_DEV As Double, ByVal cUSU_ID As String, ByVal cDAP_FEC_GRAB As Date, ByVal cDAP_ESTADO As Boolean) As Short Implements IDetalleAfectaProductoDocumentosRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroDetalleAfectaProductoDocumentosNuevo)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_SERIE, DbType.String, cDAP_SERIE)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_NUMERO, DbType.String, cDAP_NUMERO)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_ITEM, DbType.Int16, cDAP_ITEM)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.TDO_ID_AFP, DbType.String, cTDO_ID_AFP)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DTD_ID_AFP, DbType.String, cDTD_ID_AFP)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.CCT_ID_AFP, DbType.String, cCCT_ID_AFP)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DOC_SERIE_AFP, DbType.String, cDOC_SERIE_AFP)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DOC_NUMERO_AFP, DbType.String, cDOC_NUMERO_AFP)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.ART_ID, DbType.Double, cART_ID)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_CANTIDAD, DbType.Double, cDAP_CANTIDAD)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_OBS, DbType.String, cDAP_OBS)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.TDO_ID_DEV, DbType.String, cTDO_ID_DEV)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DTD_ID_DEV, DbType.String, cDTD_ID_DEV)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.CCT_ID_DEV, DbType.String, cCCT_ID_DEV)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DES_SERIE_DEV, DbType.String, cDES_SERIE_DEV)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DES_NUMERO_DEV, DbType.String, cDES_NUMERO_DEV)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.ART_ID_DEV, DbType.Double, cART_ID_DEV)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DDE_CANTIDAD_DEV, DbType.Double, cDDE_CANTIDAD_DEV)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_FEC_GRAB, DbType.DateTime, cDAP_FEC_GRAB)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_ESTADO, DbType.Boolean, cDAP_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDAP_SERIE As String, ByVal cDAP_NUMERO As String, ByVal cDAP_ITEM As Short) As Short Implements IDetalleAfectaProductoDocumentosRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroDetalleAfectaProductoDocumentos)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_SERIE, DbType.String, cDAP_SERIE)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_NUMERO, DbType.String, cDAP_NUMERO)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_ITEM, DbType.Int16, cDAP_ITEM)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDAP_SERIE As String, ByVal cDAP_NUMERO As String, ByVal cDAP_ITEM As Short, ByVal cTDO_ID_AFP As String, ByVal cDTD_ID_AFP As String, ByVal cCCT_ID_AFP As String, ByVal cDOC_SERIE_AFP As String, ByVal cDOC_NUMERO_AFP As String, ByVal cART_ID As String, ByVal cDAP_CANTIDAD As Double, ByVal cDAP_OBS As String, ByVal cTDO_ID_DEV As String, ByVal cDTD_ID_DEV As String, ByVal cCCT_ID_DEV As String, ByVal cDES_SERIE_DEV As String, ByVal cDES_NUMERO_DEV As String, ByVal cART_ID_DEV As String, ByVal cDDE_CANTIDAD_DEV As Double, ByVal cUSU_ID As String, ByVal cDAP_FEC_GRAB As Date, ByVal cDAP_ESTADO As Boolean) As Short Implements IDetalleAfectaProductoDocumentosRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroDetalleAfectaProductoDocumentosNuevo)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_SERIE, DbType.String, cDAP_SERIE)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_NUMERO, DbType.String, cDAP_NUMERO)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_ITEM, DbType.Int16, cDAP_ITEM)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.TDO_ID_AFP, DbType.String, cTDO_ID_AFP)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DTD_ID_AFP, DbType.String, cDTD_ID_AFP)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.CCT_ID_AFP, DbType.String, cCCT_ID_AFP)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DOC_SERIE_AFP, DbType.String, cDOC_SERIE_AFP)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DOC_NUMERO_AFP, DbType.String, cDOC_NUMERO_AFP)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.ART_ID, DbType.String, cART_ID)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_CANTIDAD, DbType.Double, cDAP_CANTIDAD)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_OBS, DbType.String, cDAP_OBS)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.TDO_ID_DEV, DbType.String, cTDO_ID_DEV)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DTD_ID_DEV, DbType.String, cDTD_ID_DEV)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.CCT_ID_DEV, DbType.String, cCCT_ID_DEV)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DES_SERIE_DEV, DbType.String, cDES_SERIE_DEV)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DES_NUMERO_DEV, DbType.String, cDES_NUMERO_DEV)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.ART_ID_DEV, DbType.String, cART_ID_DEV)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DDE_CANTIDAD_DEV, DbType.Double, cDDE_CANTIDAD_DEV)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_FEC_GRAB, DbType.DateTime, cDAP_FEC_GRAB)
                context.AddInParameter(cmd, DetalleAfectaProductoDocumentos.PropertyNames.DAP_ESTADO, DbType.Boolean, cDAP_ESTADO)
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
