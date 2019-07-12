Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ProvisionComprasRepositorio
        Implements IProvisionComprasRepositorio



        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal prd_Periodo_id As String, ByVal prc_Voucher As String, ByVal lib_Id As String) As Object Implements IProvisionComprasRepositorio.GetById
            Dim result As BE.ProvisionCompras = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.ProvisionCompras.Include("DetalleProvisionCompras") _
                            .Include("DetalleProvisionCompras.CuentasContables") _
                            .Include("DetalleProvisionCompras.Almacen") _
                            .Include("LibrosContables") _
                            .Include("Moneda") _
                            .Include("OperacionDetraciones") _
                            .Include("TiposBienesServicios") _
                            .Include("PuntoVenta") _
                            .Include("TipoVenta") _
                            .Include("Personas") _
                            .Include("DetalleProvisionCompras.CentroCostos") _
                            .Include("RolOpeCtaCte.DetalleTipoDocumentos") _
                            .Include("DetalleTipoDocumentos") _
                            .Include("CentroCostos") _
                            .Include("ReferenciaProvisionCompras") _
                            .Include("ReferenciaProvisionCompras.TipoDocumentos") _
                            .Include("Personas1") _
                            .Include("TiposReparables")
                          Select c Where c.prd_Periodo_id = prd_Periodo_id _
                          And c.prc_Voucher = prc_Voucher _
                          And c.lib_Id = lib_Id).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function maintenance(ByVal item As BE.ProvisionCompras) As Object Implements IProvisionComprasRepositorio.maintenance
            Try


                If (item.ChangeTracker.State = ObjectState.Added OrElse item.ChangeTracker.State = ObjectState.Modified) Then

                    Dim context = ContainerService.Resolve(Of LadisacEntities)()
                    context.ProvisionCompras.ApplyChanges(item)
                    context.SaveChanges()
                    item.AcceptChanges()

                Else
                    'elimiar
                    Dim contextDelete = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

                    Dim cmd = contextDelete.GetStoredProcCommand(DA.SPNames.SPProvisionComprasDelete)

                    contextDelete.AddInParameter(cmd, Conceptos.PropertyNames.tic_TipoConcep_Id, DbType.String, item.prd_Periodo_id)
                    contextDelete.AddInParameter(cmd, Conceptos.PropertyNames.con_Concepto, DbType.String, item.prc_Voucher)
                    contextDelete.AddInParameter(cmd, Conceptos.PropertyNames.con_EsFijoTrabajador, DbType.Boolean, item.lib_Id)

                    contextDelete.ExecuteNonQuery(cmd)

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


        Public Function MaintenanceDelete(ByVal item As BE.ProvisionCompras) As Object Implements IProvisionComprasRepositorio.MaintenanceDelete
            Try
                'elimiar
                Dim contextDelete = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

                Dim cmd = contextDelete.GetStoredProcCommand(DA.SPNames.SPProvisionComprasDelete)

                contextDelete.AddInParameter(cmd, ProvisionCompras.PropertyNames.prd_Periodo_id, DbType.String, item.prd_Periodo_id)
                contextDelete.AddInParameter(cmd, ProvisionCompras.PropertyNames.prc_Voucher, DbType.String, item.prc_Voucher)
                contextDelete.AddInParameter(cmd, ProvisionCompras.PropertyNames.lib_Id, DbType.String, item.lib_Id)

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

        Public Function spDetalleProvisionCompras(ByVal prd_Periodo_id As String, ByVal prc_Voucher As String, ByVal cuc_IdOld As String, ByVal cuc_Idnew As String) As Object Implements IProvisionComprasRepositorio.spDetalleProvisionCompras
            Try
                'elimiar
                Dim contextDelete = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

                Dim cmd = contextDelete.GetStoredProcCommand(DA.SPNames.spDetalleProvisionCompras)

                contextDelete.AddInParameter(cmd, "@prd_Periodo_id", DbType.String, prd_Periodo_id)
                contextDelete.AddInParameter(cmd, "@prc_Voucher", DbType.String, prc_Voucher)
                contextDelete.AddInParameter(cmd, "@cuc_IdOld", DbType.String, cuc_IdOld)
                contextDelete.AddInParameter(cmd, "@cuc_Idnew", DbType.String, cuc_Idnew)

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

'    Public Class AsientosManualesRepositorio
'        Implements IAsientosManualesRepositorio
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Function GetById(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String) As BE.AsientosManuales Implements IAsientosManualesRepositorio.GetById
'            Dim result As BE.AsientosManuales = Nothing
'            Try

'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.AsientosManuales.Include("DetalleAsientosManuales").Include("DetalleAsientosManuales.Personas").Include("DetalleAsientosManuales.RolOpeCtaCte.CtaCte").Include("DetalleAsientosManuales.CuentasContables").Include("DetalleAsientosManuales.RolOpeCtaCte.DetalleTipoDocumentos").Include("LibrosContables").Include("DetalleAsientosManuales.CentroCostos").Include("DetalleAsientosManuales.Moneda") _
'                          Where c.lib_Id = lib_Id And c.prd_Periodo_id = prd_Periodo_id And c.asm_NumeroVoucher = asm_NumeroVoucher).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result
'        End Function

'        Public Function Maintenance(ByVal item As BE.AsientosManuales) As Boolean Implements IAsientosManualesRepositorio.Maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.AsientosManuales.ApplyChanges(item)
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
