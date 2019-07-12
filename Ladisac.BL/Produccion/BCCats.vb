Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCCats
        Implements IBCCats

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function CatsGetById(ByVal CAT_ID As Integer) As BE.Cats Implements IBCCats.CatsGetById
            Dim result As Cats = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICatsRepositorio)()
                result = rep.GetById(CAT_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCats() As String Implements IBCCats.ListaCats
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICatsRepositorio)()
                result = rep.ListaCat
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoCats(ByVal mCats As BE.Cats) Implements IBCCats.MantenimientoCats
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICatsRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mCats.ChangeTracker.State = ObjectState.Added) Then
                        mCats.CAT_ID = bcherramientas.Get_Id("Cats")
                    ElseIf (mCats.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mCats)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaCatsMezcla() As String Implements IBCCats.ListaCatsMezcla
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaCatsMezcla")
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
