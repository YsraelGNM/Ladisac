Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCDetalleDocumentos
        Implements IBCDetalleDocumentos

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Mantenimiento(ByVal Item As BE.DetalleDocumentos) As Short Implements IBCDetalleDocumentos.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleDocumentosRepositorio)()
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

        Public Function DeleteRegistro(ByVal item As BE.DetalleDocumentos, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDO_SERIE As String, ByVal cDDO_NUMERO As String, ByVal cDDO_ITEM As Short) As Short Implements IBCDetalleDocumentos.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleDocumentosRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()

                    DeleteRegistro = rep.DeleteRegistro(item, cTDO_ID, cDTD_ID, cDDO_SERIE, cDDO_NUMERO, cDDO_ITEM)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    item.vMensajeError = ex.Message
                Else
                    item.vMensajeError = ex.InnerException.Message
                End If
                DeleteRegistro = 0
            End Try
        End Function

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDO_SERIE As String, ByVal cDDO_NUMERO As String, ByVal cDDO_ITEM As Short, ByVal cART_ID_IMP As String, ByVal cART_ID_KAR As String, ByVal cDDO_ART_FACTOR As Double, ByVal cDDO_CANTIDAD As Double, ByVal cDDO_INC_IGV As Short, ByVal cDDO_DES_INC_PRE As Double, ByVal cDDO_PRE_UNI As Double, ByVal cDDO_IGV_POR As Double, ByVal cDDO_MONTO_IGV As Double, ByVal cDDO_PRE_TOTAL As Double, ByVal cDDO_OBS_DSC_ART As String, ByVal cTDO_ID_ANT As String, ByVal cDTD_ID_ANT As String, ByVal cCCT_ID_ANT As String, ByVal cDDO_SERIE_ANT As String, ByVal cDDO_NUMERO_ANT As String, ByVal cART_AFE_PER As Boolean, ByVal cUSU_ID As String, ByVal cDDO_FEC_GRAB As Date, ByVal cDDO_ESTADO As Boolean) As Short Implements IBCDetalleDocumentos.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleDocumentosRepositorio)()
                    rep.spActualizarRegistro(cTDO_ID, cDTD_ID, cDDO_SERIE, cDDO_NUMERO, cDDO_ITEM, cART_ID_IMP, cART_ID_KAR, cDDO_ART_FACTOR, cDDO_CANTIDAD, cDDO_INC_IGV, cDDO_DES_INC_PRE, cDDO_PRE_UNI, cDDO_IGV_POR, cDDO_MONTO_IGV, cDDO_PRE_TOTAL, cDDO_OBS_DSC_ART, cTDO_ID_ANT, cDTD_ID_ANT, cCCT_ID_ANT, cDDO_SERIE_ANT, cDDO_NUMERO_ANT, cART_AFE_PER, cUSU_ID, cDDO_FEC_GRAB, cDDO_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDO_SERIE As String, ByVal cDDO_NUMERO As String, ByVal cDDO_ITEM As Short) As Short Implements IBCDetalleDocumentos.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleDocumentosRepositorio)()
                    rep.spEliminarRegistro(cTDO_ID, cDTD_ID, cDDO_SERIE, cDDO_NUMERO, cDDO_ITEM)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDDO_SERIE As String, ByVal cDDO_NUMERO As String, ByVal cDDO_ITEM As Short, ByVal cART_ID_IMP As String, ByVal cART_ID_KAR As String, ByVal cDDO_ART_FACTOR As Double, ByVal cDDO_CANTIDAD As Double, ByVal cDDO_INC_IGV As Short, ByVal cDDO_DES_INC_PRE As Double, ByVal cDDO_PRE_UNI As Double, ByVal cDDO_IGV_POR As Double, ByVal cDDO_MONTO_IGV As Double, ByVal cDDO_PRE_TOTAL As Double, ByVal cDDO_OBS_DSC_ART As String, ByVal cTDO_ID_ANT As String, ByVal cDTD_ID_ANT As String, ByVal cCCT_ID_ANT As String, ByVal cDDO_SERIE_ANT As String, ByVal cDDO_NUMERO_ANT As String, ByVal cART_AFE_PER As Boolean, ByVal cUSU_ID As String, ByVal cDDO_FEC_GRAB As Date, ByVal cDDO_ESTADO As Boolean) As Short Implements IBCDetalleDocumentos.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleDocumentosRepositorio)()
                    rep.spInsertarRegistro(cTDO_ID, cDTD_ID, cDDO_SERIE, cDDO_NUMERO, cDDO_ITEM, cART_ID_IMP, cART_ID_KAR, cDDO_ART_FACTOR, cDDO_CANTIDAD, cDDO_INC_IGV, cDDO_DES_INC_PRE, cDDO_PRE_UNI, cDDO_IGV_POR, cDDO_MONTO_IGV, cDDO_PRE_TOTAL, cDDO_OBS_DSC_ART, cTDO_ID_ANT, cDTD_ID_ANT, cCCT_ID_ANT, cDDO_SERIE_ANT, cDDO_NUMERO_ANT, cART_AFE_PER, cUSU_ID, cDDO_FEC_GRAB, cDDO_ESTADO)
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
