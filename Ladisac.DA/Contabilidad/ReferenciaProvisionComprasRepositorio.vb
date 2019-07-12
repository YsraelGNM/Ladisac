Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA
    Public Class ReferenciaProvisionComprasRepositorio
        Implements IReferenciaProvisionComprasRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal prc_Voucher As String, ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal rep_Serie As String, ByVal rep_Numero As String) As Object Implements IReferenciaProvisionComprasRepositorio.GetById
            Dim result As BE.ReferenciaProvisionCompras = Nothing
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                result = (From c In context.ReferenciaProvisionCompras _
                          Where c.prc_Voucher = prc_Voucher _
                          And c.lib_Id = lib_Id _
                          And c.prd_Periodo_id = prd_Periodo_id _
                          And c.cct_Id = cct_Id _
                          And c.tdo_Id = tdo_Id _
                          And c.dtd_Id = dtd_Id _
                          And c.rep_Serie = rep_Serie _
                          And c.rep_Numero = rep_Numero Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)

                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.ReferenciaProvisionCompras) As Object Implements IReferenciaProvisionComprasRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of LadisacEntities)()
                context.ReferenciaProvisionCompras.ApplyChanges(item)
                context.SaveChanges()
                context.AcceptAllChanges()
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

'    Public Class ProvisionComprasRepositorio
'        Implements IProvisionComprasRepositorio

'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer



'        Public Function GetById(ByVal prd_Periodo_id As String, ByVal prc_Voucher As String, ByVal lib_Id As String) As Object Implements IProvisionComprasRepositorio.GetById
'            Dim result As BE.ProvisionCompras = Nothing
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                result = (From c In context.ProvisionCompras.Include("DetalleProvisionCompras") _
'                          .Include("DetalleProvisionCompras.CuentasContables") _
'                          .Include("LibrosContables") _
'                          .Include("Moneda") _
'                          .Include("OperacionDetraciones") _
'                          .Include("TiposBienesServicios") _
'                          .Include("PuntoVenta") _
'                          .Include("TipoVenta") _
'                          .Include("Personas") _
'                          .Include("DetalleProvisionCompras.CentroCostos") _
'                          .Include("RolOpeCtaCte.DetalleTipoDocumentos") _
'                          .Include("DetalleTipoDocumentos") _
'                          Select c Where c.prd_Periodo_id = prd_Periodo_id _
'                          And c.prc_Voucher = prc_Voucher _
'                          And c.lib_Id = lib_Id).FirstOrDefault

'            Catch ex As Exception
'                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethrow) Then
'                    Throw
'                End If
'            End Try
'            Return result

'        End Function

'        Public Function maintenance(ByVal item As BE.ProvisionCompras) As Object Implements IProvisionComprasRepositorio.maintenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.ProvisionCompras.ApplyChanges(item)
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

