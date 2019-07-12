Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCCuentaRendir
        Implements IBCCuentaRendir

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function CuentaRendirGetById(ByVal CRE_ID As Integer) As BE.CuentaRendir Implements IBCCuentaRendir.CuentaRendirGetById
            Dim result As CuentaRendir = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICuentaRendirRepositorio)()
                result = rep.GetById(CRE_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCuentaRendir() As String Implements IBCCuentaRendir.ListaCuentaRendir
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICuentaRendirRepositorio)()
                result = rep.ListaCuentaRendir
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result
        End Function

        Public Function MantenimientoCuentaRendir(ByVal mCuentaRendir As BE.CuentaRendir) As Integer Implements IBCCuentaRendir.MantenimientoCuentaRendir
            Dim Result As Integer = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICuentaRendirRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mCuentaRendir.ChangeTracker.State = ObjectState.Added) Then
                        mCuentaRendir.CRE_ID = bcherramientas.Get_Id("CuentaRendir")
                    ElseIf (mCuentaRendir.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim Cod As Integer = bcherramientas.Get_Id("CuentaRendirDetalle")
                    For Each mItem In mCuentaRendir.CuentaRendirDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.CRD_ID = Cod
                            Cod += 1
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                    Next

                    Result = rep.Maintenance(mCuentaRendir)

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

        Public Function CuentaRendirTesoreria() As String Implements IBCCuentaRendir.CuentaRendirTesoreria
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spCuentaRendirTesoreria")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ImprimirCuentaRendir(ByVal CRE_ID As Integer) As System.Data.DataTable Implements IBCCuentaRendir.ImprimirCuentaRendir
            Dim result As DataTable
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spImprimirCuentaRendir", CRE_ID)
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
