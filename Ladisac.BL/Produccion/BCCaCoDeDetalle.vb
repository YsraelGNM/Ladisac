Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCCaCoDeDetalle
        Implements IBCCaCoDeDetalle

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function CaCoDeDetalleGetById(ByVal CCD_ID As Integer) As BE.CaCoDe_Detalle Implements IBCCaCoDeDetalle.CaCoDeDetalleGetById
            Dim result As CaCoDe_Detalle = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICaCoDeDetalleRepositorio)()
                result = rep.GetById(CCD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCaCoDeDetalle(ByVal Dia As Date, ByVal HOR_ID As Integer) As String Implements IBCCaCoDeDetalle.ListaCaCoDeDetalle
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICaCoDeDetalleRepositorio)()
                result = rep.ListaCaCoDeDetalle(Dia, HOR_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoCaCoDeDetalle(ByVal mCaCoDeDetalle As BE.CaCoDe_Detalle) Implements IBCCaCoDeDetalle.MantenimientoCaCoDeDetalle
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICaCoDeDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mCaCoDeDetalle.ChangeTracker.State = ObjectState.Added) Then
                        mCaCoDeDetalle.CCD_ID = bcherramientas.Get_Id("CaCoDeDetalle")
                    ElseIf (mCaCoDeDetalle.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mCaCoDeDetalle)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Sub MantenimientoCaCoDeDetalle2(ByVal colCaCoDeDetalle As System.Collections.Generic.List(Of BE.CaCoDe_Detalle), ByVal Carga As BE.ControlCarga, ByVal Quema As BE.ControlQuema, ByVal Descarga As BE.ControlDescarga) Implements IBCCaCoDeDetalle.MantenimientoCaCoDeDetalle2
            Try
                Dim ccd = ContainerService.Resolve(Of DA.ICaCoDeDetalleRepositorio)()
                Dim ca = ContainerService.Resolve(Of DA.IControlCargaRepositorio)()
                Dim co = ContainerService.Resolve(Of DA.IControlQuemaRepositorio)()
                Dim de = ContainerService.Resolve(Of DA.IControlDescargaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If Not Carga Is Nothing Then
                        If (Carga.ChangeTracker.State = ObjectState.Added) Then
                            Carga.CAR_ID = bcherramientas.Get_Id("ControlCarga")
                            Dim mBorrar = ccd.ListaCaCoDeDetalleObj(Carga.CAR_FECHA, Carga.HOR_ID)
                            For Each mObj In mBorrar
                                mObj.MarkAsDeleted()
                                ccd.Maintenance(mObj)
                            Next
                        ElseIf (Carga.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        ca.Maintenance(Carga)

                    ElseIf Not Quema Is Nothing Then
                        If (Quema.ChangeTracker.State = ObjectState.Added) Then
                            Quema.COQ_ID = bcherramientas.Get_Id("ControlQuema")
                            Dim mBorrar = ccd.ListaCaCoDeDetalleObj(Quema.COQ_FECHA, Quema.HOR_ID)
                            For Each mObj In mBorrar
                                mObj.MarkAsDeleted()
                                ccd.Maintenance(mObj)
                            Next
                        ElseIf (Carga.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        co.Maintenance(Quema)

                    ElseIf Not Descarga Is Nothing Then
                        If (Descarga.ChangeTracker.State = ObjectState.Added) Then
                            Descarga.DES_ID = bcherramientas.Get_Id("ControlDescarga")
                            Dim mBorrar = ccd.ListaCaCoDeDetalleObj(Descarga.DES_FECHA, Descarga.HOR_ID)
                            For Each mObj In mBorrar
                                mObj.MarkAsDeleted()
                                ccd.Maintenance(mObj)
                            Next
                        ElseIf (Carga.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        de.Maintenance(Descarga)

                    End If


                    Dim mLista As New List(Of CaCoDe_Detalle)
                    For Each mObj In colCaCoDeDetalle
                        Dim mDet As New CaCoDe_Detalle
                        mDet = mObj.Clone
                        mDet.ControlCarga = Nothing
                        mDet.ControlQuema = Nothing
                        mDet.ControlDescarga = Nothing
                        mDet.LadrilloMalecon = Nothing
                        mDet.CAR_ID = mObj.CAR_ID
                        mDet.COQ_ID = mObj.COQ_ID
                        mDet.DES_ID = mObj.DES_ID
                        mDet.LMA_ID = mObj.LMA_ID
                        mLista.Add(mDet)
                    Next


                    For Each mCCD In mLista
                        If (mCCD.ChangeTracker.State = ObjectState.Added) Then
                            mCCD.CCD_ID = bcherramientas.Get_Id("CaCoDeDetalle")
                        ElseIf (mCCD.ChangeTracker.State = ObjectState.Modified) Then

                        End If

                        If Not Carga Is Nothing Then
                            If mCCD.CAR_ID Is Nothing And mCCD.CCD_ESTADO.Contains("CA") Then
                                mCCD.CAR_ID = Carga.CAR_ID
                            End If
                        ElseIf Not Quema Is Nothing Then
                            If Not mCCD.CCD_ID = Nothing And Not mCCD.CAR_ID Is Nothing And mCCD.COQ_ID Is Nothing And mCCD.CCD_ESTADO.Contains("CO") Then
                                mCCD.COQ_ID = Quema.COQ_ID
                            End If
                        ElseIf Not Descarga Is Nothing Then
                            If Not mCCD.CCD_ID = Nothing And Not mCCD.CAR_ID Is Nothing And Not mCCD.COQ_ID Is Nothing And mCCD.DES_ID Is Nothing And mCCD.CCD_ESTADO.Contains("DE") Then
                                mCCD.DES_ID = Descarga.DES_ID
                            End If
                        End If

                        ccd.Maintenance(mCCD)
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

        Public Function CargarCaCoDeDetalle(ByVal mItem As System.Data.DataRow) As BE.CaCoDe_Detalle Implements IBCCaCoDeDetalle.CargarCaCoDeDetalle
            Dim nCCD As New CaCoDe_Detalle
            With nCCD
                .CCD_ID = mItem("CCD_ID")
                .CAR_ID = CInt(mItem("CAR_ID"))
                If mItem("COQ_ID") Is DBNull.Value Then .COQ_ID = Nothing Else .COQ_ID = CInt(mItem("COQ_ID"))
                If mItem("DES_ID") Is DBNull.Value Then .DES_ID = Nothing Else .DES_ID = CInt(mItem("DES_ID"))
                .LMA_ID = CInt(mItem("LMA_ID"))
                .CCD_NRO_MALE = mItem("CCD_NRO_MALE")
                .CCD_FECHA = CDate(mItem("CCD_FECHA"))
                .CCD_TIPO = mItem("CCD_TIPO")
                .CCD_ESTADO = mItem("CCD_ESTADO")
                .CCD_CANTIDAD = CInt(mItem("CCD_CANTIDAD"))
                .HOR_ID = CInt(mItem("HOR_ID"))
                .PUE_ID = CInt(mItem("PUE_ID"))
                .CCD_HORNO = mItem("CCD_HORNO")
                .CCD_PUERTA = mItem("CCD_PUERTA")
            End With
            Return nCCD
        End Function

        Public Function ValidarCarga(ByVal PRO_ID As Integer) As System.Data.DataSet Implements IBCCaCoDeDetalle.ValidarCarga
            Dim result As New DataSet
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICaCoDeDetalleRepositorio)()
                result = rep.ValidarCarga(PRO_ID)
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
