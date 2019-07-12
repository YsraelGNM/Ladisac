Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCDetallePlanilla
        Implements IBCDetallePlanilla

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.DetallePlanillas) As Object Implements IBCDetallePlanilla.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetallePlanillaRepositorio)()
                Return rep.Maintenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return False
        End Function

        Public Function SPDetallePlanillasUpdate(ByVal xml As String) As Object Implements IBCDetallePlanilla.SPDetallePlanillasUpdate
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                rep.EjecutarReporte(DA.SPNames.SPDetallePlanillasUpdate, xml)
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



'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Class BCDetallePermisosTrabajador
'        Implements IBCDetallePermisosTrabajador

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function DetallePermisosTrabajadorSeek(ByVal numero As String, ByVal item As String) As Object Implements IBCDetallePermisosTrabajador.DetallePermisosTrabajadorSeek
'            Dim result As DetallePermisosTrabajador = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IDetallePermisosTrabajadorRepositorio)()
'                result = rep.GetById(numero, item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function DetallePermisosTrabajadroQuery(ByVal numero As String, ByVal item As String) As Object Implements IBCDetallePermisosTrabajador.DetallePermisosTrabajadroQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPDetallePermisosTrabajadorSelectXML, numero, item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.DetallePermisosTrabajador) As Object Implements IBCDetallePermisosTrabajador.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IDetallePermisosTrabajadorRepositorio)()
'                Return rep.Maintenance(item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return False
'        End Function
'    End Class
'End Namespace
