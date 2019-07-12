Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCParametroEntidad
        Implements IBCParametroEntidad

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaParametroEntidad() As String Implements IBCParametroEntidad.ListaParametroEntidad
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IParametroEntidadRepositorio)()
                result = rep.ListaParametroEntidad
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoParametroEntidad(ByVal mParametroEntidad As BE.ParametroEntidad) Implements IBCParametroEntidad.MantenimientoParametroEntidad
            Try
                Dim rep = ContainerService.Resolve(Of DA.IParametroEntidadRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mParametroEntidad.ChangeTracker.State = ObjectState.Added) Then
                        mParametroEntidad.PAE_ID = bcherramientas.Get_Id("ParametroEntidad")
                    ElseIf (mParametroEntidad.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mParametroEntidad)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ParametroEntidadGetById(ByVal PAE_ID As Integer) As BE.ParametroEntidad Implements IBCParametroEntidad.ParametroEntidadGetById
            Dim result As ParametroEntidad = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IParametroEntidadRepositorio)()
                result = rep.GetById(PAE_ID)
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
