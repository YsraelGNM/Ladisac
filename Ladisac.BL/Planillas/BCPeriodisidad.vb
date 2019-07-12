Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCPeriodisidad
        Implements IBCPeriodisidad

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Sub Maintenance(ByVal item As BE.Periodisidad) Implements IBCPeriodisidad.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPeriodisidadRepositorio)()
                rep.Mantenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

        End Sub

        Public Function PeriodisidadQuery(ByVal pec_Periodisidad_Id As String, ByVal pec_Descripcion As String) As Object Implements IBCPeriodisidad.PeriodisidadQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPPeriodisidadSelectXML, pec_Periodisidad_Id, pec_Descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PeriodisidadSeek(ByVal id As String) As BE.Periodisidad Implements IBCPeriodisidad.PeriodisidadSeek
            Dim result As Periodisidad
            Try
                Dim rep = ContainerService.Resolve(Of DA.IPeriodisidadRepositorio)()
                result = rep.GetId(id)
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

'    Public Class BCTiposContratos
'        Implements IBCTiposContratos
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer
'        Public Sub Maintenance(ByVal item As BE.TiposContratos) Implements BL.IBCTiposContratos.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.ITiposContratosRepositorio)()
'                rep.Mantenance(item)
'            Catch ex As Exception

'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'        End Sub

'        Public Function TiposContratosQuery(ByVal tic_TipoCont_Id As String, ByVal tico_Descripcion As String) As Object Implements BL.IBCTiposContratos.TiposContratosQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPTiposContratosSelectXML, tic_TipoCont_Id, tico_Descripcion)

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function

'        Public Function TiposContratosSeek(ByVal id As String) As BE.TiposContratos Implements BL.IBCTiposContratos.TiposContratosSeek
'            Dim resault As TiposContratos = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.ITiposContratosRepositorio)()
'                resault = rep.GetById(id)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return resault
'        End Function
'    End Class

'End Namespace
