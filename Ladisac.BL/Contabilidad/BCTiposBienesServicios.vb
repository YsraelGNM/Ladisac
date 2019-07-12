Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCTiposBienesServicios
        Implements IBCTiposBienesServicios
        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function Maintenance(ByVal item As BE.TiposBienesServicios) As Object Implements IBCTiposBienesServicios.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposBienesServiciosRepositorio)()
                Return rep.Mantenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function TiposBienesServiciosQuery(ByVal tib_TipoBien_Id As String, ByVal tib_Descripcion As String) As Object Implements IBCTiposBienesServicios.TiposBienesServiciosQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPTiposBienesServiciosSelectXML, tib_TipoBien_Id, tib_Descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function TiposBienesServiciosSeek(ByVal id As String) As BE.TiposBienesServicios Implements IBCTiposBienesServicios.TiposBienesServiciosSeek
            Dim result As BE.TiposBienesServicios = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposBienesServiciosRepositorio)()
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


'Imports Ladisac.BL
'Namespace Ladisac.BL

'    Public Class BCClaseCuenta
'        Implements IBCClaseCuenta


'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function ClaseCuentaQuery(ByVal cls_Id As String, ByVal cls_Clase As String) As Object Implements IBCClaseCuenta.ClaseCuentaQuery

'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPClaseCuentaSelectXML, cls_Id, cls_Clase)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try

'            Return result

'        End Function

'        Public Function ClaseCuentaSeek(ByVal id As String) As BE.ClaseCuenta Implements IBCClaseCuenta.ClaseCuentaSeek
'            Dim result As BE.ClaseCuenta = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IClaseCuentaRepositorio)()
'                result = rep.GetById(id)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.ClaseCuenta) As Object Implements IBCClaseCuenta.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IClaseCuentaRepositorio)()
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