Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCRegistroEquipo
        Implements IBCRegistroEquipo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaRegistroEquipo() As String Implements IBCRegistroEquipo.ListaRegistroEquipo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRegistroEquipoRepositorio)()
                result = rep.ListaRegistroEquipo
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoRegistroEquipo(ByVal mRegistroEquipo As BE.RegistroEquipo) Implements IBCRegistroEquipo.MantenimientoRegistroEquipo
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRegistroEquipoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mRegistroEquipo.ChangeTracker.State = ObjectState.Added) Then
                        mRegistroEquipo.REQ_ID = bcherramientas.Get_Id("RegistroEquipo")
                    ElseIf (mRegistroEquipo.ChangeTracker.State = ObjectState.Modified) Then

                    End If
                    Dim CodRED As Integer = bcherramientas.Get_Id("RegistroEquipoDetalle")
                    For Each mDet In mRegistroEquipo.RegistroEquipoDetalle
                        If (mDet.ChangeTracker.State = ObjectState.Added) Then
                            mDet.RED_ID = CodRED
                            CodRED += 1
                        ElseIf (mDet.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                    Next

                    rep.Maintenance(mRegistroEquipo)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function RegistroEquipoGetById(ByVal REQ_ID As Integer) As BE.RegistroEquipo Implements IBCRegistroEquipo.RegistroEquipoGetById
            Dim result As RegistroEquipo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRegistroEquipoRepositorio)()
                result = rep.GetById(REQ_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaArea() As String Implements IBCRegistroEquipo.ListaArea
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaArea")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaTarea() As String Implements IBCRegistroEquipo.ListaTarea
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaTarea")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaUbicacionTrabajo() As String Implements IBCRegistroEquipo.ListaUbicacionTrabajo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaUbicacionTrabajo")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReporteRegistroEquipo(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Are_Id As Integer?, ByVal Tar_Id As Integer?, ByVal Eno_Id As Integer?, ByVal Per_Id As String, ByVal Utr_Id As Integer?, ByVal Req_Turno As Integer?) As String Implements IBCRegistroEquipo.ReporteRegistroEquipo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("Man.spReporteRegistroEquipo", FecIni, FecFin, Are_Id, Tar_Id, Eno_Id, Per_Id, Utr_Id, Req_Turno)
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
