Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCDetalleAfectaProductoDocumentos
        Implements IBCDetalleAfectaProductoDocumentos

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        Public Function Mantenimiento(ByVal Item As BE.DetalleAfectaProductoDocumentos) As Short Implements IBCDetalleAfectaProductoDocumentos.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleAfectaProductoDocumentosRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            Mantenimiento = 0
                            Exit Function
                        End If
                    End If
                    Mantenimiento = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Item.vMensajeError = ex.Message
                Else
                    Item.vMensajeError = ex.InnerException.Message
                End If
                Mantenimiento = 0
            End Try
        End Function

        Public Function ItemDetalleAfectaProductoDocumentos(ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cDap_Serie As String, ByVal cDap_Numero As String) As Integer Implements IBCDetalleAfectaProductoDocumentos.ItemDetalleAfectaProductoDocumentos
            Dim result As String = ""
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spItemDetalleAfectaProductoDocumentosXML, cTdo_Id, cDtd_Id, cDap_Serie, cDap_Numero))
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

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDAP_SERIE As String, ByVal cDAP_NUMERO As String, ByVal cDAP_ITEM As Short, ByVal cTDO_ID_AFE As String, ByVal cDTD_ID_AFE As String, ByVal cCCT_ID_AFE As String, ByVal cDOC_SERIE_AFE As String, ByVal cDOC_NUMERO_AFE As String, ByVal cART_ID As String, ByVal cDAP_CANTIDAD As Double, ByVal cDAP_OBS As String, ByVal cTDO_ID_DEV As String, ByVal cDTD_ID_DEV As String, ByVal cCCT_ID_DEV As String, ByVal cDES_SERIE_DEV As String, ByVal cDES_NUMERO_DEV As String, ByVal cART_ID_DEV As String, ByVal cDDE_CANTIDAD_DEV As Double, ByVal cUSU_ID As String, ByVal cDAP_FEC_GRAB As Date, ByVal cDAP_ESTADO As Boolean) As Short Implements IBCDetalleAfectaProductoDocumentos.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleAfectaProductoDocumentosRepositorio)()
                    rep.spActualizarRegistro(cTDO_ID, cDTD_ID, cDAP_SERIE, cDAP_NUMERO, cDAP_ITEM, cTDO_ID_AFE, cDTD_ID_AFE, cCCT_ID_AFE, cDOC_SERIE_AFE, cDOC_NUMERO_AFE, cART_ID, cDAP_CANTIDAD, cDAP_OBS, cTDO_ID_DEV, cDTD_ID_DEV, cCCT_ID_DEV, cDES_SERIE_DEV, cDES_NUMERO_DEV, cART_ID_DEV, cDDE_CANTIDAD_DEV, cUSU_ID, cDAP_FEC_GRAB, cDAP_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDAP_SERIE As String, ByVal cDAP_NUMERO As String, ByVal cDAP_ITEM As Short) As Short Implements IBCDetalleAfectaProductoDocumentos.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleAfectaProductoDocumentosRepositorio)()
                    rep.spEliminarRegistro(cTDO_ID, cDTD_ID, cDAP_SERIE, cDAP_NUMERO, cDAP_ITEM)
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

        Public Function spInsertarRegistro(ByVal cOrm As DetalleAfectaProductoDocumentos) As Short Implements IBCDetalleAfectaProductoDocumentos.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleAfectaProductoDocumentosRepositorio)()
                    rep.spInsertarRegistro(cOrm.TDO_ID, cOrm.DTD_ID, cOrm.DAP_SERIE, cOrm.DAP_NUMERO, cOrm.DAP_ITEM, cOrm.TDO_ID_AFP, cOrm.DTD_ID_AFP, cOrm.CCT_ID_AFP, cOrm.DOC_SERIE_AFP, cOrm.DOC_NUMERO_AFP, cOrm.ART_ID, cOrm.DAP_CANTIDAD, cOrm.DAP_OBS, cOrm.TDO_ID_DEV, cOrm.DTD_ID_DEV, cOrm.CCT_ID_DEV, cOrm.DES_SERIE_DEV, cOrm.DES_NUMERO_DEV, cOrm.ART_ID_DEV, cOrm.DDE_CANTIDAD_DEV, cOrm.USU_ID, cOrm.DAP_FEC_GRAB, cOrm.DAP_ESTADO)
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
