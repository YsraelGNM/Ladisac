Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCSolicitudAjustePrecio
        Implements IBCSolicitudAjustePrecio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaSolicitudAjustePrecio() As String Implements IBCSolicitudAjustePrecio.ListaSolicitudAjustePrecio
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISolicitudAjustePrecioRepositorio)()
                result = rep.ListaSolicitudAjustePrecio
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function MantenimientoSolicitudAjustePrecio(ByVal mSolicitudAjustePrecio As BE.SolicitudAjustePrecio) As Integer Implements IBCSolicitudAjustePrecio.MantenimientoSolicitudAjustePrecio
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISolicitudAjustePrecioRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Suppress, ts1)

                    If (mSolicitudAjustePrecio.ChangeTracker.State = ObjectState.Added) Then
                        mSolicitudAjustePrecio.SAP_ID = bcherramientas.Get_Id("SolicitudAjustePrecio")
                    ElseIf (mSolicitudAjustePrecio.ChangeTracker.State = ObjectState.Modified) Then

                    End If
                    Dim CodAPD As Integer = bcherramientas.Get_Id("SolicitudAjustePrecioDetalle")
                    For Each mDet In mSolicitudAjustePrecio.SolicitudAjustePrecioDetalle
                        If (mDet.ChangeTracker.State = ObjectState.Added) Then
                            mDet.APD_ID = CodAPD
                            CodAPD += 1
                        ElseIf (mDet.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                    Next

                    rep.Maintenance(mSolicitudAjustePrecio)

                    Scope.Complete()
                    Return 1
                End Using

            Catch ex As Exception
                mSolicitudAjustePrecio.SAP_ID = -1
                MsgBox(ex.InnerException.Message, , "Error")
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                '    Throw
                'End If
                Return 0
            End Try
        End Function

        Public Function SolicitudAjustePrecioGetById(ByVal SAP_ID As Integer) As BE.SolicitudAjustePrecio Implements IBCSolicitudAjustePrecio.SolicitudAjustePrecioGetById
            Dim result As SolicitudAjustePrecio = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISolicitudAjustePrecioRepositorio)()
                result = rep.GetById(SAP_ID)
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
