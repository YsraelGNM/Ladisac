Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCTiposPlanillas
        Implements IBCTiposPlanillas
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.TiposPlanillas) As Object Implements IBCTiposPlanillas.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposPlanillasRepositorio)()
                'Dim rep As New DA.TiposPlanillasRepositorio
                Return rep.Mantenance(item)
            Catch ex As Exception
                MsgBox(ex.Message)
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False

        End Function

        Public Function TiposPlanillasSeek(ByVal id As String) As BE.TiposPlanillas Implements IBCTiposPlanillas.TiposPlanillasSeek
            Dim result As TiposPlanillas = Nothing
            Try
                'Dim rep = ContainerService.Resolve(Of DA.ITiposPlanillasRepositorio)()
                Dim rep As New DA.TiposPlanillasRepositorio

                result = rep.GetById(id)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function TiposPlanillasQuery(ByVal tip_TipoPlan_Id As String, ByVal tip_Descripcion As String) As Object Implements IBCTiposPlanillas.TiposPlanillasQuery

            Dim result As String = Nothing
            Try
                ' Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                Dim rep As New Ladisac.DA.ReportesRepositorio

                result = rep.EjecutarReporte(DA.SPNames.SPTiposPlanillasSelectXML, tip_TipoPlan_Id, tip_Descripcion)

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
