Namespace Ladisac.BL
    Public Class BCCuentasComprobantesLogistica
        Implements IBCCuentasComprobantesLogistica

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Sub Maintenance(ByVal xml As String, ByVal USU_ID As String) Implements IBCCuentasComprobantesLogistica.Maintenance
            Try
                Dim rep = ContainerService.Resolve(Of DA.CuentasComprobantesLogisticaRepositorio)()

                ' Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                rep.Maintenance(xml, USU_ID)
                'Scope.Complete()

                ' End Using


            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

        End Sub



        Public Function spCuentasComprobantesLogisticaSelect(ByVal idAlmacen As Integer) As Object Implements IBCCuentasComprobantesLogistica.spCuentasComprobantesLogisticaSelect

            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spCuentasComprobantesLogisticaSelect, idAlmacen)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function spAlmacenSelect(ByVal sDescripcion As String) As Object Implements IBCCuentasComprobantesLogistica.spAlmacenSelect
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spAlmacenSelect, sDescripcion)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function spCuentasComprobantesLogisticaValidar(ByVal sXml As String) As Object Implements IBCCuentasComprobantesLogistica.spCuentasComprobantesLogisticaValidar
            Dim result As DataTable = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spCuentasComprobantesLogisticaValidar, sXml)

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



'Namespace Ladisac.BL
'    Public Class BCGrupoTrabajoDiasDescanso
'        Implements IBCGrupoTrabajoDiasDescanso


'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Sub Maintenance(ByVal fechaInicio As Date, ByVal xml As String, ByVal USU_ID As String) Implements IBCGrupoTrabajoDiasDescanso.Maintenance
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.GrupoTrabajoDiasDescansoRepositorio)()

'                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

'                    rep.Maintenance(fechaInicio, xml, USU_ID)
'                    Scope.Complete()

'                End Using


'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'        End Sub

'        Public Function spGrupoTrabajoDiasDescansoSelect(ByVal fechaDesde As Date, Optional ByVal Trabajador As String = "", Optional ByVal filtro As Single = 0.0) As Object Implements IBCGrupoTrabajoDiasDescanso.spGrupoTrabajoDiasDescansoSelect
'            Dim result As DataTable = Nothing
'            Try

'                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.spGrupoTrabajoDiasDescansoSelect, fechaDesde, Trabajador, filtro)

'            Catch ex As Exception

'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function


'        Public Function spGrupoTrabajoDiasDescansoReporte(ByVal fechaDesde As Date, Optional ByVal Trabajador As String = "", Optional ByVal filtro As Single = 0.0) As Object Implements IBCGrupoTrabajoDiasDescanso.spGrupoTrabajoDiasDescansoReporte
'            Dim result As DataTable = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.spGrupoTrabajoDiasDescansoReporte, fechaDesde, Trabajador, filtro)

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

