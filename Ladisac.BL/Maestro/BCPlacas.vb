Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCPlacas
        Implements IBCPlacas

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Mantenimiento(ByVal Item As BE.Placas) As Short Implements IBCPlacas.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPlacasRepositorio)()
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
                Item.vMensajeError = ex.InnerException.Message
                Mantenimiento = 0
            End Try
        End Function

        Public Function ListaPlacas(ByVal PER_Id As String) As String Implements IBCPlacas.ListaPlacas
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaPlacas", PER_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function spActualizarRegistro(ByVal cPLA_ID As String, ByVal cUNT_ID_1 As String, ByVal cUNT_ID_2 As String, ByVal cPER_ID As String, ByVal cUSU_ID As String, ByVal cPLA_FEC_GRAB As Date, ByVal cPLA_ESTADO As Boolean) As Short Implements IBCPlacas.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IPlacasRepositorio)()
                    rep.spActualizarRegistro(cPLA_ID, cUNT_ID_1, cUNT_ID_2, cPER_ID, cUSU_ID, cPLA_FEC_GRAB, cPLA_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cPLA_ID As String) As Short Implements IBCPlacas.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IPlacasRepositorio)()
                    rep.spEliminarRegistro(cPLA_ID)
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

        Public Function spInsertarRegistro(ByVal cPLA_ID As String, ByVal cUNT_ID_1 As String, ByVal cUNT_ID_2 As String, ByVal cPER_ID As String, ByVal cUSU_ID As String, ByVal cPLA_FEC_GRAB As Date, ByVal cPLA_ESTADO As Boolean) As Short Implements IBCPlacas.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IPlacasRepositorio)()
                    rep.spInsertarRegistro(cPLA_ID, cUNT_ID_1, cUNT_ID_2, cPER_ID, cUSU_ID, cPLA_FEC_GRAB, cPLA_ESTADO)
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