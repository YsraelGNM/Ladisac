Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DetalleAsientosManualesRepositorio
        Implements IDetalleAsientosManualesRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String, ByVal dam_Item As String) As BE.DetalleAsientosManuales Implements IDetalleAsientosManualesRepositorio.GetById
            Dim result As BE.DetalleAsientosManuales = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.DetalleAsientosManuales _
                          Where c.lib_Id = lib_Id And _
                          c.prd_Periodo_id = prd_Periodo_id And _
                          c.asm_NumeroVoucher = asm_NumeroVoucher And _
                          c.dam_Item = dam_Item).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.DetalleAsientosManuales) As Boolean Implements IDetalleAsientosManualesRepositorio.Maintenance
            Try

                If (item.ChangeTracker.State = ObjectState.Deleted) Then

                    MaintenanceDelete(item)

                Else

                    Dim context = ContainerService.Resolve(Of LadisacEntities)()
                    context.DetalleAsientosManuales.ApplyChanges(item)
                    context.SaveChanges()
                    context.AcceptAllChanges()
                    Return True

                End If

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False

        End Function

        Public Function MaintenanceDelete(ByVal item As BE.DetalleAsientosManuales) As Object Implements IDetalleAsientosManualesRepositorio.MaintenanceDelete
            Try
                'elimiar
                Dim contextDelete = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

                Dim cmd = contextDelete.GetStoredProcCommand(DA.SPNames.SPDetalleAsientosManualesDelete)

                contextDelete.AddInParameter(cmd, BE.DetalleAsientosManuales.PropertyNames.asm_NumeroVoucher, DbType.String, item.asm_NumeroVoucher)
                contextDelete.AddInParameter(cmd, BE.DetalleAsientosManuales.PropertyNames.lib_Id, DbType.String, item.lib_Id)
                contextDelete.AddInParameter(cmd, BE.DetalleAsientosManuales.PropertyNames.prd_Periodo_id, DbType.String, item.prd_Periodo_id)
                contextDelete.AddInParameter(cmd, BE.DetalleAsientosManuales.PropertyNames.dam_Item, DbType.String, item.dam_Item)


                contextDelete.ExecuteNonQuery(cmd)

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
'Imports System.Text

'Namespace Ladisac.DA
'    Public Class DetalleGrupoTrabajoRepositorio
'        Implements IDetalleGrupoTrabajoRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function GetById(ByVal pedido As String, ByVal numero As String, ByVal items As String) As BE.DetalleGrupoTrabajo Implements IDetalleGrupoTrabajoRepositorio.GetById
'            Dim result As BE.DetalleGrupoTrabajo = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.DetalleGrupoTrabajo _
'                          Where c.prd_Periodo_id = pedido And _
'                          c.grt_NumeroProd = numero And _
'                          c.dgt_Item = items Select c).FirstOrDefault
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function

'        Public Function Maintenance(ByVal item As BE.DetalleGrupoTrabajo) As Object Implements IDetalleGrupoTrabajoRepositorio.Maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.DetalleGrupoTrabajo.ApplyChanges(item)
'                context.SaveChanges()
'                context.AcceptAllChanges()
'                Return True
'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return True

'        End Function
'    End Class

'End Namespace
