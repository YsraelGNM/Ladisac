Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCMovimientoCajaBanco
        Implements IBCMovimientoCajaBanco

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        Public Function Mantenimiento(ByVal Item As BE.MovimientoCajaBanco) As Short Implements IBCMovimientoCajaBanco.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMovimientoCajaBancoRepositorio)()
                'Using Scope As New System.Transactions.TransactionScope()
                If Item.ChangeTracker.State <> ObjectState.Deleted Then
                    If Item.ProcesarVerificarDatos() = 0 Then
                        Mantenimiento = 0
                        Exit Function
                    End If
                End If
                Mantenimiento = rep.Maintenance(Item)
                'Scope.Complete()
                'End Using
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

        Public Function spEliminarMovimientoCajaBanco(ByVal cDocumento As String, ByVal cItem As Int16) As Short Implements IBCMovimientoCajaBanco.spEliminarMovimientoCajaBanco
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IMovimientoCajaBancoRepositorio)()
                    rep.spEliminarMovimientoCajaBanco(cDocumento, cItem)
                    Scope.Complete()
                    spEliminarMovimientoCajaBanco = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spEliminarMovimientoCajaBanco = 0
                End Try
            End Using
        End Function

        Public Function DeleteRegistro(ByVal item As BE.MovimientoCajaBanco, ByVal cDocumento As String, ByVal cITEM As Short) As Short Implements IBCMovimientoCajaBanco.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMovimientoCajaBancoRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    DeleteRegistro = rep.DeleteRegistro(item, cDocumento, cITEM)
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

        Public Function ItemMovimientoCajaBanco(ByVal cCcc_Id As String, ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cTes_Serie As String, ByVal cTes_Numero As String) As Integer Implements IBCMovimientoCajaBanco.ItemMovimientoCajaBanco
            Dim result As String = ""
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spItemMovimientoCajaBancoXML, cCcc_Id, cTdo_Id, cDtd_Id, cTes_Serie, cTes_Numero))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarEnteroXML(sr, "item")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ItemMovimientoCajaBancoExtorno(ByVal cCcc_Id As String, ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cTex_Serie As String, ByVal cTex_Numero As String) As Integer Implements IBCMovimientoCajaBanco.ItemMovimientoCajaBancoExtorno
            Dim result As String = ""
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spItemMovimientoCajaBancoExtornoXML, cCcc_Id, cTdo_Id, cDtd_Id, cTex_Serie, cTex_Numero))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarEnteroXML(sr, "item")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function spActualizarRegistro(ByVal citem As Short, ByVal cTes_Fecha_Emi As Date, ByVal cCco_Id As String, ByVal cCuc_Id As String, ByVal cTes_Monto_total As Double, ByVal cCcc_Id As String, ByVal cCct_Id As String, ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cTes_Serie As String, ByVal cTes_Numero As String, ByVal cCargo As Double, ByVal cAbono As Double, ByVal cDte_ContraValor_Doc As Double, ByVal cPer_Id_Ban As String, ByVal cPer_Id_Cli As String, ByVal cCcc_Id_Cli As String, ByVal cCct_Id_Doc As String, ByVal cTdo_Id_Doc As String, ByVal cDtd_Id_Doc As String, ByVal cDte_Serie_Doc As String, ByVal cDte_Numero_Doc As String, ByVal cDte_Observaciones As String, ByVal cDOCUMENTO As String) As Short Implements IBCMovimientoCajaBanco.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IMovimientoCajaBancoRepositorio)()
                    rep.spActualizarRegistro(citem, cTes_Fecha_Emi, cCco_Id, cCuc_Id, cTes_Monto_total, cCcc_Id, cCct_Id, cTdo_Id, cDtd_Id, cTes_Serie, cTes_Numero, cCargo, cAbono, cDte_ContraValor_Doc, cPer_Id_Ban, cPer_Id_Cli, cCcc_Id_Cli, cCct_Id_Doc, cTdo_Id_Doc, cDtd_Id_Doc, cDte_Serie_Doc, cDte_Numero_Doc, cDte_Observaciones, cDOCUMENTO)
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

        Public Function spActualizarRegistroExtorno(ByVal citem As Short, ByVal cTes_Fecha_Emi As Date, ByVal cCco_Id As String, ByVal cCuc_Id As String, ByVal cTes_Monto_total As Double, ByVal cCcc_Id As String, ByVal cCct_Id As String, ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cTes_Serie As String, ByVal cTes_Numero As String, ByVal cCargo As Double, ByVal cAbono As Double, ByVal cDte_ContraValor_Doc As Double, ByVal cPer_Id_Ban As String, ByVal cPer_Id_Cli As String, ByVal cCcc_Id_Cli As String, ByVal cCct_Id_Doc As String, ByVal cTdo_Id_Doc As String, ByVal cDtd_Id_Doc As String, ByVal cDte_Serie_Doc As String, ByVal cDte_Numero_Doc As String, ByVal cDte_Observaciones As String, ByVal cDOCUMENTO As String, ByVal cTipo As String) As Short Implements IBCMovimientoCajaBanco.spActualizarRegistroExtorno
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IMovimientoCajaBancoRepositorio)()
                    rep.spActualizarRegistroExtorno(citem, cTes_Fecha_Emi, cCco_Id, cCuc_Id, cTes_Monto_total, cCcc_Id, cCct_Id, cTdo_Id, cDtd_Id, cTes_Serie, cTes_Numero, cCargo, cAbono, cDte_ContraValor_Doc, cPer_Id_Ban, cPer_Id_Cli, cCcc_Id_Cli, cCct_Id_Doc, cTdo_Id_Doc, cDtd_Id_Doc, cDte_Serie_Doc, cDte_Numero_Doc, cDte_Observaciones, cDOCUMENTO, cTipo)
                    Scope.Complete()
                    spActualizarRegistroExtorno = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spActualizarRegistroExtorno = 0
                End Try
            End Using
        End Function

        Public Function spEliminarRegistro(ByVal cITEM As Short, ByVal cDOCUMENTO As String) As Short Implements IBCMovimientoCajaBanco.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IMovimientoCajaBancoRepositorio)()
                    rep.spEliminarRegistro(cITEM, cDOCUMENTO)
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

        Public Function spEliminarRegistroExtorno(ByVal cITEM As Short, ByVal cDOCUMENTO As String) As Short Implements IBCMovimientoCajaBanco.spEliminarRegistroExtorno
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IMovimientoCajaBancoRepositorio)()
                    rep.spEliminarRegistroExtorno(cITEM, cDOCUMENTO)
                    Scope.Complete()
                    spEliminarRegistroExtorno = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spEliminarRegistroExtorno = 0
                End Try
            End Using
        End Function

        Public Function spInsertarRegistro(ByVal citem As Short, ByVal cTes_Fecha_Emi As Date, ByVal cCco_Id As String, ByVal cCuc_Id As String, ByVal cTes_Monto_total As Double, ByVal cCcc_Id As String, ByVal cCct_Id As String, ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cTes_Serie As String, ByVal cTes_Numero As String, ByVal cCargo As Double, ByVal cAbono As Double, ByVal cDte_ContraValor_Doc As Double, ByVal cPer_Id_Ban As String, ByVal cPer_Id_Cli As String, ByVal cCcc_Id_Cli As String, ByVal cCct_Id_Doc As String, ByVal cTdo_Id_Doc As String, ByVal cDtd_Id_Doc As String, ByVal cDte_Serie_Doc As String, ByVal cDte_Numero_Doc As String, ByVal cDte_Observaciones As String, ByVal cDOCUMENTO As String) As Short Implements IBCMovimientoCajaBanco.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IMovimientoCajaBancoRepositorio)()
                    rep.spInsertarRegistro(citem, cTes_Fecha_Emi, cCco_Id, cCuc_Id, cTes_Monto_total, cCcc_Id, cCct_Id, cTdo_Id, cDtd_Id, cTes_Serie, cTes_Numero, cCargo, cAbono, cDte_ContraValor_Doc, cPer_Id_Ban, cPer_Id_Cli, cCcc_Id_Cli, cCct_Id_Doc, cTdo_Id_Doc, cDtd_Id_Doc, cDte_Serie_Doc, cDte_Numero_Doc, cDte_Observaciones, cDOCUMENTO)
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
