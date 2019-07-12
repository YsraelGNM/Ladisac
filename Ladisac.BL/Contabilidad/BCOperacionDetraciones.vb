Imports Ladisac.BL
Namespace Ladisac.BL
    Public Class BCOperacionDetraciones
        Implements IBCOperacionDetraciones
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.OperacionDetraciones) As Object Implements IBCOperacionDetraciones.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOperacionDetracionesRepositorio)()
                Return rep.Mantenance(item)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return False
        End Function

        Public Function OperacionDetracionesQuery(ByVal opd_Oper_Detra_Id As String, ByVal opd_Descripcion As String) As Object Implements IBCOperacionDetraciones.OperacionDetracionesQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                Return rep.EjecutarReporte(DA.SPNames.SPOperacionDetracionesSelectXML, opd_Oper_Detra_Id, opd_Descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function OperacionDetracionesSeek(ByVal id As String) As BE.OperacionDetraciones Implements IBCOperacionDetraciones.OperacionDetracionesSeek
            Dim result As BE.OperacionDetraciones = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOperacionDetracionesRepositorio)()
                result = rep.GetById(id)
            Catch ex As Exception
                Dim rethorw = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethorw) Then
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

