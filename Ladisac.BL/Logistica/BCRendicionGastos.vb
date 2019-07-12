Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCRendicionGastos
        Implements IBCRendicionGastos

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaRendicionGastos() As String Implements IBCRendicionGastos.ListaRendicionGastos
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRendicionGastosRepositorio)()
                result = rep.ListaRendicionGastos
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function MantenimientoRendicionGastos(ByVal mRendicionGastos As BE.RendicionGastos) As Integer Implements IBCRendicionGastos.MantenimientoRendicionGastos
            Dim Result As Integer = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRendicionGastosRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Suppress, ts1)

                    If (mRendicionGastos.ChangeTracker.State = ObjectState.Added) Then
                        mRendicionGastos.RGA_ID = bcherramientas.Get_Id("RendicionGastos")
                    ElseIf (mRendicionGastos.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim Cod As Integer = bcherramientas.Get_Id("RendicionGastosDetalle")
                    For Each mObj As RendicionGastosDetalle In mRendicionGastos.RendicionGastosDetalle
                        If (mObj.ChangeTracker.State = ObjectState.Added) Then
                            mObj.RGD_ID = Cod
                        ElseIf (mObj.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        Cod += 1
                    Next

                    Result = rep.Maintenance(mRendicionGastos)

                    Scope.Complete()

                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return Result
        End Function

        Public Function RendicionGastosGetById(ByVal RGA_ID As Integer) As BE.RendicionGastos Implements IBCRendicionGastos.RendicionGastosGetById
            Dim result As RendicionGastos = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRendicionGastosRepositorio)()
                result = rep.GetById(RGA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ImprimirRendicionGastos(ByVal RGA_ID As Integer) As System.Data.DataTable Implements IBCRendicionGastos.ImprimirRendicionGastos
            Dim result As DataTable
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spImprimirRendicionGastos", RGA_ID)
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
