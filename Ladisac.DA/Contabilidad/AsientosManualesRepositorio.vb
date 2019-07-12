

Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class AsientosManualesRepositorio
        Implements IAsientosManualesRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String) As BE.AsientosManuales Implements IAsientosManualesRepositorio.GetById
            Dim result As BE.AsientosManuales = Nothing
            Try

                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.AsientosManuales.Include("DetalleAsientosManuales") _
                          .Include("DetalleAsientosManuales.Personas") _
                          .Include("DetalleAsientosManuales.CtaCte") _
                          .Include("DetalleAsientosManuales.CuentasContables") _
                          .Include("DetalleAsientosManuales.DetalleTipoDocumentos1") _
                          .Include("LibrosContables") _
                          .Include("DetalleAsientosManuales.CentroCostos") _
                          .Include("DetalleAsientosManuales.Moneda") _
                          .Include("DetalleAsientosManuales.DetalleTipoDocumentos") _
                          Where c.lib_Id = lib_Id And c.prd_Periodo_id = prd_Periodo_id And c.asm_NumeroVoucher = asm_NumeroVoucher).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.AsientosManuales) As Boolean Implements IAsientosManualesRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.AsientosManuales.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return False

        End Function


        Public Function MaintenanceDelete(ByVal item As BE.AsientosManuales) As Object Implements IAsientosManualesRepositorio.MaintenanceDelete
            Try
                'elimiar
                Dim contextDelete = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

                Dim cmd = contextDelete.GetStoredProcCommand(DA.SPNames.SPAsientosManualesDelete)

                contextDelete.AddInParameter(cmd, BE.AsientosManuales.PropertyNames.lib_Id, DbType.String, item.lib_Id)
                contextDelete.AddInParameter(cmd, BE.AsientosManuales.PropertyNames.prd_Periodo_id, DbType.String, item.prd_Periodo_id)
                contextDelete.AddInParameter(cmd, BE.AsientosManuales.PropertyNames.asm_NumeroVoucher, DbType.String, item.asm_NumeroVoucher)

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

'    Public Class GrupoTrabajoRepositorio
'        Implements IGrupoTrabajoRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer
'        Public Function GetById(ByVal pedido As String, ByVal numero As String) As BE.GrupoTrabajo Implements IGrupoTrabajoRepositorio.GetById
'            Dim result As GrupoTrabajo = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.GrupoTrabajo.Include("DetalleGrupoTrabajo").Include("DetalleGrupoTrabajo.Personas").Include("DetalleGrupoTrabajo.TareaTrabajo").Include("DetalleGrupoTrabajo.TareaTrabajo.TiposTareaTrabajo").Include("DetalleGrupoTrabajo.Planta").Include("DetalleGrupoTrabajo.Produccion") _
'                          Where c.prd_Periodo_id = pedido And c.grt_NumeroProd = numero _
'                          Select c).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If

'            End Try
'            Return result

'        End Function

'        Public Function Maintenance(ByVal item As BE.GrupoTrabajo) As Object Implements IGrupoTrabajoRepositorio.Maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.GrupoTrabajo.ApplyChanges(item)
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
