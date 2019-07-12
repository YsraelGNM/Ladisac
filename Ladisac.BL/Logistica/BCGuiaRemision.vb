Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCGuiaRemision
        Implements IBCGuiaRemision

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GuiaRemisionGetById(ByVal GUI_ID As Integer) As BE.GuiaRemision Implements IBCGuiaRemision.GuiaRemisionGetById
            Dim result As GuiaRemision = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IGuiaRemisionRepositorio)()
                result = rep.GetById(GUI_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaGuiaRemision() As String Implements IBCGuiaRemision.ListaGuiaRemision
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IGuiaRemisionRepositorio)()
                result = rep.ListaGuiaRemision
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result
        End Function

        Public Function MantenimientoGuiaRemision(ByVal mGuiaRemision As BE.GuiaRemision) As Integer Implements IBCGuiaRemision.MantenimientoGuiaRemision
            Try
                Dim rep = ContainerService.Resolve(Of DA.IGuiaRemisionRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IGuiaRemisionDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim Flag As Boolean = False
                Dim mCorre = ContainerService.Resolve(Of DA.ICorrelativoTipoDocumentoRepositorio)()
                Dim Compuesto2 As New CorrelativoTipoDocumento
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mGuiaRemision.ChangeTracker.State = ObjectState.Added) Then
                        mGuiaRemision.GUI_ID = bcherramientas.Get_Id("GuiaRemision")
                        Flag = True
                    ElseIf (mGuiaRemision.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mListaGuiaRemisionDetalle As New List(Of GuiaRemisionDetalle)
                    For Each mObj In mGuiaRemision.GuiaRemisionDetalle
                        Dim mguiaremisionDetalle As New GuiaRemisionDetalle
                        mguiaremisionDetalle = mObj.Clone
                        mListaGuiaRemisionDetalle.Add(mguiaremisionDetalle)
                    Next


                    mGuiaRemision.ChangeTracker.ChangeTrackingEnabled = False
                    mGuiaRemision.GuiaRemisionDetalle = Nothing
                    mGuiaRemision.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mGuiaRemision)

                    For Each mItem In mListaGuiaRemisionDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.GUD_ID = bcherramientas.Get_Id("GuiaRemisionDetalle")
                            mItem.GUI_ID = mGuiaRemision.GUI_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDeta.Maintenance(mItem)
                    Next


                    If Flag Then
                        ' Correlativo de serie
                        Compuesto2.TDO_ID = "039"
                        Compuesto2.PVE_ID = "002"
                        Compuesto2.CTD_COR_SERIE = mGuiaRemision.GUI_SERIE
                        Compuesto2.CTD_COR_NUMERO = Val(mGuiaRemision.GUI_NRO) + 1
                        Compuesto2.CTD_USAR_COR = True
                        Compuesto2.USU_ID = mGuiaRemision.USU_ID
                        Compuesto2.CTD_FEC_GRAB = Now
                        Compuesto2.CTD_ESTADO = True
                        Compuesto2.MarkAsModified()
                        mCorre.Maintenance(Compuesto2)
                        '''''''''''''''''''''''
                    End If

                    Scope.Complete()

                    For Each mItem In mListaGuiaRemisionDetalle
                        mGuiaRemision.GuiaRemisionDetalle.Add(mItem)
                    Next

                    Return 1
                End Using

            Catch ex As Exception
                mGuiaRemision.GUI_ID = -1
                MsgBox(ex.InnerException.Message, , "Error")
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                '    Throw
                'End If
                Return 0
            End Try
        End Function

        Public Function ListaGuiaRemisionAProcesar(ByVal FecIni As Date, ByVal FecFin As Date) As String Implements IBCGuiaRemision.ListaGuiaRemisionAProcesar
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaGuiaRemisionAProcesar", FecIni, FecFin)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PrecioMateriaPrima(ByVal ART_ID As String, ByVal Fecha As Date) As Decimal Implements IBCGuiaRemision.PrecioMateriaPrima
            Dim result As Decimal = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spPrecioMateriaPrima", ART_ID, Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function StockCostoPromedio(ByVal ART_Id As String, ByVal Alm_Id As Integer, ByVal Fecha As Date, ByVal Flag As Integer) As Decimal Implements IBCGuiaRemision.StockCostoPromedio
            Dim result As Decimal = 0
            Try
                Dim rep = ContainerService.Resolve(Of DA.IKardexRepositorio)()
                result = rep.StockCostoPromedio(ART_Id, Alm_Id, Fecha, Flag)
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
