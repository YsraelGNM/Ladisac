Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCPrestamo
        Implements IBCPrestamo
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Mantenimiento(ByVal Item As BE.Prestamo) As Short Implements IBCPrestamo.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPrestamoRepositorio)()
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
        Public Function DeleteRegistro(ByVal item As BE.Prestamo, ByVal cTDO_ID As String, ByVal cCCC_ID As String, ByVal cTES_SERIE As String, ByVal cTES_NUMERO As String, ByVal cDTD_ID As String) As Short Implements IBCPrestamo.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPrestamoRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    DeleteRegistro = rep.DeleteRegistro(item, cTDO_ID, cCCC_ID, cTES_SERIE, cTES_NUMERO, cDTD_ID)
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

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, _
           ByVal cDTD_ID As String, _
           ByVal cCCC_ID As String, _
           ByVal cPRE_SERIE As String, _
           ByVal cPRE_NUMERO As String, _
           ByVal cPRE_FECHA_EMI As DateTime, _
           ByVal cPVE_ID As String, _
           ByVal cPER_ID_CAJ As String, _
           ByVal cPRE_MONTO_TOTAL As Double, _
           ByVal cPRE_TIPO As Boolean, _
           ByVal cUSU_ID As String, _
           ByVal cPRE_FEC_GRAB As DateTime, _
           ByVal cPRE_ESTADO As Boolean) As Short Implements IBCPrestamo.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IPrestamoRepositorio)()
                    rep.spActualizarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cPRE_SERIE, cPRE_NUMERO, cPRE_FECHA_EMI, cPVE_ID, cPER_ID_CAJ, cPRE_MONTO_TOTAL, cPRE_TIPO, cUSU_ID, cPRE_FEC_GRAB, cPRE_ESTADO)
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
                                    ByVal cPRE_SERIE As String, _
                                    ByVal cPRE_NUMERO As String) As Short Implements IBCPrestamo.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IPrestamoRepositorio)()
                    rep.spEliminarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cPRE_SERIE, cPRE_NUMERO)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, _
           ByVal cDTD_ID As String, _
           ByVal cCCC_ID As String, _
           ByVal cPRE_SERIE As String, _
           ByVal cPRE_NUMERO As String, _
           ByVal cPRE_FECHA_EMI As DateTime, _
           ByVal cPVE_ID As String, _
           ByVal cPER_ID_CAJ As String, _
           ByVal cPRE_MONTO_TOTAL As Double, _
           ByVal cPRE_TIPO As Boolean, _
           ByVal cUSU_ID As String, _
           ByVal cPRE_FEC_GRAB As DateTime, _
           ByVal cPRE_ESTADO As Boolean) As Short Implements IBCPrestamo.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IPrestamoRepositorio)()
                    rep.spInsertarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cPRE_SERIE, cPRE_NUMERO, cPRE_FECHA_EMI, cPVE_ID, cPER_ID_CAJ, cPRE_MONTO_TOTAL, cPRE_TIPO, cUSU_ID, cPRE_FEC_GRAB, cPRE_ESTADO)
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

        Public Function spActualizarEnlace(ByVal PRE_SERIE As String, ByVal PRE_NUMERO As String, ByVal CCT_IDe As String, ByVal Orm As BE.Tesoreria) As Short Implements IBCPrestamo.spActualizarEnlace
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IPrestamoRepositorio)()
                    rep.spActualizarEnlace(PRE_SERIE, PRE_NUMERO, CCT_IDe, Orm)
                    Scope.Complete()
                    spActualizarEnlace = 1
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
                    spActualizarEnlace = 0
                End Try
            End Using
        End Function
        Public Function spEliminarEnlace(ByVal PRE_SERIE As String, ByVal PRE_NUMERO As String, ByVal CCT_IDe As String, ByVal Orm As BE.Tesoreria) As Short Implements IBCPrestamo.spEliminarEnlace
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IPrestamoRepositorio)()
                    rep.spEliminarEnlace(PRE_SERIE, PRE_NUMERO, CCT_IDe, Orm)
                    Scope.Complete()
                    spEliminarEnlace = 1
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
                    spEliminarEnlace = 0
                End Try
            End Using
        End Function
    End Class
End Namespace
