Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class MovimientoCajaBancoRepositorio
        Implements IMovimientoCajaBancoRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.MovimientoCajaBanco) As Short Implements IMovimientoCajaBancoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.MovimientoCajaBanco.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Maintenance = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                Maintenance = 0
            End Try
        End Function
        Public Function spEliminarMovimientoCajaBanco(ByVal cDocumento As String, ByVal cItem As Int16) As Short Implements IMovimientoCajaBancoRepositorio.spEliminarMovimientoCajaBanco
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarMovimientoCajaBanco)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.DOCUMENTO, DbType.String, cDocumento)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.item, DbType.String, cItem)
                context.ExecuteNonQuery(cmd)
                spEliminarMovimientoCajaBanco = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarMovimientoCajaBanco = 0
            End Try
        End Function
        Public Function DeleteRegistro(ByVal item As BE.MovimientoCajaBanco, ByVal cDocumento As String, ByVal cITEM As Short) As Short Implements IMovimientoCajaBancoRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.MovimientoCajaBanco Where c.DOCUMENTO = cDocumento And c.item = cITEM Select c).FirstOrDefault()
                item.MarkAsDeleted()
                DeleteRegistro = Maintenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                DeleteRegistro = 0
            End Try
        End Function

        Public Function spActualizarRegistro(ByVal citem As Short, ByVal cTes_Fecha_Emi As Date, ByVal cCco_Id As String, ByVal cCuc_Id As String, ByVal cTes_Monto_total As Double, ByVal cCcc_Id As String, ByVal cCct_Id As String, ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cTes_Serie As String, ByVal cTes_Numero As String, ByVal cCargo As Double, ByVal cAbono As Double, ByVal cDte_ContraValor_Doc As Double, ByVal cPer_Id_Ban As String, ByVal cPer_Id_Cli As String, ByVal cCcc_Id_Cli As String, ByVal cCct_Id_Doc As String, ByVal cTdo_Id_Doc As String, ByVal cDtd_Id_Doc As String, ByVal cDte_Serie_Doc As String, ByVal cDte_Numero_Doc As String, ByVal cDte_Observaciones As String, ByVal cDOCUMENTO As String) As Short Implements IMovimientoCajaBancoRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroMovimientoCajaBanco)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.item, DbType.Int16, citem)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tes_Fecha_Emi, DbType.DateTime, cTes_Fecha_Emi)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cco_Id, DbType.String, cCco_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cuc_Id, DbType.String, cCuc_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tes_Monto_total, DbType.Double, cTes_Monto_total)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Ccc_Id, DbType.String, cCcc_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cct_Id, DbType.String, cCct_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tdo_Id, DbType.String, cTdo_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dtd_Id, DbType.String, cDtd_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tes_Serie, DbType.String, cTes_Serie)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tes_Numero, DbType.String, cTes_Numero)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cargo, DbType.Double, cCargo)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Abono, DbType.Double, cAbono)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dte_ContraValor_Doc, DbType.Double, cDte_ContraValor_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Per_Id_Ban, DbType.String, cPer_Id_Ban)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Per_Id_Cli, DbType.String, cPer_Id_Cli)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Ccc_Id_Cli, DbType.String, cCcc_Id_Cli)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cct_Id_Doc, DbType.String, cCct_Id_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tdo_Id_Doc, DbType.String, cTdo_Id_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dtd_Id_Doc, DbType.String, cDtd_Id_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dte_Serie_Doc, DbType.String, cDte_Serie_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dte_Numero_Doc, DbType.String, cDte_Numero_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dte_Observaciones, DbType.String, cDte_Observaciones)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.DOCUMENTO, DbType.String, cDOCUMENTO)
                context.ExecuteNonQuery(cmd)
                spActualizarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarRegistro = 0
            End Try
        End Function


        Public Function spActualizarRegistroExtorno(ByVal citem As Short, ByVal cTes_Fecha_Emi As Date, ByVal cCco_Id As String, ByVal cCuc_Id As String, ByVal cTes_Monto_total As Double, ByVal cCcc_Id As String, ByVal cCct_Id As String, ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cTes_Serie As String, ByVal cTes_Numero As String, ByVal cCargo As Double, ByVal cAbono As Double, ByVal cDte_ContraValor_Doc As Double, ByVal cPer_Id_Ban As String, ByVal cPer_Id_Cli As String, ByVal cCcc_Id_Cli As String, ByVal cCct_Id_Doc As String, ByVal cTdo_Id_Doc As String, ByVal cDtd_Id_Doc As String, ByVal cDte_Serie_Doc As String, ByVal cDte_Numero_Doc As String, ByVal cDte_Observaciones As String, ByVal cDOCUMENTO As String, ByVal cTipo As String) As Short Implements IMovimientoCajaBancoRepositorio.spActualizarRegistroExtorno
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroMovimientoCajaBancoExtorno)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.item, DbType.Int16, citem)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tes_Fecha_Emi, DbType.DateTime, cTes_Fecha_Emi)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cco_Id, DbType.String, cCco_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cuc_Id, DbType.String, cCuc_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tes_Monto_total, DbType.Double, cTes_Monto_total)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Ccc_Id, DbType.String, cCcc_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cct_Id, DbType.String, cCct_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tdo_Id, DbType.String, cTdo_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dtd_Id, DbType.String, cDtd_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tes_Serie, DbType.String, cTes_Serie)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tes_Numero, DbType.String, cTes_Numero)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cargo, DbType.Double, cCargo)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Abono, DbType.Double, cAbono)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dte_ContraValor_Doc, DbType.Double, cDte_ContraValor_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Per_Id_Ban, DbType.String, cPer_Id_Ban)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Per_Id_Cli, DbType.String, cPer_Id_Cli)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Ccc_Id_Cli, DbType.String, cCcc_Id_Cli)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cct_Id_Doc, DbType.String, cCct_Id_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tdo_Id_Doc, DbType.String, cTdo_Id_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dtd_Id_Doc, DbType.String, cDtd_Id_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dte_Serie_Doc, DbType.String, cDte_Serie_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dte_Numero_Doc, DbType.String, cDte_Numero_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dte_Observaciones, DbType.String, cDte_Observaciones)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.DOCUMENTO, DbType.String, cDOCUMENTO)
                context.ExecuteNonQuery(cmd)
                spActualizarRegistroExtorno = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spActualizarRegistroExtorno = 0
            End Try
        End Function

        Public Function spEliminarRegistro(ByVal cITEM As Short, ByVal cDOCUMENTO As String) As Short Implements IMovimientoCajaBancoRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroMovimientoCajaBanco)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.item, DbType.Int16, cITEM)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.DOCUMENTO, DbType.String, cDOCUMENTO)
                context.ExecuteNonQuery(cmd)
                spEliminarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarRegistro = 0
            End Try
        End Function

        Public Function spEliminarRegistroExtorno(ByVal cITEM As Short, ByVal cDOCUMENTO As String) As Short Implements IMovimientoCajaBancoRepositorio.spEliminarRegistroExtorno
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroMovimientoCajaBancoExtorno)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.item, DbType.Int16, cITEM)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.DOCUMENTO, DbType.String, cDOCUMENTO)
                context.ExecuteNonQuery(cmd)
                spEliminarRegistroExtorno = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarRegistroExtorno = 0
            End Try
        End Function

        Public Function spInsertarRegistro(ByVal citem As Short, ByVal cTes_Fecha_Emi As Date, ByVal cCco_Id As String, ByVal cCuc_Id As String, ByVal cTes_Monto_total As Double, ByVal cCcc_Id As String, ByVal cCct_Id As String, ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cTes_Serie As String, ByVal cTes_Numero As String, ByVal cCargo As Double, ByVal cAbono As Double, ByVal cDte_ContraValor_Doc As Double, ByVal cPer_Id_Ban As String, ByVal cPer_Id_Cli As String, ByVal cCcc_Id_Cli As String, ByVal cCct_Id_Doc As String, ByVal cTdo_Id_Doc As String, ByVal cDtd_Id_Doc As String, ByVal cDte_Serie_Doc As String, ByVal cDte_Numero_Doc As String, ByVal cDte_Observaciones As String, ByVal cDOCUMENTO As String) As Short Implements IMovimientoCajaBancoRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroMovimientoCajaBanco)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.item, DbType.Int16, citem)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tes_Fecha_Emi, DbType.DateTime, cTes_Fecha_Emi)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cco_Id, DbType.String, cCco_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cuc_Id, DbType.String, cCuc_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tes_Monto_total, DbType.Double, cTes_Monto_total)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Ccc_Id, DbType.String, cCcc_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cct_Id, DbType.String, cCct_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tdo_Id, DbType.String, cTdo_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dtd_Id, DbType.String, cDtd_Id)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tes_Serie, DbType.String, cTes_Serie)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tes_Numero, DbType.String, cTes_Numero)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cargo, DbType.Double, cCargo)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Abono, DbType.Double, cAbono)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dte_ContraValor_Doc, DbType.Double, cDte_ContraValor_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Per_Id_Ban, DbType.String, cPer_Id_Ban)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Per_Id_Cli, DbType.String, cPer_Id_Cli)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Ccc_Id_Cli, DbType.String, cCcc_Id_Cli)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Cct_Id_Doc, DbType.String, cCct_Id_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Tdo_Id_Doc, DbType.String, cTdo_Id_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dtd_Id_Doc, DbType.String, cDtd_Id_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dte_Serie_Doc, DbType.String, cDte_Serie_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dte_Numero_Doc, DbType.String, cDte_Numero_Doc)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.Dte_Observaciones, DbType.String, cDte_Observaciones)
                context.AddInParameter(cmd, MovimientoCajaBanco.PropertyNames.DOCUMENTO, DbType.String, cDOCUMENTO)
                context.ExecuteNonQuery(cmd)
                spInsertarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spInsertarRegistro = 0
            End Try
        End Function
    End Class
End Namespace
