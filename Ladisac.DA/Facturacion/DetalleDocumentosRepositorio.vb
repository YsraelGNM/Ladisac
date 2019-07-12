Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DetalleDocumentosRepositorio
        Implements IDetalleDocumentosRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.DetalleDocumentos) As Short Implements IDetalleDocumentosRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DetalleDocumentos.ApplyChanges(item)
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

        Public Function DeleteRegistro(ByVal item As BE.DetalleDocumentos, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDO_SERIE As String, ByVal cDDO_NUMERO As String, ByVal cDDO_ITEM As Short) As Short Implements IDetalleDocumentosRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()

                item = (From c In context.DetalleDocumentos Where c.TDO_ID = cTDO_ID And _
                                                                  c.DTD_ID = cDTD_ID And _
                                                                  c.DDO_SERIE = cDDO_SERIE And _
                                                                  c.DDO_NUMERO = cDDO_NUMERO And _
                                                                  c.DDO_ITEM = cDDO_ITEM Select c).FirstOrDefault()
                item.MarkAsDeleted()
                DeleteRegistro = Maintenance(item)
                'context.DetalleListaPrecios.ApplyChanges(item)
                'context.SaveChanges()
                'item.AcceptChanges()
                'DeleteRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                DeleteRegistro = 0
            End Try
        End Function

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDO_SERIE As String, ByVal cDDO_NUMERO As String, ByVal cDDO_ITEM As Short, ByVal cART_ID_IMP As String, ByVal cART_ID_KAR As String, ByVal cDDO_ART_FACTOR As Double, ByVal cDDO_CANTIDAD As Double, ByVal cDDO_INC_IGV As Short, ByVal cDDO_DES_INC_PRE As Double, ByVal cDDO_PRE_UNI As Double, ByVal cDDO_IGV_POR As Double, ByVal cDDO_MONTO_IGV As Double, ByVal cDDO_PRE_TOTAL As Double, ByVal cDDO_OBS_DSC_ART As String, ByVal cTDO_ID_ANT As String, ByVal cDTD_ID_ANT As String, ByVal cCCT_ID_ANT As String, ByVal cDDO_SERIE_ANT As String, ByVal cDDO_NUMERO_ANT As String, ByVal cART_AFE_PER As Boolean, ByVal cUSU_ID As String, ByVal cDDO_FEC_GRAB As Date, ByVal cDDO_ESTADO As Boolean) As Short Implements IDetalleDocumentosRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroDetalleDocumentos)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_SERIE, DbType.String, cDDO_SERIE)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_NUMERO, DbType.String, cDDO_NUMERO)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_ITEM, DbType.Int16, cDDO_ITEM)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.ART_ID_IMP, DbType.String, cART_ID_IMP)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.ART_ID_KAR, DbType.String, cART_ID_KAR)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_ART_FACTOR, DbType.Double, cDDO_ART_FACTOR)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_CANTIDAD, DbType.Double, cDDO_CANTIDAD)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_INC_IGV, DbType.Int16, cDDO_INC_IGV)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_DES_INC_PRE, DbType.Double, cDDO_DES_INC_PRE)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_PRE_UNI, DbType.Double, cDDO_PRE_UNI)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_IGV_POR, DbType.Double, cDDO_IGV_POR)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_MONTO_IGV, DbType.Double, cDDO_MONTO_IGV)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_PRE_TOTAL, DbType.Double, cDDO_PRE_TOTAL)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_OBS_DSC_ART, DbType.String, cDDO_OBS_DSC_ART)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.TDO_ID_ANT, DbType.String, cTDO_ID_ANT)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DTD_ID_ANT, DbType.String, cDTD_ID_ANT)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.CCT_ID_ANT, DbType.String, cCCT_ID_ANT)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_SERIE_ANT, DbType.String, cDDO_SERIE_ANT)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_NUMERO_ANT, DbType.String, cDDO_NUMERO_ANT)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.ART_AFE_PER, DbType.Boolean, cART_AFE_PER)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_FEC_GRAB, DbType.DateTime, cDDO_FEC_GRAB)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_ESTADO, DbType.Boolean, cDDO_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDO_SERIE As String, ByVal cDDO_NUMERO As String, ByVal cDDO_ITEM As Short) As Short Implements IDetalleDocumentosRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroDetalleDocumentos)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_SERIE, DbType.String, cDDO_SERIE)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_NUMERO, DbType.String, cDDO_NUMERO)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_ITEM, DbType.Int16, cDDO_ITEM)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDO_SERIE As String, ByVal cDDO_NUMERO As String, ByVal cDDO_ITEM As Short, ByVal cART_ID_IMP As String, ByVal cART_ID_KAR As String, ByVal cDDO_ART_FACTOR As Double, ByVal cDDO_CANTIDAD As Double, ByVal cDDO_INC_IGV As Short, ByVal cDDO_DES_INC_PRE As Double, ByVal cDDO_PRE_UNI As Double, ByVal cDDO_IGV_POR As Double, ByVal cDDO_MONTO_IGV As Double, ByVal cDDO_PRE_TOTAL As Double, ByVal cDDO_OBS_DSC_ART As String, ByVal cTDO_ID_ANT As String, ByVal cDTD_ID_ANT As String, ByVal cCCT_ID_ANT As String, ByVal cDDO_SERIE_ANT As String, ByVal cDDO_NUMERO_ANT As String, ByVal cART_AFE_PER As Boolean, ByVal cUSU_ID As String, ByVal cDDO_FEC_GRAB As Date, ByVal cDDO_ESTADO As Boolean) As Short Implements IDetalleDocumentosRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroDetalleDocumentos)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_SERIE, DbType.String, cDDO_SERIE)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_NUMERO, DbType.String, cDDO_NUMERO)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_ITEM, DbType.Int16, cDDO_ITEM)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.ART_ID_IMP, DbType.String, cART_ID_IMP)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.ART_ID_KAR, DbType.String, cART_ID_KAR)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_ART_FACTOR, DbType.Double, cDDO_ART_FACTOR)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_CANTIDAD, DbType.Double, cDDO_CANTIDAD)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_INC_IGV, DbType.Int16, cDDO_INC_IGV)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_DES_INC_PRE, DbType.Double, cDDO_DES_INC_PRE)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_PRE_UNI, DbType.Double, cDDO_PRE_UNI)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_IGV_POR, DbType.Double, cDDO_IGV_POR)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_MONTO_IGV, DbType.Double, cDDO_MONTO_IGV)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_PRE_TOTAL, DbType.Double, cDDO_PRE_TOTAL)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_OBS_DSC_ART, DbType.String, cDDO_OBS_DSC_ART)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.TDO_ID_ANT, DbType.String, cTDO_ID_ANT)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DTD_ID_ANT, DbType.String, cDTD_ID_ANT)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.CCT_ID_ANT, DbType.String, cCCT_ID_ANT)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_SERIE_ANT, DbType.String, cDDO_SERIE_ANT)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_NUMERO_ANT, DbType.String, cDDO_NUMERO_ANT)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.ART_AFE_PER, DbType.Boolean, cART_AFE_PER)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_FEC_GRAB, DbType.DateTime, cDDO_FEC_GRAB)
                context.AddInParameter(cmd, DetalleDocumentos.PropertyNames.DDO_ESTADO, DbType.Boolean, cDDO_ESTADO)
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
