Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCListaPreciosArticulos
        Implements IBCListaPreciosArticulos

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function MantenimientoListaPreciosArticulos(ByVal Item As BE.ListaPreciosArticulos) As Short Implements IBCListaPreciosArticulos.MantenimientoListaPreciosArticulos
            Try
                Dim rep = ContainerService.Resolve(Of DA.IListaPreciosArticulosRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoListaPreciosArticulos = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoListaPreciosArticulos = rep.Maintenance(Item)
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

                MantenimientoListaPreciosArticulos = 0
            End Try
        End Function

        Public Function spActualizarRegistro(ByVal cLPR_ID As String, ByVal cLPR_DESCRIPCION As String, ByVal cLPR_PRINCIPAL As Boolean, ByVal cPER_ID As String, ByVal cMON_ID As String, ByVal cUSU_ID As String, ByVal cLPR_FEC_GRAB As Date, ByVal cLPR_ESTADO As Boolean, ByVal cLPR_CONTROL As Boolean, ByVal cLPR_ID_ADJ As String) As Short Implements IBCListaPreciosArticulos.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IListaPreciosArticulosRepositorio)()
                    rep.spActualizarRegistro(cLPR_ID, cLPR_DESCRIPCION, cLPR_PRINCIPAL, cPER_ID, cMON_ID, cUSU_ID, cLPR_FEC_GRAB, cLPR_ESTADO, cLPR_CONTROL, cLPR_ID_ADJ)
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

        Public Function spEliminarRegistro(ByVal cLPR_ID As String) As Short Implements IBCListaPreciosArticulos.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IListaPreciosArticulosRepositorio)()
                    rep.spEliminarRegistro(cLPR_ID)
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

        Public Function spInsertarRegistro(ByVal cLPR_ID As String, ByVal cLPR_DESCRIPCION As String, ByVal cLPR_PRINCIPAL As Boolean, ByVal cPER_ID As String, ByVal cMON_ID As String, ByVal cUSU_ID As String, ByVal cLPR_FEC_GRAB As Date, ByVal cLPR_ESTADO As Boolean, ByVal cLPR_CONTROL As Boolean, ByVal cLPR_ID_ADJ As String) As Short Implements IBCListaPreciosArticulos.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IListaPreciosArticulosRepositorio)()
                    rep.spInsertarRegistro(cLPR_ID, cLPR_DESCRIPCION, cLPR_PRINCIPAL, cPER_ID, cMON_ID, cUSU_ID, cLPR_FEC_GRAB, cLPR_ESTADO, cLPR_CONTROL, cLPR_ID_ADJ)
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

        Public Function spDetalleListaPreciosUpdate(ByVal registroxm As String, ByVal art_id As String, ByVal precio As Double) As Object Implements IBCListaPreciosArticulos.spDetalleListaPreciosUpdate
            Dim result As Integer = -1
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                Dim rep = ContainerService.Resolve(Of DA.IListaPreciosArticulosRepositorio)()
                result = rep.spDetalleListaPreciosUpdate(registroxm, art_id, precio)
                'Scope.Complete()

                'End Using

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result

        End Function

        Public Function spListaPreciosXTipo(ByVal TPE_ID As String) As Object Implements IBCListaPreciosArticulos.spListaPreciosXTipo
            Dim result As DataTable = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spListaPreciosXTipo, TPE_ID)
                'Scope.Complete()

                'End Using

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result
        End Function
        'spDetalleListaPreciosRecargaUpdate
        Public Function spDetalleListaPreciosRecargaUpdate(ByVal registroxm As String, ByVal art_id As String, ByVal precio As Double) As Object Implements IBCListaPreciosArticulos.spDetalleListaPreciosRecargaUpdate
            Dim result As Integer = -1
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                Dim rep = ContainerService.Resolve(Of DA.IListaPreciosArticulosRepositorio)()
                result = rep.spDetalleListaPreciosRecargaUpdate(registroxm, art_id, precio)
                'Scope.Complete()

                'End Using

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result
        End Function

        Public Function spDetalleListaPreciosUpdateInsert(ByVal DatosModeloXml As String, ByVal DatosListaXml As String, ByVal cUSU_ID As String) As Object Implements IBCListaPreciosArticulos.spDetalleListaPreciosUpdateInsert
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IListaPreciosArticulosRepositorio)()
                    rep.spDetalleListaPreciosUpdateInsert(DatosModeloXml, DatosListaXml, cUSU_ID)
                    Scope.Complete()
                    spDetalleListaPreciosUpdateInsert = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    Scope.Dispose()
                    spDetalleListaPreciosUpdateInsert = 0
                End Try
            End Using
        End Function

        Public Function spListaPrecioArticulo(ByVal PVE_ID As String, ByVal ART_ID As String, ByVal PER_ID As String) As String Implements IBCListaPreciosArticulos.spListaPrecioArticulo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaPrecioArticulo", PVE_ID, ART_ID, PER_ID)
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
