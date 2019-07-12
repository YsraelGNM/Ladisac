Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCDistrito
        Implements IBCDistrito

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaDistrito() As String Implements IBCDistrito.ListaDistrito
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDistritoRepositorio)()
                result = rep.ListaDistrito()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function


        'Public Function DistritoGetById(ByVal DIS_ID As Integer) As BE.Distrito Implements IBCDistrito.DistritoGetById

        'End Function


        Public Function MantenimientoDistrito(ByVal Item As BE.Distrito) As Short Implements IBCDistrito.MantenimientoDistrito
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDistritoRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            MantenimientoDistrito = 0
                            Exit Function
                        End If
                    End If
                    MantenimientoDistrito = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                Item.vMensajeError = ex.InnerException.Message
                MantenimientoDistrito = 0
            End Try
        End Function
    End Class

End Namespace