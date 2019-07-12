Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCReciclajeLadrilloVenta
        Implements IBCReciclajeLadrilloVenta

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaReciclajeLadrilloVenta() As String Implements IBCReciclajeLadrilloVenta.ListaReciclajeLadrilloVenta
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReciclajeLadrilloVentaRepositorio)()
                result = rep.ListaReciclajeLadrilloVenta
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoReciclajeLadrilloVenta(ByVal mReciclajeLadrilloVenta As BE.ReciclajeLadrilloVenta) Implements IBCReciclajeLadrilloVenta.MantenimientoReciclajeLadrilloVenta
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReciclajeLadrilloVentaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mReciclajeLadrilloVenta.ChangeTracker.State = ObjectState.Added) Then
                        mReciclajeLadrilloVenta.RCL_ID = bcherramientas.Get_Id("ReciclajeLadrilloVenta")
                    ElseIf (mReciclajeLadrilloVenta.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mReciclajeLadrilloVenta)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ReciclajeLadrilloVentaGetById(ByVal RCL_ID As Integer) As BE.ReciclajeLadrilloVenta Implements IBCReciclajeLadrilloVenta.ReciclajeLadrilloVentaGetById
            Dim result As ReciclajeLadrilloVenta = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReciclajeLadrilloVentaRepositorio)()
                result = rep.GetById(RCL_ID)
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
