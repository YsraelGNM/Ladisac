Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCAlmacen
        Implements IBCAlmacen

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Sub MantenimientoAlmacen(ByVal mAlmacen As BE.Almacen) Implements IBCAlmacen.MantenimientoAlmacen
            Try
                Dim rep = ContainerService.Resolve(Of DA.IAlmacenRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mAlmacen.ChangeTracker.State = ObjectState.Added) Then
                        mAlmacen.ALM_ID = bcherramientas.Get_Id("Almacen")
                    ElseIf (mAlmacen.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mAlmacen)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function AlmacenGetById(ByVal ALM_ID As Integer) As BE.Almacen Implements IBCAlmacen.AlmacenGetById
            Dim result As Almacen = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IAlmacenRepositorio)()
                result = rep.GetById(ALM_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaAlmacen() As String Implements IBCAlmacen.ListaAlmacen
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IAlmacenRepositorio)()
                result = rep.ListaAlmacen()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaAlmacenRendicion(ByVal ART_ID As String) As String Implements IBCAlmacen.ListaAlmacenRendicion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaAlmacenRendicion", ART_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetByIdPadre(ByVal ALM_Id_Padre As Integer) As System.Collections.Generic.List(Of BE.Almacen) Implements IBCAlmacen.GetByIdPadre
            Dim result As List(Of Almacen) = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IAlmacenRepositorio)()
                result = rep.GetByIdPadre(ALM_Id_Padre)
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
