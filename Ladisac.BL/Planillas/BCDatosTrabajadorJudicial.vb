
Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCDatosTrabajadorJudicial
        Implements IBCDatosTrabajadorJudicial
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil


        Public Function DatosTrabajadorJudicialQuery(ByVal codigo As String, ByVal nombre As String) As Object Implements IBCDatosTrabajadorJudicial.DatosTrabajadorJudicialQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDatosTrabajadorJudicialSelectXML, codigo, nombre)


            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function DatosTrabajadorJudicialSeek(ByVal serie As String, ByVal numero As String) As Object Implements IBCDatosTrabajadorJudicial.DatosTrabajadorJudicialSeek

            Dim result As DatosTrabajadorJudicial = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDatosTrabajadorJudicialRepositorio)()
                result = rep.GetById(serie, numero)
                
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.DatosTrabajadorJudicial) As Object Implements IBCDatosTrabajadorJudicial.Maintenance
            Try
                Dim repCAB = ContainerService.Resolve(Of DA.DatosTrabajadorJudicialRepositorio)()
                Dim repDET = ContainerService.Resolve(Of DA.IDetalleTrabajadorJudicialRepositorio)()
                Dim sCorrelativo As String = Nothing



                If (item.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.DatosTrabajadorJudicial", "dtj_NumeroJudi", 10, " where dtj_SerieJudi='" & item.dtj_SerieJudi & "'")
                    item.dtj_NumeroJudi = sCorrelativo
                End If

                Dim listaDET As New List(Of DetalleTrabajadorJudicial)
                For Each RowDET In item.DetalleTrabajadorJudicial

                    Dim NewDET As New DetalleTrabajadorJudicial

                    NewDET = RowDET.Clone
                    NewDET.dtj_NumeroJudi = item.dtj_NumeroJudi
                    listaDET.Add(NewDET)
                Next
                item.ChangeTracker.ChangeTrackingEnabled = False
                item.DetalleTrabajadorJudicial = Nothing

                item.ChangeTracker.ChangeTrackingEnabled = True

                Using Scope As New System.Transactions.TransactionScope()
                    repCAB.Maintenance(item)

                    For Each mItemIngreso In listaDET
                        ' If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False
                        mItemIngreso.Conceptos = Nothing
                        mItemIngreso.TiposPlanillas = Nothing

                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True

                        mItemIngreso.dtj_NumeroJudi = item.dtj_NumeroJudi

                        'End If
                        repDET.Maintenance(mItemIngreso)
                    Next
                    Scope.Complete()


                End Using
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False
        End Function
    End Class

End Namespace
