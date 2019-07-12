Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCPeriodoLaboral
        Implements BL.IBCPeriodoLaboral

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function Maintenance(ByVal item As BE.PeriodoLaboral) As Object Implements IBCPeriodoLaboral.Maintenance
            Dim x As Integer = 0
            Try

            Catch ex As Exception

            End Try
            Return False
        End Function
    End Class

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Class BCCronogramaVacaciones
'        Implements BL.IBCCronogramaVacaciones
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer
'        <Dependency()> _
'        Public Property BCUtil As Ladisac.BL.IBCUtil

'        Public Function CronogramaVacacionesQuery(ByVal per_Id As String, ByVal crv_ItemCroVaca As String) As Object Implements IBCCronogramaVacaciones.CronogramaVacacionesQuery
'            Dim result As String = Nothing

'            Try
'                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
'                result = rep.EjecutarReporte(DA.SPNames.SPCronogramaVacacionesSelectXML, per_Id, crv_ItemCroVaca)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)

'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result
'        End Function

'        Public Function CronogramaVacacionesSeek(ByVal per_Id As String, ByVal crv_ItemCroVaca As String) As BE.CronogramaVacaciones Implements IBCCronogramaVacaciones.CronogramaVacacionesSeek
'            Dim result As BE.CronogramaVacaciones = Nothing
'            Try
'                Dim rep = ContainerService.Resolve(Of DA.ICronogramaVacacionesRepositorio)()
'                result = rep.getById(per_Id, crv_ItemCroVaca)
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function

'        Public Function Maintenance(ByVal items As System.Collections.Generic.List(Of BE.CronogramaVacaciones)) As Object Implements IBCCronogramaVacaciones.Maintenance
'            Dim x As Integer = 0
'            Try
'                Dim repDET = ContainerService.Resolve(Of DA.ICronogramaVacacionesRepositorio)()
'                Dim sCorrelativo As String = Nothing
'                Using Scope As New System.Transactions.TransactionScope
'                    sCorrelativo = BCUtil.GetId("pla.CronogramaVacaciones", "crv_ItemCroVaca", 3, " where per_Id='" & items(0).per_Id & "'")

'                    x = CInt(sCorrelativo)

'                    For Each mItemIngreso In items
'                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
'                            mItemIngreso.crv_ItemCroVaca = Right("0000" & x.ToString(), 3)
'                            x += 1
'                        End If
'                        repDET.Mantenace(mItemIngreso)
'                    Next
'                    Scope.Complete()

'                End Using
'                Return True
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