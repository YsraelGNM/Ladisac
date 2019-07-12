Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCTesoreria
        Implements IBCTesoreria
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Mantenimiento(ByVal Item As BE.Tesoreria) As Short Implements IBCTesoreria.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITesoreriaRepositorio)()
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
        Public Function DeleteRegistro(ByVal item As BE.Tesoreria, ByVal cTDO_ID As String, ByVal cCCC_ID As String, ByVal cTES_SERIE As String, ByVal cTES_NUMERO As String, ByVal cDTD_ID As String) As Short Implements IBCTesoreria.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITesoreriaRepositorio)()
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

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cTES_SERIE As String, ByVal cTES_NUMERO As String, ByVal cTES_FECHA_EMI As Date, ByVal cPVE_ID As String, ByVal cPER_ID_CAJ As String, ByVal cTES_MONTO_TOTAL As Double, ByVal cTES_ASIENTO As Boolean, ByVal cTES_CIERRE As Short, ByVal cUSU_ID As String, ByVal cTES_FEC_GRAB As Date, ByVal cTES_ESTADO As Boolean) As Short Implements IBCTesoreria.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.ITesoreriaRepositorio)()
                    rep.spActualizarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cTES_SERIE, cTES_NUMERO, cTES_FECHA_EMI, cPVE_ID, cPER_ID_CAJ, cTES_MONTO_TOTAL, cTES_ASIENTO, cTES_CIERRE, cUSU_ID, cTES_FEC_GRAB, cTES_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cTES_SERIE As String, ByVal cTES_NUMERO As String) As Short Implements IBCTesoreria.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.ITesoreriaRepositorio)()
                    rep.spEliminarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cTES_SERIE, cTES_NUMERO)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cTES_SERIE As String, ByVal cTES_NUMERO As String, ByVal cTES_FECHA_EMI As Date, ByVal cPVE_ID As String, ByVal cPER_ID_CAJ As String, ByVal cTES_MONTO_TOTAL As Double, ByVal cTES_ASIENTO As Boolean, ByVal cTES_CIERRE As Short, ByVal cUSU_ID As String, ByVal cTES_FEC_GRAB As Date, ByVal cTES_ESTADO As Boolean) As Short Implements IBCTesoreria.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.ITesoreriaRepositorio)()
                    rep.spInsertarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cTES_SERIE, cTES_NUMERO, cTES_FECHA_EMI, cPVE_ID, cPER_ID_CAJ, cTES_MONTO_TOTAL, cTES_ASIENTO, cTES_CIERRE, cUSU_ID, cTES_FEC_GRAB, cTES_ESTADO)
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
