Imports Ladisac.BE

Namespace Ladisac.BL
    Public Class BCDetalleAsientosManuales
        Implements IBCDetalleAsientosManuales

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function DetalleAsientosManualesQuery(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String, ByVal dam_Item As String) As Object Implements IBCDetalleAsientosManuales.DetalleAsientosManualesQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDetalleAsientosManualesSelectXML, lib_Id, prd_Periodo_id, asm_NumeroVoucher, dam_Item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function DetalleAsientosManualesSeek(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String, ByVal dam_Item As String) As Object Implements IBCDetalleAsientosManuales.DetalleAsientosManualesSeek
            Dim result As BE.DetalleAsientosManuales = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleAsientosManualesRepositorio)()
                result = rep.GetById(lib_Id, prd_Periodo_id, asm_NumeroVoucher, dam_Item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result

        End Function

        Public Function Maintenance(ByVal item As BE.DetalleAsientosManuales) As Object Implements IBCDetalleAsientosManuales.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetalleAsientosManualesRepositorio)()
                Return rep.Maintenance(item)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False
        End Function

        Public Function RolOpeCtaCteQuery(ByVal CCT_ID As String, ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DTD_DESCRIPCION As String) As Object Implements IBCDetalleAsientosManuales.RolOpeCtaCteQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPRolOpeCtaCteSelectXML, CCT_ID, TDO_ID, DTD_ID, DTD_DESCRIPCION)
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

'    Public Class BCDetalleGrupoTrabajo
'        Implements IBCDetalleGrupoTrabajo
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function DetalleGrupoTrabajoQuery(ByVal prd_Periodo_id As String, ByVal grt_NumeroProd As String, ByVal dgt_Item As String) As Object Implements IBCDetalleGrupoTrabajo.DetalleGrupoTrabajoQuery
'            Dim result As String = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPDetalleGrupoTrabajoSelectXML, prd_Periodo_id, grt_NumeroProd, dgt_Item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function

'        Public Function DetalleGrupoTrabajoSeek(ByVal prd_Periodo_id As String, ByVal grt_NumeroProd As String, ByVal dgt_Item As String) As Object Implements IBCDetalleGrupoTrabajo.DetalleGrupoTrabajoSeek
'            Dim result As BE.DetalleGrupoTrabajo = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IDetalleGrupoTrabajoRepositorio)()
'                result = rep.GetById(prd_Periodo_id, grt_NumeroProd, dgt_Item)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.DetalleGrupoTrabajo) As Object Implements IBCDetalleGrupoTrabajo.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IDetalleGrupoTrabajoRepositorio)()
'                Return rep.Maintenance(item)
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


