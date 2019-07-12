Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class TesoreriaCobranzaLegalRepositorio
        Implements ITesoreriaCobranzaLegalRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCT_ID As String, ByVal cTCL_SERIE As String, ByVal cTCL_NUMERO As String, ByVal cTCL_FECHA_EMI As Date, ByVal cPER_ID_CLI As String, ByVal cMON_ID As String, ByVal cTCL_MONTO As Decimal, ByVal cUSU_ID As String, ByVal cTCL_FEC_GRAB As Date, ByVal cTCL_ESTADO As Boolean) As Short Implements ITesoreriaCobranzaLegalRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroTesoreriaCobranzaLegal)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.CCT_ID, DbType.String, cCCT_ID)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TCL_SERIE, DbType.String, cTCL_SERIE)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TCL_NUMERO, DbType.String, cTCL_NUMERO)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TCL_FECHA_EMI, DbType.DateTime, cTCL_FECHA_EMI)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.MON_ID, DbType.String, cMON_ID)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TCL_MONTO, DbType.String, cTCL_MONTO)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TCL_FEC_GRAB, DbType.DateTime, cTCL_FEC_GRAB)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TCL_ESTADO, DbType.Boolean, cTCL_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cTCL_SERIE As String, ByVal cTCL_NUMERO As String, ByVal cPER_ID_CLI As String) As Short Implements ITesoreriaCobranzaLegalRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroTesoreriaCobranzaLegal)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TCL_SERIE, DbType.String, cTCL_SERIE)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TCL_NUMERO, DbType.String, cTCL_NUMERO)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCT_ID As String, ByVal cTCL_SERIE As String, ByVal cTCL_NUMERO As String, ByVal cTCL_FECHA_EMI As Date, ByVal cPER_ID_CLI As String, ByVal cMON_ID As String, ByVal cTCL_MONTO As Decimal, ByVal cUSU_ID As String, ByVal cTCL_FEC_GRAB As Date, ByVal cTCL_ESTADO As Boolean) As Short Implements ITesoreriaCobranzaLegalRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroTesoreriaCobranzaLegal)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.CCT_ID, DbType.String, cCCT_ID)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TCL_SERIE, DbType.String, cTCL_SERIE)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TCL_NUMERO, DbType.String, cTCL_NUMERO)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TCL_FECHA_EMI, DbType.DateTime, cTCL_FECHA_EMI)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.PER_ID_CLI, DbType.String, cPER_ID_CLI)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.MON_ID, DbType.String, cMON_ID)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TCL_MONTO, DbType.String, cTCL_MONTO)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TCL_FEC_GRAB, DbType.DateTime, cTCL_FEC_GRAB)
                context.AddInParameter(cmd, TesoreriaCobranzaLegal.PropertyNames.TCL_ESTADO, DbType.Boolean, cTCL_ESTADO)
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
