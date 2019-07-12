Imports Ladisac.BL
Namespace Ladisac.BL

    Public Class BCClaseCuenta
        Implements IBCClaseCuenta


        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function ClaseCuentaQuery(ByVal cls_Id As String, ByVal cls_Clase As String) As Object Implements IBCClaseCuenta.ClaseCuentaQuery

            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPClaseCuentaSelectXML, cls_Id, cls_Clase)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result

        End Function

        Public Function ClaseCuentaSeek(ByVal id As String) As BE.ClaseCuenta Implements IBCClaseCuenta.ClaseCuentaSeek
            Dim result As BE.ClaseCuenta = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IClaseCuentaRepositorio)()
                result = rep.GetById(id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.ClaseCuenta) As Object Implements IBCClaseCuenta.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IClaseCuentaRepositorio)()
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


'Imports Ladisac.BL

'Namespace Ladisac.BL
'    Public Class BCCuentasContables
'        Implements IBCCuentasContables
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer
'        Public Function CuentasContablesQuery(ByVal CUC_ID As String, ByVal CUC_DESCRIPCION As String) As Object Implements IBCCuentasContables.CuentasContablesQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPCuentasContablesSelectXML, CUC_ID, CUC_DESCRIPCION)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function CuentasContablesSeek(ByVal id As String) As BE.CuentasContables Implements IBCCuentasContables.CuentasContablesSeek
'            Dim result As BE.CuentasContables = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.ICuentasContablesRepositorio)()
'                result = rep.GetById(id)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result

'        End Function

'        Public Function Maintenance(ByVal item As BE.CuentasContables) As Object Implements IBCCuentasContables.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.ICuentasContablesRepositorio)()
'                Return rep.Mantenance(item)

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