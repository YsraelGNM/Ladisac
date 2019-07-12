Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCArea
        Implements IBCArea

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function AreaGetById(ByVal ARE_ID As Integer) As BE.Area Implements IBCArea.AreaGetById
            Dim result As Area = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IAreaRepositorio)()
                result = rep.GetById(ARE_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaArea() As String Implements IBCArea.ListaArea
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IAreaRepositorio)()
                result = rep.ListaArea
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoArea(ByVal mArea As BE.Area) Implements IBCArea.MantenimientoArea
            Try
                Dim rep = ContainerService.Resolve(Of DA.IAreaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mArea.ChangeTracker.State = ObjectState.Added) Then
                        mArea.ARE_ID = bcherramientas.Get_Id("Area")
                    ElseIf (mArea.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mArea)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaAreaRRHH() As String Implements IBCArea.ListaAreaRRHH
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaAreaRRHH")
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
