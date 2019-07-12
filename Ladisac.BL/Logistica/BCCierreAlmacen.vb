Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCCierreAlmacen
        Implements IBCCierreAlmacen

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function CierreAlmacenGetByCierre(ByVal Anio As String, ByVal Mes As String, ByVal Alm_id As String) As Boolean Implements IBCCierreAlmacen.CierreAlmacenGetByCierre
            Dim result As Boolean
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICierreAlmacenRepositorio)()
                result = rep.GetByCierre(Anio, Mes, Alm_id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function CierreAlmacenGetById(ByVal CIA_ID As Integer) As BE.CierreAlmacen Implements IBCCierreAlmacen.CierreAlmacenGetById
            Dim result As CierreAlmacen = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICierreAlmacenRepositorio)()
                result = rep.GetById(CIA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCierreAlmacen() As String Implements IBCCierreAlmacen.ListaCierreAlmacen
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICierreAlmacenRepositorio)()
                result = rep.ListaCierreAlmacen()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoCierreAlmacen(ByVal mCierreAlmacen As BE.CierreAlmacen) Implements IBCCierreAlmacen.MantenimientoCierreAlmacen
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICierreAlmacenRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mCierreAlmacen.ChangeTracker.State = ObjectState.Added) Then
                        mCierreAlmacen.CIA_ID = bcherramientas.Get_Id("CierreAlmacen")
                    ElseIf (mCierreAlmacen.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mCierreAlmacen)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function CierreAlmacenGetByCierreAlmacen(ByVal Anio As String, ByVal Mes As String, ByVal Alm_id As String) As BE.CierreAlmacen Implements IBCCierreAlmacen.CierreAlmacenGetByCierreAlmacen
            Dim result As CierreAlmacen = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICierreAlmacenRepositorio)()
                result = rep.GetByCierreAlmacen(Anio, Mes, Alm_id)
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
