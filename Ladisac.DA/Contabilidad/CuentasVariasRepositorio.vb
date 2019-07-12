Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Namespace Ladisac.DA

    Public Class CuentasVariasRepositorio
        Implements ICuentasVariasRepositorio

        <Dependency()> _
        Public Property ContainerService() As IUnityContainer

        Public Function GetById(ByVal id As String) As BE.CuentasVarias Implements ICuentasVariasRepositorio.GetById
            Dim result As BE.CuentasVarias = Nothing
            Try
                Dim context = ContainerService.Resolve(Of BE.LadisacEntities)()
                result = (From c In context.CuentasVarias. _
                          Include("CuentasContables"). _
                          Include("CuentasContables1"). _
                          Include("CuentasContables2"). _
                          Include("CuentasContables3"). _
                          Include("CuentasContables4"). _
                          Include("CuentasContables5"). _
                          Include("CuentasContables6"). _
                          Include("CuentasContables7"). _
                          Include("CuentasContables8"). _
                          Include("CuentasContables9"). _
                          Include("CuentasContables10"). _
                          Include("CuentasContables11")
                          Where c.cuv_Id = id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function Mantenance(ByVal item As BE.CuentasVarias) As Boolean Implements ICuentasVariasRepositorio.Mantenance
            Try

                If (item.ChangeTracker.State = ObjectState.Added) Then
                    Dim context = ContainerService.Resolve(Of LadisacEntities)()
                    context.CuentasVarias.ApplyChanges(item)
                    context.SaveChanges()
                    item.AcceptChanges()
                ElseIf (item.ChangeTracker.State = ObjectState.Modified) Then

                    Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                    Dim cmd = context.GetStoredProcCommand(DA.SPNames.SPCuentasVariasUpdate)

                    context.AddInParameter(cmd, CuentasVarias.PropertyNames.cuv_Id, DbType.String, item.cuv_Id)
                    context.AddInParameter(cmd, CuentasVarias.PropertyNames.cuc_IdIgvVentas, DbType.String, item.cuc_IdIgvVentas)
                    context.AddInParameter(cmd, CuentasVarias.PropertyNames.cuc_IdIgvCompras, DbType.String, item.cuc_IdIgvCompras)
                    context.AddInParameter(cmd, CuentasVarias.PropertyNames.cuc_IdIgvPerceCompra, DbType.String, item.cuc_IdIgvPerceCompra)
                    context.AddInParameter(cmd, CuentasVarias.PropertyNames.cuc_IdIgvPerceVenta, DbType.String, item.cuc_IdIgvPerceVenta)
                    context.AddInParameter(cmd, CuentasVarias.PropertyNames.cuc_IdIgvReteCompra, DbType.String, item.cuc_IdIgvReteCompra)
                    context.AddInParameter(cmd, CuentasVarias.PropertyNames.cuc_IdIgvReteVenta, DbType.String, item.cuc_IdIgvReteVenta)
                    context.AddInParameter(cmd, CuentasVarias.PropertyNames.cuc_IdRentaCuarta, DbType.String, item.cuc_IdRentaCuarta)
                    context.AddInParameter(cmd, CuentasVarias.PropertyNames.cuc_IdComprasExisten, DbType.String, item.cuc_IdComprasExisten)
                    context.AddInParameter(cmd, CuentasVarias.PropertyNames.cuc_IdPDC, DbType.String, item.cuc_IdPDC)
                    context.AddInParameter(cmd, CuentasVarias.PropertyNames.cuc_IdGDC, DbType.String, item.cuc_IdGDC)
                    context.AddInParameter(cmd, CuentasVarias.PropertyNames.cuc_IdGRD, DbType.String, item.cuc_IdGRD)
                    context.AddInParameter(cmd, CuentasVarias.PropertyNames.cuc_IdPRD, DbType.String, item.cuc_IdPRD)
                    context.AddInParameter(cmd, CuentasVarias.PropertyNames.Usu_Id, DbType.String, item.Usu_Id)

                    ' @cuv_Id Id3
                    ',@cuc_IdIgvVentas Id14
                    ',@cuc_IdIgvCompras Id14
                    ',@cuc_IdIgvPercepcionCompra id14
                    ',@cuc_IdIgvPercepcionVentas Id14
                    ' ,@cuc_IdIgvRetencionCompra id14
                    ',@cuc_IdIgvRetencionVentas Id14
                    ',@cuc_IdRentaCuarta Id14
                    ' ,@cuc_IdComprasExisten Id14
                    ' ,@cuc_IdPDC Id14
                    ' ,@cuc_IdGDC Id14
                    '  ,@cuc_IdGRD Id14
                    '  ,@cuc_IdPRD Id14
                    ',@Usu_Id Id10

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

'    Public Class ClaseCuentaRepositorio
'        Implements IClaseCuentaRepositorio

'        <Dependency()> _
'        Public Property ContainerService() As IUnityContainer


'        Public Function Mantenance(ByVal item As BE.ClaseCuenta) As Boolean Implements IClaseCuentaRepositorio.Mantenance
'            Try
'                Dim context = ContainerService.Resolve(Of LadisacEntities)()
'                context.ClaseCuenta.ApplyChanges(item)
'                context.SaveChanges()
'                item.AcceptChanges()
'                Return True
'            Catch ex As Exception
'                Dim rethro = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
'                If (rethro) Then
'                    Throw
'                End If
'            End Try
'            Return False
'        End Function

'    End Class

'End Namespace
