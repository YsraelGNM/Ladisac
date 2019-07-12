Option Strict On

Imports System.Text

Namespace Ladisac.DA
    Public Class ReportesRepositorio
        Implements IReportesRepositorio

        Public Function EjecutarReporte(ByVal report As String, ByVal ParamArray params() As Object) As String Implements IReportesRepositorio.EjecutarReporte
            Dim result As String = Nothing
            Try

                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                'Dim reader = context.ExecuteReader(report, params)

                Dim cmd = context.GetStoredProcCommand(report, params)
                cmd.CommandTimeout = 2000
                Dim reader = context.ExecuteReader(cmd)

                Dim sb As New StringBuilder()
                While reader.Read()
                    sb.Append(reader.GetString(0))
                End While
                result = sb.ToString()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.DataAccess)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function EjecutarReporteTable(ByVal report As String, ByVal ParamArray params() As Object) As System.Data.DataTable Implements IReportesRepositorio.EjecutarReporteTable
            Dim result As DataTable = Nothing
            Try

                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                'Dim reader = context.ExecuteReader(report, params)

                Dim cmd = context.GetStoredProcCommand(report, params)
                cmd.CommandTimeout = 2000
                result = context.ExecuteDataSet(cmd).Tables(0)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.DataAccess)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
    End Class
End Namespace

