Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCControlParada
        Implements IBCControlParada

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ControlParadaGetById(ByVal CPA_ID As Integer) As BE.ControlParada Implements IBCControlParada.ControlParadaGetById
            Dim result As ControlParada = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlParadaRepositorio)()
                result = rep.GetById(CPA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlParada() As String Implements IBCControlParada.ListaControlParada
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlParadaRepositorio)()
                result = rep.ListaControlParada
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlParada(ByVal mControlParada As BE.ControlParada) Implements IBCControlParada.MantenimientoControlParada
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlParadaRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IControlParadaDetalleRepositorio)()
                Dim repDetaMolde = ContainerService.Resolve(Of DA.IControlParadaMoldeDetalleRepositorio)()
                Dim repDetaArticulo = ContainerService.Resolve(Of DA.IControlParadaArticuloDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Dim repEno = ContainerService.Resolve(Of DA.IEntidadRepositorio)()

                Dim repDocu = ContainerService.Resolve(Of DA.IDocuMovimientoRepositorio)()
                Dim repDetaDocu = ContainerService.Resolve(Of DA.IDocuMovimientoDetalleRepositorio)()

                Dim repDetalleTipoDocumento = ContainerService.Resolve(Of DA.IDetalleTipoDocumentoRepositorio)()

                Dim kardex = ContainerService.Resolve(Of DA.IKardexRepositorio)()

                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlParada.ChangeTracker.State = ObjectState.Added) Then
                        mControlParada.CPA_ID = bcherramientas.Get_Id("ControlParada")
                    ElseIf (mControlParada.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mLista As New List(Of ControlParadaDetalle)
                    For Each mObj In mControlParada.ControlParadaDetalle
                        Dim mDet As New ControlParadaDetalle
                        mDet = mObj.Clone
                        mLista.Add(mDet)
                    Next
                    Dim mMolde As New List(Of ControlParadaMoldeDetalle)
                    For Each mObj In mControlParada.ControlParadaMoldeDetalle
                        Dim mDet As New ControlParadaMoldeDetalle
                        mDet = mObj.Clone
                        mMolde.Add(mDet)
                    Next
                    Dim mArticulo As New List(Of ControlParadaArticuloDetalle)
                    For Each mObj In mControlParada.ControlParadaArticuloDetalle
                        Dim mDet As New ControlParadaArticuloDetalle
                        mDet = mObj.Clone
                        mArticulo.Add(mDet)
                    Next

                    mControlParada.ChangeTracker.ChangeTrackingEnabled = False
                    mControlParada.ControlParadaDetalle = Nothing
                    mControlParada.ControlParadaMoldeDetalle = Nothing
                    mControlParada.ControlParadaArticuloDetalle = Nothing
                    mControlParada.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mControlParada)

                    For Each mItem In mLista
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.DCP_ID = bcherramientas.Get_Id("ControlParadaDetalle")
                            mItem.CPA_ID = mControlParada.CPA_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDeta.Maintenance(mItem)
                    Next

                    For Each mItem In mMolde
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.DPM_ID = bcherramientas.Get_Id("ControlParadaMoldeDetalle")
                            mItem.CPA_ID = mControlParada.CPA_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDetaMolde.Maintenance(mItem)
                    Next
                    Dim mListaEntidad = From mL In mMolde Where mL.MOL_ID > 0 Group By mL.MOL_ID Into Total = Sum(mL.DPM_TIEMPO) Select MOL_ID, Total

                    For Each mLE In mListaEntidad.ToList
                        Dim Eno As Entidad
                        Eno = repEno.GetById(mLE.MOL_ID)
                        Eno.ENO_HORAS = Eno.ENO_HORAS + mLE.Total
                    Next


                    For Each mItem In mArticulo
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.DPA_ID = bcherramientas.Get_Id("ControlParadaArticuloDetalle")
                            mItem.CPA_ID = mControlParada.CPA_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDetaArticulo.Maintenance(mItem)
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

        Public Function GetByPro_Id(ByVal PRO_Id As Integer) As System.Collections.Generic.List(Of BE.ControlParada) Implements IBCControlParada.GetByPro_Id
            Dim result As List(Of ControlParada) = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlParadaRepositorio)()
                result = rep.GetByPro_Id(PRO_Id)
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
