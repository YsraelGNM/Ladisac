Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCDetalleComedor
        Implements IBCDetalleComedor
        'fff

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.DetalleComedorPLL) As Object Implements IBCDetalleComedor.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleComedorRepositorio)()
                Return rep.Maintenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                Throw
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