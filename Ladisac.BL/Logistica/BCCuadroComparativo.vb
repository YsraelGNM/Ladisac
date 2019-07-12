Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCCuadroComparativo
        Implements IBCCuadroComparativo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function CuadroComparativoGetById(ByVal CUC_ID As Integer) As BE.CuadroComparativo Implements IBCCuadroComparativo.CuadroComparativoGetById
            Dim result As CuadroComparativo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICuadroComparativoRepositorio)()
                result = rep.GetById(CUC_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCuadroComparativo() As String Implements IBCCuadroComparativo.ListaCuadroComparativo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICuadroComparativoRepositorio)()
                result = rep.ListaCuadroComparativo
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result
        End Function

        Public Sub MantenimientoCuadroComparativo(ByVal mCuadroComparativo As BE.CuadroComparativo) Implements IBCCuadroComparativo.MantenimientoCuadroComparativo
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICuadroComparativoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mCuadroComparativo.ChangeTracker.State = ObjectState.Added) Then
                        mCuadroComparativo.CUC_ID = bcherramientas.Get_Id("CuadroComparativo")
                    ElseIf (mCuadroComparativo.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim CodCCPD As Integer = bcherramientas.Get_Id("CCProveedorDetalle")
                    Dim CodCCAPD As Integer = bcherramientas.Get_Id("CCArticuloProveedorDetalle")
                    For Each mPro In mCuadroComparativo.CCProveedorDetalle
                        If mPro.ChangeTracker.State = ObjectState.Added Then
                            mPro.CPD_ID = CodCCPD
                            CodCCPD += 1
                        ElseIf mPro.ChangeTracker.State = ObjectState.Modified Then

                        End If
                        For Each mArt In mPro.CCArticuloProveedorDetalle
                            If mArt.ChangeTracker.State = ObjectState.Added Then
                                mArt.CAP_ID = CodCCAPD
                                CodCCAPD += 1
                            ElseIf mArt.ChangeTracker.State = ObjectState.Modified Then

                            End If
                        Next
                    Next

                    rep.Maintenance(mCuadroComparativo)

                    Scope.Complete()

                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ImprimirCuadroComparativo(ByVal CUC_ID As Integer) As String Implements IBCCuadroComparativo.ImprimirCuadroComparativo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spImprimirCuadroComparativo", CUC_ID)
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
