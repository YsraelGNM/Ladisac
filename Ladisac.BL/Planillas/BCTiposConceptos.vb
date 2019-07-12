Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCTiposConceptos
        Implements IBCTiposConceptos
        Implements IBCTiposConceptosQueries
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function TiposDocumentosQuery(Optional ByVal codigo As String = Nothing, Optional ByVal des As String = Nothing) As String Implements IBCTiposConceptosQueries.TiposDocumentosQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPTiposConceptosSelectXML, codigo, des)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoInsertTiposConceptos(ByVal id As String, ByVal descripcion As String, ByVal usuario As String) Implements IBCTiposConceptos.MantenimientoInsertTiposConceptos
            Try
                Dim rep = ContainerService.Resolve(Of DA.TiposConceptosRepositorio)()
                rep.ModificarDescripcion(id, descripcion, usuario)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try



        End Sub

        Public Sub MnatenimientoInsertTiposConceptos(ByVal item As BE.TiposConceptos) Implements IBCTiposConceptos.MnatenimientoInsertTiposConceptos
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposConceptosRepositorio)()
                rep.Maintenance(item)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

        End Sub

        Public Function TiposDocumentosSeek(ByVal id As String) As BE.TiposConceptos Implements IBCTiposConceptosQueries.TiposDocumentosSeek
            Dim result As TiposConceptos = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposConceptosRepositorio)()
                result = rep.GetById(id)

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
