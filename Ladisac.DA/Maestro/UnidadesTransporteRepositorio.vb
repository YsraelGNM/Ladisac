Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class UnidadesTransporteRepositorio
        Implements IUnidadesTransporteRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaUnidadesTransporte() As String Implements IUnidadesTransporteRepositorio.ListaUnidadesTransporte
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaUnidadesTransporte")
                Dim reader = context.ExecuteReader(cmd)
                Dim sb As New StringBuilder()
                While reader.Read()
                    sb.Append(reader.GetString(0))
                End While
                result = sb.ToString()

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function GetById(ByVal UNT_Id As String) As BE.UnidadesTransporte Implements IUnidadesTransporteRepositorio.GetById

        End Function

        Public Function Maintenance(ByVal item As BE.UnidadesTransporte) As Short Implements IUnidadesTransporteRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.UnidadesTransporte.ApplyChanges(item)
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

        Public Function spActualizarRegistro(ByVal cUNT_ID As String, ByVal cUNT_COMPORTAMIENTO As Short, ByVal cUNT_TIPO As Short, ByVal cTUN_ID As String, ByVal cMAR_ID As String, ByVal cMOD_ID As String, ByVal cUNT_TARA As Double, ByVal cUNT_NRO_INS As String, ByVal cPER_ID As String, ByVal cUNT_KILOMETRAJE As Double, ByVal cUNT_HOROMETRO As Double, ByVal cUNT_NRO_SERIE As String, ByVal cUNT_NRO_MOTOR As String, ByVal cUNT_ANIO_FABRICACION As Short, ByVal cUNT_FECHA_ADQUISICION As Date, ByVal cUSU_ID As String, ByVal cUNT_FEC_GRAB As Date, ByVal cUNT_ESTADO As Boolean) As Short Implements IUnidadesTransporteRepositorio.spActualizarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spActualizarRegistroUnidadesTransporte)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_ID, DbType.String, cUNT_ID)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_COMPORTAMIENTO, DbType.Int16, cUNT_COMPORTAMIENTO)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_TIPO, DbType.Int16, cUNT_TIPO)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.TUN_ID, DbType.String, cTUN_ID)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.MAR_ID, DbType.String, cMAR_ID)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.MOD_ID, DbType.String, cMOD_ID)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_TARA, DbType.Double, cUNT_TARA)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_NRO_INS, DbType.String, cUNT_NRO_INS)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_KILOMETRAJE, DbType.Double, cUNT_KILOMETRAJE)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_HOROMETRO, DbType.Double, cUNT_HOROMETRO)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_NRO_SERIE, DbType.String, cUNT_NRO_SERIE)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_NRO_MOTOR, DbType.String, cUNT_NRO_MOTOR)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_ANIO_FABRICACION, DbType.Int16, cUNT_ANIO_FABRICACION)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_FECHA_ADQUISICION, DbType.DateTime, cUNT_FECHA_ADQUISICION)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_FEC_GRAB, DbType.DateTime, cUNT_FEC_GRAB)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_ESTADO, DbType.Boolean, cUNT_ESTADO)
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

        Public Function spEliminarRegistro(ByVal cUNT_ID As String) As Short Implements IUnidadesTransporteRepositorio.spEliminarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spEliminarRegistroUnidadesTransporte)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_ID, DbType.String, cUNT_ID)
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

        Public Function spInsertarRegistro(ByVal cUNT_ID As String, ByVal cUNT_COMPORTAMIENTO As Short, ByVal cUNT_TIPO As Short, ByVal cTUN_ID As String, ByVal cMAR_ID As String, ByVal cMOD_ID As String, ByVal cUNT_TARA As Double, ByVal cUNT_NRO_INS As String, ByVal cPER_ID As String, ByVal cUNT_KILOMETRAJE As Double, ByVal cUNT_HOROMETRO As Double, ByVal cUNT_NRO_SERIE As String, ByVal cUNT_NRO_MOTOR As String, ByVal cUNT_ANIO_FABRICACION As Short, ByVal cUNT_FECHA_ADQUISICION As Date, ByVal cUSU_ID As String, ByVal cUNT_FEC_GRAB As Date, ByVal cUNT_ESTADO As Boolean) As Short Implements IUnidadesTransporteRepositorio.spInsertarRegistro
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand(DA.SPNames.spInsertarRegistroUnidadesTransporte)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_ID, DbType.String, cUNT_ID)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_COMPORTAMIENTO, DbType.Int16, cUNT_COMPORTAMIENTO)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_TIPO, DbType.Int16, cUNT_TIPO)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.TUN_ID, DbType.String, cTUN_ID)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.MAR_ID, DbType.String, cMAR_ID)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.MOD_ID, DbType.String, cMOD_ID)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_TARA, DbType.Double, cUNT_TARA)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_NRO_INS, DbType.String, cUNT_NRO_INS)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.PER_ID, DbType.String, cPER_ID)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_KILOMETRAJE, DbType.Double, cUNT_KILOMETRAJE)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_HOROMETRO, DbType.Double, cUNT_HOROMETRO)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_NRO_SERIE, DbType.String, cUNT_NRO_SERIE)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_NRO_MOTOR, DbType.String, cUNT_NRO_MOTOR)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_ANIO_FABRICACION, DbType.Int16, cUNT_ANIO_FABRICACION)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_FECHA_ADQUISICION, DbType.DateTime, cUNT_FECHA_ADQUISICION)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.USU_ID, DbType.String, cUSU_ID)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_FEC_GRAB, DbType.DateTime, cUNT_FEC_GRAB)
                context.AddInParameter(cmd, UnidadesTransporte.PropertyNames.UNT_ESTADO, DbType.Boolean, cUNT_ESTADO)
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


