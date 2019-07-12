Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCUnidadesTransporte
        Implements IBCUnidadesTransporte

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaUnidadesTransporte() As String Implements IBCUnidadesTransporte.ListaUnidadesTransporte
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IUnidadesTransporteRepositorio)()
                result = rep.ListaUnidadesTransporte
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function UnidadesTransporteGetById(ByVal UNT_ID As String) As BE.UnidadesTransporte Implements IBCUnidadesTransporte.UnidadesTransporteGetById

        End Function

        Public Function Mantenimiento(ByVal Item As BE.UnidadesTransporte) As Short Implements IBCUnidadesTransporte.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IUnidadesTransporteRepositorio)()
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

        Public Function ListaUnidadesTransporteEmpresa(ByVal PER_ID As String) As String Implements IBCUnidadesTransporte.ListaUnidadesTransporteEmpresa
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaUnidadesTransporteEmpresa", PER_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaUnidadesTransporteSalidaCombustible(ByVal UNT_ID As String) As String Implements IBCUnidadesTransporte.ListaUnidadesTransporteSalidaCombustible
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaUnidadesTransporteSalidaCombustible", UNT_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function spActualizarRegistro(ByVal cUNT_ID As String, ByVal cUNT_COMPORTAMIENTO As Short, ByVal cUNT_TIPO As Short, ByVal cTUN_ID As String, ByVal cMAR_ID As String, ByVal cMOD_ID As String, ByVal cUNT_TARA As Double, ByVal cUNT_NRO_INS As String, ByVal cPER_ID As String, ByVal cUNT_KILOMETRAJE As Double, ByVal cUNT_HOROMETRO As Double, ByVal cUNT_NRO_SERIE As String, ByVal cUNT_NRO_MOTOR As String, ByVal cUNT_ANIO_FABRICACION As Short, ByVal cUNT_FECHA_ADQUISICION As Date, ByVal cUSU_ID As String, ByVal cUNT_FEC_GRAB As Date, ByVal cUNT_ESTADO As Boolean) As Short Implements IBCUnidadesTransporte.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IUnidadesTransporteRepositorio)()
                    rep.spActualizarRegistro(cUNT_ID, cUNT_COMPORTAMIENTO, cUNT_TIPO, cTUN_ID, cMAR_ID, cMOD_ID, cUNT_TARA, cUNT_NRO_INS, cPER_ID, cUNT_KILOMETRAJE, cUNT_HOROMETRO, cUNT_NRO_SERIE, cUNT_NRO_MOTOR, cUNT_ANIO_FABRICACION, cUNT_FECHA_ADQUISICION, cUSU_ID, cUNT_FEC_GRAB, cUNT_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cUNT_ID As String) As Short Implements IBCUnidadesTransporte.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IUnidadesTransporteRepositorio)()
                    rep.spEliminarRegistro(cUNT_ID)
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

        Public Function spInsertarRegistro(ByVal cUNT_ID As String, ByVal cUNT_COMPORTAMIENTO As Short, ByVal cUNT_TIPO As Short, ByVal cTUN_ID As String, ByVal cMAR_ID As String, ByVal cMOD_ID As String, ByVal cUNT_TARA As Double, ByVal cUNT_NRO_INS As String, ByVal cPER_ID As String, ByVal cUNT_KILOMETRAJE As Double, ByVal cUNT_HOROMETRO As Double, ByVal cUNT_NRO_SERIE As String, ByVal cUNT_NRO_MOTOR As String, ByVal cUNT_ANIO_FABRICACION As Short, ByVal cUNT_FECHA_ADQUISICION As Date, ByVal cUSU_ID As String, ByVal cUNT_FEC_GRAB As Date, ByVal cUNT_ESTADO As Boolean) As Short Implements IBCUnidadesTransporte.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IUnidadesTransporteRepositorio)()
                    rep.spInsertarRegistro(cUNT_ID, cUNT_COMPORTAMIENTO, cUNT_TIPO, cTUN_ID, cMAR_ID, cMOD_ID, cUNT_TARA, cUNT_NRO_INS, cPER_ID, cUNT_KILOMETRAJE, cUNT_HOROMETRO, cUNT_NRO_SERIE, cUNT_NRO_MOTOR, cUNT_ANIO_FABRICACION, cUNT_FECHA_ADQUISICION, cUSU_ID, cUNT_FEC_GRAB, cUNT_ESTADO)
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

        Public Function ListaUnidadesTransporteXPlaca(ByVal UNT_ID As String) As String Implements IBCUnidadesTransporte.ListaUnidadesTransporteXPlaca
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaUnidadesTransporteXPlaca", UNT_ID)
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
