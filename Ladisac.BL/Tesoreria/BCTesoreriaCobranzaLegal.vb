Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCTesoreriaCobranzaLegal
        Implements IBCTesoreriaCobranzaLegal
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCT_ID As String, ByVal cTCL_SERIE As String, ByVal cTCL_NUMERO As String, ByVal cTCL_FECHA_EMI As Date, ByVal cPER_ID_CLI As String, ByVal cMON_ID As String, ByVal cTCL_MONTO As Decimal, ByVal cUSU_ID As String, ByVal cTCL_FEC_GRAB As Date, ByVal cTCL_ESTADO As Boolean) As Short Implements IBCTesoreriaCobranzaLegal.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.ITesoreriaCobranzaLegalRepositorio)()
                    rep.spActualizarRegistro(cTDO_ID, cDTD_ID, cCCT_ID, cTCL_SERIE, cTCL_NUMERO, cTCL_FECHA_EMI, cPER_ID_CLI, cMON_ID, cTCL_MONTO, cUSU_ID, cTCL_FEC_GRAB, cTCL_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cTCL_SERIE As String, ByVal cTCL_NUMERO As String, ByVal cPER_ID_CLI As String) As Short Implements IBCTesoreriaCobranzaLegal.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.ITesoreriaCobranzaLegalRepositorio)()
                    rep.spEliminarRegistro(cTDO_ID, cDTD_ID, cTCL_SERIE, cTCL_NUMERO, cPER_ID_CLI)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCT_ID As String, ByVal cTCL_SERIE As String, ByVal cTCL_NUMERO As String, ByVal cTCL_FECHA_EMI As Date, ByVal cPER_ID_CLI As String, ByVal cMON_ID As String, ByVal cTCL_MONTO As Decimal, ByVal cUSU_ID As String, ByVal cTCL_FEC_GRAB As Date, ByVal cTCL_ESTADO As Boolean) As Short Implements IBCTesoreriaCobranzaLegal.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.ITesoreriaCobranzaLegalRepositorio)()
                    rep.spInsertarRegistro(cTDO_ID, cDTD_ID, cCCT_ID, cTCL_SERIE, cTCL_NUMERO, cTCL_FECHA_EMI, cPER_ID_CLI, cMON_ID, cTCL_MONTO, cUSU_ID, cTCL_FEC_GRAB, cTCL_ESTADO)
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
