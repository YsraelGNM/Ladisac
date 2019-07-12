Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCDetalleTrabajadorJudicial
        Implements IBCDetalleTrabajadorJudicial
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function DetalleTrabajadorJudicialQuery(ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String, Optional ByVal tip_TipoPlan_Id As String = Nothing) As Object Implements IBCDetalleTrabajadorJudicial.DetalleTrabajadorJudicialQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetalleTrabajadorJudicialSelectXML, dtj_SerieJudi, dtj_NumeroJudi, tip_TipoPlan_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function DetalleTrabajadorJudicialSeek(ByVal tip_TipoPlan_Id As String, ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String) As Object Implements IBCDetalleTrabajadorJudicial.DetalleTrabajadorJudicialSeek
            Dim result As DetalleTrabajadorJudicial = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleTrabajadorJudicialRepositorio)()
                result = rep.GetById(tip_TipoPlan_Id, dtj_SerieJudi, dtj_NumeroJudi)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.DetalleTrabajadorJudicial) As Object Implements IBCDetalleTrabajadorJudicial.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleTrabajadorJudicialRepositorio)()
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
