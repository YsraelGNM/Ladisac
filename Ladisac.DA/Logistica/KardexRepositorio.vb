Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class kardexRepositorio
        Implements IKardexRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal KAR_Id As Integer) As BE.Kardex Implements IKardexRepositorio.GetById
            Dim result As Kardex = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.Kardex Where c.KAR_ID = KAR_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub Maintenance(ByVal Kardex As BE.Kardex) Implements IKardexRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.Kardex.ApplyChanges(Kardex)
                context.SaveChanges()
                Kardex.AcceptChanges()
            Catch ex As Exception
                MsgBox(ex.Message)
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaKardex(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Integer, ByVal ART_Id As String) As String Implements IKardexRepositorio.ListaKardex
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaKardex")
                context.AddInParameter(cmd, "FecIni", DbType.Date, FecIni)
                context.AddInParameter(cmd, "FecFin", DbType.Date, FecFin)
                context.AddInParameter(cmd, "ALm_Id", DbType.Int32, Alm_Id)
                context.AddInParameter(cmd, "Art_Id", DbType.String, ART_Id)
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

        Public Sub RehacerKardex(ByVal ART_Id As String, ByVal Alm_Id As Integer, ByVal Fecha As Date) Implements IKardexRepositorio.RehacerKardex
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spRehacerKardex")
                cmd.CommandTimeout = 2000
                context.AddInParameter(cmd, "Art_Id", DbType.String, ART_Id)
                context.AddInParameter(cmd, "ALm_Id", DbType.Int32, Alm_Id)
                context.AddInParameter(cmd, "Fecha", DbType.Date, Fecha)
                context.ExecuteNonQuery(cmd)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function StockCostoPromedio(ByVal ART_Id As String, ByVal Alm_Id As Integer, ByVal Fecha As Date, ByVal Flag As Integer) As Decimal Implements IKardexRepositorio.StockCostoPromedio
            Dim result As Decimal = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.spStockxFecha(ART_Id, Alm_Id, Fecha, Flag) Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDocOperacion(ByVal IngresoSalida As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal ALM_ID As Integer?, ByVal ART_Id As String) As String Implements IKardexRepositorio.ListaDocOperacion
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaDocOperacion")
                context.AddInParameter(cmd, "IngresoSalida", DbType.Int32, IngresoSalida)
                context.AddInParameter(cmd, "FecIni", DbType.Date, FecIni)
                context.AddInParameter(cmd, "FecFin", DbType.Date, FecFin)
                context.AddInParameter(cmd, "ALM_ID", DbType.Int32, ALM_ID)
                context.AddInParameter(cmd, "ART_ID", DbType.String, ART_Id)
                cmd.CommandTimeout = 1900
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
    End Class

End Namespace


