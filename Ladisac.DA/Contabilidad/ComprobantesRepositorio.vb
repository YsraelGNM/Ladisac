Imports Ladisac.BE
Imports Microsoft.Practices.Unity
Imports System.Text


Namespace Ladisac.DA

    Public Class ComprobantesRepositorio
        Implements IComprobantesRepositorio


        <Dependency()> _
        Public Property ContainserService As IUnityContainer

        Public Function GetById(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal cob_Serie As String, ByVal cob_Numero As String) As Object Implements IComprobantesRepositorio.GetById
            Dim result As BE.Comprobantes = Nothing

            Try
                Dim context = ContainserService.Resolve(Of LadisacEntities)()
                result = (From c In context.Comprobantes.Include("Moneda") _
                          .Include("Personas") _
                          .Include("DetalleComprobantes") _
                          .Include("TipoDocumentos")
                        Where c.cct_Id = cct_Id _
                           And c.tdo_Id = tdo_Id _
                           And c.dtd_Id = dtd_Id _
                           And c.cob_Serie = cob_Serie _
                           And c.cob_Numero = cob_Numero).FirstOrDefault

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.Comprobantes) As Boolean Implements IComprobantesRepositorio.Maintenance

            Try
                Dim context = ContainserService.Resolve(Of LadisacEntities)()
                context.Comprobantes.ApplyChanges(item)
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

        Public Function MaintenanceDelete(ByVal item As BE.Comprobantes) As Boolean Implements IComprobantesRepositorio.MaintenanceDelete
            Try
                'elimiar
                Dim contextDelete = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

                Dim cmd = contextDelete.GetStoredProcCommand(DA.SPNames.spComprobantesDelete)

                contextDelete.AddInParameter(cmd, BE.Comprobantes.PropertyNames.tdo_Id, DbType.String, item.tdo_Id)
                contextDelete.AddInParameter(cmd, Comprobantes.PropertyNames.dtd_Id, DbType.String, item.dtd_Id)
                contextDelete.AddInParameter(cmd, Comprobantes.PropertyNames.cob_Serie, DbType.String, item.cob_Serie)
                contextDelete.AddInParameter(cmd, Comprobantes.PropertyNames.cob_Numero, DbType.String, item.cob_Numero)

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
