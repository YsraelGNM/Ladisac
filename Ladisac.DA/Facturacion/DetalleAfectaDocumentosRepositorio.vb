Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DetalleAfectaDocumentosRepositorio
        Implements IDetalleAfectaDocumentosRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDA_SERIE As String, ByVal cDDA_NUMERO As String, ByVal cDDA_ITEM As Short, ByVal cTDO_ID_AFE As String, ByVal cDTD_ID_AFE As String, ByVal cCCT_ID_AFE As String, ByVal cDOC_SERIE_AFE As String, ByVal cDOC_NUMERO_AFE As String, ByVal cDDA_PRE_TOTAL As Double, ByVal cDDA_OBS As String, ByVal cUSU_ID As String, ByVal cDDA_FEC_GRAB As Date, ByVal cDDA_ESTADO As Boolean) As Short Implements IDetalleAfectaDocumentosRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroDetalleAfectaDocumentos)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_SERIE, DbType.String, cDDA_SERIE)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_NUMERO, DbType.String, cDDA_NUMERO)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_ITEM, DbType.Int16, cDDA_ITEM)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.TDO_ID_AFE, DbType.String, cTDO_ID_AFE)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DTD_ID_AFE, DbType.String, cDTD_ID_AFE)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.CCT_ID_AFE, DbType.String, cCCT_ID_AFE)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DOC_SERIE_AFE, DbType.String, cDOC_SERIE_AFE)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DOC_NUMERO_AFE, DbType.String, cDOC_NUMERO_AFE)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_PRE_TOTAL, DbType.Double, cDDA_PRE_TOTAL)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_OBS, DbType.String, cDDA_OBS)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_FEC_GRAB, DbType.DateTime, cDDA_FEC_GRAB)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_ESTADO, DbType.Boolean, cDDA_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDA_SERIE As String, ByVal cDDA_NUMERO As String, ByVal cDDA_ITEM As Short) As Short Implements IDetalleAfectaDocumentosRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroDetalleAfectaDocumentos)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_SERIE, DbType.String, cDDA_SERIE)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_NUMERO, DbType.String, cDDA_NUMERO)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_ITEM, DbType.Int16, cDDA_ITEM)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDA_SERIE As String, ByVal cDDA_NUMERO As String, ByVal cDDA_ITEM As Short, ByVal cTDO_ID_AFE As String, ByVal cDTD_ID_AFE As String, ByVal cCCT_ID_AFE As String, ByVal cDOC_SERIE_AFE As String, ByVal cDOC_NUMERO_AFE As String, ByVal cDDA_PRE_TOTAL As Double, ByVal cDDA_OBS As String, ByVal cUSU_ID As String, ByVal cDDA_FEC_GRAB As Date, ByVal cDDA_ESTADO As Boolean) As Short Implements IDetalleAfectaDocumentosRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroDetalleAfectaDocumentos)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_SERIE, DbType.String, cDDA_SERIE)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_NUMERO, DbType.String, cDDA_NUMERO)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_ITEM, DbType.Int16, cDDA_ITEM)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.TDO_ID_AFE, DbType.String, cTDO_ID_AFE)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DTD_ID_AFE, DbType.String, cDTD_ID_AFE)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.CCT_ID_AFE, DbType.String, cCCT_ID_AFE)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DOC_SERIE_AFE, DbType.String, cDOC_SERIE_AFE)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DOC_NUMERO_AFE, DbType.String, cDOC_NUMERO_AFE)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_PRE_TOTAL, DbType.Double, cDDA_PRE_TOTAL)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_OBS, DbType.String, cDDA_OBS)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_FEC_GRAB, DbType.DateTime, cDDA_FEC_GRAB)
                context.AddInParameter(cmd, DetalleAfectaDocumentos.PropertyNames.DDA_ESTADO, DbType.Boolean, cDDA_ESTADO)
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
