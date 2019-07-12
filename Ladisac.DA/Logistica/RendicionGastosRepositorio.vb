Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class RendicionGastosRepositorio
        Implements IRendicionGastosRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal RGA_ID As Integer) As BE.RendicionGastos Implements IRendicionGastosRepositorio.GetById
            Dim result As RendicionGastos = Nothing
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                result = (From c In context.RendicionGastos.Include("RendicionGastosDetalle").Include("Personas") Where c.RGA_ID = RGA_ID Select c).FirstOrDefault

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaRendicionGastos() As String Implements IRendicionGastosRepositorio.ListaRendicionGastos
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaRendicionGastos")
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

        Public Function Maintenance(ByVal RendicionGastos As BE.RendicionGastos) As Integer Implements IRendicionGastosRepositorio.Maintenance
            Dim Result As Integer = 0
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.RendicionGastos.ApplyChanges(RendicionGastos)
                context.SaveChanges()
                RendicionGastos.AcceptChanges()
                result = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                result = 0
            End Try
            Return Result
        End Function
    End Class

End Namespace


