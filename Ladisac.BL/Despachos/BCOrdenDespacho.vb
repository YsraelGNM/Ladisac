Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCOrdenDespacho
        Implements IBCOrdenDespacho

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaOrdenDespacho() As String Implements IBCOrdenDespacho.ListaOrdenDespacho
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenDespachoRepositorio)()
                result = rep.ListaOrdenDespacho
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result
        End Function

        Public Sub MantenimientoOrdenDespacho(ByVal mOrdenDespacho As BE.OrdenDespacho) Implements IBCOrdenDespacho.MantenimientoOrdenDespacho
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenDespachoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mOrdenDespacho.ChangeTracker.State = ObjectState.Added) Then
                        mOrdenDespacho.ODE_ID = bcherramientas.Get_Id("OrdenDespacho")
                    ElseIf (mOrdenDespacho.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mCod As Integer = bcherramientas.Get_Id("OrdenDespachoDetalle")
                    For Each mItem In mOrdenDespacho.OrdenDespachoDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.ODD_ID = mCod
                            mCod += 1
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                    Next

                    rep.Maintenance(mOrdenDespacho)

                    Scope.Complete()

                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function OrdenDespachoGetById(ByVal ODE_ID As Integer) As BE.OrdenDespacho Implements IBCOrdenDespacho.OrdenDespachoGetById
            Dim result As OrdenDespacho = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenDespachoRepositorio)()
                result = rep.GetById(ODE_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function


        Public Function ListaPesaje(ByVal Ticket As Nullable(Of Integer)) As String Implements IBCOrdenDespacho.ListaPesaje
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaPesaje", Ticket)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function


        Public Function ListaPlacaPesaje(ByVal Uni_id As String) As String Implements IBCOrdenDespacho.ListaPlacaPesaje
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaPlacaPesaje", Uni_id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaLadrilloDespacho() As String Implements IBCOrdenDespacho.ListaLadrilloDespacho
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaLadrilloDespacho")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCronogramaXdespachar(ByVal Fecha As Date) As String Implements IBCOrdenDespacho.ListaCronogramaXdespachar
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaCronogramaXdespachar", Fecha)
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
