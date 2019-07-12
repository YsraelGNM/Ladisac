Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCTiposTareos
        Implements IBCTiposTareos

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.TiposTareos) As Object Implements IBCTiposTareos.Maintenance

            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposTareosRepositorio)()
                Return rep.Mantenance(item)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False

        End Function

        Public Function TiposTareosQuery(ByVal tio_TiposTareo_Id As String, ByVal tio_Descripcion As String) As Object Implements IBCTiposTareos.TiposTareosQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPTiposTareosSelectXML, tio_TiposTareo_Id, tio_Descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function TiposTareosSeek(ByVal id As String) As BE.TiposTareos Implements IBCTiposTareos.TiposTareosSeek
            Dim result As TiposTareos = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposTareosRepositorio)()
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

