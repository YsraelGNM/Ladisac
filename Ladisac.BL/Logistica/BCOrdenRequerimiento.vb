Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCOrdenRequerimiento
        Implements IBCOrdenRequerimiento

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaOrdenRequerimiento(ByVal Filtro As String) As DataSet Implements IBCOrdenRequerimiento.ListaOrdenRequerimiento
            Dim result As DataSet = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenRequerimientoRepositorio)()
                result = rep.ListaOrdenRequerimiento(Filtro)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function MantenimientoOrdenRequerimiento(ByVal mOrdenRequerimiento As BE.OrdenRequerimiento) As Integer Implements IBCOrdenRequerimiento.MantenimientoOrdenRequerimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenRequerimientoRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IOrdenRequerimientoDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Suppress, ts1)

                    If (mOrdenRequerimiento.ChangeTracker.State = ObjectState.Added) Then
                        mOrdenRequerimiento.ORR_ID = bcherramientas.Get_Id("OrdenRequerimiento")
                    ElseIf (mOrdenRequerimiento.ChangeTracker.State = ObjectState.Modified) Then
                    ElseIf (mOrdenRequerimiento.ChangeTracker.State = ObjectState.Deleted) Then
                    End If

                    Dim mListaOrdenRequerimientoDetalle As New List(Of OrdenRequerimientoDetalle)
                    For Each mObj In mOrdenRequerimiento.OrdenRequerimientoDetalle
                        Dim mOrdenRequerimientoDetalle As New OrdenRequerimientoDetalle
                        mOrdenRequerimientoDetalle = mObj.Clone
                        mListaOrdenRequerimientoDetalle.Add(mOrdenRequerimientoDetalle)
                    Next


                    mOrdenRequerimiento.ChangeTracker.ChangeTrackingEnabled = False
                    mOrdenRequerimiento.OrdenRequerimientoDetalle = Nothing
                    mOrdenRequerimiento.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mOrdenRequerimiento)

                    For Each mItem In mListaOrdenRequerimientoDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.ORD_ID = bcherramientas.Get_Id("OrdenRequerimientoDetalle")
                            mItem.ORR_ID = mOrdenRequerimiento.ORR_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then
                        End If
                        mItem.ChangeTracker.ChangeTrackingEnabled = False
                        Dim mOrdenRequerimientoDetalle As New OrdenRequerimientoDetalle
                        mOrdenRequerimientoDetalle = mItem.Clone
                        mItem.OrdenTrabajo = Nothing
                        mItem.Articulos = Nothing
                        mItem.Entidad = Nothing
                        mItem.ChangeTracker.ChangeTrackingEnabled = True
                        mItem.OTR_ID = mOrdenRequerimientoDetalle.OTR_ID
                        mItem.ART_ID = mOrdenRequerimientoDetalle.ART_ID
                        mItem.ENO_ID = mOrdenRequerimientoDetalle.ENO_ID
                        repDeta.Maintenance(mItem)
                        mOrdenRequerimiento.OrdenRequerimientoDetalle.Add(mItem)
                    Next

                    Scope.Complete()
                    Return 1
                End Using

            Catch ex As Exception
                mOrdenRequerimiento.ORR_ID = -1
                MsgBox(ex.InnerException.Message, , "Error")
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                '    Throw
                'End If
                Return 0
            End Try
        End Function

        Public Function OrdenRequerimientoGetById(ByVal ORR_ID As Integer) As BE.OrdenRequerimiento Implements IBCOrdenRequerimiento.OrdenRequerimientoGetById
            Dim result As OrdenRequerimiento = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenRequerimientoRepositorio)()
                result = rep.GetById(ORR_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListadoOrdenRequerimiento(ByVal FecIni As Date, ByVal FecFin As Date, ByVal ORR_Importancia As Integer, ByVal ORT_Id As Integer, ByVal Estado As Integer, ByVal Grupo As Integer) As String Implements IBCOrdenRequerimiento.ListadoOrdenRequerimiento
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListadoOrdenRequerimiento", FecIni, FecFin, ORR_Importancia, ORT_Id, Estado, Grupo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoOrdenRequerimientoDetalle(ByVal mOrdenRequerimientoDetalle As BE.OrdenRequerimientoDetalle) Implements IBCOrdenRequerimiento.MantenimientoOrdenRequerimientoDetalle
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenRequerimientoDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)
                    If (mOrdenRequerimientoDetalle.ChangeTracker.State = ObjectState.Added) Then
                        mOrdenRequerimientoDetalle.ORD_ID = bcherramientas.Get_Id("OrdenRequerimientoDetalle")
                    ElseIf (mOrdenRequerimientoDetalle.ChangeTracker.State = ObjectState.Modified) Then

                    End If
                    rep.Maintenance(mOrdenRequerimientoDetalle)
                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaORDocumentacion(ByVal ORR_Id As Integer?) As System.Data.DataSet Implements IBCOrdenRequerimiento.ListaORDocumentacion
            Dim result As New DataSet
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenRequerimientoRepositorio)()
                result = rep.ListaORDocumentacion(ORR_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function OrdenRequerimientoDetalleGetById(ByVal ORD_ID As Integer) As BE.OrdenRequerimientoDetalle Implements IBCOrdenRequerimiento.OrdenRequerimientoDetalleGetById
            Dim result As OrdenRequerimientoDetalle = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenRequerimientoDetalleRepositorio)()
                result = rep.GetById(ORD_ID)
                'Dim rep1 = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                'Dim ruta As String = rep1.EjecutarReporte("spRuta", result.OrdenTrabajo.ENO_ID)
                'result.OrdenTrabajo.Entidad.Ruta = ruta
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaORSalidaCombustible(ByVal ORR_Id As Integer?) As System.Data.DataSet Implements IBCOrdenRequerimiento.ListaORSalidaCombustible
            Dim result As New DataSet
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenRequerimientoRepositorio)()
                result = rep.ListaORSalidaCombustible(ORR_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaORLadrillo(ByVal ORR_Id As Integer?) As System.Data.DataSet Implements IBCOrdenRequerimiento.ListaORLadrillo
            Dim result As New DataSet
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenRequerimientoRepositorio)()
                result = rep.ListaORLadrillo(ORR_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function EnviarCorreoPermisoCargaSinDocumento(ByVal ORR_Id As Integer?) As String Implements IBCOrdenRequerimiento.EnviarCorreoPermisoCargaSinDocumento
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spEnviarCorreoPermisoCargaSinDocumento", ORR_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaOrdenRequerimientoServicio(ByVal Filtro As String) As System.Data.DataSet Implements IBCOrdenRequerimiento.ListaOrdenRequerimientoServicio
            Dim result As DataSet = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenRequerimientoRepositorio)()
                result = rep.ListaOrdenRequerimientoServicio(Filtro)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function CantidadPorAtender(ByVal ART_ID As String) As Double Implements IBCOrdenRequerimiento.CantidadPorAtender
            Dim result As Double = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenRequerimientoRepositorio)()
                result = rep.CantidadPorAtender(ART_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function CantidadPorComprar(ByVal ART_ID As String) As Double Implements IBCOrdenRequerimiento.CantidadPorComprar
            Dim result As Double = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenRequerimientoRepositorio)()
                result = rep.CantidadPorComprar(ART_ID)
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
