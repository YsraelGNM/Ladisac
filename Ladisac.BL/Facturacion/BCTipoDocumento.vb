Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCTipoDocumento
        Implements IBCTipoDocumento

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaDetalleTipoDocumento() As String Implements IBCTipoDocumento.ListaDetalleTipoDocumento
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleTipoDocumentoRepositorio)()
                result = rep.ListaDetalleTipoDocumento
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function TipoDocumentoGetById(ByVal DTD_ID As String) As BE.DetalleTipoDocumentos Implements IBCTipoDocumento.TipoDocumentoGetById
            Dim result As DetalleTipoDocumentos = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleTipoDocumentoRepositorio)()
                result = rep.GetById(DTD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Mantenimiento(ByVal Item As BE.TipoDocumentos) As Short Implements IBCTipoDocumento.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoDocumentoRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            Mantenimiento = 0
                            Exit Function
                        End If
                    End If
                    Mantenimiento = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Item.vMensajeError = ex.Message
                Else
                    Item.vMensajeError = ex.InnerException.Message
                End If
                Mantenimiento = 0
            End Try
        End Function

        Public Function ListaDetalleTipoDocumentoSalidaCombustible() As String Implements IBCTipoDocumento.ListaDetalleTipoDocumentoSalidaCombustible
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaDetalleTipoDocumentoSalidaCombustible")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function


        Public Function ListaDetalleTipoDocumentoRendicion() As String Implements IBCTipoDocumento.ListaDetalleTipoDocumentoRendicion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleTipoDocumentoRepositorio)()
                result = rep.ListaDetalleTipoDocumentoRendicion
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDetalleTipoDocumentoISO() As String Implements IBCTipoDocumento.ListaDetalleTipoDocumentoISO
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaDetalleTipoDocumentoISO")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDetalleTipoDocumentoRecepcion() As String Implements IBCTipoDocumento.ListaDetalleTipoDocumentoRecepcion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaDetalleTipoDocumentoRecepcion")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDetalleTipoDocumentoCuentaRendir() As String Implements IBCTipoDocumento.ListaDetalleTipoDocumentoCuentaRendir
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaDetalleTipoDocumentoCuentaRendir")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDetalleTipoDocumentoServicio() As String Implements IBCTipoDocumento.ListaDetalleTipoDocumentoServicio
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaDetalleTipoDocumentoServicio")
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
