Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCSolicitudSoporte
        Implements IBCSolicitudSoporte

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaSolicitudSoporte() As String Implements IBCSolicitudSoporte.ListaSolicitudSoporte
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISolicitudSoporteRepositorio)()
                result = rep.ListaSolicitudSoporte
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function MantenimientoSolicitudSoporte(ByVal mSolicitudSoporte As BE.SolicitudSoporte) As Integer Implements IBCSolicitudSoporte.MantenimientoSolicitudSoporte
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISolicitudSoporteRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Suppress, ts1)

                    If (mSolicitudSoporte.ChangeTracker.State = ObjectState.Added) Then
                        mSolicitudSoporte.SOS_ID = bcherramientas.Get_Id("SolicitudSoporte")
                    ElseIf (mSolicitudSoporte.ChangeTracker.State = ObjectState.Modified) Then

                    End If
                    Dim CodSSD As Integer = bcherramientas.Get_Id("SolicitudSoporteDetalle")
                    For Each mDet In mSolicitudSoporte.SolicitudSoporteDetalle
                        If (mDet.ChangeTracker.State = ObjectState.Added) Then
                            mDet.SSD_ID = CodSSD
                            CodSSD += 1
                        ElseIf (mDet.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                    Next

                    rep.Maintenance(mSolicitudSoporte)

                    Scope.Complete()
                    Return 1
                End Using

            Catch ex As Exception
                mSolicitudSoporte.SOS_ID = -1
                MsgBox(ex.InnerException.Message, , "Error")
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                '    Throw
                'End If
                Return 0
            End Try
        End Function

        Public Function SolicitudSoporteGetById(ByVal SOS_ID As Integer) As BE.SolicitudSoporte Implements IBCSolicitudSoporte.SolicitudSoporteGetById
            Dim result As SolicitudSoporte = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISolicitudSoporteRepositorio)()
                result = rep.GetById(SOS_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReporteSoSo(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Area As String, ByVal PER_ID_SOLICITADO As String) As System.Data.DataTable Implements IBCSolicitudSoporte.ReporteSoSo
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spReporteSoSo", FecIni, FecFin, Area, PER_ID_SOLICITADO)
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
