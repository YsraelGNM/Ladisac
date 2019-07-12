Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text
Namespace Ladisac.DA
    Public Class TesoreriaExtornoRepositorio
        Implements ITesoreriaExtornoRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function spActualizarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cTEX_SERIE As String, ByVal cTEX_NUMERO As String, ByVal cTEX_FECHA_EMI As Date, ByVal cUSU_ID As String, ByVal cTEX_FEC_GRAB As Date, ByVal cTEX_ESTADO As Boolean) As Short Implements ITesoreriaExtornoRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroTesoreriaExtorno)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TEX_SERIE, DbType.String, cTEX_SERIE)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TEX_NUMERO, DbType.String, cTEX_NUMERO)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TEX_FECHA_EMI, DbType.DateTime, cTEX_FECHA_EMI)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TEX_FEC_GRAB, DbType.DateTime, cTEX_FEC_GRAB)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TEX_ESTADO, DbType.Boolean, cTEX_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cTEX_SERIE As String, ByVal cTEX_NUMERO As String) As Short Implements ITesoreriaExtornoRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroTesoreriaExtorno)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TEX_SERIE, DbType.String, cTEX_SERIE)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TEX_NUMERO, DbType.String, cTEX_NUMERO)
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

        Public Function spInsertarRegistro(ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cCCC_ID As String, ByVal cTEX_SERIE As String, ByVal cTEX_NUMERO As String, ByVal cTEX_FECHA_EMI As Date, ByVal cUSU_ID As String, ByVal cTEX_FEC_GRAB As Date, ByVal cTEX_ESTADO As Boolean) As Short Implements ITesoreriaExtornoRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroTesoreriaExtorno)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TDO_ID, DbType.String, cTDO_ID)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.DTD_ID, DbType.String, cDTD_ID)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.CCC_ID, DbType.String, cCCC_ID)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TEX_SERIE, DbType.String, cTEX_SERIE)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TEX_NUMERO, DbType.String, cTEX_NUMERO)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TEX_FECHA_EMI, DbType.DateTime, cTEX_FECHA_EMI)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TEX_FEC_GRAB, DbType.DateTime, cTEX_FEC_GRAB)
                context.AddInParameter(cmd, TesoreriaExtorno.PropertyNames.TEX_ESTADO, DbType.Boolean, cTEX_ESTADO)
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
