Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA

    Public Class PlacasRepositorio
        Implements IPlacasRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.Placas) As Short Implements IPlacasRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.Placas.ApplyChanges(item)
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

        Public Function spActualizarRegistro(ByVal cPLA_ID As String, ByVal cUNT_ID_1 As String, ByVal cUNT_ID_2 As String, ByVal cPER_ID As String, ByVal cUSU_ID As String, ByVal cPLA_FEC_GRAB As Date, ByVal cPLA_ESTADO As Boolean) As Short Implements IPlacasRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroPlacas)
                context.AddInParameter(cmd, Placas.PropertyNames.PLA_ID, DbType.String, cPLA_ID)
                context.AddInParameter(cmd, Placas.PropertyNames.UNT_ID_1, DbType.String, cUNT_ID_1)
                context.AddInParameter(cmd, Placas.PropertyNames.UNT_ID_2, DbType.String, cUNT_ID_2)
                context.AddInParameter(cmd, Placas.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, Placas.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, Placas.PropertyNames.PLA_FEC_GRAB, DbType.DateTime, cPLA_FEC_GRAB)
                context.AddInParameter(cmd, Placas.PropertyNames.PLA_ESTADO, DbType.Boolean, cPLA_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cPLA_ID As String) As Short Implements IPlacasRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroPlacas)
                context.AddInParameter(cmd, Placas.PropertyNames.PLA_ID, DbType.String, cPLA_ID)
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

        Public Function spInsertarRegistro(ByVal cPLA_ID As String, ByVal cUNT_ID_1 As String, ByVal cUNT_ID_2 As String, ByVal cPER_ID As String, ByVal cUSU_ID As String, ByVal cPLA_FEC_GRAB As Date, ByVal cPLA_ESTADO As Boolean) As Short Implements IPlacasRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroPlacas)
                context.AddInParameter(cmd, Placas.PropertyNames.PLA_ID, DbType.String, cPLA_ID)
                context.AddInParameter(cmd, Placas.PropertyNames.UNT_ID_1, DbType.String, cUNT_ID_1)
                context.AddInParameter(cmd, Placas.PropertyNames.UNT_ID_2, DbType.String, cUNT_ID_2)
                context.AddInParameter(cmd, Placas.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, Placas.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, Placas.PropertyNames.PLA_FEC_GRAB, DbType.DateTime, cPLA_FEC_GRAB)
                context.AddInParameter(cmd, Placas.PropertyNames.PLA_ESTADO, DbType.Boolean, cPLA_ESTADO)
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