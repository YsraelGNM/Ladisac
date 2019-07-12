
Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCTareaTrabajo
        Implements IBCTareaTrabajo


        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil

        Public Function Maintenance(ByVal item As BE.TareaTrabajo) As Object Implements IBCTareaTrabajo.Maintenance
            Dim sCorrelativo As String
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITareaTrabajoRepositorio)()
                If (item.ChangeTracker.State = ObjectState.Added) Then
                    sCorrelativo = BCUtil.GetId("pla.TareaTrabajo", "ttr_TareaTrab_Id", 6, " ")
                    item.ttr_TareaTrab_Id = sCorrelativo
                End If

                Return rep.Mantenance(item)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False

        End Function

        Public Function TareaTrabajoQuery(ByVal tit_TipTarea_Id As String, ByVal ttr_Tarea As String, ByVal produccion_ID As String) As Object Implements IBCTareaTrabajo.TareaTrabajoQuery
            Dim result As String = Nothing
            Try
                Dim rep = (ContainerService.Resolve(Of DA.IReportesRepositorio)())
                result = rep.EjecutarReporte(DA.SPNames.SPTareaTrabajoSelectXML, tit_TipTarea_Id, ttr_Tarea, produccion_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function TareaTrabajoSeek(ByVal tit_TipTarea_Id As String, ByVal ttr_TareaTrab_Id As String) As Object Implements IBCTareaTrabajo.TareaTrabajoSeek
            Dim result As BE.TareaTrabajo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITareaTrabajoRepositorio)()
                result = rep.GetById(tit_TipTarea_Id, ttr_TareaTrab_Id)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ArticulosQuery(ByVal codigoFabrica As String, ByVal descripcion As String) As Object Implements IBCTareaTrabajo.ArticulosQuery
            Dim result As String = Nothing
            Try
                Dim rep = (ContainerService.Resolve(Of DA.IReportesRepositorio)())
                result = rep.EjecutarReporte(DA.SPNames.SPArticulosSelectXML, codigoFabrica, descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SPTareaTrabajoExportarSelect(ByVal tit_TipTarea_Id As String) As Object Implements IBCTareaTrabajo.SPTareaTrabajoExportarSelect
            Dim result As DataTable = Nothing

            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))
                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.SPTareaTrabajoExportarSelect, tit_TipTarea_Id)
                    Scope.Complete()
                End Using

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

' End Namespace