Imports Ladisac.Bl
Namespace Ladisac.BL

    Public Class BCCentroCosto
        Implements IBCCentroCosto
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Function CentroCostoQuery(Optional ByVal Id As String = Nothing, Optional ByVal descripcion As String = Nothing) As Object Implements IBCCentroCosto.CentroCostoQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spCentroCostoXML, Id, descripcion)


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