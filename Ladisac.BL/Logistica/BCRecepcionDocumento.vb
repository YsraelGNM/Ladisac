Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCRecepcionDocumento
        Implements IBCRecepcionDocumento

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaRecepcionDocumento() As String Implements IBCRecepcionDocumento.ListaRecepcionDocumento
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRecepcionDocumentoRepositorio)()
                result = rep.ListaRecepcionDocumento
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoRecepcionDocumento(ByVal mRecepcionDocumento As BE.RecepcionDocumento) Implements IBCRecepcionDocumento.MantenimientoRecepcionDocumento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRecepcionDocumentoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mRecepcionDocumento.ChangeTracker.State = ObjectState.Added) Then
                        mRecepcionDocumento.RDO_ID = bcherramientas.Get_Id("RecepcionDocumento")
                    ElseIf (mRecepcionDocumento.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mRecepcionDocumento)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                '    Throw
                'End If
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Function RecepcionDocumentoGetById(ByVal RDO_ID As Integer) As BE.RecepcionDocumento Implements IBCRecepcionDocumento.RecepcionDocumentoGetById
            Dim result As RecepcionDocumento = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRecepcionDocumentoRepositorio)()
                result = rep.GetById(RDO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDarRecepcion(ByVal PER_ID_RECIBIDO As String) As System.Collections.Generic.List(Of BE.RecepcionDocumento) Implements IBCRecepcionDocumento.ListaDarRecepcion
            Dim result As List(Of RecepcionDocumento) = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRecepcionDocumentoRepositorio)()
                result = rep.ListaDarRecepcion(PER_ID_RECIBIDO)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaReporteSeguimientoDocumento(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Serie As String, ByVal Numero As String, ByVal Per_Id_Proveedor As String, ByVal USU_ID As String) As DataTable Implements IBCRecepcionDocumento.ListaReporteSeguimientoDocumento
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("doc.spListaReporteSeguimientoDocumento", FecIni, FecFin, Serie, Numero, Per_Id_Proveedor, USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function RecepcionDocumentoGetById2(ByVal Per_Id As String, ByVal Dtd_Id As String, ByVal Serie As String, ByVal Numero As String) As BE.RecepcionDocumento Implements IBCRecepcionDocumento.RecepcionDocumentoGetById2
            Dim result As RecepcionDocumento = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IRecepcionDocumentoRepositorio)()
                result = rep.GetById2(Per_Id, Dtd_Id, Serie, Numero)
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
