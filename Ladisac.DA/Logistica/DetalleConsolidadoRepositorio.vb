Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Text

Namespace Ladisac.DA

    Public Class DetalleConsolidadoRepositorio
        Implements IDetalleConsolidadoRepositorio
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GetById(ByVal PRC_ID As Integer) As BE.DetalleConsolidado Implements IDetalleConsolidadoRepositorio.GetById
            Dim result As DetalleConsolidado = Nothing
            'Try
            '    Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
            '    result = (From c In context.DetalleConsolidado.Include("DetalleConsolidado") Where c. = PCD_ID Select c).FirstOrDefault
            'Catch ex As Exception
            '    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
            '    If (rethrow) Then
            '        Throw
            '    End If
            'End Try
            Return result
        End Function

        Public Function ListaDetalleConsolidado() As String Implements IDetalleConsolidadoRepositorio.ListaDetalleConsolidado
            Dim result As String = Nothing
            Try
                Dim context = EnterpriseLibraryContainer.Current.GetInstance(Of Database)()
                Dim cmd = context.GetStoredProcCommand("spListaDetalleConsolidado")
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

        Public Sub Maintenance(ByVal DetalleConsolidado As BE.DetalleConsolidado) Implements IDetalleConsolidadoRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.DetalleConsolidado.ApplyChanges(DetalleConsolidado)
                context.SaveChanges()
                DetalleConsolidado.AcceptChanges()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
    End Class

End Namespace


