Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCCentroRiesgo
        Implements BL.IBCCentroRiesgo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function CentroRiesgoQuery(ByVal id As String, Optional ByVal descripcion As String = Nothing) As Object Implements IBCCentroRiesgo.CentroRiesgoQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPCentroRiesgoSelectXML, id, descripcion)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function CentroRiesgoSeek(ByVal id As String) As BE.CentroRiesgo Implements IBCCentroRiesgo.CentroRiesgoSeek
            Dim result As CentroRiesgo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICentroRiesgoRepositorio)()
                result = rep.GetById(id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.CentroRiesgo) As Object Implements IBCCentroRiesgo.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICentroRiesgoRepositorio)()
                Return rep.Maintenance(item)
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