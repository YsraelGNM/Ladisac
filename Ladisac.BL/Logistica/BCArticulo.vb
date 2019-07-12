Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCArticulo
        Implements IBCArticulo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ArticuloGetById(ByVal ART_ID As String) As BE.Articulos Implements IBCArticulo.ArticuloGetById
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

        Public Function ListaArticulo() As String Implements IBCArticulo.ListaArticulo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IArticuloRepositorio)()
                result = rep.ListaArticulo()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoArticulo(ByVal mArticulo As BE.Articulos) Implements IBCArticulo.MantenimientoArticulo
            Try
                Dim rep = ContainerService.Resolve(Of DA.IArticuloRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mArticulo.ChangeTracker.State = ObjectState.Added) Then
                        mArticulo.ART_ID = bcherramientas.Get_IdTx("Articulo")
                        mArticulo.ART_Codigo = bcherramientas.Get_CodigoArticuloTx(mArticulo.GLI_ID)
                    ElseIf (mArticulo.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mArticulo)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaArticuloOrdenTrabajo(ByVal ENO_ID As String, ByVal MTO_ID As String) As String Implements IBCArticulo.ListaArticuloOrdenTrabajo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaArticuloOrdenTrabajo", ENO_ID, MTO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaArticuloControlParada() As String Implements IBCArticulo.ListaArticuloControlParada
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaArticuloControlParada")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaArticuloSumins(ByVal ART_Id As String) As System.Data.DataSet Implements IBCArticulo.ListaArticuloSumins
            Dim result As New DataSet
            Try
                Dim rep = ContainerService.Resolve(Of DA.IArticuloRepositorio)()
                result = rep.ListaArticuloSumins(ART_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaArticuloOrdenTrabajoSumins(ByVal ENO_ID As String, ByVal MTO_ID As String, ByVal ART_CODIGO As String) As System.Data.DataSet Implements IBCArticulo.ListaArticuloOrdenTrabajoSumins
            Dim result As New DataSet
            Try
                Dim rep = ContainerService.Resolve(Of DA.IArticuloRepositorio)()
                result = rep.ListaArticuloOrdenTrabajoSumins(ENO_ID, MTO_ID, ART_CODIGO)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaArticuloMateriaPrima() As String Implements IBCArticulo.ListaArticuloMateriaPrima
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaArticuloMateriaPrima")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaArticuloMateriaPrimaMezcla() As String Implements IBCArticulo.ListaArticuloMateriaPrimaMezcla
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaArticuloMateriaPrimaMezcla")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaArticuloServicio(ByVal ART_Codigo As String) As String Implements IBCArticulo.ListaArticuloServicio
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaArticuloServicio", ART_Codigo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaArticuloSucursal(ByVal ART_Codigo As String) As String Implements IBCArticulo.ListaArticuloSucursal
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaArticuloSucursal", ART_Codigo)
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
