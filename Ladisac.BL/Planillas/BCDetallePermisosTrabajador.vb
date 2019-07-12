Imports Ladisac.BE
Namespace Ladisac.BL


    Public Class BCDetallePermisosTrabajador
        Implements IBCDetallePermisosTrabajador

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function DetallePermisosTrabajadorSeek(ByVal numero As String, ByVal item As String) As Object Implements IBCDetallePermisosTrabajador.DetallePermisosTrabajadorSeek
            Dim result As DetallePermisosTrabajador = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetallePermisosTrabajadorRepositorio)()
                result = rep.GetById(numero, item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function DetallePermisosTrabajadroQuery(ByVal numero As String, ByVal item As String) As Object Implements IBCDetallePermisosTrabajador.DetallePermisosTrabajadroQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetallePermisosTrabajadorSelectXML, numero, item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.DetallePermisosTrabajador) As Object Implements IBCDetallePermisosTrabajador.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetallePermisosTrabajadorRepositorio)()
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

'    Public Class BCDetallePrestamosTrabajador
'        Implements IBCDetallePrestamosTrabajador
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function DetallePrestamosTrabajadorQuery(ByVal serie As String, ByVal numero As String, ByVal item As String) As Object Implements IBCDetallePrestamosTrabajador.DetallePrestamosTrabajadorQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPDetallePrestamosTrabajadorSelectXML, serie, numero, item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function DetallePrestamosTrabajadorSeek(ByVal serie As String, ByVal numero As String, ByVal item As String) As Object Implements IBCDetallePrestamosTrabajador.DetallePrestamosTrabajadorSeek
'            Dim result As DetallePrestamosTrabajador = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IDetallePrestamosTrabajadorRepositorio)()
'                result = rep.GetById(serie, numero, item)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.DetallePrestamosTrabajador) As Object Implements IBCDetallePrestamosTrabajador.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IDetallePrestamosTrabajadorRepositorio)()
'                Return rep.Maintenance(item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                Throw
'            End Try
'            Return False

'        End Function

'    End Class

'End Namespace