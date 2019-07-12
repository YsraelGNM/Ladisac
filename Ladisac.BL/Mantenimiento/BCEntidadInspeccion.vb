Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCEntidadInspeccion
        Implements IBCEntidadInspeccion

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function EntidadInspeccionGetById(ByVal EIN_ID As Integer) As BE.EntidadInspeccion Implements IBCEntidadInspeccion.EntidadInspeccionGetById
            Dim result As EntidadInspeccion = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IEntidadInspeccionRepositorio)()
                result = rep.GetById(EIN_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaEntidadInspeccion() As String Implements IBCEntidadInspeccion.ListaEntidadInspeccion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IEntidadInspeccionRepositorio)()
                result = rep.ListaEntidadInspeccion
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoEntidadInspeccion(ByVal mEntidadInspeccion As BE.EntidadInspeccion) Implements IBCEntidadInspeccion.MantenimientoEntidadInspeccion
            Try
                Dim rep = ContainerService.Resolve(Of DA.IEntidadInspeccionRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IParametroEntidadRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mEntidadInspeccion.ChangeTracker.State = ObjectState.Added) Then
                        mEntidadInspeccion.EIN_ID = bcherramientas.Get_Id("EntidadInspeccion")
                    ElseIf (mEntidadInspeccion.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mListaPAE As New List(Of ParametroEntidad)
                    For Each mObj In mEntidadInspeccion.ParametroEntidad
                        Dim mPAE As New ParametroEntidad
                        mPAE = mObj.Clone
                        mListaPAE.Add(mPAE)
                    Next

                    mEntidadInspeccion.ChangeTracker.ChangeTrackingEnabled = False
                    mEntidadInspeccion.ParametroEntidad = Nothing
                    mEntidadInspeccion.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mEntidadInspeccion)

                    For Each mItem In mListaPAE
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.PAE_ID = bcherramientas.Get_Id("ParametroEntidad")
                            mItem.EIN_ID = mEntidadInspeccion.EIN_ID
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
    End Class

End Namespace
