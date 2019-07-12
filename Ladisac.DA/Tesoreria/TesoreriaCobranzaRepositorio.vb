Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class TesoreriaCobranzaRepositorio
        Implements ITesoreriaCobranzaRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCT_ID As String, ByVal cTEC_SERIE As String, ByVal cTEC_NUMERO As String, ByVal cTEC_FECHA_EMI As Date, ByVal cPER_ID_CLI As String, ByVal cMON_ID As String, ByVal cTEC_MONTO As Decimal, ByVal cUSU_ID As String, ByVal cTEC_FEC_GRAB As Date, ByVal cTEC_ESTADO As Boolean) As Short Implements ITesoreriaCobranzaRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroTesoreriaCobranza)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.CCT_ID, DbType.String, cCCT_ID)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TEC_SERIE, DbType.String, cTEC_SERIE)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TEC_NUMERO, DbType.String, cTEC_NUMERO)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TEC_FECHA_EMI, DbType.DateTime, cTEC_FECHA_EMI)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.MON_ID, DbType.String, cMON_ID)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TEC_MONTO, DbType.String, cTEC_MONTO)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TEC_FEC_GRAB, DbType.DateTime, cTEC_FEC_GRAB)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TEC_ESTADO, DbType.Boolean, cTEC_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cTEC_SERIE As String, ByVal cTEC_NUMERO As String, ByVal cPER_ID_CLI As String) As Short Implements ITesoreriaCobranzaRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroTesoreriaCobranza)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TEC_SERIE, DbType.String, cTEC_SERIE)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TEC_NUMERO, DbType.String, cTEC_NUMERO)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCT_ID As String, ByVal cTEC_SERIE As String, ByVal cTEC_NUMERO As String, ByVal cTEC_FECHA_EMI As Date, ByVal cPER_ID_CLI As String, ByVal cMON_ID As String, ByVal cTEC_MONTO As Decimal, ByVal cUSU_ID As String, ByVal cTEC_FEC_GRAB As Date, ByVal cTEC_ESTADO As Boolean) As Short Implements ITesoreriaCobranzaRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroTesoreriaCobranza)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.CCT_ID, DbType.String, cCCT_ID)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TEC_SERIE, DbType.String, cTEC_SERIE)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TEC_NUMERO, DbType.String, cTEC_NUMERO)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TEC_FECHA_EMI, DbType.DateTime, cTEC_FECHA_EMI)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.MON_ID, DbType.String, cMON_ID)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TEC_MONTO, DbType.String, cTEC_MONTO)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TEC_FEC_GRAB, DbType.DateTime, cTEC_FEC_GRAB)
                context.AddInParameter(cmd, TesoreriaCobranza.PropertyNames.TEC_ESTADO, DbType.Boolean, cTEC_ESTADO)
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
