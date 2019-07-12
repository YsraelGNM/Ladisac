Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class DetallePrestamoRepositorio
        Implements IDetallePrestamoRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Public Function Maintenance(ByVal item As BE.DetallePrestamo) As Short Implements IDetallePrestamoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DetallePrestamo.ApplyChanges(item)
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
        Public Function DeleteRegistro(ByVal item As DetallePrestamo, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cDPR_SERIE As String, ByVal cDPR_NUMERO As String, ByVal cDPR_ITEM As String) As Short Implements IDetallePrestamoRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.DetallePrestamo Where c.TDO_ID = cTDO_ID And c.DTD_ID = cDTD_ID And c.CCC_ID = cCCC_ID And c.DPR_SERIE = cDPR_SERIE And c.DPR_NUMERO = cDPR_NUMERO And c.DPR_ITEM = cDPR_ITEM Select c).FirstOrDefault()
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

        Public Function spActualizarRegistro(ByVal cTDO_ID As String,
           ByVal cDTD_ID As String,ByVal cCCC_ID As String,ByVal cDPR_SERIE As String,ByVal cDPR_NUMERO As String,
           ByVal cCCT_ID As String,ByVal cMON_ID As String,ByVal cDPR_ITEM As Int16,ByVal cPER_ID_CLI As String,
           ByVal cDPR_FEC_VEN As DateTime,ByVal cDPR_CAPITAL As Double,ByVal cDPR_INTERES As Double,ByVal cDPR_GASTOS As Double,
           ByVal cDPR_IMPORTE As Double,ByVal cDPR_CONTRAVALOR As Double,ByVal cDPR_OBSERVACIONES As String,ByVal cTDO_ID_DOC As String,
           ByVal cDTD_ID_DOC As String,ByVal cCCT_ID_DOC As String,ByVal cDPR_SERIE_DOC As String,ByVal cDPR_NUMERO_DOC As String,
           ByVal cPER_ID_CLI_DOC As String,ByVal cUSU_ID As String,ByVal cDPR_FEC_GRAB As DateTime,
           ByVal cDPR_ESTADO As Boolean) As Short Implements IDetallePrestamoRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroDetallePrestamo)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_SERIE, DbType.String, cDPR_SERIE)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_NUMERO, DbType.String, cDPR_NUMERO)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.CCT_ID, DbType.String, cCCT_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.MON_ID, DbType.String, cMON_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_ITEM, DbType.Int16, cDPR_ITEM)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_FEC_VEN, DbType.DateTime, cDPR_FEC_VEN)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_CAPITAL, DbType.Double, cDPR_CAPITAL)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_INTERES, DbType.Double, cDPR_INTERES)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_GASTOS, DbType.Double, cDPR_GASTOS)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_IMPORTE, DbType.Double, cDPR_IMPORTE)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_CONTRAVALOR, DbType.Double, cDPR_CONTRAVALOR)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_OBSERVACIONES, DbType.String, cDPR_OBSERVACIONES)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.TDO_ID_DOC, DbType.String, cTDO_ID_DOC)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DTD_ID_DOC, DbType.String, cDTD_ID_DOC)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.CCT_ID_DOC, DbType.String, cCCT_ID_DOC)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_SERIE_DOC, DbType.String, cDPR_SERIE_DOC)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_NUMERO_DOC, DbType.String, cDPR_NUMERO_DOC)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.PER_ID_CLI_DOC, DbType.String, cPER_ID_CLI_DOC)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_FEC_GRAB, DbType.DateTime, cDPR_FEC_GRAB)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_ESTADO, DbType.Boolean, cDPR_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cDPR_SERIE As String, ByVal cDPR_NUMERO As String, ByVal cDPR_ITEM As Short) As Short Implements IDetallePrestamoRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroDetallePrestamo)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_SERIE, DbType.String, cDPR_SERIE)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_NUMERO, DbType.String, cDPR_NUMERO)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_ITEM, DbType.Int16, cDPR_ITEM)
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

        Public Function spEliminarRegistroGeneral(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cDPR_SERIE As String, ByVal cDPR_NUMERO As String) As Short Implements IDetallePrestamoRepositorio.spEliminarRegistroGeneral
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroGeneralDetallePrestamo)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_SERIE, DbType.String, cDPR_SERIE)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_NUMERO, DbType.String, cDPR_NUMERO)
                context.ExecuteNonQuery(cmd)
                spEliminarRegistroGeneral = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                spEliminarRegistroGeneral = 0
            End Try
        End Function

        Public Function spInsertarRegistro(ByVal cTDO_ID As String,
           ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cDPR_SERIE As String, ByVal cDPR_NUMERO As String,
           ByVal cCCT_ID As String, ByVal cMON_ID As String, ByVal cDPR_ITEM As Int16, ByVal cPER_ID_CLI As String,
           ByVal cDPR_FEC_VEN As DateTime, ByVal cDPR_CAPITAL As Double, ByVal cDPR_INTERES As Double, ByVal cDPR_GASTOS As Double,
           ByVal cDPR_IMPORTE As Double, ByVal cDPR_CONTRAVALOR As Double, ByVal cDPR_OBSERVACIONES As String, ByVal cTDO_ID_DOC As String,
           ByVal cDTD_ID_DOC As String, ByVal cCCT_ID_DOC As String, ByVal cDPR_SERIE_DOC As String, ByVal cDPR_NUMERO_DOC As String,
           ByVal cPER_ID_CLI_DOC As String, ByVal cUSU_ID As String, ByVal cDPR_FEC_GRAB As DateTime,
           ByVal cDPR_ESTADO As Boolean) As Short Implements IDetallePrestamoRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroDetallePrestamo)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_SERIE, DbType.String, cDPR_SERIE)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_NUMERO, DbType.String, cDPR_NUMERO)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.CCT_ID, DbType.String, cCCT_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.MON_ID, DbType.String, cMON_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_ITEM, DbType.Int16, cDPR_ITEM)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_FEC_VEN, DbType.DateTime, cDPR_FEC_VEN)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_CAPITAL, DbType.Double, cDPR_CAPITAL)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_INTERES, DbType.Double, cDPR_INTERES)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_GASTOS, DbType.Double, cDPR_GASTOS)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_IMPORTE, DbType.Double, cDPR_IMPORTE)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_CONTRAVALOR, DbType.Double, cDPR_CONTRAVALOR)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_OBSERVACIONES, DbType.String, cDPR_OBSERVACIONES)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.TDO_ID_DOC, DbType.String, cTDO_ID_DOC)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DTD_ID_DOC, DbType.String, cDTD_ID_DOC)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.CCT_ID_DOC, DbType.String, cCCT_ID_DOC)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_SERIE_DOC, DbType.String, cDPR_SERIE_DOC)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_NUMERO_DOC, DbType.String, cDPR_NUMERO_DOC)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.PER_ID_CLI_DOC, DbType.String, cPER_ID_CLI_DOC)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_FEC_GRAB, DbType.DateTime, cDPR_FEC_GRAB)
                context.AddInParameter(cmd, DetallePrestamo.PropertyNames.DPR_ESTADO, DbType.Boolean, cDPR_ESTADO)
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
