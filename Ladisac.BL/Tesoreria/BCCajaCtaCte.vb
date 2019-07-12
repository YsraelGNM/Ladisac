Imports Ladisac.BE

Namespace Ladisac.BL
    Partial Public Class BCCajaCtaCte
        Implements IBCCajaCtaCte


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function MantenimientoCajaCtaCte(ByVal Item As BE.CajaCtaCte) As Short Implements IBCCajaCtaCte.MantenimientoCajaCtaCte
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICajaCtaCteRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoCajaCtaCte = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoCajaCtaCte = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                Item.vMensajeError = ex.InnerException.Message
                MantenimientoCajaCtaCte = 0
            End Try
        End Function

        Public Function spCajaCtaCteSelectXML(ByVal codigo As String, ByVal descripcion As String) As String Implements IBCCajaCtaCte.spCajaCtaCteSelectXML
            Dim result As String = Nothing
            Try
                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spCajaCtaCteSelectXML, codigo, descripcion)
                ' Scope.Complete()
                ' End Using

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
