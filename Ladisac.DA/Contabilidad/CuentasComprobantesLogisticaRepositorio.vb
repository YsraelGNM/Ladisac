Namespace Ladisac.DA

    Public Class CuentasComprobantesLogisticaRepositorio
        Implements ICuentasComprobantesLogisticaRepositorio


        Public Function Maintenance(ByVal xml As String, ByVal USU_ID As String) As Object Implements ICuentasComprobantesLogisticaRepositorio.Maintenance
            Try
                Using Scope As New System.Transactions.TransactionScope()

                    Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

                    Dim cmd = context.GetStoredProcCommand(DA.SPNames.SPCuentasComprobantesLogistica)

                    context.AddInParameter(cmd, "xml", DbType.Xml, xml)
                    context.AddInParameter(cmd, "USU_ID", DbType.String, USU_ID)
                    context.ExecuteNonQuery(cmd)
                    Scope.Complete()

                End Using
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Function
    End Class

End Namespace



'Namespace Ladisac.DA
'    Public Class GrupoTrabajoDiasDescansoRepositorio
'        Implements IGrupoTrabajoDiasDescansoRepositorio


'        Public Function Maintenance(ByVal fechaInicio As Date, ByVal xml As String, ByVal USU_ID As String) As Object Implements IGrupoTrabajoDiasDescansoRepositorio.Maintenance
'            Try
'                '  Using Scope As New System.Transactions.TransactionScope()

'                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

'                Dim cmd = context.GetStoredProcCommand(DA.SPNames.SPGrupoTrabajoDiasDescansoRepositorio)
'                context.AddInParameter(cmd, "FechaInicio", DbType.Date, fechaInicio)
'                context.AddInParameter(cmd, "xml", DbType.Xml, xml)
'                context.AddInParameter(cmd, "USU_ID", DbType.String, USU_ID)
'                context.ExecuteNonQuery(cmd)


'                ' End Using
'            Catch ex As Exception

'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'        End Function
'    End Class
'End Namespace