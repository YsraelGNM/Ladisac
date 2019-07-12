Imports Ladisac.BL

Namespace Ladisac.BL

    Public Class BCCuentasContables
        Implements IBCCuentasContables

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function CuentasContablesQuery(ByVal CUC_ID As String, ByVal CUC_DESCRIPCION As String, ByVal cuc_Abreviatura As String, ByVal activo As Integer) As Object Implements IBCCuentasContables.CuentasContablesQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPCuentasContablesSelectXML, CUC_ID, CUC_DESCRIPCION, cuc_Abreviatura, activo)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function CuentasContablesSeek(ByVal id As String) As BE.CuentasContables Implements IBCCuentasContables.CuentasContablesSeek
            Dim result As BE.CuentasContables = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICuentasContablesRepositorio)()
                result = rep.GetById(id)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.CuentasContables) As Object Implements IBCCuentasContables.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICuentasContablesRepositorio)()
                Return rep.Mantenance(item)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False
        End Function

        Public Function CuentasContablesDetalleQuery(ByVal CUC_ID As String, ByVal CUC_DESCRIPCION As String) As Object Implements IBCCuentasContables.CuentasContablesDetalleQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPCuentasContablesDetalleSelectXML, CUC_ID, CUC_DESCRIPCION)

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
'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Class BCNivelEducacion
'        Implements IBCNivelEducacion

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function Maintenance(ByVal item As BE.NivelEducacion) As Object Implements IBCNivelEducacion.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.INivelEducacionRepositorio)()
'                Return rep.Mantenance(item)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return False
'        End Function

'        Public Function NivelEducacionQuery(ByVal nie_NiveEduc_Id As String, ByVal nie_Descipcion As String) As Object Implements IBCNivelEducacion.NivelEducacionQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPNivelEducacionSelectXML, nie_NiveEduc_Id, nie_Descipcion)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function

'        Public Function NivelEducacionSeek(ByVal id As String) As BE.NivelEducacion Implements IBCNivelEducacion.NivelEducacionSeek
'            Dim result As NivelEducacion = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.INivelEducacionRepositorio)()
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