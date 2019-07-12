Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCDetallePrestamo
        Implements IBCDetallePrestamo
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Mantenimiento(ByVal Item As BE.DetallePrestamo) As Short Implements IBCDetallePrestamo.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetallePrestamoRepositorio)()
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
        Public Function DeleteRegistro(ByVal item As DetallePrestamo, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cDPR_SERIE As String, ByVal cDPR_NUMERO As String, ByVal cDPR_ITEM As String) As Short Implements IBCDetallePrestamo.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetallePrestamoRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    DeleteRegistro = rep.DeleteRegistro(item, cTDO_ID, cDTD_ID, cCCC_ID, cDPR_SERIE, cDPR_NUMERO, cDPR_ITEM)
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

        Public Function spActualizarRegistro(ByVal cTDO_ID As String,
           ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cDPR_SERIE As String, ByVal cDPR_NUMERO As String,
           ByVal cCCT_ID As String, ByVal cMON_ID As String, ByVal cDPR_ITEM As Int16, ByVal cPER_ID_CLI As String,
           ByVal cDPR_FEC_VEN As DateTime, ByVal cDPR_CAPITAL As Double, ByVal cDPR_INTERES As Double, ByVal cDPR_GASTOS As Double,
           ByVal cDPR_IMPORTE As Double, ByVal cDPR_CONTRAVALOR As Double, ByVal cDPR_OBSERVACIONES As String, ByVal cTDO_ID_DOC As String,
           ByVal cDTD_ID_DOC As String, ByVal cCCT_ID_DOC As String, ByVal cDPR_SERIE_DOC As String, ByVal cDPR_NUMERO_DOC As String,
           ByVal cPER_ID_CLI_DOC As String, ByVal cUSU_ID As String, ByVal cDPR_FEC_GRAB As DateTime,
           ByVal cDPR_ESTADO As Boolean) As Short Implements IBCDetallePrestamo.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetallePrestamoRepositorio)()
                    rep.spActualizarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cDPR_SERIE, cDPR_NUMERO,
                        cCCT_ID, cMON_ID, cDPR_ITEM, cPER_ID_CLI,
                        cDPR_FEC_VEN, cDPR_CAPITAL, cDPR_INTERES, cDPR_GASTOS,
                        cDPR_IMPORTE, cDPR_CONTRAVALOR, cDPR_OBSERVACIONES, cTDO_ID_DOC,
                        cDTD_ID_DOC, cCCT_ID_DOC, cDPR_SERIE_DOC, cDPR_NUMERO_DOC,
                        cPER_ID_CLI_DOC, cUSU_ID, cDPR_FEC_GRAB, cDPR_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cCCC_ID As String, _
                                    ByVal cDPR_SERIE As String, _
                                    ByVal cDPR_NUMERO As String, _
                                    ByVal cDPR_ITEM As Int16) As Short Implements IBCDetallePrestamo.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetallePrestamoRepositorio)()
                    rep.spEliminarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cDPR_SERIE, cDPR_NUMERO, cDPR_ITEM)
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

        Public Function spEliminarRegistroGeneral(ByVal cTDO_ID As String, _
                                    ByVal cDTD_ID As String, _
                                    ByVal cCCC_ID As String, _
                                    ByVal cDPR_SERIE As String, _
                                    ByVal cDPR_NUMERO As String) As Short Implements IBCDetallePrestamo.spEliminarRegistroGeneral
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetallePrestamoRepositorio)()
                    rep.spEliminarRegistroGeneral(cTDO_ID, cDTD_ID, cCCC_ID, cDPR_SERIE, cDPR_NUMERO)
                    Scope.Complete()
                    spEliminarRegistroGeneral = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spEliminarRegistroGeneral = 0
                End Try
            End Using
        End Function

        Public Function spInsertarRegistro(ByVal cTDO_ID As String,
           ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cDPR_SERIE As String, ByVal cDPR_NUMERO As String,
           ByVal cCCT_ID As String, ByVal cMON_ID As String, ByVal cDPR_ITEM As Int16, ByVal cPER_ID_CLI As String,
           ByVal cDPR_FEC_VEN As DateTime, ByVal cDPR_CAPITAL As Double, ByVal cDPR_INTERES As Double, ByVal cDPR_GASTOS As Double,
           ByVal cDPR_IMPORTE As Double, ByVal cDPR_CONTRAVALOR As Double, ByVal cDPR_OBSERVACIONES As String, ByVal cTDO_ID_DOC As String,
           ByVal cDTD_ID_DOC As String, ByVal cCCT_ID_DOC As String, ByVal cDPR_SERIE_DOC As String, ByVal cDPR_NUMERO_DOC As String,
           ByVal cPER_ID_CLI_DOC As String, ByVal cUSU_ID As String, ByVal cDPR_FEC_GRAB As DateTime,
           ByVal cDPR_ESTADO As Boolean) As Short Implements IBCDetallePrestamo.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDetallePrestamoRepositorio)()
                    rep.spInsertarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cDPR_SERIE, cDPR_NUMERO,
                        cCCT_ID, cMON_ID, cDPR_ITEM, cPER_ID_CLI, cDPR_FEC_VEN, cDPR_CAPITAL, cDPR_INTERES, cDPR_GASTOS,
                        cDPR_IMPORTE, cDPR_CONTRAVALOR, cDPR_OBSERVACIONES, cTDO_ID_DOC,
                        cDTD_ID_DOC, cCCT_ID_DOC, cDPR_SERIE_DOC, cDPR_NUMERO_DOC,
                        cPER_ID_CLI_DOC, cUSU_ID, cDPR_FEC_GRAB, cDPR_ESTADO)
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
