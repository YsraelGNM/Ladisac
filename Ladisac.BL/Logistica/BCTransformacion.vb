Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCTransformacion
        Implements IBCTransformacion


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaTransformacion() As String Implements IBCTransformacion.ListaTransformacion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITransformacionRepositorio)()
                result = rep.ListaTransformacion
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result
        End Function

        Public Sub MantenimientoTransformacion(ByVal mTransformacion As BE.Transformacion) Implements IBCTransformacion.MantenimientoTransformacion
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITransformacionRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.ITransformacionDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim mDocu = ContainerService.Resolve(Of BL.BCDocuMovimiento)()
                Dim mTransf = ContainerService.Resolve(Of BL.BCTransformacion)()

                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mTransformacion.ChangeTracker.State = ObjectState.Added) Then
                        mTransformacion.TFO_ID = bcherramientas.Get_Id("Transformacion")
                    ElseIf (mTransformacion.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mListaTransformacionDetalle As New List(Of TransformacionDetalle)
                    For Each mObj In mTransformacion.TransformacionDetalle
                        Dim mTransformacionDetalle As New TransformacionDetalle
                        mTransformacionDetalle = mObj.Clone
                        mListaTransformacionDetalle.Add(mTransformacionDetalle)
                    Next


                    mTransformacion.ChangeTracker.ChangeTrackingEnabled = False
                    mTransformacion.TransformacionDetalle = Nothing
                    mTransformacion.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mTransformacion)


                    For Each mItem In mListaTransformacionDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.TRD_ID = bcherramientas.Get_Id("TransformacionDetalle")
                            mItem.TFO_ID = mTransformacion.TFO_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDeta.Maintenance(mItem)
                    Next

                    'Para actualizar precios 
                    mDocu.ActualizarIngresoTransformacion(mTransformacion.TFO_ID)
                    For Each mItem In mListaTransformacionDetalle
                        If mItem.TRD_ES_SALIDA = False Then mTransf.ActualizarPUServicioTransformacion(mItem.TFO_ID, mItem.ART_ID, mItem.TRD_PU, mItem.TRD_NRO_DOC, mItem.PER_ID_PROVEEDOR)
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

        Public Function TransformacionGetById(ByVal TFO_ID As Integer) As BE.Transformacion Implements IBCTransformacion.TransformacionGetById
            Dim result As Transformacion = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITransformacionRepositorio)()
                result = rep.GetById(TFO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ImpresionTransformacion(ByVal TFO_ID As Integer) As String Implements IBCTransformacion.ImpresionTransformacion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spImpresionTransformacion", TFO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaTransformacionID(ByVal TFO_ID As Integer?) As System.Data.DataSet Implements IBCTransformacion.ListaTransformacionID
            Dim result As New DataSet
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITransformacionRepositorio)()
                result = rep.ListaTransformacionID(TFO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub ActualizarPUServicioTransformacion(ByVal TFO_ID As Integer?, ByVal ART_ID As String, ByVal PU As Decimal?, ByVal TRD_NRO_SERVICIO As String, ByVal PER_ID As String) Implements IBCTransformacion.ActualizarPUServicioTransformacion
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITransformacionRepositorio)()
                rep.ActualizarPUServicioTransformacion(TFO_ID, ART_ID, PU, TRD_NRO_SERVICIO, PER_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function TransformacionxTFO() As System.Data.DataTable Implements IBCTransformacion.TransformacionxTFO
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spTransformacionxTFO")
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
