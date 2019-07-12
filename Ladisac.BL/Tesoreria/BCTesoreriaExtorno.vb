Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCTesoreriaExtorno
        Implements IBCTesoreriaExtorno
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cTEX_SERIE As String, ByVal cTEX_NUMERO As String, ByVal cTEX_FECHA_EMI As Date, ByVal cUSU_ID As String, ByVal cTEX_FEC_GRAB As Date, ByVal cTEX_ESTADO As Boolean) As Short Implements IBCTesoreriaExtorno.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.ITesoreriaExtornoRepositorio)()
                    rep.spActualizarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cTEX_SERIE, cTEX_NUMERO, cTEX_FECHA_EMI, cUSU_ID, cTEX_FEC_GRAB, cTEX_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cTEX_SERIE As String, ByVal cTEX_NUMERO As String) As Short Implements IBCTesoreriaExtorno.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.ITesoreriaExtornoRepositorio)()
                    rep.spEliminarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cTEX_SERIE, cTEX_NUMERO)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cTEX_SERIE As String, ByVal cTEX_NUMERO As String, ByVal cTEX_FECHA_EMI As Date, ByVal cUSU_ID As String, ByVal cTEX_FEC_GRAB As Date, ByVal cTEX_ESTADO As Boolean) As Short Implements IBCTesoreriaExtorno.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.ITesoreriaExtornoRepositorio)()
                    rep.spInsertarRegistro(cTDO_ID, cDTD_ID, cCCC_ID, cTEX_SERIE, cTEX_NUMERO, cTEX_FECHA_EMI, cUSU_ID, cTEX_FEC_GRAB, cTEX_ESTADO)
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
