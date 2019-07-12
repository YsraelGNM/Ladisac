Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class ProduccionRepositorio
        Implements IProduccionRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal PRO_Id As Integer) As BE.Produccion Implements IProduccionRepositorio.GetById
            Dim result As Produccion = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.Produccion.Include("Ladrillo.Articulos").Include("Planta").Include("Extrusora").Include("Personas").Include("Personas1").Include("Personas2").Include("Personas3").Include("Cortadora") Where c.PRO_ID = PRO_Id Select c).FirstOrDefault
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaProduccion() As String Implements IProduccionRepositorio.ListaProduccion
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaProduccion")
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

        Public Sub Maintenance(ByVal Produccion As BE.Produccion) Implements IProduccionRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.Produccion.ApplyChanges(Produccion)
                context.SaveChanges()
                Produccion.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaControlParadasPorDia(ByVal Fecha As Date) As String Implements IProduccionRepositorio.ListaControlParadasPorDia
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaControlParadasPorDia")
                context.AddInParameter(cmd, "Fecha", DbType.Date, Fecha)
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

        Public Function ReporteFinalProduccion(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Integer?, ByVal TPR_ID As Integer?, ByVal EXT_ID As Integer?, ByVal Finalizada As Boolean?) As String Implements IProduccionRepositorio.ReporteFinalProduccion
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spReporteFinalProduccion")
                context.AddInParameter(cmd, "FecIni", DbType.Date, FecIni)
                context.AddInParameter(cmd, "FecFin", DbType.Date, FecFin)
                context.AddInParameter(cmd, "PLA_Id", DbType.Int32, PLA_ID)
                context.AddInParameter(cmd, "TPR_ID", DbType.Int32, TPR_ID)
                context.AddInParameter(cmd, "EXT_ID", DbType.Int32, EXT_ID)
                context.AddInParameter(cmd, "Finalizada", DbType.Int32, Finalizada)
                cmd.CommandTimeout = 900
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

        Public Function ListaCombustibleHorno(ByVal HOR_Id As Integer, ByVal Mes As Integer, ByVal Anio As Integer) As String Implements IProduccionRepositorio.ListaCombustibleHorno
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaCombustibleHorno")
                context.AddInParameter(cmd, "HOR_Id", DbType.Int32, HOR_Id)
                context.AddInParameter(cmd, "Mes", DbType.Int32, Mes)
                context.AddInParameter(cmd, "Anio", DbType.Int32, Anio)
                cmd.CommandTimeout = 900
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

        Public Function ReporteFinalProduccionFinalizada(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Integer?, ByVal TPR_ID As Integer?, ByVal EXT_ID As Integer?, ByVal Finalizada As Boolean) As String Implements IProduccionRepositorio.ReporteFinalProduccionFinalizada
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spReporteFinalProduccionFinalizada")
                context.AddInParameter(cmd, "FecIni", DbType.Date, FecIni)
                context.AddInParameter(cmd, "FecFin", DbType.Date, FecFin)
                context.AddInParameter(cmd, "PLA_Id", DbType.Int32, PLA_ID)
                context.AddInParameter(cmd, "TPR_ID", DbType.Int32, TPR_ID)
                context.AddInParameter(cmd, "EXT_ID", DbType.Int32, EXT_ID)
                context.AddInParameter(cmd, "Finalizada", DbType.Int32, Finalizada)
                cmd.CommandTimeout = 900
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

        Public Function ListaResumenParadas(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Pla_Id As Integer, ByVal Lad_Id As String, ByVal SinPrueba As Integer, ByVal Ext_Id As Integer) As String Implements IProduccionRepositorio.ListaResumenParadas
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaResumenParadas")
                context.AddInParameter(cmd, "FecIni", DbType.Date, FecIni)
                context.AddInParameter(cmd, "FecFin", DbType.Date, FecFin)
                context.AddInParameter(cmd, "Pla_Id", DbType.Int32, Pla_Id)
                context.AddInParameter(cmd, "Lad_Id", DbType.String, Lad_Id)
                context.AddInParameter(cmd, "SinPrueba", DbType.Int32, SinPrueba)
                context.AddInParameter(cmd, "Ext_Id", DbType.Int32, Ext_Id)
                cmd.CommandTimeout = 9000
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

        Public Function ReporteFinalProduccionComparativo(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Integer?, ByVal TPR_ID As Integer?, ByVal EXT_ID As Integer?) As String Implements IProduccionRepositorio.ReporteFinalProduccionComparativo
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spReporteFinalProduccionComparativo")
                context.AddInParameter(cmd, "FecIni", DbType.Date, FecIni)
                context.AddInParameter(cmd, "FecFin", DbType.Date, FecFin)
                context.AddInParameter(cmd, "PLA_Id", DbType.Int32, PLA_ID)
                context.AddInParameter(cmd, "TPR_ID", DbType.Int32, TPR_ID)
                context.AddInParameter(cmd, "EXT_ID", DbType.Int32, EXT_ID)
                cmd.CommandTimeout = 9000
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

        Public Function ReporteFinalProduccionDiario(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Integer?, ByVal TPR_ID As Integer?, ByVal EXT_ID As Integer?, ByVal Finalizada As Boolean?, ByVal LAD_ID As String) As String Implements IProduccionRepositorio.ReporteFinalProduccionDiario
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spReporteFinalProduccionDiario")
                context.AddInParameter(cmd, "FecIni", DbType.Date, FecIni)
                context.AddInParameter(cmd, "FecFin", DbType.Date, FecFin)
                context.AddInParameter(cmd, "PLA_Id", DbType.Int32, PLA_ID)
                context.AddInParameter(cmd, "TPR_ID", DbType.Int32, TPR_ID)
                context.AddInParameter(cmd, "EXT_ID", DbType.Int32, EXT_ID)
                context.AddInParameter(cmd, "Finalizada", DbType.Int32, Finalizada)
                context.AddInParameter(cmd, "LAD_ID", DbType.String, LAD_ID)
                cmd.CommandTimeout = 900
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

        Public Function ListaResumenParadasForma1(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Pla_Id As Integer, ByVal Lad_Id As String, ByVal SinPrueba As Integer, ByVal Ext_Id As Integer) As String Implements IProduccionRepositorio.ListaResumenParadasForma1
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaResumenParadasForma1")
                context.AddInParameter(cmd, "FecIni", DbType.Date, FecIni)
                context.AddInParameter(cmd, "FecFin", DbType.Date, FecFin)
                context.AddInParameter(cmd, "Pla_Id", DbType.Int32, Pla_Id)
                context.AddInParameter(cmd, "Lad_Id", DbType.String, Lad_Id)
                context.AddInParameter(cmd, "SinPrueba", DbType.Int32, SinPrueba)
                context.AddInParameter(cmd, "Ext_Id", DbType.Int32, Ext_Id)
                cmd.CommandTimeout = 9000
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

        Public Function ReporteSalidaSecadero(ByVal FecIni As Date, ByVal FecFin As Date, ByVal SEC_ID As Integer?) As String Implements IProduccionRepositorio.ReporteSalidaSecadero
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spReporteSalidaSecadero")
                context.AddInParameter(cmd, "FecIni", DbType.Date, FecIni)
                context.AddInParameter(cmd, "FecFin", DbType.Date, FecFin)
                context.AddInParameter(cmd, "SEC_ID", DbType.Int32, SEC_ID)
                cmd.CommandTimeout = 900
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

        Public Function ListaProduccionFecha(ByVal Fecha As Date, ByVal PLA_ID As Integer) As System.Collections.Generic.List(Of BE.Produccion) Implements IProduccionRepositorio.ListaProduccionFecha
            Dim result As List(Of Produccion) = Nothing
            Try
                'Fecha = Fecha.AddDays(-1)
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.Produccion.Include("Ladrillo.Articulos").Include("Planta").Include("Extrusora").Include("Personas").Include("Personas1").Include("Personas2").Include("Personas3").Include("Cortadora") Where c.PRO_FECHA = Fecha.Date And c.PLA_ID = PLA_ID Order By c.PRO_FECHA, c.PRO_ID Select c).ToList
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return result
        End Function

        Public Function VwProduccionByPro_Id(ByVal PRO_ID As Integer) As BE.vwReporteFinalProduccion2 Implements IProduccionRepositorio.VwProduccionByPro_Id
            Dim result As vwReporteFinalProduccion2 = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.vwReporteFinalProduccion2 Where c.PRO_ID = PRO_ID Select c).FirstOrDefault
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


