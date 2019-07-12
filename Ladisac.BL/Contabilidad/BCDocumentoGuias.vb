Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCDocumentoGuias
        Implements IBCDocumentoGuias

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function DocumentoGuiasGetById(ByVal DGU_ID As Integer) As BE.DocumentoGuias Implements IBCDocumentoGuias.DocumentoGuiasGetById
            Dim result As DocumentoGuias = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocumentoGuiasRepositorio)()
                result = rep.GetById(DGU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDocumentoGuias() As String Implements IBCDocumentoGuias.ListaDocumentoGuias
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocumentoGuiasRepositorio)()
                result = rep.ListaDocumentoGuias()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoDocumentoGuias(ByVal mDocumentoGuias As BE.DocumentoGuias) Implements IBCDocumentoGuias.MantenimientoDocumentoGuias
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocumentoGuiasRepositorio)()
                Dim repo = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Dim fNuevo As Boolean = False

                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mDocumentoGuias.ChangeTracker.State = ObjectState.Added) Then
                        fNuevo = True
                        mDocumentoGuias.DGU_ID = bcherramientas.Get_Id("DocumentoGuias")
                    ElseIf (mDocumentoGuias.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim dCod As Integer = bcherramientas.Get_Id("DocumentoGuiasDetalle")
                    For Each mItem In mDocumentoGuias.DocumentoGuiasDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.DGD_ID = dCod
                            dCod += 1
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                    Next

                    rep.Maintenance(mDocumentoGuias)

                    If fNuevo Then
                        Dim dt As DataTable
                        dt = repo.EjecutarReporteTable("spInsertarOSE_DocumentoGuias", mDocumentoGuias.DGU_ID)
                        If dt IsNot Nothing Then
                            If dt.Rows.Count > 0 Then
                                MsgBox("O.S.: " & dt.Rows(0)(0))
                            End If
                        End If
                    End If
                    

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaGuiasTransportista(ByVal Per_Id As String, ByVal FecIni As Date, ByVal FecFin As Date) As String Implements IBCDocumentoGuias.ListaGuiasTransportista
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spGuiasTransportista", Per_Id, FecIni, fecfin)
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
