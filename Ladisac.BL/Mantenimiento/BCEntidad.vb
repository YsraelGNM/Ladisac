Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCEntidad
        Implements IBCEntidad

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function EntidadGetById(ByVal ENO_ID As Integer) As BE.Entidad Implements IBCEntidad.EntidadGetById
            Dim result As Entidad = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IEntidadRepositorio)()
                result = rep.GetById(ENO_ID)
                'Dim rep1 = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                'Dim ruta As String = rep1.EjecutarReporte("spRuta", ENO_ID)
                'result.Ruta = ruta
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaEntidad() As String Implements IBCEntidad.ListaEntidad
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IEntidadRepositorio)()
                result = rep.ListaEntidad
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoEntidad(ByVal mEntidad As BE.Entidad) Implements IBCEntidad.MantenimientoEntidad
            Try
                Dim rep = ContainerService.Resolve(Of DA.IEntidadRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IEspecificacionRepositorio)()
                Dim repDeta2 = ContainerService.Resolve(Of DA.IImagenRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mEntidad.ChangeTracker.State = ObjectState.Added) Then
                        mEntidad.ENO_ID = bcherramientas.Get_Id("Entidad")
                    ElseIf (mEntidad.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mListaEspecificacion As New List(Of Especificacion)
                    For Each mObj In mEntidad.Especificacion
                        Dim mESP As New Especificacion
                        mESP = mObj.Clone
                        mListaEspecificacion.Add(mESP)
                    Next

                    Dim mListaImagen As New List(Of Imagen)
                    For Each mObj In mEntidad.Imagen
                        Dim mIMA As New Imagen
                        mIMA = mObj.Clone
                        mListaImagen.Add(mIMA)
                    Next

                    mEntidad.ChangeTracker.ChangeTrackingEnabled = False
                    mEntidad.Especificacion = Nothing
                    mEntidad.Imagen = Nothing
                    mEntidad.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mEntidad)

                    For Each mItem In mListaEspecificacion
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.ESP_ID = bcherramientas.Get_Id("Especificacion")
                            mItem.ENO_ID = mEntidad.ENO_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDeta.Maintenance(mItem)
                    Next

                    For Each mItem In mListaImagen
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.IMA_ID = bcherramientas.Get_Id("Imagen")
                            mItem.ENO_ID = mEntidad.ENO_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDeta2.Maintenance(mItem)
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

        Public Function ListaConsumoEntidad(ByVal Eno_Id As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal Art_Id As String, ByVal OTR_ID As Integer, ByVal MTO_ID As Integer, ByVal TCM_ID As Integer, ByVal GRU_ID As Integer) As DataSet Implements IBCEntidad.ListaConsumoEntidad
            Dim result As DataSet = Nothing
            Try
                'Dim rep1 = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                'Dim result1 As String = rep1.EjecutarReporte("spListaConsumoEntidad_Pre", Eno_Id, FecIni, FecFin, Art_Id, OTR_ID, MTO_ID, TCM_ID, GRU_ID)

                Dim rep = ContainerService.Resolve(Of DA.IEntidadRepositorio)()
                result = rep.ListaConsumoEntidad(Eno_Id, FecIni, FecFin, Art_Id, OTR_ID, MTO_ID, TCM_ID, GRU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaAlertaCambios() As String Implements IBCEntidad.ListaAlertaCambios
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaAlertaCambios")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function EstadoTrabajoMantto(ByVal Eno_Id As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal CompFI As Date, ByVal CompFF As Date, ByVal Gru_Id As Nullable(Of Integer), ByVal OTR_Fase As String) As String Implements IBCEntidad.EstadoTrabajoMantto
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spEstadoTrabajoMantto", Eno_Id, FecIni, FecFin, CompFI, CompFF, Gru_Id, OTR_Fase)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaHijos(ByVal ENO_Id As Integer) As System.Collections.Generic.List(Of BE.Entidad) Implements IBCEntidad.ListaHijos
            Dim result As List(Of Entidad)
            Try
                Dim rep = ContainerService.Resolve(Of DA.IEntidadRepositorio)()
                result = rep.ListaHijos(ENO_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaHijosEntidad(ByVal ENO_ID As Integer) As String Implements IBCEntidad.ListaHijosEntidad
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

        Public Function ListaEntidadOrdenTrabajo(ByVal OTR_ID As String) As String Implements IBCEntidad.ListaEntidadOrdenTrabajo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaEntidadOrdenTrabajo", OTR_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function


        Public Function ListaEntidadID(ByVal ENO_ID As Integer?) As System.Data.DataSet Implements IBCEntidad.ListaEntidadID
            Dim result As New DataSet
            Try
                Dim rep = ContainerService.Resolve(Of DA.IEntidadRepositorio)()
                result = rep.ListaEntidadID(ENO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function EstadoTrabajoManttoDetallado(ByVal Eno_Id As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal Gru_Id As Integer?, ByVal OTR_Fase As String) As String Implements IBCEntidad.EstadoTrabajoManttoDetallado
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spEstadoTrabajoManttoDetallado", Eno_Id, FecIni, FecFin, Gru_Id, OTR_Fase)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaUsuarioEntidad(ByVal USU_ID As String, ByVal ENO_ID As Integer?) As String Implements IBCEntidad.ListaUsuarioEntidad
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaUsuarioEntidad", USU_ID, ENO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function CargarDataVisionLink(ByVal ENO_ID As Integer) As String Implements IBCEntidad.CargarDataVisionLink
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spCargarDataVisionLink", ENO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function VLConsumoCombustible(ByVal ENO_ID As Integer?, ByVal FecIni As Date, ByVal FecFin As Date) As String Implements IBCEntidad.VLConsumoCombustible
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spVLConsumoCombustible", ENO_ID, FecIni, FecFin)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaEntidadCuentaContable() As System.Collections.Generic.List(Of BE.Entidad) Implements IBCEntidad.ListaEntidadCuentaContable
            Dim result As List(Of Entidad)
            Try
                Dim rep = ContainerService.Resolve(Of DA.IEntidadRepositorio)()
                result = rep.ListaEntidadCuentaContable
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaEntidadRegistro() As String Implements IBCEntidad.ListaEntidadRegistro
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaEntidadRegistro")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaEntidadPlaca() As String Implements IBCEntidad.ListaEntidadPlaca
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaEntidadPlaca")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function UltimoHorometro(ByVal ENO_ID As Integer, ByVal Tipo As String) As Decimal Implements IBCEntidad.UltimoHorometro
            Dim result As Decimal
            Try
                Dim rep = ContainerService.Resolve(Of DA.IEntidadRepositorio)()
                result = rep.UltimoHorometro(ENO_ID, Tipo)
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
