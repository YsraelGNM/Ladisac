Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCTiposTareaTrabajo
        Implements IBCTiposTareaTrabajo
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.TiposTareaTrabajo) As Object Implements IBCTiposTareaTrabajo.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposTareaTrabajoRepositorio)()
                Return rep.Mantenance(item)
            Catch ex As Exception
                Dim rethorw = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethorw) Then
                    Throw
                End If
            End Try
            Return False
        End Function

        Public Function TiposTareaTrabajoQuery(ByVal id As String, ByVal descripcion As String) As Object Implements IBCTiposTareaTrabajo.TiposTareaTrabajoQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPTiposTareaTrabajoSelectXML, id, descripcion)

            Catch ex As Exception
                Dim rethtow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethtow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function TiposTareaTrabajoSeek(ByVal id As String) As BE.TiposTareaTrabajo Implements IBCTiposTareaTrabajo.TiposTareaTrabajoSeek
            Dim result As TiposTareaTrabajo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITiposTareaTrabajoRepositorio)()
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