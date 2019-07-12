Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCSancion
        Implements IBCSancion

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaSancion() As String Implements IBCSancion.ListaSancion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISancionRepositorio)()
                result = rep.ListaSancion
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoSancion(ByVal mSancion As BE.Sancion) Implements IBCSancion.MantenimientoSancion
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISancionRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mSancion.ChangeTracker.State = ObjectState.Added) Then
                        mSancion.SAN_ID = bcherramientas.Get_Id("Sancion")
                    ElseIf (mSancion.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim dCod As Integer = bcherramientas.Get_Id("SancionDetalle")
                    For Each mItem In mSancion.SancionDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.SAD_ID = dCod
                            dCod += 1
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                    Next

                    rep.Maintenance(mSancion)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function SancionGetById(ByVal SAN_ID As Integer) As BE.Sancion Implements IBCSancion.SancionGetById
            Dim result As Sancion = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISancionRepositorio)()
                result = rep.GetById(SAN_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlSanciones(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Per_Id_Falta As String, ByVal DNI As String, ByVal Per_Id_Empresa As String, ByVal Placa As String) As String Implements IBCSancion.ListaControlSanciones
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaControlSanciones", FecIni, FecFin, Per_Id_Falta, DNI, Per_Id_Empresa, Placa)
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
