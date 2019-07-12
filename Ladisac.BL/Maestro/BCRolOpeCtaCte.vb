Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCRolOpeCtaCte
        Implements IBCRolOpeCtaCte
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Mantenimiento(ByVal Item As BE.RolOpeCtaCte) As Short Implements IBCRolOpeCtaCte.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRolOpeCtaCteRepositorio)()
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

        Public Function CargoAbonoRolOpeCtaCte(ByVal CCT_ID As String, ByVal TDO_ID As String, ByVal DTD_ID As String) As String Implements IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spCargoAbonoRolOpeCtaCte, CCT_ID, TDO_ID, DTD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SignoCargoAbonoRolOpeCtaCte(ByVal CCT_ID As String, ByVal TDO_ID As String, ByVal DTD_ID As String) As String Implements IBCRolOpeCtaCte.SignoCargoAbonoRolOpeCtaCte
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spSignoCargoAbonoRolOpeCtaCte, CCT_ID, TDO_ID, DTD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Signo_DCargoAbonoRolOpeCtaCte(ByVal CCT_ID As String, ByVal TDO_ID As String, ByVal DTD_ID As String) As String Implements IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spSigno_DCargoAbonoRolOpeCtaCte, CCT_ID, TDO_ID, DTD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Signo_D_1CargoAbonoRolOpeCtaCte(ByVal CCT_ID As String, ByVal TDO_ID As String, ByVal DTD_ID As String) As String Implements IBCRolOpeCtaCte.Signo_D_1CargoAbonoRolOpeCtaCte
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spSigno_D_1CargoAbonoRolOpeCtaCte, CCT_ID, TDO_ID, DTD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function MovimientoCargoAbonoRolOpeCtaCte(ByVal CCT_ID As String, ByVal TDO_ID As String, ByVal DTD_ID As String) As String Implements IBCRolOpeCtaCte.MovimientoCargoAbonoRolOpeCtaCte
            Dim result As String = ""
            Try
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarString(DA.SPNames.spMovimientoCargoAbonoRolOpeCtaCte, CCT_ID, TDO_ID, DTD_ID)
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
