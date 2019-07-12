Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCOrdenTrabajo
        Implements IBCOrdenTrabajo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaOrdenTrabajo() As String Implements IBCOrdenTrabajo.ListaOrdenTrabajo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenTrabajoRepositorio)()
                result = rep.ListaOrdenTrabajo
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoOrdenTrabajo(ByVal mOrdenTrabajo As BE.OrdenTrabajo) Implements IBCOrdenTrabajo.MantenimientoOrdenTrabajo
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenTrabajoRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IOrdenTrabajoPersonalRepositorio)()
                Dim repDeta1 = ContainerService.Resolve(Of DA.IOrdenTrabajoEntidadRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mOrdenTrabajo.ChangeTracker.State = ObjectState.Added) Then
                        mOrdenTrabajo.OTR_ID = bcherramientas.Get_Id("OrdenTrabajo")
                    ElseIf (mOrdenTrabajo.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mListaOTPersonal As New List(Of OrdenTrabajoPersonal)
                    For Each mObj In mOrdenTrabajo.OrdenTrabajoPersonal
                        Dim mOTP As New OrdenTrabajoPersonal
                        mOTP = mObj.Clone
                        mListaOTPersonal.Add(mOTP)
                    Next

                    Dim mListaOTEntidad As New List(Of OrdenTrabajoEntidad)
                    For Each mObj In mOrdenTrabajo.OrdenTrabajoEntidad
                        Dim mOTE As New OrdenTrabajoEntidad
                        mOTE = mObj.Clone
                        mListaOTEntidad.Add(mOTE)
                    Next

                    mOrdenTrabajo.ChangeTracker.ChangeTrackingEnabled = False
                    mOrdenTrabajo.OrdenTrabajoPersonal = Nothing
                    mOrdenTrabajo.OrdenTrabajoEntidad = Nothing
                    mOrdenTrabajo.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mOrdenTrabajo)

                    For Each mItem In mListaOTPersonal
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.OTP_ID = bcherramientas.Get_Id("OrdenTrabajoPersonal")
                            mItem.OTR_ID = mOrdenTrabajo.OTR_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDeta.Maintenance(mItem)
                    Next

                    For Each mItem In mListaOTEntidad
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.OTE_ID = bcherramientas.Get_Id("OrdenTrabajoEntidad")
                            mItem.OTR_ID = mOrdenTrabajo.OTR_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDeta1.Maintenance(mItem)
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

        Public Function OrdenTrabajoGetById(ByVal OTR_ID As Integer) As BE.OrdenTrabajo Implements IBCOrdenTrabajo.OrdenTrabajoGetById
            Dim result As OrdenTrabajo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenTrabajoRepositorio)()
                result = rep.GetById(OTR_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaHistoricoOrdenTrabajo(ByVal ENO_Id As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal Gru_Id As Nullable(Of Integer)) As String Implements IBCOrdenTrabajo.ListaHistoricoOrdenTrabajo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaHistoricoOrdenTrabajo", ENO_Id, FecIni, FecFin, Gru_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaArticulosXOT(ByVal OTR_ID As Integer) As String Implements IBCOrdenTrabajo.ListaArticulosXOT
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaArticuloXOT", OTR_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaHijosEntidad(ByVal ENO_ID As Integer) As String Implements IBCOrdenTrabajo.ListaHijosEntidad
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaHijosEntidad", ENO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaOrdenTrabajoParaOR() As String Implements IBCOrdenTrabajo.ListaOrdenTrabajoParaOR
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaOrdenTrabajoParaOR")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaOTXMesXSemanaxAnio(ByVal Anio As Integer?, ByVal Gru_Id As Integer?) As String Implements IBCOrdenTrabajo.ListaOTXMesXSemanaxAnio
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaOTXMesXSemanaxAnio", Anio, Gru_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaPersonalXOT(ByVal OTR_ID As Integer) As String Implements IBCOrdenTrabajo.ListaPersonalXOT
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaPersonalXOT", OTR_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaOrdenTrabajoOR(ByVal OTR_ID As Integer?) As System.Data.DataSet Implements IBCOrdenTrabajo.ListaOrdenTrabajoOR
            Dim result As New DataSet
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenTrabajoRepositorio)()
                result = rep.ListaOrdenTrabajoOR(OTR_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ImprimirOrdenTrabajo(ByVal OTR_ID As Integer) As String Implements IBCOrdenTrabajo.ImprimirOrdenTrabajo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spImprimirOrdenTrabajo", OTR_ID)
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
