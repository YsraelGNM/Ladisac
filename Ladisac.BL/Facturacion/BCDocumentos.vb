Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCDocumentos
        Implements IBCDocumentos

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Mantenimiento(ByVal Item As BE.Documentos) As Short Implements IBCDocumentos.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocumentosRepositorio)()
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

        Public Function spActualizarDocumentosDOC_ESTADO(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DOC_SERIE As String, ByVal DOC_NUMERO As String, ByVal DOC_ESTADO As Short) As Short Implements IBCDocumentos.spActualizarDocumentosDOC_ESTADO
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDocumentosRepositorio)()
                    rep.spActualizarDocumentosDOC_ESTADO(TDO_ID, DTD_ID, DOC_SERIE, DOC_NUMERO, DOC_ESTADO)
                    Scope.Complete()
                    spActualizarDocumentosDOC_ESTADO = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spActualizarDocumentosDOC_ESTADO = 0
                End Try
            End Using
        End Function

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCT_ID As String, ByVal cDOC_SERIE As String, ByVal cDOC_NUMERO As String, ByVal cDOC_ORDEN_COMPRA As String, ByVal cDOC_TIPO_ORDEN_COMPRA As Short, ByVal cPER_ID_REC As String, ByVal cTDP_ID_REC As String, ByVal cDIR_ID_ENT_REC As String, ByVal cPVE_ID As String, ByVal cPVE_ID_DES As String, ByVal cMON_ID As String, ByVal cTIV_ID As String, ByVal cPER_ID_CLI As String, ByVal cTDP_ID_CLI As String, ByVal cPER_ID_CON As String, ByVal cDOC_FECHA_EMI As Date, ByVal cDOC_FECHA_ENT As Date, ByVal cDOC_FECHA_EXP As Date, ByVal cDIR_ID_FIS As String, ByVal cDIR_ID_DOM As String, ByVal cDIR_ID_ENT As String, ByVal cDIR_ID_COB As String, ByVal cPER_ID_VEN As String, ByVal cPER_ID_COB As String, ByVal cPER_ID_PRO As String, ByVal cPER_ID_GRU As String, ByVal cDOC_TIPO_LISTA As Short, ByVal cDOC_MONTO_TOTAL As Double, ByVal cDOC_CONTRAVALOR As Double, ByVal cDOC_IGV_POR As Double, ByVal cDOC_ASIENTO As Boolean, ByVal cDOC_CIERRE As Short, ByVal cFLE_ID As String, ByVal cDOC_MONTO_FLE As Double, ByVal cDOC_REQUIERE_GUIA As Boolean, ByVal cTDO_ID_AFE As String, ByVal cDTD_ID_AFE As String, ByVal cCCT_ID_AFE As String, ByVal cDOC_SERIE_AFE As String, ByVal cDOC_NUMERO_AFE As String, ByVal cDOC_MOT_EMI As Short, ByVal cDOC_NOMBRE_RECEP As String, ByVal cDOC_DNI_RECEP As String, ByVal cDOC_FEC_RECEP As Date, ByVal cDOC_ENTREGADO As Boolean, ByVal cCAF_IX_NUMERO_PRO As String, ByVal cCAF_IX_ORDEN_COM As String, ByVal cLPR_ID As String, ByVal cUSU_ID As String, ByVal cDOC_FEC_GRAB As Date, ByVal cDOC_ESTADO As Short, ByVal cDOC_MONTO_PERCEPCION As Double, ByVal cTDO_ID_GEN As String, ByVal cDTD_ID_GEN As String, ByVal cCCT_ID_GEN As String, ByVal cDOC_SERIE_GEN As String, ByVal cDOC_NUMERO_GEN As String, ByVal cDOC_OBSERVACIONES As String, ByVal cDOC_ATENCION As String, ByVal cDOC_HORA_INICIO As DateTime, ByVal cDOC_HORA_FIN As DateTime) As Short Implements IBCDocumentos.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDocumentosRepositorio)()
                    rep.spActualizarRegistro(cTDO_ID, cDTD_ID, cCCT_ID, cDOC_SERIE, cDOC_NUMERO, cDOC_ORDEN_COMPRA, cDOC_TIPO_ORDEN_COMPRA, cPER_ID_REC, cTDP_ID_REC, cDIR_ID_ENT_REC, cPVE_ID, cPVE_ID_DES, cMON_ID, cTIV_ID, cPER_ID_CLI, cTDP_ID_CLI, cPER_ID_CON, cDOC_FECHA_EMI, cDOC_FECHA_ENT, cDOC_FECHA_EXP, cDIR_ID_FIS, cDIR_ID_DOM, cDIR_ID_ENT, cDIR_ID_COB, cPER_ID_VEN, cPER_ID_COB, cPER_ID_PRO, cPER_ID_GRU, cDOC_TIPO_LISTA, cDOC_MONTO_TOTAL, cDOC_CONTRAVALOR, cDOC_IGV_POR, cDOC_ASIENTO, cDOC_CIERRE, cFLE_ID, cDOC_MONTO_FLE, cDOC_REQUIERE_GUIA, cTDO_ID_AFE, cDTD_ID_AFE, cCCT_ID_AFE, cDOC_SERIE_AFE, cDOC_NUMERO_AFE, cDOC_MOT_EMI, cDOC_NOMBRE_RECEP, cDOC_DNI_RECEP, cDOC_FEC_RECEP, cDOC_ENTREGADO, cCAF_IX_NUMERO_PRO, cCAF_IX_ORDEN_COM, cLPR_ID, cUSU_ID, cDOC_FEC_GRAB, cDOC_ESTADO, cDOC_MONTO_PERCEPCION, cTDO_ID_GEN, cDTD_ID_GEN, cCCT_ID_GEN, cDOC_SERIE_GEN, cDOC_NUMERO_GEN, cDOC_OBSERVACIONES, cDOC_ATENCION, cDOC_HORA_INICIO, cDOC_HORA_FIN)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDOC_SERIE As String, ByVal cDOC_NUMERO As String) As Short Implements IBCDocumentos.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDocumentosRepositorio)()
                    rep.spEliminarRegistro(cTDO_ID, cDTD_ID, cDOC_SERIE, cDOC_NUMERO)
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

        Public Function spInsertarRegistro(ByVal Orm As Documentos) As Short Implements IBCDocumentos.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDocumentosRepositorio)()
                    rep.spInsertarRegistro(Orm)
                    Scope.Complete()
                    spInsertarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    If ex.InnerException Is Nothing Then
                        Orm.vMensajeError = ex.Message
                    Else
                        Orm.vMensajeError = ex.InnerException.Message
                    End If
                    Scope.Dispose()
                    spInsertarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spActualizarDocumentosTIV_ID(ByVal Item As BE.Documentos) As Short Implements IBCDocumentos.spActualizarDocumentosTIV_ID
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDocumentosRepositorio)()
                    rep.spActualizarDocumentosTIV_ID(Item)
                    Scope.Complete()
                    spActualizarDocumentosTIV_ID = 1
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
                    Scope.Dispose()
                    spActualizarDocumentosTIV_ID = 0
                End Try
            End Using
        End Function

        Public Function GetById(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DOC_SERIE As String, ByVal DOC_NUMERO As String) As BE.Documentos Implements IBCDocumentos.GetById
            Dim result As Documentos = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocumentosRepositorio)()
                result = rep.GetById(TDO_ID, DTD_ID, DOC_SERIE, DOC_NUMERO)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
    End Class
End Namespace
