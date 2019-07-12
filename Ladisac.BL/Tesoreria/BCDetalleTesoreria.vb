Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCDetalleTesoreria
        Implements IBCDetalleTesoreria
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Mantenimiento(ByVal Item As BE.DetalleTesoreria) As Short Implements IBCDetalleTesoreria.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleTesoreriaRepositorio)()
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
        Public Function DeleteRegistro(ByVal item As BE.DetalleTesoreria, ByVal cTDO_ID As String, ByVal cCCC_ID As String, ByVal cDTE_SERIE As String, ByVal cDTE_NUMERO As String, ByVal cDTD_ID As String, ByVal cDTE_ITEM As String) As Short Implements IBCDetalleTesoreria.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleTesoreriaRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    DeleteRegistro = rep.DeleteRegistro(item, cTDO_ID, cCCC_ID, cDTE_SERIE, cDTE_NUMERO, cDTD_ID, cDTE_ITEM)
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

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cCCT_ID As String, ByVal cDTE_SERIE As String, ByVal cDTE_NUMERO As String, ByVal cDTE_ITEM As Short, ByVal cCCC_ID_CLI As String, ByVal cDTE_DESTINO As Short, ByVal cCCO_ID As String, ByVal cCUC_ID As String, ByVal cPER_ID_CLI As String, ByVal cTDO_ID_DOC As String, ByVal cDTD_ID_DOC As String, ByVal cCCT_ID_DOC As String, ByVal cDTE_SERIE_DOC As String, ByVal cDTE_NUMERO_DOC As String, ByVal cDTE_FEC_VEN As Date, ByVal cMON_ID_DOC As String, ByVal cDTE_IMPORTE_DOC As Double, ByVal cDTE_CONTRAVALOR_DOC As Double, ByVal cPER_ID_CLI_1 As String, ByVal cTDO_ID_DOC_1 As String, ByVal cDTD_ID_DOC_1 As String, ByVal cCCT_ID_DOC_1 As String, ByVal cDTE_SERIE_DOC_1 As String, ByVal cDTE_NUMERO_DOC_1 As String, ByVal cDTE_FEC_VEN_1 As Date, ByVal cMON_ID_DOC_1 As String, ByVal cDTE_IMPORTE_DOC_1 As Double, ByVal cDTE_CONTRAVALOR_DOC_1 As Double, ByVal cDTE_OBSERVACIONES As String, ByVal cDTE_OPE_CONTABLE As Short, ByVal cDTE_MOVIMIENTO As Short, ByVal cDTE_TIPO_RECIBO As Short, ByVal cDTE_CAPITAL_DOC As Double, ByVal cDTE_INTERES_DOC As Double, ByVal cDTE_GASTOS_DOC As Double, ByVal cDTD_IDe As String, ByVal cUSU_ID As String, ByVal cDTE_FEC_GRAB As Date, ByVal cDTE_ESTADO As Boolean) As Short Implements IBCDetalleTesoreria.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleTesoreriaRepositorio)()
                    rep.spActualizarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cCCT_ID, cDTE_SERIE, cDTE_NUMERO, cDTE_ITEM, cCCC_ID_CLI, cDTE_DESTINO, cCCO_ID, cCUC_ID, cPER_ID_CLI, cTDO_ID_DOC, cDTD_ID_DOC, cCCT_ID_DOC, cDTE_SERIE_DOC, cDTE_NUMERO_DOC, cDTE_FEC_VEN, cMON_ID_DOC, cDTE_IMPORTE_DOC, cDTE_CONTRAVALOR_DOC, cPER_ID_CLI_1, cTDO_ID_DOC_1, cDTD_ID_DOC_1, cCCT_ID_DOC_1, cDTE_SERIE_DOC_1, cDTE_NUMERO_DOC_1, cDTE_FEC_VEN_1, cMON_ID_DOC_1, cDTE_IMPORTE_DOC_1, cDTE_CONTRAVALOR_DOC_1, cDTE_OBSERVACIONES, cDTE_OPE_CONTABLE, cDTE_MOVIMIENTO, cDTE_TIPO_RECIBO, cDTE_CAPITAL_DOC, cDTE_INTERES_DOC, cDTE_GASTOS_DOC, cDTD_IDe, cUSU_ID, cDTE_FEC_GRAB, cDTE_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cDTE_SERIE As String, ByVal cDTE_NUMERO As String, ByVal cDTE_ITEM As Short) As Short Implements IBCDetalleTesoreria.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleTesoreriaRepositorio)()
                    rep.spEliminarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cDTE_SERIE, cDTE_NUMERO, cDTE_ITEM)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cCCT_ID As String, ByVal cDTE_SERIE As String, ByVal cDTE_NUMERO As String, ByVal cDTE_ITEM As Short, ByVal cCCC_ID_CLI As String, ByVal cDTE_DESTINO As Short, ByVal cCCO_ID As String, ByVal cCUC_ID As String, ByVal cPER_ID_CLI As String, ByVal cTDO_ID_DOC As String, ByVal cDTD_ID_DOC As String, ByVal cCCT_ID_DOC As String, ByVal cDTE_SERIE_DOC As String, ByVal cDTE_NUMERO_DOC As String, ByVal cDTE_FEC_VEN As Date, ByVal cMON_ID_DOC As String, ByVal cDTE_IMPORTE_DOC As Double, ByVal cDTE_CONTRAVALOR_DOC As Double, ByVal cPER_ID_CLI_1 As String, ByVal cTDO_ID_DOC_1 As String, ByVal cDTD_ID_DOC_1 As String, ByVal cCCT_ID_DOC_1 As String, ByVal cDTE_SERIE_DOC_1 As String, ByVal cDTE_NUMERO_DOC_1 As String, ByVal cDTE_FEC_VEN_1 As Date, ByVal cMON_ID_DOC_1 As String, ByVal cDTE_IMPORTE_DOC_1 As Double, ByVal cDTE_CONTRAVALOR_DOC_1 As Double, ByVal cDTE_OBSERVACIONES As String, ByVal cDTE_OPE_CONTABLE As Short, ByVal cDTE_MOVIMIENTO As Short, ByVal cDTE_TIPO_RECIBO As Short, ByVal cDTE_CAPITAL_DOC As Double, ByVal cDTE_INTERES_DOC As Double, ByVal cDTE_GASTOS_DOC As Double, ByVal cDTD_IDe As String, ByVal cUSU_ID As String, ByVal cDTE_FEC_GRAB As Date, ByVal cDTE_ESTADO As Boolean) As Short Implements IBCDetalleTesoreria.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetalleTesoreriaRepositorio)()
                    rep.spInsertarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cCCT_ID, cDTE_SERIE, cDTE_NUMERO, cDTE_ITEM, cCCC_ID_CLI, cDTE_DESTINO, cCCO_ID, cCUC_ID, cPER_ID_CLI, cTDO_ID_DOC, cDTD_ID_DOC, cCCT_ID_DOC, cDTE_SERIE_DOC, cDTE_NUMERO_DOC, cDTE_FEC_VEN, cMON_ID_DOC, cDTE_IMPORTE_DOC, cDTE_CONTRAVALOR_DOC, cPER_ID_CLI_1, cTDO_ID_DOC_1, cDTD_ID_DOC_1, cCCT_ID_DOC_1, cDTE_SERIE_DOC_1, cDTE_NUMERO_DOC_1, cDTE_FEC_VEN_1, cMON_ID_DOC_1, cDTE_IMPORTE_DOC_1, cDTE_CONTRAVALOR_DOC_1, cDTE_OBSERVACIONES, cDTE_OPE_CONTABLE, cDTE_MOVIMIENTO, cDTE_TIPO_RECIBO, cDTE_CAPITAL_DOC, cDTE_INTERES_DOC, cDTE_GASTOS_DOC, cDTD_IDe, cUSU_ID, cDTE_FEC_GRAB, cDTE_ESTADO)
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
