Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCDetalleAfectaDocumentos
        Implements IBCDetalleAfectaDocumentos

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        Public Function ItemDetalleAfectaDocumentos(ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cDaa_Serie As String, ByVal cDaa_Numero As String) As Integer Implements IBCDetalleAfectaDocumentos.ItemDetalleAfectaDocumentos
            Dim result As String = ""
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spItemDetalleAfectaDocumentosXML, cTdo_Id, cDtd_Id, cDaa_Serie, cDaa_Numero))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarEnteroXML(sr, "item")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDA_SERIE As String, ByVal cDDA_NUMERO As String, ByVal cDDA_ITEM As Short, ByVal cTDO_ID_AFE As String, ByVal cDTD_ID_AFE As String, ByVal cCCT_ID_AFE As String, ByVal cDOC_SERIE_AFE As String, ByVal cDOC_NUMERO_AFE As String, ByVal cDDA_PRE_TOTAL As Double, ByVal cDDA_OBS As String, ByVal cUSU_ID As String, ByVal cDDA_FEC_GRAB As Date, ByVal cDDA_ESTADO As Boolean) As Short Implements IBCDetalleAfectaDocumentos.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleAfectaDocumentosRepositorio)()
                    rep.spActualizarRegistro(cTDO_ID, cDTD_ID, cDDA_SERIE, cDDA_NUMERO, cDDA_ITEM, cTDO_ID_AFE, cDTD_ID_AFE, cCCT_ID_AFE, cDOC_SERIE_AFE, cDOC_NUMERO_AFE, cDDA_PRE_TOTAL, cDDA_OBS, cUSU_ID, cDDA_FEC_GRAB, cDDA_ESTADO)
                    Scope.Complete()
                    spActualizarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spActualizarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDA_SERIE As String, ByVal cDDA_NUMERO As String, ByVal cDDA_ITEM As Short) As Short Implements IBCDetalleAfectaDocumentos.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleAfectaDocumentosRepositorio)()
                    rep.spEliminarRegistro(cTDO_ID, cDTD_ID, cDDA_SERIE, cDDA_NUMERO, cDDA_ITEM)
                    Scope.Complete()
                    spEliminarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spEliminarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spInsertarRegistro(ByVal cOrm As DetalleAfectaDocumentos) As Short Implements IBCDetalleAfectaDocumentos.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleAfectaDocumentosRepositorio)()
                    rep.spInsertarRegistro(cOrm.TDO_ID, cOrm.DTD_ID, cOrm.DDA_SERIE, cOrm.DDA_NUMERO, cOrm.DDA_ITEM, cOrm.TDO_ID_AFE, cOrm.DTD_ID_AFE, cOrm.CCT_ID_AFE, cOrm.DOC_SERIE_AFE, cOrm.DOC_NUMERO_AFE, cOrm.DDA_PRE_TOTAL, cOrm.DDA_OBS, cOrm.USU_ID, cOrm.DDA_FEC_GRAB, cOrm.DDA_ESTADO)
                    Scope.Complete()
                    spInsertarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spInsertarRegistro = 0
                End Try
            End Using
        End Function
    End Class
End Namespace
