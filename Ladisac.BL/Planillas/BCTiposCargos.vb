Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCTiposCargos
        Implements IBCTiposCargos

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Sub Maintenance(ByVal item As BE.TiposCargos) Implements IBCTiposCargos.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposCargosRepositorio)()
                rep.Maintenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function TiposCargosQuery(ByVal tis_TipCargo_Id As String, ByVal tis_Descripcion As String) As Object Implements IBCTiposCargos.TiposCargosQuery
            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPTiposCargosSelectXML, tis_TipCargo_Id, tis_Descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function TiposCargosSeek(ByVal id As String) As BE.TiposCargos Implements IBCTiposCargos.TiposCargosSeek
            Dim result As TiposCargos = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposCargosRepositorio)()
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


