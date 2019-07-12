Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCMedioPagoTesoreria
        Implements IBCMedioPagoTesoreria

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Mantenimiento(ByVal Item As BE.MedioPagoTesoreria) As Short Implements IBCMedioPagoTesoreria.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMedioPagoTesoreriaRepositorio)()
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
        Public Function DeleteRegistro(ByVal item As BE.MedioPagoTesoreria, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cMPT_SERIE As String, ByVal cMPT_NUMERO As String, ByVal cMPT_ITEM As String) As Short Implements IBCMedioPagoTesoreria.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMedioPagoTesoreriaRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    DeleteRegistro = rep.DeleteRegistro(item, cTDO_ID, cDTD_ID, cCCC_ID, cMPT_SERIE, cMPT_NUMERO, cMPT_ITEM)
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

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cMPT_SERIE As String, ByVal cMPT_NUMERO As String, ByVal cMPT_ITEM As Short, ByVal cMPT_IMPORTE_AFECTO As Double, ByVal cMPT_PORCENTAJE As Double, ByVal cCHE_ID As String, ByVal cMPT_MEDIO_PAGO As Short, ByVal cMPT_SERIE_MEDIO As String, ByVal cMPT_NUMERO_MEDIO As String, ByVal cMPT_GIRADO_A As String, ByVal cMPT_CONCEPTO As String, ByVal cMPT_UBICACION As Short, ByVal cPER_ID_BAN As String, ByVal cMPT_DIFERIDO As Boolean, ByVal cMPT_FECHA_DIFERIDO As Date, ByVal cMPT_RECEPCION As Short, ByVal cUSU_ID As String, ByVal cMPT_FEC_GRAB As Date, ByVal cMPT_ESTADO As Boolean) As Short Implements IBCMedioPagoTesoreria.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IMedioPagoTesoreriaRepositorio)()
                    rep.spActualizarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cMPT_SERIE, cMPT_NUMERO, cMPT_ITEM, cMPT_IMPORTE_AFECTO, cMPT_PORCENTAJE, cCHE_ID, cMPT_MEDIO_PAGO, cMPT_SERIE_MEDIO, cMPT_NUMERO_MEDIO, cMPT_GIRADO_A, cMPT_CONCEPTO, cMPT_UBICACION, cPER_ID_BAN, cMPT_DIFERIDO, cMPT_FECHA_DIFERIDO, cMPT_RECEPCION, cUSU_ID, cMPT_FEC_GRAB, cMPT_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cMPT_SERIE As String, ByVal cMPT_NUMERO As String, ByVal cMPT_ITEM As Short) As Short Implements IBCMedioPagoTesoreria.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IMedioPagoTesoreriaRepositorio)()
                    rep.spEliminarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cMPT_SERIE, cMPT_NUMERO, cMPT_ITEM)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cMPT_SERIE As String, ByVal cMPT_NUMERO As String, ByVal cMPT_ITEM As Short, ByVal cMPT_IMPORTE_AFECTO As Double, ByVal cMPT_PORCENTAJE As Double, ByVal cCHE_ID As String, ByVal cMPT_MEDIO_PAGO As Short, ByVal cMPT_SERIE_MEDIO As String, ByVal cMPT_NUMERO_MEDIO As String, ByVal cMPT_GIRADO_A As String, ByVal cMPT_CONCEPTO As String, ByVal cMPT_UBICACION As Short, ByVal cPER_ID_BAN As String, ByVal cMPT_DIFERIDO As Boolean, ByVal cMPT_FECHA_DIFERIDO As Date, ByVal cMPT_RECEPCION As Short, ByVal cUSU_ID As String, ByVal cMPT_FEC_GRAB As Date, ByVal cMPT_ESTADO As Boolean) As Short Implements IBCMedioPagoTesoreria.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IMedioPagoTesoreriaRepositorio)()
                    rep.spInsertarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cMPT_SERIE, cMPT_NUMERO, cMPT_ITEM, cMPT_IMPORTE_AFECTO, cMPT_PORCENTAJE, cCHE_ID, cMPT_MEDIO_PAGO, cMPT_SERIE_MEDIO, cMPT_NUMERO_MEDIO, cMPT_GIRADO_A, cMPT_CONCEPTO, cMPT_UBICACION, cPER_ID_BAN, cMPT_DIFERIDO, cMPT_FECHA_DIFERIDO, cMPT_RECEPCION, cUSU_ID, cMPT_FEC_GRAB, cMPT_ESTADO)
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

        Public Function spEliminarRegistroGeneral(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cMPT_SERIE As String, ByVal cMPT_NUMERO As String) As Short Implements IBCMedioPagoTesoreria.spEliminarRegistroGeneral
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IMedioPagoTesoreriaRepositorio)()
                    rep.spEliminarRegistroGeneral(cTDO_ID, cDTD_ID, cCCC_ID, cMPT_SERIE, cMPT_NUMERO)
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

        Public Function spActualizarMPT_UBICACION(ByVal cTDO_ID As String, ByVal cCCC_ID As String, ByVal cPER_ID_BAN As String, ByVal cMPT_SERIE_MEDIO As String, ByVal cMPT_NUMERO_MEDIO As String, ByVal cMPT_UBICACION As Int16) As Short Implements IBCMedioPagoTesoreria.spActualizarMPT_UBICACION
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IMedioPagoTesoreriaRepositorio)()
                    rep.spActualizarMPT_UBICACION(cTDO_ID, cCCC_ID, cPER_ID_BAN, cMPT_SERIE_MEDIO, cMPT_NUMERO_MEDIO, cMPT_UBICACION)
                    Scope.Complete()
                    spActualizarMPT_UBICACION = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spActualizarMPT_UBICACION = 0
                End Try
            End Using
        End Function
    End Class
End Namespace
