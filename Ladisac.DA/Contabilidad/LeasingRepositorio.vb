Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA
    Public Class LeasingRepositorio
        Implements ILeasingRepositorio


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal cct_Id As String, ByVal tdo_Id As String, ByVal dtd_Id As String, ByVal lea_Serie As String, ByVal lea_Numero As String) As BE.Leasing Implements ILeasingRepositorio.GetById
            Dim result As BE.Leasing = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.Leasing.Include("DetalleLeasing").Include("DetalleLeasingActivosFijos").Include("Moneda").Include("Personas").Include("CentroCostos") _
                          Where c.cct_Id = cct_Id _
                          And c.tdo_Id = tdo_Id _
                          And c.dtd_Id = dtd_Id _
                          And c.lea_Serie = lea_Serie _
                          And c.lea_Numero = lea_Numero).FirstOrDefault()

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Maintenance(ByVal item As BE.Leasing) As Boolean Implements ILeasingRepositorio.Maintenance
            Try
                Dim contex = ContainerService.Resolve(Of LadisacEntities)()
                contex.Leasing.ApplyChanges(item)
                contex.SaveChanges()
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

        Public Function MaintenanceDelete(ByVal item As BE.Leasing) As Boolean Implements ILeasingRepositorio.MaintenanceDelete
            Try
                'eliminar
                Dim contextDelete = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = contextDelete.GetStoredProcCommand(DA.SPNames.SPLeasingDelete)

                contextDelete.AddInParameter(cmd, BE.Leasing.PropertyNames.cct_Id, DbType.String, item.cct_Id)
                contextDelete.AddInParameter(cmd, BE.Leasing.PropertyNames.tdo_Id, DbType.String, item.tdo_Id)
                contextDelete.AddInParameter(cmd, BE.Leasing.PropertyNames.dtd_Id, DbType.String, item.dtd_Id)
                contextDelete.AddInParameter(cmd, BE.Leasing.PropertyNames.lea_Serie, DbType.String, item.lea_Serie)
                contextDelete.AddInParameter(cmd, BE.Leasing.PropertyNames.lea_Numero, DbType.String, item.lea_Numero)
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



'Public Function MaintenanceDelete(ByVal item As BE.Comprobantes) As Boolean Implements IComprobantesRepositorio.MaintenanceDelete
'    Try
'        'elimiar
'        Dim contextDelete = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

'        Dim cmd = contextDelete.GetStoredProcCommand(DA.SPNames.spComprobantesDelete)

'        contextDelete.AddInParameter(cmd, BE.Comprobantes.PropertyNames.tdo_Id, DbType.String, item.tdo_Id)
'        contextDelete.AddInParameter(cmd, Comprobantes.PropertyNames.dtd_Id, DbType.String, item.dtd_Id)
'        contextDelete.AddInParameter(cmd, Comprobantes.PropertyNames.cob_Serie, DbType.String, item.cob_Serie)
'        contextDelete.AddInParameter(cmd, Comprobantes.PropertyNames.cob_Numero, DbType.String, item.cob_Numero)

'        contextDelete.ExecuteNonQuery(cmd)
'       Return True
'    Catch ex As Exception
'        Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'        If (rethrow) Then
'            Throw
'        End If
'    End Try
'    Return False
'End Function