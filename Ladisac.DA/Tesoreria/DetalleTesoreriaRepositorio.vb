Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    ''iii
    Public Class DetalleTesoreriaRepositorio
        Implements IDetalleTesoreriaRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.DetalleTesoreria) As Short Implements IDetalleTesoreriaRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DetalleTesoreria.ApplyChanges(item)
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
        Public Function DeleteRegistro(ByVal item As BE.DetalleTesoreria, ByVal cTDO_ID As String, ByVal cCCC_ID As String, ByVal cDTE_SERIE As String, ByVal cDTE_NUMERO As String, ByVal cDTD_ID As String, ByVal cDTE_ITEM As String) As Short Implements IDetalleTesoreriaRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.DetalleTesoreria Where c.TDO_ID = cTDO_ID And c.CCC_ID = cCCC_ID And c.DTE_SERIE = cDTE_SERIE And c.DTE_NUMERO = cDTE_NUMERO And c.DTD_ID = cDTD_ID And c.DTE_ITEM = cDTE_ITEM Select c).FirstOrDefault()
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

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cCCT_ID As String, ByVal cDTE_SERIE As String, ByVal cDTE_NUMERO As String, ByVal cDTE_ITEM As Short, ByVal cCCC_ID_CLI As String, ByVal cDTE_DESTINO As Short, ByVal cCCO_ID As String, ByVal cCUC_ID As String, ByVal cPER_ID_CLI As String, ByVal cTDO_ID_DOC As String, ByVal cDTD_ID_DOC As String, ByVal cCCT_ID_DOC As String, ByVal cDTE_SERIE_DOC As String, ByVal cDTE_NUMERO_DOC As String, ByVal cDTE_FEC_VEN As Date, ByVal cMON_ID_DOC As String, ByVal cDTE_IMPORTE_DOC As Double, ByVal cDTE_CONTRAVALOR_DOC As Double, ByVal cPER_ID_CLI_1 As String, ByVal cTDO_ID_DOC_1 As String, ByVal cDTD_ID_DOC_1 As String, ByVal cCCT_ID_DOC_1 As String, ByVal cDTE_SERIE_DOC_1 As String, ByVal cDTE_NUMERO_DOC_1 As String, ByVal cDTE_FEC_VEN_1 As Date, ByVal cMON_ID_DOC_1 As String, ByVal cDTE_IMPORTE_DOC_1 As Double, ByVal cDTE_CONTRAVALOR_DOC_1 As Double, ByVal cDTE_OBSERVACIONES As String, ByVal cDTE_OPE_CONTABLE As Short, ByVal cDTE_MOVIMIENTO As Short, ByVal cDTE_TIPO_RECIBO As Short, ByVal cDTE_CAPITAL_DOC As Double, ByVal cDTE_INTERES_DOC As Double, ByVal cDTE_GASTOS_DOC As Double, ByVal cDTD_IDe As String, ByVal cUSU_ID As String, ByVal cDTE_FEC_GRAB As Date, ByVal cDTE_ESTADO As Boolean) As Short Implements IDetalleTesoreriaRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroDetalleTesoreria)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CCT_ID, DbType.String, cCCT_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_SERIE, DbType.String, cDTE_SERIE)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_NUMERO, DbType.String, cDTE_NUMERO)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_ITEM, DbType.Int16, cDTE_ITEM)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CCC_ID_CLI, DbType.String, cCCC_ID_CLI)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_DESTINO, DbType.Int16, cDTE_DESTINO)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CCO_ID, DbType.String, cCCO_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CUC_ID, DbType.String, cCUC_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.TDO_ID_DOC, DbType.String, cTDO_ID_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTD_ID_DOC, DbType.String, cDTD_ID_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CCT_ID_DOC, DbType.String, cCCT_ID_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_SERIE_DOC, DbType.String, cDTE_SERIE_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_NUMERO_DOC, DbType.String, cDTE_NUMERO_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_FEC_VEN, DbType.DateTime, cDTE_FEC_VEN)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.MON_ID_DOC, DbType.String, cMON_ID_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_IMPORTE_DOC, DbType.Double, cDTE_IMPORTE_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_CONTRAVALOR_DOC, DbType.Double, cDTE_CONTRAVALOR_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.PER_ID_CLI_1, DbType.String, cPER_ID_CLI_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.TDO_ID_DOC_1, DbType.String, cTDO_ID_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTD_ID_DOC_1, DbType.String, cDTD_ID_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CCT_ID_DOC_1, DbType.String, cCCT_ID_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_SERIE_DOC_1, DbType.String, cDTE_SERIE_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_NUMERO_DOC_1, DbType.String, cDTE_NUMERO_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_FEC_VEN_1, DbType.DateTime, cDTE_FEC_VEN_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.MON_ID_DOC_1, DbType.String, cMON_ID_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_IMPORTE_DOC_1, DbType.Double, cDTE_IMPORTE_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_CONTRAVALOR_DOC_1, DbType.Double, cDTE_CONTRAVALOR_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_OBSERVACIONES, DbType.String, cDTE_OBSERVACIONES)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_OPE_CONTABLE, DbType.Int16, cDTE_OPE_CONTABLE)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_MOVIMIENTO, DbType.Int16, cDTE_MOVIMIENTO)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_TIPO_RECIBO, DbType.Int16, cDTE_TIPO_RECIBO)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_CAPITAL_DOC, DbType.Double, cDTE_CAPITAL_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_INTERES_DOC, DbType.Double, cDTE_INTERES_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_GASTOS_DOC, DbType.Double, cDTE_GASTOS_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTD_IDe, DbType.String, cDTD_IDe)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_FEC_GRAB, DbType.DateTime, cDTE_FEC_GRAB)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_ESTADO, DbType.Boolean, cDTE_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cDTE_SERIE As String, ByVal cDTE_NUMERO As String, ByVal cDTE_ITEM As Short) As Short Implements IDetalleTesoreriaRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroDetalleTesoreria)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_SERIE, DbType.String, cDTE_SERIE)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_NUMERO, DbType.String, cDTE_NUMERO)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_ITEM, DbType.Int16, cDTE_ITEM)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cCCT_ID As String, ByVal cDTE_SERIE As String, ByVal cDTE_NUMERO As String, ByVal cDTE_ITEM As Short, ByVal cCCC_ID_CLI As String, ByVal cDTE_DESTINO As Short, ByVal cCCO_ID As String, ByVal cCUC_ID As String, ByVal cPER_ID_CLI As String, ByVal cTDO_ID_DOC As String, ByVal cDTD_ID_DOC As String, ByVal cCCT_ID_DOC As String, ByVal cDTE_SERIE_DOC As String, ByVal cDTE_NUMERO_DOC As String, ByVal cDTE_FEC_VEN As Date, ByVal cMON_ID_DOC As String, ByVal cDTE_IMPORTE_DOC As Double, ByVal cDTE_CONTRAVALOR_DOC As Double, ByVal cPER_ID_CLI_1 As String, ByVal cTDO_ID_DOC_1 As String, ByVal cDTD_ID_DOC_1 As String, ByVal cCCT_ID_DOC_1 As String, ByVal cDTE_SERIE_DOC_1 As String, ByVal cDTE_NUMERO_DOC_1 As String, ByVal cDTE_FEC_VEN_1 As Date, ByVal cMON_ID_DOC_1 As String, ByVal cDTE_IMPORTE_DOC_1 As Double, ByVal cDTE_CONTRAVALOR_DOC_1 As Double, ByVal cDTE_OBSERVACIONES As String, ByVal cDTE_OPE_CONTABLE As Short, ByVal cDTE_MOVIMIENTO As Short, ByVal cDTE_TIPO_RECIBO As Short, ByVal cDTE_CAPITAL_DOC As Double, ByVal cDTE_INTERES_DOC As Double, ByVal cDTE_GASTOS_DOC As Double, ByVal cDTD_IDe As String, ByVal cUSU_ID As String, ByVal cDTE_FEC_GRAB As Date, ByVal cDTE_ESTADO As Boolean) As Short Implements IDetalleTesoreriaRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroDetalleTesoreria)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CCT_ID, DbType.String, cCCT_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_SERIE, DbType.String, cDTE_SERIE)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_NUMERO, DbType.String, cDTE_NUMERO)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_ITEM, DbType.Int16, cDTE_ITEM)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CCC_ID_CLI, DbType.String, cCCC_ID_CLI)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_DESTINO, DbType.Int16, cDTE_DESTINO)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CCO_ID, DbType.String, cCCO_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CUC_ID, DbType.String, cCUC_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.TDO_ID_DOC, DbType.String, cTDO_ID_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTD_ID_DOC, DbType.String, cDTD_ID_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CCT_ID_DOC, DbType.String, cCCT_ID_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_SERIE_DOC, DbType.String, cDTE_SERIE_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_NUMERO_DOC, DbType.String, cDTE_NUMERO_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_FEC_VEN, DbType.DateTime, cDTE_FEC_VEN)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.MON_ID_DOC, DbType.String, cMON_ID_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_IMPORTE_DOC, DbType.Double, cDTE_IMPORTE_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_CONTRAVALOR_DOC, DbType.Double, cDTE_CONTRAVALOR_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.PER_ID_CLI_1, DbType.String, cPER_ID_CLI_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.TDO_ID_DOC_1, DbType.String, cTDO_ID_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTD_ID_DOC_1, DbType.String, cDTD_ID_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.CCT_ID_DOC_1, DbType.String, cCCT_ID_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_SERIE_DOC_1, DbType.String, cDTE_SERIE_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_NUMERO_DOC_1, DbType.String, cDTE_NUMERO_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_FEC_VEN_1, DbType.DateTime, cDTE_FEC_VEN_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.MON_ID_DOC_1, DbType.String, cMON_ID_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_IMPORTE_DOC_1, DbType.Double, cDTE_IMPORTE_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_CONTRAVALOR_DOC_1, DbType.Double, cDTE_CONTRAVALOR_DOC_1)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_OBSERVACIONES, DbType.String, cDTE_OBSERVACIONES)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_OPE_CONTABLE, DbType.Int16, cDTE_OPE_CONTABLE)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_MOVIMIENTO, DbType.Int16, cDTE_MOVIMIENTO)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_TIPO_RECIBO, DbType.Int16, cDTE_TIPO_RECIBO)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_CAPITAL_DOC, DbType.Double, cDTE_CAPITAL_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_INTERES_DOC, DbType.Double, cDTE_INTERES_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_GASTOS_DOC, DbType.Double, cDTE_GASTOS_DOC)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTD_IDe, DbType.String, cDTD_IDe)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_FEC_GRAB, DbType.DateTime, cDTE_FEC_GRAB)
                context.AddInParameter(cmd, DetalleTesoreria.PropertyNames.DTE_ESTADO, DbType.Boolean, cDTE_ESTADO)
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
