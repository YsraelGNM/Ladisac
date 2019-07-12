Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCLadrilloMalecon
        Implements IBCLadrilloMalecon

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function LadrilloMaleconGetById(ByVal LMA_ID As Integer) As BE.LadrilloMalecon Implements IBCLadrilloMalecon.LadrilloMaleconGetById
            Dim result As LadrilloMalecon = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ILadrilloMaleconRepositorio)()
                result = rep.GetById(LMA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaLadrilloMalecon() As String Implements IBCLadrilloMalecon.ListaLadrilloMalecon
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ILadrilloMaleconRepositorio)()
                result = rep.ListaLadrilloMalecon
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoLadrilloMalecon(ByVal mLadrilloMalecon As BE.LadrilloMalecon) Implements IBCLadrilloMalecon.MantenimientoLadrilloMalecon
            Try
                Dim rep = ContainerService.Resolve(Of DA.ILadrilloMaleconRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mLadrilloMalecon.ChangeTracker.State = ObjectState.Added) Then
                        mLadrilloMalecon.LMA_ID = bcherramientas.Get_Id("LadrilloMalecon")
                    ElseIf (mLadrilloMalecon.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mLadrilloMalecon)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function MaleconPuertaGetById(ByVal MAL_ID As Integer) As BE.MaleconPuerta Implements IBCLadrilloMalecon.MaleconPuertaGetById
            Dim result As MaleconPuerta = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMaleconPuertaRepositorio)()
                result = rep.GetById(MAL_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ArticuloGetById(ByVal ART_ID As String) As BE.Articulos Implements IBCLadrilloMalecon.ArticuloGetById
            Dim result As Articulos = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IArticuloRepositorio)()
                result = rep.GetById(ART_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function LadrilloMaleconGetById2(ByVal HOR_Id As Integer, ByVal Nro_Male As String, ByVal PRO_Id As Integer) As BE.LadrilloMalecon Implements IBCLadrilloMalecon.LadrilloMaleconGetById2
            Dim result As LadrilloMalecon = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ILadrilloMaleconRepositorio)()
                Dim rep2 = ContainerService.Resolve(Of DA.ILadrilloRepositorio)()
                result = rep.GetById2(HOR_Id, Nro_Male, PRO_Id)
                If result IsNot Nothing Then result.Ladrillo = rep2.GetById(result.LAD_ID)
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
