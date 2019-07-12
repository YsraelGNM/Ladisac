Imports Ladisac.BL
Namespace Ladisac.BL

    Public Class BCCtaCte
        Implements IBCCtaCte
        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function CtaCteQuery(ByVal CCT_ID As String, ByVal CCT_DESCRIPCION As String) As Object Implements IBCCtaCte.CtaCteQuery

            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPCtaCteSelectXML, CCT_ID, CCT_DESCRIPCION)
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result

        End Function

        Public Function CtaCteSeek(ByVal id As String) As BE.CtaCte Implements IBCCtaCte.CtaCteSeek
            Dim result As BE.CtaCte = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.ICtaCteRepositorio)()
                result = rep.GetById(id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.CtaCte) As Object Implements IBCCtaCte.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICtaCteRepositorio)()
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
