Option Strict On
'Imports Microsoft.Practices.Unity
'Imports Ladisac.BE
'
Imports System.Text
Namespace Ladisac.DA
    Public Class MaestroRepositorio
        Implements IMaestroRepositorio

        '<Dependency()> _
        'Public Property ContainerService As IUnityContainer

        Public Function EjecutarVista(ByVal vista As String, ByVal ParamArray params() As Object) As String Implements IMaestroRepositorio.EjecutarVista
            EjecutarVista = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

                Dim cmd = context.GetStoredProcCommand(vista, params)
                cmd.CommandTimeout = 0

                'Dim reader = context.ExecuteReader(vista, params)
                Dim reader = context.ExecuteReader(cmd)

                Dim sb As New StringBuilder()
                While reader.Read()
                    sb.Append(reader.GetString(0))
                End While
                EjecutarVista = sb.ToString()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.DataAccess)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return EjecutarVista
        End Function


        'Public Function EjecutarProcedure(ByVal Procedure As String, ByVal Cantidad As Int16, ByVal Filtro As String) As String Implements IMaestrosRepositorio.EjecutarProcedure
        '    EjecutarProcedure = Nothing
        '    Try
        '        Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

        '        Dim cmd = context.GetStoredProcCommand(Procedure)
        '        context.AddInParameter(cmd, "CANTIDAD", DbType.Int16, Cantidad)
        '        context.AddInParameter(cmd, "FILTRO", DbType.String, Filtro)
        '        Dim reader = context.ExecuteReader(cmd)
        '        Dim sb As New StringBuilder()
        '        While reader.Read()
        '            sb.Append(reader.GetString(0))
        '        End While
        '        EjecutarProcedure = sb.ToString()
        '    Catch ex As Exception
        '        Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
        '        If (rethrow) Then
        '            Throw
        '        End If
        '    End Try
        'End Function


        Public Function EjecutarPendientesAtencion(ByVal Procedimiento As String, ByVal ParamArray params() As Object) As String Implements IMaestroRepositorio.EjecutarPendientesAtencion
            EjecutarPendientesAtencion = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()

                Dim cmd = context.GetStoredProcCommand(Procedimiento, params)
                cmd.CommandTimeout = 0
                Dim reader = context.ExecuteReader(cmd)
                Dim sb As New StringBuilder()
                While reader.Read()
                    sb.Append(reader.GetString(0))
                End While
                EjecutarPendientesAtencion = sb.ToString()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Function
    End Class
End Namespace
