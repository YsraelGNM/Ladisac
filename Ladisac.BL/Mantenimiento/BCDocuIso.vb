Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCDocuIso
        Implements IBCDocuIso

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function DocuIsoGetById(ByVal DIS_ID As Integer) As BE.DocuIso Implements IBCDocuIso.DocuIsoGetById
            Dim result As DocuIso = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocuIsoRepositorio)()
                result = rep.GetById(DIS_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDocuIso() As String Implements IBCDocuIso.ListaDocuIso
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocuIsoRepositorio)()
                result = rep.ListaDocuIso
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoDocuIso(ByVal mDocuIso As BE.DocuIso) Implements IBCDocuIso.MantenimientoDocuIso
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocuIsoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mDocuIso.ChangeTracker.State = ObjectState.Added) Then
                        mDocuIso.DIS_ID = bcherramientas.Get_Id("DocuIso")
                    ElseIf (mDocuIso.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim CodDID As Integer = bcherramientas.Get_Id("DocuIsoDetalle")
                    For Each mDid In mDocuIso.DocuIsoDetalle
                        If mDid.ChangeTracker.State = ObjectState.Added Then
                            mDid.DID_ID = CodDID
                            CodDID += 1
                        ElseIf mDid.ChangeTracker.State = ObjectState.Modified Then

                        End If
                    Next

                    If mDocuIso.DIS_VIGENTE = 1 Then
                        Dim mCol As List(Of DocuIso)
                        mCol = rep.ListaDocuIsoXAreXDtdXNombre(mDocuIso.ARE_ID, mDocuIso.DTD_ID, mDocuIso.DIS_ADJUNTO_DESCRI)
                        For Each mItem In mCol.ToList
                            mItem.MarkAsModified()
                            mItem.DIS_VIGENTE = 0
                            rep.Maintenance(mItem)
                        Next
                    End If

                    rep.Maintenance(mDocuIso)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaDocuIsoVigente(ByVal ARE_ID As String, ByVal DTD_ID As String, ByVal PER_ID As String, ByVal ARE_DESCRIPCION As String) As System.Collections.Generic.List(Of BE.DocuIso) Implements IBCDocuIso.ListaDocuIsoVigente
            Dim mCol As List(Of DocuIso)
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocuIsoRepositorio)()
                mCol = rep.ListaDocuIsoVigente(ARE_ID, DTD_ID, PER_ID, ARE_DESCRIPCION)
            Catch ex As Exception
                mCol = Nothing
            End Try
            Return mCol
        End Function
    End Class

End Namespace
