Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCPermisoUsuario
        Implements IBCPermisoUsuario

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaUsuarios() As String Implements IBCPermisoUsuario.ListaUsuarios
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPermisoUsuarioRepositorio)()
                result = rep.ListaUsuarios
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoUsuario(ByVal mUsuario As BE.Usuarios) Implements IBCPermisoUsuario.MantenimientoUsuario
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPermisoUsuarioRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Using Scope As New System.Transactions.TransactionScope()

                    If (mUsuario.ChangeTracker.State = ObjectState.Added) Then
                        mUsuario.USU_ID = bcherramientas.Get_IdTx("Usuario")
                    ElseIf (mUsuario.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mUsuario)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function UsuarioGetById(ByVal USU_ID As String) As BE.Usuarios Implements IBCPermisoUsuario.UsuarioGetById
            Dim result As Usuarios = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPermisoUsuarioRepositorio)()
                result = rep.GetById(USU_ID)
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
