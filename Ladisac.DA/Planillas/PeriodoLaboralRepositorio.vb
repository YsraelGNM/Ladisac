Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Namespace Ladisac.DA
    Public Class PeriodoLaboralRepositorio
        Implements IPeriodoLaboralRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function getById(ByVal per_Id As String, ByVal ItemPeriodoLaboral As String) As Object Implements IPeriodoLaboralRepositorio.getById
            Dim result As PeriodoLaboral = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.PeriodoLaboral Where c.per_Id = per_Id And c.ItemPeriodoLaboral = ItemPeriodoLaboral).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As Ladisac.BE.PeriodoLaboral) As Object Implements IPeriodoLaboralRepositorio.Maintenance
            Try
                If (item.ChangeTracker.State = ObjectState.Added OrElse item.ChangeTracker.State = ObjectState.Deleted) Then
                    Dim context = ContainerService.Resolve(Of LadisacEntities)()
                    context.PeriodoLaboral.ApplyChanges(item)
                    context.SaveChanges()
                    item.AcceptChanges()
                End If
                If (item.ChangeTracker.State = ObjectState.Modified) Then
                    Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

                    Dim cmd = context.GetStoredProcCommand(DA.SPNames.SPPeriodoLaboralUpdate)

                    context.AddInParameter(cmd, PeriodoLaboral.PropertyNames.per_Id, DbType.String, item.per_Id)
                    context.AddInParameter(cmd, PeriodoLaboral.PropertyNames.ItemPeriodoLaboral, DbType.String, item.ItemPeriodoLaboral)
                    context.AddInParameter(cmd, PeriodoLaboral.PropertyNames.pel_FechaInicio, DbType.Date, item.pel_FechaInicio)
                    context.AddInParameter(cmd, PeriodoLaboral.PropertyNames.pel_FechaFin, DbType.Date, item.pel_FechaFin)
                    context.AddInParameter(cmd, PeriodoLaboral.PropertyNames.pel_Apuntes, DbType.String, item.pel_Apuntes)
                    context.AddInParameter(cmd, PeriodoLaboral.PropertyNames.pel_EsPeriodoActivo, DbType.Boolean, item.pel_EsPeriodoActivo)
                    context.AddInParameter(cmd, PeriodoLaboral.PropertyNames.pel_EsPeriodoLiquidacion, DbType.Boolean, item.pel_EsPeriodoLiquidacion)
                    context.AddInParameter(cmd, PeriodoLaboral.PropertyNames.tic_TipoCont_Id, DbType.String, item.tic_TipoCont_Id)

                    context.AddInParameter(cmd, PeriodoLaboral.PropertyNames.Usu_Id, DbType.String, item.Usu_Id)
                    context.AddInParameter(cmd, PeriodoLaboral.PropertyNames.pel_FecGrab, DbType.DateTime, Today)

                    context.ExecuteNonQuery(cmd)

                End If

                Return True
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



'Imports Microsoft.Practices.Unity
'Imports Ladisac.BE

'Namespace Ladisac.DA
'    Public Class CronogramaVacacionesRepositorio
'        Implements ICronogramaVacacionesRepositorio
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer


'        Public Function getById(ByVal per_Id As String, ByVal crv_ItemCroVaca As String) As BE.CronogramaVacaciones Implements ICronogramaVacacionesRepositorio.getById
'            Dim result As BE.CronogramaVacaciones = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                result = (From c In context.CronogramaVacaciones Where c.per_Id = per_Id And c.crv_ItemCroVaca = crv_ItemCroVaca Select c).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Mantenace(ByVal item As BE.CronogramaVacaciones) As Boolean Implements ICronogramaVacacionesRepositorio.Mantenace
'            Try
'                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
'                context.CronogramaVacaciones.ApplyChanges(item)
'                context.SaveChanges()
'                item.AcceptChanges()
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

