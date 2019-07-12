Imports Microsoft.VisualBasic.FileIO
Imports System.IO

Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCKardexLote
        Implements IBCKardexLote

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function KardexLoteGetById(ByVal KAL_ID As Integer) As BE.KardexLote Implements IBCKardexLote.KardexLoteGetById
            Dim result As KardexLote = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IKardexLoteRepositorio)()
                result = rep.GetById(KAL_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoKardexLote(ByVal mKardexLote As BE.KardexLote) Implements IBCKardexLote.MantenimientoKardexLote
            Try
                Dim rep = ContainerService.Resolve(Of DA.IKardexLoteRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mKardexLote.ChangeTracker.State = ObjectState.Added) Then
                        mKardexLote.KAL_ID = bcherramientas.Get_Id("KardexLote")
                    ElseIf (mKardexLote.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mKardexLote)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace
