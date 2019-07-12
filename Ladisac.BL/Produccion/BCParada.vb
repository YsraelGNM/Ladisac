Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCParada
        Implements IBCParada

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Sub MantenimientoParada(ByVal mParada As BE.Parada) Implements IBCParada.MantenimientoParada
            Try
                Dim rep = ContainerService.Resolve(Of DA.IParadasRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IParadasTiposRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mParada.ChangeTracker.State = ObjectState.Added) Then
                        mParada.PAR_ID = bcherramientas.Get_Id("Parada")
                    ElseIf (mParada.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mListaParadasTipos As New List(Of ParadasTipos)
                    For Each mObj In mParada.ParadasTipos
                        Dim mParadasTipos As New ParadasTipos
                        mParadasTipos = mObj.Clone(mObj)
                        mListaParadasTipos.Add(mParadasTipos)
                    Next


                    mParada.ChangeTracker.ChangeTrackingEnabled = False
                    mParada.ParadasTipos = Nothing
                    mParada.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mParada)

                    For Each mItem In mListaParadasTipos
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.PAT_ID = bcherramientas.Get_Id("ParadasTipos")
                            mItem.PAR_ID = mParada.PAR_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDeta.Maintenance(mItem)
                    Next

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ParadaGetById(ByVal PAR_ID As Integer) As BE.Parada Implements IBCParada.ParadaGetById
            Dim result As Parada = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IParadasRepositorio)()
                result = rep.GetById(PAR_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaParada(ByVal PAR_ID As Integer) As String Implements IBCParada.ListaParada
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IParadasRepositorio)()
                result = rep.ListaParada(PAR_ID)
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
