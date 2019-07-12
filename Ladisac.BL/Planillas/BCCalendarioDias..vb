
Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCCalendarioDias
        Implements IBCCalendarioDias
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function CalendarioDiasQuery(ByVal fechaDesde As Date, ByVal fechaHasta As Date) As Object Implements IBCCalendarioDias.CalendarioDiasQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPCalendarioDiasSelectXML, fechaDesde, fechaHasta)

            Catch ex As Exception
                Dim rethtrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethtrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function CalendarioDiasSeek(ByVal id As Date) As Object Implements IBCCalendarioDias.CalendarioDiasSeek
            Dim result As BE.CalendarioDias = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICalendarioDiasRespositorio)()
                result = rep.GetbyId(id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.CalendarioDias) As Object Implements IBCCalendarioDias.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICalendarioDiasRespositorio)()
                Return rep.Mantenance(item)
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


'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Class BCAreaTrabajos
'        Implements IBCAreaTrabajos

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function AreaTrabajosQuery(Optional ByVal id As String = Nothing, Optional ByVal nombre As String = Nothing) As Object Implements IBCAreaTrabajos.AreaTrabajosQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPAreaTrabajosSelectXML, id, nombre)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function

'        Public Function Maintenance(ByVal item As BE.AreaTrabajos) As Object Implements IBCAreaTrabajos.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IAreaTrabajosRepositorio)()
'                Return rep.Mantenance(item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return False
'        End Function

'        Public Function AreaTrabajoSeek(ByVal id As String) As BE.AreaTrabajos Implements IBCAreaTrabajos.AreaTrabajoSeek
'            Dim result As AreaTrabajos = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IAreaTrabajosRepositorio)()
'                result = rep.GetById(id)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function
'    End Class

'End Namespace